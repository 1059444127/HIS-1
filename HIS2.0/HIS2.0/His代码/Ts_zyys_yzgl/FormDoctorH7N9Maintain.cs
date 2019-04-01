using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ts_zyys_yzgl
{
    public partial class FormDoctorH7N9Maintain : Form
    {
        public FormDoctorH7N9Maintain()
        {
            InitializeComponent();
        }

        private void FormDoctorH7N9Maintain_Load(object sender, EventArgs e)
        {
            //����δά��ҽ���б�
            loadNoMatintain();

            //����ά��ҽ���б�
            loadMatintain();
        }

        /// <summary>
        /// ����δά��ҽ���б�
        /// </summary>
        private void loadNoMatintain()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtNoMaintain.Text))
            {
                strWhere = " AND (a.PY_CODE LIKE '%" + txtNoMaintain.Text.Trim() + "%' OR a.D_CODE LIKE '%" + txtNoMaintain.Text.Trim() + "%')";
            }

            string strSql = @"SELECT a.EMPLOYEE_ID as Ա��id,a.NAME as ����,a.D_CODE as ����,a.PY_CODE as ƴ���� FROM dbo.JC_EMPLOYEE_PROPERTY AS a JOIN  dbo.JC_ROLE_DOCTOR AS b ON a.EMPLOYEE_ID = b.EMPLOYEE_ID
                            WHERE a.EMPLOYEE_ID NOT IN (SELECT c.EMPLOYEE_ID FROM dbo.H7N9_DOCTOR AS c WHERE c.DELETEBIT=0) " + strWhere;

            DataTable dt = InstanceForm._database.GetDataTable(strSql);
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// ����ά��ҽ���б�
        /// </summary>
        private void loadMatintain()
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(txtMaintain.Text))
            {
                strWhere = " AND (PY_CODE LIKE '%" + txtMaintain.Text.Trim() + "%' OR D_CODE LIKE '%" + txtMaintain.Text.Trim() + "%')";
            }
            string strSql = @"SELECT EMPLOYEE_ID AS  Ա��id,NAME AS ����,D_CODE AS ����,PY_CODE AS ƴ����  FROM dbo.H7N9_DOCTOR WHERE DELETEBIT=0 " + strWhere;

            DataTable dt = InstanceForm._database.GetDataTable(strSql);
            this.dataGridView2.DataSource = dt;
        }

        /// <summary>
        /// ��ѯδά����Ա
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoMaintain_Click(object sender, EventArgs e)
        {
            loadNoMatintain();
        }

        /// <summary>
        /// ��ѯ��ά����Ա
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaintain_Click(object sender, EventArgs e)
        {
            loadMatintain();
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.CurrentRow;
            if (dr != null)
            {
                
                string strEmployeeId = dr.Cells["Ա��id"].Value.ToString();
                string strName = dr.Cells["����"].Value.ToString();
                string strCode = dr.Cells["����"].Value.ToString();
                string strPyCode = dr.Cells["ƴ����"].Value.ToString();

                string strInsert = @"INSERT INTO dbo.H7N9_DOCTOR ( EMPLOYEE_ID ,NAME ,OPERATORNAME ,OPERATORTIME ,DELETEBIT,D_CODE,PY_CODE)
                                    VALUES  ( " + strEmployeeId + ", '" + strName + "','" + InstanceForm._currentUser.Name + "','" + DateTime.Now + "',0,'" + strCode + "','" + strPyCode + "')";
                if (InstanceForm._database.DoCommand(strInsert) > 0)
                {
                    loadMatintain();
                    loadNoMatintain();
                }
            }
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = this.dataGridView2.CurrentRow;
            if (dr != null)
            {
                string strEmployeeId = dr.Cells["Ա��id"].Value.ToString();


                 string strDelete = "UPDATE dbo.H7N9_DOCTOR SET DELETEBIT=1 WHERE DELETEBIT=0 AND EMPLOYEE_ID=" + strEmployeeId;
                 if (InstanceForm._database.DoCommand(strDelete) > 0)
                {
                    loadMatintain();
                    loadNoMatintain();
                }
            }
        }

        private void txtNoMaintain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loadNoMatintain();
            }
        }

        private void txtMaintain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loadMatintain();
            }
        }


    }
}