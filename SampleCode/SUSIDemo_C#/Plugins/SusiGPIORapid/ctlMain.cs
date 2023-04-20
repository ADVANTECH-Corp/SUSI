using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using Susi4.APIs;

namespace Susi4.Plugin
{
    public partial class ctlMain : UserControl
    {
        const int MAX_BANK_NUM = 4;
        const int GRID_MODE_VERTICAL = 0;
        const int GRID_MODE_HORIZONTAL = 1;

        const int GRID_COLUMN_GPIONAME = 0;
        const int GRID_COLUMN_GPIODIR = 1;
        const int GRID_COLUMN_GPIOSTATUS = 2;

        List<DeviceInfo> DevList = new List<DeviceInfo>();
        List<DevPinInfo> DevPinList = new List<DevPinInfo>();
        List<DevPinStatus> DevPinStatusList = new List<DevPinStatus>();

        int GridMode_Vertical = GRID_MODE_VERTICAL;
        int TagLED_Lo48 = 0;
        int TagLED_Hi48 = 1;
        int TagSW_Off48 = 2;
        int TagSW_On48 = 3;
        int TagDir_InPin48 = 4;
        int TagDir_OutPin48 = 5;

        class DeviceInfo
        {
            public UInt32 ID;
            public UInt32 SupportInput;
            public UInt32 SupportOutput;

            public DeviceInfo(UInt32 DeviceID)
            {
                ID = DeviceID;
                SupportInput = 0;
                SupportOutput = 0;
            }
        }

        public class DevPinInfo
        {
            public UInt32 ID;

            private string _Name = "";
            public string Name
            {
                get { return _Name; }
            }

            override public string ToString()
            {
                return String.Format("{0} ({1})", ID, Name);
            }

            public DevPinInfo(UInt32 DeviceID)
            {
                ID = DeviceID;

                UInt32 Length = 32;
                StringBuilder sb = new StringBuilder((int)Length);
                if (SusiBoard.SusiBoardGetStringA(SusiBoard.SUSI_ID_MAPPING_GET_NAME_GPIO(ID), sb, ref Length) == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                    _Name = sb.ToString();
                }
            }
        }


        public class DevPinStatus : DevPinInfo
        {
            private UInt32 _Direction = 0;
            private UInt32 _Level = 0;

            public UInt32 Direction
            {
                get
                {
                    UInt32 Status = SusiGPIO.SusiGPIOGetDirection(ID, 1, out _Direction);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                    }
                    else
                    {
                        MessageBox.Show(String.Format("SusiGPIOGetDirection() failed. (0x{0:X8})", Status));
                    }
                    return _Direction;
                }

