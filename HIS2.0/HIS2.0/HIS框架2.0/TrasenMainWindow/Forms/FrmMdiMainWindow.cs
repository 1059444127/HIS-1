using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;
using System.IO;
using Crownwood.Magic.Menus;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using TrasenFrame.Classes;
using System.Diagnostics;

namespace TrasenMainWindow
{
    /// <summary>
    /// ϵͳ������
    /// </summary>
    public partial class FrmMdiMainWindow : System.Windows.Forms.Form
    {
        #region �����Ķ�����
        // jianqg 2013-5-16 ���Ӳ��Զ����� UpdateFile,UPDATETYPE,NotUpdate

        //jianqg emr-his ������ʱע��--  ���� �ı���ѯ
        /// <summary>
        /// �ı䳣��������ͣ����ֶ��޸�AssemblyInfo�а汾�� �Զ�ʹ�ù�˾����Ŀ�� jianqg 2012-8-8 
        /// 2012-12-27 ��Ϊ���ԣ�ʹ�ó��� emr����ȡ����ֵ����ԭ���Ĺ�˾ֵ
        /// </summary>
        //private TrasenFrame.Classes.FrameKind _FRAMEKIND = FrameKind.��˾;
        /// <summary>
        /// jianqg 2012-10�� emr-his������� ���� ���Ӳ����˵������ڽ��뵽���Ӳ���ϵͳ���Զ���Ա���Ӳ���ϵͳ
        /// </summary>
        private MenuCommand menu_EmrBussinessHis = null;

        /// <summary>
        /// ����С
        /// </summary>
        private const int BUFFER_LENGTH = 4096;
        /// <summary>
        /// �����ļ�
        /// </summary>
        private const string INIFILENAME = "SYSUPDATE.INI";
        /// <summary>
        /// ����
        /// </summary>
        private string _caption;
        /// <summary>
        /// ��������
        /// </summary>
        private string _maintProgramName;
        /// <summary>
        /// �Ƿ���ע��
        /// </summary>
        private bool _ifCheckRegister;
        /// <summary>
        /// ���ڲ˵�
        /// </summary>
        private MenuCommand menuWindow;
        /// <summary>
        /// ���˵�
        /// </summary>
        private Crownwood.Magic.Menus.MenuControl mainMenu;
        /// <summary>
        /// ���߰�ť��
        /// </summary>
        private System.Windows.Forms.ToolBar mainToolbar;
        /// <summary>
        /// ϵͳʱ��
        /// </summary>
        private DateTime CurrentTime;
        /// <summary>
        /// ��Ϣ����,��������Ϣ�ͼ����˿ڽ�����Ϣ
        /// </summary>
        //private TrasenMessage.MessageController messageControler;
        /// <summary>
        /// ������ʾ���յ�����Ϣ�Ĵ���
        /// </summary>
        //private TrasenMessage.DlgImmediatelyMessage dlgMsg; //add by wangzhi 2013-08-01

        private Icon AppIcon = null;
        private Icon AppGrayIcon = null;
        /// <summary>
        /// �Ƿ�������Ϣ
        /// </summary>
        private bool newMsg = false;
        /// <summary>
        /// ��Ϣ������
        /// </summary>
        private string msgSender = "";
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        private string msgContents = "";
        /// <summary>
        /// ��Ϣ��ʾʱ�䣨�룩
        /// </summary>
        private int showTime = 5;
        /// <summary>
        /// �Ƿ��Ѿ���ʾ����Ϣ
        /// </summary>
        private bool showMsg = false;

        private ImageList userToolbarList = new ImageList();
        /// <summary>
        /// �����̷߳��������õĶ���
        /// </summary>
        private static object _objLock = new object(); //add by wangzhi 2013-08-01
        /// <summary>
        /// �Ƿ�ʵʱ��ȡϵͳ�����֪ͨ����ʵʱ������������վ��ʵʱ��Ϣ����Ӧ����ID = 7
        /// </summary>
        /// <remarks>add by wangzhi 2013-08-01</remarks>
        private int realLoadMessage = Convert.ToInt32(new TrasenFrame.Classes.SystemCfg(0007).Config == "0");
        /// <summary>
        /// ��ȡϵͳ�����֪ͨ��Ƶ�ʣ���λ���ӣ�0�򲻻�ȡ����Ӧ����ID = 8
        /// </summary>
        private int loadAnnouncementFrequency = Convert.ToInt32(Convertor.IsNull(new TrasenFrame.Classes.SystemCfg(0008).Config, "1"));

        /// <summary>
        /// �Ƿ���Ҫ�����֤��
        /// </summary>
        private bool _checkMenuAuth = true;

        private bool _IsDebugVersion = false;

        private System.Diagnostics.Process msgProcess;

        private string _system_menu_id = null;
        #endregion

        /// <summary>
        /// �����湹�캯��
        /// </summary>
        /// <param name="caption">����</param>
        /// <param name="maintProgramName">����������</param>
        /// <param name="checkRegister">�Ƿ������ע�����</param>
        public FrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister)
        {
            InitializeComponent();
            InitializeFrmMdiMainWindow(caption, maintProgramName, checkRegister, null);
        }

