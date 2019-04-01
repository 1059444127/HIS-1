using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TszyHIS;

namespace ts_zyhs_fyxx
{
    /// <summary>
    /// ���ݴ�ӡ ��ժҪ˵����
    /// </summary>
    public class frmFYXX : System.Windows.Forms.Form
    {
        //�Զ������
        private BaseFunc myFunc;
        bool isSSMZ = false;
        int _isAll = 0;//0=NO1=YES
        /// <summary>
        /// �����嵥�Ƿ���ʾҽ���ֽ�֧����
        /// </summary>
        private SystemCfg cfg7156 = new SystemCfg(7156);
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpEndDate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button bt�˳�;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rbKind1;
        private System.Windows.Forms.RadioButton rbKind2;
        private System.Windows.Forms.RadioButton rbDate1;
        private System.Windows.Forms.RadioButton rbDate2;
        private System.Windows.Forms.RadioButton rbDate3;
        private System.Windows.Forms.RadioButton rbDept1;
        private System.Windows.Forms.RadioButton rbDept2;
        private System.Windows.Forms.Button bt��ӡ�����嵥;
        private System.Windows.Forms.Button bt��ӡ�߿;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbDate4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private DataGridEx myDataGrid2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbFL1;
        private System.Windows.Forms.RadioButton rbFL4;
        private System.Windows.Forms.RadioButton rbFL3;
        private System.Windows.Forms.RadioButton rbFL2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private TheReportDateSet rds = new TheReportDateSet();
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoUnCharge;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoCharge;
        private Button btFYHZ;
        private GroupBox groupBox6;
        private RadioButton rbKdQtks;
        private RadioButton rbKdAll;
        private RadioButton rbKdBks;
        private RadioButton rbDept3;
        private DataRow dr;
        private GroupBox groupBox7;
        private RadioButton rbBrQtks;
        private RadioButton rbBrAll;
        private RadioButton rbBrBks;
        private GroupBox groupBox8;
        private RadioButton rbCzflag2;
        private RadioButton radioButton4;
        private RadioButton rbCzflag01;
        private RadioButton radioButton6;
        private RadioButton rbCzflagAll;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ��ӡ�Ը����õ�ToolStripMenuItem;
        private CheckBox chkZrdy;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem �߿����ToolStripMenuItem;
        private CheckBox checkyl;
        private DataTable TbZfbl;
        private Panel panel7;
        private Button btSx;
        private CheckBox chkHbmy;
        private Button btȫѡ1;
        private Button bt��ѡ1;
        private ComboBox cmbWard;
        private CheckBox cb��ʾ���;
        private Button btXzqfbr;
        private CheckBox chkSeekZyh;
        private Button btSeekPat;
        private InpatientNoTextBox txtZyh;
        private Button bt��ӡ��������;
        private Button btnSeek;
        private Panel panel6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RadioButton rBall;//�Ը�����
        private SystemCfg cfg7140;
        public frmFYXX(string _formText)
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

            chkHbmy.Visible = true;//Modify by tany 2011-03-07
        }

        public frmFYXX(string _formText, bool _isSSMZ)
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

            isSSMZ = _isSSMZ;

