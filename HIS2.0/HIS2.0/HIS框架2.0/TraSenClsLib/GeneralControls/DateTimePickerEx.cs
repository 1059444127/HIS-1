using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// TextBox ��ժҪ˵��:��ȡ������ɫ���뿪�����ָ�Ϊԭ����ɫ
	/// </summary>
	public class DateTimePickerEx : DateTimePicker
	{
		private Color _enterBackColor;
		private Color _oldBackColor;
		private Color _enterForeColor;
		private Color _oldForeColor;
		
		private Control _nextControl;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �Զ���TextBox(��ȡ������ɫ���뿪�����ָ�Ϊԭ����ɫ)
		/// </summary>
		/// <param name="container"></param>
		public DateTimePickerEx(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms ��׫д�����֧���������
			///
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		///�Զ���TextBox(��ȡ������ɫ���뿪�����ָ�Ϊԭ����ɫ)
		/// </summary>
		public DateTimePickerEx()
		{
			///
			/// Windows.Forms ��׫д�����֧���������
			///
			InitializeComponent();
			_enterForeColor=SystemColors.WindowText;
			_enterBackColor=SystemColors.Window;
			_oldBackColor=this.BackColor;
			_oldForeColor=this.ForeColor;
			_nextControl=null;
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

		#region ����
		/// <summary>
		/// ��ý�����ǰ��ɫ
		/// </summary>
		[DefaultValue("WindowText"),Description("��ȡ������ǰ��ɫ"),Category("Appearance")]
		public Color EnterForeColor
		{
			get
			{
				return _enterForeColor;
			}
			set 
			{
				_enterForeColor=value;
			}
		}/// <summary>
		/// ��ý����ı���ɫ
		/// </summary>
		[DefaultValue("Window"),Description("��ȡ�����ı���ɫ"),Category("Appearance")]
		public Color EnterBackColor
		{
			get
			{
				return _enterBackColor;
			}
			set 
			{
				_enterBackColor=value;
			}
		}
		/// <summary>
		/// ��SelectionStart=SelectionLengthʱ���ҷ���������ÿؼ�
		/// </summary>
		[DefaultValue("NULL"),Description("��SelectionStart=SelectionLengthʱ���ҷ���������ÿؼ�"),Category("Behavior")]
		public Control NextControl
		{
			get
			{
				return _nextControl;
			}
			set 
			{
				_nextControl=value;
			}
		}
		#endregion

		#region ��д�¼�
		/// <summary>
		/// ��дOnKeyDown�¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter && _nextControl!=null && _nextControl.CanFocus)
			{
				_nextControl.Focus();
			}
			base.OnKeyDown (e);
		}
		/// <summary>
		/// ��дOnEnter�¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnter(EventArgs e)
		{
			this.ForeColor =_enterForeColor;
			this.BackColor =_enterBackColor;
			base.OnEnter (e);
		}
		/// <summary>
		///  ��дOnLeave�¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			this.ForeColor =_oldForeColor;
			this.BackColor =_oldBackColor;
			base.OnLeave (e);
		}

		#endregion
	}
}
