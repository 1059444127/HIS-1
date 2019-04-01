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
	public class Frmconfig : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Button butsave;
		private System.Windows.Forms.Button butquit;
        private ComboBox cmbyjks;
        private Label label1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmconfig(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 494);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(888, 31);
            this.statusBar1.TabIndex = 0;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 200;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbyjks);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.butquit);
            this.groupBox2.Controls.Add(this.butsave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 82);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "����";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(175, 26);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(149, 23);
            this.cmbyjks.TabIndex = 9;
            this.cmbyjks.SelectedIndexChanged += new System.EventHandler(this.cmbyjks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(100, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "ҩ������";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(864, 21);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(139, 51);
            this.butquit.TabIndex = 1;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butsave
            // 
            this.butsave.Location = new System.Drawing.Point(704, 21);
            this.butsave.Name = "butsave";
            this.butsave.Size = new System.Drawing.Size(139, 51);
            this.butsave.TabIndex = 0;
            this.butsave.Text = "����(&S)";
            this.butsave.Click += new System.EventHandler(this.butsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myDataGrid1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 412);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "�����б�";
            // 
            // myDataGrid1
            // 
            this.myDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGrid1.CaptionVisible = false;
            this.myDataGrid1.DataMember = "";
            this.myDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.myDataGrid1.Location = new System.Drawing.Point(3, 21);
            this.myDataGrid1.Name = "myDataGrid1";
            this.myDataGrid1.Size = new System.Drawing.Size(882, 388);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn2,
            this.dataGridBoolColumn1,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "��������";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "��������";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.AllowNull = false;
            this.dataGridBoolColumn1.FalseValue = ((short)(0));
            this.dataGridBoolColumn1.HeaderText = "����ֵ";
            this.dataGridBoolColumn1.NullText = "0";
            this.dataGridBoolColumn1.NullValue = ((short)(0));
            this.dataGridBoolColumn1.TrueValue = ((short)(1));
            this.dataGridBoolColumn1.Width = 50;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "��������";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 200;
            // 
            // Frmconfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(888, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Name = "Frmconfig";
            this.Text = "��������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmyfkpz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Frmyfkpz_Load(object sender, System.EventArgs e)
		{
			//��ʼ��
			DataTable myTb=new DataTable();
			myTb.TableName="Tb";
			for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
			{	
				if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
				{
					myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,typeof(bool));
				}

				else
				{
					myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
				}
									   
				this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
			}


			this.myDataGrid1.DataSource=myTb;
			this.myDataGrid1.TableStyles[0].MappingName ="Tb";
			this.AddData();

            if (_menuTag.Function_Name=="Fun_ts_yp_xtwh_config")
                Yp.AddcmbYjks(cmbyjks,DeptType.ҩ�� , InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);
            else
                Yp.AddcmbYjks(cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

            if (InstanceForm.BCurrentUser.IsAdministrator == false) { cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId; cmbyjks.Enabled = false; }
		}


		private void AddData()
		{
			string ssql="select 0 ���,bh ��������,mc ��������,cast(zt as smallint) ����ֵ,bz �������� from yk_config where deptid="+ Convertor.IsNull(cmbyjks.SelectedValue,"0") +"";
			DataTable tb=InstanceForm.BDatabase.GetDataTable(ssql);
			FunBase.AddRowtNo(tb);
			tb.TableName="Tb";
			this.myDataGrid1.DataSource=tb;
			this.myDataGrid1.TableStyles[0].MappingName="Tb";
		}

		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butsave_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show(this, "�� [ȷ��] Ҫ�������������?", "ȷ��", MessageBoxButtons.YesNo)==DialogResult.No ) return;

			try
			{
                string str_old = "�޸�["+cmbyjks.Text.Trim()+"�ݲ��� ";
				InstanceForm.BDatabase.BeginTransaction();
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					int _values=Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["����ֵ"],"0"));
					string _code=Convertor.IsNull(tb.Rows[i]["��������"],"0");
					string ssql="update yk_config set zt="+_values+" where bh='"+_code+"' and deptid="+Convertor.IsNull(cmbyjks.SelectedValue,"0")+"";
					InstanceForm.BDatabase.DoCommand(ssql);

                    str_old =str_old+ _code.ToString() + ":" + _values.ToString()+"|" ;
				}

                SystemLog systemLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�޸�ҩƷ����", str_old, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 0, "��������" + System.Environment.MachineName, 8);
                systemLog.Save();
                systemLog = null;

                Yp.InsertLog("�޸�ҩƷ����", TrasenFrame.Forms.FrmMdiMain.CurrentDept.DeptId, 0, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString(), str_old, InstanceForm.BDatabase);


				InstanceForm.BDatabase.CommitTransaction();

				MessageBox.Show("����ɹ�");
			}
			catch(System.Exception err)
			{
				
				InstanceForm.BDatabase.RollbackTransaction();
				MessageBox.Show(err.Message);
			}

		}

        private void cmbyjks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbyjks.Text.Trim() != "" && cmbyjks.Text.Trim() != "System.Data.DataRowView" && Convertor.IsNumeric(cmbyjks.Text) == false)
            {
                AddData();
            }
        }

	}
}
