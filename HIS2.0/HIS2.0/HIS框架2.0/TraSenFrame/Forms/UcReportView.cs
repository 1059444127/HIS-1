using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;
using TrasenClasses.GeneralClasses;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using TrasenFrame.Classes;
using System.Management;

namespace TrasenFrame.Forms
{
    public partial class UcReportView : UserControl
    {
        //2013-8-16 ���ӵ���pdf���ļ��ķ���
        //2013-3-6 �����¼�  this.AddEvent_AfterSetReportSource(); ����panelLeft,panelRight
        //2012-3-4  ���⹫����ˮ�������һЩ�������¼�
        //2013-1-18 ���� ���������٣���Ҫ��temp�ļ��в������� jianqg
        //2012-2-22 ��ʾ������ToolbarStatusBar 2012-2-22 ����  jianqg

          //CrystalDecisions.Shared.ReportPageRequestContext rprc  = new CrystalDecisions.Shared.ReportPageRequestContext();
          //ReportDocument rptDoc;
          //rptDoc.FormatEngine.GetLastPageNumber(rprc);  ��ҳ�� 


        ///// <summary>
        ///// CrystalReportViewer
        ///// </summary>
        //public CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw;
        /// <summary>
        /// �����Ƿ���سɹ�
        /// </summary>
        private bool LoadReportSuccess;
        /// <summary>
        /// ���ַ������ڵ����ӡ��ִ��
        /// </summary>
        /// <remarks>Add By Tany 2010-09-25 ����һ��SQLSTR���ڵ����ӡ��ִ�и����</remarks>
        private string[] _sqlStr;
        /// <summary>
        /// �Ƿ��ڵ����ӡ��ɹ�ִ�и��ַ���
        /// </summary>
        private bool _isExecSuccess = false;

        public event EventHandler IsExecSuccessChanged;
        #region 2013-3-4 ����ί���¼�
        public event MouseEventHandler CryRepViw__MouseClick;
        public event MouseEventHandler CryRepViw__MouseMove;
        public event MouseEventHandler CryRepViw__MouseUp;
        public event MouseEventHandler CryRepViw__MouseDown;
        public event MouseEventHandler CryRepViw__MouseWheel;
        public event MouseEventHandler CryRepViw__MouseDoubleClick;


        public event EventHandler CryRepViw__MouseLeave;
        public event KeyEventHandler CryRepViw__KeyDown;
        public event KeyPressEventHandler CryRepViw__KeyPress;
        public event KeyEventHandler CryRepViw__KeyUp;
        public event EventHandler CryRepViw__Click;
        public event EventHandler CryRepViw__DoubleClick;
        #endregion


        /// <summary>
        /// ���ݿ�����
        /// </summary>
        private TrasenClasses.DatabaseAccess.RelationalDatabase db = FrmMdiMain.Database;

        private object _reportDataSource;
        private string _reportFilePath;
        private ParameterEx[] _parameters;
        private bool _toPrinter;
        private bool _localLogin;		//�Ƿ񱾻���¼
        private string _printName;		//��ӡ������
        private bool _isPrinted;		//�Ƿ�������ӡ��ť
        private string PaperName;

