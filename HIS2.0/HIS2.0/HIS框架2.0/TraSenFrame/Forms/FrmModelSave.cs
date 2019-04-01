using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TrasenFrame.Forms
{
	/// <summary>
	/// FrmModelSave ��ժҪ˵����
	/// </summary>
	public class FrmModelSave : System.Windows.Forms.Form
	{
        /// <summary>
        /// ģ������
        /// </summary>
		public string ModelName="";
		/// <summary>
		/// ģ������0=ȫԺ1=����2=����
		/// </summary>
        public int model_type = 0;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoAll;
		private System.Windows.Forms.RadioButton rdoDept;
		private System.Windows.Forms.RadioButton rdoUser;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmModelSave(string _text)
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

            this.Text = _text;
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoUser = new System.Windows.Forms.RadioButton();
            this.rdoDept = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoUser);
            this.groupBox2.Controls.Add(this.rdoDept);
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ģ������";
            // 
            // rdoUser
            // 
            this.rdoUser.Location = new System.Drawing.Point(210, 24);
            this.rdoUser.Name = "rdoUser";
            this.rdoUser.Size = new System.Drawing.Size(87, 24);
            this.rdoUser.TabIndex = 3;
            this.rdoUser.Tag = "3";
            this.rdoUser.Text = "����(&U)";
            // 
            // rdoDept
            // 
            this.rdoDept.Checked = true;
            this.rdoDept.Location = new System.Drawing.Point(113, 24);
            this.rdoDept.Name = "rdoDept";
            this.rdoDept.Size = new System.Drawing.Size(87, 24);
            this.rdoDept.TabIndex = 2;
            this.rdoDept.TabStop = true;
            this.rdoDept.Tag = "2";
            this.rdoDept.Text = "����(&D)";
            // 
            // rdoAll
            // 
            this.rdoAll.Enabled = false;
            this.rdoAll.Location = new System.Drawing.Point(16, 24);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(87, 24);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.Tag = "0";
            this.rdoAll.Text = "ȫԺ(&A)";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(88, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 26);
            this.txtName.TabIndex = 0;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ģ������";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(132, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 32);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "ȷ��(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(236, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "ȡ��(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmModelSave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModelSave";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ģ�汣��";
            this.Load += new System.EventHandler(this.FrmModelSave_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void FrmModelSave_Load(object sender, System.EventArgs e)
        {
            txtName.Focus();

            rdoAll.Enabled = FrmMdiMain.CurrentUser.IsAdministrator;
        }

		private void txtName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				btnOk_Click(sender,e);
				DialogResult = DialogResult.OK;
			}
			else if (e.KeyChar == 27)
			{
                DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if (txtName.Text.Trim()=="")
			{
				MessageBox.Show(this,"������ģ�����ƣ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtName.Focus();
				return;
			}
			else
				ModelName=txtName.Text.Trim();

			if (rdoAll.Checked)
				model_type=0;
			else if (rdoDept.Checked)
				model_type=1;
			else
				model_type=2;

            this.DialogResult = DialogResult.OK;
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
	}
}
