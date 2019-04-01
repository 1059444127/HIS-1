using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using ts_zyhs_classes;

namespace ts_zyhs_yzgl
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class frmBRFS : System.Windows.Forms.Form
	{
        public int nType=0;  //ҽ������		
		public int iSelect=2;  // 0����  1ѡ�� 2������  
		public int iSelect0=0,iSelect1=0,iSelect2=0,iSelect3=0;
		public bool IsChangeExecDept = false;
        public int newExecDept = 0;
        public DateTime execDateTime;

		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button bt��ʼ����;
		public System.Windows.Forms.RadioButton rb32;
		public System.Windows.Forms.RadioButton rb31;
		public System.Windows.Forms.RadioButton rb30;
		public System.Windows.Forms.RadioButton rb22;
		public System.Windows.Forms.RadioButton rb21;
		public System.Windows.Forms.RadioButton rb20;
		public System.Windows.Forms.RadioButton rb12;
		public System.Windows.Forms.RadioButton rb11;
		public System.Windows.Forms.RadioButton rb10;
		public System.Windows.Forms.RadioButton rb02;
		public System.Windows.Forms.RadioButton rb01;
		public System.Windows.Forms.RadioButton rb00;
		public System.Windows.Forms.RadioButton rbѡ����;
		public System.Windows.Forms.RadioButton rbȫ������;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.CheckBox chkExecDept;
		private System.Windows.Forms.ComboBox cmbExecDept;
		public System.Windows.Forms.GroupBox grpLSZD;
		public System.Windows.Forms.GroupBox grpCQZD;
		public System.Windows.Forms.GroupBox grpLSYZ;
        public System.Windows.Forms.GroupBox grpCQYZ;
        private DateTimePicker DateExecDate;
        private CheckBox chkDate;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBRFS()
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.bt��ʼ���� = new System.Windows.Forms.Button();
            this.grpLSZD = new System.Windows.Forms.GroupBox();
            this.rb32 = new System.Windows.Forms.RadioButton();
            this.rb31 = new System.Windows.Forms.RadioButton();
            this.rb30 = new System.Windows.Forms.RadioButton();
            this.grpCQZD = new System.Windows.Forms.GroupBox();
            this.rb22 = new System.Windows.Forms.RadioButton();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.grpLSYZ = new System.Windows.Forms.GroupBox();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.grpCQYZ = new System.Windows.Forms.GroupBox();
            this.rb02 = new System.Windows.Forms.RadioButton();
            this.rb01 = new System.Windows.Forms.RadioButton();
            this.rb00 = new System.Windows.Forms.RadioButton();
            this.rbѡ���� = new System.Windows.Forms.RadioButton();
            this.rbȫ������ = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbExecDept = new System.Windows.Forms.ComboBox();
            this.chkExecDept = new System.Windows.Forms.CheckBox();
            this.DateExecDate = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.grpLSZD.SuspendLayout();
            this.grpCQZD.SuspendLayout();
            this.grpLSYZ.SuspendLayout();
            this.grpCQYZ.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(0, 230);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(296, 8);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(152, 246);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(128, 26);
            this.btCancel.TabIndex = 83;
            this.btCancel.Text = "ȡ��(&E)";
            // 
            // bt��ʼ����
            // 
            this.bt��ʼ����.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt��ʼ����.Location = new System.Drawing.Point(8, 246);
            this.bt��ʼ����.Name = "bt��ʼ����";
            this.bt��ʼ����.Size = new System.Drawing.Size(128, 26);
            this.bt��ʼ����.TabIndex = 82;
            this.bt��ʼ����.Text = "��ʼ����(&F)";
            this.bt��ʼ����.Click += new System.EventHandler(this.bt��ʼ����_Click);
            // 
            // grpLSZD
            // 
            this.grpLSZD.Controls.Add(this.rb32);
            this.grpLSZD.Controls.Add(this.rb31);
            this.grpLSZD.Controls.Add(this.rb30);
            this.grpLSZD.Enabled = false;
            this.grpLSZD.Location = new System.Drawing.Point(80, 182);
            this.grpLSZD.Name = "grpLSZD";
            this.grpLSZD.Size = new System.Drawing.Size(200, 40);
            this.grpLSZD.TabIndex = 90;
            this.grpLSZD.TabStop = false;
            // 
            // rb32
            // 
            this.rb32.Location = new System.Drawing.Point(128, 16);
            this.rb32.Name = "rb32";
            this.rb32.Size = new System.Drawing.Size(64, 16);
            this.rb32.TabIndex = 14;
            this.rb32.Text = "������";
            this.rb32.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb31
            // 
            this.rb31.Location = new System.Drawing.Point(72, 16);
            this.rb31.Name = "rb31";
            this.rb31.Size = new System.Drawing.Size(48, 16);
            this.rb31.TabIndex = 13;
            this.rb31.Text = "ѡ��";
            this.rb31.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb30
            // 
            this.rb30.Enabled = false;
            this.rb30.Location = new System.Drawing.Point(16, 16);
            this.rb30.Name = "rb30";
            this.rb30.Size = new System.Drawing.Size(48, 16);
            this.rb30.TabIndex = 12;
            this.rb30.Text = "����";
            this.rb30.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpCQZD
            // 
            this.grpCQZD.Controls.Add(this.rb22);
            this.grpCQZD.Controls.Add(this.rb21);
            this.grpCQZD.Controls.Add(this.rb20);
            this.grpCQZD.Enabled = false;
            this.grpCQZD.Location = new System.Drawing.Point(80, 142);
            this.grpCQZD.Name = "grpCQZD";
            this.grpCQZD.Size = new System.Drawing.Size(200, 40);
            this.grpCQZD.TabIndex = 89;
            this.grpCQZD.TabStop = false;
            // 
            // rb22
            // 
            this.rb22.Location = new System.Drawing.Point(128, 16);
            this.rb22.Name = "rb22";
            this.rb22.Size = new System.Drawing.Size(64, 16);
            this.rb22.TabIndex = 14;
            this.rb22.Text = "������";
            this.rb22.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb21
            // 
            this.rb21.Location = new System.Drawing.Point(72, 16);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(48, 16);
            this.rb21.TabIndex = 13;
            this.rb21.Text = "ѡ��";
            this.rb21.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb20
            // 
            this.rb20.Enabled = false;
            this.rb20.Location = new System.Drawing.Point(16, 16);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(48, 16);
            this.rb20.TabIndex = 12;
            this.rb20.Text = "����";
            this.rb20.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpLSYZ
            // 
            this.grpLSYZ.Controls.Add(this.rb12);
            this.grpLSYZ.Controls.Add(this.rb11);
            this.grpLSYZ.Controls.Add(this.rb10);
            this.grpLSYZ.Enabled = false;
            this.grpLSYZ.Location = new System.Drawing.Point(80, 102);
            this.grpLSYZ.Name = "grpLSYZ";
            this.grpLSYZ.Size = new System.Drawing.Size(200, 40);
            this.grpLSYZ.TabIndex = 88;
            this.grpLSYZ.TabStop = false;
            // 
            // rb12
            // 
            this.rb12.Location = new System.Drawing.Point(128, 16);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(64, 16);
            this.rb12.TabIndex = 14;
            this.rb12.Text = "������";
            this.rb12.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb11
            // 
            this.rb11.Location = new System.Drawing.Point(72, 16);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(48, 16);
            this.rb11.TabIndex = 13;
            this.rb11.Text = "ѡ��";
            this.rb11.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb10
            // 
            this.rb10.Enabled = false;
            this.rb10.Location = new System.Drawing.Point(16, 16);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(48, 16);
            this.rb10.TabIndex = 12;
            this.rb10.Text = "����";
            this.rb10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpCQYZ
            // 
            this.grpCQYZ.Controls.Add(this.rb02);
            this.grpCQYZ.Controls.Add(this.rb01);
            this.grpCQYZ.Controls.Add(this.rb00);
            this.grpCQYZ.Enabled = false;
            this.grpCQYZ.Location = new System.Drawing.Point(80, 62);
            this.grpCQYZ.Name = "grpCQYZ";
            this.grpCQYZ.Size = new System.Drawing.Size(200, 40);
            this.grpCQYZ.TabIndex = 87;
            this.grpCQYZ.TabStop = false;
            // 
            // rb02
            // 
            this.rb02.Location = new System.Drawing.Point(128, 16);
            this.rb02.Name = "rb02";
            this.rb02.Size = new System.Drawing.Size(64, 16);
            this.rb02.TabIndex = 14;
            this.rb02.Text = "������";
            this.rb02.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb01
            // 
            this.rb01.Location = new System.Drawing.Point(72, 16);
            this.rb01.Name = "rb01";
            this.rb01.Size = new System.Drawing.Size(48, 16);
            this.rb01.TabIndex = 13;
            this.rb01.Text = "ѡ��";
            this.rb01.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rb00
            // 
            this.rb00.Enabled = false;
            this.rb00.Location = new System.Drawing.Point(16, 16);
            this.rb00.Name = "rb00";
            this.rb00.Size = new System.Drawing.Size(48, 16);
            this.rb00.TabIndex = 12;
            this.rb00.Text = "����";
            this.rb00.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // rbѡ����
            // 
            this.rbѡ����.Checked = true;
            this.rbѡ����.Location = new System.Drawing.Point(184, 8);
            this.rbѡ����.Name = "rbѡ����";
            this.rbѡ����.Size = new System.Drawing.Size(80, 24);
            this.rbѡ����.TabIndex = 86;
            this.rbѡ����.TabStop = true;
            this.rbѡ����.Text = "ѡ����";
            this.rbѡ����.Click += new System.EventHandler(this.rbѡ����_Click);
            // 
            // rbȫ������
            // 
            this.rbȫ������.Enabled = false;
            this.rbȫ������.Location = new System.Drawing.Point(80, 8);
            this.rbȫ������.Name = "rbȫ������";
            this.rbȫ������.Size = new System.Drawing.Size(104, 24);
            this.rbȫ������.TabIndex = 85;
            this.rbȫ������.Text = "ȫ������";
            this.rbȫ������.Click += new System.EventHandler(this.rbȫ������_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = "����ҽ����";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 92;
            this.label2.Text = "��ʱҽ����";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 93;
            this.label3.Text = "��ʱ�˵���";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 94;
            this.label4.Text = "�����˵���";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 95;
            this.label5.Text = "ִ�п��ң�";
            this.label5.Visible = false;
            // 
            // cmbExecDept
            // 
            this.cmbExecDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExecDept.Enabled = false;
            this.cmbExecDept.Location = new System.Drawing.Point(96, 8);
            this.cmbExecDept.Name = "cmbExecDept";
            this.cmbExecDept.Size = new System.Drawing.Size(184, 20);
            this.cmbExecDept.TabIndex = 96;
            this.cmbExecDept.Visible = false;
            // 
            // chkExecDept
            // 
            this.chkExecDept.Enabled = false;
            this.chkExecDept.Location = new System.Drawing.Point(80, 6);
            this.chkExecDept.Name = "chkExecDept";
            this.chkExecDept.Size = new System.Drawing.Size(16, 24);
            this.chkExecDept.TabIndex = 97;
            this.chkExecDept.Visible = false;
            this.chkExecDept.CheckedChanged += new System.EventHandler(this.chkExecDept_CheckedChanged);
            // 
            // DateExecDate
            // 
            this.DateExecDate.CalendarFont = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.CustomFormat = "yyyy-MM-dd";
            this.DateExecDate.Enabled = false;
            this.DateExecDate.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateExecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateExecDate.Location = new System.Drawing.Point(96, 38);
            this.DateExecDate.Name = "DateExecDate";
            this.DateExecDate.Size = new System.Drawing.Size(120, 23);
            this.DateExecDate.TabIndex = 11;
            this.DateExecDate.Value = new System.DateTime(2003, 9, 20, 0, 0, 0, 0);
            // 
            // chkDate
            // 
            this.chkDate.Location = new System.Drawing.Point(18, 42);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(80, 16);
            this.chkDate.TabIndex = 10;
            this.chkDate.Text = "ѡ������";
            this.chkDate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // frmBRFS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(280, 276);
            this.Controls.Add(this.DateExecDate);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.grpCQYZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpLSZD);
            this.Controls.Add(this.grpCQZD);
            this.Controls.Add(this.grpLSYZ);
            this.Controls.Add(this.rbѡ����);
            this.Controls.Add(this.rbȫ������);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.bt��ʼ����);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkExecDept);
            this.Controls.Add(this.cmbExecDept);
            this.Controls.Add(this.label5);
            this.Location = new System.Drawing.Point(296, 304);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(296, 314);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 314);
            this.Name = "frmBRFS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��������ҽ������";
            this.Load += new System.EventHandler(this.frmBRFS_Load);
            this.grpLSZD.ResumeLayout(false);
            this.grpCQZD.ResumeLayout(false);
            this.grpLSYZ.ResumeLayout(false);
            this.grpCQYZ.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void rbȫ������_Click(object sender, System.EventArgs e)
		{
			this.rb00.Checked=true;
			this.rb10.Checked=true;
			this.rb20.Checked=true;
			this.rb30.Checked=true;

			this.grpCQYZ.Enabled=false;
			this.grpLSYZ.Enabled=false;
			this.grpCQZD.Enabled=false;
			this.grpLSZD.Enabled=false;

			this.chkExecDept.Checked=false;
			this.chkExecDept.Enabled=false;
		}

		private void rbѡ����_Click(object sender, System.EventArgs e)
		{
			this.grpCQYZ.Enabled=true;
			this.grpLSYZ.Enabled=true;
			this.grpCQZD.Enabled=true;
			this.grpLSZD.Enabled=true;

            this.rb01.Enabled=this.nType==0?true:false;
			this.rb11.Enabled=this.nType==1?true:false;
			this.rb21.Enabled=this.nType==2?true:false;
			this.rb31.Enabled=this.nType==3?true:false;

			this.rb01.Checked=this.nType==0?true:false;
			this.rb11.Checked=this.nType==1?true:false;
			this.rb21.Checked=this.nType==2?true:false;
			this.rb31.Checked=this.nType==3?true:false;

			this.rb02.Checked=this.nType==0?false:true;
			this.rb12.Checked=this.nType==1?false:true;
			this.rb22.Checked=this.nType==2?false:true;
			this.rb32.Checked=this.nType==3?false:true;

			if(nType==1)
				chkExecDept.Enabled=true;
			else
				chkExecDept.Enabled=false;
		}

		private void bt��ʼ����_Click(object sender, System.EventArgs e)
		{	

			this.iSelect=this.rbȫ������.Checked?0:1;
			this.iSelect0=this.rb00.Checked?0:(this.rb01.Checked?1:2);
			this.iSelect1=this.rb10.Checked?0:(this.rb11.Checked?1:2);
			this.iSelect2=this.rb20.Checked?0:(this.rb21.Checked?1:2);
			this.iSelect3=this.rb30.Checked?0:(this.rb31.Checked?1:2);

			if(cmbExecDept.Enabled && cmbExecDept.Text.Trim()!="")
			{
				if(MessageBox.Show("�Ƿ���Ҫ����ѡ������ʱҽ����ҩƷ��ִ�п��Ҹ�Ϊ "+cmbExecDept.Text.Substring(5).Trim()+" ��","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					IsChangeExecDept = true;
					newExecDept = Convert.ToInt32(cmbExecDept.Text.Substring(0,2).Trim());
				}
				else
				{
					cmbExecDept.SelectedIndex=-1;
					cmbExecDept.Text="";
					return;
				}
			}

            if (chkDate.Checked)
            {
                execDateTime = DateExecDate.Value;
            }

			this.Close();
		}

		private void frmBRFS_Load(object sender, System.EventArgs e)
		{
			if(nType==1)
				chkExecDept.Enabled=true;
			else
				chkExecDept.Enabled=false;

			AddExecDept();

            execDateTime = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            this.DateExecDate.Value = execDateTime;//��������ǰϵͳ����
            this.DateExecDate.MaxDate = Convert.ToDateTime(execDateTime.Date.AddDays(Convert.ToInt32((new SystemCfg(7006)).Config)).ToShortDateString() + " 23:59:59");					//ϵͳ����    -��С
            System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32((new SystemCfg(7007)).Config), 0, 0, 0);
            this.DateExecDate.MinDate = Convert.ToDateTime(execDateTime.Subtract(diff).ToShortDateString() + " 23:59:59");	    //ϵͳ����-Static_Exec_MaxDays -���

			rbѡ����_Click(sender, e);
		}

		private void chkExecDept_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbExecDept.Enabled=chkExecDept.Checked;
		}

		private void AddExecDept()
		{
//			cmbExecDept.Items.Add("88 | ����ҩ��");
//			cmbExecDept.Items.Add("42 | ������ҩ��");
//			cmbExecDept.Items.Add("43 | ������ҩ��");
//			cmbExecDept.Items.Add("44 | ���ҳ�ҩ��");
		}

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            DateExecDate.Enabled = chkDate.Checked;
        }
	}
}
