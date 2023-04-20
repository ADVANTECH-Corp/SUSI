using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Susi4.Libraries
{
    public class EZini : Dictionary<string, IniSection>
    {
        private List<string> newIniContent = new List<string>();
        private string[] oldInilines = new string[0];
        private int EmptyLineCount = 0;
        private string[] newKeys = new string[0];
        private string _FileName;
        private Mutex hMutex = new Mutex();

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public EZini(string file)
        {
            _FileName = file;
        }

        private string Add(string line)
        {
            line = GetSectionName(line);
            this.Add(line, new IniSection());
            return line;
        }

        #region File process
        private string GetSectionName(string line)
        {
            line = line.TrimStart('[');
            line = line.TrimEnd(']');
            return line;
        }

        private bool IsComment(string line)
        {
            if (line.StartsWith(";") || line.StartsWith("#"))
                return true;

            return false;
        }

        private bool IsSection(string line)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
                return true;
            return false;
            //return Regex.IsMatch(line, "\\[|\\]");
        }

        // For write ini file
        private string[] GetSectionsNotExistInFile(string[] iniContent)
        {
            List<string> newSections = new List<string>();
            string section;
            bool isFound;

            foreach (string s in this.GetSections())
            {
                isFound = false;

                foreach (string line in iniContent)
                {
                    if (!IsSection(line))
                        continue;

                    section = GetSectionName(line);
                    if (section == s)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                    newSections.Add(s);
            }

            return newSections.ToArray();
        }

        private string[] GetKeysNotExistInFile(string currentSection, int startindex)
        {
            List<string> oldKeys = new List<string>();
            List<string> newKeys = new List<string>();
            int index;
            bool isFound;

            if (!this.HasSection(currentSection))
                return new string[0];

            for (int i = startindex; i < oldInilines.Length; i++)
            {
                if (IsComment(oldInilines[i]))
                    continue;

                if (IsSection(oldInilines[i]))   // Leave when found next section
                    break;
                else if ((index = oldInilines[i].IndexOf('=')) != -1)
                {
                    string key = oldInilines[i].Substring(0, index);
                    oldKeys.Add(key);
                }
            }
            
            foreach (string nk in this[currentSection].GetKeys())
            {
                isFound = false;

                foreach (string ok in oldKeys)
                {
                    if (nk == ok)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    newKeys.Add(nk);
                }
            }

            return newKeys.ToArray();
        }

        private void CreateIniFile()
        {
            if (!Exists())
            {
                FileStream newFile = File.Create(_FileName);
                newFile.Close();
            }
        }

        private string[] LoadIniFileToLines()
        {
            if (Exists())
            {
                StreamReader oldIni = new StreamReader(_FileName);
                string[] lines = oldIni.ReadToEnd().Split('\n');
                oldIni.Close();

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].TrimEnd('\r');
                }

                return lines;
            }

            return new string[0];
        }

        private void AddNewLines()
        {
            for (int i = 0; i < EmptyLineCount; i++)
            {
                newIniContent.Add("");
            }

            EmptyLineCount = 0;
        }

        private void AddNewSections()
        {
            string[] newSections = GetSectionsNotExistInFile(oldInilines);

            if (newSections.Length > 0)
            {
                if (newIniContent.Count > 0 && newIniContent[newIniContent.Count - 1].Trim() != "")
                    newIniContent.Add("");
            }

            // Set new sections and keys in end of file
            foreach (string nSec in newSections)
            {
                newIniContent.Add(String.Format("[{0}]", nSec));

                foreach (string key in this[nSec].Keys)
                {
                    newIniContent.Add(String.Format("{0}={1}", key, this[nSec][key]));
                }

                newIniContent.Add("");
            }
        }

        private void AddNewKeys(string currentSection)
        {
            if (newKeys.Length > 0)
            {
                foreach (string nKey in newKeys)
                {
                    newIniContent.Add(String.Format("{0}={1}", nKey, this[currentSection][nKey]));
                }
            }
        }

        private void WriteIniFile()
        {
            CreateIniFile();
            StreamWriter sw = new StreamWriter(_FileName);
            sw.Write(String.Join("\r\n", newIniContent.ToArray()));
            sw.Close();
        }
        #endregion

        public bool Load()
        {
            if (!this.Exists())
                return true;

            string section = "";

            try
            {
                StreamReader sr = new StreamReader(_FileName);

                while (sr.Peek() != -1)
                {
                    string read = sr.ReadLine().Trim();

                    if (IsComment(read))
                        continue;

                    if (read.Length == 0)
                        continue;

                    if (IsSection(read))
                    {
                        section = Add(read);
                    }
                    else
                    {
                        if (section.Length != 0)
                            this[section].Add(read);
                        else
                            throw new Exception("Ini file must start with a section.");
                    }
                }

                sr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save()
        {
            int index;
            newKeys = new string[0];
            string section = "";
            string appendline;

            try
            {
                hMutex.WaitOne();

                newIniContent.Clear();
                oldInilines = LoadIniFileToLines();

                for (int i = 0; i < oldInilines.Length; i++)
                {
                    string line = oldInilines[i].Trim();
                    appendline = oldInilines[i];


                    if (line.Length == 0)
                    {
                        EmptyLineCount++;
                        continue;
                    }
                    else if (IsComment(line))
                    {
                        ;
                    }
                    else if (IsSection(line))
                    {
                        AddNewKeys(section);
                        AddNewLines();

                        section = GetSectionName(line);
                        newKeys = GetKeysNotExistInFile(section, i + 1);
                    }
                    else if ((index = line.IndexOf('=')) != -1)   // key part
                    {
                        string key = line.Substring(0, index);

                        if (this[section].HasKey(key))
                        {
                            appendline = String.Format("{0}={1}", key, this[section][key]);
                        }

                        AddNewLines();
                    }

                    newIniContent.Add(appendline);
                }

                AddNewKeys(section);
                AddNewLines();
                AddNewSections();
                WriteIniFile();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                hMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Tells you whether or not this specific INI file exists or not.
        /// </summary>
        /// <returns>True if it is found, false if it is not.</returns>
        public bool Exists()
        {
            if (File.Exists(_FileName))
                return true;

            return false;
        }

        /// <summary>
        /// Deletes the INI file.
        /// </summary>
        /// <returns>True if the file was deleted without error, false if an exception was thrown.</returns>
        public bool DeleteFile()
        {
            try
            {
                File.Delete(_FileName);
                this.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Moves the INI file to a different location and updates all internal references to it.
        /// </summary>
        /// <param name="path">The place to move it to.</param>
        /// <returns>True if the file was moved without error, false if an exception was thrown.</returns>
        public bool MoveFile(string path)
        {
            try
            {
                File.Move(_FileName, path);
                _FileName = path;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string[] GetSections()
        {
            string[] output = new string[this.Count];
            int i = 0;

            foreach (KeyValuePair<string, IniSection> item in this)
            {
                output[i] = item.Key;
                i++;
            }
            return output;
        }

        public bool HasSection(string section)
        {
            foreach (KeyValuePair<string, IniSection> item in this)
            {
                if (item.Key == section)
                    return true;
            }
            return false;
        }
    }

    public class IniSection : Dictionary<string, string>
    {
        public void Add(string line)
        {
            if (line.Length != 0)
            {
                int index = line.IndexOf('=');

                if (index != -1)
                    base.Add(line.Substring(0, index), line.Substring(index + 1, line.Length - index - 1));
                else
                    throw new Exception("Keys must have an equal sign.");
            }
        }

        public string ToString(string key)
        {
            return key + "=" + this[key];
        }

        public string[] GetKeys()
        {
            string[] output = new string[this.Count];
            int i = 0;

            foreach (KeyValuePair<string, string> item in this)
            {
                output[i] = item.Key;
                i++;
            }
            return output;
        }

        public bool HasKey(string key)
        {
            foreach (KeyValuePair<string, string> item in this)
            {
                if (item.Key == key)
                    return true;
            }

            return false;
        }
    }
}
