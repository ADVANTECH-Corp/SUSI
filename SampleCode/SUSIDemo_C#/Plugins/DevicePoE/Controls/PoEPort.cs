using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class PoEPort : UserControl
    {
        private static readonly List<string> DetectionStatus = new List<string>()
        {
            "Unknown",
            "PD Error",
            "PD Error",
            "PD Error",
            "Detected Good",
            "PD Error",
            "Detect Open",
            "PD Error"
        };

        private static readonly List<string> ClassificationStatus = new List<string>()
        {
            "Class Unknown",
            "Class 1",
            "Class 2",
            "Class 3",
            "Class 4",
            "Error",
            "Class 0",
            "OverCurrent"
        };

        private UInt32 _portNum;
        private UInt32 _isEnable;

        // IDs
        private UInt32 _classID;
        private UInt32 _currentID;
        private UInt32 _detectionID;
        private UInt32 _powerID;
        private UInt32 _voltID;

        public PoEPort(UInt32 portNum)
        {
            _portNum = portNum;
            _detectionID = Lib.POE_ID_DETECT_BASE + _portNum;
            _classID = Lib.POE_ID_CLASS_BASE + _portNum;
            _voltID = Lib.POE_ID_VOLTAGE_BASE + _portNum;
            _currentID = Lib.POE_ID_CURRENT_BASE + _portNum;
            _powerID = Lib.POE_ID_PORT_POWER_BASE + _portNum;

            InitializeComponent();
            UInt32 status = Lib.SusiDeviceGetValue(_powerID, out _isEnable);
            if (status != SusiStatus.SUSI_STATUS_SUCCESS)
            {
                MessageBox.Show(String.Format("Cannot Get Initial Info.  (0x{0:X8})", status));
            }
            groupBox_PoE1.Text = "PoE " + (portNum + 1);
        }

        private void checkBox_Enable1_CheckedChanged(object sender, EventArgs e)
        {
            int toSetEnable = ((CheckBox)sender).Checked? 1 : 0;
            if (_isEnable != toSetEnable)
            {
                _isEnable = (UInt32)toSetEnable;
                UInt32 status = Lib.SusiDeviceSetValue(_powerID, _isEnable);
                if (status != SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    MessageBox.Show(String.Format("Cannot Set PortPower.  (0x{0:X8})", status));
                }
            }
        }

        public void update()
        {
            UInt32 status, value;

            status = Lib.SusiDeviceGetValue(_powerID, out _isEnable);
            checkBox_Enable1.Checked = (_isEnable == 1);

            if (checkBox_Enable1.Checked)
            {
                status = Lib.SusiDeviceGetValue(_detectionID, out value);
                label_detectValue1.Text = DetectionStatus[(int)value];

                status = Lib.SusiDeviceGetValue(_classID, out value);
                label_classValue1.Text = ClassificationStatus[(int)value];

                status = Lib.SusiDeviceGetValue(_voltID, out value);
                label_voltageValue1.Text = String.Format("{0:00.00} V", (double)value / 1000);

                status = Lib.SusiDeviceGetValue(_currentID, out value);
                label_currentValue1.Text = String.Format("{0:00.00} mA", (double)value / 1000);
            }
            else
            {                
                label_detectValue1.Text = DetectionStatus[0];                
                label_classValue1.Text = ClassificationStatus[0];                
                label_voltageValue1.Text = String.Format("{0:00.00} V", (double)0 / 1000);                
                label_currentValue1.Text = String.Format("{0:00.00} mA", (double)0 / 1000);
            }
        }
    }
}
