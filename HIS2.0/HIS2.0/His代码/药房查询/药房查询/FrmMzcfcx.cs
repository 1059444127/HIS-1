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
using TrasenFrame.Forms;

namespace ts_yf_cx
{
	/// <summary>
	/// Frmcffy ��ժҪ˵����
	/// </summary>
	public class FrmMzcfcx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
        private Form _mdiParent;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butcfcx;
		private System.Windows.Forms.RadioButton rdols;
        private System.Windows.Forms.RadioButton rdodq;
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
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtmzh;
		private System.Windows.Forms.TextBox txttmk;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfph;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private YpConfig s;
		private string IPAddRess;
		private System.Windows.Forms.CheckBox chkxp;
        public string _Fyckh;
        private TextBox _textBox;
        private Label label8;
        private TextBox txtxm;
        private ComboBox cmbklx;
        private Panel panel4;
        private CheckBox chkqd;
        private CheckBox chkcf;
        private CheckBox chkzsd;
        private Label label5;
        private TextBox txtzdmc;
        private Label label6;
        private TextBox txtje1;
        private Label label7;
        private CheckBox chkrsyp;
        private CheckBox chkwyyp;
        private CheckBox chkpsyp;
        private CheckBox chkcfyp;
        private CheckBox chkdjyp;
        private CheckBox chkmzyp;
        private CheckBox chkgzyp;
        private CheckBox chkjsyp;
        private TextBox txtje2;
        private Label label9;
        private ComboBox cmbyjks;
        private Label label16;
        private CheckBox chkkss;
        private TextBox txtjzys;
        private Label label10;
        private TextBox txtjzks;
        private Label label11;
        private Button btnCurrentPrint;
        private bool  _ClickQuit=false;
        private int printRows = -1;

