using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// XcjwRichTextBox ��ժҪ˵����
	/// </summary>
	public class RichTextBoxEx : System.Windows.Forms.RichTextBox
	{
		/// <summary>
		/// �Ƿ�ʹ�á�����������������ݿ��Ա�Ϊ������
		/// </summary>
		private bool boolLinkStyle=false;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// ʵ����
		/// </summary>
		/// <param name="container"></param>
		public RichTextBoxEx(System.ComponentModel.IContainer container)
		{
		
			container.Add(this);
			InitializeComponent();
		}
		/// <summary>
		/// ʵ����
		/// </summary>
		public RichTextBoxEx()
		{
			InitializeComponent();
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

		/// <summary>
		/// �Ƿ�ʹ�á������ж���ֵΪ������
		/// </summary>
		public bool LinkStyle
		{
			get{return boolLinkStyle;}
			set{boolLinkStyle = value;}
		}

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// ��дMouseMove
		/// </summary>
		/// <param name="e">����ƶ��¼�</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			bool CursorFlag = false;
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				string strLine;
				char ch;
				
				if (this.Text=="") return;

				ch = this.GetCharFromPosition(new Point(e.X,e.Y));
				intCharIndex = this.GetCharIndexFromPosition(new Point(e.X,e.Y));
				if (ch != '��' && ch != '��')
				{
					intLine = this.GetLineFromCharIndex(intCharIndex);
					strLine = this.Text;
					if ((strLine.Substring(0,intCharIndex).LastIndexOf("��")>=0 && strLine.IndexOf("��",intCharIndex)>=0) &&
						((strLine.Substring(0,intCharIndex).LastIndexOf("��")>=0 && strLine.IndexOf("��",intCharIndex)<0) ||
						(strLine.IndexOf("��",intCharIndex)>strLine.IndexOf("��",intCharIndex)) &&
						(strLine.IndexOf("��",intCharIndex)>=0 && (strLine.IndexOf("��",intCharIndex)>strLine.IndexOf("��",intCharIndex)))))
						CursorFlag = true;
				}
			}
			if (CursorFlag)
				this.Cursor = Cursors.Hand;
			else
				this.Cursor = Cursors.IBeam;
			base.OnMouseMove (e);
		}
		/// <summary>
		/// ��дMouseDown
		/// </summary>
		/// <param name="e">��갴���¼�</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				int intStart;
				int intEnd=0;
				string strLine;
				char ch;

				if (this.Text=="") return;

				ch = this.GetCharFromPosition(new Point(e.X,e.Y));
				intCharIndex = this.GetCharIndexFromPosition(new Point(e.X,e.Y));
				if (this.Cursor == Cursors.Hand)
				{
					if (ch != '��' && ch != '��')
					{
						intLine = this.GetLineFromCharIndex(intCharIndex);
						strLine = this.Text;
						intStart = strLine.Substring(0,intCharIndex).LastIndexOf("��");
						intEnd = strLine.IndexOf("��",intCharIndex);
						if ((intEnd >= 0) && (intStart >= 0))
							this.OnLinkClicked(new LinkClickedEventArgs(strLine.Substring(intStart + 1,intEnd - intStart - 1)));
					}
					this.Select(intEnd,0);
				}
			}
			base.OnMouseDown (e);
		}

		#region ���� OnTextChanged
		/*
		protected override void OnTextChanged(EventArgs e)
		{
			if (boolLinkStyle)
			{
				int intCharIndex;
				int intLine;
				int intCurIdx;
				string strLine;
				char ch;
				Font newFont;
				Font oldFont;
				Color oldColor;
				
				oldFont = this.Font;
				newFont = new Font(oldFont,FontStyle.Underline);
				oldColor = this.ForeColor;
				intCurIdx = this.SelectionStart;
				this.SelectAll();
				this.SelectionFont=oldFont;
				this.SelectionColor=oldColor;
				
				for(int i=0;i<this.TextLength;i++)
				{
					ch = Convert.ToChar(this.Text.Substring(i,1));
					intCharIndex = i;
					if (ch != '��' && ch != '��')
					{
						intLine = this.GetLineFromCharIndex(intCharIndex);
						strLine = this.Text;
						if ((strLine.Substring(0,intCharIndex).LastIndexOf("��")>=0 && strLine.IndexOf("��",intCharIndex)>=0) &&
							((strLine.Substring(0,intCharIndex).LastIndexOf("��")>=0 && strLine.IndexOf("��",intCharIndex)<0) ||
							(strLine.IndexOf("��",intCharIndex)>strLine.IndexOf("��",intCharIndex)) &&
							(strLine.IndexOf("��",intCharIndex)>=0 && (strLine.IndexOf("��",intCharIndex)>strLine.IndexOf("��",intCharIndex)))))
						{
							this.Select(intCharIndex,1);
							this.SelectionColor = Color.Blue;
							this.SelectionFont = newFont;
						}
					}
				}
				this.Select(intCurIdx,0);
			}
			base.OnTextChanged (e);
		}
		*/
		#endregion
	}
}
