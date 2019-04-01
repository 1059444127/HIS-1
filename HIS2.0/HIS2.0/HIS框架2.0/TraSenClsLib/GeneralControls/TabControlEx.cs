using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// TabControlEx ��ժҪ˵��
	/// �ؼ���tabPage��text������ʾ�����ŵ�����
	/// </summary>
	public class TabControlEx : System.Windows.Forms.TabControl
	{
		private Color _tabPageTextForeColor;
		private Color _tabPageTextBackColor;
		private Color _tabPageTextCurBackColor;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �Զ���TabControl
		/// </summary>
		/// <param name="container"></param>
		public TabControlEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			_tabPageTextForeColor=SystemColors.WindowText;
			_tabPageTextBackColor=SystemColors.Control;
			_tabPageTextCurBackColor=SystemColors.Control;

		}
		/// <summary>
		/// ���캯��
		/// </summary>
		public TabControlEx()
		{
			InitializeComponent();
			_tabPageTextForeColor=SystemColors.WindowText;
			_tabPageTextBackColor=SystemColors.Control;
			_tabPageTextCurBackColor=SystemColors.Control;

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


		#region �Զ�������
		/// <summary>
		/// TabPage��Textǰ����ɫ
		/// </summary>
		[DefaultValue("Control"),Description("TabPage��Textǰ����ɫ"),Category("Appearance")]
		public Color TabPageTextForeColor
		{
			get
			{
				return _tabPageTextForeColor;
			}
			set 
			{
				_tabPageTextForeColor=value;
			}
		}
		/// <summary>
		/// TabPage��Text������ɫ
		/// </summary>
		[DefaultValue("Control"),Description("TabPage��Textǰ����ɫ"),Category("Appearance")]
		public Color TabPageTextBackColor
		{
			get
			{
				return _tabPageTextBackColor;
			}
			set 
			{
				_tabPageTextBackColor=value;
			}
		}
		/// <summary>
		/// TabControl��ǰTabPage��Text������ɫ
		/// </summary>
		[DefaultValue("Control"),Description("TabControl��ǰTabPage��Text������ɫ"),Category("Appearance")]
		public Color TabPageTextCurBackColor
		{
			get
			{
				return _tabPageTextCurBackColor;
			}
			set 
			{
				_tabPageTextCurBackColor=value;
			}
		}
		#endregion

		#region ��д�¼�
		/// <summary>
		/// ��дOnDrawItem�¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
		{
			Rectangle tabArea;
			RectangleF tabTextArea;
			tabArea = this.GetTabRect(e.Index);			//��Ҫ������ת�������TAB���RECTANGELF
			tabTextArea = (RectangleF)(this.GetTabRect(e.Index));
			StringFormat sf=new StringFormat();			//��װ�ı�������Ϣ
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;				
			SolidBrush brush=new SolidBrush(_tabPageTextForeColor);  
			//���Ʊ����Ļ���
			SolidBrush backBrush;
			if(this.SelectedIndex==e.Index)				//ѡ��ҳ
			{
				backBrush=new SolidBrush(_tabPageTextCurBackColor);
			}
			else
			{
				backBrush=new SolidBrush(_tabPageTextBackColor);
			}
			e.Graphics.FillRectangle(backBrush,tabArea);
			//��������
			e.Graphics.DrawString(this.TabPages[e.Index].Text,this.Font,brush,tabTextArea,sf);
			base.OnDrawItem (e);
		}

		#endregion
	}
}
