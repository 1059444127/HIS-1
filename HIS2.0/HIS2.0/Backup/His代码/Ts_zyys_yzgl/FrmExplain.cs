using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ts_zyys_public;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;

namespace Ts_zyys_yzgl
{
	/// <summary>
	/// ѡ��˵����ҽ�� ��ժҪ˵����
	/// </summary>
	public class FrmExplain : System.Windows.Forms.Form
	{
		public string Explain="";
		public string default_usage="";
		public long deptID=0;
		public Guid BinID=Guid.Empty;
		private DbQuery myQuery=new DbQuery();
		private DataTable myTb=new DataTable();
		private DataSet ds=new DataSet();
		private ComboBox cmb;
		public int page=0;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gBoxOPS;
		private System.Windows.Forms.GroupBox gBoxExplain;
		private System.Windows.Forms.RadioButton radExplain;
		private System.Windows.Forms.RadioButton radOPS;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.ComboBox cmbExplain;
		private System.Windows.Forms.DateTimePicker dTimePicker1;
		private System.Windows.Forms.ComboBox cmbMZ;
		private System.Windows.Forms.ComboBox cmbSS;
		private TrasenClasses.GeneralControls.LabelEx tsLabel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGrid dGrid_Sel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.ComponentModel.IContainer components;

		public FrmExplain()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

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
            this.cmbExplain = new System.Windows.Forms.ComboBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gBoxOPS = new System.Windows.Forms.GroupBox();
            this.cmbSS = new System.Windows.Forms.ComboBox();
            this.cmbMZ = new System.Windows.Forms.ComboBox();
            this.dTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxExplain = new System.Windows.Forms.GroupBox();
            this.radExplain = new System.Windows.Forms.RadioButton();
            this.radOPS = new System.Windows.Forms.RadioButton();
            this.tsLabel1 = new TrasenClasses.GeneralControls.LabelEx(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGrid_Sel = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gBoxOPS.SuspendLayout();
            this.gBoxExplain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Sel)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbExplain
            // 
            this.cmbExplain.DropDownWidth = 250;
            this.cmbExplain.Location = new System.Drawing.Point(8, 30);
            this.cmbExplain.Name = "cmbExplain";
            this.cmbExplain.Size = new System.Drawing.Size(168, 21);
            this.cmbExplain.TabIndex = 0;
            this.cmbExplain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            this.cmbExplain.SelectedValueChanged += new System.EventHandler(this.cmbExplain_SelectedValueChanged);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(131, 192);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(72, 24);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "ȷ��(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(251, 192);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(72, 24);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "ȡ��(&C)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // gBoxOPS
            // 
            this.gBoxOPS.Controls.Add(this.cmbSS);
            this.gBoxOPS.Controls.Add(this.cmbMZ);
            this.gBoxOPS.Controls.Add(this.dTimePicker1);
            this.gBoxOPS.Controls.Add(this.label4);
            this.gBoxOPS.Controls.Add(this.label3);
            this.gBoxOPS.Controls.Add(this.label2);
            this.gBoxOPS.Enabled = false;
            this.gBoxOPS.Location = new System.Drawing.Point(208, 8);
            this.gBoxOPS.Name = "gBoxOPS";
            this.gBoxOPS.Size = new System.Drawing.Size(232, 168);
            this.gBoxOPS.TabIndex = 1;
            this.gBoxOPS.TabStop = false;
            this.gBoxOPS.Text = "����ҽ��";
            // 
            // cmbSS
            // 
            this.cmbSS.DropDownWidth = 170;
            this.cmbSS.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSS.Location = new System.Drawing.Point(72, 127);
            this.cmbSS.MaxDropDownItems = 10;
            this.cmbSS.Name = "cmbSS";
            this.cmbSS.Size = new System.Drawing.Size(152, 21);
            this.cmbSS.TabIndex = 2;
            this.cmbSS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            // 
            // cmbMZ
            // 
            this.cmbMZ.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMZ.Items.AddRange(new object[] {
            "����",
            "ȫ��",
            "������",
            "ӲĤ������",
            "׵��������",
            "��Ӳ����"});
            this.cmbMZ.Location = new System.Drawing.Point(72, 77);
            this.cmbMZ.Name = "cmbMZ";
            this.cmbMZ.Size = new System.Drawing.Size(152, 21);
            this.cmbMZ.TabIndex = 1;
            this.cmbMZ.Text = "����";
            // 
            // dTimePicker1
            // 
            this.dTimePicker1.CalendarFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dTimePicker1.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTimePicker1.Location = new System.Drawing.Point(72, 24);
            this.dTimePicker1.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dTimePicker1.MinDate = new System.DateTime(2004, 8, 23, 0, 0, 0, 0);
            this.dTimePicker1.Name = "dTimePicker1";
            this.dTimePicker1.ShowUpDown = true;
            this.dTimePicker1.Size = new System.Drawing.Size(152, 24);
            this.dTimePicker1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "��������";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "����ʽ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "����ʱ��";
            // 
            // gBoxExplain
            // 
            this.gBoxExplain.Controls.Add(this.cmbExplain);
            this.gBoxExplain.Location = new System.Drawing.Point(16, 104);
            this.gBoxExplain.Name = "gBoxExplain";
            this.gBoxExplain.Size = new System.Drawing.Size(184, 72);
            this.gBoxExplain.TabIndex = 1;
            this.gBoxExplain.TabStop = false;
            this.gBoxExplain.Text = "˵��ҽ��";
            // 
            // radExplain
            // 
            this.radExplain.Checked = true;
            this.radExplain.Location = new System.Drawing.Point(24, 40);
            this.radExplain.Name = "radExplain";
            this.radExplain.Size = new System.Drawing.Size(80, 24);
            this.radExplain.TabIndex = 0;
            this.radExplain.TabStop = true;
            this.radExplain.Text = "˵��ҽ��";
            this.radExplain.CheckedChanged += new System.EventHandler(this.radExplain_CheckedChanged);
            // 
            // radOPS
            // 
            this.radOPS.Enabled = false;
            this.radOPS.Location = new System.Drawing.Point(112, 40);
            this.radOPS.Name = "radOPS";
            this.radOPS.Size = new System.Drawing.Size(80, 24);
            this.radOPS.TabIndex = 9;
            this.radOPS.Text = "����ҽ��";
            // 
            // tsLabel1
            // 
            this.tsLabel1.BackColor1 = System.Drawing.SystemColors.ControlDarkDark;
            this.tsLabel1.BackColor2 = System.Drawing.Color.AliceBlue;
            this.tsLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsLabel1.Font = new System.Drawing.Font("����", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsLabel1.ForeColor = System.Drawing.SystemColors.Window;
            this.tsLabel1.Location = new System.Drawing.Point(0, 0);
            this.tsLabel1.Name = "tsLabel1";
            this.tsLabel1.Size = new System.Drawing.Size(456, 28);
            this.tsLabel1.TabIndex = 10;
            this.tsLabel1.Text = "˵����ҽ��";
            this.tsLabel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dGrid_Sel);
            this.panel1.Controls.Add(this.radOPS);
            this.panel1.Controls.Add(this.gBoxOPS);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.gBoxExplain);
            this.panel1.Controls.Add(this.radExplain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 244);
            this.panel1.TabIndex = 11;
            // 
            // dGrid_Sel
            // 
            this.dGrid_Sel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dGrid_Sel.CaptionVisible = false;
            this.dGrid_Sel.DataMember = "";
            this.dGrid_Sel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGrid_Sel.Location = new System.Drawing.Point(24, 152);
            this.dGrid_Sel.Name = "dGrid_Sel";
            this.dGrid_Sel.RowHeaderWidth = 20;
            this.dGrid_Sel.Size = new System.Drawing.Size(240, 130);
            this.dGrid_Sel.TabIndex = 10;
            this.dGrid_Sel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1,
            this.dataGridTableStyle2});
            this.dGrid_Sel.Visible = false;
            this.dGrid_Sel.DoubleClick += new System.EventHandler(this.dGrid_Sel_DoubleClick);
            this.dGrid_Sel.CurrentCellChanged += new System.EventHandler(this.dGrid_Sel_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dGrid_Sel;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "explain";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 20;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "�к�";
            this.dataGridTextBoxColumn1.MappingName = "ROWNO";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "����";
            this.dataGridTextBoxColumn2.MappingName = "name";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 160;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "ƴ����";
            this.dataGridTextBoxColumn3.MappingName = "py_code";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "�����";
            this.dataGridTextBoxColumn4.MappingName = "wb_code";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 60;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "������";
            this.dataGridTextBoxColumn5.MappingName = "d_code";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Ĭ���÷�";
            this.dataGridTextBoxColumn6.MappingName = "default_usage";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dGrid_Sel;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ss";
            this.dataGridTableStyle2.RowHeaderWidth = 20;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "�к�";
            this.dataGridTextBoxColumn7.MappingName = "ROWNO";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "����";
            this.dataGridTextBoxColumn8.MappingName = "name";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 160;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "ƴ����";
            this.dataGridTextBoxColumn9.MappingName = "py_code";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "�����";
            this.dataGridTextBoxColumn10.MappingName = "wb_code";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "������";
            this.dataGridTextBoxColumn11.MappingName = "d_code";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 60;
            // 
            // FrmExplain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(456, 272);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tsLabel1);
            this.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExplain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "˵����ҽ��";
            this.Activated += new System.EventHandler(this.FrmExplain_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmExplain_KeyUp);
            this.Load += new System.EventHandler(this.FrmExplain_Load);
            this.gBoxOPS.ResumeLayout(false);
            this.gBoxOPS.PerformLayout();
            this.gBoxExplain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGrid_Sel)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void radExplain_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radExplain.Checked==true) 
			{
				gBoxExplain.Enabled=true;
				gBoxOPS.Enabled=false;
				cmbExplain.Focus();
			}
			else 
			{
				gBoxOPS.Enabled=true;
				gBoxExplain.Enabled=false;
				this.dTimePicker1.Focus();
				default_usage="";
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			Explain="";
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(gBoxExplain.Enabled==true)
			{
				Explain=cmbExplain.Text;
			}
			else
			{
				string str1="",str2="",str3="";
				DateTime dtime=DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
				if(this.dTimePicker1.Value.Date==dtime) str1="����";
				else if(this.dTimePicker1.Value.Date==dtime.AddDays(1)) str1="����";
				else if(this.dTimePicker1.Value.DayOfWeek==DayOfWeek.Monday) str1="����һ";
				else str1=this.dTimePicker1.Value.Month.ToString()+"��"+this.dTimePicker1.Value.Day.ToString()+"��";
				str1+=this.dTimePicker1.Value.Hour.ToString()+":"+this.dTimePicker1.Value.Minute.ToString();
				str2=cmbMZ.Text.Trim();
				str3=cmbSS.Text.Trim();
				Explain="��"+str1+"��"+str2+"����"+str3;
			}

			this.Close();
		}

		private void FrmExplain_Load(object sender, System.EventArgs e)
		{
			DataTable dt=myQuery.GetExplain(this.deptID,7,0);
			dt.TableName="explain";
			additem(cmbExplain,dt);
			if(page!=0) 
			{
				DateTime sTime=myQuery.GetSSRQ(this.BinID);
				DateTime dTime=DateManager.ServerDateTimeByDBType(FrmMdiMain.Database);
				if(sTime.ToShortDateString()!="0001-1-1")
				{
					if(sTime>dTime) 
					{
						this.dTimePicker1.Value=sTime;
						this.dTimePicker1.Enabled=false;
					}
					else this.dTimePicker1.Value=dTime;
				}
				else this.dTimePicker1.Value=dTime;
				this.dTimePicker1.MinDate=dTime.Date;
				this.dTimePicker1.MaxDate=dTime.AddDays(7);
				myTb=myQuery.GetExplain(this.deptID,6,1);
				myTb.TableName="ss";
				ds.Tables.Add(myTb);
				//				additem(cmbSS,myTb);				
				for( int i=0 ;i<myTb.Rows.Count; i++ )
				{
					cmbSS.Items.Add(myTb.Rows[i]["NAME"]);
				}
				radOPS.Enabled=true;
				cmbSS.Text="";
                
			}
            
		}		

		private void additem(System.Windows.Forms.ComboBox cmb,DataTable dt)
		{
			if(dt.Rows.Count==0) return;

			cmb.DataSource=dt;
			cmb.DisplayMember="NAME";
			cmb.ValueMember="CODE";
			
			ds.Tables.Add(dt);
		}
		/*
				//		private void cmbSS_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				//		{
				//			if(e.KeyValue==13)
				//			{
				//				cmbSS.DroppedDown=false;
				//				if(isTab==true) 
				//				{
				//					isTab=false;
				//					SendKeys.Send("{tab}");
				//				}
				//				else isTab=true;
				//			}
				//			else isTab=false;	
				//		}
				//
				//		private void cmbSS_TextChanged(object sender, System.EventArgs e)
				//		{
				//			if(isDown) return;
				//			try
				//			{
				//				if(cmbSS.Text.Trim()=="")return;
				//				DataRow[] dr=myTb.Select("py_code like '"+cmbSS.Text.Trim()+"%'","py_code");				 
				//				cmbSS.Items.Clear();
				//				for(int j=0;j<dr.Length;j++)
				//				{
				//					cmbSS.Items.Add(dr[j]["NAME"]);
				//				}
				//				if( cmbSS.Items.Count>0 )
				//				{	
				//					cmbSS.SelectionStart=cmbSS.Text.Length;				
				//					cmbSS.DroppedDown=true;
				//				}
				//				else 
				//				{
				//					cmbSS.Select(cmbSS.Text.Trim().Length-1,1);	
				//					cmbSS.DroppedDown=false;
				//				}		
				//				
				//			}
				//			catch(System.Exception err)
				//			{
				//				err.ToString();				
				//			}			
				//		}
				//
				//		private void cmbSS_SelectionChangeCommitted(object sender, System.EventArgs e)
				//		{
				////			SendKeys.Send("{tab}");
				//		
				//		}
				//		public void ComboBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				//		{
				//			ComboBox cmb=(ComboBox)sender;
				//			int iSelectRow=-1;
				//			if(e.KeyValue>=32 && e.KeyValue<=127)
				//			{
				//				string strSelect=cmb.Text.Trim();
				//				if(strSelect=="")return;
				//				iSelectRow=cmb.FindString(strSelect);
				//				if(iSelectRow>=0)
				//				{
				//					cmb.SelectionStart=strSelect.Length;
				//					cmb.SelectionLength=cmb.Text.Length-strSelect.Length;
				//					cmb.DroppedDown=true;
				//				}
				//			}	
				//			if(e.KeyValue==13 && iSelectRow>=0)
				//			{
				//				cmb.SelectedIndex=iSelectRow;
				//				cmb.DroppedDown=false;
				//			}
				//		}
				//
				//		private void cmbSS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
				//		{
				//			if(e.KeyData==Keys.Down || e.KeyData==Keys.Up) isDown=true;
				//			else isDown=false;
				//			
				//		}
		*/
		private void ComboBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			cmb=(ComboBox)sender;
			bool respondKey=true;
			DataRow dr=null;
			if(cmb.Name=="cmbExplain") 
			{
				dr=WorkStaticFun.GetCardData(cmb,e.KeyValue,1,dGrid_Sel,0,ds,"explain",FilterType.����,SearchType.ǰ������,ref respondKey,"",false);			
			}
			else 
			{
                dr = WorkStaticFun.GetCardData(cmb, e.KeyValue, 1, dGrid_Sel, 1, ds, "ss", FilterType.����, SearchType.ǰ������, ref respondKey, "", false);			
			}
			
			if(dr!=null && respondKey)
			{
				if(gBoxExplain.Enabled==true)
				{
					default_usage=dr["CODE"].ToString().Trim();
				}	
				cmb.Text=dr["name"].ToString().Trim();		
			}		
			if(e.KeyValue==13) btOK.Focus();
		}
		private void cmbExplain_SelectedValueChanged(object sender, System.EventArgs e)
		{
			default_usage=cmbExplain.SelectedValue.ToString().Trim();		
		}

		private void dGrid_Sel_DoubleClick(object sender, System.EventArgs e)
		{
			cmb.Focus();
			ComboBox_KeyUp(cmb,new KeyEventArgs(Keys.Enter));		
		}

		private void dGrid_Sel_CurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid grid=(DataGrid)sender;
			for(int i=0;i<((DataTable)grid.DataSource).Rows.Count;i++)
			{
				grid.UnSelect(i);
			}
			grid.Select(grid.CurrentCell.RowNumber);
		}

		private void FrmExplain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData==Keys.Escape)
			{
				Explain="";
				this.Close();
			}
		}

        private void FrmExplain_Activated(object sender, EventArgs e)
        {
            cmbExplain.Focus();
        }
	}
}
