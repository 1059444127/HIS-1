using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;
using TrasenFrame.Forms;

namespace ts_ClinicalPathWay
{
    /// <summary>
    /// �ٴ�·������
    /// </summary>
    public partial class FrmPathWayAssessment : FrmBase2
    {
        #region ˽���ֶ�

        string strPathWayId = "";//�ٴ�·��ID
        bool bIsPathWay;

        #endregion

        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="strPathWayId">�ٴ�·��ID</param>
        public FrmPathWayAssessment(string strPathWayId,bool isPathWay)
        {
            InitializeComponent();
            //��ȡ���ϸ����崫�������ٴ�·��ID
            this.strPathWayId = strPathWayId;
            this.bIsPathWay = isPathWay;
        }

        #endregion

        #region �������

        /// <summary>
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayAssessment_Load(object sender, EventArgs e)
        {
            //��ʼ��
            Init();
        }

        #endregion

        #region ��ʼ��

        /// <summary>
        /// ���ݳ�ʼ��
        /// </summary>
        private void Init()
        {
            try
            {
                this.Text = this.bIsPathWay ? "�ٴ�·������" : "����������";
                //��ѯSQL���
                this.sSql = string.Format("SELECT * FROM [PATH_RULE_ITEM] WHERE [PATHWAY_ID] = '{0}' AND [DELETED] = 0", this.strPathWayId);
                this.sSqlItem = string.Format("SELECT * FROM [PATH_RULE_DICT] WHERE [APPLY_TYPE] = 1 ORDER BY [RULE_ID]");
                //��ȡ���ݵ�DataTable
                dt = DbOpt.GetDataTable(sSql);//·������DT
                dtItem = DbOpt.GetDataTable(sSqlItem);//�����ֵ�DT
                //��DataGridView(·������)
                dgvPathRuleItem.DataSource = dt;
                //��ѡ��(�����ֵ�)
                dgvPathRuleItem.ShowCardProperty[0].ShowCardDataSource = dtItem;
                //����DGV�������
                dgvPathRuleItem.Sort(dgvPathRuleItem.Columns["SORT"], ListSortDirection.Ascending);
                //��ɺ�״̬����ʾ
                this.UseHelp("��ʼ�����!");
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("��ʼ��ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

        #region ����

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��������
            DataRow drNew = dt.NewRow();
            //��ʼ������Ĭ��ֵ
            drNew["PATHWAY_ID"] = this.strPathWayId;
            drNew["DELETED"] = 0;
            drNew["SORT"] = dt.Rows.Count;
            //������е���DataTable(·������)
            dt.Rows.Add(drNew);
            //�۽���DataGridView������
            dgvPathRuleItem.CurrentCell = dgvPathRuleItem["CONTENT", dgvPathRuleItem.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //��ʼ�༭
            //dgvPathRuleItem.BeginEdit(true);
        }

        /// <summary>
        /// ѡ��ѡ���¼�
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <param name="nextFocus"></param>
        private void dgvPathRuleItem_AfterSelectedDataRow(DataRow selectedRow, ref object nextFocus)
        {
            try
            {
                //�ж���ѡ�����Ƿ�δ��ӹ�
                if (dt.Select("RULE_ID = " + selectedRow["RULE_ID"].ToString()).Length == 0)
                {
                    //��ȡDataGridView(·������)��ѡ��
                    DataRow dr = dt.Select("SORT = " + dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value.ToString())[0];
                    //��ѡ����ѡ�е����ݸ�ֵ��·��������ѡ��
                    dr["RULE_ID"] = selectedRow["RULE_ID"].ToString();
                    dr["CONTENT"] = selectedRow["CONTENT"].ToString();
                    dr["PASS"] = selectedRow["PASS"].ToString();
                    dr["NOTE"] = selectedRow["NOTE"].ToString();
                }
                else if (dt.Select("RULE_ID = " + selectedRow["RULE_ID"].ToString())[0]["RULE_ID"].ToString() == dgvPathRuleItem.SelectedRows[0].Cells["RULE_ID"].Value.ToString())
                {
                    return;
                }
                else
                {
                    Trasen.Base.MsgBox.MsgShow("��������ظ�����������!", "��ʾ", MessageBoxButtons.OK, 200, 120);
                    //����ѡ�����Ѿ�����,״̬����ʾ�ظ����
                    this.UseHelp("��������ظ�����������!");
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("ѡ��ʧ�ܣ�" + ex.Message);
            }

        }

        #endregion

        #region ɾ��

        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //�жϵ�ǰ�Ƿ�ѡ����ĳ��,�Ҹ��в�������
                if (dgvPathRuleItem.SelectedRows.Count == 1 && !dgvPathRuleItem.SelectedRows[0].IsNewRow)
                {
                    //��ȡ��ѡ�е������
                    int iSort = (int)dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value;
                    //��������Ų�ѯDataTable(·������)��Ӧ���ݲ�ɾ��
                    dt.Select("SORT = " + iSort)[0].Delete();
                    //ѭ����������Ŵ�����ɾ���е�����
                    foreach (DataRow dr in dt.Select("SORT > " + iSort))
                    {
                        //ѭ������ѯ�����ݵ������ǰ��һλ
                        dr["SORT"] = (int)dr["SORT"] - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("ɾ��ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

        #region ����

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //��ʾ�Ƿ񱣴�
                if (Trasen.Base.MsgBox.MsgShow("δѡ���������ݵ����ݽ������,ȷ�����浱ǰ����?", "��ʾ", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //����DataGridView�༭״̬
                    dgvPathRuleItem.EndEdit();
                    //����DataTable(·������)����������Ϊ�յ���,��ɾ��
                    foreach (DataRow dr in dt.Select("CONTENT is NULL"))
                    {
                        //�ж�CONTENT(��������)�Ƿ�Ϊ���ַ���
                        if (dr["CONTENT"].ToString().Trim() == "")
                            dr.Delete();//ɾ������
                    }
                    //������ǰ��DataTable(·������)�ı༭״̬
                    this.BindingContext[dt].EndCurrentEdit();
                    //��DataTable(·������)���������ݿ�,����ȡ�޸�����
                    int rows = DbOpt.Update(dt, sSql);
                    //�ж��Ƿ����޸�
                    if (rows >= 0)
                    {
                        //���ܸı�
                        dt.AcceptChanges();
                        //��ʼ��
                        Init();

                        //״̬����ʾ�ɹ�
                        this.UseHelp("����ɹ�!");
                    }
                }
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

        #region �ƶ�

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RowMove(true);
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RowMove(false);
        }
        /// <summary>
        /// ��ѡ���ƶ�
        /// </summary>
        /// <param name="isUp"></param>
        private void RowMove(bool isUp)
        {
            try
            {
                //�жϵ�ǰ�Ƿ�ѡ����ĳ��
                if (dgvPathRuleItem.SelectedRows.Count == 1)
                {
                    //�ж���ѡ�зǵ�һ��
                    if (dgvPathRuleItem.SelectedRows[0].Index > (isUp ? 0 : dgvPathRuleItem.Rows.Count - 1))
                    {
                        //��ȡ��ѡ�е������
                        int iSort = (int)dgvPathRuleItem.SelectedRows[0].Cells["SORT"].Value;
                        //��DataTable(·������)�в�����ѡ��
                        DataRow drNow = dt.Select("SORT = " + iSort)[0];
                        //��DataTable(·������)�в���Ҫ�ƶ�������
                        DataRow drMove = dt.Select("SORT = " + (iSort + (isUp ? -1 : 1)))[0];
                        //�������е������
                        drNow["SORT"] = iSort + (isUp ? -1 : 1);
                        drMove["SORT"] = iSort;
                        //����궨λ����ѡ��
                        dgvPathRuleItem.CurrentCell = dgvPathRuleItem["CONTENT", iSort + (isUp ? -1 : 1)];
                    }
                }
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("�ƶ�ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

    }
}