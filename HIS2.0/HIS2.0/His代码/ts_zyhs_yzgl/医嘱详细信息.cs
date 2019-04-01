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
using TrasenHIS.BLL;
using ts_ybznsh_interface;


namespace ts_zyhs_yzgl
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class frmYZXX : System.Windows.Forms.Form
    {
        //�Զ������
        private BaseFunc myFunc;
        public long Group_ID = 0, nType = 0, MNGType = 0, MNGType2 = 0;
        public Guid OrderID = Guid.Empty;
        public string sTitle = "";
        public bool isSSMZ = false;
        public bool isCX = false;//��ѯ
        public bool isUNCZ = false;//���������
        private SystemCfg cfg7159 = new SystemCfg(7159);//add by zouchihua 2013-8-23
        private SystemCfg cfg7191 = new SystemCfg(7191); //add by zouchihua 2014-4-4  7026����ʱ.�Ѿ������ݴ��ҩƷ�����Ƿ��Զ�ɾ������Ϣ
        private SystemCfg cfg7192 = new SystemCfg(7192);//add by zouchihua 2014-4-7  7053����ʱ��ҽ����Ŀ�˷Ѳ��Զ�������ִ�п���
        private SystemCfg cfg7207 = new SystemCfg(7207);//yaokx 2014-06-27
        private SystemCfg cfg7211 = new SystemCfg(7211);
        private SystemCfg cfg7214 = new SystemCfg(7214);//��ʱҽ���Ƿ����������

        public SystemCfg _cfg6227 = new SystemCfg(6227);//������ʿת���ʱ�� �������������ά��Ϊ�� �翪�����ո�ʽά����(20:00)��
        public SystemCfg _cfg6228 = new SystemCfg(6228);//������ʿת���ʱ���ʱ����Ĭ�ϸ�ʽ��HH$mm����

        /// <summary>
        /// add by zouchihua 2014-08-1  סԺ�Ƿ�������Ŀ����ȷ�ϣ���ҽ����Ŀ�⣩
        /// </summary>
        private SystemCfg cfg7212 = new SystemCfg(7212);
        //��������
        public bool isTSZL = false;
        //�ڷ�ҩͳ��������
        string tlfl = "";//(new SystemCfg(7048)).Config.Trim();
        //����ڷ�ҩ�Ƿ������˷�
        bool _isclkfyty = true;//(new SystemCfg(7054)).Config.Trim() == "0" ? false : true;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.Label lb5;
        private System.Windows.Forms.Label lb6;
        private System.Windows.Forms.Label lb17;
        private System.Windows.Forms.Label lb18;
        private System.Windows.Forms.Label lb19;
        private System.Windows.Forms.Label lb20;
        private System.Windows.Forms.Label lb21;
        private System.Windows.Forms.Label lb22;
        private System.Windows.Forms.Label lb23;
        private System.Windows.Forms.Label lb24;
        private System.Windows.Forms.Label lb25;
        private System.Windows.Forms.Button bt����;
        private System.Windows.Forms.Button bt�˳�;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lb11;
        private System.Windows.Forms.Label lb10;
        private System.Windows.Forms.Label lb9;
        private System.Windows.Forms.Label lb8;
        private System.Windows.Forms.Label lb7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb16;
        private System.Windows.Forms.Label lb15;
        private System.Windows.Forms.Label lb14;
        private System.Windows.Forms.Label lb13;
        private System.Windows.Forms.Label lb12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lb27;
        private System.Windows.Forms.Label lb26;
        private System.Windows.Forms.Label lb28;
        private System.Windows.Forms.Label lb29;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbÿ��ҽ��;
        private System.Windows.Forms.RadioButton rbÿ��ҽ��;
        private System.Windows.Forms.Button bt��ѡ;
        private System.Windows.Forms.Button btȫѡ;
        private DataGridEx myDataGrid1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbLX;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btȡ������;
        private System.Windows.Forms.CheckBox cb��ʾ��ɾ������;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private TrasenClasses.GeneralControls.DataGridEx dataGridEx1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbCharge;
        private System.Windows.Forms.RadioButton rbUncharge;
        private System.ComponentModel.IContainer components;
        private Button button2;
        private RadioButton rbsl;
        private RadioButton rbcs;
        private Label label28;
        private Label lblZfbl;
        private ToolTip toolTip2;
        private Label lblUnEnableCz;
        private Button btnZdb;
        private Button button3;
        public bool zczyz_notfy = false;

        //Modify By Tany 2015-12-29 ��סԺ�ű��ȫ�ֱ�������load���渳ֵ
        string _inpatientNo = "";
        string _yblx = "";
        string _xzlx = "";

        public frmYZXX()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //

            myFunc = new BaseFunc();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLX = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lb25 = new System.Windows.Forms.Label();
            this.lb24 = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lb23 = new System.Windows.Forms.Label();
            this.lb22 = new System.Windows.Forms.Label();
            this.lb21 = new System.Windows.Forms.Label();
            this.lb20 = new System.Windows.Forms.Label();
            this.lb19 = new System.Windows.Forms.Label();
            this.lb18 = new System.Windows.Forms.Label();
            this.lb17 = new System.Windows.Forms.Label();
            this.lb6 = new System.Windows.Forms.Label();
            this.lb5 = new System.Windows.Forms.Label();
            this.lb4 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.bt���� = new System.Windows.Forms.Button();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbsl = new System.Windows.Forms.RadioButton();
            this.rbcs = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btȡ������ = new System.Windows.Forms.Button();
            this.lb26 = new System.Windows.Forms.Label();
            this.lb27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lb11 = new System.Windows.Forms.Label();
            this.lb10 = new System.Windows.Forms.Label();
            this.lb9 = new System.Windows.Forms.Label();
            this.lb8 = new System.Windows.Forms.Label();
            this.lb7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnZdb = new System.Windows.Forms.Button();
            this.lb28 = new System.Windows.Forms.Label();
            this.lb29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lb16 = new System.Windows.Forms.Label();
            this.lb15 = new System.Windows.Forms.Label();
            this.lb14 = new System.Windows.Forms.Label();
            this.lb13 = new System.Windows.Forms.Label();
            this.lb12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cb��ʾ��ɾ������ = new System.Windows.Forms.CheckBox();
            this.rbÿ��ҽ�� = new System.Windows.Forms.RadioButton();
            this.rbÿ��ҽ�� = new System.Windows.Forms.RadioButton();
            this.bt��ѡ = new System.Windows.Forms.Button();
            this.btȫѡ = new System.Windows.Forms.Button();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridEx1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbUncharge = new System.Windows.Forms.RadioButton();
            this.rbCharge = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.lblZfbl = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.lblUnEnableCz = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ҽ�����ͣ�";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(508, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "¼����ң�";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "ҽ�����ݣ�";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "������";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(120, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "��λ��";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(304, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Ƶ�ʣ�";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(228, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "������";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(532, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "�÷���";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(208, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "¼��ʱ�䣺";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(404, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 18;
            this.label19.Text = "¼���ˣ�";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(396, 56);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 19;
            this.label20.Text = "���٣�";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(508, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 16);
            this.label21.TabIndex = 20;
            this.label21.Text = "ִ�п��ң�";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbLX);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lb25);
            this.groupBox1.Controls.Add(this.lb24);
            this.groupBox1.Controls.Add(this.lb23);
            this.groupBox1.Controls.Add(this.lb22);
            this.groupBox1.Controls.Add(this.lb21);
            this.groupBox1.Controls.Add(this.lb20);
            this.groupBox1.Controls.Add(this.lb19);
            this.groupBox1.Controls.Add(this.lb18);
            this.groupBox1.Controls.Add(this.lb17);
            this.groupBox1.Controls.Add(this.lb6);
            this.groupBox1.Controls.Add(this.lb5);
            this.groupBox1.Controls.Add(this.lb4);
            this.groupBox1.Controls.Add(this.lb1);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 76);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "������Ϣ";
            // 
            // lbLX
            // 
            this.lbLX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLX.Location = new System.Drawing.Point(356, 36);
            this.lbLX.Name = "lbLX";
            this.lbLX.Size = new System.Drawing.Size(32, 16);
            this.lbLX.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(308, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 16);
            this.label22.TabIndex = 49;
            this.label22.Text = "���ͣ�";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb25
            // 
            this.lb25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb25.Location = new System.Drawing.Point(456, 56);
            this.lb25.Name = "lb25";
            this.lb25.Size = new System.Drawing.Size(72, 16);
            this.lb25.TabIndex = 48;
            // 
            // lb24
            // 
            this.lb24.ContextMenu = this.contextMenu1;
            this.lb24.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb24.Location = new System.Drawing.Point(580, 56);
            this.lb24.Name = "lb24";
            this.lb24.Size = new System.Drawing.Size(128, 16);
            this.lb24.TabIndex = 47;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "���Ӳ�ҩ��ҩ��";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // lb23
            // 
            this.lb23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb23.Location = new System.Drawing.Point(352, 56);
            this.lb23.Name = "lb23";
            this.lb23.Size = new System.Drawing.Size(48, 16);
            this.lb23.TabIndex = 46;
            // 
            // lb22
            // 
            this.lb22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb22.Location = new System.Drawing.Point(276, 56);
            this.lb22.Name = "lb22";
            this.lb22.Size = new System.Drawing.Size(28, 16);
            this.lb22.TabIndex = 45;
            // 
            // lb21
            // 
            this.lb21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb21.Location = new System.Drawing.Point(168, 56);
            this.lb21.Name = "lb21";
            this.lb21.Size = new System.Drawing.Size(52, 16);
            this.lb21.TabIndex = 44;
            // 
            // lb20
            // 
            this.lb20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb20.Location = new System.Drawing.Point(72, 56);
            this.lb20.Name = "lb20";
            this.lb20.Size = new System.Drawing.Size(48, 16);
            this.lb20.TabIndex = 43;
            // 
            // lb19
            // 
            this.lb19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb19.Location = new System.Drawing.Point(460, 36);
            this.lb19.Name = "lb19";
            this.lb19.Size = new System.Drawing.Size(40, 16);
            this.lb19.TabIndex = 42;
            // 
            // lb18
            // 
            this.lb18.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb18.Location = new System.Drawing.Point(576, 36);
            this.lb18.Name = "lb18";
            this.lb18.Size = new System.Drawing.Size(132, 16);
            this.lb18.TabIndex = 41;
            // 
            // lb17
            // 
            this.lb17.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb17.Location = new System.Drawing.Point(76, 36);
            this.lb17.Name = "lb17";
            this.lb17.Size = new System.Drawing.Size(228, 16);
            this.lb17.TabIndex = 40;
            // 
            // lb6
            // 
            this.lb6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb6.Location = new System.Drawing.Point(460, 16);
            this.lb6.Name = "lb6";
            this.lb6.Size = new System.Drawing.Size(48, 16);
            this.lb6.TabIndex = 29;
            // 
            // lb5
            // 
            this.lb5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb5.Location = new System.Drawing.Point(576, 16);
            this.lb5.Name = "lb5";
            this.lb5.Size = new System.Drawing.Size(132, 16);
            this.lb5.TabIndex = 28;
            // 
            // lb4
            // 
            this.lb4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb4.Location = new System.Drawing.Point(274, 16);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(124, 16);
            this.lb4.TabIndex = 27;
            // 
            // lb1
            // 
            this.lb1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb1.Location = new System.Drawing.Point(76, 16);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(132, 16);
            this.lb1.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(392, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 16);
            this.label25.TabIndex = 21;
            this.label25.Text = "ִ�д�����";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bt����
            // 
            this.bt����.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt����.Enabled = false;
            this.bt����.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt����.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt����.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt����.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt����.ImageIndex = 4;
            this.bt����.Location = new System.Drawing.Point(907, 24);
            this.bt����.Name = "bt����";
            this.bt����.Size = new System.Drawing.Size(97, 24);
            this.bt����.TabIndex = 57;
            this.bt����.Text = "����(&C)";
            this.bt����.Click += new System.EventHandler(this.bt����_Click);
            // 
            // bt�˳�
            // 
            this.bt�˳�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(907, 52);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(97, 24);
            this.bt�˳�.TabIndex = 55;
            this.bt�˳�.Text = "�˳�(&E)";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rbsl);
            this.groupBox4.Controls.Add(this.rbcs);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(724, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 76);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "������������� ";
            // 
            // rbsl
            // 
            this.rbsl.AutoSize = true;
            this.rbsl.Location = new System.Drawing.Point(113, 46);
            this.rbsl.Name = "rbsl";
            this.rbsl.Size = new System.Drawing.Size(47, 16);
            this.rbsl.TabIndex = 63;
            this.rbsl.Text = "����";
            this.rbsl.UseVisualStyleBackColor = true;
            this.rbsl.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbcs
            // 
            this.rbcs.AutoSize = true;
            this.rbcs.Checked = true;
            this.rbcs.ForeColor = System.Drawing.Color.Maroon;
            this.rbcs.Location = new System.Drawing.Point(112, 15);
            this.rbcs.Name = "rbcs";
            this.rbcs.Size = new System.Drawing.Size(47, 16);
            this.rbcs.TabIndex = 62;
            this.rbcs.TabStop = true;
            this.rbcs.Text = "����";
            this.rbcs.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(90, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 16);
            this.label17.TabIndex = 61;
            this.label17.Text = "��";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(40, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 16);
            this.label10.TabIndex = 60;
            this.label10.Text = "��";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(8, 44);
            this.textBox1.MaxLength = 0;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 26);
            this.textBox1.TabIndex = 58;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 59;
            this.label8.Text = "ѡ��ÿ   ҽ������ ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 4;
            this.button1.Location = new System.Drawing.Point(896, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 68);
            this.button1.TabIndex = 59;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btȡ������);
            this.groupBox5.Controls.Add(this.lb26);
            this.groupBox5.Controls.Add(this.lb27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.lb11);
            this.groupBox5.Controls.Add(this.lb10);
            this.groupBox5.Controls.Add(this.lb9);
            this.groupBox5.Controls.Add(this.lb8);
            this.groupBox5.Controls.Add(this.lb7);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(4, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1012, 40);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ҽ����ʼ��Ϣ";
            // 
            // btȡ������
            // 
            this.btȡ������.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btȡ������.Enabled = false;
            this.btȡ������.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btȡ������.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btȡ������.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btȡ������.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btȡ������.ImageIndex = 4;
            this.btȡ������.Location = new System.Drawing.Point(852, 0);
            this.btȡ������.Name = "btȡ������";
            this.btȡ������.Size = new System.Drawing.Size(66, 38);
            this.btȡ������.TabIndex = 89;
            this.btȡ������.Text = "ȡ������(&Q)";
            this.btȡ������.Visible = false;
            this.btȡ������.Click += new System.EventHandler(this.btȡ������_Click);
            // 
            // lb26
            // 
            this.lb26.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb26.Location = new System.Drawing.Point(720, 20);
            this.lb26.Name = "lb26";
            this.lb26.Size = new System.Drawing.Size(62, 16);
            this.lb26.TabIndex = 49;
            // 
            // lb27
            // 
            this.lb27.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb27.Location = new System.Drawing.Point(784, 20);
            this.lb27.Name = "lb27";
            this.lb27.Size = new System.Drawing.Size(124, 16);
            this.lb27.TabIndex = 48;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(612, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 16);
            this.label26.TabIndex = 46;
            this.label26.Text = "�˶Ի�ʿ��ʱ�䣺";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb11
            // 
            this.lb11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb11.Location = new System.Drawing.Point(960, 20);
            this.lb11.Name = "lb11";
            this.lb11.Size = new System.Drawing.Size(44, 16);
            this.lb11.TabIndex = 44;
            // 
            // lb10
            // 
            this.lb10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb10.Location = new System.Drawing.Point(420, 20);
            this.lb10.Name = "lb10";
            this.lb10.Size = new System.Drawing.Size(62, 16);
            this.lb10.TabIndex = 43;
            // 
            // lb9
            // 
            this.lb9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb9.Location = new System.Drawing.Point(488, 20);
            this.lb9.Name = "lb9";
            this.lb9.Size = new System.Drawing.Size(124, 16);
            this.lb9.TabIndex = 42;
            // 
            // lb8
            // 
            this.lb8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb8.Location = new System.Drawing.Point(258, 20);
            this.lb8.Name = "lb8";
            this.lb8.Size = new System.Drawing.Size(56, 16);
            this.lb8.TabIndex = 41;
            // 
            // lb7
            // 
            this.lb7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb7.Location = new System.Drawing.Point(74, 20);
            this.lb7.Name = "lb7";
            this.lb7.Size = new System.Drawing.Size(124, 16);
            this.lb7.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "��ʼʱ�䣺";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(182, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "����ҽ����";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(316, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "ת����ʿ��ʱ�䣺";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(912, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 16);
            this.label23.TabIndex = 39;
            this.label23.Text = "�״Σ�";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.btnZdb);
            this.groupBox6.Controls.Add(this.lb28);
            this.groupBox6.Controls.Add(this.lb29);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.lb16);
            this.groupBox6.Controls.Add(this.lb15);
            this.groupBox6.Controls.Add(this.lb14);
            this.groupBox6.Controls.Add(this.lb13);
            this.groupBox6.Controls.Add(this.lb12);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(4, 132);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1012, 40);
            this.groupBox6.TabIndex = 61;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ҽ��ֹͣ��Ϣ";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 4;
            this.button3.Location = new System.Drawing.Point(867, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 38);
            this.button3.TabIndex = 91;
            this.button3.Text = "ȡ�����(&R)";
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnZdb
            // 
            this.btnZdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZdb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZdb.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZdb.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnZdb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZdb.ImageIndex = 4;
            this.btnZdb.Location = new System.Drawing.Point(814, 2);
            this.btnZdb.Name = "btnZdb";
            this.btnZdb.Size = new System.Drawing.Size(51, 38);
            this.btnZdb.TabIndex = 90;
            this.btnZdb.Text = "ת���(&P)";
            this.btnZdb.Click += new System.EventHandler(this.btnZdb_Click);
            // 
            // lb28
            // 
            this.lb28.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb28.Location = new System.Drawing.Point(720, 20);
            this.lb28.Name = "lb28";
            this.lb28.Size = new System.Drawing.Size(62, 16);
            this.lb28.TabIndex = 52;
            // 
            // lb29
            // 
            this.lb29.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb29.Location = new System.Drawing.Point(784, 20);
            this.lb29.Name = "lb29";
            this.lb29.Size = new System.Drawing.Size(124, 16);
            this.lb29.TabIndex = 51;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(612, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 16);
            this.label27.TabIndex = 50;
            this.label27.Text = "�˶Ի�ʿ��ʱ�䣺";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb16
            // 
            this.lb16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb16.Location = new System.Drawing.Point(960, 20);
            this.lb16.Name = "lb16";
            this.lb16.Size = new System.Drawing.Size(44, 16);
            this.lb16.TabIndex = 49;
            // 
            // lb15
            // 
            this.lb15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb15.Location = new System.Drawing.Point(420, 20);
            this.lb15.Name = "lb15";
            this.lb15.Size = new System.Drawing.Size(62, 16);
            this.lb15.TabIndex = 48;
            // 
            // lb14
            // 
            this.lb14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb14.Location = new System.Drawing.Point(488, 20);
            this.lb14.Name = "lb14";
            this.lb14.Size = new System.Drawing.Size(124, 16);
            this.lb14.TabIndex = 47;
            // 
            // lb13
            // 
            this.lb13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb13.Location = new System.Drawing.Point(258, 20);
            this.lb13.Name = "lb13";
            this.lb13.Size = new System.Drawing.Size(56, 16);
            this.lb13.TabIndex = 46;
            // 
            // lb12
            // 
            this.lb12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb12.Location = new System.Drawing.Point(74, 20);
            this.lb12.Name = "lb12";
            this.lb12.Size = new System.Drawing.Size(124, 16);
            this.lb12.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "ֹͣʱ�䣺";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(912, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 16);
            this.label24.TabIndex = 44;
            this.label24.Text = "ĩ�Σ�";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(182, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "ͣ��ҽ����";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(310, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 43;
            this.label11.Text = "ת����ʿ��ʱ�䣺";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 732);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 8);
            this.progressBar1.TabIndex = 87;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cb��ʾ��ɾ������);
            this.panel1.Controls.Add(this.rbÿ��ҽ��);
            this.panel1.Controls.Add(this.rbÿ��ҽ��);
            this.panel1.Controls.Add(this.bt��ѡ);
            this.panel1.Controls.Add(this.btȫѡ);
            this.panel1.Controls.Add(this.myDataGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 518);
            this.panel1.TabIndex = 88;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(899, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 93;
            this.button2.Text = "ȡ����ҩƷ����";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb��ʾ��ɾ������
            // 
            this.cb��ʾ��ɾ������.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cb��ʾ��ɾ������.Checked = true;
            this.cb��ʾ��ɾ������.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb��ʾ��ɾ������.Location = new System.Drawing.Point(464, 4);
            this.cb��ʾ��ɾ������.Name = "cb��ʾ��ɾ������";
            this.cb��ʾ��ɾ������.Size = new System.Drawing.Size(112, 16);
            this.cb��ʾ��ɾ������.TabIndex = 92;
            this.cb��ʾ��ɾ������.Text = "��ʾ��ɾ������";
            this.cb��ʾ��ɾ������.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb��ʾ��ɾ������.UseVisualStyleBackColor = false;
            this.cb��ʾ��ɾ������.CheckedChanged += new System.EventHandler(this.cb��ʾ��ɾ������_CheckedChanged);
            // 
            // rbÿ��ҽ��
            // 
            this.rbÿ��ҽ��.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbÿ��ҽ��.Enabled = false;
            this.rbÿ��ҽ��.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbÿ��ҽ��.Location = new System.Drawing.Point(660, 3);
            this.rbÿ��ҽ��.Name = "rbÿ��ҽ��";
            this.rbÿ��ҽ��.Size = new System.Drawing.Size(72, 18);
            this.rbÿ��ҽ��.TabIndex = 91;
            this.rbÿ��ҽ��.Text = "ÿ��ҽ��";
            this.rbÿ��ҽ��.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rbÿ��ҽ��.UseVisualStyleBackColor = false;
            this.rbÿ��ҽ��.Click += new System.EventHandler(this.rbÿ��ҽ��_Click);
            // 
            // rbÿ��ҽ��
            // 
            this.rbÿ��ҽ��.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbÿ��ҽ��.Checked = true;
            this.rbÿ��ҽ��.Enabled = false;
            this.rbÿ��ҽ��.Location = new System.Drawing.Point(580, 3);
            this.rbÿ��ҽ��.Name = "rbÿ��ҽ��";
            this.rbÿ��ҽ��.Size = new System.Drawing.Size(72, 18);
            this.rbÿ��ҽ��.TabIndex = 90;
            this.rbÿ��ҽ��.TabStop = true;
            this.rbÿ��ҽ��.Text = "ÿ��ҽ��";
            this.rbÿ��ҽ��.UseVisualStyleBackColor = false;
            this.rbÿ��ҽ��.Click += new System.EventHandler(this.rbÿ��ҽ��_Click);
            // 
            // bt��ѡ
            // 
            this.bt��ѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.bt��ѡ.Enabled = false;
            this.bt��ѡ.Location = new System.Drawing.Point(828, 1);
            this.bt��ѡ.Name = "bt��ѡ";
            this.bt��ѡ.Size = new System.Drawing.Size(56, 20);
            this.bt��ѡ.TabIndex = 89;
            this.bt��ѡ.Text = "��ѡ(&F)";
            this.bt��ѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt��ѡ.UseVisualStyleBackColor = false;
            this.bt��ѡ.Click += new System.EventHandler(this.bt��ѡ_Click);
            // 
            // btȫѡ
            // 
            this.btȫѡ.BackColor = System.Drawing.Color.PaleGreen;
            this.btȫѡ.Enabled = false;
            this.btȫѡ.Location = new System.Drawing.Point(756, 1);
            this.btȫѡ.Name = "btȫѡ";
            this.btȫѡ.Size = new System.Drawing.Size(56, 20);
            this.btȫѡ.TabIndex = 88;
            this.btȫѡ.Text = "ȫѡ(&A)";
            this.btȫѡ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btȫѡ.UseVisualStyleBackColor = false;
            this.btȫѡ.Click += new System.EventHandler(this.btȫѡ_Click);
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CaptionText = "������ϸ";
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Enabled = false;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1004, 518);
            this.myDataGrid1.TabIndex = 87;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.toolTip1.SetToolTip(this.myDataGrid1, "��ɫ     =   ���ñ�ɾ�� \n��ɫ     =   δ����  δ���  δ���� \n�ں�ɫ =   δ����  δ���    ����  \nǳ��ɫ =   �Ѽ��� " +
                    " δ���  δ����  \nǳ��ɫ =   �Ѽ���  δ���    ����  \n��ɫ     =   �Ѽ���  �����  δ����  \n��ɫ     =   �Ѽ���  " +
                    "�����    ����  \n��ɫ     =   �ѽ���  \n");
            this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridEx1
            // 
            this.dataGridEx1.AllowSorting = false;
            this.dataGridEx1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridEx1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridEx1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridEx1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridEx1.CaptionText = "���û���";
            this.dataGridEx1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.dataGridEx1.DataMember = "";
            this.dataGridEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEx1.Enabled = false;
            this.dataGridEx1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridEx1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridEx1.Name = "dataGridEx1";
            this.dataGridEx1.ReadOnly = true;
            this.dataGridEx1.Size = new System.Drawing.Size(1004, 518);
            this.dataGridEx1.TabIndex = 88;
            this.dataGridEx1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dataGridEx1;
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 100000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 178);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 544);
            this.tabControl1.TabIndex = 90;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1004, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "������ϸ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1004, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "���û���";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbUncharge);
            this.panel2.Controls.Add(this.rbCharge);
            this.panel2.Controls.Add(this.rbAll);
            this.panel2.Controls.Add(this.dataGridEx1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 518);
            this.panel2.TabIndex = 0;
            // 
            // rbUncharge
            // 
            this.rbUncharge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbUncharge.Location = new System.Drawing.Point(672, 3);
            this.rbUncharge.Name = "rbUncharge";
            this.rbUncharge.Size = new System.Drawing.Size(72, 18);
            this.rbUncharge.TabIndex = 93;
            this.rbUncharge.Text = "δ����";
            this.rbUncharge.UseVisualStyleBackColor = false;
            this.rbUncharge.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // rbCharge
            // 
            this.rbCharge.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbCharge.Location = new System.Drawing.Point(592, 3);
            this.rbCharge.Name = "rbCharge";
            this.rbCharge.Size = new System.Drawing.Size(72, 18);
            this.rbCharge.TabIndex = 92;
            this.rbCharge.Text = "�Ѽ���";
            this.rbCharge.UseVisualStyleBackColor = false;
            this.rbCharge.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // rbAll
            // 
            this.rbAll.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(522, 3);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(72, 18);
            this.rbAll.TabIndex = 91;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "ȫ��";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.Click += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(149, 176);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 18);
            this.label28.TabIndex = 91;
            this.label28.Text = "�Ը�������";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblZfbl
            // 
            this.lblZfbl.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZfbl.ForeColor = System.Drawing.Color.Red;
            this.lblZfbl.Location = new System.Drawing.Point(252, 176);
            this.lblZfbl.Name = "lblZfbl";
            this.lblZfbl.Size = new System.Drawing.Size(150, 18);
            this.lblZfbl.TabIndex = 92;
            // 
            // toolTip2
            // 
            this.toolTip2.AutoPopDelay = 100000;
            this.toolTip2.InitialDelay = 500;
            this.toolTip2.ReshowDelay = 100;
            // 
            // lblUnEnableCz
            // 
            this.lblUnEnableCz.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUnEnableCz.Location = new System.Drawing.Point(426, 175);
            this.lblUnEnableCz.Name = "lblUnEnableCz";
            this.lblUnEnableCz.Size = new System.Drawing.Size(578, 23);
            this.lblUnEnableCz.TabIndex = 93;
            // 
            // frmYZXX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1016, 725);
            this.Controls.Add(this.lblUnEnableCz);
            this.Controls.Add(this.lblZfbl);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.bt����);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.bt�˳�);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Name = "frmYZXX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��ϸ��Ϣ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYZXX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEx1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmYZXX_Load(object sender, System.EventArgs e)
        {
            //�����رջ��߳���ҽ�����˵��Ͳ��ܳ�����
            if (cfg7214.Config.Trim() != "1" ||
                (this.MNGType == 0 || this.MNGType == 2)
                )
            {
                this.rbsl.Visible = false;
                this.rbcs.Visible = false;
            }
            else
            {
                this.rbsl.Visible = true;
                this.rbcs.Visible = true;
            }
            if (cfg7211.Config.Trim() == "1")
                this.button2.Visible = true;
            if (FrmMdiMain.CurrentUser.IsAdministrator
                || (myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId) && new SystemCfg(7082).Config == "1"))//Modify By Tany 2010-12-28 7082�Ƿ�����ʿ��ȡ������ 0=���� 1=��
            {
                btȡ������.Visible = true;
            }
            else
            {
                btȡ������.Visible = false;
            }
            //7090�Ƿ������������ 0=���� 1=�� Add By tany 2011-06-17
            if (new SystemCfg(7090).Config == "0")
            {
                isUNCZ = true;
            }
            //7092�Ƿ��������ҩƷ���� 0=���� 1=�� Add By tany 2011-06-20
            else if ((nType == 1 || nType == 2 || nType == 3) && new SystemCfg(7092).Config == "0")
            {
                isUNCZ = true;
            }
            //7093�Ƿ����������Ŀ���� 0=���� 1=�� Add By tany 2011-06-20
            else if (nType != 1 && nType != 2 && nType != 3 && new SystemCfg(7093).Config == "0")
            {
                isUNCZ = true;
            }
            Cursor.Current = PubStaticFun.WaitCursor();

            //��ʾ������Ϣ
            string sSql = @"SELECT     
						CASE A.MNGTYPE WHEN 0 THEN '����ҽ��' 
						WHEN 1 THEN '��ʱҽ��' WHEN 5 THEN '��ʱҽ��' 
						WHEN 2 THEN '�����˵�' ELSE '��ʱ�˵�' END AS MNGTYPE,    
						CASE A.STATUS_FLAG WHEN 1 THEN 'δת��' 
						WHEN 2 THEN '��ת��' WHEN 3 THEN 'δֹͣת��' 
						WHEN 4 THEN '��ֹͣת��' WHEN 5 THEN '�����' END STATUS_FLAG,    
						A.ORDER_ID,    A.BOOK_DATE,    b.name AS OPER_DEPT, 
						c.name AS OPER_NAME,     A.ORDER_BDATE,  
						d.name  AS BDOC_NAME, A.AUDITING_DATE,    
						e.name AS AUDIT_NAME, A.AUDITING_DATE1, 
						f.name AS AUDIT_NAME1,A.FIRST_TIMES,    
						A.ORDER_EDATE,  g.name AS EDOC_NAME, 
						A.ORDER_EUDATE,     h.name  AS EUSER_NAME, 
						A.ORDER_EUDATE1,i.name AS EUSER_NAME1,A.TERMINAL_TIMES,    
						A.ORDER_CONTEXT, k.name  AS EXEC_DEPT, J.EXEC_NUM,    
						A.NUM,A.UNIT,A.DOSAGE,A.FREQUENCY,ltrim(rtrim(A.ORDER_USAGE)) ";
            if (nType == 3)
            {
                sSql += @" + case when zd.order_id is not null then '[����]' else '[�Լ�]' end ";
            }
            //Modify By Tany 2014-12-30 ����zfbl��ʾ
            sSql += @"as ORDER_USAGE,A.DROPSPER,A.HOITEM_ID,(isnull(a.zfbl,1)*100) zfbl FROM ZY_ORDERRECORD A  
						left join jc_dept_property b on a.dept_id=b.dept_id
						left join jc_employee_property c on a.OPERATOR=c.employee_id
						left join jc_employee_property d on a.ORDER_DOC=d.employee_id
						left join jc_employee_property e on a.AUDITING_USER=e.employee_id
						left join jc_employee_property f on a.AUDITING_USER1=f.employee_id
						left join jc_employee_property g on a.ORDER_EDOC=g.employee_id
						left join jc_employee_property h on a.ORDER_EUSER=h.employee_id
						left join jc_employee_property i on a.ORDER_EUSER1=i.employee_id
						left join jc_dept_property k on a.EXEC_DEPT=k.dept_id";

            if (this.nType != 3)
            {
                sSql += " , (SELECT COUNT(*) AS EXEC_NUM FROM ZY_ORDEREXEC WHERE isanalyzed<>0 and ORDER_ID='" + this.OrderID + "' ) J  WHERE A.ORDER_ID='" + this.OrderID + "'";
            }
            else
            {
                //�в�ҩ
                sSql += " left join (SELECT order_id,COUNT(order_id) AS EXEC_NUM FROM ZY_ORDEREXEC WHERE isanalyzed<>0 and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " group by order_id) J on A.Order_ID=j.Order_ID " +
                    "   left join zy_decoct zd on a.inpatient_id=zd.inpatient_id and a.group_id=zd.group_id " +
                    "   where a.delete_bit=0 and a.group_id=" + this.Group_ID + " and a.ntype=3" +
                    "         and a.inpatient_id='" + ClassStatic.Current_BinID + "' and a.baby_id=" + ClassStatic.Current_BabyID;
            }

            DataTable myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
            if (myTempTb.Rows.Count == 0) return;

            this.lb1.Text = myTempTb.Rows[0]["MNGTYPE"].ToString().Trim() + "(" + myTempTb.Rows[0]["STATUS_FLAG"].ToString().Trim() + ")";
            if (this.nType != 3)
            {
                this.lb17.Text = myTempTb.Rows[0]["ORDER_CONTEXT"].ToString().Trim();
            }
            else
            {
                this.lb17.Text = "�в�ҩ����(" + myTempTb.Rows[0]["ORDER_CONTEXT"].ToString().Trim() + "��)";
            }
            this.lb4.Text = myTempTb.Rows[0]["BOOK_DATE"].ToString().Trim();
            this.lb5.Text = myTempTb.Rows[0]["OPER_DEPT"].ToString().Trim();
            this.lb6.Text = myTempTb.Rows[0]["OPER_NAME"].ToString().Trim();
            this.lb7.Text = myTempTb.Rows[0]["ORDER_BDATE"].ToString().Trim();
            this.lb8.Text = myTempTb.Rows[0]["BDOC_NAME"].ToString().Trim();
            this.lb9.Text = myTempTb.Rows[0]["AUDITING_DATE"].ToString().Trim();
            this.lb10.Text = myTempTb.Rows[0]["AUDIT_NAME"].ToString().Trim();
            this.lb27.Text = myTempTb.Rows[0]["AUDITING_DATE1"].ToString().Trim();
            this.lb26.Text = myTempTb.Rows[0]["AUDIT_NAME1"].ToString().Trim();
            this.lb11.Text = myTempTb.Rows[0]["FIRST_TIMES"].ToString().Trim();
            this.lb18.Text = myTempTb.Rows[0]["EXEC_DEPT"].ToString().Trim();
            this.lb19.Text = myTempTb.Rows[0]["EXEC_NUM"].ToString().Trim();
            this.lb20.Text = myTempTb.Rows[0]["NUM"].ToString().Trim();
            this.lb21.Text = myTempTb.Rows[0]["UNIT"].ToString().Trim();
            this.lb22.Text = myTempTb.Rows[0]["DOSAGE"].ToString().Trim();
            this.lb23.Text = myTempTb.Rows[0]["FREQUENCY"].ToString().Trim();
            this.lb24.Text = myTempTb.Rows[0]["ORDER_USAGE"].ToString().Trim();
            this.lb25.Text = myTempTb.Rows[0]["DROPSPER"].ToString().Trim();
            this.lbLX.Text = GetOrderTypeName(nType);

            //Add By Tany 2014-12-30
            int zfbl = Convert.ToInt32(myTempTb.Rows[0]["zfbl"]);
            this.lblZfbl.Text = zfbl + "%";
            if (zfbl == 0)
            {
                label28.ForeColor = Color.Green;
                lblZfbl.ForeColor = Color.Green;
            }
            else if (zfbl == 100)
            {
                label28.ForeColor = Color.Red;
                lblZfbl.ForeColor = Color.Red;
            }
            else
            {
                label28.ForeColor = Color.Blue;
                lblZfbl.ForeColor = Color.Blue;
            }

            if (this.MNGType == 0 || this.MNGType == 2)
            {
                this.groupBox6.Enabled = true;
                this.lb12.Text = myTempTb.Rows[0]["ORDER_EDATE"].ToString().Trim();
                this.lb13.Text = myTempTb.Rows[0]["EDOC_NAME"].ToString().Trim();
                this.lb14.Text = myTempTb.Rows[0]["ORDER_EUDATE"].ToString().Trim();
                this.lb15.Text = myTempTb.Rows[0]["EUSER_NAME"].ToString().Trim();
                this.lb28.Text = myTempTb.Rows[0]["ORDER_EUDATE1"].ToString().Trim();
                this.lb29.Text = myTempTb.Rows[0]["EUSER_NAME1"].ToString().Trim();
                this.lb16.Text = myTempTb.Rows[0]["TERMINAL_TIMES"].ToString().Trim();
            }

            if (this.lb19.Text.ToString().Trim() != "" && this.lb19.Text.ToString().Trim() != "0")
            {
                this.groupBox4.Enabled = true;
                this.bt����.Enabled = true;
                this.btȡ������.Enabled = true;
                this.rbÿ��ҽ��.Enabled = true;
                this.rbÿ��ҽ��.Enabled = true;
                this.btȫѡ.Enabled = true;
                this.bt��ѡ.Enabled = true;
                this.myDataGrid1.Enabled = true;

                this.ShowData();

                this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
                string[] GrdMappingName ={"ѡ", "ҽ������","Ƶ��","����","���","����","��λ","����","����","����","���",
										 "������Ϣ","ִ�п���","������Ϣ","��ҩ��Ϣ","��������","charge_bit", "finish_bit","delete_bit",
                                         "Order_ID","ID","EXECDEPT_ID","dept_br","dept_id","item_code","day1","day2","���ͻ�ʿ","����Ա",
                                         "����ҩ","isJZ","jz_flag","DISCHARGE_BIT","����","iskdksly","xmly",//36
                                         "��ҩ����",
                    "ҩƷ����","ҩƷ����",
                    "��ҩʱ��","��ҩ��","��ҩ����","��ҩ����","������","����ʱ��","type","statitem_code","ת���","PRESCRIPTION_ID"
                    //,"zfbl"
                };//�����Ǹ������õ�//Add By Tany 2010-12-15 ����statitem_code
                int[] GrdWidth ={ 2, 10, 4, 24, 10, 6, 6, 4, 4, 8, 8, 12, 10, 12, 12, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8,
                    8,8
                    ,15, 8, 10, 8, 8, 15, 0, 0, 6 , 0};
                int[] Alignment ={ 0, 0, 0, 0, 0, 2, 1, 2, 2, 2, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2,
                    2,2
                    ,0, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                this.InitGridYZ(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);
                PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);//ȥ������

                this.dataGridEx1.TableStyles[0].GridColumnStyles.Clear();
                string[] GrdMappingName1 ={ "����", "���", "����", "��λ", "����", "���" };
                int[] GrdWidth1 ={ 40, 16, 12, 6, 16, 16 };
                int[] Alignment1 ={ 0, 0, 2, 1, 2, 2, 2 };
                int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0 };
                myFunc.InitGrid(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.dataGridEx1);
                PubStaticFun.ModifyDataGridStyle(dataGridEx1, 0);
            }
            this.Text = this.sTitle;
            //add by zouchihua 2013-9-11 ����ǲ���ҩƷ����ô�Ͳ��������
            if (this.zczyz_notfy && !(nType == 1 || nType == 2 || nType == 3))
                isUNCZ = true;
            if (isCX || isUNCZ)
            {
                this.groupBox4.Enabled = false;
                this.textBox1.Enabled = false;
                this.bt����.Enabled = false;
                this.btȡ������.Enabled = false;
                this.rbÿ��ҽ��.Enabled = false;
                this.rbÿ��ҽ��.Enabled = false;
                this.btȫѡ.Enabled = false;
                this.bt��ѡ.Enabled = false;
                //				this.myDataGrid1.Enabled=false;
            }
            //����ȡ������ add by zouchihua
            if (zczyz_notfy)
                this.btȡ������.Enabled = false;
            //�ڷ�ҩͳ��������
            tlfl = (new SystemCfg(7048)).Config.Trim();
            //����ڷ�ҩ�Ƿ������˷�
            //7054������Ϊ������д����סԺ�ţ������������Ƿ������� Modify By Tany 2015-06-04
            string cfg7054 = (new SystemCfg(7054)).Config.Trim();
            //_isclkfyty = (new SystemCfg(7054)).Config.Trim() == "0" ? false : true;

            string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID ='{0}' ", ClassStatic.Current_BinID.ToString());

            DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

            if (dtInp == null || dtInp.Rows.Count <= 0)
                throw new Exception("δ�ҵ���סԺ�ŵĲ�����Ϣ\r");

            _xzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
            _yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
            _inpatientNo = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
            if (cfg7054 == "1" || cfg7054.Contains(Convert.ToInt64(_inpatientNo).ToString()))
            {
                _isclkfyty = true;
            }
            else
            {
                _isclkfyty = false;
            }

            Cursor.Current = Cursors.Default;
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            //myDataGrid.TableStyles[0].AllowSorting=false; //����������

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
                    //myBoolCol.tool
                    //this.toolTip2
                    //myBoolCol.too
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
            //��ɫ������ҽ����״̬ 
            int ChargeCol = 16;	 //charge_bit��

            //ɾ����־
            if (Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 2]) == 1)
            {
                e.ForeColor = Color.Gray;  //��ɫ
                e.BackColor = Color.White;
                return;
            }

            int iCZ = this.myDataGrid1[e.Row, ChargeCol - 1].ToString().Trim() == "���ʷ���" ? 1 : 0; //1�������
            int iCharge = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol]);			//1�����Ѽ���
            int iFinish = Convert.ToInt16(this.myDataGrid1[e.Row, ChargeCol + 1]) == 1 ? 1 : 0;	//1��������ɣ��ѷ�ҩ�� (2�Ƿǻ���ҩ����ʱ��û����ҩƷ��Ϣ���м���ȱ�־)
            int iDisCharge = Convert.ToInt16(this.myDataGrid1[e.Row, 31]);			//1�����ѽ���


            if (iCharge == 0 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.Black;		//δ����  δ���  δ����  ��
            if (iCharge == 0 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.DarkRed;	//δ����  δ���    ����  �ں�			}
            if (iCharge == 1 && iFinish == 0 && iCZ == 0) e.ForeColor = Color.RoyalBlue;  //�Ѽ���  δ���  δ����  ǳ��
            if (iCharge == 1 && iFinish == 0 && iCZ == 1) e.ForeColor = Color.LightCoral; //�Ѽ���  δ���    ����  ǳ��
            if (iCharge == 1 && iFinish == 1 && iCZ == 0) e.ForeColor = Color.Blue;		//�Ѽ���  �����  δ����  ��
            if (iCharge == 1 && iFinish == 1 && iCZ == 1) e.ForeColor = Color.Red;		//�Ѽ���  �����    ����  ��

            if (iDisCharge == 1) e.ForeColor = Color.Green; //�Ѿ�����

            if (this.myDataGrid1[e.Row, 0].ToString() == "True")
                e.BackColor = Color.GreenYellow;
            else
                e.BackColor = Color.White;
        }


        private void ShowData()
        {
            Cursor.Current = PubStaticFun.WaitCursor();

            # region ���� 2009-06-08 Tany
            //string tmpSql = "";
            //if (cb��ʾ��ɾ������.Checked == false)
            //{
            //    tmpSql = " and a.delete_bit=0 ";
            //}

            ////ҩƷ��������Ŀ�ֿ�ȡ���ݣ�ҩƷ������ȡҽ����������Ŀ������ȡ�շ���Ŀ��
            ////Modify By Tany at 2004-10-08 ����mngtype=5���ж�
            ////Modify By Tany at 2004-10-31 �����Ż�дSQL���
            ////Modify By Tany at 2005-05-20 ����ҽ����jz_flag�ֶΣ����jz_flag=1�Ļ���ʾֱ�ӼƷѣ�����ֱ�ӳ��
            //string sSql = "  SELECT DBO.FUN_GETDATE(EXECDATE) ҽ������, " +
            //            "  ltrim(rtrim(����)) + case when a.tlfs=1 then  '��ȱҩ��' else '' end + case when a.delete_bit=1 then  '����ɾ����' else '' end + case when c2 is not null then ltrim(rtrim(c2)) else '' end as ����,���, " +
            //            "         case when a.cz_flag in (2,3) then a.num else a.NUM/a.isanalyzed end  ����,a.UNIT ��λ," +
            //            "         case when a.cz_flag in (2,3) then 1 else a.isanalyzed end ����,a.DOSAGE ����,a.RETAIL_PRICE ����,a.ACVALUE ���, " +
            //            "         convert(varchar,datepart(mm,a.BOOK_DATE)) ������Ϣ,b.name ִ�п���, " +
            //            "         convert(varchar,datepart(mm,a.charge_date)) ������Ϣ,dbo.FUN_ZY_SEEKFeeTypeName(a.cz_flag) ��������, " +
            //            "         a.charge_bit,a.finish_bit,a.delete_bit,a.Order_ID,ID,a.EXECDEPT_ID,a.dept_br,a.dept_id,a.item_code , " +
            //            "         convert(varchar,datepart(dd,a.BOOK_DATE)) day1,convert(varchar,datepart(dd,a.charge_date)) day2 ," +
            //            "         c.name ���ͻ�ʿ,d.name ����Ա,a.isJSY ����ҩ,b.isJZ,a.jz_flag,a.DISCHARGE_BIT,ltrim(rtrim(����)) as ����," +
            //            "         convert(varchar,datepart(mm,a.fy_date)) ��ҩ��Ϣ,convert(varchar,datepart(dd,a.fy_date)) day3,e.name ��ҩԱ,fy_bit" +
            //            "   FROM (SELECT C.EXECDATE,E.ITEM_NAME ����, E.ITEM_DESCRIBE ���,           " +
            //            "                A.NUM,A.UNIT,C.isanalyzed ,A.DOSAGE,A.RETAIL_PRICE,A.ACVALUE,            " +
            //            "                C.EXEUSER,C.BOOK_DATE,A.EXECDEPT_ID,A.charge_user,A.charge_date,cz_flag," +
            //            "                D.Order_ID,A.ID,A.charge_bit,A.finish_bit,D.BOOK_DATE BOOK_DATE1,a.type,d.dept_br,d.dept_id,'' item_code,0 isJSY,a.delete_bit,D.jz_flag,A.DISCHARGE_BIT,a.c2,a.tlfs,fy_bit,fy_user,fy_date " +    //����û��item_code
            //            "         FROM (select a.ID, prescription_id,orderexec_id, HSITEM_ID, NUM, UNIT, DOSAGE, RETAIL_PRICE,ACVALUE, EXECDEPT_ID, " +
            //            "         charge_user, charge_date, cz_flag, charge_bit,finish_bit, delete_bit,DISCHARGE_BIT,type,c2,tlfs,fy_bit,fy_user,fy_date from ZY_FEE_SPECI a inner join jc_stat_item c on a.statitem_code=c.code " +
            //            "         where c.itemtype<>1 AND inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") A ," +
            //            "         jc_HSITEMDICTION E , ZY_ORDEREXEC C ," +
            //            "         (select Order_ID, BOOK_DATE, dept_br,dept_id, item_code,jz_flag from ZY_ORDERRECORD where group_id=" + this.Group_ID + " and (mngtype=" + this.MNGType + " or mngtype=" + this.MNGType2 + ")" +
            //            "         and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") D " +
            //            "         WHERE a.orderexec_id=c.id and c.Order_ID=D.Order_ID  and A.HSITEM_ID=E.ITEM_ID  " + tmpSql + " and a.jgbm=e.jgbm " +
            //            "         union all " +
            //            "         SELECT C.EXECDATE,D.ORDER_CONTEXT, D.ORDER_SPEC ,   " +
            //            "                A.NUM,A.UNIT,C.isanalyzed ,A.DOSAGE,A.RETAIL_PRICE,A.ACVALUE,   " +
            //            "                C.EXEUSER,C.BOOK_DATE,A.EXECDEPT_ID,A.charge_user,A.charge_date,cz_flag," +
            //            "                D.Order_ID,A.ID,A.charge_bit,A.finish_bit,D.BOOK_DATE  ,a.type ,d.dept_br,d.dept_id,d.item_code, " +
            //            "                a.isJSY,a.delete_bit,D.jz_flag,A.DISCHARGE_BIT,a.c2,a.tlfs,fy_bit,fy_user,fy_date " +
            //            "         FROM (select a.ID, prescription_id,orderexec_id, HSITEM_ID, NUM, UNIT, DOSAGE, RETAIL_PRICE,ACVALUE, EXECDEPT_ID, " +
            //            "               charge_user, charge_date, cz_flag, charge_bit,finish_bit, delete_bit,DISCHARGE_BIT,type,c2,case when k.cjid is null then 0 else 1 end isJSY,tlfs,fy_bit,fy_user,fy_date from ZY_FEE_SPECI a " +
            //            "               inner join jc_stat_item c on a.statitem_code=c.code " +
            //            "               left join YF_KCMX k on a.cjid=k.cjid and a.execdept_id=k.deptid and k.bdelete=0 and k.deptid=" + InstanceForm.BCurrentDept.WardDeptId +
            //            "         where c.itemtype=1 AND inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") A ," +
            //            "         ZY_ORDEREXEC C ," +
            //            "        (select Order_ID,ORDER_CONTEXT,ORDER_SPEC, BOOK_DATE, dept_br,dept_id, item_code,jz_flag from ZY_ORDERRECORD where group_id=" + this.Group_ID +
            //            "         and (mngtype=" + this.MNGType + " or mngtype=" + this.MNGType2 + ")" +
            //            "         and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + ") D " +
            //            "         WHERE a.orderexec_id=c.id and c.Order_ID=D.Order_ID " + tmpSql + " ) a " +
            //            "   left join jc_dept_property b on a.EXECDEPT_ID=b.dept_id " +
            //            "   left join jc_employee_property c on a.EXEUSER=c.employee_id " +
            //            "   left join jc_employee_property d on a.charge_user=d.employee_id " +
            //            "   left join jc_employee_property e on a.fy_user=e.employee_id " +
            //            "   ORDER BY EXECDATE,type,BOOK_DATE1,cz_flag";
            #endregion

            int _deletebit = -1;
            if (cb��ʾ��ɾ������.Checked == false)
            {
                _deletebit = 0;
            }

            DataTable myTb = myFunc.ZYHS_ORDERS_SELECTFEE(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, Group_ID, FrmMdiMain.CurrentDept.WardDeptId, MNGType, MNGType2, _deletebit);

            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = false;
            col.ColumnName = "ѡ";

            col.DefaultValue = false;
            myTb.Columns.Add(col);

            this.myDataGrid1.DataSource = myTb;
            this.myDataGrid1.TableStyles[0].RowHeaderWidth = 5;

            if (myTb.Rows.Count != 0)
            {
                for (int i = myTb.Rows.Count - 1; i >= 0; i--)
                {
                    myTb.Rows[i]["����"] = string.Format("{0:F2}", myTb.Rows[i]["����"]);
                    if (myTb.Rows[i]["������Ϣ"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["������Ϣ"] = myTb.Rows[i]["������Ϣ"].ToString().Trim() + "-" + myTb.Rows[i]["day1"].ToString().Trim() + " " + myTb.Rows[i]["���ͻ�ʿ"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["������Ϣ"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["������Ϣ"] = myTb.Rows[i]["������Ϣ"].ToString().Trim() + "-" + myTb.Rows[i]["day2"].ToString().Trim() + " " + myTb.Rows[i]["����Ա"].ToString().Trim();
                    }
                    if (myTb.Rows[i]["��ҩ��Ϣ"].ToString().Trim() != "")
                    {
                        myTb.Rows[i]["��ҩ��Ϣ"] = myTb.Rows[i]["��ҩ��Ϣ"].ToString().Trim() + "-" + myTb.Rows[i]["day3"].ToString().Trim() + " " + myTb.Rows[i]["��ҩԱ"].ToString().Trim();
                    }
                }
            }

            PubStaticFun.ModifyDataGridStyle(myDataGrid1, 0);

            Cursor.Current = Cursors.Default;
        }

        //�Ƿ���Գ���
        private bool isEnableCZ(int nrow)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            string sql = "";
            DataTable tb = new DataTable();
            string strShow = "";

            //���˷��ò��ɳ�
            //���˷��ÿ��Ա�ɾ�������Կ��Ա�ѡ�� Modify by Tany 2005-09-21
            //			if(myTb.Rows[nrow]["��������"].ToString()=="���ʷ���" ) 
            //			{
            //				return false;
            //			}

            //ɾ���ķ��ò���ѡ��
            if (myTb.Rows[nrow]["delete_bit"].ToString().Trim() == "1")
            {
                return false;
            }

            int jz_flag = 0;
            jz_flag = myTb.Rows[nrow]["jz_flag"].ToString().Trim() == "" ? 0 : Convert.ToInt32(myTb.Rows[nrow]["jz_flag"]);

            long DeptId = isSSMZ || isTSZL ? FrmMdiMain.CurrentDept.DeptId : ClassStatic.Current_DeptID;
            if (!zczyz_notfy)//add by zouchihua 2013-9-11 �������˳���
            {
                //Add By Tany 2006-01-18 
                //�������������ֻ�ܳ��Լ����ҿ���
                if ((isSSMZ || isTSZL) && Convert.ToInt64(myTb.Rows[nrow]["dept_id"]) != DeptId)
                {
                    //���Ǳ����ҵķ��ò��ɳ�
                    strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "���Ǳ����ҵķ��ò��ɳ�";
                    DoOperate(strShow);
                    return false;
                }
                else if (Convert.ToInt64(myTb.Rows[nrow]["dept_id"]) != DeptId) //Add By Tany 2010-07-13 �����������������ô�жϲ���7068�Ƿ���������������ҿ�����ҽ�� 0=���� 1=��
                {
                    if (new SystemCfg(7068).Config == "0")
                    {
                        //������������Ǳ����ң���ô�����������
                        sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                        tb = FrmMdiMain.Database.GetDataTable(sql);
                        if (tb == null || tb.Rows.Count == 0)
                        {
                            //add by zouchihua ����ǻ������� 2012-01-14
                            string hzsql = "select Apply_type  from ZY_ORDERRECORD where Apply_type=4 and order_id='" + myTb.Rows[nrow]["order_id"].ToString() + "'";
                            DataTable tbb = FrmMdiMain.Database.GetDataTable(hzsql);
                            if (tbb == null || tbb.Rows.Count == 0)
                            {

                                strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "���Ǳ����ҵķ��ò��ɳ�";
                                DoOperate(strShow);
                                return false;
                            }
                        }
                    }
                }
            }

            //�Ǳ����ҵķ��õ�ִ�еص㲻�Ǳ������Ҳ����������˵�������Ŀ���ܳ�
            //��ͨҩƷ�����Գ�
            //����ҩƷδ���˷�ҩ����ȡ����
            if (myTb.Rows[nrow]["xmly"].ToString().Trim() == "2" && jz_flag != 1 //jz_flag=1��ʾֱ���շ� Modify By Tany 2005-05-20
                && Convert.ToInt64(myTb.Rows[nrow]["EXECDEPT_ID"]) != DeptId
                && Convert.ToInt32(myTb.Rows[nrow]["isJZ"]) != 1
                && nType == 5
                && Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) != 1 //Modify By Tany 2010-11-22 ���ҽ����Ŀ��ȷ�ѣ�����ֱ�ӳ�����û�б�ȷ�ѣ�ֻ�ܴ�δִ��
                )
            {

                strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + " �Ǳ�����ִ���Ҳ����������˵�������Ŀ�����ܳ���";
                DoOperate(strShow);
                return false;
            }

            //����Ѿ��������ܳ���
            //Add By Tany 2005-05-23
            if (myTb.Rows[nrow]["DISCHARGE_BIT"].ToString().Trim() == "1")
            {
                //MessageBox.Show("�÷����Ѿ����㣬���ܳ��ˣ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "�÷����Ѿ����㣬���ܳ���";
                DoOperate(strShow);
                return false;
            }
            //			}
            //����ڷ�ҩ�Ƿ��������
            if (tlfl != "" && !_isclkfyty && tlfl.IndexOf(myTb.Rows[nrow]["tlfl"].ToString().Trim()) >= 0 && Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 1)
            {
                try
                {
                    //��������� ������ǡ��������װ����ô�Ϳ��Գ��  add by zouchihua 2014-4-14
                    if (
                        Convert.ToInt32(myTb.Rows[nrow]["����"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 0
                        &&
                        (
                        System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(Convert.ToInt32(myTb.Rows[nrow]["����"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"])), @"^[+-]?\d+$")
                        &&
                         Convert.ToInt32(myTb.Rows[nrow]["����"]) % Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) == 0

                        )

                        )
                    {

                    }
                    else
                    {
                        //Modify by jchl  �Ѽ��˵Ĳ���ڷ�ҩ���������
                        if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1)
                        {
                            strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "�Ѽ��˵Ĳ���ڷ�ҩ�����ܳ���";
                            DoOperate(strShow);
                            return false;
                        }
                        //strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "����ڷ�ҩ�����ܳ���";
                        //DoOperate(strShow);
                        //return false;
                    }
                }
                catch { return false; }
            }

            if (!isSSMZ && !isTSZL)
            {

                if (zczyz_notfy)
                    return true;
                //����Ǳ����ҿ����˵�����ɾ��   add by zouchihua 2013-8-23
                sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                DataTable tbtemp = FrmMdiMain.Database.GetDataTable(sql);
                if (cfg7159.Config.Trim() == "1" && lb1.Text.IndexOf("�˵�") >= 0 && tbtemp.Rows.Count > 0)
                    return true;
                //���˲��Ǳ����ҵķ��ò��ɳ�
                //��������жϣ������ѯ����
                sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_br"].ToString().Trim();
                tb = FrmMdiMain.Database.GetDataTable(sql);
                if (tb == null || tb.Rows.Count == 0)
                {
                    //������������Ǳ����ң������ǿ���������ҩ����ô�����������
                    sql = "select * from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "' and dept_id=" + myTb.Rows[nrow]["dept_id"].ToString().Trim();
                    tb = FrmMdiMain.Database.GetDataTable(sql);
                    if (tb == null || tb.Rows.Count == 0 || myTb.Rows[nrow]["iskdksly"].ToString().Trim() != "1")
                    {

                        strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + " �ǿ���������ҩ�����ܳ���";
                        DoOperate(strShow);
                        return false;
                    }
                }
            }

            try
            {
                string strPvsScan = Convertor.IsNull(myTb.Rows[nrow]["is_PvsScn"], "0");
                if (!CanOrderRecCz(strPvsScan))
                {
                    strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "  ���龲��ҩƷ�Ѿ���ҩ������������ת���";


                    DoOperate(strShow);

                    //this.toolTip2.InitialDelay = 1000000;
                    //this.toolTip2.Active = false;
                    return false;
                }
            }
            catch
            {
                return false;
            }

            try
            {
                //STATITEM_CODE/PRESCRIPTION_ID�����ϴ��в�ҩ�����������:Modify by jchl 2015-11-04
                if (myTb.Rows[nrow]["STATITEM_CODE"].ToString().Trim() == "03")
                {
                    string empNo = myTb.Rows[nrow]["PRESCRIPTION_ID"].ToString().Trim();
                    //�����������ҩ�Ѿ��ϴ�
                    sql = string.Format(@"select count(1) as Num from yf_zcyfy_sc where JSSJH='{0}' and del_bit=0", empNo);
                    int iSc = Convert.ToInt32(FrmMdiMain.Database.GetDataResult(sql).ToString());

                    if (iSc > 0)
                    {
                        strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + "  ������ҩ�����Ѿ��ϴ�������á�����������";

                        DoOperate(strShow);
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            //������ʱ����
            //Modify By Tany 2015-12-29 ������֤��ϵͳ�����Ƿ���ڣ������ڲ������
            TrasenHIS.BLL.Judgeorder jg = new Judgeorder(FrmMdiMain.Database);
            if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1 && !jg.CheckFeeStatus(_inpatientNo, myTb.Rows[nrow]["id"].ToString()))
            {
                strShow = myTb.Rows[nrow]["ҽ������"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + " ������������ϵͳ�����Ѿ���;���㣬��������";
                DoOperate(strShow);
                return false;
            }


            //Modify by jchl 2016-12-28-----------------------------------------
            //��״����,ҽ�����˲�����������2016���˷���   
            if (_yblx.Trim().Equals("1"))
            {
                DateTime serDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                int ServerYear = serDate.Year;// PubStaticFun.GetDateFromGuid(PubStaticFun.NewGuid()).Year

                DateTime.TryParse(myTb.Rows[nrow]["BOOK_DATE"].ToString(), out serDate);//�Ѽ��˵��Ѽ���ʱ��   δ���˵��ѵ�ǰʱ��
                DateTime ChargeDate = serDate;
                int ChargeYear = ChargeDate.Year;

                //2017���Ժ�ķ�����ʱ�䲻�ܳ���2016�ļ��˷���
                if (ServerYear == 2017 && ChargeYear == 2016)
                {
                    strShow = myTb.Rows[nrow]["BOOK_DATE"].ToString() + "  " + myTb.Rows[nrow]["����"].ToString() + " ����״����,����ҽԺ��ͳһ�����ţ�ҽ�����˲�����������2016�ǲ����ķ���";
                    DoOperate(strShow);
                    return false;
                }
            }

            //����ҩƷ��ִ�еص��Ǳ����ҵ�������Ŀ���Գ�
            return true;
        }

        /// <summary>
        /// add by jchl(���������ԭ��)
        /// </summary>
        /// <param name="strResult"></param>
        private void DoOperate(string strResult)
        {
            lblUnEnableCz.Text = strResult;

            this.toolTip2.Active = true;
            this.toolTip2.InitialDelay = 100;
            this.toolTip2.SetToolTip(lblUnEnableCz, strResult);
            this.toolTip2.Show(strResult, lblUnEnableCz, 1000);

            //this.toolTip2.Active = true;
            //this.toolTip2.InitialDelay = 100;
            //this.toolTip2.Show(strResult, lblUnEnableCz);
            //toolTip2.
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
            //			if (this.myDataGrid1.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="ѡ") return;
            if (nrow > myTb.Rows.Count - 1) return;

            //���ʷ��ò���ѡ
            if (this.isEnableCZ(nrow) == false)
            {
                myTb.Rows[nrow]["ѡ"] = false; ;
                this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);
                this.myDataGrid1.DataSource = myTb;
                return;
            }

            bool isResult = myTb.Rows[nrow]["ѡ"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["ѡ"] = isResult;

            //Modify by jchl Pivas�������죨ÿ��ҽ������ÿ��ҽ��   ÿ��ҽ������pivas����жϣ�
            bool isPvsDpt = IsPvsDept(myTb.Rows[nrow]["EXECDEPT_ID"].ToString().Trim());
            if (this.rbÿ��ҽ��.Checked || isPvsDpt)
            {
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ҽ������"].ToString().Trim() == myTb.Rows[nrow]["ҽ������"].ToString().Trim()
                        && myTb.Rows[i]["��������"].ToString().Trim() == myTb.Rows[nrow]["��������"].ToString().Trim()
                        && myTb.Rows[i]["Ƶ��"].ToString().Trim() == myTb.Rows[nrow]["Ƶ��"].ToString().Trim()
                        && this.isEnableCZ(i) == true)
                    {
                        this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                        myTb.Rows[i]["ѡ"] = isResult;
                        //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                    }
                    //if (isPvsDpt)
                    //{
                    //}
                    //else
                    //{
                    //    if (myTb.Rows[i]["ҽ������"].ToString().Trim() == myTb.Rows[nrow]["ҽ������"].ToString().Trim()
                    //        && myTb.Rows[i]["��������"].ToString().Trim() == myTb.Rows[nrow]["��������"].ToString().Trim()
                    //        && this.isEnableCZ(i) == true)
                    //    {
                    //        this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    //        myTb.Rows[i]["ѡ"] = isResult;
                    //        //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                    //    }
                    //}
                }
            }

            this.myDataGrid1.DataSource = myTb;

        }


        private void rbÿ��ҽ��_Click(object sender, System.EventArgs e)
        {
            this.label10.Text = "��";
        }

        private void rbÿ��ҽ��_Click(object sender, System.EventArgs e)
        {
            this.label10.Text = "��";
        }


        private void btȫѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["��������"].ToString() != "���ʷ���" && this.isEnableCZ(i) == true)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["ѡ"] = true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt��ѡ_Click(object sender, System.EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["��������"].ToString() != "���ʷ���" && this.isEnableCZ(i) == true)
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                    myTb.Rows[i]["ѡ"] = myTb.Rows[i]["ѡ"].ToString() == "True" ? false : true;
                }
            }
            this.myDataGrid1.DataSource = myTb;
        }


        private void bt����_Click(object sender, System.EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show(this, "�Բ������������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (Convert.ToDecimal(this.textBox1.Text.Trim()) <= 0)
            {
                MessageBox.Show(this, "�Բ��𣬳���������������㣬������������ȷ�ĳ���������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (Convert.ToDecimal(this.textBox1.Text.Trim()) != Convert.ToInt32(Convert.ToDecimal(this.textBox1.Text.Trim())))
            {
                MessageBox.Show(this, "�Բ��𣬳���ֻ��������������������������ȷ�ĳ���������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }



            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string sSql = "", sSql1 = "", sSql2 = "";

            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;

            if (this.rbÿ��ҽ��.Checked)
            {
                if (MessageBox.Show(this, "ȷ��ѡ���ÿ��ҽ������" + this.textBox1.Text.Trim() + "����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            else
            {
                if (MessageBox.Show(this, "ȷ��ѡ���ÿ��ҽ������" + this.textBox1.Text.Trim() + "����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                f1.Close();
            }
            bool isHSZ = myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);

            //			if(isSSMZ==false)
            //			{
            //modify by zouchihua 2011-10-28 //�����������������Ҳ����ʿվ�����ж�
            if (!isSSMZ && !isTSZL && isHSZ == false)    // ��ʿ��
            {
                //�Ƿ�ֻ�л�ʿ���ܹ��������� Add By Tany 2007-09-12
                if ((new SystemCfg(7033)).Config == "��")
                {
                    MessageBox.Show("�Բ���ֻ�л�ʿ���ܹ��������ã�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if ((new SystemCfg(19005)).Config == "1" && !isHSZ && isSSMZ)
            {
                //�Ƿ�ֻ�л�ʿ���ܹ��������� Add By Tany 2007-09-12
                MessageBox.Show("�Բ���ֻ�л�ʿ���ܹ��������ã�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //			}



            Cursor.Current = PubStaticFun.WaitCursor();

            try
            {
                #region ��ȫ���ж�
                //��ȫ���жϷ��������֤���棬�������ͬʱ����ʱ���ظ����
                //Modify By Tany 2005-03-26
                int iSelectRows = 0;

                //Modify By Tany 2010-05-04 �����ļ۸���������趨���ȼ��㵥�γ������������룬Ȼ���ٳ��Գ�������
                decimal czcs = Convert.ToDecimal(this.textBox1.Text);
                //add by zouchihua 20134-8-21 ֻ����ʱҽ���ſ��Գ�����������������Ϊ1
                if (rbsl.Checked)
                    czcs = 1;
                //Modify By Tany 2010-12-12
                decimal _bctfje = 0;

                //Modify by Tany 2010-12-21
                //7073�Ƿ�ʹ�ó�����ȹ��� 0=���� 1=��
                string _cfg7073 = new SystemCfg(7073).Config;
                //7074���������ۼƶ�ȣ������˶�Ƚ�������ؿ��ƣ�0=�����ƣ�
                string _cfg7074 = new SystemCfg(7074).Config;
                //7075����������ȿ��Ʒ�ʽ 0=����ʾ 1=ǿ�ƿ��� 2=�������룬�������ȷ��
                string _cfg7075 = new SystemCfg(7075).Config;
                //7076������ȹ����Ƿ����ҩƷ���� 0=���� 1=��
                string _cfg7076 = new SystemCfg(7076).Config;
                //7077������ȹ����Ƿ����ҽ������ 0=���� 1=��
                string _cfg7077 = new SystemCfg(7077).Config;
                //7078������ȹ������Ƶ�ͳ�ƴ���Ŀ���룬���ж������Ŀ���룬���ö��ţ�,���ָ������ձ�ʾȫ������
                string _cfg7078 = new SystemCfg(7078).Config;
                //7080������ȹ����Ƿ����Բ��˵�ǰ���ң�ת�ƺ󲻼���ǰ�Ƶĳ��˽� 0=���� 1=��
                string _cfg7080 = new SystemCfg(7080).Config;

                //Add By tany 2015-05-12
                //7805�������ó���������ƣ�0=������ ����0�򳬹�����������ƣ�����������7073��7075��
                string _cfg7805 = new SystemCfg(7805).Config;

                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        if (myTb.Rows[i]["��������"].ToString() == "���ʷ���")
                        {
                            MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "���ǳ�����¼�������ٳ�������ѡ��ǳ�����¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["ѡ"] = false;
                            return;
                        }
                        //Add by zouchihua2011-11-19  �����жϣ�������ò��ܳ���
                        string czstr = "select *  from zy_fee_speci where delete_bit=0 and DISCHARGE_BIT=1 and id='" + myTb.Rows[i]["ID"].ToString() + "'";
                        DataTable tmtable = FrmMdiMain.Database.GetDataTable(czstr);
                        if (tmtable.Rows.Count > 0)
                        {
                            MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�����Ѿ����㣬�����ٳ�����������ѡ���¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["ѡ"] = false;
                            return;
                        }

                        if (tlfl != "" && !_isclkfyty && tlfl.IndexOf(myTb.Rows[i]["tlfl"].ToString().Trim()) >= 0 && Convert.ToInt32(myTb.Rows[i]["unitrate"]) > 1)
                        {

                            try
                            {
                                //��������� ������ǡ��������װ����ô�Ϳ��Գ��  add by zouchihua 2014-4-14
                                if (
                                    Convert.ToInt32(myTb.Rows[nrow]["����"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) > 0
                                    &&
                                    (
                                    System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(Convert.ToInt32(myTb.Rows[nrow]["����"]) / Convert.ToInt32(myTb.Rows[nrow]["unitrate"])), @"^[+-]?\d+$")
                                    &&
                                     Convert.ToInt32(myTb.Rows[nrow]["����"]) % Convert.ToInt32(myTb.Rows[nrow]["unitrate"]) == 0

                                    )

                                    )
                                {

                                }
                                else
                                {
                                    //Modify by jchl  �Ѽ��˵Ĳ���ڷ�ҩ���������
                                    if (Convert.ToInt32(myTb.Rows[nrow]["charge_bit"]) == 1)
                                    {
                                        MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�����Ѽ��˵Ĳ���Ŀڷ�ҩ�����ܳ�����������ѡ���¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        myTb.Rows[i]["ѡ"] = false;
                                        return;
                                    }
                                    //MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "���ǲ���Ŀڷ�ҩ�����ܳ�����������ѡ���¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //myTb.Rows[i]["ѡ"] = false;
                                    //return;
                                }
                            }
                            catch
                            {
                                MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "���ǲ���Ŀڷ�ҩ�����ܳ�����������ѡ���¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                myTb.Rows[i]["ѡ"] = false;
                                return;
                            }




                        }
                        decimal num_cz = Convert.ToDecimal(myTb.Rows[i]["����"]) * czcs;
                        if (this.rbsl.Checked)//add by zouchihua2013-8-21 �����ѡ���������
                            num_cz = Convert.ToDecimal(this.textBox1.Text);
                        decimal num_total = Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);
                        sSql = "select sum(num) as num  from zy_fee_speci where delete_bit=0 and (id='" + myTb.Rows[i]["ID"].ToString() + "' or cz_id='" + myTb.Rows[i]["ID"].ToString() + "')";
                        DataTable myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
                        if (myTempTb.Rows.Count != 0)
                        {
                            if (myTempTb.Rows[0]["num"].ToString() == "")
                            {
                                if (num_cz > num_total)
                                {
                                    MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�г���" + (this.rbsl.Checked == false ? "����" : "����") + "ƫ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(myTempTb.Rows[0]["num"]) == 0)
                                {
                                    MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�з����Ѿ�ȫ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                                if ((Convert.ToDecimal(myTempTb.Rows[0]["num"]) - num_cz) < 0)
                                {
                                    MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�г���" + (this.rbsl.Checked == false ? "����" : "����") + "ƫ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (myTempTb.Rows[0]["num"].ToString() == "")
                            {
                                if (num_cz > num_total)
                                {
                                    MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�г���" + (this.rbsl.Checked == false ? "����" : "����") + "ƫ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.myDataGrid1.CurrentRowIndex = i;
                                    this.ShowData();
                                    return;
                                }
                            }
                        }
                        iSelectRows += 1;

                        //Modify By Tany 2010-12-21 ���������жϸôα����Ƶķ���
                        if (myTb.Rows[i]["����"].ToString().IndexOf("��ϵͳ�Զ�������") >= 0
                            || (myTb.Rows[i]["xmly"].ToString().Trim() == "1" && _cfg7076 == "0")
                            || (nType == 5 && _cfg7077 == "0")
                            || (_cfg7078.IndexOf(myTb.Rows[i]["statitem_code"].ToString().Trim()) >= 0))
                        {
                            _bctfje += 0;//num_cz * Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);
                        }
                        else
                        {
                            _bctfje += num_cz * Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);
                        }
                    }
                }

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "�Բ���û��ѡ���¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                //Modify By Tany 2010-12-12 �����Ķ�ȹ���
                //�Ѿ������ķ����ܶ�
                decimal _czfee = 0;
                //�Ƿ�ǿ�Ʋ��������
                bool _isUnjz = false;
                //7073�Ƿ�ʹ�ó�����ȹ��� 0=���� 1=��
                if (_cfg7073 == "1")
                {
                    #region �ۼƶ�ȿ���
                    //7074���������ۼƶ�ȣ������˶�Ƚ�������ؿ��ƣ�0=�����ƣ�
                    decimal _czed = Convert.ToDecimal(_cfg7074);
                    if (_czed > 0)
                    {
                        //7075����������ȿ��Ʒ�ʽ 0=����ʾ 1=ǿ�ƿ��� 2=�������룬�������ȷ��
                        int _kzfs = Convert.ToInt16(_cfg7075);

                        string sql = "";
                        string _tj = "";
                        string _join = "";
                        //7080������ȹ����Ƿ����Բ��˵�ǰ���ң�ת�ƺ󲻼���ǰ�Ƶĳ��˽� 0=���� 1=��
                        if (_cfg7080 == "1")
                        {
                            if (isSSMZ)
                            {
                                _tj += " and a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + " ";
                            }
                            else
                            {
                                _tj += " and a.dept_br in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') and a.dept_id not in (select deptid from ss_dept) ";
                            }
                        }
                        //7076������ȹ����Ƿ����ҩƷ���� 0=���� 1=��
                        if (_cfg7076 == "0")
                        {
                            _tj += " and a.xmly<>1 ";
                        }
                        //7078������ȹ������Ƶ�ͳ�ƴ���Ŀ���룬���ж������Ŀ���룬���ö��ţ�,���ָ������ձ�ʾȫ������
                        string _tjdx = _cfg7078;
                        if (_tjdx != "")
                        {
                            _tj += " and a.statitem_code not in (" + _tjdx + ") ";
                        }
                        //ϵͳ�Զ������������жϷ���
                        _tj += " and isnull(a.bz,'')<>'��ϵͳ�Զ�������' ";
                        //7077������ȹ����Ƿ����ҽ������ 0=���� 1=��
                        if (_cfg7077 == "0")
                        {
                            _join += " inner join zy_orderrecord b on a.order_id=b.order_id and b.ntype<>5 ";
                        }

                        sql = "select sum(a.acvalue) from zy_fee_speci a " + _join + " where a.delete_bit=0 and a.cz_flag=2 and a.inpatient_id='" + ClassStatic.Current_BinID + "'" + _tj;
                        _czfee = Convert.ToDecimal(Convertor.IsNull(FrmMdiMain.Database.GetDataResult(sql), "0"));

                        if ((Math.Abs(_czfee) + Math.Abs(_bctfje) >= _czed) && _bctfje != 0)//Modify By Tany 2015-05-27 ��������˷ѽ��Ϊ0��Ҳ���ǲ����ܿط�Χ�ڵĻ�������Ҫ��ʾ
                        {
                            if (_kzfs == 2)
                            {
                                if (MessageBox.Show("�ò����ۼ��ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_czfee).ToString("0.00") + "Ԫ\n�����ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_bctfje).ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��Ϊ��" + _czed.ToString("0.00") + "Ԫ\n\n���һ��Ҫ���ˣ�����Ҫ��ؿ��ҽ���ȷ�ϣ��Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    _isUnjz = true;
                                }
                            }
                            else if (_kzfs == 1)
                            {
                                MessageBox.Show("�ò����ۼ��ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_czfee).ToString("0.00") + "Ԫ\n�����ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_bctfje).ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��Ϊ��" + _czed.ToString("0.00") + "Ԫ\n\n���������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                if (MessageBox.Show("�ò����ۼ��ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_czfee).ToString("0.00") + "Ԫ\n�����ܿ��Ƴ��˽��Ϊ��" + Math.Abs(_bctfje).ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��Ϊ��" + _czed.ToString("0.00") + "Ԫ\n\n�Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    #endregion
                }

                this.progressBar1.Maximum = iSelectRows;
                this.progressBar1.Value = 0;

                string ward_id = "";
                string ward_deptid = "";
                string nFeeID = "";

                decimal tfje = 0;
                #region//Add by Zouchihua 2011-10-12 �жϲ��˵ĵ�ǰ�����ǲ������ڱ�Ժ������Ҫ��Ϊ����ֹ��ʱ��Ժҵ��Ĳ��˲���
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                if (rtnSql[0] != "0")
                {
                    MessageBox.Show("���ڿ�Ժת�ƻ����������ƣ��ò��˼�¼�Ѿ����᲻���������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                #endregion
                //Modify by tany 2011-03-16 7053ҽ����Ŀ�˷��Ƿ���Ҫȷ�� 0=���� 1=��
                SystemCfg cfg7053 = new SystemCfg(7053);
                SystemCfg cfg7113 = new SystemCfg(7113);
                long DeptId = isSSMZ || isTSZL ? FrmMdiMain.CurrentDept.DeptId : ClassStatic.Current_DeptID;
                //add by zouchihua ���ҽ��id
                string order_id = "";
                Guid newFeeId;//Add By Tany 2015-05-27 �����²����ķ���ID����ΪҪд���ű�
                string sql_yf = "select  drugstore_id  from  JC_DEPT_DRUGSTORE where dept_id=" + InstanceForm.BCurrentDept.DeptId.ToString();
                DataTable dt_yf_dept = InstanceForm.BDatabase.GetDataTable(sql_yf);
                bool truedrugstore = false;


                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ID"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        newFeeId = PubStaticFun.NewGuid();
                        //�ѽ����Ƿ�������  0�������� 1������
                        SystemCfg cfg7603 = new SystemCfg(7603);
                        if (cfg7603.Config.Trim().Equals("0"))
                        {
                            string strValid = string.Format(@"select count(1) as Num from  zy_fee_speci A where id='{0}' and is_PvsScn=1 and 
                                                                exists(select 1 from JC_DEPT_DRUGSTORE t where A.EXECDEPT_ID=T.DRUGSTORE_ID AND is_PvsRel=1)",
                                                            myTb.Rows[i]["ID"].ToString().Trim());

                            string num = FrmMdiMain.Database.GetDataResult(strValid).ToString().Trim();
                            int iNum = int.Parse(num);

                            if (iNum > 0)
                            {
                                MessageBox.Show("�Բ��𣬸�ҩ���Ѿ�����������ɨ�裬�����������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 0);//ѡ����
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }

                        order_id = myTb.Rows[i]["order_id"].ToString().Trim();
                        //add by zouchihua 2013-2-6 ������ҽ���������
                        try
                        {
                            string ss = "select * from  zy_fee_speci  where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "' and  isnull(YBJS_BIT,0)=1 ";
                            DataTable tb = FrmMdiMain.Database.GetDataTable(ss);
                            if (tb.Rows.Count > 0)
                            {
                                MessageBox.Show("�Բ��𣬸÷����Ѿ�ҽ�����㣬�����������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                myDataGrid1.CurrentCell = new DataGridCell(i, 0);//ѡ����
                                myDataGrid1_Click(sender, e);
                                return;
                            }
                        }
                        catch { }
                        //add by zouchihua 2012-9-20 �����ҽ����Ŀ�������Ѿ�ǩ�ղ��������
                        if (nType == 5)
                        {
                            string sql = "select BQSBZ from YJ_ZYSQ where YZID='" + myTb.Rows[i]["order_id"].ToString().Trim() + "'  and yzxmid   in (select yzid from JC_ASSAY)";//ֻ�м����������
                            DataTable tmptb = FrmMdiMain.Database.GetDataTable(sql);
                            if (tmptb.Rows.Count > 0)
                            {
                                if (tmptb.Rows[0]["BQSBZ"].ToString() == "1")
                                {
                                    MessageBox.Show("�Բ��𣬸���Ŀ�Ѿ�ǩ�գ������������", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    myDataGrid1.CurrentCell = new DataGridCell(i, 0);//ѡ����
                                    myDataGrid1_Click(sender, e);
                                    return;
                                }
                            }
                            //�۷�©�ѿ��� add by zouchihua 2013-5-30
                            try
                            {
                                string feestr = "select * from zy_fee_speci a left join YJ_ZYSQ b on a.ORDEREXEC_ID=b.ZXID where tcid>0 and id='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                DataTable tbfee = FrmMdiMain.Database.GetDataTable(feestr);
                                string sql1 = "";
                                if (tbfee.Rows.Count > 0)
                                {
                                    //������ײ�
                                    sql1 = "select * from hix_check where check_flag=1 and patientCheck_id=tf_'" + tbfee.Rows[0]["PRESCRIPTION_ID"].ToString() + "'";
                                }
                                else
                                    sql1 = "select * from hix_check  where check_flag=1 and patientCheck_id=tf_'" + tbfee.Rows[0]["YJSQID"].ToString() + "'";
                                DataTable tbtfpd = FrmMdiMain.Database.GetDataTable(sql1);
                                if (tbtfpd.Rows.Count > 0)
                                {
                                    MessageBox.Show("�÷����Ѿ��ڻ���������, �������˷ѣ�����ϵ����Ա");
                                    return;
                                }

                            }
                            catch
                            {

                            }
                        }
                        bool sfxyqr = false;//��ҽ����Ŀ�˷��Ƿ���Ҫȷ��
                        //add by zouchihua 2012-4-13 ��ʿվ�Ƿ��������ҽ����Ŀ 0=��,1=����
                        if (nType == 5 && cfg7113.Config.Trim() == "1" && Convert.ToInt64(myTb.Rows[i]["execdept_id"]) != DeptId)
                        {
                            MessageBox.Show("�Բ���ϵͳ������ʿ����ҽ����Ŀ��", "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 0);//ѡ����
                            myDataGrid1_Click(sender, e);
                            return;
                        }

                        //�Ƿ�ֻ�л�ʿ���ܹ������ѷ�ҩ�ķ��� Add By Tany 2007-10-27
                        if ((new SystemCfg(7039)).Config == "��" && Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 1 && !isHSZ)
                        {
                            MessageBox.Show("�Բ��𣬵� " + Convert.ToString(i + 1) + " �м�¼�Ѿ���ҩ��ֻ�л�ʿ���ܹ�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            myDataGrid1.CurrentCell = new DataGridCell(i, 0);//ѡ����
                            myDataGrid1_Click(sender, e);
                            return;
                        }

                        if (ward_id == "" || ward_deptid == "")
                        {
                            ward_id = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select ward_id from zy_orderrecord where order_id ='" + myTb.Rows[i]["order_id"].ToString() + "'"), "");
                            ward_deptid = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select dept_id from jc_ward where ward_id ='" + ward_id + "'"), "");
                        }

                        decimal num_cz = Convert.ToDecimal(myTb.Rows[i]["����"]) * czcs;
                        //      if (this.rbsl.Checked)//add by zouchihua2013-8-21 �����ѡ���������
                        if (this.rbsl.Checked)//add by zouchihua2013-8-21 �����ѡ���������
                            num_cz = Convert.ToDecimal(this.textBox1.Text);
                        //SQL�ֳ�ҩƷ�ͷ�ҩƷ��Ҫ������dosage����ҩƷ����dosage

                        if (myTb.Rows[i]["xmly"].ToString().Trim() != "1")
                        {



                            if (
                                //����������ҺͲ������ڿ�����ִ�п��Ҷ�����ͬ Modify By Tany 2009-11-16
                                    myTb.Rows[i]["DEPT_BR"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && myTb.Rows[i]["DEPT_ID"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && nType == 5
                                    && cfg7053.Config == "1"
                                )
                            {
                                //add by zouchihua 2014-4-7  7053����ʱ(Ϊ1ʱ)�����ܿ��Ƶ�ִ�п��ң�����ö��Ÿ���
                                string cfgvalues = ("," + cfg7192.Config.Trim() + ",");
                                if (cfgvalues.Contains("," + myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() + ","))
                                {
                                    sSql1 = "charge_bit,charge_date,charge_user )";
                                    sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                }
                                else
                                {
                                    //�����ҽ��������Ҫȷ��
                                    sSql1 = "charge_bit )";
                                    sSql2 = "0 ";
                                }
                            }
                            else
                            {


                                if (cfg7212.Config.Trim() == "1")
                                {
                                    //����������ҺͲ������ڿ�����ִ�п��Ҷ�����ͬ
                                    if (nType != 5 && myTb.Rows[i]["DEPT_BR"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim()
                                    && myTb.Rows[i]["DEPT_ID"].ToString().Trim() != myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim())
                                    {
                                        string czyz = @"select HOITEM_ID from ZY_ORDERRECORD
                                                                a join JC_HOITEMDICTION  b on a.HOITEM_ID=b.ORDER_ID
                                                                where a.XMLY=2 and (isbks=1 or isryks=1) and  a.order_id='" + myTb.Rows[i]["order_id"].ToString() + @"'";
                                        DataTable tb_ksdep = FrmMdiMain.Database.GetDataTable(czyz);
                                        if (tb_ksdep.Rows.Count > 0)
                                        {
                                            //˵������Ҫ������ȷ��
                                            sSql1 = "charge_bit )";
                                            sSql2 = "0 ";
                                            sfxyqr = true;
                                        }
                                        else
                                        {
                                            //��ҩƷ��Ҫȷ�ϸ�����
                                            //��ҩƷ�����˱�־����ɱ�־����1
                                            sSql1 = "charge_bit,charge_date,charge_user )";
                                            sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                        }
                                    }
                                    else
                                    {
                                        //��ҩƷ��Ҫȷ�ϸ�����
                                        //��ҩƷ�����˱�־����ɱ�־����1
                                        sSql1 = "charge_bit,charge_date,charge_user )";
                                        sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                    }

                                }
                                else
                                {
                                    //��ҩƷ��Ҫȷ�ϸ�����
                                    //��ҩƷ�����˱�־����ɱ�־����1
                                    sSql1 = "charge_bit,charge_date,charge_user )";
                                    sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                                }

                            }

                            //Modify By Tany 2010-12-12 ���ǿ�Ʋ�������ˣ���ô���˱�־Ϊ0
                            //7078������ȹ������Ƶ�ͳ�ƴ���Ŀ���룬���ж������Ŀ���룬���ö��ţ�,���ָ������ձ�ʾȫ������
                            if (_isUnjz && _cfg7078.IndexOf(myTb.Rows[i]["statitem_code"].ToString().Trim()) < 0)
                            {
                                //Modify By Tany 2010-12-15 7077������ȹ����Ƿ����ҽ������ 0=���� 1=��
                                if (nType != 5 || (nType == 5 && _cfg7077 == "1"))
                                {
                                    sSql1 = "charge_bit )";
                                    sSql2 = "0";
                                }
                            }

                            //Modify By Tany 2015-05-12
                            #region �����������
                            if (_cfg7073 == "1")
                            {
                                //������ȿ����󣬿����Ƿ����˵����������
                                if (Convertor.IsNumeric(_cfg7805) && Convert.ToDecimal(_cfg7805) > 0)
                                {
                                    decimal jexz = Convert.ToDecimal(_cfg7805);
                                    decimal dtje = num_cz * Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);
                                    if (jexz < dtje)
                                    {
                                        if (_cfg7075 == "2")
                                        {
                                            if (MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n���һ��Ҫ���ˣ�����Ҫ��ؿ��ҽ���ȷ�ϣ��Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["ѡ"] = false;
                                                return;
                                            }
                                            else
                                            {
                                                sSql1 = "charge_bit )";
                                                sSql2 = "0";
                                            }
                                        }
                                        else if (_cfg7075 == "1")
                                        {
                                            MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n���������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            myTb.Rows[i]["ѡ"] = false;
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n�Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["ѡ"] = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                            sSql = "INSERT INTO ZY_FEE_SPECI" +
                                " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                " cost_price, retail_Price, agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                                "num,sdValue,acValue,type,tlfs,gcys,pvs_xh,zfbl," +//����pivas��� Modify By Tany 2015-04-22  ����zfbl
                                sSql1 +
                                //Modify By Tany 2015-05-25 ʹ��Ԥ�����ɵķ���ID DBO.FUN_GETGUID(NEWID(),GETDATE())
                                "SELECT '" + newFeeId + "',a.jgbm,Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                "cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                "2,a.id,0,0," +
                                "-1*" + num_cz.ToString() + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",type,tlfs,gcys,pvs_xh,zfbl," +
                                sSql2 +
                                " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            for (int k = 0; k < dt_yf_dept.Rows.Count; k++)
                            {
                                if (myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() == dt_yf_dept.Rows[k]["drugstore_id"].ToString())
                                {
                                    truedrugstore = true;
                                }
                            }
                            if (!truedrugstore)
                            {
                                MessageBox.Show("����ҽ����ִ�п��Ҳ���ȷ��");
                                return;
                            }
                            //����ҩ��ֱ�Ӽ��˵�ҩֱ�Ӽ���
                            if (Convert.ToInt16(myTb.Rows[i]["����ҩ"]) == 1
                                || Convert.ToInt16(myTb.Rows[i]["jz_flag"]) == 1
                                || ((new SystemCfg(7025)).Config == "��"))// && Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 0 Modify by Tany 2009-11-07 �ĳɳ���ҩƷ�Ƿ�ֱ�Ӽ��� -----����δ��ҩҩƷ�Ƿ�ֱ�Ӽ���
                            {
                                //����ҩƷ��ֱ�Ӽ��˵�ҩƷ�����˱�־��1����ɱ�־��0 Modify By Tany 2004-10-08 
                                sSql1 = "charge_bit,charge_date,charge_user )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + "";
                            }
                            else
                            {
                                //�ǻ���ҩƷ�����˱�־����ɱ�־����0��CZ_YPFLAG=1
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }

                            //Modify By Tany 2010-01-12 ������ҩ�Ƿ�ֱ�Ӽ���
                            if (nType == 3 && (new SystemCfg(7061)).Config == "0")
                            {
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }

                            //Modify By Tany 2010-12-12 ���ǿ�Ʋ�������ˣ���ô���˱�־Ϊ0
                            //Modify By Tany 2010-12-15 7076������ȹ����Ƿ����ҩƷ���� 0=���� 1=��
                            if (_isUnjz && _cfg7076 == "1")
                            {
                                sSql1 = "charge_bit )";
                                sSql2 = "0";
                            }
                            string strbz = "";
                            //add by zouchihua 2012-12-18 �ݴ�ҩ������͵����ݴ�ҩ���������Ļ�ֱ�Ӵ��ϼ��˱��
                            SystemCfg cfg7117 = new SystemCfg(7117);
                            string execdeptid = cfg7117.Config.Trim();
                            if (Convert.ToInt16(myTb.Rows[i]["fy_bit"]) == 1 && myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() == execdeptid)
                            {
                                sSql1 = "charge_bit,charge_date,charge_user,bz )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",'�ݴ�ҩ�Զ�����'  ";
                                strbz = "�ݴ�ҩ�Զ�����";
                            }
                            //����ǳ������������ô���������(��������ҩ��Ϣ
                            if (zczyz_notfy)
                            {
                                sSql1 = "charge_bit,charge_date,charge_user,bz )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",'���������(��������ҩ��Ϣ)'";
                            }

                            //����Һ����
                            //if (myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                            //{
                            //    //�����pivas�Ļ�����Ҫ�����ж� Modify By Tany 2015-06-03
                            //    bool isPvsDpt = IsPvsDept(myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim());
                            //    if (!isPvsDpt)
                            //    {
                            //        //����pivas��ֱ�Ӽ��ˣ����Ҳ���ҩ
                            //        sSql1 = "charge_bit,charge_date,charge_user,FY_BIT )";
                            //        sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",5"; //Modify By Tany 2015-04-23 ����Ǵ���Һ����ִ�п����Ƿ�pivas�������pivas�Ļ�����Ҫ��ҩ
                            //    }
                            //    else
                            //    {
                            //        //�����pivas�ģ��򲻼��ˣ���д�����人����ҽԺ
                            //        sSql1 = "charge_bit )";
                            //        sSql2 = "0";
                            //    }
                            //}

                            //����Һ���� Modify by jchl ������Һҩ��ֱ�ӷ�ҩ
                            if (myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("566") ||
                                myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("672") ||
                                myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim().Equals("783"))
                            {
                                //����pivas��ֱ�Ӽ��ˣ����Ҳ���ҩ
                                sSql1 = "charge_bit,charge_date,charge_user,FY_BIT )";
                                sSql2 = "1,getdate() ," + FrmMdiMain.CurrentUser.EmployeeId + ",5";
                            }

                            //Modify By Tany 2015-05-12
                            #region �����������
                            if (_cfg7073 == "1")
                            {
                                //������ȿ����󣬿����Ƿ����˵����������
                                if (Convertor.IsNumeric(_cfg7805) && Convert.ToDecimal(_cfg7805) > 0)
                                {
                                    decimal jexz = Convert.ToDecimal(_cfg7805);
                                    decimal dtje = num_cz * Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);
                                    if (jexz < dtje)
                                    {
                                        if (_cfg7075 == "2")
                                        {
                                            if (MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n���һ��Ҫ���ˣ�����Ҫ��ؿ��ҽ���ȷ�ϣ��Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["ѡ"] = false;
                                                return;
                                            }
                                            else
                                            {
                                                sSql1 = "charge_bit )";
                                                sSql2 = "0";
                                            }
                                        }
                                        else if (_cfg7075 == "1")
                                        {
                                            MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n���������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            myTb.Rows[i]["ѡ"] = false;
                                            return;
                                        }
                                        else
                                        {
                                            if (MessageBox.Show("��" + (i + 1) + "�з��ó��˽��Ϊ��" + dtje.ToString("0.00") + "Ԫ\nϵͳ������˵Ķ��ΪС�ڣ�" + jexz.ToString("0.00") + "Ԫ\n\n�Ƿ����������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            {
                                                myTb.Rows[i]["ѡ"] = false;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                            sSql = "INSERT INTO ZY_FEE_SPECI" +
                                " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                " cost_price, retail_Price, agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                                "num,sdValue,acValue,type,tlfs,gcys,pvs_xh,zfbl," +//����pivas��� Modify By Tany 2015-04-22
                                sSql1 +
                                //Modify By Tany 2015-05-25 ʹ��Ԥ�����ɵķ���ID DBO.FUN_GETGUID(NEWID(),GETDATE())
                                "SELECT '" + newFeeId + "',a.jgbm,Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                                "cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                                "2,a.id,0,0," +
                                "-1*" + num_cz.ToString() + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price*dosage)*" + czcs + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price*dosage)*" + czcs + ",type,tlfs,gcys,pvs_xh,zfbl," + //Modify By Tany 2004-11-10 ����dosage����ǰû�У�������
                                sSql2 +
                                " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        }

                        FrmMdiMain.Database.BeginTransaction();
                        try
                        {
                            FrmMdiMain.Database.DoCommand(sSql);

                            //Add By Tany 2015-05-27 ����Ƿ�����Ҫ������˵����ݣ�д����˷��ñ��������ֻ��ȡ��Щ����
                            if (_isUnjz)
                            {
                                sSql = "insert into zy_czfee(feeid) values ('" + newFeeId + "')";
                                FrmMdiMain.Database.DoCommand(sSql);
                            }

                            //add by zouchihua 2012-2-21
                            #region ������������
                            try
                            {
                                if (!zczyz_notfy)
                                {
                                    string cfg6035 = new SystemCfg(6035).Config.Trim();
                                    if (cfg6035 == "1" && myTb.Rows[i]["xmly"].ToString().Trim() == "1")
                                    {
                                        myFunc.CzJxnkc(new Guid(myTb.Rows[i]["ID"].ToString().Trim()), czcs, Convert.ToDecimal(myTb.Rows[i]["����"]));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            #endregion

                            //�����־
                            if (myTb.Rows[i]["��������"].ToString().Trim() != "�������")
                            {
                                sSql = "update zy_fee_speci set cz_flag=1 where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                FrmMdiMain.Database.DoCommand(sSql);
                                nFeeID += myTb.Rows[i]["ID"].ToString().Trim();
                            }

                            //Modify By Tany 2010-01-23 ҽ���˷�Ҳ��Ҫѭ���������˷ѽ������ϴ��˷ѽ��+��εģ������ڳ���ҽ��
                            if (nType == 5 && Convert.ToInt32(myTb.Rows[i]["TYPE"]) == 1)
                            {
                                tfje = num_cz * Convert.ToDecimal(myTb.Rows[i]["����"]) * Convert.ToDecimal(myTb.Rows[i]["����"]);

                                if (tfje != 0)
                                {
                                    sSql = "update yj_zysq set btfbz=1,tfje=tfje+(-1*" + tfje + ") where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'";
                                    FrmMdiMain.Database.DoCommand(sSql);

                                    //Modify by Tany 2011-03-16 ���ҽ���˷�ֱ�Ӽ��ˣ�����Ҫ����ҽ��ȷ��
                                    if (cfg7053.Config == "0")
                                    {
                                        Guid newYjqrid = Guid.Empty;
                                        int errCode = -1;
                                        string errMsg = "";
                                        Guid yjsqid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select yjsqid from yj_zysq where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'"), Guid.Empty.ToString()));
                                        DateTime nowTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                        //add by zouchihua 2011-12-18 yjsqidΪ��ʱ����
                                        if (yjsqid != Guid.Empty)
                                        {
                                            ts_yj_class.yjqr.yj_zysq_qrjl(new Guid(myTb.Rows[i]["order_id"].ToString()),
                                               new Guid(myTb.Rows[i]["orderexec_id"].ToString()),
                                               yjsqid,
                                               -tfje,
                                               Convert.ToInt32(myTb.Rows[i]["dept_br"].ToString()),
                                               nowTime.ToString(),
                                               FrmMdiMain.CurrentUser.EmployeeId,
                                               0,
                                               nowTime.ToString(),
                                               0,
                                               "",
                                               out newYjqrid,
                                               out errCode,
                                               out errMsg,
                                               0,
                                               FrmMdiMain.Database);
                                            if (errCode != 0)
                                            {
                                                throw new Exception("ҽ����Ŀ����ȷ��ʱ����" + errMsg);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ////add by zouchihua 2014-4-7  7053����ʱ(Ϊ1ʱ)�����ܿ��Ƶ�ִ�п��ң�����ö��Ÿ���
                                        string cfgvalues = ("," + cfg7192.Config.Trim() + ",");
                                        if (cfgvalues.Contains("," + myTb.Rows[i]["EXECDEPT_ID"].ToString().Trim() + ","))
                                        {
                                            Guid newYjqrid = Guid.Empty;
                                            int errCode = -1;
                                            string errMsg = "";
                                            Guid yjsqid = new Guid(Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select yjsqid from yj_zysq where yzid='" + new Guid(myTb.Rows[i]["order_id"].ToString()) + "' and zxid='" + new Guid(myTb.Rows[i]["orderexec_id"].ToString()) + "'"), Guid.Empty.ToString()));
                                            DateTime nowTime = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
                                            //add by zouchihua 2011-12-18 yjsqidΪ��ʱ����
                                            if (yjsqid != Guid.Empty)
                                            {
                                                ts_yj_class.yjqr.yj_zysq_qrjl(new Guid(myTb.Rows[i]["order_id"].ToString()),
                                                   new Guid(myTb.Rows[i]["orderexec_id"].ToString()),
                                                   yjsqid,
                                                   -tfje,
                                                   Convert.ToInt32(myTb.Rows[i]["dept_br"].ToString()),
                                                   nowTime.ToString(),
                                                   FrmMdiMain.CurrentUser.EmployeeId,
                                                   0,
                                                   nowTime.ToString(),
                                                   0,
                                                   "",
                                                   out newYjqrid,
                                                   out errCode,
                                                   out errMsg,
                                                   0,
                                                   FrmMdiMain.Database);
                                                if (errCode != 0)
                                                {
                                                    throw new Exception("ҽ����Ŀ����ȷ��ʱ����" + errMsg);
                                                }
                                            }
                                        }
                                    }
                                }
                                else//Modify By Tany 2010-05-27
                                {
                                    throw new Exception("ҽ����Ŀ�������Ϊ0�������������");
                                }
                            }

                            FrmMdiMain.Database.CommitTransaction();
                        }
                        catch (Exception err)
                        {
                            FrmMdiMain.Database.RollbackTransaction();
                            MessageBox.Show(err.Message);
                            return;
                        }

                        //����δ��ҩ����Ϣ�Ƿ��Զ�ɾ������Ϣ
                        //Modify By Tany 2005-12-06
                        #region ����δ��ҩ����Ϣ�Ƿ��Զ�ɾ������Ϣ

                        if ((new SystemCfg(7026)).Config == "��" && nType != 5 && sfxyqr == false) //!(nType == 5 && (new SystemCfg(7053)).Config == "1") Modify By tany 2011-03-16 ҽ�������ǲ�����Ҫȷ�ϣ�������ɾ��
                        {
                            //Modify By Tany 2011-03-16 �ڴ�����ˢ�·��ü�¼����Ϣ
                            sSql = "select * from zy_fee_speci where delete_bit=0 and id='" + myTb.Rows[i]["ID"].ToString() + "'";
                            DataTable tmpTb = FrmMdiMain.Database.GetDataTable(sSql);
                            if (tmpTb != null && tmpTb.Rows.Count > 0)
                            {
                                //���û�з�ҩ ���� û��ҽ���ϴ� ���� (û�м��� ���� �������ڵ��ڽ���)
                                if (
                                    tmpTb.Rows[0]["fy_bit"].ToString() == "0" && tmpTb.Rows[0]["scbz"].ToString() == "0"
                                    &&
                                    (
                                    tmpTb.Rows[0]["charge_bit"].ToString() == "0"
                                    //|| (tmpTb.Rows[0]["charge_bit"].ToString() == "1" && Convert.ToDateTime(tmpTb.Rows[0]["charge_date"]).ToShortDateString() == DateManager.ServerDateTimeByDBType(FrmMdiMain.Database).ToShortDateString())
                                    )
                                   )
                                {

                                    sSql = "select sum(num) as num  from zy_fee_speci where  delete_bit=0 and (id='" + myTb.Rows[i]["ID"].ToString() + "' or cz_id='" + myTb.Rows[i]["ID"].ToString() + "')";
                                    if (cfg7191.Config.Trim() == "1")
                                    {
                                        //����ǽ������ݴ�ҩ�ģ�����������Զ�ɾ��
                                        sSql += " and TLFS<>9 ";
                                    }
                                    DataTable myTmpTb = FrmMdiMain.Database.GetDataTable(sSql);
                                    if (myTmpTb != null && myTmpTb.Rows.Count != 0)
                                    {
                                        if (myTmpTb.Rows[0]["num"].ToString().Trim() != "")
                                        {
                                            //����Ѿ�ȫ���������
                                            if (Convert.ToDecimal(myTmpTb.Rows[0]["num"]) == 0)
                                            {
                                                //�ٿ�һ�³�����ҩƷ�����Ƿ����Ѿ���ҩ��
                                                //Modify By tany 2011-03-16 �������ϴ���
                                                sSql = "select fy_bit,scbz from zy_fee_speci where delete_bit=0 and cz_id='" + myTb.Rows[i]["ID"].ToString() + "'";
                                                DataTable myTmpTb1 = FrmMdiMain.Database.GetDataTable(sSql);
                                                bool isFinish = false;

                                                for (int k = 0; k < myTmpTb1.Rows.Count; k++)
                                                {
                                                    if (myTmpTb1.Rows[k]["fy_bit"].ToString() == "1"
                                                        || myTmpTb1.Rows[k]["scbz"].ToString() == "1")
                                                    {
                                                        isFinish = true;
                                                        break;
                                                    }
                                                }

                                                if (isFinish == false)
                                                {
                                                    string[] sql = new string[2];
                                                    sql[0] = "update zy_fee_speci set delete_bit=1,bz=isnull(bz,'')+'����ɾ��' where fy_bit=0 and scbz=0 and id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                                    sql[1] = "update zy_fee_speci set delete_bit=1,bz=isnull(bz,'')+'����ɾ��' where fy_bit=0 and scbz=0 and cz_id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                                                    FrmMdiMain.Database.DoCommand(null, null, null, sql);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        this.progressBar1.Value += 1;
                    }
                }

                #region"ҽ������ӿڵ���"

                bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(ClassStatic.Current_BinID.ToString(), InstanceForm.BDatabase);//�Ƿ���Ҫ����
                if (CanAudit)
                {
                    if (ClassStatic.Current_BabyID == 0)
                    {
                        string strMsg = "";
                        bool bSuc = DoVaildYbFee(myTb, MNGType, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, out strMsg);
                        if (!bSuc)
                        {
                            //MessageBox.Show(strMsg, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                #endregion

                if (nType == 1 || nType == 2)
                {
                    //ҽ�����ͣ����ˣ��Ƿ��Զ�����ҩƷͳ����Ϣ
                    //Modify By Tany 2005-11-05
                    if ((new SystemCfg(7047)).Config == "��")
                    {
                        //���ͳ���ҩƷͳ����Ϣ
                        System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

                        string yfSql = "";
                        DataTable yfTb = new DataTable();

                        //������ִ��ҩƷͳ��
                        //�����ҽ�����ڵĲ��������ڵ�ǰ����������ҽ�����ڲ�������Ҫ����ת����ǰ��ҽ�� Modify By Tany 2005-03-16
                        if (ward_id.Trim() == FrmMdiMain.CurrentDept.WardId.Trim() || isSSMZ || isTSZL)
                        {
                            string strErrWard = "";
                            string strErrExeDept = "";
                            try
                            {
                                yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                                yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                                for (int i = 0; i < yfTb.Rows.Count; i++)
                                {
                                    strErrWard = FrmMdiMain.CurrentDept.WardId;
                                    strErrExeDept = yfTb.Rows[i]["execdept_id"].ToString().Trim();
                                    //��ͳ��ҩƷ��Ϣ Modify By Tany 2005-09-13
                                    myFunc.SendYPFY(0, 1, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                    //��ͳ��ҩƷ����ҩ�� Add by zouchihua 2013-5-29 ���·��͵�ҲҪ��������
                                    myFunc.SendYPFY(2, 1, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                }

                                ////Modify by zouchihua ���Ӳ������ڲ��� 2013-7-17
                                DataTable tbtmb = FrmMdiMain.Database.GetDataTable(" SELECT WARD_ID FROM JC_WARD WHERE WARD_ID in (SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=" + myTb.Rows[0]["DEPT_BR"].ToString() + " )");
                                if (tbtmb != null && tbtmb.Rows.Count > 0)
                                {
                                    for (int j = 0; j < tbtmb.Rows.Count; j++)
                                    {
                                        strErrWard = tbtmb.Rows[j]["WARD_ID"].ToString();
                                        strErrExeDept = yfTb.Rows[j]["execdept_id"].ToString().Trim();
                                        myFunc.SendYPFY(0, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                        myFunc.SendYPFY(2, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ͳ�쳬ʱ",
                                    "������" + strErrWard + "  �������ң�" + (FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId) + " �����ˣ�" + FrmMdiMain.CurrentUser.EmployeeId + " ����ʱ�䣺 " + ExecDate + "  ִ�п��ң�" + strErrExeDept,
                                    DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);

                                _sysLog.Save();

                                throw ex;
                            }
                        }
                        else
                        {
                            string strErrWard = "";
                            string strErrExeDept = "";
                            try
                            {
                                yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + ward_id + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                                yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                                for (int i = 0; i < yfTb.Rows.Count; i++)
                                {
                                    strErrWard = ward_id;
                                    strErrExeDept = yfTb.Rows[i]["execdept_id"].ToString().Trim();
                                    //��ͳ��ҩƷ��Ϣ Modify By Tany 2005-09-13
                                    myFunc.SendYPFY(0, 1, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                    //��ͳ��ҩƷ����ҩ�� Add by zouchihua 2013-5-29 ���·��͵�ҲҪ��������
                                    myFunc.SendYPFY(2, 1, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                                }
                                ////Modify by zouchihua ���Ӳ������ڲ��� 2013-7-17
                                DataTable tbtmb = FrmMdiMain.Database.GetDataTable(" SELECT WARD_ID FROM JC_WARD WHERE WARD_ID in (SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID=" + myTb.Rows[0]["DEPT_BR"].ToString() + " )");
                                if (tbtmb != null && tbtmb.Rows.Count > 0)
                                {
                                    for (int j = 0; j < tbtmb.Rows.Count; j++)
                                    {
                                        strErrWard = tbtmb.Rows[j]["WARD_ID"].ToString();
                                        strErrExeDept = yfTb.Rows[j]["execdept_id"].ToString().Trim();
                                        myFunc.SendYPFY(0, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                        myFunc.SendYPFY(2, 1, tbtmb.Rows[j]["WARD_ID"].ToString(), FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[j]["execdept_id"]), FrmMdiMain.Jgbm);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ͳ�쳬ʱ",
                                    "������" + strErrWard + "  �������ң�" + (FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId) + " �����ˣ�" + FrmMdiMain.CurrentUser.EmployeeId + " ����ʱ�䣺 " + ExecDate + "  ִ�п��ң�" + strErrExeDept,
                                    DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);

                                _sysLog.Save();

                                throw ex;
                            }
                        }
                    }
                }

                //Add By Tany 2005-02-21
                #region ����Һֱ�ӼǷ� ��ʱ������
                //			if(PubStaticFun.GetSystemConfig(11004)=="��")
                //			{
                //				for(int i=0;i<=myTb.Rows.Count-1;i++)
                //				{
                //					//��ѡ��
                //					if(myTb.Rows[i]["ID"].ToString().Trim()!="" && myTb.Rows[i]["ѡ"].ToString()=="True" )
                //					{	
                //						//��ҩƷ
                //						if (!(myTb.Rows[i]["item_code"].ToString()=="" || myTb.Rows[i]["item_code"].ToString().Trim()=="-1"))
                //						{
                //							//�ǻ���ҩ
                //							if(Convert.ToInt16(myTb.Rows[i]["����ҩ"])==0)
                //							{
                //								string dsyStr = "Select b_dsy from YK_VYD where s_hh='"+myTb.Rows[i]["item_code"].ToString()+"'";
                //								DataTable dsyTb = InstanceForm.BDatabase.GetDataTable(dsyStr);
                //
                //								if(dsyTb!=null && dsyTb.Rows.Count>0)
                //								{
                //									//�Ǵ���Һֱ�Ӽ���
                //									if(Convert.ToInt32(dsyTb.Rows[0][0])==1)
                //									{
                //										sSql="update zy_fee_speci set charge_bit=1,charge_date=getdate(),charge_user="+InstanceForm.BCurrentUser.EmployeeId+
                //											" where cz_flag=2 and charge_bit=0 and CZ_ID="+myTb.Rows[i]["ID"].ToString().Trim()+
                //											"       and subcode='"+myTb.Rows[i]["item_code"].ToString()+"'";
                //										InstanceForm.BDatabase.DoCommand(sSql);
                //									}
                //								}
                //							}
                //						}
                //					}
                //				}
                //			}
                #endregion

                #region//add by zouchihua 2013-4-23 �������ʱҽ����������������Ϊ0����ôֱ�Ӵ���δִ�С�һ���������������ҽ�������Բ����ǲ���ҽ����Ҳ����ѷ���ɾ����
                if (this.lb1.Text.Trim().IndexOf("��ʱҽ��") >= 0 && new SystemCfg(7149).Config.Trim() == "1")
                {
                    string sql = "select SUM(ACVALUE) fee from ZY_FEE_SPECI where INPATIENT_ID='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + "  and DELETE_BIT=0 "
                               + "   and CHARGE_BIT=1 and ORDER_ID in(select a.ORDER_ID from ZY_ORDERRECORD a join ZY_ORDERRECORD b on a.ORDER_ID=b.ORDER_ID where a.ORDER_ID='" + order_id + "')   ";
                    decimal _fy = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sql), "0"));
                    if (_fy == 0)
                    {
                        //δִ��
                        //дֹͣ��־��δִ�б�־ 
                        sql = "update zy_orderrecord set order_context='��ȡ����'+order_context,wzx_flag=" + InstanceForm.BCurrentUser.EmployeeId + ",status_flag=5 ,order_edate=getdate() , memo2='���ó������Զ�����δִ�С�' " //Modify By Tany 2005-01-31 ,order_edate=getdate() //add by zouchihua 2012-6-15����δִ�е�ԭ��
                            + " where GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')   "

                            + "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        FrmMdiMain.Database.DoCommand(sql);

                        sql = " update zy_orderexec  set REALEXEUSER='" + FrmMdiMain.CurrentUser.EmployeeId + "' where  order_id in ( select order_id from ZY_ORDERRECORD where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                             " and baby_id=" + ClassStatic.Current_BabyID + " and GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')  ) ";
                        FrmMdiMain.Database.DoCommand(sql);
                        #region//add by zouchihua ͬʱ����ҽ����ӡ��¼�� 2013-4-23
                        //sSql = "  update ZY_LOGORDERPRT set order_context='��ȡ����'+order_context  " +
                        //   " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                        //    "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;
                        //  InstanceForm.BDatabase.DoCommand(sSql);
                        sql = "  update ZY_TMPORDERPRT set order_context='��ȡ����'+order_context  "
                            + " where GROUP_ID in(select GROUP_ID from ZY_ORDERRECORD where ORDER_ID='" + order_id + "')   "

                            + "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID;//û�д�ӡ�������
                        InstanceForm.BDatabase.DoCommand(sql);

                        sSql = "  update ZY_TMPORDERPRT set    PRT_STATUS=4,memo='ȡ��'  " +
                                 " where group_id=" + myTb.Rows[nrow]["Group_ID"].ToString().Trim() +
                                  "       and inpatient_id='" + ClassStatic.Current_BinID + "' and baby_id=" + ClassStatic.Current_BabyID + " and PRT_STATUS not in(0,-1)";//��ӡ�������
                        InstanceForm.BDatabase.DoCommand(sSql);
                        #endregion
                    }
                }
                #endregion
                //д��־ Add By Tany 2005-03-29
                SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ҽ������", "��fee_id=" + nFeeID + "��ҽ������", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                this.progressBar1.Value = 0;
            }
            catch (Exception err)
            {
                //SystemLog _sysLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ҽ������", "��fee_id=" + nFeeID + "��ҽ������", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
                //_sysLog.Save();
                MessageBox.Show(err.Message);
            }
            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //ֻ����������
            if (e.KeyChar == 13) bt����.Focus();
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8))
                e.Handled = true;
        }

        private void btȡ������_Click(object sender, System.EventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;
            string sSql = "";
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;

            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;

            //Modify By Tany 2011-03-14 ҽ����Ĳ�����ȡ������
            if (nType == 5)
            {
                MessageBox.Show("�Բ���ҽ�����ҽ���������ķ��ò�����ȡ�������������¿���ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.rbÿ��ҽ��.Checked)
            {
                if (MessageBox.Show(this, "ȷ�Ͻ�ѡ���ÿ��ҽ��ȡ��������", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            else
            {
                if (MessageBox.Show(this, "ȷ�Ͻ�ѡ���ÿ��ҽ��ȡ��������", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            //Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
            if (new SystemCfg(7066).Config == "0")
            {
                frmInPassword f1 = new frmInPassword();
                f1.ShowDialog();
                if (f1.isLogin == false) return;
                f1.Close();
            }
            bool isHSZ = myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);

            if (isHSZ == false)
            {
                //�Ƿ�ֻ�л�ʿ���ܹ��������� Add By Tany 2007-09-12
                if ((new SystemCfg(7033)).Config == "��")
                {
                    MessageBox.Show("�Բ���ֻ�л�ʿ���ܹ�ȡ���������ã�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Cursor.Current = PubStaticFun.WaitCursor();

            #region ��ȫ���ж�
            //��ȫ���жϷ��������֤���棬�������ͬʱ����ʱ���ظ����
            //Modify By Tany 2005-03-26
            int iSelectRows = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    if (myTb.Rows[i]["��������"].ToString() != "���ʷ���")
                    {
                        MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "�в��ǳ�����¼����ѡ�������¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        myTb.Rows[i]["ѡ"] = false;
                        return;
                    }
                    //add by zouchihua 2012-11-14 ���ƿ��Զ�ͬһ��������¼���ж�Ρ�ȡ�����ˡ�
                    string sql = " select sum(num) num from ZY_FEE_SPECI where  ORDEREXEC_ID='" + myTb.Rows[i]["ORDEREXEC_ID"].ToString() + "'  and order_id='" + myTb.Rows[i]["order_ID"].ToString() + "'  and cz_flag in(2,3)";
                    DataTable temp = FrmMdiMain.Database.GetDataTable(sql);
                    if (temp.Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(temp.Rows[0]["num"].ToString()) >= 0)
                        {
                            MessageBox.Show(this, "�Բ��𣬵�" + (i + 1) + "���Ѿ�ȡ�������ˣ���������ȡ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myTb.Rows[i]["ѡ"] = false;
                            return;
                        }
                    }
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ�������¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            string sFeeID = "";
            string ward_id = "";
            string ward_deptid = "";

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    if (ward_id == "" || ward_deptid == "")
                    {
                        ward_id = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select ward_id from zy_orderrecord where order_id ='" + myTb.Rows[i]["order_id"].ToString() + "'"), "");
                        ward_deptid = Convertor.IsNull(FrmMdiMain.Database.GetDataResult("select dept_id from jc_ward where ward_id ='" + ward_id + "'"), "");
                    }
                    try
                    {
                        InstanceForm.BDatabase.BeginTransaction();
                        //add by zouchihua 2012-2-21
                        #region ������������
                        try
                        {
                            string cfg6035 = new SystemCfg(6035).Config.Trim();
                            if (cfg6035 == "1" && myTb.Rows[i]["xmly"].ToString().Trim() == "1")
                            {
                                myFunc.CzJxnkc(new Guid(myTb.Rows[i]["ID"].ToString().Trim()), 0, Convert.ToDecimal(myTb.Rows[i]["����"]));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion

                        //���ܼ򵥵�ɾ������������һ������
                        //Modify By Tany 2005-12-30
                        //					sSql="update zy_fee_speci set delete_bit=1 where id="+myTb.Rows[i]["ID"].ToString().Trim();
                        sSql = "INSERT INTO ZY_FEE_SPECI" +
                            " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                            " cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                            " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                            " num,sdValue,acValue,type,tlfs,gcys," +
                            " charge_bit,charge_date,charge_user,pvs_xh ) " +
                            " SELECT DBO.FUN_GETGUID(NEWID(),GETDATE())," + FrmMdiMain.Jgbm + ",Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                            " cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                            " 3,DBO.FUN_GETEMPTYGUID(),0,0," +
                            //" -1*num,-1*num*retail_Price*dosage,-1*num*retail_Price*dosage,type,0,gcys," + 
                            " -1*num,-1*sdValue,-1*acValue,type,tlfs,gcys," + //Modify By Tany 2010-05-04 ���ԭ����ʲô����ʲô
                            " 1,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",pvs_xh" +//����pivas��� Modify By Tany 2015-04-22
                            " from zy_fee_speci a where id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        InstanceForm.BDatabase.DoCommand(sSql);

                        //					sSql="update zy_fee_speci set finish_bit=1 where id="+myTb.Rows[i]["ID"].ToString().Trim();
                        //					InstanceForm.BDatabase.DoCommand(sSql);	

                        sFeeID += myTb.Rows[i]["ID"].ToString().Trim() + ",";
                        InstanceForm.BDatabase.CommitTransaction();
                        #region �µ�ȡ����������Ҫ���´�����
                        /*
					//Modify By Tany 2005-10-06
					//�õ�����ķ���ID
					sSql="select cz_id from zy_fee_speci where id="+myTb.Rows[i]["ID"].ToString().Trim();
					long _czID=Convert.ToInt64(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//�õ���ͱ���������ܺ�
					sSql="select sum(num) as num  from zy_fee_speci where delete_bit=0 and (id="+_czID+" or cz_id="+_czID+")";
					decimal _totalNum=Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//�õ�������Ŀ��ԭ������
					sSql="select sum(num) as num  from zy_fee_speci where delete_bit=0 and id="+_czID;
					decimal _Num=Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(sSql),"0"));

					//�������������ȣ���ʾ���еĳ��˱�ɾ��������Ҫ�ѱ�����õı�Ǹĳ�������ǣ�ɾ�����ҲҪ�ָ�
					if(_totalNum==_Num)
					{
						sSql="update zy_fee_speci set cz_flag=0,delete_bit=0 where id="+_czID;
						InstanceForm.BDatabase.DoCommand(sSql);
					}
					else
					{
						sSql="update zy_fee_speci set delete_bit=0 where id="+_czID;
						InstanceForm.BDatabase.DoCommand(sSql);
					}
					*/
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        InstanceForm.BDatabase.RollbackTransaction();
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            #region"ҽ������ӿڵ���"

            bool CanAudit = ClsAuditCheck.CheckIsAuditCheck(ClassStatic.Current_BinID.ToString(), InstanceForm.BDatabase);//�Ƿ���Ҫ����
            if (CanAudit)
            {
                if (ClassStatic.Current_BabyID == 0)
                {
                    string strMsg = "";
                    bool bSuc = DoVaildYbFee(myTb, MNGType, ClassStatic.Current_BinID, ClassStatic.Current_BabyID, out strMsg);
                    if (!bSuc)
                    {
                        MessageBox.Show(strMsg, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            #endregion

            //д��־ Add By Tany 2005-03-29
            SystemLog _systemLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, FrmMdiMain.CurrentUser.EmployeeId, "ҽ��ȡ������", "��fee_id=" + sFeeID + "��ҽ��ȡ������", DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
            _systemLog.Save();
            _systemLog = null;

            if (nType == 1 || nType == 2)
            {
                //ҽ�����ͣ����ˣ��Ƿ��Զ�����ҩƷͳ����Ϣ
                //Modify By Tany 2005-11-05
                if ((new SystemCfg(7022)).Config == "��")
                {
                    //���ͳ���ҩƷͳ����Ϣ
                    System.DateTime ExecDate = DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);

                    string yfSql = "";
                    DataTable yfTb = new DataTable();

                    //������ִ��ҩƷͳ��
                    //�����ҽ�����ڵĲ��������ڵ�ǰ����������ҽ�����ڲ�������Ҫ����ת����ǰ��ҽ�� Modify By Tany 2005-03-16
                    if (ward_id.Trim() == FrmMdiMain.CurrentDept.WardId.Trim() || isSSMZ)
                    {
                        yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                            " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + FrmMdiMain.CurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                        yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                        for (int i = 0; i < yfTb.Rows.Count; i++)
                        {
                            //��ͳ��ҩƷ��Ϣ Modify By Tany 2005-09-13
                            myFunc.SendYPFY(0, 0, FrmMdiMain.CurrentDept.WardId, FrmMdiMain.CurrentDept.WardDeptId == 0 ? FrmMdiMain.CurrentDept.DeptId : FrmMdiMain.CurrentDept.WardDeptId, FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                        }
                    }
                    else
                    {
                        yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                            " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + ward_id + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                        yfTb = FrmMdiMain.Database.GetDataTable(yfSql);

                        for (int i = 0; i < yfTb.Rows.Count; i++)
                        {
                            //��ͳ��ҩƷ��Ϣ Modify By Tany 2005-09-13
                            myFunc.SendYPFY(0, 0, ward_id, Convert.ToInt64(ward_deptid) == 0 ? FrmMdiMain.CurrentDept.DeptId : Convert.ToInt64(ward_deptid), FrmMdiMain.CurrentUser.EmployeeId, ExecDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                        }
                    }
                }
            }

            this.progressBar1.Value = 0;

            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private string GetOrderTypeName(long _nType)
        {
            string _typeName = "";

            switch (_nType)
            {
                case 0:
                    _typeName = "��Ժ";
                    break;
                case 1:
                    _typeName = "��ҩ";
                    break;
                case 2:
                    _typeName = "��ҩ";
                    break;
                case 3:
                    _typeName = "��ҩ";
                    break;
                case 4:
                    _typeName = "����";
                    break;
                case 5:
                    _typeName = "ҽ��";
                    break;
                case 6:
                    _typeName = "����";
                    break;
                case 7:
                    _typeName = "˵��";
                    break;
                case 8:
                    _typeName = "����";
                    break;
                case 9:
                    _typeName = "����";
                    break;
            }

            return _typeName;
        }

        private void cb��ʾ��ɾ������_CheckedChanged(object sender, System.EventArgs e)
        {
            ShowData();
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            string sSql = "";
            string strSql = "";
            DataTable myTempTb = new DataTable();
            DataTable decoctTb = new DataTable();
            Guid n_id = Guid.Empty;
            string msg = "";
            int iYZH = 0;

            if (MessageBox.Show(this, "ȷ��Ҫ���Ӳ�ҩ��ҩ����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            strSql = "select id,order_id from zy_decoct where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                " and group_id=" + Group_ID;
            decoctTb = FrmMdiMain.Database.GetDataTable(strSql);

            if (decoctTb.Rows.Count > 0)
            {
                n_id = new Guid(decoctTb.Rows[0][0].ToString().Trim());
            }
            else
            {
                n_id = PubStaticFun.NewGuid();
                strSql = "insert into zy_decoct(id,inpatient_id,order_id,group_id,jgbm) values ('" + n_id + "','" + ClassStatic.Current_BinID + "','" + Guid.Empty + "'," + Group_ID + "," + FrmMdiMain.Jgbm + ")";
                FrmMdiMain.Database.DoCommand(strSql);

                if (n_id == null || n_id == Guid.Empty)
                {
                    MessageBox.Show("����ZY_DECOCT��idΪ��ֵ���޷��������ݣ�");
                    return;
                }
            }

            //ȡ��ҩ��
            sSql = @"Select a.order_id,a.order_name,a.order_unit,a.order_type,a.default_dept " +
            " from jc_hoitemdiction a " +
            " where a.order_id=" + new SystemCfg(7014).Config;
            myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
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
                    v_exec_dept = ClassStatic.Current_DeptID;//Convert.ToInt64(myTb.Rows[i]["dept_br"]);
                }
                else
                {
                    v_exec_dept = Convert.ToInt64(myTempTb.Rows[0]["default_dept"]);
                }

                //ȡ���
                sSql = @"select max(Group_Id) as YZH " +
                    "  from Zy_OrderRecord " +
                    " where inpatient_id='" + ClassStatic.Current_BinID + "'" +
                    "       and baby_id=" + ClassStatic.Current_BabyID;
                myTempTb = FrmMdiMain.Database.GetDataTable(sSql);
                if (myTempTb.Rows[0]["YZH"].ToString().Trim() == "")
                {
                    iYZH = 0;
                }
                else
                {
                    iYZH = Convert.ToInt32(myTempTb.Rows[0]["YZH"]) + 1;
                }

                //				//�������ݷ��ʶ���
                //				RelationalDatabase database=RelationalDatabase.GetDatabase(DatabaseType.IbmDb2ZY);
                //				database.Initialize("");
                //				database.Open();				
                //				//��ʼһ������
                //				database.BeginTransaction();

                FrmMdiMain.Database.BeginTransaction();

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
                        "VALUES('" + v_O_id + "'," + FrmMdiMain.Jgbm + ", '" + ClassStatic.Current_BinID + "'," + ClassStatic.Current_BabyID +
                        ",'" + FrmMdiMain.CurrentDept.WardId + "'," + ClassStatic.Current_DeptID + "," + ClassStatic.Current_DeptID +
                        ",3,getdate()," + iYZH.ToString() + "," + v_order_type + "," +
                        v_hoitem_id + ",2,'" + v_order_context + "'," + lb22.Text + ",1,'" + v_unit + "','',''," +
                        v_exec_dept + ", 1,2," +
                        FrmMdiMain.CurrentUser.EmployeeId.ToString() + ",getdate() ," + FrmMdiMain.CurrentUser.EmployeeId.ToString() + ",getdate(),0)";

                    FrmMdiMain.Database.DoCommand(strSql);

                    if (v_O_id == null || v_O_id == Guid.Empty)
                    {
                        throw new Exception("û������Order_id���޷��������ݣ�");
                    }

                    strSql = "update zy_decoct set order_id='" + v_O_id + "' where id='" + n_id + "'";
                    FrmMdiMain.Database.DoCommand(strSql);

                    FrmMdiMain.Database.CommitTransaction();

                    MessageBox.Show("���Ӳ�ҩ��ҩ�ѳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmYZXX_Load(null, null);
                }
                catch (Exception err)
                {
                    FrmMdiMain.Database.RollbackTransaction();

                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, FrmMdiMain.CurrentDept.DeptId, Convert.ToInt32(FrmMdiMain.CurrentUser.EmployeeId), "�������", "ҽ��ת������" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(FrmMdiMain.Database), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("���󣺽���ҩ�Ѳ�����ʱ�˵��������ֹ����ɼ�ҩ�ѣ�\nϵͳ��" + err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                //				finally
                //				{
                //					database.Close();
                //				}
            }
        }

        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
            if (cfg7207.Config == "0")
            {
                if (this.nType != 3 || lb24.Text.IndexOf("�Լ�") >= 0 || isCX || isUNCZ)
                {
                    menuItem1.Enabled = false;
                }
                else
                {
                    menuItem1.Enabled = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "���û���")
            {
                DataTable myTb = (DataTable)myDataGrid1.DataSource;
                if (myTb == null) return;
                if (myTb.Rows.Count < 1) return;

                DataTable myTb1 = myTb.Clone();

                string _tmp = "";

                if (rbAll.Checked)
                    _tmp = "";

                if (rbCharge.Checked)
                    _tmp = " and charge_bit=1";

                if (rbUncharge.Checked)
                    _tmp = " and charge_bit=0";


                DataRow[] drM = myTb.Select("delete_bit=0 " + _tmp);

                for (int i = 0; i < drM.Length; i++)
                {
                    DataRow myRow = myTb1.NewRow();
                    myRow.ItemArray = drM[i].ItemArray;
                    myRow["����"] = Convert.ToDecimal(myRow["����"]) * Convert.ToDecimal(myRow["����"]) * Convert.ToDecimal(myRow["����"]);
                    myTb1.Rows.Add(myRow.ItemArray);
                }

                string[] GroupbyField ={ "����", "��λ", "����" };
                string[] ComputeField ={ "����", "���" };
                string[] CField ={ "sum", "sum" };

                TsSet tsset = new TsSet();
                tsset.TsDataTable = myTb1;

                string[] GroupbyField1 ={ };
                string[] ComputeField1 ={ "���" };
                string[] CField1 ={ "sum" };

                TsSet tsset1 = new TsSet();
                tsset1.TsDataTable = myTb1;

                //����ÿ��ͳ�����
                DataTable tb = tsset.GroupTable(GroupbyField, ComputeField, CField, "", false);

                DataTable tb1 = tsset1.GroupTable(GroupbyField1, ComputeField1, CField1, "", false);

                DataRow dr = tb.NewRow();
                dr["����"] = "�ϼ�";
                dr["���"] = tb1.Rows.Count > 0 ? tb1.Rows[0]["���"] : 0;

                tb.Rows.Add(dr);

                dataGridEx1.DataSource = tb;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count < 1) return;
            bool zc = false;
            try
            {
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ID"].ToString().Trim() != "" && myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        //�����������
                        string sql = "select * from ZY_FEE_SPECI    where XMLY=1  and charge_bit=0 and DELETE_BIT=0 and CZ_FLAG in(2) and SCBZ=0 and FY_BIT=0 and id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'";
                        DataTable tb = FrmMdiMain.Database.GetDataTable(sql);
                        if (tb.Rows.Count > 0)
                        {
                            FrmMdiMain.Database.DoCommand("   update ZY_FEE_SPECI set DELETE_BIT=1,BZ=isnull(BZ,'')+'�ֶ�ȡ��ɾ��' where  id='" + myTb.Rows[i]["ID"].ToString().Trim() + "'");
                            FrmMdiMain.Database.DoCommand("   update ZY_FEE_SPECI set  cz_flag=0 where  id='" + tb.Rows[0]["cz_ID"].ToString().Trim() + "'");
                            zc = true;
                        }
                        else
                        {
                            MessageBox.Show("�ò���ֻ����û�з�ҩ�����ҡ�û��ҽ���ϴ�������ҩ��¼");
                            this.ShowData();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (zc)
                    this.ShowData();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbsl.Checked)
                label17.Text = "";
            else
                label17.Text = "��";
        }

        //add by jchl(7603=0������is_PvsScn=1 return false)
        private bool CanOrderRecCz(string isPvsScn)
        {
            SystemCfg cfg7603 = new SystemCfg(7603);

            //7603=0������is_PvsScn=1   ���������
            if (cfg7603.Config.Trim().Equals("0") && isPvsScn.Trim().Equals("1"))
                return false;

            return true;
        }

        private bool IsPvsDept(string execDept)
        {
            try
            {
                string strSql = string.Format(@"select count(1) as NUM from JC_DEPT_DRUGSTORE where DRUGSTORE_ID='{0}' and is_PvsRel=1", execDept);

                string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
                int iNum = int.Parse(num);

                if (iNum > 0)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnZdb_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;


            string bdate = _cfg6227.Config.Trim();
            if (!string.IsNullOrEmpty(bdate))
            {
                bdate = DateTime.Now.ToString("yyyy-MM-dd") + " " + bdate;

                try
                {
                    string[] strs = _cfg6228.Config.Split('$');
                    int iHour = int.Parse(strs[0].Trim());
                    int iMin = int.Parse(strs[1].Trim());

                    DateTime kssBDate = DateTime.Parse(bdate);
                    DateTime kssEDate = kssBDate.AddHours(iHour).AddMinutes(iMin);

                    if (DateTime.Compare(kssBDate, DateTime.Now) < 0 && DateTime.Compare(kssEDate, DateTime.Now) > 0)
                    {
                        MessageBox.Show("���ݾ�����ҩ���е������ĵ�Ҫ�󣬸�ʱ��Σ�" + kssBDate.ToShortTimeString() + "-" + kssEDate.ToShortTimeString() + "�����������ת���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch { }
            }

            string ss = "";
            bool bShowZdb = false;
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                {
                    if (myTb.Rows[i]["��������"].ToString().Trim().Equals("���ʷ���"))
                    {
                        ss += myTb.Rows[i]["ҽ������"].ToString() + ":" + myTb.Rows[i]["����"].ToString() + " , ";
                        bShowZdb = true;
                    }
                }
            }

            if (bShowZdb)
            {
                MessageBox.Show(ss + "\n �Ѿ������ķ���,���ܽ���ת�������\n", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ShowData();
                return;
            }


            if (MessageBox.Show(this, "ȷ��ѡ���ÿ��ҽ��ת�����", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            //ArrayList row = new ArrayList();
            //string ss = "";
            ////�Ѿ�����ɨ���˲�����ת�������
            //for (int i = 0; i < myTb.Rows.Count; i++)
            //{
            //    if (myTb.Rows[i]["ѡ"].ToString() == "True")
            //    {
            //        string id = myTb.Rows[i]["ID"].ToString();
            //        string strSql = string.Format(@"select count(1) as Num from ZY_FEE_SPECI where ID='{0}' and is_PvsScn=1", id);

            //        string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
            //        int iNum = int.Parse(num);

            //        if (iNum > 0)
            //        {
            //            row.Add(i);
            //            ss += myTb.Rows[i]["ҽ������"].ToString() + ":" + myTb.Rows[i]["����"].ToString() + " , ";
            //            continue;
            //        }

            //        //
            //        strSql = string.Format(@"update ZY_FEE_SPECI set pvs_zdb=1 where id='{0}'", id);
            //        FrmMdiMain.Database.DoCommand(strSql);
            //    }
            //}

            //if (row.Count > 0)
            //{
            //    MessageBox.Show(ss + "\n ҩ���Ѿ�ɨ�����,����ת�������\n", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.ShowData();
            //    return;
            //}

            //MessageBox.Show("�����ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Cursor.Current = Cursors.Default;

            //this.ShowData();

            DoSetZDB(myTb);
        }

        /// <summary>
        /// ȡ��ת���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;


            if (MessageBox.Show(this, "ȷ��ѡ���ÿ��ҽ�� ȡ��ת��� ��", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            ArrayList row = new ArrayList();
            string ss = "";
            //�Ѿ�����ɨ���˲�����ת�������
            for (int i = 0; i < myTb.Rows.Count; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    string id = myTb.Rows[i]["ID"].ToString();
                    string strSql = string.Format(@"select count(1) as Num from ZY_FEE_SPECI where ID='{0}' and is_PvsScn=1", id);

                    string num = FrmMdiMain.Database.GetDataResult(strSql).ToString().Trim();
                    int iNum = int.Parse(num);

                    if (iNum > 0)
                    {
                        row.Add(i);
                        ss += myTb.Rows[i]["ҽ������"].ToString() + ":" + myTb.Rows[i]["����"].ToString() + " , ";
                        continue;
                    }

                    //
                    strSql = string.Format(@"update ZY_FEE_SPECI set pvs_zdb=0 where id='{0}'", id);
                    FrmMdiMain.Database.DoCommand(strSql);
                }
            }

            if (row.Count > 0)
            {
                MessageBox.Show(ss + "\n ҩ���Ѿ�ɨ�����,���� ȡ��ת��� ����\n", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ShowData();
                return;
            }

            MessageBox.Show("�����ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;

            this.ShowData();
        }

        private bool DoVaildYbFee(DataTable myTb, string BinID, out string strMsg)
        {
            BmiAuditClass class2 = new BmiAuditClass();
            ClsAuditCheck check = new ClsAuditCheck(FrmMdiMain.Database);
            strMsg = "";
            string str = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("δ�ҵ���סԺ�ŵĲ�����Ϣ\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("δ�ҵ���סԺ�ŵĲ�����Ϣ\r" + ex.Message);
                }

                string str4;
                DataTable table = this.DoGetValidateFeeInfo(myTb);
                DataTable postFeeInfo = check.GetPostFeeInfo(table);
                decimal num = 0M;
                DataTable detailFeeInfo = check.GetDetailFeeInfo(postFeeInfo, yblx, ybzlx, out num);


                //string commandtext = string.Format("select INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID='{0}'", BinID.ToString());
                //string str3 = FrmMdiMain.Database.GetDataResult(commandtext).ToString();


                DataTable table4 = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, num, FrmMdiMain.Database);
                str = class2.ClaimAudit4Hospital_N(table4, detailFeeInfo);
                if (str.Equals("0") || str.Equals("2"))
                {
                    str4 = str.Equals("0") ? "ҽ���������ʧ�ܣ�" : "ҽ�����󣺵��ò������";
                    throw new Exception(str4 + "\r\r���ֶ��ϴ��ò��˷��õ��й�����");
                }
                if (str.Equals("3"))
                {
                    str = class2.ClaimAudit4Hospital_S(table4, detailFeeInfo);
                    str4 = str.Equals("0") ? "ҽ���������ʧ�ܣ�" : "ҽ�����󣺵��ò������";
                    if (str.Equals("0") || str.Equals("2"))
                    {
                        throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ��� \r\t ҽ��������˼�⵽����Υ������,��ֹͣΥ��ҽ��,����������,���ֶ��ϴ��ò������з��õ��й�����");
                    }
                    bool flag = check.UpdateScbz(detailFeeInfo);
                    throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ�," + (flag ? "�ɹ����±��ر�ʶ" : "ʧ�ܸ��±��ر�ʶ") + "��\r\tҽ��������˼�⵽����Υ������,��ֹͣΥ��ҽ��,���������ã� \r\t���� �������ݴ������ ���²鿴��ҽ��");
                }
                strMsg = "";
                if (!check.UpdateScbz(detailFeeInfo))
                {
                    throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ�,ʧ�ܸ��±��ر�ʶ�����ֶ��ϴ��ò��˷��ã�");
                }
                return true;
            }
            catch (Exception exception)
            {
                strMsg = exception.Message;
                this.myFunc.SaveLog((long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "ҽ�������ϴ����ݴ���", BinID.ToString() + "ҽ�����������ϴ�����" + exception.Message.ToString().Trim(), 1, 4);
                return false;
            }
        }

        private bool DoVaildYbFee(DataTable myTb, long MNGType, Guid BinID, long BabyId, out string strMsg)
        {
            BmiAuditClass class2 = new BmiAuditClass();
            ClsAuditCheck check = new ClsAuditCheck(FrmMdiMain.Database);
            strMsg = "";
            string str = "";

            string yblx = "";
            string ybzlx = "";
            string zyh = "";
            try
            {
                string inAGENCIES_ID = "";
                string ssql = string.Format("select YBLX,XZLX,INPATIENT_NO from VI_ZY_VINPATIENT_ALL where INPATIENT_ID ='{0}' ", BinID.ToString());
                try
                {
                    DataTable dtInp = InstanceForm.BDatabase.GetDataTable(ssql);

                    if (dtInp == null || dtInp.Rows.Count <= 0)
                        throw new Exception("δ�ҵ���סԺ�ŵĲ�����Ϣ\r");

                    yblx = dtInp.Rows[0]["YBLX"].ToString().Trim();
                    ybzlx = dtInp.Rows[0]["XZLX"].ToString().Trim();
                    zyh = dtInp.Rows[0]["INPATIENT_NO"].ToString().Trim();
                    if (yblx.Equals("1"))
                    {
                        inAGENCIES_ID = "1";
                    }
                    else if (yblx.Equals("3") && ybzlx.Equals("55"))
                    {
                        inAGENCIES_ID = "2";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("δ�ҵ���סԺ�ŵĲ�����Ϣ\r" + ex.Message);
                }

                string str4;
                DataTable table = this.DoGetValidateFeeInfo(myTb);
                DataTable table2 = check.GetPostFeeInfo(table, (int)MNGType, 1, BinID, BabyId);
                decimal num = 0M;
                DataTable detailFeeInfo = check.GetDetailFeeInfo(table2, yblx, ybzlx, out num);

                //string commandtext = string.Format("select INPATIENT_NO from ZY_INPATIENT where INPATIENT_ID='{0}'", BinID.ToString());
                //string str3 = FrmMdiMain.Database.GetDataResult(commandtext).ToString();

                DataTable table4 = ClsAuditCheck.RetAfSetMainInfo(BinID.ToString(), zyh, num, FrmMdiMain.Database);
                str = class2.ClaimAudit4Hospital_N(table4, detailFeeInfo);
                if (str.Equals("0") || str.Equals("2"))
                {
                    //str4 = str.Equals("0") ? "ҽ���������ʧ�ܣ�" : "ҽ�����󣺵��ò������";
                    //throw new Exception(str4 + " \r\t ���ֶ��ϴ��ò��˷��õ��й�����");
                    ///���أ� 0�����ʧ��
                    //1����˽������
                    //2�����ò������
                    //3����˽����Υ�棨ȡ����
                    //4����˽����Υ�棨���棩�������������£�
                    string err = (str.Equals("0") ? "ҽ���������ʧ�ܣ���" : "ҽ�����󡾵��ò��������");
                    err = err + "\r\r����ԭ��" + class2.l_error_message;
                    throw new Exception(err + "\r\r���ֶ��ϴ��ò��˷��õ��й�����");
                }
                if (str.Equals("3"))
                {
                    str = class2.ClaimAudit4Hospital_S(table4, detailFeeInfo);
                    str4 = str.Equals("0") ? "ҽ���������ʧ�ܣ���" : "ҽ�����󡾵��ò��������";
                    if (str.Equals("0") || str.Equals("2"))
                    {
                        throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ��� \r\r ҽ��������˼�⵽����Υ������,��ֹͣΥ��ҽ��,����������,���ֶ��ϴ��ò������з��õ��й�����");
                    }
                    bool flag = check.UpdateScbz(detailFeeInfo);
                    throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ�," + (flag ? "�ɹ����±��ر�ʶ" : "ʧ�ܸ��±��ر�ʶ") + "��\r\rҽ��������˼�⵽����Υ������,��ֹͣΥ��ҽ��,���������ã� \r\r���� �������ݴ������ ���²鿴��ҽ��");
                }
                strMsg = "";
                if (!check.UpdateScbz(detailFeeInfo))
                {
                    throw new Exception("���ݱ���ɹ�,�ϴ��й������ݳɹ�,ʧ�ܸ��±��ر�ʶ�����ֶ��ϴ��ò��˷��ã�");
                }
                return true;
            }
            catch (Exception exception)
            {
                strMsg = exception.Message;
                this.myFunc.SaveLog((long)FrmMdiMain.CurrentDept.DeptId, (long)FrmMdiMain.CurrentUser.EmployeeId, "ҽ�������ϴ����ݴ���", BinID.ToString() + "ҽ�����������ϴ�����" + exception.Message.ToString().Trim(), 1, 4);
                return false;
            }
        }

        private DataTable DoGetValidateFeeInfo(DataTable myTb)
        {
            try
            {
                DataTable table = myTb.Clone();
                for (int i = 0; i <= (myTb.Rows.Count - 1); i++)
                {
                    if ((myTb.Rows[i]["ID"].ToString().Trim() != "") && (myTb.Rows[i]["ѡ"].ToString() == "True"))
                    {
                        table.ImportRow(myTb.Rows[i]);
                    }
                }
                return table;
            }
            catch
            {
                throw new Exception("�����Ч����Ҫ ����ҽ����������� ��ҽ�����ó��� ");
            }
        }

        private void DoSetZDB(DataTable myTb)
        {
            try
            {
                //д��pivas����
                long pvsDept = 598;
                //д��pivasת����סԺҩ��(���)��359��
                long execYf = 359;
                int iSelectRows = 0;
                int msgType = 0;
                //DataTable myTb = new DataTable();
                string msg = "";
                string sMsg = "";
                string sSql = "";

                if (myTb == null || myTb.Rows.Count == 0)
                    return;

                #region ִ�п���Pivas����ת���
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString() == "True" && (!myTb.Rows[i]["EXECDEPT_ID"].ToString().Equals(pvsDept.ToString())))
                    {
                        MessageBox.Show(this, myTb.Rows[i]["����"].ToString().Trim() + "���Ǿ�����ҩ���е�������ҩ����ҩƷ������ת�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                #endregion

                #region �Ƿ��Ѿ����ˡ��Ǽ��˷��ò���ת�����
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        if (myTb.Rows[i]["CHARGE_BIT"].ToString().Equals("0"))
                        {
                            bool bRealCharged = false;

                            sSql = string.Format(@"select CHARGE_BIT from ZY_FEE_SPECI where id='{0}'", myTb.Rows[i]["id"].ToString());

                            string sChargeBit = InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim();
                            bRealCharged = !sChargeBit.Equals("0");

                            if (bRealCharged)
                            {
                                MessageBox.Show(this, myTb.Rows[i]["����"].ToString().Trim() + "���Ѽ��˷��ò�����ת�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.ShowData();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, myTb.Rows[i]["����"].ToString().Trim() + "���Ѽ��˷��ò�����ת�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                #endregion

                #region �Ƿ�ѡ����Ϣ
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        iSelectRows += 1;
                    }
                }

                if (iSelectRows == 0)
                {
                    MessageBox.Show(this, "�Բ���û��ѡ����Ϣ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                msg = "�Ƿ���Ҫ��ѡ����ҩƷת���� ��סԺҩ��(���)�� ��";

                if (MessageBox.Show(msg, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                ////Modify By Tany 2010-06-08 �Ƿ�ʹ������ȷ�� 0=ʹ�� 1=��ʹ��
                //if (new SystemCfg(7066).Config == "0")
                //{
                //    frmInPassword f1 = new frmInPassword();
                //    f1.ShowDialog();
                //    bool isHSZ = f1.isHSZ;
                //    if (f1.isLogin == false) return;
                //}

                Cursor.Current = PubStaticFun.WaitCursor();
                System.DateTime BookDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

                #region ����ִ�п���

                #region �ж� ��ͳ�����Ǵ���ҺҩƷ ����Ч��
                for (int i = 0; i < myTb.Rows.Count; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                    {
                        //Modify by jchl:2016-08-04  �����ͳ�����Ǵ���Һ У��
                        if (!myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                        {
                            sSql = "Select a.kcl yfkcl,b.num*a.dwbl/b.unitrate num,a.dwbl,b.unitrate from YF_KCMX a inner join zy_fee_speci b on a.cjid=b.xmid where a.bdelete=0 and b.id='" + myTb.Rows[i]["id"].ToString().Trim() + "' and a.deptid=" + execYf;
                            DataTable medTb = InstanceForm.BDatabase.GetDataTable(sSql);

                            if (medTb == null || medTb.Rows.Count == 0)
                            {
                                sMsg += " �� " + myTb.Rows[i]["����"].ToString().Trim() + "\n";
                            }
                            else if (Convert.ToInt32(medTb.Rows[0]["unitrate"]) > 1 && Convert.ToInt32(medTb.Rows[0]["unitrate"]) != Convert.ToInt32(medTb.Rows[0]["dwbl"]))//�����λϵ������1��˵��������С��λ�������Ҳ����ڶԷ�ҩ���ĵ�λ������������
                            {
                                sMsg += " �� " + myTb.Rows[i]["����"].ToString().Trim() + " [ ԭҩ�����Ӧҩ���Ĳ��㵥λ����ͬ ]\n";
                            }
                            else if (Convert.ToDecimal(medTb.Rows[0]["num"]) > Convert.ToDecimal(medTb.Rows[0]["yfkcl"]))
                            {
                                sMsg += " �� " + myTb.Rows[i]["����"].ToString().Trim() + " [ ������" + medTb.Rows[0]["num"].ToString().Trim() + " ] ���� [ �������" + medTb.Rows[0]["yfkcl"].ToString().Trim() + "] \n";
                            }
                        }
                    }
                }

                if (sMsg.Trim() != "")
                {
                    MessageBox.Show("����ҩƷ��Ϊ�����ĵ�ִ�п�����û�и���ҩƷ���治���������ܱ����ͣ�������ѡ����ٷ��ͣ�\n���ܸ���ִ�п��ҵ�ҩƷ������\n\n" + sMsg,
                        "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #endregion

                InstanceForm.BDatabase.BeginTransaction();

                try
                {
                    //ѡ�е�ҽ��
                    for (int i = 0; i < myTb.Rows.Count; i++)
                    {
                        if (myTb.Rows[i]["ѡ"].ToString().Trim() == "True")
                        {
                            if (Convert.ToDecimal(myTb.Rows[i]["����"]) < 0)
                            {
                                msgType = 1;
                            }
                            else
                            {
                                msgType = 0;
                            }

                            if (!myTb.Rows[i]["tlfl"].ToString().Trim().Equals("03"))
                            {
                                sSql = "update zy_fee_speci set execdept_id=" + execYf + ",apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=2,pvs_zdb=1  " +
                                    " where delete_bit=0 and fy_bit=0 and id ='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "update zy_prescription set execdept_id=" + execYf +
                                    " where id in (select prescription_id from zy_fee_speci " +
                                    " where id ='" + myTb.Rows[i]["id"].ToString().Trim() + "')";
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                            else
                            {
                                //����Һ����
                                long execDsyYf = 672;
                                string strDept = myTb.Rows[i]["DEPT_ID"].ToString().Trim();
                                int fyBit = 5;

                                sSql = string.Format(@"SELECT count(1) as Num FROM SS_DEPT where deptid='{0}'", strDept);
                                int iSsNum = int.Parse(InstanceForm.BDatabase.GetDataResult(sSql).ToString());
                                if (iSsNum > 0)
                                {
                                    fyBit = 0;//�����Ҵ���Һ��ҩ��־
                                }
                                else
                                {
                                    fyBit = 5;//�������ҿ����Ĵ���Һ��ҩ��־
                                }

                                sSql = "update zy_fee_speci set execdept_id=" + execDsyYf + ",apply_id=DBO.FUN_GETEMPTYGUID(),tlfs=0,pvs_zdb=1 ,CHARGE_DATE=getdate(),CHARGE_BIT=1,FY_BIT=" + fyBit +
                                    " where delete_bit=0 and fy_bit=0 and id ='" + myTb.Rows[i]["id"].ToString().Trim() + "'";
                                InstanceForm.BDatabase.DoCommand(sSql);

                                sSql = "update zy_prescription set execdept_id=" + execDsyYf +
                                    " where id in (select prescription_id from zy_fee_speci " +
                                    " where id ='" + myTb.Rows[i]["id"].ToString().Trim() + "')";
                                InstanceForm.BDatabase.DoCommand(sSql);
                            }
                        }
                    }

                    InstanceForm.BDatabase.CommitTransaction();
                }
                catch (Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();

                    //д������־ Add By Tany 2005-01-12
                    SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "���·���ҩƷ����ִ�п��Ҵ���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                    _systemErrLog.Save();
                    _systemErrLog = null;

                    MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source + "\n\n�����Ѿ��ع������������ִ�У�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                #endregion

                string yfSql = "Select distinct a.drugstore_id as execdept_id from jc_DEPT_DRUGSTORE " +
                    " a where a.flag in (0,2) and (a.dept_id in (select dept_id from jc_wardrdept where ward_id='" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + FrmMdiMain.CurrentDept.DeptId + ")";
                DataTable yfTb = InstanceForm.BDatabase.GetDataTable(yfSql);

                for (int i = 0; i < yfTb.Rows.Count; i++)
                {
                    //��ͳ��ҩƷ����ҩ����Ϣ Modify By Tany 2005-09-13
                    myFunc.SendYPFY(2, 0, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);

                    ////��ͳ��ҩƷ����ҩ����Ϣ Modify By Tany 2005-09-13
                    //myFunc.SendYPFY(2, 1, InstanceForm.BCurrentDept.WardId, InstanceForm.BCurrentDept.WardDeptId == 0 ? InstanceForm.BCurrentDept.DeptId : InstanceForm.BCurrentDept.WardDeptId, InstanceForm.BCurrentUser.EmployeeId, BookDate, Convert.ToInt64(yfTb.Rows[i]["execdept_id"]), FrmMdiMain.Jgbm);
                }

                //д��־ Add By Tany 2005-01-12
                SystemLog _systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "���·���ҩƷ", "BookDate=" + BookDate.ToString(), DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemLog.Save();
                _systemLog = null;

                Cursor.Current = Cursors.Default;
                MessageBox.Show("�����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.ShowData();
            }
            catch (Exception ex)
            {
                this.ShowData();
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
