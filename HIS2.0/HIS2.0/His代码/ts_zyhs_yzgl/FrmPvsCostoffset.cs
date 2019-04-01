using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_zyhs_yzgl
{
    public partial class FrmPvsCostoffset : Form
    {
       
        public FrmPvsCostoffset()
        {
            InitializeComponent();
        }

        private void FrmPvsCostoffset_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            //dataGridView1.ReadOnly = true;//���ؼ�ֻ�����ԣ�
            this.dataGridView1.AutoGenerateColumns = false;//���������У�
            radioButton2.Checked = true;
            chk_enable();
        }

        private string cx_tj()
        {
            string sql_tj = "";
            if (radioButton1.Checked)
            {
                panel4.Enabled = true;
                panel5.Enabled = false;
                if (checkBox1.Checked == true)
            {
                sql_tj += "and cz_flag='0'";
            }
                sql_tj += "and B.ORDER_BDATE>='" + dtp1.Value.ToString("yyyy-MM-dd") + " 00:00:00'" + "and B.ORDER_BDATE<'" + dtp2.Value.ToString("yyyy-MM-dd") + " 23:59:59' order by a.ORDER_ID";
            }
            else
            {
                panel4.Enabled = false;
                panel5.Enabled = true;
                if (checkBox1.Checked == true)
                {
                    sql_tj += "and cz_flag='0'";
                }
                sql_tj += "and z.Inpatient_no='" + "00"+txtzyh.Text + "' order by a.ORDER_ID";
            }
            return sql_tj;
            
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked&&txtzyh.Text.Trim()=="")
            {
                MessageBox.Show("������סԺ�ţ�");
                return;
            }
            string sql = "";
            DataTable dt = new DataTable();
            sql = string.Format(@"select
                                  z.NAME ��������,
                                  CAST(z.INPATIENT_NO AS BIGINT) סԺ��,
                                  dbo.fun_getDeptname(z.DEPT_ID) ��ǰ����,
                                  n.bed_no ��λ��,
                                  cz_flag,
                                  a.ID,
                                  B.ORDER_BDATE ҽ������,
                                  '' as Ƶ��,
                                  b.ORDER_CONTEXT ����,
                                  a.GG ���,
                                  a.NUM ����,
                                  a.UNIT ��λ,
                                  '' as ����,
                                  a.DOSAGE ����,
                                  a.RETAIL_PRICE ����,
                                  A.ACVALUE ���,
                                  DBO.FUN_GETEMPNAME(BOOK_USER) ������Ϣ,
                                  dbo.fun_getDeptname(a.EXECDEPT_ID) ִ�п���,
                                  DBO.FUN_GETEMPNAME(BOOK_USER) ������Ϣ,
                                  CONVERT(VARCHAR,DATEPART(MM,A.FY_DATE)) ��ҩ��Ϣ,
                                  DBO.FUN_ZY_SEEKFEETYPENAME(A.CZ_FLAG) ��������,
                                  F.DJH ��ҩ����,
                                  F.FYRQ ��ҩ����,
                                  h.NAME ��ҩ��,
                                  g.NAME ��ҩ����,
                                  CASE F.LYLX WHEN 0 THEN 'ͳ��' WHEN 1 THEN '��ҩ' ELSE '' END as ��ҩ����,
                                   DBO.FUN_GETEMPNAME(BOOK_USER) ������,
                                   A.BOOK_DATE ����ʱ�� ,
                                  CASE A.pvs_zdb WHEN 0 THEN '' WHEN 1 THEN 'ת���' ELSE '' END AS ת���
                                  from  zy_fee_speci A
                                  left join  ZY_ORDERRECORD  b   on  A.ORDER_ID=B.ORDER_ID
                                  LEFT JOIN YF_TLD F ON A.GROUP_ID=F.GROUPID 
                                  LEFT JOIN JC_EMPLOYEE_PROPERTY H ON F.FYR=H.EMPLOYEE_ID 
                                  LEFT JOIN JC_DEPT_PROPERTY G ON F.DEPT_LY=G.DEPT_ID 
                                  left join zy_inpatient z on a.inpatient_id=z.inpatient_id
                                  left join ZY_BEDDICTION n on  z.BED_ID=n.BED_ID  
                                  where  A.XMLY=2 and A.DELETE_BIT=0 and XMID  in ('16449','16450','16451','16452') ");
            sql = sql + cx_tj();

            dt = InstanceForm.BDatabase.GetDataTable(sql);
            dataGridView1.DataSource = dt;
            is_cz();
        }

        private void chk_enable()
        {
            if (radioButton1.Checked)
            {
                panel4.Enabled = true;
                panel5.Enabled = false;
                dataGridView1.DataSource = null;
            }
            else
            {
                panel4.Enabled = false;
                panel5.Enabled = true;
                dataGridView1.DataSource = null;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chk_enable();
        }

        private void is_cz()
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("�ò�ѯ������δ�鵽���ݣ�");
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cz_flag"].ToString() != "0")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "0")
                {
                    dataGridView1.CurrentRow.Cells[0].ReadOnly = true;
                    MessageBox.Show("��ҩƷ�ѳ���,�����ظ�������");
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[0].ReadOnly = false;

                    check_only();
                }
            }

        }

        private void btnoffset_Click(object sender, EventArgs e)
        {
            if (is_check() == false)
            {
                MessageBox.Show("�빴��һ��ҩƷ���г�����");
                return;
            }

                string chk_value = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
                if (chk_value=="True")
                {
                    update_czxx(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                }

            btnquery_Click(null,null);
        }

        private void update_czxx(string fyid)
        {
            string sql = "select *  from zy_fee_speci  where ID='" + fyid + "'";
            DataTable dt = new DataTable();
            dt = InstanceForm.BDatabase.GetDataTable(sql);
            string ITEM_NAME = dt.Rows[0]["ITEM_NAME"].ToString() + "���ѳ�����";
            DialogResult dr=MessageBox.Show("ȷ�������������ã�", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string update_sql = "update zy_fee_speci  set CZ_FLAG=1,item_name='" + ITEM_NAME + "'where ID='" + fyid + "'and CZ_FLAG=0";
                InstanceForm.BDatabase.DoCommand(update_sql);


                string insert_sql = string.Format(@"insert into ZY_FEE_SPECI ([ID]
                                                                          ,[INPATIENT_ID]
                                                                          ,[BABY_ID]
                                                                          ,[ORDER_ID]
                                                                          ,[ORDEREXEC_ID]
                                                                          ,[PRESCRIPTION_ID]
                                                                          ,[PRESC_NO]
                                                                          ,[PRESC_DATE]
                                                                          ,[BOOK_DATE]
                                                                          ,[BOOK_USER]
                                                                          ,[STATITEM_CODE]
                                                                          ,[TCID]
                                                                          ,[TC_FLAG]
                                                                          ,[XMID]
                                                                          ,[XMLY]
                                                                          ,[SUBCODE]
                                                                          ,[ITEM_NAME]
                                                                          ,[GG]
                                                                          ,[CJ]
                                                                          ,[UNIT]
                                                                          ,[UNITRATE]
                                                                          ,[COST_PRICE]
                                                                          ,[RETAIL_PRICE]
                                                                          ,[NUM]
                                                                          ,[DOSAGE]
                                                                          ,[SDVALUE]
                                                                          ,[AGIO]
                                                                          ,[ACVALUE]
                                                                          ,[QDRQ]
                                                                          ,[CHARGE_BIT]
                                                                          ,[CHARGE_DATE]
                                                                          ,[CHARGE_USER]
                                                                          ,[DELETE_BIT]
                                                                          ,[CZ_FLAG]
                                                                          ,[CZ_ID]
                                                                          ,[TYPE]
                                                                          ,[DISCHARGE_BIT]
                                                                          ,[DISCHARGE_ID]
                                                                          ,[SCBZ]
                                                                          ,[DOC_ID]
                                                                          ,[DEPT_ID]
                                                                          ,[DEPT_BR]
                                                                          ,[EXECDEPT_ID]
                                                                          ,[DEPT_LY]
                                                                          ,[GROUP_ID]
                                                                          ,[TLFS]
                                                                          ,[APPLY_ID]
                                                                          ,[FY_BIT]
                                                                          ,[FY_DATE]
                                                                          ,[FY_USER]
                                                                          ,[PY_USER]
                                                                          ,[BZ]
                                                                          ,[JGBM]
                                                                          ,[GCYS]
                                                                          ,[ZFBL]
                                                                          ,[YBJS_BIT]
                                                                          ,[YBJS_ID]
                                                                          ,[KCID]
                                                                          ,[is_PvsScn]
                                                                          ,[pvs_xh]
                                                                          ,[pvs_zdb])
                                                                     select NEWID()
                                                                          ,[INPATIENT_ID]
                                                                          ,[BABY_ID]
                                                                          ,[ORDER_ID]
                                                                          ,[ORDEREXEC_ID]
                                                                          ,[PRESCRIPTION_ID]
                                                                          ,[PRESC_NO]
                                                                          ,[PRESC_DATE]
                                                                          ,GETDATE()
                                                                          ,'{1}'
                                                                          ,[STATITEM_CODE]
                                                                          ,[TCID]
                                                                          ,[TC_FLAG]
                                                                          ,[XMID]
                                                                          ,[XMLY]
                                                                          ,[SUBCODE]
                                                                          ,[ITEM_NAME]+'(�ѳ���)'
                                                                          ,[GG]
                                                                          ,[CJ]
                                                                          ,[UNIT]
                                                                          ,[UNITRATE]
                                                                          ,[COST_PRICE]
                                                                          ,[RETAIL_PRICE]
                                                                          ,[NUM]*(-1)
                                                                          ,[DOSAGE]
                                                                          ,[SDVALUE]*(-1)
                                                                          ,[AGIO]
                                                                          ,[ACVALUE]*(-1)
                                                                          ,[QDRQ]
                                                                          ,[CHARGE_BIT]
                                                                          ,GETDATE()
                                                                          ,[CHARGE_USER]
                                                                          ,[DELETE_BIT]
                                                                          ,2
                                                                          ,a.id
                                                                          ,[TYPE]
                                                                          ,[DISCHARGE_BIT]
                                                                          ,[DISCHARGE_ID]
                                                                          ,[SCBZ]
                                                                          ,[DOC_ID]
                                                                          ,[DEPT_ID]
                                                                          ,[DEPT_BR]
                                                                          ,[EXECDEPT_ID]
                                                                          ,[DEPT_LY]
                                                                          ,[GROUP_ID]
                                                                          ,[TLFS]
                                                                          ,[APPLY_ID]
                                                                          ,[FY_BIT]
                                                                          ,[FY_DATE]
                                                                          ,[FY_USER]
                                                                          ,[PY_USER]
                                                                          ,[BZ]
                                                                          ,[JGBM]
                                                                          ,[GCYS]
                                                                          ,[ZFBL]
                                                                          ,[YBJS_BIT]
                                                                          ,[YBJS_ID]
                                                                          ,[KCID]
                                                                          ,[is_PvsScn]
                                                                          ,[pvs_xh]
                                                                          ,[pvs_zdb] from ZY_FEE_SPECI a where ID='{0}'", fyid, InstanceForm.BCurrentUser.EmployeeId);
                //insert_sql = string.Format(@"INSERT INTO ZY_FEE_SPECI" +
                //              " (id,jgbm,Order_id,prescription_id,orderexec_id,presc_date,book_date,book_user,presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                //              " cost_price, retail_Price, agio, EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                //              " CZ_FLAG,CZ_ID,DELETE_BIT,DISCHARGE_BIT, " +
                //              "num,sdValue,acValue,type,tlfs,gcys,pvs_xh,zfbl,charge_bit)"+
                //              "SELECT NEWID(),a.jgbm,Order_id,prescription_id,orderexec_id,presc_date,getdate()," + FrmMdiMain.CurrentUser.EmployeeId + ",presc_no,statitem_code,xmid,xmly,tcid,tc_flag,Inpatient_ID,baby_id,item_name,subcode,unit,unitrate,dosage," +
                //              "cost_price, retail_Price, agio,EXECDEPT_ID,dept_id,dept_br,dept_ly,doc_id,gg,cj," +
                //              "2,a.id,0,0," +
                //              "-1*num,-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",-1*convert(decimal(18,2)," + num_cz.ToString() + "/" + czcs + "*retail_Price)*" + czcs + ",type,tlfs,gcys,pvs_xh,zfbl," +
                //              sSql2 +
                //              " from zy_fee_speci a where id='" + fyid + "'");
                InstanceForm.BDatabase.DoCommand(insert_sql);
                MessageBox.Show("�����ɹ���");
            }
            else
            {
                return;
            }
        }

        private bool is_check()
        { 
            bool is_check=false;
            for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {
                if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                { is_check = true; }
            }
            return is_check;
        }
        private void check_only()
        {

            int cr = dataGridView1.CurrentRow.Index;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i != cr)
                {
                    if (dataGridView1.Rows[i].Cells["cz_flag"].Value.ToString() != "0")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = false;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = false;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    }

                }

            }
            
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    dataGridView1.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    if (dataGridView1.CurrentRow.Cells["cz_flag"].Value.ToString() == "0")
                    {
                        dataGridView1.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                }
            }
        }


    }
}