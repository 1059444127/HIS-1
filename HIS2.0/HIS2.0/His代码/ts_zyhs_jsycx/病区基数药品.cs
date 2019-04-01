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

namespace ts_zyhs_jsycx
{
	/// <summary>
	/// Form2 ��ժҪ˵����
	/// </summary>
	public class frmJSYCX : System.Windows.Forms.Form
	{
		//�Զ������
		private BaseFunc myFunc;

		private System.Windows.Forms.Panel panel1;
		private DataGridEx myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.RadioButton rb����;
		private System.Windows.Forms.RadioButton rbɾ��;
		private System.Windows.Forms.RadioButton rb����;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmJSYCX(string _formText)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//

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
			this.rb���� = new System.Windows.Forms.RadioButton();
			this.rbɾ�� = new System.Windows.Forms.RadioButton();
			this.rb���� = new System.Windows.Forms.RadioButton();
			this.myDataGrid1 = new DataGridEx();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rb����);
			this.panel1.Controls.Add(this.rbɾ��);
			this.panel1.Controls.Add(this.rb����);
			this.panel1.Controls.Add(this.myDataGrid1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(544, 389);
			this.panel1.TabIndex = 0;
			// 
			// rb����
			// 
			this.rb����.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb����.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rb����.Location = new System.Drawing.Point(322, 3);
			this.rb����.Name = "rb����";
			this.rb����.Size = new System.Drawing.Size(48, 18);
			this.rb����.TabIndex = 90;
			this.rb����.Text = "����";
			this.rb����.Click += new System.EventHandler(this.frmJSYCX_Load);
			// 
			// rbɾ��
			// 
			this.rbɾ��.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rbɾ��.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rbɾ��.Location = new System.Drawing.Point(376, 3);
			this.rbɾ��.Name = "rbɾ��";
			this.rbɾ��.Size = new System.Drawing.Size(64, 18);
			this.rbɾ��.TabIndex = 88;
			this.rbɾ��.Text = "��ɾ��";
			this.rbɾ��.Click += new System.EventHandler(this.frmJSYCX_Load);
			// 
			// rb����
			// 
			this.rb����.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rb����.BackColor = System.Drawing.Color.PaleTurquoise;
			this.rb����.Checked = true;
			this.rb����.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rb����.Location = new System.Drawing.Point(442, 3);
			this.rb����.Name = "rb����";
			this.rb����.Size = new System.Drawing.Size(72, 18);
			this.rb����.TabIndex = 89;
			this.rb����.TabStop = true;
			this.rb����.Text = "����";
			this.rb����.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rb����.Click += new System.EventHandler(this.frmJSYCX_Load);
			// 
			// myDataGrid1
			// 
			this.myDataGrid1.AllowSorting = false;
			this.myDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.myDataGrid1.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.myDataGrid1.CaptionFont = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.myDataGrid1.CaptionForeColor = System.Drawing.SystemColors.HotTrack;
			this.myDataGrid1.CaptionText = "���һ���ҩƷ";
			this.myDataGrid1.DataMember = "";
			this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myDataGrid1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDataGrid1.Location = new System.Drawing.Point(0, 0);
			this.myDataGrid1.Name = "myDataGrid1";
			this.myDataGrid1.ReadOnly = true;
			this.myDataGrid1.Size = new System.Drawing.Size(544, 389);
			this.myDataGrid1.TabIndex = 5;
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
			// frmJSYCX
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(544, 389);
			this.Controls.Add(this.panel1);
			this.Name = "frmJSYCX";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���һ���ҩƷ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmJSYCX_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmJSYCX_Load(object sender, System.EventArgs e)
		{
			string sTj="";
			if(rb����.Checked)
				sTj=" and a.delete_bit=0 ";
			else if(rbɾ��.Checked)
				sTj=" and a.delete_bit=1 ";
			else
				sTj="";
			string sSql="select dbo.FUN_ZY_SEEKDEPTNAME(a.DEPT_ID) ����,a.item_code ���,b.S_SPM ����,b.S_GG ���,c.kcl ���,b.s_dw ��λ,"+
				        "dbo.FUN_ZY_SEEKEmployeeName(a.BOOK_USER) ������,BOOK_DATE ��������,dbo.FUN_ZY_SEEKEmployeeName(DELETE_USER) ɾ����,DELETE_DATE ɾ������"+
						"  FROM jc_deptmed A,"+
                        "      (SELECT S_SPM,S_GG,S_HH,S_DW FROM YK_XYD UNION SELECT S_SPM,S_GG,S_HH ,S_DW FROM YK_CYD ) AS B"+
				        "      inner join(select s_hh,sum(n_kcl) kcl from mzyf_kcmx where deptid in (42,43,44) group by s_hh) AS C on b.s_hh=c.s_hh "+
				        "  where A.DEPT_ID in (select dept_id from jc_wardrdept where ward_id='"+InstanceForm.BCurrentDept.WardId+"')"+
                        "       and a.item_code=b.s_hh "+sTj+
				        " group by a.DEPT_ID,a.item_code,b.S_SPM,b.S_GG,c.kcl,b.s_dw,BOOK_USER,BOOK_DATE,DELETE_USER,DELETE_DATE";
			string[] GrdMappingName={"����","���","����","���","���","��λ","������","��������","ɾ����","ɾ������"};
			int[]    GrdWidth      ={10,8,28,12,8,6,8,10,8,10};
			int[]    Alignment     ={ 0,0, 0,0, 1,1,0, 0,0, 0};	
			myFunc.InitGridSQL(sSql,GrdMappingName,GrdWidth,Alignment,this.myDataGrid1);
		}

		private void myDataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			myFunc.SelRow(this.myDataGrid1);
		}
	}
}
