using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using Ts_zyys_public;
namespace ts_yp_xtwh
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class FrmAddYjks : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox groupBox3;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rdoyk;
		private System.Windows.Forms.RadioButton rdoyf;
		private System.Windows.Forms.RadioButton rdomzyf;
		private System.Windows.Forms.RadioButton rdozyyf;
		private System.Windows.Forms.TextBox txtks;
		private System.Windows.Forms.Label lblks;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblqyzt;
		private System.Windows.Forms.Button butqy;
		private System.Windows.Forms.Button butclear;
		private System.Windows.Forms.GroupBox groupBox5;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Button butstop;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.RadioButton rdoejyf;
		private System.Windows.Forms.RadioButton rdoyl;
        private Button butqxglph;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAddYjks(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
			
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
				if (components != null) 
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
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoyl = new System.Windows.Forms.RadioButton();
            this.butclear = new System.Windows.Forms.Button();
            this.butdel = new System.Windows.Forms.Button();
            this.butadd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdozyyf = new System.Windows.Forms.RadioButton();
            this.rdomzyf = new System.Windows.Forms.RadioButton();
            this.rdoejyf = new System.Windows.Forms.RadioButton();
            this.rdoyf = new System.Windows.Forms.RadioButton();
            this.rdoyk = new System.Windows.Forms.RadioButton();
            this.txtks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblks = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.butstop = new System.Windows.Forms.Button();
            this.butqy = new System.Windows.Forms.Button();
            this.lblqyzt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.myDataGrid2 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.butqxglph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 501);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(888, 24);
            this.statusBar1.TabIndex = 0;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butsave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "����";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(648, 16);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(104, 40);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(528, 16);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(104, 40);
            this.butsave.TabIndex = 0;
            this.butsave.Text = "�������(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myDataGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 437);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ǰҩ������";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(274, 417);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "��������";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "����1";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "����2";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "������";
            this.dataGridBoolColumn1.NullText = "";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "deptid";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "����ʱ��";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.ReadOnly = true;
            this.dataGridTextBoxColumn9.Width = 120;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(280, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 437);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoyl);
            this.groupBox3.Controls.Add(this.butclear);
            this.groupBox3.Controls.Add(this.butdel);
            this.groupBox3.Controls.Add(this.butadd);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.rdoyf);
            this.groupBox3.Controls.Add(this.rdoyk);
            this.groupBox3.Controls.Add(this.txtks);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblks);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(283, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 128);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "��ӿ���";
            // 
            // rdoyl
            // 
            this.rdoyl.Location = new System.Drawing.Point(248, 56);
            this.rdoyl.Name = "rdoyl";
            this.rdoyl.Size = new System.Drawing.Size(64, 24);
            this.rdoyl.TabIndex = 10;
            this.rdoyl.Text = "ԭ�Ͽ�";
            this.rdoyl.Visible = false;
            // 
            // butclear
            // 
            this.butclear.Location = new System.Drawing.Point(248, 96);
            this.butclear.Name = "butclear";
            this.butclear.Size = new System.Drawing.Size(72, 24);
            this.butclear.TabIndex = 9;
            this.butclear.Text = "���(&C)";
            this.butclear.Click += new System.EventHandler(this.butclear_Click);
            // 
            // butdel
            // 
            this.butdel.Location = new System.Drawing.Point(408, 96);
            this.butdel.Name = "butdel";
            this.butdel.Size = new System.Drawing.Size(72, 24);
            this.butdel.TabIndex = 8;
            this.butdel.Text = "ɾ��(&D)";
            this.butdel.Click += new System.EventHandler(this.butdel_Click);
            // 
            // butadd
            // 
            this.butadd.Location = new System.Drawing.Point(328, 96);
            this.butadd.Name = "butadd";
            this.butadd.Size = new System.Drawing.Size(72, 24);
            this.butadd.TabIndex = 7;
            this.butadd.Text = "���(&A)";
            this.butadd.Click += new System.EventHandler(this.butadd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rdozyyf);
            this.panel1.Controls.Add(this.rdomzyf);
            this.panel1.Controls.Add(this.rdoejyf);
            this.panel1.Location = new System.Drawing.Point(368, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 44);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // rdozyyf
            // 
            this.rdozyyf.Location = new System.Drawing.Point(80, 12);
            this.rdozyyf.Name = "rdozyyf";
            this.rdozyyf.Size = new System.Drawing.Size(72, 24);
            this.rdozyyf.TabIndex = 7;
            this.rdozyyf.Text = "סԺҩ��";
            // 
            // rdomzyf
            // 
            this.rdomzyf.Checked = true;
            this.rdomzyf.Location = new System.Drawing.Point(8, 12);
            this.rdomzyf.Name = "rdomzyf";
            this.rdomzyf.Size = new System.Drawing.Size(72, 24);
            this.rdomzyf.TabIndex = 6;
            this.rdomzyf.TabStop = true;
            this.rdomzyf.Text = "����ҩ��";
            // 
            // rdoejyf
            // 
            this.rdoejyf.Location = new System.Drawing.Point(152, 12);
            this.rdoejyf.Name = "rdoejyf";
            this.rdoejyf.Size = new System.Drawing.Size(72, 24);
            this.rdoejyf.TabIndex = 8;
            this.rdoejyf.Text = "����ҩ��";
            // 
            // rdoyf
            // 
            this.rdoyf.Location = new System.Drawing.Point(312, 56);
            this.rdoyf.Name = "rdoyf";
            this.rdoyf.Size = new System.Drawing.Size(56, 24);
            this.rdoyf.TabIndex = 5;
            this.rdoyf.Text = "ҩ��";
            this.rdoyf.CheckedChanged += new System.EventHandler(this.rdoyf_CheckedChanged);
            // 
            // rdoyk
            // 
            this.rdoyk.Checked = true;
            this.rdoyk.Location = new System.Drawing.Point(192, 55);
            this.rdoyk.Name = "rdoyk";
            this.rdoyk.Size = new System.Drawing.Size(56, 24);
            this.rdoyk.TabIndex = 4;
            this.rdoyk.TabStop = true;
            this.rdoyk.Text = "ҩ��";
            // 
            // txtks
            // 
            this.txtks.Location = new System.Drawing.Point(72, 27);
            this.txtks.Name = "txtks";
            this.txtks.Size = new System.Drawing.Size(112, 21);
            this.txtks.TabIndex = 0;
            this.txtks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "���ҿ���";
            // 
            // lblks
            // 
            this.lblks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblks.ForeColor = System.Drawing.Color.Navy;
            this.lblks.Location = new System.Drawing.Point(72, 56);
            this.lblks.Name = "lblks";
            this.lblks.Size = new System.Drawing.Size(112, 21);
            this.lblks.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "��������";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.butqxglph);
            this.groupBox4.Controls.Add(this.butstop);
            this.groupBox4.Controls.Add(this.butqy);
            this.groupBox4.Controls.Add(this.lblqyzt);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(283, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(605, 64);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "���ÿ���";
            // 
            // butstop
            // 
            this.butstop.Location = new System.Drawing.Point(339, 17);
            this.butstop.Name = "butstop";
            this.butstop.Size = new System.Drawing.Size(77, 31);
            this.butstop.TabIndex = 5;
            this.butstop.Text = "ͣ�ÿ���";
            this.butstop.Click += new System.EventHandler(this.butstop_Click);
            // 
            // butqy
            // 
            this.butqy.Location = new System.Drawing.Point(256, 17);
            this.butqy.Name = "butqy";
            this.butqy.Size = new System.Drawing.Size(79, 31);
            this.butqy.TabIndex = 4;
            this.butqy.Text = "���ÿ���";
            this.butqy.Click += new System.EventHandler(this.butqy_Click);
            // 
            // lblqyzt
            // 
            this.lblqyzt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblqyzt.ForeColor = System.Drawing.Color.Navy;
            this.lblqyzt.Location = new System.Drawing.Point(96, 22);
            this.lblqyzt.Name = "lblqyzt";
            this.lblqyzt.Size = new System.Drawing.Size(136, 21);
            this.lblqyzt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "����״̬";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.myDataGrid2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(283, 192);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(605, 245);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ϵͳ����";
            // 
            // myDataGrid2
            // 
            this.myDataGrid2.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid2.CaptionVisible = false;
            this.myDataGrid2.DataMember = "";
            this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid2.Location = new System.Drawing.Point(3, 17);
            this.myDataGrid2.Name = "myDataGrid2";
            this.myDataGrid2.Size = new System.Drawing.Size(599, 225);
            this.myDataGrid2.TabIndex = 1;
            this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridBoolColumn2,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "��������";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "��������";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridBoolColumn2
            // 
            this.dataGridBoolColumn2.FalseValue = ((short)(0));
            this.dataGridBoolColumn2.HeaderText = "����ֵ";
            this.dataGridBoolColumn2.NullValue = ((short)(1));
            this.dataGridBoolColumn2.TrueValue = ((short)(1));
            this.dataGridBoolColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "��������";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 120;
            // 
            // butqxglph
            // 
            this.butqxglph.Location = new System.Drawing.Point(422, 17);
            this.butqxglph.Name = "butqxglph";
            this.butqxglph.Size = new System.Drawing.Size(100, 31);
            this.butqxglph.TabIndex = 6;
            this.butqxglph.Text = "ȡ����������";
            this.butqxglph.Click += new System.EventHandler(this.butqxglph_Click);
            // 
            // FrmAddYjks
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(888, 525);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Name = "FrmAddYjks";
            this.Text = "���ҩ������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmyfkpz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmyfkpz_Load(object sender, System.EventArgs e)
		{
			//��ʼ��
			DataTable myTb=new DataTable();
			myTb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
				{
					myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,typeof(bool));
				}

				else
				{
					myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
				}
									   
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
			}


			this.myDataGrid1.DataSource=myTb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";
			this.AddData();

			//��ʼ��
			DataTable myTb1=new DataTable();
			myTb1.TableName="Tb1";
			for(int i=0;i<=this.myDataGrid2.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
				{
					myTb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,typeof(bool));
				}

				else
				{
					myTb1.Columns.Add(this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
				}
									   
				this.myDataGrid2.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid2.TableStyles[0].GridColumnStyles[i].HeaderText;
			}


			this.myDataGrid2.DataSource=myTb1;
			this.myDataGrid2.TableStyles[0].MappingName ="Tb1";

			
		}


		private void AddData()
		{
			string ssql="select ksmc ��������,kslx ����1,kslx2 ����2,cast(qybz as smallint) ������,DEPTID,QYSJ ����ʱ�� from yp_yjks where szjgbm="+InstanceForm._menuTag.Jgbm+" ";
            if (_menuTag.Function_Name == "Fun_ts_yp_xtwh_addyjks")
            {
                ssql = ssql + " and kslx='ҩ��'";
                rdoyk.Visible = true;
                rdoyk.Checked = true;
                rdoyf.Visible = false;
            }
            else
            {
                ssql = ssql + " and kslx='ҩ��'";
                rdoyk.Visible = false;
                rdoyf.Checked = true;
                rdoyf.Visible = true;
            }

			if (InstanceForm.BCurrentUser.IsAdministrator==false) 
			{
				ssql=ssql+" and deptid="+InstanceForm.BCurrentDept.DeptId+"";
				this.butadd.Enabled=false;
				this.butdel.Enabled=false;
			}
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			tb.TableName="Tb";
			this.myDataGrid1.DataSource=tb;
			this.myDataGrid1.TableStyles[0].MappingName="Tb";
			this.lblks.Text="";
			this.lblks.Tag="0";
			this.lblqyzt.Text="";
		}

		private void AddData1(long deptid)
		{
			string ssql="select 0 ���,bh ��������,mc ��������,cast(zt as smallint) ����ֵ,bz �������� from yk_config where deptid="+deptid+"";
			DataTable tb1=InstanceForm.BDatabase.GetDataTable(ssql);
			tb1.TableName="Tb1";
			this.myDataGrid2.DataSource=tb1;
			this.myDataGrid2.TableStyles[0].MappingName="Tb1";
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0"))==0) {MessageBox.Show("��ѡ�����");return;}
			if(MessageBox.Show(this, "�� [ȷ��] Ҫ�������������?", "ȷ��", MessageBoxButtons.YesNo)==DialogResult.No ) return;
			
			try
			{
                string str_old = "�޸�[" + lblks.Text.Trim() + "�ݲ��� ";

				InstanceForm.BDatabase.BeginTransaction();

				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					int _values=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["����ֵ"],"0"));
					string _code=Convertor.IsNull(tb.Rows[i]["��������"],"0");
					string ssql="update yk_config set zt="+_values+" where bh='"+_code+"' and deptid="+Convert.ToInt32(Convertor.IsNull(lblks.Tag ,"0"))+"";
					InstanceForm.BDatabase.DoCommand(ssql);

                    str_old = str_old + _code.ToString() + ":" + _values.ToString() + "|";
				}

                SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�޸�ҩƷ����", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "��������" + System.Environment.MachineName, 8);
                systemLog.Save();
                systemLog = null;

                Yp.InsertLog("�޸�ҩƷ����", TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, 0, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), str_old, InstanceForm.BDatabase);



				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("����ɹ�");
			}
			catch(System.Exception err)
			{
				
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}


		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			int nrow=this.myDataGrid1.CurrentCell.RowNumber ;
			if (nrow>tb.Rows.Count-1) return;

			AddData1(Convert.ToInt64(Convertor.IsNull(tb.Rows[nrow]["deptid"],"0")));
			if (Convert.ToInt16(Convertor.IsNull(tb.Rows[nrow]["������"],"0"))==1)
				lblqyzt.Text="������";
			else
				lblqyzt.Text="δ����";
			lblks.Text=tb.Rows[nrow]["��������"].ToString();
			lblks.Tag=tb.Rows[nrow]["deptid"].ToString();
			if (tb.Rows[nrow]["����1"].ToString().Trim()=="ҩ��")
			{
				rdoyk.Checked=true;
				rdoyf.Checked=false;
			}

			if (tb.Rows[nrow]["����1"].ToString().Trim()=="ԭ�Ͽ�")
			{
				rdoyl.Checked=true;
				rdoyf.Checked=false;
			}

			if (tb.Rows[nrow]["����1"].ToString().Trim()=="ҩ��")
			{
				rdoyk.Checked=false;
				rdoyf.Checked=true;
				if (tb.Rows[nrow]["����2"].ToString().Trim()=="����ҩ��")
					rdomzyf.Checked=true;
				else
					rdozyyf.Checked=true;
			}

		}

		//���������
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";control.Tag="0";}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)==""))) {} 
			else {return;}

			try
			{
				string[] GrdMappingName;
				int[] GrdWidth;
				string[]sfield;
				string ssql="";
				DataRow row;
				
				Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
				switch(control.TabIndex)
				{
					case 0:
						if (control.Text.Trim()=="") return;
						GrdMappingName=new string[] {"id","�к�","����","ƴ����","�����"};
						GrdWidth=new int[] {0,50,200,100,100};
						sfield=new string[] {"wb_code","py_code","","",""};
						ssql="select  dept_id,0 rowno, name, py_code, wb_code from jc_dept_property where dept_id<>0  and deleted=0  ";
						TrasenFrame.Forms.Fshowcard f1=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,FilterType.ƴ��,control.Text.Trim(),ssql);
						f1.Location=point;
						f1.ShowDialog(this);
						row=f1.dataRow;
						if (row!=null) 
						{
							lblks.Text=row["name"].ToString();
							lblks.Tag=row["dept_id"].ToString();
							this.SelectNextControl((Control)sender,true,false,true,true);
						}
						break;
				}
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}

		}

		private void butadd_Click(object sender, System.EventArgs e)
		{
			string type1=this.rdoyk.Checked==true?rdoyk.Text.Trim():"";
				   type1=this.rdoyl.Checked==true && type1.Trim()==""?rdoyl.Text.Trim():type1;
				   type1=this.rdoyf.Checked==true && type1.Trim()==""?rdoyf.Text.Trim():type1;
			if (type1.Trim()==""){MessageBox.Show("��ѡ��Ҫ��ӵĿ�������");return;}
			string type2="";
			if (rdoyf.Checked==true)
			{
				   type2=this.rdomzyf.Checked==true?rdomzyf.Text.Trim():"";
				   type2=this.rdozyyf.Checked==true && type2.Trim()==""?rdozyyf.Text.Trim():type2;
				   type2=this.rdoejyf.Checked==true && type2.Trim()==""?rdoejyf.Text.Trim():type2;
				   if (type2.Trim()==""){MessageBox.Show("��ѡ��Ҫ��ӵĿ�������");return;}
			}
			
			string ssql="select * from yp_yjks where deptid="+Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0")) +"";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			if (tb.Rows.Count >0){MessageBox.Show("�Բ�����������Ѿ�����","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);return;}

            
            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                ssql = "insert into yp_yjks(ksmc,kslx,kslx2,qybz,deptid,szjgbm)values('" + lblks.Text + "','" + type1.Trim() + "','" + type2.Trim() + "',0," + Convert.ToInt32(Convertor.IsNull(lblks.Tag, "0")) + ","+InstanceForm._menuTag.Jgbm+")";
                InstanceForm.BDatabase.DoCommand(ssql);


                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("��ӳɹ�");
			this.AddData();
		}

		private void butdel_Click(object sender, System.EventArgs e)
		{
			string ssql="select qybz from yp_yjks where deptid="+Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0")) +"";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			if (tb.Rows.Count>0)
			{
				if (tb.Rows[0]["qybz"].ToString()=="1"){MessageBox.Show("�Բ���������������ò���ɾ��");return;}
			}
           
            try
            {
                InstanceForm.BDatabase.BeginTransaction();
                ssql = "delete from yp_yjks where deptid=" + Convert.ToInt32(Convertor.IsNull(lblks.Tag, "0")) + " and qybz=0";
                InstanceForm.BDatabase.DoCommand(ssql);

                //��Ժ���ݴ���
                Guid log_djid = Guid.Empty;
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_ҩƷ�������ݵ����޸�, InstanceForm.BCurrentUser.Name + "ɾ��ҩ������ ��" + lblks.Text + " ��", "yp_yjks", "deptid", Convertor.IsNull(lblks.Tag, "0"), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);


                InstanceForm.BDatabase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



			MessageBox.Show("ɾ���ɹ�");
			this.AddData();
		}

		private void butclear_Click(object sender, System.EventArgs e)
		{
			this.lblks.Text="";
			this.lblks.Tag="0";
		}

		private void butqy_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0"))==0) {MessageBox.Show("��ѡ�����");return;}
			if( lblqyzt.Text.Trim()=="������" && MessageBox.Show(this, "������������ã��������ý�����������ݣ�ȷ����?", "ȷ��", MessageBoxButtons.YesNo)==DialogResult.No ) return;
			

			try
			{
                Guid log_djid = Guid.Empty;

				InstanceForm.BDatabase.BeginTransaction();
				string proname="";

				if (this.rdoyk.Checked==true)
					proname="SP_YK_ClearData";
				if (this.rdoyl.Checked==true)
					proname="SP_YL_ClearData";
				if (this.rdoyf.Checked==true)
					proname="SP_YF_ClearData";

				ParameterEx[] parameters=new ParameterEx[1];
				parameters[0].Text="@deptid";
				parameters[0].Value=Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0"));
				InstanceForm.BDatabase.DoCommand(proname,parameters,30);


                //��Ժ���ݴ���

                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_ҩƷ�������ݵ����޸�, InstanceForm.BCurrentUser.Name + "���ҩ������ ��" + lblks.Text + " ��", "yp_yjks", "deptid", Convertor.IsNull(lblks.Tag, "0"), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);


				
				InstanceForm.BDatabase.CommitTransaction();

                //��Ժ���ݴ���
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_ҩƷ�������ݵ����޸�, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);

                MessageBox.Show("���óɹ�" + errtext);
				this.AddData();
			}
			catch(System.Exception err)
			{
				
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}
		}

		private void rdoyf_CheckedChanged(object sender, System.EventArgs e)
		{
			this.panel1.Visible=this.rdoyf.Checked==true?true:false;

		}

		private void butstop_Click(object sender, System.EventArgs e)
		{
			if (Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0"))==0) {MessageBox.Show("��ѡ�����");return;}
			if( lblqyzt.Text.Trim()=="������" && MessageBox.Show(this, "������������ã�ͣ�ý�����������ݣ�ȷ����?", "ȷ��", MessageBoxButtons.YesNo)==DialogResult.No ) return;

            Guid log_djid = Guid.Empty;

			try
			{
				InstanceForm.BDatabase.BeginTransaction();

				//�������
				string proname="";
				if (this.rdoyk.Checked==true)
					proname="SP_YK_ClearData";
				if (this.rdoyl.Checked==true)
					proname="SP_YL_ClearData";
				if (this.rdoyf.Checked==true)
					proname="SP_YF_ClearData";


				ParameterEx[] parameters=new ParameterEx[1];
				parameters[0].Text="@deptid";
				parameters[0].Value=Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0"));
                InstanceForm.BDatabase.DoCommand(proname, parameters, 30);

				//ͣ�ñ�־
				string ssql="update yp_yjks set qybz=0 where deptid="+Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0")) +"";
				InstanceForm.BDatabase.DoCommand(ssql);
				 ssql="delete from yk_config where deptid="+Convert.ToInt32(Convertor.IsNull(lblks.Tag,"0")) +"";
				InstanceForm.BDatabase.DoCommand(ssql);

                //��Ժ���ݴ���
                ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                ts.Save_log(ts_HospData_Share.czlx.yp_ҩƷ�������ݵ����޸�, InstanceForm.BCurrentUser.Name + "ͣ��ҩ������ ��" + lblks.Text + " ��", "yp_yjks", "deptid", Convertor.IsNull(lblks.Tag, "0"), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);

				InstanceForm.BDatabase.CommitTransaction();


			}
			catch(System.Exception err)
			{
				
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
                return;
			}

            try
            {
                //��Ժ���ݴ���
                string errtext = "";
                ts_HospData_Share.ts_update_log tss = new ts_HospData_Share.ts_update_log();
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.yp_ҩƷ�������ݵ����޸�, InstanceForm.BDatabase);
                if (ty.Bzx == 1)
                    tss.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);

                MessageBox.Show("��ǰѡ�������ѱ�ͣ��"+errtext);
                this.AddData();
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


		}

        private void butqxglph_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Convertor.IsNull(lblks.Tag, "0")) == 0)
            {
                MessageBox.Show("��ѡ�����"); return;
            }

            if (lblqyzt.Text.Trim() == "������" && MessageBox.Show(this, "ȡ��"+lblks.Text.Trim()+"���Ź���Ĳ����ǲ�����ת�ģ����ұ����ڲ�����æ��ʱ����С���ȷ����?", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Warning ) == DialogResult.No) return;
            //��ݵ��ٴ�ȷ��
            string dlgvalue = DlgPW.Show();
            string pwStr = dlgvalue; //YS.Password;
            bool bOk = InstanceForm.BCurrentUser.CheckPassword(pwStr);
            if (!bOk)
            {
                TrasenFrame.Forms.FrmMessageBox.Show("��û��ͨ��Ȩ��ȷ�ϣ����ܽ��д˲�����", new Font("����", 12f), Color.Red, "Sorry��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 


			try
			{
                InstanceForm.BDatabase.BeginTransaction();
				ParameterEx[] parameters=new ParameterEx[1];
				parameters[0].Text="@deptid";
                parameters[0].Value = Convert.ToInt32(Convertor.IsNull(lblks.Tag, "0"));
                InstanceForm.BDatabase.DoCommand("SP_YP_QXPHGL", parameters, 30);
                InstanceForm.BDatabase.CommitTransaction();
                MessageBox.Show("�����ɹ�");

			}
			catch(System.Exception err)
			{
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show("��������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}	


        }



	}
}
