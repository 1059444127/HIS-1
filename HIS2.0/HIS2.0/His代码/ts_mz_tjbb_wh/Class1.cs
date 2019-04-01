using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Windows.Forms; 
using System.Drawing; 

namespace Utility 
{ 
    public class exGridView 
    { 
        #region �ϲ���ʱʹ�õ���λ�úʹ�С���� 
        int cTop = 0;//���ϲ���ͷ����Ķ������� 
        int cLeft = 0;//���ϲ���ͷ������������ 
        /// <summary> 
        /// ���ϲ���ͷ����Ŀ� 
        /// </summary> 
        int cWidth = 0; 
        int cHeight = 0;//�������� 
        #endregion  
        /// <summary> 
        /// �ж��Ƿ��Ѿ���datagridview�ı�ͷ����ˣ�ֻ����һ�Ρ� 
        /// </summary> 
        public static bool isEnLarged = false; 

        /// <summary> 
        /// �ϲ���ͷ,����dataGridView��CellPainting�¼��С� 
        /// </summary> 
        /// <param name="sender">��Ҫ�ػ��dataGridview</param> 
        /// <param name="e">CellPainting�еĲ���</param> 
        ///<param name="colName">�еļ���(�б����������ģ���һ�з�����ǰ��)</param> 
        /// <param name="headerText">�кϲ�����ʾ���ı�</param> 
        public void MergeHeader(object sender, DataGridViewCellPaintingEventArgs e,List<string> colNameCollection,string headerText) 
        { 
            if (e.RowIndex == -1) 
            { 
                DataGridView dataGridView1=sender as DataGridView; 
                string colName = dataGridView1.Columns[e.ColumnIndex].Name; 
                if (!isEnLarged) 
                { 
                    //0.��չ��ͷ�߶�Ϊ��ǰ��2�� 
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; 
                    dataGridView1.ColumnHeadersHeight = e.CellBounds.Height * 2; 
                    isEnLarged = true; 
                } 
                if (colNameCollection.Contains(colName)) 
                { 
                    #region �ػ���ͷ 
                    //1.����colLen���е����� 
                    if (colNameCollection.IndexOf(colName)==0) 
                    { 
                        cTop = e.CellBounds.Top; 
                        cLeft = e.CellBounds.Left;                         

                        cWidth = e.CellBounds.Width; 
                        cHeight = e.CellBounds.Height/2; 

                        foreach(string colNameItem in colNameCollection) 
                        { 
                            if (colNameItem.Equals(colName)) 
                            {//��ȥ�Լ�һ��������֮��colLen-1���еĿ� 
                                continue; 
                            }  
                            cWidth += dataGridView1.Columns[colNameItem].Width;                            
                        }                        
                    } 

                    Rectangle cArea = new Rectangle(cLeft, cTop, cWidth, cHeight); 
                    //2.����������Ϊ����ɫ��û���еķ��߼��κ����֡� 
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor)) 
                    { 
                        e.Graphics.FillRectangle(backColorBrush, cArea); 

                    } 
                    //3.��������ͷ�ı߿� 
                    using (Pen gridPen = new Pen(dataGridView1.GridColor)) 
                    { 
                        //3.1 �ϲ��߿� 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop, cLeft + cWidth, cTop); 
                        using (Pen hilightPen = new Pen(Color.WhiteSmoke)) 
                        { 
                            //3.2 �����߹� 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 1, cLeft + cWidth, cTop + 1); 
                            //3.3 �󲿷����� 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 3, cLeft, cTop + cHeight - 2); 
                        } 
                        //3.4 �²��߿� 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop + cHeight - 1, cLeft + cWidth, cTop + cHeight - 1); 
                        //3.5 �Ҳ��߿�                         
                        e.Graphics.DrawLine(gridPen, cLeft + cWidth - 1, cTop, cLeft + cWidth - 1, cTop + cHeight);//(cTop+cHeight)/2); 
                    } 
                    //4.д�ı� 
                    if (colNameCollection.IndexOf(colName) == 0) 
                    {//���ǵ�һ����д���֡� 
                        int wHeadStr = (int)(headerText.Length * e.CellStyle.Font.SizeInPoints); 
                        int wHeadCell = cWidth; 
                        int pHeadLeft = (wHeadCell - wHeadStr) / 2 - 6; 
                        using (Brush foreBrush = new SolidBrush(e.CellStyle.ForeColor)) 
                        { 
                            e.Graphics.DrawString(headerText, e.CellStyle.Font, foreBrush, new PointF(cLeft + pHeadLeft, cTop + 3)); 
                        } 
                    } 
                    

                    //5 �������б��� 
                    int FatherColHeight = e.CellBounds.Height / 2;//����һ�еĸ߶�  
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor)) 
                    { 
                        e.Graphics.FillRectangle(backColorBrush, new Rectangle(e.CellBounds.X, e.CellBounds.Y + FatherColHeight, e.CellBounds.Width - 1, e.CellBounds.Height / 2 - 1)); 
                    } 
                    //5.1�������еı߿�                    
                    using (Pen gridPen = new Pen(dataGridView1.GridColor)) 
                    { 
                        using (Pen hilightPen = new Pen(Color.WhiteSmoke)) 
                        { 
                            //5.2 �󲿷����� 
                            e.Graphics.DrawLine(hilightPen, cLeft, cTop + 3 + FatherColHeight, cLeft, cTop + cHeight - 2 + FatherColHeight); 
                        } 
                        //5.3 �²��߿� 
                        e.Graphics.DrawLine(gridPen, cLeft, cTop + cHeight - 1 + FatherColHeight, cLeft + cWidth, cTop + cHeight - 1 + FatherColHeight); 

                        //5.4 �Ҳ��߿�  
                        e.Graphics.DrawLine(gridPen, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Top + FatherColHeight, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Top + e.CellBounds.Height + FatherColHeight);//(cTop+cHeight)/2);                     

                    } 
                    //5.5 д���е��ı� 
                    int wStr = (int)(dataGridView1.Columns[e.ColumnIndex].HeaderText.Length * e.CellStyle.Font.SizeInPoints); 
                    int wCell = e.CellBounds.Width; 
                    int pLeft = (wCell - wStr) / 2;//���CELL��߿�������� 

                    using (Brush foreBrush = new SolidBrush(e.CellStyle.ForeColor)) 
                    { 
                        e.Graphics.DrawString(dataGridView1.Columns[e.ColumnIndex].HeaderText, e.CellStyle.Font, foreBrush, new PointF(e.CellBounds.X + pLeft, cTop + 3 + FatherColHeight)); 
                    }                     
                    #endregion 
                    e.Handled = true; 
                } 
            } 
        }        
    } 
} 
