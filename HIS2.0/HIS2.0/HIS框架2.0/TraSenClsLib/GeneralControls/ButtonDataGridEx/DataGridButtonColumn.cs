using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TrasenClasses.GeneralControls
{
	/// <summary>
	/// DataGridButtonColumn ��ժҪ˵����
	/// </summary>
	public class DataGridButtonColumn:DataGridTextBoxColumn
	{
		/// <summary>
		/// ���������а�ť�����¼�
		/// </summary>
		public event DataGridCellButtonClickEventHandler CellButtonClicked;

		private Bitmap _buttonFace;
		private Bitmap _buttonFacePressed;
		private int _columnNum;
		private int _pressedRow;

		/// <summary>
		/// ��������������Column����
		/// </summary>
		/// <param name="colNum">������</param>
		public DataGridButtonColumn(int colNum)
		{
			_columnNum = colNum;
			_pressedRow = -1;

			try
			{
				
				System.IO.Stream strm =this.GetType().Assembly.GetManifestResourceStream("TrasenClasses.GeneralControls.ButtonDataGridEx.fullbuttonface.bmp");
				_buttonFace = new Bitmap(strm);
				strm = this.GetType().Assembly.GetManifestResourceStream("TrasenClasses.GeneralControls.ButtonDataGridEx.fullbuttonfacepressed.bmp");
				_buttonFacePressed = new Bitmap(strm);
			}
			catch(System.Exception err){System.Console.WriteLine(err.Message);}
		}
		/// <summary>
		/// ��д���෽��
		/// </summary>
		/// <param name="source"></param>
		/// <param name="rowNum"></param>
		/// <param name="bounds"></param>
		/// <param name="readOnly"></param>
		/// <param name="instantText"></param>
		/// <param name="cellIsVisible"></param>
		protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
		{ 
			// dont call the baseclass so no editing done...
			//	base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 
		} 
		/// <summary>
		/// ���ư�ť
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bm"></param>
		/// <param name="bounds"></param>
		/// <param name="row"></param>
		private void DrawButton(Graphics g, Bitmap bm, Rectangle bounds, int row)
		{
			try
			{
				DataGrid dg = this.DataGridTableStyle.DataGrid;
				string s = dg[row, this._columnNum].ToString();
				//string s=this.TextBox.Text;

				SizeF sz = g.MeasureString(s, dg.Font, bounds.Width - 4, StringFormat.GenericTypographic);

				int x = bounds.Left + Math.Max(0, (bounds.Width - (int)sz.Width)/2);
				g.DrawImage(bm, bounds, 0, 0, bm.Width, bm.Height,GraphicsUnit.Pixel);
			
				if(sz.Height < bounds.Height)
				{
					int y = bounds.Top + (bounds.Height - (int) sz.Height) / 2;
					if(_buttonFacePressed == bm)
					{
						x++;
					}

					g.DrawString(s, dg.Font, new SolidBrush(dg.ForeColor), x, y);
				}
			}
			catch(System.Exception err)
			{
				throw new Exception("��ʾ�ؼ�����"+err.Message);
			}
		}
		/// <summary>
		/// ����ƶ�������ť�¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void HandleMouseUp(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = (hti.Column == this._columnNum && hti.Row > -1);

			_pressedRow = -1;

			Rectangle rect = new Rectangle(0,0,0,0);

			if(isClickInCell)
			{
				rect = dg.GetCellBounds(hti.Row, hti.Column);
				isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
			}
			if(isClickInCell)
			{
				Graphics g = Graphics.FromHwnd(dg.Handle);
				//	g.DrawImage(this._buttonFace, rect.Right - this._buttonFace.Width, rect.Y);
				DrawButton(g, this._buttonFace, rect, hti.Row);
				g.Dispose();
				if(CellButtonClicked != null)
					CellButtonClicked(this, new DataGridCellButtonClickEventArgs(hti.Row, hti.Column));
			}
		}
		/// <summary>
		/// ��갴������ť�¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = (hti.Column == this._columnNum	&& hti.Row > -1);

			Rectangle rect = new Rectangle(0,0,0,0);
			if(isClickInCell)
			{
				rect = dg.GetCellBounds(hti.Row, hti.Column);
				isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
			}

			if(isClickInCell)
			{
				//Console.WriteLine("HandleMouseDown " + hti.Row.ToString());
				Graphics g = Graphics.FromHwnd(dg.Handle);
				//g.DrawImage(this._buttonFacePressed, rect.Right - this._buttonFacePressed.Width, rect.Y);
				DrawButton(g, _buttonFacePressed, rect, hti.Row);
				g.Dispose();
				_pressedRow = hti.Row;
			}
			//ʵ����ѡ��

			if(hti.Row>=0)
			{
				System.Data.DataTable tb=(System.Data.DataTable)dg.DataSource;
				if(tb==null) return;
				for(int i=0;i<tb.Rows.Count;i++)
				{
					dg.UnSelect(i);
				}

				dg.Select(hti.Row);
				dg.CurrentRowIndex=hti.Row;
			}
		}
		/// <summary>
		/// ��д���෽��
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bounds"></param>
		/// <param name="source"></param>
		/// <param name="rowNum"></param>
		/// <param name="backBrush"></param>
		/// <param name="foreBrush"></param>
		/// <param name="alignToRight"></param>
		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
		{
			//base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
			try
			{
				DataGrid parent = this.DataGridTableStyle.DataGrid;
				bool current = parent.IsSelected(rowNum) ||
					( parent.CurrentRowIndex == rowNum && 
					parent.CurrentCell.ColumnNumber == this._columnNum);

			
		
				//draw the button
				Bitmap bm = _pressedRow == rowNum ? this._buttonFacePressed : this._buttonFace;
				this.DrawButton(g, bm, bounds, rowNum);
			}
			catch(System.Exception err)
			{
				throw new Exception("���ư�ť����\n"+err.Message);
			}
			//font.Dispose();
		
		}

	}
}
