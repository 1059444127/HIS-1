using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;
using TrasenClasses.DatabaseAccess;

namespace ts_yf_zyfy
{
    public class PubClass
    {
        public PubClass()
        {
        }

        public static void PrintCf(string inpatient_id, string mngtype, string groupid, RelationalDatabase _DataBase)
        {
            DataTable tb = null;
            string ssql = "select top 1  presc_no,execdept_id,cz_flag from zy_orderrecord a,zy_fee_speci b "+
            " where a.inpatient_id=b.inpatient_id and  a.order_id=b.order_id and a.inpatient_id='" + inpatient_id +
                "' and (mngtype="+mngtype+" or mngtype=5 ) and a.group_id="+groupid+"  and cz_flag in(0,1) order by cz_flag ";
            DataTable tbcx=_DataBase.GetDataTable(ssql,30);
            decimal cfh=0;
            int zxks = 0;
            int cz_flag = 0;
            if (tbcx.Rows.Count > 0)
            {
                
                cfh = Convert.ToDecimal(tbcx.Rows[0]["presc_no"].ToString());
                zxks = Convert.ToInt32(tbcx.Rows[0]["execdept_id"].ToString());
                cz_flag = Convert.ToInt32(tbcx.Rows[0]["cz_flag"].ToString());
                if (cz_flag == 1)
                {
                    MessageBox.Show("�ô����ѳ���,���ܴ�ӡ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("��ȷ�ϴ�����ִ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cfh == 0) return;

            tb = ZY_FY.SelectCF("0", new Guid(inpatient_id), "", "", "", "", "", "", "0", 0, 0, 0, cfh, _DataBase,2);
            if (tb.Rows.Count==0)
                tb = ZY_FY.SelectCF("0",new Guid( inpatient_id), "", "", "", "", "", "", "1", 0, 0, 0, cfh, _DataBase,2);



            if (new SystemCfg(8021).Config == "0")
            {
                #region ��������ҩ
                try
                {
                    if (tb.Rows.Count == 0) return;

                    DataRow[] rows;
                    rows = tb.Select("ypsl<>0");

                    ts_Yk_ReportView.Dataset2 Dset = new ts_Yk_ReportView.Dataset2();
                    DataRow myrow;
                    for (int i = 0; i <= rows.Length - 1; i++)
                    {
                        myrow = Dset.��ҩ��ϸ��.NewRow();
                        myrow["rowno"] = Convert.ToString(rows[i]["���"]);
                        myrow["yppm"] = Convert.ToString(rows[i]["Ʒ��"]);
                        myrow["ypspm"] = Convert.ToString(rows[i]["��Ʒ��"]);
                        myrow["ypgg"] = Convert.ToString(rows[i]["���"]);
                        myrow["sccj"] = Convert.ToString(rows[i]["����"]);
                        myrow["lsj"] = Convert.ToDecimal(rows[i]["����"]);
                        myrow["ypsl"] = Convert.ToDecimal(rows[i]["����"]);
                        if (Convert.ToDecimal(rows[i]["����"]) > 1 || Convert.ToString(rows[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                            myrow["cfts"] = "����:" + rows[i]["����"].ToString() + " ��   " + rows[i]["��ҩ"].ToString();
                        myrow["ypdw"] = Convert.ToString(rows[i]["��λ"]);
                        myrow["lsje"] = Convert.ToDecimal(rows[i]["���"]);
                        myrow["shh"] = Convert.ToString(rows[i]["����"]);
                        myrow["bed_no"] = Convert.ToString(rows[i]["����"]);
                        myrow["name"] = Convert.ToString(rows[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows[i]["��������"]).Trim();
                        myrow["inpatient_no"] = Convert.ToString(rows[i]["סԺ��"]);
                        myrow["lydw"] = Convert.ToString(rows[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows[i]["ҽ��"]);
                        myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows[i]["dept_id"]), _DataBase);
                        myrow["presc_no"] = rows[i]["������"].ToString().Trim();
                        myrow["order_usage"] = rows[i]["�÷�"].ToString().Trim() + " " + rows[i]["Ƶ��"].ToString().Trim();
                        myrow["xb"] = Convert.ToString(rows[i]["�Ա�"]);
                        myrow["nl"] = Convert.ToString(rows[i]["����"]);

                        myrow["JTDZ"] = "";
                        myrow["LXDH"] = "";
                        myrow["SFZH"] = "";
                        myrow["bz1"] = Convert.ToString(rows[i]["���"]);
                        myrow["bz2"] = Convert.ToString(rows[i]["��ҽ���"]);
                        myrow["bz3"] = Convert.ToString(rows[i]["��ҽ֢��"]);

                        Dset.��ҩ��ϸ��.Rows.Add(myrow);
                    }

                    ParameterEx[] parameters = new ParameterEx[2];
                    parameters[0].Text = "titletext";
                    string ss = "";
                    //if (chkcydy.Checked == false)
                        ss = "סԺ�����嵥";
                   // else
                    //    ss = "��Ժ��ҩ�嵥";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks, _DataBase) + ")" + ss.Trim();
                    parameters[1].Text = "BZ";
                    parameters[1].Value = "";
                    bool bview =  false;
                    TrasenFrame.Forms.FrmReportView f;
                    f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥ҽ��վ��.rpt", parameters, bview);
                    if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                }
                catch (System.Exception err)
                {
                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }

            else
            {
                try
                {


                    DataRow[] rows;
                    rows = tb.Select(" ypsl<>0");


                    DataRow[] rows_xy = null;
                    DataRow[] rows_zy = null;

                    rows_xy = tb.Select(" STATITEM_CODE not like '%03%' ");
                    rows_zy = tb.Select(" STATITEM_CODE like '%03%' ");
   


                    ts_Yk_ReportView.Dataset2 Dset;
                    DataRow myrow;

                    if (rows_xy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_xy.Length - 1; i++)
                        {
                            myrow = Dset.��ҩ��ϸ��.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["yppm"] = Convert.ToString(rows_xy[i]["Ʒ��"]);
                            myrow["ypspm"] = Convert.ToString(rows_xy[i]["��Ʒ��"]);
                            myrow["ypgg"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["sccj"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_xy[i]["����"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_xy[i]["����"]);
                            if (Convert.ToDecimal(rows_xy[i]["����"]) > 1 || Convert.ToString(rows_xy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "����:" + rows_xy[i]["����"].ToString() + " ��   " + rows_xy[i]["��ҩ"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_xy[i]["��λ"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_xy[i]["���"]);
                            myrow["shh"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["bed_no"] = Convert.ToString(rows_xy[i]["����"]);
                            myrow["name"] = Convert.ToString(rows_xy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_xy[i]["��������"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_xy[i]["סԺ��"]);
                            myrow["lydw"] = Convert.ToString(rows_xy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_xy[i]["ҽ��"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_xy[i]["dept_id"]), _DataBase);
                            myrow["presc_no"] = rows_xy[i]["������"].ToString().Trim();
                            myrow["order_usage"] = rows_xy[i]["�÷�"].ToString().Trim() + " " + rows_xy[i]["Ƶ��"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_xy[i]["�Ա�"]);
                            myrow["nl"] = Convert.ToString(rows_xy[i]["����"]);

                            myrow["JTDZ"] = "";
                            myrow["LXDH"] = "";
                            myrow["SFZH"] = "";
                            myrow["bz1"] = Convert.ToString(rows_xy[i]["���"]);
                            myrow["bz2"] = Convert.ToString(rows_xy[i]["��ҽ���"]);
                            myrow["bz3"] = Convert.ToString(rows_xy[i]["��ҽ֢��"]);

                            Dset.��ҩ��ϸ��.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        //if (chkcydy.Checked == false)
                            ss = "סԺ�����嵥";
                        //else
                        //    ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks, _DataBase) + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview =  false ;
                        TrasenFrame.Forms.FrmReportView f;

                        f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥ҽ��վ��.rpt", parameters, bview);
                        if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                    }

                    if (rows_zy.Length > 0)
                    {
                        Dset = new ts_Yk_ReportView.Dataset2();
                        for (int i = 0; i <= rows_zy.Length - 1; i++)
                        {
                            myrow = Dset.��ҩ��ϸ��.NewRow();
                            myrow["rowno"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["yppm"] = Convert.ToString(rows_zy[i]["Ʒ��"]);
                            myrow["ypspm"] = Convert.ToString(rows_zy[i]["��Ʒ��"]);
                            myrow["ypgg"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["sccj"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["lsj"] = Convert.ToDecimal(rows_zy[i]["����"]);
                            myrow["ypsl"] = Convert.ToDecimal(rows_zy[i]["����"]);
                            if (Convert.ToDecimal(rows_zy[i]["����"]) > 1 || Convert.ToString(rows_zy[i]["STATITEM_CODE"]).Substring(0, 2) == "03")
                                myrow["cfts"] = "����:" + rows_zy[i]["����"].ToString() + " ��   " + rows_zy[i]["��ҩ"].ToString();
                            myrow["ypdw"] = Convert.ToString(rows_zy[i]["��λ"]);
                            myrow["lsje"] = Convert.ToDecimal(rows_zy[i]["���"]);
                            myrow["shh"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["bed_no"] = Convert.ToString(rows_zy[i]["����"]);
                            myrow["name"] = Convert.ToString(rows_zy[i]["����"]).Trim() + "  ��������:" + Convert.ToString(rows_zy[i]["��������"]).Trim();
                            myrow["inpatient_no"] = Convert.ToString(rows_zy[i]["סԺ��"]);
                            myrow["lydw"] = Convert.ToString(rows_zy[i]["��ҩ����"]) + "  ҽ��:" + Convert.ToString(rows_zy[i]["ҽ��"]);
                            myrow["ksname"] = Yp.SeekDeptName(Convert.ToInt32(rows_zy[i]["dept_id"]), _DataBase);
                            myrow["presc_no"] = rows_zy[i]["������"].ToString().Trim();
                            myrow["order_usage"] = rows_zy[i]["�÷�"].ToString().Trim() + " " + rows_zy[i]["Ƶ��"].ToString().Trim();
                            myrow["xb"] = Convert.ToString(rows_zy[i]["�Ա�"]);
                            myrow["nl"] = Convert.ToString(rows_zy[i]["����"]);

                            myrow["JTDZ"] = "";
                            myrow["LXDH"] = "";
                            myrow["SFZH"] = "";
                            myrow["bz1"] = Convert.ToString(rows_zy[i]["���"]);
                            myrow["bz2"] = Convert.ToString(rows_zy[i]["��ҽ���"]);
                            myrow["bz3"] = Convert.ToString(rows_zy[i]["��ҽ֢��"]);
                            Dset.��ҩ��ϸ��.Rows.Add(myrow);
                        }

                        ParameterEx[] parameters = new ParameterEx[2];
                        parameters[0].Text = "titletext";
                        string ss = "";
                        //if (chkcydy.Checked == false)
                            ss = "סԺ�����嵥";
                        //else
                        //    ss = "��Ժ��ҩ�嵥";
                        parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "(" + Yp.SeekDeptName(zxks,_DataBase) + ")" + ss.Trim();
                        parameters[1].Text = "BZ";
                        parameters[1].Value = "";
                        bool bview =  false;
                        TrasenFrame.Forms.FrmReportView f;

                        f = new TrasenFrame.Forms.FrmReportView(Dset.��ҩ��ϸ��, Constant.ApplicationDirectory + "\\Report\\YF_סԺ�����嵥(��ҩ)ҽ��վ��.rpt", parameters, bview);
                        if (f.LoadReportSuccess) f.Show(); else f.Dispose();
                    }

                }
                catch (System.Exception err)
                {

                    MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        public static ColumnDefine NewColumnDefine( string headerText , string mappinName , int colWidth , bool colReadonly , int colBoolButton )
        {
            ColumnDefine define = new ColumnDefine();
            define.HeaderText = headerText;
            define.MappingName = mappinName;
            define.ColWidth = colWidth;
            define.ColReadOnly = colReadonly;
            define.ColBoolButton = colBoolButton;
            return define;
        }

    }
}
