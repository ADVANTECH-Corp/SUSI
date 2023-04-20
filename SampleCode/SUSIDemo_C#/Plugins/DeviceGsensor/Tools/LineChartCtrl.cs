using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LineChartCtrl
{
    public partial class LineChartCtrl : UserControl
    {
        #region Local variables

        int m_nGridWidth = 10;
        int m_nGridHeight = 10;

        float m_fValueMinimum = 0;
        float m_fValueMaximum = 100;
        float m_threadLine = 0;
        int m_nValueInterval = 1;

        int m_GridShift = 0;

        List<float> m_l1Data = new List<float>();
        List<float> m_l2Data = new List<float>();
        List<float> m_l3Data = new List<float>();

        Color m_cLine1 = Color.LimeGreen;
        Color m_cLine2 = Color.Pink;
        Color m_cLine3 = Color.Yellow;

        #endregion

        #region Public variables

        public int GridWidth
        {
            set { if (value >= 0) m_nGridWidth = value; }
            get { return m_nGridWidth; }
        }

        public int GridHeight
        {
            set { if (value >= 0) m_nGridHeight = value; }
            get { return m_nGridHeight; }
        }

        public float ValueMinimum
        {
            set { m_fValueMinimum = value; }
            get { return m_fValueMinimum; }
        }

        public float ValueMaximum
        {
            set { m_fValueMaximum = value; }
            get { return m_fValueMaximum; }
        }

        public float ThreadLine
        {
            set { m_threadLine = value; }
            get { return m_threadLine; }
        }

        public int ValueInterval
        {
            set
            {
                m_nValueInterval = value;
            }
        }

        public Color Lin11Color
        {
            get { return m_cLine1; }
            set { m_cLine1 = value; }
        }

        public Color Lin12Color
        {
            get { return m_cLine2; }
            set { m_cLine2 = value; }
        }

        public Color Lin13Color
        {
            get { return m_cLine3; }
            set { m_cLine3 = value; }
        }
        #endregion

        public LineChartCtrl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public bool AddData(float fValue)
        {
            if (m_l1Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l1Data.RemoveAt(0);

            m_l1Data.Add(fValue);
            m_GridShift = (m_GridShift + m_nValueInterval) % m_nGridWidth;

            this.Invalidate();
            return true;
        }

        public bool AddData(float fValue, float fValue2)
        {
            //if (fValue < m_fValueMinimum || fValue > m_fValueMaximum)
            //    return false;

            if (m_l1Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l1Data.RemoveAt(0);

            if (m_l2Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l2Data.RemoveAt(0);

            m_l1Data.Add(fValue);
            m_l2Data.Add(fValue2);
            m_GridShift = (m_GridShift + m_nValueInterval) % m_nGridWidth;

            this.Invalidate();
            return true;
        }

        public bool AddData(float fValue, float fValue2, float fValue3)
        {
            //if (fValue < m_fValueMinimum || fValue > m_fValueMaximum)
            //    return false;

            if (m_l1Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l1Data.RemoveAt(0);

            if (m_l2Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l2Data.RemoveAt(0);

            if (m_l3Data.Count > (ClientSize.Width / m_nValueInterval))
                m_l3Data.RemoveAt(0);

            m_l1Data.Add(fValue);
            m_l2Data.Add(fValue2);
            m_l3Data.Add(fValue3);
            m_GridShift = (m_GridShift + m_nValueInterval) % m_nGridWidth;

            this.Invalidate();
            return true;
        }

        public bool ClearData()
        {
            m_l1Data.Clear();
            m_l2Data.Clear();
            m_l3Data.Clear();
            Invalidate();
            return true;
        }

        private void LineChartCtrl_Paint(object sender, PaintEventArgs e)
        {
            if (this.BackgroundImage == null)
            {
                #region Draw background
                Brush brush = new SolidBrush(Color.Black);
                e.Graphics.FillRectangle(brush, ClientRectangle);
                #endregion

                #region Draw grid
                Pen penGrid = new Pen(Color.Green);
                for (int x = m_nGridWidth - m_GridShift; x < ClientRectangle.Right; x += m_nGridWidth)
                    e.Graphics.DrawLine(penGrid, x, 0, x, ClientRectangle.Bottom);

                for (int y = ClientRectangle.Bottom; y > 0; y -= m_nGridHeight)
                    e.Graphics.DrawLine(penGrid, 0, y, ClientRectangle.Right, y);
                #endregion
            }
            #region Draw ThresholdLine

            Pen penThreshold = new Pen(Color.Yellow);
            e.Graphics.DrawLine(penThreshold, 0,
                                ClientSize.Height - (int)((ThreadLine / m_fValueMaximum) * ClientSize.Height), 
                                ClientRectangle.Right,
                                ClientSize.Height - (int)((ThreadLine / m_fValueMaximum) * ClientSize.Height));
            
            #endregion

            #region Draw curve

            if (m_l1Data.Count > 1)
            {
                Pen penData = new Pen(m_cLine1, 2);
                Pen penData2 = new Pen(m_cLine2, 2);
                Pen penData3 = new Pen(m_cLine3, 2);

                int DrawCount = 0;
                for (int i = m_l1Data.Count - 2; i >= 0; i--)
                {
                    e.Graphics.DrawLine(penData,
                        ClientSize.Width - (DrawCount + 1) * m_nValueInterval,
                        ClientSize.Height - (int)((m_l1Data[i] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height),
                        ClientSize.Width - DrawCount * m_nValueInterval,
                        ClientSize.Height - (int)((m_l1Data[i + 1] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height));

                    if (m_l2Data.Count > 0)
                    {
                        e.Graphics.DrawLine(penData2,
                            ClientSize.Width - (DrawCount + 1) * m_nValueInterval,
                            ClientSize.Height - (int)((m_l2Data[i] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height),
                            ClientSize.Width - DrawCount * m_nValueInterval,
                            ClientSize.Height - (int)((m_l2Data[i + 1] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height));
                    }

                    if (m_l3Data.Count > 0)
                    {
                        e.Graphics.DrawLine(penData3,
                            ClientSize.Width - (DrawCount + 1) * m_nValueInterval,
                            ClientSize.Height - (int)((m_l3Data[i] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height),
                            ClientSize.Width - DrawCount * m_nValueInterval,
                            ClientSize.Height - (int)((m_l3Data[i + 1] - m_fValueMinimum) / (m_fValueMaximum - m_fValueMinimum) * ClientSize.Height));
                    }

                    DrawCount++;
                }
            }

            #endregion
        }
    }
}
