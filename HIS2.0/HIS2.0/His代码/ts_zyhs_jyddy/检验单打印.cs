using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_jyddy
{
	/// <summary>
	/// ���鵥��ӡ ��ժҪ˵����
	/// </summary>
	public class frmJYDDY : System.Windows.Forms.Form
	{
		//�Զ������
		private BaseFunc myFunc;
		private int nType=0;
		private TheReportDateSet rds=new TheReportDateSet();

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button bt��ѡ1;
		private System.Windows.Forms.Button btȫѡ1;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private DataGridEx myDataGrid2;
		private System.Windows.Forms.Button bt��ѡ2;
		private System.Windows.Forms.Button btȫѡ2;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbBYX;
		private System.Windows.Forms.RadioButton rbYX;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmJYDDY(string _formText,int _type)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
			this.Text=_formText;
			nType=_type;
			
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
			this.bt��ѡ2 = new System.Windows.Forms.Button();
			this.btȫѡ2 = new System.Windows.Forms.Button();
			this.myDataGrid2 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbBYX = new System.Windows.Forms.RadioButton();
			this.rbYX = new System.Windows.Forms.RadioButton();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btCancel = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.bt��ѡ1 = new System.Windows.Forms.Button();
			this.btȫѡ1 = new System.Windows.Forms.Button();
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(200, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(592, 557);
			this.panel1.TabIndex = 71;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.bt��ѡ2);
			this.panel3.Controls.Add(this.btȫѡ2);
			this.panel3.Controls.Add(this.myDataGrid2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(592, 493);
			this.panel3.TabIndex = 1;
			// 
			// bt��ѡ2
			// 
			this.bt��ѡ2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt��ѡ2.BackColor = System.Drawing.Color.PaleGreen;
			this.bt��ѡ2.Location = new System.Drawing.Point(424, 2);
			this.bt��ѡ2.Name = "bt��ѡ2";
			this.bt��ѡ2.Size = new System.Drawing.Size(56, 20);
			this.bt��ѡ2.TabIndex = 91;
			this.bt��ѡ2.Text = "��ѡ(&U)";
			this.bt��ѡ2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt��ѡ2.Click += new System.EventHandler(this.bt��ѡ2_Click);
			// 
			// btȫѡ2
			// 
			this.btȫѡ2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btȫѡ2.BackColor = System.Drawing.Color.PaleGreen;
			this.btȫѡ2.Location = new System.Drawing.Point(360, 2);
			this.btȫѡ2.Name = "btȫѡ2";
			this.btȫѡ2.Size = new System.Drawing.Size(56, 20);
			this.btȫѡ2.TabIndex = 90;
			this.btȫѡ2.Text = "ȫѡ(&Q)";
			this.btȫѡ2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btȫѡ2.Click += new System.EventHandler(this.btȫѡ2_Click);
			// 
			// myDataGrid2
			// 
			this.myDataGrid2.AllowSorting = false;
			this.myDataGrid2.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid2.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid2.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid2.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid2.CaptionText = "ҽ���б�";
			this.myDataGrid2.DataMember = "";
			this.myDataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid2.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid2.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid2.Name = "myDataGrid2";
			this.myDataGrid2.ReadOnly = true;
			this.myDataGrid2.Size = new System.Drawing.Size(592, 493);
			this.myDataGrid2.TabIndex = 88;
			this.myDataGrid2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid2.Click += new System.EventHandler(this.myDataGrid2_Click);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid2;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.progressBar1);
			this.panel2.Controls.Add(this.btCancel);
			this.panel2.Controls.Add(this.btnPrint);
			this.panel2.Controls.Add(this.btnRefresh);
			this.panel2.Controls.Add(this.button3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 493);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(592, 64);
			this.panel2.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.rbBYX);
			this.groupBox3.Controls.Add(this.rbYX);
			this.groupBox3.Location = new System.Drawing.Point(144, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(208, 40);
			this.groupBox3.TabIndex = 76;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "ѡ���ӡ����";
			this.groupBox3.Visible = false;
			// 
			// rbBYX
			// 
			this.rbBYX.Location = new System.Drawing.Point(112, 16);
			this.rbBYX.Name = "rbBYX";
			this.rbBYX.Size = new System.Drawing.Size(88, 16);
			this.rbBYX.TabIndex = 2;
			this.rbBYX.Text = "ѡ��δ��ӡ";
			this.rbBYX.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// rbYX
			// 
			this.rbYX.Checked = true;
			this.rbYX.Location = new System.Drawing.Point(8, 16);
			this.rbYX.Name = "rbYX";
			this.rbYX.Size = new System.Drawing.Size(88, 16);
			this.rbYX.TabIndex = 1;
			this.rbYX.TabStop = true;
			this.rbYX.Text = "ѡ���Ѵ�ӡ";
			this.rbYX.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.progressBar1.Location = new System.Drawing.Point(0, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(592, 8);
			this.progressBar1.TabIndex = 75;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btCancel.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btCancel.ImageIndex = 0;
			this.btCancel.Location = new System.Drawing.Point(512, 20);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(64, 32);
			this.btCancel.TabIndex = 72;
			this.btCancel.Text = "�˳�(&E)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnPrint.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnPrint.ImageIndex = 0;
			this.btnPrint.Location = new System.Drawing.Point(440, 20);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(64, 32);
			this.btnPrint.TabIndex = 71;
			this.btnPrint.Text = "��ӡ(&P)";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnRefresh.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnRefresh.ImageIndex = 0;
			this.btnRefresh.Location = new System.Drawing.Point(368, 20);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(64, 32);
			this.btnRefresh.TabIndex = 74;
			this.btnRefresh.Text = "ˢ��(&R)";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.button3.Enabled = false;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button3.ImageIndex = 0;
			this.button3.Location = new System.Drawing.Point(360, 12);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(224, 47);
			this.button3.TabIndex = 73;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.bt��ѡ1);
			this.panel6.Controls.Add(this.btȫѡ1);
			this.panel6.Controls.Add(this.myDataGrid1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(200, 557);
			this.panel6.TabIndex = 73;
			// 
			// bt��ѡ1
			// 
			this.bt��ѡ1.BackColor = System.Drawing.Color.PaleGreen;
			this.bt��ѡ1.Location = new System.Drawing.Point(127, 2);
			this.bt��ѡ1.Name = "bt��ѡ1";
			this.bt��ѡ1.Size = new System.Drawing.Size(56, 20);
			this.bt��ѡ1.TabIndex = 88;
			this.bt��ѡ1.Text = "��ѡ(&F)";
			this.bt��ѡ1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bt��ѡ1.Click += new System.EventHandler(this.bt��ѡ1_Click);
			// 
			// btȫѡ1
			// 
			this.btȫѡ1.BackColor = System.Drawing.Color.PaleGreen;
			this.btȫѡ1.Location = new System.Drawing.Point(63, 2);
			this.btȫѡ1.Name = "btȫѡ1";
			this.btȫѡ1.Size = new System.Drawing.Size(56, 20);
			this.btȫѡ1.TabIndex = 87;
			this.btȫѡ1.Text = "ȫѡ(&A)";
			this.btȫѡ1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btȫѡ1.Click += new System.EventHandler(this.btȫѡ1_Click);
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "�����б�";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(200, 557);
			this.myDataGrid1.TabIndex = 89;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle3});
			this.myDataGrid1.Click += new System.EventHandler(this.myDataGrid1_Click);
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.panel1);
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(792, 557);
			this.panel4.TabIndex = 74;
			// 
			// frmJYDDY
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 557);
			this.Controls.Add(this.panel4);
			this.Name = "frmJYDDY";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���鵥��ӡ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmJydprt_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid2)).EndInit();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmJydprt_Load(object sender, System.EventArgs e)
		{
			string sSql="  SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,INPATIENT_ID,Baby_ID,DEPT_ID"+
				"    FROM vi_zy_vInpatient_Bed "+                         
				"   WHERE WARD_ID= '"+InstanceForm.BCurrentDept.WardId +"'order by BED_NO,baby_id";
			myFunc.ShowGrid(1,sSql,this.myDataGrid1);

			this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
			string[] GrdMappingName={"ѡ","����","סԺ��","����","INPATIENT_ID","Baby_ID","DEPT_ID"};
			int[]    GrdWidth      ={2,4,9,10,0,0,0};
			int[]    Alignment     ={0,0,0, 0,0,0,0};			
			int[]    ReadOnly      ={0,0,0, 0,0,0,0};
			myFunc.InitGrid(GrdMappingName,GrdWidth,Alignment,ReadOnly,this.myDataGrid1);

			this.bt��ѡ1_Click(sender,e);
		}

		private void btȫѡ1_Click(object sender, System.EventArgs e)
		{
			myFunc.SelectAll(0,this.myDataGrid1);
		}

		private void bt��ѡ1_Click(object sender, System.EventArgs e)
		{
			myFunc.SelectAll(1,this.myDataGrid1);
		}

		private void btȫѡ2_Click(object sender, System.EventArgs e)
		{
			myFunc.SelectAll(0,this.myDataGrid2);
		}

		private void bt��ѡ2_Click(object sender, System.EventArgs e)
		{
			myFunc.SelectAll(1,this.myDataGrid2);
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			myFunc.SelRow(this.myDataGrid1);
		}

		private void myDataGrid1_Click(object sender, System.EventArgs e)
		{
			myFunc.SelCol_Click(this.myDataGrid1);
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=(DataTable)this.myDataGrid1.DataSource;
			if(myTb==null) return;
			if (myTb.Rows.Count==0) return;		
			
			int iSelectRows=0;
			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (myTb.Rows[i]["ѡ"].ToString()=="True") iSelectRows+=1;							
			}
			if (iSelectRows==0)
			{
				MessageBox.Show(this,"�Բ���û��ѡ���ˣ�", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Warning);						
				return;
			}

			string sSql="";
			Cursor.Current=PubStaticFun.WaitCursor(); 
			this.progressBar1.Maximum=iSelectRows;
			this.progressBar1.Value=0;	
		
			DataTable GrdTb = new DataTable();
			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				sSql="";

				if (myTb.Rows[i]["ѡ"].ToString()=="True")
				{
					#region SQL����
					/*
					sSql=@"SELECT '"+myTb.Rows[i]["����"].ToString()+"' ����,'"+myTb.Rows[i]["סԺ��"].ToString()+"' סԺ��, "+
						" '"+myTb.Rows[i]["����"].ToString()+"' ����,b.order_id,b.inpatient_id,b.baby_id,hoitem_id,b.order_context ҽ������, "+
						" b.num ����,b.unit ��λ,b.order_usage �÷�, "+
						" applydept,todept,case todept when 1091 then '�����' when 1198 then 'ѪҺ��' end ִ�п���,lis_group �������, "+
						" group_code,room_code,cls_code,mach_code,samp_code,assay_type,zy_group_name ��������,fjsm ����˵�� FROM ( "+
						" SELECT * FROM yj_applyrecord "+
                        " WHERE isarrange = 0 AND cancel_bit = 0 AND applycode IS NOT NULL "+
                        " and todept in (1091,1198) AND inpatientid="+myTb.Rows[i]["INPATIENT_ID"].ToString()+" ) a "+
						" INNER JOIN ( "+
						" select * from zy_orderrecord "+
						" where inpatient_id="+myTb.Rows[i]["INPATIENT_ID"].ToString()+
						" and baby_id="+myTb.Rows[i]["Baby_ID"].ToString()+" and dept_id not in ( "+
						" select deptid from ss_dept)) b "+
						" ON a.orderid = b.order_id "+
						" left join LS_AS_GROUP c "+
						" on char(b.hoitem_id)=c.zy_group_code "+
						" left join zy_jy_print d on b.order_id=d.order_id "+
						" order by lis_group,room_code,cls_code,mach_code,samp_code,assay_type"; 
					*/
					#endregion

					sSql="exec SP_ZYHS_JYDCQ "+myTb.Rows[i]["INPATIENT_ID"].ToString()+","+myTb.Rows[i]["Baby_ID"].ToString();

					DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql);

					if(GrdTb==null || GrdTb.Rows.Count==0)
					{
						GrdTb=tmpTb.Clone();
						GrdTb.Columns["lis_txm"].DataType=System.Type.GetType("System.Int64");
					}

					if(tmpTb.Rows.Count==0 || tmpTb==null)
					{
						this.progressBar1.Value+=1;
						continue;
					}

					for(int j=0;j<tmpTb.Rows.Count;j++)
					{
						GrdTb.Rows.Add(tmpTb.Rows[j].ItemArray);
					}
						
					this.progressBar1.Value+=1;
				}
			}

			DataColumn col=new DataColumn();
			col.DataType=System.Type.GetType("System.Boolean");			 
			col.AllowDBNull=false;
			col.ColumnName="ѡ";
			col.DefaultValue=false;
			GrdTb.Columns.Add(col);
			
			DataTable myTb1=GrdTb;
			this.myDataGrid2.DataSource=myTb1;				
				
			string[] GrdMappingName1={"ѡ","����","סԺ��","����","order_id","inpatient_id","baby_id","hoitem_id",
									  "ҽ������","����","��λ","�÷�","applydept","todept","ִ�п���","�������",
				                      "group_code","room_code","cls_code","mach_code","samp_code","assay_type",
									  "��������","����˵��","age","sexcode","lis_txm","apply_id","�۸�","applydate","applydoc"
								     };
			int[]    GrdWidth1      ={2,4,9,8,0,0,0,0,
									  24,4,4,12,0,0,10,6,
									  0,0,0,0,0,0,
									  10,10,0,0,0,0,6,0,0};
			int[]    Alignment1     ={0,0,0,0,0,0,0,0,
								      0,0,1,0,0,0,0,0,
									  0,0,0,0,0,0,
									  0,0,0,0,0,0,0,0,0};
			int[]    ReadOnly1      ={0,0,0,0,0,0,0,0,
									  0,0,0,0,0,0,0,0,
									  0,0,0,0,0,0,
									  0,0,0,0,0,0,0,0,0};
			
			this.InitGridYZ(GrdMappingName1,GrdWidth1,Alignment1,ReadOnly1,this.myDataGrid2);
			myDataGrid2.TableStyles[0].RowHeaderWidth=5;
			
