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

namespace ts_zyhs_cwsx
{
	/// <summary>
	/// From1 ��ժҪ˵����
	/// </summary>
	public class frmCWSX : System.Windows.Forms.Form
	{
		private BaseFunc myFunc;

		private System.Windows.Forms.Panel panel1;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCWSX(string _formText)
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
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.myDataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(632, 477);
			this.panel1.TabIndex = 20;
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "������λһ����";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.RowHeadersVisible = false;
			this.myDataGrid1.Size = new System.Drawing.Size(632, 477);
			this.myDataGrid1.TabIndex = 20;
			this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle1});
			this.myDataGrid1.CurrentCellChanged += new System.EventHandler(this.myDataGrid1_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// frmCWSX
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(632, 477);
			this.Controls.Add(this.panel1);
			this.Name = "frmCWSX";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "��λ����";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmCWSX_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCWSX_Load(object sender, System.EventArgs e)
		{			
			string sSql;
			//Modify by Tany 2005-02-24
			//����ͣ�ñ�־
			sSql=@"select a.Room_no as ����,a.Bed_No as ����,dbo.FUN_ZY_SEEKDEPTNAME(a.dept_id) as ��������,"+
                "  dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zz_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.zy_doc) as ����ҽ��,dbo.FUN_ZY_SEEKEMPLOYEENAME(a.CHARGENURSE) as ����ʿ, "+
                "  h.order_name as �����˵�,"+
				"  i.inpatient_no as סԺ��,i.name as ����,a.bedsex as �Ա�,"+
				"  case when i.baby_id>0 then '��' else '' end as Ӥ����,"+
				"  i.cur_Dept_name as ������������, "+
				"  case a.isplus when 1 then '��'else ''end as �Ӵ���,"+
				"  case a.isbf when 1 then '��'else ''end as ������,"+
				"  case a.isMYTS when 1 then '��'else ''end as ĸӤͬ�ҷ�,"+
				"  case a.isinuse when 1 then '��'else ''end as �Ƿ�ͣ��"+
				"  from zy_BedDiction a left join jc_hoitemdiction h on h.order_id=a.hoitem_id"+
				"  left join vi_zy_vinpatient_bed i on a.inpatient_id=i.inpatient_id and a.baby_id=i.baby_id"+
				" where a.ward_id ='" + InstanceForm.BCurrentDept.WardId + "'" +
				" order by a.Room_no,a.Bed_No ";
			string[] GrdMappingName={"����","����","��������","����ҽ��","����ҽ��","����ʿ","�����˵�","סԺ��","����","�Ա�","Ӥ����","������������","�Ӵ���","������","ĸӤ��","�Ƿ�ͣ��"};
			int[]    GrdWidth      ={     4,     4,        14,        8,         8,          8,        18,       9,     8,     4,       6,            14,       6,       6,       6,        8};
			int[]    Alignment     ={     1,     1,         0,        0,         0,          0,         0,       0,     0,     1,       1,             0,       1,       1,       1,         1};
			myFunc.InitGridSQL(sSql,GrdMappingName,GrdWidth,Alignment,this.myDataGrid1);
			PubStaticFun.ModifyDataGridStyle(myDataGrid1,0);
			myFunc.SelRow(this.myDataGrid1);	
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			myFunc.SelRow(this.myDataGrid1);			
		}

	}
}
