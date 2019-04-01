using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using Crownwood.Magic.Docking;
using Crownwood.Magic.Common;
using System.IO;
using Trasen.jqg.Print.Interface;
using Trasen.jqg.Print;
using grproLib;
using ts_zyhs_yzgl;
using System.Text;
namespace ts_zyhs_yzzc
{
    /// <summary>
    /// Form2 ��ժҪ˵����
    /// </summary>
    public class frmYZZC : System.Windows.Forms.Form
    {
        private BaseFunc myFunc;

        /// <summary>
        /// ͣ����ҽ��ʱ���Ƿ���ʾ��Ӧִ�п����Ѿ�ֹͣ 0=�� 1=��
        /// </summary>
        private SystemCfg cfg7154 = new SystemCfg(7154);
        private string sPaint = "";
        private int max_len0 = 0, max_len1 = 0, max_len2 = 0;//���ҽ������,���ҽ������(��������λ��),���������λ����	
        private Guid old_BinID = Guid.Empty;
        private long old_BabyID = 0;
        private int Kind = 0;    // 0��ҽ��  1δת��  2��ת��  3δ�˶�   4�Ѻ˶�  5δ���  6�Ѳ�� 
        DataTable outTb = new DataTable();
        DockingManager _dockingManager;
        // ���� סԺ�� ���� ���� ʱ�� ҽ�� ���� ҽ������ �� ת����ʿ �˶Ի�ʿ ִ�п��� ��� USAGE
        /// <summary>
        /// סԺ�Ƿ����÷���ȷ�ϣ���ҽ����Ŀ�⣩
        /// </summary>
        private SystemCfg cfg7212 = new SystemCfg(7212);

        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Panel panel��;
        private System.Windows.Forms.Button bt�˳�;
        private ������Ϣ.PatientInfo patientInfo1;
        private �۸���Ϣ.PriceInfo priceInfo1;
        private System.Windows.Forms.Button btOpenModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelҽ��;
        private System.Windows.Forms.RadioButton rb���в���;
        private System.Windows.Forms.RadioButton rbѡ������;
        private System.Windows.Forms.Button bt��ѡ;
        private System.Windows.Forms.Button btȫѡ;
        private System.Windows.Forms.Button bt��ʾ�л�;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Button bt��ѯ;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btת��;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DataGridEx myDataGrid3;
        private DataGridTableStyle dataGridTableStyle2;
        private Panel panel����;
        private Button bt��ѡ1;
        private Button btȫѡ1;
        private DataGridEx dataGridEx1;
        private DataGridTableStyle dataGridTableStyle3;
        private Button btnMsg;
        private Button btn_yzdy;
        private IContainer components;
        SystemCfg cfg7048 = new SystemCfg(7048);
        SystemCfg cfg7169 = new SystemCfg(7169);
        private Button btnRefuse;
        private UcShowCard ucShowCard1;
        private Label label3;
        /// <summary>
        /// Ƥ��ҽ��ת��ʱ�Ƿ����Ƥ��ҩƷҽ����ʼʱ�� 0=�� 1=��
        /// </summary>
        private SystemCfg cfg7165 = new SystemCfg(7165);
        public frmYZZC(string _formText, int _kind)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            Kind = _kind;
            this.Text = _formText;


            myFunc = new BaseFunc();

