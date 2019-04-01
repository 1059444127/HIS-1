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

namespace ts_yf_cx
{
	/// <summary>
	/// Frmkccx ��ժҪ˵����
	/// </summary>
	public class Frmtjmx : System.Windows.Forms.Form
	{
		private MenuTag _menuTag;
		private string _chineseName;
		private Form _mdiParent;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkyplx;
		private myDataGrid.myDataGrid myDataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button butcx;
		private System.Windows.Forms.Button butquit;
		private System.Windows.Forms.Button butprint;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.ComboBox cmbyplx;
		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.CheckBox chkypmc;
		private System.Windows.Forms.TextBox txtypmc;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn ��Ʒ��;
		private YpConfig s;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frmtjmx(MenuTag menuTag,string chineseName,Form mdiParent)
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
			s=new YpConfig(InstanceForm.BCurrentDept.DeptId,InstanceForm.BDatabase);

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtypmc = new System.Windows.Forms.TextBox();
            this.cmbyplx = new System.Windows.Forms.ComboBox();
            this.butprint = new System.Windows.Forms.Button();
            this.butquit = new System.Windows.Forms.Button();
            this.butcx = new System.Windows.Forms.Button();
            this.chkyplx = new System.Windows.Forms.CheckBox();
            this.chkypmc = new System.Windows.Forms.CheckBox();
            this.myDataGrid1 = new myDataGrid.myDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.��Ʒ�� = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtypmc);
            this.groupBox1.Controls.Add(this.cmbyplx);
            this.groupBox1.Controls.Add(this.butprint);
            this.groupBox1.Controls.Add(this.butquit);
            this.groupBox1.Controls.Add(this.butcx);
            this.groupBox1.Controls.Add(this.chkyplx);
            this.groupBox1.Controls.Add(this.chkypmc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��ѯ";
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(448, 16);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(112, 21);
            this.dtp2.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(428, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "��";
            // 
            // dtp1
            // 
            this.dtp1.Location = new System.Drawing.Point(312, 16);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(110, 21);
            this.dtp1.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "���ڴ�";
            // 
            // txtypmc
            // 
            this.txtypmc.Enabled = false;
            this.txtypmc.Location = new System.Drawing.Point(113, 40);
            this.txtypmc.Name = "txtypmc";
            this.txtypmc.Size = new System.Drawing.Size(144, 21);
            this.txtypmc.TabIndex = 33;
            this.txtypmc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextKeyUp);
            // 
            // cmbyplx
            // 
            this.cmbyplx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbyplx.Enabled = false;
            this.cmbyplx.Location = new System.Drawing.Point(113, 17);
            this.cmbyplx.Name = "cmbyplx";
            this.cmbyplx.Size = new System.Drawing.Size(144, 20);
            this.cmbyplx.TabIndex = 31;
            // 
            // butprint
            // 
            this.butprint.Location = new System.Drawing.Point(672, 16);
            this.butprint.Name = "butprint";
            this.butprint.Size = new System.Drawing.Size(72, 32);
            this.butprint.TabIndex = 30;
            this.butprint.Text = "��ӡ(&P)";
            this.butprint.Click += new System.EventHandler(this.butprint_Click);
            // 
            // butquit
            // 
            this.butquit.Location = new System.Drawing.Point(752, 16);
            this.butquit.Name = "butquit";
            this.butquit.Size = new System.Drawing.Size(72, 32);
            this.butquit.TabIndex = 29;
            this.butquit.Text = "�˳�(&Q)";
            this.butquit.Click += new System.EventHandler(this.butquit_Click);
            // 
            // butcx
            // 
            this.butcx.Location = new System.Drawing.Point(592, 16);
            this.butcx.Name = "butcx";
            this.butcx.Size = new System.Drawing.Size(72, 32);
            this.butcx.TabIndex = 28;
            this.butcx.Text = "��ѯ(&V)";
            this.butcx.Click += new System.EventHandler(this.butcx_Click);
            // 
            // chkyplx
            // 
            this.chkyplx.Location = new System.Drawing.Point(32, 16);
            this.chkyplx.Name = "chkyplx";
            this.chkyplx.Size = new System.Drawing.Size(95, 24);
            this.chkyplx.TabIndex = 20;
            this.chkyplx.Text = "ҩƷ����";
            this.chkyplx.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
            // 
            // chkypmc
            // 
            this.chkypmc.Location = new System.Drawing.Point(32, 40);
            this.chkypmc.Name = "chkypmc";
            this.chkypmc.Size = new System.Drawing.Size(95, 24);
            this.chkypmc.TabIndex = 38;
            this.chkypmc.Text = "ҩƷ����";
            this.chkypmc.CheckedChanged += new System.EventHandler(this.chkyplx_CheckedChanged);
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
            this.myDataGrid1.Size = new System.Drawing.Size(858, 417);
            this.myDataGrid1.TabIndex = 0;
            this.myDataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.myDataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn2,
            this.��Ʒ��,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn5});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "���";
            this.dataGridTextBoxColumn1.Width = 35;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "�����ĺ�";
            this.dataGridTextBoxColumn15.Width = 60;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "��������";
            this.dataGridTextBoxColumn16.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ʒ��";
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // ��Ʒ��
            // 
            this.��Ʒ��.Format = "";
            this.��Ʒ��.FormatInfo = null;
            this.��Ʒ��.HeaderText = "��Ʒ��";
            this.��Ʒ��.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "���";
            this.dataGridTextBoxColumn3.Width = 90;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "����";
            this.dataGridTextBoxColumn4.Width = 90;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "ԭ������";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "��������";
            this.dataGridTextBoxColumn7.Width = 60;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "ԭ���ۼ�";
            this.dataGridTextBoxColumn12.Width = 60;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "�����ۼ�";
            this.dataGridTextBoxColumn13.Width = 60;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "��������";
            this.dataGridTextBoxColumn8.Width = 60;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "��λ";
            this.dataGridTextBoxColumn9.Width = 40;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "��λ���";
            this.dataGridTextBoxColumn14.Width = 60;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "���������";
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "�����۽��";
            this.dataGridTextBoxColumn11.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "����";
            this.dataGridTextBoxColumn5.Width = 60;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 509);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(864, 24);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myDataGrid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 437);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "������ϸ";
            // 
            // Frmtjmx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(864, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmtjmx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "���۲�ѯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frmkccx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void chkyplx_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbyplx.Enabled=chkyplx.Checked==true?true:false;
			txtypmc.Enabled=chkypmc.Checked==true?true:false;
		}

		private void butcx_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataTable tb=new DataTable("Tb");
				string ssql="select 0  ���,tjwh �����ĺ�,zxrq ��������,yppm Ʒ��,ypspm ��Ʒ��, ypgg ���,dbo.fun_yp_sccj(sccj) ����,ypfj ԭ������,xpfj ��������,ylsj ԭ���ۼ�,"+
					" xlsj �����ۼ�,(xlsj-ylsj) ��λ���,tjsl ��������,B.ypdw ��λ,tpfje ���������,tlsje �����۽��,shh ���� from yf_tj a,yf_tjmx b,vi_yp_ypcd c "+
					" where wcbj=1 and a.id=b.djid and b.cjid=c.cjid and a.deptid="+InstanceForm.BCurrentDept.DeptId+
					" and zxrq>='"+this.dtp1.Value.ToShortDateString()+" 00:00:00' and djrq<='"+this.dtp2.Value.ToShortDateString()+" 23:59:59'";
			
				if (chkyplx.Checked==true && cmbyplx.Text.Trim()!="ȫ��") ssql=ssql+" and yplx="+Convert.ToInt32(Convertor.IsNull(cmbyplx.SelectedValue,"0"))+" ";
				if (chkypmc.Checked==true) ssql=ssql+" and b.cjid="+Convert.ToInt32(Convertor.IsNull(txtypmc.Tag ,"0"))+" ";

				ssql=ssql+" order by b.id";
				tb=InstanceForm.BDatabase.GetDataTable(ssql);
				FunBase.AddRowtNo(tb);
				tb.TableName="Tb";
				this.myDataGrid1.DataSource=tb;
				this.myDataGrid1.TableStyles[0].MappingName="Tb";

				decimal sumpfje=0;
				decimal sumlsje=0;
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					sumpfje=sumpfje+Convert.ToDecimal(tb.Rows[i]["���������"]);
					sumlsje=sumlsje+Convert.ToDecimal(tb.Rows[i]["�����۽��"]);
				}
				this.statusBar1.Panels[0].Text="��������� "+sumpfje.ToString("0.00");
				this.statusBar1.Panels[1].Text="�����۽�� "+sumlsje.ToString("0.00");
			}
			catch(System.Exception err)
			{
				MessageBox.Show("�Բ���,��������"+err.Message );
			}
		}

		private void Frmkccx_Load(object sender, System.EventArgs e)
		{
			this.dtp1.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
			this.dtp2.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

			FunBase.CsDataGrid(this.myDataGrid1,this.myDataGrid1.TableStyles[0],"Tb");

			Yp.AddCmbYplx(true,InstanceForm.BCurrentDept.DeptId,this.cmbyplx,InstanceForm.BDatabase);
		}


		private void butquit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butprint_Click(object sender, System.EventArgs e)
		{
			try
			{
				string bz="�������� "+this.dtp1.Value.ToShortDateString()+" �� "+this.dtp2.Value.ToShortDateString();
				if (chkyplx.Checked==true) bz=bz+"     ҩƷ���� "+cmbyplx.Text;
				if (chkypmc.Checked==true) bz=bz+"     ҩƷ���� "+txtypmc.Text;
				DataTable tb=(DataTable)this.myDataGrid1.DataSource;
				ts_Yk_ReportView.Dataset2 Dset=new ts_Yk_ReportView.Dataset2();
				DataRow myrow;
				
				for(int i=0;i<=tb.Rows.Count-1;i++)
				{
					myrow=Dset.ҩƷ���۵�.NewRow();
					myrow["xh"]=Convert.ToInt32(tb.Rows[i]["���"]);
					if (s.��ӡ����ʱ������ʾ��Ʒ��==true)
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["��Ʒ��"]);
					else
						myrow["ypmc"]=Convert.ToString(tb.Rows[i]["Ʒ��"]);
					myrow["ypgg"]=Convert.ToString(tb.Rows[i]["���"]);
					myrow["sccj"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["ypsl"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					myrow["ypdw"]=Convert.ToString(tb.Rows[i]["��λ"]);
					myrow["ypfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ������"],"0"));
					myrow["xpfj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"));
					decimal pfjdwcj=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0"))-Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ������"],"0"));
					decimal tpfje=pfjdwcj*(Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��������"],"0")));
					myrow["pfjdwcj"]=pfjdwcj.ToString("0.00");
					myrow["tpfje"]=tpfje.ToString("0.00");
					myrow["ylsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ԭ���ۼ�"],"0"));
					myrow["xlsj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�����ۼ�"],"0"));
					myrow["lsjdwcj"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["��λ���"],"0"));
					myrow["tlsje"]=Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["�����۽��"],"0"));
					myrow["shh"]=Convert.ToString(tb.Rows[i]["����"]);
					myrow["tjwh"]=Convert.ToString(tb.Rows[i]["�����ĺ�"]);
					myrow["zxrq"]=Convert.ToString(tb.Rows[i]["��������"]);
					Dset.ҩƷ���۵�.Rows.Add(myrow);

				}

				ParameterEx[] parameters=new ParameterEx[7];
				parameters[0].Text="DJH";
				parameters[0].Value="0";
				parameters[1].Text="DJY";
				parameters[1].Value=InstanceForm.BCurrentUser.Name;
				parameters[2].Text="RQ";
				parameters[2].Value="";
				parameters[3].Text="TJWH";
				parameters[3].Value="";
				parameters[4].Text="TITLETEXT";
				parameters[4].Value=TrasenFrame.Classes.Constant.HospitalName+"("+InstanceForm.BCurrentDept.DeptName+")"+"ҩƷ���۵�";
				parameters[5].Text="BZ";
				parameters[5].Value=bz;
				parameters[6].Text="swhere";
				parameters[6].Value=bz.Trim();
				
				TrasenFrame.Forms.FrmReportView f=new TrasenFrame.Forms.FrmReportView(Dset.ҩƷ���۵�,Constant.ApplicationDirectory+"\\Report\\YF_ҩƷ���۵���.rpt",parameters);
				if (f.LoadReportSuccess) f.Show();else  f.Dispose();

			}
			catch(System.Exception err)
			{
				MessageBox.Show(err.Message);
			}

		}


		//���������¼�
		private void TextKeyUp(object sender, KeyEventArgs e)//KeyEventArgs
		{
			int nkey=Convert.ToInt32(e.KeyCode);
			Control control=(Control)sender;

			if (control.Text.Trim()=="" )
			{
				control.Text="";
				control.Tag="0";
			}

			if ((nkey>=65 &&  nkey<=90) || (nkey>=48 && nkey<=57) || (nkey>=96 && nkey<=105) || nkey==8 || nkey==32 || nkey==46||(nkey==13 && (Convert.ToString(control.Tag)=="0" || Convert.ToString(control.Tag)=="")))
			{
				
			}
			else
			{
				return;
			}

			string[] GrdMappingName;
			int[] GrdWidth;
			string[]sfield;
			string ssql="";
			DataRow row;
				
			Point point=new Point(this.Location.X+control.Location.X,this.Location.Y+control.Location.Y+control.Height*3 );
			switch(control.TabIndex)
			{
				case 33:
					if (control.Text.Trim()=="") return;
					GrdMappingName=new string[] {"ggid","cjid","�к�","Ʒ��","���","����","��λ","DWBL","������","���ۼ�","����"};
					GrdWidth=new int[] {0,0,50,200,100,100,40,0,60,60,70};
					sfield=new string[] {"wbm","pym","szm","ywm","ypbm"};
                    ssql = "select distinct a.ggid,cjid,0  rowno,ypspm,ypgg,dbo.fun_yp_sccj(sccj) sccj,dbo.fun_yp_ypdw(ypdw) ypdw,1 dwbl,pfj,lsj,shh from vi_Yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and deptid=" + InstanceForm.BCurrentDept.DeptId + " ";
					TrasenFrame.Forms.Fshowcard f2=new TrasenFrame.Forms.Fshowcard(GrdMappingName,GrdWidth,sfield,Constant.CustomFilterType,control.Text.Trim(),ssql);
					f2.Location=point;
					f2.ShowDialog(this);
					row=f2.dataRow;
					if (row!=null) 
					{
						this.txtypmc.Text=row["ypspm"].ToString();
						this.txtypmc.Tag=row["cjid"].ToString();
						this.txtypmc.Focus();
					}
					break;

			}

		}








	}
}
