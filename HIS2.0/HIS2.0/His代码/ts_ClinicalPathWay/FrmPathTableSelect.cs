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
    public partial class FrmPathTableSelect : Form
    {
        //·��ID
        string _sPathWayId;

        string _sSqlPathTable;
        string _sSqlTable_Way;
        DataTable dtPathTable;
        DataTable dtTable_Way;

        public FrmPathTableSelect(DbOpt.InFoDlg infoDlg)
        {
            //������������
            InitializeComponent();
            //���մӵ��ô��崫�����Ĳ����б�
            this._sPathWayId = infoDlg.pKey1;
        }

        private void FrmPathTableSelect_Load(object sender, EventArgs e)
        {
            LoadPathTable();
            LoadTable_Way();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetNow_Click(object sender, EventArgs e)
        {
            if (dgvPathTable.SelectedRows.Count == 1)
            {
                int iPathTableID = (int)dgvPathTable.SelectedRows[0].Cells["PATH_TABLE_ID"].Value;
                if (dtTable_Way.Rows.Count > 0)
                {
                    dtTable_Way.Rows[0]["PATHTABLEID"] = iPathTableID.ToString();
                    int result = DbOpt.Update(dtTable_Way, this._sSqlTable_Way);
                    if (result > 0)
                    {
                        LoadTable_Way();
                    }
                    else
                    {
                        MessageBox.Show("���ñ�ʧ��.!");
                    }
                }
                else
                {
                    string sSqlInsert = string.Format("INSERT INTO [PATHTABLE_WAY_RELATION] VALUES('{0}',{1},'')", this._sPathWayId, iPathTableID);
                    int result = DbOpt.ExecuteNonQuery(sSqlInsert);
                    if (result > 0)
                    {
                        LoadTable_Way();
                    }
                    else
                    {
                        MessageBox.Show("���ñ�ʧ��.!");
                    }
                }
            }
        }

        void LoadTable_Way()
        {
            try
            {
                this._sSqlTable_Way = string.Format("SELECT * FROM [PATHTABLE_WAY_RELATION] WHERE [PATHWAYID] = '{0}'", this._sPathWayId);
                string sPathTableName = "��";
                dtTable_Way = DbOpt.GetDataTable(this._sSqlTable_Way);
                string sPathTableID = "";
                if (dtTable_Way.Rows.Count > 0)
                {
                    sPathTableID = dtTable_Way.Rows[0]["PATHTABLEID"].ToString();
                    sPathTableName = dtPathTable.Select("PATH_TABLE_ID = " + sPathTableID)[0]["PATH_TABLE_NAME"].ToString();
                }
                lbNow.Text = "��ǰ·��ѡ���:" + sPathTableName;
                lbNow.Tag = sPathTableID;
            }
            catch { }
        }

        void LoadPathTable()
        {
            this._sSqlPathTable = "SELECT * FROM [PATHTABLE] WHERE DELETED = 0";
            dtPathTable = DbOpt.GetDataTable(this._sSqlPathTable);
            dgvPathTable.DataSource = dtPathTable;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dtTable_Way.Rows.Count > 0)
            {
                string sSqlDelete = string.Format("DELETE FROM [PATHTABLE_WAY_RELATION] WHERE [PATHWAYID] = '{0}'", this._sPathWayId);
                int result = DbOpt.ExecuteNonQuery(sSqlDelete);
                if (result > 0)
                {
                    MessageBox.Show("����ɹ�!");
                }
                else
                {
                    MessageBox.Show("���ʧ��!");
                }
                LoadTable_Way();
            }
        }

        private void butAddbd_Click(object sender, EventArgs e)
        {
            FrmAddBdmc fb = new FrmAddBdmc();
            fb.ShowDialog();
            LoadPathTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddBdmc fb = new FrmAddBdmc();
            fb.AddorMOdify = false;
            fb._path_table_id = int.Parse(dtPathTable.DefaultView[this.dgvPathTable.CurrentCell.RowIndex]["PATH_TABLE_ID"].ToString());
            fb.ShowDialog();
            LoadPathTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvPathTable.SelectedRows.Count == 1)
            {
                int iPathTableID = (int)dgvPathTable.SelectedRows[0].Cells["PATH_TABLE_ID"].Value;
                //if (dtTable_Way.Rows.Count > 0)
                {

                    string sSqdelete = string.Format("delete from  [PATHTABLE_WAY_RELATION]  where  PATHTABLEID='{1}' and PATHWAYID='{0}'", this._sPathWayId, iPathTableID);
                    DbOpt.ExecuteNonQuery(sSqdelete);
                    sSqdelete = string.Format("delete from PATHTABLE_STEP_ITEM where   PATH_TABLE_ID='{0}'", iPathTableID);
                    DbOpt.ExecuteNonQuery(sSqdelete);
                    sSqdelete = string.Format("delete   from  PATHTABLE_STEP  where  PATH_TABLE_ID='{0}'", iPathTableID);
                    DbOpt.ExecuteNonQuery(sSqdelete);
                    sSqdelete = string.Format("delete from PATHTABLE where   PATH_TABLE_ID='{0}'", iPathTableID);
                    DbOpt.ExecuteNonQuery(sSqdelete);

                    LoadPathTable();
                    LoadTable_Way();
                }
            }
        }
    }
}