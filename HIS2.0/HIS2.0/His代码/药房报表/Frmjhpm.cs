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
	public class Frmjhpm : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton rdosl;
		private System.Windows.Forms.RadioButton rdoje;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.TextBox txtnum;
		private System.Windows.Forms.Button buttj;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbyplx;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private ComboBox cmbyjks;
        private Label label6;
        private Button butexcel;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmjhpm(MenuTag menuTag,string chineseName,Form mdiParent)
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butquit = new System.Windows.Forms.Button();
            this.butprint = new System.Windows.Forms.Button();
            this.buttj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoje = new System.Windows.Forms.RadioButton();
            this.rdosl = new System.Windows.Forms.RadioButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.butexcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butexcel);
            this.groupBox1.Controls.Add(this.cmbyjks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.buttj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtnum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoje);
            this.groupBox1.Controls.Add(this.rdosl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // cmbyjks
            // 
            this.cmbyjks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyjks.Location = new System.Drawing.Point(85, 19);
            this.cmbyjks.Name = "cmbyjks";
            this.cmbyjks.Size = new System.Drawing.Size(154, 20);
            this.cmbyjks.TabIndex = 15;
            this.cmbyjks.SelectionChangeCommitted += new System.EventHandler(this.cmbyjks_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "ҩ������";
            // 
            // cmbyplx
            // 
            this.cmbyplx.Location = new System.Drawing.Point(85, 54);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(154, 20);
            this.cmbyplx.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(22, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "ҩƷ����";
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(796, 47);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 33);
            this.butquit.TabIndex = 11;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(724, 47);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 33);
            this.butprint.TabIndex = 10;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // buttj
            // 
            this.buttj.Location = new System.Drawing.Point(643, 47);
            this.buttj.Name = "buttj";
            this.buttj.Size = new System.Drawing.Size(78, 33);
            this.buttj.TabIndex = 9;
            this.buttj.Text = "ͳ��(&T)";
            this.buttj.Click += new System.EventHandler(this.buttj_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(581, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "����ҩƷ";
            // 
            // txtnum
            // 
            this.txtnum.ForeColor = System.Drawing.Color.Blue;
            this.txtnum.Location = new System.Drawing.Point(542, 55);
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(42, 21);
            this.txtnum.TabIndex = 7;
            this.txtnum.Text = "10";
            this.txtnum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtnum_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(522, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ǰ";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(410, 55);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(113, 21);
            this.dtp2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(394, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(288, 55);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 21);
            this.dtp1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(236, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "���ڴ�";
            // 
            // rdoje
            // 
            this.rdoje.Location = new System.Drawing.Point(377, 17);
            this.rdoje.Name = "rdoje";
            this.rdoje.Size = new System.Drawing.Size(87, 24);
            this.rdoje.TabIndex = 1;
            this.rdoje.Text = "���������";
            // 
            // rdosl
            // 
            this.rdosl.Checked = true;
            this.rdosl.Location = new System.Drawing.Point(260, 20);
            this.rdosl.Name = "rdosl";
            this.rdosl.Size = new System.Drawing.Size(88, 24);
            this.rdosl.TabIndex = 0;
            this.rdosl.TabStop = true;
            this.rdosl.Text = "����������";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 502);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
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
            this.statusBarPanel3.Width = 1000;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 412);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "�������";
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
            this.myDataGrid1.Size = new System.Drawing.Size(938, 392);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "����";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "����";
            this.dataGridTextBoxColumn5.Width = 80;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "������";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "���ۼ�";
            this.dataGridTextBoxColumn7.Width = 70;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "����";
            this.dataGridTextBoxColumn8.Width = 70;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "��λ";
            this.dataGridTextBoxColumn4.Width = 40;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "�������";
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "���۽��";
            this.dataGridTextBoxColumn9.Width = 90;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "����";
            this.dataGridTextBoxColumn10.Width = 60;
            // 
            // butexcel
            // 
            this.butexcel.Location = new System.Drawing.Point(724, 12);
            this.butexcel.Name = "butexcel";
            this.butexcel.Size = new System.Drawing.Size(72, 32);
            this.butexcel.TabIndex = 43;
            this.butexcel.Text = "����(&E)";
            this.butexcel.Click += new System.EventHandler(this.butexcel_Click);
            // 
            // Frmjhpm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmjhpm";
            this.Text = "�������ͳ��";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmxspm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>


		private void txtnum_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (Convertor.IsNumeric(txtnum.Text)==false) txtnum.Text="";
		}

		private void Frmxspm_Load(object sender, System.EventArgs e)
		{
			try
			{
				dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
				
				//��ʼ��
				DataTable myTb=new DataTable();
				myTb.TableName="Tb";
				for(int i=0;i<=this.myDataGrid1.TableStyles[0].GridColumnStyles.Count-1;i++) 
				{	
					if(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].GetType().ToString()=="System.Windows.Forms.DataGridBoolColumn")
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,typeof(bool));
					else
						myTb.Columns.Add(this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText,Type.GetType("System.String"));	
									   
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].NullText="";
					this.myDataGrid1.TableStyles[0].GridColumnStyles[i].MappingName=this.myDataGrid1.TableStyles[0].GridColumnStyles[i].HeaderText;
				}
				this.myDataGrid1.DataSource=myTb;
				this.myDataGrid1.TableStyles[0].MappingName ="Tb";

                Yp.AddcmbYjks(cmbyjks, DeptType.ҩ��, InstanceForm.BDatabase, InstanceForm._menuTag.Jgbm);

                if (YpConfig.kslx(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase) != DeptType.δ֪)
                {
                    cmbyjks.SelectedValue = InstanceForm.BCurrentDept.DeptId;
                    cmbyjks.Enabled = false;
                }
                Yp.AddCmbYplx(true, Convert.ToInt32(cmbyjks.SelectedValue), this.cmbyplx,InstanceForm.BDatabase);
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
				if (Convert.ToInt32(Convertor.IsNull(txtnum.Text,"0"))==0){MessageBox.Show("����������");return;}
				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Value=Convert.ToInt32(this.rdoje.Checked);
				parameters[1].Value=Convert.ToInt32(cmbyplx.SelectedValue);
				parameters[2].Value=dtp1.Value.ToShortDateString();
				parameters[3].Value=dtp2.Value.ToShortDateString();
				parameters[4].Value=Convert.ToInt32(Convertor.IsNull(txtnum.Text,"0"));
                parameters[5].Value = Convert.ToInt32(cmbyjks.SelectedValue); ;

				parameters[0].Text="@type";
				parameters[1].Text="@yplx";
				parameters[2].Text="@dtp1";
				parameters[3].Text="@dtp2";
				parameters[4].Text="@mc";
				parameters[5].Text="@deptid";

				DataTable tb=InstanceForm.BDatabase.GetDataTable("SP_YF_tj_jhpmtj",parameters,30);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;

				decimal sumpfje=0;
				decimal sumlsje=0;
				decimal sumplce=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["�������"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["���۽��"]);
				}
				sumplce=sumlsje-sumpfje;
				this.statusBar1.Panels[0].Text="������� "+sumpfje.ToString("0.00");
				this.statusBar1.Panels[1].Text="���۽�� "+sumlsje.ToString("0.00");
				this.statusBar1.Panels[2].Text="������ "+sumplce.ToString("0.00");;
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
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
				string yplx=cmbyplx.Text.Trim();
				string rq1=dtp1.Value.ToShortDateString();
				string rq2=dtp2.Value.ToShortDateString();
				string pmlx=this.rdosl.Checked==true?this.rdosl.Text:this.rdoje.Text;
				string pmws=txtnum.Text.Trim();

				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.����������ͳ��.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["����"]);
					myrow["ypspm"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["pfj"]=Convert.ToDecimal(tb.Rows[i]["������"]);
					myrow["lsj"]=Convert.ToDecimal(tb.Rows[i]["���ۼ�"]);
					myrow["ypsl"]=Convert.ToDecimal(tb.Rows[i]["����"]);
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
					myrow["pfje"]=Convert.ToString(tb.Rows[i]["�������"]);
					myrow["lsje"]=Convert.ToString(tb.Rows[i]["���۽��"]);
					myrow["plce"]=Convert.ToDecimal(tb.Rows[i]["���۽��"])-Convert.ToDecimal(tb.Rows[i]["�������"]);
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					Dset.����������ͳ��.Rows.Add(myrow);

				}
				ParameterEx[] parameters=new ParameterEx[6];
				parameters[0].Text="yplx";
				parameters[0].Value=yplx.Trim();
				parameters[1].Text="rq1";
				parameters[1].Value=rq1.Trim();
				parameters[2].Text="rq2";
				parameters[2].Value=rq2.Trim();
				parameters[3].Text="pmlx";
				parameters[3].Value=pmlx.Trim();
				parameters[4].Text="pmws";
				parameters[4].Value=pmws.Trim();
				parameters[5].Text="TITLETEXT";
                parameters[5].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + cmbyjks.Text.Trim() + ")" + this.Text;

				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.����������ͳ��,Constant.ApplicationDirectory+"\\Report\\YF_��������ͳ��.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();
			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}

        private void cmbyjks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Yp.AddCmbYplx(true, Convert.ToInt32(this.cmbyjks.SelectedValue), this.cmbyplx,InstanceForm.BDatabase);
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
                string title = "������ʽ:";
                if (rdoje.Checked == true)
                    title = title + "���������";
                if (rdosl.Checked == true)
                    title = title + "����������";
                string where1 = "";


                where1 = "ҩ������:" + cmbyjks.Text.Trim() + " �ֿ�����:";
                where1 = where1 + " ����:" + dtp1.Value.ToShortDateString() + " ��:" + dtp2.Value.ToShortDateString() + "";
                where1 = where1 + " ҩƷ����:" + cmbyplx.Text + "  ";
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
                myExcel.Cells[1, 1] = TrasenFrame.Classes.Constant.HospitalName + "��������ͳ��";
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
