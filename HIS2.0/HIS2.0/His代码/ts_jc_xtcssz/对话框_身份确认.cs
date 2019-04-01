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

namespace ts_jc_xtcssz
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class frmInPassword : System.Windows.Forms.Form
	{
		//private BaseFunc myFunc = new BaseFunc();
		public bool isLogin=false;
		//public bool isHSZ=false;//�Ƿ�ʿ��

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Trasen.Editor.TextEdit txtOld;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btExit;
		private System.Windows.Forms.Button btOK;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInPassword()
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtOld = new Trasen.Editor.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("����_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "������";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "���ã����������룺";
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(80, 64);
            this.txtOld.MaxLength = 20;
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '*';
            this.txtOld.PassWordInput = true;
            this.txtOld.Size = new System.Drawing.Size(148, 21);
            this.txtOld.TabIndex = 0;
            this.txtOld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOld_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-2, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 8);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(168, 120);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(82, 24);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "ȡ��(&C)";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(40, 120);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 24);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "ȷ��(O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // frmInPassword
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(292, 157);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 184);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 184);
            this.Name = "frmInPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���ȷ��";
            this.Load += new System.EventHandler(this.frmInPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmInPassword_Load(object sender, System.EventArgs e)
		{
			this.label1.Text=FrmMdiMain.CurrentUser.Name;
			this.txtOld.Focus();
			this.isLogin=false;
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			FrmMdiMain.CurrentUser.Retrieve();
			if(!FrmMdiMain.CurrentUser.CheckPassword(txtOld.TextPass))
			{
				MessageBox.Show(this, "�Բ�������������벻��ȷ�����������룡", "����", MessageBoxButtons.OK,MessageBoxIcon.Error); 
				this.txtOld.Focus();	
				return;
			}

			//this.isHSZ=myFunc.IsHSZ(FrmMdiMain.CurrentUser.EmployeeId);
			this.isLogin=true;
			this.Close();
		}

		private void txtOld_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{
				this.btOK.Focus();				
			}

		}
	}
}
