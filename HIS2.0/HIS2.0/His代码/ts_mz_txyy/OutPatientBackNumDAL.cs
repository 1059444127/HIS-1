using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace ts_mz_txyy
{
    class OutPatientBackNumDAL
    {
        public static void OutPatientBackNum(string YQID, string deptid, string starttime, string endtime, DataGridView dv)
        {
            DataTable dt = new DataTable();
            string sql = string.Format(@"select (case when t.ҽ������ is null then '��ͨ����' else t.ҽ������ end) as ����,COUNT(�˺���) as �˺���
                                        from 
                                        (select c.NAME as ҽ������,a.GHXXID as �˺��� from  MZ_GHXX  a   
                                        left join JC_DEPT_PROPERTY b on  a.GHKS=b.DEPT_ID
                                        left join JC_EMPLOYEE_PROPERTY c on a.GHYS=c.EMPLOYEE_ID
                                        where BQXGHBZ=1  and b.YQID='{0}' and a.QXGHSJ>='{2} ' and a.QXGHSJ<'{3} ' and  b.DEPT_ID ='{1}') as  t
                                        group  by  ҽ������",YQID,deptid,starttime,endtime);
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            if(dt==null||dt.Rows.Count<=0)
            {
                MessageBox.Show("��ǰ��ѯ����������Ϊ�գ�");
            }
            dv.DataSource = dt;
        }

        public static void YQ(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            DataRow row ;
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "yqmc";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "yqid";
            dt.Columns.Add(column);
            row = dt.NewRow();
            row["yqmc"] = "��Ժ";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "���";
            row["yqid"] = "1002";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "��������";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["yqmc"] = "�ȼ��";
            row["yqid"] = "1001";
            dt.Rows.Add(row);
            cmb.DataSource = dt;
            cmb.DisplayMember = "yqmc";
            cmb.ValueMember = "yqid";

        }
    }
}
