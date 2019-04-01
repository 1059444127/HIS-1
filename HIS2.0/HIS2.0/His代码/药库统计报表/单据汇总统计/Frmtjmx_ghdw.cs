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

namespace ts_yk_tjbb
{
	/// <summary>
	/// Frmkccx ��ժҪ˵����
	/// </summary>
    public class Frmtjmx_ghdw : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button butcx;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn ��Ʒ��;
		private YpConfig s;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbmonth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbyear;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private ComboBox cmbyjks;
        private Label label6;
        private ComboBox cmbck;
        private Label lblck;
        private DataGridTextBoxColumn dataGridTextBoxColumn18;
        private Button butexcel;
        private DataGridTextBoxColumn dataGridTextBoxColumn19;
        private Panel panel1;
        private Splitter splitter1;
        private Panel panel2;
        private CheckBox checkBox1;
        private GroupBox groupBox3;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmtjmx_ghdw(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
			s=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.butexcel = new System.Windows.Forms.Button();
            this.cmbck = new System.Windows.Forms.ComboBox();
            this.lblck = new System.Windows.Forms.Label();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ʒ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbck);
            this.groupBox1.Controls.Add(this.lblck);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbmonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butcx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(606, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "���ֹ�����λ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(730, 39);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(68, 32);
            this.butexcel.TabIndex = 44;
            this.butexcel.Text = "����(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // cmbck
            // 
            this.cmbck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbck.Location = new System.Drawing.Point(327, 16);
            this.cmbck.Name = "cmbck";
            this.cmbck.Size = new System.Drawing.Size(141, 20);
            this.cmbck.TabIndex = 43;
            // 
            // lblck
            // 
            this.lblck.Location = new System.Drawing.Point(271, 20);
            this.lblck.Name = "lblck";
            this.lblck.Size = new System.Drawing.Size(67, 16);
            this.lblck.TabIndex = 42;
            this.lblck.Text = "�ֿ�����";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(92, 15);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(177, 20);
            this.cmbyjks.TabIndex = 41;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(29, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 40;
            this.label6.Text = "ҩ������";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(568, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "��";
            this.label1.Visible = false;
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbmonth.Location = new System.Drawing.Point(509, 48);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(55, 20);
            this.cmbmonth.TabIndex = 38;
            this.cmbmonth.Visible = false;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(487, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "��";
            this.label3.Visible = false;
            // 
            // cmbyear
            // 
            this.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyear.Items.AddRange(new object[] {
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010"});
            this.cmbyear.Location = new System.Drawing.Point(420, 48);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(65, 20);
            this.cmbyear.TabIndex = 36;
            this.cmbyear.Visible = false;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // rdo2
            // 
            this.rdo2.Checked = true;
            this.rdo2.Location = new System.Drawing.Point(341, 46);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(96, 25);
            this.rdo2.TabIndex = 35;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "���·ݲ�ѯ";
            this.rdo2.Visible = false;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(221, 46);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(111, 21);
            this.dtp2.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(204, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(92, 46);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 31;
            // 
            // rdo1
            // 
            this.rdo1.Location = new System.Drawing.Point(29, 46);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(96, 25);
            this.rdo1.TabIndex = 34;
            this.rdo1.Text = "�����ڴ�";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(667, 39);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(63, 32);
            this.butprint.TabIndex = 30;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(799, 39);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(58, 32);
            this.butquit.TabIndex = 29;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(606, 39);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(60, 32);
            this.butcx.TabIndex = 28;
            this.butcx.Text = "ͳ��(&V)";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
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
            this.myDataGrid1.Size = new System.Drawing.Size(653, 406);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn2,
            this.��Ʒ��,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn18});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "�ֿ�����";
            this.dataGridTextBoxColumn19.MappingName = "�ֿ�����";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "�����ĺ�";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "��������";
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // ��Ʒ��
            // 
            this.��Ʒ��.Format = "";
            this.��Ʒ��.FormatInfo = null;
            this.��Ʒ��.HeaderText = "��Ʒ��";
            this.��Ʒ��.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "����";
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "����";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "ԭ������";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "��������";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "ԭ���ۼ�";
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "�����ۼ�";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "��������";
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "��λ";
            this.dataGridTextBoxColumn9.Width = 40;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "��λ���";
            this.dataGridTextBoxColumn14.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "���������";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "�����۽��";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "����";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "����Ա";
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 509);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(864, 24);
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
            this.statusBarPanel4.Width = 1000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 426);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "������";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 426);
            this.panel1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 83);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 426);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(205, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 426);
            this.panel2.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(194, 406);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "������λ";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "��ע";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 426);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "������λ";
            // 
            // Frmtjmx_ghdw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmtjmx_ghdw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ȫԺ���ۻ���";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void butcx_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				ParameterEx[] parameters=new ParameterEx[7];
                parameters[0].Value = Convert.ToInt32(cmbyjks.SelectedValue);
				parameters[1].Value=dtp1.Value.ToShortDateString()+" 00:00:00";
				parameters[2].Value=dtp2.Value.ToShortDateString()+" 23:59:59";
				parameters[3].Value=0;//Convert.ToInt32(cmbyplx.SelectedValue);
	
				parameters[0].Text="@deptid";
				parameters[1].Text="@rq1";
				parameters[2].Text="@rq2";
				parameters[3].Text="@yplx";
				parameters[4].Text="@year";
				parameters[5].Text="@month";
                parameters[6].Text = "@deptid_ck";
                parameters[6].Value = Convert.ToInt32(Convertor.IsNull(cmbck.SelectedValue, "0"));

				if (rdo1.Checked==true)
				{
					parameters[4].Value=0;
					parameters[5].Value=0;
				}
				else
				{
					parameters[4].Value=Convert.ToInt32(cmbyear.Text);
					parameters[5].Value=Convert.ToInt32(cmbmonth.Text);
				}

				DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YK_TJ_TJHZ",parameters,30);
				FunBase.AddRowtNo(tb);

				object je=tb.Compute("sum(�����۽��)","");
				decimal sumtlsje=Convert.ToDecimal(Convertor.IsNull(je,"0"));

                object je1 = tb.Compute("sum(�����۽��)", "�����۽��>0");
                decimal sumtyje = Convert.ToDecimal(Convertor.IsNull(je1, "0"));

                object je2 = tb.Compute("sum(�����۽��)", "�����۽��<0");
                decimal sumtkje = Convert.ToDecimal(Convertor.IsNull(je2, "0"));

				DataRow newrow=tb.NewRow();
				newrow["���"]="�ϼ�";
				newrow["�����۽��"]=sumtlsje.ToString("0.00");
				tb.Rows.Add(newrow);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;

				this.statusBar1.Panels[0].Text=  "�����۽��ϼ�:"+sumtlsje.ToString("0.00");
                this.statusBar1.Panels[1].Text = "��ӯ���:" + sumtyje.ToString("0.00");
                this.statusBar1.Panels[2].Text = "�������:" + sumtkje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
		}

		private void Frmkccx_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

			this.rdo1.Checked=true;

            Yp.AddCmbYjks(true, InstanceForm.BCurrentDept.DeptId, cmbyjks, InstanceForm.BDatabase);
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
		}


		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string where1="";
                if (cmbck.Visible == true) where1 = "�ֿ�����:" + cmbck.Text.Trim() + "  ";
				if (rdo1.Checked==true)
				{
					where1=where1+"������ͳ��  ����:"+dtp1.Value.ToShortDateString();
					where1=where1+" ��:"+dtp2.Value.ToShortDateString();
				}
				else
				{
					where1=where1+"������·�ͳ��  ����:"+this.statusBar1.Panels[3].Text;
				}
