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
	public class Frmpyrgzl : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.StatusBarPanel statusBarPanel7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.ComboBox cmbks;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmpyrgzl(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel7 = new System.Windows.Forms.StatusBarPanel();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbks = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel5,
            this.statusBarPanel7});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel5
            // 
            this.statusBarPanel5.Name = "statusBarPanel5";
            this.statusBarPanel5.Width = 200;
            // 
            // statusBarPanel7
            // 
            this.statusBarPanel7.Name = "statusBarPanel7";
            this.statusBarPanel7.Width = 1000;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = null;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn4.Width = 120;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "����";
            this.dataGridTextBoxColumn9.Width = 90;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "����";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "ӯ������";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "��������";
            this.dataGridTextBoxColumn16.Width = 60;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "��λ";
            this.dataGridTextBoxColumn14.Width = 40;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "���";
            this.dataGridTextBoxColumn11.Width = 90;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "������λ";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "��Ŀ";
            this.dataGridTextBoxColumn17.Width = 120;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "��ҩ��λ";
            this.dataGridTextBoxColumn18.Width = 120;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "����ԭ��";
            this.dataGridTextBoxColumn19.Width = 120;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "����ԭ��";
            this.dataGridTextBoxColumn20.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "�������";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "�������";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "���۽��";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "������";
            this.dataGridTextBoxColumn7.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "������";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "CJID";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "GHDWID";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbks);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ͳ��";
            // 
            // cmbks
            // 
            this.cmbks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbks.Location = new System.Drawing.Point(78, 26);
            this.cmbks.Name = "cmbks";
            this.cmbks.Size = new System.Drawing.Size(133, 20);
            this.cmbks.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "ҩ������";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(704, 20);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 32);
            this.butquit.TabIndex = 20;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(632, 20);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 32);
            this.butprint.TabIndex = 19;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(552, 20);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 32);
            this.buttj.TabIndex = 18;
            this.buttj.Text = "ͳ��(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(401, 25);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(128, 21);
            this.dtp2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(378, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(266, 25);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(111, 21);
            this.dtp1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(218, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "���ڴ�";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 430);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "������";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 410);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn28});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "����";
            this.dataGridTextBoxColumn22.Width = 80;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "��ҩ��";
            this.dataGridTextBoxColumn27.Width = 75;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "��ҩ��";
            this.dataGridTextBoxColumn26.Width = 75;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "�����";
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // Frmpyrgzl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmpyrgzl";
            this.Text = "��ҩ�˹�����ͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmpyrgzl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmpyrgzl_Load(object sender, System.EventArgs e)
		{
			try
			{
				DataTable Tb=new DataTable();
				Tb.TableName="Tb";
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.Int16"));	
					else
						Tb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
				}
				this.myDataGrid1.DataSource=Tb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";

				this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

				Addyjks(cmbks,1);

                cmbks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[4];
				if (_menuTag.Function_Name.Trim()=="Fun_ts_yf_tjbb_pyrgzl")
					parameters[0].Value=0;
				else
					parameters[0].Value=1;
				parameters[1].Value=dtp1.Value.ToShortDateString();
				parameters[2].Value=dtp2.Value.ToShortDateString();
				parameters[3].Value=Convert.ToInt32(cmbks.SelectedValue);
				
				parameters[0].Text="@type";
				parameters[1].Text="@dtp1";
				parameters[2].Text="@dtp2";
				parameters[3].Text="@deptid";

                #region"Modify by jchl_0718"
                DataTable tb = InstanceForm.BDatabase.GetDataTable("SP_YF_tj_PYFYGZL", parameters, 30);
                //DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YF_tj_PYRGZL",parameters,30);
                #endregion
                FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}


		public static void Addyjks (System.Windows.Forms.ComboBox cmb)
		{
			string ssql="select KSMC,DEPTID from yp_yjks where qybz=1 and kslx='ҩ��'";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			cmb.DataSource=tb;
			cmb.ValueMember="DEPTID";
			cmb.DisplayMember ="KSMC";
		}
		public static void Addyjks (System.Windows.Forms.ComboBox cmb,int all)
		{
			string ssql="select KSMC,DEPTID from yp_yjks where qybz=1 and kslx='ҩ��' union select 'ȫ��',0 ";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			cmb.DataSource=tb;
			cmb.ValueMember="DEPTID";
			cmb.DisplayMember ="KSMC";
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
//				Xc_Yf_ReportView.�䷢ҩ������ͳ��    rpt=new Xc_Yf_ReportView.�䷢ҩ������ͳ��();
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

//				rpt.SetParameterValue("rq1",dtp1.Value.ToShortDateString());
//				rpt.SetParameterValue("rq2",dtp2.Value.ToShortDateString());
//				rpt.SetParameterValue("TITLETEXT",this.Text);
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.��ҩ��ҩ������ͳ��.NewRow();
					myrow["tjr"]=Convert.ToString(tb.Rows[i]["����"]);
                    myrow["fys"] = Convert.ToInt64(tb.Rows[i]["��ҩ��"]);
                    myrow["pys"] = Convert.ToInt64(tb.Rows[i]["��ҩ��"]);
                    myrow["phs"] = Convert.ToInt64(tb.Rows[i]["�����"]);
                    Dset.��ҩ��ҩ������ͳ��.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[3];
				parameters[0].Text="rq1";
				parameters[0].Value=dtp1.Value.ToShortDateString();
				parameters[1].Text="rq2";
				parameters[1].Value=dtp2.Value.ToShortDateString();
				parameters[2].Text="TITLETEXT";
				parameters[2].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+this.Text;


                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ҩ������ͳ��, Constant.ApplicationDirectory + "\\Report\\YF_�䷢ҩ������ͳ��_JCHL.rpt", parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}



	}
}
