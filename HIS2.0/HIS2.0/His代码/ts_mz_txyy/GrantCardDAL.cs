using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ts_mz_txyy
{
    class GrantCardDAL
    {
        public static void BindGHS(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            DataColumn col;
            DataRow row;
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "YQMC";
            dt.Columns.Add(col);
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "KSID";
            dt.Columns.Add(col);
            row = dt.NewRow();
            row["YQMC"] = "ȫ��";
            row["KSID"] = "36','54";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["YQMC"] = "��Ժ";
            row["KSID"] = "36";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["YQMC"] = "���";
            row["KSID"] = "54";
            dt.Rows.Add(row);
            cmb.DataSource = dt;
            cmb.DisplayMember = "YQMC";
            cmb.ValueMember = "KSID";
        }

        public static void GrantCard(string ksid,string starttime,string endtime,DataGridView dv)
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select  NAME  as �Ǽ�Ա,COUNT(KDJID) as ������  from  (select  DJY,KDJID,b.NAME  from  MZ_GHXX a left join 
                                         JC_EMPLOYEE_PROPERTY b on a.DJY =b.EMPLOYEE_ID 
                                         left join JC_EMP_DEPT_ROLE c on a.DJY=c.EMPLOYEE_ID where c.DEPT_ID in ('{0}')
                                         and a.GHSJ>'{1}' and a.GHSJ<='{2}')
                                         as t  group by NAME", ksid,starttime,endtime);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            if (dt ==null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("��ǰ��ѯ����������Ϊ�գ�");
            }
            dv.DataSource = dt;
        }
    }
}
