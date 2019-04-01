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
	public class Frmrkhztj : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.RadioButton rdo1;
		private System.Windows.Forms.RadioButton rdo2;
		private System.Windows.Forms.ComboBox cmbmonth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbyear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
        private ComboBox cmbyjks;
        private Label label6;
        private Button butexcel;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmrkhztj(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butexcel = new System.Windows.Forms.Button();
            this.cmbyjks = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbyear = new System.Windows.Forms.ComboBox();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbmonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbyear);
            this.groupBox1.Controls.Add(this.rdo2);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.rdo1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(742, 46);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 33);
            this.butexcel.TabIndex = 43;
            this.butexcel.Text = "����(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(92, 19);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(177, 20);
            this.cmbyjks.TabIndex = 30;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(29, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "ҩ������";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(572, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "��";
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
            this.cmbmonth.Location = new System.Drawing.Point(508, 54);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(56, 20);
            this.cmbmonth.TabIndex = 21;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(484, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "��";
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
            this.cmbyear.Location = new System.Drawing.Point(420, 54);
            this.cmbyear.Name = "cmbyear";
            this.cmbyear.Size = new System.Drawing.Size(64, 20);
            this.cmbyear.TabIndex = 19;
            this.cmbyear.SelectedIndexChanged += new System.EventHandler(this.cmbyear_SelectedIndexChanged);
            // 
            // rdo2
            // 
            this.rdo2.Checked = true;
            this.rdo2.Location = new System.Drawing.Point(340, 54);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(96, 25);
            this.rdo2.TabIndex = 13;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "���·ݲ�ѯ";
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(816, 46);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(64, 34);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(676, 46);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(64, 33);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(612, 46);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(64, 33);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "ͳ��(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(220, 54);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(112, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(204, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(92, 54);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 21);
            this.dtp1.TabIndex = 3;
            // 
            // rdo1
            // 
            this.rdo1.Location = new System.Drawing.Point(28, 52);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(96, 24);
            this.rdo1.TabIndex = 12;
            this.rdo1.Text = "�����ڴ�";
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3,
            this.statusBarPanel4});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(944, 23);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 409);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ͳ�����";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 389);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn1});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.ReadOnly = true;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "���";
            this.dataGridTextBoxColumn4.Width = 40;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "������λ";
            this.dataGridTextBoxColumn9.Width = 200;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "�������";
            this.dataGridTextBoxColumn10.Width = 80;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "�������";
            this.dataGridTextBoxColumn11.Width = 80;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "���۽��";
            this.dataGridTextBoxColumn15.Width = 80;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "������";
            this.dataGridTextBoxColumn17.Width = 80;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "������";
            this.dataGridTextBoxColumn16.Width = 80;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "��������";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "��ⷽʽ";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // Frmrkhztj
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmrkhztj";
            this.Text = "������ͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>


		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				//��ʼ��
				FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");
				
				//Yp.AddcmbYear(InstanceForm.BCurrentDept.DeptId, this.cmbypzlx, InstanceForm.BDatabase);
				//Yp.AddCmbYplx(true,InstanceForm.BCurrentDept.DeptId,cmbyplx, InstanceForm.BDatabase);
				this.rdo1.Checked=true;

                Yp.AddcmbYjks(cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase) != DeptType.δ֪)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);

			}
			catch(System.Exception err)
			{
				MessageBox.Show("��������"+err.Message);
			}


		}

		private void buttj_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor=PubStaticFun.WaitCursor();
				this.buttj.Enabled=false;
				ParameterEx[] parameters=new ParameterEx[6];
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

				DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YF_TJ_RKHZ",parameters,30);
				FunBase.AddRowtNo(tb);

				decimal sumjhje=0;
				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				decimal sumjlce=0;
				long sumdjzs=0;
				for (int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumjhje=sumjhje+Convert.ToDecimal(tb.Rows[i]["�������"]);
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["�������"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["���۽��"]);
					sumjlce=sumjlce+Convert.ToDecimal(tb.Rows[i]["������"]);
					sumplce=sumplce+Convert.ToDecimal(tb.Rows[i]["������"]);
					sumdjzs=sumdjzs+Convert.ToInt64(tb.Rows[i]["��������"]);
				}
				DataRow newrow=tb.NewRow();
				newrow["�������"]=sumjhje.ToString("0.00");
				newrow["�������"]=sumpfje.ToString("0.00");
				newrow["���۽��"]=sumlsje.ToString("0.00");
				newrow["������"]=sumjlce.ToString("0.00");
				newrow["������"]=sumplce.ToString("0.00");
				newrow["��������"]=sumdjzs.ToString();
				newrow["���"]="�ϼ�";
				tb.Rows.Add(newrow);

				this.statusBar1.Panels[0].Text="�������:"+sumjhje.ToString("0.00");
				this.statusBar1.Panels[1].Text="���۽��:"+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text="������:"+sumjlce.ToString("0.00");
			

				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.buttj.Enabled=true;
			}
			catch(System.Exception err)
			{
				this.buttj.Enabled=true;
				MessageBox.Show(err.Message);
			}
			finally
			{
				this.Cursor=Cursors.Arrow;
			}
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
                string where2 = InstanceForm.BCurrentUser.Name;
                //where1 = "ҩ������:" + cmbyjks.Text.Trim() + "  ";

				if (rdo1.Checked==true)
				{
					where1=where1+"������ͳ��  ����:"+dtp1.Value.ToShortDateString();
					where1=where1+" ��:"+dtp2.Value.ToShortDateString();
				}
				else
				{
					where1=where1+"������·�ͳ��  ����:"+this.statusBar1.Panels[3].Text;
				}

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();

				DataRow myrow;
				int ii=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.���ݻ���ͳ��.NewRow();
					myrow["xh"]=Convert.ToString(tb.Rows[i]["���"]);
                    myrow["rckfs"] = Convert.ToString(tb.Rows[i]["��ⷽʽ"]);
					myrow["wldw"]=Convert.ToString(tb.Rows[i]["������λ"]);
					myrow["jhje"]=Convert.ToDecimal(tb.Rows[i]["�������"]);
                    myrow["pfje"] = Convert.ToDecimal(tb.Rows[i]["�������"]);
					myrow["lsje"]=Convert.ToDecimal(tb.Rows[i]["���۽��"]);
                    myrow["jlce"] = Convert.ToDecimal(tb.Rows[i]["������"]);
					myrow["plce"]=Convert.ToDecimal(tb.Rows[i]["������"]);
					myrow["djzs"]=Convert.ToDecimal(tb.Rows[i]["��������"]);
					Dset.���ݻ���ͳ��.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[3];
				parameters[0].Text="where1";
				parameters[0].Value=where1.Trim();
				parameters[1].Text="where2";
                parameters[1].Value = where2.Trim();
				parameters[2].Text="title";
                parameters[2].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + "�����ܱ�";
				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.���ݻ���ͳ��,Constant.ApplicationDirectory+"\\Report\\YP_�����ܱ���.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
	
				
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		private void rdo1_CheckedChanged(object sender, System.EventArgs e)
		{
			DataTable tb=(DataTable)this.myDataGrid1.DataSource;
			tb.Rows.Clear();

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


		private void cmbyear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            Yp.AddcmbMonth(Convert.ToInt32(cmbyjks.SelectedValue), Convert.ToInt32(this.cmbyear.Text), cmbyear, cmbmonth, InstanceForm.BDatabase);
		}

		
		private void cmbmonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.rdo2.Checked==true)
                this.statusBar1.Panels[3].Text = Yp.Seekkjqj(Convert.ToInt32(cmbyear.Text), Convert.ToInt32(cmbmonth.Text), Convert.ToInt32(cmbyjks.SelectedValue), InstanceForm.BDatabase);
		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddcmbYear(Convert.ToInt32(cmbyjks.SelectedValue), cmbyear, InstanceForm.BDatabase);
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


                where1 = "ҩ������:" + cmbyjks.Text.Trim();
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

	}
}
