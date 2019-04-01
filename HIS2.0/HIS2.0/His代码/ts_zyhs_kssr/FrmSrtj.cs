using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_kssr
{
	/// <summary>
	/// Form2 ��ժҪ˵����
	/// </summary>
	public class FrmSrtj : System.Windows.Forms.Form
	{
		//�Զ������
		private BaseFunc myFunc;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpBeginDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker DtpEndDate;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btͳ��;
		private System.Windows.Forms.Button bt��ӡ;
		private System.Windows.Forms.Button bt�˳�;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbKind1;
		private System.Windows.Forms.RadioButton rbKind2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private TheReportDateSet rds=new TheReportDateSet();
		private DataRow dr;
		private System.Windows.Forms.RadioButton rbKind3;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSrtj(string _formText)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.Text=_formText;

			myFunc=new BaseFunc();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myDataGrid1 = new TrasenClasses.GeneralControls.DataGridEx();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbKind3 = new System.Windows.Forms.RadioButton();
            this.rbKind1 = new System.Windows.Forms.RadioButton();
            this.rbKind2 = new System.Windows.Forms.RadioButton();
            this.bt�˳� = new System.Windows.Forms.Button();
            this.bt��ӡ = new System.Windows.Forms.Button();
            this.btͳ�� = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 597);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myDataGrid1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 537);
            this.panel3.TabIndex = 2;
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.AllowSorting = false;
            this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
            this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
            this.myDataGrid1.CellSelectedBackColor = System.Drawing.Color.SkyBlue;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.ReadOnly = true;
            this.myDataGrid1.Size = new System.Drawing.Size(1008, 537);
            this.myDataGrid1.TabIndex = 4;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1008, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.bt�˳�);
            this.panel2.Controls.Add(this.bt��ӡ);
            this.panel2.Controls.Add(this.btͳ��);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 56);
            this.panel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rbKind3);
            this.groupBox3.Controls.Add(this.rbKind1);
            this.groupBox3.Controls.Add(this.rbKind2);
            this.groupBox3.Location = new System.Drawing.Point(352, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 48);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ͳ�Ʒ�Χ";
            // 
            // rbKind3
            // 
            this.rbKind3.Location = new System.Drawing.Point(280, 16);
            this.rbKind3.Name = "rbKind3";
            this.rbKind3.Size = new System.Drawing.Size(128, 24);
            this.rbKind3.TabIndex = 2;
            this.rbKind3.Text = "���������������";
            // 
            // rbKind1
            // 
            this.rbKind1.Checked = true;
            this.rbKind1.Location = new System.Drawing.Point(8, 16);
            this.rbKind1.Name = "rbKind1";
            this.rbKind1.Size = new System.Drawing.Size(136, 24);
            this.rbKind1.TabIndex = 1;
            this.rbKind1.TabStop = true;
            this.rbKind1.Text = "��ִ�еص���������";
            // 
            // rbKind2
            // 
            this.rbKind2.Location = new System.Drawing.Point(156, 16);
            this.rbKind2.Name = "rbKind2";
            this.rbKind2.Size = new System.Drawing.Size(112, 24);
            this.rbKind2.TabIndex = 0;
            this.rbKind2.Text = "��������������";
            // 
            // bt�˳�
            // 
            this.bt�˳�.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt�˳�.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt�˳�.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt�˳�.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt�˳�.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt�˳�.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt�˳�.ImageIndex = 4;
            this.bt�˳�.Location = new System.Drawing.Point(928, 16);
            this.bt�˳�.Name = "bt�˳�";
            this.bt�˳�.Size = new System.Drawing.Size(64, 24);
            this.bt�˳�.TabIndex = 52;
            this.bt�˳�.Text = "�˳�(&E)";
            this.bt�˳�.Click += new System.EventHandler(this.bt�˳�_Click);
            // 
            // bt��ӡ
            // 
            this.bt��ӡ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt��ӡ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt��ӡ.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt��ӡ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.bt��ӡ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt��ӡ.ImageIndex = 4;
            this.bt��ӡ.Location = new System.Drawing.Point(856, 16);
            this.bt��ӡ.Name = "bt��ӡ";
            this.bt��ӡ.Size = new System.Drawing.Size(64, 24);
            this.bt��ӡ.TabIndex = 51;
            this.bt��ӡ.Text = "��ӡ(&P)";
            this.bt��ӡ.Click += new System.EventHandler(this.bt��ӡ_Click);
            // 
            // btͳ��
            // 
            this.btͳ��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btͳ��.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btͳ��.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btͳ��.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btͳ��.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btͳ��.ImageIndex = 4;
            this.btͳ��.Location = new System.Drawing.Point(784, 16);
            this.btͳ��.Name = "btͳ��";
            this.btͳ��.Size = new System.Drawing.Size(64, 24);
            this.btͳ��.TabIndex = 50;
            this.btͳ��.Text = "ͳ��(&T)";
            this.btͳ��.Click += new System.EventHandler(this.btͳ��_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 4;
            this.button4.Location = new System.Drawing.Point(776, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 40);
            this.button4.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ͳ������";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = " �ӣ�";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "";
            this.dtpBeginDate.Location = new System.Drawing.Point(48, 16);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(112, 21);
            this.dtpBeginDate.TabIndex = 0;
            this.dtpBeginDate.Value = new System.DateTime(2003, 9, 27, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(168, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "����";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.Location = new System.Drawing.Point(208, 16);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(112, 21);
            this.DtpEndDate.TabIndex = 1;
            this.DtpEndDate.Value = new System.DateTime(2003, 9, 27, 23, 59, 0, 0);
            // 
            // FrmSrtj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1008, 597);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSrtj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����ͳ�Ʊ���";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSRTJ_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmSRTJ_Load(object sender, System.EventArgs e)
		{
			this.dtpBeginDate.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Year.ToString()+"-"+DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Month.ToString() +"-1 00:00:00");
			this.DtpEndDate.Value=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");

			string[] GrdMappingName1={"��������","��λ��","ҩƷ��","�����","���Ʒ�","�����","��Ѫ��","����","���Ʒ�","������","������","�Һŷ�","����","�����","������Ϸ�","�ϼ�"};
			int[]    GrdWidth1      ={12,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10};
			int[]    Alignment1     ={ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2};
			int[]	 ReadOnly1      ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
			myFunc.InitGrid(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid1);	
		}

		private void btͳ��_Click(object sender, System.EventArgs e)
		{
			string sSql="";
			if (this.DtpEndDate.Value<this.dtpBeginDate.Value)
			{
				MessageBox.Show(this,"�Բ��𣬽������ڲ���С�ڿ�ʼ���ڣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);										
				return;
			}

			this.dtpBeginDate.Value=Convert.ToDateTime(this.dtpBeginDate.Value.ToShortDateString()+" 00:00:00");
			this.DtpEndDate.Value=Convert.ToDateTime(this.DtpEndDate.Value.ToShortDateString() + " 23:59:59");
			string ss=InstanceForm.BCurrentDept.WardName+"���뱨��";
			ss+=this.rbKind1.Checked?"(��ִ�еص�ͳ��)":this.rbKind2.Checked?"(��������������ͳ��)":"(���������������)";			
			ss+="[���ڴӣ�"+this.dtpBeginDate.Value.Year.ToString()+"-"+this.dtpBeginDate.Value.Month.ToString()+"-"+this.dtpBeginDate.Value.Day.ToString()+" �� "+this.DtpEndDate.Value.Year.ToString()+"-"+this.DtpEndDate.Value.Month.ToString()+"-"+this.DtpEndDate.Value.Day.ToString()+"]";
			this.myDataGrid1.CaptionText=ss;

			Cursor.Current=PubStaticFun.WaitCursor(); 
			try
			{
//				OleDbConnection tempCon=new OleDbConnection();
//				tempCon.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Database Password=;Data Source=c:\winnt\db1.mdb;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
//				tempCon.Open();
//
//				OleDbCommand myCmd=new OleDbCommand();
//				myCmd.Connection=tempCon;
//
//				//���ԭ������
//				myCmd.CommandText="delete from FeeHZD";	
//				myCmd.ExecuteNonQuery();
				rds.Tables["BRFeeHZD"].Clear();

				int j=this.rbKind1.Checked?0:this.rbKind2.Checked?1:2;
//				int id=0;
				DataTable myTb=myFunc.GetFeeTotal("",j,InstanceForm.BCurrentDept.WardId,this.dtpBeginDate.Value,this.DtpEndDate.Value);
				
				if	(myTb.Rows.Count>=1)
				{			
					//������Ϣ����ʱ���ݿ�
					for(int i=0;i<=myTb.Rows.Count-1;i++)
					{
//						id+=1;
//						sSql=@"INSERT INTO FeeHZD(��������,��λ��,ҩƷ��,�����,���Ʒ�,�����,��Ѫ��,����,���Ʒ�,������,������,�Һŷ�,����,�����,������Ϸ�,�ϼ�,ID)									
//									VALUES(" +
//							"'" + myTb.Rows[i]["��������"].ToString()+"',"+							
//							Convert.ToDouble(myTb.Rows[i]["��λ��"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["ҩƷ��"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["�����"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["���Ʒ�"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["�����"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["��Ѫ��"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["����"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["���Ʒ�"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["������"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["������"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["�Һŷ�"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["����"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["�����"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["������Ϸ�"])+ "," +
//							Convert.ToDouble(myTb.Rows[i]["�ϼ�"])+ "," +
//							id.ToString()+")";						
//						myCmd.CommandText=sSql;
//						myCmd.ExecuteNonQuery();
						dr=rds.Tables["BRFeeHZD"].NewRow();
						dr["��������"]=myTb.Rows[i]["��������"].ToString();
						dr["��λ��"]=Convert.ToDouble(myTb.Rows[i]["��λ��"]);
						dr["ҩƷ��"]=Convert.ToDouble(myTb.Rows[i]["ҩƷ��"]);
						dr["�����"]=Convert.ToDouble(myTb.Rows[i]["�����"]);
						dr["���Ʒ�"]=Convert.ToDouble(myTb.Rows[i]["���Ʒ�"]);
						dr["�����"]=Convert.ToDouble(myTb.Rows[i]["�����"]);
						dr["��Ѫ��"]=Convert.ToDouble(myTb.Rows[i]["��Ѫ��"]);
						dr["����"]=Convert.ToDouble(myTb.Rows[i]["����"]);
						dr["���Ʒ�"]=Convert.ToDouble(myTb.Rows[i]["���Ʒ�"]);
						dr["������"]=Convert.ToDouble(myTb.Rows[i]["������"]);
						dr["������"]=Convert.ToDouble(myTb.Rows[i]["������"]);
						dr["�Һŷ�"]=Convert.ToDouble(myTb.Rows[i]["�Һŷ�"]);
						dr["����"]=Convert.ToDouble(myTb.Rows[i]["����"]);
						dr["�����"]=Convert.ToDouble(myTb.Rows[i]["�����"]);
						dr["������Ϸ�"]=Convert.ToDouble(myTb.Rows[i]["������Ϸ�"]);
						dr["�ϼ�"]=Convert.ToDouble(myTb.Rows[i]["�ϼ�"]);
						dr["ID"]=i.ToString();
						rds.Tables["BRFeeHZD"].Rows.Add(dr);
					}
				}
				
				if (myTb.Rows.Count>1)
				{
//					sSql="INSERT INTO FeeHZD (��������,��λ��,ҩƷ��,�����,���Ʒ�,�����,��Ѫ��,����,���Ʒ�,������,������,�Һŷ�,����,�����,������Ϸ�,�ϼ�,ID)"+
//						" select '�ܼ�', sum(��λ��),sum(ҩƷ��),sum(�����),sum(���Ʒ�),sum(�����),sum(��Ѫ��),sum(����),sum(���Ʒ�),"+
//						"                sum(������),sum(������),sum(�Һŷ�),sum(����),sum(�����),sum(������Ϸ�),sum(�ϼ�),99"+
//						"   from feehzd ";
//					myCmd.CommandText=sSql;
//					myCmd.ExecuteNonQuery();
					dr=rds.Tables["BRFeeHZD"].NewRow();
					dr["��������"]="�ܼ�";
					dr["��λ��"]=Convert.ToDouble(myTb.Compute("sum(��λ��)","1=1"));
					dr["ҩƷ��"]=Convert.ToDouble(myTb.Compute("sum(ҩƷ��)","1=1"));
					dr["�����"]=Convert.ToDouble(myTb.Compute("sum(�����)","1=1"));
					dr["���Ʒ�"]=Convert.ToDouble(myTb.Compute("sum(���Ʒ�)","1=1"));
					dr["�����"]=Convert.ToDouble(myTb.Compute("sum(�����)","1=1"));
					dr["��Ѫ��"]=Convert.ToDouble(myTb.Compute("sum(��Ѫ��)","1=1"));
					dr["����"]=Convert.ToDouble(myTb.Compute("sum(����)","1=1"));
					dr["���Ʒ�"]=Convert.ToDouble(myTb.Compute("sum(���Ʒ�)","1=1"));
					dr["������"]=Convert.ToDouble(myTb.Compute("sum(������)","1=1"));
					dr["������"]=Convert.ToDouble(myTb.Compute("sum(������)","1=1"));
					dr["�Һŷ�"]=Convert.ToDouble(myTb.Compute("sum(�Һŷ�)","1=1"));
					dr["����"]=Convert.ToDouble(myTb.Compute("sum(����)","1=1"));
					dr["�����"]=Convert.ToDouble(myTb.Compute("sum(�����)","1=1"));
					dr["������Ϸ�"]=Convert.ToDouble(myTb.Compute("sum(������Ϸ�)","1=1"));
					dr["�ϼ�"]=Convert.ToDouble(myTb.Compute("sum(�ϼ�)","1=1"));
					dr["ID"]=99;
					rds.Tables["BRFeeHZD"].Rows.Add(dr);
				}				

//				sSql="select * from feehzd";
//				DataTable myTempTb=new DataTable();
//				myTempTb=myOpenAss(tempCon,sSql);
				DataTable myTempTb=rds.Tables["BRFeeHZD"];
				this.myDataGrid1.DataSource=myTempTb;
				this.myDataGrid1.TableStyles[0].RowHeaderWidth=5;			
//				tempCon.Close(); //�ر���ʱ����
			}								
			catch(System.Data.OleDb.OleDbException err)
			{
				//�ر���ʱ����
				MessageBox.Show(err.ToString());
			}
			Cursor.Current=Cursors.Default;	
		}

		private void bt��ӡ_Click(object sender, System.EventArgs e)
		{
			DataTable prtTb = (DataTable)myDataGrid1.DataSource;

			if(prtTb==null || prtTb.Rows.Count==0) return;

			FrmReportView frmRptView=null;
			ParameterEx[] _parameters=new ParameterEx[2];

			_parameters[0].Text="��ͷ";
			_parameters[0].Value=this.myDataGrid1.CaptionText;
			_parameters[1].Text="��ӡ��";
			_parameters[1].Value="��ӡ�ߣ�"+ InstanceForm.BCurrentUser.Name;

			frmRptView=new FrmReportView(rds,Constant.ApplicationDirectory+"\\report\\ZYHS_�������뱨��.rpt",_parameters);
			frmRptView.Show();
		}

		private DataTable myOpenAss(OleDbConnection cCon,string sSql)
		{
			DataTable myTb=new DataTable();
			try
			{
				System.Data.OleDb.OleDbCommand mySelCmd=new OleDbCommand();
				mySelCmd.CommandText=sSql;			
				mySelCmd.Connection=cCon;
				mySelCmd.CommandType=System.Data.CommandType.Text ;
				System.Data.OleDb.OleDbDataAdapter myAdp=new OleDbDataAdapter();
				myAdp.SelectCommand=mySelCmd;
				myAdp.Fill(myTb);
			}
			catch(System.Data.OleDb.OleDbException err)
			{
				MessageBox.Show(err.ToString());
			}			
			return myTb;
		}

		private void bt�˳�_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
