using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using ts_mz_class;
using System.IO;
using System.Net;

namespace ts_mz_tjbb
{
    public partial class FrmCCBRecMx : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private string bDateTime;
        private string eDateTime;
        //��Ԫ����
        RelationalDatabase db = new MsSqlServer();
        private string fHospitalName;//ҽԺ����
        private string fOperName;//����Ա��
        private string fApplicationDir; //������

        public FrmCCBRecMx()
        {
            InitializeComponent();
        }

        public FrmCCBRecMx(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;

            db = InstanceForm.BDatabase;
            fHospitalName = TrasenFrame.Classes.Constant.HospitalName;
            fOperName = InstanceForm.BCurrentUser.Name;
            fApplicationDir = Constant.ApplicationDirectory;
        }

        public FrmCCBRecMx(RelationalDatabase adb)
        {
            InitializeComponent();
            db = adb;
            fHospitalName = "";//ֱ�Ӵ���db������ģʽ����ֱ�Ӹ��ա�
            fOperName = "";
            fApplicationDir = @"D:\TS-HIS";
        }

        private void tsmt_excel1_Click(object sender, EventArgs e)
        {
            string swhere = "";

            swhere = "�������ڴ�:" + bDateTime.ToString() + " ��:" + eDateTime.ToString();
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + label3.Text + "(���ж�)");
        }

        private void tsmt_excel2_Click(object sender, EventArgs e)
        {
            string swhere = "";

            swhere = "�������ڴ�:" + bDateTime.ToString() + " ��:" + eDateTime.ToString();
            ts_jc_log.ExcelOper.ExportData_ForDataTable(this.dataGridView1, Constant.HospitalName + label3.Text + "(ҽԺ��)");
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CcbMxTj(string startTime, string endTime, Guid tjId)
        {
            try
            {
                bDateTime = startTime;
                eDateTime = endTime;

                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@StartTime";
                parameters[0].Value = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[1].Text = "@EndTime";
                parameters[1].Value = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd HH:mm:ss");

                parameters[2].Text = "@TJID";
                parameters[2].Value = tjId;

                DataSet ds = new DataSet();
                db.AdapterFillDataSet("SP_ZZ_CCB_TJMX", parameters, ds, "tjmx", 30);
                Fun.AddRowtNo(ds.Tables[0]);
                Fun.AddRowtNo(ds.Tables[1]);
                this.dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView2.DataSource = ds.Tables[1];

                lblyhzs.Text = ds.Tables[0].Rows.Count.ToString();
                lblyhje.Text = ds.Tables[0].Compute("SUM(���н��׽��)", "").ToString();

                lblyyzs.Text = ds.Tables[1].Rows.Count.ToString();
                lblyyje.Text = ds.Tables[1].Compute("SUM(ҽԺ���׽��)", "").ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //���ж˴�ӡ
        private void tsmt_print1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView1.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._����������������ϸͳ��_���ж�_.NewRow();
                    int x = i + 1;
                    dr["���"] = Convert.ToString(tb.Rows[i]["���"]);
                    dr["���н��״���"] = Convert.ToString(tb.Rows[i]["���н��״���"]);
                    dr["���н�������"] = Convert.ToString(tb.Rows[i]["���н�������"]);
                    dr["���н��׽��"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["���н��׽��"], "0"));
                    dr["����������"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["����������"], "0"));
                    dr["�����̻���"] = Convert.ToString(tb.Rows[i]["�����̻���"]);
                    dr["�����豸���"] = Convert.ToString(tb.Rows[i]["�����豸���"]);
                    dr["�����豸��ˮ��"] = Convert.ToString(tb.Rows[i]["�����豸��ˮ��"]);
                    dset._����������������ϸͳ��_���ж�_.Rows.Add(dr);
                }
                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = fHospitalName;

                parameters[1].Text = "�����";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(db).ToShortDateString();
                parameters[2].Text = "��ע";
                parameters[2].Value = "ͳ������:" + bDateTime.ToString() + " �� " + eDateTime.ToString();

                parameters[3].Text = "ͳ����";
                parameters[3].Value = fOperName;

                string strReportDir = fApplicationDir + "\\Report\\MZ_��������������������ϸͳ�ƣ����жˣ�.rpt";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset._����������������ϸͳ��_���ж�_, strReportDir, parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //ҽԺ�˴�ӡ
        private void tsmt_print2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tb = (DataTable)dataGridView2.DataSource;
                ts_mz_report.DataSet1 dset = new ts_mz_report.DataSet1();
                DataRow dr;
                for (int i = 0; i <= tb.Rows.Count - 1; i++)
                {
                    dr = dset._����������������ϸͳ��_ҽԺ��_.NewRow();
                    int x = i + 1;
                    dr["���"] = Convert.ToString(tb.Rows[i]["���"]);
                    dr["ҽԺ���״���"] = Convert.ToString(tb.Rows[i]["ҽԺ���״���"]);
                    dr["ҽԺ��������"] = Convert.ToString(tb.Rows[i]["ҽԺ��������"]);
                    dr["ҽԺ���׽��"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ҽԺ���׽��"], "0"));
                    dr["ҽԺ������"] = Convert.ToDecimal(Convertor.IsNull(tb.Rows[i]["ҽԺ������"], "0"));
                    dr["ƽ̨��ˮ��"] = Convert.ToString(tb.Rows[i]["ƽ̨��ˮ��"]);
                    dr["�����ն˺�"] = Convert.ToString(tb.Rows[i]["�����ն˺�"]);
                    dset._����������������ϸͳ��_ҽԺ��_.Rows.Add(dr);
                }

                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "ҽԺ����";
                parameters[0].Value = fHospitalName;

                parameters[1].Text = "�����";
                parameters[1].Value = DateManager.ServerDateTimeByDBType(db).ToShortDateString();
                parameters[2].Text = "��ע";
                parameters[2].Value = "ͳ������:" + bDateTime.ToString() + " �� " + eDateTime.ToString();

                parameters[3].Text = "ͳ����";
                parameters[3].Value = fOperName;

                string strReportDir = fApplicationDir + "\\Report\\MZ_��������������������ϸͳ�ƣ�ҽԺ�ˣ�.rpt";
                TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(dset._����������������ϸͳ��_ҽԺ��_, strReportDir, parameters);
                if (f.LoadReportSuccess)
                    f.Show();
                else
                    f.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



