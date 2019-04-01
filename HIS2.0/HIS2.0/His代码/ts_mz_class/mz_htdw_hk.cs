using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;

namespace ts_mz_class
{
    public class mz_htdw_hk
    {
        public static DataTable GetHtdwhkInfo(string begin_date, string end_date, string begin_hkdate, string end_hkdate, int sfy, string dzbz,int htdw_id,int aqy_id,RelationalDatabase _DataBase)
        {
            string[] paras = new string[4];
            if (begin_date != "") paras[0] = "and sfrq>='" + begin_date + "' and sfrq<'" + end_date + "'";
            else paras[0] = "";
            if (begin_hkdate != "") paras[1] = "and b.sfsj>='" + begin_hkdate + "' and b.sfsj<'" + end_hkdate + "'";
            else paras[1] = "";
 
            string str = "";
            if(dzbz == "0") str= "  and b.blh is null ";
            else if(dzbz == "1") str = " and b.blh is not null ";
            paras[2] = str;

            string sql_where="";
            if (htdw_id != 0) sql_where = "  and ��ͬ��λID =" + htdw_id;
            if (aqy_id != 0) sql_where += " and aqyid =" + aqy_id;

            paras[3] = sql_where;

            string sql = string.Format(@" select '0' ѡ��, a.*,b.je �ѵ��ʽ��,case when b.blh is not null then '1' else '0' end jzbz from(
select f.brxxid,f.BRXM ����,a.blh �����,dwmc+'<'+isnull(d.AQYMC,'')+'>' ��ע, sum(QFGZ) ���,b.htdwid ��ͬ��λID,b.aqyid aqyid
                                        from vi_mz_fpb a  
                                        left join vi_mz_ghxx b on a.ghxxid=b.ghxxid 
                                        left join   jc_htdw c on b.htdwid=c.id  
                                        left join JC_HTDW_AQY d on d.ID = b.aqyid
                                        left join  YY_BRXX f on f.brxxid = b.brxxid 
   where 1=1 {0}  and ((sfy=0 and 0>0) or (0=0))
                          and qfgz<>0 and JLZT ='0'  
                                        
                                group by a.blh,b.htdwid,dwmc,AQYMC,f.BRXM,f.brxxid,b.aqyid)a
			left join (select blh,MAX(sfsj) sfsj,
            sum(xjzf+ylkzf)+sum(case when bdzbz = '1' then zpzf else 0 end) je
            from MZ_HTDW_JZ where bscbz = '0' group by blh)b on a.����� = b.blh where 1=1 {2} {1} {3}", paras);
            DataTable tb = _DataBase.GetDataTable(sql);
            return tb;
        }

        public static void Htdw_jz(Guid htdw_jz_id, int htdw_id, string mzh, decimal zje,decimal xjzf,decimal zpzf,decimal ylkzf, int djy, string djsj, string bz, string zph, string khdw, string khyh, int dzy, string dzsj,int bscbz, out Guid NewHtdwJzid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[19];

                parameters[0].Text = "@htdw_jz_id";
                parameters[0].Value = htdw_jz_id;

                parameters[1].Text = "@htdw_id";
                parameters[1].Value = htdw_id;

                parameters[2].Text = "@mzh";
                parameters[2].Value = mzh;

                parameters[3].Text = "@zje";
                parameters[3].Value = zje;

                parameters[4].Text = "@xjzf";
                parameters[4].Value = xjzf;

                parameters[5].Text = "@zpzf";
                parameters[5].Value = zpzf;

                parameters[6].Text = "@ylkzf";
                parameters[6].Value = ylkzf;

                parameters[7].Text = "@djy";
                parameters[7].Value = djy;

                parameters[8].Text = "@djsj";
                parameters[8].Value = djsj;

                parameters[9].Text = "@bz";
                parameters[9].Value = bz;

                parameters[10].Text = "@zph";
                parameters[10].Value = zph;

                parameters[11].Text = "@khdw";
                parameters[11].Value = khdw;

                parameters[12].Text = "@khyh";
                parameters[12].Value = khyh;

                parameters[13].Text = "@dzy";
                parameters[13].Value = dzy;

                parameters[14].Text = "@dzsj";
                parameters[14].Value = dzsj;

                parameters[15].Text = "@bscbz";
                parameters[15].Value = bscbz;

                parameters[16].Text = "@NewHtdwId";
                parameters[16].ParaDirection = ParameterDirection.Output;
                parameters[16].DataType = System.Data.DbType.Guid;
                parameters[16].ParaSize = 100;

                parameters[17].Text = "@err_code";
                parameters[17].ParaDirection = ParameterDirection.Output;
                parameters[17].DataType = System.Data.DbType.Int32;
                parameters[17].ParaSize = 100;

                parameters[18].Text = "@err_text";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].ParaSize = 100;