        #region ����API����
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structPrinterDefaults
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pDatatype;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.I4)]
            public int DesiredAccess;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinter", SetLastError = true,
          CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPTStr)] 
         string printerName,
         out IntPtr phPrinter,
         ref structPrinterDefaults pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
          CharSet = CharSet.Unicode, ExactSpelling = false,
          CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool ClosePrinter(IntPtr phPrinter);

        [DllImport("winspool.Drv", EntryPoint = "SetPrinterA", SetLastError = true,
          CharSet = CharSet.Auto, ExactSpelling = true,
          CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool SetPrinter(
         IntPtr hPrinter,
         [MarshalAs(UnmanagedType.I4)] int level,
         IntPtr pPrinter,
         [MarshalAs(UnmanagedType.I4)] int command);

        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern int DocumentProperties(
         IntPtr hwnd,
         IntPtr hPrinter,
         [MarshalAs(UnmanagedType.LPStr)] string pDeviceName,
         IntPtr pDevModeOutput,
         IntPtr pDevModeInput,
         int fMode
         );

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structSize
        {
            public Int32 width;
            public Int32 height;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structRect
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct structDevMode
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String
             dmDeviceName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSpecVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverVersion;
            [MarshalAs(UnmanagedType.U2)]
            public short dmSize;
            [MarshalAs(UnmanagedType.U2)]
            public short dmDriverExtra;
            [MarshalAs(UnmanagedType.U4)]
            public int dmFields;
            [MarshalAs(UnmanagedType.I2)]
            public short dmOrientation;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperSize;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperLength;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPaperWidth;
            [MarshalAs(UnmanagedType.I2)]
            public short dmScale;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCopies;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDefaultSource;
            [MarshalAs(UnmanagedType.I2)]
            public short dmPrintQuality;
            [MarshalAs(UnmanagedType.I2)]
            public short dmColor;
            [MarshalAs(UnmanagedType.I2)]
            public short dmDuplex;
            [MarshalAs(UnmanagedType.I2)]
            public short dmYResolution;
            [MarshalAs(UnmanagedType.I2)]
            public short dmTTOption;
            [MarshalAs(UnmanagedType.I2)]
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String dmFormName;
            [MarshalAs(UnmanagedType.U2)]
            public short dmLogPixels;
            [MarshalAs(UnmanagedType.U4)]
            public int dmBitsPerPel;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsWidth;
            [MarshalAs(UnmanagedType.U4)]
            public int dmPelsHeight;
            [MarshalAs(UnmanagedType.U4)]
            public int dmNup;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDisplayFrequency;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMMethod;
            [MarshalAs(UnmanagedType.U4)]
            public int dmICMIntent;
            [MarshalAs(UnmanagedType.U4)]
            public int dmMediaType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmDitherType;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved1;
            [MarshalAs(UnmanagedType.U4)]
            public int dmReserved2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct PRINTER_INFO_9
        {
            public IntPtr pDevMode;
        }


        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        internal struct FormInfo1
        {
            [FieldOffset(0), MarshalAs(UnmanagedType.I4)]
            public uint Flags;
            [FieldOffset(4), MarshalAs(UnmanagedType.LPWStr)]
            public String pName;
            [FieldOffset(8)]
            public structSize Size;
            [FieldOffset(16)]
            public structRect ImageableArea;
        }

        [DllImport("winspool.Drv", EntryPoint = "AddFormW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall), SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern bool AddForm(IntPtr phPrinter, [MarshalAs(UnmanagedType.I4)] int level, ref FormInfo1 form);

        [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall),
        SuppressUnmanagedCodeSecurityAttribute()]
        internal static extern Int32 GetLastError();

        [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true,
          ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool GetPrinter(
         IntPtr hPrinter,
         int dwLevel,
         IntPtr pPrinter,
         int dwBuf,
         out int dwNeeded
         );

        [Flags]
        internal enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }
        const int WM_SETTINGCHANGE = 0x001A;
        const int HWND_BROADCAST = 0xffff;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessageTimeout(
         IntPtr windowHandle,
         uint Msg,
         IntPtr wParam,
         IntPtr lParam,
         SendMessageTimeoutFlags flags,
         uint timeout,
         out IntPtr result
         );

        #endregion

        public UcReportView()
        {
            InitializeComponent();
            //CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            //AddEvent(pageView);

        }
 

        #region ���� IsPrinted��ShowPrintButton
        /// <summary>
        /// �ж��û��Ƿ����˴�ӡ��ť
        /// </summary>
        public bool IsPrinted
        {
            get
            {
                return _isPrinted;
            }
        }


        public bool ShowPrintButton
        {
            get
            {
                return this.tbbtnPrint.Visible;
            }
            set
            {
                tbbtnPrint.Visible = value;
                tbMain.Visible = value;//2013-2-22 ����
            }
        }
        #endregion
        #region ԭ�������е� public ���� ��ʱ��Ϊ���ԣ��Է�������Ҫʹ�� jianqg 2013-2-20
        public CrystalDecisions.Windows.Forms.CrystalReportViewer CryRepViw_Uc
        {
            get { return this.CryRepViw; }
        }
        public ToolBar tbMain_Uc
        {
            get { return this.tbMain; }
            
        }
        public bool LoadReportSuccess_Uc
        {
            get { return this.LoadReportSuccess; }
            set { this.LoadReportSuccess = value; }
        }
        public bool isExecSuccess_Uc
        {
            get { return this._isExecSuccess; }
            //set { this._isExecSuccess = value; }
        }
        public string[] sqlStr_Uc
        {
            get { return this._sqlStr; }
            set { this._sqlStr = value; }
        }
        

        #endregion


        #region ����3�����Զ�Ӧ_reportDataSource��_reportFilePath��_parameters jianqg 2013-2-20
        public object reportDataSource_Uc
        {
            get { return this._reportDataSource; }
            set { this._reportDataSource=value; }
        }

        public string reportFilePath_Uc
        {
            get { return this._reportFilePath; }
            set { this._reportFilePath = value; }
        }
        public ParameterEx[] parameters_Uc
        {
            get { return this._parameters; }
            set { this._parameters = value; }
        }



        #endregion

        #region ԭ���ľ�̬����
        /// <summary>
        /// ȡ���û��Զ��屨���ļ�·����������������path����ֻ�Զ���·����
        /// </summary>
        /// <param name="path">��ǰ����·��</param>
        /// <param name="localLogin">�Ƿ�Ϊ������¼</param>
        /// <returns></returns>
        public static string GetCustomReportPath(string path, bool localLogin)
        {
            //ȡ�ñ����ļ���
            string fileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            string customReportDirectory = "";
            if (localLogin)	//����Ǳ�����¼�򱨱��ļ�·��Ĭ��Ϊ�������ݿ�Access����·��
            {
                //��INI�ļ���ȡ�������ݿ�·��
                string dataSource = Crypto.Instance().UnCryp(ApiFunction.GetIniString("LOCALSERVER", "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                customReportDirectory = dataSource.Substring(0, dataSource.LastIndexOf("\\")) + "\\Report";
            }
            else
                customReportDirectory = Constant.CustomDirectory + "\\Report";
            if (!Directory.Exists(customReportDirectory))			//�����·��������������Ŀ¼
            {
                Directory.CreateDirectory(customReportDirectory);
            }
            if (!File.Exists(customReportDirectory + "\\" + fileName))	//��������ļ���������Ӱ�װĿ¼����
            {
                File.Copy(path, customReportDirectory + "\\" + fileName, true);
            }
            return customReportDirectory + "\\" + fileName;
        }
        /// <summary>
        /// ֱ�Ӵ�ӡ
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">��������</param>
        /// <param name="localLogin">�Ƿ񱾻���¼</param>
        /// <param name="printName">��ӡ������</param>
        /// <param name="actualReportFilePath">�����ļ�·���Ƿ�Ϊʵ��·��</param>
        /// <returns>��ӡ�Ƿ�ɹ�</returns>
        public static bool DirectPrint(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool localLogin, string printName, bool actualReportFilePath)
        {
            try
            {

                ReportDocument rptDoc = new ReportDocument();
                if (actualReportFilePath)
                {
                    rptDoc.Load(reportFilePath);
                }
                else
                {
                    rptDoc.Load(GetCustomReportPath(reportFilePath, localLogin));
                }
                if (reportDataSource != null)
                {
                    rptDoc.SetDataSource(reportDataSource);
                }
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        rptDoc.SetParameterValue(parameters[i].Text, parameters[i].Value);
                    }
                }
                if (printName != "")
                {
                    rptDoc.PrintOptions.PrinterName = printName;
                }
                rptDoc.PrintToPrinter(1, false, 0, 0);

                rptDoc.Dispose();
                return true;
            }
            catch (LoadSaveReportException err)
            {
                MessageBox.Show("�����ļ�·�����ô���\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("1���������Դ�����Ƿ���ȷ��\n2����鱨��������Դ���Ƿ���ȷ��\n3�������������Ƿ���ȷ��\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        #region ����
        private bool LoadReport_000001()
        {
            //��ȡ��������
            string _reportName = GetReportFileName();
            //�ӱ������ö�ȡ����ʹ�õ�ֽ����Ϣ���ڱ��ش�ӡʱָ��Ĵ�ӡ��
            ReportPaper reportPaper = ReportPaper.GetReportPapterConfigFromLocalXml( _reportName , false , this.db );

            PrinterManager printerManager = new PrinterManager();
            if ( string.IsNullOrEmpty( this._printName ) )
            {
                //�������ʱû�д���ӡ������
                if ( string.IsNullOrEmpty( reportPaper.DefaultPrinterName ) )
                {
                    //��û�д���ӡ����Ҳû���ڱ������øñ���Ĵ�ӡ������ʹ�õ�Ĭ�ϴ�ӡ��
                    this._printName = PrinterManager.CurrentDefaultPrinter;
                }
                else
                {
                    //ʹ�øñ����ڱ��������еĴ�ӡ��
                    this._printName = reportPaper.DefaultPrinterName;
                }
            }            
            //���ݵõ��Ĵ�ӡ������xml�л�ȡ��ӡ������
            Printer printer = printerManager.GetConfiguredPrinter( this._printName );
            if ( printer == null )
            {
                //�������Ĵ�ӡ��û�����ã�ʹ��Ĭ��ֵ
                printer = new Printer();
                printer.Name = this._printName;
                printer.IsNetPrinter = false;
                printer.Type = PrinterType.��ʽ��ӡ��;
            }
            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { string.Format("����[{0}]������ӡ����{1}",_reportName,_printName ) }, true );
            //�����ӡ�������⣺
            //1 ����Ĵ�ӡ������ʹ�� usb��ӡ�ߣ���Ҫʹ�ô�ͳ�Ĵ�ӡ���˿�
            //2 ����Ĵ�ӡ�� ������Է��ʣ�ʹ��\\ip\����Ĵ�ӡ��,���ӣ��İ�װ��ʽ��������Ҫ���룬�Ժ�Ҳ��Ҳ��Ҫ
            //3 ��Ҫ����ֽ�ŵĴ�ӡ�������� �������ӡ�ķ�ʽ�������ϵͳ�˵�\�������� �д�������Ϊ�ÿ�ܶ������ӡ����������ֽ��
            if ( printer.IsNetPrinter )
            {
                //jianqg 2012-10-16 ���Ӳ������ƣ��ж��Ƿ������ӡ����Ҫ���� ֽ�ţ�ԭ���� ������return LoadReportWithoutSetting();//�����ӡ��
                SystemCfg cfg24 = new SystemCfg( 24 , db );//�����ӡ���Ƿ�����ֽ��
                if ( cfg24.Config == "1" )
                    return LoadReportWithSetting();
                else
                    return LoadReportWithoutSetting();//�����ӡ��
            }
            else
            {
                if ( printer.Type == PrinterType.�����ӡ�� )
                {

                    return LoadReportWithoutSetting();
                }
                else
                {
                    return LoadReportWithSetting();
                }
            }

        }
        /// <summary>
        /// ���ر����ļ�
        /// </summary>
        /// <returns></returns>
        protected bool LoadReport()
        {
            PrinterManager printerManager = new PrinterManager();
            string objPrinter = "";//Ŀ���ӡ��
            //��ȡ��ӡ��
            if (string.IsNullOrEmpty(this._printName))
                objPrinter = PrinterManager.CurrentDefaultPrinter;//û�д���ӡ������ʹ�õ�Ĭ�ϴ�ӡ��
            else
                objPrinter = this._printName;
            //�ж�����
            Printer printer = printerManager.GetConfiguredPrinter(objPrinter);
            if (printer == null)
            {
                //�������Ĵ�ӡ��û�����ã�ʹ��Ĭ��ֵ
                printer = new Printer();
                printer.Name = objPrinter;
                printer.IsNetPrinter = false;
                printer.Type = PrinterType.��ʽ��ӡ��;
            }

            //���û�д����ӡ����
            if (string.IsNullOrEmpty(_printName))
            {
                string _reportName = GetReportFileName();
                //MessageBox.Show("test 2:" + _reportName + objPrinter.ToString());
                //�������ݿ������õ�ֽ�Ÿ�ʽ
                string sql = "select printername,lx from jc_reportpaper where reportname='" + _reportName + "'";
                //MessageBox.Show("test 2:�����ݿ��ӡ������" + sql);
                DataRow drPaper = db.GetDataRow(sql);
                if (drPaper != null)
                {

                    object obj = drPaper["printername"];
                    //MessageBox.Show("test 2:�����ݿ��ӡ������obj��" + obj.ToString());
                    if (obj != null && !Convert.IsDBNull(obj))
                    {
                        _printName = obj.ToString().Trim();//����ӡ������Ϊ�������õĴ�ӡ��
                        //MessageBox.Show("test 3:jc_reportpaper�д�ӡ��:" + _printName);
                    }
                    else
                    {
                        int lx = Convert.IsDBNull(drPaper["lx"]) ? 0 : Convert.ToInt32(drPaper["lx"]);
                        if (lx != 0)
                        {
                            if (lx == 1)
                            {
                                _printName = Constant.CInvoicePrinterName;
                            }
                            else if (lx == 2)
                            {
                                _printName = Constant.CReportPrinterName;
                            }
                        }
                        //MessageBox.Show("test 4:" + _printName + " jc_reportpaper ��lx:" + lx.ToString());
                    }
                }
            }
            //�����ӡ�������⣺
            //1 ����Ĵ�ӡ������ʹ�� usb��ӡ�ߣ���Ҫʹ�ô�ͳ�Ĵ�ӡ���˿�
            //2 ����Ĵ�ӡ�� ������Է��ʣ�ʹ��\\ip\����Ĵ�ӡ��,���ӣ��İ�װ��ʽ��������Ҫ���룬�Ժ�Ҳ��Ҳ��Ҫ
            //3 ��Ҫ����ֽ�ŵĴ�ӡ�������� �������ӡ�ķ�ʽ�������ϵͳ�˵�\�������� �д�������Ϊ�ÿ�ܶ������ӡ����������ֽ��
            if (printer.IsNetPrinter)
            {
                //jianqg 2012-10-16 ���Ӳ������ƣ��ж��Ƿ������ӡ����Ҫ���� ֽ�ţ�ԭ���� ������return LoadReportWithoutSetting();//�����ӡ��
                SystemCfg cfg24 = new SystemCfg(24, db);//�����ӡ���Ƿ�����ֽ��
                if (cfg24.Config == "1")
                    return LoadReportWithSetting();
                else
                    return LoadReportWithoutSetting();//�����ӡ��
            }
            else
            {
                if (printer.Type == PrinterType.�����ӡ��)
                {
                    
                    return LoadReportWithoutSetting();
                }
                else
                {
                    
                    return LoadReportWithSetting();
                }
            }

        }
        private bool LoadReportWithoutSetting()
        {
            return LoadReportWithoutSetting(false);
        }
        /// <summary>
        /// �����Ĵ�ӡ�����õķ�ʽ���ر���
        /// </summary>
        /// <returns></returns>
        private bool LoadReportWithoutSetting(bool isExportFile)
        {
            try
            {
                if (_reportFilePath != "")
                {
                    string strMsg = "";
                    ReportDocument rptDoc = new ReportDocument();
                    rptDoc.Load(GetCustomReportPath(_reportFilePath));
                    if (_reportDataSource != null)
                    {
                        rptDoc.SetDataSource(_reportDataSource);
                    }
                    if (_parameters != null)
                    {
                        for (int i = 0; i < _parameters.Length; i++)
                        {
                            try
                            {
                                rptDoc.SetParameterValue(_parameters[i].Text, _parameters[i].Value);
                            }
                            catch (Exception errParameter)
                            {
                                strMsg="����������ô��� ������" + _parameters[i].Text + "\n" + errParameter.Message;
                                
                                if (isExportFile) throw new Exception(strMsg);
                                else  MessageBox.Show(strMsg, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                    if (_printName != "")
                    {
                        rptDoc.PrintOptions.PrinterName = _printName;
                    }
                    if (_toPrinter)
                    {
                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        rptDoc.PrintToPrinter(1, false, 0, 0);

                        rptDoc.Dispose();

                        return false;		//��Ԥ��
                    }
                    else
                    {
                        try
                        {
                            //MessageBox.Show("LoadReportWithoutSetting 5");
                            CryRepViw.ReportSource = rptDoc;
                            //MessageBox.Show("LoadReportWithoutSetting 6");
                            this.AddEvent_AfterSetReportSource(); //2013-3-6 �����¼�
                        }
                        catch (Exception err)
                        {
                             if (isExportFile) throw new Exception(err.Message);
                             else MessageBox.Show("���ñ�������Դ����\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (LoadSaveReportException err)
            {
                if (isExportFile) throw new Exception(err.Message);
                else MessageBox.Show("�����ļ�·�����ô���\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (TypeInitializationException te)
            {
                if (isExportFile) throw new Exception(te.Message);
                else MessageBox.Show("ˮ�����������ʼ��������\r\n" + te.InnerException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                if (isExportFile) throw new Exception(err.Message);
                else MessageBox.Show("1���������Դ�����Ƿ���ȷ��\n2����鱨��������Դ���Ƿ���ȷ��\n3�������������Ƿ���ȷ��\n4�������ӡ������������ֽ�Ÿ�ʽ��\n5��ӡ��û�����ӻ򲻿��û�Ĭ�ϴ�ӡû������\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        /// <summary>
        /// ����Ӳ�����Ĭ��ֽ�����õķ�ʽ���ر���
        /// </summary>
        /// <returns></returns>
        private bool LoadReportWithSetting()
        {
            try
            {
                if (_reportFilePath != "")
                {
                    ReportDocument rptDoc = new ReportDocument();
                    rptDoc.Load(GetCustomReportPath(_reportFilePath));
                    if (_reportDataSource != null)
                    {
                        rptDoc.SetDataSource(_reportDataSource);
                       
                    }
                    if (_parameters != null)
                    {
                        for (int i = 0; i < _parameters.Length; i++)
                        {
                            try
                            {
                                rptDoc.SetParameterValue(_parameters[i].Text, _parameters[i].Value);
                            }
                            catch (Exception errParameter)
                            {
                                MessageBox.Show("����������ô��� ������" + _parameters[i].Text + "\n" + errParameter.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                        }
                    }

                    if (_printName != "")
                    {
                        rptDoc.PrintOptions.PrinterName = _printName;
                    }
                    //�����Զ���ֽ�Ÿ�ʽ,���û�������,���������Ϊ��ѡֽ��
                    AddCustomPaperAndSetDefaultPaper(rptDoc);
                    if (_toPrinter)
                    {
                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        rptDoc.PrintToPrinter(1, false, 0, 0);


                        rptDoc.Dispose();
                        ResetDefaultPaper();//add by wangzhi 20101214

                        return false;		//��Ԥ��
                    }
                    else
                    {
                        try
                        {
                            CryRepViw.ReportSource = rptDoc;
                            this.AddEvent_AfterSetReportSource(); //2013-3-6 �����¼�
                            
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("���ñ�������Դ����\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (LoadSaveReportException err)
            {
                MessageBox.Show("�����ļ�·�����ô���\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            catch (TypeInitializationException te)
            {
                MessageBox.Show("ˮ�����������ʼ��������\r\n" + te.InnerException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("1���������Դ�����Ƿ���ȷ��\n2����鱨��������Դ���Ƿ���ȷ��\n3�������������Ƿ���ȷ��\n4�������ӡ������������ֽ�Ÿ�ʽ��\n5��ӡ��û�����ӻ򲻿��û�Ĭ�ϴ�ӡû������\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        /// <summary>
        /// ����ClientWindow.ini��DEFUAL_PAPTER��ֵ���ô�ӡ����Ĭ��ֽ��
        /// </summary>
        private void ResetDefaultPaper()
        {
            string sRset = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", Constant.ApplicationDirectory + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(sRset))
            {
                ApiFunction.WriteIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", "TRUE", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                sRset = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "ALLOW_RESET", Constant.ApplicationDirectory + "\\ClientWindow.ini");
            }
            if (sRset.ToUpper() == "TRUE")
            {
                string sVal = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                if (string.IsNullOrEmpty(sVal))
                {
                    ApiFunction.WriteIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", "A4", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                    sVal = ApiFunction.GetIniString("RESET_PRINTER_PAPTER", "DEFUAL_PAPTER", Constant.ApplicationDirectory + "\\ClientWindow.ini");
                }
                //��Ԥ���Ļ�ֱ�ӻ�ԭֽ������
                WorkStaticFun.SetPrinterDefaultPaper(sVal /*"A4"*/);
            }
        }
        /// <summary>
        /// ����Զ���ֽ�Ų�������Ϊ��ǰ��ӡ����Ĭ��ֽ��
        /// </summary>
        /// <param name="rptDoc"></param>
        private void AddCustomPaperAndSetDefaultPaper(ReportDocument rptDoc)
        {
            try
            {
                string _reportName = GetReportFileName();
                //�������ݿ������õ�ֽ�Ÿ�ʽ
                string sql = "select * from jc_reportpaper where reportname='" + _reportName + "'";
                DataTable paperTb = db.GetDataTable(sql);
                //���������ֽ�ŲŽ�������Ĳ���
                if (paperTb.Rows.Count > 0)
                {
                    PrintDocument prtdoc = new PrintDocument();
                    string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//��ȡĬ�ϴ�ӡ��

                    #region �����ӡ��ֽ�����ü����
                    #region ��ȡ��ӡ��ע�����Ϣ
                    Microsoft.Win32.RegistryKey rk;
                    if (!strDefaultPrinter.StartsWith(@"\\"))//���ش�ӡ��
                    {
                        //rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Printers\\" + strDefaultPrinter + "\\DsDriver");
                        rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\Printers\" + strDefaultPrinter + @"\DsDriver");
                    }
                    else                                //�����ӡ��
                    {
                        //string[] p = strDefaultPrinter.Remove(0, 2).Split(new char[] { '\\' });
                        //string path = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\LanMan Print Services\\Servers\\" + p[0] + "\\Printers\\" + p[1] + "\\DsDriver";
                        //rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(path);

                        //jianqg  ���� ���������ӡ��  win7 �� 2012-7-25
                        rk = WorkStaticFun.GetRegistryKey_NetWorkPrint(strDefaultPrinter);
                    }
                    #endregion
                    //��ȡĬ�ϴ�ӡ��֧�ֵ�ֽ��
                    string[] papers = (string[])(rk.GetValue("printMediaSupported"));
                    int iPaper = 0;
                    bool Exist = false;
                    PaperName = paperTb.Rows[0]["PAPERNAME"].ToString();

                    //�������ֽ���Ƿ����
                    for (int i = 0; i < papers.Length; i++)
                    {
                        if (papers[i].ToString().ToUpper() == PaperName.ToUpper())
                        {
                            iPaper = i;
                            Exist = true;
                            break;
                        }
                    }

                    const int PRINTER_ACCESS_USE = 0x00000008;
                    const int PRINTER_ACCESS_ADMINISTER = 0x00000004;
                    const int FORM_PRINTER = 0x00000002;

                    structPrinterDefaults defaults = new structPrinterDefaults();
                    defaults.pDatatype = null;
                    defaults.pDevMode = IntPtr.Zero;
                    defaults.DesiredAccess = PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE;

                    IntPtr hPrinter = IntPtr.Zero;

                    //���û�����ֽ�������
                    if (!Exist)
                    {
                        #region ���ֽ�ŵ���ӡ��
                        //�򿪴�ӡ�� 
                        if (OpenPrinter(strDefaultPrinter, out hPrinter, ref defaults))
                        {
                            try
                            {
                                float WidthInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERWIDTH"]);
                                float HeightInMm = Convert.ToSingle(paperTb.Rows[0]["PAPERHEIGHT"]);

                                //��������ʼ��FORM_INFO_1 
                                FormInfo1 formInfo = new FormInfo1();
                                formInfo.Flags = 0;
                                formInfo.pName = PaperName;
                                formInfo.Size.width = (int)(WidthInMm * 1000.0);
                                formInfo.Size.height = (int)(HeightInMm * 1000.0);
                                formInfo.ImageableArea.left = 0;
                                formInfo.ImageableArea.right = formInfo.Size.width;
                                formInfo.ImageableArea.top = 0;
                                formInfo.ImageableArea.bottom = formInfo.Size.height;
                                //AddForm(hPrinter, 1, ref formInfo);
                                if (!AddForm(hPrinter, 1, ref formInfo))
                                {
                                    StringBuilder strBuilder = new StringBuilder();
                                    strBuilder.AppendFormat("���ӡ�� {1} ����Զ���ֽ�� {0} ʧ�ܣ�������ţ�{2}",
                                     PaperName, strDefaultPrinter, GetLastError());
                                    throw new ApplicationException(strBuilder.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("�Զ���ֽ���Ѿ����óɹ�����һ�δ�ӡ��Լ��Ҫ���뵽��ʮ�����ô�ӡ���������ĵȴ���\n", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //return false;
                                }

                                //��ʼ�� 
                                const int DM_OUT_BUFFER = 2;
                                const int DM_IN_BUFFER = 8;
                                structDevMode devMode = new structDevMode();
                                IntPtr hPrinterInfo, hDummy;
                                PRINTER_INFO_9 printerInfo;
                                printerInfo.pDevMode = IntPtr.Zero;
                                int iPrinterInfoSize, iDummyInt;

                                int papersLength = 0;

                                papersLength = papers.Length;

                                papers = (string[])(rk.GetValue("printMediaSupported"));

                                if (papersLength == papers.Length)
                                {
                                    for (int i = 1; i <= 30; i++)
                                    {
                                        papers = (string[])(rk.GetValue("printMediaSupported"));
                                        if (papersLength != papers.Length)
                                        {
                                            MessageBox.Show("��ʱ" + i.ToString() + "�룡");
                                            break;
                                        }
                                        else
                                        {
                                            SendMessageTimeout(
                                             new IntPtr(HWND_BROADCAST),
                                             WM_SETTINGCHANGE,
                                             IntPtr.Zero,
                                             IntPtr.Zero,
                                             SendMessageTimeoutFlags.SMTO_NORMAL,
                                             1000,
                                             out hDummy);
                                        }
                                    }
                                }

                                //�������ֽ���Ƿ����
                                for (int i = 0; i < papers.Length; i++)
                                {
                                    if (papers[i].ToString().ToUpper() == PaperName.ToUpper())
                                    {
                                        iPaper = i;
                                        break;
                                    }
                                }

                                int iDevModeSize = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, IntPtr.Zero, IntPtr.Zero, 0);

                                if (iDevModeSize < 0)
                                    throw new ApplicationException("�޷�ȡ��DEVMODE�ṹ�Ĵ�С��");

                                //���仺�� 
                                IntPtr hDevMode = Marshal.AllocCoTaskMem(iDevModeSize + 100);

                                //��ȡDEV_MODEָ�� 
                                int iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, hDevMode, IntPtr.Zero, DM_OUT_BUFFER);

                                if (iRet < 0)
                                    throw new ApplicationException("�޷����DEVMODE�ṹ��");

                                //���DEV_MODE 
                                devMode = (structDevMode)Marshal.PtrToStructure(hDevMode, devMode.GetType());


                                devMode.dmFields = 0x10000;

                                //FORM���� 
                                devMode.dmFormName = PaperName;

                                Marshal.StructureToPtr(devMode, hDevMode, true);

                                iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter,
                                 printerInfo.pDevMode, printerInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER);

                                if (iRet < 0)
                                    throw new ApplicationException("�޷�Ϊ��ӡ���趨��ӡ����");

                                GetPrinter(hPrinter, 9, IntPtr.Zero, 0, out iPrinterInfoSize);
                                if (iPrinterInfoSize == 0)
                                    throw new ApplicationException("����GetPrinter����ʧ�ܣ�");

                                hPrinterInfo = Marshal.AllocCoTaskMem(iPrinterInfoSize + 100);

                                bool bSuccess = GetPrinter(hPrinter, 9, hPrinterInfo, iPrinterInfoSize, out iDummyInt);

                                if (!bSuccess)
                                    throw new ApplicationException("����GetPrinter����ʧ�ܣ�");

                                printerInfo = (PRINTER_INFO_9)Marshal.PtrToStructure(hPrinterInfo, printerInfo.GetType());
                                printerInfo.pDevMode = hDevMode;

                                Marshal.StructureToPtr(printerInfo, hPrinterInfo, true);

                                bSuccess = SetPrinter(hPrinter, 9, hPrinterInfo, 0);

                                if (!bSuccess)
                                    throw new Win32Exception(Marshal.GetLastWin32Error(), "����SetPrinter����ʧ�ܣ��޷����д�ӡ�����ã�");
                            }
                            catch (ApplicationException apperr)
                            {
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            finally
                            {
                                ClosePrinter(hPrinter);
                            }
                        }
                        #endregion
                    }
                    else//��ֽ��������Ϊ��ѡֽ��
                    {
                        #region ���ô�ӡ����Ĭ��ֽ��
                        //�򿪴�ӡ�� 
                        if (OpenPrinter(strDefaultPrinter, out hPrinter, ref defaults))
                        {
                            try
                            {
                                //��ʼ�� 
                                const int DM_OUT_BUFFER = 2;
                                const int DM_IN_BUFFER = 8;
                                structDevMode devMode = new structDevMode();
                                IntPtr hPrinterInfo, hDummy;
                                PRINTER_INFO_9 printerInfo;
                                printerInfo.pDevMode = IntPtr.Zero;
                                int iPrinterInfoSize, iDummyInt;


                                int iDevModeSize = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, IntPtr.Zero, IntPtr.Zero, 0);

                                if (iDevModeSize < 0)
                                    throw new ApplicationException("�޷�ȡ��DEVMODE�ṹ�Ĵ�С��");

                                //���仺�� 
                                IntPtr hDevMode = Marshal.AllocCoTaskMem(iDevModeSize + 100);

                                //��ȡDEV_MODEָ�� 
                                int iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter, hDevMode, IntPtr.Zero, DM_OUT_BUFFER);

                                if (iRet < 0)
                                    throw new ApplicationException("�޷����DEVMODE�ṹ��");

                                //���DEV_MODE 
                                devMode = (structDevMode)Marshal.PtrToStructure(hDevMode, devMode.GetType());


                                devMode.dmFields = 0x10000;

                                //FORM���� 
                                devMode.dmFormName = PaperName;

                                Marshal.StructureToPtr(devMode, hDevMode, true);

                                iRet = DocumentProperties(IntPtr.Zero, hPrinter, strDefaultPrinter,
                                 printerInfo.pDevMode, printerInfo.pDevMode, DM_IN_BUFFER | DM_OUT_BUFFER);

                                if (iRet < 0)
                                    throw new ApplicationException("�޷�Ϊ��ӡ���趨��ӡ����");

                                GetPrinter(hPrinter, 9, IntPtr.Zero, 0, out iPrinterInfoSize);
                                if (iPrinterInfoSize == 0)
                                    throw new ApplicationException("����GetPrinter����ʧ�ܣ�");

                                hPrinterInfo = Marshal.AllocCoTaskMem(iPrinterInfoSize + 100);

                                bool bSuccess = GetPrinter(hPrinter, 9, hPrinterInfo, iPrinterInfoSize, out iDummyInt);

                                if (!bSuccess)
                                    throw new ApplicationException("����GetPrinter����ʧ�ܣ�");

                                printerInfo = (PRINTER_INFO_9)Marshal.PtrToStructure(hPrinterInfo, printerInfo.GetType());
                                printerInfo.pDevMode = hDevMode;

                                Marshal.StructureToPtr(printerInfo, hPrinterInfo, true);

                                bSuccess = SetPrinter(hPrinter, 9, hPrinterInfo, 0);

                                if (!bSuccess)
                                    throw new Win32Exception(Marshal.GetLastWin32Error(), "����SetPrinter����ʧ�ܣ��޷����д�ӡ�����ã�");

                                //SendMessageTimeout(
                                // new IntPtr( HWND_BROADCAST ) ,
                                // WM_SETTINGCHANGE ,
                                // IntPtr.Zero ,
                                // IntPtr.Zero ,
                                // FrmReportView.SendMessageTimeoutFlags.SMTO_NORMAL ,
                                // 1000 ,
                                // out hDummy );
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            finally
                            {
                                ClosePrinter(hPrinter);
                            }
                        }
                        #endregion
                    }
                    //Modify By Tany 2010-10-08 ���ֽ�Ų����ڣ���������ķ�ʽ����һ��
                    try
                    {
                        int[] sizes = PaperSizeGetter.Get_PaperSizes(strDefaultPrinter);
                        int paperSizeid = sizes[iPaper];

                        rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)(paperSizeid);
                    }
                    catch
                    {
                        PaperSize myPaperSize = null;
                        //���Ҵ�ӡ����֧��ֽ���е�ͬ��ֽ��
                        foreach (PaperSize paperSize in prtdoc.PrinterSettings.PaperSizes)
                        {
                            if (paperSize.PaperName.ToLower() == PaperName.ToLower())
                            {
                                myPaperSize = paperSize;
                                break;
                            }
                        }
                        //���ô�ӡ����
                        rptDoc.PrintOptions.PrinterName = strDefaultPrinter;
                        //���ô�ӡֽ��
                        if (myPaperSize != null)
                            rptDoc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)myPaperSize.RawKind;
                    }
                    #endregion

                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("�Զ���ֽ�����ô���\n" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// ���ݱ���·����ȡ��������
        /// jianqg 2013-1-28 ��private ��Ϊprotected ���� ���ڼ̳�
        /// </summary>
        /// <returns></returns>
        protected string GetReportFileName()
        {
            string _reportName = _reportFilePath;
            int _idx = 0;
            //��_reportFilePathȡ�������ļ���
            while (_reportName.IndexOf(@"\") >= 0)
            {
                _idx = _reportName.IndexOf(@"\");
                _reportName = _reportName.Substring(_idx + 1);
            }
            _reportName = _reportName.Substring(0, _reportName.Length - 4);
            return _reportName;
        }

        /// <summary>
        /// �����л����±���·��ת�����Զ���·��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetCustomReportPath(string path)
        {
            //ȡ�ñ����ļ���
            string fileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            string customReportDirectory = "";
            if (_localLogin)	//����Ǳ�����¼�򱨱��ļ�·��Ĭ��Ϊ�������ݿ�Access����·��
            {
                //��INI�ļ���ȡ�������ݿ�·��
                //string dataSource=Crypto.Instance().UnCryp(ApiFunction.GetIniString("LOCALSERVER","DATASOURCE",Constant.ApplicationDirectory+"\\ClientConfig.ini"));
                string dataSource = ApiFunction.GetIniString("LOCALSERVER", "DATASOURCE", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                customReportDirectory = dataSource.Substring(0, dataSource.LastIndexOf("\\")) + "\\Report";
            }
            else
                customReportDirectory = Constant.CustomDirectory + "\\Report";
            if (!Directory.Exists(customReportDirectory))			//�����·��������������Ŀ¼
            {
                Directory.CreateDirectory(customReportDirectory);
            }
            if (!File.Exists(customReportDirectory + "\\" + fileName))	//��������ļ���������Ӱ�װĿ¼����
            {
                File.Copy(path, customReportDirectory + "\\" + fileName, true);
            }
            return customReportDirectory + "\\" + fileName;
        }

        //Add By Tany 2010-09-25
        /// <summary>
        /// ��ӡ��ִ��SQL���
        /// </summary>
        private void ExecSqlString()
        {
            bool old_isExecSuccess = _isExecSuccess;
            if (_sqlStr != null && _sqlStr.Length > 0 && !_isExecSuccess)
            {
                try
                {
                    db.DoCommand(null, null, null, _sqlStr);
                    
                    _isExecSuccess = true;
                    if (IsExecSuccessChanged != null) IsExecSuccessChanged(null, new EventArgs());
                }
                catch (Exception ex)
                {
                    _isExecSuccess = false;
                    if (IsExecSuccessChanged != null) IsExecSuccessChanged(null, new EventArgs());
                    string sql = "";
                    for (int i = 0; i < _sqlStr.Length; i++)
                    {
                        if (_sqlStr[i].Trim() != "")
                        {
                            sql += "[" + i.ToString() + "]" + _sqlStr[i].Trim() + ";";
                        }
                    }

                    throw new Exception(ex.Message + "\n\n" + sql);
                }
            }
        }
        #endregion

        #region �¼�
        public void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (!Convertor.IsInteger(nupFromPage.Value.ToString()))
                {
                    MessageBox.Show("��ʼҳ��ֻ������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Convertor.IsInteger(nupToPage.Value.ToString()))
                {
                    MessageBox.Show("����ҳ��ֻ������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (nupFromPage.Value > nupToPage.Value)
                {
                    MessageBox.Show("��ʼҳ�벻�ܴ��ڽ���ҳ�룡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                switch (Convert.ToInt32(e.Button.Tag))
                {
                    case 0:
                        ReportDocument rptDoc = (ReportDocument)CryRepViw.ReportSource;

                        //Add By Tany 2010-09-25
                        ExecSqlString();
                        if (rbtnAll.Checked)
                            rptDoc.PrintToPrinter(Convert.ToInt32(nupCopies.Value), false, 0, 0);
                        else
                            rptDoc.PrintToPrinter(Convert.ToInt32(nupCopies.Value), false, Convert.ToInt32(nupFromPage.Value), Convert.ToInt32(nupToPage.Value));

                        break;
                    default:
                        break;
                }
                _isPrinted = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Add By Tany 2015-04-23 �������ô�ӡ��
                //Modify By Tany 2015-05-21 ��ʱ���Σ���Ϊ��Щ�������ò��ɹ�
                //if (err.Message.Contains("��ӡ��") || err.Message.ToLower().Contains("print"))
                //{
                //    reNameprint();
                //    MessageBox.Show("ϵͳ�Ѿ����ô�ӡ���������´�ӡ������");
                //}
            }

        }
        private void rbtnPageRange_CheckedChanged(object sender, System.EventArgs e)
        {
            nupFromPage.Enabled = rbtnPageRange.Checked;
            lblTo.Enabled = rbtnPageRange.Checked;
            nupToPage.Enabled = rbtnPageRange.Checked;
        }
        //Add By Tany 2007-10-24
        //--------------------------------------------------------------
        #endregion

        #region ԭ�������е��¼�Load ��Closed ��Ϊ�������̣����Թ����ڵ��� jianqg 2013-2-20
        public void Control_Closed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PrinterManager printerManager = new PrinterManager();
                string objPrinter = "";//Ŀ���ӡ��
                //��ȡ��ӡ��

                if (string.IsNullOrEmpty(this._printName))
                    objPrinter = PrinterManager.CurrentDefaultPrinter;
                else
                    objPrinter = this._printName;
                //�ж�����

                Printer printer = printerManager.GetConfiguredPrinter(objPrinter);
                if (printer != null)
                {
                    //�����ӡ���������ӡ������ԭֽ��
                    if (printer.Type != PrinterType.�����ӡ�� && !printer.IsNetPrinter)
                    {
                        ResetDefaultPaper();
                    }
                }
            }
            catch
            {
                //
            }
            finally
            {
                //2013-1-18 ���� ���������٣���Ҫ��temp�ļ��в������� jianqg
                if (CryRepViw.ReportSource != null)
                {
                    ReportDocument rpt = CryRepViw.ReportSource as ReportDocument;
                    if (rpt != null) rpt.Dispose();

                }
                CryRepViw.Dispose();



            }
        }

        public void Control_Load(object sender, EventArgs e)
        {

            //Modify By Tany 2012-04-06
            //Modify By Tany 2012-05-15 21ˮ�������ӡԤ�������Ƿ��������ļ� 0=��1=����
            //Modify By jianq 2012-07-31 ���� emr �е��� ������Ϊû��FrmMdiMain.CurrentUser
            User CurrentUser = null;
            if (FrmMdiMain.CurrentUser == null)
            {
                CurrentUser = new User();
            }
            else
            {
                CurrentUser = FrmMdiMain.CurrentUser;
            }

            if (CurrentUser.IsAdministrator || new SystemCfg(21).Config == "0")
            {
                CryRepViw.ShowCloseButton = true;
                CryRepViw.ShowExportButton = true;
                CryRepViw.ShowRefreshButton = true;
                CryRepViw.ShowGroupTreeButton = true;
            }


        }
        //--------------------------------------------------------------
        #endregion

        #region ԭ�������й��캯��  ��Ϊ��Ӧ�Ĺ��̣����Թ����ڵ��� jianqg 2013-2-20
    
       /// <summary>
        /// �����ӡ�๹�캯��
        /// </summary>
        public bool Init()
        {
            //InitializeComponent();
            _toPrinter = false;
            _localLogin = false;
            _reportDataSource = null;
            _reportFilePath = "";
            _parameters = null;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = false;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        /// <param name="printName">��ӡ������</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string printName)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = printName;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        /// <param name="localLogin">�Ƿ񱾻����ݿⱨ���ӡ</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = localLogin;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        /// <param name="localLogin">�Ƿ񱾻����ݿⱨ���ӡ</param>
        /// <param name="printName">��ӡ������</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool localLogin, string printName)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = localLogin;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = printName;
            _isPrinted = false;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2010-09-25 ����һ�����캯��������ֱ�Ӵ�ӡʱ������ִ��sql���
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        /// <param name="sqlStr">��ӡ��ִ���ַ���</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            _sqlStr = sqlStr;//Add by tany 2010-09-25
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2010-10-25 ����һ�����캯��������ֱ�Ӵ�ӡʱ������ִ��sql��䣬���Ը�����������
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        /// <param name="sqlStr">��ӡ��ִ���ַ���</param>
        /// <param name="database">���ݿ�</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, string[] sqlStr, TrasenClasses.DatabaseAccess.RelationalDatabase database)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            _sqlStr = sqlStr;//Add by tany 2010-09-25
            db = database;//Add By tany 2010-10-25
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        //Add By Tany 2012-03-06 ����һ�����캯���������Ƿ���ʾ������ˢ�¡��رա���״Ŀ¼�Ȱ�ť
        /// <summary>
        /// ���ݱ����ļ���·��������Դ��ʾ����
        /// </summary>
        /// <param name="reportDataSource">��������Դ</param>
        /// <param name="reportFilePath">�����ļ�·��</param>
        /// <param name="parameters">�������</param>
        /// <param name="toPrinter">�Ƿ�ֱ�Ӵ�ӡ</param>
        public bool Init(object reportDataSource, string reportFilePath, ParameterEx[] parameters, bool toPrinter, bool isShowExport, bool isShowRefresh, bool isShowCloseButton, bool isShowTree)
        {
            //
            // Windows ���������֧���������
            //
            //InitializeComponent();
            _toPrinter = toPrinter;
            _localLogin = false;
            _reportDataSource = reportDataSource;
            _reportFilePath = reportFilePath;
            _parameters = parameters;
            _printName = "";
            _isPrinted = false;
            CryRepViw.ShowCloseButton = isShowCloseButton;
            CryRepViw.ShowExportButton = isShowExport;
            CryRepViw.ShowRefreshButton = isShowRefresh;
            CryRepViw.ShowGroupTreeButton = isShowTree;
            LoadReportSuccess = LoadReport();
            return LoadReportSuccess;
        }
        #endregion


        #region ShowOrHide_ToolbarStatusBar
        /// <summary>
        /// ��ʾ������ToolbarStatusBar 2012-2-22 ����  jianqg
        /// </summary>
        /// <param name="Visible"></param>
        public void ShowOrHide_ToolbarStatusBar(bool Visible)
        {
            CryRepViw.DisplayToolbar = false;
            CryRepViw.DisplayStatusBar = false;
            
            tbMain.Visible = false;
            label1.Visible = nupCopies.Visible = false;
            rbtnAll.Visible = rbtnPageRange.Visible = nupFromPage.Visible = lblTo.Visible = nupToPage.Visible = false;
        }
        #endregion


        #region ShowHideGroupTree,GetLastPageNumber,ReportPrint 2013-3-4
        public void ShowHideGroupTree(bool visible)
        {
            CryRepViw.DisplayGroupTree = visible;



        }
        public int GetLastPageNumber()
        {
            CrystalDecisions.Shared.ReportPageRequestContext rprc  = new CrystalDecisions.Shared.ReportPageRequestContext();
            ReportDocument rptDoc=(ReportDocument)CryRepViw.ReportSource;
            
            return rptDoc.FormatEngine.GetLastPageNumber(rprc);  //��ҳ�� 
        }

        public void ReportPrint(int copies)
        {
            ReportDocument rptDoc = (ReportDocument)CryRepViw.ReportSource;
           
            rptDoc.PrintToPrinter(copies, false, 0, 0);
        }
        #endregion
        #region CryRepViw �¼� 2013-3-4
        private void CryRepViw_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseClick != null) CryRepViw__MouseClick(sender, e);
        }
        private void CryRepViw_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseMove != null) CryRepViw__MouseMove(sender, e);
        }
        private void CryRepViw_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseUp != null) CryRepViw__MouseUp(sender, e);
        }
        private void CryRepViw_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseDown != null) CryRepViw__MouseDown(sender, e);
        }

        private void CryRepViw_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseWheel != null) CryRepViw__MouseWheel(sender, e);
        }
        private void CryRepViw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.CryRepViw__MouseDoubleClick != null) CryRepViw__MouseDoubleClick(sender, e);
        }

        private void CryRepViw_MouseLeave(object sender, EventArgs e)
        {
            if (this.CryRepViw__MouseLeave != null) CryRepViw__MouseLeave(sender, e);
        }

        private void CryRepViw_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.CryRepViw__KeyDown != null) CryRepViw__KeyDown(sender, e);
        }
        private void CryRepViw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.CryRepViw__KeyPress != null) CryRepViw__KeyPress(sender, e);
        }



        private void CryRepViw_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.CryRepViw__KeyUp != null) CryRepViw__KeyUp(sender, e);
            
        }

        private void CryRepViw_Click(object sender, EventArgs e)
        {
            if (this.CryRepViw__Click != null) CryRepViw__Click(sender, e);
        }
        private void CryRepViw_DoubleClick(object sender, EventArgs e)
        {
            if (this.CryRepViw__DoubleClick != null) CryRepViw__DoubleClick(sender, e);
        }
        #endregion

        #region �����¼� SetReportSource,AddEvent 2013-3-6
        /// <summary>
        /// SetReportSource �������¼�
        /// </summary>
        private void AddEvent_AfterSetReportSource()
        {
            CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            if (pageView != null && pageView.Controls.Count > 0)
            {
                TabControl temp_tabControl = new TabControl();
                //CrystalDecisions.Windows.Forms.DocumentControl docControl = null; 
                foreach (Control control in pageView.Controls)
                {
                    if (control.GetType() == temp_tabControl.GetType())
                    {
                        TabControl tc = (TabControl)control;
                        foreach (Control tab in tc.Controls)
                        {
                            //tab.BackColor = Color.White;
                            AddEvent(tab);

                        }

                        break;
                    }
                }
                
            }
        }
        private void AddEvent(Control objControl)
        {
            //CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            objControl.MouseClick += new MouseEventHandler(CryRepViw_MouseClick);

            objControl.MouseMove += new MouseEventHandler(CryRepViw_MouseMove);
            objControl.MouseUp += new MouseEventHandler(CryRepViw_MouseUp);
            objControl.MouseDown += new MouseEventHandler(CryRepViw_MouseDown);

            objControl.MouseWheel += new MouseEventHandler(CryRepViw_MouseWheel);
            objControl.MouseDoubleClick += new MouseEventHandler(CryRepViw_MouseDoubleClick);

            objControl.MouseLeave += new EventHandler(CryRepViw_MouseLeave);


            objControl.KeyDown += new KeyEventHandler(CryRepViw_KeyDown);
            objControl.KeyPress += new KeyPressEventHandler(CryRepViw_KeyPress);
            objControl.KeyUp += new KeyEventHandler(CryRepViw_KeyUp);

            objControl.Click += new EventHandler(CryRepViw_Click);
            objControl.DoubleClick += new EventHandler(CryRepViw_DoubleClick);
        }
        #endregion

        #region �������� ���ڷ�ҳ�Ŀؼ� 2013-3-6
        public Panel PanelLeft
        {
            get
            {
                return this.panelLeft;
            }
        }
        public Panel PanelRight
        {
            get
            {
                return this.panelRight;
            }
        }
        #endregion
        #region panelLeft,panelRight ��Visible �Զ�����pageView��ɫ 2013-3-6
        public void panel_VisibleChanged(object sender, EventArgs e)
        {
           
            Control objCtl = sender as Control;
            if (objCtl != null)
            {
                if (objCtl.Name == "panelLeft") panelRight.Visible = panelLeft.Visible;
                if (objCtl.Name == "panelRight") panelLeft.Visible = panelRight.Visible;
            }

            CrystalDecisions.Windows.Forms.PageView pageView = CryRepViw.Controls[0] as CrystalDecisions.Windows.Forms.PageView;
            if (pageView != null && pageView.Controls.Count > 0)
            {
                TabControl temp_tabControl = new TabControl();
                //CrystalDecisions.Windows.Forms.DocumentControl docControl = null; 
                foreach (Control control in pageView.Controls)
                {
                    if (control.GetType() == temp_tabControl.GetType())
                    {
                        TabControl tc = (TabControl)control;
                        foreach (Control tab in tc.Controls)
                        {
                            tab.BackColor = panelRight.Visible ? SystemColors.Window : SystemColors.Control;
                            panelRight.BackColor = panelLeft.BackColor = tab.BackColor;

                        }

                        
                    }
                }
            }

        }
        #endregion


        #region ExportToFile  �ڲ�����
        /// <summary>
        /// �����ļ� �ڲ�����
        /// </summary>
        /// <param name="ReportDoc"></param>
        /// <param name="FileName_export"></param>
        /// <param name="File_Type"></param>
        /// <returns></returns>
        private bool ExportToFile(ReportDocument ReportDoc,string FileName_export, FileType File_Type)
        {
            bool isSucess = false;
            CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();

            ReportDoc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            if (File_Type == FileType.Word)
            {

                ReportDoc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
            }
            else if (File_Type == FileType.PDF || File_Type != FileType.Word)
            {
                ReportDoc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            }
            DiskOpts.DiskFileName = FileName_export;

            ReportDoc.ExportOptions.DestinationOptions = DiskOpts;
            ReportDoc.Export();
            isSucess = true;
            return isSucess;
        }
        #endregion

        #region ExportToFile  �ⲿ����
        /// <summary>
        /// �ؼ����� �ļ� ExportToFile
        /// </summary>
        /// <param name="FileName_export">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>
        /// <param name="File_Type">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>
        /// <returns></returns>
        public bool ExportToFile(string FileName_export, FileType File_Type)
        {
            if (CryRepViw.ReportSource == null)
            {
                throw new Exception("û�б����ļ���");
            }
            ReportDocument ReportDoc = (ReportDocument)CryRepViw.ReportSource;
            return ExportToFile(ReportDoc, FileName_export, File_Type);
        }


        /// <summary>   
        /// ���������ļ�ΪPDF��ʽ   
        /// </summary>   
        /// <param name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
        /// <param name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
        /// <param name="FileName_export">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>  
        /// <param name="parameters">�����б�</param>   
        /// <returns>bool�ɹ�����true,ʧ�ܷ���false</returns> 
        public bool ExportToFile(string ReportFile, object ReportDataSource, string FileName_export, ParameterEx[] parameters, FileType File_Type)
        {
            try
            {
                _reportFilePath = ReportFile;
                _reportDataSource = ReportDataSource;
                _parameters = parameters;

                LoadReportWithoutSetting(true);
    
                bool flag = ExportToFile(FileName_export, File_Type);
                //2013-1-18 ���� ���������٣���Ҫ��temp�ļ��в������� jianqg
                if (CryRepViw.ReportSource == null)
                {
                    ReportDocument ReportDoc = (ReportDocument)CryRepViw.ReportSource;
                    ReportDoc.Dispose();
                }
               
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }
        //public void Init_ExportFile(string ReportFile, object ReportDataSource, ParameterEx[] parameters)
        //{
        //    _reportFilePath = ReportFile;
        //    _reportDataSource = ReportDataSource;
        //    _parameters = parameters;
        //    LoadReportWithoutSetting();
        //}
        #endregion 

        //Add By Trasen 2015-04-23
        /// <summary>
        /// ���ô�ӡ��
        /// </summary>
        private void resetPrint()
        {
            try
            {
                string computerName = System.Environment.MachineName;
                using (ManagementObject gManagementObject = new ManagementObject())
                {
                    gManagementObject.Scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", computerName));
                    gManagementObject.Scope.Connect();

                    string PrinterDevice = "";// "EPSON LQ-630 ESC/P 2 Ver 2.0";
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
                    ManagementObjectCollection omc = searcher.Get();
                    foreach (ManagementObject mo in omc)
                    {
                        if (bool.Parse(mo["Default"].ToString()))
                        {
                            PrinterDevice = mo["Name"].ToString();
                            break;
                        }
                    }
                    string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
                    ManagementObject printer = new ManagementObject(path);
                    printer.Scope = gManagementObject.Scope;
                    printer.Get();
                    ManagementObject printerCopy = (ManagementObject)printer.Clone();
                    printer.Delete();

                    printerCopy.SetPropertyValue("DeviceId", PrinterDevice);
                    printerCopy.SetPropertyValue("Caption", PrinterDevice);
                    printerCopy.SetPropertyValue("Name", PrinterDevice);
                    printerCopy.Put();
                }
            }
            catch (Exception ex) { }
        }

        //Add By Trasen 2015-04-27
        /// <summary>
        /// ��������ӡ��
        /// </summary>
        private void reNameprint()
        {
            string computerName = System.Environment.MachineName;
            using (ManagementObject gManagementObject = new ManagementObject())
            {
                gManagementObject.Scope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", computerName));
                gManagementObject.Scope.Connect();

                string PrinterDevice = "";// "EPSON LQ-630 ESC/P 2 Ver 2.0";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Printer");
                ManagementObjectCollection omc = searcher.Get();
                foreach (ManagementObject mo in omc)
                {
                    if (bool.Parse(mo["Default"].ToString()))
                    {
                        PrinterDevice = mo["Name"].ToString();
                        break;
                    }
                }
                string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
                ManagementObject printer = new ManagementObject(path);
                printer.Scope = gManagementObject.Scope;
                printer.Get();
                //�޸�Ϊ��ʱ����
                printer.InvokeMethod("RenamePrinter", new object[] { "new_name" });

                //���»�ȡwmi����
                path = @"win32_printer.DeviceId='new_name'";
                ManagementObject printer2 = new ManagementObject(path);
                printer2.InvokeMethod("RenamePrinter", new object[] { PrinterDevice });
                //string ss = printer.GetPropertyValue("CurrentPaperType").ToString();
            }

        }

    }
}