            DockingPanel();
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
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
            this.panel�� = new System.Windows.Forms.Panel();
            this.panel���� = new System.Windows.Forms.Panel();
            this.ucShowCard1 = new ts_zyhs_classes.UcShowCard();
            this.bt��ѡ1 = new System.Windows.Forms.Button();
            this.btȫѡ1 = new System.Windows.Forms.Button();
            this.dataGridEx1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.panelҽ�� = new System.Windows.Forms.Panel();
            this.btn_yzdy = new System.Windows.Forms.Button();
            this.btnMsg = new System.Windows.Forms.Button();
            this.rb���в��� = new System.Windows.Forms.RadioButton();
            this.rbѡ������ = new System.Windows.Forms.RadioButton();
            this.bt��ѡ = new System.Windows.Forms.Button();
            this.btȫѡ = new System.Windows.Forms.Button();
            this.bt��ʾ�л� = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel�� = new System.Windows.Forms.Panel();
            this.btnRefuse = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.patientInfo1 = new ������Ϣ.PatientInfo();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bt��ѯ = new System.Windows.Forms.Button();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.btת�� = new System.Windows.Forms.Button();
            this.btOpenModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.myDataGrid3 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.priceInfo1 = new �۸���Ϣ.PriceInfo();
            this.label3 = new System.Windows.Forms.Label();
            this.panel��.SuspendLayout();
            this.panel����.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).BeginInit();
            this.panelҽ��.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel��.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel��
            // 
            this.panel��.Controls.Add(this.panel����);
            this.panel��.Controls.Add(this.panelҽ��);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel��.Location = new System.Drawing.Point(0, 0);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1008, 468);
            this.panel��.TabIndex = 1;
            // 
            // panel����
            // 
            this.panel����.Controls.Add(this.ucShowCard1);
            this.panel����.Controls.Add(this.bt��ѡ1);
            this.panel����.Controls.Add(this.btȫѡ1);
            this.panel����.Controls.Add(this.dataGridEx1);
            this.panel����.Location = new System.Drawing.Point(82, 56);
            this.panel����.Name = "panel����";
            this.panel����.Size = new System.Drawing.Size(206, 333);
            this.panel����.TabIndex = 90;
            // 
            // ucShowCard1
            // 
            this.ucShowCard1.IType = 0;
            this.ucShowCard1.Key = "";
            this.ucShowCard1.Location = new System.Drawing.Point(5, 1);
            this.ucShowCard1.Name = "ucShowCard1";
            this.ucShowCard1.Row = null;
            this.ucShowCard1.Size = new System.Drawing.Size(113, 21);
            this.ucShowCard1.TabIndex = 88;
            this.ucShowCard1.Value = "";
            this.ucShowCard1.MyDelEvent += new ts_zyhs_classes.UcShowCard.MyDel(this.ucShowCard1_MyDelEvent);
            // 
            // bt��ѡ1
            // 
            this.bt��ѡ1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ѡ1.Location = new System.Drawing.Point(163, 1);
            this.bt��ѡ1.Name = "bt��ѡ1";
            this.bt��ѡ1.Size = new System.Drawing.Size(37, 20);
            this.bt��ѡ1.TabIndex = 85;
            this.bt��ѡ1.Text = "��ѡ";
            this.bt��ѡ1.UseVisualStyleBackColor = false;
            this.bt��ѡ1.Click += new System.EventHandler(this.bt��ѡ1_Click);
            // 
            // btȫѡ1
            // 
            this.btȫѡ1.BackColor = System.Drawing.Color.PaleGreen;
            this.btȫѡ1.Location = new System.Drawing.Point(122, 1);
            this.btȫѡ1.Name = "btȫѡ1";
            this.btȫѡ1.Size = new System.Drawing.Size(37, 20);
            this.btȫѡ1.TabIndex = 84;
            this.btȫѡ1.Text = "ȫѡ";
            this.btȫѡ1.UseVisualStyleBackColor = false;
            this.btȫѡ1.Click += new System.EventHandler(this.btȫѡ1_Click);
            // 
            // dataGridEx1
            // 
            this.dataGridEx1.AllowSorting = false;
            this.dataGridEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEx1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridEx1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridEx1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridEx1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridEx1.DataMember = "";
            this.dataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEx1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridEx1.Name = "dataGridEx1";
            this.dataGridEx1.ReadOnly = true;
            this.dataGridEx1.RowHeaderWidth = 5;
            this.dataGridEx1.Size = new System.Drawing.Size(206, 333);
            this.dataGridEx1.TabIndex = 86;
            this.dataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dataGridEx1.CurrentCellChanged += new System.EventHandler(this.dataGridEx1_CurrentCellChanged);
            this.dataGridEx1.Click += new System.EventHandler(this.dataGridEx1_Click);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.dataGridEx1;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.RowHeaderWidth = 5;
            // 
            // panelҽ��
            // 
            this.panelҽ��.Controls.Add(this.label3);
            this.panelҽ��.Controls.Add(this.btn_yzdy);
            this.panelҽ��.Controls.Add(this.btnMsg);
            this.panelҽ��.Controls.Add(this.rb���в���);
            this.panelҽ��.Controls.Add(this.rbѡ������);
            this.panelҽ��.Controls.Add(this.bt��ѡ);
            this.panelҽ��.Controls.Add(this.btȫѡ);
            this.panelҽ��.Controls.Add(this.bt��ʾ�л�);
            this.panelҽ��.Controls.Add(this.myDataGrid1);
            this.panelҽ��.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelҽ��.Location = new System.Drawing.Point(0, 0);
            this.panelҽ��.Name = "panelҽ��";
            this.panelҽ��.Size = new System.Drawing.Size(1008, 468);
            this.panelҽ��.TabIndex = 1;
            // 
            // btn_yzdy
            // 
            this.btn_yzdy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_yzdy.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_yzdy.Location = new System.Drawing.Point(863, 1);
            this.btn_yzdy.Name = "btn_yzdy";
            this.btn_yzdy.Size = new System.Drawing.Size(86, 20);
            this.btn_yzdy.TabIndex = 81;
            this.btn_yzdy.Text = "ҽ����ӡ";
            this.btn_yzdy.UseVisualStyleBackColor = false;
            this.btn_yzdy.Click += new System.EventHandler(this.btn_yzdy_Click);
            // 
            // btnMsg
            // 
            this.btnMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMsg.BackColor = System.Drawing.Color.PaleGreen;
            this.btnMsg.Location = new System.Drawing.Point(638, 1);
            this.btnMsg.Name = "btnMsg";
            this.btnMsg.Size = new System.Drawing.Size(86, 20);
            this.btnMsg.TabIndex = 83;
            this.btnMsg.Text = "֪ͨҽ��(&M)";
            this.btnMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMsg.UseVisualStyleBackColor = false;
            this.btnMsg.Visible = false;
            this.btnMsg.Click += new System.EventHandler(this.btnMsg_Click);
            // 
            // rb���в���
            // 
            this.rb���в���.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb���в���.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rb���в���.Checked = true;
            this.rb���в���.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb���в���.Location = new System.Drawing.Point(559, 3);
            this.rb���в���.Name = "rb���в���";
            this.rb���в���.Size = new System.Drawing.Size(72, 18);
            this.rb���в���.TabIndex = 82;
            this.rb���в���.TabStop = true;
            this.rb���в���.Text = "���в���";
            this.rb���в���.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb���в���.UseVisualStyleBackColor = false;
            // 
            // rbѡ������
            // 
            this.rbѡ������.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbѡ������.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbѡ������.Location = new System.Drawing.Point(483, 3);
            this.rbѡ������.Name = "rbѡ������";
            this.rbѡ������.Size = new System.Drawing.Size(72, 18);
            this.rbѡ������.TabIndex = 81;
            this.rbѡ������.Text = "ѡ������";
            this.rbѡ������.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbѡ������.UseVisualStyleBackColor = false;
            // 
            // bt��ѡ
            // 
            this.bt��ѡ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ѡ.Location = new System.Drawing.Point(798, 1);
            this.bt��ѡ.Name = "bt��ѡ";
            this.bt��ѡ.Size = new System.Drawing.Size(56, 20);
            this.bt��ѡ.TabIndex = 80;
            this.bt��ѡ.Text = "��ѡ(&F)";
            this.bt��ѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ѡ.UseVisualStyleBackColor = false;
            this.bt��ѡ.Click += new System.EventHandler(this.bt��ѡ_Click);
            // 
            // btȫѡ
            // 
            this.btȫѡ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btȫѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.btȫѡ.Location = new System.Drawing.Point(733, 1);
            this.btȫѡ.Name = "btȫѡ";
            this.btȫѡ.Size = new System.Drawing.Size(56, 20);
            this.btȫѡ.TabIndex = 79;
            this.btȫѡ.Text = "ȫѡ(&A)";
            this.btȫѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btȫѡ.UseVisualStyleBackColor = false;
            this.btȫѡ.Click += new System.EventHandler(this.btȫѡ_Click);
            // 
            // bt��ʾ�л�
            // 
            this.bt��ʾ�л�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ʾ�л�.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ʾ�л�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ʾ�л�.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt��ʾ�л�.Location = new System.Drawing.Point(379, 1);
            this.bt��ʾ�л�.Name = "bt��ʾ�л�";
            this.bt��ʾ�л�.Size = new System.Drawing.Size(98, 20);
            this.bt��ʾ�л�.TabIndex = 69;
            this.bt��ʾ�л�.Text = "��ʾ�����б�";
            this.bt��ʾ�л�.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ʾ�л�.UseVisualStyleBackColor = false;
            this.bt��ʾ�л�.Click += new System.EventHandler(this.bt��ʾ�л�_Click_1);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "δת��ҽ�������У�";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1008, 468);
            this.myDataGrid1.TabIndex = 25;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myDataGrid1_MouseUp);
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel��
            // 
            this.panel��.Controls.Add(this.btnRefuse);
            this.panel��.Controls.Add(this.patientInfo1);
            this.panel��.Controls.Add(this.progressBar1);
            this.panel��.Controls.Add(this.bt��ѯ);
            this.panel��.Controls.Add(this.bt�˳�);
            this.panel��.Controls.Add(this.btת��);
            this.panel��.Controls.Add(this.btOpenModel);
            this.panel��.Controls.Add(this.groupBox1);
            this.panel��.Controls.Add(this.myDataGrid3);
            this.panel��.Controls.Add(this.priceInfo1);
            this.panel��.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel��.Location = new System.Drawing.Point(0, 468);
            this.panel��.Name = "panel��";
            this.panel��.Size = new System.Drawing.Size(1008, 124);
            this.panel��.TabIndex = 2;
            // 
            // btnRefuse
            // 
            this.btnRefuse.ContextMenu = this.contextMenu1;
            this.btnRefuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefuse.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefuse.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnRefuse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefuse.ImageIndex = 9;
            this.btnRefuse.Location = new System.Drawing.Point(887, 8);
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.Size = new System.Drawing.Size(58, 24);
            this.btnRefuse.TabIndex = 67;
            this.btnRefuse.Text = "�ܾ�(&R)";
            this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem10,
            this.menuItem8,
            this.menuItem9});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "��ҽ��";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "δת��ҽ��";
            this.menuItem3.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "��ת��ҽ��";
            this.menuItem4.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "δ�˶�ҽ��";
            this.menuItem6.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 6;
            this.menuItem7.Text = "�Ѻ˶�ҽ��";
            this.menuItem7.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 7;
            this.menuItem10.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 8;
            this.menuItem8.Text = "δ���ҽ��";
            this.menuItem8.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 9;
            this.menuItem9.Text = "�Ѳ��ҽ��";
            this.menuItem9.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // patientInfo1
            // 
            this.patientInfo1.BackColor = System.Drawing.SystemColors.Control;
            this.patientInfo1.IsShow = true;
            this.patientInfo1.Location = new System.Drawing.Point(0, 0);
            this.patientInfo1.Name = "patientInfo1";
            this.patientInfo1.Size = new System.Drawing.Size(460, 124);
            this.patientInfo1.TabIndex = 60;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(767, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 8);
            this.progressBar1.TabIndex = 65;
            // 
            // bt��ѯ
            // 
            this.bt��ѯ.ContextMenu = this.contextMenu1;
            this.bt��ѯ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt��ѯ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ѯ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt��ѯ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt��ѯ.ImageIndex = 9;
            this.bt��ѯ.Location = new System.Drawing.Point(771, 8);
            this.bt��ѯ.Name = "bt��ѯ";
            this.bt��ѯ.Size = new System.Drawing.Size(58, 24);
            this.bt��ѯ.TabIndex = 64;
            this.bt��ѯ.Text = "��ѯ(&C)";
            this.bt��ѯ.Click += new System.EventHandler(this.bt��ѯ_Click);
            // 
            // bt�˳�
            // 
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(945, 8);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(58, 24);
            this.bt�˳�.TabIndex = 63;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // btת��
            // 
            this.btת��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btת��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btת��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btת��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btת��.ImageIndex = 9;
            this.btת��.Location = new System.Drawing.Point(829, 8);
            this.btת��.Name = "btת��";
            this.btת��.Size = new System.Drawing.Size(58, 24);
            this.btת��.TabIndex = 62;
            this.btת��.Text = "ת��(&Z)";
            this.btת��.Click += new System.EventHandler(this.btת��_Click);
            // 
            // btOpenModel
            // 
            this.btOpenModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenModel.Enabled = false;
            this.btOpenModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpenModel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenModel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btOpenModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenModel.ImageIndex = 1;
            this.btOpenModel.Location = new System.Drawing.Point(767, 0);
            this.btOpenModel.Name = "btOpenModel";
            this.btOpenModel.Size = new System.Drawing.Size(240, 40);
            this.btOpenModel.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(767, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginDate.Enabled = false;
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginDate.Location = new System.Drawing.Point(64, 18);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(165, 21);
            this.dtpBeginDate.TabIndex = 10;
            this.dtpBeginDate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "����";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "�ӣ�";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(64, 42);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(165, 21);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "��ʱ���ѯ";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // myDataGrid3
            // 
            this.myDataGrid3.AllowSorting = false;
            this.myDataGrid3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid3.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid3.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid3.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
            this.myDataGrid3.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid3.DataMember = "";
            this.myDataGrid3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid3.Location = new System.Drawing.Point(461, 0);
            this.myDataGrid3.Name = "myDataGrid3";
            this.myDataGrid3.ReadOnly = true;
            this.myDataGrid3.RowHeaderWidth = 20;
            this.myDataGrid3.Size = new System.Drawing.Size(304, 124);
            this.myDataGrid3.TabIndex = 66;
            this.myDataGrid3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid3.Visible = false;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid3;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // priceInfo1
            // 
            this.priceInfo1.Dv = null;
            this.priceInfo1.Location = new System.Drawing.Point(459, 0);
            this.priceInfo1.Name = "priceInfo1";
            this.priceInfo1.Order_context = null;
            this.priceInfo1.Size = new System.Drawing.Size(309, 128);
            this.priceInfo1.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(119, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "�̣���ͨ�������󷽲�ͨ������δ��";
            // 
            // frmYZZC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 592);
            this.Controls.Add(this.panel��);
            this.Controls.Add(this.panel��);
            this.Name = "frmYZZC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZZC_Load_1);
            this.Activated += new System.EventHandler(this.frmYZZC_Load);
            this.panel��.ResumeLayout(false);
            this.panel����.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).EndInit();
            this.panelҽ��.ResumeLayout(false);
            this.panelҽ��.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel��.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid3)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void DockingPanel()
        {
            _dockingManager = new DockingManager(this, VisualStyle.IDE);

            _dockingManager.InnerControl = panel��;
            _dockingManager.OuterControl = panel��;

            Content content = _dockingManager.Contents.Add(panel����, "�����б�");

            WindowContent wc = _dockingManager.AddContentWithState(content, State.DockLeft) as WindowContent;

            content.CloseButton = false;
            content.HideButton = true;
            content.DisplaySize = panel����.Size;
            content.AutoHideSize = panel����.Size;

            _dockingManager.HideAllContents();
        }

        private void frmYZZC_Load(object sender, System.EventArgs e)
        {
            DateTime now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            //��������ǰϵͳ����
            this.dtpBeginDate.Value = Convert.ToDateTime(now.ToShortDateString() + " 00:00:00");
            this.dtpBeginDate.MinDate = Convert.ToDateTime("2004-7-1 00:00:00");
            this.dtpBeginDate.MaxDate = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");

            this.dtpEndDate.Value = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");
            this.dtpEndDate.MinDate = Convert.ToDateTime("2004-7-1 00:00:00");
            this.dtpEndDate.MaxDate = Convert.ToDateTime(now.ToShortDateString() + " 23:59:59");

            //Modify By Tany 2015-02-09 �����ٰ�����
            string sSql = string.Format(@"  SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,INPATIENT_ID,Baby_ID,DEPT_ID
                    FROM vi_zy_vInpatient_Bed WHERE  WARD_ID= '{0}' 
                    order by case when  isnumeric(BED_NO)=1 and SUBSTRING (BED_NO ,0,2)<>'+'   then 1  
                    when PATINDEX('%[߹-��]%',BED_NO)>0 then 2 when SUBSTRING (BED_NO ,0,2)='+' then 3  else  4   end
                    ,case when isnumeric(BED_NO)=1 then cast(bed_no as int) else 999999 end,BED_NO,baby_id", InstanceForm.BCurrentDept.WardId);
            myFunc.ShowGrid(1, sSql, this.dataGridEx1);

            this.dataGridEx1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName1 ={ "ѡ", "����", "סԺ��", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID" };
            int[] GrdWidth1 ={ 2, 5, 0, 10, 0, 0, 0 };
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.dataGridEx1);
            //Modify by jchl
            DataTable dtSrc = dataGridEx1.DataSource as DataTable;
            DoInitCtr(GrdMappingName1, GrdMappingName1, new string[] { "����", "סԺ��", "����" }, new int[] { 0, 60, 100, 80, 0, 0, 0 }, dtSrc);

            btȫѡ1_Click(null, null);

            this.Show_Data();
            int sfztwide = 0;
            int ischeck = 0;
            DataTable dt = new DataTable();
            string sql_sfkg = "select dictvalue1 from YHS_HOS_DICT where id=1";
            dt = InstanceForm.BDatabase.GetDataTable(sql_sfkg);
            if (dt.Rows[0]["dictvalue1"].ToString() == "1")
            {
                DataTable dt_dept = new DataTable();
                string sql_dept = "select IsCheck   from YHS_HOS_KESHI_SF where KESHI_CODE= " + InstanceForm.BCurrentDept.DeptId.ToString();
                dt_dept = InstanceForm.BDatabase.GetDataTable(sql_dept);
                if (dt_dept.Rows.Count > 0 && dt_dept.Rows[0]["IsCheck"].ToString() == "1")
                { ischeck = 1; }
            }
            if (ischeck == 1)
            {
                sfztwide = 2;
            }
            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","Inpatient_ID","Baby_ID","isMY","item_code","xmly",    
										"ѡ","��","����","סԺ��","����","����","ʱ��","ҽ��","����","ҽ������","���","��","ִ�п���","ת����ʿ","�˶Ի�ʿ","��Ի�ʿ",
										"������","����","��Σ","��ʳ","order_hl","order_bz","order_bw","order_ys","ͣ","SERIAL_NO","mngtype",
                                        "AUDITING_USER","AUDITING_USER1","AUDITING_USER2","usage","ps_flag","ps_orderid","ps_user","hoitem_id"};
            int[] GrdWidth =     { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, sfztwide, 5, 9, 6, 5, 5, 6, 4, 80, 4, 4, 10, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
        }


        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //����������

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "ѡ")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            string TypeStr = sender.GetType().ToString();
            if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn"
                || sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn")
            {

                DataGridEx DataGrid = new DataGridEx();
                switch (TypeStr)
                {
                    case "TrasenClasses.GeneralControls.DataGridEnableBoolColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableBoolColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                    case "TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn":
                        {
                            DataGrid = (TrasenClasses.GeneralControls.DataGridEx)((((TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn)sender).DataGridTableStyle).DataGrid);
                            break;
                        }
                }

                DataTable myTb = (DataTable)DataGrid.DataSource;
                if (myTb == null || myTb.Rows.Count == 0)
                    return;
                //��ɫ������ҽ����״̬ 
                int ColorCol = 0;		 //״̬��
                int ntype = 10;		 //7��˵��
                e.BackColor = Color.White;
                if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //�����
                {
                    e.ForeColor = Color.Blue;
                }
                if (this.myDataGrid1[e.Row, ColorCol].ToString() == "5")   //��ֹͣ
                {
                    e.ForeColor = Color.Gray;
                }

                //��ʱҽ���ú�ɫ
                if (this.myDataGrid1[e.Row, 45].ToString() == "1" || this.myDataGrid1[e.Row, 45].ToString() == "5")
                {
                    e.ForeColor = Color.Red;
                }

                if (sender is DataGridEnableTextBoxColumn)
                {

                    DataGridEnableTextBoxColumn tb = sender as DataGridEnableTextBoxColumn;
                    if (tb.HeaderText.Trim().Equals("���"))
                    {

                        //˵����ҽ�������ɫ
                        if (this.myDataGrid1[e.Row, ntype].ToString() == "7")
                        {
                            //e.ForeColor = Color.Orange;
                            string _color = Convertor.IsNull("Orange", "");
                            if (_color != "")
                            {
                                Color cl = Color.FromName(_color);
                                //e.BackColor = Color.Orange;
                                if (cl.ToArgb() != 0)
                                {
                                    e.ForeColor = cl;
                                    // e.ForeColor = Color.White;
                                }
                            }
                        }
                    }
                }

                ////˵��ҽ������ɫ //Add By tany 2011-06-19
                //if (this.myDataGrid1[e.Row, 28].ToString() == "˵��")
                //{
                //    e.ForeColor = Color.Brown;
                //}

                //ѡ����
                if (this.myDataGrid1[e.Row, 19].ToString() == "True")
                {
                    e.BackColor = Color.GreenYellow;
                }
                else
                {
                    e.BackColor = Color.White;
                }
            }
        }


        private void checkBox1_Click(object sender, System.EventArgs e)
        {
            bool isChecked = this.checkBox1.Checked;
            this.label1.Enabled = isChecked;
            this.label2.Enabled = isChecked;
            this.dtpBeginDate.Enabled = isChecked;
            this.dtpEndDate.Enabled = isChecked;
        }


        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            MenuItem mn = (MenuItem)sender;
            string mnName = mn.Text.Trim();
            switch (mnName)
            {
                case "��ҽ��":
                    this.Kind = 0;
                    break;
                case "δת��ҽ��":
                    this.Kind = 1;
                    break;
                case "��ת��ҽ��":
                    this.Kind = 2;
                    break;
                case "δ�˶�ҽ��":
                    this.Kind = 3;
                    break;
                case "�Ѻ˶�ҽ��":
                    this.Kind = 4;
                    break;
                case "δ���ҽ��":
                    this.Kind = 5;
                    break;
                case "�Ѳ��ҽ��":
                    this.Kind = 6;
                    break;
            }
            this.Show_Data();
        }

        private void Show_Data()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            this.btת��.Enabled = false;
            switch (this.Kind)
            {
                case 0:
                    this.myDataGrid1.CaptionText = "��ҽ��";
                    break;
                case 1:
                    this.myDataGrid1.CaptionText = "δת��ҽ��";
                    this.btת��.Text = "ת��(&Z)";
                    break;
                case 2:
                    this.myDataGrid1.CaptionText = "��ת��ҽ��";
                    this.btת��.Text = "ת��(&Z)";
                    break;
                case 3:
                    this.myDataGrid1.CaptionText = "δ�˶�ҽ��";
                    this.btת��.Text = "�˶�(&Z)";
                    break;
                case 4:
                    this.myDataGrid1.CaptionText = "�Ѻ˶�ҽ��";
                    this.btת��.Text = "�˶�(&Z)";
                    break;
                case 5:
                    this.myDataGrid1.CaptionText = "δ���ҽ��";
                    this.btת��.Text = "���(&Z)";
                    break;
                case 6:
                    this.myDataGrid1.CaptionText = "�Ѳ��ҽ��";
                    this.btת��.Text = "���(&Z)";
                    break;
            }
            this.Text = this.myDataGrid1.CaptionText;

            //this.dtpBeginDate.Value = Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString() + " " + this.dtpBeginDate.Value.Hour + ":" + this.dtpBeginDate.Value.Minute + ":00");
            //this.dtpEndDate.Value = Convert.ToDateTime(this.dtpEndDate.Value.ToShortDateString() + " " + this.dtpEndDate.Value.Hour + ":" + this.dtpEndDate.Value.Minute + ":00");

            DataTable myTb = new DataTable();
            //���Ӳ����б���֧��������������
            //Kind==1
            //Modify By Tany 2009-07-27
            if (1 == 2)
            {
                #region ������������
                if (this.checkBox1.Checked)
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "��ʱ��ӣ�" + this.dtpBeginDate.Value.ToString() + " �� " + this.dtpEndDate.Value.ToString() + "��";
                    myTb = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, Kind, 1, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                }
                else
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "�����У�";
                    myTb = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, Kind, 0, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                }
                #endregion
            }
            else
            {
                #region ������������
                if (this.checkBox1.Checked)
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "��ʱ��ӣ�" + this.dtpBeginDate.Value.ToString() + " �� " + this.dtpEndDate.Value.ToString() + "��";
                }
                else
                {
                    this.myDataGrid1.CaptionText = this.myDataGrid1.CaptionText + "�����У�";
                }

                DataTable patTb = (DataTable)dataGridEx1.DataSource;//InstanceForm.BDatabase.GetDataTable("select inpatient_id,baby_id from vi_zy_vinpatient_bed where ward_id='" + InstanceForm.BCurrentDept.WardId + "' order by bed_no");
                DataTable tmpTb = new DataTable();

                progressBar1.Maximum = patTb.Rows.Count;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;

                //ѭ����������
                for (int i = 0; i < patTb.Rows.Count; i++)
                {
                    if (patTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        tmpTb.Clear();

                        if (this.checkBox1.Checked)
                        {
                            tmpTb = myFunc.GetBinOrdrszcInpatient("", InstanceForm.BCurrentDept.WardId, Kind, 1, this.dtpBeginDate.Value, this.dtpEndDate.Value, new Guid(patTb.Rows[i]["inpatient_id"].ToString()), Convert.ToInt64(patTb.Rows[i]["baby_id"].ToString()));
                        }
                        else
                        {
                            tmpTb = myFunc.GetBinOrdrszcInpatient("", InstanceForm.BCurrentDept.WardId, Kind, 0, this.dtpBeginDate.Value, this.dtpEndDate.Value, new Guid(patTb.Rows[i]["inpatient_id"].ToString()), Convert.ToInt64(patTb.Rows[i]["baby_id"].ToString()));
                        }

                        if (myTb == null || myTb.Columns.Count == 0)
                        {
                            myTb = tmpTb.Clone();
                        }

                        for (int j = 0; j < tmpTb.Rows.Count; j++)
                        {
                            myTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                        }
                    }
                    progressBar1.Value += 1;
                }
                #endregion
            }
            #region //����������ʾ δת����δ�˶� add by zouchihua 2014-8-16
            /*Modify By Tany 2015-04-15 �人������ʱ����Ҫ
            DataTable myTb_tk;
            if (Kind == 1)
            {
                //δ�˶�
                myTb_tk = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, 1, 3, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                for (int i = 0; i < myTb_tk.Rows.Count; i++)
                {
                    DataRow[] whd_row = myTb.Select("order_id='" + myTb_tk.Rows[i]["order_id"].ToString() + "'");
                    if (whd_row.Length <= 0)
                    {
                        myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                    }
                }

            }
            if (Kind == 3)
            {

                //δת��
                myTb_tk = myFunc.GetBinOrdrszc("", InstanceForm.BCurrentDept.WardId, 3, 3, this.dtpBeginDate.Value, this.dtpEndDate.Value);
                for (int i = 0; i < myTb_tk.Rows.Count; i++)
                {
                    DataRow[] whd_row = myTb.Select("order_id='" + myTb_tk.Rows[i]["order_id"].ToString() + "'");
                    if (whd_row.Length <= 0)
                    {
                        myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                    }
                    //myTb.Rows.Add(myTb_tk.Rows[i].ItemArray);
                }
            }
            */
            #endregion
            outTb = myTb.Copy();

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "ѡ";
            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            CheckGrdData(myTb);
            this.myDataGrid1.DataSource = myTb;

            if (myTb.Rows.Count == 0)
            {
                this.old_BabyID = 0;
                this.btת��.Enabled = false;
            }
            else
            {
                if (this.Kind == 1 || this.Kind == 3 || this.Kind == 5) this.btת��.Enabled = true;
            }

            this.priceInfo1.ClearYpInfo();
            this.Show_Patient();
            myDataGrid3_Clear();

            progressBar1.Value = 0;
            Cursor.Current = Cursors.Default;
        }

        private void CheckGrdData(DataTable myTb)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0, iName = 0, iType = 0, iDoc = 0;                //��¼��һ����ʾ���ں�ʱ�䡢����,���ͣ�ҽ�����к�
            int l = 0, group_rows = 1;    //ͬ���е�ҽ������
            bool isShowDay = true;
            this.sPaint = "";

            #region �������
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 1) l += 4;
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {

                #region ��ʾ����
                if (i != 0)
                {
                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[iName]["Inpatient_ID"].ToString().Trim()
                        && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[iName]["Baby_ID"].ToString().Trim())
                    {
                        myTb.Rows[i]["����"] = System.DBNull.Value;
                        myTb.Rows[i]["סԺ��"] = System.DBNull.Value;
                        myTb.Rows[i]["����"] = System.DBNull.Value;
                        isShowDay = false;
                    }
                    else
                    {
                        iName = i;
                        isShowDay = true;  //��Ҫ��ʾ���ں�ʱ��
                    }
                }
                else isShowDay = true;
                #endregion

                #region ��ʾ����ʱ��
                myTb.Rows[i]["����"] = myFunc.getDate(myTb.Rows[i]["����"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["ʱ��"] = myFunc.getTime(myTb.Rows[i]["ʱ��"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["����"].ToString().Trim() == myTb.Rows[iDay]["����"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["����"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["ʱ��"].ToString().Trim() == myTb.Rows[iTime]["ʱ��"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["ʱ��"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion

                #region ��ʾҽ��
                if (i != 0)
                {
                    if (myTb.Rows[i]["ҽ��"].ToString().Trim() == myTb.Rows[iDoc]["ҽ��"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["ҽ��"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDoc = i;
                    }
                }
                #endregion

                #region ��ʾ����
                if (i != 0)
                {
                    if (myTb.Rows[i]["����"].ToString().Trim() == "����")
                    {
                        myTb.Rows[i]["��"] = System.DBNull.Value;
                    }

                    if (myTb.Rows[i]["����"].ToString().Trim() == myTb.Rows[iType]["����"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["����"] = System.DBNull.Value;
                    }
                    else
                    {
                        iType = i;
                    }
                }
                #endregion

                #region ��ʾҽ������

                //��ҽ�����ݡ�+= ��ҽ�����ݡ�+���ո�+��������λ��
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 1) l += 4;
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "") myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                else myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(/*max_len0-l*/5) + sNum;//Modify By Tany 2004-10-27

                //ͣҽ���Ĵ���
                if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 1)
                {
                    if (Convert.ToInt16(myTb.Rows[i]["SERIAL_NO"]) == 0)
                    {
                        myTb.Rows[i]["ҽ������"] = "ͣ��" + myTb.Rows[i]["ҽ������"].ToString();
                    }
                    else
                    {
                        myTb.Rows[i]["ҽ������"] = "    " + myTb.Rows[i]["ҽ������"].ToString();
                    }
                }

                //if  ( (i==myTb.Rows.Count-1) || (i!=myTb.Rows.Count-1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i+1]["Group_id"].ToString().Trim() && myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i+1]["mngtype"].ToString().Trim() ))
                if ((i == myTb.Rows.Count - 1) ||
                       (i != myTb.Rows.Count - 1 &&
                          ((myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()
                              && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[i + 1]["mngtype"].ToString().Trim()
                             )
                            ||
                            (myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                           )
                    //�������ID����Ӥ��ID��һ��������ͬһ���� Add By Tany 2010-03-20
                           || myTb.Rows[i]["inpatient_id"].ToString().Trim() != myTb.Rows[i + 1]["inpatient_id"].ToString().Trim()
                           || myTb.Rows[i]["baby_id"].ToString().Trim() != myTb.Rows[i + 1]["baby_id"].ToString().Trim()
                        )
                    )
                {
                    //��������һ�л��к���һ�е�ҽ���Ų�һ��

                    //ͬ���е�һ��ҽ���ġ�ҽ�����ݡ�+=���÷���+�����١�+ ��Ƶ�ʡ�+��������
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim());
                    myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "")
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    }
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "")
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"��/min";	
                    }
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "" && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&& ( Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 || 
                        //						(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD" ) )
                        )
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    }
                    if (Convert.ToInt16(myTb.Rows[i - group_rows + 1]["Dosage"]) > 1)
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Dosage"].ToString().Trim() + "��";
                    }
                    int cd = 0;
                    //add by zouchihua 2012-6-23 ��������
                    if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��");
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//������ʾ
                        if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//�����ҩƷ
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //������ʾ
                    //if ((myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "1" || myTb.Rows[i - group_rows + 1]["mngtype"].ToString() == "5") && Convert.ToInt32(myTb.Rows[i - group_rows + 1]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1]["zsl"].ToString().Trim() != "")//�����ҩƷ
                    //{
                    //    string ssNum = "";
                    //    if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1]["zsl"]))
                    //    {
                    //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                    //        if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1]["zsl"]) == 0)
                    //            ssNum = "";
                    //    }
                    //    else
                    //    {
                    //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                    //    }
                    //    myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + ssNum + myTb.Rows[i - group_rows + 1]["zsldw"].ToString().Trim();
                    //}

                    //���һ���е�ҽ����������1
                    if (group_rows != 1)
                    {
                        //[3i2]0 �����������һ��ҽ�������һ��������ҽ��������ҽ����status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }
                    group_rows = 1;
                }
                else
                {
                    try
                    {
                        //������ǵ�һ�У��ұ��к���һ�е�ҽ����һ��
                        myTb.Rows[i]["��"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }



                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "2" && myTb.Rows[i]["ntype"].ToString().Trim() != "3") || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        }


        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            myDataGrid3_Clear();
            this.Show_Patient();

            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            string ColumnName = this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim();
            if (ColumnName == "��")
            {
                //add by zouchihua ֻ��ҽ��ת����ʱ��ſ���ѡ��ĩ�κ��״�
                if (Kind != 1)
                    return;
                DataTable myTb = new DataTable();
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null || myTb.Rows.Count == 0) return;

                if (myTb.Rows[nrow]["��"].ToString().Trim() != "")
                {
                    this.addPlCmb(myTb.Rows[nrow]["frequency"].ToString().Trim());
                }
                else
                {
                    DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["��"];
                    dgtb.TextBox.Controls.Clear();
                }
            }
        }

        private void myDataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0)
            {
                this.priceInfo1.ClearYpInfo();
                return;
            }

            //�����ҽ��������
            if (ncol == 27)
            {
                //��ʾҩƷ��Ϣ
                myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb.Rows.Count > 0)
                {
                    int myCJID = Convert.ToInt32(myTb.Rows[nrow]["hoitem_id"]);
                    double myNUM = 0;
                    //add by zouchihua 2012-6-22 �����ʱҽ��������
                    if ((myTb.Rows[nrow]["mngtype"].ToString() == "1" || myTb.Rows[nrow]["mngtype"].ToString() == "5"))
                    {
                        if (myTb.Rows[nrow]["zsl"].ToString() != "")
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["zsl"]);
                        else
                            myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);
                    }
                    else
                        myNUM = Convert.ToDouble(myTb.Rows[nrow]["Num"]);

                    int myDWLX = Convert.ToInt32(myTb.Rows[nrow]["dwlx"]);
                    long myEXECDEPT = Convert.ToInt64(myTb.Rows[nrow]["exec_dept"]);
                    int myTYPE = Convert.ToInt32(myTb.Rows[nrow]["nType"]);
                    //��Ч���ж�
                    if (myTYPE < 3 && myTYPE != 0)
                    {
                        this.priceInfo1.Visible = true;
                        this.myDataGrid3.Visible = false;
                        //Modify By tany 2011-04-12 ��ȡ����ҽ������
                        int yblx = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult("select yblx from zy_inpatient where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "'"));
                        this.priceInfo1.SetYpInfo(myCJID, myNUM, myDWLX, myEXECDEPT, yblx);
                    }
                    else
                    {
                        this.priceInfo1.Visible = false;
                        this.myDataGrid3.Visible = true;
                        this.priceInfo1.ClearYpInfo();
                        if (myTYPE != 3)
                        {
                            long HOitem_ID = Convert.ToInt64(Convertor.IsNull(myTb.Rows[nrow]["hoitem_id"].ToString(), "0"));
                            double num = Convert.ToDouble(Convertor.IsNull(myTb.Rows[nrow]["num"].ToString(), "0"));
                            string User_Name = myTb.Rows[nrow]["order_usage"].ToString();

                            //this.myDataGrid3.TableStyles.Clear();

                            DataTable myTbTemp = myFunc.SetItemInfo("", HOitem_ID, num, User_Name, (new Department(myEXECDEPT, InstanceForm.BDatabase)).Jgbm); //*js);
                            this.myDataGrid3.DataSource = myTbTemp;

                            string[] GrdMappingName4 ={ "id", "����", "����", "��λ", "����", "���" };
                            int[] GrdWidth4 ={ 0, 15, 5, 4, 6, 8 };
                            int[] Alignment4 ={ 0, 0, 0, 0, 0, 0 };
                            int[] Readonly4 ={ 0, 0, 0, 0, 0, 0 };
                            myFunc.InitGrid(GrdMappingName4, GrdWidth4, Alignment4, Readonly4, this.myDataGrid3);

                            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
                            this.myDataGrid3.Refresh();
                        }
                    }
                }
            }
        }

        private void myDataGrid1_Click(object sender, System.EventArgs e)
        {
            //����BOOL��
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //��"ѡ"�ֶ�
            if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "ѡ") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["ѡ"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["ѡ"] = isResult;
            //this.myDataGrid1.DataSource=myTb;
            //this.myDataGrid1.CurrentCell=new DataGridCell(nrow,ncol);	

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[nrow]["mngtype"].ToString().Trim()
                    && myTb.Rows[i]["ͣ"].ToString().Trim() == myTb.Rows[nrow]["ͣ"].ToString().Trim()
                    && myTb.Rows[i]["Inpatient_id"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
                    && myTb.Rows[i]["Baby_id"].ToString().Trim() == myTb.Rows[nrow]["Baby_id"].ToString().Trim()
                    && myTb.Rows[i]["ѡ"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["ѡ"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.myDataGrid1.DataSource = myTb;

        }

        private void myDataGrid3_Clear()
        {
            DataTable myTb = (DataTable)this.myDataGrid3.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            this.myDataGrid3.CaptionText = "��Ŀ��ϸ";
            myTb.Rows.Clear();
        }

        private void myDataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

            while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //����
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 310 + (this.max_len0 + 4) * 6;
                    else start_point = 310 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "1":  //δ���
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //��ֹͣ
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default: //�����
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }


        private void Show_Patient()
        {

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb.Rows.Count == 0)
            {
                this.old_BabyID = 0;
                this.patientInfo1.ClearInpatientInfo();
                return;
            }

            //�õ����˻�����Ϣ
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            //if (this.old_BinID != Convert.ToInt64(this.myDataGrid1[nrow, 14]) || this.old_BabyID != Convert.ToInt64(this.myDataGrid1[nrow, 15]))
            if (this.old_BinID != new Guid(Convertor.IsNull(this.myDataGrid1[nrow, 14], Guid.Empty.ToString())) || this.old_BabyID != Convert.ToInt64(Convertor.IsNull(this.myDataGrid1[nrow, 15], "0")))
            {
                this.old_BinID = new Guid(this.myDataGrid1[nrow, 14].ToString());
                this.old_BabyID = Convert.ToInt32(this.myDataGrid1[nrow, 15]);
                this.patientInfo1.SetInpatientInfo(new Guid(myDataGrid1[nrow, 14].ToString()), Convert.ToInt64(myDataGrid1[nrow, 15]), Convert.ToInt32(this.myDataGrid1[nrow, 15]));
            }
        }


        private void bt��ʾ�л�_Click(object sender, System.EventArgs e)
        {
            if (this.panelҽ��.Height == 592)
            {
                this.panelҽ��.Height = 664;
            }
            else
            {
                this.panelҽ��.Height = 592;
            }
        }

        private void btȫѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb���в���.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["ѡ"] = true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //�²��˵��к�	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["ѡ"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["ѡ"] = isTrue;
                    }
                    else isTrue = false;
                }
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void bt��ѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            int nrow = 0, j = 0;
            bool isTrue = false;
            DataGridCell myCel = myDataGrid1.CurrentCell;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (this.rb���в���.Checked)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["ѡ"] = myTb.Rows[i]["ѡ"].ToString() == "True" ? false : true;
                }
                else
                {
                    if (i == 0
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() != myTb.Rows[i - 1]["Baby_ID"].ToString().Trim())
                        || (i != 0 && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        nrow = i;	 //�²��˵��к�	
                        isTrue = false;
                        for (j = i; j <= myTb.Rows.Count - 1; j++)
                        {
                            if (myTb.Rows[j]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[j]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                            {
                                if (myTb.Rows[j]["ѡ"].ToString() == "True")
                                {
                                    isTrue = true;
                                    break;
                                }
                            }
                            else break;
                        }
                    }

                    if (isTrue && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_ID"].ToString().Trim() && myTb.Rows[i]["Baby_ID"].ToString().Trim() == myTb.Rows[nrow]["Baby_ID"].ToString().Trim())
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                        myTb.Rows[i]["ѡ"] = myTb.Rows[i]["ѡ"].ToString() == "True" ? false : true;
                    }
                }
            }
            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.CurrentCell = myCel;
        }

        private void bt��ѯ_Click(object sender, System.EventArgs e)
        {
            this.Show_Data();
        }
        /// <summary>
        /// ����ִ�п���
        /// </summary>
        private bool GxZxks(DataTable tb)
        {
            SelectTb(tb);
            tb.DefaultView.RowFilter = "convert(ѡ, 'System.String')='True' and  XMLY=2";
            tb = tb.DefaultView.ToTable();
            if (tb.Rows.Count == 0)
                return true;
            Ts_ClinicalPath_Statistics.FrmZxksXg fxg = new Ts_ClinicalPath_Statistics.FrmZxksXg();
            fxg.tb = tb;
            fxg.ShowDialog();
            if (fxg.DialogResult == DialogResult.OK)
                return true;
            else
                return false;
        }
        private void SelectTb(DataTable tb)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i - j < tb.Rows.Count; i++)
            {
                if (tb.Rows[i - j]["����"].ToString().Trim() == "")
                {
                    tb.Rows[i - j]["����"] = tb.Rows[i - j - 1]["����"];
                    tb.Rows[i - j]["סԺ��"] = tb.Rows[i - j - 1]["סԺ��"];
                    tb.Rows[i - j]["����"] = tb.Rows[i - j - 1]["����"];
                    tb.Rows[i - j]["����"] = tb.Rows[i - j - 1]["����"];
                    tb.Rows[i - j]["ʱ��"] = tb.Rows[i - j - 1]["ʱ��"];
                    tb.Rows[i - j]["ҽ��"] = tb.Rows[i - j - 1]["ҽ��"];
                    tb.Rows[i - j]["����"] = tb.Rows[i - j - 1]["����"];
                }
            }

            for (i = 0; i - j < tb.Rows.Count; i++)
            {
                try
                {

                    DataTable temptb = FrmMdiMain.Database.GetDataTable("select * from JC_HOITEMDICTION where (isbks=1 or isryks=1) and order_id=" + tb.Rows[i - j]["HOITEM_ID"] + "");
                    if (temptb.Rows.Count == 0)
                    {

                        tb.Rows.Remove(tb.Rows[i - j]);
                        j++;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        private void btת��_Click(object sender, System.EventArgs e)
        {
            //add by zouchihua 2013-8-27 ��Ѫ��ҽ��
            ArrayList orderlist = new ArrayList();
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            DataTable decoctTb = new DataTable();
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            string sSql = "", sSql1 = "", sSql2 = "", tmpSql = "";
            int i = 0, iSelectRows = 0;
            if (cfg7212.Config.Trim() == "1")
            {
                myTb.DefaultView.RowFilter = "";
                DataTable temptbb = myTb.DefaultView.ToTable();
                myTb.DefaultView.RowFilter = "";
                if (!GxZxks(temptbb)) return;

            }
            DataRow dr;
            DataTable jmcxTb = new DataTable();
            jmcxTb.Columns.Add("Inpatient_ID");
            jmcxTb.Columns.Add("Baby_ID");
            jmcxTb.Columns.Add("����");
            jmcxTb.Columns.Add("סԺ��");
            jmcxTb.Columns.Add("����");
            jmcxTb.Columns.Add("����");
            jmcxTb.Columns.Add("ʱ��");
            jmcxTb.Columns.Add("ҽ��");
            jmcxTb.Columns.Add("ҽ������");
            jmcxTb.Columns.Add("��Ѫ�Ѵ���");
            jmcxTb.Columns.Add("��Ѫ�ܴ���");
            jmcxTb.Columns.Add("dept_br");
            jmcxTb.Columns.Add("dept_id");
            #region �˶�Ҳ��ִ��ǩ��һ�� �����������˹��ź�����
            DateTime _execTime = new DateTime();
            long _employeeId = 0;
            if (this.Kind == 3 || this.Kind == 5)
            {
                frmExecTime frmET = new frmExecTime(InstanceForm.BCurrentUser.UserID, InstanceForm.BDatabase);
                frmET.ShowDialog();

                string zxrxm = "";
                if (frmET.DialogResult == DialogResult.OK)
                {
                    _execTime = frmET._execTime;
                    _employeeId = frmET._employeeId;
                }
            }
            #endregion
            #region ��Ч���ж�
            SystemCfg cfg = new SystemCfg(7041);
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {

                //�Ƿ�����û��Ƥ�Խ����ҽ��ת�� Add By Tany 2007-10-30
                #region
                if (cfg.Config != "��")
                {
                    //�ж���ҪƤ�Ե�ҽ���Ƿ����ת��
                    //ͣҽ�������ж� Modify By Tany 2005-01-26
                    if (this.Kind == 1 && myTb.Rows[i]["ѡ"].ToString() == "True"
                        && Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                        && myTb.Rows[i]["Order_Usage"].ToString().Trim() != "Ƥ��"
                        && myTb.Rows[i]["Order_Usage"].ToString().Trim().ToUpper() != "AST"
                        && Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                    {
                        Guid psOrderId = new Guid(myTb.Rows[i]["ps_orderid"].ToString());
                        string psStr = "select 1 from zy_orderrecord where order_id='" + psOrderId + "'";
                        DataTable psTb = InstanceForm.BDatabase.GetDataTable(psStr);

                        //ֻҪ�ҵ������ݾ�˵����������ԣ����û���ҵ����ٿ��ǲ���û�н����û�ж�Ӧҽ��
                        //˵�������Ƥ���Ǵ������ԣ�����ҽ��ps_flag=-1��������������һ��
                        if (psTb != null && psTb.Rows.Count > 0)
                        {
                            if (AllowYxZc(myTb.Rows[i]["item_code"].ToString().Trim()) == false)
                            {
                                MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����Ƥ�Խ�������ԣ�������ת����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 19);//ѡ����
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }
                        else
                        {
                            psStr = "select count(*) num from zy_orderrecord where ps_orderid='" + new Guid(myTb.Rows[i]["ps_orderid"].ToString()) + "' and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();
                            psTb = InstanceForm.BDatabase.GetDataTable(psStr);
                            if (psTb.Rows[0][0].ToString().Trim() == "1")
                            {
                                MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "��û�ж�Ӧ��Ƥ��ҽ������ҽ�����¿�Ƥ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 19);//ѡ����
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                            MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����û��Ƥ�Խ����������ת����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 19);//ѡ����
                            myDataGrid1_Click(sender, e);
                            return;
                        }
                    }
                }
                #endregion

                #region ��֤ת���˶���
                if (i == 0 || myTb.Rows[i]["Group_ID"].ToString().Trim() != myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                    || myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim())
                {
                    if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        //�˶�ʱ���Ƿ���Ҫ�����жϼ�¼�ĺϷ��ԣ���ִ�п��ң��״�ĩ�Σ�ҩƷ�ĵ�λ�ȵȣ�
                        iSelectRows += 1;
                        if (this.Kind == 3 || this.Kind == 5)
                        {
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == _employeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == _employeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER2"].ToString().Trim() == _employeeId.ToString().Trim()
                                )
                            {
                                MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����ҽ��ת�����˶ԡ���Ի�ʿ������Ϊͬһ�ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (myTb.Rows[i]["AUDITING_USER"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER1"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                || myTb.Rows[i]["AUDITING_USER2"].ToString().Trim() == InstanceForm.BCurrentUser.EmployeeId.ToString().Trim()
                                )
                            {
                                MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����ҽ��ת�����˶ԡ���Ի�ʿ������Ϊͬһ�ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
                #endregion

                //Add By Tany 2015-03-31 �������������ǲ���������ID�����û���򷵻�
                #region ��֤ҽ���Ƿ�������ID
                if (this.Kind == 1 && myTb.Rows[i]["ѡ"].ToString() == "True"
                        && Convert.ToInt16(myTb.Rows[i]["ntype"]) == 5
                        && Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                {
                    Guid YjOrderId = new Guid(myTb.Rows[i]["order_id"].ToString());
                    string YjStr = "select * from zy_jy_print where order_id='" + YjOrderId + "' and delete_bit=0";
                    DataTable YjTb = InstanceForm.BDatabase.GetDataTable(YjStr);

                    //����ҵ���¼
                    if (YjTb != null && YjTb.Rows.Count > 0)
                    {
                        if (Convertor.IsNull(YjTb.Rows[0]["apply_no"], "") == "")
                        {
                            MessageBox.Show(this, "�Բ��𣬡�" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����LIS�����Ϊ��ֵ������ת������֪ͨҽ��ȡ��ҽ�����¿�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 19);//ѡ����
                            myDataGrid1_Click(sender, e);
                            return;
                        }
                    }
                }
                #endregion
            }
            #endregion

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, "ȷ�Ͽ�ʼ��" + this.btת��.Text.Trim() + "����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (this.Kind == 1 && new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                bool isHSZ = f1.isHSZ;
                if (f1.isLogin == false) return;
            }

            Cursor.Current = PubStaticFun.WaitCursor();


            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            //			//�������ݷ��ʶ���
            //			RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
            //			database.Initialize("");
            //			database.Open();

            //
            bool sf_wtg = false;
            int ischeck = 0;
            DataTable dt = new DataTable();
            string sql_sfkg = "select dictvalue1 from YHS_HOS_DICT where id=1";
            dt = InstanceForm.BDatabase.GetDataTable(sql_sfkg);
            if (dt.Rows[0]["dictvalue1"].ToString() == "1")
            {
                DataTable dt_dept = new DataTable();
                string sql_dept = "select IsCheck   from YHS_HOS_KESHI_SF where KESHI_CODE= " + InstanceForm.BCurrentDept.DeptId.ToString();
                dt_dept = InstanceForm.BDatabase.GetDataTable(sql_dept);
                if (dt_dept.Rows.Count > 0 && dt_dept.Rows[0]["IsCheck"].ToString() == "1")
                { ischeck = 1; }
            }

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    //ҩ��ʿ�� add by chenli 2017-09-03
                    if (ischeck == 1)
                    {
                        if ((myTb.Rows[i]["���"].ToString().Trim() == "��ҩ" || myTb.Rows[i]["���"].ToString().Trim() == "��ҩ" || myTb.Rows[i]["���"].ToString().Trim() == "��ҩ") && myTb.Rows[i]["status_flag"].ToString().Trim() == "1" && myTb.Rows[i]["hoitem_id"].ToString().Trim()!="-1")
                        {
                            if (myTb.Rows[i]["��"].ToString().Trim() == "��" || myTb.Rows[i]["��"].ToString().Trim() == "")
                            {
                                sf_wtg = true;
                                //MessageBox.Show(myTb.Rows[i]["����"].ToString().Trim() + "[" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "]" + "��δ�󷽣�����ϵҩ����!");
                                //sf_wtg += myTb.Rows[i]["����"].ToString().Trim() + "[" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "]" + "��δ�󷽣�����ϵҩ����!\r\n";
                                continue;
                            }
                            if (myTb.Rows[i]["��"].ToString().Trim() == "��")
                            {
                                sf_wtg = true;
                                //MessageBox.Show(myTb.Rows[i]["����"].ToString().Trim() + "[" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "]" + "��δͨ��������ϵ����ҽ��!");
                                //sf_wtg += myTb.Rows[i]["����"].ToString().Trim() + "[" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "]" + "��δͨ��������ϵ����ҽ��!\r\n";
                                continue;
                            }
                        }
                    }

                    //Ƥ��ҽ��ת��ʱ����Ƥ���÷�ҽ����ʼʱ�� add by zouchihua 2013-9-4
                    if (cfg7165.Config.Trim() == "1")
                    {
                        if (this.Kind == 1 && myTb.Rows[i]["ѡ"].ToString() == "True"
                            && Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                            && myTb.Rows[i]["Order_Usage"].ToString().Trim() == "Ƥ��"
                            //&& myTb.Rows[i]["����"].ToString().Trim().ToUpper() == "����"
                            && Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                        {
                            string psorder_id = myTb.Rows[i]["ps_orderid"].ToString().Trim().ToUpper();
                            if (psorder_id != Guid.Empty.ToString() && psorder_id != "")
                            {
                                try
                                {
                                    string groupstr = " select GROUP_ID from ZY_ORDERRECORD  where order_id!='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "' and  PS_ORDERID='" + psorder_id + "' and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'";
                                    DataTable grouptb = InstanceForm.BDatabase.GetDataTable(groupstr);
                                    if (grouptb.Rows.Count > 0)
                                    {
                                        InstanceForm.BDatabase.DoCommand("update ZY_ORDERRECORD set  ORDER_BDATE =getdate(),memo='ҽ��ת�����Ŀ�ʼʱ��'+cast(ORDER_BDATE as varchar(36)) where  group_id=" + grouptb.Rows[0]["GROUP_ID"].ToString() + " and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'");
                                    }
                                }
                                catch { }
                            }
                        }

                        //����Ƥ��ҩʱ��

                        if (this.Kind == 1 && myTb.Rows[i]["ѡ"].ToString() == "True"
                            //&& Convert.ToInt16(myTb.Rows[i]["ps_flag"]) == 0
                            && myTb.Rows[i]["Order_Usage"].ToString().Trim() != "Ƥ��"
                            //&& myTb.Rows[i]["����"].ToString().Trim().ToUpper() == "����"
                            && int.Parse(myTb.Rows[i]["ntype"].ToString().Trim()) < 3
                            && Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                        {
                            string psorder_id = myTb.Rows[i]["ps_orderid"].ToString().Trim().ToUpper();
                            if (psorder_id != Guid.Empty.ToString() && psorder_id != "")
                            {
                                try
                                {
                                    string groupstr = " select GROUP_ID from ZY_ORDERRECORD  where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "' and  PS_ORDERID='" + psorder_id + "' and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'";
                                    DataTable grouptb = InstanceForm.BDatabase.GetDataTable(groupstr);
                                    if (grouptb.Rows.Count > 0)
                                    {
                                        InstanceForm.BDatabase.DoCommand("update ZY_ORDERRECORD set  ORDER_BDATE =getdate(),memo='ҽ��ת�����Ŀ�ʼʱ��'+cast(ORDER_BDATE as varchar(36)) where  group_id=" + grouptb.Rows[0]["GROUP_ID"].ToString() + " and  inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'");
                                    }
                                }
                                catch { }
                            }
                        }
                    }

                    #region ��¼�ж�����������Ѫ By Tany 2004-10-30
                    if (Kind == 1)
                    {
                        if (myTb.Rows[i]["usage"].ToString().Trim() == "������Ѫ")
                        {
                            orderlist.Add(outTb.Rows[i]["ORDER_ID"]);
                            dr = jmcxTb.NewRow();
                            dr["Inpatient_ID"] = outTb.Rows[i]["Inpatient_ID"];
                            dr["Baby_ID"] = outTb.Rows[i]["Baby_ID"];
                            dr["����"] = outTb.Rows[i]["����"];
                            dr["סԺ��"] = outTb.Rows[i]["סԺ��"];
                            dr["����"] = outTb.Rows[i]["����"];
                            dr["����"] = myFunc.getDate(outTb.Rows[i]["����"].ToString().Trim(), outTb.Rows[i]["day1"].ToString().Trim());
                            dr["ʱ��"] = myFunc.getTime(outTb.Rows[i]["ʱ��"].ToString().Trim(), outTb.Rows[i]["second1"].ToString().Trim());
                            dr["ҽ��"] = outTb.Rows[i]["ҽ��"];
                            dr["ҽ������"] = outTb.Rows[i]["ҽ������"];
                            dr["��Ѫ�Ѵ���"] = "0";
                            dr["��Ѫ�ܴ���"] = "0";
                            dr["dept_br"] = outTb.Rows[i]["dept_br"];
                            dr["dept_id"] = outTb.Rows[i]["dept_id"];
                            jmcxTb.Rows.Add(dr);
                        }
                    }
                    #endregion



                    if (!(i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                        && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                    {
                        //add by zouchihua 2012-2-21
                        #region �Ƿ�ʹ�������棬ת��ʱ����ʱҽ���������棬����ҽ���������������
                        try
                        {
                            string cfg6035 = new SystemCfg(6035).Config.Trim();
                            if (cfg6035 == "1" && Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0 && Kind == 1)//��ҽ��ת��
                            {
                                myFunc.OprateXnkc(new Guid(myTb.Rows[i]["Inpatient_ID"].ToString().Trim()), long.Parse(myTb.Rows[i]["baby_id"].ToString().Trim()), Guid.Empty, int.Parse(myTb.Rows[i]["Group_ID"].ToString().Trim()), 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            continue;
                        }
                        #endregion

                        //add by zouchihua 2013-9-18 ����ǳ���ҽ������ô�͸ı���ݿ�ʼʱ��ı��״κ�ĩ��
                        if (cfg7169.Config.Trim() == "1" && myTb.Rows[i]["mngtype"].ToString().Trim() == "0" && myTb.Rows[i]["xmly"].ToString().Trim() == "1" && Kind == 1)
                        {

                            myFunc.ChangeFirtorLastTime(myTb.Rows[i]["Inpatient_ID"].ToString().Trim(), myTb.Rows[i]["Group_ID"].ToString().Trim(), Convert.ToInt16(myTb.Rows[i]["ͣ"]), 0,
                                myTb.Rows[i]["FREQUENCY"].ToString().Trim(), cfg7048.Config.Trim());
                        }

                        #region �ж��ǲ����м�ҩ�ѣ�����������һ����ҩ����ʱ�˵�
                        if (Kind == 1)
                        {
                            //add by zouchihua 2013-11-28 ����ı��˼�����ҲҪ�ı�
                            string strdosage = string.Format(@" select id from ZY_DECOCT a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID where a.inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and a.group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and b.num!=" + Convert.ToDecimal(myTb.Rows[i]["dosage"].ToString().Trim()) + "");
                            DataTable tbdosageChange = InstanceForm.BDatabase.GetDataTable(strdosage);
                            if (tbdosageChange.Rows.Count > 0)
                            {
                                string update = string.Format(@"  update ZY_ORDERRECORD set NUM=" + Convert.ToDecimal(myTb.Rows[i]["dosage"].ToString().Trim()) + "  from  ZY_DECOCT a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID "
                                + "     where a.inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and a.group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()));
                                InstanceForm.BDatabase.DoCommand(update);
                            }
                            //Add By Tany 2004-10-20
                            //-------------------------------------------------------------------------------------------------------------
                            Guid n_id = Guid.Empty;
                            string msg = "";
                            int iYZH = 0;
                            string strSql = "select id from zy_decoct where inpatient_id='" + new Guid(myTb.Rows[i]["inpatient_id"].ToString().Trim()) + "'" +
                                " and group_id=" + Convert.ToDecimal(myTb.Rows[i]["group_id"].ToString().Trim()) + " and (order_id is null or order_id=DBO.FUN_GETEMPTYGUID())";
                            decoctTb = InstanceForm.BDatabase.GetDataTable(strSql);



                            if (decoctTb.Rows.Count > 0)
                            {
                                n_id = new Guid(decoctTb.Rows[0][0].ToString().Trim());
                                //��ȡ����ҽ��������
                                for (int j = 0; j <= myTb.Rows.Count - 1; j++)
                                {
                                    if (myTb.Rows[j]["ҽ������"].ToString().Trim() != "" && myTb.Rows[j]["ѡ"].ToString() == "True")
                                    {
                                        if (myTb.Rows[j]["Group_ID"].ToString().Trim() == myTb.Rows[i]["Group_ID"].ToString().Trim() && myTb.Rows[j]["inpatient_id"].ToString().Trim() == myTb.Rows[i]["inpatient_id"].ToString().Trim())
                                        {
                                            msg += " " + myTb.Rows[j]["ҽ������"].ToString().Trim() + "\n";
                                        }
                                    }
                                }


                                //����Ҫ���ʣ�ֱ����ȡ Modify By Tany 2005-08-03
                                if (MessageBox.Show("����ҽ����Ҫ��ҩ���Ƿ��Զ����ɼ�ҩ�ѣ�\n����ҽ��������\n" + msg, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //ȡ���
                                    sSql = @"select max(Group_Id) as YZH " +
                                        "  from Zy_OrderRecord " +
                                        " where inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'" +
                                        "       and baby_id=" + Convert.ToDecimal(myTb.Rows[i]["baby_id"].ToString().Trim());//+
                                    //										"       and mngtype=3";
                                    DataTable myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                                    if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
                                    {
                                        iYZH = 0;
                                    }
                                    else
                                    {
                                        iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]) + 1;
                                    }

                                    //ȡ��ҩ��
                                    sSql = @"Select a.order_id,a.order_name,a.order_unit,a.order_type,a.default_dept " +
                                        " from jc_hoitemdiction a " +
                                        " where a.order_id=" + new SystemCfg(7014).Config;
                                    myTempTb.Clear();
                                    myTempTb = InstanceForm.BDatabase.GetDataTable(sSql);
                                    //���û�����ü�ҩ�Ѵ��룬���������ҩ��
                                    if (myTempTb.Rows.Count == 0 || myTempTb == null)
                                    {
                                        MessageBox.Show("û�����ü�ҩ�Ѵ��룬���ֹ������ҩ�ѣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                    {
                                        decimal v_hoitem_id = Convert.ToDecimal(myTempTb.Rows[0]["order_id"].ToString());
                                        string v_order_context = myTempTb.Rows[0]["order_name"].ToString().Trim();
                                        string v_unit = myTempTb.Rows[0]["order_unit"].ToString().Trim();
                                        int v_order_type = Convert.ToInt32(myTempTb.Rows[0]["order_type"].ToString().Trim());
                                        long v_exec_dept = 0;

                                        //���û��ִ�п��ң����ǲ��˿���
                                        if (myTempTb.Rows[0]["default_dept"].ToString().Trim() == ""
                                            || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "0"
                                            || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "-1"
                                            || myTempTb.Rows[0]["default_dept"].ToString().Trim() == "1")
                                        {
                                            v_exec_dept = Convert.ToInt64(myTb.Rows[i]["dept_br"]);
                                        }
                                        else
                                        {
                                            v_exec_dept = Convert.ToInt64(myTempTb.Rows[0]["default_dept"]);
                                        }

                                        //										//��ʼһ������
                                        //										database.BeginTransaction();

                                        InstanceForm.BDatabase.BeginTransaction();

                                        try
                                        {
                                            Guid v_O_id = PubStaticFun.NewGuid();
                                            //����ҽ����¼��
                                            strSql = @"INSERT INTO ZY_ORDERRECORD( " +
                                                "order_id,jgbm,INPATIENT_ID,Baby_ID,WARD_ID,DEPT_BR,DEPT_ID, " +
                                                "MNGTYPE,ORDER_BDATE,GROUP_ID,NTYPE, " +
                                                "HOITEM_ID,xmly,ORDER_CONTEXT,NUM,DOSAGE,UNIT,ORDER_USAGE,FREQUENCY, " +
                                                "EXEC_DEPT,FIRST_TIMES,STATUS_FLAG, " +
                                                "AUDITING_USER,AUDITING_DATE,OPERATOR,BOOK_DATE,SERIAL_NO ) " +
                                                "VALUES( '" + v_O_id + "'," + FrmMdiMain.Jgbm + ",'" +
                                                myTb.Rows[i]["inpatient_id"].ToString().Trim() + "'," + Convert.ToDecimal(myTb.Rows[i]["baby_id"].ToString().Trim()) +
                                                ",'" + InstanceForm.BCurrentDept.WardId + "'," + Convert.ToDecimal(myTb.Rows[i]["dept_br"].ToString().Trim()) + "," + Convert.ToDecimal(myTb.Rows[i]["dept_id"].ToString().Trim()) +
                                                ",3,getdate()," + iYZH.ToString() + "," + v_order_type + "," +
                                                v_hoitem_id + ",2,'" + v_order_context + "'," + myTb.Rows[i]["dosage"] + ",1,'" + v_unit + "','',''," +
                                                v_exec_dept + ", 1,2," +
                                                InstanceForm.BCurrentUser.EmployeeId.ToString() + ",getdate() ," + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",getdate(),0)";

                                            InstanceForm.BDatabase.DoCommand(strSql);

                                            if (v_O_id == null || v_O_id == Guid.Empty)
                                            {
                                                throw new Exception("û������Order_id���޷��������ݣ�");
                                            }

                                            strSql = "update zy_decoct set order_id='" + v_O_id + "' where id='" + n_id + "'";
                                            InstanceForm.BDatabase.DoCommand(strSql);

                                            InstanceForm.BDatabase.CommitTransaction();

                                        }
                                        catch (Exception err)
                                        {
                                            InstanceForm.BDatabase.RollbackTransaction();

                                            //д������־ Add By Tany 2005-01-12
                                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "ҽ��ת������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                            _systemErrLog.Save();
                                            _systemErrLog = null;

                                            MessageBox.Show("���󣺽���ҩ�Ѳ�����ʱ�˵��������ֹ����ɼ�ҩ�ѣ�\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        int _isstopzc = 0;//add by zouchihua 2013-6-18 ��¼�Ƿ���ͣҽ��ת��
                        #region ��������
                        sSql = @"update zy_OrderRecord ";
                        switch (this.Kind)
                        {
                            case 1:
                                sSql += Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0 ?
                                    //��ҽ��ת��
                                    " set status_flag=2, Auditing_User=" + InstanceForm.BCurrentUser.EmployeeId + ",Auditing_Date=getdate()" :
                                    //ͣҽ��ת��
                                    " set status_flag=4, ORDER_EUSER=" + InstanceForm.BCurrentUser.EmployeeId + ",ORDER_EUDATE=getdate()";
                                tmpSql = " and status_flag in (1,3)";//Add By Tany 2005-01-20 ������ͣ��ת��Ҫ�ж�״̬�����ǲ����Ѿ���ת������	
                                if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 1)
                                    _isstopzc = 1;
                                break;
                            case 3:
                                //add by zouchihua  2014-4-16 �˶�Ҳ��ִ��ǩ��һ�� �����������˹��ź�����
                                sSql += Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0 ?
                                    //��ҽ���˶�
                                    " set Auditing_User1=" + _employeeId + ",Auditing_Date1='" + _execTime + "'" :
                                    //ͣҽ���˶�
                                    " set ORDER_EUSER1=" + _employeeId + ",ORDER_EUDATE1='" + _execTime + "'";
                                break;
                            case 5:
                                //add by zouchihua  2014-4-16 �˶�Ҳ��ִ��ǩ��һ�� �����������˹��ź�����
                                sSql += Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0 ?
                                    //��ҽ�����
                                    " set Auditing_User2=" + InstanceForm.BCurrentUser.EmployeeId + ",Auditing_Date2=getdate()" :
                                    //ͣҽ�����
                                    " set ORDER_EUSER2=" + InstanceForm.BCurrentUser.EmployeeId + ",ORDER_EUDATE2=getdate()";
                                break;
                        }
                        //Modify by zouchihua 2012-1-31  
                        if (myTb.Rows[i]["mngtype"].ToString().Trim() == "1")
                        {
                            sSql += " where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and mngtype in(1,5 )  " +
                                "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;
                        }
                        else
                        {
                            sSql += " where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                 "       and mngtype=" + myTb.Rows[i]["mngtype"].ToString().Trim() +
                                 "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                 "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;
                        }
                        try
                        {
                            InstanceForm.BDatabase.DoCommand(sSql);
                            try
                            {
                                //add by zouchihua 2013-6-18  ҽ������������ʾ
                                if (cfg7154.Config.Trim() == "1" && _isstopzc == 1 && myTb.Rows[i]["ntype"].ToString().Trim() == "5")
                                {
                                    string sqltb = "select * from zy_orderrecord where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "'";
                                    DataTable tbtb = FrmMdiMain.Database.GetDataTable(sqltb);
                                    string msg_wardid = "";
                                    long msg_deptid = long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                                    long msg_empid = 0;
                                    string msg_sender = FrmMdiMain.CurrentDept.DeptName + "��" + FrmMdiMain.CurrentUser.Name;
                                    string msg_msg = FrmMdiMain.CurrentDept.DeptName + " ���� " + myTb.Rows[i]["����"].ToString().Trim() + " ��";
                                    msg_msg += "��" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����ʱ��" + tbtb.Rows[0]["ORDER_EDATE"].ToString() + "ֹͣ����\r\n";
                                    TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.סԺ��ʿվ, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                                }

                            }
                            catch { }

                        }
                        catch (Exception err)
                        {
                            //д������־ Add By Tany 2005-01-12
                            SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "ҽ��ת������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                            _systemErrLog.Save();
                            _systemErrLog = null;

                            MessageBox.Show("����ҽ��ת��ʱ����������ת����\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        if (Kind == 1)
                        {
                            //����Ի��鵥�����zy_jy_print
                            sSql = "update zy_jy_print set finish_bit=1 where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "' and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();

                            try
                            {
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            catch (Exception err)
                            {
                                //д������־ Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "���鵥��˴���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("���󣺻��鵥���ʱ����\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }

                        this.progressBar1.Value += 1;
                        #endregion
                    }

                    #region �������Ϣ����Ҫ�������� by tany
                    sSql1 = "";
                    tmpSql = "";
                    if (this.Kind == 1)
                    {
                        if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                        {
                            //��ҽ��ת��
                            if (Convert.ToInt16(myTb.Rows[i]["������"]) != 0)
                            {
                                sSql1 = "ORDER_HL='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_HL_SPEC='" + myTb.Rows[i]["ҽ������"].ToString() + "',ORDER_TENDLEVEL=" + myTb.Rows[i]["������"].ToString();
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["����"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["��Σ"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW='" + myTb.Rows[i]["Order_ID"].ToString() + "'";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["��ʳ"]) != 0)
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS='" + myTb.Rows[i]["Order_ID"].ToString() + "',ORDER_YS_SPEC='" + myTb.Rows[i]["ҽ������"].ToString() + "'";
                            }

                        }
                        else
                        {
                            //ͣҽ��ת��
                            if (Convert.ToInt16(myTb.Rows[i]["������"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_hl"].ToString().Trim())
                            {
                                sSql1 = "ORDER_HL=null,ORDER_HL_SPEC='',ORDER_TENDLEVEL=0";
                                //Add By Tany 2005-01-12
                                //�����ͣ������Ҫ�������ڻ����¼������ļ����ǲ���һ��
                                //��Ҫ�Ƿ�ֹ�ȿ��»�����ͣ�ϻ����ʱ�����»����¼���
                                tmpSql = "order_tendlevel=" + myTb.Rows[i]["������"].ToString().Trim() + " and";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["����"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bz"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BZ=null"; ;
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["��Σ"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_bw"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_BW=null";
                            }
                            if (Convert.ToInt16(myTb.Rows[i]["��ʳ"]) != 0 && myTb.Rows[i]["Order_ID"].ToString().Trim() == myTb.Rows[i]["order_ys"].ToString().Trim())
                            {
                                sSql1 += sSql1 == "" ? "" : ",";
                                sSql1 += "ORDER_YS=null,ORDER_YS_SPEC=''";
                            }
                        }
                        if (sSql1 != "")
                        {
                            sSql = "update zy_inpatient_hl set " + sSql1 + " where " + tmpSql +
                                " inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "' and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim();

                            try
                            {
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            catch (Exception err)
                            {
                                //д������־ Add By Tany 2005-01-12
                                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "���»����¼����" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                                _systemErrLog.Save();
                                _systemErrLog = null;

                                MessageBox.Show("���󣺸��»����¼ʱ����\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    #endregion

                    //����ҽ����� 2011-07-24
                    try
                    {
                        string isUseQyyl = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("QYYL", "�Ƿ�����", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\QyylInterface.ini");
                        if (isUseQyyl == "1")
                        {
                            if (Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select grjkdah from yy_brxx a inner join zy_inpatient b on a.brxxid=b.patient_id where b.inpatient_id='" + myTb.Rows[i]["inpatient_id"].ToString() + "'"), "") != "")
                            {
                                string QyylType = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("QYYL", "����", TrasenFrame.Classes.Constant.ApplicationDirectory + "\\QyylInterface.ini");

                                ts_qyyl_interface.Iqyyl qyyl = ts_qyyl_interface.QyylFactory.Qyyl(QyylType);

                                if (Convert.ToInt16(myTb.Rows[i]["ͣ"]) == 0)
                                {
                                    qyyl.SetZyyz(myTb.Rows[i]["order_id"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if(sf_wtg)
            {
                MessageBox.Show("�󷽲�ͨ����ҽ����X����δ�󷽵�ҽ����O������ת��,\n��֪ͨҽ����סԺҩ������ҩʦ���й�ͨ");
            }

            //			database.Close();

            if (jmcxTb != null && jmcxTb.Rows.Count != 0)
            {
                frmJmcx fj = new frmJmcx();
                fj.inTb = jmcxTb;
                fj._orderlist = orderlist;//add by zouchihua 2013-8-27 ҽ��id
                fj.ShowDialog();
                //fj.Dispose();
            }
            this.progressBar1.Value = 0;

            this.Show_Data();
        }

        private bool AllowYxZc(string YPHH)
        {
            //�����Ƿ�����ת��
            bool result = false;
            string YXYP = (new SystemCfg(7005)).Config;

            if (YXYP.IndexOf(YPHH.Trim()) >= 0)
                result = true;

            return result;
        }

        private void bt�˳�_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmYZZC_Load_1(object sender, EventArgs e)
        {
            //7096ҽ��ת��Ĭ��ѡ�����˻���ȫѡ���� 0=ȫѡ���� 1=ѡ������
            if (new SystemCfg(7096).Config == "1")
            {
                rbѡ������.Checked = true;
            }
            else
            {
                rb���в���.Checked = true;
            }
        }

        /// <summary>
        /// ����Ƶ��ѡ��
        /// </summary>
        /// <param name="pl">Ƶ��</param>
        private void addPlCmb(string pl)
        {
            int num = 1;
            if (pl.Trim() != "")
            {
                string sSql = "select * from JC_FREQUENCY where upper(name)=upper('" + pl.Trim() + "')";
                DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

                if (myTb.Rows.Count > 0)
                {
                    num = Convert.ToInt32(Convertor.IsNull(myTb.Rows[0]["execnum"], "1"));
                }
            }

            ComboBox cmb = new ComboBox();
            cmb.Items.Clear();
            for (int i = 0; i <= num; i++)
            {
                cmb.Items.Add(i);
            }

            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Dock = DockStyle.Fill;
            cmb.Cursor = Cursors.Hand;
            cmb.DropDownWidth = 80;
            cmb.BackColor = Color.LightCyan;
            cmb.SelectionChangeCommitted += new EventHandler(cmbPl_SelectionChangeCommitted);
            DataGridTextBoxColumn dgtb = (DataGridTextBoxColumn)this.myDataGrid1.TableStyles[0].GridColumnStyles["��"];
            dgtb.TextBox.Controls.Clear();//���������
            dgtb.TextBox.Controls.Add(cmb);
        }

        private void cmbPl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource; ;
            int nrow = this.myDataGrid1.CurrentCell.RowNumber;
            int ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            try
            {
                this.myDataGrid1[this.myDataGrid1.CurrentCell] = ((ComboBox)sender).Text.ToString().Trim();
                int num = Convert.ToInt32(((ComboBox)sender).Text);
                myTb.Rows[nrow]["��"] = num;

                string sql = "";
                if (Convert.ToInt32(myTb.Rows[nrow]["ͣ"]) == 0)
                {
                    sql = "update zy_orderrecord set first_times=" + num + " where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "' and baby_id=" + myTb.Rows[nrow]["baby_id"].ToString() + " and mngtype=" + myTb.Rows[nrow]["mngtype"].ToString() + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString();
                }
                else if (Convert.ToInt32(myTb.Rows[nrow]["ͣ"]) == 1)
                {
                    sql = "update zy_orderrecord set terminal_times=" + num + " where inpatient_id='" + myTb.Rows[nrow]["inpatient_id"].ToString() + "' and baby_id=" + myTb.Rows[nrow]["baby_id"].ToString() + " and mngtype=" + myTb.Rows[nrow]["mngtype"].ToString() + " and group_id=" + myTb.Rows[nrow]["group_id"].ToString();
                }
                FrmMdiMain.Database.DoCommand(sql);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("ѡ���������������ѡ��\n" + err.Message, "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridEx1_Click(object sender, EventArgs e)
        {
            myFunc.SelCol_Click(this.dataGridEx1);
        }

        private void dataGridEx1_CurrentCellChanged(object sender, EventArgs e)
        {
            myFunc.SelRow(this.dataGridEx1);
        }

        private void btȫѡ1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.dataGridEx1);
        }

        private void bt��ѡ1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.dataGridEx1);
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            //DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            //if (myTb == null) return;
            //if (myTb.Rows.Count == 0) return;

            //Cursor.Current = PubStaticFun.WaitCursor();

            //for (i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
            //    {

            //    }
            //}

            //Cursor.Current = Cursors.Default;
        }

        private void bt��ʾ�л�_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < _dockingManager.Contents.Count; i++)
            {
                if (_dockingManager.Contents[i].Visible)
                {
                    _dockingManager.HideContent(_dockingManager.Contents[i]);
                }
                else
                {
                    _dockingManager.ShowContent(_dockingManager.Contents[i]);
                }
            }
        }

        private void btn_yzdy_Click(object sender, EventArgs e)
        {
            DataTable dy_table = (DataTable)this.myDataGrid1.DataSource;
            if (dy_table.Rows.Count < 0)
            {
                MessageBox.Show("û�п��Դ�ӡ��ҽ��");
                return;
            }
            string ID = "";
            int count = 0;
            string zyh = "";
            string ch = "";
            string xm = "";
            string rq = "";
            string sj = "";
            string ys = "";
            int lx = 0;
            DataTable dy_table_new = null;
            DataTable dyzytable = null;

            //  DataRow[] rows = dy_table.Select("ѡ=true", "sort asc");
            DataRow[] rows = dy_table.Select("ѡ=true", "");

            DataTable t = dy_table.Clone();
            t.Clear();
            foreach (DataRow row in rows)
            {
                t.ImportRow(row);
            }
            if (t.Rows.Count == 0)
                dy_table_new = dy_table;
            else
                dy_table_new = t;


            if (!dy_table_new.Columns.Contains("sort"))
            {
                dy_table_new.Columns.Add("sort", Type.GetType("System.Int32"));
            }
            for (int i = 0; i < dy_table_new.Rows.Count; i++)
            {
                if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() != ID)
                {
                    ID = dy_table_new.Rows[i]["INPATIENT_ID"].ToString();
                    zyh = dy_table_new.Rows[i]["סԺ��"].ToString();
                    ch = dy_table_new.Rows[i]["����"].ToString();
                    xm = dy_table_new.Rows[i]["����"].ToString();
                    rq = dy_table_new.Rows[i]["����"].ToString();
                    sj = dy_table_new.Rows[i]["ʱ��"].ToString();
                    ys = dy_table_new.Rows[i]["ҽ��"].ToString();
                    if (dy_table_new.Rows[i]["����"].ToString() == "����")
                        dy_table_new.Rows[i]["sort"] = 0;
                    else
                        dy_table_new.Rows[i]["sort"] = 1;
                    lx = Convert.ToInt32(dy_table_new.Rows[i]["sort"].ToString());
                }
                else
                {
                    if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() == ID && dy_table_new.Rows[i]["����"].ToString() == "")
                        dy_table_new.Rows[i]["sort"] = lx;
                    if (dy_table_new.Rows[i]["INPATIENT_ID"].ToString() == ID && dy_table_new.Rows[i]["����"].ToString() == "����")
                    {
                        dy_table_new.Rows[i]["סԺ��"] = zyh;
                        dy_table_new.Rows[i]["����"] = ch;
                        dy_table_new.Rows[i]["����"] = xm;
                        dy_table_new.Rows[i]["����"] = rq;
                        dy_table_new.Rows[i]["ʱ��"] = sj;
                        dy_table_new.Rows[i]["ҽ��"] = ys;
                        dy_table_new.Rows[i]["sort"] = 1;
                        lx = 1;
                    }

                }
            }
            DataRow[] rows1 = dy_table_new.Select(" ", "sort asc");

            DataTable t1 = dy_table_new.Clone();
            t1.Clear();
            foreach (DataRow row in rows1)
            {
                t1.ImportRow(row);
            }
            dyzytable = t1;

            DateTime date = DateTime.Now;
            String strTime = date.GetDateTimeFormats('y')[0].ToString();//����
            string url = Path.GetDirectoryName(Application.StartupPath);
            Trasen.jqg.Print.Interface.IPrinter printer = new Trasen.jqg.Print.ReportPrinter();
            printer.ReportTemplateFile = Application.StartupPath + "\\ҽ��ת������.grf";
            Trasen.jqg.Print.Interface.IParameter[] par = new Trasen.jqg.Print.Interface.IParameter[1];
            par[0] = new Trasen.jqg.Print.ReportParameter("time", strTime);
            printer.PrintDataSource = dyzytable;
            printer.ReportParameters = par;
            printer.Preview();


        }

        /// <summary>
        /// �ܾ�����  add by jchl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefuse_Click(object sender, EventArgs e)
        {
            try
            {
                //1������״̬1�ܾ�Ϊ����״̬0�����ڡ���ʱҽ����     
                //2��ҽ��ͣҽ��3״̬�ܾ�Ϊ��ʿת��״̬2������ҽ����
                DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count == 0) return;

                string sSql = "", sSql1 = "", sSql2 = "", tmpSql = "";
                int i = 0, iSelectRows = 0;
                if (cfg7212.Config.Trim() == "1")
                {
                    myTb.DefaultView.RowFilter = "";
                    DataTable temptbb = myTb.DefaultView.ToTable();
                    myTb.DefaultView.RowFilter = "";
                    if (!GxZxks(temptbb)) return;
                }
                DataRow dr;

                #region ��Ч���ж�
                SystemCfg cfg = new SystemCfg(7041);
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ҽ������"].ToString().Trim().IndexOf("��Ժ", 0) >= 0 || myTb.Rows[i]["ҽ������"].ToString().Trim().IndexOf("ת", 0) >= 0
                        || myTb.Rows[i]["ҽ������"].ToString().Trim().IndexOf("��������", 0) >= 0 || myTb.Rows[i]["ҽ������"].ToString().Trim().IndexOf("����ҽ��", 0) >= 0 || myTb.Rows[i]["ҽ������"].ToString().Trim().IndexOf("����ҽ��", 0) >= 0)
                    {
                        MessageBox.Show("�Բ���ת�ơ���Ժ������ҽ�����ܾܾ�ת��������ϵҽ��ֱ��ɾ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (i == 0 || myTb.Rows[i]["Group_ID"].ToString().Trim() != myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                        || myTb.Rows[i]["Inpatient_ID"].ToString().Trim() != myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim())
                    {
                        if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                        {
                            if (!myTb.Rows[i]["status_flag"].ToString().Trim().Equals("1"))
                            {
                                MessageBox.Show("�Բ��𣬸�ҽ��" + myTb.Rows[i]["ҽ������"].ToString() + "���������,ֻ�з��͵�ҽ�����ܾܾ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            iSelectRows += 1;
                        }
                    }

                }
                #endregion

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "�Բ���û����Ҫ�ܾ���ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(this, "ȷ��Ҫ�ܾ�ת��ѡ���ҽ����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
                if (this.Kind == 1 && new SystemCfg(7066).Config == "0")
                {
                    frmInPassword f1 = new frmInPassword();
                    f1.ShowDialog();
                    bool isHSZ = f1.isHSZ;
                    if (f1.isLogin == false) return;
                }

                Cursor.Current = PubStaticFun.WaitCursor();

                this.progressBar1.Maximum = iSelectRows;
                this.progressBar1.Value = 0;

                Hashtable hsDept = new Hashtable();
                Hashtable hsBed = new Hashtable();

                try
                {
                    InstanceForm.BDatabase.BeginTransaction();

                    for (i = 0; i <= myTb.Rows.Count - 1; i++)
                    {
                        if (myTb.Rows[i]["ҽ������"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                        {
                            if (!(i != 0 && myTb.Rows[i]["Group_ID"].ToString().Trim() == myTb.Rows[i - 1]["Group_ID"].ToString().Trim()
                                && myTb.Rows[i]["Inpatient_ID"].ToString().Trim() == myTb.Rows[i - 1]["Inpatient_ID"].ToString().Trim()))
                            {
                                //У���ҽ���Ƿ��ѷ���
                                string vSql = "select * from zy_OrderRecord where delete_bit=0 and group_id=" +
                                                myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                                 "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                                 "       and status_flag = 1 " +
                                                  "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;

                                //У�����ҽ���Ƿ�Ϊ����״̬
                                DataTable vTb = FrmMdiMain.Database.GetDataTable(vSql);

                                if (vTb.Rows.Count <= 0)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    this.progressBar1.Value = 0;
                                    return;
                                }

                                #region ����

                                //����ܾ���¼���ܾ���
                                DataRow[] drGrps = myTb.Select("group_id='" + myTb.Rows[i]["group_id"].ToString().Trim() + "'");
                                foreach (DataRow drGrp in drGrps)
                                {
                                    string iSql = "insert into zy_jjyzzc(id,order_id,inpatient_id,status_flag,refuse_flag,refuse_context,refuse_No,refuse_name,refuse_time) values ('" +
                                        TrasenClasses.GeneralClasses.PubStaticFun.NewGuid().ToString() + "','" + drGrp["Order_ID"].ToString() + "','" + drGrp["inpatient_id"].ToString() + "',1,0,''," + InstanceForm.BCurrentUser.EmployeeId + ",'" + InstanceForm.BCurrentUser.Name + "','" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "')";
                                    InstanceForm.BDatabase.DoCommand(iSql);
                                }

                                //����ҽ������״̬����0
                                sSql = @"update zy_OrderRecord set status_flag=0 where delete_bit=0 and group_id=" + myTb.Rows[i]["Group_ID"].ToString().Trim() +
                                         "       and inpatient_id='" + myTb.Rows[i]["Inpatient_ID"].ToString().Trim() + "'" +
                                         "       and baby_id=" + myTb.Rows[i]["Baby_ID"].ToString().Trim() + tmpSql;

                                InstanceForm.BDatabase.DoCommand(sSql);

                                if (!hsDept.ContainsKey(myTb.Rows[i]["dept_id"].ToString().Trim()))
                                {
                                    ArrayList al = new ArrayList();
                                    StringBuilder sb = new StringBuilder();

                                    al.Add(myTb.Rows[i]["Inpatient_ID"].ToString().Trim());
                                    sb.Append(myTb.Rows[i]["����"].ToString().Trim() + "��");

                                    hsDept.Add(myTb.Rows[i]["dept_id"].ToString().Trim(), al);
                                    hsBed.Add(myTb.Rows[i]["dept_id"].ToString().Trim(), sb);
                                }
                                else
                                {
                                    ArrayList al = hsDept[myTb.Rows[i]["dept_id"].ToString().Trim()] as ArrayList;
                                    StringBuilder sb = hsBed[myTb.Rows[i]["dept_id"].ToString().Trim()] as StringBuilder;

                                    if (!al.Contains(myTb.Rows[i]["Inpatient_ID"].ToString().Trim()))
                                    {
                                        al.Add(myTb.Rows[i]["Inpatient_ID"].ToString().Trim());
                                        sb.Append(myTb.Rows[i]["����"].ToString().Trim() + "��");
                                    }
                                }


                                this.progressBar1.Value += 1;
                                #endregion
                            }
                        }
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception ex)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    this.progressBar1.Value = 0;
                    MessageBox.Show("����ҽ��ת��ʱ����������ת����\nϵͳ��" + ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                try
                {
                    try
                    {
                        //string sqltb = "select * from zy_orderrecord where order_id='" + myTb.Rows[i]["ORDER_ID"].ToString().Trim() + "'";
                        //DataTable tbtb = FrmMdiMain.Database.GetDataTable(sqltb);
                        //string msg_wardid = "";
                        //long msg_deptid = long.Parse(myTb.Rows[i]["EXEC_DEPT"].ToString().Trim());
                        //long msg_empid = 0;
                        //string msg_sender = FrmMdiMain.CurrentDept.DeptName + "��" + FrmMdiMain.CurrentUser.Name;
                        //string msg_msg = FrmMdiMain.CurrentDept.DeptName + " ���� " + myTb.Rows[i]["����"].ToString().Trim() + " ��";
                        //msg_msg += "��" + myTb.Rows[i]["ҽ������"].ToString().Trim() + "����ʱ��" + tbtb.Rows[0]["ORDER_EDATE"].ToString() + "ֹͣ����\r\n";
                        //TrasenFrame.Classes.WorkStaticFun.SendMessage(false, SystemModule.סԺ��ʿվ, msg_wardid, msg_deptid, msg_empid, msg_sender, msg_msg);
                        //add by zouchihua 2013-8-15
                        string jzyzxx = "";

                        if (hsDept.Count > 0)
                        {

                            foreach (DictionaryEntry de in hsDept)
                            {
                                string dept = de.Key.ToString();

                                StringBuilder sb = hsBed[dept] as StringBuilder;
                                sb.Remove(sb.Length - 1, 1);
                                jzyzxx = "�оܾ�ת����ҽ��������������\r\n" + sb.ToString() + " ��\r\n �ܾ��ˣ�" + InstanceForm.BCurrentUser.Name + jzyzxx;
                                MessageInfo msg = new MessageInfo();
                                msg.ReciveDeptId = Convert.ToInt32(dept);
                                //msg.ReciveStaffer = InstanceF;
                                msg.FontColor = Color.Red;
                                msg.ReciveSystem = null;
                                //msg.ReciveWardId = 0;// FrmMdiMain.CurrentDept.WardId;
                                msg.Summary = jzyzxx;
                                //msg.SendTime = DateManager.ServerDateTimeByDBType(InstanceForm._database);

                                //msg.AssemblyParameter = "1 2 3";
                                msg.AssemblyFuncationName = "Fun_Ts_zyys_main_1";
                                msg.AssemblyTag = "";
                                msg.AssemblyDLL = "Ts_zyys_main";
                                msg.AssemblyFormText = "סԺҽ��������";
                                msg.IsMustRead = true;
                                WorkStaticFun.SendMessage(msg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception err)
                {
                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId), "�������", "ҽ��ת������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("����ҽ��ת��ʱ����������ת����\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                this.progressBar1.Value = 0;

                this.Show_Data();
            }
            catch { }
        }

        private void ucShowCard1_MyDelEvent()
        {
            ucShowCard1.Value = ucShowCard1.Row["����"].ToString();
            ucShowCard1.Key = ucShowCard1.Row["INPATIENT_ID"].ToString();

            DataTable dt = dataGridEx1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return;

            dt.DefaultView.RowFilter = "INPATIENT_ID='" + ucShowCard1.Key + "'";
        }

        private void DoInitCtr(string[] headtext, string[] mappingname, string[] serchFileds, int[] cols, DataTable dtSrc)
        {
            ucShowCard1.Init(headtext, mappingname, serchFileds, cols, dtSrc);
        }
    }
}
