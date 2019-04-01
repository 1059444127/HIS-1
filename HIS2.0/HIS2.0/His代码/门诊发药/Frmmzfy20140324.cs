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

namespace ts_yf_mzfy
{
	/// <summary>
	/// Frmcffy ��ժҪ˵����
	/// </summary>
	public class Frmcffy : System.Windows.Forms.Form
	{
        private DateTime PrintRq;
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Splitter splitter2;
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
        public  string _Fyckh;
        public string _Fyckmc;
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
        private bool  _ClickQuit=false;
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
        private HlyyInterface hlyyjk ;

		public Frmcffy(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text =chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
            s = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);


            //������ҩ��ʾ��lidan add 2013-09-16
            cfghlyytype = (new SystemCfg(8040)).Config;//8040������0����ʹ�ú�����ҩ��ʾ��1����ͨ
            if (cfghlyytype != "0" && cfghlyytype != "")
            {
                hlyyjk = Ts_Hlyy_Interface.HlyyFactory.Hlyy("��ͨ");
                hlyyjk.RegisterServer_fun(null);//���ĵ�
                //hlyyjk.Refresh();//ˢ���ĵ�
            }



			if (s.���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ==true)
				this.chkxp.Checked=true;
			else
				this.chkxp.Checked=false;
			//��ַ��ַ
			IPAddRess=PubStaticFun.GetMacAddress();
			
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
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
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.chkrq.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkrq.ForeColor = System.Drawing.Color.Black;
            this.chkrq.Location = new System.Drawing.Point(10, 67);
            this.chkrq.Name = "chkrq";
            this.chkrq.Size = new System.Drawing.Size(88, 21);
            this.chkrq.TabIndex = 12;
            this.chkrq.Text = "��������";
            this.chkrq.CheckedChanged += new System.EventHandler(this.chkrq_CheckedChanged);
            // 
            // dtprq2
            // 
            this.dtprq2.Enabled = false;
            this.dtprq2.Location = new System.Drawing.Point(225, 66);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(110, 21);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(204, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "��";
            // 
            // dtprq1
            // 
            this.dtprq1.Enabled = false;
            this.dtprq1.Location = new System.Drawing.Point(88, 66);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(112, 21);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(693, 66);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(58, 24);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "��ʷ";
            // 
            // rdodq
            // 
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(645, 66);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(58, 24);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "��ǰ";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(234, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "��ҩ��";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(982, 3);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel8.Size = new System.Drawing.Size(980, 98);
            this.panel8.TabIndex = 1;
            // 
            // cmbyf
            // 
            this.cmbyf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyf.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbyf.Location = new System.Drawing.Point(529, 65);
            this.cmbyf.Name = "cmbyf";
            this.cmbyf.Size = new System.Drawing.Size(107, 22);
            this.cmbyf.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(492, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "ҩ��";
            // 
            // buthj
            // 
            this.buthj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buthj.ForeColor = System.Drawing.Color.Navy;
            this.buthj.Location = new System.Drawing.Point(888, 32);
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
            this.txtlsh.Location = new System.Drawing.Point(714, 6);
            this.txtlsh.Name = "txtlsh";
            this.txtlsh.Size = new System.Drawing.Size(147, 21);
            this.txtlsh.TabIndex = 41;
            this.txtlsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(667, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "��ˮ��";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.Location = new System.Drawing.Point(270, 5);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(71, 22);
            this.cmbklx.TabIndex = 40;
            // 
            // txtxm
            // 
            this.txtxm.Enabled = false;
            this.txtxm.Location = new System.Drawing.Point(403, 66);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(87, 21);
            this.txtxm.TabIndex = 39;
            this.txtxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtxm_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(340, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "��������";
            // 
            // butqhfyck
            // 
            this.butqhfyck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butqhfyck.ForeColor = System.Drawing.Color.Navy;
            this.butqhfyck.Location = new System.Drawing.Point(750, 32);
            this.butqhfyck.Name = "butqhfyck";
            this.butqhfyck.Size = new System.Drawing.Size(131, 24);
            this.butqhfyck.TabIndex = 36;
            this.butqhfyck.Text = "�л���ҩ����";
            this.butqhfyck.Click += new System.EventHandler(this.butqhfyck_Click);
            // 
            // lblzd
            // 
            this.lblzd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblzd.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblzd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblzd.Location = new System.Drawing.Point(479, 36);
            this.lblzd.Name = "lblzd";
            this.lblzd.Size = new System.Drawing.Size(265, 22);
            this.lblzd.TabIndex = 35;
            this.lblzd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(445, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 34;
            this.label16.Text = "���";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblks.Location = new System.Drawing.Point(346, 36);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(96, 22);
            this.lblks.TabIndex = 33;
            this.lblks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(312, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "����";
            // 
            // lblnl
            // 
            this.lblnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblnl.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblnl.Location = new System.Drawing.Point(248, 36);
            this.lblnl.Name = "lblnl";
            this.lblnl.Size = new System.Drawing.Size(64, 22);
            this.lblnl.TabIndex = 31;
            this.lblnl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblnl.Click += new System.EventHandler(this.lblnl_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(216, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "����";
            // 
            // lblxb
            // 
            this.lblxb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxb.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxb.Location = new System.Drawing.Point(176, 36);
            this.lblxb.Name = "lblxb";
            this.lblxb.Size = new System.Drawing.Size(37, 22);
            this.lblxb.TabIndex = 29;
            this.lblxb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(144, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "�Ա�";
            // 
            // lblxm
            // 
            this.lblxm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblxm.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblxm.Location = new System.Drawing.Point(64, 36);
            this.lblxm.Name = "lblxm";
            this.lblxm.Size = new System.Drawing.Size(76, 22);
            this.lblxm.TabIndex = 27;
            this.lblxm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "����";
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfph.Location = new System.Drawing.Point(563, 6);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(100, 21);
            this.txtfph.TabIndex = 0;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtfph.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(517, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "��Ʊ��";
            // 
            // txttmk
            // 
            this.txttmk.BackColor = System.Drawing.Color.White;
            this.txttmk.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txttmk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txttmk.Location = new System.Drawing.Point(342, 6);
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size(173, 21);
            this.txttmk.TabIndex = 2;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txttmk.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "������/����";
            // 
            // butcfcx
            // 
            this.butcfcx.Enabled = false;
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(750, 66);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(131, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "��ѯ(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtmzh.Location = new System.Drawing.Point(64, 6);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(112, 21);
            this.txtmzh.TabIndex = 0;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            this.txtmzh.Enter += new System.EventHandler(this.txttmk_Enter);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "�����";
            // 
            // butquit
            // 
            this.butquit.BackColor = System.Drawing.SystemColors.Control;
            this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butquit.ForeColor = System.Drawing.Color.Navy;
            this.butquit.Location = new System.Drawing.Point(889, 66);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(80, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // chkall
            // 
            this.chkall.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(182, 14);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(56, 21);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "ȫѡ";
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // cmbpyr
            // 
            this.cmbpyr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpyr.Location = new System.Drawing.Point(272, 14);
            this.cmbpyr.Name = "cmbpyr";
            this.cmbpyr.Size = new System.Drawing.Size(82, 20);
            this.cmbpyr.TabIndex = 11;
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
            this.panel6.Location = new System.Drawing.Point(0, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(982, 50);
            this.panel6.TabIndex = 10;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.panel17.Size = new System.Drawing.Size(982, 50);
            this.panel17.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkqd);
            this.panel4.Controls.Add(this.chkcf);
            this.panel4.Controls.Add(this.chkzsd);
            this.panel4.Controls.Add(this.chkxp);
            this.panel4.Location = new System.Drawing.Point(393, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 44);
            this.panel4.TabIndex = 38;
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
            this.chkcf.Location = new System.Drawing.Point(91, 3);
            this.chkcf.Name = "chkcf";
            this.chkcf.Size = new System.Drawing.Size(72, 16);
            this.chkcf.TabIndex = 30;
            this.chkcf.Text = "���ﴦ��";
            this.chkcf.UseVisualStyleBackColor = true;
            // 
            // chkzsd
            // 
            this.chkzsd.AutoSize = true;
            this.chkzsd.Location = new System.Drawing.Point(3, 24);
            this.chkzsd.Name = "chkzsd";
            this.chkzsd.Size = new System.Drawing.Size(84, 16);
            this.chkzsd.TabIndex = 29;
            this.chkzsd.Text = "����ע�䵥";
            this.chkzsd.UseVisualStyleBackColor = true;
            // 
            // chkxp
            // 
            this.chkxp.Checked = true;
            this.chkxp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkxp.Location = new System.Drawing.Point(91, 24);
            this.chkxp.Name = "chkxp";
            this.chkxp.Size = new System.Drawing.Size(114, 17);
            this.chkxp.TabIndex = 36;
            this.chkxp.Text = "Ĭ�ϴ�ӡСƱ";
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point(86, 13);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(96, 24);
            this.rdo2.TabIndex = 20;
            this.rdo2.Text = "�ѷ�ҩ����";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(5, 12);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(96, 24);
            this.rdo1.TabIndex = 19;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "δ��ҩ����";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // chkprint
            // 
            this.chkprint.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkprint.Location = new System.Drawing.Point(786, 23);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(103, 21);
            this.chkprint.TabIndex = 18;
            this.chkprint.Text = "��ҩʱ��ӡ";
            // 
            // chkprintview
            // 
            this.chkprintview.Location = new System.Drawing.Point(786, -1);
            this.chkprintview.Name = "chkprintview";
            this.chkprintview.Size = new System.Drawing.Size(88, 24);
            this.chkprintview.TabIndex = 17;
            this.chkprintview.Text = "��ӡʱԤ��";
            // 
            // butfy
            // 
            this.butfy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.butfy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butfy.ForeColor = System.Drawing.Color.Navy;
            this.butfy.Location = new System.Drawing.Point(619, 11);
            this.butfy.Name = "butfy";
            this.butfy.Size = new System.Drawing.Size(65, 24);
            this.butfy.TabIndex = 13;
            this.butfy.Text = "��ҩ(&O)";
            this.butfy.UseVisualStyleBackColor = false;
            this.butfy.Click += new System.EventHandler(this.butfy_Click);
            // 
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(686, 11);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(88, 24);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "��ӡ����(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // rdo3
            // 
            this.rdo3.Location = new System.Drawing.Point(2, 39);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(96, 24);
            this.rdo3.TabIndex = 37;
            this.rdo3.Text = "��ҩ����";
            this.rdo3.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 463);
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
            this.statusBar1.Size = new System.Drawing.Size(980, 24);
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
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 500;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 439);
            this.panel2.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 439);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.splitter3);
            this.panel3.Controls.Add(this.panel_left);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 341);
            this.panel3.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.myDataGrid1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(249, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(731, 341);
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
            this.myDataGrid1.Size = new System.Drawing.Size(731, 341);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
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
            this.splitter3.Size = new System.Drawing.Size(5, 341);
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
            this.panel_left.Size = new System.Drawing.Size(244, 341);
            this.panel_left.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 317);
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
            this.dataGridView1.Size = new System.Drawing.Size(244, 317);
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
            this.ClientSize = new System.Drawing.Size(982, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.splitter2);
            this.KeyPreview = true;
            this.Name = "Frmcffy";
            this.Text = "���﷢ҩ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            this.Activated += new System.EventHandler(this.Frmcffy_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frmcffy_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frmcffy_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frmcffy_KeyDown);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
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
            Yp.AddcmbPyr(InstanceForm.BCurrentDept.DeptId, cmbpyr, InstanceForm.BDatabase);
			cmbpyr.SelectedValue=Convert.ToInt32(InstanceForm.BCurrentUser.EmployeeId);

			CshMxGrid(this.myDataGrid1);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

			this.dtprq1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);//.AddDays(-3);
			this.dtprq2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			
			this.chkrq.Checked=false;

            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();
            butqhfyck.Text = butqhfyck.Text + "(" + _Fyckh.Trim() + "��)";
			if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzfy_cx")
				this.butfy.Visible=false;
			this.txtmzh.Focus();

            Yp.AddcmbYjks(false,  cmbyf,DeptType.ҩ��, InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);
            cmbyf.SelectedValue = InstanceForm.BCurrentDept.DeptId.ToString();

            if ((new SystemCfg(8006)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ҽ��"].Width = 0;



            //string cfgs = new SystemCfg(8010).Config;
            //if (cfgs == "1") rdocfgs.Checked = true;
            //if (cfgs == "0") rdoqdgs.Checked = true;
            //if (cfgs == "2") rdoall.Checked = true;
            if (s.���﷢ҩʱ��ӡ���� == true) chkcf.Checked = true;
            if (s.���﷢ҩʱ��ӡ�嵥 == true) chkqd.Checked = true;
            if (s.���﷢ҩʱ��ӡע�䵥 == true) chkzsd.Checked = true;

            if (s.���﷢ҩʱĬ�ϴ�ӡ���� == true) chkprint.Checked = true;


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
            if (cfg8027 == "0") panel_left.Visible = false;
            if (cfg8027 == "2")
            {
                ��Ʊ��.Visible = false;
                Column2.Width = Column2.Width + 15;
                ���.Width = ���.Width + 15;
                panel_left.Width = panel_left.Width - ��Ʊ��.Width + 20;
            }
            if (cfg8027 != "0")
                button_ref_Click(sender, e);


          



		}

		
		private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx  xcjwDataGrid)
		{
			#region �����ϸ����

            //string[] HeaderText ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
            //string[] MappingName ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
            //int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65, 70, 40, 40, 70, 0, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*��������*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80,0,90,150 ,50,50};
            //bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true,true,true,true,true,true };
            //bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

            string[] HeaderText ={ "���", "��ʾ��", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
            string[] MappingName ={  "���", "��ʾ��", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp", "fpid", "��Ʊ��ˮ��", "��ҩ��ע", "��ע2", "��ע3" };
            int[] ColWidth ={ 40, 30, 30, 30, 60, 0, 0, 60, 60, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 60, 40, 65, 70, 40, 40, 70, 0, 50, 0, 50/*userage*/, 50, 0, 0, 0, 0, 0, 90, 60, 90/*��������*/, 60, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80, 0, 90, 150, 50, 50 };
            bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            bool[] ColBool ={ true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };


			DataTable dtTmp=new DataTable();
			dtTmp.TableName="tbmx";

            SystemCfg cfg8032 = new SystemCfg(8032);


			for(int j=0;j<=HeaderText.Length-1;j++)
			{
				//DataGridEnableBoolColumn
				if (ColBool[j]==false)
				{
                    if (HeaderText[j].ToString() != "��ʾ��")
                    {
                        DataGridEnableTextBoxColumn colText = new DataGridEnableTextBoxColumn(j);
                        colText.HeaderText = HeaderText[j];
                        colText.MappingName = MappingName[j];
                        colText.Width = ColWidth[j];
                        colText.NullText = "";
                        colText.ReadOnly = ColReadOnly[j];
                        //colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.CheckCellEnabled += new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
                        colText.TextBox.TextChanged += new EventHandler(TextBox_TextChanged);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
                    }
                    else
                    {
                        MydataGirdImageColumn mycol = new MydataGirdImageColumn();
                        mycol.HeaderText = HeaderText[j];
                        mycol.MappingName = MappingName[j];
                        mycol.Width = ColWidth[j];
                        mycol.NullText = "";
                        mycol.ReadOnly = ColReadOnly[j];
                        mycol.ONCurrentChange += new DelCurrentChage(mycol_ONCurrentChange);
                        xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(mycol);
                        if (cfg8032.Config == "0")
                            mycol.Width = 0;
                    }

					DataColumn datacol;
					if (MappingName[j].Trim()=="ypsl" || MappingName[j]=="���")
						datacol=new DataColumn(MappingName[j],Type.GetType("System.Decimal"));
					else
						datacol=new DataColumn(MappingName[j]);
					
					dtTmp.Columns.Add(datacol);
				}
				else
				{
					DataGridButtonColumn btnCol=new DataGridButtonColumn(j);
					btnCol.HeaderText=HeaderText[j];
					btnCol.MappingName=MappingName[j];
					btnCol.Width=ColWidth[j];
					btnCol.CellButtonClicked+=new DataGridCellButtonClickEventHandler(btnCol_CellButtonClicked);
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(btnCol);
                    
					this.myDataGrid1.MouseDown +=new MouseEventHandler(btnCol.HandleMouseDown);
					this.myDataGrid1.MouseUp +=new MouseEventHandler(btnCol.HandleMouseUp);
                    
					
					DataColumn datacol;
					datacol=new DataColumn(MappingName[j]);
					dtTmp.Columns.Add(datacol);

				}
				
			}

			xcjwDataGrid.DataSource=dtTmp;
			xcjwDataGrid.TableStyles[0].MappingName ="tbmx";

			if (s.����������ʾ��Ʒ��==true)
				xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width=100;
			else
				xcjwDataGrid.TableStyles[0].GridColumnStyles["��Ʒ��"].Width=0;
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
                if (tbmx.Columns[ncol].Caption != "��ʾ��") return;
                Guid ghxxid = new Guid(tbmx.Rows[nrow]["patid"].ToString());
                string mzh = tbmx.Rows[nrow]["�����"].ToString();
                string xb = tbmx.Rows[nrow]["�Ա�"].ToString();
                object brxxid = InstanceForm.BDatabase.GetDataResult("select top 1 brxxid from mz_ghxx where ghxxid='"+ghxxid+"'", 30);

                //MessageBox.Show(brxxid.ToString());
                //Add hlyy by Zj 2012-02-13
                YY_BRXX brxx = new YY_BRXX(new Guid(Convertor.IsNull(brxxid,Guid.Empty.ToString())), InstanceForm.BDatabase);
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
            ImageList im=new ImageList();
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
				e.BackColor=Color.White;
				DataTable tb;
				if (sender.GetType().ToString()=="TrasenClasses.GeneralControls.DataGridEnableBoolColumn")
				{
					DataGridEnableBoolColumn column=(DataGridEnableBoolColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}
				else
				{
					DataGridEnableTextBoxColumn column=(DataGridEnableTextBoxColumn)sender;
					tb=(DataTable)column.DataGridTableStyle.DataGrid.DataSource; 
				}
				if (e.Row>tb.Rows.Count-1) return;
				//				if (tb.Rows[e.Row]["cjid"].ToString().Trim()=="")
				//					e.BackColor=Color.Azure;
				
				if (tb.Rows[e.Row]["��ҩ"].ToString().Trim()=="��")
					e.ForeColor=Color.Blue;
				if (tb.Rows[e.Row]["��ҩ"].ToString().Trim()=="") 
					e.ForeColor=Color.Black;
				if (tb.Rows[e.Row]["��ҩ"].ToString().Trim()=="��") 
					e.ForeColor=Color.Gray;
					
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			//			
		}



		//��ѯ������ť�¼�
		private void butcfcx_Click(object sender, System.EventArgs e)
		{
			this.Cursor=PubStaticFun.WaitCursor();

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


                DataTable tb=new DataTable();

                //string rq1=chkrq.Checked==true?dtprq1.Value.ToShortDateString():"";
                //string rq2=chkrq.Checked==true?dtprq2.Value.ToShortDateString():"";
				int bk=this.rdodq.Checked==true?0:1;
                int fybz = 0;
                if (rdo2.Checked == true) fybz = 1;
                if (rdo3.Checked == true) fybz = 2;

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

                if (txtxm.Text.Trim()=="" && txtmzh.Text.Trim() == "" && txttmk.Text.Trim() == "" && txtfph.Text.Trim() == "" && chkrq.Checked == false && rdo2.Checked == true)
                {
                    MessageBox.Show("��ѡ��һ���Ĳ�ѯ����");
                    return;
                }

                tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, txtxm.Text.Trim(),
					 "",0,
                    fyrq1 , fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);

				this.AddPresc(tb);

				chkall.Checked=false;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message );
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}


		//��Ӵ�����¼
		private void AddPresc(DataTable tbcf)
		{
			
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();

			if (tbcf.Rows.Count==0)return;
			string _prescNo=tbcf.Rows[0]["������"].ToString().Trim();
			int _PrescRowNo=0;
			decimal _PrescJe=0;

            if (tbcf.Rows.Count > 0) cmbpyr.Text = tbcf.Rows[0]["��ҩԱ"].ToString().Trim();
			for (int i=0;i<=tbcf.Rows.Count-1;i++)
			{
				if(tbcf.Rows[i]["������"].ToString().Trim()!=_prescNo)
				{
					DataRow row=tb.NewRow();
					row["���"]="С��";
					row["���"]=_PrescJe.ToString("0.00");
					row["������"]=_prescNo;
					_prescNo=tbcf.Rows[i]["������"].ToString().Trim();
					_PrescRowNo=0;
					_PrescJe=0;
					tb.Rows.Add(row); 

					DataRow row1=tb.NewRow();
					tb.Rows.Add(row1);
				}

				if(tbcf.Rows[i]["������"].ToString().Trim()==_prescNo)
				{
					_PrescRowNo=_PrescRowNo+1;
					tbcf.Rows[i]["���"]=_PrescRowNo.ToString();
					//					if (this.tabControl1.SelectedTab==this.tabPage2) tbcf.Rows[i]["��ҩ"]="��";
					tb.ImportRow(tbcf.Rows[i]); 
					_PrescJe=_PrescJe+Convert.ToDecimal(tbcf.Rows[i]["���"]);

                    //wxz

                    //wxz
				}
				
				_prescNo=tbcf.Rows[i]["������"].ToString().Trim();
				
			}

			//������һ�Ŵ����ĺϼ�
			DataRow endrow=tb.NewRow();
			endrow["���"]="С��";
			endrow["���"]=_PrescJe.ToString("0.00");
			endrow["������"]=_prescNo;
			tb.Rows.Add(endrow);

            //if (tb.Rows.Count > 1)
            //    myDataGrid1.CurrentCell =null;
		}




		
		#region һ�����
	
		private void chkrq_CheckedChanged(object sender, System.EventArgs e)
		{
			dtprq1.Enabled=this.chkrq.Checked==true?true:false;
			dtprq2.Enabled=this.chkrq.Checked==true?true:false;
			this.butcfcx.Enabled=this.chkrq.Checked==true?true:false;
            txtxm.Enabled = this.chkrq.Checked == true ? true : false;
		}


		//��ϸ�еİ�ť�¼�
		private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			if (this.rdo2.Checked==true)return;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (tb.Rows[i]["������"].ToString().Trim()==tb.Rows[e.RowIndex]["������"].ToString().Trim() && tb.Rows[i]["������"].ToString().Trim()!="" && tb.Rows[i]["��ҩ"].ToString().Trim()!="��" )
				{
					if (tb.Rows[i]["��ҩ"].ToString().Trim()=="")
						tb.Rows[i]["��ҩ"]="��";
					else
						tb.Rows[i]["��ҩ"]="";
				}
			}
		}

		//ȫѡ
		private void chkall_CheckedChanged(object sender, System.EventArgs e)
		{
//			if (this.tabControl1.SelectedTab!=this.tabPage1) return;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (tb.Rows[i]["������"].ToString().Trim()!="" && tb.Rows[i]["��ҩ"].ToString().Trim()!="��")
				{
					if (chkall.Checked==true)
						tb.Rows[i]["��ҩ"]="��";
					else
						tb.Rows[i]["��ҩ"]="";
				}
			}
		}

		
		#endregion

		private void butfy_Click(object sender, System.EventArgs e)
		{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;

				//if (s.��ҩģʽ==true && this._Fyckh.Trim()==""){MessageBox.Show("ϵͳ��ǰ������ҩģʽ����ǰ���ڱ������ã�","��ҩ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;};
				if (s.ϵͳ����==false){MessageBox.Show("ϵͳδ����"); return;}
				if (s.����ϵͳ==true){MessageBox.Show("ϵͳ������Ա����"); return;}

				string _pronamefy="";string _pronamefymx="";
				if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_mzfy")
				{
					_pronamefy="sp_yf_fy";
					_pronamefymx="sp_yf_fymx";
				}
				else
				{
					_pronamefy="sp_yk_fy";
					_pronamefymx="sp_yk_fymx";
				}

				
            if (cmbpyr.Text.Trim()==""){MessageBox.Show("��ѡ����ҩ�ˣ�","��ҩ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;}


			string sDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();;
			Guid  fyid=Guid.Empty;
			Guid  fymxid=Guid.Empty;
			int err_code=-1;
			string err_text="";

			
			try
			{
                
				this.Cursor=PubStaticFun.WaitCursor();

				//���鴦��
				DataRow[] selrow=tb.Select("��ҩ='��' and ypid<>''");
				DataTable tbsel=tb.Clone();
				for(int w=0;w<=selrow.Length-1;w++)
					tbsel.ImportRow(selrow[w]);


                //��ҩʱ ������ҩ��ʾ 
               
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

                                int gh = InstanceForm.BCurrentUser.EmployeeId;
                                string cfrq = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd HH:mm:ss");
                                string employeename = InstanceForm.BCurrentUser.Name;
                                int ksdm = InstanceForm.BCurrentDept.DeptId;
                                string ksmc = InstanceForm.BCurrentDept.DeptName;
                                string mzh = tbsel.Rows[0]["�����"].ToString();
                                string brxmhlyy = tbsel.Rows[0]["����"].ToString();
                                string xb = tbsel.Rows[0]["�Ա�"].ToString();
                                DataTable tb1 = tbsel;
                                string icd = tbsel.Rows[0]["���"].ToString();

                                int hfresult=hlyyjk.RegisterServer_fun(null);//���ĵ�
                                hlyyjk.Refresh();
                                StringBuilder sss = new StringBuilder(ts_mz_hlyy.GetXml(gh, cfrq, employeename, ksdm, ksmc, mzh, birth, brxmhlyy, xb, tb1, icd));
                                hfresult = hlyyjk.DrugAnalysis(sss, 1);

                                if (hfresult >=2 )
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
                    //MessageBox.Show("PASS����!ԭ��:" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }
                #endregion





				string[] GroupbyField	={"jssjh","��Ʊ��","�ܽ��","���ʽ��","�Żݽ��","�Ը����","����","cfxh",
											 "patid","�����","����","ysdm","ksdm","�շ�����","sfczy","��ҩ����"};
				string[] ComputeField	={"���"};
				string[] CField	={"sum"};
				DataTable tbcf=FunBase.GroupbyDataTable(tbsel,GroupbyField,ComputeField,CField,null);
				if (tbcf.Rows.Count==0){MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼");return;}

				int cfcount=0;
				this.butfy.Enabled=false;
                //add by wangzhi
                decimal sumje = 0;
                string brxm = "";
                string _Bz = "";//��ҩ��ϸ��ע
                //end add
				InstanceForm.BDatabase.BeginTransaction();

                int iiii = tbcf.Rows.Count;
                
				for(int i=0;i<=tbcf.Rows.Count-1;i++)
				{
                    DataRow[] rows = tb.Select("��Ʊ��='" + tbcf.Rows[i]["��Ʊ��"].ToString() + "' and ypid<>'' and �����='" + tbcf.Rows[i]["�����"].ToString() + "' AND CFXH='" + tbcf.Rows[i]["CFXH"].ToString() + "'", "���");

					#region ���뷢ҩͷ��
                    MZYF.SaveFy(rows[0]["cflx"].ToString(),
						Convert.ToDecimal(tbcf.Rows[i]["jssjh"]),
						Convert.ToInt64(Convertor.IsNull(tbcf.Rows[i]["��Ʊ��"],"0")),
						Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�ܽ��"],"0")),
						Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���ʽ��"],"0")),
						Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Żݽ��"],"0")),
						Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["�Ը����"],"0")),
						Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"],"0")),
						new Guid(tbcf.Rows[i]["cfxh"].ToString()),
                        new Guid(Convertor.IsNull(tbcf.Rows[i]["patid"], Guid.Empty.ToString())),
						tbcf.Rows[i]["�����"].ToString(),
						tbcf.Rows[i]["����"].ToString(),
						Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ysdm"],"0")),
						Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ksdm"],"0")),
						tbcf.Rows[i]["�շ�����"].ToString(),
						Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["sfczy"],"0")),
						sDate,
						InstanceForm.BCurrentUser.EmployeeId,
						Convert.ToInt32(cmbpyr.SelectedValue),
						Convertor.IsNull(tbcf.Rows[i]["��ҩ����"],"0"),
						_Fyckh,
                        InstanceForm.BCurrentDept.DeptId, 0, _menuTag.FunctionTag, 0, _pronamefy, out fyid, out err_code, out err_text, InstanceForm._menuTag.Jgbm, InstanceForm.BDatabase);
					if (err_code!=0 || fyid==Guid.Empty){throw new System.Exception(err_text);}
					this.butfy.Tag=fyid.ToString();
					#endregion 

					#region ���뷢ҩ��ϸ
                    
					for (int j=0;j<=rows.Length-1;j++)
					{
                        string UserEat = rows[j]["Ƶ��"].ToString().Trim() == "" ? "" : Convert.ToDouble(rows[j]["����"]).ToString() + rows[j]["������λ"].ToString().Trim() + "/ÿ��";
                        string yf = Convert.ToString(rows[j]["�÷�"]) + "  " + rows[j]["ʹ��Ƶ��"].ToString().Trim() + " " + UserEat;
                        string  zt = Convert.ToString(rows[j]["����"]);

						MZYF.SaveFymx(fyid,
							Convert.ToInt64(Convertor.IsNull(rows[j]["��Ʊ��"],"0")),
                            new Guid(Convertor.IsNull(rows[j]["cfxh"], Guid.Empty.ToString())),
							Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"],"0")),
							rows[j]["����"].ToString(),
							rows[j]["Ʒ��"].ToString(),
							rows[j]["��Ʒ��"].ToString(),
							rows[j]["���"].ToString(),
							rows[j]["����"].ToString(),
							rows[j]["��λ"].ToString(),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["ydwbl"],"0")),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["����"],"0")),
							Convert.ToInt32(Convertor.IsNull(rows[j]["����"],"0")),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["������"],"0")),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["�������"],"0")),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["����"],"0")),
							Convert.ToDecimal(Convertor.IsNull(rows[j]["���"],"0")),
							0,
							0,
							InstanceForm.BCurrentDept.DeptId,
							Guid.Empty,
							"",
							Guid.Empty,
							new Guid(Convertor.IsNull(rows[j]["cfmxid"],Guid.Empty.ToString())),
                            rows[j]["Ƥ��"].ToString(),
                            yf.Trim(),
                            zt.Trim(),
                            Convertor.IsNull(rows[j]["�÷�"],""),
                            Convertor.IsNull(rows[j]["Ƶ��"], ""),
                            Convertor.IsNull(rows[j]["����"],""),
                            Convertor.IsNull(rows[j]["������λ"], ""),
                            Convert.ToDecimal(Convertor.IsNull(rows[j]["����"],"0")),
                            Convert.ToInt32(Convertor.IsNull(rows[j]["���־"],"0")),
                            Convert.ToInt32(Convertor.IsNull(rows[j]["�������"],"0")),
							_pronamefymx,
							out fymxid,
							out err_code,
                            out err_text, InstanceForm.BDatabase);
						if (err_code!=0){throw new System.Exception(err_text);}				
						cfcount=cfcount+1;


                        string ssql = "select '["+rows[j]["Ʒ��"].ToString()+"] �����:'+cast(cast(round(kcl/dwbl,3) as float) as varchar(50))+rtrim(dbo.fun_yp_ypdw(nypdw))+',��������ֵ:' +cast(cast(kcxx as float) as varchar(30))+rtrim(dbo.fun_yp_ypdw(nypdw)) as bz from yf_kcmx a,yp_kcsxx b where a.cjid=b.cjid and a.deptid=b.deptid and round(kcl/dwbl,3)<kcxx  and kcxx>0 and a.cjid=" + Convert.ToInt32(Convertor.IsNull(rows[j]["ypid"], "0")) + " and a.deptid="+InstanceForm.BCurrentDept.DeptId+" ";
                        DataTable tbsxx = InstanceForm.BDatabase.GetDataTable(ssql);
                        if (tbsxx.Rows.Count > 0)
                            _Bz = _Bz + Convertor.IsNull(tbsxx.Rows[0][0], "") + "\n";
					}

					#endregion 

                    //add by wangzhi
                    sumje += Convert.ToDecimal( Convertor.IsNull( tbcf.Rows[i]["�ܽ��"] , "0" ) );
                    brxm = tbcf.Rows[i]["����"].ToString().Trim();
                    
                    //end add
				}

				if (selrow.Length!=cfcount)
				{
					throw new Exception("��������,��̨���µ���������������ǰѡ��ҩ������");
				}

                //���鴦��
                DataTable tbsel_hj = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel_hj.ImportRow(selrow[w]);
                string[] GroupbyField_hj ={ "FPID"};
                string[] ComputeField_hj ={ "���" };
                string[] CField_hj ={ "sum" };
                DataTable tbcf_hj = FunBase.GroupbyDataTable(tbsel_hj, GroupbyField_hj, ComputeField_hj, CField_hj, null);
                for (int i = 0; i <= tbcf_hj.Rows.Count - 1; i++)
                {
                    string ssql = "update yf_fyjh set bfybz=1,FYRQ='"+sDate+"' where fpid='"+tbcf_hj.Rows[i]["fpid"].ToString()+"'";
                    InstanceForm.BDatabase.DoCommand(ssql);
                }


				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();

				

                #region ������   20110307
                try
                {
                    DataRow[] selrowX = tb.Select("��ҩ='��' and ypid<>''");
                    DataTable tbselX = tb.Clone();
                    for (int w = 0; w <= selrowX.Length - 1; w++)
                        tbselX.ImportRow(selrowX[w]);

                    string[] GroupbyFieldX ={"����"};
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
                            cfmx[i].brxm=Convertor.IsNull(selrow[i]["����"], "");
                            cfmx[i].fph = Convertor.IsNull(selrow[i]["��Ʊ��"], "");
                        }
                        string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                        if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
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
                #endregion
                MessageBox.Show("��ҩ�ɹ���\n\n"+_Bz, "��ҩ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
				this.butfy.Enabled=true;

                DataRow[] rows_ref = null;
                DataView dv=(DataView)dataGridView1.DataSource;
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
			catch(System.Exception err)
			{
				this.butfy.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}


			//��ӡ����
			try
			{
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (tb.Rows[i]["��ҩ"].ToString().Trim()=="��")
						tb.Rows[i]["��ҩ"]="��";
				}

				//��ӡ���������
				if (chkprint.Checked==true) this.butprint_Click(sender,e);
			}
			catch(System.Exception err)
			{
				MessageBox.Show ("��ӡ����ʱ��������"+err.Message ,"����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

            string bqypjq = ApiFunction.GetIniString("������", "����������", Constant.ApplicationDirectory + "//ClientWindow.ini");
            string pjqxh = ApiFunction.GetIniString("������", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            if (bqypjq == "true")
            {
                ts_pjq.ipjq ipjq = ts_pjq.PjqFactory.Newpjq(pjqxh);
                string perr_text = "";
                int perr_code = 0;
                ipjq.Pj(InstanceForm.BCurrentUser.LoginCode.ToString(), InstanceForm.BCurrentUser.Name, InstanceForm.BCurrentDept.DeptId.ToString(), InstanceForm.BCurrentDept.DeptName, out perr_code, out perr_text);
                if (perr_code != 0) throw new Exception("���������ó���!" + perr_text);
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
            public VoiceCaller(string name, ts_VoiceCall.Icall  call)
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
                

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				butprint.Enabled=false;

                YpConfig ypconfig = new YpConfig(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase);

                
				//���鴦��
				DataRow[] selrow;
                if (ypconfig.���﷢ҩ����ܴ�ӡ����==true)
                    selrow = tb.Select("( ��ҩ='��') and ypid<>''");
                else
                    selrow = tb.Select("(��ҩ='��' or  ��ҩ='��') and ypid<>''");
				DataTable tbsel=tb.Clone();
				for(int w=0;w<=selrow.Length-1;w++)
					tbsel.ImportRow(selrow[w]);

                DataTable tbcf;
                if (rdo1.Checked == true) //���Ϊδ��ҩ��ȡ�ܽ��ѷ�ҩ��ȡ���ֵ
                {
                    string[] GroupbyField ={ "cfxh", "��Ʊ��", "�ܽ��", "���", "�����" };
                    string[] ComputeField ={ };
                    string[] CField ={  };
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
                        DataRow[] rows = tbfp.Select("fpid='"+tbcf_dy.Rows[i]["fpid"].ToString()+"'");
                        if (rows.Length==1)
                            rows[0]["��ӡ"]="1";
                    }

                }

				butprint.Enabled=true;
			}
			catch(System.Exception err)
			{
				butprint.Enabled=true;
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
            if (fpid != "") where = where + " and fpid='"+fpid+"'";
            rows = tb2.Select(where );
            if (rows.Length == 0) return;


            string jtdz = ""; string grlxdh = ""; string sfzh = "";
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
                myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
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
                myrow["pyr"] = this.cmbpyr.Text.Trim(); ;
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
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;

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
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥.rpt", parameters, bview);
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

        private void PrintCf(DataRow row, int cfgs)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;
            if (cfgs == 1)
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' ");
            else
                rows = tb2.Select(" cfxh='" + row["cfxh"] + "' and zsyp=1 ");
            if (rows.Length == 0) return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

            string jtdz = ""; string grlxdh = ""; string sfzh = "";
            string ssql = "select * from yy_brxx a inner join mz_cfb b on a.brxxid=b.brxxid where b.cfid='" + row["cfxh"].ToString() + "'";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
            {
                jtdz = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
                grlxdh = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
                sfzh = Convertor.IsNull(tb.Rows[0]["sfzh"], "");
            }

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
                myrow["pc"] = Convertor.IsNull(rows[i]["ʹ��Ƶ��"], "");
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
                myrow["pyr"] = this.cmbpyr.Text.Trim(); ;
                myrow["fyr"] = Convert.ToString(rows[i]["��ҩԱ"]) == "" ? InstanceForm.BCurrentUser.Name : Convert.ToString(rows[i]["��ҩԱ"]);
                myrow["pyckdm"] = Convertor.IsNull(rows[i]["��ҩ����"],"")==""?"":Convertor.IsNull(rows[i]["��ҩ����"],"");
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
                myrow["dyr"] = InstanceForm.BCurrentUser.Name;

                Dset.���˴����嵥.Rows.Add(myrow);
                #endregion

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
            if (Convert.ToString(rows[0]["cflx"]) != "03")
                parameters[4].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[4].Value = 0;
            parameters[5].Text = "zyf";
            if (Convert.ToString(rows[0]["cflx"]) == "03")
                parameters[5].Value = Convert.ToDecimal(rows[0]["�ܽ��"]);
            else
                parameters[5].Value = 0;
            parameters[6].Text = "yfmc";
            parameters[6].Value = InstanceForm.BCurrentDept.DeptName;
            bool bview = true;
            if (chkprintview.Checked == true) bview = false;
            TrasenFrame.Forms.FrmReportView f;
            if (cfgs == 1)
            {
                if (Convert.ToString(rows[0]["cflx"]) == "03")
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥_��ҩ����.rpt", parameters, bview);

                else
                    f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(������ʽ).rpt", parameters, bview);
            }
            else
            {
                f = new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥, Constant.ApplicationDirectory + "\\Report\\YF_���˴����嵥(ע�䵥).rpt", parameters, bview);
            }
            if (f.LoadReportSuccess) f.Show(); else f.Dispose();


        }

		private void PrintCfXP()
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;

			DataRow[] rows;
			rows=tb.Select("( ��ҩ='��' or ��ҩ='��')  and ����<>''");
			if (rows.Length==0) return;
			string cftsname="";
			cftsname=Convert.ToString(rows[0]["��Ŀ"]).Trim()=="�в�ҩ"?"��ҩ����":"";
			ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
			DataRow myrow;
			for(int i=0;i<=rows.Length-1;i++)
			{
				myrow=Dset.���˴����嵥.NewRow();
				//myrow["xh"]=Convert.ToInt32(rows[i]["���"]);
				myrow["ypmc"]=Convert.ToString(rows[i]["Ʒ��"]);
				myrow["ypgg"]=Convert.ToString(rows[i]["���"]);
				myrow["sccj"]=Convert.ToString(rows[i]["����"]);
				myrow["lsj"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["����"],"0"));
				myrow["zje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["�ܽ��"],"0"));
				myrow["ypsl"]=Convertor.IsNull(rows[i]["����"],"0");
				myrow["ypdw"]=Convert.ToString(rows[i]["��λ"]);
				myrow["cfts"]=Convert.ToString(rows[i]["��Ŀ"]).Trim()=="�в�ҩ"?rows[i]["����"]+"��":"";
				myrow["lsje"]=Convert.ToDecimal(Convertor.IsNull(rows[i]["���"],"0"));
				string UserEat="";
				UserEat=rows[i]["Ƶ��"].ToString().Trim()==""?"":Convert.ToDouble(rows[i]["����"]).ToString()+rows[i]["������λ"].ToString().Trim()+"/ÿ��";
				myrow["yf"]=Convert.ToString(rows[i]["�÷�"])+"  "+rows[i]["ʹ��Ƶ��"].ToString().Trim()+" "+UserEat;
				myrow["pc"]= rows[i]["ʹ��Ƶ��"].ToString().Trim();
				myrow["syjl"]="";
				myrow["zt"]=Convert.ToString(rows[i]["����"]);
				myrow["shh"]=Convert.ToString(rows[i]["����"]);
				myrow["ksname"]=Convert.ToString(rows[i]["����"]);//+"  �ѱ�:"+this.patientInfo1.FeeTypeName;
				string ysqm="";
				//if (Convert.ToString(row["ҽ��ǩ��"]).Trim()!="")  ysqm="   ҽ��ǩ��:"+Convert.ToString(rows[i]["ҽ��ǩ��"]);
				myrow["ysname"]=Convert.ToString(rows[i]["ҽ��"])+ysqm;
				myrow["Pyck"]=rows[i]["Ƥ��"].ToString();
				myrow["fph"]=Convert.ToString(rows[i]["��Ʊ��"]);
				myrow["hzxm"]=Convert.ToString(rows[i]["����"]);
				myrow["sex"]=Convert.ToString(rows[i]["�Ա�"]);
				myrow["age"]=Convert.ToString(rows[i]["����"]);
				myrow["blh"]=Convert.ToString(rows[i]["�����"]);
				myrow["sfrq"]=Convert.ToString(rows[i]["�շ�����"]);
				myrow["pyr"]=this.cmbpyr.Text.Trim();;
				myrow["fyr"]=InstanceForm.BCurrentUser.Name;
				Dset.���˴����嵥.Rows.Add(myrow);
			}

			ParameterEx[] parameters=new ParameterEx[1];
			parameters[0].Text="TITLETEXT";
			parameters[0].Value=TrasenFrame.Classes.Constant.HospitalName+"������ϸ��";
			bool bview=this.chkprintview.Checked==true?false:true;
			TrasenFrame.Forms.FrmReportView f;
			f=new TrasenFrame.Forms.FrmReportView(Dset.���˴����嵥,Constant.ApplicationDirectory+"\\Report\\YF_���˴����嵥�б�_СƱ.rpt",parameters,bview);
			if (f.LoadReportSuccess) f.Show();else  f.Dispose();

		}


		//��ѯ����
		private void txtghxh_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			try
			{
				int nkey=Convert.ToInt32(e.KeyChar);
				if (nkey==13)
				{
					DataTable mytb=(DataTable)this.myDataGrid1.DataSource;
					mytb.Rows.Clear();

					Control control=(Control)sender;
					ts_mz_brxx.MzGhxx ghxx=null;
					ts_mz_brxx.MzBrxx brxx=null;

                    string sfrq1 = "";
                    string sfrq2 = "";
                    string fyrq1 = "";
                    string fyrq2 = "";
                    decimal jslsh =Convert.ToDecimal(Convertor.IsNull(txtlsh.Text,"0"));

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

					DataTable tb=null;

					if (control.Name=="txtmzh")
					{
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);
						DataTable tbghxx=ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty,Guid.Empty,txtmzh.Text.Trim(),0,0,InstanceForm.BDatabase);
                        if (tbghxx.Rows.Count==0)
                            tbghxx = tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, txtmzh.Text.Trim(), 0,1, InstanceForm.BDatabase);
						if (tbghxx.Rows.Count==0){MessageBox.Show("û���ҵ����ˣ�����������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
						ghxx=new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                        brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                       
						tb=MZYF.SelectMzcfk(_menuTag.Function_Name,Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue,"0")),ghxx.ghxh,"",
							"",0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty , Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
						this.txttmk.Text="";
                        jslsh = 0;
						//this.txtghxh.Text="";
						this.txtfph.Text="";
						_textBox=txtmzh;

					}
					if (control.Name=="txttmk")
					{
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                        txttmk.Text = Fun.returnKh(klx, txttmk.Text, InstanceForm.BDatabase);
                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txttmk.Text.Trim(), "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        if (brxx.binid==Guid.Empty) { MessageBox.Show("û���ҵ����ˣ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(brxx.binid, Guid.Empty, "", 0, Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        Guid ghxxid = Guid.Empty;
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            ghxxid = ghxx.ghxh;
                        }
                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
							"",0,
                            fyrq1 ,fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,
                            Guid.Empty,brxx.binid, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
						this.txtmzh.Text="";
						this.txtfph.Text="";
                        jslsh = 0;
						_textBox=txttmk;
					}
					if (control.Name=="txtlsh")
					{
                        //DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, new Guid(Convertor.IsNull(txtghxh.Text, Guid.Empty.ToString())), "", 0, Convert.ToInt16(this.rdols.Checked));
                        //if (tbghxx.Rows.Count == 0) { MessageBox.Show("û���ҵ����ˣ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataRow row = null;
                        //ghxx = new ts_mz_brxx.MzGhxx(row);
                        //brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, 0, "","", Convert.ToInt16(this.rdols.Checked),InstanceForm.BDatabase);

                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
                            Convertor.IsNull(txtfph.Text, "0"),jslsh,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty, Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
                        this.txtmzh.Text = "";
                        this.txttmk.Text = "";
                        this.txtfph.Text = "";
                        _textBox = txtlsh;
					}
					if (control.Name=="txtfph")
					{

                        if (Convertor.IsNumeric(txtfph.Text) == false) { MessageBox.Show("��Ʊ�����������֣�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        DataTable tbghxx = ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty, Guid.Empty, "", Convert.ToInt64(Convertor.IsNull(txtfph.Text, "0")), Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
						//if (tbghxx.Rows.Count==0){MessageBox.Show("û���ҵ����ˣ�����������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
                        if (tbghxx.Rows.Count > 0)
                        {
                            ghxx = new ts_mz_brxx.MzGhxx(tbghxx.Rows[0]);
                            brxx = new ts_mz_brxx.MzBrxx(ghxx.binid, 0, "", "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
                        }



                        tb = MZYF.SelectMzcfk(_menuTag.Function_Name, Convert.ToInt64(Convertor.IsNull(cmbyf.SelectedValue, "0")), Guid.Empty, "",
							Convertor.IsNull(txtfph.Text,"0"),0,
                            fyrq1, fyrq2, 0, Convert.ToInt16(this.rdo2.Checked), "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0,Guid.Empty,Guid.Empty, Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);
						this.txtmzh.Text="";
						this.txttmk.Text="";
                        jslsh = 0;
						//this.txtghxh.Text="";
						_textBox=txtfph;
					}

					this.chkall.Checked=false;

					this.AddPresc(tb);

					if (this.rdo1.Checked==true)
					{
						if (tb.Rows.Count>0)
							this.chkall.Checked=true;
						else
							this.chkall.Checked=false;
					}

                    if (brxx != null)
                    {
                        this.lblxm.Text = Convertor.IsNull(brxx.����, "");
                        this.lblxb.Text = Convertor.IsNull(brxx.�Ա�, "");
                        this.lblnl.Text = Convertor.IsNull(brxx.����, "");
                        this.lblks.Text = ghxx == null ? "" : Convertor.IsNull(ghxx.�Һſ�������, "");
                        this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull(ghxx.�������, "");
                    }
                    else
                    {
                        this.lblxm.Text = "";
                        this.lblxb.Text = "";
                        this.lblnl.Text = "";
                        this.lblks.Text = ghxx == null ? "" : Convertor.IsNull(ghxx.�Һſ�������, "");
                        this.lblzd.Text = ghxx == null ? "" : Convertor.IsNull(ghxx.�������, "");
                    }

					if (tb.Rows.Count!=0 && this.rdo1.Checked==true && s.���﷢ҩ��ť�Ƿ�������ý���==true)
						this.butfy.Focus();
					else
					{
						TextBox control1=(TextBox)sender;
						control1.SelectAll();
						control1.Focus();
					}
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void txtmzh_Move(object sender, System.EventArgs e)
		{
			txtmzh.Focus();
			txtmzh.Select(0,txtmzh.Text.Length);
		}

		private void txtmzh_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Control control=(Control)sender;
			if (control.Name=="txtmzh")
			{
				txtmzh.Focus();
				txtmzh.Select(0,txtmzh.Text.Length);
			}
			if (control.Name=="txttmk")
			{
				txttmk.Focus();
				txttmk.Select(0,txttmk.Text.Length);
			}
			if (control.Name=="txtghxh")
			{
                //txtghxh.Focus();
                //txtghxh.Select(0,txtghxh.Text.Length);
			}
			if (control.Name=="txtfph")
			{
				txtfph.Focus();
				txtfph.Select(0,txtfph.Text.Length);
			}
		}

		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
			Control control=(Control)sender;
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();
			this.chkall.Checked=false;
			this.chkall.Enabled=this.rdo1.Checked==true?true:false;
			this.butfy.Enabled=this.rdo1.Checked==true?true:false;

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

        private void Frmcffy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void lblnl_Click(object sender, EventArgs e)
        {

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
            if (control.Name == "txtmzh" && rdo2.Checked==true)
                chkrq.Checked = false;
            
        }

        private void button_ref_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];
                parameters[0].Value = _menuTag.Function_Name.Trim();
                parameters[1].Value = InstanceForm.BCurrentDept.DeptId;
                parameters[2].Value = dtprq_ref.Value.ToShortDateString()+"";
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
            if (dataGridView1.CurrentCell == null) return;
            if (dv.Table.Rows.Count == 0) return;

            this.Cursor = PubStaticFun.WaitCursor();

            try
            {
                int nrow = dataGridView1.CurrentCell.RowIndex;
                int bk = this.rdodq.Checked == true ? 0 : 1;
                int fybz = rdo1.Checked==true?0:1;
                string sfrq1 = "";
                string sfrq2 = "";
                string fyrq1 = "";
                string fyrq2 = "";
                string brxxid = dv[nrow]["brxxid"].ToString();
                string fph = dv[nrow]["��Ʊ��"].ToString();

                sfrq1 = chkrq.Checked == true ? dtprq1.Value.ToShortDateString() : "";
                sfrq2 = chkrq.Checked == true ? dtprq2.Value.ToShortDateString() : "";
                fyrq1 = "";
                fyrq2 = "";



               DataTable  tb = MZYF.SelectMzcfk(_menuTag.Function_Name, InstanceForm.BCurrentDept.DeptId, Guid.Empty, txtxm.Text.Trim(),
                     fph, 0,
                    fyrq1, fyrq2, 0, fybz, "", sfrq1, sfrq2, 0, "", "", 0, 0, "", "", "", 0, 0, Guid.Empty,new Guid(brxxid), Convert.ToInt32(this.rdols.Checked), InstanceForm.BDatabase);

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
            string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");

            if (Convertor.IsNull(_Fyckh,"")  == "")
            {
                MessageBox.Show("��û��ѡ��ҩ����,��ѡ�������","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            

            DataTable tb = (DataTable)myDataGrid1.DataSource;
            DataRow[] selrow;
            if (rdo1.Checked==true)
                selrow = tb.Select("��ҩ='��' and ypid<>''");
            else
                selrow = tb.Select("��ҩ='��' and ypid<>''");

            if (selrow.Length==0) { MessageBox.Show("��ѡ���˴������ٺ���", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            string brxm = selrow[0]["����"].ToString();// tb.Rows[0]["����"].ToString();��Ϊѡ��Ĳ���
            decimal sumje ;
            if (rdo1.Checked==true)
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
            string[] GroupbyField ={"FPID","����","��Ʊ��","�����"};
            string[] ComputeField ={ "���" };
            string[] CField ={ "sum" };
            DataTable tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
            if (tbcf.Rows.Count == 0) { MessageBox.Show("û��Ҫ��ҩ��ҩƷ��¼"); return; }
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
                parameters[9].Value = InstanceForm.BCurrentUser.EmployeeId ;

                parameters[10].Text = "@jhlx";
                parameters[10].Value = "call";

                int iii = InstanceForm.BDatabase.DoCommand("SP_YF_FYJH", parameters, 60);
            }

            if (bqybjq == "true" && _menuTag.Function_Name == "Fun_ts_yf_mzfy")
            {
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
                string ss = "��" + brxm + "��" +_Fyckmc + "��ȡҩ";
                _voiceCaller.Call(ss);

                VoiceCaller call = new VoiceCaller(ss, _voiceCaller);
                thCall = new Thread(new ThreadStart(call.VoiceCall));
                call.Thread = thCall;
                thCall.Start();
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

                if (rdo2.Checked==true)
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



	}
}