            chkHbmy.Visible = false;//Modify by tany 2011-03-07
            //Modify by zouchihua 2011-10-26
            rbDate3.Checked = true;
            rbKind1.Checked = true;
            rbKdBks.Checked = true;
            rdoAll.Checked = true;
            dtpBeginDate.Enabled = false;
        }

        public frmFYXX(string _formText, int _isALL)
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

            _isAll = _isALL;

            chkHbmy.Visible = false;//Modify by tany 2011-03-07
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkyl = new System.Windows.Forms.CheckBox();
            this.chkZrdy = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbCzflag2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.rbCzflag01 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.rbCzflagAll = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbBrQtks = new System.Windows.Forms.RadioButton();
            this.rbBrAll = new System.Windows.Forms.RadioButton();
            this.rbBrBks = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbKdQtks = new System.Windows.Forms.RadioButton();
            this.rbKdAll = new System.Windows.Forms.RadioButton();
            this.rbKdBks = new System.Windows.Forms.RadioButton();
            this.btFYHZ = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.myDataGrid2 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFL2 = new System.Windows.Forms.RadioButton();
            this.rbFL3 = new System.Windows.Forms.RadioButton();
            this.rbFL4 = new System.Windows.Forms.RadioButton();
            this.rbFL1 = new System.Windows.Forms.RadioButton();
            this.bt��ӡ�߿ = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.�߿����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt��ӡ�����嵥 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.��ӡ�Ը����õ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbKind1 = new System.Windows.Forms.RadioButton();
            this.rbKind2 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbDept3 = new System.Windows.Forms.RadioButton();
            this.rbDept1 = new System.Windows.Forms.RadioButton();
            this.rbDept2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDate4 = new System.Windows.Forms.RadioButton();
            this.rbDate3 = new System.Windows.Forms.RadioButton();
            this.rbDate2 = new System.Windows.Forms.RadioButton();
            this.rbDate1 = new System.Windows.Forms.RadioButton();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoCharge = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoUnCharge = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btSx = new System.Windows.Forms.Button();
            this.chkHbmy = new System.Windows.Forms.CheckBox();
            this.btȫѡ1 = new System.Windows.Forms.Button();
            this.bt��ѡ1 = new System.Windows.Forms.Button();
            this.cmbWard = new System.Windows.Forms.ComboBox();
            this.cb��ʾ��� = new System.Windows.Forms.CheckBox();
            this.btXzqfbr = new System.Windows.Forms.Button();
            this.chkSeekZyh = new System.Windows.Forms.CheckBox();
            this.btSeekPat = new System.Windows.Forms.Button();
            this.txtZyh = new TrasenClasses.GeneralControls.InpatientNoTextBox(this.components);
            this.bt��ӡ�������� = new System.Windows.Forms.Button();
            this.btnSeek = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rBall = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkyl);
            this.panel1.Controls.Add(this.chkZrdy);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.btFYHZ);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.bt��ӡ�߿);
            this.panel1.Controls.Add(this.bt��ӡ�����嵥);
            this.panel1.Controls.Add(this.bt�˳�);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(798, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 719);
            this.panel1.TabIndex = 5;
            // 
            // checkyl
            // 
            this.checkyl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkyl.AutoSize = true;
            this.checkyl.Checked = true;
            this.checkyl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkyl.Location = new System.Drawing.Point(18, 640);
            this.checkyl.Name = "checkyl";
            this.checkyl.Size = new System.Drawing.Size(48, 16);
            this.checkyl.TabIndex = 51;
            this.checkyl.Text = "Ԥ��";
            this.checkyl.UseVisualStyleBackColor = true;
            this.checkyl.Visible = false;
            // 
            // chkZrdy
            // 
            this.chkZrdy.AutoSize = true;
            this.chkZrdy.Enabled = false;
            this.chkZrdy.Location = new System.Drawing.Point(72, 5);
            this.chkZrdy.Name = "chkZrdy";
            this.chkZrdy.Size = new System.Drawing.Size(72, 16);
            this.chkZrdy.TabIndex = 11;
            this.chkZrdy.Text = "���մ�ӡ";
            this.chkZrdy.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.rbCzflag2);
            this.groupBox8.Controls.Add(this.radioButton4);
            this.groupBox8.Controls.Add(this.rbCzflag01);
            this.groupBox8.Controls.Add(this.radioButton6);
            this.groupBox8.Controls.Add(this.rbCzflagAll);
            this.groupBox8.Location = new System.Drawing.Point(8, 403);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 40);
            this.groupBox8.TabIndex = 50;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "����״̬";
            // 
            // rbCzflag2
            // 
            this.rbCzflag2.Location = new System.Drawing.Point(128, 16);
            this.rbCzflag2.Name = "rbCzflag2";
            this.rbCzflag2.Size = new System.Drawing.Size(64, 16);
            this.rbCzflag2.TabIndex = 8;
            this.rbCzflag2.Text = "����¼";
            this.rbCzflag2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radioButton4
            // 
            this.radioButton4.Enabled = false;
            this.radioButton4.Location = new System.Drawing.Point(8, 40);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(88, 16);
            this.radioButton4.TabIndex = 7;
            this.radioButton4.Text = "���嵥����";
            this.radioButton4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton4.Visible = false;
            // 
            // rbCzflag01
            // 
            this.rbCzflag01.Location = new System.Drawing.Point(64, 16);
            this.rbCzflag01.Name = "rbCzflag01";
            this.rbCzflag01.Size = new System.Drawing.Size(64, 16);
            this.rbCzflag01.TabIndex = 6;
            this.rbCzflag01.Text = "����¼";
            this.rbCzflag01.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radioButton6
            // 
            this.radioButton6.Enabled = false;
            this.radioButton6.Location = new System.Drawing.Point(104, 40);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(88, 16);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "���������";
            this.radioButton6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton6.Visible = false;
            // 
            // rbCzflagAll
            // 
            this.rbCzflagAll.Checked = true;
            this.rbCzflagAll.Location = new System.Drawing.Point(8, 16);
            this.rbCzflagAll.Name = "rbCzflagAll";
            this.rbCzflagAll.Size = new System.Drawing.Size(48, 16);
            this.rbCzflagAll.TabIndex = 4;
            this.rbCzflagAll.TabStop = true;
            this.rbCzflagAll.Text = "ȫ��";
            this.rbCzflagAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.rbBrQtks);
            this.groupBox7.Controls.Add(this.rbBrAll);
            this.groupBox7.Controls.Add(this.rbBrBks);
            this.groupBox7.Location = new System.Drawing.Point(8, 177);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 40);
            this.groupBox7.TabIndex = 49;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "���˿���";
            // 
            // rbBrQtks
            // 
            this.rbBrQtks.Location = new System.Drawing.Point(120, 16);
            this.rbBrQtks.Name = "rbBrQtks";
            this.rbBrQtks.Size = new System.Drawing.Size(72, 16);
            this.rbBrQtks.TabIndex = 4;
            this.rbBrQtks.Text = "��������";
            this.rbBrQtks.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbBrAll
            // 
            this.rbBrAll.Checked = true;
            this.rbBrAll.Location = new System.Drawing.Point(8, 16);
            this.rbBrAll.Name = "rbBrAll";
            this.rbBrAll.Size = new System.Drawing.Size(48, 16);
            this.rbBrAll.TabIndex = 3;
            this.rbBrAll.TabStop = true;
            this.rbBrAll.Text = "����";
            this.rbBrAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbBrBks
            // 
            this.rbBrBks.Location = new System.Drawing.Point(58, 16);
            this.rbBrBks.Name = "rbBrBks";
            this.rbBrBks.Size = new System.Drawing.Size(64, 16);
            this.rbBrBks.TabIndex = 2;
            this.rbBrBks.Text = "������";
            this.rbBrBks.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.rbKdQtks);
            this.groupBox6.Controls.Add(this.rbKdAll);
            this.groupBox6.Controls.Add(this.rbKdBks);
            this.groupBox6.Location = new System.Drawing.Point(8, 222);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 40);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "��������";
            // 
            // rbKdQtks
            // 
            this.rbKdQtks.Location = new System.Drawing.Point(120, 16);
            this.rbKdQtks.Name = "rbKdQtks";
            this.rbKdQtks.Size = new System.Drawing.Size(72, 16);
            this.rbKdQtks.TabIndex = 4;
            this.rbKdQtks.Text = "��������";
            this.rbKdQtks.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbKdAll
            // 
            this.rbKdAll.Checked = true;
            this.rbKdAll.Location = new System.Drawing.Point(8, 16);
            this.rbKdAll.Name = "rbKdAll";
            this.rbKdAll.Size = new System.Drawing.Size(48, 16);
            this.rbKdAll.TabIndex = 3;
            this.rbKdAll.TabStop = true;
            this.rbKdAll.Text = "����";
            this.rbKdAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbKdBks
            // 
            this.rbKdBks.Location = new System.Drawing.Point(58, 16);
            this.rbKdBks.Name = "rbKdBks";
            this.rbKdBks.Size = new System.Drawing.Size(64, 16);
            this.rbKdBks.TabIndex = 2;
            this.rbKdBks.Text = "������";
            this.rbKdBks.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btFYHZ
            // 
            this.btFYHZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btFYHZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFYHZ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btFYHZ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btFYHZ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFYHZ.ImageIndex = 4;
            this.btFYHZ.Location = new System.Drawing.Point(16, 684);
            this.btFYHZ.Name = "btFYHZ";
            this.btFYHZ.Size = new System.Drawing.Size(88, 24);
            this.btFYHZ.TabIndex = 48;
            this.btFYHZ.Text = "���û���(&H)";
            this.toolTip1.SetToolTip(this.btFYHZ, "���û��ܲ�ѯ���ǲ��˵�ǰ���з��ã�����������������");
            this.btFYHZ.Click += new System.EventHandler(this.btFYHZ_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.myDataGrid2);
            this.panel3.Location = new System.Drawing.Point(8, 449);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 181);
            this.panel3.TabIndex = 46;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGreen;
            this.button2.Location = new System.Drawing.Point(128, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 20);
            this.button2.TabIndex = 86;
            this.button2.Text = "��ѡ(&P)";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.bt��ѡ2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Location = new System.Drawing.Point(64, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 20);
            this.button1.TabIndex = 85;
            this.button1.Text = "ȫѡ(&Q)";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btȫѡ2_Click);
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.AllowSorting = false;
            this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid2.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid2.CaptionText = "���";
            this.myDataGrid2.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.ReadOnly = true;
            this.myDataGrid2.Size = new System.Drawing.Size(200, 181);
            this.myDataGrid2.TabIndex = 11;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid2.Click += new System.EventHandler(this.myDataGrid2_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbFL2);
            this.groupBox1.Controls.Add(this.rbFL3);
            this.groupBox1.Controls.Add(this.rbFL4);
            this.groupBox1.Controls.Add(this.rbFL1);
            this.groupBox1.Location = new System.Drawing.Point(8, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 40);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "����С��";
            // 
            // rbFL2
            // 
            this.rbFL2.Enabled = false;
            this.rbFL2.Location = new System.Drawing.Point(8, 40);
            this.rbFL2.Name = "rbFL2";
            this.rbFL2.Size = new System.Drawing.Size(88, 16);
            this.rbFL2.TabIndex = 7;
            this.rbFL2.Text = "���嵥����";
            this.rbFL2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbFL2.Visible = false;
            this.rbFL2.Click += new System.EventHandler(this.rbFL1_Click);
            // 
            // rbFL3
            // 
            this.rbFL3.Checked = true;
            this.rbFL3.Location = new System.Drawing.Point(104, 16);
            this.rbFL3.Name = "rbFL3";
            this.rbFL3.Size = new System.Drawing.Size(88, 16);
            this.rbFL3.TabIndex = 6;
            this.rbFL3.TabStop = true;
            this.rbFL3.Text = "����Ʊ����";
            this.rbFL3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbFL3.Click += new System.EventHandler(this.rbFL1_Click);
            // 
            // rbFL4
            // 
            this.rbFL4.Enabled = false;
            this.rbFL4.Location = new System.Drawing.Point(104, 40);
            this.rbFL4.Name = "rbFL4";
            this.rbFL4.Size = new System.Drawing.Size(88, 16);
            this.rbFL4.TabIndex = 5;
            this.rbFL4.Text = "���������";
            this.rbFL4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbFL4.Visible = false;
            this.rbFL4.Click += new System.EventHandler(this.rbFL1_Click);
            // 
            // rbFL1
            // 
            this.rbFL1.Location = new System.Drawing.Point(8, 16);
            this.rbFL1.Name = "rbFL1";
            this.rbFL1.Size = new System.Drawing.Size(88, 16);
            this.rbFL1.TabIndex = 4;
            this.rbFL1.Text = "������";
            this.rbFL1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbFL1.Click += new System.EventHandler(this.rbFL1_Click);
            // 
            // bt��ӡ�߿
            // 
            this.bt��ӡ�߿.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ӡ�߿.ContextMenuStrip = this.contextMenuStrip2;
            this.bt��ӡ�߿.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt��ӡ�߿.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ӡ�߿.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt��ӡ�߿.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt��ӡ�߿.ImageIndex = 4;
            this.bt��ӡ�߿.Location = new System.Drawing.Point(112, 657);
            this.bt��ӡ�߿.Name = "bt��ӡ�߿";
            this.bt��ӡ�߿.Size = new System.Drawing.Size(88, 24);
            this.bt��ӡ�߿.TabIndex = 44;
            this.bt��ӡ�߿.Text = "�߿(&C)";
            this.bt��ӡ�߿.Click += new System.EventHandler(this.bt��ӡ�߿_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�߿����ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(131, 26);
            // 
            // �߿����ToolStripMenuItem
            // 
            this.�߿����ToolStripMenuItem.Name = "�߿����ToolStripMenuItem";
            this.�߿����ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.�߿����ToolStripMenuItem.Text = "�߿����";
            this.�߿����ToolStripMenuItem.Click += new System.EventHandler(this.�߿����ToolStripMenuItem_Click);
            // 
            // bt��ӡ�����嵥
            // 
            this.bt��ӡ�����嵥.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ӡ�����嵥.ContextMenuStrip = this.contextMenuStrip1;
            this.bt��ӡ�����嵥.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt��ӡ�����嵥.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ӡ�����嵥.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt��ӡ�����嵥.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt��ӡ�����嵥.ImageIndex = 4;
            this.bt��ӡ�����嵥.Location = new System.Drawing.Point(16, 658);
            this.bt��ӡ�����嵥.Name = "bt��ӡ�����嵥";
            this.bt��ӡ�����嵥.Size = new System.Drawing.Size(88, 24);
            this.bt��ӡ�����嵥.TabIndex = 43;
            this.bt��ӡ�����嵥.Text = "�����嵥(&F)";
            this.bt��ӡ�����嵥.Click += new System.EventHandler(this.bt��ӡ�����嵥_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ӡ�Ը����õ�ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // ��ӡ�Ը����õ�ToolStripMenuItem
            // 
            this.��ӡ�Ը����õ�ToolStripMenuItem.Name = "��ӡ�Ը����õ�ToolStripMenuItem";
            this.��ӡ�Ը����õ�ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.��ӡ�Ը����õ�ToolStripMenuItem.Text = "��ӡ�Ը����õ�";
            this.��ӡ�Ը����õ�ToolStripMenuItem.Click += new System.EventHandler(this.��ӡ�Ը����õ�ToolStripMenuItem_Click);
            // 
            // bt�˳�
            // 
            this.bt�˳�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(112, 683);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(88, 24);
            this.bt�˳�.TabIndex = 40;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.rbKind1);
            this.groupBox5.Controls.Add(this.rbKind2);
            this.groupBox5.Location = new System.Drawing.Point(8, 132);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 40);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ѡ�����";
            // 
            // rbKind1
            // 
            this.rbKind1.Location = new System.Drawing.Point(8, 16);
            this.rbKind1.Name = "rbKind1";
            this.rbKind1.Size = new System.Drawing.Size(72, 16);
            this.rbKind1.TabIndex = 1;
            this.rbKind1.Text = "��Ŀ����";
            this.rbKind1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbKind2
            // 
            this.rbKind2.Checked = true;
            this.rbKind2.Location = new System.Drawing.Point(104, 16);
            this.rbKind2.Name = "rbKind2";
            this.rbKind2.Size = new System.Drawing.Size(72, 16);
            this.rbKind2.TabIndex = 0;
            this.rbKind2.TabStop = true;
            this.rbKind2.Text = "��Ŀ��ϸ";
            this.rbKind2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rbDept3);
            this.groupBox3.Controls.Add(this.rbDept1);
            this.groupBox3.Controls.Add(this.rbDept2);
            this.groupBox3.Location = new System.Drawing.Point(8, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 40);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ִ�п���";
            // 
            // rbDept3
            // 
            this.rbDept3.Location = new System.Drawing.Point(120, 16);
            this.rbDept3.Name = "rbDept3";
            this.rbDept3.Size = new System.Drawing.Size(72, 16);
            this.rbDept3.TabIndex = 4;
            this.rbDept3.Text = "��������";
            this.rbDept3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbDept1
            // 
            this.rbDept1.Checked = true;
            this.rbDept1.Location = new System.Drawing.Point(8, 16);
            this.rbDept1.Name = "rbDept1";
            this.rbDept1.Size = new System.Drawing.Size(48, 16);
            this.rbDept1.TabIndex = 3;
            this.rbDept1.TabStop = true;
            this.rbDept1.Text = "����";
            this.rbDept1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbDept2
            // 
            this.rbDept2.Location = new System.Drawing.Point(58, 16);
            this.rbDept2.Name = "rbDept2";
            this.rbDept2.Size = new System.Drawing.Size(64, 16);
            this.rbDept2.TabIndex = 2;
            this.rbDept2.Text = "������";
            this.rbDept2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rBall);
            this.groupBox2.Controls.Add(this.rbDate4);
            this.groupBox2.Controls.Add(this.rbDate3);
            this.groupBox2.Controls.Add(this.rbDate2);
            this.groupBox2.Controls.Add(this.rbDate1);
            this.groupBox2.Controls.Add(this.dtpBeginDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.DtpEndDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 118);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ѡ������";
            // 
            // rbDate4
            // 
            this.rbDate4.Location = new System.Drawing.Point(64, 16);
            this.rbDate4.Name = "rbDate4";
            this.rbDate4.Size = new System.Drawing.Size(112, 16);
            this.rbDate4.TabIndex = 10;
            this.rbDate4.Text = "����δ���˷���";
            this.rbDate4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbDate4.Click += new System.EventHandler(this.rbDate1_Click);
            // 
            // rbDate3
            // 
            this.rbDate3.Location = new System.Drawing.Point(64, 40);
            this.rbDate3.Name = "rbDate3";
            this.rbDate3.Size = new System.Drawing.Size(104, 16);
            this.rbDate3.TabIndex = 9;
            this.rbDate3.Text = "���м��˷���";
            this.rbDate3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbDate3.Click += new System.EventHandler(this.rbDate1_Click);
            // 
            // rbDate2
            // 
            this.rbDate2.Location = new System.Drawing.Point(8, 40);
            this.rbDate2.Name = "rbDate2";
            this.rbDate2.Size = new System.Drawing.Size(56, 16);
            this.rbDate2.TabIndex = 8;
            this.rbDate2.Text = "����";
            this.rbDate2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbDate2.Click += new System.EventHandler(this.rbDate1_Click);
            // 
            // rbDate1
            // 
            this.rbDate1.Checked = true;
            this.rbDate1.Location = new System.Drawing.Point(8, 16);
            this.rbDate1.Name = "rbDate1";
            this.rbDate1.Size = new System.Drawing.Size(48, 16);
            this.rbDate1.TabIndex = 7;
            this.rbDate1.TabStop = true;
            this.rbDate1.Text = "һ��";
            this.rbDate1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbDate1.Click += new System.EventHandler(this.rbDate1_Click);
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginDate.Location = new System.Drawing.Point(41, 62);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.ShowUpDown = true;
            this.dtpBeginDate.Size = new System.Drawing.Size(143, 21);
            this.dtpBeginDate.TabIndex = 6;
            this.dtpBeginDate.Value = new System.DateTime(2007, 9, 27, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "�ӣ�";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpEndDate.Enabled = false;
            this.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEndDate.Location = new System.Drawing.Point(41, 89);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.ShowUpDown = true;
            this.DtpEndDate.Size = new System.Drawing.Size(143, 21);
            this.DtpEndDate.TabIndex = 3;
            this.DtpEndDate.Value = new System.DateTime(2007, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "����";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.Location = new System.Drawing.Point(8, 636);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 74);
            this.button4.TabIndex = 41;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.ContextMenu = this.contextMenu1;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 4;
            this.button3.Location = new System.Drawing.Point(40, 654);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(8, 8);
            this.button3.TabIndex = 47;
            this.button3.Text = "������(&M)";
            this.toolTip1.SetToolTip(this.button3, "��ѡ������ʱʹ�ö���");
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "��ӡ";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Ԥ��";
            this.menuItem2.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rdoCharge);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.rdoUnCharge);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.rdoAll);
            this.groupBox4.Location = new System.Drawing.Point(8, 357);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 40);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "����״̬";
            // 
            // rdoCharge
            // 
            this.rdoCharge.Location = new System.Drawing.Point(128, 16);
            this.rdoCharge.Name = "rdoCharge";
            this.rdoCharge.Size = new System.Drawing.Size(64, 16);
            this.rdoCharge.TabIndex = 8;
            this.rdoCharge.Text = "�ѽ���";
            this.rdoCharge.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radioButton1
            // 
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(8, 40);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.Text = "���嵥����";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton1.Visible = false;
            // 
            // rdoUnCharge
            // 
            this.rdoUnCharge.Checked = true;
            this.rdoUnCharge.Location = new System.Drawing.Point(64, 16);
            this.rdoUnCharge.Name = "rdoUnCharge";
            this.rdoUnCharge.Size = new System.Drawing.Size(64, 16);
            this.rdoUnCharge.TabIndex = 6;
            this.rdoUnCharge.TabStop = true;
            this.rdoUnCharge.Text = "δ����";
            this.rdoUnCharge.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radioButton3
            // 
            this.radioButton3.Enabled = false;
            this.radioButton3.Location = new System.Drawing.Point(104, 40);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(88, 16);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "���������";
            this.radioButton3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButton3.Visible = false;
            // 
            // rdoAll
            // 
            this.rdoAll.Location = new System.Drawing.Point(8, 16);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(48, 16);
            this.rdoAll.TabIndex = 4;
            this.rdoAll.Text = "ȫ��";
            this.rdoAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(8, 8);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(782, 8);
            this.progressBar1.TabIndex = 7;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(8, 24);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(782, 8);
            this.progressBar2.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 679);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btSx);
            this.panel7.Controls.Add(this.chkHbmy);
            this.panel7.Controls.Add(this.btȫѡ1);
            this.panel7.Controls.Add(this.bt��ѡ1);
            this.panel7.Controls.Add(this.cmbWard);
            this.panel7.Controls.Add(this.cb��ʾ���);
            this.panel7.Controls.Add(this.btXzqfbr);
            this.panel7.Controls.Add(this.chkSeekZyh);
            this.panel7.Controls.Add(this.btSeekPat);
            this.panel7.Controls.Add(this.txtZyh);
            this.panel7.Controls.Add(this.bt��ӡ��������);
            this.panel7.Controls.Add(this.btnSeek);
            this.panel7.Controls.Add(this.myDataGrid1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(798, 659);
            this.panel7.TabIndex = 96;
            // 
            // btSx
            // 
            this.btSx.BackColor = System.Drawing.Color.PaleGreen;
            this.btSx.Location = new System.Drawing.Point(413, 2);
            this.btSx.Name = "btSx";
            this.btSx.Size = new System.Drawing.Size(39, 20);
            this.btSx.TabIndex = 105;
            this.btSx.Text = "ˢ��";
            this.btSx.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSx.UseVisualStyleBackColor = false;
            this.btSx.Click += new System.EventHandler(this.btSx_Click);
            // 
            // chkHbmy
            // 
            this.chkHbmy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHbmy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.chkHbmy.Location = new System.Drawing.Point(468, 4);
            this.chkHbmy.Name = "chkHbmy";
            this.chkHbmy.Size = new System.Drawing.Size(73, 16);
            this.chkHbmy.TabIndex = 106;
            this.chkHbmy.Text = "�ϲ�ĸӤ";
            this.chkHbmy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkHbmy.UseVisualStyleBackColor = false;
            this.chkHbmy.Visible = false;
            this.chkHbmy.CheckedChanged += new System.EventHandler(this.cb��ʾ���_CheckedChanged);
            // 
            // btȫѡ1
            // 
            this.btȫѡ1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btȫѡ1.BackColor = System.Drawing.Color.PaleGreen;
            this.btȫѡ1.Location = new System.Drawing.Point(688, 2);
            this.btȫѡ1.Name = "btȫѡ1";
            this.btȫѡ1.Size = new System.Drawing.Size(56, 20);
            this.btȫѡ1.TabIndex = 96;
            this.btȫѡ1.Text = "ȫѡ(&A)";
            this.btȫѡ1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btȫѡ1.UseVisualStyleBackColor = false;
            this.btȫѡ1.Click += new System.EventHandler(this.btȫѡ1_Click);
            // 
            // bt��ѡ1
            // 
            this.bt��ѡ1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ѡ1.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ѡ1.Location = new System.Drawing.Point(744, 2);
            this.bt��ѡ1.Name = "bt��ѡ1";
            this.bt��ѡ1.Size = new System.Drawing.Size(56, 20);
            this.bt��ѡ1.TabIndex = 97;
            this.bt��ѡ1.Text = "��ѡ(&F)";
            this.bt��ѡ1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ѡ1.UseVisualStyleBackColor = false;
            this.bt��ѡ1.Click += new System.EventHandler(this.bt��ѡ1_Click);
            // 
            // cmbWard
            // 
            this.cmbWard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWard.DropDownWidth = 100;
            this.cmbWard.FormattingEnabled = true;
            this.cmbWard.Location = new System.Drawing.Point(342, 2);
            this.cmbWard.Name = "cmbWard";
            this.cmbWard.Size = new System.Drawing.Size(69, 20);
            this.cmbWard.TabIndex = 104;
            // 
            // cb��ʾ���
            // 
            this.cb��ʾ���.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb��ʾ���.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cb��ʾ���.Checked = true;
            this.cb��ʾ���.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb��ʾ���.Location = new System.Drawing.Point(468, 4);
            this.cb��ʾ���.Name = "cb��ʾ���";
            this.cb��ʾ���.Size = new System.Drawing.Size(73, 16);
            this.cb��ʾ���.TabIndex = 98;
            this.cb��ʾ���.Text = "��ʾ���";
            this.cb��ʾ���.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb��ʾ���.UseVisualStyleBackColor = false;
            this.cb��ʾ���.Visible = false;
            // 
            // btXzqfbr
            // 
            this.btXzqfbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btXzqfbr.BackColor = System.Drawing.Color.PaleGreen;
            this.btXzqfbr.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btXzqfbr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btXzqfbr.ImageIndex = 4;
            this.btXzqfbr.Location = new System.Drawing.Point(623, 2);
            this.btXzqfbr.Name = "btXzqfbr";
            this.btXzqfbr.Size = new System.Drawing.Size(65, 20);
            this.btXzqfbr.TabIndex = 103;
            this.btXzqfbr.Text = "ѡ��Ƿ��";
            this.btXzqfbr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btXzqfbr.UseVisualStyleBackColor = false;
            this.btXzqfbr.Click += new System.EventHandler(this.btXzqfbr_Click);
            // 
            // chkSeekZyh
            // 
            this.chkSeekZyh.BackColor = System.Drawing.Color.PaleTurquoise;
            this.chkSeekZyh.Location = new System.Drawing.Point(51, 4);
            this.chkSeekZyh.Name = "chkSeekZyh";
            this.chkSeekZyh.Size = new System.Drawing.Size(88, 16);
            this.chkSeekZyh.TabIndex = 99;
            this.chkSeekZyh.Text = "����סԺ��";
            this.chkSeekZyh.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSeekZyh.UseVisualStyleBackColor = false;
            this.chkSeekZyh.CheckedChanged += new System.EventHandler(this.chkSeekZyh_Click);
            // 
            // btSeekPat
            // 
            this.btSeekPat.BackColor = System.Drawing.Color.PaleGreen;
            this.btSeekPat.Enabled = false;
            this.btSeekPat.Location = new System.Drawing.Point(276, 2);
            this.btSeekPat.Name = "btSeekPat";
            this.btSeekPat.Size = new System.Drawing.Size(64, 20);
            this.btSeekPat.TabIndex = 102;
            this.btSeekPat.Text = "��ѯ����";
            this.btSeekPat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSeekPat.UseVisualStyleBackColor = false;
            this.btSeekPat.Click += new System.EventHandler(this.btSeekPat_Click);
            // 
            // txtZyh
            // 
            this.txtZyh.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtZyh.Enabled = false;
            this.txtZyh.EnabledFalseBackColor = System.Drawing.SystemColors.Control;
            this.txtZyh.EnabledRightKey = true;
            this.txtZyh.EnabledTrueBackColor = System.Drawing.SystemColors.Window;
            this.txtZyh.EnterBackColor = System.Drawing.SystemColors.Window;
            this.txtZyh.EnterForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZyh.Location = new System.Drawing.Point(136, 1);
            this.txtZyh.Name = "txtZyh";
            this.txtZyh.NextControl = null;
            this.txtZyh.PreviousControl = null;
            this.txtZyh.Size = new System.Drawing.Size(92, 21);
            this.txtZyh.TabIndex = 100;
            // 
            // bt��ӡ��������
            // 
            this.bt��ӡ��������.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ӡ��������.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ӡ��������.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ӡ��������.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt��ӡ��������.ImageIndex = 4;
            this.bt��ӡ��������.Location = new System.Drawing.Point(542, 2);
            this.bt��ӡ��������.Name = "bt��ӡ��������";
            this.bt��ӡ��������.Size = new System.Drawing.Size(81, 20);
            this.bt��ӡ��������.TabIndex = 95;
            this.bt��ӡ��������.Text = "��������(&G)";
            this.bt��ӡ��������.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ӡ��������.UseVisualStyleBackColor = false;
            this.bt��ӡ��������.Click += new System.EventHandler(this.bt��ӡ��������_Click);
            // 
            // btnSeek
            // 
            this.btnSeek.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSeek.Enabled = false;
            this.btnSeek.Location = new System.Drawing.Point(228, 2);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(48, 20);
            this.btnSeek.TabIndex = 101;
            this.btnSeek.Text = "����";
            this.btnSeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "�����б�";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(798, 659);
            this.myDataGrid1.TabIndex = 10;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(798, 20);
            this.panel6.TabIndex = 95;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 20);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "������";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ת�Ʋ���";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.progressBar2);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 679);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 40);
            this.panel4.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1014, 719);
            this.panel5.TabIndex = 12;
            // 
            // rBall
            // 
            this.rBall.AutoSize = true;
            this.rBall.Location = new System.Drawing.Point(156, 40);
            this.rBall.Name = "rBall";
            this.rBall.Size = new System.Drawing.Size(47, 16);
            this.rBall.TabIndex = 11;
            this.rBall.TabStop = true;
            this.rBall.Text = "����";
            this.rBall.UseVisualStyleBackColor = true;
            // 
            // frmFYXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1014, 719);
            this.Controls.Add(this.panel5);
            this.Name = "frmFYXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���ò�ѯ��ӡ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFYXX_Load);
            this.Activated += new System.EventHandler(this.frmDJDY_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmDJDY_Load(object sender, System.EventArgs e)
        {
            int zxzf = 0;
            if (cfg7156.Config.Trim() == "1")
                zxzf = 8;
            //��������ҵĲ�����Ϣ        8��4                                                                                 //���ӽ����ܷ�����ʾ add by zouchihua 2013-4-22                                        16
           // string[] GrdMappingName1 ={ "ѡ", "����", "סԺ��", "����", "�Ա�", "����", "��������", "��Ժ����", "��������", 
            //"ҽ������", "�ѽ����ܷ���", "δ�����ܷ���", "Ԥ����", "δ����֧Ʊ", "�����޶�", "�������","�ֽ�֧��" ,"���",
            //"���ɿ�", "�ϴδ߿�����", "��������", "��������", "��������", "inpatient_id", "baby_id", "�ܴ�ҽ��" };
           // int[] GrdWidth1 ={ 2, 4, 9, 8, 4, 4, 10, 10, 8, 8, 10, 10, 8, 0, 8, 8, zxzf, 8, 6, 10, 8, 8, 8, 0, 0, 8 };
           // int[] Alignment1 ={ 0, 0, 0, 0, 1, 2,0,0, 1, 1,0, 2, 2, 1, 2, 2, 2,2, 1, 1, 1, 1, 0, 0, 0,0 };
          //  int[] ReadOnly1 ={ 0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 1, 0, 0, 0, 0, 0, 0 ,0};

            string[] GrdMappingName1 ={ "ѡ", "����", "סԺ��", "����", "�Ա�", "����", "��������", "��Ժ����", "��������", 
                "ҽ������", "�ѽ����ܷ���", "δ�����ܷ���", "Ԥ����", "���", "δ����֧Ʊ", "�����޶�", "�������", "�ֽ�֧��",
                "���ɿ�", "�ϴδ߿�����", "��������", "��������", "��������", "inpatient_id", "baby_id", "�ܴ�ҽ��" };
            int[] GrdWidth1 ={ 2, 5, 9, 8, 4, 4, 10, 10, 8, 8, 10, 10, 8, 8, 0, 8, 8, zxzf, 6, 10, 8, 8, 8, 0, 0, 8 };
            int[] Alignment1={ 0, 0, 0, 0, 1, 2, 0,  0,  1, 1,  0,  2, 2, 2, 2, 2, 2, 2,    2,  1, 1,  1, 1, 0, 0, 0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
           
            myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            //������
            string[] GrdMappingName2 ={ "ѡ", "����", "����" };
            int[] GrdWidth2 ={ 2, 4, 16 };
            int[] Alignment2 ={ 0, 1, 0 };
            int[] ReadOnly2 ={ 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName2, GrdWidth2, Alignment2, ReadOnly2, this.myDataGrid2);

            Show_Data1();

            rbFL1_Click(null, null);
            //add by zouchihua 2013-6-26
            if (isSSMZ)
                this.tabControl1.Visible = false;
        }

        private void Show_Data1()
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            string sSql = "";
            if (isSSMZ)
            {
                if (this.cb��ʾ���.Checked)
                {
                    sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,1) δ�����ܷ���," +
                        " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=a.baby_id)  �ѽ����ܷ���," +//�Ѿ��������
                        " dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                        //" case �������� when 'ҽ��' then YBYE else dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) end ���, ''as ���ɿ�,"+
                        " DBJE �������,dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) ���, ''as ���ɿ�," +
                        "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��, �����޶�,flag ,ryts " +
                         " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                        "  from ( SELECT a.BED_NO ����,a.INPATIENT_NO סԺ��,a.NAME ����,a.SEX_NAME �Ա�,a.age ����, " +
                        "          a.CUR_DEPT_NAME ��������,a.JSFS_NAME ��������,a.BRLX_NAME ��������,a.in_date ��Ժ����,'' �ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,a.YBYE,a.DBJE " +
                        "         ,a.out_date ��Ժ����,a.yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,a.gzdw ������λ,a.social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��,YJJ_LIMIT �����޶�,a.flag ,a.ryts " +
                        "          FROM vi_zy_vInpatient_Bed a (nolock),ss_apprecord b (nolock),ss_arrrecord c (nolock) " +
                        "          where a.inpatient_id=b.inpatient_id and a.baby_id=0 and " +
                        "          b.sno=c.sno and b.inpatient_id=c.inpatient_id and b.apbj=1 and  c.bdelete=0 and c.wcbj=0 ) a " +
                        "  left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                        "                       FROM ZY_CK (nolock) " +
                        "                      GROUP BY INPATIENT_ID) as e " +
                        "  on a.INPATIENT_ID=e.INPATIENT_ID " +
                        "  order by a.dept_id,case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����//Modify by zouchihua 2012-12-20 ����������
                }
                else
                {
                    sSql = "select ���� ,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������," +
                        "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��, �����޶�,flag ,ryts " +
                          " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                        "   from (SELECT a.BED_NO ����,a.INPATIENT_NO סԺ��,a.NAME ����,a.SEX_NAME �Ա�,a.age ����, " +
                        "         a.CUR_DEPT_NAME ��������,a.JSFS_NAME ��������,a.BRLX_NAME ��������,xzlx_name ��������,dylx_name ��������,a.in_date ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID " +
                        "         ,a.out_date ��Ժ����,a.yblx_name ҽ������,a.gzdw ������λ,a.social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,a.flag ,a.ryts" +
                        "        FROM vi_zy_vInpatient_Bed a (nolock),ss_apprecord b (nolock),ss_arrrecord c (nolock) " +
                        "        where a.inpatient_id=b.inpatient_id  and a.baby_id=0 and " +
                        "        b.sno=c.sno and b.inpatient_id=c.inpatient_id and b.apbj=1 and  c.bdelete=0 and c.wcbj=0 ) a " +
                        "  order by a.dept_id,case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����//Modify by zouchihua 2012-12-20 ����������
                }
            }
            else
            {
                if (_isAll == 0)
                {
                    if (this.tabControl1.SelectedIndex == 0)
                    {
                        //add by zouchihua 2013-6-26 ԭ����
                        if (this.cb��ʾ���.Checked)
                        {
                            sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������, ��������, ��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id," + (chkHbmy.Checked ? 0 : 1) + ") δ�����ܷ���," +//Modify By tany 2011-03-07 �ϲ�ĸӤ
                                " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=" + (chkHbmy.Checked ? "0" : " a.baby_id ") + ")   �ѽ����ܷ���," +//�Ѿ��������
                                " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                                //" case �������� when 'ҽ��' then YBYE else dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) end ���, ''as ���ɿ�,"+
                                " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id," + (chkHbmy.Checked ? "-1" : "a.baby_id") + ") ���, ''as ���ɿ�," +
                                "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������, ��������, ��������,������λ,���֤,����,�ܴ�ҽ�� , �����޶�,flag ,ryts" +
                                  " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                                "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����," +
                                "         CUR_DEPT_NAME ��������,JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,'' �ϴδ߿�����,INPATIENT_ID,Baby_ID,DEPT_ID,YBYE,DBJE " +
                                "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                                "         FROM vi_zy_vInpatient_Bed (nolock) " +
                                "         WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "'" + (chkHbmy.Checked ? " and baby_id=0 " : "") + ") a " +//Modify By tany 2011-03-07
                                "   left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                                "                       FROM ZY_CK (nolock) " +
                                "                      GROUP BY INPATIENT_ID) as e " +
                                "   on a.INPATIENT_ID=e.INPATIENT_ID " +
                                "  order by case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����//Modify by zouchihua 2012-12-20 ����������
                        }
                        else
                        {
                            sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������, ��������, ��������," +
                                "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��,�����޶�,flag ,ryts" +
                                  " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                                "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����,CUR_DEPT_NAME ��������," +
                                "         JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                                "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��, YJJ_LIMIT �����޶�,flag ,ryts " +
                                "    FROM vi_zy_vInpatient_Bed (nolock) " +
                                "   WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "') a " +
                                "  order by case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����
                        }
                    }
                    else
                    {
                        //add by zouchihua 2013-6-26 ת�Ʋ���
                        if (this.cb��ʾ���.Checked)
                        {
                            sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������, ��������, ��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id," + (chkHbmy.Checked ? 0 : 1) + ") δ�����ܷ���," +//Modify By tany 2011-03-07 �ϲ�ĸӤ
                                " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=" + (chkHbmy.Checked ? "0" : " a.baby_id ") + ")   �ѽ����ܷ���," +//�Ѿ��������
                                " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                                //" case �������� when 'ҽ��' then YBYE else dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) end ���, ''as ���ɿ�,"+
                                " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id," + (chkHbmy.Checked ? "-1" : "a.baby_id") + ") ���, ''as ���ɿ�," +
                                "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������, ��������, ��������,������λ,���֤,����,�ܴ�ҽ�� , �����޶�,flag ,ryts" +
                                  " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                                "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����," +
                                "         CUR_DEPT_NAME ��������,JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,'' �ϴδ߿�����,INPATIENT_ID,Baby_ID,DEPT_ID,YBYE,DBJE " +
                                "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                                "         FROM vi_zy_vInpatient_all (nolock) " +
                                "         WHERE flag in(1,3,4,5)  and  inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))   "
                                + (chkHbmy.Checked ? " and baby_id=0 " : "") + ") a " +//Modify By tany 2011-03-07
                                "   left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                                "                       FROM ZY_CK (nolock) " +
                                "                      GROUP BY INPATIENT_ID) as e " +
                                "   on a.INPATIENT_ID=e.INPATIENT_ID " +
                                "  order by case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����//Modify by zouchihua 2012-12-20 ����������
                        }
                        else
                        {
                            sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������, ��������, ��������," +
                                "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��,�����޶�,flag ,ryts" +
                                  " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                                "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����,CUR_DEPT_NAME ��������," +
                                "         JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                                "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��, YJJ_LIMIT �����޶�,flag ,ryts " +
                                "    FROM vi_zy_vInpatient_all (nolock) " +
                                "   WHERE  flag in(1,3,4,5)  and  inpatient_id in (select inpatient_id from zy_transfer_dept where cancel_bit=0 and finish_bit=1 and s_dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "'))" + " ) a " +
                                "  order by case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����
                        }
                    }
                }
                else//ȫ������
                {
                    if (this.cb��ʾ���.Checked)
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,1) δ�����ܷ���," +
                            " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=a.baby_id)  �ѽ����ܷ���," +//�Ѿ��������
                            " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                            //" case �������� when 'ҽ��' then YBYE else dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) end ���, ''as ���ɿ�,"+
                            " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) ���, ''as ���ɿ�," +
                            "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��, �����޶�,flag ,ryts " +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����," +
                            "         CUR_DEPT_NAME ��������,JSFS_NAME ��������,BRLX_NAME ��������,xzlx_name ��������,dylx_name ��������,in_date ��Ժ����,'' �ϴδ߿�����,INPATIENT_ID,Baby_ID,DEPT_ID,YBYE,DBJE " +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                            "         FROM vi_zy_vInpatient_Bed (nolock) WHERE (WARD_ID= '" + cmbWard.SelectedValue.ToString().Trim() + "' or '" + cmbWard.SelectedValue.ToString().Trim() + "'='-1')) a " +
                            "   left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                            "                       FROM ZY_CK " +
                            "                      GROUP BY INPATIENT_ID) as e " +
                            "   on a.INPATIENT_ID=e.INPATIENT_ID " +
                            "  order by a.dept_id,case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����
                    }
                    else
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������, ��������, ��������," +
                            "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ�� , �����޶�,flag ,ryts" +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����,CUR_DEPT_NAME ��������," +
                            "         JSFS_NAME ��������,BRLX_NAME ��������,xzlx_name ��������,dylx_name ��������,in_date ��Ժ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��, YJJ_LIMIT �����޶� ,flag ,ryts" +
                            "    FROM vi_zy_vInpatient_Bed (nolock) where (WARD_ID= '" + cmbWard.SelectedValue.ToString().Trim() + "' or '" + cmbWard.SelectedValue.ToString().Trim() + "'='-1')) a " +
                            "  order by a.dept_id,case when isnumeric(����)=1 and SUBSTRING (���� ,0,2)<>'+'   then 1 when PATINDEX('%[߹-��]%',����)>0 then 2 when SUBSTRING (���� ,0,2)='+' then 3  else  4   end ,case when isnumeric(����)=1 then cast(���� as int) else 999999 end,����,a.INPATIENT_ID,a.Baby_ID";//Modify By Tany 2015-02-09 �����ٰ�����
                    }
                }
            }

            this.myFunc.ShowGrid(1, sSql, this.myDataGrid1);

            Cursor.Current = Cursors.Default;
        }

        private void cb��ʾ���_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSeekZyh.Checked == false)
            {
                this.Show_Data1();
            }
            else
            {
                btnSeek_Click(null, null);
            }
            this.bt��ӡ�߿.Enabled = this.cb��ʾ���.Checked;
            this.button3.Enabled = this.cb��ʾ���.Checked;
            if (rbDate1.Checked) this.bt��ӡ�����嵥.Enabled = this.cb��ʾ���.Checked;
        }


        private void btȫѡ1_Click(object sender, System.EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid1);
        }

        private void bt��ѡ1_Click(object sender, System.EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid1);
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

            this.myDataGrid1.DataSource = myTb;
        }

        private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            this.myDataGrid1.Select(myDataGrid1.CurrentCell.RowNumber);
        }


        private void rbDate1_Click(object sender, System.EventArgs e)
        {
            if (this.rbDate1.Checked)
            {
                this.dtpBeginDate.Enabled = true;
                this.DtpEndDate.Enabled = false;
                if (this.cb��ʾ���.Checked)
                {
                    this.bt��ӡ�����嵥.Enabled = true;
                }
                else
                {
                    this.bt��ӡ�����嵥.Enabled = false;
                }
            }
            else this.bt��ӡ�����嵥.Enabled = true;

            if (this.rbDate2.Checked)
            {
                this.dtpBeginDate.Enabled = true;
                this.DtpEndDate.Enabled = true;
            }

            if (this.rbDate3.Checked || this.rbDate4.Checked || rBall.Checked)
            {
                this.dtpBeginDate.Enabled = false;
                this.DtpEndDate.Enabled = false;
            }

            //Modify by tany 2011-03-10
            chkZrdy.Enabled = rbDate2.Checked;
            if (!rbDate2.Checked)
            {
                chkZrdy.Checked = false;
            }
        }


        private void rbFL1_Click(object sender, System.EventArgs e)
        {
            if (this.rbFL1.Checked)
            {
                DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count <= 0) return;
                myTb.Rows.Clear();
                return;
            }

            string sSql = "";

            //���嵥����
            //			if (this.rbFL2.Checked) sSql="select code ���� ,name ���� from jc_PTITEMDICTION order by  code";

            //����Ʊ����
            if (this.rbFL3.Checked)
            {
                sSql = "select code ���� ,item_name ���� from JC_ZYFP_XM order by code";
            }

            //���������
            //			if (this.rbFL4.Checked) sSql="select code ���� ,name ���� from jc_CWITEMDICTION order by code";

            this.myFunc.ShowGrid(1, sSql, this.myDataGrid2);
            this.btȫѡ2_Click(sender, e);
        }


        private void btȫѡ2_Click(object sender, System.EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid2);
        }

        private void bt��ѡ2_Click(object sender, System.EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid2);
        }

        private void myDataGrid2_Click(object sender, System.EventArgs e)
        {
            myFunc.SelCol_Click(this.myDataGrid2);
        }


        private void bt��ӡ�����嵥_Click(object sender, System.EventArgs e)
        {
            int i = 0, j = 0, id = 0;
            string sSql = "";
            //Add By Tany 2011-03-10 �������մ�ӡ���ܣ�ֻ�ж��տ���ѡ�����մ�ӡ
            int days = 0;
            //add by zouchihua 2013-5-7סԺ��ʿվ�������嵥��ϸ��ӡ�Ƿ��ӡ�ײ����� 0=�� 1=��
            SystemCfg cfg7150 = new SystemCfg(7150);
            SystemCfg cfg7071 = new SystemCfg(7071);
            //Add By Tany 2011-03-11
            //7086��ӡ�嵥ʱ�Ƿ���ʾҩƷ��Ʒ����ע 0=���� 1=��
            SystemCfg cfg7086 = new SystemCfg(7086);
            //7094�����嵥�Ƿ��в�ҩ��ϸ�ϲ���ʾ 0=���� 1=�� Modify by tany 2011-06-20
            SystemCfg cfg7094 = new SystemCfg(7094);

            //Add BY Tany 2011-08-18
            //7098�����嵥��ӡʱ����ҽ���Ƿ�ȡ�����ϴ��󷵻صı�����Ϣ 0=���� 1=��
            SystemCfg cfg7098 = new SystemCfg(7098);
            //add by zouchihua 2012-01-21
            //�����嵥����ʾ�Ը�������ҽ������
            string[] BxsZfbl_yblx = new SystemCfg(7103).Config.ToString().Split(',');
            //δ�����ܷ����Ƿ�ͳ�Ƶ�ǰ������ 0=��1=�� add by zouchihua 2012-3-9
            SystemCfg cfg7107=new SystemCfg(7107);
            //add by zouchihua 2012-8-4
            //������ҩ��ͳ�ƴ���Ŀ������01��02��03��ҩƷ
            SystemCfg cfg7132 = new SystemCfg(7132);
            string cfg7132str="0";
            if (cfg7132.Config.Trim() == "")
                cfg7132str = "'0'";
            else
                cfg7132str = cfg7132.Config.Trim();
            
            #region ���ѡ��Ĳ��˸���
            DataTable GrdTb = (DataTable)this.myDataGrid1.DataSource;
            if (GrdTb == null) return;
            if (GrdTb.Rows.Count < 1) return;
            int iSelectRows = 0;
            for (i = 0; i <= GrdTb.Rows.Count - 1; i++)
            {
                if (GrdTb.Rows[i]["ѡ"].ToString() == "True" && GrdTb.Rows[i]["inpatient_id"].ToString() != "")
                {
                    #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(new Guid(GrdTb.Rows[i]["INPATIENT_ID"].ToString().Trim()));
                    if (rtnSql[0] != "0")
                    {
                        continue;
                    }
                    //��������Ҳ���� 
                    if (rtnSql[2] != "0")
                    {
                        continue;
                    }
                    #endregion
                    iSelectRows += 1;
                }
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ���˻���ֻѡ�����Ѿ�������Ϣ�Ĳ��ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            # endregion

            #region ����
            string sBegDate = "";
            string sEndDate = "";
            string sSql_date = "", sParam_date = "";
            if (this.rbDate1.Checked || this.rbDate2.Checked)
            {
                sBegDate = Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString() + " 00:00:00").ToString();
                sEndDate = Convert.ToDateTime(this.DtpEndDate.Value.ToShortDateString() + " 23:59:59").ToString();
                //һ�ջ����
                if (this.rbDate1.Checked)
                {
                    this.DtpEndDate.Value = Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString() + " 23:59:59");
                    sBegDate = Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString() + " 00:00:00").ToString();
                    sEndDate = Convert.ToDateTime(this.DtpEndDate.Value.ToShortDateString() + " 23:59:59").ToString();
                    //if (this.rbFL1.Checked == false)
                    //{
                    //    this.btȫѡ2_Click(sender, e);
                    //}
                }
                else
                {
                    if (this.DtpEndDate.Value < this.dtpBeginDate.Value)
                    {
                        MessageBox.Show(this, "�Բ��𣬽������ڲ���С�ڿ�ʼ���ڣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sBegDate = this.dtpBeginDate.Value.ToString();
                    sEndDate = this.DtpEndDate.Value.ToString();

                    if (chkZrdy.Enabled && chkZrdy.Checked)
                    {
                        TimeSpan ts = DtpEndDate.Value.Date.Subtract(dtpBeginDate.Value.Date);
                        days = ts.Days;
                    }
                }
                //sSql_date = " and a.charge_bit=1 and a.charge_date between '" + sBegDate + "' and '" + sEndDate + "'";
                //Modify By Tany 2009-08-13 �����ж��嵥����������
                //�����������С�ڵ��ڼ������ڣ���ô�Լ�������Ϊ׼
                //����������ڴ��ڼ������ڣ���ô�Դ�������Ϊ׼
                //Modify By Tany 2010-09-28 ���Ӳ������жϣ��Ƿ��ü������ڻ��Ǵ�������
                //7071 �����嵥����ͳ�Ʒ�ʽ 0=����ʵ�ʷ������� 1=������ǰ�ķ��ð��������ڣ������Ժ󰴴�������
                sSql_date = " and a.charge_bit=1 ";
                if (cfg7071.Config == "1")
                {
                    sSql_date += " and ((a.charge_date>=a.presc_date and a.charge_date between '" + sBegDate + "' and '" + sEndDate + "') ";
                    sSql_date += " or (a.charge_date<a.presc_date and a.presc_date between '" + sBegDate + "' and '" + sEndDate + "'))";
                }
                else
                {
                    sSql_date += " and (a.charge_date between '" + sBegDate + "' and '" + sEndDate + "') ";
                }
                sParam_date = "�������ڣ� " + sBegDate + " �� " + sEndDate;
            }
            if (this.rbDate3.Checked)
            {
                //�Ѽ���
                sSql_date = " and a.charge_bit=1 ";
                sParam_date = "�����м��˷��ã�";
            }
            if (this.rbDate4.Checked)
            {
                //δ����
                sSql_date = " and a.charge_bit=0 ";
                sParam_date = "������δ���˷��ã�";
            }
            //add by zouchihua ���м��˺�δ���� 2013-9-9
            if (this.rBall.Checked)
            {
                sParam_date = "�����м��˺�δ���˷��ã�";
            }
            #endregion

            # region ���˿���
            string sSql_brdept = "";
            if (this.rbBrBks.Checked)
            {
                //������
                sSql_brdept = " and a.dept_br in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
            }
            else if (this.rbBrQtks.Checked)
            {
                //��������
                sSql_brdept = " and a.dept_br not in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
            }
            #endregion

            # region ��������
            string sSql_kddept = "";
            if (this.rbKdBks.Checked)
            {
                //������
                sSql_kddept = " and (a.dept_id in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
            }
            else if (this.rbKdQtks.Checked)
            {
                //��������
                sSql_kddept = " and a.dept_id not in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
            }
            #endregion

            # region ִ�еص�
            string sSql_execdept = "";
            if (this.rbDept2.Checked)
            {
                //������
                sSql_execdept = " and execdept_id in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
            }
            else if (this.rbDept3.Checked)
            {
                //��������
                sSql_execdept = " and execdept_id not in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
            }
            #endregion

            # region ����
            string sSql_fl_0sf = "", sSql_fl_temp = "", sSql_fl_1 = "", sParam_fl = "";//,sSql_fl_0xy="",sSql_fl_0cy="",sSql_fl_0zy=""
            //			bool   isXY=false,isCY=false,isZY=false;
            if (this.rbFL1.Checked)
            {
                sSql_fl_0sf = ",'' as code,'' as name ";
                //				sSql_fl_0xy=",'' as code,'' as name ";
                //				sSql_fl_0cy=",'' as code,'' as name ";
                //				sSql_fl_0zy=",'' as code,'' as name ";
                //				isXY=true;
                //				isCY=true;
                //				isZY=true;
            }
            else
            {
                DataTable GrdTb2 = (DataTable)this.myDataGrid2.DataSource;
                if (GrdTb2 == null) return;
                if (GrdTb2.Rows.Count < 1)
                {
                    MessageBox.Show(this, "�Բ���û��������ݣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                for (i = 0; i <= GrdTb2.Rows.Count - 1; i++)
                {
                    if (GrdTb2.Rows[i]["ѡ"].ToString() == "True" && GrdTb2.Rows[i]["����"].ToString() != "")
                    {
                        sSql_fl_temp += sSql_fl_temp == "" ? "" : " or ";
                        sSql_fl_temp += "c.code = '" + GrdTb2.Rows[i]["����"].ToString() + "'";
                        //						if (this.rbFL3.Checked && GrdTb2.Rows[i]["����"].ToString().Trim()=="01") isXY=true;
                        //						if (this.rbFL3.Checked && GrdTb2.Rows[i]["����"].ToString().Trim()=="02") isCY=true;
                        //						if (this.rbFL3.Checked && GrdTb2.Rows[i]["����"].ToString().Trim()=="03") isZY=true;
                    }
                    else sParam_fl = "����";
                }
                if (sSql_fl_temp == "")
                {
                    MessageBox.Show(this, "�Բ���û��ѡ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sSql_fl_0sf = ",c.code,c.name";
                    //��Ʊ����
                    if (this.rbFL3.Checked)
                    {
                        sSql_fl_1 = " inner join jc_stat_item b on a.statitem_code=b.code " +
                                "   inner join (select code as code,item_name as name from JC_ZYFP_XM) as  c " +
                                "   on c.code=b.zyfp_code and (" + sSql_fl_temp + ")";
                        //						sSql_fl_0xy=",'01' as code ,'��ҩ��' as name ";
                        //						sSql_fl_0cy=",'02' as code ,'�г�ҩ' as name ";
                        //						sSql_fl_0zy=",'03' as code ,'��ҩ��' as name ";						
                        sParam_fl += "��Ʊ����";
                    }
                }
            }
            #endregion

            # region ���㷽ʽ
            string sSql_charge = "";
            string _ChargeName = "";
            if (rdoUnCharge.Checked)
            {
                sSql_charge = " and discharge_bit=0 ";
                _ChargeName = "(δ����)";
            }
            else if (rdoCharge.Checked)
            {
                sSql_charge = " and discharge_bit=1 ";
                _ChargeName = "(�ѽ���)";
            }
            else
            {
                sSql_charge = "";
                _ChargeName = "";
            }
            #endregion

            # region ���㷽ʽ
            string sSql_czflag = "";
            string _czflagName = "";
            if (rbCzflag01.Checked)
            {
                sSql_czflag = " and cz_flag in (0,1) ";
                _czflagName = "(����¼)";
            }
            else if (rbCzflag2.Checked)
            {
                sSql_czflag = " and cz_flag=2 ";
                _czflagName = "(����¼)";
            }
            else
            {
                sSql_czflag = "";
                _czflagName = "";
            }
            #endregion

            //add by zouchihua 2012-9-6 ÿ�����˴�һ��
            bool Mcdy = false;
            if (checkyl.Checked==false)
                Mcdy = true;
            //�Ƿ��ӡͳ��ʱ���
            bool BprintYe = false;
            string ssql = "";
            if ((new SystemCfg(7043)).Config == "1")
            {
                BprintYe = true;
            }

            bool Boo = false;//���������Ƿ�goto ���
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                //Modify by tany 2011-03-10 ���մ�ӡ
                for (int dd = 0; dd <= days; dd++)
                {
                    if (days > 0)
                    {
                        sBegDate = Convert.ToDateTime(this.dtpBeginDate.Value.Date.AddDays(dd).ToShortDateString() + " 00:00:00").ToString();
                        if (dd == 0)
                        {
                            sBegDate = this.dtpBeginDate.Value.ToString();
                        }
                        sEndDate = Convert.ToDateTime(this.dtpBeginDate.Value.Date.AddDays(dd).ToShortDateString() + " 23:59:59").ToString();
                        if (dd == days)
                        {
                            sEndDate = this.DtpEndDate.Value.ToString();
                        }

                        sSql_date = " and a.charge_bit=1 ";
                        if (cfg7071.Config == "1")
                        {
                            sSql_date += " and ((a.charge_date>=a.presc_date and a.charge_date between '" + sBegDate + "' and '" + sEndDate + "') ";
                            sSql_date += " or (a.charge_date<a.presc_date and a.presc_date between '" + sBegDate + "' and '" + sEndDate + "'))";
                        }
                        else
                        {
                            sSql_date += " and (a.charge_date between '" + sBegDate + "' and '" + sEndDate + "') ";
                        }
                        sParam_date = "�������ڣ� " + sBegDate + " �� " + sEndDate;
                        Boo = false;//yaokx 2014-06-09 ���˷��ò�ѯ�����Ҫ��ӡ����ÿ����շ����嵥������ѡ��ÿ������ӡ��ѡ��ʱ���Ȼ��ѡ�����մ�ӡ���ܣ���������ʵ���ϻ���ֻͳ���˿�ʼ��һ�����Ŀ�����嵥
                    }

                    rds.Tables["BRFeeMXD"].Clear();
                    //DataColumn BZ1Column = new DataColumn();
                    //BZ1Column.DataType = typeof(decimal);
                    //BZ1Column.ColumnName = "BZ1";
                    //BZ1Column.Caption = "BZ1";
                    //rds.Tables["BRFeeMXD"].Columns.Add(BZ1Column);
                xxx:
                    progressBar1.Maximum = iSelectRows;
                    progressBar1.Value = 0;

                    string yjk = "";
                    //�����µ�����
                    for (j = 0; j <= GrdTb.Rows.Count - 1; j++)
                    {
                       
                        if (GrdTb.Rows[j]["INPATIENT_ID"].ToString().Trim() != "" && GrdTb.Rows[j]["ѡ"].ToString() == "True")
                        {


                            string yjksql = @"select NVALUES from ZY_DEPOSITS where NTRANS in(10,20) and DISCHARGE_BIT=1 and  INPATIENT_ID='" + GrdTb.Rows[j]["INPATIENT_ID"].ToString() + "' and CANCEL_BIT=0";

                            DataRow yjkdr = InstanceForm.BDatabase.GetDataRow(yjksql);
                            if (yjkdr != null)
                               yjk= yjkdr["NVALUES"].ToString();

                            #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                            string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(new Guid( GrdTb.Rows[j]["INPATIENT_ID"].ToString().Trim()));
                            if (rtnSql[0] != "0")
                            {
                                continue;
                            }
                            if (rtnSql[2]!="0")
                            {
                                MessageBox.Show("�п�Ժ����δ��", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                continue;
                            }
                            #endregion
                            DataTable ybfy = null;
                            if (cfg7140.Config.Trim() == "1")
                                //add by zouchihua 2013-1-21 ֻ��ĸ�ײ�ͳ��
                                ybfy = GetInpatientInfo(new Guid(GrdTb.Rows[j]["inpatient_id"].ToString()), 0, 1);


                            //ͳ�Ʋ��˵����
                            string sqlDate = "";
                            decimal zfy = 0;


                            if (BprintYe == true)
                            {
                                if (rbDate3.Checked || rbDate4.Checked || rbDate3.Checked)
                                { }
                                else
                                {
                                   
                                    if (new SystemCfg(7071).Config == "1")
                                    {
                                        sqlDate += " and ((charge_date>=presc_date and charge_date <= '" + sEndDate + "') ";
                                        sqlDate += " or (charge_date<presc_date and presc_date <= '" + sEndDate + "'))";
                                    }
                                    else
                                    {
                                        sqlDate += " and (charge_date <= '" + sEndDate + "') ";
                                    }
                                }
                                ssql = "select sum(acvalue) zfy from zy_fee_speci(nolock) where inpatient_id='" + GrdTb.Rows[j]["INPATIENT_ID"] + "'" + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + " " + sqlDate + " and delete_bit=0 and charge_bit=1 and discharge_bit=0";
                                zfy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(ssql), "0"));
                            }

                            //Modify By Tany 2005-04-25
                            //�жϲ��˵ķ����Ƿ�����ʷ��
                            string Fee_Table = "zy_fee_speci";
                            int nStatus = 0;

                            //����ǲ���סԺ�ŵĲ��˲��ж��Ƿ���㲢ת��  wxz ���в��˲鵱ǰΪ���������ĳ��������goto��䣬�����ⶼ��
                            ////////////if (chkSeekZyh.Checked)
                            ////////////    nStatus = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select nstatus from zy_discharge where cancel_bit=0 and cz_flag=0 and inpatient_id=" + GrdTb.Rows[j]["INPATIENT_ID"].ToString()), "0"));
                            ////////////else
                            if (Boo == false)
                                nStatus = 0;
                            else
                                nStatus = 1;

                            if (nStatus == 0)
                            {
                                Fee_Table = "zy_fee_speci";
                            }
                            else
                            {
                                Fee_Table = "zy_fee_speci_h";
                            }

                            //����
                            //Modify By tany 2010-09-09 ҩƷ��item_id����ggid����Ҫ�ǲ�ѯҽ��ƥ���ϵ
                            if (this.rbKind1.Checked)
                            {
                                //Modify by Tany 2011-03-11 ҩƷ����Ŀ���Ƹ��ݲ������ж��ǲ�����ʾҩƷ��Ʒ����ע
                                sSql = "SELECT -1 tcid,null fee_id,xmly,item_id,yblx,ybjklx,��Ŀ���,���,��λ,����," +
                                "         '' as  ��������,'' as ������,'' as ��������,'' as  ִ�п��� ,b.name as ���˿���,'' as ��������," + //add by zouchihua 2012-3-28 ���ӿ�������
                                "         replace(��Ŀ����,'�������ˡ�','') ��Ŀ����,sum(����) as ����,sum(���) as ���,a.code,a.name,a.xh,CAST(ISNULL(ZFBL,1) as decimal(10,2)) as ZFBL " +
                                "  FROM (SELECT -1 tcid,xmly,item_id,SUBCODE ��Ŀ���,Item_Name ��Ŀ����,'' ���,UNIT ��λ,retail_Price ����,NUM ����,ACVALUE ���,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,1 xh,inpatient_id,baby_id,ZFBL" +
                                "  FROM " +
                                "     ( " ;
                                 //****************   //��ӡ�ײ���ϸ modify by zouchihua 2013-5-16
                                if (cfg7150.Config.Trim() != "2")
                                {
                                    sSql += "       SELECT a.tcid tcid, xmly,xmid item_id,a.unit,a.retail_Price,a.num,a.acValue,a.Item_Name,a.SUBCODE,a.presc_date,a.charge_date,a.charge_user,a.cz_flag,a.execdept_id,a.prescription_id,a.DEPT_ID,a.DEPT_BR,inpatient_id,baby_id " + sSql_fl_0sf + " ,a.ZFBL" +
                                    "         FROM " + Fee_Table + "  a (nolock)   " + sSql_fl_1 + //dbo.FUN_ZY_SEEKHSITEMSTDCODE(HSItem_ID)inner join jc_HSITEMDICTION s on a.HSItem_ID=s.item_id
                                    "        WHERE a.xmly=2 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "              and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept;
                                }
                                else
                                {
                                    sSql += "       SELECT -1 tcid,xmly,xmid item_id,a.unit,a.retail_Price,a.num,a.acValue,a.Item_Name,a.SUBCODE,a.presc_date,a.charge_date,a.charge_user,a.cz_flag,a.execdept_id,a.prescription_id,a.DEPT_ID,a.DEPT_BR,inpatient_id,baby_id " + sSql_fl_0sf + " ,a.ZFBL" +
                                     "         FROM " + Fee_Table + "  a (nolock)   " + sSql_fl_1 + //dbo.FUN_ZY_SEEKHSITEMSTDCODE(HSItem_ID)inner join jc_HSITEMDICTION s on a.HSItem_ID=s.item_id
                                     "        WHERE a.xmly=2 and TC_FLAG<=0 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                     "              and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                     sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                    "  union all " +
                                     "       SELECT a.tcid tcid,a.xmly,a.TCID item_id,f.UNIT,sum(acValue)/(select top 1 case when czflag1=2 then  -ISANALYZED else ISANALYZED end from VI_ZY_ORDEREXEC where ID=a.ORDEREXEC_ID  ) retail_Price," +
                                      " (select top 1 case when czflag1=2 then  -ISANALYZED else ISANALYZED end from VI_ZY_ORDEREXEC where ID=a.ORDEREXEC_ID  )  num,sum(acValue) acValue,'���ײ͡�'+d.ITEM_NAME,cast(tcid as nvarchar(50)) SUBCODE," +
                                      "  a.presc_date,null charge_date,null charge_user,czflag1 cz_flag,a.execdept_id ,newid() prescription_id,a.DEPT_ID,a.DEPT_BR,a.inpatient_id,a.baby_id " + sSql_fl_0sf + " ,a.ZFBL" +
                                      "  FROM  ( select *,(case when CZ_FLAG=2 then 2 else 0 end ) czflag1 from  " + Fee_Table + " ) a   " + sSql_fl_1 + "  join JC_TC d on a.TCID=d.ITEM_ID  " +
                                        " left join ZY_ORDERRECORD f on a.ORDER_ID=f.ORDER_ID  " + //'���ײ͡�'+d.ITEM_NAME,tcid SUBCODE,a.presc_date,null charge_date,null charge_user,0 cz_flag,a.execdept_id,newid() prescription_id,a.DEPT_ID,a.DEPT_BR,a.inpatient_id,a.baby_id
                                     "        WHERE a.xmly=2 and TC_FLAG>0 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                     "              and a.inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and a.baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                     sSql_date + sSql_execdept + sSql_kddept + sSql_brdept;
                                     if(!this.rbFL1.Checked)//����Ƿ���
                                         sSql += "  group by a.inpatient_id,a.baby_id,tcid,PRESC_DATE,a.xmly,f.UNIT,ORDEREXEC_ID,d.ITEM_NAME,c.code,c.name,execdept_id,a.DEPT_ID,a.DEPT_BR,(case when CZ_FLAG=2 then 2 else 0 end ),czflag1,ZFBL ";
                                     else//������
                                         sSql += "  group by a.inpatient_id,a.baby_id,tcid,PRESC_DATE,a.xmly,f.UNIT,ORDEREXEC_ID,d.ITEM_NAME,execdept_id,a.DEPT_ID,a.DEPT_BR,(case when CZ_FLAG=2 then 2 else 0 end ),czflag1,ZFBL ";
                                }
                                //************************
                               sSql+= "     ) AS A1" +
                                "    UNION ALL " +
                                "    SELECT -1 tcid,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,2,inpatient_id,baby_id,ZFBL" +
                                "      FROM " +
                                "           ( " +
                                "             SELECT xmly,SUBCODE,xmid,unit,retail_Price,a.Item_Name,num,acValue,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL" +
                                "               FROM " + Fee_Table + " a (nolock) " + sSql_fl_1 +
                                "              WHERE a.xmly=1 and ( statitem_code='01' or (statitem_code in (select TJDXM from YP_YPLX where TJDXM not in ('01','02','03')  and TJDXM not in( " + cfg7132str + ")  )  )  ) and delete_bit=0 " + sSql_charge + sSql_czflag +
                                "                    and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                "            ) AS B1 " +
                                "      LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,GGID,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID " +
                                "    UNION ALL " +
                                "    SELECT -1 tcid,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,3,inpatient_id,baby_id,ZFBL" +
                                "      FROM " +
                                "           ( " +
                                "             SELECT xmly,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL" +
                                "               FROM " + Fee_Table + " a (nolock) " + sSql_fl_1 +
                                "              WHERE a.xmly=1 and  statitem_code='02' and delete_bit=0 " + sSql_charge + sSql_czflag +
                                "                    and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                "            ) AS B1 " +
                                "      LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID ";
                                //7094�����嵥�Ƿ��в�ҩ��ϸ�ϲ���ʾ 0=���� 1=��
                                if (cfg7094.Config == "0")
                                {
                                    //��ϸ
                                    sSql += "   UNION ALL " +
                                    "   SELECT -1 tcid,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num*dosage,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,4,inpatient_id,baby_id,ZFBL" +
                                    "     FROM " +
                                    "          ( " +
                                    "            SELECT xmly,dosage,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL" +
                                    "              FROM " + Fee_Table + " a (nolock) " + sSql_fl_1 +
                                    "             WHERE a.xmly=1 and  (a.statitem_code='03' or a.statitem_code in( " + cfg7132str + ") ) and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "                   and a.inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and a.baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                    "            ) as b1" +
                                    "      LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID ";
                                }
                                else
                                {
                                    //����
                                    sSql += "   UNION ALL " +
                                        //"   SELECT xmly,0 item_id,substring(rtrim(convert(varchar(30),PRESC_NO)),1,charindex('.',convert(varchar(30),PRESC_NO))-1) SUBCODE, " +
                                    "   SELECT -1 tcid,xmly,0 item_id,'ZY' SUBCODE, " +
                                    "          '�в�ҩ��' Item_Name,'' S_YPGG,'' unit,0 retail_Price,0,sum(ACVALUE) ACVALUE,presc_date,charge_date,charge_user,0 cz_flag,execdept_id,'" + Guid.Empty.ToString() + "' prescription_id,DEPT_ID,DEPT_BR,code,name,4,inpatient_id,baby_id,ZFBL" +
                                    "     FROM " +
                                    "          ( " +
                                    "            SELECT xmly,dosage,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,PRESC_NO,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL" +
                                    "              FROM " + Fee_Table + " a (nolock) " + sSql_fl_1 +
                                    "             WHERE a.xmly=1 and  (a.statitem_code='03' or a.statitem_code in( " + cfg7132str + ") )  and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "                   and a.inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and a.baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                    "            ) as b1 " +
                                    "    group by xmly,DEPT_ID,DEPT_BR,code,name,inpatient_id,baby_id,presc_date,charge_date,charge_user,execdept_id,ZFBL";
                                }
                                sSql += "   ) a inner join vi_zy_vinpatient_all c (nolock) on a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id " +
                                    "    left join jc_dept_property b (nolock) on c.dept_id=b.dept_id " +
                                    " group by c.yblx,c.ybjklx,xmly,item_id,a.code,��Ŀ���,���,��λ,����,DEPT_BR,��Ŀ����,a.name,a.xh,b.name,ZFBL" +
                                    " ORDER BY a.xh,a.code,��Ŀ���";

                                #region �в�ҩҪ��ʾ��ϸ Modify By Tany 2007-11-15
                                //"   UNION ALL " +
                                //"   SELECT case when len(rtrim(convert(varchar,PRESC_NO)))<=5 then 'ZY'+rtrim(convert(varchar,PRESC_NO)) else  'ZY'+substring(rtrim(convert(varchar,PRESC_NO)),len(rtrim(convert(varchar,PRESC_NO)))-5,6) end ," +
                                //"          '�в�ҩ����' ,'' ,'��' ,sum(acvalue)/dosage ,dosage,sum(acvalue),'2002-01-01 00:00:00','2002-01-01 00:00:00',1,1,DEPT_BR,1,DEPT_ID,DEPT_BR,code,name,4,inpatient_id,baby_id" +
                                //"     FROM " +
                                //"          ( " +
                                //"            SELECT a.retail_Price, a.dosage,a.acvalue,a.execdept_id,a.DEPT_ID,DEPT_BR,a.presc_no,inpatient_id,baby_id" + sSql_fl_0sf +
                                //"              FROM " + Fee_Table + " a" + sSql_fl_1 +
                                //"             WHERE a.statitem_code='03' and a.delete_bit=0 " + sSql_charge +
                                //"                   and a.inpatient_id=" + GrdTb.Rows[j]["inpatient_id"].ToString() + " and a.baby_id=" + GrdTb.Rows[j]["baby_id"].ToString() +
                                //sSql_date + sSql_execdept + sSql_kddept +
                                //"            ) as b1" +
                                //"   group by presc_no,DEPT_ID,DEPT_BR,dosage,code,name,inpatient_id,baby_id ) a inner join vi_zy_vinpatient_info c on a.inpatient_id=c.inpatient_id and a.baby_id=c.baby_id " +
                                #endregion
                            }
                            else//��ϸ
                            {
                                sSql = "SELECT tcid,fee_id,xmly,item_id,yblx,ybjklx,��Ŀ���,���,��λ,����," + //��ִ��������Ϊ����������ʾ����Ϊ���ø�dataset������ֶ����֣����Ի��ǽ����������� Modify By Tany 2004-10-17
                                "         rtrim(convert(varchar,datepart(mm,presc_date)))+'-'+rtrim(convert(varchar,datepart(dd,presc_date))) as ��������,b.name as ������," +
                                    //								"         rtrim(char(month(charge_date)))+'-'+rtrim(char(day(charge_date))) as ��������,dbo.FUN_ZY_SEEKEmployeeName(charge_user) as ������,"+
                                "         case cz_flag when 1 then '�������' when 2 then '���ʷ���' else '' end as ��������,c.name as ִ�п��� ,d.name as ���˿���,f.name as ��������, " +//add by zouchihua 2012-3-28 ���ӿ�������
                                    //								"         case when date(charge_date)=date(presc_date) then ��Ŀ���� else rtrim(��Ŀ����)+'('+rtrim(char(month(presc_date)))+'-'+rtrim(char(day(presc_date)))+'����)' end as ��Ŀ����,����,���,code,name"+								
                                "        replace(��Ŀ����,'�������ˡ�','') ��Ŀ���� ,����,���,a.code,a.name,CAST(ISNULL(ZFBL,1) as decimal(10,2)) as ZFBL " +
                                "    FROM (SELECT tcid,fee_id,xmly,item_id,SUBCODE ��Ŀ���,Item_Name ��Ŀ����,'' ���,UNIT ��λ,retail_Price ����,NUM ����,ACVALUE ���,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,1 xh,inpatient_id,baby_id,ZFBL " +
                                "  FROM " +
                                "     ( " + 
                                "       SELECT a.tcid,a.id fee_id,xmly,xmid item_id,a.unit,a.retail_Price,a.num,a.acValue,a.Item_Name,a.SUBCODE,a.presc_date,a.charge_date,a.charge_user,a.cz_flag,a.execdept_id,a.prescription_id,a.DEPT_ID,a.DEPT_BR,inpatient_id,baby_id " + sSql_fl_0sf + " ,a.ZFBL " +
                                "         FROM " + Fee_Table + "  a   " + sSql_fl_1 + //dbo.FUN_ZY_SEEKHSITEMSTDCODE(HSItem_ID)inner join jc_HSITEMDICTION s on a.HSItem_ID=s.item_id
                                "        WHERE    a.xmly=2 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                "              and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                sSql_date + sSql_execdept + sSql_kddept + sSql_brdept;

                                if (cfg7150.Config.Trim() == "2")
                                {
                                    sSql += " and TC_FLAG<=0 ";//����ӡ�ײ���ϸ
                                }
                                if (cfg7150.Config.Trim()=="0")
                                    sSql += "     ) AS A1" ;
                               // "     ) AS A1" +
                                else

                                {  //add by zouchihua �����ײʹ�ӡ 2013-5-7
                                    if (cfg7150.Config.Trim() == "1")
                                    {
                                        sSql += "  UNION ALL " +
                                    "    " +
                                    "    select  a.tcid tcid,a.id fee_id,a.xmly,xmid item_id,f.unit,d.PRICE,(select top 1 ISANALYZED from VI_ZY_ORDEREXEC where ID=a.ORDEREXEC_ID  ) num" +
                                    " ,null acValue,'���ײ͡�'+d.ITEM_NAME,null SUBCODE,a.presc_date,a.presc_date charge_date,a.charge_user,a.cz_flag,a.execdept_id,a.prescription_id,a.DEPT_ID,a.DEPT_BR,a.inpatient_id,a.baby_id " + sSql_fl_0sf + " ,a.ZFBL " +
                                    "  FROM " + Fee_Table + "  a   " + sSql_fl_1 + "  join JC_TC d on a.TCID=d.ITEM_ID  " +
                                    " left join ZY_ORDERRECORD f on a.ORDER_ID=f.ORDER_ID  " +
                                    " where TC_FLAG>0 and  FYID in (select min(FYID) from ZY_FEE_SPECI where  inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + " and TC_FLAG>0 group by TC_FLAG,ORDER_ID,ORDEREXEC_ID ) " +//ORDER_ID,ORDEREXEC_ID 
                                    "  and a.xmly=2 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "              and a.inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and a.baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                     sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                  "     ) AS A1";
                                    }
                                    else
                                    {
                                        //ֻ��ӡ�ײ�ͷ
                                        sSql += "  UNION ALL " +
                                   "    " +
                                   "    select  a.tcid tcid,NEWID() fee_id,a.xmly,a.TCID item_id,f.unit,sum(acValue)/(select top 1 case when czflag1=2 then  -ISANALYZED else ISANALYZED end from VI_ZY_ORDEREXEC where ID=a.ORDEREXEC_ID  ) PRICE,(select top 1 case when czflag1=2 then  -ISANALYZED else ISANALYZED end from VI_ZY_ORDEREXEC where ID=a.ORDEREXEC_ID  ) num" +
                                   " ,sum(acValue) acValue,'���ײ͡�'+d.ITEM_NAME,cast(tcid as nvarchar(50)) SUBCODE,a.presc_date,null charge_date,null charge_user,0 cz_flag,a.execdept_id,newid() prescription_id,a.DEPT_ID,a.DEPT_BR,a.inpatient_id,a.baby_id " + sSql_fl_0sf + " ,a.ZFBL " +
                                   "  FROM  ( select *,(case when CZ_FLAG=2 then 2 else 0 end ) czflag1 from  " + Fee_Table + " ) a   " + sSql_fl_1 + "  join JC_TC d on a.TCID=d.ITEM_ID  " +
                                   " left join ZY_ORDERRECORD f on a.ORDER_ID=f.ORDER_ID  " +
                                   " where TC_FLAG>0   " +//ORDER_ID,ORDEREXEC_ID 
                                   "  and a.xmly=2 and a.delete_bit=0 " + sSql_charge + sSql_czflag +
                                   "              and a.inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and a.baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept;
                                        if (!rbFL1.Checked)
                                            sSql += " group by a.inpatient_id,a.baby_id,tcid,PRESC_DATE,a.xmly,f.UNIT,ORDEREXEC_ID,d.ITEM_NAME,c.code,c.name,execdept_id,a.DEPT_ID,a.DEPT_BR,(case when CZ_FLAG=2 then 2 else 0 end ),czflag1,a.ZFBL  ";
                                        else
                                            sSql += " group by a.inpatient_id,a.baby_id,tcid,PRESC_DATE,a.xmly,f.UNIT,ORDEREXEC_ID,d.ITEM_NAME,execdept_id,a.DEPT_ID,a.DEPT_BR,(case when CZ_FLAG=2 then 2 else 0 end ),czflag1,a.ZFBL  ";
                                        sSql += "        ) AS A1";
                                    }
                                //*******************
                                }
                                sSql+=
                                "    UNION ALL " +
                                "    SELECT  -1 tcid,fee_id,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,2,inpatient_id,baby_id,ZFBL " +
                                "      FROM " +
                                "           ( " +
                                "             SELECT a.id fee_id,xmly,SUBCODE,xmid,unit,retail_Price,a.Item_Name,num,acValue,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL " +
                                "               FROM " + Fee_Table + " a " + sSql_fl_1 +
                                "              WHERE a.xmly=1 and ( statitem_code='01' or (statitem_code in (select TJDXM from YP_YPLX where TJDXM not in ('01','02','03')  and TJDXM not in( " + cfg7132str + ")  )  )  ) and delete_bit=0 " + sSql_charge + sSql_czflag +
                                "                    and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                "            ) AS B1 " +
                                "      LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID " +
                                "    UNION ALL " +
                                "    SELECT  -1 tcid,fee_id,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,3,inpatient_id,baby_id,ZFBL" +
                                "      FROM " +
                                "           ( " +
                                "             SELECT a.id fee_id,xmly,SUBCODE,xmid,unit,retail_Price,num,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL " +
                                "               FROM " + Fee_Table + " a " + sSql_fl_1 +
                                "              WHERE a.xmly=1 and statitem_code='02' and delete_bit=0 " + sSql_charge + sSql_czflag +
                                "                    and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                "            ) AS B1 " +
                                "      LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2 ON B1.xmid=B2.CJID ";
                                //7094�����嵥�Ƿ��в�ҩ��ϸ�ϲ���ʾ 0=���� 1=��
                                if (cfg7094.Config == "0")
                                {
                                    //��ϸ
                                    sSql += "   UNION ALL " +
                                    "   SELECT  -1 tcid,fee_id,xmly,b2.ggid item_id,B1.SUBCODE,Item_Name+(case when " + cfg7086.Config + "=1 and ltrim(rtrim(YPSPMBZ))<>'' then '('+YPSPMBZ+')' else '' end) Item_Name,S_YPGG,unit,retail_Price,num*dosage,ACVALUE,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,code,name,4,inpatient_id,baby_id,ZFBL" +
                                    "     FROM " +
                                    "          ( " +
                                    "            SELECT a.id fee_id,xmly,SUBCODE,xmid,unit,retail_Price,num,dosage,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL " +
                                    "              FROM " + Fee_Table + " a" + sSql_fl_1 +
                                    "             WHERE a.xmly=1 and (a.statitem_code='03' or a.statitem_code in( " + cfg7132str + ") )  and delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "                   and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                    "           ) AS B1 " +
                                    "           LEFT JOIN (SELECT S_YPGG,S_YPSPM,SHH,CJID,ggid,YPSPMBZ FROM VI_YP_YPCD) AS B2  ON B1.xmid=B2.CJID ";
                                }
                                else
                                {
                                    //����
                                    sSql += "   UNION ALL " +
                                        //"   SELECT xmly,0 item_id,substring(rtrim(convert(varchar(30),PRESC_NO)),1,charindex('.',convert(varchar(30),PRESC_NO))-1) SUBCODE, " +
                                    "   SELECT  -1 tcid,null fee_id,xmly,0 item_id,'ZY' SUBCODE, " +
                                    "          '�в�ҩ��' Item_Name,'' S_YPGG,'' unit,0 retail_Price,0,sum(ACVALUE) ACVALUE,null presc_date,null charge_date,null charge_user,0 cz_flag,execdept_id,null prescription_id,null DEPT_ID,null DEPT_BR,code,name,4,inpatient_id,baby_id,ZFBL" +
                                    "     FROM " +
                                    "          ( " +
                                    "            SELECT xmly,SUBCODE,xmid,unit,retail_Price,num,dosage,acValue,a.Item_Name,presc_date,charge_date,charge_user,cz_flag,execdept_id,PRESC_NO,prescription_id,DEPT_ID,DEPT_BR,inpatient_id,baby_id" + sSql_fl_0sf + " ,a.ZFBL " +
                                    "              FROM " + Fee_Table + " a" + sSql_fl_1 +
                                    "             WHERE a.xmly=1 and (a.statitem_code='03' or a.statitem_code in( " + cfg7132str + ") )  and delete_bit=0 " + sSql_charge + sSql_czflag +
                                    "                   and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "' " + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + //Modify By tany 2011-03-07 �ж��Ƿ�ĸӤ�ϲ�����
                                    sSql_date + sSql_execdept + sSql_kddept + sSql_brdept +
                                    "           ) AS B1 " +
                                    "    group by xmly,code,name,inpatient_id,baby_id,execdept_id,ZFBL";
                                }
                                sSql += ") a inner join vi_zy_vinpatient_all v on a.inpatient_id=v.inpatient_id and a.baby_id=v.baby_id " +
                                "    left join jc_employee_property b on a.charge_user=b.employee_id " +
                                "    left join jc_dept_property c on a.execdept_id=c.dept_id " +
                                "    left join jc_dept_property d on v.DEPT_ID=d.dept_id " +
                                 "   left join jc_dept_property f on a.DEPT_ID=f.dept_id                                                    ";
                                if (cfg7150.Config.Trim() == "0")
                                    sSql += " ORDER BY a.xh,a.code,��Ŀ���,a.charge_date";
                                else
                                    sSql += " ORDER BY a.xh,a.code,a.tcid,presc_date,a.charge_date,��Ŀ���";

                                #region Modify By Tany 2006-12-07
                                //								sSql+=								
                                //									"   UNION ALL "+
                                //									"   SELECT case when len(rtrim(char(PRESC_NO)))<=5 then 'ZY'+rtrim(char(PRESC_NO)) else  'ZY'+substring(rtrim(char(PRESC_NO)),len(rtrim(char(PRESC_NO)))-5,6) end ,"+
                                //									"          '�в�ҩ����' ,'' ,'��' ,sum(acvalue)/dosage ,dosage,sum(acvalue),'2002-01-01 00:00:00',1,cz_flag,DEPT_BR,max(prescription_id),DEPT_ID,DEPT_BR,code,name,4"+
                                //									"     FROM "+
                                //									"          ( "+
                                //									"            SELECT a.retail_Price, a.dosage,a.acvalue,cz_flag,a.DEPT_ID,DEPT_BR,a.prescription_id,a.presc_no"+sSql_fl_0zy+
                                //									"              FROM "+Fee_Table+" a"+
                                //									"             WHERE a.statitem_code='03'  and a.delete_bit=0 "+			
                                //									"                   and a.inpatient_id="+GrdTb.Rows[j]["inpatient_id"].ToString()+" and a.baby_id="+GrdTb.Rows[j]["baby_id"].ToString()+				
                                //									sSql_date + sSql_execdept+ 
                                //									"            ) as b1"+
                                //									"   group by presc_no,DEPT_ID,DEPT_BR,dosage,code,name,cz_flag";
                                //							}
                                //��ϸ
                                #endregion
                            }
                            int jrflag = 0;
                            DataTable myTb1 = InstanceForm.BDatabase.GetDataTable(sSql);
                            if (myTb1.Rows.Count >= 1)
                            {
                                progressBar2.Maximum = myTb1.Rows.Count;
                                progressBar2.Value = 0;
                                id += 1; 
                                // DataRow[] rowsXX = TbZfbl.Select(" yblx=" + Convert.ToInt64(myTb1.Rows[0]["yblx"]) + "");

                                //������Ϣ����ʱ���ݿ�
                                for (i = 0; i <= myTb1.Rows.Count - 1; i++)
                                {
                                    //id += 1;
                                    //����Ϊ0����ʾ
                                    //Modify by tany 2011-06-21 ���Ϊ0����ʾ
                                    if (
                                        Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["���"], "0")) != 0 ||
                                        (Convert.ToInt32(Convertor.IsNull(myTb1.Rows[i]["tcid"], "-1")) > 0 && myTb1.Rows[i]["��Ŀ����"].ToString().IndexOf("���ײ͡�") >= 0
                                        )

                                        )
                                    {

                                        dr = rds.Tables["BRFeeMXD"].NewRow();
                                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                                        dr["סԺ��"] = GrdTb.Rows[j]["סԺ��"].ToString();
                                        dr["����"] = GrdTb.Rows[j]["����"].ToString().Trim();// +"(" + GrdTb.Rows[j]["��������"].ToString().Trim() + ")";
                                        dr["���˿���"] = myTb1.Rows[i]["���˿���"].ToString();
                                        dr["������"] = myTb1.Rows[i]["code"].ToString();
                                        dr["�������"] = myTb1.Rows[i]["name"].ToString();
                                        dr["��Ŀ���"] = myTb1.Rows[i]["��Ŀ���"].ToString();
                                        dr["��Ŀ����"] = myTb1.Rows[i]["��Ŀ����"].ToString();
                                        dr["BZ6"] = myTb1.Rows[i]["ZFBL"] != null && myTb1.Rows[i]["ZFBL"] != DBNull.Value ? Convert.ToDecimal(myTb1.Rows[i]["ZFBL"].ToString()) : 1; 
                                        dr["���"] = myTb1.Rows[i]["���"].ToString();
                                        dr["��λ"] = myTb1.Rows[i]["��λ"].ToString();
                                        dr["����"] = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["����"], "0"));
                                        dr["����"] = myFunc.removeZero(Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["����"], "0")));
                                        dr["���"] = Convert.ToDecimal(Convertor.IsNull(myTb1.Rows[i]["���"], "0"));
                                        //add by zouchihua 2013-5-7������ײ�
                                        if (cfg7150.Config.Trim() != "2"
                                            &&
                                            Convert.ToInt32(Convertor.IsNull(myTb1.Rows[i]["tcid"], "-1")) > 0 &&
                                            myTb1.Rows[i]["��Ŀ����"].ToString().IndexOf("���ײ͡�") >= 0
                                            )
                                        {
                                            dr["���"] = System.DBNull.Value;
                                            dr["����"] = System.DBNull.Value;
                                        }

                                        dr["ִ�п���"] = myTb1.Rows[i]["ִ�п���"].ToString();
                                        dr["��������"] = myTb1.Rows[i]["��������"].ToString();
                                        dr["������"] = myTb1.Rows[i]["������"].ToString();
                                        dr["��������"] = myTb1.Rows[i]["��������"].ToString();
                                        dr["baby_id"] = GrdTb.Rows[j]["baby_id"].ToString();
                                        dr["id"] = id.ToString();
                                        dr["��������"] = myTb1.Rows[i]["��������"].ToString();//add by zouchihua 2012-3-28
                                        //Modify By Tany 2009-10-10
                                        dr["�Ա�"] = GrdTb.Rows[j]["�Ա�"].ToString().Trim();
                                        dr["��Ժ����"] = GrdTb.Rows[j]["��Ժ����"].ToString().Trim();
                                        dr["��Ժ����"] = GrdTb.Rows[j]["��Ժ����"].ToString().Trim();
                                        dr["����"] = GrdTb.Rows[j]["����"].ToString().Trim();
                                        dr["���"] = (GrdTb.Rows[j]["��������"].ToString().Trim() == "ҽ��" ? GrdTb.Rows[j]["ҽ������"].ToString().Trim() : GrdTb.Rows[j]["��������"].ToString().Trim());
                                        dr["������λ"] = GrdTb.Rows[j]["������λ"].ToString().Trim();
                                        dr["���֤"] = GrdTb.Rows[j]["���֤"].ToString().Trim();
                                        //add by zouchihua 2012-3-22
                                        dr["��Ժ����"] = GrdTb.Rows[j]["ryts"].ToString();
                                        string zyzt = "";
                                        if (Int32.Parse(GrdTb.Rows[j]["flag"].ToString()) <= 4)
                                            zyzt = "��Ժ";
                                        else
                                            if (Int32.Parse(GrdTb.Rows[j]["flag"].ToString()) == 5)
                                                zyzt = "����";
                                            else
                                                zyzt = "��Ժ";
                                        dr["��Ժ״̬"] = zyzt;

                                        dr["����ʱ��"] = DBNull.Value;
                                        dr["����ʱ��"] = DBNull.Value;
                                        dr["ҽ���ܶ�"] = DBNull.Value;
                                        dr["ͳ��֧��"] = DBNull.Value;
                                        dr["�˻�֧��"] = DBNull.Value;
                                        dr["����֧��"] = DBNull.Value;
                                        dr["�ֽ�֧��"] = DBNull.Value;
                                        dr["ҽ�����"] = DBNull.Value;
                                        dr["bz"] = "";
                                        for (int x = 0; x < 5; x++)
                                        {
                                            dr["bz" + (x + 1).ToString()] = "";
                                        }
                                        //add by zouchihua 2013-1-21
                                        if (ybfy != null && ybfy.Rows.Count > 0 && Convertor.IsNull(ybfy.Rows[0]["ybjs_date"], "") != "")
                                        {
                                            dr["����ʱ��"] = Convert.ToDateTime(ybfy.Rows[0]["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss");
                                            dr["ҽ���ܶ�"] = Convert.ToDecimal(ybfy.Rows[0]["ybzfy"]);
                                            dr["ͳ��֧��"] = Convert.ToDecimal(ybfy.Rows[0]["tczf"]);
                                            dr["�˻�֧��"] = Convert.ToDecimal(ybfy.Rows[0]["zhzf"]);
                                            dr["����֧��"] = Convert.ToDecimal(ybfy.Rows[0]["qtzf"]);
                                            dr["�ֽ�֧��"] = Convert.ToDecimal(ybfy.Rows[0]["xjzf"]);
                                            dr["ҽ�����"] = Convert.ToDecimal(Convert.ToDecimal(ybfy.Rows[0]["yjk"]) - Convert.ToDecimal(ybfy.Rows[0]["xjzf"]));
                                        }

                                        //add by zouchihua 2012-5-31
                                        dr["�������"] = GrdTb.Rows[j]["�������"].ToString();
                                        dr["�����޶�"] = GrdTb.Rows[j]["�����޶�"].ToString();
                                        if (this.cb��ʾ���.Checked)
                                        {
                                            //										sSql+="'" + GrdTb.Rows[j]["Ԥ����"].ToString() + "'," +"'" + GrdTb.Rows[j]["δ�����ܷ���"].ToString() + "','" + GrdTb.Rows[j]["���"].ToString() + "')";
                                            dr["δ����Ԥ����"] = GrdTb.Rows[j]["Ԥ����"].ToString();
                                            dr["δ�����ܷ���"] = GrdTb.Rows[j]["δ�����ܷ���"].ToString();
                                            //add by zouchihua 2012-03-09 δ�����ܷ����Ƿ�ͳ�Ƶ�ǰ������ 0=��1=��
                                            if (cfg7107.Config == "1" && jrflag == 0)
                                            {
                                                dr["δ�����ܷ���"] = zfy;
                                                //jrflag = 1;
                                                //string sqltj = " charge_bit=1 and DELETE_BIT=0 and discharge_bit=0   ";
                                                //if (cfg7071.Config == "1")
                                                //{
                                                //    sqltj += " and ((a.charge_date>=a.presc_date and a.charge_date <='" + sEndDate + "') ";
                                                //    sqltj += " or (a.charge_date<a.presc_date and a.presc_date<='" + sEndDate + "'))";
                                                //}
                                                //else
                                                //{
                                                //    sqltj += " and (a.charge_date <='" + sEndDate + "') ";
                                                //}
                                                //sqltj=" select sum(ACVALUE) δ�����ܷ��� from ZY_FEE_SPECI a where "+sqltj+" and inpatient_id='"+ GrdTb.Rows[j]["inpatient_id"].ToString()+"' ";
                                                // if(!chkHbmy.Checked)
                                                //     sqltj+=" and baby_id="+GrdTb.Rows[j]["baby_id"].ToString();

                                                // DataTable tb = FrmMdiMain.Database.GetDataTable(sqltj);
                                                // if (tb != null && tb.Rows.Count > 0)
                                                // {
                                                //     dr["δ�����ܷ���"] = tb.Rows[0]["δ�����ܷ���"].ToString();

                                                // }
                                            }


                                            decimal ye = Convert.ToDecimal(Convertor.IsNull(GrdTb.Rows[j]["Ԥ����"], "0")) - zfy;
                                            dr["���"] = BprintYe == true ? ye.ToString() : GrdTb.Rows[j]["���"].ToString();//��ʾʵʱ���
                                        }
                                        else
                                        {
                                            dr["δ����Ԥ����"] = " ";
                                            dr["δ�����ܷ���"] = " ";
                                            dr["���"] = " ";
                                        }

                                        //yaokx 2014-06-04
                                        dr["�ܷ���"] = GrdTb.Rows[j]["�ѽ����ܷ���"].ToString();


                                        dr["Ԥ����"] = yjk;
                                        //if (yblx.ybjklx > 0 )
                                        //{

                                       

                                        DataRow[] rows = TbZfbl.Select("xmly=" + Convert.ToInt16(myTb1.Rows[i]["xmly"]) + " and xmid=" + Convert.ToInt64(myTb1.Rows[i]["item_id"].ToString() == "" ? "0" : myTb1.Rows[i]["item_id"].ToString()) + " and yblx=" + Convert.ToInt64(myTb1.Rows[0]["yblx"].ToString() == "" ? "-1" : myTb1.Rows[0]["yblx"].ToString()) + "");//and ybjklx=" + yblx.ybjklx+ ""
                                        if (rows.Length == 0)
                                        {
                                            dr["�Ը�����"] = "��ƥ��";//"100%";yaokx 2014-06-06
                                            dr["�Ը����"] = dr["���"];
                                        }
                                        else
                                        {
                                            decimal zfbl = Convert.ToDecimal(Convertor.IsNull(rows[0]["zfbl"], "1"));
                                            dr["�Ը�����"] = "��ƥ��";// Convert.ToInt32(zfbl * 100).ToString() + "%";yaokx 2014-06-06
                                            //Modify By tany 2010-09-27 �Ը����ļ��㻹Ҫ�ȶ�����޼ۣ�����޼���Ե���
                                            //��������
                                            decimal bxdj = Math.Round(Convert.ToDecimal(Convertor.IsNull(dr["����"], "0")) * (1 - zfbl), 2);
                                            //�Ը����
                                            decimal zfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(dr["���"], "0")) * zfbl, 2);

                                            if (bxdj > Convert.ToDecimal(rows[0]["zgxj"]))
                                            {
                                                zfje = (Convert.ToDecimal(Convertor.IsNull(dr["����"], "0")) - Convert.ToDecimal(rows[0]["zgxj"])) * Convert.ToDecimal(dr["����"]);
                                            }
                                            dr["�Ը����"] = zfje;
                                        }

                                        //Modify By tany 2011-08-18 ����ҽ�����Զ���ȡ������Ϣ
                                        //7098�����嵥��ӡʱ����ҽ���Ƿ�ȡ�����ϴ��󷵻صı�����Ϣ 0=���� 1=��
                                        if (cfg7098.Config == "1"
                                            && (Convert.ToInt32(myTb1.Rows[i]["ybjklx"]) == 8 || Convert.ToInt32(myTb1.Rows[i]["ybjklx"]) == 14)
                                            && Convertor.IsNull(myTb1.Rows[i]["fee_id"], "") != "")
                                        {
                                            DataRow drYbxx = InstanceForm.BDatabase.GetDataRow("select * from ZY_YB_DRSYB_FYBLXX where feeid='" + myTb1.Rows[i]["fee_id"].ToString() + "'");
                                            if (drYbxx != null)
                                            {
                                                string sZfbl = "";
                                                switch (Convert.ToInt32(drYbxx["sfxmdj"]))
                                                {
                                                    case 1:
                                                        sZfbl = "����";
                                                        break;
                                                    case 2:
                                                        sZfbl = "����";
                                                        break;
                                                    case 3:
                                                        sZfbl = "�Է�";
                                                        break;
                                                    default:
                                                        sZfbl = dr["�Ը�����"].ToString();
                                                        break;
                                                }
                                                dr["�Ը�����"] = sZfbl;
                                                dr["�Ը����"] = Convert.ToDecimal(drYbxx["zlje"]) + Convert.ToDecimal(drYbxx["zfje"]);
                                            }
                                        }

                                        //}
                                        //add by zouchihua 2012-2-21
                                        //������������� �Ը������ͽ�Ϊ��
                                        for (int x = 0; x < BxsZfbl_yblx.Length; x++)
                                        {
                                            if (BxsZfbl_yblx[x].Trim() != "" && myTb1.Rows[i]["yblx"].ToString().Trim() == BxsZfbl_yblx[x].Trim())
                                            {
                                                dr["�Ը�����"] = "";
                                                dr["�Ը����"] = DBNull.Value;
                                                break;
                                            }
                                        }
                                        //dr["�Ը����"] = dr["�Ը����"].ToString();
                                        //Modify By Tany 2011-01-21 ����Ǵ�ӡ�Ը����ã���ô�ж�һ���Ը�����
                                        if (sender != null
                                            || (sender == null && Convert.ToDecimal(dr["�Ը����"].ToString().Replace("%", "")) != 0))//Modify By Tany 2011-08-18 ԭ���жϵı���������ֻҪ���Ը�������
                                        {
                                            //���������ż��뵽��ӡ���ݼ�
                                            rds.Tables["BRFeeMXD"].Rows.Add(dr);
                                        }

                                    }

                                    progressBar2.Value += 1;
                                }
                            }
                            
                            progressBar1.Value += 1;
                            progressBar2.Value = 0;

                            //add by zouchihua 2102-9-6
                            if (Mcdy)
                            {
                                #region
                                if (this.chkSeekZyh.Checked == true && Boo == false)
                                {
                                    Boo = true;
                                    goto xxx;
                                }

                                string sParam1 = "", sParam2 = "", sParam3 = "";
                                if (this.cb��ʾ���.Checked)
                                {
                                    sParam1 = "Ԥ���";
                                    sParam2 = "�ܷ��ã�";
                                    sParam3 = "��";
                                }
                                sParam_fl = sParam_fl == "" ? "" : "(" + sParam_fl + ")";

                                FrmReportView frmRptView = null;
                                string _reportName = "";
                                ParameterEx[] _parameters = new ParameterEx[6];

                                //Modify By Tany 2011-01-21 ����Ǵ�ӡ�Ը����ã�senderΪnull
                                if (sender == null)
                                {
                                    _reportName = "ZYHS_�Ը����õ�.rpt";
                                    _parameters[0].Text = "��ͷ";
                                    _parameters[0].Value = new SystemCfg(0002).Config + "סԺ�����Ը����õ�";// +sParam_fl + _ChargeName;
                                }
                                else
                                {
                                    if (this.rbKind1.Checked)
                                    {
                                        //����
                                        if (this.rbFL1.Checked)
                                        {
                                            //������
                                            _reportName = "ZYHS_���õ����ܲ�����.rpt";
                                            _parameters[0].Text = "��ͷ";
                                            _parameters[0].Value = new SystemCfg(0002).Config + "סԺ���˷��û��ܵ�";// +sParam_fl + _ChargeName;
                                        }
                                        else
                                        {
                                            //����
                                            _reportName = "ZYHS_���õ����ܷ���.rpt";
                                            _parameters[0].Text = "��ͷ";
                                            _parameters[0].Value = new SystemCfg(0002).Config + "סԺ���˷��û��ܵ�";// +sParam_fl + _ChargeName;
                                        }
                                    }
                                    else
                                    {
                                        //��ϸ
                                        if (this.rbFL1.Checked)
                                        {
                                            //������
                                            _reportName = "ZYHS_���õ���ϸ������.rpt";
                                            _parameters[0].Text = "��ͷ";
                                            _parameters[0].Value = new SystemCfg(0002).Config + "סԺ���˷�����ϸ��";// +sParam_fl + _ChargeName;
                                        }
                                        else
                                        {
                                            //����
                                            _reportName = "ZYHS_���õ���ϸ����.rpt";
                                            _parameters[0].Text = "��ͷ";
                                            _parameters[0].Value = new SystemCfg(0002).Config + "סԺ���˷�����ϸ��";// +sParam_fl + _ChargeName;
                                        }
                                    }
                                }

                                _parameters[1].Text = "����";
                                _parameters[1].Value = sParam_date;
                                _parameters[2].Text = "��ӡ��";
                                _parameters[2].Value = "��ӡ�ߣ�" + InstanceForm.BCurrentUser.Name;
                                _parameters[3].Text = "Ԥ����";
                                _parameters[3].Value = sParam1;
                                _parameters[4].Text = "�ܷ���";
                                _parameters[4].Value = sParam2;
                                _parameters[5].Text = "���";
                                _parameters[5].Value = sParam3;
                                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters,true);
                                #endregion
                                rds.Tables["BRFeeMXD"].Clear();
                            }
                        }
                    }
                    //MessageBox.Show("dddd");

                    progressBar1.Value = 0;
                    //add by zouchiua 2012-9-6
                    if (Mcdy)
                        return;
                    if (this.chkSeekZyh.Checked == true && Boo == false)
                    {
                        Boo = true;
                        goto xxx;
                    }

                    string sParam11 = "", sParam21 = "", sParam31 = "";
                    if (this.cb��ʾ���.Checked)
                    {
                        sParam11 = "Ԥ���";
                        sParam21 = "�ܷ��ã�";
                        sParam31 = "��";
                    }
                    sParam_fl = sParam_fl == "" ? "" : "(" + sParam_fl + ")";

                    FrmReportView frmRptView1 = null;
                    string _reportName1 = "";
                    ParameterEx[] _parameters1 = new ParameterEx[6];

                    //Modify By Tany 2011-01-21 ����Ǵ�ӡ�Ը����ã�senderΪnull
                    if (sender == null)
                    {
                        _reportName1 = "ZYHS_�Ը����õ�.rpt";
                        _parameters1[0].Text = "��ͷ";
                        _parameters1[0].Value = new SystemCfg(0002).Config + "סԺ�����Ը����õ�";// +sParam_fl + _ChargeName;
                    }
                    else
                    {
                        if (this.rbKind1.Checked)
                        {
                            //����
                            if (this.rbFL1.Checked)
                            {
                                //������
                                _reportName1 = "ZYHS_���õ����ܲ�����.rpt";
                                _parameters1[0].Text = "��ͷ";
                                _parameters1[0].Value = new SystemCfg(0002).Config + "סԺ���˷��û��ܵ�";// +sParam_fl + _ChargeName;
                            }
                            else
                            {
                                //����
                                _reportName1 = "ZYHS_���õ����ܷ���.rpt";
                                _parameters1[0].Text = "��ͷ";
                                _parameters1[0].Value = new SystemCfg(0002).Config + "סԺ���˷��û��ܵ�";// +sParam_fl + _ChargeName;
                            }
                        }
                        else
                        {
                            //��ϸ
                            if (this.rbFL1.Checked)
                            {
                                //������
                                _reportName1 = "ZYHS_���õ���ϸ������.rpt";
                                _parameters1[0].Text = "��ͷ";
                                _parameters1[0].Value = new SystemCfg(0002).Config + "סԺ���˷�����ϸ��";// +sParam_fl + _ChargeName;
                            }
                            else
                            {
                                //����
                                _reportName1 = "ZYHS_���õ���ϸ����.rpt";
                                _parameters1[0].Text = "��ͷ";
                                _parameters1[0].Value = new SystemCfg(0002).Config + "סԺ���˷�����ϸ��";// +sParam_fl + _ChargeName;
                            }
                        }
                    }

                    _parameters1[1].Text = "����";
                    _parameters1[1].Value = sParam_date; 
                    _parameters1[2].Text = "��ӡ��";
                    _parameters1[2].Value = "��ӡ�ߣ�" + InstanceForm.BCurrentUser.Name;
                    _parameters1[3].Text = "Ԥ����";
                    _parameters1[3].Value = sParam11;
                    _parameters1[4].Text = "�ܷ���";
                    _parameters1[4].Value = sParam21;
                    _parameters1[5].Text = "���";
                    _parameters1[5].Value = sParam31;
                   
                    try
                    {
                        frmRptView1 = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName1, _parameters1);
                        //���ӵ������� add by zouchihua 2013-9-13
                        if (this.rbKind1.Checked)
                        {
                            frmRptView1.ShowExportButton = true;
                        }
                        frmRptView1.Show();
                    }
                    catch (Exception ex)
                    {
                        new Exception("��ӡ����" + ex.Message);
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void bt��ӡ�߿_Click(object sender, System.EventArgs e)
        {
            //�õ�������Ϣ
            DataTable GrdTb = (DataTable)this.myDataGrid1.DataSource;
            if (GrdTb == null || GrdTb.Rows.Count < 1) return;

            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                //Modify By Tany 2010-09-28
                string[] sSql = new string[GrdTb.Rows.Count];
                string sql = "";

                string dwmc = (new SystemCfg(0002)).Config;
                string khyh = (new SystemCfg(0003)).Config;
                string zh = (new SystemCfg(0004)).Config;

                rds.Tables["BRFeeCKD"].Clear();
                //�����µ�����
                for (int j = 0; j <= GrdTb.Rows.Count - 1; j++)
                {
                    if (GrdTb.Rows[j]["inpatient_id"].ToString().Trim() != "" && GrdTb.Rows[j]["ѡ"].ToString() == "True")
                    {
                        //������ʱ��SQL���
                        dr = rds.Tables["BRFeeCKD"].NewRow();

                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                        dr["סԺ��"] = GrdTb.Rows[j]["סԺ��"].ToString().Remove(0,2);
                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                        dr["����"] = InstanceForm.BCurrentDept.WardName;
                        dr["��Ժ����"] = GrdTb.Rows[j]["��Ժ����"].ToString();
                        dr["��������"] = GrdTb.Rows[j]["���ɿ�"].ToString();
                        dr["��Ԥ��"] = GrdTb.Rows[j]["Ԥ����"].ToString();
                        dr["�ܷ���"] = GrdTb.Rows[j]["δ�����ܷ���"].ToString();
                        dr["���"] = GrdTb.Rows[j]["���"].ToString();
                        dr["��������"] = GrdTb.Rows[j]["��������"].ToString();
                        //Modify By Tany 2011-03-07
                        //7085��ӡ�߿ʱ�ܷ����Ƿ����Ԥִ�еķ��� 0=���� 1=��
                        if (new SystemCfg(7085).Config == "0")
                        {
                            decimal zfy = 0;
                            string sqlDate = " and ((charge_date>=presc_date and charge_date <= getdate()) ";
                            sqlDate += " or (charge_date<presc_date and presc_date <= getdate()))";
                            string ssql = "select sum(acvalue) zfy from zy_fee_speci(nolock) where inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "'" + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + " " + sqlDate + " and delete_bit=0 and charge_bit=1 and discharge_bit=0";
                            zfy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(ssql), "0"));

                            dr["�ܷ���"] = zfy.ToString("0.00");
                            dr["���"] = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(GrdTb.Rows[j]["Ԥ����"], "0")) - zfy).ToString("0.00");
                        }
                        dr["��λ����"] = dwmc;
                        dr["��������"] = khyh;
                        dr["�˺�"] = zh;
                        dr["������"] = InstanceForm.BCurrentUser.Name;

                        if (GrdTb.Rows[j]["��������"].ToString().Trim().IndexOf("ҽ��") >= 0)
                        {
                            //Modify By Tany 2010-09-28 ����ҽ�����ü���
                            if (Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select is_ybjs from zy_inpatient where inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "'"), "0")) == 0)
                            {
                                //û��ҽ������
                                sql = "select * from zy_yb_jsb_rjjl where delete_bit=0 and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "' order by ybjs_date desc";
                            }
                            else
                            {
                                //�Ѿ�ҽ������
                                sql = "select * from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "' order by ybjs_date desc";
                            }

                            DataTable ybTb = InstanceForm.BDatabase.GetDataTable(sql);

                            if (ybTb != null && ybTb.Rows.Count > 0)
                            {
                                dr["ҽ����������"] = Convert.ToDateTime(ybTb.Rows[0]["ybjs_date"]);
                                dr["ҽ���ܷ���"] = Convert.ToDecimal(ybTb.Rows[0]["zfy"]);
                                dr["ͳ��֧��"] = Convert.ToDecimal(ybTb.Rows[0]["tczf"]);
                                dr["�˻�֧��"] = Convert.ToDecimal(ybTb.Rows[0]["zhzf"]);
                                dr["����֧��"] = Convert.ToDecimal(ybTb.Rows[0]["qtzf"]);
                                dr["�ֽ�֧��"] = Convert.ToDecimal(ybTb.Rows[0]["xjzf"]);
                            }
                        }

                        rds.Tables["BRFeeCKD"].Rows.Add(dr);

                        //����߿��¼
                        sSql[j] = "insert into zy_ck(id,inpatient_id,ck_date,ck_user,ck_values,jgbm) values('" + PubStaticFun.NewGuid() + "','" + new Guid(GrdTb.Rows[j]["inpatient_id"].ToString()) + "'" +
                            ",'" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + Convert.ToDecimal(GrdTb.Rows[j]["���ɿ�"].ToString().Trim() == "" ? "0" : GrdTb.Rows[j]["���ɿ�"].ToString().Trim()) + "," + FrmMdiMain.Jgbm + ")";
                        //InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }

                FrmReportView fp = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\ZYHS_�߿.rpt", null);

                //Modify By Tany 2010-09-28 ��ӡ��Ÿ��´߿��¼
                fp._sqlStr = sSql;

                fp.Show();
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show(err.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void bt��ӡ��������_Click(object sender, System.EventArgs e)
        {
            //�õ�������Ϣ
            DataTable GrdTb = (DataTable)this.myDataGrid1.DataSource;
            if (GrdTb == null || GrdTb.Rows.Count < 1) return;

            DataTable myTb = GrdTb.Clone();//Copy();
            myTb = GrdTb.Copy();

            DataSet rs = new DataSet();
            myTb.TableName = "tabGrd";
            rs.Tables.Add(myTb);

            FrmReportView fp = new FrmReportView(myTb, Constant.ApplicationDirectory + "\\report\\ZYHS_���Ҳ��˷���.rpt", null);
            fp.Show();
        }

        //��ӡ������
        private void button3_Click(object sender, System.EventArgs e)
        {
            Button btnNew = (Button)sender;
            Point pp = new Point(btnNew.Location.X, btnNew.Location.Y + btnNew.Height);
            contextMenu1.Show(btnNew.Parent, pp);
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //			int i=0,j=0;
            //			RelationalDatabase _Database=RelationalDatabase.GetDatabase();
            //			_Database.Initialize("");
            //			IDbCommand cmd=null;
            //			bool IsYL=false;
            //			
            //			MenuItem mi = (MenuItem)sender;
            //			if(mi.Text=="Ԥ��")
            //				IsYL=true;
            //			else
            //				IsYL=false;
            //
            //			FeePrint feePrint=new FeePrint();
            //			feePrint.bDate=dtpBeginDate.Value;
            //			feePrint.eDate=DtpEndDate.Value;
            //			Patient pt=null;
            //			Inpatient ipt= null;
            //			
            //			Cursor.Current=new Cursor(ClassStatic.Static_cur); 
            //
            //			#region ���ѡ��Ĳ��˸���
            //			DataTable GrdTb=(DataTable)this.myDataGrid1.DataSource;
            //			if(GrdTb==null)return;
            //			if(GrdTb.Rows.Count<1)return;
            //			int iSelectRows=0;
            //			for(i=0;i<=GrdTb.Rows.Count-1;i++)
            //			{
            //				if (GrdTb.Rows[i]["ѡ"].ToString()=="True" && GrdTb.Rows[i]["inpatient_id"].ToString()!="")
            //				{
            //					iSelectRows+=1;					
            //				}
            //			}
            //			if (iSelectRows==0)
            //			{
            //				MessageBox.Show(this,"�Բ���û��ѡ���ˣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
            //				return;
            //			}
            //			long[] arr_inpatient_id = new long[iSelectRows];
            //			string[] arr_bedno= new string[iSelectRows];
            //			double[] arr_ye= new double[iSelectRows];
            //			j=0;
            //			for(i=0;i<=GrdTb.Rows.Count-1;i++)
            //			{
            //				if (GrdTb.Rows[i]["ѡ"].ToString()=="True" && GrdTb.Rows[i]["inpatient_id"].ToString()!="")
            //				{
            //					arr_inpatient_id[j]=Convert.ToInt64(GrdTb.Rows[i]["inpatient_id"].ToString());
            //					arr_bedno[j]=GrdTb.Rows[i]["����"].ToString().Trim();
            //					arr_ye[j]=Convert.ToDouble(GrdTb.Rows[i]["���"].ToString().Trim());
            //					j++;
            //				}
            //			}
            //			# endregion
            //				
            //			feePrint.inpatients=new PATIENT[iSelectRows];
            //			feePrint.ItemTables=new DataTable[iSelectRows];
            //			feePrint.DrugTables=new DataTable[iSelectRows];
            //
            //			for(int k=0;k<iSelectRows;k++)
            //			{
            //				//���ɲ����б�
            //				feePrint.inpatients[k]=new PATIENT(); 
            //				try
            //				{
            //					ipt=new Inpatient(arr_inpatient_id[k]);
            //					pt=new Patient(ipt.PatientID);
            //					if(pt==null) throw new Exception("���������д�����ID="+ipt.PatientID.ToString());
            //
            //					feePrint.inpatients[k].Name=pt.Name.Trim();
            //					feePrint.inpatients[k].InpatientNo=pt.Inpatient_No.Trim();
            //					feePrint.inpatients[k].DischargeType=ipt.DischargeType;
            //					feePrint.inpatients[k].Deptment=new Deptment(ipt.Dept_ID).Name.Trim();
            //					feePrint.inpatients[k].BedNo=arr_bedno[k];//Convert.ToString(XcjwHIS.PubicBaseClasses.Convertor.IsNull(ipt.Bed_ID,""));
            //					feePrint.inpatients[k].Type=ipt.DischargeName.Trim();
            //					feePrint.inpatients[k].Deposits=ipt.GetDeposits(dtpBeginDate.Value,true);
            //					feePrint.inpatients[k].Fee=ipt.GetFee(DtpEndDate.Value);
            //					feePrint.inpatients[k].Ybleft=arr_ye[k];
            //
            //					//�����б�
            //					_Database.Open();
            //					cmd=_Database.GetCommand();
            //					cmd.CommandText="SJ_GET_PTITEMFEE";
            //					cmd.CommandType=System.Data.CommandType.StoredProcedure;
            //
            //					cmd.Parameters.Add(_Database.GetParameter("",ipt.InpatientID));
            //					cmd.Parameters.Add(_Database.GetParameter("",dtpBeginDate.Value.ToString("yyyy-MM-dd")));
            //					cmd.Parameters.Add(_Database.GetParameter("",DtpEndDate.Value.ToString("yyyy-MM-dd")));
            //					feePrint.ItemTables[k]=_Database.GetDataTable(cmd);
            //					_Database.Close();
            //				}
            //				catch(System.Exception err) 
            //				{
            //					MessageBox.Show(err.Message);
            //				}
            //
            //				//�����ҪҩƷ��Ϣ�����ȡҩƷ
            //
            //				try
            //				{
            //					_Database.Open();
            //					cmd=_Database.GetCommand();
            //					cmd.CommandText="SJ_GET_DRUGLIST";
            //					cmd.CommandType=System.Data.CommandType.StoredProcedure;
            //
            //					cmd.Parameters.Add(_Database.GetParameter("",ipt.InpatientID));
            //					cmd.Parameters.Add(_Database.GetParameter("",dtpBeginDate.Value.ToString("yyyy-MM-dd")));
            //					cmd.Parameters.Add(_Database.GetParameter("",DtpEndDate.Value.ToString("yyyy-MM-dd")));
            //					feePrint.DrugTables[k]=_Database.GetDataTable(cmd);
            //					_Database.Close();
            //
            //				}
            //				catch(System.Exception err) {MessageBox.Show("��ҩƷ����\n"+err.Message);}
            ////				_Database.Close();
            //
            //			}
            //			
            //			//�Ƿ��ӡҩƷ
            //			feePrint._Drug=true;
            //			try
            //			{
            //				//true=Ԥ�� false=ֱ�Ӵ�
            //				feePrint.Print(IsYL);
            //			}
            //			catch(System.Exception err)
            //			{
            //				MessageBox.Show(err.Message);
            //			}
            //
            //			_Database.Close();
            //			Cursor.Current=Cursors.Default;
        }

        private void chkSeekZyh_Click(object sender, System.EventArgs e)
        {
            txtZyh.Text = "";
            txtZyh.Enabled = chkSeekZyh.Checked;
            btnSeek.Enabled = chkSeekZyh.Checked;
            btSeekPat.Enabled = chkSeekZyh.Checked;

            if (chkSeekZyh.Checked)
            {
                myDataGrid1.DataSource = null;
                txtZyh.Focus();
            }
            else
            {
                Show_Data1();
            }
        }

        private void txtZyh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSeek_Click(null, null);
            }
            //��������ĸ��ͷ��סԺ��
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            //{
            //    e.Handled = true;
            //}
        }

        private void btnSeek_Click(object sender, System.EventArgs e)
        {
            if (txtZyh.Text.Trim() == "")
                txtZyh.Text = "0";

            string sSql = "";

            if (isSSMZ)
            {
                //				sSql=@"SELECT distinct a.BED_NO AS ����,a.NAME AS ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,a.isMY "+                                 
                //					"  FROM vi_zy_vInpatient_All a,ss_apprecord b,ss_arrrecord c "+                         
                //					"  where a.inpatient_id=b.inpatient_id and a.inpatient_no='"+txtZyh.Text.Trim()+"'"+
                //					"  and b.sno=c.sno and b.inpatient_id=c.inpatient_id and b.apbj=1 and  c.bdelete=0 "+
                //					"  order by a.baby_id";
                sSql = @"SELECT a.BED_NO AS ����,a.NAME AS ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,a.isMY " +
                    "  FROM vi_zy_vInpatient_All a " +
                    "  where a.inpatient_no='" + txtZyh.Text.Trim() + "' and flag<>10 " +
                    "  order by a.baby_id";
            }
            else
            {
                if (_isAll == 0)
                {
                    sSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE  inpatient_no='" + txtZyh.Text.Trim() + "' and flag<>10 " + //WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and
                        "  order by baby_id";
                }
                else
                {
                    sSql = @" SELECT BED_NO AS ����,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID,isMY " +
                        "   FROM vi_zy_vInpatient_All " +
                        "  WHERE inpatient_no='" + txtZyh.Text.Trim() + "' and flag<>10 " +
                        "  order by baby_id";
                }
            }
            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("û���ҵ��ò�����Ϣ����˶�סԺ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Show_Date_Inpatient(txtZyh.Text);
        }

        private void Show_Date_Inpatient(string Inpatient_no)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            string sSql = "";
            if (isSSMZ)
            {
                if (this.cb��ʾ���.Checked)
                {
                    sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,1) δ�����ܷ���," +
                        " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=a.baby_id)  �ѽ����ܷ���," +//�Ѿ��������
                        " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                        " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) ���, ''as ���ɿ�," +
                        "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ�� ,�����޶�,flag ,ryts" +
                          " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                        "   from (SELECT a.BED_NO ����,a.INPATIENT_NO סԺ��,a.NAME ����,a.SEX_NAME �Ա�,a.age ����,a.CUR_DEPT_NAME ��������," +
                        "         a.JSFS_NAME ��������,BRLX_NAME ��������,a.in_date ��Ժ����,'' �ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,a.YBYE,a.DBJE " +
                        "         ,a.out_date ��Ժ����,a.yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,a.gzdw ������λ,a.social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶� ,a.flag ,a.ryts " +
                        "  FROM vi_zy_vInpatient_All a " +//,ss_apprecord b,ss_arrrecord c "+
                        //						"  where a.inpatient_id=b.inpatient_id and "+
                        //						"  b.sno=c.sno and b.inpatient_id=c.inpatient_id and b.apbj=1 and  c.bdelete=0 "+
                        "  where a.inpatient_no='" + Inpatient_no + "' and flag<>10) a" +
                        "         left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                        "                       FROM ZY_CK " +
                        "                      GROUP BY INPATIENT_ID) as e " +
                        "         on a.INPATIENT_ID=e.INPATIENT_ID " +
                        "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                }
                else
                {
                    sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������," +
                        "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��,�����޶� " +
                          " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                        "   from (SELECT a.BED_NO ����,a.INPATIENT_NO סԺ��,a.NAME ����,a.SEX_NAME �Ա�,a.age ����," +
                        "         a.CUR_DEPT_NAME ��������,a.JSFS_NAME ��������,BRLX_NAME ��������,a.in_date ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,flag,ryts " +
                        "         ,a.out_date ��Ժ����,a.yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,a.gzdw ������λ,a.social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��,  YJJ_LIMIT �����޶�,a.flag ,a.ryts" +
                        "    FROM vi_zy_vInpatient_All a " +//,ss_apprecord b,ss_arrrecord c "+
                        //						"  where a.inpatient_id=b.inpatient_id and "+
                        //						"  b.sno=c.sno and b.inpatient_id=c.inpatient_id and b.apbj=1 and  c.bdelete=0 "+  
                        "  where a.inpatient_no='" + Inpatient_no + "' and flag<>10) a " +
                        "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                }
            }
            else
            {
                if (_isAll == 0)
                {
                    if (this.cb��ʾ���.Checked)
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id," + (chkHbmy.Checked ? 0 : 1) + ") δ�����ܷ���," + //Modify By Tany 2011-03-07
                           " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=" + (chkHbmy.Checked ? "0" : " a.baby_id ") + ")   �ѽ����ܷ���," +//�Ѿ��������
                            " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                            " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id," + (chkHbmy.Checked ? "-1" : "a.baby_id") + ") ���, ''as ���ɿ�," + //Modify By Tany 2011-03-07
                            "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��,�����޶� ,flag,ryts" +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����," +
                            "         CUR_DEPT_NAME ��������,JSFS_NAME ��������,BRLX_NAME ��������,xzlx_name ��������,dylx_name ��������,in_date ��Ժ����,'' �ϴδ߿�����,INPATIENT_ID,Baby_ID,DEPT_ID,YBYE,DBJE " +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                            "    FROM vi_zy_vInpatient_All " +
                            "   WHERE  inpatient_no='" + Inpatient_no + "' and flag<>10" + (chkHbmy.Checked ? " and baby_id=0 " : "") + ") a " + //Modify By Tany 2011-03-07 //WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and
                            "         left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                            "                       FROM ZY_CK " +
                            "                      GROUP BY INPATIENT_ID) as e " +
                            "         on a.INPATIENT_ID=e.INPATIENT_ID " +
                            "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                    }
                    else
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������," +
                            "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ�� , �����޶� ,flag,ryts" +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����,CUR_DEPT_NAME ��������," +
                            "         JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                            "    FROM vi_zy_vInpatient_All " +
                            "   WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + Inpatient_no + "' and flag<>10) a " +
                            "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                    }
                }
                else
                {
                    if (this.cb��ʾ���.Checked)
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,1) δ�����ܷ���," +
                            " (SELECT ISNULL(SUM(ACVALUE),0)   FROM ZY_FEE_SPECI  WHERE CHARGE_BIT = 1  AND DELETE_BIT=0  AND DISCHARGE_BIT = 1  and INPATIENT_ID=a.inpatient_id and a.baby_id=a.baby_id)  �ѽ����ܷ���," +//�Ѿ��������
                            " DBJE �������,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,2) Ԥ����,dbo.FUN_ZY_SEEKPATFEEINFO(a.inpatient_id,a.baby_id,3) δ����֧Ʊ," +
                            " dbo.FUN_ZY_SEEKPATFEEYE(a.inpatient_id,a.baby_id) ���, ''as ���ɿ�," +
                            "        ��Ժ����,e.�ϴδ߿�����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��, �����޶� ,flag,ryts" +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����," +
                            "         CUR_DEPT_NAME ��������,JSFS_NAME ��������,BRLX_NAME ��������,xzlx_name ��������,dylx_name ��������,in_date ��Ժ����,'' �ϴδ߿�����,INPATIENT_ID,Baby_ID,DEPT_ID,YBYE,DBJE ,flag ,ryts" +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ��, YJJ_LIMIT �����޶�" +
                            "    FROM vi_zy_vInpatient_All " +
                            "   WHERE inpatient_no='" + Inpatient_no + "' and flag<>10) a " +
                            "         left join ( SELECT INPATIENT_ID,MAX(CK_DATE) AS �ϴδ߿����� " +
                            "                       FROM ZY_CK " +
                            "                      GROUP BY INPATIENT_ID) as e " +
                            "         on a.INPATIENT_ID=e.INPATIENT_ID " +
                            "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                    }
                    else
                    {
                        sSql = "select ����,����,סԺ��,�Ա�,����,��������,��������,��������,��������,��������," +
                            "        ''as ���ɿ�, ��Ժ����,a.INPATIENT_ID,a.Baby_ID,a.DEPT_ID,��Ժ����,ҽ������,������λ,���֤,����,�ܴ�ҽ��, �����޶� ,flag,ryts" +
                              " ,isnull((select top 1 XJZF from ZY_YB_JSB_RJJL where DELETE_BIT=0 and inpatient_id=a.inpatient_id order by YBJS_DATE desc ) ,(select top 1 XJZF from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id=a.inpatient_id )) �ֽ�֧�� " +//add by zouchihua 2013-8-12����ֽ�֧��
                            "   from (SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,SEX_NAME �Ա�,age ����,CUR_DEPT_NAME ��������," +
                            "         JSFS_NAME ��������,BRLX_NAME ��������,in_date ��Ժ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                            "         ,out_date ��Ժ����,yblx_name ҽ������,xzlx_name ��������,dylx_name ��������,gzdw ������λ,social_no ���֤,WARD_NAME ����,zydoc_name �ܴ�ҽ�� , YJJ_LIMIT �����޶�,flag ,ryts" +
                            "    FROM vi_zy_vInpatient_All " +
                            "   WHERE inpatient_no='" + Inpatient_no + "' and flag<>10) a " +
                            "  order by dbo.Fun_GetBedToOrder(����),a.INPATIENT_ID,a.Baby_ID";
                    }
                }
            }

            this.myFunc.ShowGrid(1, sSql, this.myDataGrid1);
            Cursor.Current = Cursors.Default;
        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void bt�˳�_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btFYHZ_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0, id = 0;
            string sSql = "";

            #region ���ѡ��Ĳ��˸���
            DataTable GrdTb = (DataTable)this.myDataGrid1.DataSource;
            if (GrdTb == null) return;
            if (GrdTb.Rows.Count < 1) return;
            int iSelectRows = 0;
            for (i = 0; i <= GrdTb.Rows.Count - 1; i++)
            {   
                if (GrdTb.Rows[i]["ѡ"].ToString() == "True" && GrdTb.Rows[i]["inpatient_id"].ToString() != "")
                {
                    #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                    string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(new Guid( GrdTb.Rows[i]["INPATIENT_ID"].ToString().Trim()));
                    if (rtnSql[0] != "0")
                    {
                        continue;
                    }
                    if (rtnSql[2]!="0")
                    {
                        continue;
                    }
                    #endregion
                    iSelectRows += 1;
                }
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ���˻���ֻѡ�����Ѿ�������Ϣ�Ĳ��ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            # endregion
            //add by zouchihua 2012-9-6 ÿ�����˴�һ��
            bool Mcdy = false;
            if (checkyl.Checked == false)
                Mcdy = true;
            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {

                string date1 = "";
                string date2 = "";

                if (rbDate1.Checked == true)
                {
                    date1 = this.dtpBeginDate.Value.ToShortDateString() + " 00:00:00";
                    date2 = this.dtpBeginDate.Value.ToShortDateString() + " 23:59:59";
                }
                if (rbDate2.Checked == true)
                {
                    date1 = this.dtpBeginDate.Value.ToString();
                    date2 = this.DtpEndDate.Value.ToString();
                }
                progressBar1.Maximum = iSelectRows;
                progressBar1.Value = 0;

                rds.Tables["tabfeelist"].Clear();
                //�����µ�����
                for (j = 0; j <= GrdTb.Rows.Count - 1; j++)
                {
                    if (GrdTb.Rows[j]["INPATIENT_ID"].ToString().Trim() != "" && GrdTb.Rows[j]["ѡ"].ToString() == "True")
                    {
                        #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                        string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt( new Guid( GrdTb.Rows[j]["INPATIENT_ID"].ToString().Trim()));
                        if (rtnSql[0] != "0")
                        {
                            continue;
                        }
                        if (rtnSql[2]!="0")
                        {
                            continue;
                        }
                        #endregion
                        ////�жϲ��˵ķ����Ƿ�����ʷ��
                        //string Fee_Table = "zy_fee_speci";
                        //int nStatus = 0;

                        ////����ǲ���סԺ�ŵĲ��˲��ж��Ƿ���㲢ת��
                        //if (chkSeekZyh.Checked)
                        //    nStatus = Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select nstatus from zy_discharge where cancel_bit=0 and cz_flag=0 and inpatient_id='" + GrdTb.Rows[j]["INPATIENT_ID"].ToString() + "'"), "0"));
                        //else
                        //    nStatus = 0;

                        //if (nStatus == 0)
                        //{
                        //    Fee_Table = "zy_fee_speci";
                        //}
                        //else
                        //{
                        //    Fee_Table = "zy_fee_speci_h";
                        //}

                        //sSql = "select c.code,c.item_name ��Ŀ,sum(a.acvalue) ��� from " + Fee_Table + " a " +
                        //       "inner join jc_stat_item b on a.statitem_code=b.code " +
                        //       "inner join jc_zyfp_xm c on c.code=b.zyfp_code " +
                        //       "where a.delete_bit=0 and a.charge_bit=1 " +
                        //       "and a.inpatient_id=" + GrdTb.Rows[j]["inpatient_id"].ToString() + " and baby_id=" + GrdTb.Rows[j]["baby_id"].ToString() +
                        //       "group by c.code,c.item_name ";
                        //sSql += "union all "+
                        //       "select 'AA','�ϼ�' ��Ŀ,sum(a.acvalue) ��� from " + Fee_Table + " a " +
                        //       "inner join jc_stat_item b on a.statitem_code=b.code " +
                        //       "inner join jc_zyfp_xm c on c.code=b.zyfp_code " +
                        //       "where a.delete_bit=0 and a.charge_bit=1 " +
                        //       "and a.inpatient_id=" + GrdTb.Rows[j]["inpatient_id"].ToString() + " and baby_id=" + GrdTb.Rows[j]["baby_id"].ToString();
                        //sSql += "order by c.code";

                        //Modify by tany 2011-03-07 ���Ӻϲ�ĸӤ��ѡ��
                        sSql = "exec sp_zyhs_brfyhj '" + GrdTb.Rows[j]["inpatient_id"].ToString() + "'," + (chkHbmy.Checked ? "-1" : GrdTb.Rows[j]["baby_id"].ToString()) + ",'" + date1.ToString() + "','" + date2.ToString() + "'";

                        DataTable myTb1 = InstanceForm.BDatabase.GetDataTable(sSql);
                        if (myTb1.Rows.Count >= 1)
                        {
                            //Modify by tany 2011-08-22 ���������������һ�²�����Ϣ
                            string patSql = "select * from vi_zy_vinpatient_all where inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString() + "'" + (chkHbmy.Checked ? "" : (" and baby_id=" + GrdTb.Rows[j]["baby_id"].ToString()));
                            DataRow patDr = InstanceForm.BDatabase.GetDataRow(patSql);
                            DataTable ybfy=null;
                            if(cfg7140.Config.Trim()=="1")
                               //add by zouchihua 2013-1-21 ֻ��ĸ�ײ�ͳ��
                                ybfy= GetInpatientInfo(new Guid(GrdTb.Rows[j]["inpatient_id"].ToString()), 0, 1);

                            progressBar2.Maximum = myTb1.Rows.Count;
                            progressBar2.Value = 0;

                            //������Ϣ����ʱ���ݿ�
                            for (i = 0; i <= myTb1.Rows.Count - 1; i++)
                            {
                                id += 1;
                                //����Ϊ0����ʾ
                                if (Convert.ToDouble(Convertor.IsNull(myTb1.Rows[i]["���"], "0")) != 0)
                                {

                                    dr = rds.Tables["tabfeelist"].NewRow();
                                    dr["����"] = GrdTb.Rows[j]["����"].ToString();
                                    dr["סԺ��"] = GrdTb.Rows[j]["סԺ��"].ToString();
                                    dr["����"] = GrdTb.Rows[j]["����"].ToString();
                                    dr["����"] = GrdTb.Rows[j]["��������"].ToString();
                                    dr["��Ŀ"] = myTb1.Rows[i]["��Ŀ"].ToString();
                                    dr["���"] = myTb1.Rows[i]["���"].ToString();


                                    dr["��Ժʱ��"] = Convert.ToDateTime(GrdTb.Rows[j]["��Ժ����"]).ToShortDateString();
                                    dr["סԺ����"] = patDr["ryts"].ToString();
                                    dr["Ԥ����"] = Convert.ToDecimal(Convertor.IsNull(GrdTb.Rows[j]["Ԥ����"], "0"));
                                    dr["���"] = Convert.ToDecimal(Convertor.IsNull(GrdTb.Rows[j]["���"], "0"));
                                    if (patDr["out_date"].ToString() != "")
                                        dr["��Ժ����"] = Convert.ToDateTime(patDr["out_date"]);
                                    else
                                        dr["��Ժ����"] = DBNull.Value;
                                    dr["����ʱ��"] = DBNull.Value;
                                    dr["����ʱ��"] = DBNull.Value;
                                    dr["ҽ���ܶ�"] = DBNull.Value;
                                    dr["ͳ��֧��"] = DBNull.Value;
                                    dr["�˻�֧��"] = DBNull.Value;
                                    dr["����֧��"] = DBNull.Value;
                                    dr["�ֽ�֧��"] = DBNull.Value;
                                    dr["ҽ�����"] = DBNull.Value;
                                    dr["bz"] = GrdTb.Rows[j]["ҽ������"].ToString(); ;//��������
                                    for (int x = 0; x < 5;x++)
                                    {
                                        dr["bz" + (x + 1).ToString()] = "";
                                    }
                                        //add by zouchihua 2013-1-21
                                      if (ybfy!=null&&ybfy.Rows.Count > 0 && Convertor.IsNull(ybfy.Rows[0]["ybjs_date"], "") != "")
                                        {
                                            dr["����ʱ��"] = Convert.ToDateTime(ybfy.Rows[0]["ybjs_date"]).ToString("yyyy-MM-dd HH:mm:ss");
                                            dr["ҽ���ܶ�"] = Convert.ToDecimal(ybfy.Rows[0]["ybzfy"]);
                                            dr["ͳ��֧��"] = Convert.ToDecimal(ybfy.Rows[0]["tczf"]);
                                            dr["�˻�֧��"] = Convert.ToDecimal(ybfy.Rows[0]["zhzf"]);
                                            dr["����֧��"] = Convert.ToDecimal(ybfy.Rows[0]["qtzf"]);
                                            dr["�ֽ�֧��"] = Convert.ToDecimal(ybfy.Rows[0]["xjzf"]);
                                            dr["ҽ�����"] = Convert.ToDecimal(Convert.ToDecimal(ybfy.Rows[0]["yjk"]) - Convert.ToDecimal(ybfy.Rows[0]["xjzf"]));
                                        }

                                    rds.Tables["tabfeelist"].Rows.Add(dr);

                                }

                                progressBar2.Value += 1;
                            }
                        }

                        if (Mcdy)
                        {
                            FrmReportView frmRptView1 = null;
                            string _reportName1 = "";
                            ParameterEx[] _parameters1 = new ParameterEx[1];


                            _reportName1 = "ZYHS_���÷������.rpt";

                            _parameters1[0].Text = "��ӡ��";
                            _parameters1[0].Value = InstanceForm.BCurrentUser.Name;

                            frmRptView1 = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName1, _parameters1,true);
                        }
                        progressBar1.Value += 1;
                        progressBar2.Value = 0;
                    }
                }

                progressBar1.Value = 0;
                if (Mcdy)
                    return;
                FrmReportView frmRptView = null;
                string _reportName = "";
                ParameterEx[] _parameters = new ParameterEx[1];


                _reportName = "ZYHS_���÷������.rpt";

                _parameters[0].Text = "��ӡ��";
                _parameters[0].Value = InstanceForm.BCurrentUser.Name;

                frmRptView = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
                
                frmRptView.Show();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// �õ�������Ϣ
        /// </summary>
        /// <param name="BinID">inpatient_id</param>
        /// <param name="BabyID">baby_id</param>
        /// <param name="isMY">�Ƿ�ĸӤͬ��</param>
        /// <returns></returns>
        public DataTable GetInpatientInfo(Guid BinID, long BabyID, int isMY)
        {
            DataTable myTb = new DataTable();
            string sSql = "";
            ParameterEx[] parameters = new ParameterEx[3];

            sSql = "sp_zyhs_getbininfo";
            parameters[0].Value = BinID;
            parameters[0].Text = "@binid";
            parameters[1].Value = BabyID;
            parameters[1].Text = "@babyid";
            parameters[2].Value = isMY;
            parameters[2].Text = "@ismy";

            myTb = InstanceForm.BDatabase.GetDataTable(sSql, parameters, 60);

            //�������ݱ����
            return myTb;
        }
        private void frmFYXX_Load(object sender, EventArgs e)
        {
            //�����嵥��ӡ���Ƿ�ÿ������һ����ӡ����1=�ǣ�0=��
            SystemCfg cfg7134 = new SystemCfg(7134);
            if (cfg7134.Config.Trim() == "1")
                this.checkyl.Visible = true;
            cfg7140 = new SystemCfg(7140);
            //7083�����嵥Ĭ������Ϊ�����ǰ���죨0=���죩 Add By Tany 2010-12-30
            int cfgDay = Convert.ToInt32(Convertor.IsNull(new SystemCfg(7083).Config, "0"));
            if (cfgDay < 0)
            {
                cfgDay = 0;
            }
            this.dtpBeginDate.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-cfgDay).ToShortDateString() + " 00:00:00");
            this.DtpEndDate.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-cfgDay).ToShortDateString() + " 23:59:59");

            string ssql = "select * from jc_yb_bl where zybz=1";
            TbZfbl = InstanceForm.BDatabase.GetDataTable(ssql);

            //סԺ�ų���
            txtZyh.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);

            //���ò�ѯĬ�� 0=��Ŀ���� 1=��Ŀ��ϸ
            int bz = 0;
            try
            {
                bz = Convert.ToInt32(new SystemCfg(7065).Config);
            }
            catch (Exception ex)
            {
            }
            if (bz == 0)
            {
                rbKind1.Checked = true;
            }
            else
            {
                rbKind2.Checked = true;
            }
           

            //��ȡ�����б�
            if (_isAll != 0)
            {
                cmbWard.Visible = true;
                string sql = "";
                sql = "select '-1' ward_id,'ȫ��' ward_name union all select ward_id,ward_name from jc_ward where jgbm=" + FrmMdiMain.Jgbm + "";

                DataTable tb = FrmMdiMain.Database.GetDataTable(sql);

                cmbWard.ValueMember = "ward_id";
                cmbWard.DisplayMember = "ward_name";
                cmbWard.DataSource = tb;

                cmbWard.SelectedIndex = 0;
                this.tabControl1.Visible = false;
            }
            else
            {
                cmbWard.Visible = false;
            }
        }

        private void btSeekPat_Click(object sender, EventArgs e)
        {
            DlgInpatients dlgInpat;
            string _inpatientNo = "";

            if (isSSMZ || _isAll != 0)
            {
                dlgInpat = new DlgInpatients();
                dlgInpat.ShowDialog();
                _inpatientNo = DlgInpatients.SelectedInpatientNO;
            }
            else
            {
                dlgInpat = new DlgInpatients(InstanceForm.BCurrentDept.WardId);
                dlgInpat.ShowDialog();
                _inpatientNo = DlgInpatients.SelectedInpatientNO;
            }

            if (_inpatientNo.Trim() != "")
            {
                txtZyh.Text = _inpatientNo;
                btnSeek_Click(null, null);
            }
        }

        private void btXzqfbr_Click(object sender, EventArgs e)
        {
            if (!cb��ʾ���.Checked)
            {
                MessageBox.Show("�빴ѡ��ʾ��", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DataTable myTb = ((DataTable)myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            DlgInputBox Inputbox = new DlgInputBox("0.00", "������Ƿ�ѵĶ�ȣ��磺-100", "Ƿ�Ѳ���ѡ��");
            CheckBox cb=new CheckBox();
            cb.Checked = false;
            if (cfg7156.Config.Trim() == "1")
            {
                cb.Checked = true;
                cb.Width = 150;
                cb.ForeColor = Color.Blue;
                cb.Text = "���ֽ�֧���Ƚ�";
                Inputbox.Controls.Add(cb);
                cb.Location = new Point(10, 100); 
            }
            Inputbox.NumCtrl = true;
            Inputbox.ShowDialog();
            if (!DlgInputBox.DlgResult) return;

            if (!Convertor.IsNumeric(DlgInputBox.DlgValue))
            {
                MessageBox.Show("������һ����Ч�����֣�", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            decimal fyxz = Convert.ToDecimal(DlgInputBox.DlgValue);

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                myTb.Rows[i]["ѡ"] = false;

                myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                decimal ye = Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["���"], "0"));
                if (Convertor.IsNull(myTb.Rows[i]["��������"], "").IndexOf("ҽ��") >= 0)
                {
                    // �����ҽ���������ֽ�֧�����Ƚ�
                    if (cb.Checked)
                    {
                        //�ֽ�֧��Ϊ�գ���ô��ȡδ������ܷ���
                        ye = Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["Ԥ����"], "0")) - Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["�ֽ�֧��"], Convertor.IsNull(myTb.Rows[i]["δ�����ܷ���"], "0")));
                    }
                    else
                    {
                        ye = myFunc.GetYbye(Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["δ�����ܷ���"], "0")), Convert.ToDecimal(Convertor.IsNull(myTb.Rows[i]["Ԥ����"], "0")), new Guid(Convertor.IsNull(myTb.Rows[i]["INPATIENT_ID"], Guid.Empty.ToString())));
                    }
                }
                if (fyxz != 0)
                {
                    if (ye < fyxz)
                    {
                        myTb.Rows[i]["ѡ"] = true;
                    }
                }
                else//����Ϊ��ʱ
                {
                   if( ye<Convert.ToDecimal(myTb.Rows[i]["�����޶�"]))
                       myTb.Rows[i]["ѡ"] = true;
                }
            }
            myDataGrid1.DataSource = myTb;
        }

        private void btSx_Click(object sender, EventArgs e)
        {
            frmDJDY_Load(null, null);
        }

        private void ��ӡ�Ը����õ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bt��ӡ�����嵥_Click(null, null);
        }

        private void �߿����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�õ�������Ϣ
            DataTable GrdTb = (DataTable)this.myDataGrid1.DataSource;
            if (GrdTb == null || GrdTb.Rows.Count < 1) return;

            Cursor.Current = PubStaticFun.WaitCursor();
            try
            {
                //Modify By Tany 2010-09-28
                string[] sSql = new string[GrdTb.Rows.Count];
                string sql = "";

                string dwmc = (new SystemCfg(0002)).Config;
                string khyh = (new SystemCfg(0003)).Config;
                string zh = (new SystemCfg(0004)).Config;

                rds.Tables["BRFeeCKDHZ"].Clear();
                //�����µ�����
                for (int j = 0; j <= GrdTb.Rows.Count - 1; j++)
                {
                    if (GrdTb.Rows[j]["inpatient_id"].ToString().Trim() != "" && GrdTb.Rows[j]["ѡ"].ToString() == "True")
                    {
                        //������ʱ��SQL���
                        dr = rds.Tables["BRFeeCKDHZ"].NewRow();

                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                        dr["סԺ��"] = GrdTb.Rows[j]["סԺ��"].ToString();
                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                        dr["����"] = InstanceForm.BCurrentDept.WardName;
                        dr["��Ժ����"] = GrdTb.Rows[j]["��Ժ����"].ToString();
                        dr["��������"] = GrdTb.Rows[j]["���ɿ�"].ToString();
                        dr["��Ԥ��"] = GrdTb.Rows[j]["Ԥ����"].ToString();
                        dr["�ܷ���"] = GrdTb.Rows[j]["δ�����ܷ���"].ToString();
                        dr["���"] = GrdTb.Rows[j]["���"].ToString();

                        //add by zouchihua 2012-5-25
                        dr["�Ա�"] = GrdTb.Rows[j]["�Ա�"].ToString();
                        dr["����"] = GrdTb.Rows[j]["����"].ToString();
                        dr["����"] = GrdTb.Rows[j]["��������"].ToString();
                        dr["��������"] = GrdTb.Rows[j]["��������"].ToString();
                        //Modify By Tany 2011-03-07
                        //7085��ӡ�߿ʱ�ܷ����Ƿ����Ԥִ�еķ��� 0=���� 1=��
                        if (new SystemCfg(7085).Config == "0")
                        {
                            decimal zfy = 0;
                            string sqlDate = " and ((charge_date>=presc_date and charge_date <= getdate()) ";
                            sqlDate += " or (charge_date<presc_date and presc_date <= getdate()))";
                            string ssql = "select sum(acvalue) zfy from zy_fee_speci(nolock) where inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "'" + (chkHbmy.Checked ? "" : " and baby_id=" + GrdTb.Rows[j]["baby_id"]) + " " + sqlDate + " and delete_bit=0 and charge_bit=1 and discharge_bit=0";
                            zfy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(ssql), "0"));

                            dr["�ܷ���"] = zfy.ToString("0.00");
                            dr["���"] = Convert.ToDecimal(Convert.ToDecimal(Convertor.IsNull(GrdTb.Rows[j]["Ԥ����"], "0")) - zfy).ToString("0.00");
                        }
                        dr["��λ����"] = dwmc;
                        dr["��������"] = khyh;
                        dr["�˺�"] = zh;
                        dr["������"] = InstanceForm.BCurrentUser.Name;

                        if (GrdTb.Rows[j]["��������"].ToString().Trim().IndexOf("ҽ��") >= 0)
                        {
                            //Modify By Tany 2010-09-28 ����ҽ�����ü���
                            if (Convert.ToInt32(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult("select is_ybjs from zy_inpatient where inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "'"), "0")) == 0)
                            {
                                //û��ҽ������
                                sql = "select * from zy_yb_jsb_rjjl where delete_bit=0 and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "' order by ybjs_date desc";
                            }
                            else
                            {
                                //�Ѿ�ҽ������
                                sql = "select * from zy_yb_jsb where delete_bit=0 and cz_flag=0 and inpatient_id='" + GrdTb.Rows[j]["inpatient_id"].ToString().Trim() + "' order by ybjs_date desc";
                            }

                            DataTable ybTb = InstanceForm.BDatabase.GetDataTable(sql);

                            if (ybTb != null && ybTb.Rows.Count > 0)
                            {
                                dr["ҽ����������"] = Convert.ToDateTime(ybTb.Rows[0]["ybjs_date"]);
                                dr["ҽ���ܷ���"] = Convert.ToDecimal(ybTb.Rows[0]["zfy"]);
                                dr["ͳ��֧��"] = Convert.ToDecimal(ybTb.Rows[0]["tczf"]);
                                dr["�˻�֧��"] = Convert.ToDecimal(ybTb.Rows[0]["zhzf"]);
                                dr["����֧��"] = Convert.ToDecimal(ybTb.Rows[0]["qtzf"]);
                                dr["�ֽ�֧��"] = Convert.ToDecimal(ybTb.Rows[0]["xjzf"]);
                            }
                        }

                        rds.Tables["BRFeeCKDHZ"].Rows.Add(dr);

                        //����߿��¼
                       // sSql[j] = "insert into zy_ck(id,inpatient_id,ck_date,ck_user,ck_values,jgbm) values('" + PubStaticFun.NewGuid() + "','" + new Guid(GrdTb.Rows[j]["inpatient_id"].ToString()) + "'" +
                        //    ",'" + DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase) + "'," + InstanceForm.BCurrentUser.EmployeeId + "," + Convert.ToDecimal(GrdTb.Rows[j]["���ɿ�"].ToString().Trim() == "" ? "0" : GrdTb.Rows[j]["���ɿ�"].ToString().Trim()) + "," + FrmMdiMain.Jgbm + ")";
                        //InstanceForm.BDatabase.DoCommand(sSql);
                    }
                }

                FrmReportView fp = new FrmReportView(rds, Constant.ApplicationDirectory + "\\report\\ZYHS_�߿����.rpt", null);

                //Modify By Tany 2010-09-28 ��ӡ��Ÿ��´߿��¼
                //fp._sqlStr = sSql;

                fp.Show();
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show(err.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
           Show_Data1();
            

        }
    }
}