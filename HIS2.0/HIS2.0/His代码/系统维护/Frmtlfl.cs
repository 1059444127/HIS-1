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
namespace ts_yp_xtwh
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Frmtlfl : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private myDataGrid.myDataGrid myDataGrid2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butdel;
		private System.Windows.Forms.Button butadd;
		private System.Windows.Forms.Button butall;
		private System.Windows.Forms.Button butuall;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel8;
		private System.ComponentModel.IContainer components;

		public Frmtlfl(MenuTag menuTag,string chineseName,Form mdiParent)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			_menuTag=menuTag;
			_chineseName=chineseName;
			_mdiParent=mdiParent;
			this.Text=_chineseName;
			
			
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frmtlfl));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.myDataGrid1 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn2 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.myDataGrid2 = new myDataGrid.myDataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel3 = new System.Windows.Forms.Panel();
			this.butuall = new System.Windows.Forms.Button();
			this.butall = new System.Windows.Forms.Button();
			this.butquit = new System.Windows.Forms.Button();
			this.butdel = new System.Windows.Forms.Button();
			this.butadd = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.panel6 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel8.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 461);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(880, 16);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.Text = "statusBar1";
			this.statusBar1.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(176, 461);
			this.panel1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.treeView1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.ForeColor = System.Drawing.Color.Navy;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 461);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "����鿴";
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(3, 17);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(170, 441);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(176, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 461);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid1.CaptionForeColor = System.Drawing.Color.Navy;
			this.myDataGrid1.CaptionText = "AAA";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.Size = new System.Drawing.Size(701, 226);
			this.myDataGrid1.TabIndex = 0;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridBoolColumn2,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn18});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "���";
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 35;
			// 
			// dataGridBoolColumn2
			// 
			this.dataGridBoolColumn2.FalseValue = ((short)(0));
			this.dataGridBoolColumn2.HeaderText = "ѡ��";
			this.dataGridBoolColumn2.MappingName = "";
			this.dataGridBoolColumn2.NullValue = ((short)(0));
			this.dataGridBoolColumn2.TrueValue = ((short)(1));
			this.dataGridBoolColumn2.Width = 40;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "����";
			this.dataGridTextBoxColumn2.MappingName = "";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 70;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Ʒ��";
			this.dataGridTextBoxColumn3.MappingName = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 120;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "��Ʒ��";
			this.dataGridTextBoxColumn4.MappingName = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 120;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "���";
			this.dataGridTextBoxColumn5.MappingName = "";
			this.dataGridTextBoxColumn5.ReadOnly = true;
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "����";
			this.dataGridTextBoxColumn7.MappingName = "";
			this.dataGridTextBoxColumn7.ReadOnly = true;
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "��λ";
			this.dataGridTextBoxColumn6.MappingName = "";
			this.dataGridTextBoxColumn6.ReadOnly = true;
			this.dataGridTextBoxColumn6.Width = 40;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "����";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.ReadOnly = true;
			this.dataGridTextBoxColumn8.Width = 65;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "cjid";
			this.dataGridTextBoxColumn18.MappingName = "";
			this.dataGridTextBoxColumn18.ReadOnly = true;
			this.dataGridTextBoxColumn18.Width = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.myDataGrid2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 36);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(701, 172);
			this.panel2.TabIndex = 8;
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.Silver;
			this.myDataGrid2.CaptionForeColor = System.Drawing.Color.Navy;
			this.myDataGrid2.CaptionText = "��ѡ��Ҫ��ӵ������ҩƷ";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.HeaderForeColor = System.Drawing.Color.Black;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.Size = new System.Drawing.Size(701, 172);
			this.myDataGrid2.TabIndex = 0;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridBoolColumn1,
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn17});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "";
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "���";
			this.dataGridTextBoxColumn9.MappingName = "";
			this.dataGridTextBoxColumn9.ReadOnly = true;
			this.dataGridTextBoxColumn9.Width = 35;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = ((short)(0));
			this.dataGridBoolColumn1.HeaderText = "ѡ��";
			this.dataGridBoolColumn1.MappingName = "";
			this.dataGridBoolColumn1.NullText = "0";
			this.dataGridBoolColumn1.NullValue = ((short)(0));
			this.dataGridBoolColumn1.TrueValue = ((short)(1));
			this.dataGridBoolColumn1.Width = 40;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "����";
			this.dataGridTextBoxColumn10.MappingName = "";
			this.dataGridTextBoxColumn10.ReadOnly = true;
			this.dataGridTextBoxColumn10.Width = 70;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Ʒ��";
			this.dataGridTextBoxColumn11.MappingName = "";
			this.dataGridTextBoxColumn11.ReadOnly = true;
			this.dataGridTextBoxColumn11.Width = 120;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.HeaderText = "��Ʒ��";
			this.dataGridTextBoxColumn12.MappingName = "";
			this.dataGridTextBoxColumn12.ReadOnly = true;
			this.dataGridTextBoxColumn12.Width = 120;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "���";
			this.dataGridTextBoxColumn13.MappingName = "";
			this.dataGridTextBoxColumn13.ReadOnly = true;
			this.dataGridTextBoxColumn13.Width = 75;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "����";
			this.dataGridTextBoxColumn14.MappingName = "";
			this.dataGridTextBoxColumn14.ReadOnly = true;
			this.dataGridTextBoxColumn14.Width = 75;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "��λ";
			this.dataGridTextBoxColumn15.MappingName = "";
			this.dataGridTextBoxColumn15.ReadOnly = true;
			this.dataGridTextBoxColumn15.Width = 40;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "����";
			this.dataGridTextBoxColumn16.MappingName = "";
			this.dataGridTextBoxColumn16.ReadOnly = true;
			this.dataGridTextBoxColumn16.Width = 65;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "cjid";
			this.dataGridTextBoxColumn17.MappingName = "";
			this.dataGridTextBoxColumn17.ReadOnly = true;
			this.dataGridTextBoxColumn17.Width = 0;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.butuall);
			this.panel3.Controls.Add(this.butall);
			this.panel3.Controls.Add(this.butquit);
			this.panel3.Controls.Add(this.butdel);
			this.panel3.Controls.Add(this.butadd);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(701, 36);
			this.panel3.TabIndex = 9;
			// 
			// butuall
			// 
			this.butuall.BackColor = System.Drawing.SystemColors.Control;
			this.butuall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butuall.ForeColor = System.Drawing.Color.Navy;
			this.butuall.Location = new System.Drawing.Point(328, -1);
			this.butuall.Name = "butuall";
			this.butuall.Size = new System.Drawing.Size(72, 32);
			this.butuall.TabIndex = 4;
			this.butuall.Text = "��ѡ(&U)";
			this.butuall.Click += new System.EventHandler(this.butuall_Click);
			// 
			// butall
			// 
			this.butall.BackColor = System.Drawing.SystemColors.Control;
			this.butall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butall.ForeColor = System.Drawing.Color.Navy;
			this.butall.Location = new System.Drawing.Point(248, -1);
			this.butall.Name = "butall";
			this.butall.Size = new System.Drawing.Size(72, 32);
			this.butall.TabIndex = 3;
			this.butall.Text = "ȫѡ(&S)";
			this.butall.Click += new System.EventHandler(this.butall_Click);
			// 
			// butquit
			// 
			this.butquit.BackColor = System.Drawing.SystemColors.Control;
			this.butquit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butquit.ForeColor = System.Drawing.Color.Navy;
			this.butquit.Location = new System.Drawing.Point(568, -1);
			this.butquit.Name = "butquit";
			this.butquit.Size = new System.Drawing.Size(72, 32);
			this.butquit.TabIndex = 2;
			this.butquit.Text = "�˳�(&Q)";
			this.butquit.Click += new System.EventHandler(this.butquit_Click);
			// 
			// butdel
			// 
			this.butdel.BackColor = System.Drawing.SystemColors.Control;
			this.butdel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butdel.ForeColor = System.Drawing.Color.Navy;
			this.butdel.Location = new System.Drawing.Point(488, -1);
			this.butdel.Name = "butdel";
			this.butdel.Size = new System.Drawing.Size(72, 32);
			this.butdel.TabIndex = 1;
			this.butdel.Text = "�Ƴ�(&D)";
			this.butdel.Click += new System.EventHandler(this.butdel_Click);
			// 
			// butadd
			// 
			this.butadd.BackColor = System.Drawing.SystemColors.Control;
			this.butadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.butadd.ForeColor = System.Drawing.Color.Navy;
			this.butadd.Location = new System.Drawing.Point(408, -1);
			this.butadd.Name = "butadd";
			this.butadd.Size = new System.Drawing.Size(72, 32);
			this.butadd.TabIndex = 0;
			this.butadd.Text = "���(&A)";
			this.butadd.Click += new System.EventHandler(this.butadd_Click);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.panel5);
			this.panel7.Controls.Add(this.panel4);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(701, 250);
			this.panel7.TabIndex = 11;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.myDataGrid1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 24);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(701, 226);
			this.panel5.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.tabControl1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(701, 24);
			this.panel4.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(701, 24);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.panel2);
			this.panel6.Controls.Add(this.panel3);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new System.Drawing.Point(179, 253);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(701, 208);
			this.panel6.TabIndex = 12;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(179, 250);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(701, 3);
			this.splitter2.TabIndex = 13;
			this.splitter2.TabStop = false;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.panel7);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(179, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(701, 250);
			this.panel8.TabIndex = 14;
			// 
			// Frmtlfl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(880, 477);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.Name = "Frmtlfl";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Frmtlfl_Load);
			this.Activated += new System.EventHandler(this.Frmtlfl_Activated);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//������Ա�־��
		private void AddTreeYpsx()
		{
			
			this.treeView1.Nodes.Clear();
			this.treeView1.ImageList=this.imageList1;
			TreeNode node = treeView1.Nodes.Add("����״̬");
			TreeNode node1 = treeView1.Nodes.Add("ҩƷ����");


//			TreeNode Cnode1=node.Nodes.Add("�Է�ҩƷ");
//			Cnode1.Tag=" and zfyp=1 ";
//			Cnode1.ImageIndex=1;
			TreeNode Cnode2=node.Nodes.Add("����ҩƷ");
			Cnode2.Tag=" and djyp=1 ";
			Cnode2.ImageIndex=1;
			TreeNode Cnode3=node.Nodes.Add("����ҩƷ");
			Cnode3.Tag=" and mzyp=1 ";
			Cnode3.ImageIndex=1;
			TreeNode Cnode4=node.Nodes.Add("Ƥ��ҩƷ");
			Cnode4.Tag=" and psyp=1 ";
			Cnode4.ImageIndex=1;
			TreeNode Cnode5=node.Nodes.Add("����ҩƷ");
			Cnode5.Tag=" and jsyp=1 ";
			Cnode5.ImageIndex=1;
			TreeNode Cnode6=node.Nodes.Add("����ҩƷ");
			Cnode6.Tag=" and gzyp=1 ";
			Cnode6.ImageIndex=1;
			TreeNode Cnode7=node.Nodes.Add("�Ǵ���ҩƷ");
			Cnode7.Tag=" and fcfyp=1 ";
			Cnode7.ImageIndex=1;
			TreeNode Cnode8=node.Nodes.Add("����ҺҩƷ");
			Cnode8.Tag=" and dsyyp=1 ";
			Cnode8.ImageIndex=1;
			TreeNode Cnode10=node.Nodes.Add("GMPҩƷ");
			Cnode10.Tag=" and gmpyp=1 ";
			Cnode10.ImageIndex=1;
//			TreeNode Cnode11=node.Nodes.Add("ҽ������ҩƷ");
//			Cnode11.Tag=" and ybpsyp=1 ";
//			Cnode11.ImageIndex=1;
//			TreeNode Cnode12=node.Nodes.Add("�б�ҩƷ");
//			Cnode12.Tag=" and zbzt>0 ";
//			Cnode12.ImageIndex=1;
			TreeNode Cnode13=node.Nodes.Add("ͣ�õ�ҩƷ");
			Cnode13.Tag=" and BDELETE=1 ";
			Cnode13.ImageIndex=1;


			//������
			DataTable tb=InstanceForm.BDatabase.GetDataTable("select * from yp_yplx where id<=2");
			for(int i=0 ;i<=tb.Rows.Count-1;i++)
			{
				TreeNode nodejx = node1.Nodes.Add(tb.Rows[i]["mc"].ToString());
				nodejx.Tag=" and n_yplx="+Convert.ToInt32(tb.Rows[i]["id"])+"";
				nodejx.ImageIndex=0;
				DataTable tbc=InstanceForm.BDatabase.GetDataTable("select * from yp_ypjx where yplx="+Convert.ToInt32(tb.Rows[i]["id"])+"");
				for (int j=0;j<=tbc.Rows.Count-1;j++)
				{
					TreeNode Cnodejx = nodejx.Nodes.Add(tbc.Rows[j]["mc"].ToString());
					Cnodejx.Tag=" and n_yplx="+Convert.ToInt32(tb.Rows[i]["id"])+" and s_ypjx='"+Convert.ToString(tbc.Rows[j]["mc"]).Trim()+"'";
					Cnodejx.ImageIndex=1;
				}
				TreeNode CnodeNull = nodejx.Nodes.Add("Null");
				CnodeNull.Tag=" and n_yplx="+Convert.ToInt32(tb.Rows[i]["id"])+" and (s_ypjx is null or rtrim(s_ypjx)='') ";
				CnodeNull.ImageIndex=1;
			}


		}

		//���ҩ�����
		private void Addtlfl()
		{
			string ssql="select * from yp_tlfl";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				TabPage Tabpage =new System.Windows.Forms.TabPage(tb.Rows[i]["name"].ToString());
				Tabpage.Tag=tb.Rows[i]["code"].ToString();
				this.tabControl1.Controls.Add(Tabpage);
			}
		}
	
		//��Ӷ�Ӧ��TABPAGE��ҩƷ
		private void AddTabPageYp(string tlfl)
		{
			string ssql="select 0 ���,cast(0 as smallint) ѡ��,s_ypjx ����,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,s_ypdw ��λ,shh ����,cjid from yp_ypcjd where tlfl='"+tlfl+"' order by n_yplx,s_ypjx";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			tb.TableName="tb1";
			this.myDataGrid1.DataSource=tb;
		}

		//���û�й����ҩƷ
		private void AddSelectYp(string ssql)
		{
			string ssqlb="select 0 ���,cast(0 as smallint) ѡ��,s_ypjx ����,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,s_ypdw ��λ,shh ����,cjid from yp_ypcjd where (tlfl is null or rtrim(tlfl)='')  "+ssql;
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssqlb);
			tb.TableName="tb2";
			this.myDataGrid2.DataSource=tb;
		}
		
		//Load �¼�
		private void Frmtlfl_Load(object sender, System.EventArgs e)
		{

			//���ͳ�����
			this.Addtlfl();

			//��ʼ����
			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"tb1");
			FunBase.CsDataGrid(this.myDataGrid2,this.myDataGrid2.TableStyles[0],"tb2");

			//��ӵ�ǰͳ�����
			AddTabPageYp(this.tabControl1.SelectedTab.Tag.ToString().Trim());
		
		}

		//TabPage �ĸı��¼�
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//��ӵ�ǰͳ�����
			AddTabPageYp(this.tabControl1.SelectedTab.Tag.ToString().Trim());
			this.myDataGrid1.CaptionText=this.tabControl1.SelectedTab.Text.Trim();
		}

		//ѡ�����νṹ�Ľڵ��¼�
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node.Tag!=null)
			this.AddSelectYp(e.Node.Tag.ToString());
		}

		//ȫѡ�¼�
		private void butall_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				tb.Rows[i]["ѡ��"]=(short)1;
			}
		}

		//��ȫѡ�¼�
		private void butuall_Click(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid2.DataSource;
			for(int i=0;i<=tb.Rows.Count-1;i++)
			{
				tb.Rows[i]["ѡ��"]=(short)0;
			}
		}

		//����¼�
		private void butadd_Click(object sender, System.EventArgs e)
		{
			this.butadd.Enabled=false;


			try
			{
				InstanceForm.BDatabase.BeginTransaction();

				DataTable tb=(DataTable)this.myDataGrid2.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToBoolean(tb.Rows[i]["ѡ��"])==true)
					{
						string ssql="update yp_ypcjd set tlfl='"+this.tabControl1.SelectedTab.Tag.ToString().Trim()+"' where cjid="+Convert.ToInt32(tb.Rows[i]["cjid"])+"";
						InstanceForm.BDatabase.DoCommand(ssql);
					}
				}

				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("����ɹ�");
				this.butadd.Enabled=true;
				//ˢ�µ�ǰͳ�����
				AddTabPageYp(this.tabControl1.SelectedTab.Tag.ToString().Trim());
				//ˢ��û�з����ҩƷ
				AddSelectYp(this.treeView1.SelectedNode.Tag.ToString());

			}
			catch(System.Exception err)
			{
				this.butadd.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				this.butadd.Enabled=true;
				MessageBox.Show(err.Message);
				
			}

		}

		//��������¼�
		private void butdel_Click(object sender, System.EventArgs e)
		{
			this.butdel.Enabled=false;

			try
			{
				InstanceForm.BDatabase.BeginTransaction();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					if (Convert.ToBoolean(tb.Rows[i]["ѡ��"])==true)
					{
						string ssql="update yp_ypcjd set tlfl=null where cjid="+Convert.ToInt32(tb.Rows[i]["cjid"])+"";
						InstanceForm.BDatabase.DoCommand(ssql);
					}
				}

				//�ύ����
				InstanceForm.BDatabase.CommitTransaction();
				MessageBox.Show("��ǰѡ���ҩƷ�ѳɹ��������");
				this.butdel.Enabled=true;

				//ˢ�µ�ǰͳ�����
				AddTabPageYp(this.tabControl1.SelectedTab.Tag.ToString().Trim());
				//ˢ��û�з����ҩƷ
				AddSelectYp(this.treeView1.SelectedNode.Tag.ToString());

			}
			catch(System.Exception err)
			{
				this.butadd.Enabled=true;
				InstanceForm.BDatabase.RollbackTransaction();
				this.butdel.Enabled=true;
				MessageBox.Show(err.Message);
				
			}

		}

		
		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Frmtlfl_Activated(object sender, System.EventArgs e)
		{
			//������νṹ
			AddTreeYpsx();
		}

	}


}
