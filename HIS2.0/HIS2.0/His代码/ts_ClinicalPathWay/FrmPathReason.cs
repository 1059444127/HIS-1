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
    public partial class FrmPathReason : FrmBase2
    {
        public FrmPathReason()
        {
            InitializeComponent();
        }
        
        public void Init()
        {
            try
            {
                this.sSql = "SELECT * FROM [PATH_REASON]";
                this.sSqlItem = "SELECT * FROM [PATH_VARIANT_TYPE]";
                string sql = "select 0 id ,'������' name union all select 1 id ,'������' name";

                dt = DbOpt.GetDataTable(sSql);
                dtItem = DbOpt.GetDataTable(sSqlItem);

               
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).DataSource = dtItem;
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).DisplayMember = "VARIANT_TYPE_NAME";
                ((DataGridViewComboBoxColumn)dgvReason.Columns["VARIANT_TYPE_ID"]).ValueMember = "VARIANT_TYPE_ID";

                DataTable dtBytype = DbOpt.GetDataTable(sql);
                ((DataGridViewComboBoxColumn)dgvReason.Columns["��������"]).DataSource = dtBytype;
                ((DataGridViewComboBoxColumn)dgvReason.Columns["��������"]).DisplayMember = "name";
                ((DataGridViewComboBoxColumn)dgvReason.Columns["��������"]).ValueMember = "id";


                dgvReason.DataSource = dt;
                //��ɺ�״̬����ʾ
                this.UseHelp("��ʼ�����!");
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("��ʼ��ʧ�ܣ�" + ex.Message);
            }

        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow drNew = dt.NewRow();

                drNew["PATH_REASON_ID"] = Guid.NewGuid().ToString();

                dt.Rows.Add(drNew);
                //�۽���DataGridView������
                dgvReason.CurrentCell = dgvReason["REASON", dgvReason.Rows.GetLastRow(DataGridViewElementStates.Visible)];

                dgvReason.BeginEdit(true);
            }
            catch (Exception ex)
            {
                //�쳣״̬����ʾ
                this.UseHelp("����ʧ�ܣ�" + ex.Message);
            }

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
                //�ж�DGV�Ƿ���ѡ�����Ҳ�������
                if (dgvReason.SelectedRows.Count == 1 && !dgvReason.SelectedRows[0].IsNewRow)
                {
                    //��ȡѡ���е�RULE_IDֵ
                    string iReasonId = dgvReason.SelectedRows[0].Cells["PATH_REASON_ID"].Value.ToString();
                    dt.Select("PATH_REASON_ID = '" + iReasonId + "'")[0].Delete();
                    this.UseHelp("ɾ�����!");
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
                this.dgvReason.EndEdit();  
                //��ʾ�Ƿ񱣴�
                if (Trasen.Base.MsgBox.MsgShow("δ��д�������ݵ����ݽ������,ȷ������?", "��ʾ", MessageBoxButtons.YesNo, 350, 120) == DialogResult.Yes)
                {
                    DataTable tb =(DataTable) this.dgvReason.DataSource;
                    tb.GetChanges();
                    //����DGV�༭״̬
                    //dgvReason.EndEdit();
                    //����DT����������Ϊ�յ���,��ɾ��
                    foreach (DataRow dr in dt.Select("REASON is NULL"))
                    {
                        if (dr["REASON"].ToString().Trim() == "")
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
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPathReason_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}