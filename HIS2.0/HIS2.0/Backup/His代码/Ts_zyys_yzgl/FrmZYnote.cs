using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
	/// <summary>
	/// ��ҩ��ע ��ժҪ˵����
	/// </summary>
	public class FrmZYnote : System.Windows.Forms.Form
	{
		public string note="";
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbNote;
		private System.Windows.Forms.TextBox txtNote;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmZYnote()
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
			this.cmbNote = new System.Windows.Forms.ComboBox();
			this.txtNote = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbNote
			// 
			this.cmbNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNote.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmbNote.Items.AddRange(new object[] {
														 "�ȼ�",
														 "����",
														 "����",
														 "���",
														 "���",
														 "�Ȼ�",
														 "���",
														 "������ˮ"});
			this.cmbNote.Location = new System.Drawing.Point(96, 16);
			this.cmbNote.Name = "cmbNote";
			this.cmbNote.Size = new System.Drawing.Size(128, 21);
			this.cmbNote.TabIndex = 0;
			this.cmbNote.SelectedIndexChanged += new System.EventHandler(this.cmbNote_SelectedIndexChanged);
			// 
			// txtNote
			// 
			this.txtNote.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtNote.Location = new System.Drawing.Point(96, 48);
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(128, 23);
			this.txtNote.TabIndex = 1;
			this.txtNote.Text = "������";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "��עѡ��";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "��ע���ݣ�";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.button1.Location = new System.Drawing.Point(87, 85);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "ȷ��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmZYnote
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(248, 119);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNote);
			this.Controls.Add(this.cmbNote);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmZYnote";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "��ҩ��ע";
			this.Load += new System.EventHandler(this.FrmZYnote_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmbNote_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.txtNote.Text.Trim()=="") this.txtNote.Text=this.cmbNote.Text;
			else this.txtNote.Text+="��"+this.cmbNote.Text;
		
		}

		private void FrmZYnote_Load(object sender, System.EventArgs e)
		{
			this.txtNote.Text="";
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			note=this.txtNote.Text.Trim();
			this.Close();
		}

		
	}
}
