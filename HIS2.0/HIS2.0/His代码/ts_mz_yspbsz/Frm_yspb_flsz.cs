using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using System.Data.SqlClient;

namespace ts_mz_yspbsz
{
    public partial class Frm_yspb_flsz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;


        private int mod = 0;     //0 ��ʾ  1�޸� 
        private int _id = -1;


        public Frm_yspb_flsz()
        {
            InitializeComponent();
        }

        public Frm_yspb_flsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        //��ʼ����ť״̬
        private void ThisStatus()
        {
            toolbtnAdd.Enabled = true;
            toolbtnMod.Enabled = true;
            toolbtnDel.Enabled = true;
            toolbtnSav.Enabled = false;
            toolbtnCal.Enabled = false;
            toolbtnRef.Enabled = true;
        }

        private void ReadTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType() != typeof(System.Windows.Forms.Label))
                {
                    ctl.Enabled = false;
                }
            }
        }

        //��datagridview
        private void Bangding()
        {
            string sql = @"select id,mc,bzk = case bzk when '1' then '��' when  '0' then '��' end,PXXH from JC_MZ_YSPB_KSFL";
            DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
            this.dgvflsz.DataSource = dt;
            if (this.dgvflsz.RowCount == 0)
                return;
            dgvflsz.AllowUserToAddRows = false;
            dgvflsz.ReadOnly = true;
        }

        //��ʼ��combobox
        private void InitCombobox()
        {
            cbbOpen.Items.AddRange(new object[] { "��", "��" });
            cbbOpen.SelectedIndex = 0;
        }

        private void Frm_yspb_flsz_Load(object sender, EventArgs e)
        {
            InitCombobox();
            ThisStatus();
            ReadTxt();
            Bangding();
        }

        private void dgvflsz_Click(object sender, EventArgs e)
        {
            ReadTxt();
            if (dgvflsz.RowCount > 0)
            {
                try
                {
                    _id = Convert.ToInt32(this.dgvflsz.Rows[this.dgvflsz.CurrentCell.RowIndex].Cells["ID"].Value.ToString());
                    //txtName.Text = this.dgvflsz.Rows[this.dgvflsz.CurrentCell.RowIndex].Cells["MC"].Value.ToString();
                    cbbOpen.Text = this.dgvflsz.Rows[this.dgvflsz.CurrentCell.RowIndex].Cells["BZK"].Value.ToString();
                    txtPXXH.Text = this.dgvflsz.Rows[this.dgvflsz.CurrentCell.RowIndex].Cells["PXXH"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����");
                }
            }
            ThisStatus();
        }

        private void WriterTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (!ctl.GetType().IsSubclassOf(typeof(System.Windows.Forms.Label)) && ctl.GetType() != typeof(System.Windows.Forms.Label))
                {
                    ctl.Enabled = true;
                }
            }
        }

        private void ClearTxt()
        {
            foreach (Control ctl in splitContainer1.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ctl.Text = "";
                    ctl.Tag = "";
                }
            }
        }

        private void AddStatus()
        {
            toolbtnAdd.Enabled = false;
            toolbtnMod.Enabled = false;
            toolbtnDel.Enabled = false;
            toolbtnSav.Enabled = true;
            toolbtnCal.Enabled = true;
            toolbtnRef.Enabled = false;
            toolbtnClo.Enabled = true;
        }

        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            AddStatus();
            ClearTxt();
            mod = 0;
            _id = 0;
            WriterTxt();
            this.txtName.Focus();
            this.dgvflsz.Enabled = false;
        }

        private void toolbtnMod_Click(object sender, EventArgs e)
        {
            AddStatus();
            WriterTxt();
            mod = 1;
            this.txtName.Focus();
            this.dgvflsz.Enabled = false;
        }

        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("��ȷ��Ҫɾ��������¼��", "�˳���ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                InstanceForm.BDatabase.BeginTransaction();
                try
                {
                    ParameterEx[] parameters3 = new ParameterEx[6];
                    parameters3[0].Text = "@ID";
                    parameters3[0].Value = _id;
                    parameters3[1].Text = "@MC";
                    parameters3[1].Value = txtName.Text.Trim();
                    parameters3[2].Text = "@BZK";
                    parameters3[2].Value = cbbOpen.SelectedIndex.ToString();
                    parameters3[3].Text = "@PXXH";
                    parameters3[3].Value = txtPXXH.Text.Trim();
                    parameters3[4].Text = "@i";
                    parameters3[4].Value = 3;
                    parameters3[5].Text = "@newid";
                    parameters3[5].ParaDirection = ParameterDirection.Output;
                    parameters3[5].DataType = System.Data.DbType.Int32;
                    parameters3[5].ParaSize = 100;

                    InstanceForm.BDatabase.DoCommand("SP_JC_MZPB_FLSZ", parameters3, 60);
                    //��Ժ���ݴ���_____������־
                    string bz = "";
                    bz = "ɾ�������Ű����:" + txtName.Text.ToString().Trim();
                    Guid log_djid = Guid.Empty;
                    ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
                    ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, bz, "JC_MZ_YSPB_KSFL", "ID", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                    InstanceForm.BDatabase.CommitTransaction();

                    ClearTxt();
                    Bangding();

                    //��Ժ���ݴ���___ִ��ͬ������ 
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, InstanceForm.BDatabase);
                    if (ty.Bzx == 1 && log_djid != Guid.Empty) //ֻ�е�����ִ�б�־Ϊ1ʱ��ִ��
                    {
                        ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                        if (errtext != "") MessageBox.Show(errtext, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (System.Exception err)
                {
                    InstanceForm.BDatabase.RollbackTransaction();
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolbtnSav_Click(object sender, EventArgs e)
        {
            Guid log_djid = Guid.Empty;
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("�������Ű��������", "��ʾ");
                return;
            }

            InstanceForm.BDatabase.BeginTransaction();
            try
            {
                ParameterEx[] parameters3 = new ParameterEx[6];
                parameters3[0].Text = "@MC";
                parameters3[0].Value = txtName.Text.Trim();
                parameters3[1].Text = "@BZK";
                parameters3[1].Value = cbbOpen.SelectedIndex.ToString();
                parameters3[2].Text = "@PXXH";
                parameters3[2].Value = txtPXXH.Text.Trim();
                parameters3[3].Text = "@id";
                parameters3[3].Value = _id;
                parameters3[4].Text = "@i";
                int iii = 0;
                if (mod == 0) iii = 1;
                if (mod == 1) iii = 2;
                parameters3[4].Value = iii;

                parameters3[5].Text = "@newid";
                parameters3[5].ParaDirection = ParameterDirection.Output;
                parameters3[5].DataType = System.Data.DbType.Int32;
                parameters3[5].ParaSize = 100;

                InstanceForm.BDatabase.DoCommand("SP_JC_MZPB_FLSZ", parameters3, 60);
                if (mod == 0)
                {
                    //��Ժ���ݴ���_____������־
                    string newid = Convertor.IsNull(parameters3[5].Value, "");
                    string bz = "";
                    bz = "���������Ű��������:" + txtName.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, bz, "JC_MZ_YSPB_KSFL", "ID", newid, InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);

                }
                if (mod == 1)
                {

                    //��Ժ���ݴ���_____������־
                    string bz = "";
                    bz = "���������Ű��������:" + txtName.Text.ToString().Trim();
                    ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, bz, "JC_MZ_YSPB_KSFL", "ID", _id.ToString(), InstanceForm._menuTag.Jgbm, 0, "", out log_djid, InstanceForm.BDatabase);
                }

                InstanceForm.BDatabase.CommitTransaction();

                ThisStatus();
                dgvflsz.Enabled = true;
                Bangding();
                ReadTxt();

                //��Ժ���ݴ���___ִ��ͬ������ 
                string errtext = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty) //ֻ�е�����ִ�б�־Ϊ1ʱ��ִ��
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out errtext);
                    if (errtext != "") MessageBox.Show(errtext, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvflsz_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvflsz.DataSource;

            if (dt == null || dt.Rows.Count == 0)
                return;

            int nrow = 0;

            if (dgvflsz.CurrentCell != null)
                nrow = dgvflsz.CurrentCell.RowIndex;

            _id = Convert.ToInt32(dt.Rows[nrow]["ID"].ToString().Trim());
            txtName.Text = dt.Rows[nrow]["MC"].ToString().Trim();
            cbbOpen.Text = dt.Rows[nrow]["BZK"].ToString().Trim();
            txtPXXH.Text = dt.Rows[nrow]["PXXH"].ToString().Trim();
        }

        private void toolbtnCal_Click(object sender, EventArgs e)
        {
            ReadTxt();
            ThisStatus();
            mod = 0;
            dgvflsz.Enabled = true;
            dgvflsz_CurrentCellChanged(null, null);
        }

        //�ж��Ƿ�Ϊ�༭״̬
        private void caozuo()
        {
            if (mod == 0)
            {
                ReadTxt();
                dgvflsz.ReadOnly = true;
            }

            if (mod == 1)
            {
                dgvflsz.ReadOnly = true;
            }
        }

        private void toolbtnRef_Click(object sender, EventArgs e)
        {
            Bangding();
            mod = 0;
            caozuo();
        }

        private void toolbtnClo_Click(object sender, EventArgs e)
        {
            ReadTxt();
            if (MessageBox.Show("��ȷ��Ҫ�˳���", "�˳���ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.OK)
                this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((int)e.KeyCode == 13)
            //{
            //    txtItemName.Focus();
            //}

            if ((int)e.KeyCode == 13)
            {
                cbbOpen.Focus();
            }
        }

        private void cbbOpen_KeyDown(object sender, KeyEventArgs e)
        {
            txtPXXH.Focus();
        }

        private void txtPXXH_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13)
            {
                if (mod == 1)
                {
                    if (MessageBox.Show("��ȷ��Ҫ�޸�������¼��", "�޸���ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        toolbtnSav_Click(null, null);
                    }
                }
                else
                {
                    if (MessageBox.Show("��ȷ��Ҫ���������¼��", "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        toolbtnSav_Click(null, null);
                    }
                }
            }
        }

        private void dgvflsz_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {

                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,

                    Convert.ToInt32(e.RowBounds.Location.Y + (e.RowBounds.Height - dgvflsz.RowHeadersDefaultCellStyle.Font.Size) / 2),

                    dgvflsz.RowHeadersWidth - 4, e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),

                    dgvflsz.RowHeadersDefaultCellStyle.Font, rectangle, dgvflsz.RowHeadersDefaultCellStyle.ForeColor,

                    TextFormatFlags.Right);

            }
            catch (Exception ex)
            {

                Console.Write("dgvflsz_RowPostPaint��" + ex.Message);

            }
        }

        private void tooltextsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strVal = this.tooltextsearch.Text.Trim().Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]");
                if (strVal != "")
                {
                    DataTable dt = (DataTable)dgvflsz.DataSource;
                    DataView dv = dt.DefaultView;
                    string strFilter1 = "MC like '" + strVal + "%'";
                    dv.RowFilter = strFilter1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ѯ���󣬰����Ƿ��ַ�" + ex.Message);
            }
        }

        private void Frm_yspb_flsz_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F3)
            {
                toolbtnAdd_Click(sender, e);
            }
            if (e.KeyData == Keys.F4)
            {
                toolbtnMod_Click(sender, e);
            }
            if (e.KeyData == Keys.F2)
            {
                toolbtnSav_Click(sender, e);
            }
        }
    }
}

