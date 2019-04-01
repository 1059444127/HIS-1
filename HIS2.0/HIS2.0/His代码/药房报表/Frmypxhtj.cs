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
namespace ts_yf_tjbb
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Frmypxhtj : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdomz;
		private System.Windows.Forms.RadioButton rdoall;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
        private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private ComboBox cmbyjks;
        private Label label4;
        private Label label6;
        private TextBox txtdm;
        private DataGridTextBoxColumn dataGridTextBoxColumn15;
        private Button butexcel;
        private Label label3;
        private TextBox txtmb;
        private RadioButton rdozy;
        private DataGridTextBoxColumn dataGridTextBoxColumn17;
        private DataGridTextBoxColumn dataGridTextBoxColumn18;
        private DataGridTextBoxColumn dataGridTextBoxColumn19;
        private DataGridTextBoxColumn dataGridTextBoxColumn20;
        private DataGridTextBoxColumn dataGridTextBoxColumn21;
        private DataGridTextBoxColumn dataGridTextBoxColumn22;
        private StatusBarPanel statusBarPanel4;
        private StatusBarPanel statusBarPanel5;
        private StatusBarPanel statusBarPanel6;
        private Panel panel4;
        private RadioButton rdols;
        private RadioButton rdodq;
        private RadioButton rdoall_bf;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frmypxhtj(MenuTag menuTag, string chineseName, Form mdiParent)
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoall_bf = new System.Windows.Forms.RadioButton();
            this.rdols = new System.Windows.Forms.RadioButton();
            this.rdodq = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmb = new System.Windows.Forms.TextBox();
            this.rdozy = new System.Windows.Forms.RadioButton();
            this.butexcel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdm = new System.Windows.Forms.TextBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdomz = new System.Windows.Forms.RadioButton();
            this.rdoall = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel6 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtmb);
            this.groupBox1.Controls.Add(this.rdozy);
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtdm);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdomz);
            this.groupBox1.Controls.Add(this.rdoall);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdoall_bf);
            this.panel4.Controls.Add(this.rdols);
            this.panel4.Controls.Add(this.rdodq);
            this.panel4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(615, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(76, 65);
            this.panel4.TabIndex = 44;
            // 
            // rdoall_bf
            // 
            this.rdoall_bf.ForeColor = System.Drawing.Color.Black;
            this.rdoall_bf.Location = new System.Drawing.Point(7, 42);
            this.rdoall_bf.Name = "rdoall_bf";
            this.rdoall_bf.Size = new System.Drawing.Size(58, 24);
            this.rdoall_bf.TabIndex = 13;
            this.rdoall_bf.Text = "ȫ��";
            this.rdoall_bf.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // rdols
            // 
            this.rdols.ForeColor = System.Drawing.Color.Black;
            this.rdols.Location = new System.Drawing.Point(7, 22);
            this.rdols.Name = "rdols";
            this.rdols.Size = new System.Drawing.Size(58, 24);
            this.rdols.TabIndex = 11;
            this.rdols.Text = "��ʷ";
            // 
            // rdodq
            // 
            this.rdodq.Checked = true;
            this.rdodq.ForeColor = System.Drawing.Color.Black;
            this.rdodq.Location = new System.Drawing.Point(7, 3);
            this.rdodq.Name = "rdodq";
            this.rdodq.Size = new System.Drawing.Size(58, 24);
            this.rdodq.TabIndex = 10;
            this.rdodq.TabStop = true;
            this.rdodq.Text = "��ǰ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 43;
            this.label3.Text = "ģ������";
            // 
            // txtmb
            // 
            this.txtmb.Location = new System.Drawing.Point(461, 16);
            this.txtmb.Name = "txtmb";
            this.txtmb.Size = new System.Drawing.Size(148, 21);
            this.txtmb.TabIndex = 0;
            this.txtmb.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            this.txtmb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // rdozy
            // 
            this.rdozy.Location = new System.Drawing.Point(306, 13);
            this.rdozy.Name = "rdozy";
            this.rdozy.Size = new System.Drawing.Size(85, 24);
            this.rdozy.TabIndex = 41;
            this.rdozy.Text = "סԺ����";
            this.rdozy.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(800, 23);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(68, 30);
            this.butexcel.TabIndex = 40;
            this.butexcel.Text = "����(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "ҩƷ����";
            // 
            // txtdm
            // 
            this.txtdm.Location = new System.Drawing.Point(462, 46);
            this.txtdm.Name = "txtdm";
            this.txtdm.Size = new System.Drawing.Size(147, 21);
            this.txtdm.TabIndex = 1;
            this.txtdm.TextChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            this.txtdm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(65, 15);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(115, 20);
            this.cmbyjks.TabIndex = 24;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "ҩ������";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(872, 21);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(65, 32);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(731, 21);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(63, 32);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "ͳ��(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(227, 46);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(139, 21);
            this.dtp2.TabIndex = 5;
            this.dtp2.ValueChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(206, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "��";
            this.label2.Visible = false;
            // 
            // dtp1
            // 
            this.dtp1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(64, 46);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(137, 21);
            this.dtp1.TabIndex = 3;
            this.dtp1.ValueChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "��ҩ����";
            // 
            // rdomz
            // 
            this.rdomz.Location = new System.Drawing.Point(236, 13);
            this.rdomz.Name = "rdomz";
            this.rdomz.Size = new System.Drawing.Size(85, 24);
            this.rdomz.TabIndex = 0;
            this.rdomz.Text = "��������";
            this.rdomz.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // rdoall
            // 
            this.rdoall.Checked = true;
            this.rdoall.Location = new System.Drawing.Point(187, 13);
            this.rdoall.Name = "rdoall";
            this.rdoall.Size = new System.Drawing.Size(88, 24);
            this.rdoall.TabIndex = 1;
            this.rdoall.TabStop = true;
            this.rdoall.Text = "ȫ��";
            this.rdoall.CheckedChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4,
            this.statusBarPanel5,
            this.statusBarPanel6});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Width = 150;
            // 
            // statusBarPanel4
            // 
            this.statusBarPanel4.Name = "statusBarPanel4";
            this.statusBarPanel4.Width = 160;
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Width = 160;
            // 
            // statusBarPanel6
            // 
            this.statusBarPanel6.Name = "statusBarPanel6";
            this.statusBarPanel6.Text = "��ҩ������Ϊȫ��ʱ,��ǰ���ΪȫԺ�ܿ��";
            this.statusBarPanel6.Width = 300;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 423);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ͳ�����";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 403);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "����";
            this.dataGridTextBoxColumn14.Width = 65;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "�ɹ���ˮ��";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "��Ʒ��";
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "���";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "����";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "������";
            this.dataGridTextBoxColumn17.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn18.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "����";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "��λ";
            this.dataGridTextBoxColumn8.Width = 40;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "�������";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 70;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "���۽��";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 70;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "������";
            this.dataGridTextBoxColumn19.Width = 70;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "��ǰ���";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 60;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "����������";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 70;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "������۽��";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 70;
            // 
            // Frmypxhtj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmypxhtj";
            this.Text = "�����������ͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 00:00:00");
				dtp2.Value=Convert.ToDateTime( DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString()+" 23:59:59");

				//��ʼ��
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

                Yp.AddcmbYjks(true,cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
                
                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId, InstanceForm.BDatabase) != DeptType.δ֪)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                else
                {
                    cmbyjks.SelectedIndex = 0;
                }
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}


		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				this.buttj.Enabled=false;
				ParameterEx[] parameters=new ParameterEx[7];
                int ntype = 0;
                if (rdomz.Checked == true) ntype = 1;
                if (rdozy.Checked == true) ntype = 2;
				parameters[0].Value=ntype;
                parameters[1].Value = dtp1.Value.ToString();
                parameters[2].Value = dtp2.Value.ToString();
                parameters[3].Value = Convert.ToInt32(cmbyjks.SelectedValue);
                parameters[4].Value = Convertor.IsNull(txtdm.Tag,"0");
                parameters[5].Value = Convertor.IsNull(txtmb.Tag, "0");

                int bk = 0;
                if (rdols.Checked == true) bk = 1;
                if (rdoall_bf.Checked == true) bk = 2;
                parameters[6].Text = "@bk";
                parameters[6].Value = bk;

				parameters[0].Text="@type";
				parameters[1].Text="@dtp1";
				parameters[2].Text="@dtp2";
				parameters[3].Text="@deptid";
                parameters[4].Text = "@cjid";
                parameters[5].Text = "@mbid";
                parameters[6].Text = "@bk";


                DataView dv = new DataView();
                dv = InstanceForm.BDatabase.GetDataTable("SP_YF_tj_ypxhtj", parameters, 60).DefaultView;
                FunBase.AddRowtNo(dv.Table);

                DataTable tb = dv.Table;
				decimal sumpfje=Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(�������)",""),"0"));
                decimal sumlsje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(���۽��)", ""), "0"));
                decimal sumplce = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(������)", ""), "0"));
                decimal sumkcpfje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(����������)", ""), "0"));
                decimal sumkclsje = Convert.ToDecimal(Convertor.IsNull(tb.Compute("sum(������۽��)", ""), "0"));

                this.statusBar1.Panels[0].Text = "������� " + sumpfje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "���۽�� " + sumlsje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "������ " + sumplce.ToString("0.00");
                this.statusBar1.Panels[3].Text = "���������� " + sumkcpfje.ToString("0.00");
                this.statusBar1.Panels[4].Text = "������۽�� " + sumkclsje.ToString("0.00");
				this.buttj.Enabled=true;

                DataRow row = tb.NewRow();
                row["���"] = "�ϼ�";
                row["�������"] = sumpfje.ToString();
                row["���۽��"] = sumlsje.ToString();
                row["������"] = sumplce.ToString();
                row["����������"] = sumkcpfje.ToString();
                row["������۽��"] = sumkclsje.ToString();
                tb.Rows.Add(row);

                tb.TableName = "Tb";
                this.myDataGrid1.DataSource = dv;

			}
			catch(System.Exception err)
			{
				this.buttj.Enabled=true;
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	


        //���������¼�
        private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
        {
            int nkey = Convert.ToInt32(e.KeyCode);
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }

            if ((nkey >= 65 && nkey <= 90) || (nkey >= 48 && nkey <= 57) || (nkey >= 96 && nkey <= 105)  || nkey == 32  || (nkey == 13 && (Convert.ToString(control.Tag) == "0" || Convert.ToString(control.Tag) == "")))
            {

            }
            else
            {
                return;
            }

            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            DataRow row;

            Point point = new Point(this.Location.X + control.Location.X, this.Location.Y + control.Location.Y + control.Height * 3);
            switch (control.TabIndex)
            {
                case 1:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "DWBL", "������", "���ۼ�", "����" };
                    GrdWidth = new int[] { 0, 0, 50, 200, 100, 100, 40, 0, 60, 60, 70  };
                    sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                    if (Convertor.IsNull(cmbyjks.SelectedValue,"0")!="0")
                         ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + Convert.ToInt32(cmbyjks.SelectedValue) + " ";
                    else
                         ssql = "select a.ggid,cjid,0  rowno,yppm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_yp_ypcd a,yp_ypbm b where a.ggid=b.ggid   ";
                     TrasenFrame.Forms.Fshowcard f2 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                    f2.Location = point;
                    f2.Width = 700;
                    f2.Height = 300;
                    f2.ShowDialog(this);
                    row = f2.dataRow;
                    if (row != null)
                    {
                        this.txtdm.Text = row["yppm"].ToString();
                        this.txtdm.Tag = row["cjid"].ToString();
                    }
                    break;
                case 0:
                    if (control.Text.Trim() == "") return;
                    GrdMappingName = new string[] { "ģ������","ƴ����","�����","id"};
                    GrdWidth = new int[] { 150,60,60,0};
                    sfield = new string[] { "wbm", "pym","","","" };
                    ssql = "select mbmc,pym,wbm,id from yp_yptjmb b where id>0   ";
                    TrasenFrame.Forms.Fshowcard f3 = new TrasenFrame.Forms.Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                    f3.Location = point;
                    f3.Width = 700;
                    f3.Height = 300;
                    f3.ShowDialog(this);
                    row = f3.dataRow;
                    if (row != null)
                    {
                        this.txtmb.Text = row["mbmc"].ToString();
                        this.txtmb.Tag = row["id"].ToString();
                    }
                    break;

            }

        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    #region �򵥴�ӡ

            //    this.butexcel.Enabled = false;
            //    Excel.Application myExcel = new Excel.Application();

            //    myExcel.Application.Workbooks.Add(true);

            //    //��ѯ����
            //    string title = "";
            //    if (rdoall.Checked == true)
            //        title = title + "ͳ�Ʒ�Χ:�����סԺ";
            //    if (rdomz.Checked==true)
            //        title = title + "ͳ�Ʒ�Χ:����";
            //    if (rdozy.Checked == true)
            //        title = title + "ͳ�Ʒ�Χ:סԺ";
            //    string where1 = "";


            //    where1 =title+  "  ҩ������:" + cmbyjks.Text.Trim();
            //    where1 = where1 + " ����:" + dtp1.Value.ToShortDateString() + " ��:" + dtp2.Value.ToShortDateString() + "";
            //    if (txtmb.Text.Trim()!="") where1=where1+" ͳ��ģ��:"+txtmb.Text.Trim();

            //    //д����ͷ
            //    DataTable tb = (DataTable)this.myDataGrid1.DataSource;
            //    int SumRowCount = tb.Rows.Count;
            //    int SumColCount = tb.Columns.Count;

            //    for (int j = 0; j < tb.Columns.Count; j++)
            //    {
            //        myExcel.Cells[5, 1 + j] = tb.Columns[j].ColumnName;

            //    }
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


            //    //����д�����ݣ�
            //    for (int i = 0; i < tb.Rows.Count; i++)
            //    {
            //        for (int j = 0; j < tb.Columns.Count; j++)
            //        {
            //            myExcel.Cells[6 + i, 1 + j] = "" + tb.Rows[i][j].ToString();
            //        }
            //    }

            //    //���ñ�����Ϊ����Ӧ���
            //    myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

            //    //�ӱ߿�
            //    myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

            //    //��������
            //    myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "סԺ������ҩͳ��";
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
            //    //�������ƿ��о���
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //    //��������
            //    myExcel.Cells[3, 1] = where1.Trim();
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
            //    myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //    //���һ��Ϊ��ɫ
            //    myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

            //    //��Excel�ļ��ɼ�
            //    myExcel.Visible = true;
            //    this.butexcel.Enabled = true;
            //    #endregion
            //}
            //catch (System.Exception err)
            //{
            //    this.butexcel.Enabled = true;
            //    MessageBox.Show(err.Message);
            //}

            try
            {

                DataView dv = (DataView)this.myDataGrid1.DataSource;

                DataTable tb = dv.Table;
                // ����Excel����                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel�޷�����");
                    return;
                }
                // ����Excel������
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // ������������������������������
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = 0;
                int RowCount = tb.Rows.Count+1;
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                        colCount = colCount + 1;
                }

               
                //��ѯ����
                string title = "";
                if (rdoall.Checked == true)
                    title = title + "ͳ�Ʒ�Χ:�����סԺ";
                if (rdomz.Checked==true)
                    title = title + "ͳ�Ʒ�Χ:����";
                if (rdozy.Checked == true)
                    title = title + "ͳ�Ʒ�Χ:סԺ";
                string where1 = "";


                where1 =title+  "  ҩ������:" + cmbyjks.Text.Trim();
                where1 = where1 + " ����:" + dtp1.Value.ToString() + " ��:" + dtp2.Value.ToString() + "";
                if (txtmb.Text.Trim()!="") where1=where1+" ͳ��ģ��:"+txtmb.Text.Trim();


                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = "ȫԺҩƷ�������ͳ��";
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                // ��������
                Excel.Range range1 = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[2, colCount]);
                range1.MergeCells = true;

                // ������������
                object[,] objData = new object[RowCount + 1, colCount + 1];
                // ��ȡ�б���
                for (int i = 0; i <= tb.Columns.Count - 1; i++)
                {
                        objData[1, colIndex++] = tb.Columns[i].Caption;
                }
                objData[0, 0] =where1 ;
                // ��ȡ����

                //for (int i = 0; i <= tb.Rows.Count - 1; i++)
                //{
                //    colIndex = 0;
                //    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                //    {
                //        objData[i + 2, colIndex++] = "" + tb.Rows[i][j].ToString();
                //    }
                //    Application.DoEvents();
                //}
                for (int i = 0; i <= dv.Table.Rows.Count-1; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j <= tb.Columns.Count - 1; j++)
                    {
                        objData[i + 2, colIndex++] = "" + dv[i][j].ToString();
                    }
                    Application.DoEvents();
                }




                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]);
                range.Value2 = objData;

                // 
                xlApp.get_Range(xlApp.Cells[3, 1], xlApp.Cells[RowCount + 2, colCount]).Borders.LineStyle = 1;

                //���ñ�����Ϊ����Ӧ���
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Select();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Columns.AutoFit();
                xlApp.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount + 2, colCount]).Font.Size = 9;

                xlApp.Visible = true;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tbmx = (DataTable)myDataGrid1.DataSource;
                if (tbmx != null) tbmx.Clear();

            }
            catch (System.Exception err)
            {
            }
        }



	}
}
