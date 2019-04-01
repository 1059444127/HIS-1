using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_zxd
{
    public partial class Frmzxdprint : Form
    {
        public Frmzxdprint()
        {
            InitializeComponent();
        }

          public Frmzxdprint(string _formText)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;

            myFunc = new BaseFunc();
        }
        public Frmzxdprint(string _formText, int _isqk)
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
            this.Text = _formText;
            ifqk = _isqk;
            myFunc = new BaseFunc();
        }

        //�Զ������
        private BaseFunc myFunc;
        private System.DateTime TempDate;
        private string sPaint = "";
        private int max_len0 = 0, max_len1 = 0, max_len2 = 0;//���ҽ������,���ҽ������(��������λ��),���������λ����	
        private long old_BinID = 0, old_BabyID = 0;
        private int kind = 0;              
        private string kind_name = "���Ƶ�";   	  //����,������
        private int ifqk = 0;//0 ���� 1��
        DataTable freqtb;

        /// <summary>
        /// ������Ϣ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeek_Click(object sender, EventArgs e)
        {
            if (txtZyh.Text.Trim() == "")
                txtZyh.Text = "0";

            string sSql = "";

            sSql = @" SELECT BED_NO AS ����,INPATIENT_NO סԺ��,NAME AS ����,INPATIENT_ID,Baby_ID,DEPT_ID " +
                "   FROM vi_zy_vInpatient_All " +
                "  WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "' and inpatient_no='" + txtZyh.Text.Trim() + "'" +
                "  order by baby_id";

            DataTable myTb = InstanceForm.BDatabase.GetDataTable(sSql);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                MessageBox.Show("û���ҵ��ò�����Ϣ����˶�סԺ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            myFunc.ShowGrid(1, sSql, this.myDataGrid1);

            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "ѡ", "����", "סԺ��", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID" };
            int[] GrdWidth ={ 2, 4, 9, 10, 0, 0, 0 };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            this.bt��ѡ1_Click(sender, e);

            if (new SystemCfg(7008).Config == "��")
            {
                rbѡ��.Visible = true;
                dtpSel.Visible = true;
            }
            else
            {
                rbѡ��.Visible = false;
                dtpSel.Visible = false;
            }

            dtpSel.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
        }

        /// <summary>
        /// ��ҳ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frmzxdprint_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //LoadUseType();
            string sSql = "";
            if (ifqk == 0)
            {
                sSql = "  SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,INPATIENT_ID,Baby_ID,DEPT_ID,WARD_NAME ����" +
                  "    FROM vi_zy_vInpatient_Bed " +
                  "   WHERE WARD_ID= '" + InstanceForm.BCurrentDept.WardId + "'order by BED_NO,baby_id";
            }
            else
            {
                //���в���
                sSql = "  SELECT BED_NO ����,INPATIENT_NO סԺ��,NAME ����,INPATIENT_ID,Baby_ID,DEPT_ID,WARD_NAME ���� " +
                  "    FROM vi_zy_vInpatient_Bed " +
                  "    order by WARD_ID,BED_NO,baby_id";
            }
            myFunc.ShowGrid(1, sSql, this.myDataGrid1);
            int bqwide = 0;
            if (ifqk == 1)
                bqwide = 9;
            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "ѡ", "����", "סԺ��", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "����" };
            int[] GrdWidth ={ 2, 4, 9, 10, 0, 0, 0, bqwide };
            int[] Alignment ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ReadOnly ={ 0, 0, 0, 0, 0, 0, 0, 0 };
            myFunc.InitGrid(GrdMappingName, GrdWidth, Alignment, ReadOnly, this.myDataGrid1);

            //this.bt��ѡ1_Click(sender,e);

            if (new SystemCfg(7008).Config == "��")
            {
                rbѡ��.Visible = true;
                dtpSel.Visible = true;
            }
            else
            {
                rbѡ��.Visible = false;
                dtpSel.Visible = false;
            }

            dtpSel.Value = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);

            //סԺ�ų���
            txtZyh.InpatientNoLength = Convert.ToInt32(new SystemCfg(5026).Config);

            freqtb = FrmMdiMain.Database.GetDataTable("select name ����,id,py_code from JC_FREQUENCY ");
            this.serchText1.tb = freqtb;
        }

        /// <summary>
        /// ������ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt��ѡ1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid1);
        }

        /// <summary>
        /// ����ȫѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btȫѡ1_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid1);
        }

        /// <summary>
        /// ����ѡ�е�Ԫ��仯����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            myFunc.SelRow(this.myDataGrid1);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            myFunc.SelCol_Click(this.myDataGrid1);
        }

        /// <summary>
        /// ����ȫѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btȫѡ2_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(0, this.myDataGrid2);
        }

        /// <summary>
        /// ������ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt��ѡ2_Click(object sender, EventArgs e)
        {
            myFunc.SelectAll(1, this.myDataGrid2);
        }

        /// <summary>
        /// ���ñ��ʽ
        /// </summary>
        /// <param name="GrdMappingName"></param>
        /// <param name="GrdWidth"></param>
        /// <param name="Alignment"></param>
        /// <param name="ReadOnly"></param>
        /// <param name="myDataGrid"></param>
        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].GridColumnStyles.Clear();
            myDataGrid.TableStyles[0].AllowSorting = false; //����������

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "ѡ")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// ������ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //��ɫ������ҽ����״̬ 
            int ColorCol = 0;		 //��ӡ��־
            if (Convert.ToInt16(this.myDataGrid2[e.Row, ColorCol]) == 1)
            {
                //�Ѵ�ӡ
                e.ForeColor = Color.Blue;
            }
            if (Convert.ToInt16(this.myDataGrid2[e.Row, ColorCol]) == 0)
            {
                //û��ӡ
                e.ForeColor = Color.Black;
            }

            //ѡ����
            if (this.myDataGrid2[e.Row, 4].ToString() == "True")
            {
                e.BackColor = Color.GreenYellow;
            }
            else
            {
                e.BackColor = Color.White;
            }
        }

        /// <summary>
        /// ������ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt��ѯ_Click(object sender, EventArgs e)
        {
            string tj = "";
            if (this.textBox1.Text.Trim() != "")
            {
                //ʱ���
                string sjd = this.textBox1.Text.Trim();
                if (sjd.Length == 1)
                    sjd = "0" + sjd + ":00";
                //�õ�ִ��Ƶ�����Ʊ�
                string sql = " select   NAME from JC_FREQUENCY where CHARINDEX('" + sjd + "',EXECTIME)>0";
                DataTable pltb = FrmMdiMain.Database.GetDataTable(sql);
                tj = " (";
                for (int i = 0; i < pltb.Rows.Count; i++)
                {
                    tj += "'" + pltb.Rows[i]["NAME"].ToString() + "',";
                }
                //
                if (tj == " (")
                    tj = "";
                else
                {
                    tj = tj.Substring(0, tj.Length - 1);
                    tj += ")";
                }
            }
            //
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int iSelectRows = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True") iSelectRows += 1;
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ���ˣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SystemCfg cfg7131 = new SystemCfg(7131);
            this.TempDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
            if (this.rb����.Checked)
                TempDate = TempDate.AddDays(1);
            else if (rbѡ��.Checked)
                TempDate = dtpSel.Value;
            string sSql = "", sSql1 = "", sSql2 = "";
            //�ȴ�����
            Cursor.Current = PubStaticFun.WaitCursor();
            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;
            try
            {
                DataTable GrdTb = new DataTable();
                for (int i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    sSql = "";
                    sSql1 = "";
                    sSql2 = "";

                    if (myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        sSql1 += sSql1 == "" ? "" : " or ";
                        sSql1 += " (a.inpatient_id='" + myTb.Rows[i]["INPATIENT_ID"].ToString() + "' and a.baby_id=" + myTb.Rows[i]["Baby_ID"].ToString() + ")";

                        sSql1 += " )";  //ѡ��Ĳ���
                        sSql1 += this.rbȫ��.Checked ? "" : (this.rbû��ӡ.Checked ? " and f.id is null" : " and f.id is not null"); //�Ƿ��ӡ	

                        //���d_code=0 ��ȡ����������;  ���d_code=1,��ֻȡ���� d_code=2,��ֻȡ����
                        sSql = @"SELECT a.INPATIENT_ID,a.order_id,case when f.ID is null then 0 else 1 end as ISPRINT,
                                      '" + myTb.Rows[i]["����"].ToString() + @"' ����,'" + myTb.Rows[i]["����"].ToString() + @"' ����,
                                      case a.mngtype when 0 then '����' else '����'end as ����,a.mngtype,
                                      convert(varchar,datepart(mm,a.Order_bDate)) AS ������,convert(varchar,datepart(hh,a.Order_bDate)) ��ʱ��,
                                      convert(varchar,datepart(dd,a.Order_bDate)) day1,convert(varchar,datepart(mi,a.Order_bDate)) second1,
                                      a.Order_Context AS ������Ŀ,a.unit AS ��λ,a.FREQUENCY AS Ƶ��,'' AS ִ��ʱ��,
                                      case when a.status_flag in(4,5) and a.mngtype=0 then convert(varchar,datepart(mm,a.Order_eDate)) else '' end ͣ����,
                                      case when a.status_flag in(4,5) and a.mngtype=0 then convert(varchar,datepart(hh,a.Order_eDate)) else '' end ͣʱ��,
                                      convert(varchar,datepart(dd,a.Order_eDate)) day2,convert(varchar,datepart(mi,a.Order_eDate)) second2,
                                      dbo.fun_getEmpName(a.AUDITING_USER) AS ǩ��,a.MEMO AS ��ע,a.dept_id,dbo.fun_getdate(a.Order_bDate) as bdate1,dbo.fun_getdate(a.Order_eDate) as edate1,a.group_id,a.BABY_ID
                                      FROM ZY_ORDERRECORD a INNER JOIN JC_YZPRINTSET b ON a.hoitem_id=b.ORDER_ID 
                                      LEFT JOIN ZY_Printzdzxd f ON a.ORDER_ID=f.ORDER_ID 
                                      LEFT JOIN jc_Frequency q ON upper(ltrim(rtrim(a.frequency)))=upper(ltrim(rtrim(q.name)))
                                      WHERE  a.xmly=2 and a.dept_id not in (select deptid from SS_DEPT) AND a.delete_bit=0 ";
                        if (cfg7131.Config.Trim() == "1")
                        {
                            sSql += " and a.status_flag>1 and a.status_flag<=5 and  convert(datetime,dbo.fun_getdate( case when a.mngtype =0 then a.Order_BDate else DATEADD(dd,0-isnull(a.ts,0),a.Order_BDate) end) )<='" + TempDate.ToShortDateString() + "' and (Order_eDate is null or a.status_flag in (2,3) or  " +
                              "convert(datetime,dbo.fun_getdate(case when a.mngtype =0 then a.Order_BDate else DATEADD(dd,isnull(a.ts,0),a.Order_BDate) end))>='" + TempDate.ToShortDateString() + //Modify by zouchihua 2012-6-23 �������ʱҽ��Ҫ����ȥ����
                                //Modify by zouchihua 2012-6-23 �������ʱҽ��Ҫ����ȥ����
                              " ' or (convert(datetime,dbo.fun_getdate(a.Order_EDate))>='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) and a.mngtype=0))" +//Add By Tany 2004-12-06 ����ֹͣ�ĳ���Ҳ��ӡ or  Date(b.Order_EDate)>='" + TempDate.ToShortDateString() + "'
                                //and Date(b.Order_BDate)<='" + TempDate.ToShortDateString() + "' Modify By Tany 2004-11-14
                                //" and a.ward_id='"+ InstanceForm.BCurrentDept.WardId + "'"+
                              " and (((q.lx=1 or q.lx is null) and (datediff(dd,(case a.first_times when 0 then a.order_bdate+1 else a.order_bdate end),'" + TempDate.ToShortDateString() + "') % (case when q.CycleDay is null then 1 else q.CycleDay end))=0) or (q.lx=2 and CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,'" + TempDate.ToShortDateString() + "')),CONVERT(VARCHAR,q.zxr))>0))"; //ҽ��Ƶ�� Modify By Tany 
                        }
                        else
                        {
                            sSql += " and a.status_flag>1 and a.status_flag<=5 and  convert(datetime,dbo.fun_getdate(a.Order_BDate))<='" + TempDate.ToShortDateString() + "' and (Order_eDate is null or a.status_flag in (2,3) or  " +
                              "convert(datetime,dbo.fun_getdate( a.Order_BDate))>='" + TempDate.ToShortDateString() + //Modify by zouchihua 2012-6-23 �������ʱҽ��Ҫ����ȥ����
                                //Modify by zouchihua 2012-6-23 �������ʱҽ��Ҫ����ȥ����
                              " ' or (convert(datetime,dbo.fun_getdate(a.Order_EDate))>='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) and a.mngtype=0))" +//Add By Tany 2004-12-06 ����ֹͣ�ĳ���Ҳ��ӡ or  Date(b.Order_EDate)>='" + TempDate.ToShortDateString() + "'
                                //and Date(b.Order_BDate)<='" + TempDate.ToShortDateString() + "' Modify By Tany 2004-11-14
                                //" and a.ward_id='"+ InstanceForm.BCurrentDept.WardId + "'"+
                              " and (((q.lx=1 or q.lx is null) and (datediff(dd,(case a.first_times when 0 then a.order_bdate+1 else a.order_bdate end),'" + TempDate.ToShortDateString() + "') % (case when q.CycleDay is null then 1 else q.CycleDay end))=0) or (q.lx=2 and CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,'" + TempDate.ToShortDateString() + "')),CONVERT(VARCHAR,q.zxr))>0))"; //ҽ��Ƶ�� Modify By Tany 
                        }
                        //Add By Tany 2004-11-22
                        //ֻ��ʾ�����¿���
                        if (rbOnlyToday.Checked)
                        {
                            sSql += " and convert(datetime,dbo.fun_getdate(a.Order_BDate))='" + TempDate.ToShortDateString() + "' ";
                        }
                        //Add By Tany 2004-12-06
                        //ֻ��ʾ������ͣ��
                        if (rbTodayStop.Checked)
                        {
                            sSql += " and convert(datetime,dbo.fun_getdate(a.Order_EDate))='" + TempDate.ToShortDateString() + "' and a.status_flag in (4,5) ";
                        }
                        //Add By Tany 2004-11-24
                        //��������յģ��򲻴���ʱҽ��
                        if (this.rb����.Checked)
                        {
                            sSql += " and a.mngtype<>1 ";
                        }
                        //Add By Tany 2004-11-25
                        //����ҽ��
                        if (this.rbLongOrders.Checked)
                        {
                            sSql += " and a.mngtype=0 ";
                        }
                        //Add By Tany 2004-11-25
                        //��ʱҽ��
                        if (this.rbTempOrders.Checked)
                        {
                            sSql += " and a.mngtype in(1,5) ";//Modify by zouchihua 2012-6-22 ��ʱҽ������������
                        }
                        //add by zouchihua 2012-4-24 �����˿������ҵ�ѡ��
                        if (this.RbBks.Checked)
                        {
                            sSql += " and ( a.dept_id in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') or a.dept_id=" + InstanceForm.BCurrentDept.DeptId + ")";
                        }
                        if (this.rbQt.Checked)
                        {
                           sSql+= " and a.dept_id not in (select dept_id from jc_wardrdept where ward_id = '" + InstanceForm.BCurrentDept.WardId + "') ";
                        }
                        //add by zouchihua 2013-1-18�����ʱ��㣬�Ͱ���ʱ�����
                        if (this.textBox1.Text.Trim()=="")
                        {
                            //add by zouchihua 2012-9-11
                            if (this.serchText1.textBox1.Text.Trim() != "")
                            {
                                sSql += " and a.FREQUENCY='" + this.serchText1.textBox1.Text.Trim() + "' ";
                            }
                        }
                        else
                        {
                            if (this.serchText1.textBox1.Text.Trim() == ""&&tj.Trim()!="")
                                sSql += " and a.FREQUENCY  in " + tj+ " ";
                            if (this.serchText1.textBox1.Text.Trim() != "" && tj.Trim() != "")
                                sSql += "  and ( a.FREQUENCY='" + this.serchText1.textBox1.Text.Trim() + "' or a.FREQUENCY  in " + tj + ") ";
                            if (this.serchText1.textBox1.Text.Trim() == "" && tj.Trim() == "")
                                sSql += " and 1=2 ";
                        }
                        //���ϵ��㷨̫���ӣ�ֻ��Ҫ�ж�����÷��ǲ����������ִ�е�
                        sSql += "  and (";
                        //Modify By Tany 2007-09-18  
                        if (rabcwh.Checked)
                        {
                            sSql2 = " order by ����,a.Order_Context,a.Order_bDate";
                        }
                        else
                        {
                            sSql2 = " order by a.Order_Context,����,a.Order_bDate";
                        }
                        //myFunc.ShowGrid(1,sSql+sSql1+sSql2,this.myDataGrid2);
                        DataTable tmpTb = InstanceForm.BDatabase.GetDataTable(sSql + sSql1 + sSql2,60);
                        if (GrdTb == null || GrdTb.Rows.Count == 0)
                            GrdTb = tmpTb.Clone();
                        if (tmpTb.Rows.Count == 0 || tmpTb == null)
                        {
                            this.progressBar1.Value += 1;
                            continue;
                        }
                        for (int j = 0; j < tmpTb.Rows.Count; j++)
                        {
                            GrdTb.Rows.Add(tmpTb.Rows[j].ItemArray);
                        }
                        this.progressBar1.Value += 1;
                    }
                }
                DataColumn col = new DataColumn();
                col.DataType = System.Type.GetType("System.Boolean");
                col.AllowDBNull = false;
                col.ColumnName = "ѡ";
                col.DefaultValue = false;
                GrdTb.Columns.Add(col);

                DataTable myTb1 = GrdTb;//(DataTable)this.myDataGrid2.DataSource;
                CheckGrdData(myTb1);
                this.myDataGrid2.DataSource = myTb1;
                if (rabcwh.Checked)
                {
                    string[] GrdMappingName1 ={"ISPRINT","INPATIENT_ID","order_id","mngtype",
										 "ѡ","����","����","������","��ʱ��","����","������Ŀ","��λ","Ƶ��","ͣ����","ͣʱ��","ִ��ʱ��","ǩ��","��ע",
										 "day1","second1","day2","second2",
										 "bdate1","edate1","group_id","a.BABY_ID"};
                    int[] GrdWidth1 ={ 0, 0, 0, 0,
                    2, 4, 8, 6, 6, 4, 48, 6, 6, 6,6,10,8,48,
                    0, 0, 0, 0, 
                    0, 0, 0, 0};
                    int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid2);
                }
                else
                {
                    string[] GrdMappingName1 ={"ISPRINT","INPATIENT_ID","order_id","mngtype",
										 "ѡ","������Ŀ","����","����","������","��ʱ��","����","��λ","Ƶ��","ͣ����","ͣʱ��","ִ��ʱ��","ǩ��","��ע",
										 "day1","second1","day2","second2",
										 "bdate1","edate1","group_id","a.BABY_ID"};
                    int[] GrdWidth1 ={ 0, 0, 0, 0,
                    2,48, 4, 8, 6, 6, 4, 6, 6, 6,6,6,8,48,
                    0, 0, 0, 0, 
                    0, 0, 0, 0};
                    int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid2);
                }

                myDataGrid2.TableStyles[0].RowHeaderWidth = 5;

                this.myDataGrid2.CaptionText = this.kind_name;
                this.bt��ѡ2_Click(sender, e);
                this.progressBar1.Value = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }      
        }


        //private string GetNumUnit(DataTable myTb, int i)
        //{
        //    string sNum = "";
        //    if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt32(Convert.ToDecimal(myTb.Rows[i]["Num"])))
        //    {
        //        sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
        //    }
        //    else
        //    {
        //        sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
        //    }
        //    //Modify By Tany 2004-10-27
        //    if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "2" && myTb.Rows[i]["ntype"].ToString().Trim() != "3") || sNum == "0" || sNum == "")
        //        return "";
        //    else
        //        return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();
        //}

        private void CheckGrdData(DataTable myTb)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0, iName = 0, iType = 0;   //��¼��һ����ʾ���ں�ʱ����к�
            int l = 0, group_rows = 1;    //ͬ���е�ҽ������
            this.sPaint = "";
            bool isShowDay = false;

            #region �������
            //max_len0 = 0;
            //max_len1 = 0;
            //max_len2 = 0;
            //for (i = 0; i <= myTb.Rows.Count - 1; i++)
            //{
            //    sNum = this.GetNumUnit(myTb, i);
            //    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["������Ŀ"].ToString().Trim());
            //    max_len0 = max_len0 > l ? max_len0 : l;
            //    if (sNum.Trim() != "")
            //    {
            //        max_len1 = max_len1 > l ? max_len1 : l;
            //        l = System.Text.Encoding.Default.GetByteCount(sNum);
            //        max_len2 = max_len2 > l ? max_len2 : l;
            //    }
            //}
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region ��ʾ����  Modify By Tany 2004-11-20 ��ʱ���Σ���Ҫ�����û��ѡ���У���ӡ������û����������
                //				if (i!=0) 
                //				{
                //					if (   myTb.Rows[i]["Inpatient_ID"].ToString().Trim()==myTb.Rows[iName]["Inpatient_ID"].ToString().Trim() 
                //						&& myTb.Rows[i]["Baby_ID"].ToString().Trim()==myTb.Rows[iName]["Baby_ID"].ToString().Trim() ) 
                //					{
                //						if (this.type==1 || this.type==3 )
                //						{
                //							myTb.Rows[i]["p����"]="";
                //							myTb.Rows[i]["p����"]="";
                //						}
                //						myTb.Rows[i]["����"]=System.DBNull.Value;
                //						myTb.Rows[i]["����"]=System.DBNull.Value;
                //						isShowDay=false;
                //					}
                //					else
                //					{
                //						iName=i;
                //						isShowDay=true;  //��Ҫ��ʾ���ں�ʱ��
                //					}	
                //				}
                //				else isShowDay=true;
                #endregion

                #region ��ʾ����ʱ��  Modify By Tany 2004-11-20 ��ʱ���Σ���Ҫ�����û��ѡ���У���ӡ������û����������
                if (Convert.ToInt16(myTb.Rows[i]["mngtype"]) == 0)
                {
                    myTb.Rows[i]["ͣ����"] = myFunc.getDate(myTb.Rows[i]["ͣ����"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                    myTb.Rows[i]["ͣʱ��"] = myFunc.getTime(myTb.Rows[i]["ͣʱ��"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                }
                else
                {
                    myTb.Rows[i]["ͣ����"] = "";
                    myTb.Rows[i]["ͣʱ��"] = "";
                }

                myTb.Rows[i]["������"] = myFunc.getDate(myTb.Rows[i]["������"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["��ʱ��"] = myFunc.getTime(myTb.Rows[i]["��ʱ��"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["������"].ToString().Trim() == myTb.Rows[iDay]["������"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["������"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }

                    if (myTb.Rows[i]["��ʱ��"].ToString().Trim() == myTb.Rows[iTime]["��ʱ��"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["��ʱ��"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }


                if (myTb.Rows[i]["����"].ToString().Trim() == "����")
                {
                    myTb.Rows[i]["ͣ����"] = System.DBNull.Value;
                    myTb.Rows[i]["ͣʱ��"] = System.DBNull.Value;
                    //myTb.Rows[i]["first_times"] = System.DBNull.Value;
                    //myTb.Rows[i]["terminal_times"] = System.DBNull.Value;
                }
                #endregion

                #region ��ʾ����
                if (i != 0)
                {
                    if (myTb.Rows[i]["����"].ToString().Trim() == myTb.Rows[iType]["����"].ToString().Trim() && isShowDay == false)
                    {
                        myTb.Rows[i]["����"] = System.DBNull.Value;
                    }
                    else
                    {
                        iType = i;
                    }
                }
                #endregion

                #region ��ʾҽ������

                ////��ҽ�����ݡ�+= ��ҽ�����ݡ�+���ո�+��������λ��
                //l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["������Ŀ"].ToString().Trim());
                //sNum = this.GetNumUnit(myTb, i);
                ////if (sNum.Trim()!=" ") 
                //myTb.Rows[i]["������Ŀ"] = myTb.Rows[i]["������Ŀ"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;
                ////else myTb.Rows[i]["ҽ������"]=myTb.Rows[i]["ҽ������"].ToString().Trim () +myFunc.Repeat_Space(max_len0-l)+sNum;
                ////myTb.Rows[i-group_rows+1]["p����"]=sNum;// why????By Tany
                //myTb.Rows[i]["p����"] = sNum;

                //if ((i == myTb.Rows.Count - 1) ||
                //       (i != myTb.Rows.Count - 1 &&
                //                                  ((myTb.Rows[i]["group_id"].ToString().Trim() != myTb.Rows[i + 1]["group_id"].ToString().Trim() && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                //                                     ||
                //                                     (myTb.Rows[i]["mngtype"].ToString().Trim() != myTb.Rows[i + 1]["mngtype"].ToString().Trim())
                //                                     ||
                //                                     (myTb.Rows[i]["inpatient_id"].ToString().Trim() != myTb.Rows[i + 1]["inpatient_id"].ToString().Trim())
                //                                   )
                //        )
                //    )
                //{
                //    //��������һ�л��к���һ�е�ҽ���Ų�һ��

                //    //ͬ���е�һ��ҽ���ġ�ҽ�����ݡ�+=���÷���+ ��Ƶ�ʡ�+�����١�
                //    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim());
                //    if (sNum.Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);
                //    else myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len0 - l + 4);

                //    //�÷�
                //    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                //    myTb.Rows[i - group_rows + 1]["p�÷�"] = myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();

                //    //Ƶ��
                //    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "")
                //    {
                //        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                //        myTb.Rows[i - group_rows + 1]["pƵ��"] = myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                //        if (myTb.Rows[iType]["����"].ToString().Trim() == "����")//tany
                //        {

                //            //Ƶ�ʣ��״Σ���ĩ�Σ�							
                //            if (Convert.ToDateTime(myTb.Rows[i - group_rows + 1]["bdate1"].ToString().Trim()).ToString("yyyy-MM-dd") == Convert.ToDateTime(this.TempDate.ToShortDateString().Trim()).ToString("yyyy-MM-dd") && myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() != "")
                //            {
                //                myTb.Rows[i - group_rows + 1]["frequency"] += "(" + myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["ҽ������"] += "(" + myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["p�״�"] = myTb.Rows[i - group_rows + 1]["first_times"].ToString().Trim();
                //            }

                //            string dd = "";
                //            if (myTb.Rows[i - group_rows + 1]["edate1"].ToString().Trim() != "")
                //                dd = Convert.ToDateTime(myTb.Rows[i - group_rows + 1]["edate1"].ToString().Trim()).ToString("yyyy-MM-dd");
                //            if (dd.Trim() == Convert.ToDateTime(this.TempDate.ToShortDateString().Trim()).ToString("yyyy-MM-dd") && myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() != "" && (myTb.Rows[i - group_rows + 1]["status_flag"].ToString().Trim() == "4" || myTb.Rows[i - group_rows + 1]["status_flag"].ToString().Trim() == "5"))
                //            {
                //                myTb.Rows[i - group_rows + 1]["frequency"] += "(" + myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["ҽ������"] += "(" + myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim() + ")";
                //                myTb.Rows[i - group_rows + 1]["p�״�"] = myTb.Rows[i - group_rows + 1]["terminal_times"].ToString().Trim();
                //            }
                //        }
                //    }

                //    //����					
                //    if (myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim() != "")
                //    {
                //        myTb.Rows[i - group_rows + 1]["ҽ������"] += "  ����:" + myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim();
                //        myTb.Rows[i - group_rows + 1]["p��ע"] = "[ ����:" + myTb.Rows[i - group_rows + 1]["dropsper"].ToString().Trim() + " ]";
                //    }

                //    //���һ���е�ҽ����������1
                //    if (group_rows != 1)
                //    {
                //        //[3i2]0 �����������һ��ҽ�������һ��������ҽ��������ҽ��,0�Ǵ���û�д�ӡ
                //        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["ISPRINT"].ToString().Trim();

                //        //��һ��
                //        myTb.Rows[i - group_rows + 1]["p����"] = "��";
                //        //���һ��
                //        myTb.Rows[i]["p����"] = "��";

                //        //�м���
                //        for (int j = 1; j <= group_rows - 2; j++)
                //        {
                //            myTb.Rows[i - group_rows + 1 + j]["p����"] = "��";
                //        }
                //    }
                //    group_rows = 1;
                //}
                //else
                //{
                //    try
                //    {
                //        //����������һ�У��ұ��к���һ�е�ҽ����һ��
                //        myTb.Rows[i]["ͣ����"] = System.DBNull.Value;
                //        myTb.Rows[i]["ͣʱ��"] = System.DBNull.Value;
                //        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;
                //        //group_rows+=1;
                //    }
                //    catch (System.Data.OleDb.OleDbException err)
                //    {
                //        MessageBox.Show(err.ToString());
                //    }
                //    catch (System.Exception err)
                //    {
                //        MessageBox.Show(err.ToString());
                //    }
                //}
                #endregion

            }
            this.myDataGrid2.DataSource = myTb;
        }

        /// <summary>
        /// �˳�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt�˳�_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// סԺ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZyh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //��ENTER��
            if (e.KeyChar == 13)
                btnSeek.Focus();
            //��������
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Ƶ�ʸ�ֵ
        /// </summary>
        private void serchText1_fz()
        {
            if (serchText1.row == null)
                return;
            DataRow row = serchText1.row;
            this.serchText1.textBox1.Text = row["����"].ToString().Trim();
            this.serchText1.textBox1.Tag = row["id"].ToString().Trim();
        }

        /// <summary>
        /// Ƶ�ʱ仯
        /// </summary>
        private void serchText1_TextChage()
        {
            serchText1.BringToFront();
            freqtb.DefaultView.RowFilter = "py_code like '%" + this.serchText1.textBox1.Text.Trim() + "%'  ";
            this.serchText1.tb = freqtb.DefaultView.ToTable();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid2_Paint(object sender, PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid2.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid2.DataSource, this.myDataGrid2.DataMember];

            while (y < this.myDataGrid2.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //����
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 239 + (this.max_len0 + 4) * 6;
                    else start_point = 239 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "0":  //δ��ӡ
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "1":  //�Ѵ�ӡ
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }

        /// <summary>
        /// ʱ����뿪������ʱ�������1-24֮��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim()=="")
            {
                return;
            }
            bool bp2 = System.Text.RegularExpressions.Regex.IsMatch(this.textBox1.Text.Trim(), @"(^[0-9]*$)");
            if (!bp2)
            {
                MessageBox.Show("�������������ͣ�", "��ʾ��Ϣ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Focus();
            }
            else
            {
                try
                {
                    if (int.Parse(this.textBox1.Text) < 1 || int.Parse(this.textBox1.Text) > 24)
                    {
                        MessageBox.Show("������1��24֮������֣�", "��ʾ��Ϣ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.textBox1.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("������1��24֮������֣�", "��ʾ��Ϣ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt��ӡ_Click(object sender, EventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid2.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;
            int iSelectRows = 0, i = 0, j = 0;
            string msg = "", tmpbed = "";

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True") iSelectRows += 1;
                if (myTb.Rows[i]["ѡ"].ToString() == "True" && myTb.Rows[i]["ISPRINT"].ToString() == "1")
                {
                    if (myTb.Rows[i]["����"].ToString() != tmpbed && myTb.Rows[i]["����"].ToString().Trim() != "")
                    {
                        msg += myTb.Rows[i]["����"].ToString() + "�� " + myTb.Rows[i]["����"].ToString() + "��\r\n";
                        tmpbed = myTb.Rows[i]["����"].ToString();
                    }
                    msg += "    " + myTb.Rows[i]["������Ŀ"].ToString() + "\r\n";
                    j += 1;
                }
            }
            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ����Ҫ��ӡ�ļ�¼��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (j > 0)
            {
                FrmTxtMsg frmTxtMsg = new FrmTxtMsg();
                frmTxtMsg.txtMsg.Text = "��ӡ���ļ�¼������\r\n\r\n" + msg;
                frmTxtMsg.txtMsg.ReadOnly = true;
                frmTxtMsg.ShowDialog();
                if (MessageBox.Show(this, "��ѡ��ļ�¼���С�" + j.ToString() + "������¼�Ѿ���ӡ����ȷ��������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            Cursor.Current = PubStaticFun.WaitCursor();
            this.progressBar1.Maximum = iSelectRows;
            this.progressBar1.Value = 0;

            //bool isPL = false;//ִ�е���ӡ�Ƿ�Ƶ����ʾ��¼�� Add By Tany 2007-09-17
            //if ((new SystemCfg(7035)).Config == "��")
            //{
            //    string zdllx = (new SystemCfg(7144).Config);
            //    zdllx = ',' + zdllx + ',';
            //    //���ѡ���ִ�е�idû�а����ڲ���7144���棬��ô�Ͱ���Ƶ�ʴ�ӡ
            //    if (!zdllx.Trim().Contains(',' + this.cmbZxd.SelectedValue.ToString().Trim() + ','))
            //        isPL = true;
            //    else
            //        isPL = false;
            //}
            //else
            //{
            //    isPL = false;
            //}

            //bool isPrintGG = false;
            //if (new SystemCfg(7069).Config == "1")
            //{
            //    isPrintGG = true;
            //}
            ////Add By tany 2011-05-31 
            ////7089ִ�е�ҩƷ���ƺ�ҩƷ������ʽ 0=������� 1=�������
            //int _ggType = Convert.ToInt16(new SystemCfg(7089).Config);

            try
            {
                string sSql = "";
                System.DateTime pTempDate = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                Dstdzxd.dszxdDataTable dt = new Dstdzxd.dszxdDataTable();

                //int _jsq = 1;//����������Ϊ������ô�������ǻ���һ����¼
                //int _crjls = 0;//�����¼��
                //_crjls = Convert.ToInt32((new SystemCfg(7036)).Config);
                //�����µ�����
                //Add By Tany 2010-09-26 ��ִ�е���ӡ��¼���ڵ����ӡ�����
                string[] sql = new string[myTb.Rows.Count];
                for (i = 0; i <= myTb.Rows.Count - 1; i++)
                {
                    if (myTb.Rows[i]["ѡ"].ToString() == "True")
                    {
                        DataRow dr = dt.NewRow();
                        dr["colCWH"] = myTb.Rows[i]["����"].ToString();
                        dr["colXM"] = myTb.Rows[i]["����"].ToString();
                        dr["colZLXM"] = myTb.Rows[i]["������Ŀ"].ToString();
                        dr["colZXSJ"] = myTb.Rows[i]["ִ��ʱ��"].ToString();
                        dr["colPL"] = myTb.Rows[i]["Ƶ��"].ToString();
                        dr["colQM"] = myTb.Rows[i]["ǩ��"].ToString();
                        dr["colBZ"] = myTb.Rows[i]["��ע"].ToString();
                        dt.Rows.Add(dr);
                        //�����ݿ���������
                        sSql = "select id from ZY_Printzdzxd where order_id='" + myTb.Rows[i]["order_id"].ToString() + "'";
                        DataTable tempTab = InstanceForm.BDatabase.GetDataTable(sSql);
                        //Modify By Tany 2010-09-26 �γ�sql����
                        if (tempTab.Rows.Count > 0)
                        {
                            //�Ѿ���ӡ��update
                            sql[i] = "update ZY_Printzdzxd set PRINT_DATE='" + pTempDate.ToString() + "' , print_user=" + InstanceForm.BCurrentUser.EmployeeId + " where id=" + tempTab.Rows[0]["id"].ToString();
                        }
                        else
                        {
                            //û�д�ӡ�������¼
                            sql[i] = "insert into  ZY_Printzdzxd(ORDER_ID,ZXD_DATE,PRINT_DATE,PRINT_USER,JGBM) values ('" +   
                                myTb.Rows[i]["order_id"].ToString() + "'," +
                                "'" + this.TempDate.ToString() + "'," +
                                "'" + pTempDate.ToString() + "'," +
                                InstanceForm.BCurrentUser.EmployeeId + "," + FrmMdiMain.Jgbm + ")";
                        }
                        //InstanceForm.BDatabase.DoCommand(sSql); Modify By Tany 2010-09-26
                        progressBar1.Value += 1;
                    }
                }
                progressBar1.Value = 0;

                //��ӡ����
                FrmReportView frmRptView = null;        
                ParameterEx[] _parameters = new ParameterEx[3];
                string _type = "";

                if (rbAllMngtype.Checked)
                {
                    _type = "(ȫ��)";
                }
                else if (rbLongOrders.Checked)
                {
                    _type = "(����)";
                }
                else if (rbTempOrders.Checked)
                {
                    _type = "(����)";
                }
                _parameters[0].Text = "yymc";//ҽԺ����
                _parameters[0].Value = new SystemCfg(0002).Config + "����ִ�е�" + _type;
                _parameters[1].Text = "dept_name";//����
                _parameters[1].Value = InstanceForm.BCurrentDept.WardName;
                _parameters[2].Text = "print_date";//����
                _parameters[2].Value = pTempDate;
                string _reportName = "";
                if (rabcwh.Checked)
                {
                    _reportName = "HIS_�ض�ִ�е���ӡ1.rpt";
                }
                else
                {
                    _reportName = "HIS_�ض�ִ�е���ӡ2.rpt";
                }
                frmRptView = new FrmReportView(dt, Constant.ApplicationDirectory + "\\report\\" + _reportName, _parameters);
                frmRptView._sqlStr = sql;
                frmRptView.WindowState = FormWindowState.Maximized;
                frmRptView.Show();
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(err.ToString());
            }
            //			this.bt��ѯ_Click(sender,e);
            myDataGrid2.DataSource = null;
        }

        /// <summary>
        /// �Ƿ�ͨ��סԺ�Ų�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSeekZyh_Click(object sender, EventArgs e)
        {
            txtZyh.Enabled = chkSeekZyh.Checked;
            btnSeek.Enabled = chkSeekZyh.Checked;
            txtZyh.Text = "";
            if (chkSeekZyh.Checked)
            {
                myDataGrid1.DataSource = null;
                txtZyh.Focus();
            }
            else
            {
                Frmzxdprint_Load(null, null);
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myDataGrid2_Click(object sender, EventArgs e)
        {
            //����BOOL��
            int nrow, ncol;
            nrow = this.myDataGrid2.CurrentCell.RowNumber;
            ncol = this.myDataGrid2.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0 && nrow > 0) this.myDataGrid2.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid2.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid2.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            //��"ѡ"�ֶ�
            if (this.myDataGrid2.TableStyles[0].GridColumnStyles[ncol].MappingName.Trim() != "ѡ") return;
            if (nrow > myTb.Rows.Count - 1) return;

            bool isResult = myTb.Rows[nrow]["ѡ"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["ѡ"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["group_id"].ToString().Trim() == myTb.Rows[nrow]["group_id"].ToString().Trim()
                    && myTb.Rows[i]["mngtype"].ToString().Trim() == myTb.Rows[nrow]["mngtype"].ToString().Trim()
                    && myTb.Rows[i]["Inpatient_id"].ToString().Trim() == myTb.Rows[nrow]["Inpatient_id"].ToString().Trim()
                    && myTb.Rows[i]["Baby_id"].ToString().Trim() == myTb.Rows[nrow]["Baby_id"].ToString().Trim()
                    && myTb.Rows[i]["ѡ"].ToString() != isResult.ToString())
                {
                    this.myDataGrid2.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["ѡ"] = isResult;
                }
            }

            this.myDataGrid2.DataSource = myTb;
        }

        private void rbAllMngtype_CheckedChanged(object sender, EventArgs e)
        {
            //�ı�����ѡ���ʱ����������
            myDataGrid2.DataSource = null;
        }

        private void rabcwh_CheckedChanged(object sender, EventArgs e)
        {
            //�ı�����ѡ���ʱ����������
            myDataGrid2.DataSource = null;
        }

        private void rbѡ��_CheckedChanged(object sender, EventArgs e)
        {
            dtpSel.Enabled = rbѡ��.Checked;
        }
    }
}