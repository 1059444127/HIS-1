using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;
using TrasenFrame.Classes;

namespace ts_mz_tjbb
{
    public partial class FrmBaseReport : Form
    {
        public FrmBaseReport()
        {
            InitializeComponent();
        }

        protected GridppReport report = new GridppReport();
        private Form _mdiParent;
        public MenuTag _menuTag;
        private string _chineseName;

        private string reportFilename;
        protected DataTable dt;

        protected string querySQL;
        [Description("������ش洢�����ַ���")]
        public string QuerySQL
        {
            set { querySQL = value; }
        }

        public FrmBaseReport(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            InitializeComponent();
            InitForm(menuTag, chineseName, mdiParent, reportFilename);            
        }

        protected virtual void InitForm(MenuTag menuTag, string chineseName, Form mdiParent, string reportFilename)
        {
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.reportFilename = reportFilename;

            title.Text = _chineseName;

            title.TextAlign = ContentAlignment.MiddleCenter;
            //Add by HXY 20140826 ���ÿ�ʼʱ��ͽ���ʱ��Ϊ��ǰ���ǰһ��
            dtpBegin.Value = dtpBegin.Value.AddDays(-1);
            dtpEnd.Value = dtpEnd.Value.AddDays(-1);
        }

        protected virtual void ConstructFun(string reportFilename)
        {
            report = new GridppReport();

            report.Initialize += new _IGridppReportEvents_InitializeEventHandler(Report_Initialize);
            report.LoadFromFile(Constant.ApplicationDirectory + "\\" + reportFilename);

            report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

        }

        void report_FetchRecord()
        {
            FillFieldRecordToReport(report, dt);
        }

