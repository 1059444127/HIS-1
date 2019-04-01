using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace ts_mz_tjbb
{
    partial class TreeHeadDataGridView
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region �����������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }
    public partial class TreeHeadDataGridView :  DevComponents.DotNetBar.Controls.DataGridViewX//   System.Windows.Forms.DataGridView
    {
        private TreeView treeView1 = new TreeView();
        public TreeHeadDataGridView()
        {
            InitializeComponent();
        }

        public TreeHeadDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection HeadSource
        {
            get { return this.treeView1.Nodes; }

        }


        private int _cellHeight = 17;
        private int _columnDeep = 1;
        [Description("���û��úϲ���ͷ�������")]
        public int ColumnDeep
        {
            get
            {
                if (this.Columns.Count == 0)
                    _columnDeep = 1;
                this.ColumnHeadersHeight = _cellHeight * _columnDeep;
                return _columnDeep;
            }

            set
            {
                if (value < 1)
                    _columnDeep = 1;
                else
                    _columnDeep = value;
                this.ColumnHeadersHeight = _cellHeight * _columnDeep;
            }
        }

        ///<summary>
        ///���ƺϲ���ͷ
        ///</summary>
        ///<param name="node">�ϲ���ͷ�ڵ�</param>
        ///<param name="e">��ͼ������</param>
        ///<param name="level">������</param>
        ///<remarks></remarks>
        public void PaintUnitHeader(TreeNode node, DataGridViewCellPaintingEventArgs e, int level)
        {
            //���ڵ�ʱ�˳��ݹ����
            if (level == 0)
                return;

            RectangleF uhRectangle;
            int uhWidth;
            SolidBrush gridBrush = new SolidBrush(this.GridColor);

            Pen gridLinePen = new Pen(Brushes.Blue);
            StringFormat textFormat = new StringFormat();


            textFormat.Alignment = StringAlignment.Center;

            uhWidth = GetUnitHeaderWidth(node);

            //��ԭ���㷨�����������⡣
            if (node.Nodes.Count == 0)
            {
                uhRectangle = new Rectangle(e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * _cellHeight,
                            uhWidth - 1,
                            _cellHeight * (_columnDeep - node.Level) - 1);
            }
            else
            {
                uhRectangle = new Rectangle(
                            e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * _cellHeight,
                            uhWidth - 1,
                            _cellHeight - 1);
            }

            Color backColor = e.CellStyle.BackColor;
            if (node.BackColor != Color.Empty)
            {
                backColor = node.BackColor;
            }
            SolidBrush backColorBrush = new SolidBrush(backColor);

            //������
            e.Graphics.FillRectangle(Brushes.LightGray, uhRectangle);


            //������
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Left
                                , uhRectangle.Bottom
                                , uhRectangle.Right
                                , uhRectangle.Bottom);
            //���Ҷ���
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Right
                                , uhRectangle.Top
                                , uhRectangle.Right
                                , uhRectangle.Bottom);

            ////д�ֶ��ı�
            Color foreColor = Color.Black;
            if (node.ForeColor != Color.Empty)
            {
                foreColor = node.ForeColor;
            }
            e.Graphics.DrawString(node.Text, this.Font
                                    , new SolidBrush(foreColor)
                                    , uhRectangle.Left + uhRectangle.Width / 2 -
                                    e.Graphics.MeasureString(node.Text, this.Font).Width / 2 - 1
                                    , uhRectangle.Top +
                                    uhRectangle.Height / 2 - e.Graphics.MeasureString(node.Text, this.Font).Height / 2);

            ////�ݹ����()
            if (node.PrevNode == null)
                if (node.Parent != null)
                    PaintUnitHeader(node.Parent, e, level - 1);
        }

        /// <summary>
        /// ��úϲ������ֶεĿ��
        /// </summary>
        /// <param name="node">�ֶνڵ�</param>
        /// <returns>�ֶο��</returns>
        /// <remarks></remarks>
        private int GetUnitHeaderWidth(TreeNode node)
        {
            //��÷���ײ��ֶεĿ��

            int uhWidth = 0;
            //�����ײ��ֶεĿ��
            if (node.Nodes == null)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            if (node.Nodes.Count == 0)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            for (int i = 0; i <= node.Nodes.Count - 1; i++)
            {
                uhWidth = uhWidth + GetUnitHeaderWidth(node.Nodes[i]);
            }
            return uhWidth;
        }


        /// <summary>
        /// ��õײ��ֶ�����
        /// </summary>
        /// <param name="node">�ײ��ֶνڵ�</param>
        /// <returns>����</returns>
        /// <remarks></remarks>
        private int GetColumnListNodeIndex(TreeNode node)
        {
            for (int i = 0; i <= _columnList.Count - 1; i++)
            {
                if (((TreeNode)_columnList[i]).Equals(node))
                    return i;
            }
            return -1;
        }

        private List<TreeNode> _columnList = new List<TreeNode>();
        [Description("��׌ӽY�c����")]
        public List<TreeNode> NadirColumnList
        {
            get
            {
                if (this.treeView1 == null)
                    return null;

                if (this.treeView1.Nodes == null)
                    return null;

                if (this.treeView1.Nodes.Count == 0)
                    return null;

                _columnList.Clear();
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    //GetNadirColumnNodes(_columnList, node, false);
                    GetNadirColumnNodes(_columnList, node);
                }
                return _columnList;
            }
        }

        private void GetNadirColumnNodes(List<TreeNode> alList, TreeNode node)
        {
            if (node.FirstNode == null)
            {
                alList.Add(node);
            }
            foreach (TreeNode n in node.Nodes)
            {
                GetNadirColumnNodes(alList, n);
            }
        }

        /// <summary>
        /// ��õײ��ֶμ���
        /// </summary>
        /// <param name="alList">�ײ��ֶμ���</param>
        /// <param name="node">�ֶνڵ�</param>
        /// <param name="checked">�����������</param>
        /// <remarks></remarks>
        private void GetNadirColumnNodes(List<TreeNode> alList, TreeNode node, Boolean isChecked)
        {
            if (isChecked == false)
            {
                if (node.FirstNode == null)
                {
                    alList.Add(node);
                    if (node.NextNode != null)
                    {
                        GetNadirColumnNodes(alList, node.NextNode, false);
                        return;
                    }
                    if (node.Parent != null)
                    {
                        GetNadirColumnNodes(alList, node.Parent, true);
                        return;
                    }
                }
                else
                {
                    if (node.FirstNode != null)
                    {
                        GetNadirColumnNodes(alList, node.FirstNode, false);
                        return;
                    }
                }
            }
            else
            {
                if (node.FirstNode == null)
                {
                    return;
                }
                else
                {
                    if (node.NextNode != null)
                    {
                        GetNadirColumnNodes(alList, node.NextNode, false);
                        return;
                    }

                    if (node.Parent != null)
                    {
                        GetNadirColumnNodes(alList, node.Parent, true);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ��Ԫ�����(��д)
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            //�б��ⲻ��д
            if (e.ColumnIndex < 0)
            {
                base.OnCellPainting(e);
                return;
            }

            if (_columnDeep == 1)
            {
                base.OnCellPainting(e);
                return;
            }

            //���Ʊ�ͷ
            if (e.RowIndex == -1)
            {
                PaintUnitHeader((TreeNode)NadirColumnList[e.ColumnIndex], e, _columnDeep);
                e.Handled = true;
            }

        }

    }
}