                set
                {
                    UInt32 Status = SusiGPIO.SusiGPIOSetDirection(ID, 1, value);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        _Direction = value;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("SusiGPIOSetDirection() failed. (0x{0:X8})", Status));
                    }
                }

            }

            public UInt32 Level
            {
                get {
                    UInt32 Status = SusiGPIO.SusiGPIOGetLevel(ID, 1, out _Level);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                    }
                    else
                    {
                        MessageBox.Show(String.Format("SusiGPIOGetLevel() failed. (0x{0:X8})", Status));
                    }
                    return _Level;
                }

                set
                {
                    UInt32 Status = SusiGPIO.SusiGPIOSetLevel(ID, 1, value);
                    if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                    {
                        _Level = value;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("SusiGPIOSetLevel() failed. (0x{0:X8})", Status));
                    }
                }
            }

            public DevPinStatus(UInt32 DeviceID)
                : base(DeviceID)

            {
                UInt32 Status = SusiGPIO.SusiGPIOGetDirection(ID, 1, out _Direction);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                }
                else
                {
                    MessageBox.Show(String.Format("SusiGPIOGetDirection() failed. (0x{0:X8})", Status));
                }


                Status = SusiGPIO.SusiGPIOGetLevel(ID, 1, out _Level);
                if (Status == SusiStatus.SUSI_STATUS_SUCCESS)
                {
                }
                else
                {
                    MessageBox.Show(String.Format("SusiGPIOGetLevel() failed. (0x{0:X8})", Status));
                }
            }
        }



        public bool Available
        {
            get { return (DevList.Count > 0); }
        }

        public ctlMain()
        {
            try
            {
                UInt32 Status = SusiLib.SusiLibInitialize();

                if (Status != SusiStatus.SUSI_STATUS_SUCCESS && Status != SusiStatus.SUSI_STATUS_INITIALIZED)
                    return;
            }
            catch
            {
                return;
            }

            InitializeComponent();
            InitializeGPIO();
            InitializePins();

            if (GridMode_Vertical == GRID_MODE_VERTICAL)
            {
                InitializeGrid();
            }
            else
            {
                InitializeGrid_HorMode();
            }


        }

        ~ctlMain()
        {
            DevList = null;
            DevPinList = null;
            DevPinStatusList = null;
        }

        private void PageGPIORapid_Load(object sender, EventArgs e)
        {
            timer_statusupdating.Enabled = true;
        }


        private void InitializeGPIO()
        {
            UInt32 Status;

            for (int i = 0; i < MAX_BANK_NUM; i++)
            {
                DeviceInfo info = new DeviceInfo(SusiGPIO.SUSI_ID_GPIO_BANK((UInt32)i));

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_INPUT_SUPPORT, out info.SupportInput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                Status = SusiGPIO.SusiGPIOGetCaps(info.ID, SusiGPIO.SUSI_ID_GPIO_OUTPUT_SUPPORT, out info.SupportOutput);
                if (Status != SusiStatus.SUSI_STATUS_SUCCESS)
                    continue;

                DevList.Add(info);
            }

            if (DevList.Count > 0)
            {
            }
        }

        private void InitializePins()
        {
            StringBuilder sb = new StringBuilder(32);
            UInt32 mask;

            for (int i = 0; i < DevList.Count; i++)
            {
                // 32 pins per bank
                for (int j = 0; j < 32; j++)
                {
                    mask = (UInt32)(1 << j);
                    if ((DevList[i].SupportInput & mask) > 0 || (DevList[i].SupportOutput & mask) > 0)
                    {
                        DevPinInfo pinInfo = new DevPinInfo((UInt32)((i << 5) + j));
                        DevPinList.Add(pinInfo);

                        DevPinStatus pinStatus = new DevPinStatus((UInt32)((i << 5) + j));
                        DevPinStatusList.Add(pinStatus);
                    }
                }
            }

            if (DevList.Count > 0)
            {
                //comboBox_PinNum.SelectedIndex = 0;
            }
        }


        private void InitializeGrid()
        {
            gpioGridView.Rows.Add(DevPinStatusList.Count);

            for (int i = 0; i < DevPinStatusList.Count; i++)
            {
                gpioGridView.Rows[i].Cells[GRID_COLUMN_GPIONAME].Value = DevPinStatusList[i].Name.ToString();

                gpioGridView.Rows[i].Cells[2].Tag = TagLED_Lo48;


                if (DevPinStatusList[i].Direction == 1)
                {
                    gpioGridView.Rows[i].Cells[1].Tag = TagDir_InPin48;
                    gpioGridView.Rows[i].Cells[1].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48;
                    gpioGridView.Rows[i].Cells[2].Value = (DevPinStatusList[i].Level == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Lo48;
                }
                else
                {
                    gpioGridView.Rows[i].Cells[1].Tag = TagDir_OutPin48;
                    gpioGridView.Rows[i].Cells[1].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;
                    gpioGridView.Rows[i].Cells[2].Value = (DevPinStatusList[i].Level == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_SW_On48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_SW_Off48;

                }
            }
        }

        private void InitializeGrid_HorMode()
        {
            int r = 0;
            int i = 0;
            while (true)
            {
                if (i >= DevPinStatusList.Count)
                {
                    break;
                }

                gpioGridView.Rows.Add(1);

                for (int gpioGrid = 0; gpioGrid < 4; gpioGrid++)
                {
                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 0].Value = DevPinStatusList[i].Name.ToString();
                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 1].Value = (DevPinStatusList[i].Direction == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;

                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 2].Value = (DevPinStatusList[i].Level == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Lo48;


                    i++;
                }
                r++;
            }
        }


        private void gpioGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            Int32 pinIndex;
            if (GridMode_Vertical == GRID_MODE_VERTICAL)
            {
                pinIndex = e.RowIndex;
            }
            else
            {
                pinIndex = (Int32)(e.ColumnIndex / 3) + (Int32)(e.RowIndex * 4);
            }

            switch (gpioGridView.Columns[e.ColumnIndex].Name)
            {
                case "gpioName":
                    break;

                case "gpioDir":
                    if (DevPinStatusList[pinIndex].Direction == 1)
                    {
                        DevPinStatusList[pinIndex].Direction = 0;
                        if((int)gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != TagDir_OutPin48)
                        {
                            gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = TagDir_OutPin48;
                            gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;
                        }
                    }
                    else
                    {
                        DevPinStatusList[pinIndex].Direction = 1;
                        if ((int)gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != TagDir_InPin48)
                        {
                            gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = TagDir_InPin48;
                            gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48;
                        }
                    }
                    break;

                case "gpioValue":
                    if (DevPinStatusList[pinIndex].Direction != 1)
                    {
                        if (DevPinStatusList[pinIndex].Level == 1)
                        {
                            DevPinStatusList[pinIndex].Level = 0;
                            if ((int)gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != TagSW_Off48)
                            {
                                gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = TagSW_Off48;
                                gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::Susi4.Plugin.Properties.Resources.GPIO_SW_Off48;
                            }
                        }
                        else
                        {
                            DevPinStatusList[pinIndex].Level = 1;
                            if ((int)gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != TagSW_On48)
                            {
                                gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = TagSW_On48;
                                gpioGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = global::Susi4.Plugin.Properties.Resources.GPIO_SW_On48;
                            }
                        }
                    }
                    break;
            }
        }


        private void UpdateGrid()
        {
            for (int i = 0; i < DevPinStatusList.Count; i++)
            {
                if (DevPinStatusList[i].Direction == 1)
                {
                    if((int)gpioGridView.Rows[i].Cells[1].Tag != TagDir_InPin48)
                    {
                        gpioGridView.Rows[i].Cells[1].Tag = TagDir_InPin48;
                        gpioGridView.Rows[i].Cells[1].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48;
                    }

                    if (DevPinStatusList[i].Level == 1)
                    {
                        if ((int)(gpioGridView.Rows[i].Cells[2].Tag) != TagLED_Hi48)
                        {
                            gpioGridView.Rows[i].Cells[2].Tag = TagLED_Hi48;
                            gpioGridView.Rows[i].Cells[2].Value = global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48;
                        }
                    }
                    else
                    {
                        if ((int)(gpioGridView.Rows[i].Cells[2].Tag) != TagLED_Lo48)
                        {
                            gpioGridView.Rows[i].Cells[2].Tag = TagLED_Lo48;
                            gpioGridView.Rows[i].Cells[2].Value = global::Susi4.Plugin.Properties.Resources.GPIO_LED_Lo48;
                        }
                    }

                }
                else
                {
                    if ((int)gpioGridView.Rows[i].Cells[1].Tag != TagDir_OutPin48)
                    {
                        gpioGridView.Rows[i].Cells[1].Tag = TagDir_OutPin48;
                        gpioGridView.Rows[i].Cells[1].Value = global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;
                    }


                    if (DevPinStatusList[i].Level == 1)
                    {
                        if ((int)(gpioGridView.Rows[i].Cells[2].Tag) != TagSW_On48)
                        {
                            gpioGridView.Rows[i].Cells[2].Tag = TagSW_On48;
                            gpioGridView.Rows[i].Cells[2].Value = global::Susi4.Plugin.Properties.Resources.GPIO_SW_On48;
                        }
                    }
                    else
                    {
                        if ((int)(gpioGridView.Rows[i].Cells[2].Tag) != TagSW_Off48)
                        {
                            gpioGridView.Rows[i].Cells[2].Tag = TagSW_Off48;
                            gpioGridView.Rows[i].Cells[2].Value = global::Susi4.Plugin.Properties.Resources.GPIO_SW_Off48;
                        }
                    }

                }
            }
        }


        private void UpdateGrid_HorMode()
        {

            int r = 0;
            int i = 0;
            while (true)
            {
                if (i >= DevPinStatusList.Count)
                {
                    break;
                }

                for (int gpioGrid = 0; gpioGrid < 4; gpioGrid++)
                {
                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 1].Value = (DevPinStatusList[i].Direction == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;

                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 2].Value = (DevPinStatusList[i].Level == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Lo48;

                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 1].Value = (DevPinStatusList[i].Direction == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_InPin48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_Dir_OutPin48;

                    gpioGridView.Rows[r].Cells[gpioGrid * 3 + 2].Value = (DevPinStatusList[i].Level == 1) ?
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Hi48 :
                        global::Susi4.Plugin.Properties.Resources.GPIO_LED_Lo48;

                    i++;
                }
                r++;
            }
        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Timer 1s timeout");
        }

        private void timer_statusupdating_Tick(object sender, EventArgs e)
        {

            if (GridMode_Vertical == GRID_MODE_VERTICAL)
            {
                UpdateGrid();
            }
            else
            {
                UpdateGrid_HorMode();
            }

        }

    }
}