        /// <summary>
        /// �����湹�캯��
        /// </summary>
        /// <param name="caption">����</param>
        /// <param name="maintProgramName">����������</param>
        /// <param name="checkRegister">�Ƿ������ע�����</param>
        public FrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister, string system_menu_id)
        {
            InitializeComponent();
            InitializeFrmMdiMainWindow(caption, maintProgramName, checkRegister, system_menu_id);
        }

        private void InitializeFrmMdiMainWindow(string caption, string maintProgramName, bool checkRegister, string system_menu_id)
        {
            _system_menu_id = system_menu_id;
            try
            {
                #region ��ʽ��͵��԰������,��ԭ������ʱ�޸ĸ�Ϊ����ini
                string strDebug = ApiFunction.GetIniString("Enviroment", "IsDebugVersion", Application.StartupPath + "\\ClientConfig.ini");
                if (string.IsNullOrEmpty(strDebug))
                    ApiFunction.WriteIniString("Enviroment", "IsDebugVersion", "false", Application.StartupPath + "\\ClientConfig.ini");
                strDebug = ApiFunction.GetIniString("Enviroment", "IsDebugVersion", Application.StartupPath + "\\ClientConfig.ini");
                try
                {
                    _IsDebugVersion = Convert.ToBoolean(strDebug);
                }
                catch
                {
                    _IsDebugVersion = false;
                }
                #endregion

                #region jianqg 2012-8-8 ������ͼ��
                ResourceManager rm = new ResourceManager("TrasenMainWindow.Properties.Resources", typeof(TrasenMainWindow.Properties.Resources).Assembly);
                string appIconName = "App";
                string appGrayIconName = "AppGray";
                switch (TrasenFrame.Forms.FrmMdiMain.FRAMEKIND)
                {
                    case TrasenFrame.Classes.FrameKind.����:
                        appIconName = "App_dr";
                        appGrayIconName = "AppGray_dr";
                        if (caption.Contains("����"))
                            caption = "����ҽԺ����ϵͳ";
                        break;
                    case TrasenFrame.Classes.FrameKind.����:
                        appIconName = "App_OnKiy";
                        appGrayIconName = "AppGray_OnKiy";
                        if (caption.Contains("����"))
                            caption = "����ҽԺ����ϵͳ";
                        break;
                }
                AppIcon = (System.Drawing.Icon)rm.GetObject(appIconName);
                AppGrayIcon = (System.Drawing.Icon)rm.GetObject(appGrayIconName);
                this.Icon = AppIcon;
                this.notifyIcon1.Icon = AppIcon;
                #endregion
                for (int i = 0; i < imgToolbar.Images.Count; i++)
                {
                    Image img = imgToolbar.Images[i];
                    userToolbarList.Images.Add(img);
                }
                userToolbarList.ImageSize = new Size(20, 20);
                #region ���밴ť��
                mainToolbar = new ToolBar();
                mainToolbar.Dock = DockStyle.Top;
                mainToolbar.Appearance = ToolBarAppearance.Flat;
                mainToolbar.TextAlign = ToolBarTextAlign.Right;
                mainToolbar.ImageList = userToolbarList;//this.imgToolbar;

                mainToolbar.ButtonClick += new ToolBarButtonClickEventHandler(mainToolbar_ButtonClick);
                Panel panBtn = new Panel();
                panBtn.Dock = DockStyle.Top;
                this.Controls.Add(panBtn);
                panBtn.Controls.Add(mainToolbar);
                panBtn.Height = mainToolbar.Height;
                #endregion
                #region ����˵�
                mainMenu = new MenuControl();
                mainMenu.Dock = DockStyle.Top;
                mainMenu.MdiContainer = this;
                this.Controls.Add(mainMenu);
                #endregion
                this.Text = caption;
                _caption = caption;
                _maintProgramName = maintProgramName;
                _ifCheckRegister = checkRegister;

                //Modify By Tany 2012-05-15 0022ϵͳ��¼ʱ�Ƿ���������������ѡ��� 0=��1=����
                if (new TrasenFrame.Classes.SystemCfg(22).Config == "1")
                {
                    TrasenFrame.Forms.FrmMdiMain.CurrentDept = this.InstanceCurrentDept();
                }
                if (TrasenFrame.Forms.FrmMdiMain.CurrentDept == null || TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId <= 0)
                {
                    //���û��ʵ�����ɹ��������û�ѡ����Һ���ʵ������ͬʱ���� ��Ա-����-ϵͳ �Ĺ�ϵ
                    TrasenFrame.Forms.FrmSelectDept fSelect = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);
                    if (fSelect.ShowDialog(this) == DialogResult.OK)
                    {
                        int selectDept = Convert.ToInt32(fSelect.SelectedDeptId);
                        TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelect.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);

                        string sql = "update jc_emp_dept_role set xtbh=" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + " where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id= " + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                        TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);

                        LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                        LoadFixedMenu();
                        LoadFixedToolbarButton();

                        this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                    }
                    else
                    {
                        MessageBox.Show("û��ѡ���¼���ң����򽫽�������", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        CloseMessageDectectProcess();
                        Application.Exit();
                    }
                }
                else
                {
                    //ѡ����ҵ�ʱ��ı����Ա�ĵ�¼����
                    //Modify By Tany 2009-12-23
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("update pub_user set login_dept = " + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID);

                    LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                    LoadFixedMenu();
                    LoadFixedToolbarButton();
                    this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            this.SizeChanged += delegate(object sender, EventArgs e)
            {
                LoadBackgroupPicture();
            };
            this.Activated += delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentDept != null)
                    this.sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
            };
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (!this._IsDebugVersion)
                    base.Text = value;
                else
                    base.Text = value + "--����˾�ڲ���������ģʽ��";
            }
        }

        #region ��Ļ���г�ʱ��������  add by wangzhi 2010-11-27
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public int size;
            public int lastTick;
        }
        [DllImport("User32")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO lii);
        private int lastActivity = Environment.TickCount;
        private delegate void AfterIdleTimeoutEventHandler();   //���峬���趨�Ŀ��еȴ�ʱ����¼�����ί��
        private event AfterIdleTimeoutEventHandler AfterIdleTimeoutEvent; //���峬���趨�Ŀ��еȴ�ʱ����¼�
        private delegate void PasswordValidateEventHandler();//���崦����������֤���ڵ�ί��
        private int idleTimeout = 0;
        private Thread thIdle;
        private bool screenLocked = false;
        /// <summary>
        /// �����ڳ������еȴ�ʱ����¼�
        /// </summary>
        private void ProcessAfterIdleTimeoutEvent()
        {
            PasswordValidateEventHandler handler = new PasswordValidateEventHandler(ShowPasswordValidate);
            this.Invoke(handler);
        }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        private void DetectIdleTime()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (screenLocked)
                    return;
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.size = 8;

                if (GetLastInputInfo(ref lastInputInfo))
                {
                    lastActivity = Math.Max(lastActivity, lastInputInfo.lastTick);

                    int diff = Environment.TickCount - lastActivity; //�������һ�������̻�����ڵ�ʱ����
                    if (diff > idleTimeout)
                    {
                        //��ǰ�������һ�������̻ʱ�������ڿ���ʱ��ֵ��
                        //������������ʱ���¼�
                        AfterIdleTimeoutEvent();
                    }
                }
            }
        }
        /// <summary>
        /// ��ʾ���봰�ڣ��൱����������֤��������
        /// </summary>
        private void ShowPasswordValidate()
        {
            if (thIdle != null)
            {
                thIdle.Suspend();
                //this.WindowState = FormWindowState.Minimized;
                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}

                TrasenFrame.Forms.FrmLockScreen fLockScreen = new TrasenFrame.Forms.FrmLockScreen(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
                CloseMessageDectectProcess();
                fLockScreen.ShowDialog(this);
                if (fLockScreen.ExitProgrammer)
                {
                    ExitProgrammer();
                    return;
                }
                //DisplayUnDealMessage();
                StartMesssageDectectProcess();

                screenLocked = false;
                thIdle.Resume();
            }
        }
        /// <summary>
        /// ��ȡ��������������ܵ�ʱ��
        /// </summary>
        /// <returns></returns>
        private int GetGroupIdleTimeOut()
        {
            //return 3 * 1000;
            return TrasenFrame.Forms.FrmMdiMain.CurrentSystem.AutoLockTime * 60 * 1000;
        }
        #endregion

        #region ���ر���ͼ
        private void LoadBackgroupPicture()
        {
            Image image = null;
            image = (new TrasenFrame.Classes.AppEnvironment()).GetBackgroundImage(TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode);

            if (image != null)
            {
                Image imageBk = image.GetThumbnailImage(this.Width, this.Height, (new Image.GetThumbnailImageAbort(delegate()
                {
                    return false;
                })), IntPtr.Zero);
                this.BackgroundImage = imageBk;
            }
            else
                this.BackgroundImage = null;
        }
        #endregion

        #region ��̬����:��ں���StartupMain���Ӵ��崦������
        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="connectionType"></param>
        /// <param name="connectionString"></param>
        /// <param name="maintProgramName"></param>
        /// <param name="checkRegister"></param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister)
        {
            WriteFrameLocalLog(new string[] { "Begin Invoke ��StartupMain(string,TrasenFrame.Classs.ConnectionType,string,bool,bool)��" }, true);
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, false);
        }

        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate)
        {
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, IsFormUpdate, null);
        }
        /// <summary>
        /// ϵͳ����
        /// </summary>
        /// <param name="caption">����</param>
        /// <param name="connectionType">�������</param>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="maintProgramName">����������</param>
        /// <param name="checkRegister">�Ƿ������ע�����</param>
        /// <param name="checkRegister">�Ƿ�����updateexe����</param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate, string LogingCode)
        {
            StartupMain(caption, connectionType, connectionString, maintProgramName, checkRegister, IsFormUpdate, LogingCode, null);
        }
        /// <summary>
        /// ϵͳ����
        /// </summary>
        /// <param name="caption">����</param>
        /// <param name="connectionType">�������</param>
        /// <param name="connectionString">�����ַ���</param>
        /// <param name="maintProgramName">����������</param>
        /// <param name="checkRegister">�Ƿ������ע�����</param>
        /// <param name="checkRegister">�Ƿ�����updateexe����</param>
        public static void StartupMain(string caption, TrasenFrame.Classes.ConnectionType connectionType, string connectionString,
            string maintProgramName, bool checkRegister, bool IsFormUpdate, string LogingCode, string system_menu_id)
        {
            try
            {
                switch (TrasenFrame.Forms.FrmMdiMain.FRAMEKIND)
                {
                    case TrasenFrame.Classes.FrameKind.����:
                        caption = "����ҽԺ����ϵͳ";
                        break;
                    case TrasenFrame.Classes.FrameKind.����:
                        caption = "����ҽԺ����ϵͳ";
                        break;
                }


                //�������ݿ�
                if (TrasenFrame.Classes.Constant.IsSelectConnect)
                {
                    TrasenFrame.Forms.FrmSelectConnect frmSelectConnect = new TrasenFrame.Forms.FrmSelectConnect(connectionType);
                    frmSelectConnect.ShowDialog();

                    if (frmSelectConnect.ServerName.Trim() != "")
                    {
                        connectionString = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, frmSelectConnect.ServerName);
                    }
                }
                switch (connectionType)
                {
                    case TrasenFrame.Classes.ConnectionType.SQLSERVER:
                        TrasenFrame.Forms.FrmMdiMain.Database = new MsSqlServer();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new MsSqlServer();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new MsSqlServer();
                        break;
                    case TrasenFrame.Classes.ConnectionType.IBMDB2:
                        TrasenFrame.Forms.FrmMdiMain.Database = new IbmDb2();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new IbmDb2();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new IbmDb2();
                        break;
                    case TrasenFrame.Classes.ConnectionType.MSACCESS:
                        TrasenFrame.Forms.FrmMdiMain.Database = new MsAccess();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new MsAccess();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new MsAccess();
                        break;
                    case TrasenFrame.Classes.ConnectionType.ORACLE:
                        TrasenFrame.Forms.FrmMdiMain.Database = new Oracle();
                        TrasenFrame.Forms.FrmMdiMain.Database_Lis = new Oracle();
                        TrasenFrame.Forms.FrmMdiMain.Database_Pacs = new Oracle();
                        break;
                    default:
                        break;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                {

                    //��ʼ�����ݿ�����
                    TrasenFrame.Forms.FrmMdiMain.Database.Initialize(connectionString);
                    WriteFrameLocalLog(new string[] { "Initialize Database Connection Object (TrasenFrame.Forms.FrmMdiMain.Database.Initialize( connectionString ))" }, true);
                    //Add By Tany 2009-3-31 ����LIS��PACS������
                    bool _lis = false;
                    bool _pacs = false;
                    string sqlType = "";
                    switch (connectionType)
                    {
                        case TrasenFrame.Classes.ConnectionType.SQLSERVER:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("SQLSERVERTYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.IBMDB2:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("IBMDB2TYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.MSACCESS:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("MSACCESSTYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        case TrasenFrame.Classes.ConnectionType.ORACLE:
                            sqlType = Crypto.Instance().Decrypto(ApiFunction.GetIniString("ORACLETYPE", "TYPE", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ClientConfig.ini"));
                            break;
                        default:
                            break;
                    }
                    string[] type = sqlType.Split('|');
                    if (type.Length > 0)
                    {
                        for (int i = 0; i < type.Length && type[i].Trim() != ""; i++)
                        {
                            if (type[i].Trim().ToUpper() == "LIS")
                            {
                                _lis = true;
                                continue;
                            }
                            if (type[i].Trim().ToUpper() == "PACS")
                            {
                                _pacs = true;
                                continue;
                            }
                        }
                    }
                    if (_lis)
                    {
                        //ʵ����LIS����������
                        try
                        {
                            string connectionString_lis = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, "LIS");
                            if (connectionString_lis.Trim() != "")
                                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Initialize(connectionString_lis);
                        }
                        catch (System.Exception err)
                        {
                            MessageBox.Show("�������ݿ�������������LIS�����������������ݿ�ʱ���ɹ������飡", "�������ݿ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (_pacs)
                    {
                        //ʵ����PACS����������
                        try
                        {
                            string connectionString_pacs = TrasenFrame.Classes.WorkStaticFun.GetConnnectionString(connectionType, "PACS");
                            if (connectionString_pacs.Trim() != "")
                                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Initialize(connectionString_pacs);
                        }
                        catch (System.Exception err)
                        {
                            MessageBox.Show("�������ݿ�������������PACS�����������������ݿ�ʱ���ɹ������飡", "�������ݿ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (ProcessSysUpdate(IsFormUpdate) == true)
                    {
                        //���������־true�����ļ���Ҫ���������������ļ�
                        string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\SysUpdateEx.exe";

                        if (System.IO.File.Exists(path))
                        {
                            if (string.IsNullOrEmpty(LogingCode))
                            {
                                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "����������������" + path }, true);
                                System.Diagnostics.Process.Start(path);
                            }
                            else
                            {
                                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "����������������" + path + " " + "SSO" }, true);
                                Process proc = new Process();
                                proc.StartInfo = new ProcessStartInfo(path);
                                proc.StartInfo.Arguments = "SSO";
                                proc.Start();
                                //System.Diagnostics.Process.Start( path + " " + "SSO" );
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("�����ļ�" + path + "��ʧ,������ϵ����Ա�Ի�ȡ���µĳ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }



                    //��ȡ��������
                    TrasenFrame.Forms.FrmMdiMain.Jgbm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[0]);
                    TrasenFrame.Forms.FrmMdiMain.Jgmc = (TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[1].ToString().Trim();
                    TrasenFrame.Forms.FrmMdiMain.JgYybm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[2]);
                    TrasenFrame.Forms.FrmMdiMain.JgServerIpaddr = (TrasenFrame.Forms.FrmMdiMain.GetJgbmmc())[3].ToString().Trim();

                    //��ȡ���Ļ�������
                    TrasenFrame.Forms.FrmMdiMain.ZxJgbm = Convert.ToInt32((TrasenFrame.Forms.FrmMdiMain.GetZxJgbmmc())[0]);
                    TrasenFrame.Forms.FrmMdiMain.ZxJgmc = (TrasenFrame.Forms.FrmMdiMain.GetZxJgbmmc())[1].ToString().Trim();
                    //����ǰ�������һ�����õĶ˿ں�
                    TrasenFrame.Forms.FrmMdiMain.PortNum = TrasenFrame.Classes.WorkStaticFun.GetAvailablePortNumber();



                    if (string.IsNullOrEmpty(LogingCode))
                    {
                        #region ������½,ϵͳ��¼
                        DlgLogin dlglogin = new DlgLogin();
                        dlglogin.BringToFront();
                        dlglogin.ShowDialog();

                        if (dlglogin.LoginSuccess)
                        {
                            TrasenFrame.Forms.FrmMdiMain.CurrentUser = dlglogin.CurrentUser;
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(dlglogin.CurrentSystem, TrasenFrame.Forms.FrmMdiMain.Database);
                            //����������
                            Application.Run(new FrmMdiMainWindow(caption, maintProgramName, checkRegister));
                        }
                        else
                        {
                            if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                                //Database_Lis.Dispose();
                            }
                            if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
                            {
                                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                                //Database_Pacs.Dispose();
                            }
                            TrasenFrame.Forms.FrmMdiMain.Database.Close();
                            TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                            Application.Exit();
                        }
                        #endregion
                    }
                    else
                    {
                        #region ���Ż���½
                        TrasenFrame.Forms.FrmMdiMain.CurrentUser = new User(LogingCode, TrasenFrame.Forms.FrmMdiMain.Database);
                        DataTable dtSystem = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
                        if (dtSystem.Rows.Count >= 1)
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new SystemInfo(Convert.ToInt32(dtSystem.Rows[0]["System_ID"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        else
                            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new SystemInfo();
                        TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "�������Ż�����������.." }, true);
                        //����������
                        Application.Run(new FrmMdiMainWindow(caption, maintProgramName, checkRegister, system_menu_id));
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("���ݿ�����ʧ�ܣ�ֹͣ���У�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database_Lis = null;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database_Pacs = null;
                }
                if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                {
                    if (TrasenFrame.Forms.FrmMdiMain.Database.ConnectionStates == ConnectionState.Open && TrasenFrame.Forms.FrmMdiMain.CurrentUser != null)
                    {
                        //Modify By Tany 2009-12-02 ���ӵ�½״̬�ļ�¼
                        //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );
                        TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
                    }
                    TrasenFrame.Forms.FrmMdiMain.Database.Close();
                    TrasenFrame.Forms.FrmMdiMain.Database = null;
                    Application.Exit();
                }
            }
        }


        /// <summary>
        /// �ж�Mdi�Ӵ����Ƿ��Ѿ���
        /// </summary>
        /// <param name="mdiForm">MDI������</param>
        /// <param name="formText">MDI�Ӵ�������</param>
        /// <returns></returns>
        public static bool MdiChildFormIsExist(Form mdiForm, string formText)
        {
            bool blResult = false;
            int m = mdiForm.MdiChildren.Length;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Activate();
                    blResult = true;
                    break;
                }
            }
            return blResult;
        }
        /// <summary>
        /// �ж�Mdi�Ӵ����Ƿ��Ѿ���
        /// </summary>
        /// <param name="mdiForm">MDI������</param>
        /// <param name="formText">MDI�Ӵ�������</param>
        /// <param name="childForm">�Ӵ������</param>
        /// <returns></returns>
        public static bool MdiChildFormIsExist(Form mdiForm, string formText, ref Form childForm)
        {
            bool blResult = false;
            int m = mdiForm.MdiChildren.Length;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Activate();
                    blResult = true;
                    childForm = mdiForm.MdiChildren[i];
                    break;
                }
            }
            return blResult;
        }
        /// <summary>
        /// �ر�ָ��MDI�Ӵ���
        /// </summary>
        /// <param name="mdiForm">MDI������</param>
        /// <param name="formText">MDI�Ӵ�������</param>
        /// <returns></returns>
        public static void CloseMdiChildForm(Form mdiForm, string formText)
        {
            int m = mdiForm.MdiChildren.Length;
            if (m == 0)
                return;
            for (int i = 0; i < m; i++)
            {
                if (mdiForm.MdiChildren[i].Text == formText)
                {
                    mdiForm.MdiChildren[i].Close();
                    i -= 1;
                    m -= 1;
                }
            }
        }
        #endregion

        #region ������³���ĸ��� add by wangzhi 2011-02-15
        /// <summary>
        /// ����XML�ļ�
        /// </summary>
        public static void CreateUpdateInfoFile(string sFile)
        {
            FileStream fs = new FileStream(sFile, FileMode.Create);
            fs.Close();
            DirectoryInfo dir = new DirectoryInfo(TrasenFrame.Classes.Constant.ApplicationDirectory);
            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                string fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(files[i].FullName).FileVersion;
                fileVersion = files[i].LastWriteTime.ToString("yyyyMMddHHmmss");
                ApiFunction.WriteIniString("FILEINFO", files[i].Name, fileVersion, TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini");
            }

        }
        /// <summary>
        /// ���������ļ��ĸ���
        /// </summary>
        /// <returns></returns>
        private static bool ProcessSysUpdate(bool IsFormUpdate)
        {
            //2013-7-3 jianqg ���� ���ܲ��ֻ������������ļ� ��ע�� f.Show();f.Refresh();f.Close();
            WriteFrameLocalLog((new string[] { "Start Check Update File" }), true);
            //Frmflash f = new Frmflash();
            try
            {
                bool update = false;
                string updateFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
                if (!File.Exists(updateFile))
                {
                    CreateUpdateInfoFile(updateFile);
                    WriteFrameLocalLog((new string[] { "Created UpdateFile.ini File" }), true);
                }

                //��������õ�exe�������°汾���ɿ�����ظ�exe
                if (HasNewVersionOfUpdateEXE())
                {
                    WriteFrameLocalLog((new string[] { "Detected New Version Of File : SystemUpdateEx.exe,Ready To Download" }), true);
                    DownLoadUpdateProgrammer();
                    WriteFrameLocalLog((new string[] { "SystemUpdateEx.exe Download Finished" }), true);
                }
                // jianqg 2013-5-16 ���Ӳ��Զ����� UpdateFile,UPDATETYPE,NotUpdate
                string notUpdate = ApiFunction.GetIniString("UPDATETYPE", "NotUpdate", updateFile);
                if (notUpdate.Trim().ToLower() == "true")
                {
                    WriteFrameLocalLog((new string[] { "UpdateFile.ini->[UPDATETYPE]->NotUpdate=true,Stop Update and Return to Main Program" }), true);
                    return false;
                }

                if (IsFormUpdate)
                {
                    //�������Update������,����Ҫ�ٽ��и��¼�� wangzhi 2013-06-19
                    WriteFrameLocalLog((new string[] { "IsFromUpdate = true,return false" }), true);
                    return false;
                }

                //��ȡ�����ļ�(���������������ִ���ļ�)
                DataTable tableNewFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable(@"select name,Version,download_folder from pub_systemupdate 
                                                                                                where name not in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
                string fileName = "";
                string[] fileVersion = new string[2];

                for (int i = 0; i < tableNewFile.Rows.Count; i++)
                {
                    fileName = tableNewFile.Rows[i]["name"].ToString();

                    //add by wangzhi 2012-03-01
                    string path = Convertor.IsNull(tableNewFile.Rows[i]["download_folder"].ToString(), "").Trim();
                    if (string.IsNullOrEmpty(path))
                        path = "";// "..";
                    if (path == "..")
                        path = "";

                    string fullFilename = path + "\\" + fileName;
                    if (path == "")
                        fullFilename = fileName;
                    //end add

                    //�������汾��
                    fileVersion[0] = tableNewFile.Rows[i]["Version"].ToString().Trim();
                    //���ذ汾��
                    fileVersion[1] = ApiFunction.GetIniString("FILEINFO", /*fileName*/ fullFilename, TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini");
                    if (fileName.ToLower() == "trasenframe.dll")
                    {
                        WriteFrameLocalLog((new string[] { "TrasenFrame Version:Server[" + fileVersion[0] + "  Local:[" + fileVersion[1] + "]" }), true);
                    }
                    if (fileVersion[0].Trim() != fileVersion[1].Trim())
                    {
                        update = true;//���°汾���ļ�Ҫ����
                        break;
                    }
                }
                WriteFrameLocalLog((new string[] { "update=" + update.ToString() }), true);
                return update;

            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("������������������ļ���������" + err.Message + "\r\n" + err.StackTrace + "\r\n" + err.GetType().ToString() + "�뽫����Ϣ������ϵͳ����Ա", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                //f.Close();
            }
        }
        /// <summary>
        /// �������������ִ���ļ�
        /// </summary>
        /// <remarks>�Ƚ������ļ����ص��ض�Ŀ¼��Ȼ����ض�Ŀ¼Copy������Ŀ¼</remarks>
        private static void DownLoadUpdateProgrammer()
        {
            //���Ҫ�������ļ��Ǹ��³���kill��������������Ľ���

            #region wangzhi ע�� 2013-06-19.������Ĵ���ɱ����
            //System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("SysUpdateEx");
            //while (ps.Length > 0)
            //{
            //    for (int idx = 0; idx < ps.Length; idx++)
            //    {
            //        if (!ps[idx].HasExited)
            //            ps[idx].Kill();
            //        ps[idx].Close();
            //        ps[idx].Dispose();
            //    }
            //    ps = System.Diagnostics.Process.GetProcessesByName("SysUpdateEx");
            //}
            #endregion

            #region ��ȡ��ǰ���н����������е�UPDATE����ID
            System.Diagnostics.Process[] proces = System.Diagnostics.Process.GetProcesses();//��ȡ���н���
            System.Collections.Generic.List<int> lstPID = new System.Collections.Generic.List<int>(); //����UpdateEx.exe�Ľ����б�
            foreach (System.Diagnostics.Process p in proces)
            {
                //������ǰ���н��̣�Ϊ��ֹ�������ж�ԭʼ�ļ�����ֻҪ��SysUpdateEx������ӵ��б�
                string originalFilename = "";
                try
                {
                    originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//תΪ��д
                }
                catch (Exception error)
                {
                    //����ϵͳ����ģ��ȵĴ������
                    continue;
                }
                if (!string.IsNullOrEmpty(originalFilename) && originalFilename == "SYSUPDATEEX.EXE")
                    lstPID.Add(p.Id);
            }
            #endregion

            #region ѭ������Update�Ľ���
            foreach (int pid in lstPID)
            {
                #region ʹ��Process���������
                System.Diagnostics.Process p = null;
                try
                {
                    #region ���Ի�ȡָ��ID�Ľ���,�����ȡ������������һ������ID
                    try
                    {
                        //��һ�ο�ʼ���ҽ���ID
                        p = System.Diagnostics.Process.GetProcessById(pid);
                    }
                    catch (ArgumentException e0)
                    {
                        continue;
                    }
                    #endregion
                    int count = 1;    //���峢�Դ���
                    int maxCount = 3; //��������Դ���
                    //����ҵ����̣�����ѭ�����Խ������̣�����ΪmaxCountָ��
                    #region ѭ�����Խ���Update.exe����
                    while (count <= maxCount)
                    {
                        WriteFrameLocalLog(new string[] { string.Format("Try To Terminate Process[ID:{1}] for {0} Times", count, pid) }, true);
                        p.Kill();
                        p.WaitForExit();

                        #region �������»�ȡ���̣����Ƿ񱻽���,�������������whileѭ��
                        try
                        {
                            //���¸���ID��ȡ����
                            p = System.Diagnostics.Process.GetProcessById(pid);
                        }
                        catch
                        {
                            //�������ArgementException,˵�������Ѿ�����,����whileѭ��
                            WriteFrameLocalLog(new string[] { string.Format("Process[ID:{1}] Has Terminated", pid) } , true);
                            break;
                        }
                        #endregion

                        #region ���û�б�����������ѭ��Kill��ֱ���ﵽָ���ĳ��Դ���
                        if (count == maxCount)
                        {
                            //������Դ��������޶�����������ѭ��
                            WriteFrameLocalLog(new string[] { string.Format("Try To Terminate Process[ID:{1}] least than {1} Times", maxCount, pid) }, true);
                            MessageBox.Show(string.Format("���Խ���SysUpdateEx.exe����({0})�Ѵ����Σ����ֹ�����", pid));
                            break;
                        }
                        else
                        {
                            //���¸���ID��ȡ���̵Ĳ�������ɹ����������һ��ѭ������������
                            count++;
                        }
                        #endregion
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    WriteFrameLocalLog(new string[] { string.Format("Catched a Exception at terminate process[ID:{0}],Error Message:{1}", pid, error.Message) }, true);
                }
                #endregion
            }
            #endregion

            #region ���Update.exe�Ľ����Ƿ��в���,������У�����������
            foreach (int pid in lstPID)
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                    MessageBox.Show("�����޷�����SystemUpdateEx.exe,���������µ�SystemUpdateEx.exe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; //�˳����ش���
                }
                catch
                {
                    continue;
                }
            }
            #endregion

            WriteFrameLocalLog((new string[] { "Ready from Update File:SystemUpdateEx.exe" }), true);
            string iniFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
            DataRow drNewUpdateFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow("select name,Version,file_value from pub_systemupdate where name in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
            Object obj = drNewUpdateFile["file_value"];//����������ļ�����
            string fileName = drNewUpdateFile["name"].ToString().Trim();//���������ļ���
            string serverVersion = drNewUpdateFile["Version"].ToString().Trim();//��������汾��

            string fullFileName = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\" + fileName;

            if (obj != null && !Convert.IsDBNull(obj))
            {
                if (File.Exists(fullFileName))
                {
                    //ɾ��ԭ�ļ�
                    File.Delete(fullFileName);
                    WriteFrameLocalLog((new string[] { string.Format("Delete Old File:{0}", fullFileName) }), true);
                }
                #region �Ѷ���������תΪ�ļ�
                using (FileStream fw = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    WriteFrameLocalLog((new string[] { string.Format("Write content to File : {0}", fullFileName) }), true);
                    byte[] buffer = (byte[])obj;
                    int fileLength = (int)buffer.Length / BUFFER_LENGTH;
                    if (fileLength * BUFFER_LENGTH < buffer.Length)
                    {
                        fileLength++;
                    }

                    for (int j = 0; j < fileLength; j++)	//�Գ���ΪBUFFER_LENGTH�ֽڵĿ���д���
                    {
                        if (buffer.Length - j * BUFFER_LENGTH >= BUFFER_LENGTH)
                        {
                            fw.Write(buffer, j * BUFFER_LENGTH, BUFFER_LENGTH);
                        }
                        else
                        {
                            fw.Write(buffer, j * BUFFER_LENGTH, buffer.Length - j * BUFFER_LENGTH);
                        }
                        fw.Seek(0, SeekOrigin.End);
                    }
                    fw.Close();
                    fw.Dispose();
                }
                #endregion

                //���ļ������������汾��д�뵽���ص�ini��
                ApiFunction.WriteIniString("FILEINFO", fileName, serverVersion, iniFile);
                WriteFrameLocalLog((new string[] { string.Format("SystemUpdateEx.exe Update Successfully��Version:{0}", serverVersion) }), true);
            }
        }
        /// <summary>
        /// �ж��Ƿ����°汾�ĸ��³���
        /// </summary>
        /// <returns></returns>
        private static bool HasNewVersionOfUpdateEXE()
        {
            string iniFile = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\UpdateFile.ini";
            DataRow drUpdateFile = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow("select name,Version,file_value from pub_systemupdate where name in ('SystemUpdate.exe','SysUpdate.exe','SysUpdateEx.exe') and delete_bit=0");
            if (drUpdateFile == null)
                return false;
            Object obj = drUpdateFile["file_value"];//����������ļ�����
            string fileName = drUpdateFile["name"].ToString().Trim();//���������ļ���
            string serverVersion = drUpdateFile["Version"].ToString().Trim();//��������ķ������汾
            //��������ı��ذ汾��
            string localVersion = ApiFunction.GetIniString("FILEINFO", fileName, iniFile);
            if (serverVersion.Trim().ToUpper() != localVersion.Trim().ToUpper())
                return true;
            else
                return false;
        }
        /// <summary>
        /// д���صĿ����־���� add by wangzhi 2013-06-21
        /// </summary>
        /// <param name="content"></param>
        /// <param name="showTime"></param>
        /// <param name="type">0:������־ 1:������־</param>
        public static void WriteFrameLocalLog(string[] content, bool showTime)
        {
            try
            {
                string path = string.Format("{0}\\AppLog", System.Windows.Forms.Application.StartupPath);
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                string logFile = string.Format("{0}\\{1}", path, fileName);

                string strTime = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
                if (!showTime)
                    strTime = "";

                if (!System.IO.File.Exists(logFile))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(logFile))
                    {
                        sw.WriteLine(string.Format("{0}Trasen.exe Created Log File", strTime));
                        sw.Flush();
                        sw.Close();
                    }
                }

                for (int i = 0; i < content.Length; i++)
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(logFile))
                    {
                        if (i == 0)
                        {
                            sw.WriteLine(strTime + content[i]);
                        }
                        else
                        {
                            if (strTime != "")
                            {
                                sw.WriteLine("                     " + content[i]);
                            }
                            else
                            {
                                sw.WriteLine(content[i]);
                            }
                        }
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }
        #endregion

        #region  ���ݵ�ǰ�û���ϵͳʵ��������
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private TrasenFrame.Classes.Department InstanceCurrentDept()
        {
            string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and  xtbh = " + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + " and dept_id in (select dept_id from jc_dept_property where jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + ")";//Modify By tany 2010-04-01 ��ȡĬ�Ͽ��ҵ�ʱ���ж�һ�¸ÿ��Ҳ��ǵ�ǰ���������µĿ���
            //string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + CurrentUser.EmployeeId + " and  [default] = 1";
            DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
            if (dr == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return new TrasenFrame.Classes.Department(Convert.ToInt32(dr["ksbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region ������Ĳ˵����ء��˵��¼��Ĵ����Լ� �������ļ��ؼ�����¼��Ĵ���

        #region �˵�[ϵͳ]
        private void mnuSRelogin_Click(object sender, System.EventArgs e)
        {
            //���µ�¼��¼�ϵ��û�ID,����ע����¼ Modify by Tany 2009-12-02
            long _oldUserId = TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID;

            //ϵͳ��¼
            DlgLogin dlglogin = new DlgLogin();
            dlglogin.ShowDialog();
            if (dlglogin.LoginSuccess)
            {
                if (_oldUserId != dlglogin.CurrentUser.UserID)
                {
                    //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + _oldUserId );
                    TrasenFrame.Classes.User.ClearOnlineStatus(_oldUserId, 0, "", TrasenFrame.Forms.FrmMdiMain.Database);
                }
                try
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                    }

                }
                catch
                {
                }

                TrasenFrame.Forms.FrmMdiMain.CurrentUser = dlglogin.CurrentUser;
                TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(dlglogin.CurrentSystem, TrasenFrame.Forms.FrmMdiMain.Database);
                //������
                sttbpUnit.Text = "�û���λ��" + TrasenFrame.Classes.WorkStaticFun.GetConfigValueByCode(0002, TrasenFrame.Forms.FrmMdiMain.Database) + "��" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "��" + TrasenFrame.Forms.FrmMdiMain.Jgmc + "��";
                sttbpUser.Text = "����Ա��" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                //���ݵ�ǰ�û���ѡ���ϵͳ���ҿ���
                string sql = "select dept_id as ksbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and xtbh =" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId;
                DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
                if (!TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    if (dr != null)
                    {
                        TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(Convert.ToInt32(dr["ksbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                    }
                    else
                    {
                        TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);
                        DialogResult dlg = fSelectDept.ShowDialog();
                        if (dlg != DialogResult.OK)
                        {
                            MessageBox.Show("û��ѡ�����,����ر�!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            CloseMessageDectectProcess();
                            Application.Exit();
                        }
                        else
                        {
                            TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                            sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                        }
                    }
                }

                LoadBackgroupPicture();

                this.mainMenu.MenuCommands.Clear();
                this.mainToolbar.Buttons.Clear();
                //����ϵͳ�˵�
                LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                //���ع̶����ֲ˵�
                LoadFixedMenu();
                LoadFixedToolbarButton();

                this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;

                ShowMessage(0);
                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
        }

        private void mnuUpLoad_Click(object sender, System.EventArgs e)
        {
            TrasenFrame.Forms.FrmFileUpLoad frmFileUpLoad = new TrasenFrame.Forms.FrmFileUpLoad(true);
            if (!MdiChildFormIsExist(this, frmFileUpLoad.Text))
            {
                frmFileUpLoad.MdiParent = this;
                frmFileUpLoad.Show();
            }

        }

        private void mnuUpLoadBD_Click(object sender, System.EventArgs e)
        {
            TrasenFrame.Forms.FrmFileUpLoad frmFileUpLoad = new TrasenFrame.Forms.FrmFileUpLoad(false);
            if (!MdiChildFormIsExist(this, frmFileUpLoad.Text))
            {
                frmFileUpLoad.MdiParent = this;
                frmFileUpLoad.Show();
            }

        }

        private void menuSwitch_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("���Ŀ��һ�رյ�ǰ�����Ӵ��ڣ�ȷ�����ģ�", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
                else
                {
                    return;
                }
            }
            TrasenFrame.Forms.FrmSelectDept fSelect = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId);

            if (fSelect.ShowDialog() == DialogResult.OK && fSelect.SelectedDeptId != TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId)
            {
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = new TrasenFrame.Classes.Department(fSelect.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);

                sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;

                this.mainMenu.MenuCommands.Clear();
                this.mainToolbar.Buttons.Clear();
                //����ѡ��Ŀ����뵱ǰ�û������Ҷ�Ӧ��ϵͳ�����¼��ز˵�
                string sql = "select xtbh from jc_emp_dept_role where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);
                if (dr != null)
                {
                    TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(dr["xtbh"]), TrasenFrame.Forms.FrmMdiMain.Database);
                    if (TrasenFrame.Forms.FrmMdiMain.CurrentSystem != null)
                    {
                        //���¼��ز˵�
                        LoadUserSystemMenu(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId);
                    }
                    else
                    {
                        //�޶�Ӧ��ϵͳ
                        DataTable tableSys = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
                    }
                }

                LoadFixedMenu();
                LoadFixedToolbarButton();

                //if ( this.dlgMsg != null )
                //{
                //    dlgMsg.Clear();
                //    dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
        }

        private void mnuSysSetting_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }
            FrmSystemSet fSystemset = new FrmSystemSet();
            fSystemset.MdiParent = this;
            fSystemset.Show();
        }
        /// <summary>
        /// jianqg 2012-7-3 ���� �˵���ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSysSearch_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }


            try
            {
                //����ts_jc_cdcx.dll
                string dllName = "ts_jc_cdcx.dll";
                string strNameSpace = "ts_jc_cdcx";
                string className = "frmMain";
                MenuCommand menuCmd = sender as MenuCommand;
                if (menuCmd == null)
                    return;
                if (menuCmd.Text.Contains("�Զ�����SQL�ű�"))
                {
                    dllName = "ts_autosql.dll";
                    strNameSpace = "ts_autosql";
                    className = "FrmPath";
                }

                string fullPath = Application.StartupPath + "\\" + dllName;
                if (System.IO.File.Exists(fullPath))
                {
                    Assembly assembly = Assembly.LoadFile(fullPath);
                    object objInstance = assembly.CreateInstance(strNameSpace + "." + "InstanceForm");
                    objInstance.GetType().GetProperty("Database").SetValue(objInstance, TrasenFrame.Forms.FrmMdiMain.Database, null);
                    if (menuCmd.Text.Contains("�Զ�����SQL�ű�"))
                    {
                        objInstance.GetType().GetProperty("CurrentUser").SetValue(objInstance, TrasenFrame.Forms.FrmMdiMain.CurrentUser, null);
                    }
                    //objInstance.GetType().GetProperty("MdiParent").SetValue(objInstance, this, null);

                    object[] args = new object[] { null, "ϵͳ�˵���ѯ", null };
                    object objForm = assembly.CreateInstance(strNameSpace + "." + className, true, BindingFlags.CreateInstance, null, args, null, null);
                    if (objForm != null)
                    {

                        Form f1 = (Form)objForm;
                        f1.Text = "ϵͳ�˵���ѯ";
                        f1.MdiParent = this;
                        f1.Show();
                    }
                }
            }
            catch (Exception err)
            {
                //Console.WriteLine( err.Message );
                throw err;
            }



        }

        private void mnuGroupUser_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Text == ((MenuCommand)sender).Text)
                {
                    f.Activate();
                    return;
                }
            }
            TrasenFrame.Forms.FrmGroupAccess fGroupAccess = new TrasenFrame.Forms.FrmGroupAccess();
            fGroupAccess.MdiParent = this;
            fGroupAccess.Show();
        }

        private void menuChangeDept_Click(object sender, EventArgs e)
        {
            //jianqg 2012-10�� emr-his������� �޸� ԭ�� �˵��п����л� û�йرմ��ڣ��������У�����ͳһ
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("�л����һ�رյ�ǰ�����Ӵ��ڣ�ȷ���л���", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }

                }
                else
                {
                    return;
                }
            }
            TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
            if (fSelectDept.ShowDialog() == DialogResult.OK)
            {
                int ksbh = fSelectDept.SelectedDeptId;
                //�������ͨ�û������¹�ϵ
                if (!TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    string sql = "update jc_emp_dept_role set xtbh =" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + " where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + " and dept_id=" + ksbh;
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand(sql);
                }
                TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = dept;
                MessageBox.Show("�����Ѹ���Ϊ��" + dept.DeptName + "��", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //if ( this.dlgMsg != null )
                //{
                //    this.dlgMsg.Clear();
                //    this.dlgMsg.Hide();
                //}
                //DisplayUnDealMessage();
                CloseMessageDectectProcess();
                StartMesssageDectectProcess();
            }
            fSelectDept.Close();

            //jianqg 2012-10�� emr-his������� ���� �������Ӳ����˵����Զ��򿪵��Ӳ���
            if (menu_EmrBussinessHis != null)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }

            //Add By Tany 2017-08-17
            LoadLisWjz();

            //Add By HYD 2017-09-19
            LoadPACSWjz();
        }

        private void menuReleaseMsg_Click(object sender, EventArgs e)
        {
            // Begin Modifty by Wangzhi

            //begin comment by wangzhi 2010-10-19
            //�ж��û��������Ƿ����ʹ�÷������ܣ�����ֻ�����
            //SystemCfg cfg = new SystemCfg(0006);
            //string sql = "select 1 from pub_group_user where group_id in (" + cfg.Config + ") and user_id=" + FrmMdiMain.CurrentUser.UserID;
            //DataRow dr = FrmMdiMain.Database.GetDataRow(sql);
            //end comment

            //����Ϣ����������б����жϵ�ǰ�û��ܷ񷢲���Ϣ
            string sql = "select * from pub_message_releasor where employee_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
            DataRow dr = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(sql);

            //End Modifty

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(TrasenFrame.Classes.Constant.ApplicationDirectory + "\\TrasenMessage.dll");
            Type type = null;
            Object obj = null;
            if (dr == null)
            {
                //ֻ�����
                type = assembly.GetType("TrasenMessage.FrmMsgBrower", false, true);
                obj = System.Activator.CreateInstance(type);
            }
            else
            {
                //��ʹ�÷�������
                type = assembly.GetType("TrasenMessage.FrmMsgRelease", false, true);
                obj = System.Activator.CreateInstance(type);
            }
            FrameEnvironment frameEvt = new FrameEnvironment();
            frameEvt.Database = TrasenFrame.Forms.FrmMdiMain.Database;
            frameEvt.User = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
            frameEvt.Department = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
            frameEvt.CSystem = TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId;

            ((Form)obj).MdiParent = this;
            ((Form)obj).WindowState = FormWindowState.Maximized;
            ((Form)obj).Tag = frameEvt;
            ((Form)obj).Show();
        }

        #endregion

        #region �̶��˵�����
        /// <summary>
        /// ���ع̶��˵�����
        /// </summary>
        private void LoadFixedMenu()
        {
            #region [ϵͳ]
            MenuCommand menuSystem = new MenuCommand("ϵͳ");
            MenuCommand menuReleasorSet = new MenuCommand("����֪ͨ��Ա����", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmMessageReleasor frmReleasor = new TrasenFrame.Forms.FrmMessageReleasor();
                frmReleasor.ShowDialog();
            }));//add by wangzhi 2010-10-19

            MenuCommand menuNoteAndMessage = new MenuCommand("����֪ͨ����Ϣ");
            MenuCommand menuReleaseMessage = new MenuCommand("����֪ͨ����", new EventHandler(menuReleaseMsg_Click));
            MenuCommand menuImmMessage = new MenuCommand("��ʱ��Ϣ����", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenMessage.FrmMsgManager frmMsgMgr = new TrasenMessage.FrmMsgManager(TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator);
                frmMsgMgr.ShowDialog();
            }));
            menuNoteAndMessage.MenuCommands.AddRange(new MenuCommand[] { menuReleaseMessage, menuImmMessage });

            MenuCommand menuLockTimeSet = new MenuCommand("ϵͳ����ʱ������", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmLockTimeSet f = new TrasenFrame.Forms.FrmLockTimeSet();
                f.ShowDialog();
            }));
            MenuCommand menuMessageSender = new MenuCommand("����Ϣ����", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmMessageSender fSender = new TrasenFrame.Forms.FrmMessageSender();
                fSender.Show();
            }));

            MenuCommand mnuSysSetting = new MenuCommand("ϵͳ�˵�����", new EventHandler(mnuSysSetting_Click));
            MenuCommand mnuSysSearch = new MenuCommand("ϵͳ�˵���ѯ", new EventHandler(mnuSysSearch_Click));//jianqg 2012-7-3 ���� �˵���ѯ
            MenuCommand mnuSysAutoSql = new MenuCommand("�Զ�����SQL�ű�", new EventHandler(mnuSysSearch_Click));//jianqg 2013-2-22 ���� �Զ�����SQL�ű�
            MenuCommand mnuGroupUser = new MenuCommand("ϵͳ�û�������", new EventHandler(mnuGroupUser_Click));
            MenuCommand mnuUpLoadFile = new MenuCommand("ϵͳ�����ļ��ϴ�(���з�����)", new EventHandler(mnuUpLoad_Click));
            MenuCommand mnuUpLoadFileBD = new MenuCommand("ϵͳ�����ļ��ϴ�(���ط�����)", new EventHandler(mnuUpLoadBD_Click));
            MenuCommand menuSpliter1 = new MenuCommand("-");
            MenuCommand menuSwitch = new MenuCommand("����ϵͳ");
            MenuCommand menuChangeDept = new MenuCommand("���ĵ�ǰ����", new EventHandler(menuChangeDept_Click));
            #region ��ȡ�û�ӵ�е�ϵͳ
            DataTable tableSys = TrasenFrame.Forms.FrmMdiMain.CurrentUser.GetSystemInfo();
            for (int i = 0; i < tableSys.Rows.Count; i++)
            {
                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(tableSys.Rows[i]["System_Id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                MenuCommand menuSys = new MenuCommand();
                menuSys.Text = tableSys.Rows[i]["Name"].ToString().Trim();
                menuSys.Tag = tag;
                menuSys.Click += new EventHandler(menuSys_Click);
                if (tag.System.SystemId == TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId)
                    menuSys.Checked = true;

                menuSwitch.MenuCommands.Add(menuSys);

            }
            #endregion
            MenuCommand menuSpliter2 = new MenuCommand("-");
            MenuCommand menuResetPwd = new MenuCommand("�޸�����", new EventHandler(delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd)
                {
                    MessageBox.Show("ʹ�ù��������½�����޸�����", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TrasenFrame.Forms.DlgPasswd dlgPasswd = new TrasenFrame.Forms.DlgPasswd();
                dlgPasswd.AllowCancel = true;
                dlgPasswd.ShowDialog();
            }));
            MenuCommand menuRelogin = new MenuCommand("���µ�¼", new EventHandler(mnuSRelogin_Click));
            MenuCommand menuParaSet = new MenuCommand("��������", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenFrame.Forms.FrmParaSetting frmParaSetting = new TrasenFrame.Forms.FrmParaSetting();
                frmParaSetting.ShowDialog();
            }));
            MenuCommand menuSpliter3 = new MenuCommand("-");
            MenuCommand menuExit = new MenuCommand("�˳�ϵͳ", System.Windows.Forms.Shortcut.AltF4, new EventHandler(delegate(object sender, EventArgs e)
            {
                this.Close();
            }));
            if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                menuSystem.MenuCommands.AddRange(new MenuCommand[] { menuReleasorSet,menuNoteAndMessage, menuLockTimeSet,
                    menuMessageSender, 
                    mnuSysSetting, 
                    mnuSysSearch,
                    mnuSysAutoSql,
                    mnuGroupUser, 
                    mnuUpLoadFile, 
                    mnuUpLoadFileBD,
                    menuSpliter1, 
                    menuSwitch,
                    menuChangeDept, 
                    menuSpliter2, 
                    menuResetPwd, 
                    menuRelogin, 
                    menuParaSet, 
                    menuSpliter3, 
                    menuExit });
            else
                menuSystem.MenuCommands.AddRange(new MenuCommand[] { menuNoteAndMessage, 
                    menuMessageSender, 
                    menuSwitch, 
                    menuChangeDept, 
                    menuSpliter2, 
                    menuResetPwd, 
                    menuRelogin, 
                    menuParaSet, 
                    menuSpliter3, 
                    menuExit });
            #endregion

            #region [����]
            menuWindow = new MenuCommand("����(&W)");
            MenuCommand mnuWTileHorizontal = new MenuCommand("ˮƽƽ��(&H)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }));
            MenuCommand mnuWTileVertical = new MenuCommand("��ֱƽ��(&W)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }));
            MenuCommand mnuWCascade = new MenuCommand("�������(&C)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.Cascade);
            }));
            MenuCommand mnuWArrangeIcons = new MenuCommand("����ͼ��(&A)", new EventHandler(delegate(object sender, EventArgs e)
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
            }));
            menuWindow.MenuCommands.AddRange(new MenuCommand[] { mnuWTileHorizontal, mnuWTileVertical, mnuWCascade, mnuWArrangeIcons });

            //Add By Tany 2010-07-22 �ڴ�������ʾ�Ѿ��򿪵Ĵ���
            menuWindow.PopupStart += new CommandHandler(menuWindow_PopupStart);
            menuWindow.PopupEnd += new CommandHandler(menuWindow_PopupEnd);
            #endregion

            #region [����]
            MenuCommand menuHelp = new MenuCommand("����(&H)");
            MenuCommand mnuHelp = new MenuCommand("ʹ�ð���(&H)");
            MenuCommand menuAbout = new MenuCommand("����(&A)", new EventHandler(delegate(object sender, EventArgs e)
            {
                TrasenMainWindow.Forms.FrmAbout frmAbout = new TrasenMainWindow.Forms.FrmAbout(_caption, _maintProgramName);
                frmAbout.ShowDialog();
            }));
            MenuCommand menuSupport = new MenuCommand("����֧��(&S)");
            MenuCommand menuRegAndAuth = new MenuCommand("ע�ἰ��Ȩ");
            MenuCommand mnuSRegister = new MenuCommand("ϵͳע��(&R)", delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    DlgRegister dlgRegister = new DlgRegister();
                    dlgRegister.ShowDialog();
                }
                else
                {
                    MessageBox.Show("�Բ����㲻��ϵͳ����Ա������ʹ��ע�Ṧ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            MenuCommand menuAuth = new MenuCommand("�˵���Ȩ(&A)", delegate(object sender, EventArgs e)
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.IsAdministrator)
                {
                    (new TrasenMainWindow.Forms.FrmMenuAuth()).ShowDialog();
                }
                else
                {
                    MessageBox.Show("�Բ����㲻��ϵͳ����Ա������ʹ��ע�Ṧ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            menuRegAndAuth.MenuCommands.AddRange(new MenuCommand[] { mnuSRegister, menuAuth });

            menuHelp.MenuCommands.AddRange(new MenuCommand[] { mnuHelp, menuAbout, menuSupport, menuRegAndAuth });
            #endregion

            this.mainMenu.MenuCommands.AddRange(new MenuCommand[] { menuSystem, menuWindow, menuHelp });

            //���������С
            mainMenu.Font = new Font("����", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));

        }

        //�˵���ʧʱ������̶��˵�������Ĳ˵�
        private void menuWindow_PopupEnd(MenuCommand mc)
        {
            int count = mc.MenuCommands.Count;

            if (count >= 4)
            {
                for (int index = 4; index < count; index++)
                    mc.MenuCommands.RemoveAt(4);
            }
        }

        //�˵�����ʱ�����ش򿪵��Ӵ���Ϊ�˵�
        private void menuWindow_PopupStart(MenuCommand mc)
        {
            Form current = this.ActiveMdiChild;

            Form[] children = this.MdiChildren;

            if (children.Length > 0)
            {
                mc.MenuCommands.Add(new MenuCommand("-"));

                foreach (Form f in children)
                {
                    MenuCommand newMC = new MenuCommand(f.Text);

                    newMC.Checked = (current == f);
                    newMC.Click += new EventHandler(newMC_Click);

                    mc.MenuCommands.Add(newMC);
                }
            }
        }
        //����ѡ�е��Ӵ���
        private void newMC_Click(object sender, EventArgs e)
        {
            MenuCommand childCommand = sender as MenuCommand;

            string name = childCommand.Text;

            Form[] children = this.MdiChildren;

            foreach (Form f in children)
            {
                if (f.Text == name)
                {
                    f.Activate();
                    break;
                }
            }
        }
        //�̶��˵��ĵ���¼�
        private void menuSys_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("����ϵͳ��رյ�ǰ�����Ӵ��ڣ�ȷ�����ģ�", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                }
                else
                {
                    return;
                }
            }
            mainMenu.MenuCommands.Clear();
            mainToolbar.Buttons.Clear();
            TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;
            TrasenFrame.Forms.FrmMdiMain.CurrentSystem = new TrasenFrame.Classes.SystemInfo(tag.System.SystemId, TrasenFrame.Forms.FrmMdiMain.Database);
            LoadUserSystemMenu(tag.System.SystemId, true);
            LoadFixedMenu();
            LoadFixedToolbarButton();
            this.Text = this._caption + "--" + tag.System.SystemName;

            LoadBackgroupPicture();

            //ǿ��������ѡ�����
            TrasenFrame.Forms.FrmSelectDept fSelectDept = new TrasenFrame.Forms.FrmSelectDept(TrasenFrame.Forms.FrmMdiMain.CurrentUser);
            if (fSelectDept.ShowDialog() == DialogResult.OK)
            {
                int ksbh = fSelectDept.SelectedDeptId;
                TrasenFrame.Classes.Department dept = new TrasenFrame.Classes.Department(fSelectDept.SelectedDeptId, TrasenFrame.Forms.FrmMdiMain.Database);
                TrasenFrame.Forms.FrmMdiMain.CurrentDept = dept;
                this.sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
            }
            else
            {
                MessageBox.Show("�������ϵͳ��δ���ĵ�¼����", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            fSelectDept.Close();
            //if ( this.dlgMsg != null )
            //{
            //    dlgMsg.Clear();
            //    dlgMsg.Hide();
            //}
            //this.DisplayUnDealMessage();
            CloseMessageDectectProcess();
            StartMesssageDectectProcess();

            //jianqg 2012-10�� emr-his������� ���� �������Ӳ����˵����Զ��򿪵��Ӳ���(��ϵͳ�������⣬ϵͳ����ʱ����ϵͳ����ʱ����)
            if (menu_EmrBussinessHis != null)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }

        }
        #endregion

        #region ����ϵͳ����������ģ��˵�
        /// <summary>
        /// ����ϵͳ�˵�  jianqg 2012-10�� emr-his������� ����
        /// </summary>
        /// <param name="SystemId"></param>
        private void LoadUserSystemMenu(int SystemId)
        {
            LoadUserSystemMenu(SystemId, false);

        }
        /// <summary>
        /// //jianqg 2012-10�� emr-his������� �޸� ���Ӳ���is_menuSys_Click
        /// </summary>
        /// <param name="SystemId"></param>
        /// <param name="is_menuSys_Click"> �Ƿ��ǵ�� ����ϵͳ</param>
        private void LoadUserSystemMenu(int SystemId, bool is_menuSys_Click)
        {

            //jianqg 2012-10�� emr-his������� ����
            menu_EmrBussinessHis = null;

            //��ȡ�˵���ʱ��ı����Ա�ĵ�¼ϵͳ�Ϳ���
            //Modify By Tany 2009-12-23
            TrasenFrame.Forms.FrmMdiMain.Database.DoCommand("update pub_user set login_dept=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + ",login_system = " + SystemId + " where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID);

            DataTable table = TrasenFrame.Forms.FrmMdiMain.LoadSystemMenuList(SystemId);

            DataRow[] rows = table.Select("Parent_Id=-1", "Sort_Id");

            for (int i = 0; i < rows.Length; i++)
            {
                MenuCommand menu = new MenuCommand(rows[i]["name"].ToString().Trim());
                menu.Text = rows[i]["name"].ToString().Trim();
                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();

                tag.Function_Name = rows[i]["Function_Name"].ToString().Trim();
                tag.FunctionTag = rows[i]["function_tag"].ToString().Trim();
                tag.DllName = rows[i]["Dll_name"].ToString().Trim();
                tag.MenuName = menu.Text;
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(rows[i]["menu_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                tag.Jgbm = Convert.ToInt32(rows[i]["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(rows[i]["jgbm"]);//Add By Tany 2010-01-14 Modify By Tany ���û�����û������룬��Ĭ�ϻ�����������Ϊ��¼��������
                //jianqg emr-his ������ʱע��
                tag.CanUsePublicPwd = Convert.ToInt32(rows[i]["CanUsePublicPwd"]) == 1 ? true : false;//�Ƿ�����ù������� jianqg 2012-10-6 emr-his�������  ����

                menu.Tag = tag;
                if (ContainMenu_ts_autosql(tag))
                    continue;//���� 2012-2-22 jianqg ���̶��˵�

                menu.Click += new EventHandler(menu_Click);
                //jianqg 2012-10�� emr-his������� ����  �Ƿ�������Ӳ����˵�
                ContainMenu_EmrBussinessHis(menu);
                object objIcon = Convert.IsDBNull(rows[i]["icon"]) ? null : rows[i]["icon"];

                AddSubMenu(table, menu, Convert.ToInt32(rows[i]["menu_id"]));
                mainMenu.MenuCommands.Add(menu);
                if (Convert.ToInt32(rows[i]["showtoolbar"]) == 1)
                {
                    if (objIcon == null)
                    {
                        AddButton(menu.Text, tag);
                    }
                    else
                    {
                        AddButton(menu.Text, tag, objIcon);
                    }
                }
                //mainMenu.MenuItems.Add( menu );
            }
            //jianqg 2012-10�� emr-his������� ���� �������Ӳ����˵����Զ��򿪵��Ӳ���(��ϵͳ�������⣬ϵͳ����ʱ����ϵͳ����ʱ����)
            if (menu_EmrBussinessHis != null && is_menuSys_Click == false)
            {
                menu_Click(menu_EmrBussinessHis, null);
            }
        }
        /// <summary>
        /// ����Ӳ˵�
        /// </summary>
        /// <param name="tableMenu"></param>
        /// <param name="parentMenu"></param>
        /// <param name="parentMenuId"></param>
        private void AddSubMenu(DataTable tableMenu, MenuCommand parentMenu, int parentMenuId)
        {
            DataRow[] rows = tableMenu.Select("Parent_Id=" + parentMenuId.ToString(), "Sort_Id");
            for (int i = 0; i < rows.Length; i++)
            {
                MenuCommand menu = new MenuCommand();
                menu.Text = rows[i]["name"].ToString().Trim();

                TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                tag.Function_Name = rows[i]["Function_Name"].ToString().Trim();
                tag.FunctionTag = rows[i]["function_tag"].ToString().Trim();
                tag.DllName = rows[i]["Dll_name"].ToString().Trim();
                tag.MenuName = menu.Text;
                tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(rows[i]["menu_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                tag.Jgbm = Convert.ToInt32(rows[i]["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(rows[i]["jgbm"]);//Add By Tany 2010-01-14 Modify By Tany ���û�����û������룬��Ĭ�ϻ�����������Ϊ��¼��������
                //jianqg emr-his ������ʱע��
                tag.CanUsePublicPwd = Convert.ToInt32(rows[i]["CanUsePublicPwd"]) == 1 ? true : false;//�Ƿ�����ù������� jianqg 2012-10-6 emr-his�������  ����
                //wangzhi 13-08-12 ������Ȩ��                
                menu.Tag = tag;
                if (ContainMenu_ts_autosql(tag))
                    continue;//���� 2012-2-22 jianqg ���̶��˵�
                //jianqg 2012-10�� emr-his������� ����  �Ƿ�������Ӳ����˵�
                ContainMenu_EmrBussinessHis(menu);
                object objIcon = Convert.IsDBNull(rows[i]["icon"]) ? null : rows[i]["icon"];

                if (menu.Text != "-")
                    menu.Click += new EventHandler(menu_Click);

                if (Convert.ToInt32(rows[i]["showtoolbar"]) == 1)
                {
                    if (objIcon == null)
                    {
                        AddButton(menu.Text, tag);
                    }
                    else
                    {
                        AddButton(menu.Text, tag, objIcon);
                    }
                }
                AddSubMenu(tableMenu, menu, Convert.ToInt32(rows[i]["menu_id"]));
                parentMenu.MenuCommands.Add(menu);
                //parentMenu.MenuItems.Add(menu);
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {


            if (MdiChildFormIsExist(this, ((TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag).MenuName))
                return;

            MenuClickTraceLog(sender);

            RelationalDatabase jgbmDb = null;
            try
            {
                TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;

                #region wangzhi������Ȩ����֤
                if (tag.DllName.ToUpper() != "TS_PUB_REPORT") //�Զ��屨���ü����Ȩ2013-08-16
                {
                    if (!_IsDebugVersion)
                    {
                        if (this._checkMenuAuth)
                        {
                            TrasenFrame.Classes.MenuTag _tag = TrasenFrame.Classes.MenuTag.GetTag(tag.DllName, tag.Function_Name, tag.FunctionTag, tag.MenuName,
                                TrasenFrame.Forms.FrmMdiMain.Database);
                            try
                            {
                                string tmp = TrasenRegister.Security.DeCryp(_tag.AuthCode);
                                string[] val = tmp.Split("|$|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                if (val[0] != (new TrasenFrame.Classes.SystemCfg(0002)).Config)
                                {
                                    MessageBox.Show("�ò˵�û����Ȩ����ǰ�û���������Ȩ�벻��ȷ,����ʹ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (val[1] != tag.MenuName || val[2] != tag.DllName || val[3] != tag.Function_Name)
                                {
                                    MessageBox.Show("�˵���Ϣ����Ȩ��Ϣ��һ�£�����ʹ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show("��Ȩ�벻��ȷ��������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                #endregion

                //jianqg 2012-10�� emr-his������� ����
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd == false)
                {
                    MessageBox.Show("�ò˵�������ʹ�ù������룡", "��ʾ��Ϣ");
                    return;
                }
                //Modify By Tany 2010-01-14
                //����ò˵�������ָ���Ǳ��أ���ʹ��ָ������ݿ�����
                if (tag.Jgbm != -1 && tag.Jgbm != TrasenFrame.Forms.FrmMdiMain.Jgbm)
                {
                    jgbmDb = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(tag.Jgbm);

                    TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                        tag.System.SystemId, this, jgbmDb);
                }
                else
                {
                    TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                        tag.System.SystemId, this, TrasenFrame.Forms.FrmMdiMain.Database);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ���ع�������ť
        private void LoadFixedToolbarButton()
        {
            ToolBarButton btn = new ToolBarButton();
            btn.Text = "�л�����";
            btn.Tag = "SWITCH";
            btn.ImageIndex = 1;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "���µ�¼";
            btn.Tag = "RELOGIN";
            btn.ImageIndex = 2;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "����";
            btn.Tag = "LOCKSRCEEN";
            btn.ImageIndex = 4;
            this.mainToolbar.Buttons.Add(btn);

            btn = new ToolBarButton();
            btn.Style = ToolBarButtonStyle.Separator;
            this.mainToolbar.Buttons.Add(btn);
            btn = new ToolBarButton();
            btn.Text = "�ر�";
            btn.Tag = "EXIT";
            btn.ImageIndex = 3;
            this.mainToolbar.Buttons.Add(btn);
            //���������С
            mainToolbar.Font = new Font("����", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));
            this.sttbMain.Font = new Font("����", (float)Convert.ToDouble(TrasenFrame.Classes.Constant.MenuFontSize == "" ? "9" : TrasenFrame.Classes.Constant.MenuFontSize));
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                tlbbtn.ImageIndex = 0;
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag, int icoIndex)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                if (icoIndex < this.imgToolbar.Images.Count && icoIndex >= 0)
                    tlbbtn.ImageIndex = icoIndex;
                else
                    tlbbtn.ImageIndex = 0;
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        private void AddButton(string Text, TrasenFrame.Classes.MenuTag tag, object Icon)
        {
            if (tag.DllName != "" && tag.Function_Name != "")
            {
                ToolBarButton tlbbtn = new ToolBarButton();
                tlbbtn.Text = Text;
                tlbbtn.Tag = tag;
                if (Icon != null)
                {
                    byte[] byteIco = (byte[])Icon;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteIco);
                    try
                    {
                        Image img = Image.FromStream(ms, true);

                        userToolbarList.Images.Add(img);

                        //imgToolbar.Images.Add( img );
                        tlbbtn.ImageIndex = userToolbarList.Images.Count - 1;
                    }
                    catch (Exception err)
                    {
                        tlbbtn.ImageIndex = 0;
                    }
                }
                else
                {
                    tlbbtn.ImageIndex = 0;
                }
                this.mainToolbar.Buttons.Add(tlbbtn);
            }
        }
        #endregion

        #region ��������ť�¼�
        private void mainToolbar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            TrasenFrame.Classes.MenuTag tag;
            if (e.Button.Tag is TrasenFrame.Classes.MenuTag)
            {
                tag = (TrasenFrame.Classes.MenuTag)e.Button.Tag;
                MenuCommand menu = new MenuCommand();
                menu.Tag = tag;
                menu_Click(menu, null);
            }
            else
            {
                string sTmp = e.Button.Tag.ToString();
                if (sTmp.Trim().ToUpper() == "EXIT")
                {
                    //
                    try
                    {
                        if (this.MdiChildren.Length > 0)
                        {
                            Form form = this.ActiveMdiChild;
                            form.Close();
                        }
                        else
                            this.Close();
                    }
                    catch
                    {
                    }
                }
                if (sTmp.Trim().ToUpper() == "RELOGIN")
                {
                    mnuSRelogin_Click(null, null);
                }
                if (sTmp.Trim().ToUpper() == "SWITCH")
                {
                    //if (this.MdiChildren.Length > 0)
                    //{
                    //    if (MessageBox.Show("�л����һ�رյ�ǰ�����Ӵ��ڣ�ȷ���л���", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        foreach (Form frm in this.MdiChildren)
                    //        {
                    //            frm.Close();
                    //            frm.Dispose();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //}
                    //jianqg 2012-10�� emr-his������� �޸� ԭ�� �˵��п����л� û�йرմ��ڣ��������У�����ͳһ
                    menuChangeDept_Click(null, null);
                }
                if (sTmp.Trim().ToUpper() == "LOCKSRCEEN")
                {
                    //if ( dlgMsg != null )
                    //{
                    //    dlgMsg.Clear();
                    //    dlgMsg.Hide();
                    //}
                    CloseMessageDectectProcess();
                    TrasenFrame.Forms.FrmLockScreen fLockScreen = new TrasenFrame.Forms.FrmLockScreen(TrasenFrame.Forms.FrmMdiMain.CurrentUser, true);
                    fLockScreen.ShowDialog();
                    if (fLockScreen.ExitProgrammer)
                    {
                        ExitProgrammer();
                        return;
                    }
                    screenLocked = false;
                    //DisplayUnDealMessage();
                    StartMesssageDectectProcess();
                }
            }
        }
        #endregion

        #endregion

        #region �������¼�   FrmMdiMainWindow_Load �� FrmMdiMain_Closing ��FrmMdiMain_Activated �� FrmMdiMain_SizeChanged
        private void FrmMdiMain_Load(object sender, System.EventArgs e)
        {

            try
            {
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser == null || TrasenFrame.Forms.FrmMdiMain.CurrentDept == null)
                {
                    Application.Exit();
                    return;
                }
                //��װ4.0Framework
                InstallDotNetFramework();

                string hospitalName = (new TrasenFrame.Classes.SystemCfg(0002)).Config;//��ȡҽԺ����
                DateTime serverTime = DateManager.ServerDateTimeByDBType(TrasenFrame.Forms.FrmMdiMain.Database);//��ȡ��ǰ������ʱ��

                #region ����״̬����Ϣ��ҽԺ���ƣ���ǰ��¼����Ա������,ϵͳʱ�����ʾ
                sttbpUnit.Text = "�û���λ��" + hospitalName + "��" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "��" + TrasenFrame.Forms.FrmMdiMain.Jgmc + "��";
                if (this._IsDebugVersion)
                    sttbpUnit.Text += "�����Կ���ģʽ��";
                sttbpUser.Text = "����Ա��" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                sttbpDept.Text = "���ſ��ң�" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                this.CurrentTime = serverTime;
                this.timeSystem.Enabled = true;
                this.timeSystem.Tick += new EventHandler(timeSystem_Tick);
                #endregion

                #region ������ʱ���������ʱ��ͬ��
                TrasenClasses.GeneralClasses.SystemTime systNew = new SystemTime();
                systNew.wDay = Convert.ToInt16(serverTime.Day);
                systNew.wMonth = Convert.ToInt16(serverTime.Month);
                systNew.wYear = Convert.ToInt16(serverTime.Year);
                systNew.wHour = Convert.ToInt16(serverTime.Hour);
                systNew.wMinute = Convert.ToInt16(serverTime.Minute);
                systNew.wSecond = Convert.ToInt16(serverTime.Second);
                ApiFunction.SetLocalTime(ref systNew);// ����API������ϵͳʱ�� 
                #endregion

                #region ע����֤ add by wangzhi 2010-09-29
                TrasenRegister.Licence.CheckRegisterCode += new TrasenRegister.CheckRegisterCodeHandle(Licence_CheckRegisterCode);
                try
                {

                    bool ret = TrasenRegister.Licence.DoCheck(hospitalName, serverTime, TrasenFrame.Forms.FrmMdiMain.Database);
                    if (ret)
                    {
                        return;
                    }
                    else
                    {
                        //Modify By Tany 2012-02-23 ���ע����֤ͨ�������ж��Ƿ������ע��Ĺ�˾��Ϣ
                        try
                        {
                            string keyCode = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select RegCode from YY_Register"), "");
                            if (!String.IsNullOrEmpty(keyCode))
                            {
                                string[] contents = TrasenRegister.Licence.GetRegisterInfo(keyCode);
                                if (contents.Length >= 7)
                                {
                                    _caption = contents[5];
                                    _maintProgramName = contents[6];

                                    this.Text = _caption + "--" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName;
                                    this.notifyIcon1.Text = _caption; //Modify By tany 2012-03-06
                                }
                            }
                        }
                        catch//����������
                        {
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "ע����֤�쳣", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                #endregion

                #region ������ add by wangzhi 2010-12-16 \ 2013-09-17 ���빫�����벻�����޸�����
                TrasenFrame.Classes.SystemCfg cfgAllowEmptyPwd = new TrasenFrame.Classes.SystemCfg(16);
                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Password.Trim() == "" && cfgAllowEmptyPwd.Config == "1"
                    && !TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd)
                {
                    TrasenFrame.Forms.DlgPasswd fPwd = new TrasenFrame.Forms.DlgPasswd();
                    fPwd.Message = "����ǰ������Ϊ�գ�ϵͳ�����˲���������룬�������������";
                    fPwd.AllowCancel = false;
                    fPwd.ShowDialog();
                }

                #endregion

                //��ʾ���桢֪ͨ
                ShowMessage(0);

                #region ������ʱ��Ϣ������(�߳�)��(2013-12-26 comment by wangzhi ��ܲ��ٸ���������Ϣ��������Ϊ����������Ϣ�Ľ��̣��ɽ���ȥ������Ϣ)
                //LoadtimerMessageConfig(); //commit by wangzhi ����ԭ���Ķ�ʱ�������ɵ�ϵͳʱ�ӿ��ƶ�ʱ��ȥ����

                //ʵ������Ϣ������������ʼ������¼ʱ��õĶ˿�
                //messageControler = new TrasenMessage.MessageController();
                //messageControler.RecivedMessage += new TrasenMessage.ReceviedMessageHandler( messageControler_RecivedMessage );
                //messageControler.StartListen();

                //add by wangzhi ����һ���������ڼ�����Ϣ
                StartMesssageDectectProcess();
                #endregion

                #region ���еȴ��������� add by wangzhi 2010-11-27(�߳�)
                idleTimeout = GetGroupIdleTimeOut();
                if (idleTimeout > 0)
                {
                    this.AfterIdleTimeoutEvent += new AfterIdleTimeoutEventHandler(ProcessAfterIdleTimeoutEvent);
                    thIdle = new Thread(new ThreadStart(DetectIdleTime));
                    thIdle.IsBackground = true;
                    thIdle.Start();
                }
                #endregion

                #region ���ò�������ϵͳ��Ϣ��ⶨʱ�� (�����ǲ�����LIS�Ǳ߸���Ϊ����Ϣ��ͨ��ͳһ����Ϣ����������)
                int timespan = 0;
                try
                {
                    TrasenFrame.Classes.SystemCfg cfg19 = new TrasenFrame.Classes.SystemCfg(19);
                    int second = Convert.ToInt32(cfg19.Config); //���õ�����
                    timespan = 1000 * second;
                }
                catch
                {
                    MessageBox.Show("ϵͳ����19�����ڻ����ô���,����ϵ����Ա,��δ���øò���ǰ���������ϵͳ��Ϣ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (timespan != 0)
                {
                    //timespan = 1000 * 2; //�����ã�2����һ��
                    timerSubSystemMessage.Interval = timespan;
                    timerSubSystemMessage.Start();
                }
                else
                {
                    timerSubSystemMessage.Enabled = false;
                }
                #endregion

                #region ��ʾδ����Ϣ ,(2013-12-26 comment by wangzhi ע�͡���ܲ��ټ�����Ϣ����Ϣ����һ������ȥ���������ֻ������Ӧ)
                //this.DisplayUnDealMessage();
                #endregion

                LoadBackgroupPicture();

                WriteFrameLocalLog(new string[] { "Mian Window Load Successfully" }, true);

                #region ���ָ����ĳ��ϵͳ��ĳ���˵�
                if (!string.IsNullOrEmpty(_system_menu_id))
                {
                    WriteFrameLocalLog(new string[] { "��������ָ���Ľ���" + _system_menu_id }, true);
                    string[] strArray = _system_menu_id.Split("|".ToCharArray());
                    string str0 = string.Format(@"select m.*,psm.system_id
                                                     from pub_menu m
                                                        inner join pub_system_menu as psm on psm.menu_id=m.menu_id
                                                        inner join pub_group_menu as gm on psm.sys_menu_id = gm.system_menu_id
                                                        inner join pub_group_user as gu on gm.[group_id]=gu.[group_id]
                                                        inner join pub_user u on gu.[user_id]=u.id 
                                                    where u.code='{0}' and psm.system_id={1} and m.menu_id={2}",
                                                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode, strArray[0], strArray[1]);
                    DataRow row = TrasenFrame.Forms.FrmMdiMain.Database.GetDataRow(str0);
                    if (row != null)
                    {
                        TrasenFrame.Classes.MenuTag tag = new TrasenFrame.Classes.MenuTag();
                        tag.Function_Name = row["Function_Name"].ToString().Trim();
                        tag.FunctionTag = row["function_tag"].ToString().Trim();
                        tag.DllName = row["Dll_name"].ToString().Trim();
                        tag.MenuName = row["Name"].ToString().Trim();
                        tag.System = new TrasenFrame.Classes.SystemInfo(Convert.ToInt32(row["system_id"]), TrasenFrame.Forms.FrmMdiMain.Database);
                        tag.Jgbm = Convert.ToInt32(row["jgbm"]) == -1 ? TrasenFrame.Forms.FrmMdiMain.Jgbm : Convert.ToInt32(row["jgbm"]);
                        tag.CanUsePublicPwd = Convert.ToInt32(row["CanUsePublicPwd"]) == 1 ? true : false;

                        TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                            TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag,
                            Convert.ToInt64(strArray[1]), this, TrasenFrame.Forms.FrmMdiMain.Database);
                        //MenuCommand menu = new MenuCommand();
                        //menu.Text = tag.MenuName;
                        //menu.Tag = tag;
                        //menu_Click( menu , new EventArgs() );
                    }
                }
                #endregion

                LoadLisWjz();
                LoadPACSWjz();// Add by HYD 2017-09-19
                Loadntp();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        void Licence_CheckRegisterCode(TrasenRegister.CheckRegisterCodeEventArgs e)
        {
            TrasenRegister.FrmWaring frmNote = new TrasenRegister.FrmWaring(e.InterruptProgrammer, e.Message, e.ShowTime,
                TrasenFrame.Forms.FrmMdiMain.Database, (new TrasenFrame.Classes.SystemCfg(0002)).Config);

            frmNote.ShowDialog(this);
            if (frmNote.ExitProgramm)
            {
                Application.Exit();
            }
        }

        private void FrmMdiMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {

                if (MessageBox.Show("��ȷ��Ҫ�˳�ϵͳ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //�ȹر������Ӵ��� Modify by Tany 2009-05-22
                    foreach (Form frm in this.MdiChildren)
                    {
                        frm.Close();
                        frm.Dispose();
                    }
                    e.Cancel = false;

                    //Modify By Tany 2009-12-02 ���ӵ�½״̬�ļ�¼
                    //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );                    
                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
                    //�ر�����
                    if (TrasenFrame.Forms.FrmMdiMain.Database != null)
                    {
                        if (TrasenFrame.Forms.FrmMdiMain.Database.ConnectionStates == ConnectionState.Open)
                            TrasenFrame.Forms.FrmMdiMain.Database.Close();
                        TrasenFrame.Forms.FrmMdiMain.Database.Close();
                        TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
                    }
                    //if ( messageControler != null )
                    //{
                    //    messageControler.StopListen();
                    //}

                    #region �˳�����ʱֹͣ���м���߳�
                    if (thIdle != null && thIdle.IsAlive)
                    {
                        thIdle.Abort();
                    }
                    #endregion

                    notifyIcon1.Visible = false;
                    CloseMessageDectectProcess();
                    Application.Exit();

                    System.Diagnostics.Process.GetCurrentProcess().Kill();


                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����");
                CloseMessageDectectProcess();
                Application.Exit();
            }

        }
        #endregion

        int count1 = 0;
        /// <summary>
        /// ���ڴ洢��ȡ����ʱ��ļ�����,��ϵͳʱ�Ӽ�����Ϊ׼����λΪ��
        /// </summary>        
        void timeSystem_Tick(object sender, EventArgs e)
        {
            this.CurrentTime = this.CurrentTime.AddSeconds(1);
            sttbpDateTime.Text = "��ǰʱ�䣺" + this.CurrentTime.ToLongDateString() + " " + this.CurrentTime.ToLongTimeString();

            if (this.realLoadMessage == 1)
            {
                count1++;
                if (count1 == (loadAnnouncementFrequency * 60))
                {
                    OnShowAnnouncementHandler handler = new OnShowAnnouncementHandler(ShowAnnouncementForm);
                    IAsyncResult result = handler.BeginInvoke((int)1, new AsyncCallback(ShowAnnouncementCallback), "OK");
                }
            }
        }

        #region ��ʾϵͳ����ķ�����ί�ж���
        /// <summary>
        /// ������ʾ���洰�ڵ�ί��
        /// </summary>
        /// <param name="flag"></param>
        private delegate void OnShowAnnouncementHandler(int flag);
        /// <summary>
        /// ������ʾ������첽ί�лص�����
        /// </summary>
        /// <param name="result"></param>
        private void ShowAnnouncementCallback(IAsyncResult result)
        {
            OnShowAnnouncementHandler handler = (OnShowAnnouncementHandler)((AsyncResult)result).AsyncDelegate;
            handler.EndInvoke(result);
            if (result.IsCompleted)
            {
                count1 = 0;
            }
        }
        /// <summary>
        /// �����첽���õķ���
        /// </summary>
        /// <param name="flag"></param>
        private void ShowAnnouncementForm(int flag)
        {
            this.Invoke(new OnShowAnnouncementHandler(ShowMessage), flag);
        }
        /// <summary>
        /// ��ʾ֪ͨ����
        /// </summary>
        /// <param name="_flag">��ʾ����0=�����Ƿ񱾵��Ѷ�1=���˱����Ѷ�</param>
        private void ShowMessage(int _flag)
        {
            RelationalDatabase database = TrasenFrame.Forms.FrmMdiMain.Database.GetCopy();
            try
            {
                database.Initialize(TrasenFrame.Forms.FrmMdiMain.Database.ConnectionString);
                database.Open();
                string sql = "select 1 from pub_message where deletebit=0 and datediff(d,releasedate,getdate()) < invalidday";
                DataRow dr = database.GetDataRow(sql);
                if (dr == null)
                    return;

                //�������Ч��������Ϣ
                sql = "select msgId from pub_message where deletebit=0 and datediff(d,releasedate,getdate()) < invalidday";
                sql += " and msgId in (";
                sql += "select msgid from pub_message_recivelist where (reciver_type = 0 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId + ") or (reciver_type=1 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + ") or (reciver_type=2 and reciver_id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + ")";
                sql += " ) order by sort desc,releasedate desc";//Modify By Tany 2012-04-17 �����ö�����

                DataTable tbMsg = database.GetDataTable(sql);
                if (tbMsg.Rows.Count == 0)
                    return;

                DataTable tb = tbMsg.Clone();
                if (_flag != 0)
                {
                    for (int i = 0; i < tbMsg.Rows.Count; i++)
                    {
                        if (TrasenClasses.GeneralClasses.ApiFunction.GetIniString("MessageInfo", tbMsg.Rows[i]["msgId"].ToString().Trim(), Application.StartupPath + "\\MessageInfo.ini").Trim() == "1")
                        {
                            continue;
                        }
                        tb.Rows.Add(tbMsg.Rows[i].ItemArray);
                    }
                }
                else
                {
                    tb = tbMsg.Copy();
                }

                if (tb.Rows.Count == 0)
                    return;

                //���ݷ�������ǰϵͳ�����ҡ��û�����Ϣ

                object[] objMsgs = new object[tb.Rows.Count];
                object[] objMsgId = new object[tb.Rows.Count];

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //objMsgs[i] = tb.Rows[i]["content"];
                    objMsgId[i] = tb.Rows[i]["msgId"];
                }

                //�Թ����Ƶ���ʽ��ʾ������Ϣ
                TrasenMessage.FrmMsgBorad fMsgBorad = new TrasenMessage.FrmMsgBorad(database, objMsgs, objMsgId);
                fMsgBorad.ShowDialog();
            }
            catch (Exception error)
            {
            }
            finally
            {
                database.Close();
                database.Dispose();
            }
        }
        #endregion

        #region ������ļ�ʱ��Ϣ�ļ�������ʾ����
        private void timerTwinkle_Tick(object sender, EventArgs e)
        {
            if (this.newMsg)
            {
                if (notifyIcon1.Icon == AppIcon)
                {
                    notifyIcon1.Icon = AppGrayIcon;
                }
                else
                {
                    notifyIcon1.Icon = AppIcon;
                }

                if (!this.showMsg && this.msgSender.Trim() != "" && this.msgContents != "")
                {
                    this.showMsg = true;
                    notifyIcon1.ShowBalloonTip(this.showTime * 1000, this.msgSender, this.msgContents, ToolTipIcon.Info);
                }
            }
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            this.newMsg = false;
            this.showMsg = false;
            this.msgSender = "";
            this.msgContents = "";
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            this.newMsg = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowAllMessage(DateTime.Now);
        }
        /// <summary>
        /// ��ʾĳ���������Ϣ
        /// </summary>
        /// <param name="date"></param>
        private void ShowAllMessage(DateTime date)
        {
            this.newMsg = false;
            this.showMsg = false;
            this.msgSender = "";
            this.msgContents = "";

            //string path = TrasenFrame.Classes.Constant.CustomDirectory + "\\��Ϣ��¼\\MSG" ;
            string path = Application.StartupPath + "\\��Ϣ��¼";
            string file = path + "\\MSG" + date.ToString("yyyyMMdd") + ".txt";
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                string ss = sr.ReadToEnd();
                sr.Close();
                TrasenFrame.Forms.FrmTxtMsg frmTxtMsg = new TrasenFrame.Forms.FrmTxtMsg();
                frmTxtMsg.Text = "��Ϣ";
                frmTxtMsg.txtMsg.Text = ss;
                frmTxtMsg.txtMsg.ReadOnly = true;
                frmTxtMsg.TopMost = true;
                frmTxtMsg.MaximizeBox = false;
                frmTxtMsg.MinimizeBox = false;
                frmTxtMsg.ShowDialog();
            }
        }
        #endregion

        /// <summary>
        /// ��ʾδ�������Ϣ
        /// </summary>
        //private void DisplayUnDealMessage()
        //{

        //    List<TrasenFrame.Classes.MessageInfo> undealMessages = TrasenFrame.Classes.MessageInfo.GetUnDealMessageList( TrasenFrame.Forms.FrmMdiMain.Database );
        //    if ( undealMessages.Count > 0 )
        //    {
        //        foreach ( TrasenFrame.Classes.MessageInfo msg in undealMessages )
        //        {
        //            TrasenMessage.MessageCommunication message = new TrasenMessage.MessageCommunication( msg.MessageId , msg.Summary , msg.SenderName , msg.IsMustRead ? 1 : 0 , msg.ShowTime );
        //            message.SendTime = msg.SendTime;
        //            message.Color = msg.FontColor;
        //            ShowRecivedMessageHandler handler = new ShowRecivedMessageHandler( ShowReciveMessage );
        //            handler.BeginInvoke( message , new AsyncCallback( ReciveMessageCallback ) , "" );
        //        }
        //    }
        //}

        private void ExitProgrammer()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
                frm.Dispose();
            }
            //Modify By Tany 2009-12-02 ���ӵ�½״̬�ļ�¼
            //TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( "update pub_user set login_bit=0,login_time=null,login_ip=null,login_mac=null,login_pcname=null,login_dept=null,login_system=null where id=" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.UserID );
            TrasenFrame.Forms.FrmMdiMain.CurrentUser.Loginout();
            //�ر�����
            if (TrasenFrame.Forms.FrmMdiMain.Database != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database.Close();
                TrasenFrame.Forms.FrmMdiMain.Database.Dispose();
            }

            #region jianqg 2012-8-20 ���� ����Database_Lis��Database_Pacs
            if (TrasenFrame.Forms.FrmMdiMain.Database_Lis != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database_Lis.Close();
                //Database_Lis.Dispose();
            }
            if (TrasenFrame.Forms.FrmMdiMain.Database_Pacs != null)
            {
                TrasenFrame.Forms.FrmMdiMain.Database_Pacs.Close();
                //Database_Pacs.Dispose();
            }
            #endregion

            //if ( messageControler != null )
            //{
            //    messageControler.StopListen();
            //}
            notifyIcon1.Visible = false;
            CloseMessageDectectProcess();
            Application.Exit();
            TrasenRegister.Licence.Realse();

            #region �˳�����ʱֹͣ���м���߳�
            if (thIdle != null && thIdle.IsAlive)
            {
                thIdle.Abort();
            }
            #endregion
            //jianqg 2012-10�� emr-his������� ����
            menu_EmrBussinessHis = null;


        }
        /// <summary>
        /// ��ϵͳ��Ϣ������
        /// </summary>
        private TrasenFrame.Classes.SubSystemMessageProcessor ssmp;

        private void timerSubSystemMessage_Tick(object sender, EventArgs e)
        {
            try
            {
                ssmp = new TrasenFrame.Classes.SubSystemMessageProcessor(this, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept,
                    TrasenFrame.Classes.Constant.ApplicationDirectory, TrasenFrame.Forms.FrmMdiMain.Database);
                ssmp.AfterShowMessageDialog += new TrasenFrame.Classes.OnAfterShowMessageDialogHandle(ssmp_AfterShowMessageDialog);
                ssmp.CloseShowMessageDialog += new TrasenFrame.Classes.OnCloseShowMessageDialoghandle(ssmp_CloseShowMessageDialog);
                ssmp.Detecting();
            }
            catch (Exception err)
            {
                MessageBox.Show("�����ϵͳ��Ϣʱ��������" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ssmp_CloseShowMessageDialog()
        {
            timerSubSystemMessage.Start();
        }

        void ssmp_AfterShowMessageDialog()
        {
            timerSubSystemMessage.Stop();
        }

        /// <summary>
        /// jianqg 2013-2-22 �Ƿ����Զ������˵� 
        /// </summary>
        /// <param name="tag"></param>
        bool ContainMenu_ts_autosql(TrasenFrame.Classes.MenuTag tag)
        {
            //jianqg 2013-2-22 �Ƿ����Զ������˵�
            if (tag.DllName == "ts_autosql" && tag.Function_Name == "Fun_ts_autosql")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// //jianqg 2012-10�� emr-his������� ���� �Ƿ���� ���Ӳ����˵�
        /// </summary>
        /// <param name="tag"></param>
        void ContainMenu_EmrBussinessHis(MenuCommand menu)
        {
            //jianqg 2012-10�� emr-his������� ���� 
            TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)menu.Tag;
            if (menu_EmrBussinessHis == null && tag.DllName == "EmrBussinessHis" && tag.Function_Name == "Fun_EmrBussinessHis")
            {

                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd)
                    menu_EmrBussinessHis = menu;//ʹ�ù��������½�����˵����ÿ���ʹ�ù�������
                else if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd == false)
                    menu_EmrBussinessHis = menu;//ʹ��˽�������½
            }
        }

        /// <summary>
        /// //jianqg 2012-10�� emr-his������� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sttbMain_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {
            if (e.StatusBarPanel.Name == "sttbpDept")
            {
                menuChangeDept_Click(null, null);
            }
        }
        /// <summary>
        /// ��¼�˵��������־ add  by wangzhi 2013-06-21
        /// </summary>
        /// <param name="sender">����Ĳ˵�����</param>
        private void MenuClickTraceLog(object sender)
        {
            try
            {
                TrasenFrame.Classes.MenuTag tag = (TrasenFrame.Classes.MenuTag)((MenuCommand)sender).Tag;
                string time = this.CurrentTime.ToString("yyyy-MM-dd HH:mm:ss");
                string strLog = string.Format("�û�[{0}]��[{1}]�������ϵͳ[{2}]�еĲ˵����е�[{3}],��¼����[{4}],��������[{5}]",
                    TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, time, TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemName, tag.MenuName, TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName, tag.Function_Name);
                TrasenFrame.Classes.WorkStaticFun.SaveSysLog(strLog, TrasenFrame.Forms.FrmMdiMain.CurrentSystem, tag, TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.Database);
            }
            catch (Exception error)
            {
                System.Collections.Generic.List<string> lstStr = new System.Collections.Generic.List<string>();
                lstStr.Add("��¼�˵������־��������");
                lstStr.Add("������Ϣ��" + error.Message);
                WriteFrameLocalLog(lstStr.ToArray(), true);
            }
        }

        #region �µ���Ϣ������� add by wangzhi 2013-08-01
        //void messageControler_RecivedMessage( TrasenMessage.IMessageProcessor message  )
        //{
        //    //���յ���Ϣ���첽ί�е�����Ϣ��ʾ
        //    ShowRecivedMessageHandler handler = new ShowRecivedMessageHandler( ShowReciveMessage );
        //    handler.BeginInvoke( message  , new AsyncCallback( ReciveMessageCallback ) , "" );
        //}
        ///// <summary>
        ///// ��ʾ��ʱ��Ϣ
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="MsgParamter"></param>
        //private void ShowReciveMessage( TrasenMessage.IMessageProcessor IMessage  )
        //{
        //    TrasenMessage.MessageCommunication msg = (TrasenMessage.MessageCommunication)IMessage;
        //    lock ( _objLock )
        //    {
        //        msg.WriteMessage();

        //        if ( msg.ShowType == 0 )
        //        {
        //            //��������ݷ�ʽ��ʾ���Ա�����ֵ���ɶ�ʱ��ȥ������Ϣ�����Ľ�)
        //            this.newMsg = true;
        //            this.msgSender = msg.Sender;
        //            this.msgContents = msg.MessageString;
        //            this.showTime = msg.ShowTime;
        //            this.showMsg = false;
        //        }
        //        else
        //        {
        //            lock ( _objLock )
        //            {
        //                this.Invoke( new ShowMessageFormHandler( showMessagePopForm ) , msg );
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// �첽ί�еĻص�����
        ///// </summary>
        ///// <param name="result"></param>
        //private void ReciveMessageCallback( IAsyncResult result )
        //{
        //    ShowRecivedMessageHandler hander = (ShowRecivedMessageHandler)( (System.Runtime.Remoting.Messaging.AsyncResult)result ).AsyncDelegate;
        //    hander.EndInvoke( result );
        //}
        ///// <summary>
        ///// ��ʾ���յ�����Ϣ��ί��
        ///// </summary>
        ///// <param name="message"></param>
        ///// <param name="MsgParamter"></param>
        //private delegate void ShowRecivedMessageHandler( TrasenMessage.IMessageProcessor message );
        ///// <summary>
        ///// ��ʾ��Ϣ��������
        ///// </summary>
        ///// <param name="message"></param>
        //private void showMessagePopForm( TrasenMessage.MessageCommunication message )
        //{
        //    if ( dlgMsg == null )
        //    {
        //        dlgMsg = new TrasenMessage.DlgImmediatelyMessage();
        //        dlgMsg.MessageContentClicked += new TrasenMessage.OnMessageContentClickedHander( dlgMsg_MessageContentClicked );
        //        dlgMsg.SetCheckedMessageStatus +=new TrasenMessage.OnSetCheckedMessageStautsHandler(dlgMsg_SetCheckedMessageStatus);
        //        dlgMsg.TopMost = true;
        //    }
        //    dlgMsg.Show();
        //    dlgMsg.BringToFront();
        //    while ( !dlgMsg.IsHandleCreated )
        //    {
        //        //��ѭ������ֹ���ھ����δ������ִ��Invoke����
        //    }
        //    dlgMsg.AddMessage( message );
        //}
        /// <summary>
        /// ������ϢID��������Ҫ����Ϣ�����ڣ�����ģ���е�FORM��
        /// </summary>
        /// <param name="MessageId"></param>
        public void createMoudleForm(Guid MessageId)
        {
            try
            {
                TrasenFrame.Classes.MessageInfo message = new TrasenFrame.Classes.MessageInfo(MessageId, TrasenFrame.Forms.FrmMdiMain.Database);
                if (string.IsNullOrEmpty(message.AssemblyDLL))
                    return;
                //����MenuTag
                TrasenFrame.Classes.MenuTag tag = TrasenFrame.Classes.MenuTag.GetTag(message.AssemblyDLL, message.AssemblyFuncationName, message.AssemblyTag,
                    message.AssemblyFormText, TrasenFrame.Forms.FrmMdiMain.Database);

                if (TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginUsePublicPwd && tag.CanUsePublicPwd == false)
                {
                    MessageBox.Show("�ò˵�������ʹ�ù������룡", "��ʾ��Ϣ");
                    return;
                }

                object objForm = null;
                object[] commucationVal = new object[] { message.AssemblyParameter };
                if (MdiChildFormIsExist(this, tag.MenuName))
                {
                    objForm = this.ActiveMdiChild;
                }
                else
                {
                    RelationalDatabase jgbmDb = null;
                    try
                    {
                        //Modify By Tany 2010-01-14
                        //����ò˵�������ָ���Ǳ��أ���ʹ��ָ������ݿ�����
                        if (tag.Jgbm != -1 && tag.Jgbm != TrasenFrame.Forms.FrmMdiMain.Jgbm)
                        {
                            jgbmDb = TrasenFrame.Classes.WorkStaticFun.GetJgbmDb(tag.Jgbm);

                            objForm = TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                             TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag, tag.System.SystemId, this, jgbmDb, ref commucationVal);
                        }
                        else
                        {
                            objForm = TrasenFrame.Classes.WorkStaticFun.InstanceForm(tag.DllName, tag.Function_Name, tag.MenuName,
                             TrasenFrame.Forms.FrmMdiMain.CurrentUser, TrasenFrame.Forms.FrmMdiMain.CurrentDept, tag, tag.System.SystemId, this, TrasenFrame.Forms.FrmMdiMain.Database, ref commucationVal);
                        }
                        if (((Form)objForm).MdiParent != null)
                        {
                            ((Form)objForm).WindowState = FormWindowState.Maximized;
                            ((Form)objForm).Show();
                        }
                        else
                        {
                            ((Form)objForm).Show();
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "����ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region ��Ĭ��װ.net framework4.0
        private static void InstallDotNetFramework()
        {
            //dotNetFx40 ��Ĭ��װ
            //dotNetFx40_Full_x86_x64.exe /q /norestart /ChainingPackage FullX64Bootstrapper  
            DirectoryInfo[] directories = new DirectoryInfo(Environment.SystemDirectory + @"\..\Microsoft.NET\Framework").GetDirectories("v?.?.*");
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            foreach (DirectoryInfo info2 in directories)
            {
                string ver = info2.Name.Substring(1, 3);
                if (ver == "4.0")
                {
                    return;
                }
            }
            string installFile = System.Windows.Forms.Application.StartupPath + "\\DotNetFramework\\dotNetFx40_Full_x86_x64.exe";
            if (System.IO.File.Exists(installFile))
            {

                string args = "/q /norestart /ChainingPackage FullX64Bootstrapper";
                System.Diagnostics.Process.Start(installFile, args);
            }
            else
            {
                string message = string.Format("��ǰ����û�а�װ.Net Framework4.0, ����δ�ҵ���װ�ļ�{0}", installFile);
                TrasenFrame.Classes.MessageInfo mi = new TrasenFrame.Classes.MessageInfo();
                mi.IsMustRead = false;
                mi.ShowTime = 5;
                mi.Summary = message;
                mi.ReciveStaffer = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;
                TrasenFrame.Classes.WorkStaticFun.SendMessage(mi);
            }
        }
        #endregion

        private void StartMesssageDectectProcess()
        {
            string exeName = System.Windows.Forms.Application.StartupPath + "\\tsmsgDtc.exe";
            if (!System.IO.File.Exists(exeName))
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("TrasenMainWindow.Resources.tsmsgDtc.exe"))
                {
                    byte[] fileByte = new byte[(int)stream.Length];
                    stream.Read(fileByte, 0, (int)stream.Length);
                    using (System.IO.FileStream fs = new System.IO.FileStream(exeName, System.IO.FileMode.Create))
                    {
                        fs.Write(fileByte, 0, fileByte.Length);
                        fs.Flush();
                    }
                    stream.Close();
                }
            }
            if (!System.IO.File.Exists(exeName))
            {
                MessageBox.Show("δ��������Ϣ��������tsmsgDtc.exe", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int currentProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;

            msgProcess = new System.Diagnostics.Process();
            msgProcess.StartInfo.FileName = exeName;
            msgProcess.StartInfo.Arguments = string.Format("/{0} /{1} /{2} /{3} /{4} /{5}",
                TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId,
                TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId,
                TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                this.Handle,
                TrasenFrame.Forms.FrmMdiMain.PortNum,
                currentProcessId
                );
            msgProcess.Start();
            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "TrasenHIS����:" + currentProcessId.ToString() + "�����Ľ���:" + msgProcess.Id }, true);
        }

        private void CloseMessageDectectProcess()
        {
            if (this.msgProcess != null)
            {
                try
                {
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(msgProcess.Id);
                    if (p != null)
                    {
                        p.Kill();
                        p.Dispose();
                        p = null;
                    }
                }
                catch
                {
                    TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog(new string[] { "������Ϣ����δ����" }, true);
                }
            }
        }

        const int WM_COPYDATA = 0x004A;
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            string revMessage = "";
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                    revMessage = mystr.lpData;
                    string flag = revMessage.Substring(0, 1);
                    string sValue = revMessage.Remove(0, 2);
                    if (flag == "0")
                    {
                        //���յ�������ϢID����ʾ��Ҫ���д����
                        createMoudleForm(new Guid(sValue));
                    }
                    else
                    {
                        string[] strDetail = sValue.Split(",".ToCharArray());
                        this.newMsg = true;
                        this.msgSender = strDetail[0];
                        this.msgContents = strDetail[1];
                        this.showTime = Convert.ToInt32(strDetail[2]);
                        this.showMsg = false;
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        //Add By Tany 2015-07-23
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="procName"></param>
        private static void KillProcess(string procName)
        {
            try
            {
                /**********ʹ��cmd����������� add by wangzhi 2013-06-18*************/
                //Classes.Logger.Write("��ʼ�����̲�������ؽ���");
                //����Ҫkill�Ľ����б�
                List<string> lstExe = new List<string>();
                #region Ҫkill����HIS��ؽ���
                //lstExe.Add("TRASEN");
                //lstExe.Add("TRASEN.EXE");
                //lstExe.Add("NEUSOFT");
                //lstExe.Add("NEUSOFT.EXE");
                //lstExe.Add("ONKIY");
                //lstExe.Add("ONKIY.EXE");
                //lstExe.Add("NEUSOFTEMR");
                //lstExe.Add("NEUSOFTEMR.EXE");
                //lstExe.Add("TRASENEMR");
                //lstExe.Add("TRASENEMR.EXE");
                //lstExe.Add("EMRDOCORNURSEVIEW");
                //lstExe.Add("EMRDOCORNURSEVIEW.EXE");
                //lstExe.Add("EMRCONFIG");
                //lstExe.Add("EMRCONFIG.EXE");
                //lstExe.Add("CLIENTCONFIG");
                //lstExe.Add("CLIENTCONFIG.EXE");
                lstExe.Add(procName.ToUpper());
                lstExe.Add(procName.ToUpper() + ".EXE");
                #endregion

                #region ��ȡ��ǰ���н����������е�HIS����ID
                List<int> lstPID = new List<int>();
                try
                {
                    System.Diagnostics.Process[] proces = Process.GetProcesses();
                    foreach (Process p in proces)
                    {
                        //������ǰ���н��̣�Ϊ��ֹ�������ж�ԭʼ�ļ�����ֻҪ��HIS��صĳ������ӵ�KILL�б���
                        string originalFilename = "";
                        try
                        {
                            originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//תΪ��д
                        }
                        catch
                        {
                            //����ϵͳ����ģ��ȵĴ������
                            continue;
                        }
                        //ִ���ļ����Ʋ�Ϊ�ղ�����ɾ���б��д��ڣ�����ӵ�KILL�б���
                        if (!string.IsNullOrEmpty(originalFilename) && lstExe.Contains(originalFilename))
                            lstPID.Add(p.Id);
                    }
                    //Classes.Logger.Write("��������ؽ��̹�" + lstPID.Count.ToString());
                }
                catch (Exception error)
                {
                    //Classes.Logger.Write("�������̷�������", error);
                }
                #endregion

                //ɱ����,����taskkill����ǿ�ƽ�������   
                int killType = 1;
                foreach (int pid in lstPID)
                {
                    if (killType == 0)
                    {
                        #region ����cmd.exe��������
                        //Classes.Logger.Write("��ʼ���Խ�������" + pid.ToString());

                        System.Diagnostics.Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";

                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardError = true;
                        cmd.StartInfo.CreateNoWindow = true;

                        string command = "taskkill /PID " + pid + " /F /T";
                        cmd.Start();
                        cmd.StandardInput.WriteLine(command);
                        //Classes.Logger.Write(command);

                        cmd.StandardInput.WriteLine("exit");
                        //Classes.Logger.Write("exit");
                        cmd.WaitForExit();
                        cmd.Close();

                        //Classes.Logger.Write("ִ�н�����");
                        #endregion
                    }
                    else
                    {
                        #region ʹ��Process���������
                        try
                        {
                            //��һ�ο�ʼ���ҽ���ID
                            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(pid);
                            int count = 1;
                            int maxCount = 3;
                            //����ҵ����̣�����ѭ�����Խ������̣�����ΪmaxCountָ��
                            while (count <= maxCount)
                            {
                                //Classes.Logger.Write(string.Format("���ڵ�{0}���Խ�������{1}", count, pid));
                                p.Kill();
                                p.WaitForExit();
                                try
                                {
                                    //���¸���ID��ȡ����
                                    p = System.Diagnostics.Process.GetProcessById(pid);
                                }
                                catch
                                {
                                    //�������ArgementException,˵�������Ѿ�����,����whileѭ��
                                    //Classes.Logger.Write(string.Format("����{0}�Ѿ�����", pid));
                                    break;
                                }

                                if (count == maxCount)
                                {
                                    //������Դ��������޶�����������ѭ��
                                    //Classes.Logger.Write(string.Format("��������{0}�ν�������{1}ʧ�ܣ�", maxCount, pid));
                                    break;
                                }
                                else
                                {
                                    //���¸���ID��ȡ���̵Ĳ�������ɹ����������һ��ѭ������������
                                    count++;
                                }
                            }
                        }
                        catch (ArgumentException argex)
                        {
                            //��һ�ο�ʼ���ҽ��̷�������
                            //Classes.Logger.Write(string.Format("����{0}δ�������ѽ�����", pid));
                        }
                        catch (Exception error)
                        {
                            //Classes.Logger.Write(string.Format("�ڽ�������{0}ʱ��������", error));
                        }
                        #endregion
                    }
                }
                //Classes.Logger.Write("�����̲�������ؽ��̵Ĵ������");
                return;
            }
            catch
            {
                //throw new Exception("���������޷��ر�" + procName + "Ӧ�ó������ֹ��رճ��������" + err.Message);
                //MessageBox.Show("���������޷��ر����Ӧ�ó������ֹ��رճ��������" + err.Message);
                //return;
            }
        }

        #region ����LIS��Σ��ֵ���� Add By Tany 2015-07-23
        /// <summary>
        /// ����LISΣ��ֵ
        /// </summary>
        private static void LoadLisWjz()
        {
            try
            {
                KillProcess("CISMsg");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\CISMsg.exe";

                if (System.IO.File.Exists(path))
                {
                    string rylx = "";
                    switch (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Rylx)
                    {
                        case EmployeeType.ҽ��:
                            rylx = "ҽ��";
                            break;
                        case EmployeeType.��ʿ:
                            rylx = "��ʿ";
                            break;
                        default:
                            rylx = "����";
                            break;
                    }
                    string ksdm = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select oldid from datamap where newtable='jc_dept_property' and newid='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");
                    ////ѪҺ�ڿƲ��� (��������)   ��  ҽ�� �������ҽ���ʹ� �� ҽ����   ����ǻ�ʿ�ʹ�  ����ʿ����  ��  D1234(��½��ID)  �� 123 ����ID  �������ˣ���½��������
                    string cs = "" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + rylx + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode + "," + ksdm + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "";
                    System.Diagnostics.Process.Start(path, cs);
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion

        #region ����LIS��Σ��ֵ���� Add By HYD 2017-09-20

        private static void LoadPACSWjz()
        {
            try
            {
                KillProcess("IMCISClientTool");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\IMCISClientTool.exe";
               // string path = @"C:\Program Files\IMCISPlugin\" + "\\IMCISClientTool.exe";

                if (System.IO.File.Exists(path))
                {
                    /* string rylx = "";
                     switch (TrasenFrame.Forms.FrmMdiMain.CurrentUser.Rylx)
                     {
                         case EmployeeType.ҽ��:
                             rylx = "ҽ��";
                             break;
                         case EmployeeType.��ʿ:
                             rylx = "��ʿ";
                             break;
                         default:
                             rylx = "����";
                             break;
                     }
                   

                     string ksdm = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select oldid from datamap where newtable='jc_dept_property' and newid='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");
                     //ѪҺ�ڿƲ��� (��������)   ��  ҽ�� �������ҽ���ʹ� �� ҽ����   ����ǻ�ʿ�ʹ�  ����ʿ����  ��  D1234(��½��ID)  �� 123 ����ID  �������ˣ���½��������
                    string cs = "" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + rylx + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.LoginCode + "," + ksdm + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "";
                     */

                    // ���÷�ʽΪ��C:\Program Files\IMCISPlugin\IMCISClientTool.exe �û�����,�û�����,����ID,��������,����

                    string BQMC = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select top 1 WARD_NAME from JC_WARD where DEPT_ID='" + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "'"), "");

                    string UserGH = Convertor.IsNull(TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult("select code  from Pub_User where Employee_Id='" + TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId + "'"), "");
                    string cs = "" + UserGH + "," + TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name + "," + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId + "," + TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName + "," + BQMC + "";
                   // MessageBox.Show("PACS");
                    System.Diagnostics.Process.Start(path, cs);
                   // MessageBox.Show("PACS");
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion


        #region ����ntpʱ�������ͬ�� Add By Tany 2015-10-30
        /// <summary>
        /// ����ntpʱ�������ͬ��
        /// </summary>
        private static void Loadntp()
        {
            try
            {
                KillProcess("ntp");

                string path = TrasenFrame.Classes.Constant.ApplicationDirectory + "\\ntp.exe";

                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                    return;
                }
            }
            catch
            {
            }
        }

        #endregion
    }
}
