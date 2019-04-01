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
    public partial class FrmPathWayCode : FrmBase2
    {
        public FrmPathWayCode()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void Init()
        {
            try
            {
                this.sSql = "SELECT * FROM [PATH_DM]";
                dt = DbOpt.GetDataTable(sSql);
                dtItem = dt.Copy();
                dt.DefaultView.RowFilter = "VALID in( 2,4)";
                dtItem.DefaultView.RowFilter = "VALID = 1";

                dgvCodeType.DataSource = dt;
                dgvCode.DataSource = dtItem;

                this.UseHelp("��ʼ�����!");
            }
            catch (Exception ex)
            {
                this.UseHelp("��ʼ��ʧ�ܣ�" + ex.Message);
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathWayCode_Load(object sender, EventArgs e)
        {
            //��ʼ��
            Init();
        }
        /// <summary>
        /// ѡ�����͸����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCodeType_SelectionChanged(object sender, EventArgs e)
        {
            dgvCode.Tag = null;
            if (dgvCodeType.SelectedRows.Count > 0)
            {
                int iKind = (int)dgvCodeType.SelectedRows[0].Cells["KIND_t"].Value;
                dgvCode.Tag = dgvCodeType.SelectedRows[0].Cells["VALID_t"].Value.ToString();
                dtItem.DefaultView.RowFilter = "VALID = 1 AND KIND = " + iKind;
            }
            if (dgvCode.Tag != null && dgvCode.Tag.ToString() == "2")
            {
                dgvCode.ReadOnly = false;
            }
            else dgvCode.ReadOnly = true;

            barBtAdd.Enabled = barBtSave.Enabled = barBtDelete.Enabled = !dgvCode.ReadOnly;

        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgvCode.ReadOnly) return;
            //��ȡ��ǰѡ��Ĵ������ͺ�KIND
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            int iKind = (int)dgvCodeType.SelectedRows[0].Cells["KIND_t"].Value;
            //ˢ��
            Init();
            StartEdit(true);
            //����ѡ��Ĵ�������
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
            //��������
            DataRow drNew = dtItem.NewRow();
            //��ʼ������Ĭ��ֵ
            drNew["KIND"] = iKind;
            drNew["VALID"] = 1;
            drNew["CODE"] = dtItem.Select(string.Format("KIND = {0} AND VALID = {1}", iKind, 1)).Length + 1;
            //������е���DataTable
            dtItem.Rows.Add(drNew);
            //�۽���DataGridView������
            dgvCode.CurrentCell = dgvCode["NAME", dgvCode.Rows.GetLastRow(DataGridViewElementStates.Visible)];
            //��ʼ�༭
            dgvCode.BeginEdit(true);
        }
        /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (dgvCode.ReadOnly) return;
                //�жϵ�ǰ�Ƿ�ѡ����ĳ��,�Ҹ��в�������
                if (dgvCode.SelectedRows.Count == 1 && !dgvCode.SelectedRows[0].IsNewRow)
                {
                    //��ȡ��ѡ�е�KIND
                    int iKind = (int)dgvCode.SelectedRows[0].Cells["KIND"].Value;
                    //��ȡ��ѡ�е�CODE
                    int iCode = Convert.ToInt32(dgvCode.SelectedRows[0].Cells["CODE"].Value);
                    //����KIND��CODE��ѯDataTable��Ӧ���ݲ�ɾ��
                    dtItem.Select(string.Format("KIND = {0} AND CODE = {1}", iKind, iCode))[0].Delete();
                }
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("ɾ��ʧ�ܣ�" + ex.Message);
            }
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (dgvCode.ReadOnly) return;
                //��ʾ�Ƿ񱣴�
                if (Trasen.Base.MsgBox.MsgShow("û�д�������Ƶ����ݽ������,ȷ�����浱ǰ����?", "��ʾ", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    //��ȡ��ǰѡ��Ĵ�������
                    int iSelect = dgvCodeType.SelectedRows[0].Index;
                    //����DataGridView�༭״̬
                    dgvCode.EndEdit();
                    //����DataTable�д��������Ϊ�յ���,��ɾ��
                    foreach (DataRow dr in dtItem.Select("CODE is NULL OR NAME is NULL"))
                    {
                        //�ж�CODE��NAME�Ƿ�Ϊ���ַ���
                        if (dr["CODE"].ToString().Trim() == "" || dr["NAME"].ToString().Trim() == "")
                            dr.Delete();//ɾ������
                    }
                    //������ǰ��DataTable�ı༭״̬
                    this.BindingContext[dtItem].EndCurrentEdit();
                    //��DataTable���������ݿ�,����ȡ�޸�����
                    int rows = DbOpt.Update(dtItem, sSql);
                    //�ж��Ƿ����޸�
                    if (rows >= 0)
                    {
                        //���ܸı�
                        dtItem.AcceptChanges();
                        //��ʼ��
                        Init();
                        //����ѡ��Ĵ�������
                        dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
                        //״̬����ʾ�ɹ�

                        this.UseHelp("����ɹ�!");
                        StartEdit(false);
                    }
                }
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }
        }
        /// <summary>
        /// ˢ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȡ��ǰѡ��Ĵ�������
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            //��ʼ��
            Init();            
            //����ѡ��Ĵ�������
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
        }
        /// <summary>
        /// ��ʼ�༭
        /// </summary>
        /// <param name="isEdit"></param>
        private void StartEdit(bool isEdit)
        {
            this.barBtAdd.Enabled = !isEdit;
            this.barBtCancel.Enabled = isEdit;
            this.barBtDelete.Enabled = !isEdit;
            this.barBtRefresh.Enabled = !isEdit;
            this.dgvCodeType.Enabled = !isEdit;
        }
        /// <summary>
        /// ȡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //��ȡ��ǰѡ��Ĵ�������
            int iSelect = dgvCodeType.SelectedRows[0].Index;
            Init();
            //����ѡ��Ĵ�������
            dgvCodeType.CurrentCell = dgvCodeType["NOTE_t", iSelect];
            StartEdit(false);
            
        }
    }
}