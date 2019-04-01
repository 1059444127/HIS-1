using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// ListViewEx ��ժҪ˵����
	/// </summary>
	public class ListViewEx : System.Windows.Forms.ListView
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// ListViewEx
		/// </summary>
		/// <param name="container"></param>
		public ListViewEx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}
		/// <summary>
		/// ����ListViewEx
		/// </summary>
		public ListViewEx()
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
		/// ��дOnColumnClick
		/// </summary>
		/// <param name="e"></param>
		protected override void OnColumnClick(System.Windows.Forms.ColumnClickEventArgs e)
		{
			string headerText=null;
			int endIndex;
			int upIndex=this.Columns[e.Column].Text.LastIndexOf("��");
			int downIndex=this.Columns[e.Column].Text.LastIndexOf("��");
			//��ȥ�������е������ͷ
			for(int i=0;i<this.Columns.Count;i++)
			{
				headerText=this.Columns[i].Text;
				endIndex=headerText.LastIndexOf("��");
				if(endIndex<0)
				{
					endIndex=headerText.LastIndexOf("��");
				}
				if(endIndex>0)
				{
					this.Columns[i].Text=headerText.Substring(0,endIndex);
					break;
				}
			}
			if(upIndex<0 && downIndex<0)
			{
				this.ListViewItemSorter=new ListViewItemUpComparer(e.Column);
				this.Columns[e.Column].Text =this.Columns[e.Column].Text+"��";
			}
			else
			{
				if(upIndex>0)
				{
					this.ListViewItemSorter=new ListViewItemDownComparer(e.Column);
					this.Columns[e.Column].Text =this.Columns[e.Column].Text+"��";
				}
				else
				{
					this.ListViewItemSorter=new ListViewItemUpComparer(e.Column);
					this.Columns[e.Column].Text =this.Columns[e.Column].Text+"��";
				}
			}
			this.Sort();
			base.OnColumnClick (e);
		}
	}
	/// <summary>
	/// ��������IComparer
	/// </summary>
	public class ListViewItemUpComparer : IComparer 
	{
		private int col;
		/// <summary>
		/// ���캯��
		/// </summary>
		public ListViewItemUpComparer() 
		{
			col=0;
		}
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="column"></param>
		public ListViewItemUpComparer(int column) 
		{
			col=column;
		}
		/// <summary>
		/// ����Ƚ�
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) 
		{
			string yText=((ListViewItem)y).SubItems[col].Text;
			string xText=((ListViewItem)x).SubItems[col].Text;
			if(Convertor.IsNumeric(yText) && Convertor.IsNumeric(xText))
			{
				decimal result=Convert.ToDecimal(xText)-Convert.ToDecimal(yText);
				if(result>0)
					return 1;
				else if(result==0)
					return 0;
				else 
					return -1;
			}
			else
			{
				return String.Compare(xText,yText);
			}
		}
	}
	/// <summary>
	/// ��������IComparer
	/// </summary>
	public class ListViewItemDownComparer : IComparer 
	{
		private int col;
		/// <summary>
		/// ���캯��
		/// </summary>
		public ListViewItemDownComparer() 
		{
			col=0;
		}
		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="column"></param>
		public ListViewItemDownComparer(int column) 
		{
			col=column;
		}
		/// <summary>
		/// ����Ƚ�
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y) 
		{
			string yText=((ListViewItem)y).SubItems[col].Text;
			string xText=((ListViewItem)x).SubItems[col].Text;
			if(Convertor.IsNumeric(yText) && Convertor.IsNumeric(xText))
			{
				decimal result=Convert.ToDecimal(yText)-Convert.ToDecimal(xText);
				if(result>0)
					return 1;
				else if(result==0)
					return 0;
				else 
					return -1;
			}
			else
			{
				return String.Compare(yText, xText);
			}
		}
	}
}