                _DataBase.DoCommand("SP_MZ_HTDW_JZ", parameters, 30);
                NewHtdwJzid = new Guid(parameters[16].Value.ToString());
                err_code = Convert.ToInt32(parameters[17].Value);
                err_text = Convert.ToString(parameters[18].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }

        public static string GetSMZH(string[] mzh, RelationalDatabase _DataBase)
        {
            string str = "(";
            for (int i = 0; i < mzh.Length; i++)
            {
                str += Convert.ToString(mzh[i]) + ",";
            }
            str = str.Substring(0, str.Length - 1);
            str += ")";
            return str;
        }
        public static string SelectFPID(string Smzh, RelationalDatabase _DataBase)
        {

            string sql = @"select fpid from VI_MZ_FPB where JLZT =0 and BLH in " + Smzh;

            DataTable dt = _DataBase.GetDataTable(sql);

            string Sfpid = "('";
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                Sfpid += Convert.ToString(dt.Rows[i]["fpid"]) + "','";
            Sfpid = Sfpid.Substring(0, Sfpid.Length - 2);
            Sfpid += ")";
            return Sfpid;
        }

         //<summary>
         //�ϲ���ӡ��Ʊ
         //</summary>
        public static void Print(string Smzh, Guid brxxid, string Sfpid, EmptyFP newfp,int emplyeeId,string Dysj, RelationalDatabase _DataBase)
        {
            int err_code = -1;
            string err_text = "";
            try
            {
                _DataBase.BeginTransaction();
                //���·�Ʊ��¼�ķ�Ʊ��,��ӡ�ˣ���ӡʱ��
                string[] Fpid = Sfpid.Replace("'","").Replace("(","").Replace(")","").Split(',');
                for (int i = 0; i < Fpid.Length; i++)
                    mz_sf.UpdateFpdyxx(new Guid(Fpid[i]), newfp.Fph, newfp.Qz, emplyeeId, Dysj, out err_text, _DataBase);
                
                //�������ñ�ĵ�ǰ��Ʊ��
                mz_sf.UpdateDqfph(newfp.FplyId, newfp.Fph, newfp.Fph, out err_text, _DataBase);

                UpdateFpdyxx(Smzh, newfp.Fph, newfp.Qz, emplyeeId, Dysj, out err_text, _DataBase);

                _DataBase.CommitTransaction();
            }
            catch (Exception err)
            {
                _DataBase.RollbackTransaction();
                throw new Exception("���·�Ʊ��ӡ��Ϣ����µ�ǰ��Ʊ�ų���," + err.Message + "");
            }

            #region ��ӡ��Ʊ

            try
            {
                string sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();

                string sql = @"select * from yy_brxx a where a.brxxid='" + brxxid + "'";
                DataTable brxxTb = _DataBase.GetDataTable(sql);

                sql = @"select sum(isnull(zje,0)) zje,sum(isnull(xjzf,0)) xjzf,sum(isnull(zpzf,0)) zpzf,sum(isnull(ylkzf,0)) ylkzf, 
                                sfsj,sfy from MZ_HTDW_JZ where blh in" + Smzh + "group by sfsj,sfy";
                DataTable htdwjzTb = _DataBase.GetDataTable(sql);

                #region ��ӡ

                PrintClass.OPDInvoice invoice = new PrintClass.OPDInvoice();
                invoice.OtherInfo = "";
                invoice.HisName = Constant.HospitalName;
                invoice.PatientName = brxxTb.Rows[0]["brxm"].ToString();
                invoice.OutPatientNo = Smzh;
                //invoice.DepartmentName = Fun.SeekDeptName(ksdm, _DataBase);
                //invoice.DoctorName = Fun.SeekEmpName(ysdm, _DataBase);
                invoice.InvoiceNo = "����Ʊ�ţ�" + newfp.Fph; //��ӡ�·�Ʊ�ķ�Ʊ�� modify by wangzhi 201-12-1

                invoice.sfck = "";
                invoice.fyck = "";


                //invoice.TotalMoneyCN = Money.NumToChn(dset.Tables[0].Rows[0]["ZJE"].ToString());
                //invoice.TotalMoneyNum = Convert.ToDecimal(dset.Tables[0].Rows[0]["ZJE"]);

                invoice.Klx = "";
                //invoice.kh = kh;

                SystemCfg cfgsfy = new SystemCfg(3016);
                if (cfgsfy.Config == "1")
                    invoice.Payee = Fun.SeekEmpName(Convert.ToInt32(htdwjzTb.Rows[0]["sfy"].ToString()), _DataBase);//FrmMdiMain.CurrentUser.Name;
                else
                    invoice.Payee = htdwjzTb.Rows[0]["sfy"].ToString();

                DateTime time = Convert.ToDateTime(sDate);
                invoice.Year = time.Year;
                invoice.Month = time.Month;
                invoice.Day = time.Day;

                //invoice.Zxks = Fun.SeekDeptName(zxks, _DataBase);
                invoice.OtherInfo = Convert.ToDateTime(sDate).ToString() + "����";


                
                invoice.sfsj = Convert.ToDateTime(sDate).ToLongTimeString();

                //��ȡ���շѵķ�Ʊ��Ϣ
                DataSet dset = GetFpResult(Sfpid, out err_code, out err_text, _DataBase);

                PrintClass.InvoiceItem[] item = null;
                PrintClass.InvoiceItemDetail[] itemdetail = null; // ���ӷ�Ʊ��ϸ��Ŀ

                DataRow[] rows = dset.Tables[0].Select("");
                item = new PrintClass.InvoiceItem[rows.Length];
                for (int m = 0; m <= rows.Length - 1; m++)
                {
                    item[m].ItemName = rows[m]["ITEM_NAME"].ToString().Trim();
                    item[m].ItemMoney = Convert.ToDecimal(rows[m]["je"]);//��Ʊ��Ŀ���
                }
                invoice.Items = item;

                // ���ӷ�Ʊ��ϸ��Ŀ
                DataRow[] rowsdetail = dset.Tables[3].Select("");
                itemdetail = new PrintClass.InvoiceItemDetail[rowsdetail.Length];
                for (int m = 0; m <= rowsdetail.Length - 1; m++)
                {
                    itemdetail[m].ItemDetailName = rowsdetail[m]["PM"].ToString().Trim();
                    itemdetail[m].ItemDW = rowsdetail[m]["DW"].ToString().Trim();
                    itemdetail[m].ItemGG = rowsdetail[m]["GG"].ToString().Trim();
                    itemdetail[m].ItemJS = Convert.ToDecimal(rowsdetail[m]["JS"]);
                    itemdetail[m].ItemNum = Convert.ToDecimal(rowsdetail[m]["SL"]);
                    itemdetail[m].ItemPrice = Convert.ToDecimal(rowsdetail[m]["DJ"]);
                    itemdetail[m].ItemJE = Convert.ToDecimal(rowsdetail[m]["JE"]);
                }
                invoice.ItemDetail = itemdetail;

                //if (Bview != "true")
                invoice.Print();
                //else
                    //invoice.Preview();

                #endregion
            }
            catch (System.Exception err)
            {
                throw new Exception("��ӡ��Ʊʱ��������" + err.Message);
            }
            #endregion
        }

