using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.InteropServices;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using ts_zyhs_fpcw;
using System.Drawing.Drawing2D;
using System.Diagnostics;
namespace ts_zyhs_cwyl
{
    /// <summary>
    /// ������ ��ժҪ˵����
    /// </summary>
    public class frmCWYL : System.Windows.Forms.Form
    {
        //�Զ����ֶ�
        //public long BinID = 0;
        //public long Baby = 0;
        private BaseFunc myFunc;
        [DllImport("user32.dll")]
        static extern int GetScrollPos(IntPtr hwnd, int bar);
        public delegate void Delegtesroll(int i, int index, ListView lv);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(int hWnd, int Msg, int wParam, int lParam);
        public System.Data.OleDb.OleDbConnection cCon = new OleDbConnection();
        public DataView SelectDataView = null;
        private int bit = 0;  //bit=0 ͼ�� bit=1 ��ͷ��
        private string[] stagArr;
        public static Guid[] openForm = new Guid[10]; //���򿪵�ҽ�������壬����Ϊ10��
        private bool isClose = true;//�Ƿ�Ҫ�ر�
        private bool isCloseC = true;
        string bedno = "";
        string name = "";
        string sex = "";
        string age = "";
        string fb = "";
        string zyh = "";
        string bq = "";
        string tend = "";
        string zd = "";
        string ryrq = "";
        string bc = "";
        PictureBox[] Cpgb;//ͼƬ�ٴ�·��
        //�Ƿ�ʹ�õ��Ӳ��� Add By Tany 2011-07-30
        private bool isUseEMR = false;
        SystemCfg cfg7145 = new SystemCfg(7145);
        SystemCfg cfg7205 = new SystemCfg(7205);
        SystemCfg cfg7600 = new SystemCfg(7600);//Modify by jchl  ��ʿվ���䴲λ�Ƿ�����������λ�ѣ�0��1��  
        #region Windows�ؼ�
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Panel panel����;
        private ts_zyhs_cwyl.myListview listView1;
        private System.Windows.Forms.MenuItem mnb������Ϣ;
        private System.Windows.Forms.MenuItem mnuDYCY;
        private System.Windows.Forms.MenuItem mnb��Ժ�ٻ�;
        private ������Ϣ.PatientInfo patientInfo1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mnuBRZK;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem40;
        private System.Windows.Forms.MenuItem menuItem43;
        private System.Windows.Forms.MenuItem menuItem48;
        private System.Windows.Forms.MenuItem menuItem49;
        private System.Windows.Forms.MenuItem menuItem51;
        private System.Windows.Forms.Panel panBed;
        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private RichTextBoxEx rtbMsg;
        private System.Windows.Forms.MenuItem mnuRefrashBed;
        private System.Windows.Forms.MenuItem mnuOrderPrt;
        private System.Windows.Forms.MenuItem mnuBC;
        private System.Windows.Forms.MenuItem mnuQXBC;
        private System.Windows.Forms.MenuItem mnuFM;
        private System.Windows.Forms.MenuItem mnuOrderQuery;
        private System.Windows.Forms.MenuItem mnuOrderZC;
        private System.Windows.Forms.MenuItem mnuZDLR;
        private System.Windows.Forms.MenuItem mnuFYXX;
        private System.Windows.Forms.MenuItem mnuYPXX;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuXGXX;
        private System.Windows.Forms.MenuItem mnuZC;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imgBED;
        private Panel plDock;
        private Button btRefresh;
        private DataGridView dgvNewPatient;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private MenuItem mnuXgbrxx;
        private MenuItem menuItem1;
        private MenuItem mnuEMR;
        private ImageList ImgCp;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private MenuItem menuItem7;
        private Button btSyncOldHISPatInfo;
        private UcShowCard ucShowCard1;
        private MenuItem menuItem8;
        private System.Windows.Forms.Timer timer1;
        #endregion Windows�ؼ�

        public frmCWYL(string _formText, long _curDeptId, long _curUserId)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();

