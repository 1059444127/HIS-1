using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;

namespace ts_mz_class
{
    public partial class Frmxm : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public RelationalDatabase _DataBase;
        public User _BCurrentUser;
        public string config = "";
        public Frmxm(MenuTag menuTag, string chineseName, Form mdiParent, RelationalDatabase DataBase, User BCurrentUser)
        {
            InitializeComponent();
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            _DataBase = DataBase;
            _BCurrentUser = BCurrentUser;
        }

        private void Frmxm_Load(object sender, EventArgs e)
        {
            BindLoad();
        }

        private void BindLoad()
        {
            //�������
            DataTable tbbb = (DataTable)dataGridView2.DataSource;
            if (tbbb != null)
                tbbb.Clear();
            //Add By Zj 2012-05-15
            string functionname = _menuTag.Function_Name;
            string Name = "";
            string sssql = "";
            string ssql = "";
            string sql = "";
            string strarr = "";
            DataTable tb = new DataTable();
            DataTable ttb = new DataTable();
            switch (_chineseName)
            {
                #region ����������ĿSQL
                case "notinxm"://����������Ŀ
                    Name = "XM";
                    //��ѯ���������ֵ
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    //��ѯͳ�ƴ���Ŀ������CODEֵ���ڱ�����������������
                    sql = "select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM ";
                    if (strarr != "()") //���������û�м�¼ �Ͳ����Not in ����
                        sql += " where CODE not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    //�ڰ�datagridview2֮ǰ���ж��Ƿ���Ҫ����
                    if (strarr == "()")//������ڿ� ����
                        return;
                    //��ѯͳ�ƴ���Ŀ������CODEֵ�ڱ�����������������
                    ssql = @"select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM  where CODE in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region ��������ҩƷ����SQL
                case "notinyp"://��������ҩƷ����
                    Name = "YP";
                    sql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sql)) + ")";

                    ssql = @"select * from (select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select 'Ƥ��ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name 
                                    union all 
                                    select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name) a  ";
                    if (strarr != "()")
                        ssql += "where a.name not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(ssql);
                    dataGridView1.DataSource = tb;
                    if (strarr == "()")
                        return;
                    sssql = @"select * from (select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select 'Ƥ��ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name 
                                    union all 
                                    select '����ҩƷ' name
                                    union all 
                                    select '����ҩƷ' name
                                    union all
                                    select '����ҩƷ' name) a where a.name in " + strarr + " ";

                    ttb = _DataBase.GetDataTable(sssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region �������Ŀ���SQL
                case "notinks":
                    Name = "KS";
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    sql = "select NAME,PY_CODE,WB_CODE,DEPT_ID from JC_DEPT_PROPERTY where LAYER=3 and DELETED=0 ";
                    if (strarr != "()")
                        sql += " and  DEPT_ID not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    if (strarr == "()")
                        return;
                    ssql = @" select NAME,PY_CODE,WB_CODE,DEPT_ID from JC_DEPT_PROPERTY where LAYER=3 and DELETED=0 and DEPT_ID in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                #region ����������SQL
                case "inssf":
                    Name = "SSF";
                    sssql = "select config from jc_report_config where functionname='" + functionname + "' and name='" + Name + "' and deleted=0";
                    strarr = "(" + Convert.ToString(_DataBase.GetDataResult(sssql)) + ")";
                    //��ѯͳ�ƴ���Ŀ������CODEֵ���ڱ�����������������
                    sql = "select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM ";
                    if (strarr != "()") //���������û�м�¼ �Ͳ����Not in ����
                        sql += " where CODE not in " + strarr + " ";
                    tb = _DataBase.GetDataTable(sql);
                    dataGridView1.DataSource = tb;
                    //�ڰ�datagridview2֮ǰ���ж��Ƿ���Ҫ����
                    if (strarr == "()")//������ڿ� ����
                        return;
                    //��ѯͳ�ƴ���Ŀ������CODEֵ�ڱ�����������������
                    ssql = @"select CODE,ITEM_NAME,PY_CODE,WB_CODE from JC_STAT_ITEM  where CODE in " + strarr + " ";
                    ttb = _DataBase.GetDataTable(ssql);
                    dataGridView2.DataSource = ttb;
                    break;
                #endregion
                default:
                    MessageBox.Show("û����������!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                return;
            }
            else
            {
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            config = "";
            string sql = "";
            string str = "";
            switch (_chineseName)
            {
                #region ���벻��������Ŀ
                case "notinxm":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["ѡ"].Value != null && (bool)dataGridView1.Rows[i].Cells["ѡ"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["CODE"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='XM' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='XM' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','����������Ŀ����','XM',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region ���벻������ҩƷ
                case "notinyp":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["ѡ"].Value != null && (bool)dataGridView1.Rows[i].Cells["ѡ"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["NAME"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='YP' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='YP' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','��������ҩƷ����','YP',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region ���벻�����Ŀ���
                case "notinks":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["ѡ"].Value != null && (bool)dataGridView1.Rows[i].Cells["ѡ"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["DEPT_ID"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='KS' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='KS' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','�������Ŀ��Ҵ���','KS',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                #region ���������Ѱ�������Ŀ
                case "inssf":
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["ѡ"].Value != null && (bool)dataGridView1.Rows[i].Cells["ѡ"].Value)
                            config += "''" + dataGridView1.Rows[i].Cells["CODE"].Value.ToString() + "'',";
                    }
                    if (config == "")
                        return;
                    config = config.Substring(0, config.Length - 1);
                    sql = "select config from jc_report_config where functionname='" + _menuTag.Function_Name + "' and name='SSF' and deleted=0";
                    str = Convert.ToString(_DataBase.GetDataResult(sql)).Replace("'", "''");
                    if (str != "")
                        sql = "update jc_report_config set config='" + str + "," + config + "' where functionname='" + _menuTag.Function_Name + "' and name='SSF' and deleted=0";
                    else
                        sql = "insert into jc_report_config values ('" + _menuTag.Function_Name + "','" + config + "','������������','SSF',0," + _BCurrentUser.EmployeeId + ",getdate())";
                    if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                        this.Close();
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView2.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    string sql = "";
                    string deleteconfig = "";
                    string CurrentID = "";
                    switch (_chineseName)
                    {
                        case "notinxm":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["CODE"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='XM' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='XM' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "notinyp":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["name"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='YP' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["name"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["name"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='YP' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "notinks":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["dept_id"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='KS' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["dept_id"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["dept_id"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='KS' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        case "inssf":
                            CurrentID = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["CODE"].Value);
                            if (dataGridView2.Rows.Count == 1)
                                sql = "delete from JC_REPORT_config where functionname='" + _menuTag.Function_Name + "' and Name='SSF' and deleted=0";
                            else
                            {
                                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) != CurrentID)
                                        deleteconfig += "''" + Convert.ToString(dataGridView2.Rows[i].Cells["CODE"].Value) + "'',";
                                }
                                deleteconfig = deleteconfig.Substring(0, deleteconfig.Length - 1);
                                sql = "update JC_REPORT_config set config='" + deleteconfig + "' where functionname='" + _menuTag.Function_Name + "' and Name='SSF' and deleted=0";
                            }
                            if (Convert.ToInt32(_DataBase.GetDataResult(sql)) == 0)
                                BindLoad();
                            break;
                        default:
                            break;
                    }


                }
            }
        }
    }
}