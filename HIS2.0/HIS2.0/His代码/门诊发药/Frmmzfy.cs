using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using YpClass;
using ts_mz_class;
using System.Threading;
using System.Text;
using Ts_Hlyy_Interface;
using System.Collections.Generic;
using ts_call;
using ts_yf_mzkf;
using System.IO;
using System.Net;
using System.Data.SqlClient;
//using TrasenMainWindow;




namespace ts_yf_mzfy
{
    /// <summary>
    /// Frmcffy ��ժҪ˵����
    /// </summary>
    public class Frmcffy : System.Windows.Forms.Form, IMessageFilter
    {
        private DateTime PrintRq;
        private MenuTag _menuTag;
        private string _chineseName;
        private Form _mdiParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbpyr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button butfy;
        private System.Windows.Forms.Button butquit;
        private System.Windows.Forms.Button butprint;
        private System.Windows.Forms.Button butcfcx;
        private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
        private System.Windows.Forms.CheckBox chkrq;
        private System.Windows.Forms.DateTimePicker dtprq2;
        private System.Windows.Forms.DateTimePicker dtprq1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private TrasenClasses.GeneralControls.ButtonDataGridEx myDataGrid1;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.CheckBox chkprintview;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox chkprint;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtmzh;
        private System.Windows.Forms.TextBox txttmk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtfph;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblxm;
        private System.Windows.Forms.Label lblxb;
        private System.Windows.Forms.Label lblnl;
        private System.Windows.Forms.Label lblks;
        private System.Windows.Forms.Label lblzd;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private YpConfig s;
        private string IPAddRess;
        private System.Windows.Forms.CheckBox chkxp;
        public string _Fyckh;
        public string _Fyckmc;
        private string kflx;
        private RadioButton rdo3;
        private Button butqhfyck;
        private TextBox _textBox;
        private Label label8;
        private TextBox txtxm;
        private ComboBox cmbklx;
        private Panel panel4;
        private CheckBox chkqd;
        private CheckBox chkcf;
        private CheckBox chkzsd;
        private TextBox txtlsh;
        private Label label6;
        private bool _ClickQuit = false;
        //���屨������ʾ����
        private ts_call.Icall _call;
        private Panel panel7;
        private Splitter splitter3;
        private Panel panel_left;
        private Panel panel5;
        private DataGridView dataGridView1;
        private Panel panel9;
        private Button button_ref;
        private Panel panel10;
        private DateTimePicker dtprq_ref;
        private Button buthj;
        //���屨������ʾ���߳�
        Thread thCall = null;
        private DataGridViewButtonColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn ��Ʊ��;
        private DataGridViewTextBoxColumn ���;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn ��ӡ;
        private DataGridViewTextBoxColumn fpid;
        private DataGridViewTextBoxColumn bfybz;
        private ComboBox cmbyf;
        private Label label9;
        private string cfg8027 = "0";
        private string cfghlyytype = "0";
        private HlyyInterface hlyyjk;
        private string hlyytype = "";

        private bool bpcgl = false; //�Ƿ�������ι��� 
        private string pcglfs = "0"; //0�Ƚ��ȳ� 1��Ч���ȳ�
        private bool btjhj = false;
        private Button btnPy; //�������� 

        ts_yf_mzkf.IMzkf kf = null;
        private Button btnhqcf;
        private Button btnReadCard;
        private Label label11;
        private ComboBox cmbFylb;
        private Label label13;
        private Button btnFpCk;
        private Button btnCancerOver;
        private Button btnOver;
        /// <summary>
        /// �Ƿ����ÿ췢
        /// </summary>
        private bool bqyyfkf = false;
        private CheckBox chkmj;
        private CheckBox chkJ2; //�Ƿ����ÿ췢

        private string strFyKFCkFlag = "1";
        private CheckBox chkDJ;//�˴���ӷ�ҩ�����Ƿ���п췢��ҩ��424 ���еĴ����ÿ췢�����ǲ��ÿ췢��ҩ�������

        //������ Add by zhujh 2017-0511
        YongTai yongtai = null;

        private class InventoryNotEnoughException : Exception
        {
            private object data;
            public object Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
        }

        public Frmcffy(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);


            //������ҩ��ʾ��lidan add 2013-09-16
            cfghlyytype = (new SystemCfg(8040)).Config;//8040������0����ʹ�ú�����ҩ��ʾ��1����ͨ

            hlyytype = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("��ͨ");
                hlyyjk.RegisterServer_fun(null);//���ĵ�
                //hlyyjk.Refresh();//ˢ���ĵ�
            }



