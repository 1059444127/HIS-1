using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenFrame.Forms
{
	/// <summary>
	/// �Զ����InputBox�Ի���
	/// </summary>
	public class DlgInputBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOk;
		private System.Windows.Forms.Label lbText;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// �Ի�����
		/// </summary>
		public static bool DlgResult;
		/// <summary>
		/// �Ի��򷵻�ֵ
		/// </summary>
		public static string DlgValue;
		/// <summary>
		/// ���ֿ���
		/// </summary>
		public bool NumCtrl;
		/// <summary>
		/// �Ƿ�ʹ��PasswordChar����
		/// </summary>
		public bool HideChar;	
		/// <summary>
		/// �����ַ�
		/// </summary>
		public char PasswordChar;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// ���캯��
		/// </summary>
		public DlgInputBox()
		{
			DlgValue="";
			InitializeComponent();
			DlgResult=false;
			NumCtrl=false;
			HideChar=false;
		}
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="DefaultValue">Ĭ��ֵ</param>
		/// <param name="strText">˵������</param>
		/// <param name="strCaption">��������</param>
		public DlgInputBox(string DefaultValue,string strText,string strCaption)
		{
			InitializeComponent();
			lbText.Text=strText;
			this.Text=strCaption;
			DlgResult=false;
			DlgValue=DefaultValue;
			txtInput.Text=DefaultValue;
			HideChar=false;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgInputBox));
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btOk = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.lbText = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(12, 78);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(366, 21);
			this.txtInput.TabIndex = 0;
			this.txtInput.Text = "";
			// 
			// btOk
			// 
			this.btOk.Location = new System.Drawing.Point(300, 16);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(80, 24);
			this.btOk.TabIndex = 1;
			this.btOk.Text = "ȷ��(&O)";
			this.btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(300, 46);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(80, 24);
			this.btCancel.TabIndex = 2;
			this.btCancel.Text = "ȡ��(&C)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// lbText
			// 
			this.lbText.Location = new System.Drawing.Point(56, 16);
			this.lbText.Name = "lbText";
			this.lbText.Size = new System.Drawing.Size(238, 54);
			this.lbText.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 32);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// DlgInputBox
			// 
			this.AcceptButton = this.btOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(396, 136);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lbText);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOk);
			this.Controls.Add(this.txtInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "DlgInputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DlgInputBox";
			this.Load += new System.EventHandler(this.DlgInputBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btOk_Click(object sender, System.EventArgs e)
		{
			if(NumCtrl)
			{
				if(!Convertor.IsNumeric(txtInput.Text))
				{
					MessageBox.Show("�Ƿ�����ֵ,���������֣�");
					return;
				}
			}
			DlgResult=true;
			DlgValue=txtInput.Text.Trim();
			this.Close();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			DlgResult=false;
			this.Close();
		}

		private void DlgInputBox_Load(object sender, System.EventArgs e)
		{
			if(HideChar)
			{
				if(PasswordChar.ToString().Trim()=="")
					txtInput.PasswordChar='*';
				else
					txtInput.PasswordChar=PasswordChar; 
			}
		}
	}
	/// <summary>
	/// InputBox��̬����
	/// </summary>
	public class DlgInputBoxStatic
	{
		/// <summary>
		/// ����״̬(DialogResult.Ok����DialogResult.Cancel)
		/// </summary>
		public static DialogResult dlgResult = DialogResult.Cancel;
		
		/// <summary>
		/// ��̬����InputBox�Ի���
		/// </summary>
		/// <param name="prompt">˵������</param>
		/// <param name="title">��������</param>
		/// <param name="defaultValue">Ĭ��ֵ</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// ��̬����InputBox�Ի���
		/// </summary>
		/// <param name="prompt">˵������</param>
		/// <param name="title">��������</param>
		/// <param name="defaultValue">Ĭ��ֵ</param>
		/// <param name="numCtrl">�Ƿ�ֻ������������</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// ��̬����InputBox�Ի���
		/// </summary>
		/// <param name="prompt">˵������</param>
		/// <param name="title">��������</param>
		/// <param name="defaultValue">Ĭ��ֵ</param>
		/// <param name="numCtrl">�Ƿ�ֻ������������</param>
		/// <param name="hideChar">�Ƿ���������ֵ</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl,bool hideChar)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.HideChar =hideChar;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
		/// <summary>
		/// ��̬����InputBox�Ի���
		/// </summary>
		/// <param name="prompt">˵������</param>
		/// <param name="title">��������</param>
		/// <param name="defaultValue">Ĭ��ֵ</param>
		/// <param name="numCtrl">�Ƿ�ֻ������������</param>
		/// <param name="hideChar">�Ƿ���������ֵ</param>
		/// <param name="passwordChar">�����ַ�</param>
		/// <returns></returns>
		public static string InputBox(string prompt,string title,string defaultValue,bool numCtrl,bool hideChar,char passwordChar)
		{
			DlgInputBox dlgInputBox=new DlgInputBox(defaultValue,prompt,title);
			dlgInputBox.NumCtrl =numCtrl;
			dlgInputBox.HideChar =hideChar;
			dlgInputBox.PasswordChar=passwordChar;
			dlgInputBox.ShowDialog();
			if(DlgInputBox.DlgResult)
			{
				dlgResult = DialogResult.OK;
				return DlgInputBox.DlgValue;
			}
			else
			{
				dlgResult = DialogResult.Cancel;
				return null;
				
			}
		}
	}
}
