using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
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
	public class frmInputDate : System.Windows.Forms.Form
	{
		public bool result=false;
		public bool isDefalut=true;
		public System.Windows.Forms.DateTimePicker DtpbeginDate;
		public System.Windows.Forms.TextBox textBox1;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioButton2;
		
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInputDate()
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
            this.label1 = new System.Windows.Forms.Label();
            this.DtpbeginDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "�������˵�ֹͣʱ�䣺";
            // 
            // DtpbeginDate
            // 
            this.DtpbeginDate.CalendarFont = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DtpbeginDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DtpbeginDate.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpbeginDate.Location = new System.Drawing.Point(32, 32);
            this.DtpbeginDate.Name = "DtpbeginDate";
            this.DtpbeginDate.ShowUpDown = true;
            this.DtpbeginDate.Size = new System.Drawing.Size(176, 23);
            this.DtpbeginDate.TabIndex = 1;
            this.DtpbeginDate.Value = new System.DateTime(2003, 9, 20, 19, 22, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 8);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(136, 144);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 24);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "ȡ��(&E)";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(24, 144);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(80, 24);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "ȷ��(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 82);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 24);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ĭ��ֵ";
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "������ĩ��ִ�д�����";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(24, 106);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 24);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.Text = "�趨ֵ��";
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(96, 106);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 11;
            // 
            // frmInputDate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(240, 173);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.DtpbeginDate);
            this.Controls.Add(this.label1);
            this.Name = "frmInputDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "����ʱ��";
            this.Load += new System.EventHandler(this.frmInputDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInputDate_Load(object sender, System.EventArgs e)
		{
			this.DtpbeginDate.Value=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);                      //��������ǰϵͳ����
			this.DtpbeginDate.MaxDate=Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString() + " 23:59:59");					//ϵͳ����    -���
			System.TimeSpan diff = new System.TimeSpan(Convert.ToInt32((new SystemCfg(7007)).Config), 0, 0, 0);  			
			this.DtpbeginDate.MinDate=DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).Subtract(diff);	    //ϵͳ����-Begin_MinDays�� -��С	
		}

		private void radioButton1_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Text="";
		}

		private void radioButton2_Click(object sender, System.EventArgs e)
		{
			this.textBox1.Enabled=true;
			this.textBox1.Text="1";
		}


		private void btOK_Click(object sender, System.EventArgs e)
		{

			if (this.radioButton2.Checked && this.textBox1.Text.Trim()=="")
			{
				MessageBox.Show(this,"�Բ���ĩ��ִ�д���������Ϊ�գ�", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
				return;
			}
			if (MessageBox.Show(this, "ȷ��ֹͣѡ��ĳ����˵���", "ȷ��", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No) return;				
			this.result=true;
			this.isDefalut=this.radioButton1.Checked?true:false;
		    this.Close();
		}

		
	}
}
