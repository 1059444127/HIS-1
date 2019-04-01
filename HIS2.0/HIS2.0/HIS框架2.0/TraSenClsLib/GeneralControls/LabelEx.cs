using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// LabelEx��ժҪ˵����
	/// </summary>
	public class LabelEx : Label
	{
		private Color _BackColor1=SystemColors.ControlDarkDark;
		private Color _BackColor2=Color.AliceBlue;
		
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �Զ���Label(�н�����Զ��屳��ɫ)
		/// </summary>
		/// <param name="container"></param>
		public LabelEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// �Զ���Label(�н�����Զ��屳��ɫ)
		/// </summary>
		public LabelEx()
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
		
		#region ����
		/// <summary>
		/// ��ɫ����ĵ�һ����ɫ
		/// </summary>
		[DefaultValue("ControlDarkDark"),Description("��ɫ����ĵ�һ����ɫ"),Category("Appearance")]
		public Color BackColor1
		{
			get { return _BackColor1; }
			set 
			{
				_BackColor1 = value; 
				Invalidate();
			}
		}
		/// <summary>
		/// ��ɫ����ĵڶ�����ɫ
		/// </summary>
		[DefaultValue("AliceBlue"),Description("��ɫ����ĵڶ�����ɫ"),Category("Appearance")]
		public Color BackColor2
		{
			get { return _BackColor2; }
			set 
			{
				_BackColor2 = value; 
				Invalidate();
			}
		}

		#endregion


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
		/// OnPaint
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			using(Brush MyBrush = new System.Drawing.Drawing2D.LinearGradientBrush( ClientRectangle, _BackColor1,_BackColor2, 10 ))
			{
				e.Graphics.FillRectangle(MyBrush,0,0,this.Size.Width ,this.Size.Height);
			}
			base.OnPaint (e);
		}

	}
}