        public static DataSet GetFpResult(string fpid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@fpid";
                parameters[0].Value = fpid;

                parameters[1].Text = "@err_code";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int32;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@err_text";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_MZSF_GetFpResult_Htdw", parameters, dset, "sfmx", 30);

                err_code = Convert.ToInt32(parameters[1].Value);
                err_text = Convert.ToString(parameters[2].Value);
                return dset;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }

        public static EmptyFP GetFPH(int Czy, RelationalDatabase _DataBase)
        {
            int err_code;
            string err_text;
            DataTable tbfp = ts_mz_class.Fun.GetFph(Czy, 1, 1, out err_code, out err_text, _DataBase);
            if (err_code != 0 || tbfp.Rows.Count == 0)
            {
                throw new Exception(err_text);
            }
            EmptyFP fp = new EmptyFP(new Guid(tbfp.Rows[0]["fpid"].ToString()),
                                            tbfp.Rows[0]["fph"].ToString(),
                                            Convert.IsDBNull(tbfp.Rows[0]["qz"]) ? "" : tbfp.Rows[0]["qz"].ToString());
            return fp;
        }

        public static void UpdateFpdyxx(string Smzh, string fph, string qz, int dyy, string dysj, out string err_text, RelationalDatabase _DataBase)
        {
            err_text = "";
            string ssql = "update MZ_HTDW_JZ set fph='" + fph + "' ,fpdyy=" + dyy + ",fpdysj='" + dysj + "' where blh in" + Smzh; ; //Modify By Zj 2013-03-20 ����СƱ�����ж� СƱΪ��.
            int i = _DataBase.DoCommand(ssql);
            if (i == 0)
                throw new Exception("���·�Ʊ��ʱ��������,û�и��µ���");
        }
    }
}
