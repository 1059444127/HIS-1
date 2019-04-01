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
	public class Frmkcgdcbj : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbyplx;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.Button butref;
		private System.Windows.Forms.Button button2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.Button butprint;
        private ComboBox cmbyjks;
        private Label label3;

		private System.ComponentModel.Container components = null;

		public Frmkcgdcbj(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.butprint = new System.Windows.Forms.Button();
            this.butref = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.butref);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(76, 23);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(116, 20);
            this.cmbyjks.TabIndex = 19;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "ҩ������";
            // 
            // rdo2
            // 
            this.rdo2.Location = new System.Drawing.Point(383, 38);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(168, 23);
            this.rdo2.TabIndex = 17;
            this.rdo2.Text = "�г��������޵Ŀ��ҩƷ";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.Checked = true;
            this.rdo1.Location = new System.Drawing.Point(384, 18);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(168, 24);
            this.rdo1.TabIndex = 16;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "�г��������޵Ŀ��ҩƷ";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // butprint
            // 
            this.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butprint.Location = new System.Drawing.Point(641, 24);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 23);
            this.butprint.TabIndex = 15;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butref
            // 
            this.butref.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butref.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.butref.Location = new System.Drawing.Point(563, 24);
            this.butref.Name = "butref";
            this.butref.Size = new System.Drawing.Size(72, 23);
            this.butref.TabIndex = 13;
            this.butref.Text = "��ѯ(&F)";
            this.butref.Click += new System.EventHandler(this.butref_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(720, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "�˳�(&Q)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Location = new System.Drawing.Point(257, 24);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(113, 20);
            this.cmbyplx.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(193, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "ҩƷ����";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 442);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "��ѯ���";
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
            this.myDataGrid1.Size = new System.Drawing.Size(858, 422);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1,
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.Width = 30;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "����";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "������";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn9.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "����";
            this.dataGridTextBoxColumn5.Width = 70;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "�����";
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "��������";
            this.dataGridTextBoxColumn6.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "��λ";
            this.dataGridTextBoxColumn8.Width = 30;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "����";
            this.dataGridTextBoxColumn23.Width = 60;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "cjid";
            this.dataGridTextBoxColumn24.Width = 0;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "���";
            this.dataGridTextBoxColumn11.Width = 30;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn12.Width = 150;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "���";
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "����";
            this.dataGridTextBoxColumn14.Width = 75;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "������";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn16.Width = 60;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "����";
            this.dataGridTextBoxColumn17.Width = 70;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "�����";
            this.dataGridTextBoxColumn18.Width = 70;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "��������";
            this.dataGridTextBoxColumn19.Width = 70;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "��λ";
            this.dataGridTextBoxColumn20.Width = 30;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "����";
            this.dataGridTextBoxColumn21.Width = 60;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "CJID";
            this.dataGridTextBoxColumn22.Width = 0;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 484);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(864, 25);
            this.statusBar1.TabIndex = 2;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // Frmkcgdcbj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 509);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmkcgdcbj";
            this.Text = "���ߵʹ�����";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkcgdcbj_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>


		private void Frmkcgdcbj_Load(object sender, System.EventArgs e)
		{
			CsMydataGrid(this.rdo1.Checked);


            Yp.AddcmbYjks(cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

            if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase) != DeptType.δ֪)
            {
                cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                cmbyjks.Enabled = false;
            }
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx,InstanceForm.BDatabase);
		}

		private void CsMydataGrid(bool rdo1)
		{
			this.myDataGrid1.DataSource=null;
			this.myDataGrid1.TableStyles[0].MappingName="";
			this.myDataGrid1.TableStyles[1].MappingName="";
			int ii=0;
			if (rdo1==true) ii=0;else ii=1;
			//��ʼ��
			DataTable myTb=new DataTable();
			myTb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[ii].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
					myTb.Columns.Add(this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].HeaderText,typeof(bool));
				else
					myTb.Columns.Add(this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
				this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].NullText="";
				this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[ii].GridColumnStyles[i].HeaderText;
			}
			this.myDataGrid1.DataSource=myTb;
			this.myDataGrid1.TableStyles[ii].MappingName ="Tb";

		}

		private void rdo2_CheckedChanged(object sender, System.EventArgs e)
		{
		  CsMydataGrid(this.rdo1.Checked);
		}

		private void butref_Click(object sender, System.EventArgs e)
		{
			try
			{
				string ssql="";
				int yplx=Convert.ToInt32(cmbyplx.SelectedValue);

				if (this.rdo1.Checked==true)
					ssql="select 0  ���,yppm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ����,pfj ������,lsj ���ۼ�,"+
						" cast(kcxx*(dwbl/ydwbl) as decimal(10,3)) ����,kcl �����,"+
						"((cast(kcxx*(dwbl/ydwbl) as decimal(10,3)))-kcl) ��������,dbo.fun_yp_ypdw(zxdw) ��λ,shh ����,a.cjid "+
						" from yp_kcsxx a,YF_kcmx b ,vi_yp_ypcd c"+ 
						" where a.cjid=b.cjid and a.deptid=b.deptid and b.cjid=c.cjid and b.deptid="+Convert.ToInt32(cmbyjks.SelectedValue)+" and b.bdelete=0 and ((cast(kcxx*(dwbl/ydwbl) as decimal(10,3)))-kcl)> 0";
				else
					ssql="select 0  ���,yppm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ����,pfj ������,lsj ���ۼ�,"+
						" cast(kcsx*(dwbl/ydwbl) as decimal(10,3)) ����,kcl �����,"+
						"(kcl-(cast(kcsx*(dwbl/ydwbl) as decimal(10,3)))) ��������,dbo.fun_yp_ypdw(zxdw) ��λ,shh ����,a.cjid "+
						" from yp_kcsxx a,YF_kcmx b ,vi_yp_ypcd c"+ 
						" where a.cjid=b.cjid and a.deptid=b.deptid and b.cjid=c.cjid and b.deptid="+Convert.ToInt32(cmbyjks.SelectedValue)+" and b.bdelete=0 and (kcl-(cast(kcsx*(dwbl/ydwbl) as decimal(10,3))))>0 ";
				if (yplx>0) ssql=ssql+" and yplx="+yplx+"";
				DataTable  tb=InstanceForm.BDatabase.GetDataTable(ssql);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string tjlb=rdo1.Checked==true?rdo1.Text.Trim():rdo2.Text.Trim();
				string kcsxxheadertext=rdo1.Checked==true?"����":"����";
				string bjczheadertext=rdo1.Checked==true?"��������":"��������";

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				//				ts_Yk_ReportView.ҩƷ�ߵʹ����� rpt=new ts_Yk_ReportView.ҩƷ�ߵʹ�����();
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.ҩƷ�ߵʹ�����.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					myrow["ypspm"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["pfj"]=Convert.ToDecimal(tb.Rows[i]["������"]);
					myrow["lsj"]=Convert.ToDecimal(tb.Rows[i]["���ۼ�"]);
					if (rdo1.Checked==true)
						myrow["kcsxx"]=Convert.ToDecimal(tb.Rows[i]["����"]);
					else
						myrow["kcsxx"]=Convert.ToDecimal(tb.Rows[i]["����"]);

					myrow["kcl"]=Convert.ToDecimal(tb.Rows[i]["�����"]);

					if (rdo1.Checked==true)
						myrow["gdc"]=Convert.ToDecimal(tb.Rows[i]["��������"]);
					else
						myrow["gdc"]=Convert.ToDecimal(tb.Rows[i]["��������"]);

					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					Dset.ҩƷ�ߵʹ�����.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[5];
				parameters[0].Text="yplx";
				parameters[0].Value=cmbyplx.Text;
				parameters[1].Text="tjlb";
				parameters[1].Value=tjlb;
				parameters[2].Text="kcsxxheadertext";
				parameters[2].Value=kcsxxheadertext.Trim();
				parameters[3].Text="bjczheadertext";
				parameters[3].Value=bjczheadertext.Trim();
				parameters[4].Text="TITLETEXT";
                parameters[4].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + this.Text;

				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ�ߵʹ�����,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ�ߵʹ�����.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), cmbyplx, InstanceForm.BDatabase);
        }

	}
}
