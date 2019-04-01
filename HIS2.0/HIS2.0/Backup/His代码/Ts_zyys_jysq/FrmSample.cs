using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Ts_zyys_jysq
{
	/// <summary>
	/// FrmSample ��ժҪ˵����
	/// </summary>
	public class FrmSample : System.Windows.Forms.Form
	{
		public string item="";
		public string sample="";
		public int sampleCode=0;
		public DataTable sampleTb=new DataTable();
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbSample;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSample()
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbSample = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(208, 64);
			this.button1.Name = "button1";
			this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.button1.TabIndex = 0;
			this.button1.Text = "ȷ��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "���";
			// 
			// cmbSample
			// 
			this.cmbSample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSample.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbSample.Location = new System.Drawing.Point(32, 64);
			this.cmbSample.Name = "cmbSample";
			this.cmbSample.Size = new System.Drawing.Size(120, 22);
			this.cmbSample.TabIndex = 2;
			// 
			// FrmSample
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(320, 117);
			this.Controls.Add(this.cmbSample);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSample";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ָ���ͼ�걾";
			this.Load += new System.EventHandler(this.FrmSample_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmSample_Load(object sender, System.EventArgs e)
		{
			this.label1.Text="��Ϊ��Ŀ��"+this.item+"��ָ���ͼ�걾��";

			this.cmbSample.Items.Clear();
			this.cmbSample.DataSource=this.sampleTb;
			this.cmbSample.DisplayMember="NAME";
			this.cmbSample.ValueMember="CODE";			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.sampleCode=Convert.ToInt32(this.cmbSample.SelectedValue);
			this.Close();
		}
	}
}
