using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trasen.Base;

namespace ts_ClinicalPathWay
{
    public partial class FrmRuleDictionary : FrmBase2
    {
        bool bIsPathWay;
        #region ���캯��

        /// <summary>
        /// ���캯��
        /// </summary>
        public FrmRuleDictionary(bool isPathWay)
        {
            InitializeComponent();
            this.bIsPathWay = isPathWay;
        }

        #endregion

        #region �������

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRuleDictionary_Load(object sender, EventArgs e)
        {
            //��ʼ��
            Init();
        }

        #endregion

        #region ��ʼ��

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void Init()
        {
            try
            {
                APPLY_TYPE.Items.Add(this.bIsPathWay ? "·������" : "����������");
                APPLY_TYPE.Items.Add("�׶�����");

                //��ѯSQL���
                sSql = string.Format("SELECT * FROM [PATH_RULE_DICT] ORDER BY [RULE_ID]");
                //�����ݵ�DataTable
                dt = DbOpt.GetDataTable(sSql);
                //��DGV
                dgvDic.DataSource = dt;
                //״̬����ʾ���
                this.UseHelp("��ʼ�����!");
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("��ʼ��ʧ�ܣ�" + ex.Message);
            }
        }
        /// <summary>
        /// ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDic_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //���ݰ����ݳ�ʼ��ComboBoxѡ����
            foreach (DataGridViewRow dgvr in dgvDic.Rows)
            {
                if (dgvr.Cells["APPLY_TYPE_Bind"].Value.ToString() == "1")
                    dgvr.Cells["APPLY_TYPE"].Value = this.bIsPathWay ? "·������" : "����������";
                else if (dgvr.Cells["APPLY_TYPE_Bind"].Value.ToString() == "2")
                    dgvr.Cells["APPLY_TYPE"].Value = "�׶�����";
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
            //��ʼ�����е�IDֵ
            int flag = dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (flag < 0)
                drNew["RULE_ID"] = 0;
            else
                drNew["RULE_ID"] = (int)dgvDic.Rows[dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells["RULE_ID"].Value + 1;
            //������е���DT
            dt.Rows.Add(drNew);
            //�۽���DGV������
            dgvDic.CurrentCell = dgvDic["CONTENT", dgvDic.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //��ʼ����������
            dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value = this.bIsPathWay ? "·������" : "����������";
            dgvDic.CurrentRow.Cells["PASS"].Value = 1;
            //��ʼ�༭
            dgvDic.BeginEdit(true);
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
            //�ж�DGV�Ƿ���ѡ�����Ҳ�������
            if (dgvDic.SelectedRows.Count == 1 && !dgvDic.SelectedRows[0].IsNewRow)
            {
                //��ȡѡ���е�RULE_IDֵ
                int iRuleId = (int)dgvDic.SelectedRows[0].Cells["RULE_ID"].Value;
                //����RULE_ID��ѯ�������
                if ((int)DbOpt.GetDataTable("SELECT COUNT(*) FROM [PATH_RULE_ITEM] WHERE [RULE_ID] = " + iRuleId).Rows[0][0] > 0)
                {
                    //�����������,����ʾ�޷�ɾ��,����.
                    MessageBox.Show("�������������ڱ�ʹ��,��Ҫɾ��������,�����Ƴ���������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //��û���������,���DT��ɾ������.
                    dt.Select("RULE_ID = " + iRuleId)[0].Delete();
                    this.UseHelp("ɾ�����!");
                }
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
                if (Trasen.Base.MsgBox.MsgShow("δ��д�������ݵ����ݽ������,ȷ�����浱ǰ�ֵ�����?", "��ʾ", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //����DGV�༭״̬
                    dgvDic.EndEdit();
                    //����DT����������Ϊ�յ���,��ɾ��
                    foreach (DataRow dr in dt.Select("CONTENT is NULL"))
                    {
                        if (dr["CONTENT"].ToString().Trim() == "")
                            dr.Delete();
                    }
                    //�����޸�
                    this.BindingContext[dt].EndCurrentEdit();
                    int rows = DbOpt.Update(dt, sSql);
                    if (rows >= 0)
                    {
                        dt.AcceptChanges();
                        //��ʼ��
                        Init();
                        this.UseHelp("����ɹ�!");
                    }
                }
            }
            catch (Exception ex)
            {
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }
        }

        #endregion

        #region �������ͱ��

        /// <summary>
        /// �������ͱ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDic_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //����ComboBox�е�ѡ����,�޸İ��е�����
            if (dgvDic.CurrentRow != null && dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value != null)
            {
                //��ȡComboBox��ѡ������
                string sValue = dgvDic.CurrentRow.Cells["APPLY_TYPE"].Value.ToString();
                //�ж�ѡ������������������
                if (sValue == "·������" || sValue == "����������")
                    dgvDic.CurrentRow.Cells["APPLY_TYPE_Bind"].Value = 1;
                else if (sValue == "�׶�����")
                    dgvDic.CurrentRow.Cells["APPLY_TYPE_Bind"].Value = 2;
            }
        }

        #endregion
    }
}