            if (s.���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ == true)
                this.chkxp.Checked = true;
            else
                this.chkxp.Checked = false;
            //��ַ��ַ
            IPAddRess = PubStaticFun.GetMacAddress();
            try
            {
                kflx = ApiFunction.GetIniString("ҩ���췢����", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            }
            catch
            { }


            try
            {
                // 1Ϊ�� ��ʾ�߿췢��ҩ  0��ʾ���߿췢��ҩ
                strFyKFCkFlag = ApiFunction.GetIniString("ҩ����ҩ�Ƿ��߿췢��������", "���ÿ���", Constant.ApplicationDirectory + "//ClientWindow.ini");
            }
            catch
            { }

            if (strFyKFCkFlag == "")
            {
                strFyKFCkFlag = "1";
            }
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //

            //Add by Zhujh 2017-05-10
            yongtai = new YongTai();
            int intYongTai = yongtai.OpinionInit(1);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmcffy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkrq = new System.Windows.Forms.CheckBox();
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnCancerOver = new System.Windows.Forms.Button();
            this.btnOver = new System.Windows.Forms.Button();
            this.btnFpCk = new System.Windows.Forms.Button();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnPy = new System.Windows.Forms.Button();
            this.cmbyf = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buthj = new System.Windows.Forms.Button();
            this.txtlsh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butqhfyck = new System.Windows.Forms.Button();
            this.lblzd = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblnl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblxb = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblxm = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttmk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.cmbpyr = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFylb = new System.Windows.Forms.ComboBox();
            this.btnhqcf = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkDJ = new System.Windows.Forms.CheckBox();
            this.chkJ2 = new System.Windows.Forms.CheckBox();
            this.chkmj = new System.Windows.Forms.CheckBox();
            this.chkqd = new System.Windows.Forms.CheckBox();
            this.chkcf = new System.Windows.Forms.CheckBox();
            this.chkzsd = new System.Windows.Forms.CheckBox();
            this.chkxp = new System.Windows.Forms.CheckBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butfy = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.rdo3 = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel_left = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.��Ʊ�� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.��� = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.��ӡ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bfybz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button_ref = new System.Windows.Forms.Button();
            this.dtprq_ref = new System.Windows.Forms.DateTimePicker();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel_left.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkrq
            // 
            this.chkrq.AutoSize = true;
            this.chkrq.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrq.ForeColor = System.Drawing.Color.Black;
            this.chkrq.Location = new System.Drawing.Point(5, 63);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(82, 18);
            this.chkrq.TabIndex = 12;
            this.chkrq.Text = "��������";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkrq_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(236, 62);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(110, 21);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(211, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "��";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(93, 62);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(112, 21);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.AutoSize = true;
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(752, 73);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(47, 16);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "��ʷ";
            // 
            // rdodq
            // 
            this.rdodq.AutoSize = true;
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(752, 56);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(47, 16);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "��ǰ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(242, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "��ҩ��";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.btnCancerOver);
            this.panel8.Controls.Add(this.btnOver);
            this.panel8.Controls.Add(this.btnFpCk);
            this.panel8.Controls.Add(this.btnReadCard);
            this.panel8.Controls.Add(this.btnPy);
            this.panel8.Controls.Add(this.cmbyf);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.buthj);
            this.panel8.Controls.Add(this.txtlsh);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.cmbklx);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.butqhfyck);
            this.panel8.Controls.Add(this.lblzd);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.lblks);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.lblnl);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.lblxb);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.lblxm);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.txtfph);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.txttmk);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtmzh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.chkrq);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.rdols);
            this.panel8.Controls.Add(this.rdodq);
            this.panel8.Controls.Add(this.butquit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1147, 91);
            this.panel8.TabIndex = 1;
            // 
            // btnCancerOver
            // 
            this.btnCancerOver.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancerOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancerOver.ForeColor = System.Drawing.Color.Navy;
            this.btnCancerOver.Location = new System.Drawing.Point(920, 31);
            this.btnCancerOver.Name = "btnCancerOver";
            this.btnCancerOver.Size = new System.Drawing.Size(80, 24);
            this.btnCancerOver.TabIndex = 50;
            this.btnCancerOver.Text = "ȡ������";
            this.btnCancerOver.UseVisualStyleBackColor = false;
            this.btnCancerOver.Visible = false;
            this.btnCancerOver.Click += new System.EventHandler(this.btnCancerOver_Click);
            // 
            // btnOver
            // 
            this.btnOver.BackColor = System.Drawing.SystemColors.Control;
            this.btnOver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOver.ForeColor = System.Drawing.Color.Navy;
            this.btnOver.Location = new System.Drawing.Point(805, 31);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(109, 24);
            this.btnOver.TabIndex = 49;
            this.btnOver.Text = "����";
            this.btnOver.UseVisualStyleBackColor = false;
            this.btnOver.Visible = false;
            this.btnOver.Click += new System.EventHandler(this.btnOver_Click);
            // 
            // btnFpCk
            // 
            this.btnFpCk.BackColor = System.Drawing.SystemColors.Control;
            this.btnFpCk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFpCk.ForeColor = System.Drawing.Color.Navy;
            this.btnFpCk.Location = new System.Drawing.Point(652, 31);
            this.btnFpCk.Name = "btnFpCk";
            this.btnFpCk.Size = new System.Drawing.Size(75, 24);
            this.btnFpCk.TabIndex = 48;
            this.btnFpCk.Text = "תһ¥ҩ��";
            this.btnFpCk.UseVisualStyleBackColor = false;
            this.btnFpCk.Click += new System.EventHandler(this.btnFpCk_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReadCard.ForeColor = System.Drawing.Color.Navy;
            this.btnReadCard.Location = new System.Drawing.Point(480, 5);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(38, 24);
            this.btnReadCard.TabIndex = 47;
            this.btnReadCard.Text = "����";
            this.btnReadCard.UseVisualStyleBackColor = false;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnPy
            // 
            this.btnPy.BackColor = System.Drawing.SystemColors.Control;
            this.btnPy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPy.ForeColor = System.Drawing.Color.Navy;
            this.btnPy.Location = new System.Drawing.Point(726, 31);
            this.btnPy.Name = "btnPy";
            this.btnPy.Size = new System.Drawing.Size(80, 24);
            this.btnPy.TabIndex = 46;
            this.btnPy.Text = "��ҩ(F12)";
            this.btnPy.UseVisualStyleBackColor = false;
            this.btnPy.Click += new System.EventHandler(this.btnPy_Click);
            // 
            // cmbyf
            // 
            this.cmbyf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyf.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyf.Location = new System.Drawing.Point(576, 61);
            this.cmbyf.Name = "cmbyf";
            this.cmbyf.Size = new System.Drawing.Size(168, 22);
            this.cmbyf.TabIndex = 45;
            this.cmbyf.SelectedIndexChanged += new System.EventHandler(this.cmbyf_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(521, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 44;
            this.label9.Text = "ҩ  ��";
            // 
            // buthj
            // 
            this.buthj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buthj.ForeColor = System.Drawing.Color.Navy;
            this.buthj.Location = new System.Drawing.Point(921, 31);
            this.buthj.Name = "buthj";
            this.buthj.Size = new System.Drawing.Size(80, 24);
            this.buthj.TabIndex = 43;
            this.buthj.Text = "����(&F9)";
            this.buthj.Click += new System.EventHandler(this.buthj_Click);
            // 
            // txtlsh
            // 
            this.txtlsh.BackColor = System.Drawing.Color.White;
            this.txtlsh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtlsh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtlsh.Location = new System.Drawing.Point(805, 6);
            this.txtlsh.Name = "txtlsh";
            this.txtlsh.Size = new System.Drawing.Size(196, 21);
            this.txtlsh.TabIndex = 41;
            this.txtlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(750, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "��ˮ��";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.Location = new System.Drawing.Point(275, 6);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(57, 22);
            this.cmbklx.TabIndex = 40;
            // 
            // txtxm
            // 
            this.txtxm.BackColor = System.Drawing.Color.White;
            this.txtxm.Enabled = false;
            this.txtxm.Location = new System.Drawing.Point(393, 62);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(122, 21);
            this.txtxm.TabIndex = 39;
            this.txtxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtxm_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(352, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "����";
            // 
            // butqhfyck
            // 
            this.butqhfyck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butqhfyck.ForeColor = System.Drawing.Color.Navy;
            this.butqhfyck.Location = new System.Drawing.Point(811, 31);
            this.butqhfyck.Name = "butqhfyck";
            this.butqhfyck.Size = new System.Drawing.Size(103, 24);
            this.butqhfyck.TabIndex = 36;
            this.butqhfyck.Text = "�л���ҩ����";
            this.butqhfyck.Click += new System.EventHandler(this.butqhfyck_Click);
            // 
            // lblzd
            // 
            this.lblzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzd.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblzd.Location = new System.Drawing.Point(576, 32);
            this.lblzd.Name = "lblzd";
            this.lblzd.Size = new System.Drawing.Size(75, 22);
            this.lblzd.TabIndex = 35;
            this.lblzd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(521, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 34;
            this.label16.Text = "��  ��";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(393, 31);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(121, 22);
            this.lblks.TabIndex = 33;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(352, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 32;
            this.label14.Text = "����";
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblnl.Location = new System.Drawing.Point(274, 31);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(72, 22);
            this.lblnl.TabIndex = 31;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(233, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 30;
            this.label12.Text = "����";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxb.Location = new System.Drawing.Point(190, 31);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(37, 22);
            this.lblxb.TabIndex = 29;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(149, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 28;
            this.label10.Text = "�Ա�";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxm.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxm.Location = new System.Drawing.Point(59, 32);
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size(84, 22);
            this.lblxm.TabIndex = 27;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "��  ��";
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfph.Location = new System.Drawing.Point(576, 6);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(168, 21);
            this.txtfph.TabIndex = 0;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtfph.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(521, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "��Ʊ��";
            // 
            // txttmk
            // 
            this.txttmk.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttmk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttmk.Location = new System.Drawing.Point(333, 6);
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size(146, 21);
            this.txttmk.TabIndex = 2;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txttmk.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "������/����";
            // 
            // butcfcx
            // 
            this.butcfcx.Enabled = false;
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(805, 63);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(109, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "��ѯ(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtmzh.Location = new System.Drawing.Point(59, 6);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(120, 21);
            this.txtmzh.TabIndex = 0;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtmzh.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "�����";
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(921, 62);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(179, 8);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(56, 18);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "ȫѡ";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(289, 8);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(89, 20);
            this.cmbpyr.TabIndex = 11;
            this.cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
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
            this.imageList1.Images.SetKeyName(5, "�޵�.jpg");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.panel17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1149, 48);
            this.panel6.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel17.Controls.Add(this.label13);
            this.panel17.Controls.Add(this.label11);
            this.panel17.Controls.Add(this.cmbFylb);
            this.panel17.Controls.Add(this.btnhqcf);
            this.panel17.Controls.Add(this.panel4);
            this.panel17.Controls.Add(this.rdo2);
            this.panel17.Controls.Add(this.rdo1);
            this.panel17.Controls.Add(this.chkprint);
            this.panel17.Controls.Add(this.chkprintview);
            this.panel17.Controls.Add(this.butfy);
            this.panel17.Controls.Add(this.butprint);
            this.panel17.Controls.Add(this.cmbpyr);
            this.panel17.Controls.Add(this.label5);
            this.panel17.Controls.Add(this.chkall);
            this.panel17.Controls.Add(this.rdo3);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1149, 48);
            this.panel17.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(272, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "(�в�ҩ�ϴ�ѡ��)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 41;
            this.label11.Text = "��ҩ���";
            // 
            // cmbFylb
            // 
            this.cmbFylb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFylb.Enabled = false;
            this.cmbFylb.FormattingEnabled = true;
            this.cmbFylb.Location = new System.Drawing.Point(153, 27);
            this.cmbFylb.Name = "cmbFylb";
            this.cmbFylb.Size = new System.Drawing.Size(116, 20);
            this.cmbFylb.TabIndex = 40;
            // 
            // btnhqcf
            // 
            this.btnhqcf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnhqcf.ForeColor = System.Drawing.Color.Navy;
            this.btnhqcf.Location = new System.Drawing.Point(726, 3);
            this.btnhqcf.Name = "btnhqcf";
            this.btnhqcf.Size = new System.Drawing.Size(99, 42);
            this.btnhqcf.TabIndex = 39;
            this.btnhqcf.Text = " ��ȡ��ϵ      ͳ����(&G)";
            this.btnhqcf.Click += new System.EventHandler(this.btnhqcf_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkDJ);
            this.panel4.Controls.Add(this.chkJ2);
            this.panel4.Controls.Add(this.chkmj);
            this.panel4.Controls.Add(this.chkqd);
            this.panel4.Controls.Add(this.chkcf);
            this.panel4.Controls.Add(this.chkzsd);
            this.panel4.Controls.Add(this.chkxp);
            this.panel4.Location = new System.Drawing.Point(385, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 44);
            this.panel4.TabIndex = 38;
            // 
            // chkDJ
            // 
            this.chkDJ.AutoSize = true;
            this.chkDJ.Checked = true;
            this.chkDJ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDJ.Location = new System.Drawing.Point(102, 23);
            this.chkDJ.Name = "chkDJ";
            this.chkDJ.Size = new System.Drawing.Size(48, 16);
            this.chkDJ.TabIndex = 39;
            this.chkDJ.Text = "����";
            this.chkDJ.UseVisualStyleBackColor = true;
            // 
            // chkJ2
            // 
            this.chkJ2.AutoSize = true;
            this.chkJ2.Checked = true;
            this.chkJ2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJ2.Location = new System.Drawing.Point(177, 22);
            this.chkJ2.Name = "chkJ2";
            this.chkJ2.Size = new System.Drawing.Size(48, 16);
            this.chkJ2.TabIndex = 38;
            this.chkJ2.Text = "����";
            this.chkJ2.UseVisualStyleBackColor = true;
            // 
            // chkmj
            // 
            this.chkmj.AutoSize = true;
            this.chkmj.Location = new System.Drawing.Point(176, 2);
            this.chkmj.Name = "chkmj";
            this.chkmj.Size = new System.Drawing.Size(72, 16);
            this.chkmj.TabIndex = 37;
            this.chkmj.Text = "�顢��һ";
            this.chkmj.UseVisualStyleBackColor = true;
            // 
            // chkqd
            // 
            this.chkqd.AutoSize = true;
            this.chkqd.Location = new System.Drawing.Point(3, 3);
            this.chkqd.Name = "chkqd";
            this.chkqd.Size = new System.Drawing.Size(72, 16);
            this.chkqd.TabIndex = 31;
            this.chkqd.Text = "�����嵥";
            this.chkqd.UseVisualStyleBackColor = true;
            // 
            // chkcf
            // 
            this.chkcf.AutoSize = true;
            this.chkcf.Location = new System.Drawing.Point(102, 2);
            this.chkcf.Name = "chkcf";
            this.chkcf.Size = new System.Drawing.Size(72, 16);
            this.chkcf.TabIndex = 30;
            this.chkcf.Text = "���ﴦ��";
            this.chkcf.UseVisualStyleBackColor = true;
            // 
            // chkzsd
            // 
            this.chkzsd.AutoSize = true;
            this.chkzsd.Checked = true;
            this.chkzsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkzsd.Location = new System.Drawing.Point(3, 24);
            this.chkzsd.Name = "chkzsd";
            this.chkzsd.Size = new System.Drawing.Size(96, 16);
            this.chkzsd.TabIndex = 29;
            this.chkzsd.Text = "����ע�䴦��";
            this.chkzsd.UseVisualStyleBackColor = true;
            // 
            // chkxp
            // 
            this.chkxp.Checked = true;
            this.chkxp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkxp.Location = new System.Drawing.Point(102, 24);
            this.chkxp.Name = "chkxp";
            this.chkxp.Size = new System.Drawing.Size(97, 17);
            this.chkxp.TabIndex = 36;
            this.chkxp.Text = "Ĭ�ϴ�ӡСƱ";
            this.chkxp.Visible = false;
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(91, 9);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(83, 16);
            this.rdo2.TabIndex = 20;
            this.rdo2.Text = "�ѷ�ҩ����";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(3, 9);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(83, 16);
            this.rdo1.TabIndex = 19;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "δ��ҩ����";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // chkprint
            // 
            this.chkprint.AutoSize = true;
            this.chkprint.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkprint.Location = new System.Drawing.Point(939, 28);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(84, 16);
            this.chkprint.TabIndex = 18;
            this.chkprint.Text = "��ҩʱ��ӡ";
            // 
            // chkprintview
            // 
            this.chkprintview.AutoSize = true;
            this.chkprintview.Location = new System.Drawing.Point(939, 9);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(84, 16);
            this.chkprintview.TabIndex = 17;
            this.chkprintview.Text = "��ӡʱԤ��";
            // 
            // butfy
            // 
            this.butfy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(638, 3);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(81, 42);
            this.butfy.TabIndex = 13;
            this.butfy.Text = "��ҩ(&O)";
            this.butfy.UseVisualStyleBackColor = false;
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(832, 3);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(99, 42);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "��ӡ����(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.Location = new System.Drawing.Point(3, 31);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(71, 16);
            this.rdo3.TabIndex = 37;
            this.rdo3.Text = "��ҩ����";
            this.rdo3.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 48);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 468);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(2, 492);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1147, 24);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 180;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 180;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 770;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 444);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 444);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel_left);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1147, 353);
            this.panel3.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.myDataGrid1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(249, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(898, 353);
            this.panel7.TabIndex = 3;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.GridLineColor = System.Drawing.Color.SeaGreen;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.myDataGrid1.Size = new System.Drawing.Size(898, 353);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.DataSourceChanged += new System.EventHandler(this.myDataGrid1_DataSourceChanged);
            this.myDataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.myDataGrid1_Paint);
            this.myDataGrid1.BindingContextChanged += new System.EventHandler(this.myDataGrid1_BindingContextChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.Silver;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 0;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(244, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 353);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel5);
            this.panel_left.Controls.Add(this.panel9);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(244, 353);
            this.panel_left.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 329);
            this.panel5.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.��Ʊ��,
            this.���,
            this.Column3,
            this.��ӡ,
            this.fpid,
            this.bfybz});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(244, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "���";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "���";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "����";
            this.Column2.HeaderText = "����";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 55;
            // 
            // ��Ʊ��
            // 
            this.��Ʊ��.DataPropertyName = "��Ʊ��";
            this.��Ʊ��.HeaderText = "��Ʊ��";
            this.��Ʊ��.Name = "��Ʊ��";
            this.��Ʊ��.ReadOnly = true;
            this.��Ʊ��.Width = 70;
            // 
            // ���
            // 
            this.���.DataPropertyName = "���";
            this.���.HeaderText = "���";
            this.���.Name = "���";
            this.���.ReadOnly = true;
            this.���.Width = 55;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "brxxid";
            this.Column3.HeaderText = "brxxid";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // ��ӡ
            // 
            this.��ӡ.DataPropertyName = "��ӡ";
            this.��ӡ.HeaderText = "��ӡ";
            this.��ӡ.Name = "��ӡ";
            this.��ӡ.ReadOnly = true;
            this.��ӡ.Visible = false;
            // 
            // fpid
            // 
            this.fpid.DataPropertyName = "fpid";
            this.fpid.HeaderText = "fpid";
            this.fpid.Name = "fpid";
            this.fpid.ReadOnly = true;
            this.fpid.Visible = false;
            // 
            // bfybz
            // 
            this.bfybz.DataPropertyName = "bfybz";
            this.bfybz.HeaderText = "bfybz";
            this.bfybz.Name = "bfybz";
            this.bfybz.ReadOnly = true;
            this.bfybz.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.dtprq_ref);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(244, 24);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button_ref);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(112, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(132, 24);
            this.panel10.TabIndex = 2;
            // 
            // button_ref
            // 
            this.button_ref.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ref.Location = new System.Drawing.Point(0, 0);
            this.button_ref.Name = "button_ref";
            this.button_ref.Size = new System.Drawing.Size(132, 24);
            this.button_ref.TabIndex = 0;
            this.button_ref.Text = "ˢ��(&F5)";
            this.button_ref.UseVisualStyleBackColor = true;
            this.button_ref.Click += new System.EventHandler(this.button_ref_Click);
            // 
            // dtprq_ref
            // 
            this.dtprq_ref.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtprq_ref.Location = new System.Drawing.Point(0, 0);
            this.dtprq_ref.Name = "dtprq_ref";
            this.dtprq_ref.Size = new System.Drawing.Size(112, 21);
            this.dtprq_ref.TabIndex = 1;
            // 
            // Frmcffy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1149, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel6);
            this.KeyPreview = true;
            this.Name = "Frmcffy";
            this.Text = "���﷢ҩ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.Activated += new System.EventHandler(this.Frmcffy_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmcffy_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frmcffy_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frmcffy_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frmcffy_KeyDown);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel_left.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        //���ش���
        private void Frmcffy_Load(object sender, System.EventArgs e)
        {
            btnFpCk.Visible = false;
            btnFpCk.Visible = InstanceForm.BCurrentDept.DeptId == 424;

            Application.AddMessageFilter(this);

            cmbpyr.SelectedIndexChanged -= new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
            cmbpyr.SelectedValue = Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);
            //cmbpyr.SelectedValue = DBNull.Value;
            cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);

            CshMxGrid(this.myDataGrid1);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            this.dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//.AddDays(-3);
            this.dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            this.chkrq.Checked = false;

            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
            butqhfyck.Text = butqhfyck.Text + "(" + _Fyckh.Trim() + "��)";
            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_cx")
                this.butfy.Visible = false;
            this.txtmzh.Focus();

            Yp.AddcmbYjks(false, cmbyf, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            cmbyf.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();

            if ((new SystemCfg(8006)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ҽ��"].Width = 0;



            //string cfgs = new SystemCfg(8010).Config;
            //if (cfgs == "1") rdocfgs.Checked = true;
            //if (cfgs == "0") rdoqdgs.Checked = true;
            //if (cfgs == "2") rdoall.Checked = true;
            if (s.���﷢ҩʱ��ӡ���� == true)
                chkcf.Checked = true;
            if (s.���﷢ҩʱ��ӡ�嵥 == true)
                chkqd.Checked = true;
            if (s.���﷢ҩʱ��ӡע�䵥 == true)
                chkzsd.Checked = true;

            if (s.���﷢ҩʱĬ�ϴ�ӡ���� == true)
                chkprint.Checked = true;

            //����ҩ���췢����
            if (s.ҩ���췢 == true)
                bqyyfkf = true;


            //�Զ�����Ƶ��
            string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(_menuTag.Function_Name, cmbklx, txttmk);

            try
            {
                string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                _call = ts_call.CallFactory.NewCall(bjqxh);
            }
            catch (System.Exception err)
            {
            }

            cfg8027 = (new SystemCfg(8027)).Config;
            if (cfg8027 == "0")
                panel_left.Visible = false;
            if (cfg8027 == "2")
            {
                ��Ʊ��.Visible = false;
                Column2.Width = Column2.Width + 15;
                ���.Width = ���.Width + 15;
                panel_left.Width = panel_left.Width - ��Ʊ��.Width + 20;
            }
            if (cfg8027 != "0")
                button_ref_Click(sender, e);


            //�򿪵�
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("��ͨ");
                hlyyjk.RegisterServer_fun(null);//���ĵ�
                hlyyjk.Refresh();
            }

            SystemCfg cfg8051 = new SystemCfg(8051);
            pcglfs = cfg8051.Config;

            //��������
            SystemCfg cfg8056 = new SystemCfg(8056);
            if (cfg8056.Config == "1")
            {
                btjhj = true;
            }

            SetDefaultFocuse();

            //����ini����
            IsVisable();

            SystemCfg sc = new SystemCfg(10025);
            if (sc != null && !string.IsNullOrEmpty(sc.Config) && sc.Config.Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {
                btnPy.Visible = true;
            }
            else
            {
                btnPy.Visible = false;
                lblzd.Width += btnPy.Width;
            }

            if (bqyyfkf)
            {
                string bjqxh = ApiFunction.GetIniString("ҩ���췢����", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                kf = ts_yf_mzkf.CallFactory.NewMzkf(bjqxh);//
            }

            if (kf is IMzkf)
            {
                //�����������췢,��֧�ֶ������ͬʱ��ҩ�ͷ�ҩ
                chkall.Visible = false;
            }

            //Modify by jchl
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("name", typeof(string));

                dt.Rows.Add(new object[] { "-1", "ȫ��" });
                dt.Rows.Add(new object[] { "1", "�����ҷ�ҩ" });
                dt.Rows.Add(new object[] { "2", "���ϴ����" });

                Addcmb(cmbFylb, dt, "id", "name");

                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_ZCY")
                {
                    cmbFylb.SelectedIndex = 2;
                    //rdCydy.Visible = false;
                    //rdCffy.Checked = true;
                }
                else if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY")
                {
                    cmbFylb.SelectedIndex = 1;

                    //���� ȡ����������
                    btnOver.Visible = true;
                    btnCancerOver.Visible = true;
                    butqhfyck.Visible = false;
                    btnFpCk.Visible = false;
                    buthj.Visible = false;
                }
                else
                {
                    cmbFylb.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void SetDefaultFocuse()
        {
            /*
             * �����䷢ҩҪ��������ƹ�궨λ�����ſ�
             * update code by py 7-1 19:25
            */
            string iniPath = string.Format("{0}\\ClientWindow.ini", Application.StartupPath);
            if (System.IO.File.Exists(iniPath))
            {
                string iniConfig = ApiFunction.GetIniString("���﷢ҩ", "�������Ȼ�ý���", iniPath);
                if (string.IsNullOrEmpty(iniConfig))
                    ApiFunction.WriteIniString("���﷢ҩ", "�������Ȼ�ý���", "true", iniPath);
                iniConfig = ApiFunction.GetIniString("���﷢ҩ", "�������Ȼ�ý���", iniPath);
                if (!string.IsNullOrEmpty(iniConfig))
                {
                    try
                    {
                        if (Convert.ToBoolean(iniConfig))
                        {
                            txttmk.Focus();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        #region ԭ�����д���
        //private void CshMxGridA(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        //{
        //    #region �����ϸ����

        //    //string[] HeaderText ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
        //    //string[] MappingName ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
        //    //int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65, 70, 40, 40, 70, 0, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*��������*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80,0,90,150 ,50,50};
        //    //bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true,true,true,true,true,true };
        //    //bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        //    //ncq 2014-04-16 ���tycfmxid 
        //    string[] HeaderText ={ "���", "��ʾ��", "��ҩ", "Ƥ��", "��Ŀ", "�ܽ��", "����", "��Ʒ��", "Ʒ��", "���", "��λ", "����", "����", "�÷�", "Ƶ��", "����", "���", "���", "ҽ��", "����", "��Ʊ��", "�����", "�Ա�", "����", "����", "����", "���", "��ҩ", "����", "������λ", "����", "���־", "�������", "¼��Ա", "¼������", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3", "tyid", "dwbl", "����", "Ч��", "���κ�", "ypsl", "hwmc", "byscf" };
        //    string[] MappingName ={ "���", "��ʾ��", "��ҩ", "Ƥ��", "��Ŀ", "�ܽ��", "����", "��Ʒ��", "Ʒ��", "���", "��λ", "����", "����", "�÷�", "Ƶ��", "����", "���", "���", "ҽ��", "����", "��Ʊ��", "�����", "�Ա�", "����", "����", "����", "���", "��ҩ", "����", "������λ", "����", "���־", "�������", "¼��Ա", "¼������", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3", "tyid", "dwbl", "����", "Ч��", "���κ�", "ypsl", "hwmc", "byscf" };
        //    int[] ColWidth ={ 40, 30, 30, 30, 0, 0, 60, 60, 150, 110, 50/*ypsl*/, 40, 50, 50, 60, 60, 60, 65, 90, 90, 90, 90, 40, 70, 0, 50, 50, 50/*userage*/, 50, 0, 0, 0, 0, 60, 90, 90, 90/*��������*/, 60, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80, 0, 90, 150, 50, 50, 0, 0, 60, 60, 95, 0, 0, 100 };
        //    bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
        //    bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        //    DataTable dtTmp = new DataTable();
        //    dtTmp.TableName = "tbmx";
        //    SystemCfg cfg8032 = new SystemCfg(8032);
        //    for (int j = 0; j <= HeaderText.Length - 1; j++)
        //    {
        //        //DataGridEnableBoolColumn
        //        if (ColBool[j] == false)
        //        {
        //            if (HeaderText[j].ToString() != "��ʾ��")
        //            {
        //                DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
        //                colText.HeaderText = HeaderText[j];
        //                colText.MappingName = MappingName[j];
        //                colText.Width = ColWidth[j];
        //                colText.NullText = "";
        //                colText.ReadOnly = ColReadOnly[j];
        //                //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
        //                colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
        //                colText.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
        //                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
        //            }
        //            else
        //            {
        //                MydataGirdImageColumn mycol = new MydataGirdImageColumn();
        //                mycol.HeaderText = HeaderText[j];
        //                mycol.MappingName = MappingName[j];
        //                mycol.Width = ColWidth[j];
        //                mycol.NullText = "";
        //                mycol.ReadOnly = ColReadOnly[j];
        //                mycol.ONCurrentChange += new DelCurrentChage(mycol_ONCurrentChange);
        //                xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(mycol);
        //                if (cfg8032.Config == "0")
        //                    mycol.Width = 0;
        //            }

        //            DataColumn datacol;
        //            if (MappingName[j].Trim() == "ypsl" || MappingName[j] == "���")
        //                datacol = new DataColumn(MappingName[j], Type.GetType("System.Decimal"));
        //            else
        //                datacol = new DataColumn(MappingName[j]);

        //            dtTmp.Columns.Add(datacol);
        //        }
        //        else
        //        {
        //            DataGridButtonColumn btnCol = new DataGridButtonColumn(j);
        //            btnCol.HeaderText = HeaderText[j];
        //            btnCol.MappingName = MappingName[j];
        //            btnCol.Width = ColWidth[j];
        //            btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
        //            xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
        //            this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
        //            this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);
        //            DataColumn datacol;
        //            datacol = new DataColumn(MappingName[j]);
        //            dtTmp.Columns.Add(datacol);
        //        }
        //    }
        //    xcjwDataGrid.DataSource = dtTmp;
        //    xcjwDataGrid.TableStyles[0].MappingName = "tbmx";
        //    if (s.����������ʾ��Ʒ�� == true)
        //        xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 100;
        //    else
        //        xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;
        //    #endregion
        //}
        #endregion

        private bool IsVisable(string columnName, bool defaultVisable)
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("���ﴦ����ҩ������", columnName, Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("���ﴦ����ҩ������", columnName, defaultVisable ? "1" : "0", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("���ﴦ����ҩ������", columnName, Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }

        private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx xcjwDataGrid)
        {
            #region �����ϸ����

            List<ColumnDefine> columns = new List<ColumnDefine>();
            #region �ж���
            columns.Add(ColumnDefine.NewColumnDefine("���", "���", 40, true, 1));
            columns.Add(ColumnDefine.NewColumnDefine("��ʾ��", "��ʾ��", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ", "��ҩ", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("Ƥ��", "Ƥ��", 30, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��Ŀ", "��Ŀ", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�ܽ��", "�ܽ��", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", 60, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��Ʒ��", "��Ʒ��", 150, true, 0));  //
            columns.Add(ColumnDefine.NewColumnDefine("Ʒ��", "Ʒ��", (IsVisable("Ʒ��", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���", "���", (IsVisable("���", true) ? 110 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��λ", "��λ", (IsVisable("��λ", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�÷�", "�÷�", (IsVisable("�÷�", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("Ƶ��", "Ƶ��", (IsVisable("Ƶ��", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���", "���", (IsVisable("���", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���", "���", (IsVisable("���", true) ? 65 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("ҽ��", "ҽ��", (IsVisable("ҽ��", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��Ʊ��", "��Ʊ��", (IsVisable("��Ʊ��", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�����", "�����", (IsVisable("�����", true) ? 105 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�Ա�", "�Ա�", (IsVisable("�Ա�", true) ? 40 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���", "���", (IsVisable("���", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ", "��ҩ", (IsVisable("��ҩ", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("������λ", "������λ", (IsVisable("������λ", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���־", "���־", (IsVisable("���־", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�������", "�������", (IsVisable("�������", false) ? 30 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("¼��Ա", "¼��Ա", (IsVisable("¼��Ա", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("¼������", "¼������", (IsVisable("¼������", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�շ�����", "�շ�����", (IsVisable("�շ�����", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�Ƿ�Ա", "�Ƿ�Ա", (IsVisable("�Ƿ�Ա", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩԱ", "��ҩԱ", (IsVisable("��ҩԱ", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩԱ", "��ҩԱ", (IsVisable("��ҩԱ", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("������", "������", (IsVisable("������", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFLX", "CFLX", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("JSSJH", "JSSJH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("CFXH", "CFXH", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("PATID", "PATID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YSDM", "YSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("KSDM", "KSDM", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("sfczy", "sfczy", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("qrczyh", "qrczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("pyczyh", "pyczyh", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ����", "��ҩ����", (IsVisable("��ҩ����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���ʽ��", "���ʽ��", (IsVisable("���ʽ��", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�Żݽ��", "�Żݽ��", (IsVisable("�Żݽ��", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�Ը����", "�Ը����", (IsVisable("�Ը����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YPID", "YPID", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("YDWBL", "YDWBL", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("cfmxid", "cfmxid", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("������", "������", (IsVisable("������", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�������", "�������", (IsVisable("�������", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("ʹ��Ƶ��", "ʹ��Ƶ��", (IsVisable("ʹ��Ƶ��", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", false) ? 70 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��λ���", "��λ���", (IsVisable("��λ���", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("zsyp", "zsyp", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("fpid", "fpid", (IsVisable("fpid", true) ? 80 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��Ʊ��ˮ��", "��Ʊ��ˮ��", (IsVisable("��Ʊ��ˮ��", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ҩ��ע", "��ҩ��ע", (IsVisable("��ҩ��ע", true) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ע2", "��ע2", (IsVisable("��ע2", true) ? 150 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("��ע3", "��ע3", (IsVisable("��ע3", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("�����÷�", "tsyf", 150, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("tyid", "tyid", (IsVisable("tyid", true) ? 50 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("dwbl", "dwbl", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("����", "����", (IsVisable("����", false) ? 90 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("Ч��", "Ч��", (IsVisable("Ч��", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("���κ�", "���κ�", (IsVisable("���κ�", true) ? 60 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("ypsl", "ypsl", (IsVisable("ypsl", true) ? 95 : 0), true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("hwmc", "hwmc", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("byscf", "byscf", 0, true, 0));
            columns.Add(ColumnDefine.NewColumnDefine("������λ����", "������λ����", 0, true, 0));
            #endregion

            DataTable dtTmp = new DataTable();
            dtTmp.TableName = "tbmx";
            SystemCfg cfg8032 = new SystemCfg(8032);
            #region ������
            int j = 0;
            foreach (ColumnDefine define in columns)
            {
                //DataGridEnableBoolColumn
                if (define.ColBoolButton == 0)
                {
                    if (define.HeaderText != "��ʾ��")
                    {
                        DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                        colText.HeaderText = define.HeaderText;
                        colText.MappingName = define.MappingName;
                        colText.Width = define.ColWidth;
                        colText.NullText = "";
                        colText.ReadOnly = define.ColReadOnly;
                        //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    }
                    else
                    {
                        MydataGirdImageColumn mycol = new MydataGirdImageColumn();
                        mycol.HeaderText = define.HeaderText;
                        mycol.MappingName = define.MappingName;
                        mycol.Width = define.ColWidth;
                        mycol.NullText = "";
                        mycol.ReadOnly = define.ColReadOnly;
                        mycol.ONCurrentChange += new DelCurrentChage(mycol_ONCurrentChange);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(mycol);
                        if (cfg8032.Config == "0")
                            mycol.Width = 0;
                    }

                    DataColumn datacol;
                    if (define.MappingName.Trim() == "ypsl" || define.MappingName == "���")
                        datacol = new DataColumn(define.MappingName, Type.GetType("System.Decimal"));
                    else
                        datacol = new DataColumn(define.MappingName);

                    dtTmp.Columns.Add(datacol);
                }
                else
                {
                    DataGridButtonColumn btnCol = new DataGridButtonColumn(j);
                    btnCol.HeaderText = define.HeaderText;
                    btnCol.MappingName = define.MappingName;
                    btnCol.Width = define.ColWidth;
                    btnCol.CellButtonClicked += new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
                    xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
                    this.myDataGrid1.MouseDown += new MouseEventHandler(btnCol.HandleMouseDown);
                    this.myDataGrid1.MouseUp += new MouseEventHandler(btnCol.HandleMouseUp);
                    DataColumn datacol;
                    datacol = new DataColumn(define.MappingName);
                    dtTmp.Columns.Add(datacol);
                }
                j++;
            }
            #endregion
            xcjwDataGrid.DataSource = dtTmp;
            xcjwDataGrid.TableStyles[0].MappingName = "tbmx";
            //if (s.����������ʾ��Ʒ�� == true)
            xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 150;
            //else
            //    xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width = 0;
            #endregion
        }

        void mycol_ONCurrentChange(int CurIndex)
        {
            try
            {

                string hlyytype = ApiFunction.GetIniString("hlyy", "name", System.Windows.Forms.Application.StartupPath + "\\Hlyy.ini");
                DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                int nrow = myDataGrid1.CurrentCell.RowNumber;
                int ncol = myDataGrid1.CurrentCell.ColumnNumber;
                if (tbmx.Columns[ncol].Caption != "��ʾ��")
                    return;
                Guid ghxxid = new Guid(tbmx.Rows[nrow]["patid"].ToString());
                string mzh = tbmx.Rows[nrow]["�����"].ToString();
                string xb = tbmx.Rows[nrow]["�Ա�"].ToString();
                object brxxid = InstanceForm.BDatabase.GetDataResult("select top 1 brxxid from mz_ghxx where ghxxid='" + ghxxid + "'", 30);

                //MessageBox.Show(brxxid.ToString());
                //Add hlyy by Zj 2012-02-13
                YY_BRXX brxx = new YY_BRXX(new Guid(Convertor.IsNull(brxxid, Guid.Empty.ToString())), InstanceForm.BDatabase);
                string username = InstanceForm.BCurrentUser.EmployeeId.ToString() + "/" + InstanceForm.BCurrentUser.Name;
                string ksname = InstanceForm.BCurrentDept.DeptId.ToString() + "/" + InstanceForm.BCurrentDept.DeptName;
                ts_mz_class.ts_mz_hlyy.InitializationHLYY(username, ksname, Convert.ToInt32(TrasenFrame.Forms.FrmMdiMain.CurrentSystem.SystemId), mzh, 0, brxx.Brxm, xb, brxx.Csrq);

                //MessageBox.Show("ʵ����������");

                DateTime severtime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                Ts_Hlyy_Interface.HlyyInterface hl = Ts_Hlyy_Interface.HlyyFactory.Hlyy(hlyytype);

                string ss = tbmx.Rows[nrow]["YPID"].ToString() + "," + tbmx.Rows[nrow]["Ʒ��"].ToString() + "," + tbmx.Rows[nrow]["��λ"].ToString() + "," + tbmx.Rows[nrow]["�÷�"].ToString();
                DataTable Tab_hlyy = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, ghxxid, "",
                     "", 0,
                    "", "", 0, 2, "", "", "", 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                Ts_Hlyy_Interface.CfInfo[] cfinfo = new Ts_Hlyy_Interface.CfInfo[Tab_hlyy.Rows.Count];
                int result = 0;
                //MessageBox.Show("��ʼFOR��,һ��"+cfinfo.Length.ToString()+"��");
                for (int i = 0; i <= cfinfo.Length - 1; i++)
                {
                    cfinfo[i].dwmc = Tab_hlyy.Rows[i]["������λ"].ToString();
                    cfinfo[i].jl = Tab_hlyy.Rows[i]["����"].ToString();
                    cfinfo[i].kyzsj = severtime;
                    cfinfo[i].kyzsj = Convert.ToDateTime(severtime);
                    cfinfo[i].kyzysid = Tab_hlyy.Rows[i]["ysdm"].ToString();
                    cfinfo[i].kyzysmc = Tab_hlyy.Rows[i]["ҽ��"].ToString();
                    cfinfo[i].pc = Tab_hlyy.Rows[i]["Ƶ��"].ToString().Trim();
                    cfinfo[i].Tyzsj = Convert.ToDateTime(severtime);
                    cfinfo[i].xmid = Tab_hlyy.Rows[i]["YPID"].ToString();
                    cfinfo[i].xmly = 1;
                    cfinfo[i].yf = Tab_hlyy.Rows[i]["�÷�"].ToString();
                    cfinfo[i].yzid = Tab_hlyy.Rows[i]["cfmxid"].ToString();
                    cfinfo[i].yzmc = Tab_hlyy.Rows[i]["Ʒ��"].ToString();
                    cfinfo[i].Yztype = 1;
                    if (-1 > 0)
                        cfinfo[i].zh = result;
                    else
                    {
                        cfinfo[i].zh = result;
                        result++;
                    }
                }
                //MessageBox.Show("FOR����");
                hl.recipe_check(3, null, severtime, 1, ref cfinfo, 0);

                //MessageBox.Show("�ɹ�");
            }
            catch (Exception ex)
            {
                MessageBox.Show("���ô���!ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        void TextBox_TextChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            ImageList im = new ImageList();
            string dd = control.Text;
            //im.Images.Add(this.imageList1.Images[
            //control.Controls.Add(
        }

        void colText_WidthChanged(object sender, EventArgs e)
        {

        }

        //����ɫ�ı��¼�
        private void myDataGrid1_CheckCellEnabled(object sender, DataGridEnableEventArgs e)
        {
            try
            {
                e.BackColor = Color.White;
                DataTable tb;
                if (sender.GetType().ToString() == "TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
                {
                    DataGridEnableBoolColumn column = (DataGridEnableBoolColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                else
                {
                    DataGridEnableTextBoxColumn column = (DataGridEnableTextBoxColumn)sender;
                    tb = (DataTable)column.DataGridTableStyle.DataGrid.DataSource;
                }
                if (e.Row > tb.Rows.Count - 1)
                    return;
                //				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
                //					e.BackColor=Color.Azure;

                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "��")
                    e.ForeColor = Color.Blue;
                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "")
                    e.ForeColor = Color.Black;
                if (tb.Rows[e.Row]["��ҩ"].ToString().Trim() == "��")
                    e.ForeColor = Color.Gray;
                if (tb.Rows[e.Row]["byscf"].ToString().Trim() == "1")
                    e.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(222)))), ((int)(((byte)(255))))); //System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
                else
                    e.BackColor = Color.White;



                //Modify by jchl
                if (tb.Rows[e.Row]["����"].ToString().Trim() == "������" && tb.Rows[e.Row]["cflx"].ToString().Trim() == "03")
                {
                    e.BackColor = Color.LightGreen;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //			
        }

        //��ѯ������ť�¼�
        private void butcfcx_Click(object sender, System.EventArgs e)
        {
            this.Cursor = PubStaticFun.WaitCursor();
            try
            {
                #region ������ 20110307
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    try
                    {
                        if (this._call != null && this._call.CurrentThread != null)
                            this._call.CurrentThread.Abort();
                        this._call.Call(ts_call.DmType.���, "", 0);
                    }
                    catch
                    {
                    }
                }
                #endregion


                DataTable tb = new DataTable();

                //string rq1=chkrq.Checked==true?dtprq1.Value.ToShortDateString():"";
                //string rq2=chkrq.Checked==true?dtprq2.Value.ToShortDateString():"";
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = 0;
                if (rdo2.Checked == true)
                    fybz = 1;
                if (rdo3.Checked == true)
                    fybz = 2;

                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";

                if (rdo1.Checked == true)
                {
                    sfrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                    sfrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                    fyrq1 = "";
                    fyrq2 = "";
                }
                else
                {
                    sfrq1 = "";
                    sfrq2 = "";
                    fyrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                    fyrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                }

                if (txtxm.Text.Trim() == "" && txtmzh.Text.Trim() == "" && txttmk.Text.Trim() == "" && txtfph.Text.Trim() == "" && chkrq.Checked == false && rdo2.Checked == true)
                {
                    MessageBox.Show("��ѡ��һ���Ĳ�ѯ����");
                    return;
                }

                tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, txtxm.Text.Trim(),
                     "", 0,
                    fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);

                this.AddPresc(tb);

                chkall.Checked = false;

                firstXm = string.Empty;
                //setButtionState = 0;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //��Ӵ�����¼
        private void AddPresc(DataTable tbcf)
        {

            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();

            if (tbcf.Rows.Count == 0)
                return;

            tbcf = DoFilFylb(tbcf);

            if (tbcf.Rows.Count == 0)
                return;

            string _prescNo = tbcf.Rows[0]["������"].ToString().Trim();
            int _PrescRowNo = 0;
            decimal _PrescJe = 0;

            if (tbcf.Rows.Count > 0)
            {
                cmbpyr.SelectedIndexChanged -= new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
                //cmbpyr.Text = tbcf.Rows[0]["��ҩԱ"].ToString().Trim();
                cmbpyr.SelectedIndexChanged += new System.EventHandler(this.cmbpyr_SelectedIndexChanged);
            }
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                if (tbcf.Rows[i]["������"].ToString().Trim() != _prescNo)
                {
                    DataRow row = tb.NewRow();
                    row["���"] = "С��";
                    row["���"] = _PrescJe.ToString("0.00");
                    row["������"] = _prescNo;
                    _prescNo = tbcf.Rows[i]["������"].ToString().Trim();
                    _PrescRowNo = 0;
                    _PrescJe = 0;
                    tb.Rows.Add(row);

                    DataRow row1 = tb.NewRow();
                    tb.Rows.Add(row1);
                }

                if (tbcf.Rows[i]["������"].ToString().Trim() == _prescNo)
                {
                    _PrescRowNo = _PrescRowNo + 1;
                    tbcf.Rows[i]["���"] = _PrescRowNo.ToString();
                    //					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["��ҩ"]="��";
                    tb.ImportRow(tbcf.Rows[i]);
                    _PrescJe = _PrescJe + Convert.ToDecimal(tbcf.Rows[i]["���"]);

                    //wxz

                    //wxz
                }

                _prescNo = tbcf.Rows[i]["������"].ToString().Trim();

            }

            //������һ�Ŵ����ĺϼ�
            DataRow endrow = tb.NewRow();
            endrow["���"] = "С��";
            endrow["���"] = _PrescJe.ToString("0.00");
            endrow["������"] = _prescNo;
            tb.Rows.Add(endrow);

            //if (tb.Rows.Count > 1)
            //    myDataGrid1.CurrentCell =null;
        }

        #region һ�����

        private void chkrq_CheckedChanged(object sender, System.EventArgs e)
        {
            dtprq1.Enabled = this.chkrq.Checked == true ? true : false;
            dtprq2.Enabled = this.chkrq.Checked == true ? true : false;
            this.butcfcx.Enabled = this.chkrq.Checked == true ? true : false;
            txtxm.Enabled = this.chkrq.Checked == true ? true : false;
        }


        string firstXm = string.Empty;
        //int setButtionState = 0;
        //��ϸ�еİ�ť�¼�
        private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            if (this.rdo2.Checked == true)
                return;

            //int cfdcount = 1;
            //if (!string.IsNullOrEmpty(firstXm))
            //{
            //    List<string> cfxhList = new List<string>();
            //    DataRow[] retRows = tb.Select(string.Format(" ���� = '{0}'", firstXm));
            //    if (retRows != null && retRows.Length > 0)
            //    {
            //        foreach (DataRow row in retRows)
            //        {
            //            if (cfxhList.Count == 0)
            //                cfxhList.Add(row["cfxh"].ToString().Trim());
            //            else if (!cfxhList.Contains(row["cfxh"].ToString().Trim()))
            //            {
            //                cfxhList.Add(row["cfxh"].ToString().Trim());
            //            }
            //        }
            //    }
            //    cfdcount = cfxhList.Count;
            //}
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["������"].ToString().Trim() == tb.Rows[e.RowIndex]["������"].ToString().Trim() && tb.Rows[i]["������"].ToString().Trim() != "" && tb.Rows[i]["��ҩ"].ToString().Trim() != "��")
                {
                    if (tb.Rows[i]["��ҩ"].ToString().Trim() == "")
                    {
                        object xm = tb.Rows[i]["����"];
                        if (string.IsNullOrEmpty(firstXm))
                            firstXm = xm != null ? xm.ToString().Trim() : string.Empty;
                        if (kf != null)
                        {
                            if (firstXm == xm.ToString().Trim())
                            {
                                tb.Rows[i]["��ҩ"] = "��";
                            }

                            if (tb.Rows[i][0] != null && tb.Rows[i][0].ToString().Trim() == "С��")  //&& setButtionState <= cfdcount)
                            {
                                if (xm == DBNull.Value && tb.Rows[i - 1]["����"].ToString().Trim() == firstXm)
                                {
                                    //setButtionState++;
                                    tb.Rows[i]["��ҩ"] = "��";
                                }
                            }
                        }
                        else
                        {
                            tb.Rows[i]["��ҩ"] = "��";
                        }

                    }
                    else
                    {
                        tb.Rows[i]["��ҩ"] = "";
                        if (!string.IsNullOrEmpty(firstXm))
                        {
                            DataRow[] retRows = tb.Select(string.Format(" ���� = '{0}' and ��ҩ = '��'", firstXm));
                            if (retRows == null || retRows.Length <= 0)
                            {
                                firstXm = string.Empty;
                                //setButtionState = 0;
                            }
                        }
                    }
                }
            }
            myDataGrid1.Refresh();
        }

        //ȫѡ
        private void chkall_CheckedChanged(object sender, System.EventArgs e)
        {
            //			if (this.tabControl1.SelectedTab!=this.tabPage1) return;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            for (int i = 0; i <= tb.Rows.Count - 1; i++)
            {
                if (tb.Rows[i]["������"].ToString().Trim() != "" && tb.Rows[i]["��ҩ"].ToString().Trim() != "��")
                {
                    if (chkall.Checked == true)
                        tb.Rows[i]["��ҩ"] = "��";
                    else
                        tb.Rows[i]["��ҩ"] = "";
                }
            }
        }


        #endregion

        private void DoZcyJyFy()
        {
            try
            {

                string hosCode = "990002";
                string hosName = "�人������ҽԺ";

                string sFre = string.Format(@"select EXECNUM,* from JC_FREQUENCY ");
                DataTable dtFre = InstanceForm.BDatabase.GetDataTable(sFre);

                if (true)
                {
                    DateTime _sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    int NN = 0;
                    int YY = 0;

                    //������ҩ���в�ҩ������
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;

                    //���鴦��
                    //emrͬ������    �÷�Ϊ  �������ʹ���
                    DataRow[] selrow = tb.Select("��ҩ='��' and ypid<>'' and �÷�='����'");
                    DataTable tbsel = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel.ImportRow(selrow[w]);

                    string[] GroupbyField ={ "jssjh", "��Ʊ��", "�ܽ��", "���ʽ��", "�Żݽ��", "�Ը����", "cfxh", "patid", "�����", "����", "ysdm", "ksdm", "�շ�����", "sfczy", "��ҩ����", "�Ա�", "����", "ҽ��", "����", "����" };
                    string[] ComputeField ={ "���" };
                    string[] CField ={ "sum" };
                    DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                        SetDefaultFocuse();
                        return;
                    }
                    else if (tbcf.Rows.Count > 1)
                    {
                        MessageBox.Show("�в�ҩ��ҩ����ֻ�ܵ��ŷ���");
                        SetDefaultFocuse();
                        return;
                    }

                    //���ﴦ����ҩ�У��в�ҩ������
                    if (tbcf.Rows.Count > 0)
                    {
                        for (int i = 0; i < tbcf.Rows.Count; i++)
                        //for (int i = 0; i < 1; i++)
                        {
                            bool bThisPresSuc = false;

                            DataRow[] rows = tb.Select("��Ʊ��='" + tbcf.Rows[i]["��Ʊ��"].ToString() + "' and ypid<>'' and �����='" + tbcf.Rows[i]["�����"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "���");

                            string _presc_no = Convert.ToString(tbcf.Rows[i]["CFXH"]); //������ 
                            decimal _sumzje = Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�ܽ��"], "0")); //���
                            int _cfts = 0;// Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")); //����
                            _cfts = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")); //����
                            Guid _inpatient_id = new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString()));//ghxxid

                            string _inpatient_no = Convert.ToString(tbcf.Rows[i]["�����"]);//�����
                            string _hzxm = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            string _hzxb = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["�Ա�"], ""));//�Ա�
                            string _hznl = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����
                            string _jtdz = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["��ͥ��ַ"], ""));//��ͥ��ַ
                            string _lxfs = "";// Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["��ϵ��ʽ"], ""));//��ϵ��ʽ
                            string _blh = "����" + _inpatient_no;

                            string wardCode = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//���￴����ҡ����޸����ۡ�
                            string bedNo = "";//Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//����

                            //ClsZcyJy.ClsJyInterFace
                            string _ts = "2"; //������һ�켸�Ρ�Ƶ�ʵ�ִ�д�����
                            string _fs = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["����"], ""));//�����Ǽ���; //�����Ǽ���

                            string fre = ""; // Convert.ToString(Convertor.IsNull(rows[j]["Ƶ��"], ""));
                            string _yyfs = ""; //��ҩ��ʽ���÷���
                            string _jyfs = "2";//��ҩ��ʽ��д�������޸����ۡ�
                            string _allWgt = "";//����������������ʱ���ա�
                            string packvolume = "200";//��װ������д��Ĭ��200��

                            string _dept_id = Convertor.IsNull(tbcf.Rows[i]["KSDM"], "0");//����
                            string _doc_id = Convertor.IsNull(tbcf.Rows[i]["YSDM"], "-1");//ҽ��
                            Guid _fyid = Guid.Empty;//��ҩID

                            //�޸��ϴ� �� ����������
                            FrmZcyTsFs frmFsTs = new FrmZcyTsFs(_fs, _ts);
                            frmFsTs.ShowDialog();

                            if (frmFsTs.save)
                            {
                                _ts = frmFsTs.Ts;
                                _fs = frmFsTs.Fs;
                            }

                            DateTime dtScTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//�ϴ�ʱ��

                            string buyUnit = "KG";

                            string doc = Convert.ToString(Convertor.IsNull(tbcf.Rows[i]["ҽ��"].ToString(), ""));////Convert.ToString(Convertor.IsNull(rows[j]["ҽ��"], ""));


                            //��ѯ���͸ô�����ϸ�� ��ҩϵͳ 
                            decimal sumjhje = 0;//�ܽ������
                            NN = 0;//��ϸ����
                            string strMsg = "";
                            bool bDel = false;

                            //�ϴ�֮ǰ��ɾ��������ϸ
                            try
                            {
                                //�ϴ�֮ǰ��ɾ��������ϸ
                                bDel = ClsZcyJy.ClsJyInterFace.DeletePres(hosCode, _presc_no, out strMsg);



                            }
                            catch (Exception ex)
                            {
                                //log
                                //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
                                TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** �������в�ҩ�ϴ��� begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** �в�ҩ�ϴ� end ***",
                                DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                continue;
                            }

                            for (int j = 0; j <= rows.Length - 1; j++)
                            {

                                //if (string.IsNullOrEmpty(fre))
                                //{
                                //    //fre = Convert.ToString(Convertor.IsNull(rows[j]["Ƶ��"], ""));
                                //    fre = "bid";//��ҩԼ��д��    ����EMR������
                                //    if (!string.IsNullOrEmpty(fre))
                                //    {
                                //        _ts = ClsZcyJy.ClsJyInterFace.GetFreqExecNum(dtFre, fre);

                                //        if (_ts.Equals("-1"))
                                //        {
                                //            return;
                                //        }
                                //    }
                                //}

                                //if (string.IsNullOrEmpty(_fs))
                                //{
                                //    _fs = Convert.ToString(Convertor.IsNull(rows[j]["����"], ""));
                                //    _cfts = Convert.ToInt32(Convertor.IsNull(rows[i]["����"], "0")); //����
                                //}

                                if (string.IsNullOrEmpty(_yyfs))
                                {
                                    _yyfs = Convert.ToString(Convertor.IsNull(rows[j]["�÷�"], ""));
                                }

                                string cjid = rows[j]["YPID"].ToString();
                                string spm = rows[j]["Ʒ��"].ToString();
                                string gg = rows[j]["���"].ToString();
                                string sccj = rows[j]["����"].ToString();

                                int _yl = Convert.ToInt32(rows[j]["����"]);
                                int _js = Convert.ToInt32(rows[j]["����"]);
                                int _sl = (_yl * _js);
                                string sl = _sl.ToString();
                                string yldw = rows[j]["��λ"].ToString(); //Convert.ToInt32(rows[j]["��λ"]);
                                string jldwsl = rows[j]["������λ����"].ToString(); //Convert.ToInt32(rows[j]["��λ"]);

                                string jl = rows[j]["����"].ToString();
                                string jldw = rows[j]["������λ"].ToString();
                                string lsdj = rows[j]["����"].ToString();
                                decimal lsje = decimal.Parse(Convertor.IsNull(rows[j]["���"].ToString(), "0"));
                                string tsyf = Convertor.IsNull(rows[j]["tsyf"], "");

                                string pfdj = rows[j]["������"].ToString();
                                decimal pfje = decimal.Parse(Convertor.IsNull(rows[j]["�������"].ToString(), "0"));


                                //------------------add by wangzhi at 2014-08-01 ��������ͬ�Ĵ���,(д��ҩ��ϸ�ĵ�λ���浥λһ��)------------------  
                                //js = 1;  //ǿ�Ƽ���Ϊ1
                                //sl = ypsl; //����ֱ��ȡ��ֽ��
                                //pfj_cfmx = Convert.ToDecimal(rows[j]["������"]) * dwbl_cfmx / dwbl_kc; //ʹ��������ʹ�õĵ�λ���������ʹ�õĵ�λ����һ��
                                //lsj_cfmx = Convert.ToDecimal(rows[j]["����"]) * dwbl_cfmx / dwbl_kc;   //ͬ��
                                //------------------end modify by wangzhi at 2014-08-01------------------
                                strMsg = "";
                                //

                                bool bMedSuc = false;
                                try
                                {
                                    bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, jldwsl, _yl.ToString(), jldwsl, lsdj, lsje.ToString("0.00"), jldw, tsyf, out strMsg);

                                    ////ѭ���ϴ���ϸ
                                    //bMedSuc = ClsZcyJy.ClsJyInterFace.His_DrugInfo(_presc_no, hosCode, hosName, cjid, spm, gg, sccj, sl, yl, sl, lsdj, lsje, jldw, tsyf, out strMsg);

                                }
                                catch (Exception ex)
                                {
                                    //log
                                    //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** �������в�ҩ�ϴ��� begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** �в�ҩ�ϴ� end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                    break;
                                }

                                if (bMedSuc)
                                {
                                    NN = NN + 1;
                                }
                                else
                                {
                                    //log
                                    //��ϸ�ϴ�ʧ��   �������ϴ�ֹͣ  ���鴦����ʼ
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** �������в�ҩ�ϴ��� begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** �в�ҩ�ϴ� end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,strMsg) }, false);

                                    break;
                                }

                                sumjhje += lsje;
                            }

                            string ret = "";
                            if (NN == rows.Length)
                            {
                                //
                                //bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, _blh,
                                //    wardCode, bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume);

                                //
                                bThisPresSuc = ClsZcyJy.ClsJyInterFace.His_UserRecipe(hosCode, hosName, _hzxm, _hzxb, _hznl, _jtdz, _lxfs, _presc_no, "", _blh,
                                    bedNo, _ts, _fs, _yyfs, _jyfs, _allWgt, packvolume, dtScTime, doc, dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), buyUnit, wardCode, sumjhje.ToString("0.00"), dtScTime.ToString("yyyy-MM-dd HH:mm:ss"), "", "", out ret);

                                if (!bThisPresSuc)
                                {
                                    //log
                                    //������Ϣ�ϴ�����  �������ϴ�ֹͣ,    �������鴦����ʼ
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** ��סԺ�в�ҩ�ϴ��� begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** �в�ҩ�ϴ� end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ret) }, false);

                                    continue;
                                }
                            }


                            //�ӿڴ���ɹ�
                            if (bThisPresSuc)
                            {


                                InstanceForm.BDatabase.BeginTransaction();
                                try
                                {
                                    //���£�CHARGE_BIT,FY_BIT,FY_DATE,FY_USER
                                    string strCySql = string.Format(@"update MZ_CFB set bfybz=1,FYRQ='{1}' ,FYR='{2}'
                                                            where CFID='{0}' ", _presc_no, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentUser.EmployeeId);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    strCySql = string.Format(@"update yf_zcyfy_sc set del_bit=1 where CFXH='{0}' ", _presc_no);

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    strCySql = string.Format(@"insert into yf_zcyfy_sc(
                                                        id,jgbm,cflx,JSSJH,FPH,
                                                        zje,cfts,CFXH,PATID,PATIENTNO,HZXM,YSDM,KSDM,
                                                        SKRQ,SKY,FYRQ,FYR,PYR,PYCKH,FYCKH,DEPTID,JZCFBZ,TFBZ,YWLX,wkdz)  
                                                        values('{0}','{1}','{2}','{3}','{4}',
                                                        '{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',
                                                        '{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}');  ",
                                                        Guid.NewGuid(), InstanceForm._menuTag.Jgbm, "1", "0", "02",
                                                        _sumzje, _cfts, _presc_no, _inpatient_id, _inpatient_no, _hzxm, _doc_id, _dept_id,
                                                        _sDate, InstanceForm.BCurrentUser.EmployeeId, _sDate, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BCurrentUser.EmployeeId,
                                                        "", "", InstanceForm.BCurrentDept.DeptId, "1", 0, _menuTag.FunctionTag, PubStaticFun.GetMacAddress());

                                    InstanceForm.BDatabase.DoCommand(strCySql);

                                    InstanceForm.BDatabase.CommitTransaction();
                                }
                                catch (Exception ex)
                                {
                                    InstanceForm.BDatabase.RollbackTransaction();
                                    //log
                                    TrasenMainWindow.FrmMdiMainWindow.WriteFrameLocalLog(new string[] { string.Format(@"
*** �������в�ҩ�ϴ��� begin ***
*** Local Time : '{0}' ***
*** Pres_no    : '{1}' ***
*** Inp_id     : '{2}' ***
*** Err_info   : '{3}' ***
*** �в�ҩ�ϴ� end ***",
                                                                                                        DateTime.Now.ToString(),_presc_no,_inpatient_id,ex.Message) }, false);

                                    throw ex;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    #region ������������Ϊ�ѷ�ҩ״̬


                    MessageBox.Show("��ҩ�ɹ���\n\n", "��ҩ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CallNumber(2); //���ҩ���к���ʾ��

                    SetDefaultFocuse();
                    this.butfy.Enabled = true;
                    try
                    {
                        DataRow[] rows_ref = null;
                        DataView dv = (DataView)dataGridView1.DataSource;
                        if (dv != null)
                        {
                            DataTable tbref = dv.Table;
                            if (cfg8027 == "1")
                                rows_ref = tbref.Select("��Ʊ��='" + tbcf.Rows[0]["��Ʊ��"].ToString() + "' and ����='" + tbcf.Rows[0]["����"].ToString() + "'");
                            if (cfg8027 == "2")
                                rows_ref = tbref.Select("����='" + tbcf.Rows[0]["����"].ToString() + "'");
                            if (rows_ref != null)
                            {
                                if (rows_ref.Length > 0)
                                    tbref.Rows.Remove(rows_ref[0]);
                            }
                            if (cfg8027 != "0" && tbref.Rows.Count == 0)
                                button_ref_Click(null, null);
                        }

                        if (_textBox != null)
                        {
                            _textBox.Focus();
                            _textBox.SelectAll();
                        }
                        else
                        {
                            txtmzh.Focus();
                            txtmzh.SelectAll();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    //��ӡ����
                    try
                    {
                        for (int i = 0; i <= tb.Rows.Count - 1; i++)
                        {
                            if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                                tb.Rows[i]["��ҩ"] = "��";
                        }

                        //��ӡ���������
                        if (chkprint.Checked == true)
                        {
                            this.butprint_Click(null, null);
                        }
                        //this.butprint_Click(sender, e);
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show("��ӡ����ʱ��������" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�ϴ�����" + ex.Message, "��ʾ");
            }
            finally
            {
                //this.Cursor = Cursors.Arrow;
                SetDefaultFocuse();
                //Add by Zhujh 2017-05-10 ������
                yongtai.PlzOpinion();
            }

            //string bqypjq = ApiFunction.GetIniString("������", "����������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //string pjqxh = ApiFunction.GetIniString("������", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //if (bqypjq == "true")
            //{
            //    ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
            //    string perr_text = "";
            //    int perr_code = 0;
            //    ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
            //    if (perr_code != 0)
            //        throw new Exception("���������ó���!" + perr_text);
            //}
        }

        protected bool getTimeSpan(string timeStr,string Str_start,string str_End)
        {
            //�жϵ�ǰʱ���Ƿ��ڹ���ʱ�����
           // string _strWorkingDayAM = "08:30";//����ʱ������08:30
           // string _strWorkingDayPM = "17:30";

            string _strWorkingDayAM = Str_start;//����ʱ������08:30
            string _strWorkingDayPM = str_End;
            TimeSpan dspWorkingDayAM = DateTime.Parse(_strWorkingDayAM).TimeOfDay;
            TimeSpan dspWorkingDayPM = DateTime.Parse(_strWorkingDayPM).TimeOfDay;

            //string time1 = "2017-2-17 8:10:00";
            DateTime t1 = Convert.ToDateTime(timeStr);

            TimeSpan dspNow = t1.TimeOfDay;
            if (dspNow > dspWorkingDayAM && dspNow < dspWorkingDayPM)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// �����ҩ��ť�������Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butfy_Click(object sender, System.EventArgs e)
        {
            string str_GHXXID = "";//�Һ���ϢID
            string str_PATID = "";//������ϢID
            string str_HHkf_settingValue = ApiFunction.GetIniString("ҩ���췢����", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
            string str_HH_Flag = "";
            if (str_HHkf_settingValue.Equals("��Ժʹ����Ժ��ͬ����췢"))
            {
                str_HH_Flag = "1";
            }


            //�Ƿ����ɨ���������ǿ���ж�

            //**************************************************
            #region

            string str_SMFlag = ApiFunction.GetIniString("ǿ��������ɨ�뷢ҩ", "ǿ������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            //[ǿ��������ɨ�뷢ҩ] ǿ������=1  Ϊ1��ʾǿ�ƿ��ƣ����򲻽���ǿ�ƿ���
            if (str_SMFlag == "1")
            {
                bool str_flag = false;
                SystemCfg str_TimeFlag = new SystemCfg(19006);
                if (str_TimeFlag != null && !string.IsNullOrEmpty(str_TimeFlag.Config) )
                {
                    //���������
                    if (str_TimeFlag.Config.Contains("-"))
                    {
                        //18:00:00-23:00:00 ʱ���ʽ 
                        //string time=convert.tostring(DateTime.Today).split( new char []{' '});    
                        //textbox1.text=time[0]; �Կո���Ϊ�ֽ��;
                        string strtime = str_TimeFlag.Config.ToString();
                        string[] time = strtime.Split(new char[]{'-'});
                        string str_Start = time[0].ToString();
                        string str_StrEnd = time[1].ToString();
                       
                      string str_serTime= DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();//������ʱ��
                      str_flag = getTimeSpan(str_serTime, str_Start, str_StrEnd);

                      if (str_flag)
                      {
                          string str_YPIDall = get_fy_YPID_All(); //�õ�ҩƷID������ַ��� 
                          // MessageBox.Show(str_YPIDall);
                          CheckDrugTxm_List FW = new CheckDrugTxm_List();
                          FW.FillDj(str_YPIDall);
                          FW.ShowDialog();
                          //if (FW.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                         
                        // if (FW.ShowDialog() != DialogResult.OK)
                          if(FW.ReturnValue!="0")
                          {
                              return ;
                          } 
                      }

                    }
                    else
                    {
                        MessageBox.Show("������˶Է�ҩ������Ϣʱ��θ�ʽ�����ò���ȷ�������ø�ʽ�磺18:00-23:00");
                    }
                }               
            }
          

            #endregion


            string validSql = string.Format(@"select count(1) as num from V_JC_YP_ZCYSC where dept_id='{0}'", InstanceForm.BCurrentDept.DeptId);

            int iRet = int.Parse(InstanceForm.BDatabase.GetDataResult(validSql).ToString());

            if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_ZCY" && iRet > 0)
            {
                DoZcyJyFy();
            }
            else
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource; //������ϸ����
                //if (s.��ҩģʽ==true && this._Fyckh.Trim()==""){MessageBox.Show("ϵͳ��ǰ������ҩģʽ����ǰ���ڱ������ã�","��ҩ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;};
                if (s.ϵͳ���� == false)
                {
                    MessageBox.Show("ϵͳδ����");
                    return;
                }
                if (s.����ϵͳ == true)
                {
                    MessageBox.Show("ϵͳ������Ա����");
                    return;
                }

                //int dd = tb.Rows.Count;

                string _pronamefy = "";
                string _pronamefymx = "";
                if (_menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY")
                {
                    _pronamefy = "sp_yf_fy";
                    _pronamefymx = "sp_yf_fymx";
                }
                else
                {
                    _pronamefy = "sp_yk_fy";
                    _pronamefymx = "sp_yk_fymx";
                }

                if (cmbpyr.Text.Trim() == "")
                {
                    MessageBox.Show("��ѡ����ҩ�ˣ�", "��ҩ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string sDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                string brxm = string.Empty;
                string brxxid = string.Empty;
                try
                {
                    //if (dataGridView1.CurrentRow != null)
                    //{
                    //    DataView dv = dataGridView1.DataSource as DataView;
                    //    int nrow = dataGridView1.CurrentRow.Index;
                    //    brxm = dv[nrow]["����"] != null ? dv[nrow]["����"].ToString() : "";
                    //    brxxid = dv[nrow]["brxxid"].ToString();
                    //}
                    //else
                    //{
                    object objXm = tb.Rows[0]["����"] ?? "";
                    object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tb.Rows[0]["patid"].ToString() + "' ");
                    brxm = objXm.ToString();
                    brxxid = objbrxxid != null ? objbrxxid.ToString() : "";

                    //����Ϊ�����͵����ӽ������ŵ����������õ�
                    str_GHXXID = tb.Rows[0]["patid"].ToString();//�Һ���ϢID
                    str_PATID = brxxid;//������ϢID
                    //}                  

                }
                catch
                { }

                Guid fyid = Guid.Empty;
                Guid fymxid = Guid.Empty;
                int err_code = -1;
                string err_text = "";
                try
                {
                    this.Cursor = PubStaticFun.WaitCursor();
                    //���鴦��
                    DataRow[] selrow = tb.Select("��ҩ='��' and ypid<>''");
                    DataTable tbsel = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel.ImportRow(selrow[w]);

                    #region ������ҩ
                    try
                    {
                        if (cfghlyytype != "0" && cfghlyytype != "")
                        {
                            switch (cfghlyytype)
                            {
                                case "1":
                                    #region ��ͨ������ҩ Add By lidan 2013-09-16
                                    object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tbsel.Rows[0]["patid"].ToString() + "' ");
                                    string strbrxxid = objbrxxid != null ? objbrxxid.ToString() : "";

                                    YY_BRXX brxx = new YY_BRXX(new Guid(strbrxxid), InstanceForm.BDatabase);
                                    string birth = brxx.Csrq;
                                    string patname = brxx.Brxm;

                                    int gh = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;// InstanceForm.BCurrentUser.EmployeeId;
                                    string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                                    string employeename = TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name;
                                    int ksdm = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId;
                                    string ksmc = TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptName;
                                    string mzh = tbsel.Rows[0]["�����"].ToString();
                                    string brxmhlyy = tbsel.Rows[0]["����"].ToString();
                                    string xb = tbsel.Rows[0]["�Ա�"].ToString();
                                    DataTable tb1 = tbsel;
                                    string icd = tbsel.Rows[0]["���"].ToString();
                                    int hfresult = hlyyjk.RegisterServer_fun(null);//���ĵ�

                                    hlyyjk.Refresh();
                                    StringBuilder sss = new StringBuilder(ts_mz_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, mzh, birth, brxmhlyy, xb, tb1, icd));

                                    hfresult = hlyyjk.DrugAnalysis(sss, 1);

                                    if (hfresult >= 2)
                                    {
                                        if (MessageBox.Show("����!�����п��ܴ��ڲ��������ҩ,��Ҫ������ҩ��?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                            return;
                                        hfresult = hlyyjk.SaveDrug(sss, 1);
                                    }

                                    hlyyjk.SaveXml(sss);


                                    //YpClass.Ypcj cj = new YpClass.Ypcj(Convert.ToInt32(tb1.Rows[0]["ypid"].ToString()), InstanceForm.BDatabase);
                                    //string str5 = " <safe><general_name>" + cj.S_YPPM+ "</general_name><license_number>" + cj.GGID.ToString() + "</license_number><type>0</type></safe>";
                                    //hlyyjk.ShowPoint(new StringBuilder(str5));

                                    //if (hfresult >= 2)
                                    //{
                                    //    if (MessageBox.Show("����!�����п��ܴ��ڲ��������ҩ,��Ҫ����������?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                    //        return;
                                    //    hfresult = hf.SaveDrug(sss, 1);
                                    //}

                                    #endregion
                                    break;
                                //case "2":
                                //    #region ����
                                //    #endregion
                                //    break;
                                default:
                                    MessageBox.Show(cfghlyytype + "�ú�����ҩ�ӿڲ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PASS����!ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #endregion

                    //string[] GroupbyField ={"jssjh","��Ʊ��","�ܽ��","���ʽ��","�Żݽ��","�Ը����","����","cfxh","patid","�����","����","ysdm","ksdm","�շ�����","sfczy","��ҩ����"};
                    string[] GroupbyField ={ "jssjh", "��Ʊ��", "�ܽ��", "���ʽ��", "�Żݽ��", "�Ը����", "cfxh", "patid", "�����", "����", "ysdm", "ksdm", "�շ�����", "sfczy", "��ҩ����" };
                    string[] ComputeField ={ "���" };
                    string[] CField ={ "sum" };
                    DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                    if (tbcf.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                        SetDefaultFocuse();
                        return;
                    }

                    InstanceForm.DebugView(tbcf);

                    #region ..������ж�,������˲��Ǳ��ⷿ��ҩ�����ұ��ⷿû������ҩ����� by wangzhi 2014-07-08
                    DataRow[] __rows = tb.Select("��ҩ='��' and ypid<> ''");
                    DataTable dtInvalid = new DataTable();
                    dtInvalid.Columns.Add("YP");
                    foreach (DataRow r in __rows)
                    {
                        decimal yl = Convert.ToDecimal(Convertor.IsNull(r["����"], "0"));
                        decimal je = Convert.ToDecimal(Convertor.IsNull(r["���"], "0"));
                        int ypid = Convert.ToInt32(r["YPID"]);
                        string ypmc = Convertor.IsNull(r["��Ʒ��"], "");
                        string ypgg = Convertor.IsNull(r["���"], "");
                        decimal kcl = Convert.ToDecimal(Convertor.IsNull(InstanceForm.BDatabase.GetDataResult(string.Format("select kcl from YF_KCMX where cjid = {0} and deptid={1}", ypid, InstanceForm.BCurrentDept.DeptId)), "0"));
                        if (kcl <= 0 && (yl != 0 || je != 0))
                        {
                            dtInvalid.Rows.Add(new object[] { ypmc + ypgg });
                        }
                    }
                    if (dtInvalid.Rows.Count > 0)
                    {
                        InventoryNotEnoughException exception = new InventoryNotEnoughException();
                        exception.Data = dtInvalid;
                        throw exception;
                    }
                    #endregion

                    //Add by zhujh 2017-06-26  �������󣺷�ҩ��ʱ������ʾ����ǡ�����ҩƷ��ʶ��ר����
                    foreach (DataRow item in tb.Rows)
                    {
                        if (Convertor.IsNull(item["��ҩ��ע"], "").Contains("����"))
                        {
                            MessageBox.Show("��ǡ�����ҩƷ��ʶ��ר����", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }

                    if (MessageBox.Show("�Ƿ�ҩ��", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        SetDefaultFocuse();
                        return;
                    }                  


                    ////Add by zhujh 2017-05-27 ������ʱ���
                    //ExecTimeLogger logger = ExecTimeLogger.Run("ҩ����ҩ");

                    InstanceForm.DebugView(tb);
                    int cfcount = 0;
                    this.butfy.Enabled = false;
                    //add by wangzhi
                    decimal sumje = 0;
                    //string brxm = "";
                    string _Bz = "";//��ҩ��ϸ��ע
                    //end add

                    Dictionary<string, string> updatePyrInfo = new Dictionary<string, string>();
                    if (!bpcgl) //���������ι���
                    {
                        InstanceForm.BDatabase.BeginTransaction();

                        #region ����yf_fy yf_fymx
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            DataRow[] rows = tb.Select("��Ʊ��='" + tbcf.Rows[i]["��Ʊ��"].ToString() + "' and ypid<>'' and �����='" + tbcf.Rows[i]["�����"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "���");

                            #region ���뷢ҩͷ��
                            MZYF.SaveFy(rows[0]["cflx"].ToString().Trim(),
                                Convert.ToDecimal(tbcf.Rows[i]["jssjh"]),
                                Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["��Ʊ��"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�ܽ��"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���ʽ��"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Żݽ��"], "0")),
                                Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Ը����"], "0")),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0")),
                                new Guid(tbcf.Rows[i]["cfxh"].ToString()),
                                new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString())),
                                tbcf.Rows[i]["�����"].ToString(),
                                tbcf.Rows[i]["����"].ToString(),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ysdm"], "0")),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ksdm"], "0")),
                                tbcf.Rows[i]["�շ�����"].ToString(),
                                Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["sfczy"], "0")),
                                sDate,
                                InstanceForm.BCurrentUser.EmployeeId,
                             // Convert.ToInt32(cmbpyr.SelectedValue),
                              Convert.ToInt32(GetKF_NY_HH_PYR(tbcf.Rows[i]["cfxh"].ToString())),//�˴����� �ӿ췢���õ���Ӧ��������ҩԱID Add by hyd 2017-11-30 
                                Convertor.IsNull(tbcf.Rows[i]["��ҩ����"], "0"),
                                _Fyckh,
                                InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, 0, _pronamefy, out fyid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase, string.Empty);
                            if (err_code != 0 || fyid == Guid.Empty)
                            {
                                throw new System.Exception(err_text);
                            }
                            this.butfy.Tag = fyid.ToString();
                            #endregion

                            string updateMzcfSql = "update MZ_CFB set PYR = {0},PYRXM = '{1}',PYRQ = '{2}',hxpyr = 1 where cfid = '" + tbcf.Rows[i]["cfxh"].ToString() + "'";
                            string updateYffySql = "update yf_FY set PYR = {0},pyrq = '{1}' where ID = '" + fyid.ToString() + "' ";
                            updatePyrInfo.Add(updateMzcfSql, updateYffySql);

                            #region ���뷢ҩ��ϸ
                            for (int j = 0; j <= rows.Length - 1; j++)
                            {
                                string UserEat = rows[j]["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[j]["����"]).ToString() + rows[j]["������λ"].ToString().Trim() + "/ÿ��";
                                string yf = Convert.ToString(rows[j]["�÷�"]) + "  " + rows[j]["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
                                string zt = Convert.ToString(rows[j]["����"]);
                                MZYF.SaveFymx(fyid,
                                    Convert.ToInt64(Convertor.IsNull(rows[j]["��Ʊ��"], "0")),
                                    new Guid(Convertor.IsNull(rows[j]["cfxh"], Guid.Empty.ToString())),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"], "0")),
                                    rows[j]["����"].ToString(),
                                    rows[j]["Ʒ��"].ToString(),
                                    rows[j]["��Ʒ��"].ToString(),
                                    rows[j]["���"].ToString(),
                                    rows[j]["����"].ToString(),
                                    rows[j]["��λ"].ToString(),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["ydwbl"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0")),//
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["����"], "0")),//
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["������"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["�������"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0")),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["���"], "0")),
                                    0,
                                    0,
                                    InstanceForm.BCurrentDept.DeptId,
                                    Guid.Empty,
                                    "",
                                    Guid.Empty,
                                    new Guid(Convertor.IsNull(rows[j]["cfmxid"], Guid.Empty.ToString())),
                                    rows[j]["Ƥ��"].ToString(),
                                    yf.Trim(),
                                    zt.Trim(),
                                    Convertor.IsNull(rows[j]["�÷�"], ""),
                                    Convertor.IsNull(rows[j]["Ƶ��"], ""),
                                    Convertor.IsNull(rows[j]["����"], ""),
                                    Convertor.IsNull(rows[j]["������λ"], ""),
                                    Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0")),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["���־"], "0")),
                                    Convert.ToInt32(Convertor.IsNull(rows[j]["�������"], "0")),
                                    _pronamefymx,
                                    out fymxid,
                                    out err_code,
                                    out err_text,
                                    0, 0, "", "", Guid.Empty,
                                    InstanceForm.BDatabase, bpcgl);
                                if (err_code != 0)
                                {
                                    throw new System.Exception(err_text);
                                }
                                cfcount = cfcount + 1;


                                string ssql = "select '[" + rows[j]["Ʒ��"].ToString() + "] �����:'+cast(cast(round(kcl/dwbl,3) as float) as varchar(50))+rtrim(dbo.fun_yp_ypdw(nypdw))+',��������ֵ:' +cast(cast(kcxx as float) as varchar(30))+rtrim(dbo.fun_yp_ypdw(nypdw)) as bz from yf_kcmx a,yp_kcsxx b where a.cjid=b.cjid and a.deptid=b.deptid and round(kcl/dwbl,3)<kcxx  and kcxx>0 and a.cjid=" + Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"], "0")) + " and a.deptid=" + InstanceForm.BCurrentDept.DeptId + " ";
                                DataTable tbsxx = InstanceForm.BDatabase.GetDataTable(ssql);
                                if (tbsxx.Rows.Count > 0)
                                    _Bz = _Bz + Convertor.IsNull(tbsxx.Rows[0][0], "") + "\n";
                            }

                            #endregion

                            //add by wangzhi
                            sumje += Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�ܽ��"], "0"));
                            //brxm = tbcf.Rows[i]["����"].ToString().Trim();
                            //end add   
                        }

                        if (selrow.Length != cfcount)
                        {
                            throw new Exception("��������,��̨���µ���������������ǰѡ��ҩ������");
                        }

                        #endregion
                    }
                    else
                    {
                        #region
                        DataRow[] rows_cfmx = tb.Select("��ҩ='��' and ypid<>''", "cfxh,���");
                        DataTable tbkcph = InstanceForm.BDatabase.GetDataTable(@"select ID kcid,yppch,CJID,YPPH,YPXQ,JHJ,KCL,0 
                            as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj,dbo.fun_yp_ypdw(zxdw) as kcdw from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and kcl>0 and bdelete = 0 ");


                        #region �����
                        if (!tb.Columns.Contains("YPPCH2"))
                        {
                            tb.Columns.Add(new DataColumn("YPPCH2", Type.GetType("System.String")));
                        }

                        if (!tb.Columns.Contains("YPPH2"))
                        {
                            tb.Columns.Add(new DataColumn("YPPH2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("YPXQ2"))
                        {
                            tb.Columns.Add(new DataColumn("YPXQ2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("KCID2"))
                        {
                            tb.Columns.Add(new DataColumn("KCID2", Type.GetType("System.String")));
                        }
                        if (!tb.Columns.Contains("JHJ2"))
                        {
                            tb.Columns.Add(new DataColumn("JHJ2", Type.GetType("System.Decimal")));
                        }
                        if (!tb.Columns.Contains("JHJE2"))
                        {
                            tb.Columns.Add(new DataColumn("JHJE2", Type.GetType("System.Decimal")));
                        }
                        if (!tb.Columns.Contains("KDSl"))
                        {
                            tb.Columns.Add(new DataColumn("KDSl", Type.GetType("System.Decimal")));//�ɵ�����
                        }
                        #endregion

                        DataTable tb_temp = tb.Clone();//��������ϸ
                        DataRow[] rows_sel = tb.Select("��ҩ='��' and ypid<>''", "cfxh,���");



                        decimal sumlsje = 0;//���۽��ϼ�
                        decimal sumpfje = 0;//�������ϼ�
                        decimal _sumlsje = 0;
                        decimal _sumpfje = 0;
                        for (int i = 0; i < rows_sel.Length; i++)
                        {
                            //decimal lsje = Convert.ToDecimal(rows_sel[i]["���"]);
                            //sumlsje += lsje;
                            //decimal pfje = Convert.ToDecimal(rows_sel[i]["�������"]);
                            //sumpfje += pfje;

                            decimal yl = Convert.ToDecimal(rows_sel[i]["����"]);
                            decimal js = Convert.ToDecimal(rows_sel[i]["����"]);
                            decimal lsj = Convert.ToDecimal(rows_sel[i]["����"]);
                            decimal pfj = Convert.ToDecimal(rows_sel[i]["������"]);
                            decimal lsje = Convert.ToDecimal(yl * js * lsj);//���۽��
                            decimal pfje = Convert.ToDecimal(yl * js * pfj);//�������
                            sumlsje += lsje;
                            sumpfje += pfje;

                            tb_temp.ImportRow(rows_sel[i]);
                        }
                        DataTable tb_pcmx = tb.Clone();
                        DataTable tb_pcmx_fs = tb.Clone();
                        DataTable tb_pcmx_zs_wfp = tb.Clone();

                        try
                        {
                            #region ��������

                            //��һ����������ϸ�ȵ���,��������������ϸ�����һ���������,����Ҳ�����棬��ȥ������Ŀ������
                            DataRow[] rows_fs = tb_temp.Select("��ҩ='��' and ypid<>'' and ypsl<0", "cfxh,���");
                            DataRow[] rows_zs;
                            #region
                            for (int i = 0; i < rows_fs.Length; i++)
                            {
                                int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);
                                DataRow row_fs = rows_fs[i];
                                decimal ypsl_fs = Convert.ToDecimal(row_fs["ypsl"]);//������������
                                rows_zs = tb_temp.Select("��ҩ='��' and ypid<>'' and cfmxid='" + row_fs["tyid"] + "'", "cfxh,���");
                                for (int j = 0; j < rows_zs.Length; j++)
                                {
                                    int dwbl_zs = Convert.ToInt32(rows_zs[j]["dwbl"]);
                                    if (dwbl_zs != dwbl_fs)
                                    {
                                        throw new Exception("��λ������������,��ҩ��ϸ�е�λ������ԭ��λ������һ��");
                                    }
                                    DataRow row_zs = rows_zs[j];
                                    decimal ypsl_zs = Convert.ToDecimal(row_zs["ypsl"]);
                                    if (ypsl_zs <= 0)
                                        continue;
                                    if (ypsl_fs == 0)
                                        break;
                                    decimal cksl = 0;//������ ����
                                    decimal temp = ypsl_fs + ypsl_zs;
                                    if (temp >= 0)//������ϸ���� ���� ������������
                                    {
                                        cksl = ypsl_fs;
                                        ypsl_fs = 0;
                                    }
                                    else//������ϸ����С�� ������������
                                    {
                                        cksl = ypsl_zs * (-1);
                                        ypsl_fs = ypsl_fs + ypsl_zs;
                                    }

                                    //����������Ϣ
                                    DataRow[] rows_kcph = new DataRow[] { };
                                    if (pcglfs == "0")//�Ƚ��ȳ�
                                        rows_kcph = tbkcph.Select("cjid=" + row_fs["ypid"].ToString() + "", "djsj asc");
                                    else//��Ч���ȳ�
                                        rows_kcph = tbkcph.Select("cjid=" + row_fs["ypid"].ToString() + "", "ypxq asc");
                                    if (rows_kcph.Length == 0)
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row_fs["cjid"].ToString() + " order by djsj desc ").Select();

                                    if (rows_kcph.Length <= 0)
                                        throw new Exception("����в����ڼ�¼��");

                                    //������ϸ����
                                    DataRow rowkcph = rows_kcph[0];
                                    DataRow newrow_fs = tb_temp.NewRow();
                                    newrow_fs = row_fs;
                                    newrow_fs["yppch2"] = rowkcph["yppch"];
                                    newrow_fs["ypph2"] = rowkcph["ypph"];
                                    newrow_fs["ypxq2"] = rowkcph["ypxq"];
                                    newrow_fs["kcid2"] = rowkcph["kcid"];
                                    decimal jhj_kc = Convert.ToDecimal(rowkcph["jhj"]);//������
                                    //int dwbl_kc = Convert.ToInt32(rowkcph["dwbl"]);
                                    decimal jhj = Convert.ToDecimal(jhj_kc / dwbl_fs);
                                    newrow_fs["jhj2"] = jhj;
                                    newrow_fs["ypsl"] = cksl;//����
                                    newrow_fs["jhje2"] = Convert.ToDecimal(cksl * jhj);//�������
                                    newrow_fs["kdsl"] = 0;//�ɵ�����
                                    tb_pcmx.ImportRow(newrow_fs);

                                    //������ϸ����
                                    DataRow newrow_zs = tb_temp.NewRow();
                                    newrow_zs = row_zs;
                                    newrow_zs["yppch2"] = rowkcph["yppch"];
                                    newrow_zs["ypph2"] = rowkcph["ypph"];
                                    newrow_zs["ypxq2"] = rowkcph["ypxq"];
                                    newrow_zs["kcid2"] = rowkcph["kcid"];
                                    newrow_zs["jhj2"] = jhj;
                                    newrow_zs["jhje2"] = Convert.ToDecimal(cksl * jhj * (-1));//�������
                                    newrow_zs["ypsl"] = Convert.ToDecimal(cksl * (-1));//����
                                    newrow_zs["kdsl"] = 0;//�ɵ�����
                                    tb_pcmx.ImportRow(newrow_zs);

                                    //decimal mmmmm = Convert.ToDecimal(row_zs["ypsl"]);
                                    //row_zs["ypsl"] = Convert.ToDecimal(row_zs["ypsl"]) + cksl;//�ı�����


                                    row_fs["ypsl"] = ypsl_fs;//�ı为��
                                    row_zs["ypsl"] = ypsl_zs + cksl;
                                }

                            }
                            #endregion
                            //InstanceForm.DebugView( tb_temp );
                            //�ڶ�����������������
                            //DataRow[] rows_mx = tb_temp.Select( "��ҩ='��' and ypid<>'' and ypsl>0" , "cfxh,���" ); //comment by wangzhi by 2014-07-11
                            DataRow[] rows_mx = tb_temp.Select("��ҩ='��' and ypid<>'' and ( ypsl>=0 or ypsl is null)", "cfxh,���");

                            int mm = rows_mx.Length;

                            #region
                            for (int i = 0; i < rows_mx.Length; i++)
                            {
                                #region ������
                                DataRow row = rows_mx[i];
                                DataRow[] rows_kcph;
                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "djsj asc,yppch asc ");
                                else
                                    rows_kcph = tbkcph.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "ypxq asc");

                                //��λ�����Ƚ�
                                if (rows_kcph.Length > 0)
                                {
                                    int dwbl_kc = Convert.ToInt32(rows_kcph[0]["dwbl"]);
                                    int dwbl_mx = Convert.ToInt32(row["dwbl"]);
                                    if (dwbl_kc != dwbl_mx)
                                    {
                                        throw new Exception("��λ���������仯,��ˢ�����ݺ����ԣ�");
                                    }
                                }

                                decimal sysl = Convert.ToDecimal(row["ypsl"]);//ʣ������

                                //�������Ϊ�㡣��û�п���ҩƷ���ر�����ָ���������ҺҩƷ 2014-07-11
                                if (sysl == 0 && rows_kcph.Length == 0)
                                {
                                    DataTable tbkcph_ex = InstanceForm.BDatabase.GetDataTable(@"select dbo.FUN_GETEMPTYGUID() kcid,'11111111111' yppch,CJID,'' as YPPH,'2014-07-11' as YPXQ, 0 JHJ,100 KCL,0 
                            as CKL,YPDW,1 DWBL,0 BDELETE,0 ykbdelete,djsj from vi_yp_ypcd where CJID=" + rows_mx[i]["ypid"] + "   ");
                                    rows_kcph = tbkcph_ex.Select(" kcl>0 and bdelete = 0 and cjid=" + row["ypid"].ToString() + "", "ypxq asc");
                                }

                                for (int j = 0; j < rows_kcph.Length; j++)//���ſ����
                                {
                                    DataRow row1 = rows_kcph[j];
                                    decimal cksl = 0;//���γ�����
                                    decimal kcl = Convert.ToDecimal(row1["kcl"]);//���ο����
                                    if (kcl == 0)
                                        continue;
                                    if (sysl < 0)  //if ( sysl == 0 )//wangzhi 2014-07-11
                                        break;
                                    if (kcl > sysl)//���������ʣ������
                                    {
                                        cksl = sysl;
                                        sysl = 0;
                                    }
                                    else//�����С��ʣ������
                                    {
                                        cksl = kcl;
                                        sysl = sysl - kcl;
                                    }
                                    //�������������Ϣ
                                    DataRow newrow = tb_temp.NewRow();
                                    newrow = row;
                                    newrow["yppch2"] = row1["yppch"];
                                    newrow["ypph2"] = row1["ypph"];
                                    newrow["ypxq2"] = row1["ypxq"];
                                    newrow["kcid2"] = row1["kcid"];
                                    decimal jhj = Math.Round(Convert.ToDecimal(row1["jhj"]) / Convert.ToInt32(row1["dwbl"]), 4);
                                    newrow["jhj2"] = jhj;
                                    newrow["jhje2"] = Math.Round(jhj * cksl, 3);
                                    newrow["ypsl"] = cksl;
                                    //decimal pfj = Convert.ToDecimal(row["������"]);
                                    //newrow["������"] = pfj;
                                    //newrow["�������"] = Convert.ToDecimal(pfj * cksl);
                                    newrow["KCID2"] = row1["kcid"];
                                    newrow["KDSL"] = 0;//�ɵ�����
                                    tb_pcmx.ImportRow(newrow);
                                    row1["kcl"] = kcl - cksl;//�����ο�����
                                    if (sysl == 0)//���ʣ����������0 ������ǰ���ο��ѭ��
                                    {
                                        break;
                                    }
                                }
                                #endregion

                                #region δ��������� ���ʣ��������Ȼ>0
                                if (sysl > 0)
                                {
                                    row["ypsl"] = sysl;
                                    if (Convert.ToDecimal(row["ypsl"]) > 0)
                                    {
                                        DataRow row_zs = tb_temp.NewRow();
                                        row_zs = row;
                                        tb_pcmx_zs_wfp.ImportRow(row);
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            //������������ʣ�µĸ�����ϸ �õ�һ��������ϸ   
                            rows_mx = tb_temp.Select("��ҩ='��' and ypid<>'' and ypsl<0", "cfxh,���");
                            for (int i = 0; i < rows_mx.Length; i++)
                            {
                                DataRow row = rows_mx[i];

                                #region ���ηֽ�
                                decimal ypsl = Convert.ToDecimal(row["ypsl"]);
                                DataRow[] rows_kcph = new DataRow[] { };

                                if (pcglfs == "0")
                                    rows_kcph = tbkcph.Select("cjid=" + row["ypid"].ToString() + "", "djsj asc");
                                else
                                    rows_kcph = tbkcph.Select("cjid=" + row["ypid"].ToString() + "", "ypxq asc");
                                if (rows_kcph.Length == 0)
                                {
                                    if (pcglfs == "0")
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by djsj desc,yppch desc ").Select();
                                    }
                                    else
                                    {
                                        rows_kcph = InstanceForm.BDatabase.GetDataTable("select top 1 ID kcid, yppch, CJID,YPPH,YPXQ,JHJ,KCL,0 as CKL,ZXDW,DWBL,BDELETE,ykbdelete,djsj from yf_kcph where deptid=" + InstanceForm.BCurrentDept.DeptId + " and cjid=" + row["cjid"].ToString() + " order by ypxq desc ").Select();
                                    }
                                }
                                if (rows_kcph.Length < 0)
                                    throw new Exception("�Ҳ���������μ�¼��");

                                //�������������Ϣ  
                                DataRow row1 = rows_kcph[0];
                                DataRow newrow = tb_temp.NewRow();
                                newrow = row;
                                newrow["yppch2"] = row1["yppch"];
                                newrow["ypph2"] = row1["ypph"];
                                newrow["ypxq2"] = row1["ypxq"];
                                newrow["kcid2"] = row1["kcid"];
                                decimal jhj_kc = Convert.ToDecimal(row1["jhj"]);
                                decimal dwbl_fs = Convert.ToInt32(row1["dwbl"]);
                                decimal jhj = Convert.ToDecimal(jhj_kc / dwbl_fs);//����
                                newrow["jhj2"] = jhj;
                                newrow["jhje2"] = Math.Round(jhj * ypsl, 3);
                                newrow["ypsl"] = ypsl;
                                decimal pfj = Convert.ToDecimal(row["������"]);
                                //newrow["������"] = pfj;
                                //newrow["�������"] = Math.Round(pfj * ypsl, 2);
                                newrow["KDSL"] = ypsl * (-1);//�ɵ�����
                                tb_pcmx_fs.ImportRow(newrow);
                                //�����ο�����
                                row1["kcl"] = Convert.ToDecimal(row1["kcl"]) - ypsl;

                                #endregion
                            }

                            //���Ĳ�������δ��δ�����������ȥ�Ѿ�����ĸ�����ȥ����  
                            foreach (DataRow row_zs in tb_pcmx_zs_wfp.Rows)
                            {
                                #region ���ηֽ�
                                decimal sysl = Convert.ToDecimal(row_zs["ypsl"]);
                                int dwbl_zs = Convert.ToInt32(row_zs["dwbl"]);

                                rows_fs = tb_pcmx_fs.Select(" kdsl>0 and ypid=" + row_zs["ypid"].ToString());
                                for (int i = 0; i < rows_fs.Length; i++)
                                {

                                    decimal cks = 0;
                                    DataRow row_fs = rows_fs[i];
                                    int dwbl_fs = Convert.ToInt32(rows_fs[i]["dwbl"]);

                                    if (dwbl_fs != dwbl_zs)
                                    {
                                        throw new Exception("��λ���������仯����ˢ�����ݺ����ԣ�");
                                    }

                                    decimal kdsl = Convert.ToDecimal(row_fs["kdsl"]);
                                    if (kdsl == 0)
                                        continue;

                                    if (kdsl >= sysl)
                                    {
                                        kdsl = kdsl - sysl;
                                        cks = sysl;
                                        sysl = 0;
                                    }
                                    else
                                    {
                                        cks = kdsl;
                                        kdsl = 0;
                                        sysl -= cks;
                                    }
                                    row_fs["kdsl"] = kdsl;

                                    DataRow newrow = tb_temp.NewRow();
                                    newrow = row_zs;
                                    newrow["yppch2"] = row_fs["yppch2"];//���κ�
                                    newrow["ypph2"] = row_fs["ypph2"];//����
                                    newrow["ypxq2"] = row_fs["ypxq2"];//Ч��
                                    newrow["kcid2"] = row_fs["kcid2"];//kcid
                                    newrow["jhj2"] = row_fs["jhj2"];
                                    newrow["jhje2"] = Convert.ToDecimal(Convert.ToDecimal(row_fs["jhj2"]) * cks);
                                    newrow["ypsl"] = cks;

                                    tb_pcmx.ImportRow(newrow);
                                    row_zs["ypsl"] = sysl;

                                    if (sysl == 0)
                                    {
                                        break;
                                    }
                                    if (kdsl == 0)
                                    {
                                        continue;
                                    }
                                }
                                #endregion
                            }
                            foreach (DataRow row in tb_pcmx_fs.Rows)
                            {
                                tb_pcmx.ImportRow(row);
                            }
                            //���岽���������δ������������򱨴�
                            DataRow[] rows_zs_wfp = tb_pcmx_zs_wfp.Select("ypsl>0");
                            if (rows_zs_wfp.Length > 0)
                            {
                                throw new Exception(string.Format("{0} {1} ���ÿ�������㣡", rows_zs_wfp[0]["Ʒ��"], rows_zs_wfp[0]["���"]));
                            }
                            #endregion

                            //string str = "������ϸ��\n";
                            //foreach (DataRow row in tb_pcmx.Rows)
                            //{
                            //    str += row["Ʒ��"].ToString().Trim() + " " + row["���"].ToString().Trim() + " " + row["ypsl"].ToString().Trim() + " " + row["yppch2"].ToString() + row["jhj2"].ToString() + ">>\n";
                            //}
                            //MessageBox.Show(str);
                            //return;

                        }
                        catch (Exception err_pc)
                        {
                            MessageBox.Show("����������ʱ��������" + err_pc.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            butfy.Enabled = true;
                            return;
                        }
                        //MessageBox.Show("ok");
                        //butfy.Enabled = true;
                        //return;


                        //����������ϸ

                        //string[] GroupbyField ={"jssjh","��Ʊ��","�ܽ��","���ʽ��","�Żݽ��","�Ը����","����","cfxh",
                        //                         "patid","�����","����","ysdm","ksdm","�շ�����","sfczy","��ҩ����"};
                        //string[] ComputeField ={ "ypsl" };
                        //string[] CField ={ "sum" };
                        //DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);

                        InstanceForm.DebugView(tb_pcmx);

                        InstanceForm.BDatabase.BeginTransaction();

                        #region ����yf_fy yf_fymx
                        for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                        {
                            //DataRow[] rowssss = tbcf.Select("");

                            //int cflx = 0;//��������  ����������ι��� ������Ϊ03(��ҩ)�����⴦��
                            string strFilter = string.Format("��Ʊ��='{0}' and ypid<>'' and �����='{1}' AND CFXH='{2}'", tbcf.Rows[i]["��Ʊ��"], tbcf.Rows[i]["�����"], tbcf.Rows[i]["CFXH"]);
                            //InstanceForm.DebugView( tb_pcmx );
                            DataRow[] rows = tb_pcmx.Select(strFilter, "���");

                            int count = rows.Length;
                            if (count == 0)
                                throw new Exception("������ϸʧ�ܣ�����:" + strFilter);


                            #region ���뷢ҩ��ͷ
                            MZYF.SaveFy(rows[0]["cflx"].ToString().Trim(),
                              Convert.ToDecimal(tbcf.Rows[i]["jssjh"]),
                              Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["��Ʊ��"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�ܽ��"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���ʽ��"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Żݽ��"], "0")),
                              Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Ը����"], "0")),
                              Convert.ToInt32(Convertor.IsNull(tb_pcmx.Rows[0]["����"], "0")),
                              new Guid(tbcf.Rows[i]["cfxh"].ToString()),
                              new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString())),
                              tbcf.Rows[i]["�����"].ToString(),
                              tbcf.Rows[i]["����"].ToString(),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ysdm"], "0")),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ksdm"], "0")),
                              tbcf.Rows[i]["�շ�����"].ToString(),
                              Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["sfczy"], "0")),
                              sDate,
                              InstanceForm.BCurrentUser.EmployeeId,
                            //  Convert.ToInt32(cmbpyr.SelectedValue),
                            Convert.ToInt32(GetKF_NY_HH_PYR(tbcf.Rows[i]["cfxh"].ToString())),//�˴����и��Ĵӿ췢���õ�������Ӧ����ҩԱ     Add by hyd 2017-11-30                        
                              Convertor.IsNull(tbcf.Rows[i]["��ҩ����"], "0"),
                              _Fyckh,
                              InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, 0,
                              _pronamefy, out fyid, out err_code, out err_text,
                              InstanceForm._menuTag.Jgbm,
                              InstanceForm.BDatabase, string.Empty);
                            if (err_code != 0 || fyid == Guid.Empty)
                            {
                                throw new System.Exception(err_text);
                            }
                            this.butfy.Tag = fyid.ToString();

                            
                            string updateMzcfSql = "update MZ_CFB set PYR = {0},PYRXM = '{1}',PYRQ = '{2}',hxpyr = 1 where cfid = '" + tbcf.Rows[i]["cfxh"].ToString() + "'";
                            string updateYffySql = "update yf_FY set PYR = {0},pyrq = '{1}' where ID = '" + fyid.ToString() + "' ";
                            updatePyrInfo.Add(updateMzcfSql, updateYffySql);
                            #endregion

                            #region  �ϵĲ��뷢ҩ��ϸ ������ҩ ��������������� �����������⴦��
                            //decimal sumjhje = 0;//�ܽ������
                            //DataRow[] rows_pc = tb_pcmx.Select("cfxh='"+tbcf.Rows[i]["cfxh"]+"'");
                            ////DataRow[] rows_pc = tb.Select("��Ʊ��='" + tbcf.Rows[i]["��Ʊ��"].ToString() + "' and ypid<>'' and �����='" + tbcf.Rows[i]["�����"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "���");
                            //for (int m = 0; m < rows_pc.Length; m++)
                            //{
                            //    DataRow rowpc = rows_pc[m];
                            //    string UserEat = rowpc["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rowpc["����"]).ToString() + rowpc["������λ"].ToString().Trim() + "/ÿ��";
                            //    string yf = Convert.ToString(rowpc["�÷�"]) + "  " + rowpc["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
                            //    string zt = Convert.ToString(rowpc["����"]);

                            //    int dwbl = Convert.ToInt32(rowpc["dwbl"]) ;     //���dwbl
                            //    decimal ypsl = Convert.ToDecimal(rowpc["ypsl"]);
                            //    decimal jhj = Convert.ToDecimal(rowpc["jhj2"]); //����
                            //    decimal jhje = Convert.ToDecimal(jhj * ypsl);   //�������
                            //    string ypph = rowpc["ypph2"].ToString();
                            //    string ypxq = rowpc["ypxq2"].ToString();
                            //    string yppch = rowpc["yppch2"].ToString();
                            //    Guid kcid = new Guid(rowpc["kcid2"].ToString());

                            //    int dwbl_cfmx = Convert.ToInt32(rowpc["ydwbl"]);//������ϸdwbl
                            //    int js_cfmx = Convert.ToInt32(rowpc["����"]);
                            //    //decimal ypsl_cfmx =Convert.ToDecimal( ypsl * dwbl / dwbl_cfmx);//������ϸ������
                            //    //Modify by dyw 2014/6/30
                            //    decimal ypsl_cfmx = Convert.ToDecimal(ypsl * dwbl_cfmx/ dwbl);//������ϸ������ 
                            //    decimal yl_cfmx = Convert.ToDecimal( ypsl_cfmx / js_cfmx);//������ϸ������
                            //    decimal jhj_cfmx =Convert.ToDecimal( jhj * dwbl_cfmx /dwbl);//������ϸ�н��ۣ�
                            //    decimal jhje_cfmx = jhje;

                            //    decimal pfj_cfmx = Convert.ToDecimal(rowpc["������"]);//������ϸ������
                            //    decimal pfje_cfmx = Convert.ToDecimal(pfj_cfmx*ypsl_cfmx);//������ϸ�������

                            //    decimal lsj_cfmx = Convert.ToDecimal(rowpc["����"]);//������ϸ���ۼ�
                            //    decimal lsje_cfmx = Convert.ToDecimal(lsj_cfmx*ypsl_cfmx);//������ϸ���۽��

                            //    _sumlsje += lsje_cfmx;
                            //    _sumpfje += pfje_cfmx;

                            //    #region ���뷢ҩ��ϸ
                            //    MZYF.SaveFymx(fyid,
                            //                    Convert.ToInt64(Convertor.IsNull(rowpc["��Ʊ��"], "0")),
                            //                    new Guid(Convertor.IsNull(rowpc["cfxh"], Guid.Empty.ToString())),
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["ypid"], "0")),
                            //                    rowpc["����"].ToString(),
                            //                    rowpc["Ʒ��"].ToString(),
                            //                    rowpc["��Ʒ��"].ToString(),
                            //                    rowpc["���"].ToString(),
                            //                    rowpc["����"].ToString(),
                            //                    rowpc["��λ"].ToString(),
                            //                    dwbl_cfmx,                  //��λ����
                            //                    yl_cfmx,                    //����
                            //                    js_cfmx,                    //����
                            //                    pfj_cfmx,                   //������
                            //                    pfje_cfmx,                  //�������
                            //                    lsj_cfmx,                   //���ۼ�
                            //                    lsje_cfmx,                  //���۽��
                            //                    0,
                            //                    0,
                            //                    InstanceForm.BCurrentDept.DeptId,
                            //                    new Guid(Convertor.IsNull(rowpc["tyid"],Guid.Empty.ToString())),
                            //                    ypph,
                            //                    Guid.Empty,
                            //                    new Guid(Convertor.IsNull(rowpc["cfmxid"], Guid.Empty.ToString())),
                            //                    rowpc["Ƥ��"].ToString(),
                            //                    yf.Trim(),                                                    //�÷�
                            //                    zt.Trim(),                                                    //����
                            //                    Convertor.IsNull(rowpc["�÷�"], ""),                          //�÷�
                            //                    Convertor.IsNull(rowpc["Ƶ��"], ""),                          //Ƶ��
                            //                    Convertor.IsNull(rowpc["����"], ""),                          //����
                            //                    Convertor.IsNull(rowpc["������λ"], ""),                      //������λ
                            //                    Convert.ToDecimal(Convertor.IsNull(rowpc["����"], "0")),      //����
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["���־"], "0")),      //���־
                            //                    Convert.ToInt32(Convertor.IsNull(rowpc["�������"], "0")),    //�����־
                            //                    _pronamefymx,                                                 //�洢������
                            //                    out fymxid,                                                   //fymxid
                            //                    out err_code,
                            //                    out err_text,
                            //                    jhj_cfmx,           //����
                            //                    jhje_cfmx,          //�������
                            //                    ypxq,               //Ч��       
                            //                    yppch,              //���κ�
                            //                    kcid,               //kcid
                            //                    InstanceForm.BDatabase,
                            //                    bpcgl);

                            //        if (err_code != 0)
                            //        {
                            //            throw new System.Exception(err_text);
                            //        }
                            //    #endregion
                            //    sumjhje += jhje;     //�������
                            //}

                            #endregion

                            #region ���뷢ҩ��ϸ ������ҩ ��������������� �����������⴦��
                            decimal sumjhje = 0;//�ܽ������
                            DataRow[] rows_pc = tb_pcmx.Select("cfxh='" + tbcf.Rows[i]["cfxh"] + "'");
                            //DataRow[] rows_pc = tb.Select("��Ʊ��='" + tbcf.Rows[i]["��Ʊ��"].ToString() + "' and ypid<>'' and �����='" + tbcf.Rows[i]["�����"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "���");
                            for (int m = 0; m < rows_pc.Length; m++)
                            {
                                DataRow rowpc = rows_pc[m];
                                string UserEat = rowpc["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rowpc["����"]).ToString() + rowpc["������λ"].ToString().Trim() + "/ÿ��";
                                string yf = Convert.ToString(rowpc["�÷�"]) + "  " + rowpc["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
                                string zt = Convert.ToString(rowpc["����"]);
                                int dwbl = Convert.ToInt32(rowpc["dwbl"]);     //���dwbl
                                decimal ypsl = Convert.ToDecimal(Convertor.IsNull(rowpc["ypsl"], "0"));//����浥λ�������
                                decimal jhj = Convert.ToDecimal(rowpc["jhj2"]); //��浥λ����
                                decimal jhje = Math.Round(Convert.ToDecimal(jhj * ypsl), 4);   //�������=��浥λ����*��浥λ����
                                string ypph = rowpc["ypph2"].ToString();
                                string ypxq = rowpc["ypxq2"].ToString();
                                string yppch = rowpc["yppch2"].ToString();
                                Guid kcid = new Guid(rowpc["kcid2"].ToString());
                                int dwbl_cfmx = Convert.ToInt32(rowpc["ydwbl"]);//������ϸdwbl
                                int js_cfmx = Convert.ToInt32(rowpc["����"]);
                                decimal ypsl_cfmx = Convert.ToDecimal(ypsl * dwbl_cfmx / dwbl);//������ϸ���� 

                                //-- comment by wangzhi
                                //decimal yl_cfmx = Convert.ToDecimal( ypsl_cfmx / js_cfmx );
                                //decimal jhj_cfmx = Convert.ToDecimal( jhj * dwbl / dwbl_cfmx );//������ϸ�н���  �����Ľ����۷�����ϸ�Ľ�����
                                //decimal pfj_cfmx = Convert.ToDecimal( rowpc["������"] );//������ϸ������ (����ʱ��������)
                                //decimal pfje_cfmx = Math.Round( Convert.ToDecimal( pfj_cfmx * yl_cfmx * js_cfmx ) , 4 );//������ϸ�������=������ϸ������*������ϸ����*������ϸ����
                                //decimal lsj_cfmx = Convert.ToDecimal( rowpc["����"] );//������ϸ���ۼ�
                                //decimal lsje_cfmx = Math.Round( Convert.ToDecimal( lsj_cfmx * yl_cfmx * js_cfmx ) , 4 );//������ϸ���۽��=������ϸ���ۼ�*������ϸ����*������ϸ����
                                //-- end comment

                                //------------------modify by wangzhi at 2014-08-01------------------                            
                                decimal yl_cfmx = decimal.Round(ypsl_cfmx / js_cfmx, 6);
                                string cfmxdw = rowpc["��λ"].ToString();  //�����еĵ�λ��ע�⣺�����Ǵ�λ��Ҳ������С��λ
                                string ss = kcid.ToString();
                                InstanceForm.DebugView(tbkcph);
                                string kcdw = cfmxdw;
                                if (kcid != Guid.Empty)
                                    kcdw = tbkcph.Select(string.Format("kcid='{0}'", kcid))[0]["kcdw"].ToString().Trim();
                                string fydw = cfmxdw;//��ҩ��λ��Ĭ�ϴ����еĵ�λ
                                decimal fyjhj = jhj; //��ҩ�Ľ���
                                decimal fypfj = 0;
                                decimal fylsj = 0;
                                int fy_dwbl = dwbl; //д��ҩ��ĵ�λ������Ĭ�Ͽ�浥λ����
                                yl_cfmx = ypsl; //ǿ������Ϊ������ypsl�����е���ʵ������(����������Ѿ���ǰ�����β��ʱ����浥λ�����,��λΪ��浥λ)
                                js_cfmx = 1;    //ǿ�Ƽ���Ϊ 1                            
                                fydw = kcdw;   //д��ҩ��ĵ�λ��Ĭ�Ͽ�浥λ

                                decimal jhj_cfmx = Convert.ToDecimal(jhj * dwbl / dwbl_cfmx);//������ϸ�н���  �����Ľ����۷�����ϸ�Ľ�����
                                fyjhj = jhj;
                                decimal jhje_cfmx = jhje;

                                //�����ۼ����
                                decimal pfj_cfmx = Convert.ToDecimal(rowpc["������"]);//������ϸ������ (����ʱ��������)
                                decimal pfje_cfmx = Math.Round(Convert.ToDecimal(pfj_cfmx * yl_cfmx * js_cfmx), 4);//������ϸ�������=������ϸ������*������ϸ����*������ϸ����
                                //�������ʱ�ĵ�λ�Ϳ����С��λ��һ�£��򽫼۸�ͽ��תΪ�Ϳ�浥λ����һ��
                                pfj_cfmx = Math.Round(Convert.ToDecimal(rowpc["������"]) * dwbl_cfmx / dwbl, 4);
                                pfje_cfmx = Math.Round(Convert.ToDecimal(pfj_cfmx * yl_cfmx * js_cfmx), 4);

                                //���ۼۼ����
                                decimal lsj_cfmx = Convert.ToDecimal(rowpc["����"]);//������ϸ���ۼ�
                                decimal lsje_cfmx = Math.Round(Convert.ToDecimal(lsj_cfmx * yl_cfmx * js_cfmx), 4);//������ϸ���۽��=������ϸ���ۼ�*������ϸ����*������ϸ����
                                lsj_cfmx = Math.Round(Convert.ToDecimal(rowpc["����"]) * dwbl_cfmx / dwbl, 4);
                                lsje_cfmx = Math.Round(Convert.ToDecimal(lsj_cfmx * yl_cfmx * js_cfmx), 4);
                                //------------------end modify by wangzhi at 2014-08-01------------------

                                //lsje_cfmx = Convert.ToDecimal( Convertor.IsNull( rowpc["���"] , "0" ) );
                                _sumlsje += lsje_cfmx;
                                _sumpfje += pfje_cfmx;
                                #region ���뷢ҩ��ϸ
                                MZYF.SaveFymx(fyid,
                                                Convert.ToInt64(Convertor.IsNull(rowpc["��Ʊ��"], "0")),
                                                new Guid(Convertor.IsNull(rowpc["cfxh"], Guid.Empty.ToString())),
                                                Convert.ToInt32(Convertor.IsNull(rowpc["ypid"], "0")),
                                                rowpc["����"].ToString(),
                                                rowpc["Ʒ��"].ToString(),
                                                rowpc["��Ʒ��"].ToString(),
                                                rowpc["���"].ToString(),
                                                rowpc["����"].ToString(),
                                                fydw,//rowpc["��λ"].ToString() ,
                                                fy_dwbl, // dwbl_cfmx ,                  //��λ����
                                                yl_cfmx,                    //����
                                                js_cfmx,                    //����
                                                pfj_cfmx,                   //������
                                                pfje_cfmx,                  //�������
                                                lsj_cfmx,                   //���ۼ�
                                                lsje_cfmx,                  //���۽��
                                                0,
                                                0,
                                                InstanceForm.BCurrentDept.DeptId,
                                                new Guid(Convertor.IsNull(rowpc["tyid"], Guid.Empty.ToString())),
                                                ypph,
                                                Guid.Empty,
                                                new Guid(Convertor.IsNull(rowpc["cfmxid"], Guid.Empty.ToString())),
                                                rowpc["Ƥ��"].ToString(),
                                                yf.Trim(),                                                    //�÷�
                                                zt.Trim(),                                                    //����
                                                Convertor.IsNull(rowpc["�÷�"], ""),                          //�÷�
                                                Convertor.IsNull(rowpc["Ƶ��"], ""),                          //Ƶ��
                                                Convertor.IsNull(rowpc["����"], ""),                          //����
                                                Convertor.IsNull(rowpc["������λ"], ""),                      //������λ
                                                Convert.ToDecimal(Convertor.IsNull(rowpc["����"], "0")),      //����
                                                Convert.ToInt32(Convertor.IsNull(rowpc["���־"], "0")),      //���־
                                                Convert.ToInt32(Convertor.IsNull(rowpc["�������"], "0")),    //�����־
                                                _pronamefymx,                                                 //�洢������
                                                out fymxid,                                                   //fymxid
                                                out err_code,
                                                out err_text,
                                                fyjhj, //jhj_cfmx ,           //����
                                                jhje_cfmx,          //�������
                                                ypxq,               //Ч��       
                                                yppch,              //���κ�
                                                kcid,               //kcid
                                                InstanceForm.BDatabase,
                                                bpcgl);

                                if (err_code != 0)
                                {
                                    throw new System.Exception(err_text);
                                }
                                #endregion
                                sumjhje += jhje;     //�������
                            }
                            #endregion


                            #region ���·�ҩͷ���еĽ������
                            string ssql = string.Format(" update yf_fy set jhje={0} where id='{1}'", sumjhje, fyid);
                            if (InstanceForm.BDatabase.DoCommand(ssql) <= 0)
                            {
                                throw new Exception("���½������ʧ��");
                            }
                            #endregion

                        }
                        #endregion

                        #region �����֤
                        //if ( Math.Abs( sumlsje - _sumlsje ) > Convert.ToDecimal( 0.05 ) )
                        //{
                        //    throw new Exception( string.Format( "��������,������ϸ�н��ϼƣ�{0},��ҩ��ϸ�н��ϼ�{1}" , sumlsje , _sumlsje ) );
                        //}
                        //if ( Math.Abs( sumpfje - _sumpfje ) > Convert.ToDecimal( 0.05 ) )
                        //{
                        //    throw new Exception( string.Format( "������������,������ϸ���������ϼƣ�{0},��ҩ��ϸ���������ϼ�{1}" , sumpfje , _sumpfje ) );
                        //}
                        #endregion

                        if (err_code != 0)
                        {
                            throw new Exception(string.Format("��ʾ��{0}", err_text));
                        }
                        #endregion
                    }

                    //���鴦��
                    DataTable tbsel_hj = tb.Clone();
                    for (int w = 0; w <= selrow.Length - 1; w++)
                        tbsel_hj.ImportRow(selrow[w]);
                    string[] GroupbyField_hj ={ "FPID" };
                    string[] ComputeField_hj ={ "���" };
                    string[] CField_hj ={ "sum" };
                    DataTable tbcf_hj = FunBase.GroupbyDataTable(tbsel_hj, GroupbyField_hj, ComputeField_hj, CField_hj, null);
                    for (int i = 0; i <= tbcf_hj.Rows.Count - 1; i++)
                    {
                        string ssql = "update yf_fyjh set bfybz=1,FYRQ='" + sDate + "' where fpid='" + tbcf_hj.Rows[i]["fpid"].ToString() + "'";
                        InstanceForm.BDatabase.DoCommand(ssql);
                    }

                    //�ύ����
                    InstanceForm.BDatabase.CommitTransaction();

                    ////Add by zhujh 2017-05-27 ��ʱ���ֹͣ
                    //logger.Stop();


                    ////Add by zhujh 2017-05-27 ������ʱ���
                    //ExecTimeLogger logger2 = ExecTimeLogger.Run("ҩ����ҩ�췢");

                    //�˴�ֻ�б�Ժ����Ժ���ֿ��ҽ������� �˴����ɲ����� ��Ժ�췢��ҩ
                    if (rdo1.Checked && InstanceForm.BCurrentDept.DeptId == 207)
                    {
                        //�ж��Ƿ�ʹ����ͬ�Ŀ췢�ӿڷ�ҩ
                        if (str_HH_Flag.Equals("1"))
                        {
                            #region �������1 ���ʾ��Ժʹ����Ժ��ͬ�Ŀ췢�ӿ�
                            if (strFyKFCkFlag == "1")
                            {
                                string retValue_HH = "";
                                retValue_HH = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);
                                if (Convert.ToInt32(retValue_HH) == 1)
                                {
                                    // MessageBox.Show("ҩƷ�췢��ҩ�ɹ���");
                                }
                                else
                                {
                                    MessageBox.Show("ҩƷ�췢��ҩʧ�ܣ�");
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region ����Ժʹ��ԭ�����Ͽ췢�ӿڣ��˴�Ϊ�˼��ݱ���ԭ���Ĳ���
                            string pyrInfo = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);

                            if (!string.IsNullOrEmpty(pyrInfo) && pyrInfo.Contains(",") && updatePyrInfo.Count > 0)
                            {
                                string[] pyrData = pyrInfo.Split(new string[] { "," }, StringSplitOptions.None);
                                if (pyrData != null && pyrData.Length > 2)
                                {
                                    string sql = string.Empty;
                                    foreach (KeyValuePair<string, string> tmp in updatePyrInfo)
                                    {
                                        if (!string.IsNullOrEmpty(pyrData[0]) && !string.IsNullOrEmpty(pyrData[1]) && !string.IsNullOrEmpty(pyrData[2]))
                                        {
                                            sql = string.Format(tmp.Key, pyrData[0], pyrData[1], pyrData[2]);
                                            InstanceForm.BDatabase.DoCommand(sql);
                                        }

                                        if (!string.IsNullOrEmpty(pyrData[0]) && !string.IsNullOrEmpty(pyrData[2]))
                                        {
                                            sql = string.Format(tmp.Value, pyrData[0], pyrData[2]);
                                            InstanceForm.BDatabase.DoCommand(sql);
                                        }
                                    }
                                }
                            }
                            #endregion 
                        }
                    }


                    //��Ժ�췢��ҩ
                    #region ��Ժ�췢��ҩ
                    string retValue = "";
                    if (rdo1.Checked && InstanceForm.BCurrentDept.DeptId == 424)
                    {
                        if (strFyKFCkFlag == "1")
                        {
                            retValue = EndClinicInfo(tb, brxm, brxxid, str_HH_Flag);
                            if (Convert.ToInt32(retValue) == 1)
                            {
                                // MessageBox.Show("ҩƷ�췢��ҩ�ɹ���");
                            }
                            else
                            {
                                MessageBox.Show("ҩƷ�췢��ҩʧ�ܣ�");
                            }
                        }
                    }
                    #endregion 

                    #region ԭ���ķ���û���õ���ʱ����
                    /* Modify By Zhujh 2017-02-17 ����
                    #region ������   20110307
                    //�������Ժ�к�
                    if (this._call is ts_call_whzxyymz)
                    {
                        try
                        {
                            DataRow[] selrowX = tb.Select("��ҩ='��' and ypid<>''");
                            DataTable tbselX = tb.Clone();
                            for (int w = 0; w <= selrowX.Length - 1; w++)
                                tbselX.ImportRow(selrowX[w]);

                            string[] GroupbyFieldX ={ "����" };
                            string[] ComputeFieldX ={ "���" };
                            string[] CFieldX ={ "sum" };
                            DataTable tbcfX = FunBase.GroupbyDataTable(tbselX, GroupbyFieldX, ComputeFieldX, CFieldX, null);
                            if (tbcfX.Rows.Count == 1)
                            {

                                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                                for (int i = 0; i <= selrow.Length - 1; i++)
                                {
                                    cfmx[i].PM = Convertor.IsNull(selrow[i]["Ʒ��"], "");
                                    cfmx[i].GG = Convertor.IsNull(selrow[i]["���"], "");
                                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                                    cfmx[i].DW = Convertor.IsNull(selrow[i]["��λ"], "0");
                                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["���"], "0"));
                                    cfmx[i].fyck = _Fyckmc;
                                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["����"], "");
                                    cfmx[i].fph = Convertor.IsNull(selrow[i]["��Ʊ��"], "");
                                }
                                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                                if (bqybjq == "true" && (_menuTag.Function_Name == "Fun_ts_yf_mzfy" || _menuTag.Function_Name.Trim() == "Fun_ts_yf_mzfy_YFFY"))
                                {
                                    Caller call = new Caller(brxm, sumje, cfmx, this._call);
                                    thCall = new Thread(new ThreadStart(call.call));
                                    call.Thread = thCall;
                                    thCall.Start();
                                }
                            }
                        }
                        catch (System.Exception err)
                        {
                        }
                    }
                    #endregion
                    */
                    #endregion 

                    //Add by zhujh 2017-05-27 ��ʱ���ֹͣ
                    //logger2.Stop();

                    MessageBox.Show("��ҩ�ɹ���\n\n" + _Bz, "��ҩ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CallNumber(2); //���ҩ���к���ʾ��

                    SetDefaultFocuse();
                    this.butfy.Enabled = true;
                    try
                    {
                        DataRow[] rows_ref = null;
                        DataView dv = (DataView)dataGridView1.DataSource;
                        if (dv != null)
                        {
                            DataTable tbref = dv.Table;
                            if (cfg8027 == "1")
                                rows_ref = tbref.Select("��Ʊ��='" + tbcf.Rows[0]["��Ʊ��"].ToString() + "' and ����='" + tbcf.Rows[0]["����"].ToString() + "'");
                            if (cfg8027 == "2")
                                rows_ref = tbref.Select("����='" + tbcf.Rows[0]["����"].ToString() + "'");
                            if (rows_ref != null)
                            {
                                if (rows_ref.Length > 0)
                                    tbref.Rows.Remove(rows_ref[0]);
                            }
                            if (cfg8027 != "0" && tbref.Rows.Count == 0)
                                button_ref_Click(sender, e);
                        }

                        if (_textBox != null)
                        {
                            _textBox.Focus();
                            _textBox.SelectAll();
                        }
                        else
                        {
                            txtmzh.Focus();
                            txtmzh.SelectAll();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("111:" + error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (InventoryNotEnoughException exception)
                {
                    DataTable dt = (DataTable)exception.Data;
                    string message = "";
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                        message = message + dt.Rows[i]["YP"].ToString() + "\r\n";
                    message = message + dt.Rows[dt.Rows.Count - 1]["YP"].ToString();
                    message = string.Format("����ҩƷ\r\n{0}\r\n�ڵ�ǰ�ⷿû�п�棬���ܷ�ҩ", message);
                    this.butfy.Enabled = true;
                    MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (System.Exception err)
                {
                    this.butfy.Enabled = true;
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show("222:" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                    SetDefaultFocuse();
                    //Add by Zhujh 2017-05-10 ������
                    yongtai.PlzOpinion();
                }

                //�˴����ӵ��ӽ������¼���¼
                Add_DJJKKXX_ToEventLogMZ(str_PATID,str_GHXXID);

                //��ӡ����
                try
                {
                    for (int i = 0; i <= tb.Rows.Count - 1; i++)
                    {
                        if (tb.Rows[i]["��ҩ"].ToString().Trim() == "��")
                            tb.Rows[i]["��ҩ"] = "��";
                    }

                    //��ӡ���������
                    if (chkprint.Checked == true)
                        this.butprint_Click(sender, e);
                }
                catch (System.Exception err)
                {
                    MessageBox.Show("��ӡ����ʱ��������" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string bqypjq = ApiFunction.GetIniString("������", "����������", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string pjqxh = ApiFunction.GetIniString("������", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqypjq == "true")
                {
                    ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
                    string perr_text = "";
                    int perr_code = 0;
                    ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
                    if (perr_code != 0)
                        throw new Exception("���������ó���!" + perr_text);
                }


            }

        }

        /// <summary>
        /// ��ʾҩƷ��ϸ�Ķ���
        /// </summary>
        private class Caller
        {
            string _name;
            decimal _je;
            ts_call.CFMX[] _cfmx;
            Thread _thread;
            ts_call.Icall _call;


            public Thread Thread
            {
                get
                {
                    return _thread;
                }
                set
                {
                    _thread = value;
                }
            }
            public Caller(string name, decimal je, ts_call.CFMX[] cfmx, ts_call.Icall call)
            {
                _name = name;
                _je = je;
                _cfmx = cfmx;
                _call = call;
            }
            public void call()
            {
                try
                {
                    if (_call != null && _call.CurrentThread != null)
                    {
                        _call.CurrentThread.Abort();
                    }
                    _call.CurrentThread = _thread;
                    _call.Call(ts_call.DmType.��ҩ, _name, Convert.ToDouble(_je), _cfmx);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            public void call_hj()
            {
                if (_call != null && _call.CurrentThread != null)
                {
                    _call.CurrentThread.Abort();
                }
                _call.CurrentThread = _thread;
                _call.Call(ts_call.DmType.��ҩ����, _name, Convert.ToDouble(_je), _cfmx);
            }
        }

        private class VoiceCaller
        {
            string _name;
            Thread _thread;
            ts_VoiceCall.Icall __voiceCall;


            public Thread Thread
            {
                get
                {
                    return _thread;
                }
                set
                {
                    _thread = value;
                }
            }
            public VoiceCaller(string name, ts_VoiceCall.Icall call)
            {
                _name = name;
                __voiceCall = call;
            }
            public void VoiceCall()
            {
                if (__voiceCall != null && __voiceCall.CurrentThread != null)
                {
                    __voiceCall.CurrentThread.Abort();
                }
                __voiceCall.CurrentThread = _thread;
                __voiceCall.Call(_name);
            }
        }

        private void butquit_Click(object sender, System.EventArgs e)
        {
            _ClickQuit = true;
            this.Close();
        }

        private void butprint_Click(object sender, System.EventArgs e)
        {
            try
            {
                //��ҽԺ�Ĵ�������
                //FrmselRq frmselrq = new FrmselRq();
                //frmselrq.ShowDialog();
                //if (frmselrq.bok == true)
                //{
                //    PrintRq = frmselrq.rq;
                //}
                //else
                //    return;

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                butprint.Enabled = false;

                YpConfig ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                //Add by zhujh 2017-06-26  �������󣺷�ҩ��ʱ������ʾ����ǡ�����ҩƷ��ʶ��ר����
                foreach (DataRow item in tb.Rows)
                {
                    if (Convertor.IsNull(item["��ҩ��ע"], "").Contains("����"))
                    {
                        MessageBox.Show("��ǡ�����ҩƷ��ʶ��ר����", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }


                //���鴦��
                DataRow[] selrow;
                if (ypconfig.���﷢ҩ����ܴ�ӡ���� == true)
                    selrow = tb.Select("( ��ҩ='��') and ypid<>''");
                else
                    selrow = tb.Select("(��ҩ='��' or  ��ҩ='��') and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);

                DataTable tbcf;
                if (rdo1.Checked == true) //���Ϊδ��ҩ��ȡ�ܽ��ѷ�ҩ��ȡ���ֵ
                {
                    string[] GroupbyField ={ "cfxh", "��Ʊ��", "�ܽ��", "���", "�����" };
                    string[] ComputeField ={ };
                    string[] CField ={ };
                    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                }
                else
                {
                    string[] GroupbyField ={ "cfxh", "��Ʊ��", "���", "�����" };
                    string[] ComputeField ={ "���" };
                    string[] CField ={ "sum" };
                    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                }

                if (chkxp.Checked == true)
                {
                    this.PrintCfXP();
                    return;
                }

                SystemCfg cfg8035 = new SystemCfg(8035);

                //���﷢ҩ����ҩʱ,�������嵥�Ĵ�ӡ˳�� 1�ȴ�ӡ�������ӡ�嵥,2�ȴ�ӡ�嵥���ӡ����
                if (cfg8035.Config == "1")
                {
                    //����
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1);
                    }
                    //ע�䵥


                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2);
                    }

                    //�嵥
                    //���鴦��
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "fpid" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["fpid"].ToString());
                        }
                    }
                }
                else
                {
                    //�嵥
                    //���鴦��
                    if (chkqd.Checked == true)
                    {
                        DataTable tbselqd = tb.Clone();
                        for (int w = 0; w <= selrow.Length - 1; w++)
                            tbselqd.ImportRow(selrow[w]);

                        DataTable tbcfqd;
                        string[] GroupbyFieldqd ={ "fpid" };
                        string[] ComputeFieldqd ={ };
                        string[] CFieldqd ={ };
                        tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                        for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                        {
                            this.PrintCf(tbcfqd.Rows[i]["fpid"].ToString());
                        }
                    }

                    //����
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkcf.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 1);
                    }

                    //ע�䵥

                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        if (chkzsd.Checked == true)
                            this.PrintCf(tbcf.Rows[i], 2);
                    }

                }

                //�����񴦷���ӡ
                if (chkmj.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintMJ(tbcf.Rows[i]);
                    }
                }
                //����ҩƷ������ӡ
                if (chkDJ.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintDJ(tbcf.Rows[i]);
                    }
                }

                //����������ӡ
                if (chkJ2.Checked == true)
                {
                    for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                    {
                        this.PrintJ2(tbcf.Rows[i]);
                    }
                }

                if (chkcf.Checked == true)
                {
                    //���鴦��
                    DataRow[] selrow_dy = tb.Select("��ҩ='��' and ypid<>''");
                    DataTable tbsel_dy = tb.Clone();
                    for (int w = 0; w <= selrow_dy.Length - 1; w++)
                        tbsel_dy.ImportRow(selrow_dy[w]);
                    string[] GroupbyField_dy ={ "FPID", "����", "��Ʊ��", "�����" };
                    string[] ComputeField_dy ={ "���" };
                    string[] CField_dy ={ "sum" };
                    DataTable tbcf_dy = FunBase.GroupbyDataTable(tbsel_dy, GroupbyField_dy, ComputeField_dy, CField_dy, null);

                    for (int i = 0; i <= tbcf_dy.Rows.Count - 1; i++)
                    {
                        ParameterEx[] parameters = new ParameterEx[11];
                        parameters[0].Text = "@FPID";
                        parameters[0].DataType = System.Data.DbType.Guid;
                        parameters[0].Value = tbcf_dy.Rows[i]["fpid"].ToString();

                        parameters[1].Text = "@FPH";
                        parameters[1].Value = tbcf_dy.Rows[i]["��Ʊ��"].ToString();

                        parameters[2].Text = "@ZJE";
                        parameters[2].DataType = System.Data.DbType.Decimal;
                        parameters[2].Value = tbcf_dy.Rows[i]["���"].ToString();

                        parameters[3].Text = "@BRXM";
                        parameters[3].Value = tbcf_dy.Rows[i]["����"].ToString();

                        parameters[4].Text = "@BLH";
                        parameters[4].Value = tbcf_dy.Rows[i]["�����"].ToString();

                        parameters[5].Text = "@LYCK";
                        parameters[5].Value = _Fyckh;

                        parameters[6].Text = "@LYCKMC";
                        parameters[6].Value = _Fyckmc;

                        parameters[7].Text = "@DEPTID";
                        parameters[7].DataType = System.Data.DbType.Int32;
                        parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                        parameters[8].Text = "@DEPTNAME";
                        parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                        parameters[9].Text = "@DJY";
                        parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                        parameters[10].Text = "@jhlx";
                        parameters[10].Value = "print";

                        int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);


                        DataView dv = (DataView)dataGridView1.DataSource;
                        DataTable tbfp = dv.Table;
                        DataRow[] rows = tbfp.Select("fpid='" + tbcf_dy.Rows[i]["fpid"].ToString() + "'");
                        if (rows.Length == 1)
                            rows[0]["��ӡ"] = "1";
                    }

                }

                butprint.Enabled = true;
            }
            catch (System.Exception err)
            {
                butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }

        private void PrintCf(DataRow row)
        {
            //DataTable tb=(DataTable)this.myDataGrid1.DataSource;

            //DataRow[] rows;
            //rows=tb.Select("( ��ҩ='��' or ��ҩ='��') and ��Ʊ��='"+row["��Ʊ��"]+"' ");
            //if (rows.Length==0) return;
            //string cftsname="";
            //cftsname=Convert.ToString(rows[0]["��Ŀ"]).Trim()=="�в�ҩ"?"��ҩ����":"";
            //ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

            //DataRow myrow = null;
            //int yzzh = 0;
            //int xxx = 0;

            //for(int i=0;i<=rows.Length-1;i++)
            //{
            //        //myrow=Dset.���˴����嵥.NewRow();
            //        //myrow["xh"]=Convert.ToInt32(rows[i]["���"]);
            //        //myrow["ypmc"]=Convert.ToString(rows[i]["Ʒ��"]);
            //        //myrow["ypgg"]=Convert.ToString(rows[i]["���"]);
            //        //myrow["sccj"]=Convert.ToString(rows[i]["����"]);
            //        //myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["����"],"0"));
            //        //myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["����"],"0"));
            //        //myrow["ypdw"]=Convert.ToString(rows[i]["��λ"]);
            //        //myrow["cfts"]=Convert.ToString(rows[i]["��Ŀ"]).Trim()=="�в�ҩ"?rows[i]["����"]+"��":"";
            //        //myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["���"],"0"));
            //        //string UserEat="";
            //        //UserEat=rows[i]["Ƶ��"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["����"]).ToString()+rows[i]["������λ"].ToString().Trim()+"/ÿ��";
            //        //myrow["yf"]=Convert.ToString(rows[i]["�÷�"])+"  "+rows[i]["ʹ��Ƶ��"].ToString().Trim()+" "+UserEat;
            //        //myrow["pc"]= rows[i]["ʹ��Ƶ��"].ToString().Trim();
            //        //myrow["syjl"]="";
            //        //myrow["zt"]=Convert.ToString(rows[i]["����"]);
            //        //myrow["shh"]=Convert.ToString(rows[i]["����"]);
            //        //myrow["ksname"]=Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
            //        //string ysqm="";
            //        ////if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
            //        //myrow["ysname"]=Convert.ToString(rows[i]["ҽ��"])+ysqm;
            //        //myrow["Pyck"]=rows[i]["Ƥ��"].ToString();
            //        //myrow["fph"]=Convert.ToString(rows[i]["��Ʊ��"]);
            //        //myrow["hzxm"]=Convert.ToString(rows[i]["����"]);
            //        //myrow["sex"]=Convert.ToString(rows[i]["�Ա�"]);
            //        //myrow["age"]=Convert.ToString(rows[i]["����"]);
            //        //myrow["blh"]=Convert.ToString(rows[i]["�����"]);
            //        //myrow["sfrq"]=Convert.ToString(rows[i]["�շ�����"]);
            //        //myrow["pyr"]=this.cmbpyr.Text.Trim();;
            //        //myrow["fyr"]=InstanceForm.BCurrentUser.Name;
            //        //Dset.���˴����嵥.Rows.Add(myrow);


            //        if (Convert.ToString(rows[0]["cflx"]) == "03" && rdocfgs.Checked == true)
            //        {
            //            #region ��ҩ������ʽ
            //            if (xxx == 2)
            //            {
            //                Dset.���˴����嵥.Rows.Add(myrow);
            //                myrow = Dset.���˴����嵥.NewRow();
            //                xxx = 0;
            //            }
            //            if (i == 0)
            //                myrow = Dset.���˴����嵥.NewRow();

            //            xxx = xxx + 1;
            //            string s = "                                                         ";
            //            string zt = Convertor.IsNull(rows[i]["����"], "").Trim() == "" ? "" : "(" + Convertor.IsNull(rows[i]["����"], "").Trim() + ")";
            //            string _ypmc = rows[i]["Ʒ��"].ToString().Trim() + zt.Trim() + s;
            //            _ypmc = _ypmc.Replace("@", "");
            //            _ypmc = _ypmc.Replace("%", "");
            //            _ypmc = _ypmc.Replace("*", "");
            //            _ypmc = new String(System.Text.Encoding.Default.GetChars(System.Text.Encoding.Default.GetBytes(_ypmc), 0, 15));
            //            string _yl = rows[i]["����"].ToString() + rows[i]["��λ"].ToString().Trim();
            //            _yl = _yl + s;
            //            _yl = new String(System.Text.Encoding.Default.GetChars(System.Text.Encoding.Default.GetBytes(_yl), 0, 6));
            //            myrow["ypmc"] = myrow["ypmc"] + _ypmc + " " + _yl + "     ";

            //            myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
            //            myrow["sccj"] = Convert.ToString(rows[i]["����"]);
            //            myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
            //            myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
            //            myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
            //            myrow["cfts"] = Convert.ToString(rows[i]["��Ŀ"]).Trim() == "�в�ҩ" ? rows[i]["����"] + "��" : "";
            //            myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
            //            string UserEat = "";
            //            UserEat = rows[i]["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["����"]).ToString() + rows[i]["������λ"].ToString().Trim() + "/ÿ��";
            //            myrow["yf"] = Convert.ToString(rows[i]["�÷�"]) + "  " + rows[i]["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
            //            myrow["pc"] = rows[i]["ʹ��Ƶ��"].ToString().Trim();
            //            myrow["syjl"] = "";
            //            myrow["zt"] = " " + Convert.ToString(rows[i]["����"]);
            //            myrow["shh"] = Convert.ToString(rows[i]["����"]);
            //            myrow["ksname"] = Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
            //            string ysqm = "";
            //            //if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
            //            myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim() + Convertor.IsNull(ysqm, "");
            //            myrow["Pyck"] = rows[i]["Ƥ��"].ToString();
            //            myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
            //            myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
            //            myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
            //            myrow["age"] = Convert.ToString(rows[i]["����"]);
            //            myrow["blh"] = Convert.ToString(rows[i]["�����"]);
            //            myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
            //            if (Convert.ToString(rows[i]["��ҩԱ"]).Trim() == "")
            //                myrow["pyr"] = this.cmbpyr.Text.Trim(); 
            //            else
            //                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]).Trim();
            //            myrow["fyr"] = "";
            //            myrow["pyckdm"] = Convert.ToString(rows[i]["��ҩ����"]); ;
            //            myrow["fyckdm"] = Convert.ToString(rows[i]["��ҩ����"]);
            //            myrow["zdmc"] = Convert.ToString(rows[i]["���"]);
            //            //myrow["syff"] = Convert.ToString(rows[i]["�÷�"]);
            //            //myrow["sypc"] = Convert.ToString(rows[i]["Ƶ��"]);
            //            //myrow["jl"] = Convert.ToString(rows[i]["����"]);
            //            //myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
            //            //myrow["ts"] = Convert.ToDecimal(rows[i]["����"]);
            //            if (rows[i]["���־"].ToString() == "1")
            //                yzzh = yzzh + 1;
            //            myrow["yzzh"] = yzzh;
            //            myrow["pxxh"] = Convert.ToInt32(rows[i]["�������"]);

            //            if (i == rows.Length - 1)
            //                Dset.���˴����嵥.Rows.Add(myrow);


            //            #endregion ��ҩ������ʽ

            //        }
            //        else
            //        {
            //            #region  ����ҩ������ʽ
            //            myrow = Dset.���˴����嵥.NewRow();
            //            myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
            //            myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
            //            myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
            //            myrow["sccj"] = Convert.ToString(rows[i]["����"]);
            //            myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
            //            myrow["ypsl"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
            //            myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
            //            myrow["cfts"] = Convert.ToString(rows[i]["��Ŀ"]).Trim() == "�в�ҩ" ? rows[i]["����"] + "��" : "";
            //            myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
            //            string UserEat = "";
            //            UserEat = rows[i]["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["����"]).ToString() + rows[i]["������λ"].ToString().Trim() + "/ÿ��";
            //            myrow["yf"] = Convert.ToString(rows[i]["�÷�"]) + "  " + rows[i]["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
            //            myrow["pc"] = rows[i]["ʹ��Ƶ��"].ToString().Trim();
            //            myrow["syjl"] = "";
            //            myrow["zt"] = " " + Convert.ToString(rows[i]["����"]);
            //            myrow["shh"] = Convert.ToString(rows[i]["����"]);
            //            myrow["ksname"] = Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
            //            string ysqm = "";
            //            //if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
            //            myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim() + Convertor.IsNull(ysqm, "");
            //            myrow["Pyck"] = rows[i]["Ƥ��"].ToString();
            //            myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
            //            myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
            //            myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
            //            myrow["age"] = Convert.ToString(rows[i]["����"]);
            //            myrow["blh"] = Convert.ToString(rows[i]["�����"]);
            //            myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
            //            if (Convert.ToString(rows[i]["��ҩԱ"]).Trim() == "")
            //                myrow["pyr"] = this.cmbpyr.Text.Trim();
            //            else
            //                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]).Trim();
            //            myrow["fyr"] = "";
            //            myrow["pyckdm"] = Convert.ToString(rows[i]["��ҩ����"]);
            //            myrow["fyckdm"] = Convert.ToString(rows[i]["��ҩ����"]);
            //            myrow["zdmc"] = Convert.ToString(rows[i]["���"]);
            //            //myrow["syff"] = Convert.ToString(rows[i]["�÷�"]);
            //            //myrow["sypc"] = Convert.ToString(rows[i]["Ƶ��"]);
            //            //myrow["jl"] = Convert.ToString(rows[i]["����"]);
            //            //myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
            //            //myrow["ts"] = Convert.ToDecimal(rows[i]["����"]);
            //            if (rows[i]["���־"].ToString() == "1")
            //                yzzh = yzzh + 1;
            //            myrow["yzzh"] = yzzh;
            //            myrow["pxxh"] = Convert.ToInt32(rows[i]["�������"]);

            //            if (rdocfgs.Checked == true && Convert.ToString(rows[0]["cflx"]) != "03")
            //            {
            //                if (rows[i]["���־"].ToString() == "1")
            //                    myrow["ypmc"] = "��" + myrow["ypmc"];
            //                if (rows[i]["���־"].ToString() == "-1")
            //                    myrow["ypmc"] = "��" + myrow["ypmc"];
            //                if (rows[i]["���־"].ToString() != "1" && rows[i]["���־"].ToString() != "-1")
            //                    myrow["ypmc"] = "��" + myrow["ypmc"];

            //                myrow["ypmc"] = myrow["ypmc"] + " " + rows[i]["��λ���"].ToString().Trim();//;+ "*" + rows[i]["����"].ToString() + rows[i]["��λ"].ToString();
            //                myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();

            //            }
            //            Dset.���˴����嵥.Rows.Add(myrow);

            //            if (rdocfgs.Checked == true && Convert.ToString(rows[0]["cflx"]) != "03")
            //            {
            //                DataRow myrow1;
            //                string ps = "";
            //                string ss = " ";
            //                if (Convert.ToString(rows[i]["Ƥ��"]).Trim() != "")
            //                    ps = " (" + Convert.ToString(rows[i]["Ƥ��"]).Trim() + ")";
            //                if (i < rows.Length - 1)
            //                {
            //                    if (rows[i]["���־"].ToString() != "-1" && yzzh>0) ss = "��";
            //                }
            //                myrow1 = Dset.���˴����嵥.NewRow();
            //                myrow1["ypmc"] = ss + "      �÷�:" + rows[i]["����"].ToString() + rows[i]["������λ"].ToString().Trim()
            //                    + Convert.ToString(rows[i]["����"]) + " " + Convert.ToString(rows[i]["�÷�"]) +
            //                    " " + rows[i]["ʹ��Ƶ��"].ToString().Trim() + ps;
            //                if (Convert.ToString(rows[i]["�÷�"]).Trim() == "")
            //                    myrow1["ypmc"] = "       �÷�:";

            //                myrow1["yzzh"] = yzzh;
            //                myrow1["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim() + Convertor.IsNull(ysqm, "");
            //                myrow1["pyr"] = myrow["pyr"];
            //                Dset.���˴����嵥.Rows.Add(myrow1);
            //            }
            //            #endregion
            //        }
            //}

            ////ParameterEx[] parameters=new ParameterEx[4];
            ////parameters[0].Text="cfts";
            ////parameters[0].Value=cftsname;
            ////parameters[1].Text="zje";
            ////if (rdo1.Checked==true) //���Ϊδ��ҩ��ȡ�ܽ��ѷ�ҩ��ȡ���ֵ
            ////    parameters[1].Value=Convert.ToDecimal(Convertor.IsNull(row["�ܽ��"],"0"));
            ////else
            ////    parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(row["���"], "0"));
            ////parameters[2].Text="TITLETEXT";
            ////parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+"������ϸ��";
            ////parameters[3].Text="text1";
            ////parameters[3].Value="��ҩ��λ:"+InstanceForm.BCurrentDept.DeptName+"    ���:"+row["���"].ToString();
            ////bool bview=this.chkprintview.Checked==true?false:true;
            ////TrasenFrame.Forms.FrmReportView f;

            ////if (Convert.ToString(rows[0]["��Ŀ"]).Trim()!="�в�ҩ")
            ////    f=new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥,Constant.ApplicationDirectory+"\\Report\\YF_���˴����嵥.rpt",parameters,bview);
            ////else
            ////    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥_��ҩ����.rpt", parameters, bview);

            ////if (f.LoadReportSuccess) f.Show();else  f.Dispose();

            //if (Convert.ToString(rows[0]["cflx"]) == "03" && rdocfgs.Checked == true)
            //{
            //    myrow = Dset.���˴����嵥.NewRow();
            //    myrow["ypmc"] = "      �÷�:" + Convert.ToString(rows[0]["�÷�"]) + " " + Convert.ToString(rows[0]["����"]) + " " + rows[0]["ʹ��Ƶ��"].ToString().Trim() + "       ��������: " + rows[0]["����"] + "��";
            //    myrow["yzzh"] = yzzh;
            //    myrow["ysname"] = Convert.ToString(rows[0]["ҽ��"]).Trim();
            //    Dset.���˴����嵥.Rows.Add(myrow);
            //}

            //ParameterEx[] parameters = new ParameterEx[7];
            //parameters[0].Text = "cfts";
            //parameters[0].Value = cftsname;
            //parameters[1].Text = "zje";
            //parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["�ܽ��"], "0"));
            //parameters[2].Text = "TITLETEXT";
            //if (rdocfgs.Checked == true)
            //    parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "���ﴦ����";
            //else
            //    parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + InstanceForm.BCurrentDept.DeptName + ")" + "������ϸ��";
            //parameters[3].Text = "text1";
            //parameters[3].Value = "��ҩ��λ:" + InstanceForm.BCurrentDept.DeptName + "    ���:" + rows[0]["���"].ToString();

            //parameters[4].Text = "xyf";
            //if (Convert.ToString(rows[0]["cflx"]) != "03")
            //    parameters[4].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            //else
            //    parameters[4].Value = 0;
            //parameters[5].Text = "zyf";
            //if (Convert.ToString(rows[0]["cflx"]) == "03")
            //    parameters[5].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            //else
            //    parameters[5].Value = 0;
            //parameters[6].Text = "yfmc";
            //parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            //bool bview = true;
            //if (chkprintview.Checked == true) bview = false;
            //TrasenFrame.Forms.FrmReportView f;
            //if (rdocfgs.Checked == true)
            //    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(������ʽ).rpt", parameters, bview);
            //else
            //{
            //    if (Convert.ToString(rows[0]["cflx"]) == "03")
            //        f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥_��ҩ����.rpt", parameters, bview);
            //    else
            //        f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥.rpt", parameters, bview);
            //}
            //if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

        private void PrintCf(string fpid)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;

            string where = "(��ҩ='��' or  ��ҩ='��') and ypid<>''";
            if (fpid != "")
                where = where + " and fpid='" + fpid + "'";
            rows = tb2.Select(where);
            if (rows.Length == 0)
                return;

            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + rows[0]["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                #region  ����ҩ������ʽ
                myrow = Dset.���˴����嵥.NewRow();
                myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
                myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                myrow["cfts"] = rows[i]["����"].ToString();
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                myrow["yf"] = Convertor.IsNull(rows[i]["�÷�"], "");

                //Modify by jchl
                //myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["Ƶ��"], "");

                myrow["syjl"] = "";
                myrow["zt"] = Convertor.IsNull(rows[i]["����"], "");
                myrow["shh"] = Convert.ToString(rows[i]["����"]);
                myrow["ksname"] = Convert.ToString(rows[i]["����"]).Trim();
                myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim();
                myrow["PSZT"] = rows[i]["Ƥ��"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
                myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
                myrow["age"] = Convert.ToString(rows[i]["����"]);
                myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
                myrow["pyr"] = this.cmbpyr.Text.Trim();

                myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["��ҩԱ"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? "" : Convertor.IsNull(rows[i]["��ҩ����"], "");
                myrow["fyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["��ҩ����"], "");
                myrow["zdmc"] = Convertor.IsNull(rows[i]["���"], "");
                myrow["syff"] = Convert.ToString(rows[i]["�÷�"]);
                myrow["sypc"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");
                if (rows[i]["���־"].ToString() == "1")
                {
                    yzzh = yzzh + 1;
                }
                myrow["yzzh"] = yzzh;
                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                myrow["fzbz"] = rows[i]["���־"].ToString();

                myrow["JTDZ"] = jtdz;
                myrow["LXDH"] = grlxdh;
                myrow["SFZH"] = sfzh;
                myrow["bz1"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                Dset.���˴����嵥.Rows.Add(myrow);
                #endregion
            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["����"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = sumje;
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "��ҩ��λ:" + InstanceForm.BCurrentDept.DeptName + "    ���:" + rows[0]["���"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        private void PrintCf(DataRow row, int cfgs)
        {

            //Modify by Zhujh 2017-02-17 
            // string[] arry = new string[] { "��ͨ�ȵ���(ŵ����R��о��", "��ͨ�ȵ���(ŵ����R��", "�;�����п(ŵ����Nо���ȵ���", "�;�����п(ŵ����N���ȵ���","Ԥ���ȵ���(ŵ����30R��о��","Ԥ���ȵ���(ŵ����50R��о��","�Ŷ��ȵ���50��","�Ŷ��ȵ���30��(ŵ����30��о)","�Ŷ��ȵ�����(ŵ�����о)",
            //"��ͨ�ȵ���(������R��о��" ,"�;�����п(������Nо)�ȵ���","Ԥ���ȵ���(������30R��о��","�ʾ��ȵ�����(Ԥ���)","������25","������50","������","Ԥ���ȵ��أ������������70/30��","��ͨ�ȵ����루���������ֱ�о��",
            // "�ȵ����루�����֣�","�׵�����","��ע�������򵰰ף�PH4)","��������루�̴ܹ","����³��ע��Һ��Ԥ��䣩"};//���Ǳ� 11.28  ���ܴ�ӡ��ҩƷ


            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;
            if (cfgs == 1)
            { rows = tb2.Select(" cfxh='" + row["cfxh"] + "' "); }
            else
            {
                //��ѯά����ҩƷƷ����ͼ����ָ����ͼ������򲻴�ӡ
                DataTable dtYpCjid = GetYpCjidList();

                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
                if (rows.Length == 0)
                    return;

                for (int m = 0; m <= rows.Length - 1; m++)//Modify by Zhujh  2017-02-17 �鿴�Ƿ�����ָ����ҩƷ
                {
                    for (int j = 0; j < dtYpCjid.Rows.Count; j++)
                    {
                        if (rows[m]["����"].ToString().Trim() == dtYpCjid.Rows[j]["cjid"].ToString().Trim())
                        {
                            return;
                        }
                    }
                }

                /* Modify by Zhujh 2017-02-17 ע��
                for (int m = 0; m <= rows.Length - 1; m++)//���Ǳ�  11.28 �鿴�Ƿ�����ָ����ҩƷ
                {
                    string pinming = Convert.ToString(rows[m]["Ʒ��"]);
                    for (int j = 0; j < arry.Length; j++)
                    {
                        if (pinming.IndexOf(arry[j].ToString().Trim()) >= 0)
                        {
                            return;
                        }
                    }
                }
                */
            }

            if (rows.Length == 0)
                return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            string jtdz = "";
            string grlxdh = "";
            string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }
            if (cfgs == 2)
            {
                //Modify By Zhujh 2017-02-17
                //�ж��÷��Ƿ���ά���÷���ͼ����
                DataTable dtYpyf = GetYpYFList();
                DataTable dt = null;
                bool PTCF = true;
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");
                string strsql = @"SELECT d.JSYP,d.MZYP,d.DJYP FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
                dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);

                //2.�ж�ҩƷ�Ƿ�������ҩƷ�뾫��ҩƷ������ҩ���������һ���ҩƷ���򲻽��д�ӡ
                if (dt == null || dt.Rows.Count <= 0) return;
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    if (dt.Rows[i]["JSYP"].ToString() == "True" || dt.Rows[i]["DJYP"].ToString() == "True" || dt.Rows[i]["MZYP"].ToString() == "True")
                    {
                        PTCF = false;
                    }
                }
                if (PTCF)
                {
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        string yf = Convert.ToString(rows[i]["�÷�"]);//���Ǳ�  11.28 �鿴�Ƿ�����ע��ҩƷ
                        for (int j = 0; j < dtYpyf.Rows.Count; j++)
                        {
                            //if (yf == "iv drip" || yf == "iv" || yf == "im" || yf == "ih" || yf == "H") //Modify by Zhujh 2017-02-17ע��
                            if (yf == dtYpyf.Rows[j]["yf"].ToString())
                            {
                                #region  ����ҩ������ʽ
                                myrow = Dset.���˴����嵥.NewRow();
                                myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                                myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                                myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                                myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));

                                //Modify by zhujh 2017-03-03
                                if (Convertor.IsNull(rows[i]["����"], "0") == "0")
                                {
                                    string strSqlsl = "select a.SL from MZ_CFB_MX a inner join MZ_CFB b on a.CFID=b.CFID where b.FPH='" + Convert.ToString(rows[i]["��Ʊ��"]) + "' AND a.BM=" + Convert.ToString(rows[i]["ypid"]);
                                    DataTable dtsl = InstanceForm.BDatabase.GetDataTable(strSqlsl);
                                    if (dtsl == null || dtsl.Rows.Count <= 0)
                                    {
                                        myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();

                                    }
                                    else
                                    {
                                        myrow["ypsl"] = Convert.ToDouble(dtsl.Rows[0]["sl"]).ToString();
                                    }
                                }
                                else
                                {
                                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                                }
                                myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                                myrow["cfts"] = rows[i]["����"].ToString();
                                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                                myrow["yf"] = Convertor.IsNull(rows[i]["�÷�"], "");

                                //Modify by jchl
                                //myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
                                myrow["pc"] = Convertor.IsNull(rows[i]["Ƶ��"], "");

                                myrow["syjl"] = "";
                                myrow["zt"] = Convertor.IsNull(rows[i]["����"], "");
                                myrow["shh"] = Convert.ToString(rows[i]["����"]);
                                myrow["ksname"] = Convert.ToString(rows[i]["����"]).Trim();
                                myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim();
                                myrow["PSZT"] = rows[i]["Ƥ��"].ToString();
                                myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                                myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
                                myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
                                myrow["age"] = Convert.ToString(rows[i]["����"]);
                                myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                                myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
                                myrow["pyr"] = GetImageByte((Convertor.IsNull(cmbpyr.SelectedValue, "0")));
                                myrow["imgfyr"] = GetImageByte((Convertor.IsNull(rows[i]["qrczyh"], "0")));
                                myrow["imgpyr"] = GetImageByte((Convertor.IsNull(rows[i]["pyczyh"], "0"))); //this.cmbpyr.Text.Trim(); modify by jchl
                                ;
                                myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["��ҩԱ"]);
                                myrow["pyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? "" : Convertor.IsNull(rows[i]["��ҩ����"], "");
                                myrow["fyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["��ҩ����"], "");
                                myrow["zdmc"] = Convertor.IsNull(rows[i]["���"], "");

                                myrow["syff"] = Convert.ToString(rows[i]["�÷�"]);
                                myrow["sypc"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                                myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                                myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                                myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                                myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");

                                if (rows[i]["���־"].ToString() == "1")
                                {
                                    yzzh = yzzh + 1;
                                }
                                myrow["yzzh"] = yzzh;
                                myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                                myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                                myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                                myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                                //myrow["sfrq"] = PrintRq.ToLongDateString();
                                //myrow["cfrq"] = PrintRq.ToLongDateString();
                                //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["�����"]).Substring(8,Convert.ToString(rows[i]["�����"]).Length-8);
                                myrow["fzbz"] = rows[i]["���־"].ToString();

                                myrow["JTDZ"] = jtdz;
                                myrow["LXDH"] = grlxdh;
                                myrow["SFZH"] = sfzh;
                                myrow["bz1"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                                myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                                myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                                myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                                myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                                myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                                myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                                Dset.���˴����嵥.Rows.Add(myrow);
                                #endregion
                            }
                        }
                    }

                }
            }
            else
            {

                for (int i = 0; i <= rows.Length - 1; i++)
                {

                    #region  ����ҩ������ʽ
                    myrow = Dset.���˴����嵥.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                    myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                    myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                    myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
                    myrow["ypsl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                    myrow["cfts"] = rows[i]["����"].ToString();
                    myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                    myrow["yf"] = Convertor.IsNull(rows[i]["�÷�"], "");

                    //Modify by jchl
                    //myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
                    myrow["pc"] = Convertor.IsNull(rows[i]["Ƶ��"], "");

                    myrow["syjl"] = "";
                    myrow["zt"] = Convertor.IsNull(rows[i]["����"], "");
                    myrow["shh"] = Convert.ToString(rows[i]["����"]);
                    myrow["ksname"] = Convert.ToString(rows[i]["����"]).Trim();
                    myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim();
                    myrow["PSZT"] = rows[i]["Ƥ��"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                    myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
                    myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
                    myrow["age"] = Convert.ToString(rows[i]["����"]);
                    myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                    myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
                    myrow["pyr"] = GetImageByte((Convertor.IsNull(cmbpyr.SelectedValue, "0")));
                    myrow["imgfyr"] = GetImageByte((Convertor.IsNull(rows[i]["qrczyh"], "0")));
                    myrow["imgpyr"] = GetImageByte((Convertor.IsNull(rows[i]["pyczyh"], "0"))); //this.cmbpyr.Text.Trim(); modify by jchl
                    ;
                    myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["��ҩԱ"]);
                    myrow["pyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? "" : Convertor.IsNull(rows[i]["��ҩ����"], "");
                    myrow["fyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["��ҩ����"], "");
                    myrow["zdmc"] = Convertor.IsNull(rows[i]["���"], "");
                    myrow["syff"] = Convert.ToString(rows[i]["�÷�"]);
                    myrow["sypc"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                    myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");

                    if (rows[i]["���־"].ToString() == "1")
                    {
                        yzzh = yzzh + 1;
                    }
                    myrow["yzzh"] = yzzh;
                    myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                    myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                    myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                    myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                    //myrow["sfrq"] = PrintRq.ToLongDateString();
                    //myrow["cfrq"] = PrintRq.ToLongDateString();
                    //myrow["blh"] =PrintRq.Year.ToString()+"0"+PrintRq.Month.ToString()+PrintRq.Day.ToString()+ Convert.ToString(rows[i]["�����"]).Substring(8,Convert.ToString(rows[i]["�����"]).Length-8);
                    myrow["fzbz"] = rows[i]["���־"].ToString();

                    myrow["JTDZ"] = jtdz;
                    myrow["LXDH"] = grlxdh;
                    myrow["SFZH"] = sfzh;
                    myrow["bz1"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                    myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                    myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                    myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    myrow["dyr"] = InstanceForm.BCurrentUser.Name;
                    myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.���˴����嵥.Rows.Add(myrow);
                    #endregion
                }


            }

            if (Dset.���˴����嵥.Rows.Count <= 0)
            {
                return;
            }

            ParameterEx[] parameters = new ParameterEx[7];
            parameters[0].Text = "cfts";
            parameters[0].Value = rows[0]["����"].ToString();
            parameters[1].Text = "zje";
            parameters[1].Value = Convert.ToDecimal(Convertor.IsNull(rows[0]["�ܽ��"], "0"));
            parameters[2].Text = "TITLETEXT";
            parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "";
            parameters[3].Text = "text1";
            parameters[3].Value = "��ҩ��λ:" + InstanceForm.BCurrentDept.DeptName + "    ���:" + rows[0]["���"].ToString();

            parameters[4].Text = "xyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            if (cfgs == 1)
            {
                if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥_��ҩ����.rpt", parameters, bview);

                else
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(������ʽ).rpt", parameters, bview);
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_�췢���˴����嵥(������ʽ).rpt", parameters, bview);
            }
            else
            {
                if (Convert.ToString(rows[0]["cflx"]).Trim() == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥_��ҩ����.rpt", parameters, bview);

                else
                    //f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(������ʽ).rpt", parameters, bview);
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_�췢���˴����嵥(������ʽ).rpt", parameters, bview);
                // f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(ע�䵥).rpt", parameters, bview);
            }
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();
        }

        private void PrintCfXP()
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;

            DataRow[] rows;
            rows = tb.Select("( ��ҩ='��' or ��ҩ='��')  and ����<>''");
            if (rows.Length == 0)
                return;
            string cftsname = "";
            cftsname = Convert.ToString(rows[0]["��Ŀ"]).Trim() == "�в�ҩ" ? "��ҩ����" : "";
            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow;
            for (int i = 0; i <= rows.Length - 1; i++)
            {
                myrow = Dset.���˴����嵥.NewRow();
                //myrow["xh"]=Convert.ToInt32(rows[i]["���"]);
                myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
                myrow["zje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["�ܽ��"], "0"));
                myrow["ypsl"] = Convertor.IsNull(rows[i]["����"], "0");
                myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                myrow["cfts"] = Convert.ToString(rows[i]["��Ŀ"]).Trim() == "�в�ҩ" ? rows[i]["����"] + "��" : "";
                myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                string UserEat = "";
                UserEat = rows[i]["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[i]["����"]).ToString() + rows[i]["������λ"].ToString().Trim() + "/ÿ��";
                myrow["yf"] = Convert.ToString(rows[i]["�÷�"]) + "  " + rows[i]["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;


                //Modify by jchl
                //myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
                myrow["pc"] = Convertor.IsNull(rows[i]["Ƶ��"], "");
                //myrow["pc"] = rows[i]["ʹ��Ƶ��"].ToString().Trim();

                myrow["syjl"] = "";
                myrow["zt"] = Convert.ToString(rows[i]["����"]);
                myrow["shh"] = Convert.ToString(rows[i]["����"]);
                myrow["ksname"] = Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
                string ysqm = "";
                //if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
                myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]) + ysqm;
                myrow["Pyck"] = rows[i]["Ƥ��"].ToString();
                myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
                myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
                myrow["age"] = Convert.ToString(rows[i]["����"]);
                myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
                myrow["pyr"] = this.cmbpyr.Text.Trim();
                ;
                myrow["fyr"] = InstanceForm.BCurrentUser.Name;
                Dset.���˴����嵥.Rows.Add(myrow);
            }

            ParameterEx[] parameters = new ParameterEx[1];
            parameters[0].Text = "TITLETEXT";
            parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "������ϸ��";
            bool bview = this.chkprintview.Checked == true ? false : true;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥�б�_СƱ.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }

        /// <summary>
        /// ���鴦����ӡ
        /// </summary>
        /// <param name="dr"></param>
        private void PrintMJ(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool jmcf = false;
            //1.��ѯҩƷ�����Ϣ
            string strsql = @"SELECT d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.�ж�ҩƷ�Ƿ�������ҩƷ�뾫��ҩƷ������ҩ���������һ���ҩƷ������д�ӡ
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((dt.Rows[i]["JSYP"].ToString() == "True" && dt.Rows[i]["JSYPFL"].ToString() == "1") || dt.Rows[i]["MZYP"].ToString() == "True")
                {
                    jmcf=true;
                }
            }
            if(jmcf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.���ﾫ�鴦����.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                    myrow["gg"] = Convert.ToString(rows[i]["���"]);
                    //myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                    //myrow["lsj"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["����"], "0"));
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["��λ"]);
                    //myrow["lsje"] = Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));
                    //myrow["yf"] = Convertor.IsNull(rows[i]["�÷�"], "");

                    myrow["pl"] = Convertor.IsNull(rows[i]["Ƶ��"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    //myrow["syjl"] = "";
                    //myrow["zt"] = Convertor.IsNull(rows[i]["����"], "");
                    //myrow["shh"] = Convert.ToString(rows[i]["����"]);
                    //myrow["ksname"] = Convert.ToString(rows[i]["����"]).Trim();
                    //myrow["ysname"] = Convert.ToString(rows[i]["ҽ��"]).Trim();
                    //myrow["PSZT"] = rows[i]["Ƥ��"].ToString();
                    myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                    //myrow["hzxm"] = Convert.ToString(rows[i]["����"]);
                    //myrow["sex"] = Convert.ToString(rows[i]["�Ա�"]);
                    //myrow["age"] = Convert.ToString(rows[i]["����"]);
                    //myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                    //myrow["sfrq"] = Convert.ToString(rows[i]["�շ�����"]);
                    //myrow["pyr"] = this.cmbpyr.Text.Trim();

                    //myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["��ҩԱ"]);
                    //myrow["pyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? "" : Convertor.IsNull(rows[i]["��ҩ����"], "");
                    //myrow["fyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"], "") == "" ? _Fyckh : Convertor.IsNull(rows[i]["��ҩ����"], "");
                    //myrow["zdmc"] = Convertor.IsNull(rows[i]["���"], "");
                    myrow["ypyf"] = Convert.ToString(rows[i]["�÷�"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");
                    //if (rows[i]["���־"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["���־"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;
                    //myrow["bz1"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                    //myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.���ﾫ�鴦����.Rows.Add(myrow);
                }
            }

            
            if (Dset.���ﾫ�鴦����.Rows.Count <= 0) return;
            ParameterEx[] parameters = new ParameterEx[11];
            parameters[0].Text = "xm";
            parameters[0].Value = Convert.ToString(rows[0]["����"]);
            parameters[1].Text = "xb";
            parameters[1].Value = Convert.ToString(rows[0]["�Ա�"]);
            parameters[2].Text = "nl";
            parameters[2].Value = Convert.ToString(rows[0]["����"]);
            parameters[3].Text = "ks";
            parameters[3].Value = Convert.ToString(rows[0]["����"]).Trim();
            parameters[4].Text = "bq";
            parameters[4].Value = "";
            parameters[5].Text = "ch";
            parameters[5].Value = "";
            parameters[6].Text = "zd";
            parameters[6].Value = Convertor.IsNull(rows[0]["���"], "");
            parameters[7].Text = "hzsfzh";
            parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
            parameters[8].Text = "zyh";
            parameters[8].Value = Convert.ToString(rows[0]["�����"]);
            parameters[9].Text = "rq";
            //parameters[9].Value = DateTime.Now.ToString();
            parameters[9].Value = Convert.ToString(rows[0]["¼������"]);
            parameters[10].Text = "yf";
            parameters[10].Value = sumje;

            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.���ﾫ�鴦����, Constant.ApplicationDirectory + "\\Report\\MZYF_��ҩ�龫һ�����嵥.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }
        /// <summary>
        /// ����ҩƷ������ӡ   add by chenli  2017-08-21
        /// </summary>
        /// <param name="row"></param>
        private void PrintDJ(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool djcf = false;
            //1.��ѯҩƷ�����Ϣ
            string strsql = @"SELECT d.DJYP,d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.�ж�ҩƷ�Ƿ��Ǿ���ҩƷ������ҩ��������ڶ����ҩƷ������д�ӡ
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["DJYP"].ToString() == "True")
                {
                   djcf=true;
                }

            }
            if(djcf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.����.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                    myrow["gg"] = Convert.ToString(rows[i]["���"]);
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["��λ"]);
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));

                    myrow["pl"] = Convertor.IsNull(rows[i]["Ƶ��"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                    myrow["ypyf"] = Convert.ToString(rows[i]["�÷�"]);
                    myrow["bzl"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                    myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");
                    //if (rows[i]["���־"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["���־"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;

                    //myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.����.Rows.Add(myrow);
                }
            }
                
                if (Dset.����.Rows.Count <= 0) return;
                ParameterEx[] parameters = new ParameterEx[11];
                parameters[0].Text = "xm";
                parameters[0].Value = Convert.ToString(rows[0]["����"]);
                parameters[1].Text = "xb";
                parameters[1].Value = Convert.ToString(rows[0]["�Ա�"]);
                parameters[2].Text = "nl";
                parameters[2].Value = Convert.ToString(rows[0]["����"]);
                parameters[3].Text = "ks";
                parameters[3].Value = Convert.ToString(rows[0]["����"]).Trim();
                parameters[4].Text = "bq";
                parameters[4].Value = "";
                parameters[5].Text = "ch";
                parameters[5].Value = "";
                parameters[6].Text = "zd";
                parameters[6].Value = Convertor.IsNull(rows[0]["���"], "");
                parameters[7].Text = "hzsfzh";
                parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
                parameters[8].Text = "zyh";
                parameters[8].Value = Convert.ToString(rows[0]["�����"]);
                parameters[9].Text = "rq";
                //parameters[9].Value = DateTime.Now.ToString();
                parameters[9].Value = Convert.ToString(rows[0]["¼������"]);
                parameters[10].Text = "yf";
                parameters[10].Value = sumje;

                bool bview = true;
                if (chkprintview.Checked == true)
                    bview = false;
                TrasenFrame.Forms.FrmReportView f;
                f = new TrasenFrame.Forms.FrmReportView(Dset.����, Constant.ApplicationDirectory + "\\Report\\MZYF_��ҩ���紦���嵥.rpt", parameters, bview);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            
        }

        /// <summary>
        /// ��2������ӡ
        /// </summary>
        /// <param name="dr"></param>
        private void PrintJ2(DataRow row)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;
            decimal sumje = 0;
            DataTable dt = null;
            bool j2cf = false;
            //1.��ѯҩƷ�����Ϣ
            string strsql = @"SELECT d.DJYP,d.JSYP,d.MZYP,d.JSYPFL,f.SFZH FROM dbo.MZ_CFB AS a JOIN dbo.MZ_CFB_MX AS b ON a.CFID = b.CFID
                                JOIN YP_YPCJD AS c ON b.BM = c.CJID
                                JOIN dbo.YP_YPGGD AS d ON c.GGID = d.GGID
                                JOIN dbo.YY_BRXX as f ON a.BRXXID = f.BRXXID
                                WHERE a.CFID='" + row["cfxh"] + "'";
            dt = InstanceForm.BDatabase.GetDataTable(strsql, 30);
            //2.�ж�ҩƷ�Ƿ��Ǿ���ҩƷ������ҩ��������ڶ����ҩƷ������д�ӡ
            if (dt == null || dt.Rows.Count <= 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i]["JSYPFL"].ToString() == "2")
                {
                    j2cf=true;
                }

            }
            if (j2cf)
            {
                for (int i = 0; i <= rows.Length - 1; i++)
                {
                    myrow = Dset.����.NewRow();
                    myrow["xh"] = Convert.ToInt32(rows[i]["���"]);
                    myrow["ypmc"] = Convert.ToString(rows[i]["Ʒ��"]);
                    myrow["gg"] = Convert.ToString(rows[i]["���"]);
                    myrow["sl"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    myrow["dw"] = Convert.ToString(rows[i]["��λ"]);
                    sumje = sumje + Convert.ToDecimal(Convertor.IsNull(rows[i]["���"], "0"));

                    myrow["pl"] = Convertor.IsNull(rows[i]["Ƶ��"], "");
                    myrow["ysimage"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));

                    myrow["blh"] = Convert.ToString(rows[i]["�����"]);
                    myrow["ypyf"] = Convert.ToString(rows[i]["�÷�"]);
                    myrow["bzl"] = Convertor.IsNull(rows[i]["��ҩ��ע"], "");
                    myrow["fph"] = Convert.ToString(rows[i]["��Ʊ��"]);
                    //myrow["pl"] = Convert.ToString(rows[i]["ʹ��Ƶ��"]);
                    myrow["jl"] = Convert.ToString(Convert.ToDouble(rows[i]["����"]));
                    myrow["jldw"] = Convert.ToString(rows[i]["������λ"]);
                    //myrow["ts"] = Convert.ToDouble(Convertor.IsNull(rows[i]["����"], "0")).ToString();
                    //myrow["jx"] = Convertor.IsNull(rows[i]["����"], "");
                    //if (rows[i]["���־"].ToString() == "1")
                    //{
                    //    yzzh = yzzh + 1;
                    //}
                    //myrow["yzzh"] = yzzh;
                    //myrow["pxxh"] = Convert.ToInt32(Convertor.IsNull(rows[i]["�������"], "0"));
                    //myrow["syjl"] = Convertor.IsNull(rows[i]["��λ���"], "");
                    //myrow["sfrq"] = Convert.ToDateTime(rows[i]["�շ�����"]).ToLongDateString();
                    //myrow["cfrq"] = Convert.ToDateTime(rows[i]["¼������"]).ToLongDateString();
                    //myrow["fzbz"] = rows[i]["���־"].ToString();

                    ////myrow["JTDZ"] = jtdz;
                    ////myrow["LXDH"] = grlxdh;
                    ////myrow["SFZH"] = sfzh;

                    //myrow["bz2"] = Convertor.IsNull(rows[i]["��ע2"], "");
                    //myrow["bz3"] = Convertor.IsNull(rows[i]["��ע3"], "");
                    //myrow["tsyf"] = Convertor.IsNull(rows[i]["tsyf"], "");
                    //myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                    //myrow["image"] = GetImageByte((Convertor.IsNull(rows[i]["ysdm"], "0")));
                    //myrow["hwmc"] = Convertor.IsNull(rows[i]["hwmc"], "");
                    Dset.����.Rows.Add(myrow);
                }
            }

            
            if (Dset.����.Rows.Count <= 0) return;
            ParameterEx[] parameters = new ParameterEx[11];
            parameters[0].Text = "xm";
            parameters[0].Value = Convert.ToString(rows[0]["����"]);
            parameters[1].Text = "xb";
            parameters[1].Value = Convert.ToString(rows[0]["�Ա�"]);
            parameters[2].Text = "nl";
            parameters[2].Value = Convert.ToString(rows[0]["����"]);
            parameters[3].Text = "ks";
            parameters[3].Value = Convert.ToString(rows[0]["����"]).Trim();
            parameters[4].Text = "bq";
            parameters[4].Value = "";
            parameters[5].Text = "ch";
            parameters[5].Value = "";
            parameters[6].Text = "zd";
            parameters[6].Value = Convertor.IsNull(rows[0]["���"], "");
            parameters[7].Text = "hzsfzh";
            parameters[7].Value = dt.Rows[0]["SFZH"].ToString();
            parameters[8].Text = "zyh";
            parameters[8].Value = Convert.ToString(rows[0]["�����"]);
            parameters[9].Text = "rq";
            //parameters[9].Value = DateTime.Now.ToString();
            parameters[9].Value = Convert.ToString(rows[0]["¼������"]);
            parameters[10].Text = "yf";
            parameters[10].Value = sumje;

            bool bview = true;
            if (chkprintview.Checked == true)
                bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.����, Constant.ApplicationDirectory + "\\Report\\MZYF_��ҩ���������嵥.rpt", parameters, bview);
            if (f.LoadReportSuccess)
                f.Show();
            else
                f.Dispose();

        }

        //��ѯ����
        private void txtghxh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                int nkey = Convert.ToInt32(e.KeyChar);
                if (nkey == 13)
                {
                    //if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
                    //{
                    //    if (string.IsNullOrEmpty(_Fyckh))
                    //    {
                    //        MessageBox.Show("��û��ѡ��ҩ����,��ѡ�������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}
                    DataTable mytb = (DataTable)this.myDataGrid1.DataSource;
                    mytb.Rows.Clear();

                    Control control = (Control)sender;
                    ts_mz_brxx.MzGhxx ghxx = null;
                    ts_mz_brxx.MzBrxx brxx = null;

                    string sfrq1 = "";
                    string sfrq2 = "";
                    string fyrq1 = "";
                    string fyrq2 = "";
                    decimal jslsh = Convert.ToDecimal(Convertor.IsNull(txtlsh.Text, "0"));

                    if (rdo1.Checked == true)
                    {
                        sfrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                        sfrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                        fyrq1 = "";
                        fyrq2 = "";
                    }
                    else
                    {
                        sfrq1 = "";
                        sfrq2 = "";
                        fyrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                        fyrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                    }

                    DataTable tb = null;
                    if (control.Name == "txtmzh")
                    {
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0, 0, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0)
                            tbghxx = tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0, 1, InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count == 0)
                        {
                            MessageBox.Show("û���ҵ����ˣ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), ghxx.ghxh, "",
                            "", 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txttmk.Text = "";
                        jslsh = 0;
                        //this.txtghxh.Text="";
                        this.txtfph.Text = "";
                        _textBox = txtmzh;

                    }
                    if (control.Name == "txttmk")
                    {
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));

                        //txttmk.Text = Fun.returnKh(klx, txttmk.Text, InstanceForm.BDatabase);

                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txttmk.Text.Trim(), "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        if (brxx.binid == Guid.Empty)
                        {
                            MessageBox.Show("û���ҵ����ˣ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(brxx.binid, Guid.Empty, "", 0, Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        Guid ghxxid = Guid.Empty;
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            ghxxid = ghxx.ghxh;
                        }
                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            "", 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,
                            Guid.Empty, brxx.binid, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txtfph.Text = "";
                        jslsh = 0;
                        _textBox = txttmk;
                    }
                    if (control.Name == "txtlsh")
                    {
                        //DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, new Guid(Convertor.IsNull(txtghxh.Text, Guid.Empty.ToString())), "", 0, Convert.ToInt16(this.rdols.Checked));
                        //if (tbghxx.Rows.Count == 0) { MessageBox.Show("û���ҵ����ˣ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataRow row = null;
                        //ghxx = new ts_mz_brxx.MzGhxx(row);
                        //brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, 0, "","", Convert.ToInt16(this.rdols.Checked),InstanceForm.BDatabase);

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"), jslsh,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txttmk.Text = "";
                        this.txtfph.Text = "";
                        _textBox = txtlsh;
                    }

                    bool bBMYF = false;
                    if (control.Name == "txtfph")
                    {

                        if (Convertor.IsNumeric(txtfph.Text) == false)
                        {
                            MessageBox.Show("��Ʊ�����������֣�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //δ��ҩ�Ƿ��Ǳ���ҩ����ҩƷ Modify by jchl
                        if (Convert.ToInt16(this.rdo2.Checked) != 1)
                        {
                            string strSql = string.Format(@"select COUNT(1) as Num from MZ_CFB where FPH='{0}' and ZXKS in (841)", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")));
                            int iNum = Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(strSql).ToString());
                            if (iNum > 0)
                            {
                                MessageBox.Show("�÷�Ʊִ�п���Ϊ������ҩ����,���ܷ�ҩ!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                        }

                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        //if (tbghxx.Rows.Count==0){MessageBox.Show("û���ҵ����ˣ�����������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        }



                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"), 0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txttmk.Text = "";
                        jslsh = 0;
                        //this.txtghxh.Text="";
                        _textBox = txtfph;
                    }

                    this.chkall.Checked = false;
                    //if (rdo1.Checked)
                    //{
                    //    //�췢����
                    //    SendClinicInfo(tb);
                    //}

                    this.AddPresc(tb);

                    if (this.rdo1.Checked == true)
                    {
                        if (tb.Rows.Count > 0)
                            this.chkall.Checked = true;
                        else
                            this.chkall.Checked = false;
                    }

                    lblxm.Text = "";
                    lblxb.Text = "";
                    lblnl.Text = "";
                    lblks.Text = "";
                    lblzd.Text = "";
                    if (tb.Rows.Count > 0)
                    {
                        lblxm.Text = tb.Rows[0]["����"].ToString();
                        lblxb.Text = tb.Rows[0]["�Ա�"].ToString();
                        lblnl.Text = tb.Rows[0]["����"].ToString();
                        lblks.Text = tb.Rows[0]["����"].ToString();
                        lblzd.Text = tb.Rows[0]["���"].ToString();

                        firstXm = string.Empty;
                        //setButtionState = 0;
                    }

                    //if ( brxx != null )
                    //{
                    //    this.lblxm.Text = Convertor.IsNull( brxx.���� , "" );
                    //    this.lblxb.Text = Convertor.IsNull( brxx.�Ա� , "" );
                    //    this.lblnl.Text = Convertor.IsNull( brxx.���� , "" );
                    //    this.lblks.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.�Һſ������� , "" );
                    //    this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.������� , "" );
                    //}
                    //else
                    //{
                    //    this.lblxm.Text = "";
                    //    this.lblxb.Text = "";
                    //    this.lblnl.Text = "";
                    //    this.lblks.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.�Һſ������� , "" );
                    //    this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull( ghxx.������� , "" );
                    //}

                    if (tb.Rows.Count != 0 && this.rdo1.Checked == true && s.���﷢ҩ��ť�Ƿ�������ý��� == true)
                        this.butfy.Focus();
                    else
                    {
                        TextBox control1 = (TextBox)sender;
                        control1.SelectAll();
                        control1.Focus();
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtmzh_Move(object sender, System.EventArgs e)
        {
            txtmzh.Focus();
            txtmzh.Select(0, txtmzh.Text.Length);
        }

        private void txtmzh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "txtmzh")
            {
                txtmzh.Focus();
                txtmzh.Select(0, txtmzh.Text.Length);
            }
            if (control.Name == "txttmk")
            {
                txttmk.Focus();
                txttmk.Select(0, txttmk.Text.Length);
            }
            if (control.Name == "txtghxh")
            {
                //txtghxh.Focus();
                //txtghxh.Select(0,txtghxh.Text.Length);
            }
            if (control.Name == "txtfph")
            {
                txtfph.Focus();
                txtfph.Select(0, txtfph.Text.Length);
            }
        }

        private void rdo2_CheckedChanged(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            tb.Rows.Clear();
            this.chkall.Checked = false;
            this.chkall.Enabled = this.rdo1.Checked == true ? true : false;
            this.butfy.Enabled = this.rdo1.Checked == true ? true : false;

            if (rdo2.Checked == true)
                myDataGrid1.TableStyles[0].GridColumnStyles["��ʾ��"].Width = 0;
            else
                myDataGrid1.TableStyles[0].GridColumnStyles["��ʾ��"].Width = 25;
            button_ref_Click(sender, e);

        }

        private void butprinthz_Click(object sender, System.EventArgs e)
        {

        }

        private void Frmcffy_Activated(object sender, System.EventArgs e)
        {
            this.txtmzh.Focus();
            string khjd = ApiFunction.GetIniString("���﷢ҩ", "�������Ȼ�ý���", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (khjd == "true")
                txttmk.Focus();
        }

        private void Frmcffy_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string serverName = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("SERVER_NAME", "NAME", Constant.ApplicationDirectory + "\\ClientConfig.ini");
                string connectionString = WorkStaticFun.GetConnnectionString(ConnectionType.SQLSERVER, serverName);
                //Modify By Tany 2016-02-17
                //�����ĵ�ʱ�������´�����Ϊ���人����ҽԺ�кţ������������ַ�����ڷſ����޸�Update_fyck����
                RelationalDatabase database = FunBase.Database(ConnectionType.SQLSERVER, connectionString);
                MZYF.Update_fyck(IPAddRess, _Fyckh, 0, database);
                database.Dispose();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butqhfyck_Click(object sender, EventArgs e)
        {
            this.Close();
            Frmpyck f = new Frmpyck(_menuTag, _chineseName, _mdiParent);
            f.ShowDialog();
        }


        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butcfcx_Click(sender, null);
        }

        private void txttmk_Enter(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Name == "txtfph")
                chkrq.Checked = false;
            if (control.Name == "txttmk")
            {
                //dtprq1.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).AddDays(-1);
                //dtprq2.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                chkrq.Checked = true;
            }
            if (control.Name == "txtmzh" && rdo2.Checked == true)
                chkrq.Checked = false;
        }

        private void button_ref_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Value = _menuTag.Function_Name.Trim();
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Value = dtprq_ref.Value.ToShortDateString() + "";
                parameters[3].Value = dtprq_ref.Value.ToShortDateString() + "";
                parameters[4].Value = _Fyckh;
                parameters[5].Value = rdodq.Checked == true ? 0 : 1;
                parameters[6].Value = rdo1.Checked == true ? 0 : 1;

                parameters[0].Text = "@functionName";
                parameters[1].Text = "@deptid";
                parameters[2].Text = "@rq1";
                parameters[3].Text = "@rq2";
                parameters[4].Text = "@FYCK";
                parameters[5].Text = "@bk";
                parameters[6].Text = "@fybz";

                DataTable tb = InstanceForm.BDatabase.GetDataTable("sp_yf_select_MZCF_REF", parameters, 30);
                FunBase.AddRowtNo(tb);

                this.dataGridView1.DataSource = tb.DefaultView;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = (DataView)dataGridView1.DataSource;
            if (dataGridView1.CurrentCell == null)
                return;
            if (dv.Table.Rows.Count == 0)
                return;
            this.Cursor = PubStaticFun.WaitCursor();
            //if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
            //{
            //    if (string.IsNullOrEmpty(_Fyckh))
            //    {
            //        MessageBox.Show("��û��ѡ��ҩ����,��ѡ�������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}            
            try
            {
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = rdo1.Checked == true ? 0 : 1;
                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";
                string brxxid = dv[nrow]["brxxid"].ToString();
                string fph = dv[nrow]["��Ʊ��"].ToString();

                sfrq1 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                sfrq2 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                fyrq1 = "";
                fyrq2 = "";

                DataTable tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, txtxm.Text.Trim(), fph, 0,
                     fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                lblxm.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";
                lblks.Text = "";
                lblzd.Text = "";
                if (tb.Rows.Count > 0)
                {
                    lblxm.Text = tb.Rows[0]["����"].ToString();
                    lblxb.Text = tb.Rows[0]["�Ա�"].ToString();
                    lblnl.Text = tb.Rows[0]["����"].ToString();
                    lblks.Text = tb.Rows[0]["����"].ToString();
                    lblzd.Text = tb.Rows[0]["���"].ToString();
                }
                //if (rdo1.Checked)
                //{
                //    //�췢����
                //    SendClinicInfo(tb);
                //}
                this.AddPresc(tb);
                if (rdo1.Checked == true)
                {
                    chkall.Checked = false;
                    chkall.Checked = true;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Frmcffy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                button_ref_Click(sender, e);
            }
            if (e.KeyData == Keys.F9)
            {
                buthj_Click(sender, e);
            }
        }

        private void buthj_Click(object sender, EventArgs e)
        {
            try
            {
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (Convertor.IsNull(_Fyckh, "") == "")
                {
                    MessageBox.Show("��û��ѡ��ҩ����,��ѡ�������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("��ҩ='��' and ypid<>''");
                else
                    selrow = tb.Select("��ҩ='��' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("��ѡ���˴������ٺ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["����"].ToString();// tb.Rows[0]["����"].ToString();��Ϊѡ��Ĳ���

                decimal sumje;
                if (rdo1.Checked == true)
                    sumje = Convert.ToDecimal(tb.Compute("sum(���)", "��ҩ='��'"));
                else
                    sumje = Convert.ToDecimal(tb.Compute("sum(���)", "��ҩ='��'"));

                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    cfmx[i].PM = Convertor.IsNull(selrow[i]["Ʒ��"], "");
                    cfmx[i].GG = Convertor.IsNull(selrow[i]["���"], "");
                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                    cfmx[i].DW = Convertor.IsNull(selrow[i]["��λ"], "0");
                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["���"], "0"));
                    cfmx[i].fyck = _Fyckmc;
                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["����"], "");
                    cfmx[i].fph = Convertor.IsNull(selrow[i]["��Ʊ��"], "");
                }

                //���鴦��
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                string[] GroupbyField ={ "FPID", "����", "��Ʊ��", "�����" };
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                    return;
                }
                string brkh = string.Empty;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[11];
                    parameters[0].Text = "@FPID";
                    parameters[0].DataType = System.Data.DbType.Guid;
                    parameters[0].Value = tbcf.Rows[i]["fpid"].ToString();

                    parameters[1].Text = "@FPH";
                    parameters[1].Value = tbcf.Rows[i]["��Ʊ��"].ToString();

                    parameters[2].Text = "@ZJE";
                    parameters[2].DataType = System.Data.DbType.Decimal;
                    parameters[2].Value = tbcf.Rows[i]["���"].ToString();

                    parameters[3].Text = "@BRXM";
                    parameters[3].Value = tbcf.Rows[i]["����"].ToString();

                    parameters[4].Text = "@BLH";
                    parameters[4].Value = tbcf.Rows[i]["�����"].ToString();
                    brkh = tbcf.Rows[i]["�����"].ToString();

                    parameters[5].Text = "@LYCK";
                    parameters[5].Value = _Fyckh;

                    parameters[6].Text = "@LYCKMC";
                    parameters[6].Value = _Fyckmc;

                    parameters[7].Text = "@DEPTID";
                    parameters[7].DataType = System.Data.DbType.Int32;
                    parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[8].Text = "@DEPTNAME";
                    parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                    parameters[9].Text = "@DJY";
                    parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[10].Text = "@jhlx";
                    parameters[10].Value = "call";

                    int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);

                    if (rdo2.Checked)
                    {
                        break;
                    }
                }

                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    if (!string.IsNullOrEmpty(_Fyckh) && !string.IsNullOrEmpty(brkh) && _call is ts_call_whzxyybymz)
                    {
                        (_call as ts_call_whzxyybymz).Brkh = brkh;
                        (_call as ts_call_whzxyybymz).Qyzt = 1;
                        (_call as ts_call_whzxyybymz).WindowNum = _Fyckh;
                    }

                    Caller call = new Caller(brxm, sumje, cfmx, this._call);
                    thCall = new Thread(new ThreadStart(call.call_hj));
                    call.Thread = thCall;
                    thCall.Start();
                }

                //2013-08-08
                string bqyyy = ApiFunction.GetIniString("��������", "��������", Constant.ApplicationDirectory + "//ClientWindow.ini");
                string byyxh = ApiFunction.GetIniString("��������", "�����ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqyyy == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    ts_VoiceCall.Icall _voiceCaller = ts_VoiceCall.CallFactory.NewCall(byyxh);
                    string ss = "��" + brxm + "��" + _Fyckmc + "��ȡҩ";
                    _voiceCaller.Call(ss);

                    VoiceCaller call = new VoiceCaller(ss, _voiceCaller);
                    thCall = new Thread(new ThreadStart(call.VoiceCall));
                    call.Thread = thCall;
                    thCall.Start();
                    //string strSqlBrxxid = string.Format("select BRXXID from MZ_GHXX where GHXXID='{0}'", inpid);
                    //inpid = InstanceForm.BDatabase.GetDataResult(strSqlBrxxid).ToString();

                    //ClsMzCall.CallInp.CallInpatient(_Fyckmc, brxm, inpid);

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                if (Convert.ToInt64(Convertor.IsNull(dgv.Cells["��ӡ"].Value, "0")) > 0)
                {
                    dgv.DefaultCellStyle.BackColor = Color.SkyBlue;
                }

                if (rdo2.Checked == true)
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
        }

        private void myDataGrid1_BindingContextChanged(object sender, EventArgs e)
        {


        }

        private void myDataGrid1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbyf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptid = Convert.ToInt32(Convertor.IsNull(cmbyf.SelectedValue, "0")); //�ⷿid
            bpcgl = Yp.BPcgl(deptid, InstanceForm.BDatabase);                        //�Ƿ�������ι���
        }

        private int uid_pyr = 0;
        private void cmbpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbpyr.SelectedValue == null || cmbpyr.SelectedValue == DBNull.Value || cmbpyr.SelectedValue.ToString().Equals("-1"))
                    return;

                int uid_sel = Convert.ToInt32(cmbpyr.SelectedValue);//ѡ���û�
                int uid_cur = InstanceForm.BCurrentUser.EmployeeId;//��ǰ�û�
                SystemCfg cfg8059 = new SystemCfg(8059);
                //if (cfg8059.Config == "1")

                if (true)
                {
                    //if (uid_sel != uid_cur && uid_pyr != 0)
                    if (uid_sel != uid_cur)
                    {
                        //��ݵ��ٴ�ȷ��
                        string dlgvalue = Ts_zyys_public.DlgPW.Show();
                        string pwStr = dlgvalue; //YS.Password;

                        string strSql = string.Format("select Id as userid from Pub_User where Employee_Id={0} ", uid_sel);
                        int userid = int.Parse(Convertor.IsNull(InstanceForm.BCurrentUser.Database.GetDataResult(strSql), uid_sel.ToString()));

                        bool bOk = new User(userid, InstanceForm.BDatabase).CheckPassword(pwStr);

                        if (!bOk)
                        {
                            TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbpyr.SelectedValue = "-1";
                            return;
                        }
                    }

                }
                uid_pyr = Convert.ToInt32(cmbpyr.SelectedValue);
            }
            catch { }
        }

        private byte[] GetImageByte(string strEmployeeId)
        {
            string ss = "select sign from JC_EMPLOYEE_PROPERTY where EMPLOYEE_ID=" + strEmployeeId + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ss);
            if (tb == null || tb.Rows.Count == 0 || tb.Rows[0]["sign"].GetType().ToString() == "System.DBNull")
                return null;
            else
                return ((byte[])tb.Rows[0]["sign"]);
        }


        #region ����췢����
        /// <summary>
        ///ClientWindow.ini���ÿ췢������
        /// </summary>
        /// <returns></returns>
        private bool IsVisable()
        {
            string strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("ҩ���췢����", "����", Application.StartupPath + "\\ClientWindow.ini");
            if (string.IsNullOrEmpty(strVal))
                TrasenClasses.GeneralClasses.ApiFunction.WriteIniString("ҩ���췢����", "����", "", Application.StartupPath + "\\ClientWindow.ini");
            strVal = TrasenClasses.GeneralClasses.ApiFunction.GetIniString("ҩ���췢����", "����", Application.StartupPath + "\\ClientWindow.ini");
            return strVal == "1" ? true : false;
        }


        /// <summary>
        /// ������ʼ���� 
        /// </summary>
        /// <param name="tbInfo"></param>
        /// <param name="strWinid">���ں�</param>
        /// <param name="strManno">����Ա</param>
        /// <param name="strManname">����Ա���</param>
        /// <param name="strIP">IP��ַ</param>
        private int SendClinicInfo(DataTable tbInfo, string brxm, string brxxid, string str_HH_Flag)
        {
            //���ں�/����Ա���/����Ա/IP��ַ
            int ret = 0;
            string retMsg = string.Empty;
            try
            {
                if (bqyyfkf)
                {
                    if (kf != null)
                    {
                        kf.DataBase = InstanceForm.BDatabase;
                        kf.Brxm = brxm;
                        kf.Brxxid = brxxid;
                        ret = kf.SendMedicine(tbInfo, this._Fyckh, InstanceForm.BCurrentUser.EmployeeId.ToString(), InstanceForm.BCurrentUser.Name.Trim(), this.IPAddRess, InstanceForm.BCurrentDept.DeptId, str_HH_Flag);

                        if (ret == 200) //�˴�����ֵ?
                        {
                            MessageBox.Show("��ҩ��������ҩ��,���Ժ�!", "��ʾ");
                            return 0;
                        }
                    }
                    else
                    {

                        retMsg = "kfΪNULL,����δ����SendMedicine�ӿ�";
                    }
                }
                else
                {
                    retMsg = "�Ƿ����ÿ췢��ҩ��bqyyfkf����Ϊfalse,����δ����SendMedicine�ӿ�";
                }


                if (!string.IsNullOrEmpty(retMsg))
                {
                    ThrowTechError(retMsg, 1, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
                }
            }
            catch (Exception err)
            {
                retMsg = string.Format("ִ��SendClinicInfo���������쳣:{0}", err.Message);
                ThrowTechError(retMsg, 1, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
            }
            return ret;
        }

        /// <summary>
        /// ����������ҩ
        /// </summary>
        /// <param name="tbInfo"></param>
        private string EndClinicInfo(DataTable tbInfo, string brxm, string brxxid, string str_HH_Flag)
        {
            string retMsg = string.Empty;
            string ret = "0";
            try
            {
                if (kf != null)
                {
                    if (bqyyfkf)
                    {
                        kf.DataBase = InstanceForm.BDatabase;
                        kf.Brxm = brxm;
                        kf.Brxxid = brxxid;
                        ret = kf.EndToMedicine(tbInfo, this._Fyckh, InstanceForm.BCurrentUser.EmployeeId.ToString(), InstanceForm.BCurrentUser.Name.Trim(), this.IPAddRess, InstanceForm.BCurrentDept.DeptId, str_HH_Flag);

                        string msg = string.Empty;

                        if (ret == "101") //���صĲ���ֵ��
                            msg = "�������Ϊ��!";
                        else if (ret == "102" || ret == "103")
                            msg = "cfid��Ӧwhzxyy_mz_cfb_zb����Ϊ��";

                        if (string.IsNullOrEmpty(msg)) //���û���쳣  update code  py  2016-7-5
                        {
                            if (!string.IsNullOrEmpty(ret) && ret.Contains(","))
                            {
                                return ret;
                            }
                        }
                    }
                    else
                    {
                        retMsg = "������ҩʱbqyyfkf����Ϊfalse,����δ����EndToMedicine�ӿ�";
                    }
                }
                else
                {
                    retMsg = "kfΪNULL,����δ����EndToMedicine�ӿ�";
                }

                if (!string.IsNullOrEmpty(retMsg))
                {
                    ThrowTechError(retMsg, 2, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
                }
            }
            catch (Exception err)
            {
                retMsg = string.Format("ִ��EndClinicInfo���������쳣:{0}", err.Message);
                ThrowTechError(retMsg, 2, new List<string>(), _Fyckh, this.WanIp, brxm, brxxid);
            }
            return ret;
        }

        /// <summary>
        /// ��¼����ļ�¼��־
        /// </summary>
        /// <param name="error"></param>
        /// <param name="type"></param>
        /// <param name="cfList"></param>
        /// <param name="fyckh"></param>
        /// <param name="execIp"></param>
        /// <param name="Brxm"></param>
        /// <param name="Brxxid"></param>
        void ThrowTechError(string error, int type, List<string> cfList, string fyckh, string execIp, string Brxm, string Brxxid)
        {
            if (kf != null && kf is ts_whzxyy_mzkf)
            {
                string remark = string.Empty;
                object[] param = null;
                try
                {
                    string ErrPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, "����췢��־");
                    if (!Directory.Exists(ErrPath))
                    {
                        Directory.CreateDirectory(ErrPath);
                    }
                    StreamWriter txtWriter = new StreamWriter(string.Format(@"{0}\{1}-log.txt", ErrPath, DateTime.Now.ToString("yyyy-MM-dd")), true);
                    param = new object[] { Brxm ?? "",
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                   type == 1 ? "��ʼ��ҩ" : "������ҩ", 
                                   type == 1 ? "sendMedToWillach" : "endSendMedToWillach", 
                                   error };
                    remark = string.Format("{0}��{1}{2},���û���{3}�ӿڷ���:{4}", param);
                    txtWriter.WriteLine(remark);
                    if (cfList != null && cfList.Count > 0)
                    {
                        foreach (string s in cfList)
                            txtWriter.WriteLine(s);
                    }
                    txtWriter.WriteLine();
                    txtWriter.Close();
                }
                catch
                {
                    MessageBox.Show("������־��¼ʧ��!", "��ʾ");
                }

                try
                {
                    param = new object[] { Guid.NewGuid().ToString(), Brxxid, Brxm, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), type, error, remark, execIp, string.IsNullOrEmpty(fyckh) ? "Null" : fyckh, InstanceForm.BCurrentDept.DeptId };
                    string sql = string.Format(@"insert into mz_mzkflog(ID,BRXXID,BRXM,CREATEDATE,KFTYPE,EXECRESULT,REMARK,EXECIP,FYCKH,DEPTID) VALUES(
                               '{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},{9})", param);
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch (Exception err)
                {
                    MessageBox.Show(string.Format("���ݿ���־��¼ʧ��!{0}", err.Message), "��ʾ");
                }
            }
        }

        private string WanIp
        {
            get
            {
                try
                {
                    System.Net.IPAddress addr;
                    addr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                    return addr.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


        #endregion

        /// <summary>
        /// �����ҩ��ť������ҩ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPy_Click(object sender, EventArgs e)
        {
            if (rdo1.Checked == false)
            {
                MessageBox.Show("ֻ�ܶ�δ��ҩ�Ĳ�����ҩ!");
                return;
            }
            if (rdo1.Checked && bqyyfkf && !string.IsNullOrEmpty(kflx))
            {
                if (string.IsNullOrEmpty(_Fyckh))
                {
                    MessageBox.Show("��û��ѡ��ҩ����,��ѡ�������", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DataTable tb = myDataGrid1.DataSource as DataTable;
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("û���ҵ����˼�������Ϣ", "��ʾ");
                return;
            }
            object objXm = tb.Rows[0]["����"] ?? "";
            object objbrxxid = InstanceForm.BDatabase.GetDataResult("select BRXXID from MZ_GHXX where GHXXID='" + tb.Rows[0]["patid"].ToString() + "' ");
            string brxm = objXm.ToString();
            string brxxid = objbrxxid != null ? objbrxxid.ToString() : "";
            string msg = string.Format("ȷ��ҪΪ{0}ִ����ҩ������", brxm);
            this.Cursor = PubStaticFun.WaitCursor();

            //Add by zhujh 2017-05-27 ������ʱ��ؿ�ʼ
          //  ExecTimeLogger logger = ExecTimeLogger.Run("ҩ����ҩ");

            try
            {
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = rdo1.Checked == true ? 0 : 1;
                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";
                string fph = ""; //tb.Rows[0]["��Ʊ��"].ToString();

                sfrq1 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                sfrq2 = chkrq.Checked == true ? dtprq_ref.Value.ToShortDateString() : "";
                fyrq1 = "";
                fyrq2 = "";

                int num = 0;
                DataTable table = null;
            Label001:
                {

                    table = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, txtxm.Text.Trim(), fph, 0, fyrq1, fyrq2, 0, fybz,
                        "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, new Guid(brxxid), Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                }

                if (rdo1.Checked)
                {
                    if (num <= 3)
                    {
                        if (table == null || table.Rows.Count == 0)
                        {
                            num++;
                            Thread.Sleep(2000);
                            goto Label001;
                        }
                    }
                    // �췢��ҩ
                    //Add by zhujh 2017-05-27 ������ʱ��ؿ�ʼ
                    //ExecTimeLogger logger = ExecTimeLogger.Run("ҩ����ҩ");
                    //��Ժ��Ժʹ����ͬ����췢

                    string str_HHkf_settingValue = ApiFunction.GetIniString("ҩ���췢����", "����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    string str_HH_Flag = "";
                    if (str_HHkf_settingValue.Equals("��Ժʹ����Ժ��ͬ����췢"))
                    {
                        str_HH_Flag = "1";
                    }

                    int ret = SendClinicInfo(table, brxm, brxxid, str_HH_Flag);

                    //Add by zhujh 2017-05-27 ������ʱ��ؽ���
                    //logger.Stop();

                    if (ret == 0)
                    {
                        MessageBox.Show("ҩƷ�췢��ҩδ�ɹ���");
                    }
                    if (ret == 1)
                    {
                       //  MessageBox.Show("ҩƷ�췢��ҩ�ɹ���");
                    }
                    if (ret == 2)
                    {
                        MessageBox.Show("ҩƷ�췢δ�ҵ�������");
                    }
                    if (ret == 3)
                    {
                        MessageBox.Show("ҩƷ�췢�Ѿ������ҩ��");
                    }
                    if (ret == 4)
                    {
                        MessageBox.Show("ҩƷ�췢�Ѿ������ҩ��");
                    }
                    if (ret == 5)
                    {
                        MessageBox.Show("���մ������뷢�����µ���ָ�");
                    }
                }

                lblxm.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";
                lblks.Text = "";
                lblzd.Text = "";
                if (table.Rows.Count > 0)
                {
                    lblxm.Text = table.Rows[0]["����"].ToString();
                    lblxb.Text = table.Rows[0]["�Ա�"].ToString();
                    lblnl.Text = table.Rows[0]["����"].ToString();
                    lblks.Text = table.Rows[0]["����"].ToString();
                    lblzd.Text = table.Rows[0]["���"].ToString();
                }
                this.AddPresc(table);
                if (rdo1.Checked == true)
                {
                    chkall.Checked = false;
                    chkall.Checked = true;
                }

                //CallNumber(1);

                //Modify by Zhujh 2017-02-15
                /*
                #region ������ӡ
                string pydy = ApiFunction.GetIniString("��Ժʵʱ���ڴ�ӡ", "������ҩʱ��ӡ", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (InstanceForm.BCurrentDept.DeptId == 207)
                {
                    if (!string.IsNullOrEmpty(pydy) && Convert.ToBoolean(pydy))
                    {
                        string sql = string.Format("select kh from YY_KDJB where brxxid = '{0}'", brxxid);
                        DataTable brxxTable = InstanceForm.BDatabase.GetDataTable(sql);
                        string kh = string.Empty;
                        if (brxxTable != null && brxxTable.Rows.Count > 0)
                        {
                            kh = brxxTable.Rows[0][0].ToString().Trim();
                            string resultMsg = string.Empty;

                            ts_PrintProcess.PrescriptionPrint p = new ts_PrintProcess.PrescriptionPrint();
                            p.Print(kh, InstanceForm.BCurrentDept.DeptId, out resultMsg);
                        }
                    }
                }
                #endregion
                */
                //Add by zhujh 2017-05-27 ������ʱ��ؿ�ʼ
                //ExecTimeLogger logger2 = ExecTimeLogger.Run("ҩ����ҩ��ӡ");

                //��ӡ���� Modify by Zhujh 2017-02-15
                this.butprint_Click(sender, e);

                //Add by zhujh 2017-05-27 ������ʱ��ؽ���
                //logger2.Stop();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }



        /// <summary>
        /// �к�
        /// </summary>
        /// <param name="Qyzt">1���� 2�����ʾ��</param>
        private void CallNumber(int Qyzt)
        {
            if (_call is ts_call_whzxyybymz)
            {
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (Convertor.IsNull(_Fyckh, "") == "")
                {
                    return;
                }
                DataTable rettable = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = rettable.Select("��ҩ='��' and ypid<>''");
                else
                    selrow = rettable.Select("��ҩ='��' and ypid<>''");

                if (selrow.Length == 0)
                {
                    return;
                }
                string brName = selrow[0]["����"].ToString();// tb.Rows[0]["����"].ToString();��Ϊѡ��Ĳ���
                decimal sumje;
                if (rdo1.Checked == true)
                    sumje = Convert.ToDecimal(rettable.Compute("sum(���)", "��ҩ='��'"));
                else
                    sumje = Convert.ToDecimal(rettable.Compute("sum(���)", "��ҩ='��'"));

                ts_call.CFMX[] cfmx = new ts_call.CFMX[selrow.Length];
                for (int i = 0; i <= selrow.Length - 1; i++)
                {
                    cfmx[i].PM = Convertor.IsNull(selrow[i]["Ʒ��"], "");
                    cfmx[i].GG = Convertor.IsNull(selrow[i]["���"], "");
                    cfmx[i].DJ = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                    cfmx[i].SL = Convert.ToDecimal(Convertor.IsNull(selrow[i]["����"], "0"));
                    cfmx[i].DW = Convertor.IsNull(selrow[i]["��λ"], "0");
                    cfmx[i].JE = Convert.ToDecimal(Convertor.IsNull(selrow[i]["���"], "0"));
                    cfmx[i].fyck = _Fyckmc;
                    cfmx[i].deptid = InstanceForm.BCurrentDept.DeptId;
                    cfmx[i].brxm = Convertor.IsNull(selrow[i]["����"], "");
                    cfmx[i].fph = Convertor.IsNull(selrow[i]["��Ʊ��"], "");
                }

                //���鴦��
                DataTable tbsel = rettable.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);
                string[] GroupbyField ={ "FPID", "����", "��Ʊ��", "�����" };
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    //MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");
                    return;
                }

                string brkh = string.Empty;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    ParameterEx[] parameters = new ParameterEx[11];
                    parameters[0].Text = "@FPID";
                    parameters[0].DataType = System.Data.DbType.Guid;
                    parameters[0].Value = tbcf.Rows[i]["fpid"].ToString();

                    parameters[1].Text = "@FPH";
                    parameters[1].Value = tbcf.Rows[i]["��Ʊ��"].ToString();

                    parameters[2].Text = "@ZJE";
                    parameters[2].DataType = System.Data.DbType.Decimal;
                    parameters[2].Value = tbcf.Rows[i]["���"].ToString();

                    parameters[3].Text = "@BRXM";
                    parameters[3].Value = tbcf.Rows[i]["����"].ToString();

                    parameters[4].Text = "@BLH";
                    parameters[4].Value = tbcf.Rows[i]["�����"].ToString();
                    brkh = tbcf.Rows[i]["�����"].ToString();

                    parameters[5].Text = "@LYCK";
                    parameters[5].Value = _Fyckh;

                    parameters[6].Text = "@LYCKMC";
                    parameters[6].Value = _Fyckmc;

                    parameters[7].Text = "@DEPTID";
                    parameters[7].DataType = System.Data.DbType.Int32;
                    parameters[7].Value = InstanceForm.BCurrentDept.DeptId;

                    parameters[8].Text = "@DEPTNAME";
                    parameters[8].Value = InstanceForm.BCurrentDept.DeptName;

                    parameters[9].Text = "@DJY";
                    parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId;

                    parameters[10].Text = "@jhlx";
                    parameters[10].Value = "call";

                    int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);

                    if (rdo2.Checked)
                    {
                        break;
                    }
                }

                if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
                {
                    if (!string.IsNullOrEmpty(_Fyckh) && !string.IsNullOrEmpty(brkh) && _call is ts_call_whzxyybymz)
                    {
                        (_call as ts_call_whzxyybymz).Brkh = brkh;
                        (_call as ts_call_whzxyybymz).Qyzt = Qyzt;
                        (_call as ts_call_whzxyybymz).WindowNum = _Fyckh;

                        Caller call = new Caller(brName, sumje, cfmx, this._call);
                        thCall = new Thread(new ThreadStart(call.call_hj));
                        call.Thread = thCall;
                        thCall.Start();
                    }
                }
            }
        }

        private void myDataGrid1_DataSourceChanged(object sender, EventArgs e)
        {
            firstXm = string.Empty;
            //setButtionState = 0;
        }

        private void btnhqcf_Click(object sender, EventArgs e)
        {
            if (txttmk.Text.Trim() == string.Empty)
            {
                MessageBox.Show("�����벡�˿���!");
                return;
            }
            if (txtfph.Text.Trim() == string.Empty)
            {
                MessageBox.Show("�����뷢Ʊ��!");
                return;
            }


            //ԭ���ķ���
            #region ԭ���ķ���
            /*
            string postString = string.Format(@"<examReqInfoType><examReqId>{0}</examReqId><id>{1}</id></examReqInfoType>", txtfph.Text.Trim(), txttmk.Text.Trim());
            TrasenWs.TrasenWS ws = new ts_yf_mzfy.TrasenWs.TrasenWS();
            string reslut = ws.ExeWebService("SaveMzcf", postString);
            if (!string.IsNullOrEmpty(reslut))
            {
                if (reslut.Contains("�ظ���"))
                {
                    //MessageBox.Show("�ò��˴�����Ϣ�Ѵ���!");
                    // exec SP_WHZXYY_mz_cfb '368100012696', @errcode output, @errtext output,905466454  

                    ParameterEx[] parameters1 = new ParameterEx[3];

                    parameters1[0].Text = "@err_code";
                    parameters1[0].ParaDirection = ParameterDirection.Output;
                    parameters1[0].DataType = System.Data.DbType.Int32;
                    parameters1[0].ParaSize = 100;

                    parameters1[1].Text = "@err_text";
                    parameters1[1].ParaDirection = ParameterDirection.Output;
                    parameters1[1].ParaSize = 100;

                    parameters1[2].Text = "@id";
                    parameters1[2].Value = txttmk.Text.Trim();
                    int ret = InstanceForm.BDatabase.DoCommand("SP_WHZXYY_mz_brxx", parameters1, 30);

                    ParameterEx[] parameters = new ParameterEx[4];
                    parameters[0].Text = "@jsdjh";
                    parameters[0].Value = txtfph.Text.Trim();

                    parameters[1].Text = "@err_code";
                    parameters[1].ParaDirection = ParameterDirection.Output;
                    parameters[1].DataType = System.Data.DbType.Int32;
                    parameters[1].ParaSize = 100;

                    parameters[2].Text = "@err_text";
                    parameters[2].ParaDirection = ParameterDirection.Output;
                    parameters[2].ParaSize = 100;

                    parameters[3].Text = "@id";
                    parameters[3].Value = txttmk.Text.Trim();
                    ret = InstanceForm.BDatabase.DoCommand("SP_WHZXYY_mz_cfb", parameters, 30);
                    if (ret <= 0)
                        MessageBox.Show("�ò��˴�����Ϣ�Ѵ���!");
                    else
                        MessageBox.Show("�����ɹ�!");
                }
                else if (reslut.Contains("����ɹ�"))
                    button_ref_Click(button_ref, new EventArgs());
            }
            */
            
            #endregion

            //����ӵĻ�ȡ��ϵͳ�����ķ���

            #region ����ӵĻ�ȡ��ϵͳ�����ķ��� Add By HYD 2017-11-20
            
            YFZLWebSevice.TrasenWS ws = new ts_yf_mzfy.YFZLWebSevice.TrasenWS();
            string reslut = ws.ExeWebService("v3tv2PrescInfoForDrugDirect", txtfph.Text.Trim());
            if (!string.IsNullOrEmpty(reslut))
            {
                MessageBox.Show(reslut);
            }
             
            #endregion 


        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ts_ReadCard.ICard iCard = ts_ReadCard.CardFactory.CreateInstance(ts_ReadCard.CardType.�人����ҽԺ���񽡿���, null);
            if (iCard != null)
            {
                object obj = iCard.ReadCard(null);
                txttmk.Text = obj != null ? obj.ToString() : string.Empty;
            }
            if (txttmk.Text.Trim() != string.Empty)
                txtghxh_KeyPress(txttmk, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void Frmcffy_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Frmcffy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                btnPy_Click(null, null);
            }
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        //Add by jchl����������ҩ�����ݷ�ҩ�����˴�����
        private DataTable DoFilFylb(DataTable tb)
        {
            try
            {
                //Modify by jchl��������ҩ�����ݷ�ҩ�����ж�-1��ȫ��  1����ҩ����ҩ  2���÷�(ˮ���)��ҩ(����)���ˡ�
                DataTable dtCffy = tb.Clone();
                if (cmbFylb.SelectedValue.ToString().Trim().Equals("1"))
                {
                    DataRow[] drs = tb.Select("�÷�<>'����'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("2"))
                {
                    // 
                    DataRow[] drs = tb.Select("�÷�='����'");

                    for (int i = 0; i < drs.Length; i++)
                    {
                        dtCffy.Rows.Add(drs[i].ItemArray);
                    }
                }
                else if (cmbFylb.SelectedValue.ToString().Trim().Equals("-1"))
                {
                    return tb;
                }

                return dtCffy;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ת��13���ڳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFpCk_Click(object sender, EventArgs e)
        {
            //δ��ҩ��ťѡ����
            if (rdo1.Checked == true)
            {
                DataTable tb = (DataTable)this.myDataGrid1.DataSource; //������ϸ����

                // this.Cursor = PubStaticFun.WaitCursor();
                //���鴦��
                DataRow[] selrow = tb.Select("��ҩ='��' and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);


                string[] GroupbyField ={ "jssjh", "��Ʊ��", "�ܽ��", "���ʽ��", "�Żݽ��", "�Ը����", "cfxh", "patid", "�����", "����", "ysdm", "ksdm", "�շ�����", "sfczy", "��ҩ����" };
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum" };
                DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                if (tbcf.Rows.Count == 0)
                {
                    MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼��Ҫ��תһ¥ҩ�����ڡ�ȡҩ��");
                    // SetDefaultFocuse();
                    return;
                }

                if (MessageBox.Show("�Ƿ�תһ¥ҩ�����ڡ�ȡҩ��", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    // SetDefaultFocuse();
                    return;
                }

                //ת��һ¥ҩ��
                Hashtable ht = new Hashtable();
                string str_Fphtemp = "";
                string str_Fph = "";
                if (tbcf.Rows.Count > 0)
                {
                    str_Fphtemp = tbcf.Rows[0]["��Ʊ��"].ToString();
                    ht.Add(0, str_Fphtemp);
                }
                for (int i = 0; i < tbcf.Rows.Count; i++)
                {
                    str_Fph = tbcf.Rows[i]["��Ʊ��"].ToString();
                    if (i > 0)
                    {
                        if (!str_Fphtemp.Equals(str_Fph))
                        {
                            str_Fphtemp = str_Fph;
                            ht.Add(i, str_Fph);
                        }
                    }
                }

              //  WebOldHisService.n_yygh oldhisSer = new WebOldHisService.n_yygh();//������ϵͳ�ṩ��WebService ���� add by HYD 2016-09-12
               // TrasenWs.TrasenWS ws = new ts_yf_mzfy.TrasenWs.TrasenWS(); // Add BY HYD 2017-08-18 ������ϵͳ�շ�
               
                KFCommSer.WebService ws = new ts_yf_mzfy.KFCommSer.WebService();
                string WinNo = string.Empty;

                foreach (DictionaryEntry de in ht)
                {
                    string strerr = "";
                   // string strMess = oldhisSer.mzjs_get_fyckh(de.Value.ToString(), "001", ref strerr);
                   //string strMess = ws.ExeWebService("GetKF_FYCKH", de.Value.ToString());//ͨ����Ʊ�ŵõ��շ�ʱ�Ŀ췢���ں� Add BY HYD 2017-08-18 ������ϵͳ�շ�

                    //<message><code>200</code><msg>15</msg></message>

                    //�����µķ��񷽷�������Ժ�췢201����
                    string str_KFComm = "<root><AreaId>" + "1001" + "</AreaId><SerialNo>" + de.Value.ToString() + "</SerialNo><UserID>" + InstanceForm.BCurrentUser.EmployeeId.ToString() + "</UserID></root>";
                    string strMess = ws.ExecuteWS("Execute_201", str_KFComm);// Add BY HYD 2017-09-27                   

                    System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                    document.LoadXml(strMess);
                    System.Xml.XmlNode ndCode = document.SelectSingleNode("message/msg");
                    WinNo = ndCode.InnerText;

                    if (WinNo.Length > 0)
                    {
                        try
                        {
                            int tmp = int.Parse(WinNo);

                            if (tmp > 0)
                            {
                                MessageBox.Show("���֪���˵�һ¥��" + tmp + "������ȡҩ��");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("�췢���񷵻ص����ݲ���ȷ��");
                        }
                    }

                }
                //ת��13���ڷ�ҩ��ʾ
                /* string err = "";
                 * string str_Fph=tbcf.Rows[i]["��Ʊ��"].ToString();
                 WebReference.n_yygh p = new WebReference.n_yygh();
                 string s1 = p.mzjs_get_fyckh("637100001772", "001", ref err);
                 *  MessageBox.Show(s1);
                 //Response.Write(s1); */
            }
            else
            {
                MessageBox.Show("ֻ��ѡ��δ��ҩ���Ķ��н���ת�����ڷ�ҩ��");
            }

            #region ԭ��ת��13���ڵĳ���
            /****************************������ԭ���ķ���************************************************************
            ////д��13
            ////��ҩ����
            DataTable tb = (DataTable)this.myDataGrid1.DataSource; //������ϸ����

            this.Cursor = PubStaticFun.WaitCursor();
            //���鴦��
            DataRow[] selrow = tb.Select("��ҩ='��' and ypid<>''");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);

            //string[] GroupbyField ={"jssjh","��Ʊ��","�ܽ��","���ʽ��","�Żݽ��","�Ը����","����","cfxh","patid","�����","����","ysdm","ksdm","�շ�����","sfczy","��ҩ����"};
            string[] GroupbyField ={ "jssjh", "��Ʊ��", "�ܽ��", "���ʽ��", "�Żݽ��", "�Ը����", "cfxh", "patid", "�����", "����", "ysdm", "ksdm", "�շ�����", "sfczy", "��ҩ����" };
            string[] ComputeField ={ "���" };
            string[] CField ={ "sum" };
            DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            if (tbcf.Rows.Count == 0)
            {
                MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼��Ҫ��ת13��ҩ���ڡ�");
                SetDefaultFocuse();
                return;
            }

            if (MessageBox.Show("�Ƿ�ת13�Ŵ��ڡ���ҩ��", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                SetDefaultFocuse();
                return;
            }

            InstanceForm.BDatabase.BeginTransaction();

            try
            {
                for (int i = 0; i < tbcf.Rows.Count; i++)
                {
                    string cfid = tbcf.Rows[i]["cfxh"].ToString();
                    string ssql = string.Format(@"update MZ_CFB set FYCK='{0}' where CFID='{1}'", 13, cfid);
                    InstanceForm.BDatabase.DoCommand(ssql);                 


                }

                //�ύ����
                InstanceForm.BDatabase.CommitTransaction();

                MessageBox.Show("�����ɹ�", "��ҩ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                InstanceForm.BDatabase.RollbackTransaction();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                SetDefaultFocuse();
            }
            **********************************************************/
            #endregion
        }

        #region IMessageFilter ��Ա

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 522)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void btnOver_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentDept.DeptId != 417)
                {
                    MessageBox.Show("��δ���Ŵ˹���");
                    return;
                }

                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("��ҩ='��' and ypid<>''");
                else
                    selrow = tb.Select("��ҩ='��' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("��ѡ���˴������ٺ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["����"].ToString();// tb.Rows[0]["����"].ToString();��Ϊѡ��Ĳ���
                string ip = PubStaticFun.GetIPAddress();//webserviceд��  �в�ҩ��ǰ�û�
                string type = "0";

                ClsMzCall.ClsMzZcyCall.CallInpatient(brxm, inpid, ip, type);
            }
            catch
            { }
        }

        private void btnCancerOver_Click(object sender, EventArgs e)
        {
            try
            {
                if (InstanceForm.BCurrentDept.DeptId != 417)
                {
                    MessageBox.Show("��δ���Ŵ˹���");
                    return;
                }

                DataTable tb = (DataTable)myDataGrid1.DataSource;
                DataRow[] selrow;
                if (rdo1.Checked == true)
                    selrow = tb.Select("��ҩ='��' and ypid<>''");
                else
                    selrow = tb.Select("��ҩ='��' and ypid<>''");

                if (selrow.Length == 0)
                {
                    MessageBox.Show("��ѡ���˴������ٺ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inpid = selrow[0]["PATID"].ToString();//ghxxid
                string brxm = selrow[0]["����"].ToString();// tb.Rows[0]["����"].ToString();��Ϊѡ��Ĳ���
                string ip = PubStaticFun.GetIPAddress();//webserviceд���в�ҩ��ǰ�û�
                string type = "1";

                ClsMzCall.ClsMzZcyCall.CallInpatient(brxm, inpid, ip, type);
            }
            catch
            { }
        }

        /// <summary>
        /// ��ȡά����ҩƷƷ���б�
        /// </summary>
        private DataTable GetYpCjidList()
        {
            string strSql = "SELECT cjid FROM V_MZFY_PM ";
            return InstanceForm.BDatabase.GetDataTable(strSql);
        }

        /// <summary>
        /// ��ȡά�����÷��б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetYpYFList()
        {
            string strSql = "SELECT yf FROM V_MZFY_YF ";
            return InstanceForm.BDatabase.GetDataTable(strSql);
        }

        public string get_fy_YPID_All()
        {
            DataTable tb = (DataTable)this.myDataGrid1.DataSource; //������ϸ����
            DataRow[] selrow = tb.Select("��ҩ='��' and ypid<>''");
            DataTable tbsel = tb.Clone();
            for (int w = 0; w <= selrow.Length - 1; w++)
                tbsel.ImportRow(selrow[w]);
            string str_ypid = string.Empty;
            string str_tmpid = string.Empty;


            if (tbsel.Rows.Count > 0)
            {
                for (int m = 0; m < tbsel.Rows.Count; m++)
                {
                    str_ypid = tbsel.Rows[m]["YPID"].ToString();
                    str_tmpid += str_ypid + ",";
                }

                str_tmpid = str_tmpid.Substring(0, str_tmpid.Length - 1);  
            }

            str_ypid = str_tmpid;
            return str_ypid;
        }


        /// <summary>
        /// Ϊ����ϳ���ʦ��������ʦҪ��˴��ӿ췢��ȡ����
        /// </summary>
        /// <param name="str_CFXH"></param>
        /// <returns></returns>
        public string GetKF_NY_HH_PYR(string str_CFXH)
        {
            string str_Pyr = string.Empty;//��ҩԱ

            //��Ժһ¥ҩ���뱱Ժһ¥ҩ��ʱ�ӿ췢��ȡ����,����ҩ���ӽ�����ȡ��ҩ��   add by hyd 2017-11-30 �췢����Ӧ��Ϣ��Ҫ��
            if (("207,424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
            {

                SqlConnection conn = null;
                SqlCommand cmd = null;
                DataTable dt = new DataTable();
                string str_SQL = "";
                if (("424").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                {
                    //�����Ͼ�·��
                    conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.0.44;database=Mis9whszxyybyDB");
                    str_SQL = string.Format(@"select winno, presc_no, patient_id, patient_name, opmanuserno2, opman2, processdate2 from 
                                              dbo.HIS_CONSIS_PRESC_FINISHOPMAN2VW where presc_no='{0}';", str_CFXH);
                    cmd = new SqlCommand(str_SQL, conn);
                }

                if (("207").Contains(InstanceForm.BCurrentDept.DeptId.ToString()))
                {
                    //���ʺ����
                    conn = new SqlConnection("uid=Led;pwd=Led;server=192.168.100.171;database=Mis9whzxyyhhDB");
                    str_SQL = string.Format(@"select winno, presc_no, patient_id, patient_name, opmanuserno2, opman2, processdate2 from 
                                              dbo.HIS_CONSIS_PRESC_FINISHOPMAN2VW where presc_no='{0}';", str_CFXH);
                    cmd = new SqlCommand(str_SQL, conn);
                }
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        str_Pyr = dt.Rows[0]["opmanuserno2"].ToString();//��ҩԱID
                        if (str_Pyr == "")
                        {
                            str_Pyr = cmbpyr.SelectedValue.ToString();//�������촦��ʱ����ҩ�˴ӽ�����ȡֵ����Ϊ�췢ֻ����һ�������
                        }

                    }
                    else
                    {                        
                        str_Pyr = cmbpyr.SelectedValue.ToString();//�������촦��ʱ����ҩ�˴ӽ�����ȡֵ����Ϊ�췢ֻ����һ�������
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            else
            {
                str_Pyr = cmbpyr.SelectedValue.ToString();//�����������ҽ��з�ҩʱ����ҩ���Ǵӽ�����ȡֵ
            }
            return str_Pyr;
        }


        private void Add_DJJKKXX_ToEventLogMZ(string strPATID,string strGHXXID)
        {
            DataTable tab_DJJK = null;
            bool str_Flag = false;
            string str_ZFZH = "";//���֤��
            string str_KH = "";//���˿���

            //ͨ��������ϢID�ҵ�������û�е��ӽ�����
            string sql = string.Format(@"select KH,SFZH from YY_KDJB AS A INNER JOIN YY_BRXX AS B ON A.BRXXID=B.BRXXID where A.KLX=8 and A.BRXXID='{0}'  order by A.DJSJ DESC ", strPATID);

            try
            {
                tab_DJJK = InstanceForm.BDatabase.GetDataTable(sql);
                if (tab_DJJK != null && tab_DJJK.Rows.Count > 0)
                {
                    //��ʾ�����е��ӽ���������
                    str_Flag = true;
                    str_ZFZH = tab_DJJK.Rows[0]["SFZH"].ToString();//�������֤��
                    str_KH = tab_DJJK.Rows[0]["KH"].ToString();//���˵��ӽ�������

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("���ӽ��������ݿ���Ϣ��ѯʧ��!{0}", err.Message), "��ʾ");
            }

            if (str_Flag)
            {
                try
                {

                   // sql = string.Format(@"insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID)  VALUES('{0}','{1}','{2}')", "DJJKKMZFYXX.HIS", "YF_FY", str_ZFZH);
                    sql = string.Format(@"insert into EVENTLOG_MZ(EVENT,CATEGORY,BIZID)  VALUES('{0}','{1}','{2}')", "DJJKKMZFYXX.HIS", "YF_FY", str_KH);
                    InstanceForm.BDatabase.DoCommand(sql);
                }
                catch (Exception err)
                {
                    MessageBox.Show(string.Format("���ӽ��������ݿ���־��¼ʧ��!{0}", err.Message), "��ʾ");
                }
            }        

           
        }


    }
}
