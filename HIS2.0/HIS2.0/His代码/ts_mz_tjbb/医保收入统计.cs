using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Forms;

namespace ts_mz_tjbb
{
    /// <summary>
    /// �����������ͳ��
    /// </summary>
    public partial class FrmYbsrtj : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;

        /// <summary>
        /// ���캯��
        /// </summary>
        public FrmYbsrtj(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            this.Text = chineseName;
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            dtp1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 0:00:00"));
            this.WindowState = FormWindowState.Maximized;
        }

        // ͳ��
        private void butcx_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtp1.Value > dtp2.Value)
                {
                    MessageBox.Show("��ʼ���ڲ��ܴ��ڽ������ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ParameterEx[] parameters = new ParameterEx[5];
                parameters[0].Text = "@KSRQ";
                parameters[0].Value = dtp1.Value.ToString();

                parameters[1].Text = "@JSRQ";
                parameters[1].Value = dtp2.Value.ToString();

                parameters[2].Text = "@KSDM";
                parameters[2].Value = Convertor.IsNull(cmbksmc.SelectedValue, "");

                parameters[3].Text = "@YBLX";
                parameters[3].Value = Convertor.IsNull(cmbyblx.SelectedValue, "");

                parameters[4].Text = "@SFY";
                parameters[4].Value = Convertor.IsNull(cmbsfy.SelectedValue, "");

                DataSet dset = new DataSet();
                FrmMdiMain.Database.AdapterFillDataSet("SP_MZ_YBSRTJ", parameters, dset, "ybsrtj", 30);

                dgvData.Columns.Clear();
                DataTable dt = dset.Tables[0];

                #region ����ϼ�
                double tcze = 0;
                double ylzfy = 0;
                int brrs = 0;
                double cjfy = 0;
                double ypze = 0;
                double jcf = 0;
                double clf = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    tcze += dr["ͳ���ܶ�"] is DBNull ? 0 : Convert.ToDouble(dr["ͳ���ܶ�"]);
                    ylzfy += dr["ҽ���ܷ���"] is DBNull ? 0 : Convert.ToDouble(dr["ҽ���ܷ���"]);
                    //brrs += dr["��������"] is DBNull ? 0 : Convert.ToInt32(dr["��������"]);
                    cjfy += dr["�ξ�����"] is DBNull ? 0 : Convert.ToDouble(dr["�ξ�����"]);
                    ypze += dr["�����˴�ҩƷ�ܶ�"] is DBNull ? 0 : Convert.ToDouble(dr["�����˴�ҩƷ�ܶ�"]);
                    jcf += dr["����"] is DBNull ? 0 : Convert.ToDouble(dr["����"]);
                    clf += dr["���Ϸ�"] is DBNull ? 0 : Convert.ToDouble(dr["���Ϸ�"]);
                }
                dt.Rows.Add(new object[]
                {
                    DBNull.Value, "�ϼ�", "", tcze.ToString("#0.00"), ylzfy.ToString("#0.00"), cjfy.ToString("#0.00"), ypze.ToString("#0.00"), DBNull.Value, jcf.ToString("#0.00"), DBNull.Value, clf.ToString("#0.00"), DBNull.Value
                });
                #endregion

                dgvData.DataSource = dt;
                dgvData.Rows[dgvData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ͳ��ʱ��������" + Environment.NewLine + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // �ر�
        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ����
        private void Frmjzlscx_Load(object sender, EventArgs e)
        {
            // ���Ұ�
            FunAddComboBox.AddDept(true, 1, cmbksmc, InstanceForm.BDatabase);
            // �շ�Ա��
            FunAddComboBox.AddOperator(true, cmbsfy, InstanceForm.BDatabase);
            // ҽ�����Ͱ�
            FunAddComboBox.AddYblx(true, 0, cmbyblx, InstanceForm.BDatabase);

            cmbksmc.SelectedIndex = 0;
            cmbsfy.SelectedIndex = 0;
            cmbyblx.SelectedIndex = 0;
        }

        private void butexcel_Click(object sender, EventArgs e)
        {
            if ( dgvData.DataSource == null )
                return;

            try
            {
                this.Cursor = PubStaticFun.WaitCursor();
                this.btnExcel.Enabled = false;
                DataTable tb = dgvData.DataSource as DataTable;
                string swhere = string.Format("�������ƣ�{0}  ҽ�����ͣ�{1}  �շ�Ա��{2}  �շ�ʱ�䣺{3} �� {4}", cmbksmc.Text, cmbyblx.Text, cmbsfy.Text, dtp1.Text, dtp2.Text);
                ExportToExcel(tb, Constant.HospitalName + " " + this.Text, swhere);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("����Excelʱ��������" + Environment.NewLine + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.btnExcel.Enabled = true;
            }

        }

        private void butprinthz_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable tbmx = (DataTable)dataGridView1.DataSource;

            //    ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();

            //    DataRow myrow = Dset.�շ���Ŀ.NewRow();
            //    for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
            //    {
            //        int x = i + 1;
            //        string nm = "T" + x.ToString();
            //        myrow[nm] = tbmx.Columns[i].ColumnName.Trim();
            //    }
            //    Dset.�շ���Ŀ.Rows.Add(myrow);

            //    for (int nrow = 0; nrow <= tbmx.Rows.Count - 1; nrow++)
            //    {
            //        DataRow myrow1 = Dset.�շ���Ŀ���.NewRow();
            //        for (int i = 0; i <= tbmx.Columns.Count - 1; i++)
            //        {
            //            int x = i + 1;
            //            string nm = "JE" + x.ToString();
            //            myrow1[nm] = tbmx.Rows[nrow][tbmx.Columns[i].ColumnName].ToString();
            //        }
            //        Dset.�շ���Ŀ���.Rows.Add(myrow1);
            //    }


            //    ParameterEx[] parameters = new ParameterEx[5];

            //    parameters[0].Text = "ҽԺ����";
            //    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName;

            //    parameters[1].Text = "�����";
            //    parameters[1].Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToShortDateString();

            //    string ss = "����:" + cmbjgbm.Text;
            //    if (Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0") ss = ss + " ҽ������:" + cmbyblx.Text.Trim();
            //    if (Convertor.IsNull(cmbsfy.SelectedValue, "0") != "0") ss = ss + " �շ�Ա:" + cmbsfy.Text.Trim();
            //    ss = ss + " �շ�����:" + dtp1.Value.ToString() + " �� " + dtp2.Value.ToString();

            //    parameters[2].Text = "��ע";
            //    parameters[2].Value = ss;

            //    parameters[3].Text = "�ֽ��д";
            //    parameters[3].Value = "";

            //    parameters[4].Text = "����Ա";
            //    parameters[4].Value = InstanceForm.BCurrentUser.Name;

            //    TrasenFrame.Forms.FrmReportView f;
            //    f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_ҽ������ͳ��(����).rpt", parameters);
            //    if (f.LoadReportSuccess)
            //        f.Show();
            //    else
            //        f.Dispose();
            //}
            //catch (System.Exception err)
            //{
            //    MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = dgvData.DataSource as DataTable;
                //TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dt, Constant.ApplicationDirectory + "\\Report\\MZYBSRTJ.rpt", null);
                //if (f.LoadReportSuccess)
                //    f.Show();
                //else
                //    f.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// �������ݱ�Excel
        /// </summary>
        /// <param name="table">���ݱ�</param>
        /// <param name="title">����</param>
        /// <param name="info">�����Ϣ</param>
        private void ExportToExcel(DataTable table, string title, string info)
        {
            if (table == null)
                return;

            Excel.Application myExcel = new Excel.Application();
            myExcel.Application.Workbooks.Add(true);

            //д����ͷ
            int sumRowCount = table.Rows.Count;
            int sumColCount = 0;

            for (int j = 0; j < table.Columns.Count; j++)
            {
                sumColCount += 1;
                myExcel.Cells[5, sumColCount] = table.Columns[j].ColumnName;
            }
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5, sumColCount]).Font.Size = 10;

            //����д������
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int ncol = 0;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    ncol = ncol + 1;
                    myExcel.Cells[6 + i, ncol] = "'" + table.Rows[i][j].ToString().Trim();
                }
            }

            //���ñ�����Ϊ����Ӧ���
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[6, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Columns.AutoFit();

            //�ӱ߿�
            myExcel.get_Range(myExcel.Cells[5, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Borders.LineStyle = 1;

            //��������
            myExcel.Cells[1, 1] = title;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Bold = true;
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Font.Size = 16;
            //�������ƿ��о���
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[1, 1], myExcel.Cells[1, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection;

            //��������
            myExcel.Cells[3, 1] = info.Trim();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Font.Size = 10;
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[3, sumColCount]).Select();
            myExcel.get_Range(myExcel.Cells[3, 1], myExcel.Cells[5, sumColCount]).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //���һ��Ϊ��ɫ
            myExcel.get_Range(myExcel.Cells[5 + sumRowCount, 1], myExcel.Cells[5 + sumRowCount, sumColCount]).Interior.ColorIndex = 19;

            //��Excel�ļ��ɼ�
            myExcel.Visible = true;
        }

        private void FrmYbsrtj_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
                btnprint_Click(sender, e);
            else if (e.KeyCode == Keys.Q)
                this.Close();
            else if (e.KeyCode == Keys.E)
                butexcel_Click(sender, e);
            else if (e.KeyCode == Keys.T)
                butcx_Click(sender, e);
        }
    }
}