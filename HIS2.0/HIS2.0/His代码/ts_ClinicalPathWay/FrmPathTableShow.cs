using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using TrasenFrame.Classes;
using Microsoft.Office.Interop.Word;
using System.Drawing.Drawing2D;

namespace ts_ClinicalPathWay
{
    public partial class FrmPathTableShow : Form
    {
        public FrmPathTableShow()
        {
            InitializeComponent();
        }

        private void Seasons()
        {
            int iUID = 0;
            string sUname = "pantechex";
            string sSql = string.Format("SELECT * FROM [UserInfo] WHERE [UID] = {0} AND [Uname] = '{1}'", iUID, sUname);
            DataTable dt = DbOpt.GetDataTable(sSql);

            dataGridView1.DataSource = dt;
        } 

        private void FrmPathTableShow_Load(object sender, EventArgs e)
        {
            DataTable dt = DbOpt.GetDataTable("select * from PATHTABLE");
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataTable dt = DbOpt.GetDataTable("select * from PATHTABLE_STEP where PATH_TABLE_ID = " + dataGridView1.SelectedRows[0].Cells["PATH_TABLE_ID"].Value);
                dataGridView2.DataSource = dt;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataTable dt = DbOpt.GetDataTable("select * from PATHTABLE_STEP_ITEM where PATH_TABLE_ID = " + dataGridView1.SelectedRows[0].Cells["PATH_TABLE_ID"].Value + " and TABLE_STEP_ID = " + dataGridView2.SelectedRows[0].Cells["TABLE_STEP_ID"].Value);
                dataGridView3.DataSource = dt;
            }
        }

        WordClass wordClass = new WordClass();
        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                wordClass.CreateDocument();
                //-------------------------------��ʼ------------------------------------
                //�����ı����뷽ʽ
                wordClass.WordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //��������
                wordClass.WordApplication.Selection.Font.Name = "����";
                //�Ӵ�
                wordClass.WordApplication.Selection.Font.Bold = 1;
                //���������С
                wordClass.WordApplication.Selection.Font.Size = 13;
                //���ù̶��о�
                wordClass.WordApplication.Selection.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceExactly;
                wordClass.WordApplication.Selection.ParagraphFormat.LineSpacing = 13;

                wordClass.WordApplication.Selection.ParagraphFormat.SpaceAfter = 0;


                wordClass.AppendText("���ɹ����ٴ�·��");
                wordClass.WordApplication.Selection.Font.Name = "����";
                wordClass.WordApplication.Selection.Font.Bold = 0;
                wordClass.WordApplication.Selection.Font.Size = 11;
                wordClass.WordApplication.Selection.ParagraphFormat.LineSpacing = 12;
                wordClass.AppendText("���ö��󣺵�һ���Ϊ���ɹ��ޣ�ICD-10�� K40.2��K40.9��");
                wordClass.AppendText("������������������������ ��ICD-9-CM-3�� 53.0-53.1��");
                wordClass.AppendText("����������____________�Ա�______���䣺______����ţ�__________סԺ�ţ�__________");
                
                wordClass.SaveAs(@"E:\tt.doc");
                wordClass.Close(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //wordClass.OpenDocument(@"E:\lj.doc");
            //string str = wordClass.Document.WordOpenXML; 
        }

        private void btnGDI_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(595, 841);
            Graphics g = Graphics.FromImage(image);


            GraphicsUnit gu = GraphicsUnit.Point;
            #region ����

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            RectangleF rfTitle = image.GetBounds(ref gu);
            System.Drawing.Font fTitle = new System.Drawing.Font("����", 10, FontStyle.Regular, GraphicsUnit.Point);
            rfTitle.Size = new SizeF(rfTitle.Width, fTitle.Height);
            rfTitle.Location = new PointF(rfTitle.X, 50);

            #endregion

            #region ������
            System.Drawing.Font fTitleChild = new System.Drawing.Font("����", 8, FontStyle.Regular, GraphicsUnit.Point);
            RectangleF rfTitleC = image.GetBounds(ref gu);

            rfTitleC.Size = new SizeF(rfTitleC.Width, fTitleChild.Height);
            rfTitleC.Location = new PointF(50, 50 + fTitle.Height);

            RectangleF rfTitleC2 = rfTitleC;
            rfTitleC2.Location = new PointF(50,rfTitleC2.Y+fTitleChild.Height);


            RectangleF rfTitleC3 = rfTitleC2;
            rfTitleC3.Location = new PointF(50,rfTitleC3.Y+fTitleChild.Height);
            #endregion


            g.Clear(Color.White);
            g.DrawString("���ɹ����ٴ�·��", fTitle, Brushes.Black, rfTitle, sf);
            g.DrawString("���ö��󣺵�һ���Ϊ���ɹ��ޣ�ICD-10�� K40.2��K40.9��", fTitleChild, Brushes.Black, rfTitleC);
            g.DrawString("������������������������ ��ICD-9-CM-3�� 53.0-53.1��", fTitleChild, Brushes.Black, rfTitleC2);
            g.DrawString("����������____________�Ա�______���䣺______����ţ�__________סԺ�ţ�__________", fTitleChild, Brushes.Black, rfTitleC3);
            pbTable.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordClass.OpenDocument(@"E:\fggs.doc");

            wordClass.Replace("{Name}", "����");
            wordClass.Replace("{XB}", "��");
            wordClass.Replace("{NL}", "28");
            wordClass.Replace("{MZH}", "0100020");
            wordClass.Replace("{ZYH}", "2929290");
            wordClass.Replace("{ZYN}", "2012");
            wordClass.Replace("{ZYY}", "11");
            wordClass.Replace("{ZYR}", "15");
            wordClass.Replace("{CYN}", "2012");
            wordClass.Replace("{CYY}", "11");
            wordClass.Replace("{CYR}", "22");

            wordClass.SaveAs(@"E:\sc.doc");

            
            winWordControl1.LoadDocument(@"E:\sc.doc");
            winWordControl1.document.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;

            
            //wordClass.Close(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            winWordControl1.document.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmPathWayTablePrint("����", "��", "20", "02920292", "8274367393", "2012", "11", "20", "2012", "11", "27", "9cc4578f-ab75-452c-9811-d43b6b8d4751").ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmEmrItemRelation().ShowDialog();
        }
    }
}