            DockingPanel();
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (isClose == false) return;
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCWYL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            ""}, -1);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.mnuRefrashBed = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.mnuXGXX = new System.Windows.Forms.MenuItem();
            this.mnuXgbrxx = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuZC = new System.Windows.Forms.MenuItem();
            this.mnuBC = new System.Windows.Forms.MenuItem();
            this.mnuQXBC = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.mnuFM = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.mnuOrderQuery = new System.Windows.Forms.MenuItem();
            this.mnuOrderZC = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuZDLR = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuFYXX = new System.Windows.Forms.MenuItem();
            this.mnuYPXX = new System.Windows.Forms.MenuItem();
            this.mnb������Ϣ = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuBRZK = new System.Windows.Forms.MenuItem();
            this.mnuDYCY = new System.Windows.Forms.MenuItem();
            this.mnb��Ժ�ٻ� = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.mnuOrderPrt = new System.Windows.Forms.MenuItem();
            this.mnuEMR = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panBed = new System.Windows.Forms.Panel();
            this.imgBED = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel���� = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSyncOldHISPatInfo = new System.Windows.Forms.Button();
            this.rtbMsg = new TrasenClasses.GeneralControls.RichTextBoxEx(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.patientInfo1 = new ������Ϣ.PatientInfo();
            this.panel�� = new System.Windows.Forms.Panel();
            this.panel�� = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plDock = new System.Windows.Forms.Panel();
            this.dgvNewPatient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.btRefresh = new System.Windows.Forms.Button();
            this.ImgCp = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new ts_zyhs_cwyl.myListview();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.panel����.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel��.SuspendLayout();
            this.panel��.SuspendLayout();
            this.plDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem48,
            this.mnuRefrashBed,
            this.menuItem6,
            this.menuItem43,
            this.mnuXGXX,
            this.mnuXgbrxx,
            this.menuItem3,
            this.mnuZC,
            this.mnuBC,
            this.mnuQXBC,
            this.menuItem11,
            this.mnuFM,
            this.menuItem20,
            this.mnuOrderQuery,
            this.mnuOrderZC,
            this.menuItem4,
            this.mnuZDLR,
            this.menuItem2,
            this.mnuFYXX,
            this.mnuYPXX,
            this.mnb������Ϣ,
            this.menuItem9,
            this.menuItem10,
            this.menuItem1,
            this.mnuBRZK,
            this.mnuDYCY,
            this.mnb��Ժ�ٻ�,
            this.menuItem40,
            this.mnuOrderPrt,
            this.mnuEMR,
            this.menuItem5,
            this.menuItem7,
            this.menuItem8});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 0;
            this.menuItem48.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem49,
            this.menuItem51});
            this.menuItem48.Text = "��ͼ";
            this.menuItem48.Popup += new System.EventHandler(this.menuItem48_Popup);
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 0;
            this.menuItem49.Text = "ͼ��";
            this.menuItem49.Click += new System.EventHandler(this.viewType_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 1;
            this.menuItem51.Text = "��ͷ��";
            this.menuItem51.Click += new System.EventHandler(this.viewType_Click);
            // 
            // mnuRefrashBed
            // 
            this.mnuRefrashBed.Index = 1;
            this.mnuRefrashBed.Text = "ˢ�´�λ";
            this.mnuRefrashBed.Click += new System.EventHandler(this.mnuRefrashBed_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "����������";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 3;
            this.menuItem43.Text = "-";
            // 
            // mnuXGXX
            // 
            this.mnuXGXX.Index = 4;
            this.mnuXGXX.Text = "�޸Ĺܴ���Ϣ";
            this.mnuXGXX.Click += new System.EventHandler(this.mnuXGXX_Click);
            // 
            // mnuXgbrxx
            // 
            this.mnuXgbrxx.Index = 5;
            this.mnuXgbrxx.Text = "�޸Ĳ�����Ϣ";
            this.mnuXgbrxx.Click += new System.EventHandler(this.mnuXgbrxx_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.Text = "-";
            // 
            // mnuZC
            // 
            this.mnuZC.Index = 7;
            this.mnuZC.Text = "ת��";
            this.mnuZC.Click += new System.EventHandler(this.mnuZC_Click);
            // 
            // mnuBC
            // 
            this.mnuBC.Index = 8;
            this.mnuBC.Text = "����";
            this.mnuBC.Click += new System.EventHandler(this.mnuBCorQXBC_Click);
            // 
            // mnuQXBC
            // 
            this.mnuQXBC.Index = 9;
            this.mnuQXBC.Text = "ȡ������";
            this.mnuQXBC.Click += new System.EventHandler(this.mnuBCorQXBC_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 10;
            this.menuItem11.Text = "-";
            // 
            // mnuFM
            // 
            this.mnuFM.Index = 11;
            this.mnuFM.Text = "";
            this.mnuFM.Click += new System.EventHandler(this.mnuFM_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 12;
            this.menuItem20.Text = "-";
            // 
            // mnuOrderQuery
            // 
            this.mnuOrderQuery.Index = 13;
            this.mnuOrderQuery.Text = "ҽ����ѯ";
            this.mnuOrderQuery.Click += new System.EventHandler(this.mnuOrderQuery_Click);
            // 
            // mnuOrderZC
            // 
            this.mnuOrderZC.Index = 14;
            this.mnuOrderZC.Text = "ҽ��ת��";
            this.mnuOrderZC.Click += new System.EventHandler(this.mnuOrderZC_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 15;
            this.menuItem4.Text = "ҽ���˶�";
            this.menuItem4.Visible = false;
            this.menuItem4.Click += new System.EventHandler(this.mn1���䴲λ_Click);
            // 
            // mnuZDLR
            // 
            this.mnuZDLR.Index = 16;
            this.mnuZDLR.Text = "�˵�¼��";
            this.mnuZDLR.Click += new System.EventHandler(this.mnuZDLR_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 17;
            this.menuItem2.Text = "-";
            // 
            // mnuFYXX
            // 
            this.mnuFYXX.Index = 18;
            this.mnuFYXX.Text = "������Ϣ";
            this.mnuFYXX.Click += new System.EventHandler(this.mnuFYXX_Click);
            // 
            // mnuYPXX
            // 
            this.mnuYPXX.Index = 19;
            this.mnuYPXX.Text = "ҩƷ��Ϣ";
            this.mnuYPXX.Click += new System.EventHandler(this.mnuYPXX_Click);
            // 
            // mnb������Ϣ
            // 
            this.mnb������Ϣ.Index = 20;
            this.mnb������Ϣ.Text = "������Ϣ";
            this.mnb������Ϣ.Visible = false;
            this.mnb������Ϣ.Click += new System.EventHandler(this.mn1���䴲λ_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 21;
            this.menuItem9.Text = "����";
            this.menuItem9.Visible = false;
            this.menuItem9.Click += new System.EventHandler(this.mn1���䴲λ_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 22;
            this.menuItem10.Text = "ȡ������";
            this.menuItem10.Visible = false;
            this.menuItem10.Click += new System.EventHandler(this.mn1���䴲λ_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 23;
            this.menuItem1.Text = "-";
            // 
            // mnuBRZK
            // 
            this.mnuBRZK.Index = 24;
            this.mnuBRZK.Text = "����ת��";
            this.mnuBRZK.Click += new System.EventHandler(this.mnuBRZK_Click);
            // 
            // mnuDYCY
            // 
            this.mnuDYCY.Index = 25;
            this.mnuDYCY.Text = "�����Ժ";
            this.mnuDYCY.Click += new System.EventHandler(this.mnuDYCY_Click);
            // 
            // mnb��Ժ�ٻ�
            // 
            this.mnb��Ժ�ٻ�.Index = 26;
            this.mnb��Ժ�ٻ�.Text = "��Ժ�ٻ�";
            this.mnb��Ժ�ٻ�.Visible = false;
            this.mnb��Ժ�ٻ�.Click += new System.EventHandler(this.mn1���䴲λ_Click);
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 27;
            this.menuItem40.Text = "-";
            // 
            // mnuOrderPrt
            // 
            this.mnuOrderPrt.Index = 28;
            this.mnuOrderPrt.Text = "ҽ����ӡ";
            this.mnuOrderPrt.Click += new System.EventHandler(this.mnuOrderPrt_Click);
            // 
            // mnuEMR
            // 
            this.mnuEMR.Index = 29;
            this.mnuEMR.Text = "���Ӳ���";
            this.mnuEMR.Click += new System.EventHandler(this.mnuEMR_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 30;
            this.menuItem5.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 31;
            this.menuItem7.Text = "ҽ�����";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // panBed
            // 
            this.panBed.AutoScroll = true;
            this.panBed.BackColor = System.Drawing.Color.White;
            this.panBed.ContextMenu = this.contextMenu1;
            this.panBed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBed.Location = new System.Drawing.Point(0, 0);
            this.panBed.Name = "panBed";
            this.panBed.Size = new System.Drawing.Size(1014, 215);
            this.panBed.TabIndex = 3;
            // 
            // imgBED
            // 
            this.imgBED.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgBED.ImageStream")));
            this.imgBED.TransparentColor = System.Drawing.Color.Transparent;
            this.imgBED.Images.SetKeyName(0, "");
            this.imgBED.Images.SetKeyName(1, "");
            this.imgBED.Images.SetKeyName(2, "");
            this.imgBED.Images.SetKeyName(3, "");
            this.imgBED.Images.SetKeyName(4, "");
            this.imgBED.Images.SetKeyName(5, "");
            this.imgBED.Images.SetKeyName(6, "");
            this.imgBED.Images.SetKeyName(7, "");
            this.imgBED.Images.SetKeyName(8, "");
            this.imgBED.Images.SetKeyName(9, "");
            this.imgBED.Images.SetKeyName(10, "");
            this.imgBED.Images.SetKeyName(11, "");
            this.imgBED.Images.SetKeyName(12, "");
            this.imgBED.Images.SetKeyName(13, "");
            this.imgBED.Images.SetKeyName(14, "");
            this.imgBED.Images.SetKeyName(15, "");
            this.imgBED.Images.SetKeyName(16, "");
            this.imgBED.Images.SetKeyName(17, "");
            this.imgBED.Images.SetKeyName(18, "");
            this.imgBED.Images.SetKeyName(19, "");
            this.imgBED.Images.SetKeyName(20, "");
            this.imgBED.Images.SetKeyName(21, "");
            this.imgBED.Images.SetKeyName(22, "");
            this.imgBED.Images.SetKeyName(23, "");
            this.imgBED.Images.SetKeyName(24, "");
            this.imgBED.Images.SetKeyName(25, "");
            this.imgBED.Images.SetKeyName(26, "");
            this.imgBED.Images.SetKeyName(27, "");
            this.imgBED.Images.SetKeyName(28, "");
            this.imgBED.Images.SetKeyName(29, "");
            this.imgBED.Images.SetKeyName(30, "");
            this.imgBED.Images.SetKeyName(31, "");
            this.imgBED.Images.SetKeyName(32, "");
            this.imgBED.Images.SetKeyName(33, "");
            this.imgBED.Images.SetKeyName(34, "");
            this.imgBED.Images.SetKeyName(35, "");
            this.imgBED.Images.SetKeyName(36, "");
            this.imgBED.Images.SetKeyName(37, "");
            this.imgBED.Images.SetKeyName(38, "");
            this.imgBED.Images.SetKeyName(39, "");
            this.imgBED.Images.SetKeyName(40, "");
            this.imgBED.Images.SetKeyName(41, "");
            this.imgBED.Images.SetKeyName(42, "");
            this.imgBED.Images.SetKeyName(43, "");
            this.imgBED.Images.SetKeyName(44, "");
            this.imgBED.Images.SetKeyName(45, "");
            this.imgBED.Images.SetKeyName(46, "");
            this.imgBED.Images.SetKeyName(47, "");
            this.imgBED.Images.SetKeyName(48, "");
            this.imgBED.Images.SetKeyName(49, "");
            this.imgBED.Images.SetKeyName(50, "");
            this.imgBED.Images.SetKeyName(51, "");
            this.imgBED.Images.SetKeyName(52, "");
            this.imgBED.Images.SetKeyName(53, "");
            this.imgBED.Images.SetKeyName(54, "");
            this.imgBED.Images.SetKeyName(55, "");
            this.imgBED.Images.SetKeyName(56, "");
            this.imgBED.Images.SetKeyName(57, "");
            this.imgBED.Images.SetKeyName(58, "");
            this.imgBED.Images.SetKeyName(59, "");
            this.imgBED.Images.SetKeyName(60, "");
            this.imgBED.Images.SetKeyName(61, "");
            this.imgBED.Images.SetKeyName(62, "");
            this.imgBED.Images.SetKeyName(63, "");
            this.imgBED.Images.SetKeyName(64, "");
            this.imgBED.Images.SetKeyName(65, "");
            this.imgBED.Images.SetKeyName(66, "");
            this.imgBED.Images.SetKeyName(67, "");
            this.imgBED.Images.SetKeyName(68, "");
            this.imgBED.Images.SetKeyName(69, "");
            this.imgBED.Images.SetKeyName(70, "");
            this.imgBED.Images.SetKeyName(71, "lg.ico");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            // 
            // panel����
            // 
            this.panel����.Controls.Add(this.panel2);
            this.panel����.Controls.Add(this.panel1);
            this.panel����.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel����.Location = new System.Drawing.Point(0, 215);
            this.panel����.Name = "panel����";
            this.panel����.Size = new System.Drawing.Size(1014, 144);
            this.panel����.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSyncOldHISPatInfo);
            this.panel2.Controls.Add(this.rtbMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(461, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 144);
            this.panel2.TabIndex = 16;
            // 
            // btSyncOldHISPatInfo
            // 
            this.btSyncOldHISPatInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSyncOldHISPatInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSyncOldHISPatInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSyncOldHISPatInfo.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSyncOldHISPatInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSyncOldHISPatInfo.Location = new System.Drawing.Point(363, 118);
            this.btSyncOldHISPatInfo.Name = "btSyncOldHISPatInfo";
            this.btSyncOldHISPatInfo.Size = new System.Drawing.Size(169, 24);
            this.btSyncOldHISPatInfo.TabIndex = 46;
            this.btSyncOldHISPatInfo.Text = "ͬ������ϵͳ������Ϣ";
            this.btSyncOldHISPatInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSyncOldHISPatInfo.Click += new System.EventHandler(this.btSyncOldHISPatInfo_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.BackColor = System.Drawing.SystemColors.Window;
            this.rtbMsg.DetectUrls = false;
            this.rtbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMsg.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbMsg.LinkStyle = true;
            this.rtbMsg.Location = new System.Drawing.Point(0, 0);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(553, 144);
            this.rtbMsg.TabIndex = 14;
            this.rtbMsg.Text = "";
            this.rtbMsg.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbMsg_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.patientInfo1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 144);
            this.panel1.TabIndex = 15;
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 0);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(461, 144);
            this.patientInfo1.TabIndex = 14;
            // 
            // panel��
            // 
            this.panel��.BackColor = System.Drawing.Color.White;
            this.panel��.Controls.Add(this.panel��);
            this.panel��.Controls.Add(this.panel����);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel��.Location = new System.Drawing.Point(0, 0);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1014, 359);
            this.panel��.TabIndex = 5;
            // 
            // panel��
            // 
            this.panel��.Controls.Add(this.listView1);
            this.panel��.Controls.Add(this.panBed);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel��.Location = new System.Drawing.Point(0, 0);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1014, 215);
            this.panel��.TabIndex = 4;
            this.panel��.SizeChanged += new System.EventHandler(this.panel��_SizeChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plDock
            // 
            this.plDock.Controls.Add(this.dgvNewPatient);
            this.plDock.Controls.Add(this.ucShowCard1);
            this.plDock.Controls.Add(this.btRefresh);
            this.plDock.Location = new System.Drawing.Point(55, 84);
            this.plDock.Name = "plDock";
            this.plDock.Size = new System.Drawing.Size(139, 274);
            this.plDock.TabIndex = 6;
            // 
            // dgvNewPatient
            // 
            this.dgvNewPatient.AllowUserToAddRows = false;
            this.dgvNewPatient.AllowUserToDeleteRows = false;
            this.dgvNewPatient.AllowUserToResizeRows = false;
            this.dgvNewPatient.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNewPatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNewPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewPatient.Location = new System.Drawing.Point(0, 50);
            this.dgvNewPatient.MultiSelect = false;
            this.dgvNewPatient.Name = "dgvNewPatient";
            this.dgvNewPatient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNewPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNewPatient.RowHeadersVisible = false;
            this.dgvNewPatient.RowHeadersWidth = 4;
            this.dgvNewPatient.RowTemplate.Height = 23;
            this.dgvNewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewPatient.Size = new System.Drawing.Size(139, 224);
            this.dgvNewPatient.TabIndex = 1;
            this.dgvNewPatient.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNewPatient_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "����";
            this.Column1.HeaderText = "����";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "�Ա�";
            this.Column2.HeaderText = "�Ա�";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 20;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "��������";
            this.Column3.HeaderText = "��������";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "������Դ";
            this.Column4.HeaderText = "������Դ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "סԺ��";
            this.Column6.HeaderText = "סԺ��";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "��Ժ����";
            this.Column5.HeaderText = "��Ժ����";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Ӥ����";
            this.Column7.HeaderText = "Ӥ����";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ID";
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "pat_in_dept";
            this.Column9.HeaderText = "pat_in_dept";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "inpatient_id";
            this.Column10.HeaderText = "inpatient_id";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "baby_id";
            this.Column11.HeaderText = "baby_id";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(0, 29);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(139, 21);
            this.ucShowCard1.TabIndex = 2;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.White;
            this.btRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRefresh.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRefresh.Location = new System.Drawing.Point(0, 0);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(139, 29);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "ˢ�²���(&R)";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // ImgCp
            // 
            this.ImgCp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgCp.ImageStream")));
            this.ImgCp.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgCp.Images.SetKeyName(0, "utsing.gif");
            this.ImgCp.Images.SetKeyName(1, "CP.png");
            this.ImgCp.Images.SetKeyName(2, "dbz1.ico");
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LargeImageList = this.imgBED;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1014, 215);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.GD += new ts_zyhs_cwyl.GdtGt(this.listView1_GD);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.MouseLeave += new System.EventHandler(this.listView1_MouseLeave);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 32;
            this.menuItem8.Text = "�����¼";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // frmCWYL
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1014, 359);
            this.Controls.Add(this.plDock);
            this.Controls.Add(this.panel��);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCWYL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��ʿ����վ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCWYL_Load_1);
            this.Activated += new System.EventHandler(this.frmCWYL_Activated);
            this.Leave += new System.EventHandler(this.frmCWYL_Leave);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCWYL_Closing);
            this.panel����.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel��.ResumeLayout(false);
            this.panel��.ResumeLayout(false);
            this.plDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPatient)).EndInit();
            this.ResumeLayout(false);

        }

        void panel��_SizeChanged(object sender, EventArgs e)
        {
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }

        void listView1_GD()
        {
            int i = 0;
            for (i = 0; i < this.listView1.Items.Count; i++)
            {
                scroll(0, i, listView1);
            }
        }
        private void scroll(int i, int index, ListView mylistView)
        {
            try
            {
                int x = GetScrollPos(mylistView.Handle, 0);
                int y = GetScrollPos(mylistView.Handle, 1);
                if (Cpgb[index] != null)
                    Cpgb[index].Location = new Point(mylistView.Items[index].Position.X + mylistView.LargeImageList.ImageSize.Width - x, mylistView.Items[index].Position.Y + mylistView.LargeImageList.ImageSize.Height - 15 - y);
            }
            catch
            {

            }
        }
        #endregion

        private void DockingPanel()
        {
            DockingManager _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.OuterControl = panel��;
            _dockingManager.InnerControl = panel��;

            Content content = _dockingManager.Contents.Add(plDock, "�²���");
            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;

            content.CloseButton = false;
            //content.
        }



        private void frmCWYL_Load(object sender, System.EventArgs e)
        {
            //Modify by jchl
            mnuZDLR.Visible = false;
            mnuOrderZC.Visible = false;

            //Add By Tany 2005-02-24
            if (CheckBedNo() == false)
            {
                MessageBox.Show("�������д�λ���������غϣ����ֲ������������ش����뼰ʱ֪ͨ��Ϣ�Ƹ��ģ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;

            InitView(bit, 0);
            this.listView1.Focus();

            ShowNewPatient();
        }

        private void frmCWYL_Closing(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] != Guid.Empty)
                {
                    isCloseC = false;
                    break;
                }
            }
            if (isCloseC == false)
            {
                if (MessageBox.Show("����δ�رյ�ҽ��¼�봰�壬�Ƿ�Ҫ�رգ�", "ѯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    isClose = true;
                }
                else
                {
                    isClose = false;
                    e.Cancel = true;
                }
                isCloseC = true;
                return;
            }
        }

        /// <summary>
        /// ��鴲λ����Ƿ����ظ�ֵ
        /// </summary>
        /// <returns></returns>
        private bool CheckBedNo()
        {
            bool isOk = true;
            string sSql = "select bed_no from zy_beddiction where isinuse=0 and ward_id='" + InstanceForm.BCurrentDept.WardId + "' group by bed_no having count(bed_no)>1";
            DataTable bedTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (bedTb.Rows.Count > 0)
            {
                isOk = false;
            }

            return isOk;
        }

        private void InitView(int bit, int pxlx)//bit=0 ͼ�� bit=1 ��ͷ�� pxlx 0=��λ�ţ�1=��������
        {
            string S_Data = "";
            string sSql = "";
            try
            {
                if (bit == 0)
                {
                    panBed.Visible = false;
                    listView1.Visible = true;

                    //Modify by Tany 2005-02-24
                    //����ͣ�ñ�־
                    sSql = "select config from jc_config where id=7044";
                    string px = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql), "0");
                    //if (px.ToString() == "0")
                    //    px = " A.ROOM_NO,dbo.Fun_GetBedToOrder( (case when left(a.bed_no,1)='+' then '999'+a.bed_no else a.bed_no end) )";//Modify by zouchihua 2012-3-12 ��λ�������Ӻ����ж�
                    //else
                    //    px = "dbo.Fun_GetBedToOrder( (case when left(a.bed_no,1)='+' then '999'+a.bed_no else a.bed_no end) )";//Modify by zouchihua 2012-3-12 ��λ�������Ӻ����ж�

                    //Modify by pengy 2014-11-21
                    if (px == "0")
                    {
                        //                        px = @"  A.ROOM_NO asc,
                        //                                 CHARINDEX('+',a.bed_no) ASC,
                        //                                 ISNUMERIC(a.bed_no) DESC,
                        //                                 CAST(substring(a.bed_no,PATindex('%[1234567890]%',a.bed_no),
                        //                                 len(a.bed_no) - patindex('%[1234567890]%',a.bed_no) + 1) as INT)";

                        px = @" A.ROOM_NO asc,
                                case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end";
                    }
                    else
                        //                        px = @"  CHARINDEX('+',a.bed_no) ASC,
                        //                                 ISNUMERIC(a.bed_no) DESC,
                        //                                 CAST(substring(a.bed_no,PATindex('%[1234567890]%',a.bed_no),
                        //                                 len(a.bed_no) - patindex('%[1234567890]%',a.bed_no) + 1) as INT)";
                        px = @"case when isnumeric(a.bed_no)=1 and SUBSTRING (a.bed_no ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',a.bed_no)>0 then 2 when SUBSTRING (a.bed_no ,0,2)='+' then 3  else  4   end ,case when isnumeric(a.bed_no)=1 then cast(a.bed_no as int) else 999999 end,a.bed_no";

                    if (pxlx == 1)
                        px = " c.name,A.ROOM_NO ";
                    sSql = @"SELECT a.Ismzlg ,A.ROOM_NO,A.BED_NO,A.INPATIENT_ID,A.ISBF,A.ISMYTS,A.BED_ID,B.BED_NO as BF_NO,C.AGE,isnull(C.OUT_MODE,0) OUT_MODE, " +
                        "       C.NAME,C.DISCHARGETYPE,C.FLAG,C.SEX_NAME,C.JSFS_NAME,C.TENDLEVEL,C.ORDER_BW,C.ORDER_BZ,yblx_name, A.Baby_ID," +
                        "       convert(char(41),A.INPATIENT_ID)+convert(char(11),A.Baby_ID)+convert(char(11),A.ISMYTS)  + convert(char(11),C.DEPT_ID) + convert(char(11),C.ISMY) + isnull(C.SEX_NAME,'δ֪')+'  '+c.hsj     AS STAG " +//+'  ����'+convert(char(15), dbo.FUN_ZY_SEEKPATFEEYE (A.INPATIENT_ID,0)) 
                        "  FROM ZY_BEDDICTION A left join ZY_BEDDICTION B on a.bf_id=b.bed_id" +
                        "  LEFT JOIN (select * from vi_ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "')  C ON C.INPATIENT_ID=A.INPATIENT_ID AND C.Baby_ID=A.Baby_ID " +
                        "  WHERE A.ISINUSE=0 and A.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' ORDER BY " + px;// (select * from ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId +"') Modify By Tany 2005-01-23
                    DataTable BedTb = InstanceForm.BDatabase.GetDataTable(sSql);
                    this.listView1.Items.Clear();

                    if (BedTb.Rows.Count == 0) return;
                    #region//add by zouchihua �����ٴ�·��ͼ��
                    Cpgb = null;
                    GC.Collect();
                    Cpgb = new PictureBox[BedTb.Rows.Count];
                    this.listView1.Controls.Clear();
                    #endregion
                    #region//add by yaokx 2014-03-04 �����־
                    string cfg7185 = new SystemCfg(7185).Config.Trim();
                    string value = "";
                    if (cfg7185 != "")
                    {
                        string[] ss = cfg7185.Split(',');


                        for (int ii = 0; ii < ss.Length; ii++)
                        {
                            value += "'" + ss[ii] + "',";
                        }
                        value = value.Substring(0, value.Length - 1);
                    }
                    #endregion
                    for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
                    {
                        DataRow BedRow = BedTb.Rows[i];//��ǰΪ��λΪ3λ �����ڸ�Ϊ5 modify by zouchihua 2012-6-1
                        S_Data = BedRow["BED_NO"].ToString().Trim();//ֱ��ȡ��λ //BedRow["BED_NO"].ToString().Trim().Length >= 5 ? BedRow["BED_NO"].ToString().Trim().Substring(0, 5) : BedRow["BED_NO"].ToString().Trim() + myFunc.Repeat_Space(5 - BedRow["BED_NO"].ToString().Trim().Length);
                        if (BedRow["ORDER_BW"].ToString().Trim() != "0" && BedRow["ORDER_BW"].ToString().Trim() != "") S_Data += "*";
                        if (BedRow["ORDER_BZ"].ToString().Trim() != "0" && BedRow["ORDER_BZ"].ToString().Trim() != "") S_Data += "��";
                        string gl = " ";
                        if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() != "" && value != "")
                        {
                            string strgl = "select * from zy_orderrecord where inpatient_id='" + BedRow["INPATIENT_ID"] + "' and delete_bit=0 and status_flag>=2 and status_flag<4 and HOITEM_ID in (" + value + ")";
                            DataTable dtgl = InstanceForm.BDatabase.GetDataTable(strgl);
                            if (dtgl != null)
                            {
                                if (dtgl.Rows.Count > 0)
                                {
                                    gl = " ����," + dtgl.Rows[0]["ORDER_CONTEXT"].ToString();
                                }
                            }
                        }

                        if (BedRow["Ismzlg"].ToString().Trim() == "1")
                        {
                            this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                        }
                        else
                        {
                            if (Convert.ToString(BedRow["INPATIENT_ID"]).Trim() == "")
                            {
                                if (BedRow["ISBF"].ToString() == "1")
                                {
                                    S_Data += "\r\n" + "(" + BedRow["BF_NO"].ToString().Trim() + "�� ��)";
                                }
                                try
                                {
                                    this.listView1.Items.Add(S_Data.Trim(), 0).Tag = Convert.ToString(BedRow["STAG"]);
                                }
                                catch { this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl; }
                            }
                            else
                            {
                                if (BedRow["DISCHARGETYPE"].ToString() == "1")
                                {
                                    if (cfg7145.Config.Trim() == "0")
                                        S_Data += "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //ҽ��	
                                    else
                                    {
                                        string str3 = " select * from zy_yb_shxx  where inpatient_id='" + BedRow["INPATIENT_ID"].ToString() + "' and ybjs_bit=0  and isnull(delete_bit,0)=0 ";
                                        DataTable table2 = InstanceForm.BDatabase.GetDataTable(str3);
                                        if (table2.Rows.Count != 0)
                                        {
                                            if (table2.Rows[0]["hs_shbz"].ToString() == "1")
                                            {
                                                if (table2.Rows[0]["RYSH"].ToString() == "1")
                                                {
                                                    S_Data = S_Data + "(��" + Convert.ToString(BedRow["yblx_name"]).Trim() + ")";
                                                }
                                                else
                                                {
                                                    S_Data = S_Data + "(��" + Convert.ToString(BedRow["yblx_name"]).Trim() + ")";
                                                }
                                            }
                                            else
                                            {
                                                S_Data = S_Data + "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //ҽ��	
                                            }
                                        }
                                        else
                                        {
                                            S_Data = S_Data + "(" + BedRow["yblx_name"].ToString().Trim() + ")";   //ҽ��	
                                        }
                                    }
                                    //S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                                }
                                S_Data += "\r\n" + Convert.ToString(BedRow["NAME"]).Trim();
                                if (BedRow["ISBF"].ToString() == "1")
                                {
                                    S_Data += "(��)";
                                }

                                //							int m=0,n=0;					
                                //							if (BedRow["SEX_NAME"].ToString().Trim()=="��")
                                //								n=0;  //��
                                //							else
                                //								n=(BedRow["ISMYTS"].ToString()=="0"? 1:2);          //Ů��ĸӤ
                                //					
                                //							if (BedRow["FLAG"].ToString() =="4")        //�����Ժ 						
                                //								this.listView1.Items.Add(S_Data.Trim(),n+1).Tag=Convert.ToString(BedRow["STAG"]);
                                //							else 
                                //							{
                                //								m=(Convert.ToString(BedRow["TENDLEVEL"]).Trim()==""?0:Convert.ToInt32(BedRow["TENDLEVEL"]));  // ������
                                //								this.listView1.Items.Add(S_Data.Trim() ,n*5+m+4).Tag=Convert.ToString(BedRow["STAG"]);
                                //							}

                                //��λͼ����ʾ
                                //1=3���������Ա�2=4~12Ů3=13~22Ů4=23~59Ů5=60+Ů6=4~12��7=13~22��8=23~59��9=60+��10=ĸӤ
                                //1-10  ��ͨ
                                //11-20 ����
                                //21-30 ��Ժ
                                //31-40 һ������
                                //41-50 ��������
                                //51-60 ��������
                                //61-70 �ؼ�����

                                int m = 0;//������
                                int n = 0;//ͼƬλ��
                                int _type = 0;//����
                                if (BedRow["FLAG"].ToString() == "4")        //�����Ժ 	
                                {
                                    //����
                                    if (Convert.ToInt32(BedRow["OUT_MODE"]) == 4)
                                    {
                                        _type = 1;
                                    }
                                    else
                                    {
                                        _type = 2;
                                    }
                                    try
                                    {
                                        n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                                        this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                    catch
                                    {
                                        this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                }
                                else
                                {
                                    m = (Convert.ToString(BedRow["TENDLEVEL"]).Trim() == "" ? 0 : Convert.ToInt32(BedRow["TENDLEVEL"]));  // ������
                                    switch (m)
                                    {
                                        case 0://��ͨ
                                            _type = 0;
                                            break;
                                        case 1://����
                                            _type = 5;
                                            break;
                                        case 2://����
                                            _type = 4;
                                            break;
                                        case 3://һ��
                                            _type = 3;
                                            break;
                                        case 4://�ؼ�
                                            _type = 6;
                                            break;
                                        default:
                                            _type = 0;
                                            break;
                                    }
                                    try
                                    {
                                        n = GetBedImgNO(BedRow["SEX_NAME"].ToString().Trim(), Convert.ToInt32(BedRow["AGE"]), _type, Convert.ToInt32(BedRow["ISMYTS"]));
                                        this.listView1.Items.Add(S_Data.Trim(), n).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                    catch
                                    {
                                        this.listView1.Items.Add(S_Data.Trim(), 71).Tag = Convert.ToString(BedRow["STAG"]) + gl;
                                    }
                                }
                            }
                        }
                        #region  //add by zouchihua 2012-11-01
                        string cpstatus = this.myFunc.GetCpzt(Convert.ToString(BedRow["INPATIENT_ID"]).Trim(), "0").ToString();
                        if (cpstatus.IndexOf("1") >= 0 || cpstatus.IndexOf("9") >= 0)
                        {
                            Cpgb[i] = new PictureBox();
                            if (cpstatus == "9")
                                Cpgb[i].Name = Convert.ToString(i) + "������";
                            Cpgb[i].Tag = i;
                            Cpgb[i].Size = new Size(20, 20);
                            //gb[i].MouseClick += new MouseEventHandler(Form3_MouseClick);
                            Cpgb[i].MouseEnter += new EventHandler(frmMain_MouseEnter1);
                            // Cpgb[i].MouseDoubleClick += new MouseEventHandler(frmMain_MouseDoubleClick1);
                            Cpgb[i].Location = new Point(this.listView1.Items[i].Position.X + this.listView1.LargeImageList.ImageSize.Width, this.listView1.Items[i].Position.Y + this.listView1.LargeImageList.ImageSize.Height - 15);
                            if (cpstatus == "15")
                                Cpgb[i].Image = this.ImgCp.Images[0];
                            else
                                if (cpstatus.Trim() == "9")
                                    Cpgb[i].Image = this.ImgCp.Images[2];
                                else
                                    Cpgb[i].Image = this.ImgCp.Images[1];
                            this.listView1.Controls.Add(Cpgb[i]);
                        }
                        #endregion

                    }
                }
                else if (bit == 1)
                {
                    int x = 9;
                    int y = 9;

                    panBed.Visible = true;
                    listView1.Visible = false;

                    //Modify by Tany 2005-02-24
                    //����ͣ�ñ�־
                    sSql = @"SELECT A.ROOM_NO,A.BED_NO,A.INPATIENT_ID,A.ISBF,A.ISMYTS,A.BED_ID,c.inpatient_no," +
                        "       C.NAME,C.DISCHARGETYPE,C.FLAG,C.SEX_NAME,c.age,C.JSFS_NAME,C.TENDLEVEL,C.ORDER_BW,C.ORDER_BZ,dbo.fun_getdate(c.in_date) in_date,c.in_diagnosis,c.ryzd," +
                        "       convert(char(41),A.INPATIENT_ID)+convert(char(11),A.Baby_ID)+convert(char(11),A.ISMYTS)  + convert(char(11),C.DEPT_ID) + convert(char(11),C.ISMY) + isnull(C.SEX_NAME,'δ֪') AS STAG " +
                        "  FROM ZY_BEDDICTION A LEFT JOIN (select * from vi_ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId + "')  C ON C.INPATIENT_ID=A.INPATIENT_ID AND C.Baby_ID=A.Baby_ID " +
                        " WHERE A.ISINUSE=0 and A.WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' ORDER BY A.ROOM_NO,dbo.Fun_GetBedToOrder(A.BED_NO)";// (select * from ZY_vInpatient_Bed where WARD_ID='" + InstanceForm.BCurrentDept.WardId +"') Modify By Tany 2005-01-23
                    DataTable BedTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    panBed.Controls.Clear();

                    stagArr = new string[BedTb.Rows.Count];

                    if (BedTb.Rows.Count == 0) return;

                    for (int i = 0; i <= BedTb.Rows.Count - 1; i++)
                    {
                        Button bt = new Button();

                        bt.AllowDrop = true;
                        bt.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(227)), ((System.Byte)(236)));
                        bt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                        bt.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
                        bt.Size = new System.Drawing.Size(80, 105);
                        bt.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                        bt.Location = new System.Drawing.Point(x, y);
                        bt.Name = "bt" + i.ToString();
                        bt.Paint += new System.Windows.Forms.PaintEventHandler(button_Paint);
                        bt.Click += new EventHandler(bt_Click);
                        //						bt.DoubleClick += new EventHandler(bt_DoubleClick);
                        bt.MouseDown += new MouseEventHandler(bt_MouseDown);
                        //						bt.MouseHover += new EventHandler(bt_Click);

                        if (x + 169 >= this.panBed.Width)
                        {
                            y = y + 114;
                            x = this.panBed.Location.X + 9;
                        }
                        else
                        {
                            x = x + 89;
                        }

                        int ll = 0;
                        //����10λ
                        if (BedTb.Rows[i]["bed_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["bed_no"].ToString().Trim().Length;
                            bt.Tag = BedTb.Rows[i]["bed_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["bed_no"].ToString().Trim().Substring(0, 10);
                        }
                        //����6λ
                        if (BedTb.Rows[i]["name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["name"].ToString().Trim().Substring(0, 6);
                        }
                        //�Ա�2λ
                        if (BedTb.Rows[i]["sex_name"].ToString().Trim().Length <= 2)
                        {
                            ll = 2 - BedTb.Rows[i]["sex_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["sex_name"].ToString().Trim().Substring(0, 2);
                        }
                        //����3λ
                        if (BedTb.Rows[i]["age"].ToString().Trim().Length <= 3)
                        {
                            ll = 3 - BedTb.Rows[i]["age"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["age"].ToString().Trim().Substring(0, 3);
                        }
                        //�������6λ
                        if (BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length <= 6)
                        {
                            ll = 6 - BedTb.Rows[i]["jsfs_name"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["jsfs_name"].ToString().Trim().Substring(0, 6);
                        }
                        //סԺ��10λ
                        if (BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["inpatient_no"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //����10λ
                        string s_bq = "";
                        if (BedTb.Rows[i]["order_bw"].ToString() != "0" && BedTb.Rows[i]["order_bw"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "*" + "��Σ";
                        if (BedTb.Rows[i]["order_bz"].ToString() != "0" && BedTb.Rows[i]["order_bz"].ToString() != "" && BedTb.Rows[i]["inpatient_no"].ToString() != "")
                            s_bq = s_bq + "��" + "����";
                        if (s_bq.Length <= 10)
                        {
                            ll = 10 - s_bq.Length;
                            bt.Tag = bt.Tag + s_bq + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag += BedTb.Rows[i]["inpatient_no"].ToString().Trim().Substring(0, 10);
                        }
                        //����10λ
                        string s_hl = "";
                        switch (BedTb.Rows[i]["TENDLEVEL"].ToString())
                        {
                            case "4":
                                s_hl = "�ؼ�����";
                                break;
                            case "3":
                                s_hl = "һ������";
                                break;
                            case "2":
                                s_hl = "��������";
                                break;
                            case "1":
                                s_hl = "��������";
                                break;
                        }
                        if (s_hl.Length <= 10)
                        {
                            ll = 10 - s_hl.Length;
                            bt.Tag = bt.Tag + s_hl + Space(ll);
                        }
                        else
                        {
                            //bt.Tag = bt.Tag + BedTb.Rows[i]["in_diagnosis"].ToString().Trim().Substring(0, 10);
                            //Modify by Tany 2010-03-17 ��Ժ�������
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //���10λ
                        if (BedTb.Rows[i]["ryzd"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["ryzd"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["ryzd"].ToString().Trim().Substring(0, 10);
                        }
                        //��Ժʱ��10λ
                        if (BedTb.Rows[i]["in_date"].ToString().Trim().Length <= 10)
                        {
                            ll = 10 - BedTb.Rows[i]["in_date"].ToString().Trim().Length;
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim() + Space(ll);
                        }
                        else
                        {
                            bt.Tag = bt.Tag + BedTb.Rows[i]["in_date"].ToString().Trim().Substring(0, 10);
                        }
                        //ĸӤͬ��6λ
                        string s_myts = "";
                        if (BedTb.Rows[i]["ismyts"].ToString() == "1" && cfg7205.Config == "0")
                            s_myts = "(ĸӤͬ��)";
                        else
                            s_myts = Space(6);
                        bt.Tag = bt.Tag + s_myts;
                        //����3λ
                        string s_bf = "";
                        if (BedTb.Rows[i]["isbf"].ToString() == "1")
                            s_bf = "(��)";
                        else
                            s_bf = Space(3);
                        bt.Tag = bt.Tag + s_bf;
                        //��Ժ״̬6λ
                        string s_cy = "";
                        if (BedTb.Rows[i]["FLAG"].ToString() == "6")
                            s_cy = "(�����Ժ)";
                        else
                            s_cy = Space(6);
                        bt.Tag = bt.Tag + s_cy;

                        this.toolTip1.SetToolTip(bt, "��        �ţ�" + bt.Tag.ToString().Substring(0, 10).Trim() +
                            bt.Tag.ToString().Substring(77, 6).Trim() + bt.Tag.ToString().Substring(83, 3).Trim() + bt.Tag.ToString().Substring(86, 6).Trim() + "\n" +
                            "��        ����" + bt.Tag.ToString().Substring(10, 6) + "\n" +
                            "��        ��" + bt.Tag.ToString().Substring(16, 2) + "\n" +
                            "��        �䣺" + bt.Tag.ToString().Substring(18, 3) + "\n" +
                            "�������" + bt.Tag.ToString().Substring(21, 6) + "\n" +
                            "ס  Ժ  �ţ�" + bt.Tag.ToString().Substring(27, 10) + "\n" +
                            "��        �飺" + bt.Tag.ToString().Substring(37, 10) + "\n" +
                            "������" + bt.Tag.ToString().Substring(47, 10) + "\n" +
                            "��Ժ��ϣ�" + bt.Tag.ToString().Substring(57, 10) + "\n" +
                            "��Ժ���ڣ�" + bt.Tag.ToString().Substring(67, 10));

                        stagArr[i] = BedTb.Rows[i]["stag"].ToString();
                        panBed.Controls.Add(bt);

                    }
                }

                rtbMsg.Text = ShowMsgText();

            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }
        void frmMain_MouseEnter1(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();

            t.Show(((sender as PictureBox).Name.IndexOf("������") >= 0 ? "�ò��˽��뵥���ֹ���" : "�ò��˽����ٴ�·������"), this.listView1, (sender as PictureBox).Location.X + (sender as PictureBox).Height, (sender as PictureBox).Location.Y + 20, 1000);
        }

        /// <summary>
        /// ��ô�λͼƬ�����
        /// </summary>
        /// <param name="_sex">�Ա�</param>
        /// <param name="_age">����</param>
        /// <param name="_type">����(0=��ͨ1=����2=��Ժ3=һ������4=��������5=��������6=�ؼ�����)</param>
        /// <param name="_ismy">�Ƿ�ĸӤ</param>
        /// <returns></returns>
        private int GetBedImgNO(string _sex, int _age, int _type, int _ismy)
        {
            //1=3���������Ա�2=4~12Ů3=13~22Ů4=23~59Ů5=60+Ů6=4~12��7=13~22��8=23~59��9=60+��10=ĸӤ
            //1-10  ��ͨ
            //11-20 ����
            //21-30 ��Ժ
            //31-40 һ������
            //41-50 ��������
            //51-60 ��������
            //61-70 �ؼ�����
            int m = 0;//�����
            int n = 0;//��Ů��������λ�ò�
            int _rtn = 0;
            if (cfg7205.Config == "1" && _ismy > 0)
            {
                if (_sex == "��")
                    n = 4;  //�д�4λ��ʼ
                else
                    n = 0;//Ů��0λ��ʼ
            }
            else
            {
                if (_sex == "��")
                    n = 4;  //�д�4λ��ʼ
                else
                    n = 0;//Ů��0λ��ʼ
            }

            //3�����²�����Ů
            if (_age <= 3)
            {
                m = 1;
                _rtn = _type * 10 + m;
            }
            if (_age > 3 && _age <= 12)
            {
                m = 2;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 12 && _age <= 22)
            {
                m = 3;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 22 && _age <= 59)
            {
                m = 4;
                _rtn = _type * 10 + m + n;
            }
            if (_age > 59)
            {
                m = 5;
                _rtn = _type * 10 + m + n;
            }
            //���ĸӤֱ��ȡ���һλ
            if (cfg7205.Config == "0")
            {
                if (_ismy > 0)
                {
                    _rtn = _type * 10 + 10;
                }
            }

            return _rtn;
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count >= 1)
                {
                    string STAG = Convert.ToString(this.listView1.SelectedItems[0].Tag);
                    if ((STAG.Trim() != "") && (STAG != null))
                    {
                        ClassStatic.Current_BinID = new Guid(STAG.Substring(0, 41).Trim());
                        ClassStatic.Current_BabyID = Convert.ToInt64(STAG.Substring(41, 11).Trim());
                        ClassStatic.Current_isMYTS = Convert.ToInt16(STAG.Substring(52, 11).Trim());
                        ClassStatic.Current_DeptID = Convert.ToInt64(STAG.Substring(63, 11).Trim());
                        ClassStatic.Current_isMY = Convert.ToInt16(STAG.Substring(74, 11));
                        this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);

                        DataRow dr = patientInfo1.myRow;
                        if (dr != null)
                        {
                            string msg = "";
                            msg += "��        �ţ�" + patientInfo1.lbBed.Text + "\n";
                            msg += "��        ����" + patientInfo1.lbName.Text + "\n";
                            msg += "��        ��" + patientInfo1.lbSex.Text + "\n";
                            msg += "��        �䣺" + patientInfo1.lbAge.Text + "\n";
                            msg += "�������" + patientInfo1.lbJSLX.Text + "\n";
                            msg += "ס  Ժ  �ţ�" + patientInfo1.lbID.Text + "\n";
                            msg += "��  ��  ID��" + Convertor.IsNull(dr["inpatient_bano"], "") + "\n"; //Add By tany 2015-04-23 ���Ӳ���ID��ʾ
                            //����
                            string s_bq = "";
                            if (dr["order_bw"].ToString() != "0" && dr["order_bw"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "*" + "��Σ";
                            if (dr["order_bz"].ToString() != "0" && dr["order_bz"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                                s_bq = s_bq + "��" + "����";
                            //try
                            //{ 
                            //    if (dr["order_ph"].ToString() != "0" && dr["order_ph"].ToString() != "" && dr["inpatient_no"].ToString() != "")
                            //        s_bq = s_bq + " " + "�㻤";
                            //}
                            //catch { }
                            msg += "��        �飺" + s_bq + "\n";
                            msg += "������" + (dr["HLJB_NAME"].ToString().Trim().Length > 4 ? dr["HLJB_NAME"].ToString().Trim().Substring(0, 4) : dr["HLJB_NAME"].ToString().Trim()) + dr["order_ph"].ToString() + "\n";// //add by zouchihua 2013-8-1 �����㻤ѡ��
                            msg += "��Ժ��ϣ�" + patientInfo1.lbRYZD.Text + "\n";
                            msg += "��Ժ���ڣ�" + patientInfo1.lbIn_Date.Text + "\n";
                            msg += "�����ܶ" + patientInfo1.lbFYZE.Text + "\n";
                            msg += "δ����" + patientInfo1.lbWJSFY.Text + "\n";
                            msg += "Ԥ  ��  �" + patientInfo1.lbYJK.Text + "\n";
                            msg += "Ƿ���޶" + Convert.ToDecimal(dr["yjj_limit"]).ToString("0.00") + "\n";//Add By tany 2010-11-27
                            msg += "��        �" + patientInfo1.lbYE.Text + "\n";
                            msg += "��        ʾ��" + patientInfo1.lbTs.Text + "\n";
                            if (Convert.ToDecimal(Convertor.IsNull(dr["fyxz"], "0")) > 0)
                            {
                                msg += "�������ƣ�" + Convert.ToDecimal(dr["fyxz"]).ToString("0.00") + "\n";
                            }
                            if (Convertor.IsNull(dr["ybjs_date"], "") != "")
                            {
                                msg += "����ʱ�䣺" + Convert.ToDateTime(dr["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\n";
                                msg += "ҽ���ܶ" + Convert.ToDecimal(dr["ybzfy"]).ToString("0.00") + "\n";
                                msg += "ͳ��֧����" + Convert.ToDecimal(dr["tczf"]).ToString("0.00") + "\n";
                                msg += "�˻�֧����" + Convert.ToDecimal(dr["zhzf"]).ToString("0.00") + "\n";
                                msg += "����֧����" + Convert.ToDecimal(dr["qtzf"]).ToString("0.00") + "\n";
                                msg += "�ֽ�֧����" + Convert.ToDecimal(dr["xjzf"]).ToString("0.00") + "\n";
                                msg += "ҽ����" + Convert.ToDecimal(Convert.ToDecimal(dr["yjk"]) - Convert.ToDecimal(dr["xjzf"])).ToString("0.00") + "\n";
                            }
                            string ryshbz = Convertor.IsNull(dr["rysh_bz"], "");
                            if (ryshbz != "")
                            {
                                msg += "��Ժ��ע��" + ryshbz + "\n";
                            }
                            //Add By Tany 2011-01-05
                            msg += "��        ����" + dr["SICKDESCRIPTION"].ToString().Trim() + "\n";
                            toolTip1.Show(msg, listView1, this.listView1.SelectedItems[0].Position.X + 50, this.listView1.SelectedItems[0].Position.Y + 40, 60000);
                        }
                        else
                        {
                            toolTip1.Hide(listView1);
                        }
                    }
                    else
                    {
                        this.patientInfo1.ClearInpatientInfo();
                        ClassStatic.Current_BinID = Guid.Empty;
                        ClassStatic.Current_BabyID = 0;
                        ClassStatic.Current_DeptID = 0;
                        ClassStatic.Current_isMYTS = 0;
                        ClassStatic.Current_isMY = 0;

                        toolTip1.Hide(listView1);
                    }
                }
                else
                {
                    toolTip1.Hide(listView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            toolTip1.Hide(listView1);
            DragDropEffects dropEffect = listView1.DoDragDrop(e.Item, DragDropEffects.All | DragDropEffects.Link);
        }

        private void listView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem dragItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                if (dragItem.ListView.Equals(listView1))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        //
        private bool IsTimeRight(string dtRyrq)
        {
            try
            {
                string dtNow = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd");

                string ryrq = DateTime.Parse(dtRyrq).ToString("yyyy-MM-dd");

                return dtNow.Equals(ryrq);
            }
            catch { return false; }
        }

        private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                #region ����
                string sSql = "", sMsg = "";
                string old_bed_no, new_bed_no;
                long old_dept_id, new_dept_id;
                Guid old_bed_id, new_bed_id;

                //��Ļ�����ת��
                System.Drawing.Point p = new Point(e.X, e.Y);
                Point p1 = listView1.PointToClient(p);

                //�õ���ǰ��VIEWITEM
                System.Windows.Forms.ListViewItem new_item = listView1.GetItemAt(p1.X, p1.Y);
                System.Windows.Forms.ListViewItem old_item = listView1.SelectedItems[0];

                //���VIEWITEM��Ϊ�գ���ִ��ת������
                if (new_item != null)
                {
                    if (new_item.Text == old_item.Text) return;

                    //i=old_item.Text.Trim().IndexOf("-",0,old_item.Text.Trim().Length);
                    //j=old_item.Text.Trim().IndexOf("\r",0,old_item.Text.Trim().Length);
                    //old_bed_no=old_item.Text.Trim().Substring(i+1,j-i-1);
                    if (old_item.Text.IndexOf("*") < 0)
                    {
                        if (old_item.Text.IndexOf("��") < 0)
                        {
                            if (old_item.Text.IndexOf("(") < 0)
                            {
                                // old_bed_no = old_item.Text.Trim().Substring(0, 4).Trim(); �̶�ȡ4λ���У�ȡ�����з�Ϊֹ�ȽϺ� Modify BY Tany 2014-12-04
                                old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("\r")).Trim();//old_item.Text.Trim().Substring(0,1)=="��" + old_item.Text.Trim().Substring(0,1)=="��"?old_item.Text.Trim().Substring(0,3):old_item.Text.Trim().Substring(0,2);
                            }
                            else
                            {
                                old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("("));
                            }
                        }
                        else
                            old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("��"));
                    }
                    else
                        old_bed_no = old_item.Text.Trim().Substring(0, old_item.Text.IndexOf("*"));
                    sSql = "select bed_id,INPATIENT_ID,isbf,INPATIENT_dept,bedsex from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + old_bed_no + "'";
                    DataTable old_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);

                    #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(new Guid(old_tempTab.Rows[0]["INPATIENT_ID"].ToString()));

                    if (rtnSql[2] != "0")
                    {
                        MessageBox.Show("���ڿ�Ժ��������δ��ɣ������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion
                    if (Convert.ToInt16(old_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "�Բ��𣬰�������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    old_bed_id = new Guid(old_tempTab.Rows[0]["bed_id"].ToString());
                    old_dept_id = Convert.ToInt32(old_tempTab.Rows[0]["INPATIENT_dept"]);

                    //i=new_item.Text.Trim().IndexOf("-",0,new_item.Text.Trim().Length);
                    //j=new_item.Text.Trim().IndexOf("\r",0,new_item.Text.Trim().Length);
                    //j=(j==-1?j=new_item.Text.Trim().Length:j);
                    //new_bed_no=new_item.Text.Trim().Substring(i+1,j-i-1);
                    new_bed_no = new_item.Text.Trim();//.Substring(0,1)=="��"?new_item.Text.Trim().Substring(0,3):new_item.Text.Trim().Substring(0,2);
                    sSql = "select bed_id,INPATIENT_ID,isbf,dept_id,room_no from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + new_bed_no + "'";
                    DataTable new_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (new_tempTab.Rows[0]["INPATIENT_ID"].ToString().Trim() != "")
                    {
                        MessageBox.Show(this, "�Բ���Ŀ�괲λ���ǿմ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt16(new_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "�Բ���Ŀ�괲λ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    new_bed_id = new Guid(new_tempTab.Rows[0]["bed_id"].ToString());
                    new_dept_id = Convert.ToInt32(new_tempTab.Rows[0]["dept_id"]);

                    //�Ա��ж�
                    sSql = @"select * from zy_BedDiction " +
                        " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                        "   and room_no='" + new_tempTab.Rows[0]["room_no"].ToString().Trim() + "'" +
                        "   and inpatient_id is not null " +
                        "   and bedsex!='" + old_tempTab.Rows[0]["bedsex"].ToString() + "'";
                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (tempTab.Rows.Count > 0)
                    {
                        sMsg = "Ŀ�귿��ס�����Բ��ˣ�";
                    }

                    if (new_dept_id != old_dept_id)
                    {
                        //if (MessageBox.Show(this, "������λ���������Ҳ���ͬ��" + sMsg + "�Ƿ�ȷ��ת����", "ת��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                        //Modify By Tany 2016-11-21 ����������ת��
                        MessageBox.Show(this, "Ŀ�괲λ���ڡ�" + new Department(new_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "������ǰ�������ڡ�" + new Department(old_dept_id, InstanceForm.BDatabase).DeptName.Trim() + "��\r\n������λ���������Ҳ���ͬ�������������", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        if (patientInfo1.IsShow)
                        {
                            if (MessageBox.Show(this, sMsg + "�Ƿ�ȷ�Ͻ� [" + old_bed_no + "��] ����ת�� [" + new_bed_no + "��] ��", "ת��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        else
                        {
                            patientInfo1.IsShow = true;
                            return;
                        }
                    }

                    string _outmsg = myFunc.ChangeBed("", 1, old_bed_id, new_bed_id, InstanceForm.BCurrentUser.EmployeeId, FrmMdiMain.Jgbm);

                    if (_outmsg.Trim() != "")
                    {
                        MessageBox.Show(_outmsg);
                    }

                    //ˢ��LISTVIEW
                    InitView(bit, 0);

                    //д��־ Add By Tany 2005-01-12
                    SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "ת��", _outmsg + "�Ѳ��� " + ClassStatic.Current_BinID + " ��" + old_bed_id.ToString() + "��λ����ת��" + new_bed_id.ToString() + "��λ����", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;
                }
                #endregion
            }
            else if (e.Data.GetDataPresent(typeof(int)))
            {
                #region ���䴲λ
                //����
                DataTable tb = (DataTable)this.dgvNewPatient.DataSource;

                if (tb == null || tb.Rows.Count == 0)
                {
                    return;
                }

                int nrow = (int)e.Data.GetData(typeof(int));
                Guid _inpatientid = new Guid(tb.Rows[nrow]["inpatient_id"].ToString());
                long _babyid = Convert.ToInt64(tb.Rows[nrow]["baby_id"].ToString());

                //Modify by jchl
                if (!IsTimeRight(tb.Rows[nrow]["��Ժ����"].ToString()))
                {
                    //������䴲λ���ں���Ժ���ڲ���ͬ
                    if (MessageBox.Show("���䴲λ�������� �� ��Ժ���ڣ�" + tb.Rows[nrow]["��Ժ����"].ToString() + "����ͬ,�Ƿ����", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                        return;
                }

                //����ˢ�²�����Ϣ Modify By Tany 2010-04-15
                string tSql = "select * from vi_zy_vinpatient where flag not in (2,6,10) and inpatient_id='" + _inpatientid + "' and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                DataTable tTb = InstanceForm.BDatabase.GetDataTable(tSql);

                if (tTb == null || tTb.Rows.Count == 0)
                {
                    MessageBox.Show("�Բ��𣬸ò�����Ϣ�Ѿ�ˢ�£��������ڿɲ�����Χ�����ʵ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btRefresh_Click(null, null);
                    return;
                }

                string name = tTb.Rows[0]["name"].ToString();
                long _deptid = Convert.ToInt64(tTb.Rows[0]["dept_id"].ToString());
                string _sex = tTb.Rows[0]["sex"].ToString();

                string sFlag = "";
                string sSql = "";
                string _outmsg = "";
                string new_bed_no = "";
                long new_dept_id = 0;
                int isPLUS = 0;
                string Room_NO = "";
                Guid new_bed_id = Guid.Empty;

                int isInput_ZD = 0;

                int isUpdate = 1;//Modify By Tany �ϴ����Զ����´�λ��
                //int isUpdate = tb.Rows[nrow]["������Դ"].ToString().Trim() == "����Ժ" ? 0 : 1;
                int isTmpIn = 1;//0=��ʱ��ס ״̬4��1=��ס ״̬3

                //��Ļ�����ת��
                System.Drawing.Point p = new Point(e.X, e.Y);
                Point p1 = listView1.PointToClient(p);

                //�õ���ǰ��VIEWITEM
                System.Windows.Forms.ListViewItem new_item = listView1.GetItemAt(p1.X, p1.Y);

                //���VIEWITEM��Ϊ�գ���ִ�зִ�����
                if (new_item != null)
                {
                    new_bed_no = new_item.Text.Trim();//.Substring(0,1)=="��"?new_item.Text.Trim().Substring(0,3):new_item.Text.Trim().Substring(0,2);
                    sSql = "select bed_id,INPATIENT_ID,isbf,dept_id,room_no,isPLUS from ZY_BEDDICTION where isinuse=0 and WARD_ID='" + InstanceForm.BCurrentDept.WardId + "' and bed_no='" + new_bed_no + "'";
                    DataTable new_tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (new_tempTab.Rows[0]["INPATIENT_ID"].ToString().Trim() != "")
                    {
                        MessageBox.Show(this, "�Բ���Ŀ�괲λ���ǿմ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Convert.ToInt16(new_tempTab.Rows[0]["isbf"].ToString()) == 1)
                    {
                        MessageBox.Show(this, "�Բ���Ŀ�괲λ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    new_bed_id = new Guid(new_tempTab.Rows[0]["bed_id"].ToString());
                    new_dept_id = Convert.ToInt32(new_tempTab.Rows[0]["dept_id"]);
                    isPLUS = Convert.ToInt32(new_tempTab.Rows[0]["isPLUS"]);
                    Room_NO = new_tempTab.Rows[0]["Room_NO"].ToString();

                    //��λ��Ч���ж�
                    //Add By Tany 2005-02-24
                    string isInuse = Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select isinuse from zy_beddiction where bed_id='" + new_bed_id + "'"), "");
                    if (isInuse == "1")
                    {
                        MessageBox.Show("���Ŵ�λ�Ѿ���ͣ�ã�������ѡ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitView(bit, 0);
                        ShowNewPatient();
                        return;
                    }

                    if (_babyid > 0 && cfg7205.Config == "0")//isCK && Modify By Tany 2011-03-07 ���е�Ӥ�������ܵ����ִ�
                    {
                        //if(MessageBox.Show(this, "ȷ��Ϊ��Ӥ���������䴲λ��", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) 
                        MessageBox.Show(this, "Ӥ�����ܵ������䴲λ���������䴲λ���ܲ˵���ѡ��ĸӤͬ�ң�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (_babyid > 0 && cfg7205.Config == "1")
                    {
                        MessageBox.Show(this, "���Ӳ��˲��ܵ������䴲λ���������䴲λ���ܲ˵���ѡ����ͬ�ң�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show(this, "�Ƿ�ȷ�Ͻ� " + name + " ���˷��䵽 " + new_bed_no + " �Ŵ���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;

                    //�޸Ĵ�λ���жϷ�ʽ Modify By Tany 2010-04-26

                    //Modify by jchl
                    //if (cbCWF.Checked)
                    //if (cfg7600.Config.Trim().Equals("1"))
                    {
                        //��λ��HOITEM_ID
                        //SystemCfg cfg = new SystemCfg(7024);
                        //string _hoitemID = cfg.Config;
                        //if (_hoitemID.Trim() == "") _hoitemID = "0";
                        //���Ƿ���δֹͣ�Ĵ�λ�˵�
                        sSql = @"select 1 from zy_orderrecord where inpatient_id='" + _inpatientid + "'" +
                            " and baby_id=" + _babyid + " and mngtype=2 and status_flag=2 " +
                            " and delete_bit=0 and hoitem_id in (select order_id from jc_hsitemdiction a  " +
                            " inner join jc_hoi_hdi b on a.item_id=b.hditem_id " +
                            " inner join jc_hoitemdiction c on b.hoitem_id=c.order_id " +
                            " where a.statitem_code in (" + new SystemCfg(7029).Config + "))";//Modify by Tany 2010-11-26 ��λ�Ѵ���Ŀ��������ж��
                        DataTable tmpbedTb = InstanceForm.BDatabase.GetDataTable(sSql);

                        if (tmpbedTb.Rows.Count > 0)
                        {
                            if (MessageBox.Show(this, "������δֹͣ�Ĵ�λ�ѳ����˵����Ƿ�Ҫ�Զ����ɴ�λ�ѳ����˵���", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                isInput_ZD = 1;
                            }
                        }
                    }

                    //����һ�����ж�,�Ӵ�����
                    if ((new_dept_id != _deptid) && (isPLUS == 0))
                    {
                        if (MessageBox.Show(this, "���˿����봲λ���Ҳ�һ�£��Ƿ�ȷ�Ϸ��䣿", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    //ͬһ�����Ա��ж�
                    string s = _sex.Trim();
                    if (s != "") s = (s == "��" ? "Ů" : "��");
                    sSql = @"select * from zy_BedDiction " +
                        " where ward_id='" + InstanceForm.BCurrentDept.WardId + "'" +
                        "   and room_no='" + Room_NO + "'" +
                        "   and bedsex='" + s + "'";
                    DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                    if (tempTab.Rows.Count > 0)
                    {
                        if (MessageBox.Show(this, "�÷���ס��" + s + "�Բ��ˣ��Ƿ�ȷ�Ϸ��䣿", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    }

                    //�ٴ��жϲ���״̬�Ƿ��������� Add By Tany 2005-04-26
                    sSql = "select flag from vi_zy_vinpatient_info where inpatient_id='" + _inpatientid + "' and baby_id=" + _babyid + " and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "')";
                    DataTable patTb = InstanceForm.BDatabase.GetDataTable(sSql);

                    if (patTb == null || patTb.Rows.Count == 0)
                    {
                        MessageBox.Show("�Բ���û���ҵ�������Ϣ�����ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InitView(bit, 0);
                        ShowNewPatient();
                        return;
                    }
                    else
                    {
                        sFlag = patTb.Rows[0][0].ToString().Trim();//Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select flag from vi_zy_vinpatient_all where inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID).ToString(),"");
                        if (sFlag == "2" || sFlag == "6" || sFlag == "10")
                        {
                            MessageBox.Show("�Բ��𣬲����Ѿ����������Ϣ��ɾ�������ܽ��в�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            InitView(bit, 0);
                            ShowNewPatient();
                            return;
                        }
                    }

                    //ģʽ1Ϊ���������䴲λ
                    _outmsg = myFunc.AssignBed("", 1, new_bed_id, _deptid, _inpatientid, _babyid, _sex, Room_NO, 0, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentUser.EmployeeId, isInput_ZD, isUpdate, isTmpIn, FrmMdiMain.Jgbm);

                    string OperType = "���䴲λ";

                    //д��־ Add By Tany 2005-01-12
                    SystemLog _systemLog = new SystemLog(-1, Convert.ToInt64(ClassStatic.Current_DeptID), InstanceForm.BCurrentUser.EmployeeId, OperType, _outmsg + "�� " + name + " ���˷��䵽 " + new_bed_no + " �Ŵ�", DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemLog.Save();
                    _systemLog = null;

                    if (_outmsg.Trim() != "")
                    {
                        MessageBox.Show(_outmsg);
                    }
                    else
                    {
                        MessageBox.Show("���䴲λ�ɹ���");
                    }

                    //ˢ��LISTVIEW
                    InitView(bit, 0);
                    ShowNewPatient();
                }
                #endregion
            }
        }

        #region �ϲ˵��¼�
        private void mn1���䴲λ_Click(object sender, System.EventArgs e)
        {
            //			int i=0;
            //			string sName="", sSql="";
            //			bool isCheckEmpty=false;	//�������Ƿ�û��һ������
            //			bool isInput=false;			//�Ƿ�������ҽ��
            //			bool isBC=false;            //�Ƿ��ǰ�����ȡ������
            //			bool isCheckSelect=false;	//�Ƿ�ѡ�в���
            //			bool isShow=true;			//�Ƿ���ʾ����
            //			bool isRefresh=true;		//�Ƿ�ˢ��listview
            //			
            //			System.Type tp=sender.GetType();
            //			switch (tp.ToString())
            //			{
            //				case "System.Windows.Forms.MenuItem":
            //					MenuItem mn=(MenuItem) sender;
            //					i=mn.Text.Trim().Length<4?mn.Text.Trim().Length:4;
            //					sName=mn.Text.Trim().Substring(0,i);
            //					break;
            //				case "System.Windows.Forms.Button":
            //					Button bt=(Button) sender;
            //					//i=bt.Text.Trim().Length<4?bt.Text.Trim().Length:4;
            //					sName=bt.Text.Trim();//.Substring(0,i);
            //					break;	
            //				case "System.Windows.Forms.ListView":
            //					if(mn3ҽ����ѯ.Visible)
            //						sName="ҽ����ѯ";
            //					else
            //						return;
            //					break;
            //			}
            //			
            //			System.Windows.Forms.Form f1=new Form();
            //			switch (sName.Trim())
            //			{
            //				#region ��λ����
            //				case "���䴲λ":
            //					f1=new frmFPCW();					
            //					//f1=new Form1();				
            //					break;
            //				case "ˢ�´�λ":					
            //					isShow=false;					
            //					break;
            ////				case "����":
            ////					isCheckSelect=true;
            ////					isShow=false;
            ////					break;
            ////				case "ȡ������":
            ////					isCheckSelect=true;
            ////					isShow=false;
            ////					break;
            //				case "����":
            //					isCheckSelect=true;
            //					isShow=false;
            //					isBC=true;
            //					break;
            //				case "ȡ������":
            //					isCheckSelect=true;
            //					isShow=false;
            //					isBC=true;
            //					break;
            //				case "��λ����":
            //					f1=new frmCWSX();					
            //					break;
            //				#endregion
            //				
            //				#region ���˹���
            //				case "������Ϣ":
            //					isCheckSelect=true;
            //					f1=new frmPatientInfo();
            //					break;
            //				case "����һ��":
            //					isCheckSelect=false;
            //					f1=new frmAllPatientInfo();
            //					break;
            //				case "�޸���Ϣ":
            //					isCheckSelect=true;
            //					f1=new frmXGXX();
            //					break;
            //				case "���Ҳ���":
            //					f1=new frmCZBR();
            //					break;
            //				case "����":
            //					if(this.listView1.SelectedItems.Count<1 + this.listView1.SelectedItems[0].Tag==null + this.listView1.SelectedItems[0].Tag.ToString()=="") 
            //					{
            //						MessageBox.Show(this,"��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					if (this.listView1.SelectedItems[0].Tag.ToString().Substring(55,1)!="Ů")
            //					{
            //						MessageBox.Show(this,"�Բ�����ѡ��Ĳ��˱�����Ů�ԣ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //						return;
            //					}
            //					if (Convert.ToInt16(ClassStatic.Current_BabyID)>0)
            //					{
            //						MessageBox.Show(this,"�Բ�����ѡ��Ĳ�����Ӥ����", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //						return;
            //					}
            //					f1=new frmFM();
            //					break;
            //				case "ת��":					
            //					f1=new frmZK();
            //					break;
            //				case "�����Ժ":					
            //					f1=new frmDYCY();
            //					break;
            //				#endregion
            //
            //				#region ҽ������
            //				case "ҽ����ѯ":
            //					isCheckEmpty=true;
            //					f1=new frmYZGL();
            //					break;
            //				case "δ����ҽ":
            //					isCheckEmpty=true;
            //					f1=new frmYZCX();
            //					break;
            //				case "δ������":
            //					isCheckSelect=true;
            //					frmWzxxm fwzx=new frmWzxxm();
            //					fwzx.v_inpatinet_id=ClassStatic.Current_BinID;
            //					fwzx.v_baby_id=Convert.ToDecimal(ClassStatic.Current_BabyID);
            //					fwzx.ShowDialog();
            //					fwzx.Dispose();
            //					return;
            //                 case "ҽ��ת��":
            //					 if (this.isNotEmpty==false)
            //					 {
            //						 MessageBox.Show(this,"��������û�в���", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						 return;
            //					 }
            //					 frmYZZC fmYZZC=new frmYZZC();
            //					 fmYZZC.Kind=1;
            //					 fmYZZC.ShowDialog();
            //					 fmYZZC.Dispose();	
            //					 isShow=false;
            //					 break;
            //				case "ҽ���˶�":
            //					if (this.isNotEmpty==false)
            //					{
            //						MessageBox.Show(this,"��������û�в���", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					frmYZZC fmYZZC1=new frmYZZC();
            //					fmYZZC1.Kind=3;
            //					fmYZZC1.ShowDialog();
            //					fmYZZC1.Dispose();	
            //					isShow=false;
            //					break;	
            //				case "ҽ�����":
            //					if (this.isNotEmpty==false)
            //					{
            //						MessageBox.Show(this,"��������û�в���", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            //					frmYZZC fmYZZC2=new frmYZZC();
            //					fmYZZC2.Kind=5;
            //					fmYZZC2.ShowDialog();
            //					fmYZZC2.Dispose();	
            //					isShow=false;
            //					break;
            //				case "�˵�����":
            //					isCheckEmpty=true;
            //					isInput=true;
            //					isShow=false;
            //					break;
            //				case "�����˵�":
            //					isCheckEmpty=true;
            //					isInput=true;
            //					isShow=false;
            //					break;
            //				case "ģ���ѯ":
            //					frmYZModel fm=new frmYZModel();
            //					fm.MngType=0;		
            //					fm.ShowDialog();
            //					fm.Dispose();	
            //					isShow=false;
            //					break;
            //				#endregion
            //
            //				#region ִ��
            //				case "ҽ������":
            //					isCheckEmpty=true;
            //					f1=new frmExecOrders();
            //					break;
            //				case "ҩƷ��Ϣ":
            //					f1=new frmYPXX();
            //					break;
            //				case "����ҩƷ":
            //					f1=new frmJSYTJ();
            //					break;
            //				case "������ҩ":					
            //					frmHydprt fh = new frmHydprt();	
            //					fh.sType="������ҩƷ��ӡ";
            //					fh.ShowDialog();
            //					fh.Dispose();
            //					return;	
            //				case "������Ϣ":
            //					isCheckEmpty=true;
            //					f1=new frmDJDY();			
            //					break;		
            //				case "ִ�е�":
            //					isCheckEmpty=true;
            //					f1=new frmZXD();			
            //					break;
            //				case "���鵥��":					
            //					f1=new frmHydprt();			
            //					break;
            //				case "ȡ��ҽ��":					
            //					f1=new frmCancel();			
            //					break;
            //				#endregion
            //
            //				#region ��������
            //				case "��Ժ����":
            //					isCheckSelect=true;
            //					f1=new frmHLPG();
            //					break;
            //				case "һ�㻼��":
            //					isCheckSelect=true;
            //					frmYBHZ fy=new frmYBHZ();
            //					fy.Show_Date(ClassStatic.Current_BinID,Convert.ToDecimal(ClassStatic.Current_BabyID));
            //					fy.ShowDialog();
            //					fy.Dispose();
            //					return;
            //				case "Σ�ػ���":
            //					isCheckSelect=true;
            //					frmWZHZ fw=new frmWZHZ();
            //					fw.Show_Date(ClassStatic.Current_BinID,Convert.ToDecimal(ClassStatic.Current_BabyID));
            //					fw.ShowDialog();
            //					fw.Dispose();
            //					return;
            ////				case "�����ⵥ":
            ////					isCheckSelect=true;
            ////					f1=new frmSCD0();
            ////					break;
            //				case "���ⵥ":
            //				case "�� �� ��":
            //					isCheckSelect=true;
            //					f1=new Frmscd();
            //					break;
            //				case "�Ĳ��¼":
            //					isCheckSelect=true;
            //					f1=new frmSCD1();
            //					break;
            //				case "�����¼":
            ////					isCheckSelect=true;
            //					f1=new  frmJBJL();
            //					break;
            //				#endregion
            //
            //				#region �������
            //				case "��ʿ�Ű�":
            //					f1=new  frmHSPB();
            //					break;
            //				case "ͳ�ƻ�ʿ":
            //					f1=new  frmReptPbgzl();
            //					break;
            //				case "ҽ���Ű�":
            //					f1=new  frmYSPB();
            //					break;				
            //				case "������":
            //					//
            //					break;
            //				#endregion
            //				
            //				#region �ۺ�ͳ��
            //				case "����ͳ��":
            //					f1=new frmCRTJ();
            //					break;
            //				case "��������":
            //					f1=new frmWardGzrz();
            //					break;
            //				case "��������":
            //					f1=new frmSRTJ();
            //					break;
            //				case "��������":
            //					f1=new frmReptPbgzl();
            //					break;
            //				case "��������":
            //					f1=new frmWarddeptSR();
            //					break;
            //				#endregion
            //                
            //				#region ϵͳ
            //				case"�÷��븽":
            //					f1=new frmAddFee();
            //					isRefresh=false;
            //					break;
            //				case"���һ���":
            //					f1=new frmJSY();
            //					isRefresh=false;
            //					break;
            //				case"��Ŀ��ѯ":
            //					f1=new frmxmcx();
            //					isRefresh=false;
            //					break;
            //				case"���µ�¼":
            //					frmLogin flg1=new frmLogin();
            //					flg1.ShowDialog();
            //					if (flg1.LoginOK==false) 
            //					{
            //						this.Close();						
            //					}
            //					this.frmCWYL_Load(sender,e);
            //					return;
            //				case "��������":
            //					f1=new DlgChgPWD();
            //					isRefresh=false;
            //					break;
            //				case "�˳�ϵͳ":
            //					Application.Exit();
            //					return;
            //				#endregion
            //					
            //				default:
            //					MessageBox.Show(this,"�Բ��𣬴˹������ڽ�����....", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning); 
            //					return;
            //			}			
            //
            //			// ��鲡�����Ƿ�û��һ������
            //			if (isCheckEmpty || isCheckSelect ) 
            //			{
            //				if (this.isNotEmpty==false)
            //				{
            //					MessageBox.Show(this,"��������û�в���", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //					return;
            //				}
            //			}
            //
            //
            //			#region �Ƿ�������ҽ��
            //			if (isInput) 
            //			{
            //				frmYZLR fy=new frmYZLR();
            //				frmJRYZLR fj=new frmJRYZLR();
            //
            //				if(SelectDataView==null)
            //				{
            //					//frmLoading fw=new frmLoading();
            //					//fw.Show();
            //					//fw.Update();
            //
            //					//����ȡ�����ݷ��õ�DATAVIEW��ȥ					
            ////					DataTable myTb=myFunc.GetSelCard("","",1);
            //					//ֻ��ʾ8��9�ģ�������ʾִ�п��� Modify By Tany 2005-05-22
            //					sSql=@"SELECT AA.ƴ���� ,AA.ҽ������ as ����, AA.��λ,AA.����,1 as ����,"+
            ////						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS ҽ�����,Hoicode as ��׼��,AA.BZ as ��ע,Order_Type as type,iscomplex,zxdd_id AS exec_dept,seekdeptname(zxdd_id) ִ�п���"+   //Modify By Tany 2005-06-13 ��jc_HOItemDictionȡִ�п���
            //						  "       CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10) ) AS ҽ�����,Hoicode as ��׼��,AA.BZ as ��ע,Order_Type as type,iscomplex,default_dept AS exec_dept,seekdeptname(default_dept) ִ�п���"+
            //						  "  FROM (SELECT  a.order_name as ҽ������,order_unit as ��λ,retail_price as ����,a.py_code as ƴ����,"+
            //						  "                default_dept,a.bz,a.ORDER_ID,a.Order_Type,a.Hoicode,c.iscomplex,zxdd_id"+
            //						  "          FROM  jc_HOItemDiction a,jc_HOI_HDI b,jc_HSItemDiction c "+
            //		                  "         WHERE a.ORDER_ID=b.Hoitem_id and c.item_id=b.Hditem_id and a.delete_bit=0 and a.Order_Type IN (8, 9))  AS AA ";
            //						 // "ORDER BY Order_Type "; 
            //					DataTable myTb=InstanceForm.BDatabase.GetDataTable(sSql);
            //					myTb.TableName="ORDERQUERY";				
            //					SelectDataView=new DataView();
            //					SelectDataView.Table=myTb;
            //					//fw.Close();
            //				}
            //
            //				switch (sName.Trim())
            //				{
            //					case "�˵�����":
            //						fy.SelectDataView=this.SelectDataView;				
            //						fy.ShowDialog();
            //						break;
            //					case "�����˵�":
            //						fj.SelectDataView=this.SelectDataView;				
            //						fj.ShowDialog();
            //						break;
            //				}
            //
            //				fy.Dispose();
            //				fj.Dispose();
            //			}
            //			#endregion
            //
            //
            //			//����Ƿ�ѡ�в���,
            //			if (isCheckSelect) 
            //			{
            ////				if(listView1.Visible)
            ////				{
            ////					if(this.listView1.SelectedItems.Count<1 || this.listView1.SelectedItems[0].Tag==null || this.listView1.SelectedItems[0].Tag.ToString()=="") 
            ////					{
            ////						MessageBox.Show(this,"��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            ////						return;
            ////					}
            ////				}
            ////				else
            ////				{
            //					//���ж��Ƿ��е���¼���ֻ����û�в�����Ϣ
            //					//Modify By Tany 2004-10-28
            //					if(ClassStatic.Current_BinID=="0" || ClassStatic.Current_BinID==null)
            //					{
            //						MessageBox.Show(this,"��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //						return;
            //					}
            ////				}
            //			}
            //
            //			//�Ƿ���ʾ����
            //			if (isShow) 
            //			{
            //				f1.ShowDialog();
            //				f1.Dispose();	
            //			}
            //			else
            //			{
            //				if (isBC)
            //				{
            //					frmBC fmBC=new frmBC();
            //					fmBC.isBC=sName=="����"?true:false;
            //					fmBC.ShowDialog();
            //					fmBC.Dispose();
            //				}
            //
            //				#region �˹���������  ������ȡ������
            //				switch (sName)
            //				{
            //					case "����":
            //						#region ����
            //						sSql=@"select bed_id,ISBF,ROOM_NO from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID;
            //						DataTable tempTab1=InstanceForm.BDatabase.GetDataTable(sSql);					
            //						if (Convert.ToInt16(tempTab1.Rows[0]["ISBF"])==1)
            //						{
            //							MessageBox.Show(this,"�Բ��𣬸÷����Ѿ�������", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						sSql=@"select * from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and room_no='"+tempTab1.Rows[0]["ROOM_NO"].ToString()+"'"+
            //							"   and inpatient_id!="+ ClassStatic.Current_BinID +
            //							"   and inpatient_id is not null ";
            //						DataTable tempTab2=InstanceForm.BDatabase.GetDataTable(sSql);
            //						if (tempTab2.Rows.Count>0)
            //						{
            //							MessageBox.Show(this,"�Բ��𣬸÷�����ס�ˣ������������", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						if(MessageBox.Show(this, "ȷ�ϰ�����", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;				
            //						myFunc.ChangeBed("",3,Convert.ToInt32(tempTab1.Rows[0]["bed_id"]),0,InstanceForm.BCurrentUser.EmployeeId );
            //						break;
            //						#endregion
            //					case "ȡ������":
            //						#region ȡ������
            //						sSql=@"select bed_id,ISBF,ROOM_NO from zy_BedDiction "+
            //							" where ward_id='"+ InstanceForm.BCurrentDept.WardId + "'" +
            //							"   and inpatient_id="+ClassStatic.Current_BinID+" and baby_id="+ClassStatic.Current_BabyID;
            //						DataTable tempTab3=InstanceForm.BDatabase.GetDataTable(sSql);					
            //						if (Convert.ToInt16(tempTab3.Rows[0]["ISBF"])==0)
            //						{
            //							MessageBox.Show(this,"�Բ��𣬸÷���û�б�����", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
            //							return;
            //						}
            //
            //						if(MessageBox.Show(this, "ȷ��ȡ��������", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;				
            //						myFunc.ChangeBed("",4,Convert.ToInt32(tempTab3.Rows[0]["bed_id"]),0,InstanceForm.BCurrentUser.EmployeeId );
            //						break;			
            //						#endregion					
            //				}
            //				#endregion
            //			}
            //
            //			//�Ƿ�ˢ��listview
            //			if (isRefresh) InitView(bit);
        }
        #endregion

        private void viewType_Click(object sender, System.EventArgs e)
        {
            MenuItem mi = new MenuItem();
            mi = (MenuItem)sender;

            if (mi.Text == "ͼ��") bit = 0;
            else bit = 1;

            InitView(bit, 0);
        }

        private void button_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Button bt = (Button)sender;

            //����
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 15, bt.Width, 15);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 30, bt.Width, 30);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 45, bt.Width, 45);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 60, bt.Width, 60);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 75, bt.Width, 75);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 0, 90, bt.Width, 90);

            //����
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 40, 0, 40, 30);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,80,0,80,20);
            e.Graphics.DrawLine(System.Drawing.Pens.Gray, 20, 15, 20, 30);
            //e.Graphics.DrawLine(System.Drawing.Pens.Black,60,20,60,40);

            //������Ϣ
            bedno = bt.Tag.ToString().Substring(0, 10);
            name = bt.Tag.ToString().Substring(10, 6);
            sex = bt.Tag.ToString().Substring(16, 2);
            age = bt.Tag.ToString().Substring(18, 3);
            fb = bt.Tag.ToString().Substring(21, 6);
            zyh = bt.Tag.ToString().Substring(27, 10);
            bq = bt.Tag.ToString().Substring(37, 10);
            tend = bt.Tag.ToString().Substring(47, 10);
            zd = bt.Tag.ToString().Substring(57, 10);
            ryrq = bt.Tag.ToString().Substring(67, 10);
            if (bt.Tag.ToString().Substring(83, 3).Trim() != "" && name.Trim() == "")
                bc = bt.Tag.ToString().Substring(83, 3).Trim();
            else
                bc = "";
            e.Graphics.DrawString(bedno.Trim() + bc, bt.Font, Brushes.Red, 2, 2);
            e.Graphics.DrawString(name, bt.Font, Brushes.MidnightBlue, 41, 2);
            e.Graphics.DrawString(sex, bt.Font, Brushes.MidnightBlue, 2, 17);
            e.Graphics.DrawString(age, bt.Font, Brushes.MidnightBlue, 22, 17);
            e.Graphics.DrawString(fb, bt.Font, Brushes.MidnightBlue, 41, 17);
            e.Graphics.DrawString(zyh, bt.Font, Brushes.MidnightBlue, 2, 32);
            e.Graphics.DrawString(bq, bt.Font, Brushes.Red, 2, 47);
            e.Graphics.DrawString(tend, bt.Font, Brushes.MidnightBlue, 2, 62);
            e.Graphics.DrawString(zd, bt.Font, Brushes.MidnightBlue, 2, 77);
            e.Graphics.DrawString(ryrq, bt.Font, Brushes.MidnightBlue, 2, 92);
        }

        private string Space(int len)
        {
            string space = "";
            if (len > 0)
            {
                for (int i = 1; i <= len; i++)
                {
                    space += " ";
                }
            }
            return space;
        }

        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int ii = Convert.ToInt32(bt.Name.Substring(2));

            if ((stagArr[ii].Trim() != "") && (stagArr[ii] != null))
            {
                ClassStatic.Current_BinID = new Guid(stagArr[ii].Substring(0, 41).Trim());
                ClassStatic.Current_BabyID = Convert.ToInt64(stagArr[ii].Substring(41, 11).Trim());
                ClassStatic.Current_isMYTS = Convert.ToInt16(stagArr[ii].Substring(52, 11).Trim());
                ClassStatic.Current_DeptID = Convert.ToInt64(stagArr[ii].Substring(63, 11).Trim());
                ClassStatic.Current_isMY = Convert.ToInt16(stagArr[ii].Substring(74, 11));
                this.patientInfo1.SetInpatientInfo(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, ClassStatic.Current_isMY);
            }
            else
            {
                this.patientInfo1.ClearInpatientInfo();
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;
            }


        }

        private void bt_MouseDown(object sender, MouseEventArgs e)
        {
            bt_Click(sender, e);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //mtype 0=ȫ��ϵͳ 1=��ʿ 2=ҽ��
            DataTable msgTb = new DataTable();
            string sSql = "";
            DateTime NowTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            rtbMsg.Text = "";
            sSql = "select distinct a.id,bdate,title from zy_message a inner join zy_message_dept b on a.id=b.p_id"
                + " where '" + NowTime + "' between a.bdate and a.edate and mtype in (0,1) and level=1"//ֻ��ʾϵͳ����Ϣ Modify By Tany 2005-03-14
                + " and (b.dept_id=0 or b.dept_id in (SELECT DEPT_ID FROM JC_WARDRDEPT WHERE WARD_ID='" + InstanceForm.BCurrentDept.WardId + "'))";
            msgTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (msgTb == null || msgTb.Rows.Count == 0)
                return;

            for (int i = 0; i < msgTb.Rows.Count; i++)
            {
                rtbMsg.Text += "��" + msgTb.Rows[i]["id"].ToString().Trim() + "��" + msgTb.Rows[i]["bdate"].ToString().Trim() + "  " + msgTb.Rows[i]["title"].ToString().Trim() + "\n";
            }

            rtbMsg.Focus();
            rtbMsg.Select(rtbMsg.TextLength, 0);
            rtbMsg.ScrollToCaret();
        }

        private void rtbMsg_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            //			frmMsg fm = new frmMsg();
            //			fm.MsgId=e.LinkText;
            //			fm.ShowDialog();
            //			fm.Dispose();
        }

        private void mnuRefrashBed_Click(object sender, System.EventArgs e)
        {
            InitView(bit, 0);
        }

        private void mnuOrderPrt_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzdy", "Fun_ts_zyhs_yzdy", "ҽ����ӡ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuBCorQXBC_Click(object sender, System.EventArgs e)
        {
            //���ж��Ƿ��е���¼���ֻ����û�в�����Ϣ
            //Modify By Tany 2004-10-28
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MenuItem mn = (MenuItem)sender;
            string mnName = mn.Text.Trim();

            frmBC frmBc = null;
            bool _isBC = true;

            if (mnName == "����")
                _isBC = true;
            else
                _isBC = false;

            frmBc = new frmBC(_isBC);
            frmBc.ShowDialog();
            frmBc.Dispose();

            InitView(bit, 0);
        }

        private void mnuFM_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (cfg7205.Config == "0")
                {
                    if (this.listView1.SelectedItems[0].Tag.ToString().Substring(85, 1) != "Ů")
                    {
                        MessageBox.Show(this, "�Բ�����ѡ��Ĳ��˱�����Ů�ԣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "�Բ�������һ�����ˣ�" + "\n" + this.listView1.SelectedItems[0].Tag.ToString(), "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt16(ClassStatic.Current_BabyID) > 0)
            {
                MessageBox.Show(this, "�Բ�����ѡ��Ĳ�����Ӥ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmFM frmFm = new frmFM();
            frmFm.ShowDialog();
            frmFm.Dispose();

            InitView(bit, 0);
        }

        private void mnuOrderQuery_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzgl", "Fun_ts_zyhs_yzgl", "ҽ������", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuOrder_Click(object sender, System.EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string docSql = "select zy_doc from zy_inpatient a inner join JC_ROLE_DOCTOR b on a.zy_doc=b.employee_id where a.inpatient_id='" + ClassStatic.Current_BinID + "'";
            DataTable docTb = InstanceForm.BDatabase.GetDataTable(docSql);

            if (docTb == null || docTb.Rows.Count == 0)
            {
                MessageBox.Show("�ò���û�з���ܴ�ҽ�������ȷ���ܴ�ҽ�����ٽ���ҽ��¼�룡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (openform(ClassStatic.Current_BinID) == true)
            {
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                return;
            }

            object[] communicateValue = new object[7];
            communicateValue[0] = ClassStatic.Current_BinID;
            communicateValue[1] = InstanceForm.BCurrentDept.WardId;
            communicateValue[2] = ClassStatic.Current_DeptID;
            communicateValue[3] = listView1.SelectedItems[0].Tag;
            communicateValue[4] = myFunc.OutFlag(ClassStatic.Current_BinID, ClassStatic.Current_BabyID);
            communicateValue[5] = 1;
            communicateValue[6] = InstanceForm.BCurrentDept.WardDeptId;

            GetForm("ts_zyys_yzgl", "Fun_Ts_zyys_hsyz", "ҽ��¼��", InstanceForm.BCurrentUser.UserID, InstanceForm.BCurrentDept.DeptId, communicateValue, true);
        }

        private void mnuOrderZC_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_yzzc", "Fun_ts_zyhs_yzzc", "ҽ��ת��", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuZDLR_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_zdlr", "Fun_ts_zyhs_zdlr", "�ʵ�¼��", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuFYXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_fyxx", "Fun_ts_zyhs_fyxx", "���˷��ò�ѯ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuYPXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_ypxx", "Fun_ts_zyhs_ypxx", "ҩƷ��Ϣ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuXGXX_Click(object sender, System.EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_xgxx", "Fun_ts_zyhs_xgxx", "�޸���Ϣ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void frmCWYL_Activated(object sender, System.EventArgs e)
        {
            frmCWYL_Load(null, null);
            PostMessage(this.listView1.Handle.ToInt32(), 0x020A, 0, 0);
        }

        private void mnuZC_Click(object sender, System.EventArgs e)
        {
            //���ж��Ƿ��е���¼���ֻ����û�в�����Ϣ
            //Modify By Tany 2004-10-28
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
            if (rtnSql[2] != "0")
            {
                MessageBox.Show("���ڿ�Ժ��������δ��ɣ������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cursor = Cursors.Default;
                return;
            }
            #endregion
            frmZC frmZc = new frmZC();
            frmZc.ShowDialog();
            frmZc.Dispose();

            InitView(bit, 0);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);
            //���ݲ����ж��Ƿ�ʹ�û�ʿվҽ��¼��
            //Modify By Tany 2007-09-04
            if ((new SystemCfg(7032)).Config == "��")
            {
                //Modify By tany 2011-06-18
                string _cfg7037 = (new SystemCfg(7037)).Config;
                //������п��ҿ���¼��
                if (_cfg7037 == "����")
                {
                    mnuOrder_Click(null, null);
                }
                else if (_cfg7037 != "")//ָ�����ҿ���¼��
                {
                    string[] _cfgWard = _cfg7037.Split(',');
                    bool _isInput = false;
                    if (_cfgWard.Length > 0)
                    {
                        for (int i = 0; i < _cfgWard.Length; i++)
                        {
                            if (InstanceForm.BCurrentDept.WardId == _cfgWard[i])
                            {
                                _isInput = true;
                                break;
                            }
                        }
                    }
                    if (_isInput)
                    {
                        mnuOrder_Click(null, null);
                    }
                    else
                    {
                        mnuOrderQuery_Click(null, null);
                    }
                }
                else
                {
                    mnuOrderQuery_Click(null, null);
                }
            }
            else
            {
                mnuOrderQuery_Click(null, null);
            }
        }

        private void GetForm(string dllName, string functionName, string chineseName, long userID, long deptID, object[] communicateValue, bool showType)
        {
            try
            {
                User _user_id = new User(Convert.ToInt32(userID), FrmMdiMain.Database);
                Department _dept_id = new Department(Convert.ToInt32(deptID), FrmMdiMain.Database);

                //���DLL�д���
                Form _dllform = (Form)WorkStaticFun.InstanceForm(dllName, functionName, chineseName, _user_id, _dept_id, null, FrmMdiMain.Database, ref communicateValue);
                _dllform.StartPosition = FormStartPosition.CenterScreen;
                if (showType) _dllform.ShowDialog();
                else _dllform.Show();
                for (int i = 0; i < 10; i++) openForm[i] = Guid.Empty;   //���Ѿ��򿪵�ҽ����������г�ʼ��,���û����仰,�ڹر�ҽ��������ٴ������ʾ��ҽ�������Ѿ���
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace.ToString());
                Cursor = Cursors.Default;
                return;
            }
        }

        #region �жϸò��˵�ҽ���������Ƿ��
        private bool openform(Guid Bin_ID)
        {
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] == Bin_ID)
                {
                    MessageBox.Show("�ò��˵�ҽ���������Ѿ��򿪡�", "��ʾ");
                    return true;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (openForm[i] == Guid.Empty)
                {
                    openForm[i] = Bin_ID;
                    return false;
                }

                if (i == 9)
                {
                    MessageBox.Show("ҽ��������̫�࣡", "��ʾ");
                    return true;
                }
            }
            return true;
        }
        #endregion

        private void btRefresh_Click(object sender, EventArgs e)
        {
            ShowNewPatient();
        }

        private void ShowNewPatient()
        {
            string sSql = @"select in_date as ��Ժ����,inpatient_no as סԺ��,x.name as ����,x.baby_no as Ӥ����, " +
                    "         case when sexcode=1 then '��' else 'Ů' end as �Ա�, " +
                    "         dbo.FUN_ZY_SEEKDEPTNAME(x.dept_id) as ��������," +
                    "         case when y.zkcs is null  then '����Ժ' else 'ת��'end as ������Դ," +
                    "         x.inpatient_id as ID,dept_id as pat_in_dept,x.inpatient_id,x.baby_id " +
                    "    from (select inpatient_no,name,0 baby_id,0 baby_no,sexcode,in_date,inpatient_id,dept_id " +
                    "          from vi_zy_vinpatient a " +
                    "          where flag=1 " +
                    "                and a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' ) " +
                    "          union all " +
                    "          select inpatient_no,babyname,baby_id,baby_no,sex,in_date,inpatient_id,dept_id " +
                    "          from zy_inpatient_baby " +
                    "          where flag=1 " +
                    "                and dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "' )) x " +
                //ֻҪת�ɹ���,�����Ƿ�ȡ��,�����ת��,���ı䲡����Ժ���� Modify By tany 2009-10-28
                //"    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where cancel_bit=0 and finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "    left join (select inpatient_id,baby_id,count(id) as zkcs from ZY_TRANSFER_DEPT where finish_bit=1 group by inpatient_id,baby_id ) as y on x.inpatient_id=y.inpatient_id and x.baby_id=y.baby_id " +
                    "   order by in_date ";

            DataTable tb = InstanceForm.BDatabase.GetDataTable(sSql);

            dgvNewPatient.DataSource = tb;

            string[] GrdMappingName1 ={ "����", "�Ա�", "��������", "������Դ", "סԺ��", "��Ժ����", "Ӥ����", "ID", "pat_in_dept", "INPATIENT_ID", "Baby_ID" };
            //Modify by jchl
            DataTable dtSrc = dgvNewPatient.DataSource as DataTable;
            DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "����", "סԺ��" }, new int[] { 60, 60, 100, 0, 0, 0, 0, 0, 0, 0, 0 }, dtSrc);

        }

        private void dgvNewPatient_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Clicks == 1) && (e.Button == MouseButtons.Left) && (e.ColumnIndex > 0) && (e.RowIndex > -1))
            {
                dgvNewPatient.DoDragDrop(e.RowIndex, DragDropEffects.All | DragDropEffects.Link);
            }
        }

        private void mnuXgbrxx_Click(object sender, EventArgs e)
        {
            Guid brxxid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select patient_id from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "'"), Guid.Empty.ToString()));
            Guid kdjid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select kdjid from yy_kdjb where brxxid='" + brxxid + "'"), Guid.Empty.ToString()));

            if (brxxid == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��");
                return;
            }
            MenuTag mt = new MenuTag();
            mt.Function_Name = "hs";

            ts_mz_kgl.Frmbrkdj frm = new ts_mz_kgl.Frmbrkdj(mt, "�޸Ĳ�����Ϣ", MdiParent, brxxid, kdjid);
            frm.ShowDialog();
        }

        //private void dgvNewPatient_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    dgvNewPatient.ClearSelection();
        //    dgvNewPatient.CurrentCell.Selected = true;
        //    dgvNewPatient.Rows[dgvNewPatient.CurrentRow.Index].Selected = true;
        //    dgvNewPatient.CurrentCell = dgvNewPatient.Rows[dgvNewPatient.CurrentRow.Index].Cells[0];
        //}

        /// <summary>
        /// ��ʾ������̬����Ϣ
        /// </summary>
        /// <returns></returns>
        private string ShowMsgText()
        {
            //Modify by Tany 2010-02-05 ȡ����������־����Ϣ������һ��
            DataTable rtnTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[4];
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            try
            {
                sSql = "SP_ZYHS_WARDGZRZ";

                parameters[0].Value = InstanceForm.BCurrentDept.WardId;
                parameters[0].Text = "@WARD_ID";
                parameters[1].Value = now.ToString("yyyy-MM-dd 00:00:00");
                parameters[1].Text = "@BDATE";
                parameters[2].Value = now.ToString("yyyy-MM-dd 23:59:59"); ;
                parameters[2].Text = "@EDATE";
                parameters[3].Value = 0;
                parameters[3].Text = "@FLAG";

                rtnTb = FrmMdiMain.Database.GetDataTable(sSql, parameters, 60);

                string rs = "";
                if (rtnTb.Rows.Count > 0)
                {
                    int zy = 0;
                    int cy = 0;
                    int sw = 0;
                    int ss = 0;
                    int bw = 0;
                    int bz = 0;
                    int th = 0;
                    int yjhl = 0;
                    //add by zouchihua 2013-8-1 �����㻤��
                    int ph = 0;
                    //add by yaokx 2014-05-13 ���ڴ�����������Ժ����
                    int lgrs = 0;
                    int zyrs = 0;
                    int cqrs = 0;
                    for (int i = 0; i < rtnTb.Rows.Count; i++)
                    {
                        zy += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["����"], "0"));
                        cy += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["��Ժ�ϼ�"], "0"));
                        sw += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["����"], "0"));
                        ss += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["����"], "0"));
                        bw += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["��Σ"], "0"));
                        bz += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["����"], "0"));
                        th += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["�ػ�"], "0"));
                        yjhl += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["һ������"], "0"));
                        ph += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["�㻤"], "0"));
                        lgrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["��������"], "0"));
                        zyrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["��Ժ��λ����"], "0"));
                        cqrs += Convert.ToInt32(Convertor.IsNull(rtnTb.Rows[i]["��������"], "0"));
                    }
                    rs = "��ǰ��Ժ������" + zy + "��ע����������+�ڴ�������\r\n";
                    rs += "���ճ�Ժ������" + cy + "������������" + sw + "��\r\n";
                    rs += "��������������" + ss + "\r\n";
                    rs += "��Σ������" + bw + "\r\n";
                    rs += "����������" + bz + "\r\n";
                    rs += "�ؼ�����������" + th + "\r\n";
                    rs += "һ������������" + yjhl + "\r\n";
                    rs += "�㻤������" + ph + "\r\n";
                    rs += "���ڴ�������" + (lgrs + zyrs) + "��ע��סԺ�ڴ�����:" + zyrs + ";����ռ������:" + lgrs + "��\r\n";
                    rs += "����Ժ������" + (lgrs + zyrs + cqrs) + "��ע���ڴ�����:" + (lgrs + zyrs) + "+��������:" + cqrs + "��\r\n";
                }

                return rs;
            }
            catch (Exception err)
            {
                //д������־ Add By Tany 2005-01-12
                SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "�������", "SP_ZYHS_WARDGZRZ����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 7);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }
        }

        private void mnuBRZK_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_brzk", "Fun_ts_zyhs_brzk", "����ת��", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void mnuDYCY_Click(object sender, EventArgs e)
        {
            WorkStaticFun.InstanceForm("ts_zyhs_dycy", "Fun_ts_zyhs_dycy", "�����Ժ", InstanceForm.BCurrentUser, InstanceForm.BCurrentDept, new MenuTag(), 0, this.MdiParent, InstanceForm.BDatabase);
        }

        private void frmCWYL_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            toolTip1.Hide(listView1);

            mnuEMR.Visible = isUseEMR;
        }

        private void frmCWYL_Load_1(object sender, EventArgs e)
        {
            if (cfg7205.Config == "1")
                this.mnuFM.Text = "���ø���";
            else
                this.mnuFM.Text = "����";

            this.listView1.LostFocus += new EventHandler(listView1_LostFocus);
            this.listView1.OwnerDraw = true;
            //7128 ��ʿվ�Ƿ�������� 0=��1=�� add by zouchihua 2012-6-1
            SystemCfg cfg7128 = new SystemCfg(7128);
            if (cfg7128.Config.Trim() == "0")
                mnuFM.Enabled = false;
            //add by zouchihua 2013-3-7 �Ƿ���Ҫ��ʿվ���ҽ�����˵����

            if (cfg7145.Config.Trim() == "1")
                menuItem7.Visible = true;
            else
                menuItem7.Visible = false;
            //7095�Ƿ�ʹ�û�ʿվ���Ӳ��� 0=���� 1=��
            string cfg = new SystemCfg(7095).Config;
            if (cfg == "1")
            {
                isUseEMR = true;
            }
            else
            {
                isUseEMR = false;
            }
            string cfg7112 = new SystemCfg(7112).Config;
            if (cfg7112.Trim() == "1")
            {
                mnuXgbrxx.Enabled = false;
            }
        }

        void listView1_LostFocus(object sender, EventArgs e)
        {
            //����ʧȥ������
            toolTip1.Hide(this.listView1);
        }

        private void mnuEMR_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inpatient inpatient = new Inpatient(ClassStatic.Current_BinID);
            Patient patient = new Patient(inpatient.PatientID);
            //  //0:�û���� 1�����β���סԺ��ʶ 2:�������ڿ��� 3:���˳������� 4:������Ժ���� 5�����˳�Ժ���� 6��Ӥ��id
            object[] communicateValue = new object[6];
            communicateValue[0] = FrmMdiMain.CurrentUser.LoginCode.Trim();
            communicateValue[1] = ClassStatic.Current_BinID;
            communicateValue[2] = ClassStatic.Current_DeptID;
            communicateValue[3] = patient.Birthday.ToString();
            communicateValue[4] = inpatient.In_date.ToString();
            communicateValue[5] = inpatient.Flag == 4 ? inpatient.Out_date.ToString() : "";
            Form _dllform = (Form)WorkStaticFun.InstanceForm("EmrHisNurseInterface", "Fun_emr_nurse_interface", "������д", FrmMdiMain.CurrentUser, FrmMdiMain.CurrentDept, null, FrmMdiMain.Database, ref communicateValue);
            //_dllform.StartPosition = FormStartPosition.CenterScreen;
            if (_dllform != null)
            {
                _dllform.ShowDialog();
            }

        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            InitView(bit, 1);
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            if (ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show(this, "��ѡ��һ�����ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            frmInPassword password = new frmInPassword();
            password.ShowDialog();
            if (!password.isLogin)
            {
                MessageBox.Show(this, "������󣡣�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DateTime serverDateTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                string commandText = "select  DISCHARGETYPE,inpatient_id  from zy_inpatient where inpatient_id='" + ClassStatic.Current_BinID + "' ";
                DataTable dataTable = FrmMdiMain.Database.GetDataTable(commandText);
                this.toolTip1.SetToolTip(this.listView1, "");
                commandText = " select * from VI_ZY_VINPATIENT_ALL  where inpatient_id='" + ClassStatic.Current_BinID + "' ";
                DataTable table2 = FrmMdiMain.Database.GetDataTable(commandText);
                try
                {
                    if (table2.Rows.Count >= 1)
                    {
                        DataTable table3 = new DataTable();
                        DataTable table4 = new DataTable();
                        string str2 = "select * from ZY_YB_SHXX where inpatient_id='" + new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString().Trim()) + "'    ";
                        table4 = FrmMdiMain.Database.GetDataTable(str2);
                        if (table4.Rows.Count == 0)
                        {
                            frmlrzd frmlrzd = new frmlrzd("cwyl", new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString()), FrmMdiMain.CurrentUser);
                            frmlrzd.ShowDialog();
                            if (frmlrzd.ReturnValue != 3)
                            {
                                this.frmCWYL_Load(null, null);
                            }
                            if ((frmlrzd.ReturnValue != 3) && (frmlrzd.ReturnValue != -1))
                            {
                            }
                        }
                        else if (table4.Rows[0]["RYSH"].ToString() != "1")
                        {
                            frmlrzd frmlrzd2 = new frmlrzd("cwyl", new Guid(dataTable.Rows[0]["INPATIENT_ID"].ToString()), FrmMdiMain.CurrentUser);
                            frmlrzd2.ShowDialog();
                            if (frmlrzd2.ReturnValue != 3)
                            {
                                this.frmCWYL_Load(null, null);
                            }
                            if ((frmlrzd2.ReturnValue != 3) && (frmlrzd2.ReturnValue != -1))
                            {
                            }
                        }
                        else if (table4.Rows[0]["RYSH"].ToString() == "1")
                        {
                            MessageBox.Show("�ò����Ѿ���ҽ������Ժ����ҽ����Ժ���ͨ������ʿվ�Ѳ��ܽ�����˲�������", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MessageBox.Show("�Ͻӿڲ��˲��ܽ������ֲ���", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void menuItem48_Popup(object sender, EventArgs e)
        {
            toolTip1.Hide(this.listView1);
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this.listView1);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {

                //Rectangle rc = new Rectangle(new Point(e.Bounds.Location.X + this.columnHeader1.Width, e.Bounds.Y), new Size(e.Bounds.Width - this.columnHeader1.Width, e.Bounds.Height - 1));
                //LinearGradientBrush brush =
                //            new LinearGradientBrush(rc, FColor,
                //            TColor, LinearGradientMode.Horizontal);
                // Draw the background and focus rectangle for a selected item.
                //e.Graphics.FillRectangle(brush, rc);
                //e.Graphics.DrawRectangle(Pens.Blue, e.Bounds);
                //e.DrawFocusRectangle();
            }
            // e.DrawText(TextFormatFlags.Default);

            if (e.Item.Text.IndexOf("*") >= 0)
            {
                e.Graphics.DrawString("��Σ", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y);
            }
            if (e.Item.Text.IndexOf("��") >= 0)
            {
                if (e.Item.Text.IndexOf("��") >= 0 && e.Item.Text.IndexOf("*") >= 0)
                    e.Graphics.DrawString("����", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y + 15);
                else
                    e.Graphics.DrawString("����", e.Item.Font, Brushes.Red, e.Bounds.Location.X - 10, e.Bounds.Location.Y);
            }
            // Font f=new Font("����",FontStyle.Bold);
            try
            {
                Font f = new Font("����", 18, FontStyle.Bold);
                if (e.Item.Tag.ToString().IndexOf("R") >= 0)
                    e.Graphics.DrawString("R", f, Brushes.Red, e.Bounds.Location.X + 2, e.Bounds.Location.Y + 22);
                //���봦�� add by yaokx 2014-03-04
                if (e.Item.Tag.ToString().IndexOf("����") >= 0)
                {
                    //1���Ӵ����� ��ɫ��2��ѪҺ��Һ���� ��ɫ��3������������ ��ɫ��4�����ܸ��� ��ɫ��5������������ ��ɫ��
                    string[] list = e.Item.Tag.ToString().Split(',');
                    Font f2 = new Font("����", 11);
                    if (list[1].IndexOf("�Ӵ�����") >= 0)
                        e.Graphics.DrawString("����", f2, Brushes.Blue, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("ѪҺ��Һ����") >= 0 || list[1].IndexOf("ѪҺ����") >= 0 || list[1].IndexOf("��Һ����") >= 0 || list[1].IndexOf("Ѫ��Һ����") >= 0)
                        e.Graphics.DrawString("����", f2, Brushes.Red, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("����������") >= 0)
                        e.Graphics.DrawString("����", f2, Brushes.Blue, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("���ܸ���") >= 0)
                        e.Graphics.DrawString("����", f2, Brushes.Gold, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);
                    else if (list[1].IndexOf("����������") >= 0)
                        e.Graphics.DrawString("����", f2, Brushes.Brown, e.Bounds.Location.X - 15, e.Bounds.Location.Y + 30);

                }
                string str = e.Item.Tag.ToString();
                //Ƿ�ѵĴ���
                Font f1 = new Font("����", 16, FontStyle.Bold);
                if (str.Substring(str.IndexOf("����")).IndexOf('-') > 0)
                    e.Graphics.DrawString("Ƿ", f1, Brushes.Red, e.Bounds.Location.X + this.listView1.LargeImageList.ImageSize.Width + 15, e.Bounds.Location.Y);


            }
            catch { }
            e.DrawDefault = true;
            try
            {
                Font f1 = new Font("����", 10, FontStyle.Bold);
                if (e.Item.ImageIndex == 71)
                    e.Graphics.DrawString("��\r\n��\r\n��\r\n��", f1, Brushes.Blue, e.Bounds.Location.X + this.listView1.LargeImageList.ImageSize.Width + 20, e.Bounds.Location.Y);
            }
            catch { }
            //e.Graphics.DrawImage(e.Item.ImageList.Images[e.Item.ImageIndex], e.Item.Position);
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            //toolTip1.Hide(this.listView1); 
        }

        private void btSyncOldHISPatInfo_Click(object sender, EventArgs e)
        {
            TrasenHIS.BLL.SyncPatientInfo.SyncPat(FrmMdiMain.Database);
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["����"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = dgvNewPatient.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";
        }
        /// <summary>
        /// ����ҽ��ϵͳ���������ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem8_Click(object sender, EventArgs e)
        {
            Process proc = null;
            try
            {
                string targetDir = string.Format(@"D:\bsoft\portal");//this is where mybatch.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName ="HisIntoNis.bat";
                proc.StartInfo.Arguments = string.Format(InstanceForm.BCurrentUser.LoginCode.ToString()+" "+patientInfo1.lbID.Text.Remove(0,2));//this is argument
                //proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.CreateNoWindow = false;
                //proc.StartInfo.UseShellExecute = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }

    }
}