		public FrmMzcfcx(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.dtprq2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtprq1 = new System.Windows.Forms.DateTimePicker();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.ButtonDataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtjzys = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtjzks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkkss = new System.Windows.Forms.CheckBox();
            this.txtje2 = new System.Windows.Forms.TextBox();
            this.txtje1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkrsyp = new System.Windows.Forms.CheckBox();
            this.chkcfyp = new System.Windows.Forms.CheckBox();
            this.txtzdmc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbklx = new System.Windows.Forms.ComboBox();
            this.txtxm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtfph = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttmk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butcfcx = new System.Windows.Forms.Button();
            this.txtmzh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkpsyp = new System.Windows.Forms.CheckBox();
            this.chkdjyp = new System.Windows.Forms.CheckBox();
            this.chkmzyp = new System.Windows.Forms.CheckBox();
            this.chkwyyp = new System.Windows.Forms.CheckBox();
            this.chkgzyp = new System.Windows.Forms.CheckBox();
            this.chkjsyp = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.btnCurrentPrint = new System.Windows.Forms.Button();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkqd = new System.Windows.Forms.CheckBox();
            this.chkcf = new System.Windows.Forms.CheckBox();
            this.chkzsd = new System.Windows.Forms.CheckBox();
            this.chkxp = new System.Windows.Forms.CheckBox();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.chkprintview = new System.Windows.Forms.CheckBox();
            this.butprint = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
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
            this.SuspendLayout();
            // 
            // dtprq2
            // 
            this.dtprq2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq2.Location = new System.Drawing.Point(455, 33);
            this.dtprq2.Name = "dtprq2";
            this.dtprq2.Size = new System.Drawing.Size(140, 21);
            this.dtprq2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(433, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "��";
            // 
            // dtprq1
            // 
            this.dtprq1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtprq1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprq1.Location = new System.Drawing.Point(292, 33);
            this.dtprq1.Name = "dtprq1";
            this.dtprq1.Size = new System.Drawing.Size(138, 21);
            this.dtprq1.TabIndex = 7;
            // 
            // rdols
            // 
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(246, 10);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(58, 24);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "��ʷ";
            // 
            // rdodq
            // 
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(190, 10);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(58, 24);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "��ǰ";
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
            this.myDataGrid1.Size = new System.Drawing.Size(980, 322);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.Silver;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.txtjzys);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.txtjzks);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.chkkss);
            this.panel8.Controls.Add(this.txtje2);
            this.panel8.Controls.Add(this.txtje1);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.chkrsyp);
            this.panel8.Controls.Add(this.chkcfyp);
            this.panel8.Controls.Add(this.txtzdmc);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.cmbklx);
            this.panel8.Controls.Add(this.txtxm);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.txtfph);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.txttmk);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.butcfcx);
            this.panel8.Controls.Add(this.txtmzh);
            this.panel8.Controls.Add(this.dtprq1);
            this.panel8.Controls.Add(this.dtprq2);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.butquit);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.chkpsyp);
            this.panel8.Controls.Add(this.chkdjyp);
            this.panel8.Controls.Add(this.chkmzyp);
            this.panel8.Controls.Add(this.chkwyyp);
            this.panel8.Controls.Add(this.chkgzyp);
            this.panel8.Controls.Add(this.chkjsyp);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(980, 117);
            this.panel8.TabIndex = 1;
            // 
            // txtjzys
            // 
            this.txtjzys.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjzys.Location = new System.Drawing.Point(292, 90);
            this.txtjzys.Name = "txtjzys";
            this.txtjzys.Size = new System.Drawing.Size(119, 23);
            this.txtjzys.TabIndex = 192;
            this.txtjzys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtjzys_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(229, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 193;
            this.label10.Text = "����ҽ��";
            // 
            // txtjzks
            // 
            this.txtjzks.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtjzks.Location = new System.Drawing.Point(83, 90);
            this.txtjzks.Name = "txtjzks";
            this.txtjzks.Size = new System.Drawing.Size(131, 23);
            this.txtjzks.TabIndex = 190;
            this.txtjzks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtjzks_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(21, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 191;
            this.label11.Text = "��������";
            // 
            // chkkss
            // 
            this.chkkss.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkkss.ForeColor = System.Drawing.Color.Black;
            this.chkkss.Location = new System.Drawing.Point(753, 62);
            this.chkkss.Name = "chkkss";
            this.chkkss.Size = new System.Drawing.Size(80, 24);
            this.chkkss.TabIndex = 189;
            this.chkkss.Text = "������";
            // 
            // txtje2
            // 
            this.txtje2.BackColor = System.Drawing.Color.White;
            this.txtje2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtje2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtje2.Location = new System.Drawing.Point(150, 63);
            this.txtje2.Name = "txtje2";
            this.txtje2.Size = new System.Drawing.Size(47, 21);
            this.txtje2.TabIndex = 188;
            this.txtje2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // txtje1
            // 
            this.txtje1.BackColor = System.Drawing.Color.White;
            this.txtje1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtje1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtje1.Location = new System.Drawing.Point(83, 63);
            this.txtje1.Name = "txtje1";
            this.txtje1.Size = new System.Drawing.Size(48, 21);
            this.txtje1.TabIndex = 186;
            this.txtje1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 185;
            this.label7.Text = "�������";
            // 
            // chkrsyp
            // 
            this.chkrsyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkrsyp.ForeColor = System.Drawing.Color.Black;
            this.chkrsyp.Location = new System.Drawing.Point(681, 62);
            this.chkrsyp.Name = "chkrsyp";
            this.chkrsyp.Size = new System.Drawing.Size(80, 24);
            this.chkrsyp.TabIndex = 184;
            this.chkrsyp.Text = "����ҩƷ";
            // 
            // chkcfyp
            // 
            this.chkcfyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkcfyp.ForeColor = System.Drawing.Color.Black;
            this.chkcfyp.Location = new System.Drawing.Point(608, 62);
            this.chkcfyp.Name = "chkcfyp";
            this.chkcfyp.Size = new System.Drawing.Size(80, 24);
            this.chkcfyp.TabIndex = 183;
            this.chkcfyp.Text = "����ҩƷ";
            // 
            // txtzdmc
            // 
            this.txtzdmc.Location = new System.Drawing.Point(292, 63);
            this.txtzdmc.Name = "txtzdmc";
            this.txtzdmc.Size = new System.Drawing.Size(303, 21);
            this.txtzdmc.TabIndex = 43;
            this.txtzdmc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(227, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "�������";
            // 
            // cmbklx
            // 
            this.cmbklx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbklx.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbklx.Location = new System.Drawing.Point(289, 5);
            this.cmbklx.Name = "cmbklx";
            this.cmbklx.Size = new System.Drawing.Size(72, 22);
            this.cmbklx.TabIndex = 40;
            // 
            // txtxm
            // 
            this.txtxm.Enabled = false;
            this.txtxm.Location = new System.Drawing.Point(83, 33);
            this.txtxm.Name = "txtxm";
            this.txtxm.Size = new System.Drawing.Size(114, 21);
            this.txtxm.TabIndex = 39;
            this.txtxm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "��������";
            // 
            // txtfph
            // 
            this.txtfph.BackColor = System.Drawing.Color.White;
            this.txtfph.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtfph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtfph.Location = new System.Drawing.Point(515, 6);
            this.txtfph.Name = "txtfph";
            this.txtfph.Size = new System.Drawing.Size(80, 21);
            this.txtfph.TabIndex = 0;
            this.txtfph.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(464, 10);
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
            this.txttmk.Location = new System.Drawing.Point(363, 6);
            this.txttmk.Name = "txttmk";
            this.txttmk.Size = new System.Drawing.Size(100, 21);
            this.txttmk.TabIndex = 2;
            this.txttmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(203, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "������/����";
            // 
            // butcfcx
            // 
            this.butcfcx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butcfcx.ForeColor = System.Drawing.Color.Navy;
            this.butcfcx.Location = new System.Drawing.Point(849, 9);
            this.butcfcx.Name = "butcfcx";
            this.butcfcx.Size = new System.Drawing.Size(77, 24);
            this.butcfcx.TabIndex = 19;
            this.butcfcx.Text = "��ѯ(&F)";
            this.butcfcx.Click += new System.EventHandler(this.butcfcx_Click);
            // 
            // txtmzh
            // 
            this.txtmzh.BackColor = System.Drawing.Color.White;
            this.txtmzh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmzh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtmzh.Location = new System.Drawing.Point(83, 6);
            this.txtmzh.Name = "txtmzh";
            this.txtmzh.Size = new System.Drawing.Size(114, 21);
            this.txtmzh.TabIndex = 0;
            this.txtmzh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtghxh_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 10);
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
            this.butquit.Location = new System.Drawing.Point(851, 57);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(71, 24);
            this.butquit.TabIndex = 15;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.UseVisualStyleBackColor = false;
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(225, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "��ҩ����";
            // 
            // chkpsyp
            // 
            this.chkpsyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkpsyp.ForeColor = System.Drawing.Color.Black;
            this.chkpsyp.Location = new System.Drawing.Point(753, 10);
            this.chkpsyp.Name = "chkpsyp";
            this.chkpsyp.Size = new System.Drawing.Size(80, 24);
            this.chkpsyp.TabIndex = 179;
            this.chkpsyp.Text = "Ƥ��ҩƷ";
            // 
            // chkdjyp
            // 
            this.chkdjyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkdjyp.ForeColor = System.Drawing.Color.Black;
            this.chkdjyp.Location = new System.Drawing.Point(681, 10);
            this.chkdjyp.Name = "chkdjyp";
            this.chkdjyp.Size = new System.Drawing.Size(80, 24);
            this.chkdjyp.TabIndex = 178;
            this.chkdjyp.Text = "����ҩƷ";
            // 
            // chkmzyp
            // 
            this.chkmzyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkmzyp.ForeColor = System.Drawing.Color.Black;
            this.chkmzyp.Location = new System.Drawing.Point(608, 10);
            this.chkmzyp.Name = "chkmzyp";
            this.chkmzyp.Size = new System.Drawing.Size(80, 24);
            this.chkmzyp.TabIndex = 177;
            this.chkmzyp.Text = "����ҩƷ";
            // 
            // chkwyyp
            // 
            this.chkwyyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkwyyp.ForeColor = System.Drawing.Color.Black;
            this.chkwyyp.Location = new System.Drawing.Point(753, 36);
            this.chkwyyp.Name = "chkwyyp";
            this.chkwyyp.Size = new System.Drawing.Size(84, 24);
            this.chkwyyp.TabIndex = 182;
            this.chkwyyp.Text = "����ҩƷ";
            // 
            // chkgzyp
            // 
            this.chkgzyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkgzyp.ForeColor = System.Drawing.Color.Black;
            this.chkgzyp.Location = new System.Drawing.Point(681, 36);
            this.chkgzyp.Name = "chkgzyp";
            this.chkgzyp.Size = new System.Drawing.Size(84, 24);
            this.chkgzyp.TabIndex = 181;
            this.chkgzyp.Text = "����ҩƷ";
            // 
            // chkjsyp
            // 
            this.chkjsyp.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkjsyp.ForeColor = System.Drawing.Color.Black;
            this.chkjsyp.Location = new System.Drawing.Point(608, 36);
            this.chkjsyp.Name = "chkjsyp";
            this.chkjsyp.Size = new System.Drawing.Size(80, 24);
            this.chkjsyp.TabIndex = 180;
            this.chkjsyp.Text = "����ҩƷ";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(130, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 20);
            this.label9.TabIndex = 187;
            this.label9.Text = "��";
            // 
            // chkall
            // 
            this.chkall.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkall.ForeColor = System.Drawing.Color.Black;
            this.chkall.Location = new System.Drawing.Point(319, 13);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(56, 21);
            this.chkall.TabIndex = 20;
            this.chkall.Text = "ȫѡ";
            this.chkall.Visible = false;
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            this.panel17.Controls.Add(this.btnCurrentPrint);
            this.panel17.Controls.Add(this.cmbyjks);
            this.panel17.Controls.Add(this.label16);
            this.panel17.Controls.Add(this.panel4);
            this.panel17.Controls.Add(this.chkprint);
            this.panel17.Controls.Add(this.chkprintview);
            this.panel17.Controls.Add(this.chkall);
            this.panel17.Controls.Add(this.butprint);
            this.panel17.Controls.Add(this.rdols);
            this.panel17.Controls.Add(this.rdodq);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(982, 50);
            this.panel17.TabIndex = 14;
            // 
            // btnCurrentPrint
            // 
            this.btnCurrentPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCurrentPrint.ForeColor = System.Drawing.Color.Navy;
            this.btnCurrentPrint.Location = new System.Drawing.Point(667, 0);
            this.btnCurrentPrint.Name = "btnCurrentPrint";
            this.btnCurrentPrint.Size = new System.Drawing.Size(113, 24);
            this.btnCurrentPrint.TabIndex = 137;
            this.btnCurrentPrint.Text = "��ӡ��ǰ����(&C)";
            this.btnCurrentPrint.Click += new System.EventHandler(this.btnCurrentPrint_Click);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.ForeColor = System.Drawing.Color.Blue;
            this.cmbyjks.Location = new System.Drawing.Point(64, 13);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(112, 20);
            this.cmbyjks.TabIndex = 135;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(8, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 19);
            this.label16.TabIndex = 136;
            this.label16.Text = "ҩ������";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.Navy;
            this.butprint.Location = new System.Drawing.Point(667, 25);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(113, 24);
            this.butprint.TabIndex = 14;
            this.butprint.Text = "��ӡ���д���(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
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
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(980, 322);
            this.panel3.TabIndex = 3;
            // 
            // FrmMzcfcx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(982, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.splitter2);
            this.Name = "FrmMzcfcx";
            this.Text = "���﷢ҩ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmcffy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
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
            this.ResumeLayout(false);

		}
		#endregion


		//���ش���
		private void Frmcffy_Load(object sender, System.EventArgs e)
		{
            butcfcx.Enabled = true;
            txtxm.Enabled = true;
			CshMxGrid(this.myDataGrid1);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            Yp.AddcmbYjks_mz(true,cmbyjks, InstanceForm.BDatabase,_menuTag.Jgbm);

			this.dtprq1.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 00:00:00");
            this.dtprq2.Value = Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");
			
            IPAddRess = TrasenClasses.GeneralClasses.PubStaticFun.GetMacAddress();

			this.txtmzh.Focus();

            if ((new SystemCfg(8006)).Config == "0")
                this.myDataGrid1.TableStyles[0].GridColumnStyles["ҽ��"].Width = 0;


            if (s.���﷢ҩʱ��ӡ���� == true) chkcf.Checked = true;
            if (s.���﷢ҩʱ��ӡ�嵥 == true) chkqd.Checked = true;
            if (s.���﷢ҩʱ��ӡע�䵥 == true) chkzsd.Checked = true;

            if (s.���﷢ҩʱĬ�ϴ�ӡ���� == true) chkprint.Checked = true;


            this.cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
            if (cmbyjks.SelectedIndex == -1)
                cmbyjks.SelectedIndex = 0;

		}

		
		private void CshMxGrid(TrasenClasses.GeneralControls.ButtonDataGridEx  xcjwDataGrid)
		{
			#region �����ϸ����
            //string[] HeaderText	={"���","��ҩ","Ƥ��","��Ʊ��","��Ŀ","�ܽ��","����","����","��Ʒ��","Ʒ��","����","��λ","���","����","����","���","����","���","�����","�Ա�","����","���","����","ҽ��","��ҩ","�÷�","Ƶ��","����","������λ","����","���־","�������","¼������","¼��Ա","�շ�����","�Ƿ�Ա","��ҩ����","��ҩԱ","��ҩԱ","������","CFLX","JSSJH","CFXH","PATID","YSDM","KSDM","sfczy","qrczyh","pyczyh","��ҩ����","��ҩ����","���ʽ��","�Żݽ��","�Ը����","YPID","YDWBL","cfmxid","����","������","�������","ʹ��Ƶ��","����"};
            //string[] MappingName={"���","��ҩ","Ƥ��","��Ʊ��","��Ŀ","�ܽ��","����","����","��Ʒ��","Ʒ��","����","��λ","���","����","����","���","����","���","�����","�Ա�","����","���","����","ҽ��","��ҩ","�÷�","Ƶ��","����","������λ","����","���־","�������","¼������","¼��Ա","�շ�����","�Ƿ�Ա","��ҩ����","��ҩԱ","��ҩԱ","������","CFLX","JSSJH","CFXH","PATID","YSDM","KSDM","sfczy","qrczyh","pyczyh","��ҩ����","��ҩ����","���ʽ��","�Żݽ��","�Ը����","YPID","YDWBL","cfmxid","����","������","�������","ʹ��Ƶ��","����"};
            //int	  [] ColWidth={40,30,30,60,0,0,60,0,110,110,50/*ypsl*/,40,90,90,60,0,40,65,0,0,0,0,0,50,0,0/*userage*/,0,0,0,0,0,0,90,60,90/*��������*/,0,90,60,60,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,90,0};
            //bool[] ColReadOnly={true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
            //bool[] ColBool={true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};

            string[] HeaderText ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���","ʹ�÷���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���" ,"zsyp"};
            string[] MappingName ={ "���", "��ҩ", "Ƥ��", "��Ʊ��", "��Ŀ", "�ܽ��", "����", "����", "��Ʒ��", "Ʒ��", "����", "��λ", "���", "����", "����", "���", "����", "���", "ʹ�÷���", "�����", "�Ա�", "����", "���", "����", "ҽ��", "��ҩ", "�÷�", "Ƶ��", "����", "������λ", "����", "���־", "�������", "¼������", "¼��Ա", "�շ�����", "�Ƿ�Ա", "��ҩ����", "��ҩԱ", "��ҩԱ", "������", "CFLX", "JSSJH", "CFXH", "PATID", "YSDM", "KSDM", "sfczy", "qrczyh", "pyczyh", "��ҩ����", "��ҩ����", "���ʽ��", "�Żݽ��", "�Ը����", "YPID", "YDWBL", "cfmxid", "����", "������", "�������", "ʹ��Ƶ��", "����", "��λ���", "zsyp" };
            int[] ColWidth ={ 40, 30, 30, 60, 0, 0, 60, 0, 110, 110, 50/*ypsl*/, 40, 90, 90, 60, 0, 40, 65,120, 70, 40, 40, 70, 70, 50, 0, 0/*userage*/, 0, 0, 0, 0, 0, 0, 90, 60, 90/*��������*/, 0, 90, 60, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 80 };
            bool[] ColReadOnly ={ true, true, true, true, true, true, true, true, true,true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,true };
            bool[] ColBool ={ true, false, false, false, false, false, false, false, true,false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,false };


			DataTable dtTmp=new DataTable();
			dtTmp.TableName="tbmx";

			for(int j=0;j<=HeaderText.Length-1;j++)
			{
				//DataGridEnableBoolColumn
				if (ColBool[j]==false)
				{
					DataGridEnableTextBoxColumn colText=new DataGridEnableTextBoxColumn(j);
					colText.HeaderText=HeaderText[j];
					colText.MappingName=MappingName[j];
					colText.Width=ColWidth[j];
					colText.NullText="";
					colText.ReadOnly=ColReadOnly[j];
					//colText.CheckCellEnabled+=new XcjwHIS.PublicControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
					colText.CheckCellEnabled+=new TrasenClasses.GeneralControls.DataGridEnableTextBoxColumn.EnableCellEventHandler(myDataGrid1_CheckCellEnabled);
					
					xcjwDataGrid.TableStyles[0].GridColumnStyles.Add(colText);
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

                #region ѡ�е��иı���ɫ LQQ 2013-3-29
                if(printRows.ToString() == e.Row.ToString())             
                    e.BackColor= Color.Pink;
                #endregion


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

            string where = "";
            if (chkmzyp.Checked == true) where = where == "" ? " mzyp=1 " : where + " or mzyp=1 ";
            if (chkdjyp.Checked == true) where = where == "" ? " djyp=1 " : where + " or djyp=1 ";
            if (chkpsyp.Checked == true) where = where == "" ? " psyp=1 " : where + " or psyp=1 ";
            if (chkjsyp.Checked == true) where = where == "" ? " jsyp=1 " : where + " or jsyp=1 ";
            if (chkgzyp.Checked == true) where = where == "" ? " gzyp=1 " : where + " or gzyp=1 ";
            if (chkwyyp.Checked == true) where = where == "" ? " wyyp=1 " : where + " or wyyp=1 ";
            if (chkcfyp.Checked == true) where = where == "" ? " cfyp=1 " : where + " or cfyp=1 ";
            if (chkrsyp.Checked == true) where = where == "" ? " rsyp=1 " : where + " or rsyp=1 ";
            if (chkkss.Checked == true) where = where == "" ? " kssdjid>0 " : where + " or kssdjid=1 ";

			try
			{

                ParameterEx[] parameters = new ParameterEx[18];
                parameters[0].Text = "@functionname";
                parameters[0].Value = _menuTag.Function_Name;

                parameters[1].Text = "@deptid";
                parameters[1].Value = Convert.ToInt32(cmbyjks.SelectedValue) ;

                parameters[2].Text = "@blh";
                parameters[2].Value = txtmzh.Text.Trim();

                parameters[3].Text = "@hzxm";
                parameters[3].Value = txtxm.Text.Trim();

                parameters[4].Text = "@fph";
                parameters[4].Value = txtfph.Text.Trim();

                parameters[5].Text = "@klx";
                parameters[5].Value = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue,"0"));

                parameters[6].Text = "@kh";
                parameters[6].Value = txttmk.Text.Trim();

                parameters[7].Text = "@zdmc";
                parameters[7].Value = txtzdmc.Text.Trim();

                parameters[8].Text = "@je1";
                parameters[8].Value = Convert.ToDecimal(Convertor.IsNull(txtje1.Text,"0"));

                parameters[9].Text = "@je2";
                parameters[9].Value = Convert.ToDecimal(Convertor.IsNull(txtje2.Text, "0"));

                parameters[10].Text = "@qrrq1";
                parameters[10].Value = dtprq1.Value.ToString();

                parameters[11].Text = "@qrrq2";
                parameters[11].Value = dtprq2.Value.ToString();

                parameters[12].Text = "@qrczyh";
                parameters[12].Value = 0;

                parameters[13].Text = "@fybz";
                parameters[13].Value = 1;

                parameters[14].Text = "@where";
                parameters[14].Value = where;

                parameters[15].Text = "@bk";
                parameters[15].Value = rdols.Checked==true?1:0;

                parameters[16].Text = "@ksdm";
                parameters[16].Value = Convertor.IsNull(txtjzks.Tag,"0");

                parameters[17].Text = "@ysdm";
                parameters[17].Value = Convertor.IsNull(txtjzys.Tag, "0");

                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_SELECT_MZCF_CX", parameters, 60);



				this.AddPresc(tb);

				chkall.Checked=false;


                //���鴦��
                string[] GroupbyField ={ "PATID"};
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum", "count" };
                TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                xcset.TsDataTable = tb;
                DataTable tbpat = xcset.GroupTable(GroupbyField, ComputeField, CField,"patid<>''");

                //���鴦��
                string[] GroupbyField1 ={ "CFXH" };
                string[] ComputeField1 ={ "���" };
                string[] CField1 ={ "sum", "count" };
                TrasenFrame.Classes.TsSet xcset2 = new TrasenFrame.Classes.TsSet();
                xcset2.TsDataTable = tb;
                DataTable tbcf = xcset2.GroupTable(GroupbyField1, ComputeField1, CField1,"patid<>''");

                statusBar1.Panels[0].Text = "�����˴�:" + tbpat.Rows.Count.ToString();
                statusBar1.Panels[1].Text = "��������:" + tbcf.Rows.Count.ToString();
                string je=Convertor.IsNull(tbcf.Compute("sum(���)",""),"");
                statusBar1.Panels[2].Text = "�������:" + je;


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

            //if (tbcf.Rows.Count > 0) cmbpyr.Text = tbcf.Rows[0]["��ҩԱ"].ToString().Trim();
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
				}
				
				_prescNo=tbcf.Rows[i]["������"].ToString().Trim();
				
			}

			//������һ�Ŵ����ĺϼ�
			DataRow endrow=tb.NewRow();
			endrow["���"]="С��";
			endrow["���"]=_PrescJe.ToString("0.00");
			endrow["������"]=_prescNo;
			tb.Rows.Add(endrow);
		}

		
		#region һ�����
	
		//��ϸ�еİ�ť�¼�
		private void btnCol_CellButtonClicked(object sender, DataGridCellButtonClickEventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			//if (this.rdo2.Checked==true)return;
			for(
                int i=0;i<=tb.Rows.Count-1;i++)
			{
				if (tb.Rows[i]["������"].ToString().Trim()==tb.Rows[e.RowIndex]["������"].ToString().Trim() && tb.Rows[i]["������"].ToString().Trim()!="" && tb.Rows[i]["��ҩ"].ToString().Trim()!="��" )
				{
					if (tb.Rows[i]["��ҩ"].ToString().Trim()=="")
						tb.Rows[i]["��ҩ"]="��";
					else
						tb.Rows[i]["��ҩ"]="";
				}
			}
            ////PrintRows_Current(e.RowIndex);

        }

        #region  ÿ�Ŵ������Ӵ�ӡ���� ���С��ʱ���Ӵ�ӡ���� LQQ 2013-3-29
        private void PrintRows_Current(int currentRows)
        {
            ///////////////////ÿ�Ŵ������Ӵ�ӡ���� ���С��ʱ���Ӵ�ӡ���� LQQ 2013-3-29
            //int currentRows = 0;
            try
            {
                if (currentRows >= 0)
                {
                    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                    string xh_str = Convert.ToString(tb.Rows[currentRows]["���"]).Trim();
                    if (xh_str != "")
                    {
                        if (xh_str == "С��")
                            currentRows = currentRows - 1;
                        //else
                        //    currentRows = currentRows;
                        string cfid_str = Convert.ToString(tb.Rows[currentRows]["������"]).Trim();
                        string fph_str = Convert.ToString(tb.Rows[currentRows]["��Ʊ��"]).Trim();

                        PrintFun_CF(cfid_str);
                        #region ������ע�䵥
                        //if (e.RowIndex > 0)
                        //{
                        //����
                        if (chkcf.Checked == true)
                            this.PrintCf(tb.Rows[currentRows], 1);
                        //ע�䵥
                        if (chkzsd.Checked == true)
                            this.PrintCf(tb.Rows[currentRows], 2);
                        //��Ʊ��
                        if (chkqd.Checked == true)
                            this.PrintCf(fph_str);
                        //}
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("�Բ���,����û��Ҫ��ӡ������!");
                    }
                }
                ////////////////////////////
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        #endregion
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


		
		private void butquit_Click(object sender, System.EventArgs e)
		{
            _ClickQuit = true;
			this.Close();
        }

        #region ����ÿ�Ŵ�����ӡ����
        /// <summary>
        /// ����ÿ�Ŵ�����ӡ����
        /// </summary>
        private void PrintFun_CF(string cfid_str)
        {
            #region //Ĭ�ϴ�ӡСƱ
            if (chkxp.Checked == true)//Ĭ�ϴ�ӡСƱ
            {
                string s_str = "( ��ҩ='��' or ��ҩ='��')  and ����<>'' and ������='"+cfid_str+"'";/////////LQQ
                this.PrintCfXP(s_str);
                return;
            }
            #endregion
        }

        #endregion

        private void butprint_Click(object sender, System.EventArgs e)
		{
            #region �����ӡ������ť
            try
            {
                #region //Ĭ�ϴ�ӡСƱ
                if (chkxp.Checked == true)//Ĭ�ϴ�ӡСƱ
                {
                    string s_str = "( ��ҩ='��' or ��ҩ='��')  and ����<>''";/////////LQQ
                    this.PrintCfXP(s_str);
                    return;
                }
                #endregion

                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                butprint.Enabled = false;

                //���鴦��
                DataRow[] selrow = tb.Select("(��ҩ='��' or  ��ҩ='��') and ypid<>''");
                DataTable tbsel = tb.Clone();
                for (int w = 0; w <= selrow.Length - 1; w++)
                    tbsel.ImportRow(selrow[w]);

                DataTable tbcf;
                //if (rdo1.Checked == true) //���Ϊδ��ҩ��ȡ�ܽ��ѷ�ҩ��ȡ���ֵ
                //{
                //    string[] GroupbyField ={ "cfxh", "��Ʊ��", "�ܽ��", "���", "�����" };
                //    string[] ComputeField ={ };
                //    string[] CField ={  };
                //    tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                //}
                //else
                //{
                string[] GroupbyField ={ "cfxh", "��Ʊ��", "���", "�����" };
                string[] ComputeField ={ "���" };
                string[] CField ={ "sum" };
                tbcf = FunBase.GroupbyDataTable(tbsel, GroupbyField, ComputeField, CField, null);
                //}


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
                    string[] GroupbyFieldqd ={ "��Ʊ��" };
                    string[] ComputeFieldqd ={ };
                    string[] CFieldqd ={ };
                    tbcfqd = FunBase.GroupbyDataTable(tbselqd, GroupbyFieldqd, ComputeFieldqd, CFieldqd, null);
                    for (int i = 0; i <= tbcfqd.Rows.Count - 1; i++)
                    {
                        this.PrintCf(tbcfqd.Rows[i]["��Ʊ��"].ToString());
                    }
                }



                butprint.Enabled = true;
            }
            catch (System.Exception err)
            {
                butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
            #endregion
		}
        
        private void PrintCf(string fph)
        {
            DataTable tb2 = (DataTable)this.myDataGrid1.DataSource;
            DataRow[] rows;

            string where = "(��ҩ='��' or  ��ҩ='��') and ypid<>''";
            if (fph != "") where = where + " and ��Ʊ��='"+fph+"'";
            rows = tb2.Select(where );
            if (rows.Length == 0) return;

            ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
            DataRow myrow = null;
            int yzzh = 0;

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
                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
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
                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
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
                myrow["fzbz"] = rows[i]["���־"].ToString();
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


        #region ��ӡĬ��СƱ
        private void PrintCfXP(string selectStr)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;

			DataRow[] rows;
            rows = tb.Select(selectStr);//"( ��ҩ='��' or ��ҩ='��')  and ����<>''"
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
                myrow["pyr"] = Convert.ToString(rows[i]["��ҩԱ"]);
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
        #endregion


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

					DataTable tb=null;

					if (control.Name=="txtmzh")
					{
                        this.txtmzh.Text = FunBase.returnMzh(this.txtmzh.Text, InstanceForm.BDatabase,InstanceForm._menuTag.Jgbm);
						DataTable tbghxx=ts_mz_brxx.MzGhxx.ReadGhxx(Guid.Empty,Guid.Empty,txtmzh.Text.Trim(),0,Convert.ToInt16(this.rdols.Checked),InstanceForm.BDatabase);
						if (tbghxx.Rows.Count==0){MessageBox.Show("û���ҵ����ˣ�����������","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;}
						this.txttmk.Text="";
						this.txtfph.Text="";
						_textBox=txtmzh;

					}
					if (control.Name=="txttmk")
					{
                        int klx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                        txttmk.Text = Fun.returnKh(klx, txttmk.Text, InstanceForm.BDatabase);
                        brxx = new ts_mz_brxx.MzBrxx(Guid.Empty, klx, txttmk.Text.Trim(), "", Convert.ToInt16(this.rdols.Checked), InstanceForm.BDatabase);
						this.txtmzh.Text="";
						//this.txtghxh.Text="";
						this.txtfph.Text="";
						_textBox=txttmk;
					}

					if (control.Name=="txtfph")
					{
                        if (Convertor.IsNumeric(txtfph.Text) == false) { MessageBox.Show("��Ʊ�����������֣�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
						this.txtmzh.Text="";
						this.txttmk.Text="";
						//this.txtghxh.Text="";
						_textBox=txtfph;
					}

                    butcfcx_Click(sender, e);
					this.chkall.Checked=false;

					

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

        private void txtxm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                butcfcx_Click(sender, null);
        }

        private void butfy_Click(object sender, EventArgs e)
        {

        }

        private void txtjzks_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {
                string[] headtext = new string[] { "��������", "������", "ƴ����", "dept_id" };
                string[] mappingname = new string[] { "name", "d_code", "py_code", "dept_id" };
                string[] searchfields = new string[] { "d_code", "py_code", "wb_code" };
                int[] colwidth = new int[] { 150, 100, 100, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhks(false, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                    return;
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["dept_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void txtjzys_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            int nkey = (int)e.KeyChar;
            if (nkey == 8 || nkey == 46) { control.Text = ""; control.Tag = ""; return; }
            if ((int)e.KeyChar != 13)
            {

                string[] headtext = new string[] { "ҽ������", "����", "����", "ƴ����", "�����", "employee_id" };
                string[] mappingname = new string[] { "name", "ys_code", "code", "py_code", "wb_code", "employee_id" };
                string[] searchfields = new string[] { "ys_code", "py_code", "wb_code" };//, "code" Modify By Tany 2008-12-19 ��һ���й���
                int[] colwidth = new int[] { 100, 75, 75, 75, 75, 0 };
                TrasenFrame.Forms.FrmSelectCard f = new FrmSelectCard(searchfields, headtext, mappingname, colwidth);
                f.sourceDataTable = Fun.GetGhys(0, InstanceForm.BDatabase);
                f.WorkForm = this;
                f.srcControl = control;
                f.Font = control.Font;
                f.Width = 400;
                f.ReciveString = e.KeyChar.ToString();
                e.Handled = true;
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    control.Focus();
                }
                else
                {
                    control.Tag = Convert.ToInt32(f.SelectDataRow["employee_id"]);
                    control.Text = f.SelectDataRow["name"].ToString().Trim();
                }
            }
        }

        private void btnCurrentPrint_Click(object sender, EventArgs e)
        {
            PrintRows_Current(printRows);
        }

        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            printRows = myDataGrid1.CurrentRowIndex;          
        }

	}
}
