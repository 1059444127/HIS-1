using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_kgl
{
    public partial class Frmklxsz : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Frmklxsz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.Text = this.Text + " [" + InstanceForm._menuTag.Jgbm + "]";
        }

        private void Frmklxsz_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            FillData();
        }

        private void FillData()
        {
            //Modify by Kevin 2013-04-03 csje,mzorzy,isycx
            string ssql = "select klx,klxmc,bjebz,bqfgz,bqybz,binput,bmm,mrmm,kcd,xh,id,rtrim(item_name)+'  '+cast(cast(cost_price as float) as varchar(20))+'Ԫ' sfxm,csje,mzorzy,isycx from JC_KLX a left join jc_hsitemdiction b  on a.sfxmid=b.item_id order by xh";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            this.dataGridView1.DataSource = tb;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;

            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;
            string[] ss = new string[tb.Rows.Count];

            try
            {


                string ssql = "";

                InstanceForm.BDatabase.BeginTransaction();
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["id"], "0"));
                    int klx = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["klx"], "0"));
                    string klxmc = tb.Rows[i]["klxmc"].ToString().Trim();
                    int bjebz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bjebz"], "0"));
                    int bqfgz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bqfgz"], "0"));
                    int bqybz = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bqybz"], "0"));
                    int bmm = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["bmm"], "0"));
                    string mrmm = tb.Rows[i]["mrmm"].ToString().Trim();
                    int kcd = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["kcd"], "0"));
                    int xh = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["xh"], "0"));
                    int binput = Convert.ToInt16(Convertor.IsNull(tb.Rows[i]["binput"], "0"));
                    //Modify by Kevin 2013-04-03
                    //begin
                    decimal csje = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["csje"], "0"));  //��ʼ���
                    int mzzy = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["mzorzy"], "0"));  //����סԺ
                    int isycx = Convert.ToInt32(Convertor.IsNull(tb.Rows[i]["isycx"], "0"));  //�Ƿ�һ��������
                    //end

                    if (klx <= 0) throw new Exception("�����ͱ������");
                    if (klxmc == "") throw new Exception("���������Ʊ���");
                    if (kcd == 0) throw new Exception("�����ȱ���");
                    if (xh == 0) throw new Exception("��������ű���");
                    if (bmm == 1 && mrmm == "")
                        throw new Exception("����������֤ʱ,Ĭ���������");
                    //Modify by Kevin 2013-04-03
                    if (mzzy < 1 && mzzy > 2)  //��ֹά����Ա���������֣���ɼ�������
                        throw new Exception("���������סԺ��������,����������");


                    //Modify by Kevin 2013-04-03 csje,mzorzy,isycx
                    if (id == 0)
                        ssql = "insert into JC_KLX(klx,klxmc,bjebz,bqfgz,bqybz,bmm,mrmm,kcd,xh,binput,csje,mzorzy,isycx)values(" + klx + ",'" + klxmc + "'," + bjebz + "," + bqfgz + "," + bqybz + "," + bmm + ",'" + mrmm + "'," + kcd + "," + xh + "," + binput + ",'" + csje + "'," + mzzy + "," + isycx + ")";
                    else
                        ssql = "update JC_KLX set klx=" + klx + ",klxmc='" + klxmc + "',bjebz=" + bjebz + ",bqfgz=" + bqfgz + ",bqybz=" + bqybz + ",bmm=" + bmm + ",mrmm='" + mrmm + "',kcd=" + kcd + ",xh=" + xh + ",binput=" + binput + ",csje = '" + csje + "',mzorzy = " + mzzy + ",isycx = " + isycx + " where id=" + id + "";
                    InstanceForm.BDatabase.DoCommand(ssql);

                    //��Ժ���ݴ���
                    ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, "���������� ��" + klxmc + " ��", "jc_klx", "klx", klx.ToString(), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);
                    ss[i] = log_djid.ToString();
                }
                InstanceForm.BDatabase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                //��Ժ���ݴ���
                string msg = "";
                for (int i = 0; i <= ss.Length - 1; i++)
                {
                    if (Convertor.IsNull(ss[i], "") == "") continue;
                    string errtext = "";
                    ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, InstanceForm.BDatabase);
                    if (ty.Bzx == 1)
                    {
                        ts.Pexec_log(new Guid(ss[i]), InstanceForm.BDatabase, out errtext);
                        msg = msg + errtext;
                    }
                }

                MessageBox.Show("����ɹ�" + msg);
                FillData();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void butdel_Click(object sender, EventArgs e)
        {
            ts_HospData_Share.ts_update_log ts = new ts_HospData_Share.ts_update_log();
            Guid log_djid = Guid.Empty;

            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb.Rows.Count == 0) return;
            int nrow = dataGridView1.CurrentCell.RowIndex;
            if (MessageBox.Show("��ȷ��Ҫɾ�� [" + Convertor.IsNull(tb.Rows[nrow]["klxmc"], "") + "] �� ��", "ѯ�ʴ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                int id = Convert.ToInt32(Convertor.IsNull(tb.Rows[nrow]["id"], "0"));
                string ssql = "delete from JC_KLX where id=" + id + "";
                InstanceForm.BDatabase.DoCommand(ssql);


                //��Ժ���ݴ���
                ts.Save_log(ts_HospData_Share.czlx.jc_�������ݵ����޸�, "ɾ��������:��" + tb.Rows[nrow]["klxmc"].ToString() + "��", "jc_klx", "klx", tb.Rows[nrow]["klx"].ToString(), InstanceForm._menuTag.Jgbm, -999, "", out log_djid, InstanceForm.BDatabase);


                InstanceForm.BDatabase.CommitTransaction();

                dataGridView1.Rows.Remove(dataGridView1.Rows[nrow]);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                //��Ժ���ݴ���
                string msg = "";
                ts_HospData_Share.ts_update_type ty = new ts_HospData_Share.ts_update_type((int)ts_HospData_Share.czlx.jc_�������ݵ����޸�, InstanceForm.BDatabase);
                if (ty.Bzx == 1 && log_djid != Guid.Empty)
                {
                    ts.Pexec_log(log_djid, InstanceForm.BDatabase, out msg);
                }

                if (msg != "")
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception err)
            {
                MessageBox.Show("��������" + err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            DataRow row = tb.NewRow();
            tb.Rows.Add(row);
            dataGridView1.DataSource = tb;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["�����ͱ���"];
            dataGridView1.Focus();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                if (dataGridView1.CurrentCell.RowIndex != dataGridView1.Rows.Count - 1) return;
                if (dataGridView1.CurrentCell.ColumnIndex + 1 <= dataGridView1.Columns.Count - 1)
                {
                    if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex + 1].Width > 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex + 1];
                        return;
                    }
                }
                if (dataGridView1.CurrentCell.ColumnIndex + 1 > dataGridView1.Columns.Count - 2)
                {
                    butnew_Click(sender, e);
                }
            }
        }






    }
}