//			this.bt��ѡ2_Click(sender,e);
			this.progressBar1.Value=0;
			Cursor.Current=Cursors.Default;
		}

		private void InitGridYZ(string[] GrdMappingName,int[] GrdWidth,int[] Alignment,int[] ReadOnly,DataGridEx myDataGrid)
		{
			myDataGrid.TableStyles[0].GridColumnStyles.Clear();
			myDataGrid.TableStyles[0].AllowSorting=false; //����������

			DataGridEnableTextBoxColumn aColumnTextColumn ;
			for(int i=0; i<=GrdMappingName.Length-1; i++)
			{
				if (GrdMappingName[i].ToString().Trim()=="ѡ")
				{
					DataGridEnableBoolColumn myBoolCol=new DataGridEnableBoolColumn(i);
					myBoolCol.CheckCellEnabled  += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);						
					myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol); 
					myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName=GrdMappingName[i].ToString();
					myDataGrid.TableStyles[0].GridColumnStyles[i].Width=GrdWidth[i]==0?0:(GrdWidth[i]*7+2);				
				}
				else
				{
					aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
					aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
					myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
					myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName=GrdMappingName[i].ToString();
					myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText=GrdMappingName[i].ToString().Trim();
					myFunc.InitGrid_Sub(i,GrdMappingName,GrdWidth,Alignment,myDataGrid);
					if (ReadOnly[i]!=0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly=true;	
				}
			}			
		}

		private void SetEnableValues(object sender,DataGridEnableEventArgs e)
		{
			//��ɫ������ҽ����״̬ 
			int ColorCol=15;		 //�������
			if (Convert.ToInt16(this.myDataGrid2[e.Row,ColorCol]) >= 0 )
			{
				//�Ѵ�ӡ
				e.ForeColor = Color.Blue;
			}
			if (Convert.ToInt16(this.myDataGrid2[e.Row,ColorCol]) < 0)   
			{
				//û��ӡ
				e.ForeColor = Color.Black;
			}

			//ѡ����
			if (this.myDataGrid2[e.Row,0].ToString() == "True")
			{
				e.BackColor=Color.GreenYellow;
			}
			else
			{
				e.BackColor=Color.White;
			}
		}

		private void myDataGrid2_Click(object sender, System.EventArgs e)
		{
			//����BOOL��
			int nrow,ncol;
			nrow=this.myDataGrid2.CurrentCell.RowNumber;
			ncol=this.myDataGrid2.CurrentCell.ColumnNumber;
			
			//�ύ��������
			if(ncol>0 && nrow>0)this.myDataGrid2.CurrentCell=new DataGridCell(nrow,ncol-1);
			this.myDataGrid2.CurrentCell=new DataGridCell(nrow,ncol);

			DataTable myTb=((DataTable)this.myDataGrid2.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;

			//��"ѡ"�ֶ�
			if (this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim()!="ѡ") return;
			if (nrow>myTb.Rows.Count-1) return;
			
			bool isResult=myTb.Rows[nrow]["ѡ"].ToString()=="True"?false:true;
			myTb.Rows[nrow]["ѡ"]=isResult;		
            
			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				if (   myTb.Rows[i]["room_code"].ToString().Trim()==myTb.Rows[nrow]["room_code"].ToString().Trim()
					&& myTb.Rows[i]["room_code"].ToString().Trim()!=""
					&& myTb.Rows[i]["room_code"].ToString().Trim()!="-1"
					&& myTb.Rows[i]["cls_code"].ToString().Trim()==myTb.Rows[nrow]["cls_code"].ToString().Trim()
					&& myTb.Rows[i]["cls_code"].ToString().Trim()!=""
					&& myTb.Rows[i]["cls_code"].ToString().Trim()!="-1"
					&& myTb.Rows[i]["mach_code"].ToString().Trim()==myTb.Rows[nrow]["mach_code"].ToString().Trim()
					&& myTb.Rows[i]["mach_code"].ToString().Trim()!=""
					&& myTb.Rows[i]["mach_code"].ToString().Trim()!="-1"
					&& myTb.Rows[i]["samp_code"].ToString().Trim()==myTb.Rows[nrow]["samp_code"].ToString().Trim()
					&& myTb.Rows[i]["samp_code"].ToString().Trim()!=""
					&& myTb.Rows[i]["samp_code"].ToString().Trim()!="-1"
					&& myTb.Rows[i]["assay_type"].ToString().Trim()==myTb.Rows[nrow]["assay_type"].ToString().Trim()
					&& myTb.Rows[i]["assay_type"].ToString().Trim()!=""
					&& myTb.Rows[i]["assay_type"].ToString().Trim()!="-1"
					&& myTb.Rows[i]["����˵��"].ToString().Trim()==myTb.Rows[nrow]["����˵��"].ToString().Trim()
					&& myTb.Rows[i]["Inpatient_id"].ToString().Trim()==myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
					&& myTb.Rows[i]["Baby_id"].ToString().Trim()==myTb.Rows[nrow]["Baby_id"].ToString().Trim()
					&& myTb.Rows[i]["ѡ"].ToString()!=isResult.ToString() )
				{
					this.myDataGrid2.CurrentCell=new DataGridCell(i,ncol);
					myTb.Rows[i]["ѡ"]=isResult;
				}
			}

			this.myDataGrid2.DataSource=myTb;
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			DataTable myTb=((DataTable)this.myDataGrid2.DataSource);
			if(myTb == null) return;
			if(myTb.Rows.Count<=0)return;
			
			int iSelectRows=0,m=0,n=0;
			
			//�ж��Ƿ���ѡ�񣬲��������ʱ�������ֶ�
			for(int i=0;i<=myTb.Rows.Count-1;i++)
			{
				myTb.Rows[i]["lis_txm"]=-1;
				if (myTb.Rows[i]["ѡ"].ToString()=="True") iSelectRows+=1;							
			}
			if (iSelectRows==0)
			{
				MessageBox.Show(this,"�Բ���û��ѡ����Ҫ��ӡ�ļ�¼��", "��ʾ", MessageBoxButtons.OK,MessageBoxIcon.Information);						
				return;
			}
            
			Cursor.Current=PubStaticFun.WaitCursor();

			//������
			long _txm=Convert.ToInt64(InstanceForm.BDatabase.GetDataResult("select convert(varchar,getdate(),112)").ToString().Trim()+"001");
			//�����������Ϣ
			DataTable txmTb=new DataTable();
			txmTb.Columns.Add("txm",System.Type.GetType("System.Int64"));
			//�ж��Ƿ��г������Ϣ
			this.progressBar1.Maximum=myTb.Rows.Count;
			this.progressBar1.Value=0;

			for(m=0;m<=myTb.Rows.Count-1;m++)
			{
				if(myTb.Rows[m]["ѡ"].ToString()=="True")
				{
					//�ȵ�һ��ʱ���+��ŵ�������
					_txm=_txm+m;
					//���m�������һ��
					if(m!=myTb.Rows.Count-1)
					{
						//�����ǰ��û�������룬��д��
						if(Convert.ToInt64(myTb.Rows[m]["lis_txm"])==-1)
						{
							myTb.Rows[m]["lis_txm"]=_txm;
							DataRow txmRow=txmTb.NewRow();
							txmRow[0]=_txm;
							txmTb.Rows.Add(txmRow);
							//�������ж���û����ͬ���͵ģ�д����ͬ������
							for(n=m+1;n<=myTb.Rows.Count-1;n++)
							{
								if(myTb.Rows[n]["ѡ"].ToString()=="True")
								{
									if (   myTb.Rows[m]["room_code"].ToString().Trim()==myTb.Rows[n]["room_code"].ToString().Trim()
										&& myTb.Rows[m]["room_code"].ToString().Trim()!=""
										&& myTb.Rows[m]["room_code"].ToString().Trim()!="-1"
										&& myTb.Rows[m]["cls_code"].ToString().Trim()==myTb.Rows[n]["cls_code"].ToString().Trim()
										&& myTb.Rows[m]["cls_code"].ToString().Trim()!=""
										&& myTb.Rows[m]["cls_code"].ToString().Trim()!="-1"
										&& myTb.Rows[m]["mach_code"].ToString().Trim()==myTb.Rows[n]["mach_code"].ToString().Trim()
										&& myTb.Rows[m]["mach_code"].ToString().Trim()!=""
										&& myTb.Rows[m]["mach_code"].ToString().Trim()!="-1"
										&& myTb.Rows[m]["samp_code"].ToString().Trim()==myTb.Rows[n]["samp_code"].ToString().Trim()
										&& myTb.Rows[m]["samp_code"].ToString().Trim()!=""
										&& myTb.Rows[m]["samp_code"].ToString().Trim()!="-1"
										&& myTb.Rows[m]["assay_type"].ToString().Trim()==myTb.Rows[n]["assay_type"].ToString().Trim()
										&& myTb.Rows[m]["assay_type"].ToString().Trim()!=""
										&& myTb.Rows[m]["assay_type"].ToString().Trim()!="-1"
										&& myTb.Rows[m]["����˵��"].ToString().Trim()==myTb.Rows[n]["����˵��"].ToString().Trim()
										&& myTb.Rows[m]["Inpatient_id"].ToString().Trim()==myTb.Rows[n]["Inpatient_id"].ToString().Trim()
										&& myTb.Rows[m]["Baby_id"].ToString().Trim()==myTb.Rows[n]["Baby_id"].ToString().Trim())
									{
										myTb.Rows[n]["lis_txm"]=_txm;
									}
								}
							}
						}
					}
					else
					{
						//��������һ�в��ҵ�ǰ��û�������룬��д��
						if(Convert.ToInt64(myTb.Rows[m]["lis_txm"])==-1)
						{
							myTb.Rows[m]["lis_txm"]=_txm;
							DataRow txmRow=txmTb.NewRow();
							txmRow[0]=_txm;
							txmTb.Rows.Add(txmRow);
						}
					}
				}
				this.progressBar1.Value+=1;
			}
			
			string sSql="";
			string _msg="";
			bool _isOld=false;//�ж��Ƿ�����ԭ������ţ�����ǵģ�����ԭ������Ϣ����ӡ���������ݿ⣩������������ݣ������û����Ϲ�������������ӡ
			try
			{
				this.progressBar1.Maximum=txmTb.Rows.Count;
				this.progressBar1.Value=0;

				//ѭ�������룬���ɲ����¼
				for(int i=0;i<=txmTb.Rows.Count-1;i++)
				{
					DataRow[] tmpRowM=myTb.Select("lis_txm="+txmTb.Rows[i]["txm"].ToString().Trim());
					DataTable tmpTb=myTb.Clone();
					foreach(DataRow dr in tmpRowM)
					{
						tmpTb.Rows.Add(dr.ItemArray);
					}
					long _lisGroup=Convert.ToInt64(tmpTb.Rows[0]["�������"]);
					long _OldLisGroup=-1;//������µ���Ŀ���룬ԭ����TXM��ϵҪ�����
					//ѭ�������Ƿ��в�ͬ��¼
					for(int j=0;j<=tmpTb.Rows.Count-1;j++)
					{
						//���������Ų�ͬ��˵�����µĿ��Ժϲ�����Ŀ���룬���¼����ʾ��ʿ
						if(Convert.ToInt64(tmpTb.Rows[j]["�������"])!=_lisGroup)
						{
							_msg+="��  "+tmpTb.Rows[j]["����"].ToString().Trim()+"  �� ����  "+tmpTb.Rows[j]["����"].ToString().Trim()+"  ��\n";
							for(int jj=0;jj<=tmpTb.Rows.Count-1;jj++)
							{
								if(Convert.ToInt64(tmpTb.Rows[jj]["�������"])>-1)
								{
									_OldLisGroup=Convert.ToInt64(tmpTb.Rows[jj]["�������"]);
								}
								_msg+="  ������ţ�"+tmpTb.Rows[jj]["�������"].ToString().Trim()+"   "+tmpTb.Rows[jj]["ҽ������"].ToString().Trim()+"\n";
							}
							//���������Ŀ����
							_isOld=false;
							//ֻҪ�ҵ�һ���Ϳ��Բ���������
							break;
						}
						else//��������ͬ
						{
							//�����Ų�����-1��˵�����ϵ�����
							if(Convert.ToInt64(tmpTb.Rows[j]["�������"])!=-1)
							{
								_isOld=true;
							}
							else
							{
								_isOld=false;
							}
						}
					}
					//�����Ҫ�����ϵ

					if(!_isOld && _OldLisGroup>-1)
					{
						sSql="select conf from ls_as_txm where delete_bit=0 and id="+_OldLisGroup;
						if(InstanceForm.BDatabase.GetDataResult(sSql).ToString().Trim()!="F")
						{
							MessageBox.Show("ϵͳ��⵽�������Ѿ������»�ȷ�ϣ�ҳ�潫�Զ�ˢ�£�������ѡ����Ŀ����ӡ��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
							btnRefresh_Click(null,null);
							return;
						}
						else
						{
							sSql="update ls_as_txm set delete_bit=1 where delete_bit=0 and conf='F' and chk_flag='F' and id="+_OldLisGroup;
							InstanceForm.BDatabase.DoCommand(sSql);
						}
					}

					//�����Ҫ�����µ�txm��ϵ
					if(!_isOld)
					{
						string _groupname="",_groupcode="",_applyid="";
						string _NewLisGroup="";
						float _price=0;
						for(int j=0;j<=tmpTb.Rows.Count-1;j++)
						{
							_groupname+=tmpTb.Rows[j]["��������"].ToString().Trim();
							if(j!=tmpTb.Rows.Count-1)
							{
								_groupname+=",";
							}
							_groupcode+=tmpTb.Rows[j]["group_code"].ToString().Trim();
							if(j!=tmpTb.Rows.Count-1)
							{
								_groupcode+=",";
							}
							_applyid+=tmpTb.Rows[j]["apply_id"].ToString().Trim();
							if(j!=tmpTb.Rows.Count-1)
							{
								_applyid+=",";
							}
							_price+=Convert.ToSingle(tmpTb.Rows[j]["�۸�"]);
						}

						InstanceForm.BDatabase.BeginTransaction();
						try
						{
							//����LIS������
							sSql=@"insert into LS_AS_TXM(TXM_NO, GROUP_NAME, GROUP_CODE, SAMP_NO, REG_NO, NAME, SEX, AGE, "+
								" DEPT_CODE, BED_CODE, TYPE, ASSAY_TYPE, ROOM_CODE, MACH_CODE, SAMP_CODE, "+
								" DIAG_NAME, REQ_DR, REQ_DATE, CHK_FLAG, CONF, FY, DELETE_BIT, PRINT_DEGREE) "+
								" values("+tmpTb.Rows[0]["lis_txm"].ToString()+",'"+tmpTb.Rows[0]["����˵��"].ToString().Trim()+" "+_groupname+"',0,0,'"+tmpTb.Rows[0]["סԺ��"].ToString()+"',"+
								" '"+tmpTb.Rows[0]["����"].ToString()+"','"+tmpTb.Rows[0]["sexcode"].ToString()+"',"+tmpTb.Rows[0]["age"].ToString()+","+
								" '"+tmpTb.Rows[0]["applydept"].ToString()+"','"+tmpTb.Rows[0]["����"].ToString()+"','','"+tmpTb.Rows[0]["assay_type"].ToString()+"',"+
								" "+tmpTb.Rows[0]["room_code"].ToString()+","+tmpTb.Rows[0]["mach_code"].ToString()+","+tmpTb.Rows[0]["samp_code"].ToString()+","+
								" '','"+InstanceForm.BCurrentUser.EmployeeId+"','"+DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Date+"','F','F',"+_price+",0,0)";
							InstanceForm.BDatabase.DoCommand(sSql);

							sSql="select IDENT_CURRENT('LS_AS_TXM') as id";
							_NewLisGroup=InstanceForm.BDatabase.GetDataResult(sSql).ToString();

							InstanceForm.BDatabase.CommitTransaction();
						}
						catch(Exception err)
						{
							InstanceForm.BDatabase.RollbackTransaction();
							throw new Exception(err.Message);
						}
//						finally
//						{
//							database.Close();
//						}

						//����ZY������
						sSql=@"update yj_applyrecord set lis_group="+_NewLisGroup+" where id in ("+_applyid+")";
						InstanceForm.BDatabase.DoCommand(sSql);

						//��������������
						for(int k=0;k<=myTb.Rows.Count-1;k++)
						{
							if(myTb.Rows[k]["ѡ"].ToString()=="True")
							{
								if(myTb.Rows[k]["lis_txm"].ToString().Trim()==txmTb.Rows[i]["txm"].ToString().Trim())
								{
									myTb.Rows[k]["�������"]=_NewLisGroup;
								}
							}
						}
					}
					this.progressBar1.Value+=1;
				}
				if(_msg.Trim()!="")
				{
					MessageBox.Show("ϵͳ��⵽���в��˵���Ŀ��Ҫ������ϣ�ԭ���ĵ����Ѿ����ϣ�\n\n"+_msg,"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}

				//��ʼ��ӡ����
				this.progressBar1.Maximum=myTb.Rows.Count;
				this.progressBar1.Value=0;

				rds.tabJYSQD.Clear();
				string tmpSql="";
				for(int k=0;k<=myTb.Rows.Count-1;k++)
				{
					//ѡ���˵����ݲ��ҵ������ǵ�һ�е�ʱ�򣬼�����Ų��ܺ���һ����ͬ
					if(myTb.Rows[k]["ѡ"].ToString()=="True")
					{
						if(k==0 || (k!=0 && myTb.Rows[k]["�������"].ToString()!=myTb.Rows[k-1]["�������"].ToString()))
						{
							tmpSql="select a.id,a.txm_no,case a.sex when '1' then '��' else 'Ů' end sex, "+
								" a.age,b.samp_name,a.group_name,a.fy "+
								" from ls_as_txm a left join ls_as_sample b on a.samp_code=b.samp_code "+
								" where a.delete_bit=0 and a.id="+myTb.Rows[k]["�������"].ToString();
							DataTable tmpTb=new DataTable();//=InstanceForm.BDatabase.GetDataTable(DatabaseType.IbmDb2LIS,tmpSql);��һ��������Ϊû��lis���� Modify By Tany 2006-12-04

							if(tmpTb.Rows.Count>0)
							{
								DataRow dr=rds.tabJYSQD.NewRow();
								dr["���"]=tmpTb.Rows[0]["id"].ToString();
								dr["������"]="*"+tmpTb.Rows[0]["txm_no"].ToString().Trim()+"*";
								dr["סԺ��"]=myTb.Rows[k]["סԺ��"].ToString();
								dr["����"]=myTb.Rows[k]["����"].ToString();
								dr["�Ա�"]=tmpTb.Rows[0]["sex"].ToString();
								dr["����"]=tmpTb.Rows[0]["age"].ToString();
								dr["����"]=myTb.Rows[k]["applydept"].ToString();
								dr["����"]=InstanceForm.BCurrentDept.WardName;
								dr["����"]=myTb.Rows[k]["����"].ToString();
								dr["�걾"]=tmpTb.Rows[0]["samp_name"].ToString();
								dr["��Ŀ����"]=tmpTb.Rows[0]["group_name"].ToString();
								dr["����ҽ��"]=myTb.Rows[k]["applydoc"].ToString();
								dr["��������"]=Convert.ToDateTime(myTb.Rows[k]["applydate"]).Date;
								dr["�۸�"]=tmpTb.Rows[0]["fy"].ToString();

								rds.tabJYSQD.Rows.Add(dr);
							}
						}
					}
					this.progressBar1.Value+=1;
				}

				FrmReportView frmRptView=null;
				ParameterEx[] _parameters=new ParameterEx[2];

				_parameters[0].Text="ҽԺ����";
				_parameters[0].Value=(new SystemCfg(0002)).Config;
				_parameters[1].Text="��ӡ��";
				_parameters[1].Value=InstanceForm.BCurrentUser.Name;

				frmRptView=new FrmReportView(rds,Constant.ApplicationDirectory+"\\report\\ZYHS_�������뵥.rpt",_parameters);
				frmRptView.Show();
			}
			catch(Exception err)
			{
				MessageBox.Show("����"+err.Message+"\n"+"Source��"+err.Source,"����",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			finally
			{
				btnRefresh_Click(null,null);
				Cursor.Current=Cursors.Default;
			}
		}
	}
}