//				if (chkyplx.Checked==true) bz=bz+"     ҩƷ���� "+cmbyplx.Text;
//				if (chkypmc.Checked==true) bz=bz+"     ҩƷ���� "+txtypmc.Text;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				
				for(int i=0;i<=tb.Rows.Count-2;i++)
				{
					myrow=Dset.ҩƷ���۵�.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					if (s.��ӡ����ʱ������ʾ��Ʒ��==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
					myrow["ypfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ������"],"0"));
					myrow["xpfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					decimal pfjdwcj=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ������"],"0"));
					decimal tpfje=pfjdwcj*(Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0")));
					myrow["pfjdwcj"]=pfjdwcj.ToString("0.00");
					myrow["tpfje"]=tpfje.ToString("0.00");
					myrow["ylsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ���ۼ�"],"0"));
					myrow["xlsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�����ۼ�"],"0"));
					myrow["lsjdwcj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��λ���"],"0"));
					myrow["tlsje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�����۽��"],"0"));
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["tjwh"]=Convert.ToString(tb.Rows[i]["�����ĺ�"]);
					myrow["zxrq"]=Convert.ToString(tb.Rows[i]["��������"]);
                    myrow["ckmc"] = Convert.ToString(tb.Rows[i]["�ֿ�����"]);
					Dset.ҩƷ���۵�.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Text="DJH";
				parameters[0].Value="0";
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value="";
				parameters[3].Text="TJWH";
				parameters[3].Value="";
				parameters[4].Text="TITLETEXT";
				parameters[4].Value=TrasenFrame.Classes.Constant.HospitalName+"("+cmbyjks.Text.Trim()+")"+"ҩ����۵�";
				parameters[5].Text="BZ";
				parameters[5].Value="";
				parameters[6].Text="swhere";
				parameters[6].Value=where1;

				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ���۵�,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ���۵���.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}


		private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
		}

		
		private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.rdo2.Checked==true)
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
		}

		private void rdo1_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();

			this.statusBar1.Panels[0].Text="";
			this.statusBar1.Panels[1].Text="";
			this.statusBar1.Panels[2].Text="";
			this.statusBar1.Panels[3].Text="";


			if (rdo1.Checked==true)
			{
				dtp1.Enabled=true;
				dtp2.Enabled=true;
				cmbyear.Enabled=false;
				cmbmonth.Enabled=false;
				this.statusBar1.Panels[3].Text="";
			}
			else
			{
				dtp1.Enabled=false;
				dtp2.Enabled=false;
				cmbyear.Enabled=true;
				cmbmonth.Enabled=true;
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
			}
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
            Yp.AddCmbYjks_ck(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbck, InstanceForm.BDatabase);
            if (this.rdo2.Checked == true)
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);

            if (cmbck.Items.Count == 1)
            {
                cmbck.Visible = false;
                lblck.Visible = false;
            }
            else
            {
                cmbck.Visible = true;
                lblck.Visible = true;
            }
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            try
            {
                #region �򵥴�ӡ

                this.butexcel.Enabled = false;
                Excel.Application myExcel = new Excel.Application();

                myExcel.Application.Workbooks.Add(true);

                //��ѯ����
                string title = ":";
                if (rdo1.Checked == true)
                    title = title + "����:" + dtp1.Value.ToShortDateString() + " ��:" + dtp2.Value.ToShortDateString();
                else
                    title = title + "���:" + cmbyear.Text.Trim() + " �·�:" + cmbmonth.Text.Trim();
                string where1 = "";


                where1 = "ҩ������:" + cmbyjks.Text.Trim() + " �ֿ�����:" + cmbck.Text.Trim();
                where1 = where1 + title;

                //д����ͷ
                DataTable tb = (DataTable)this.myDataGrid1.DataSource;
                int SumRowCount = tb.Rows.Count;
                int SumColCount = tb.Columns.Count;

                for (int j = 0; j < tb.Columns.Count; j++)
                {
                    myExcel.Cells[5, 1 + j] = tb.Columns[j].ColumnName;

                }
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, SumColCount]).Font.Size = 10;


                //����д�����ݣ�
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    for (int j = 0; j < tb.Columns.Count; j++)
                    {
                        myExcel.Cells[6 + i, 1 + j] = "" + tb.Rows[i][j].ToString();
                    }
                }

                //���ñ�����Ϊ����Ӧ���
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Columns.AutoFit();

                //�ӱ߿�
                myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Borders.LineStyle = 1;

                //��������
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + this.Text;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Bold = true;
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Font.Size = 16;
                //�������ƿ��о���
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                //��������
                myExcel.Cells[3, 1] = where1.Trim();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Font.Size = 10;
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, SumColCount]).Select();
                myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, SumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                //���һ��Ϊ��ɫ
                myExcel.get_Range(myExcel.Cells[5 + SumRowCount, 1], myExcel.Cells[5 + SumRowCount, SumColCount]).Interior.ColorIndex = 19;

                //��Excel�ļ��ɼ�
                myExcel.Visible = true;
                this.butexcel.Enabled = true;
                #endregion
            }
            catch (System.Exception err)
            {
                this.butprint.Enabled = true;
                MessageBox.Show(err.Message);
            }
        }


        //��ȡ���ۻ��� 
        private DataTable GetTjHz_ghdw(int deptid,int year,int month,DateTime t1,DateTime t2,TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = "";
            DataTable tb=new DataTable();
            t1=Convert.ToDateTime(t1.ToShortDateString()+" 00:00:01");
            t2 = Convert.ToDateTime(t2.ToShortDateString() + " 23:59:59");
            string ssql_rq="";

            if (month == 0)
            {
                ssql_rq = string.Format(" and b.zxrq>='{0}' and b.zxrq<='{1}'",t1,t2);
            }
            if (deptid == 0)
            {
                #region ȫԺ
                ssql = string.Format(@"
                                select tt.CJID,tt.YPDW, tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,SUM(tt.YPSL) YPSL,SUM(tt.JHJE) JHJE,SUM(tt.LSJE) LSJE, tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,WLDW,GHDWMC  from 
                                (
	                                select aa.*,dbo.fun_getDeptname(aa.deptid) KSMC, cc.WLDW, dbo.fun_yp_ghdw(cc.WLDW) GHDWMC from 
	                                  (
	                                    select  a.CJID,a.YPDW,a.SHH,a.YPPM,a.YPGG,a.SCCJ,a.YPSL,c.YLSJ,c.XLSJ,c.SCJHJ YJHJ,c.MRJHJ XJHJ,YPPCH,a.DEPTID,
			                                    a.JHJE,a.PFJE,a.LSJE 
	                                            from YK_DJMX a inner join YF_TJ b on  a.DJID= b.ZXDJID  
	                                            inner join YF_TJMX c on b.ID=c.DJID 
	                                            where a.YWLX='005' {0}
	                                    union all
	                                    select a.CJID,a.YPDW, a.SHH,a.YPPM,a.YPGG,a.SCCJ,a.YPSL,c.YLSJ,c.XLSJ,c.SCJHJ YJHJ,c.MRJHJ XJHJ,YPPCH,a.DEPTID,
			                                    a.JHJE,a.PFJE,a.LSJE
	                                            from YF_DJMX a inner join YF_TJ b on  a.DJID= b.ZXDJID  
	                                            inner join YF_TJMX c on b.ID=c.DJID 
	                                            where a.YWLX='005' {0} 
	                                  ) aa left join YK_DJMX  bb on aa.YPPCH=bb.YPPCH  and bb.YWLX='001'
									                                left join YK_DJ cc on bb.DJID=cc.ID and cc.YWLX='001'  
                                 )
                                 tt  group by WLDW,tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,GHDWMC,CJID,YPDW 

                            ",ssql_rq);
                #endregion
            }
            else
            {
                #region ��������
                ssql = string.Format(" select kslx from yp_yjks where deptid={0} ",deptid);
                bool byk = false;
                DataTable tb_kslx = db.GetDataTable(ssql);
                if (tb_kslx.Rows.Count < 0)
                {
                    throw new Exception("��������");
                }
                else
                {
                    if (tb_kslx.Rows[0][0].ToString() == "ҩ��")
                    {
                        byk = true;
                    }
                }

                if (byk)
                {
                    #region ҩ��
                    ssql = string.Format(@"
                                select tt.CJID,tt.YPDW, tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,SUM(tt.YPSL) YPSL,SUM(tt.JHJE) JHJE,SUM(tt.LSJE) LSJE, tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,WLDW,GHDWMC  from 
                                (
	                                select aa.*,dbo.fun_getDeptname(aa.deptid) KSMC, cc.WLDW, dbo.fun_yp_ghdw(cc.WLDW) GHDWMC from 
	                                  (
	                                    select  a.CJID,a.YPDW,a.SHH,a.YPPM,a.YPGG,a.SCCJ,a.YPSL,c.YLSJ,c.XLSJ,c.SCJHJ YJHJ,c.MRJHJ XJHJ,YPPCH,a.DEPTID,
			                                    a.JHJE,a.PFJE,a.LSJE 
	                                            from YK_DJMX a inner join YF_TJ b on  a.DJID= b.ZXDJID  
	                                            inner join YF_TJMX c on b.ID=c.DJID 
	                                            where a.YWLX='005' and a.depitd={0} {1}
                                        
	                                 
	                                  ) aa left join YK_DJMX  bb on aa.YPPCH=bb.YPPCH  and bb.YWLX='001'
									                                left join YK_DJ cc on bb.DJID=cc.ID and cc.YWLX='001' 
                                 )
                                 tt  group by WLDW,tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,GHDWMC,CJID,YPDW ",deptid,ssql_rq);
                    #endregion
                }
                else
                {
                    #region ҩ��
                    ssql = string.Format(@"
                                select tt.CJID,tt.YPDW, tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,SUM(tt.YPSL) YPSL,SUM(tt.JHJE) JHJE,SUM(tt.LSJE) LSJE, tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,WLDW,GHDWMC  from 
                                (
	                                select aa.*,dbo.fun_getDeptname(aa.deptid) KSMC, cc.WLDW, dbo.fun_yp_ghdw(cc.WLDW) GHDWMC from 
	                                  (
	                                    
	                                    select a.CJID,a.YPDW, a.SHH,a.YPPM,a.YPGG,a.SCCJ,a.YPSL,c.YLSJ,c.XLSJ,c.SCJHJ YJHJ,c.MRJHJ XJHJ,YPPCH,a.DEPTID,
			                                    a.JHJE,a.PFJE,a.LSJE
	                                            from YF_DJMX a inner join YF_TJ b on  a.DJID= b.ZXDJID  
	                                            inner join YF_TJMX c on b.ID=c.DJID 
	                                            where a.YWLX='005' and a.deptid ={0} {1}
	                                  ) aa left join YK_DJMX  bb on aa.YPPCH=bb.YPPCH  and bb.YWLX='001'
									                                left join YK_DJ cc on bb.DJID=cc.ID and cc.YWLX='001' 
                                 )
                                 tt  group by WLDW,tt.SHH,tt.YPPM,tt.YPGG,tt.SCCJ,tt.YLSJ,tt.XLSJ,tt.YJHJ,tt.XJHJ,DEPTID,KSMC,GHDWMC,CJID,YPDW ",deptid,ssql_rq);
                    #endregion
                }
                #endregion
            }

            tb = db.GetDataTable(ssql);
            return tb;
        }

        private DataTable GetTjHz(int deptid, int year, int month, DateTime t1, DateTime t2, TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string ssql = "";
            DataTable tb = new DataTable();
            t1 = Convert.ToDateTime(t1.ToShortDateString() + " 00:00:01");
            t2 = Convert.ToDateTime(t2.ToShortDateString() + " 23:59:59");
            string ssql_rq="";
            if (month == 0)
            {
                ssql_rq = string.Format(" and b.zxrq>='{0}' and b.zxrq<='{1}'", t1, t2);
            }
            string ssql_deptid = "";
            if (deptid > 0)
            {
                ssql_deptid = string.Format(" and a.deptid={0}",deptid);
            }

            ssql = string.Format(@"
                 select tt.CJID,tt.ypdw,tt.shh,tt.YPPM,tt.YPGG,tt.SCCJ,SUM(YPSL) ypsl,SUM(tt.TJHJE),SUM(tt.TLSJE),SUM(tt.tpfje),
                  tt.yjhj,tt.xjhj,tt.YPFJ,tt.YLSJ,tt.YLSJ,tt.XLSJ,tt.DEPTID,tt.KSMC
                   from
                (
                select a.CJID,a.YPDW, b.shh,b.YPPM,b.YPGG,b.s_sccj SCCJ,a.TJSL YPSL,
                a.DEPTID,dbo.fun_getDeptname(a.DEPTID) KSMC,
                a.SCJHJ yjhj,a.MRJHJ xjhj,a.YPFJ,a.XPFJ,a.YLSJ,a.XLSJ, a.TJHJE,a.TPFJE,a.TLSJE 
                from YF_TJMX a  inner join VI_YP_YPCD b on a.CJID=b.cjid  
                {0} {1}
                ) tt
                group by tt.DEPTID, tt.CJID,tt.ypdw,tt.shh,tt.YPPM,tt.YPGG,tt.SCCJ,tt.yjhj,tt.xjhj,tt.YPFJ,tt.XPFJ,tt.YLSJ,tt.XLSJ,tt.KSMC
    
                ",ssql_rq,ssql_deptid);

            return tb;

        }

       

	}
}