        public static void FillFieldRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //�����ֶ������������ƽ���ƥ�䣬����DataReader�ֶ���Grid++Report��¼�����ֶ�֮��Ķ�Ӧ��ϵ
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // �� DataTable �е�ÿһ����¼ת���� Grid++Report �����ݼ���ȥ
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }
        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }

        private void Report_Initialize()
        {
            ReportInit();
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        protected virtual void ReportInit()
        {
            //��ʼ����
            if (report.ParameterByName("beginDate") != null)
                report.ParameterByName("beginDate").AsString = this.dtpBegin.Value.ToString("yyyy��MM��dd��");
            if (report.ParameterByName("endDate") != null)
                report.ParameterByName("endDate").AsString = this.dtpEnd.Value.ToString("yyyy��MM��dd��");
        }

        /// <summary>
        /// ����ͳ�Ʊ�����Ϣ
        /// </summary>
        protected virtual void Retrieve()
        {
            dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
            this.dgvResult.DataSource = dt;
        }

        protected virtual void Preview()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.PrintPreview(true);
            }
        }

        protected virtual void Export()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.ExportDirect(GRExportType.gretXLS, this.Text, true, true);
                report.UnprepareExport();
            }
        }

        protected virtual void Print()
        {
            if (dt != null)
            {
                ConstructFun(reportFilename);
                report.Print(true);
            }
        }

        protected virtual object[] SetParams()
        {
            object[] procedureParams = new object[2];

            procedureParams[0] = this.dtpBegin.Value.Date;
            procedureParams[1] = this.dtpEnd.Value.Date;

            return procedureParams;
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = TrasenClasses.GeneralClasses.PubStaticFun.WaitCursor();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Retrieve();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Preview();
        }

        private void FrmBaseReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            AddColunm();
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow == null) return;
            int crow = dgvResult.CurrentRow.Index;
            showDetail(crow);
        }

        protected virtual void showDetail(int crow)
        {
            switch (_menuTag.Function_Name)
            {
                case "Fun_MZ_HTDW_QFHZB":
                    {
                        int htdwid = Convert.ToInt32(dgvResult.Rows[crow].Cells["HTDWID"].Value.ToString());
                        string htdwmc = dgvResult.Rows[crow].Cells["����"].Value.ToString();

                        FrmBaseReport_detail frmDetail = new FrmBaseReport_detail(htdwid, this.dtpBegin.Value.Date, this.dtpEnd.Value.Date, "���ﲡ��δ����Ƿ����ϸ", "���ﲡ��δ����Ƿ����ϸ��.grf", htdwmc);
                        frmDetail.QuerySQL = "execute dbo.SP_MZ_HTDW_QFHZB_MX '{0}','{1}',{2}";

                        frmDetail.ShowDialog();
                        break;
                    }
            }

        }

        protected virtual void AddColunm()
        {
            switch (_menuTag.Function_Name)
            {
                case "Fun_MZ_HTDW_QFHZB":
                    {
                        this.dgvResult.Columns.Add("HTDWID", "HTDWID");
                        this.dgvResult.Columns["HTDWID"].DataPropertyName = "HTDWID";
                        this.dgvResult.Columns["HTDWID"].Visible = false;

                        this.dgvResult.Columns.Add("����", "����");
                        this.dgvResult.Columns["����"].DataPropertyName = "����";
                        this.dgvResult.Columns["����"].Width = 200;

                        this.dgvResult.Columns.Add("����", "����");
                        this.dgvResult.Columns["����"].DataPropertyName = "����";
                        this.dgvResult.Columns["����"].Width = 100;

                        this.dgvResult.Columns.Add("�ܷ���", "�ܷ���");
                        this.dgvResult.Columns["�ܷ���"].DataPropertyName = "�ܷ���";
                        this.dgvResult.Columns["�ܷ���"].Width = 100;

                        this.dgvResult.Columns.Add("Ƿ�Ѷ�", "Ƿ�Ѷ�");
                        this.dgvResult.Columns["Ƿ�Ѷ�"].DataPropertyName = "Ƿ�Ѷ�";
                        this.dgvResult.Columns["Ƿ�Ѷ�"].Width = 100;
                        break;
                    }
                case "Fun_MZ_HTDW_WJSHZB":
                    {

                        this.dgvResult.Columns.Add("��ͬ��λ", "��ͬ��λ");
                        this.dgvResult.Columns["��ͬ��λ"].DataPropertyName = "��ͬ��λ";
                        this.dgvResult.Columns["��ͬ��λ"].Width = 200;

                        this.dgvResult.Columns.Add("�ڳ����", "�ڳ����");
                        this.dgvResult.Columns["�ڳ����"].DataPropertyName = "�ڳ����";
                        this.dgvResult.Columns["�ڳ����"].Width = 120;

                        this.dgvResult.Columns.Add("�������Ӷ�", "�������Ӷ�");
                        this.dgvResult.Columns["�������Ӷ�"].DataPropertyName = "�������Ӷ�";
                        this.dgvResult.Columns["�������Ӷ�"].Width = 120;

                        this.dgvResult.Columns.Add("���ڼ��ٶ�", "���ڼ��ٶ�");
                        this.dgvResult.Columns["���ڼ��ٶ�"].DataPropertyName = "���ڼ��ٶ�";
                        this.dgvResult.Columns["���ڼ��ٶ�"].Width = 120;

                        this.dgvResult.Columns.Add("�������", "�������");
                        this.dgvResult.Columns["�������"].DataPropertyName = "�������";
                        this.dgvResult.Columns["�������"].Width = 120;
                        break;
                    }
                case "Fun_MZSF_GH_CF_LIST":
                    {

                        this.dgvResult.Columns.Add("�����", "�����");
                        this.dgvResult.Columns["�����"].DataPropertyName = "�����";
                        this.dgvResult.Columns["�����"].Width = 150;

                        this.dgvResult.Columns.Add("����", "����");
                        this.dgvResult.Columns["����"].DataPropertyName = "����";
                        this.dgvResult.Columns["����"].Width = 100;

                        this.dgvResult.Columns.Add("ʵ�ս��", "ʵ�ս��");
                        this.dgvResult.Columns["ʵ�ս��"].DataPropertyName = "ʵ�ս��";
                        this.dgvResult.Columns["ʵ�ս��"].Width = 100;

                        this.dgvResult.Columns.Add("�ֽ�֧��", "�ֽ�֧��");
                        this.dgvResult.Columns["�ֽ�֧��"].DataPropertyName = "�ֽ�֧��";
                        this.dgvResult.Columns["�ֽ�֧��"].Width = 100;

                        this.dgvResult.Columns.Add("ˢ����", "ˢ����");
                        this.dgvResult.Columns["ˢ����"].DataPropertyName = "ˢ����";
                        this.dgvResult.Columns["ˢ����"].Width = 80;

                        this.dgvResult.Columns.Add("ҽ����", "ҽ����");
                        this.dgvResult.Columns["ҽ����"].DataPropertyName = "ҽ����";
                        this.dgvResult.Columns["ҽ����"].Width = 80;

                        this.dgvResult.Columns.Add("���˶�", "���˶�");
                        this.dgvResult.Columns["���˶�"].DataPropertyName = "���˶�";
                        this.dgvResult.Columns["���˶�"].Width = 80;

                        this.dgvResult.Columns.Add("�շ�����", "�շ�����");
                        this.dgvResult.Columns["�շ�����"].DataPropertyName = "�շ�����";
                        this.dgvResult.Columns["�շ�����"].Width = 120;

                        this.dgvResult.Columns.Add("�շ�Ա", "�շ�Ա");
                        this.dgvResult.Columns["�շ�Ա"].DataPropertyName = "�շ�Ա";
                        this.dgvResult.Columns["�շ�Ա"].Width = 80;

                        this.dgvResult.Columns.Add("�Һſ���", "�Һſ���");
                        this.dgvResult.Columns["�Һſ���"].DataPropertyName = "�Һſ���";
                        this.dgvResult.Columns["�Һſ���"].Width = 100;

                        this.dgvResult.Columns.Add("�Һż���", "�Һż���");
                        this.dgvResult.Columns["�Һż���"].DataPropertyName = "�Һż���";
                        this.dgvResult.Columns["�Һż���"].Width = 100;

                        this.dgvResult.Columns.Add("�̵��", "�̵��");
                        this.dgvResult.Columns["�̵��"].DataPropertyName = "�̵��";
                        this.dgvResult.Columns["�̵��"].Width = 100;
                        break;
                    }
                case "Fun_MZSF_HTDWHK_LIST":
                    this.dgvResult.Columns.Add("���˵�λ", "���˵�λ");
                    this.dgvResult.Columns["���˵�λ"].DataPropertyName = "���˵�λ";
                    this.dgvResult.Columns["���˵�λ"].Width = 200;

                    this.dgvResult.Columns.Add("����", "����");
                    this.dgvResult.Columns["����"].DataPropertyName = "����";
                    this.dgvResult.Columns["����"].Width = 100;

                    this.dgvResult.Columns.Add("�շ�����", "�շ�����");
                    this.dgvResult.Columns["�շ�����"].DataPropertyName = "�շ�����";
                    this.dgvResult.Columns["�շ�����"].Width = 150;

                    this.dgvResult.Columns.Add("���", "���");
                    this.dgvResult.Columns["���"].DataPropertyName = "���";
                    this.dgvResult.Columns["���"].Width = 100;

                    this.dgvResult.Columns.Add("�շ�Ա", "�շ�Ա");
                    this.dgvResult.Columns["�շ�Ա"].DataPropertyName = "�շ�Ա";
                    this.dgvResult.Columns["�շ�Ա"].Width = 80;

                    this.dgvResult.Columns.Add("�̵��", "�̵��");
                    this.dgvResult.Columns["�̵��"].DataPropertyName = "�̵��";
                    this.dgvResult.Columns["�̵��"].Width = 80;

                    this.dgvResult.Columns.Add("��Ʊ��", "��Ʊ��");
                    this.dgvResult.Columns["��Ʊ��"].DataPropertyName = "��Ʊ��";
                    this.dgvResult.Columns["��Ʊ��"].Width = 80;

                    this.dgvResult.Columns.Add("������ˮ��", "������ˮ��");
                    this.dgvResult.Columns["������ˮ��"].DataPropertyName = "������ˮ��";
                    this.dgvResult.Columns["������ˮ��"].Width = 150;
                    break;
                case "Fun_MZSF_HTDWMX":
                case "Fun_MZSF_HTDWMX_WJS":
                    if (dt == null) dt = InstanceForm.BDatabase.GetDataTable(string.Format(querySQL, SetParams()));
                    foreach (DataColumn Col in dt.Columns)
                    {
                        string name = Col.ColumnName;
                        this.dgvResult.Columns.Add(name,name);
                        this.dgvResult.Columns[name].DataPropertyName = name;
                        this.dgvResult.Columns[name].Width = 100;
                    }
                    break;
                case "Fun_mz_zy_zzb":
                    {
                        this.dgvResult.Columns.Add("����", "����");
                        this.dgvResult.Columns["����"].DataPropertyName = "����";
                        this.dgvResult.Columns["����"].Width = 100;

                        this.dgvResult.Columns.Add("סԺ�ܷ���", "סԺ�ܷ���");
                        this.dgvResult.Columns["סԺ�ܷ���"].DataPropertyName = "סԺ�ܷ���";
                        this.dgvResult.Columns["סԺ�ܷ���"].Width = 200;

                        this.dgvResult.Columns.Add("��Ժ�˴�", "��Ժ�˴�");
                        this.dgvResult.Columns["��Ժ�˴�"].DataPropertyName = "��Ժ�˴�";
                        this.dgvResult.Columns["��Ժ�˴�"].Width = 150;

                        this.dgvResult.Columns.Add("�����ܷ���", "�����ܷ���");
                        this.dgvResult.Columns["�����ܷ���"].DataPropertyName = "�����ܷ���";
                        this.dgvResult.Columns["�����ܷ���"].Width = 200;

                        this.dgvResult.Columns.Add("����Һ��˴�", "����Һ��˴�");
                        this.dgvResult.Columns["����Һ��˴�"].DataPropertyName = "����Һ��˴�";
                        this.dgvResult.Columns["����Һ��˴�"].Width = 250;
                        break;
                    }
            }
        }

    }
}