using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
namespace ts_mzys_class
{
    public class mzys
    {
        //Add by zp 2014-01-07 ����Ĺ��ӷѺ;�����Ѫ��Ҫ������Ŀ�����Զ����� ��ҩ����
        private static DataTable dt_JYBBFLMX = null;
        private static SystemCfg _cfg7015 = null;
        private static SystemCfg _cfg7016 = null;
        private static int exc_dept7016 = -1;
        private static int exc_dept7015 = -1;
        private static SystemCfg _cfg3077 = null; 
        /// <summary>
        /// ��ѯ�����������ﲡ���������·������������ add by zp 2013-06-19
        /// </summary>
        /// <param name="ntype">0 ���� 1 ���� 2 ���� 3�Ѻ���δ����</param>
        /// <param name="zjdm">������</param>
        /// <param name="ysdm">ҽ������</param>
        /// <param name="ksdm">���Ҵ���</param>
        /// <param name="rq1">��ʼ����</param>
        /// <param name="rq2">��������</param>
        /// <returns></returns>
        public static DataTable Select_br_Fz(int ntype, int zjdm, int ysdm, int ksdm, string rq1, string rq2,int sxwid,int ghjb, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@type";
                parameters[0].Value = ntype;

                parameters[1].Text = "@zjdm";
                parameters[1].Value = zjdm;

                parameters[2].Text = "@ysdm";
                parameters[2].Value = ysdm;

                parameters[3].Text = "@ksdm";
                parameters[3].Value = ksdm;

                parameters[4].Text = "@rq1";
                parameters[4].Value = rq1;

                parameters[5].Text = "@rq2";
                parameters[5].Value = rq2;

                parameters[6].Text="@sxwid";
                parameters[6].Value = sxwid;//Modify by zp 2013-11-05 SP_mzys_select_hzyzbr_New
                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_mzys_GetHzbr_New", parameters, dset, "fzpat", 30);
                DataTable dt=dset.Tables[0]; //�õ���ҽ���ŵĺ����¼,������ҽ����
                if (dset.Tables.Count > 1)
                {
                    if (new SystemCfg(3103).Config != "1")
                    {
                        DataTable _dt2 = dset.Tables[1];//�õ��ҿ��Һŵļ�¼
                        for (int i = 0; i < _dt2.Rows.Count; i++)
                            dt.Rows.Add(_dt2.Rows[i].ItemArray);
                    }
                    else
                    {
                        if (dset.Tables.Count==3)
                        {
                            //dt.Clear();  chencan/ �ô��뵼��ҽ��վ����������ҽ���Ǳ��˵ľ����¼
                            DataTable _dt2 = dset.Tables[2];//�õ������ļ�¼
                            for (int i = 0; i < _dt2.Rows.Count; i++)
                                dt.Rows.Add(_dt2.Rows[i].ItemArray);
                        }
                    }
                }
                if (ntype==0)
                   dt= MZHS_FZJL.FindPatientByFzjb(dt, 1, ghjb, _DataBase);
                return dt;
                
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// ��ѯ�����������ﲡ��  Modify by zp 2013-11-11
        /// </summary>
        /// <param name="ntype">0 ���� 1 ���� 2 ����</param>
        /// <param name="zjdm">������</param>
        /// <param name="ysdm">ҽ������</param>
        /// <param name="ksdm">���Ҵ���</param>
        /// <param name="rq1">��ʼ����</param>
        /// <param name="rq2">��������</param>
        /// <returns></returns>
        public static DataTable Select_br(int ntype, int zjdm, int ysdm, int ksdm, string rq1, string rq2, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];

                parameters[0].Text = "@type";
                parameters[0].Value = ntype;

                parameters[1].Text = "@zjdm";
                parameters[1].Value = zjdm;

                parameters[2].Text = "@ysdm";
                parameters[2].Value = ysdm;

                parameters[3].Text = "@ksdm";
                parameters[3].Value = ksdm;

                parameters[4].Text = "@rq1";
                parameters[4].Value = rq1;

                parameters[5].Text = "@rq2";
                parameters[5].Value = rq2;

                DataTable dt = _DataBase.GetDataTable("SP_mzys_GetHzbr", parameters, 30);
                //return _DataBase.GetDataTable("SP_mzys_GetHzbr", parameters, 30);//Modify by zp 2013-11-05 "SP_mzys_select_hzyzbr"
                //dt = MZHS_FZJL.FindPatientByFzjb(dt, 1, ghjb, _DataBase);
                return dt;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            } 
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="execdept"></param>
        /// <param name="ghxxid"></param>
        /// <param name="tcid"></param>
        /// <param name="tccs"></param>
        /// <param name="hjid"></param>
        /// <param name="jzid">����ɣ�</param>
        /// <returns></returns>
        public static DataTable Select_cf(int execdept, Guid ghxxid, int tcid, decimal tccs, Guid hjid, Guid jzid, long order_item_id, long jgbm, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];

                parameters[0].Text = "@execdept";
                parameters[0].Value = execdept;//27

                parameters[1].Text = "@ghxxid";
                parameters[1].Value = ghxxid;//e4ec3f9f-de67-434d-9588-a2bd00a9708d

                parameters[2].Text = "@tcid";
                parameters[2].Value = tcid;//0

                parameters[3].Text = "@tccs";
                parameters[3].Value = tccs;//0

                parameters[4].Text = "@hjid";
                parameters[4].Value = hjid;//00000000-0000-0000-0000-000000000000

                parameters[5].Text = "@jzid";
                parameters[5].Value = jzid;//ad9dbb71-9cfb-4653-b95e-a2bd00a9b08f

                parameters[6].Text = "@order_item_id";
                parameters[6].Value = order_item_id;//0

                parameters[7].Text = "@jgbm";
                parameters[7].Value = jgbm;//1000

                DataTable tb = _DataBase.GetDataTable("SP_MZys_Selectcf", parameters, 30);
                return tb; 
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="ghxxid"></param>
        /// <param name="hjid"></param>
        /// <param name="jgbm"></param>
        /// <param name="count"></param>
        /// <param name="_Database"></param>
        public static void Export_cf_pdf( Guid ghxxid , Guid hjid , long jgbm , int count , RelationalDatabase _Database )
        {
            try
            {
                DataTable tb = Select_cf( 0 , ghxxid , 0 , 0 , hjid , Guid.Empty , 0 , jgbm , _Database );


                DataRow rowBrxx = _Database.GetDataRow( string.Format(
                                        @"select b.brxm as ��������,dbo.FUN_ZY_SEEKSEXNAME(xb) as �Ա�,dbo.fun_GetAge(csrq,0,getdate()) as ����,
                                            c.blh as �����,a.JSSJ as ��������,dbo.fun_getDeptname(a.JSKSDM) as ����,dbo.fun_getempname(a.JSYSDM) as ҽ��,
                                            a.zdmc as �������,d.cfje as �������,dbo.FUN_ZY_SEEKBRLXNAME( b.BRLX) as ��������
                                     from MZYS_JZJL a inner join YY_BRXX b on a.BRXXID = b.BRXXID
                                     inner join mz_ghxx c on a.ghxxid = c.ghxxid
                                     inner join mz_hjb d on a.jzid = d.jzid
                                     where a.GHXXID ='{0}' and d.hjid = '{1}' " , ghxxid , hjid ) );

                string reportTemplate = Application.StartupPath + "\\����ǩ.grf";

                Trasen.Print.Grid5.ReportPrinter rp = new Trasen.Print.Grid5.ReportPrinter();
                #region ����ģ��
                if ( !System.IO.File.Exists( reportTemplate ) )
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile( Application.StartupPath + "\\ts_mzys_class.dll" );
                    using ( System.IO.Stream stream = assembly.GetManifestResourceStream( "ts_mzys_class.����ǩ.grf" ) )
                    {
                        byte[] fileByte = new byte[(int)stream.Length];
                        stream.Read( fileByte , 0 , (int)stream.Length );
                        using ( System.IO.FileStream fs = new System.IO.FileStream( reportTemplate , System.IO.FileMode.Create ) )
                        {
                            fs.Write( fileByte , 0 , fileByte.Length );
                            fs.Flush();

                        }
                        stream.Close();
                        stream.Dispose();
                    }
                }
                #endregion
                rp.ReportTemplateFile = reportTemplate;
                #region ����
                List<Trasen.Print.Grid5.Interface.IParameter> list = new List<Trasen.Print.Grid5.Interface.IParameter>();
                Trasen.Print.Grid5.Interface.IParameter parameter;
                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "��������";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["��������"] ) ? "" : rowBrxx["��������"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "�Ա�";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["�Ա�"] ) ? "" : rowBrxx["�Ա�"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "����";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["����"] ) ? "" : rowBrxx["����"].ToString() ) );
                list.Add( parameter );


                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "�����";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["�����"] ) ? "" : rowBrxx["�����"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "��������";
                parameter.ParameterValue = ( rowBrxx == null ? "" : Convert.ToDateTime( rowBrxx["��������"].ToString() ).ToString( "yyyy-MM-dd" ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "����";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["����"] ) ? "" : rowBrxx["����"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "ҽ��";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["ҽ��"] ) ? "" : rowBrxx["ҽ��"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "�������";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["�������"] ) ? "" : rowBrxx["�������"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "�������";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["�������"] ) ? "" : rowBrxx["�������"].ToString() ) );
                list.Add( parameter );

                parameter = new Trasen.Print.Grid5.ReportParameter();
                parameter.ParameterName = "��������";
                parameter.ParameterValue = ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["��������"] ) ? "" : rowBrxx["��������"].ToString() ) );
                list.Add( parameter );

                #endregion
                rp.ReportParameters = list.ToArray();
                rp.PrintDataSource = tb;

                string path = System.Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) + "\\" + ( rowBrxx == null ? "" : ( Convert.IsDBNull( rowBrxx["��������"] ) ? "" : rowBrxx["��������"].ToString() ) ) + count.ToString();

                rp.Report.ExportDirect( grproLib.GRExportType.gretPDF , path , true , false );
            }
            catch ( Exception error )
            {
                throw new Exception( "����������������" , error );
            }

        }

        public static DataTable Select_cyyp(int ysdm, RelationalDatabase _DataBase)
        {
            //Add By Zj 2012-05-11 ��ӳ���ID���� ��ֹ�����¼.
            string ssql = "select yppm+isnull(ypspmbz,'') Ʒ��,ypgg ���,lsj ����,pym ƴ����,wbm �����,sypc Ƶ��,ggid,a.cjid from MZYS_CYYPXM a ,vi_yp_ypcd b " +
                          " where a.xmid=b.ggid  and a.CJID=b.cjid and lx=1 and ysdm=" + ysdm + "  and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " order by sypc desc";
            return _DataBase.GetDataTable(ssql);
        }

        public static DataTable Select_cyxm(int ysdm, RelationalDatabase _DataBase)
        {
            string ssql = @"select c.order_name ��Ŀ����,cost_price ����,rtrim(c.order_unit) ��λ,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,sypc Ƶ��,0 tcid,c.order_id 
                             from jc_hsitemdiction a inner join  jc_hoi_hdi b on a.item_id=b.hditem_id and b.tc_flag=0
                            inner join jc_hoitemdiction c on b.hoitem_id=c.order_id 
                             inner join mzys_cyypxm d on c.order_id=d.xmid and d.lx=2 where c.delete_bit=0 and ysdm=" + ysdm + " and a.jgbm=d.jgbm and a.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm +
                            @" union all
                            select order_name ��Ŀ����,price ����,rtrim(item_unit) ��λ,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,sypc Ƶ��,a.item_id tcid,c.order_id 
                            from jc_tc a inner join  jc_hoi_hdi b on a.item_id=b.hditem_id and b.tc_flag=1
                               inner join jc_hoitemdiction c on b.hoitem_id=c.order_id
                            inner join mzys_cyypxm d on c.order_id=d.xmid and d.lx=2  where a.delete_bit=0  and ysdm=" + ysdm + " and a.jgbm=d.jgbm and  a.jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm +
                            @"order by Ƶ�� desc";
            return _DataBase.GetDataTable(ssql);
        }

        public static DataTable Select_cyzd(int ysdm, RelationalDatabase _DataBase)
        {
            string ssql = "select zdmc �������,pym ƴ����,wbm �����,zdbm ����,sypc Ƶ�� from MZYS_CYZD " +
                          " where  ysdm=" + ysdm + " and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + " order by sypc desc";
            return _DataBase.GetDataTable(ssql);
        }

        /// <summary>
        /// ��ѯģ�� Modify By zp 2013-08-02 ����ģ��������޹� 
        /// </summary>
        /// <param name="ksdm"></param>
        /// <param name="ysdm"></param>
        /// <param name="funname"></param>
        /// <param name="mbjb"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable Select_Mb(int ksdm, int ysdm, string funname, int mbjb, RelationalDatabase _DataBase)
        {
            string ssql = @"select  mbmc ģ������,pym,(case mbjb when 0 then 'Ժ��'
                            when 1 then '�Ƽ�' when 2 then '����' when 3 then 'Ժ��Э������' when 4 then '�Ƽ�Э������' else '' end) ����,mbxh as mbid,fid,BTree from JC_CFMB 
                           where bscbz=0    "; //and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "
            /*------------------------------------------------------����ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_grmb")
                ssql = ssql + " and (mbjb in(2) and ysdm=" + ysdm + ")";//����ģ��������޹� and (ksdm=" + ksdm + " or ksdm=0) )
            /*------------------------------------------------------�Ƽ�ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_kjmb")
                ssql = ssql + " and mbjb in(1) and ksdm=" + ksdm + " ";
            /*------------------------------------------------------Ժ��ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_yjmb")
                ssql = ssql + " and mbjb in(0)";
            if ( funname == "Fun_ts_mzys_blcflr_xdcf_yj" )
                ssql = ssql + " and mbjb in(3)";
            if ( funname == "Fun_ts_mzys_blcflr_xdcf_kj" )
                ssql = ssql + " and mbjb in(4)";
            /*------------------------------------------------------����ҽ����������¼��||סԺҽ������¼��----------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr" || funname == "Fun_ts_mzys_blcflr_wtsq" || funname == "Fun_ts_zyys_blcflr")
            {
                // if (mbjb==0 || mbjb==1)
                //    ssql = ssql + " and mbjb =" + mbjb + " ";
                // if (mbjb==2)
                //    ssql = ssql + " and mbjb=2 and ysdm=" + ysdm + " ";
                //if (mbjb < 0)
                //    ssql = ssql + " and (mbjb in(0,1) or ysdm="+ysdm+" )";
                if (mbjb < 0)
                {
                    ssql = ssql + " and (mbjb =0 or ((mbjb=1 or mbjb=4) and ksdm=" + ksdm + ") or (mbjb=2 and ysdm=" + ysdm + ") ) ";
                }

                if (mbjb == 0 || mbjb == 3 )
                    ssql = ssql + " and mbjb =" + mbjb + " ";
                if (mbjb == 1)
                    ssql = ssql + " and mbjb=1 and ksdm=" + ksdm + " ";
                if (mbjb == 2) //����Ǹ���ģ�� ����������
                    ssql = ssql + " and  mbjb=2  and  ysdm=" + ysdm + " ";//and (ksdm=" + ksdm + " or ksdm=0)
                if ( mbjb == 4 )
                    ssql = ssql + " and mbjb=4 and ksdm=" + ksdm;
            }
            ssql = ssql + " order by mbmc";
            return _DataBase.GetDataTable(ssql);
        }

        //ͨ��ģ�弶��id ��ȡģ����Ϣ Add by zp 2013-12-11
        public static DataTable Select_Mb(int ksdm, int ysdm, int mbjb, RelationalDatabase _DataBase)
        {
            string ssql = @"select  mbmc ģ������,pym,(case mbjb when 0 then 'Ժ��'
                            when 1 then '�Ƽ�' when 2 then '����'  else '' end) ����,mbxh as mbid,fid,BTree from JC_CFMB 
                           where bscbz=0    "; //and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "
            /*------------------------------------------------------����ģ��----------------------------------------------------------------------------*/

            // if (mbjb==0 || mbjb==1)
            //    ssql = ssql + " and mbjb =" + mbjb + " ";
            // if (mbjb==2)
            //    ssql = ssql + " and mbjb=2 and ysdm=" + ysdm + " ";
            //if (mbjb < 0)
            //    ssql = ssql + " and (mbjb in(0,1) or ysdm="+ysdm+" )";
            if (mbjb < 0)
            {
                ssql = ssql + " and (mbjb =0 or (mbjb=1 and ksdm=" + ksdm + ") or (mbjb=2 and djy=" + ysdm + ") ) ";
            }

            if (mbjb == 0)
                ssql = ssql + " and mbjb =" + mbjb + " ";
            if (mbjb == 1)//add by jiangzf
            {
                SystemCfg cfg3096 = new SystemCfg(3096);
                if (cfg3096.Config.Trim() == "1")
                    ssql = ssql + " and (( mbjb=1 and ksdm=" + ksdm + ") or  (mbjb=2  and  djy=" + ysdm + " )) ";
                else
                    ssql = ssql + " and mbjb=1 and ksdm=" + ksdm + " ";
            }
            if (mbjb == 2) //����Ǹ���ģ�� ����������
                ssql = ssql + " and  mbjb=2  and  djy=" + ysdm + " ";//and (ksdm=" + ksdm + " or ksdm=0)

            ssql = ssql + " order by mbmc";
            return _DataBase.GetDataTable(ssql);
        }

        /// <summary>
        /// ��ѯģ�����
        /// </summary>
        /// <param name="ksdm"></param>
        /// <param name="ysdm"></param>
        /// <param name="funname"></param>
        /// <param name="mbjb"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static DataTable Select_MbFl(int ksdm, int ysdm, string funname, int mbjb, RelationalDatabase _DataBase)
        {
            string ssql = @"select  mbmc ģ������,pym,(case mbjb when 0 then 'Ժ��'
                            when 1 then '�Ƽ�' when 2 then '����'  else '' end) ����,mbxh as mbid,fid,BTree from JC_CFMB 
                           where bscbz=0   and BTree=1  "; //and jgbm=" + TrasenFrame.Forms.FrmMdiMain.Jgbm + "
            /*------------------------------------------------------����ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_grmb")
                ssql = ssql + " and (mbjb in(2) and ysdm=" + ysdm + " and (ksdm=" + ksdm + " or ksdm=0) ) ";
            /*------------------------------------------------------�Ƽ�ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_kjmb")
                ssql = ssql + " and mbjb in(1) and ksdm=" + ksdm + " ";
            /*------------------------------------------------------Ժ��ģ��----------------------------------------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr_yjmb")
                ssql = ssql + " and mbjb in(0)";

            if( funname == "Fun_ts_mzys_blcflr_xdcf_yj" )
                ssql = ssql + " and mbjb in(3)";
            if( funname == "Fun_ts_mzys_blcflr_xdcf_kj")
                ssql = ssql + " and mbjb in(4)";
            /*------------------------------------------------------����ҽ����������¼��||סԺҽ������¼��----------------------------------------------*/
            if (funname == "Fun_ts_mzys_blcflr" || funname == "Fun_ts_mzys_blcflr_wtsq" || funname == "Fun_ts_zyys_blcflr")
            {
                // if (mbjb==0 || mbjb==1)
                //    ssql = ssql + " and mbjb =" + mbjb + " ";
                // if (mbjb==2)
                //    ssql = ssql + " and mbjb=2 and ysdm=" + ysdm + " ";
                //if (mbjb < 0)
                //    ssql = ssql + " and (mbjb in(0,1) or ysdm="+ysdm+" )";
                if (mbjb < 0)
                {
                    ssql = ssql + " and (mbjb =0 or (mbjb=1 and ksdm=" + ksdm + ") or (mbjb=2 and ysdm=" + ysdm + ") ) ";
                }

                if (mbjb == 0)
                    ssql = ssql + " and mbjb =" + mbjb + " ";
                if (mbjb == 1)
                    ssql = ssql + " and mbjb=1 and ksdm=" + ksdm + " ";
                if (mbjb == 2)
                    ssql = ssql + " and  mbjb=2 and ysdm=" + ysdm + "";
            }
            ssql = ssql + " order by mbjb";
            return _DataBase.GetDataTable(ssql);
        }

        public static DataTable Seek_Yp_Price(int dwlx, decimal num, int zxcs, int jgts, decimal ts, int cjid, int yfid, int ydwbl, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];

                parameters[0].Text = "@dwtype";
                parameters[0].Value = dwlx;

                parameters[1].Text = "@num";
                parameters[1].Value = num;

                parameters[2].Text = "@zxcs";
                parameters[2].Value = zxcs;

                if (jgts == 0) jgts = 1;
                parameters[3].Text = "@jgts";
                parameters[3].Value = jgts;

                parameters[4].Text = "@ts";
                parameters[4].Value = ts;

                parameters[5].Text = "@cjid";
                parameters[5].Value = cjid;

                parameters[6].Text = "@deptid";
                parameters[6].Value = yfid;

                parameters[7].Text = "@dwbl";
                parameters[7].Value = ydwbl;


                DataTable tb;
                if (new SystemCfg(3017).Config == "1")
                    tb = _DataBase.GetDataTable("sp_Fun_DW_NUM_MZ", parameters, 30);
                else
                    tb = _DataBase.GetDataTable("sp_Fun_DW_NUM", parameters, 30);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        public static DataTable GetJyGlItem(DataTable dt, RelationalDatabase _DataBase)
        {
            DataTable dt_new = new DataTable();
            try
            {
                if (!dt.Columns.Contains("hjid")) return dt_new;
                if (new SystemCfg(3083, _DataBase).Config.Trim() == "0") return dt_new;
                dt_new = dt.Clone(); //����� ������Ҫ���ɹ��ӷѺ;�����Ѫ�ѵ���Ŀ
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convertor.IsNull(dt.Rows[i]["hjid"], "") == Guid.Empty.ToString() && Convertor.IsNull(dt.Rows[i]["��Ŀ��Դ"], "1") == "2" && Convertor.IsNull(dt.Rows[i]["�÷�"], "") == "������Ѫ")
                    {
                        dt_new.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("�����쳣!ԭ��:" + ea.Message, "��ʾ");
            }
            return dt_new;
        }

        public static void Yjsq(long jgbm, DataTable tbmx, Guid yjsqid, Guid yzid, Guid brxxid, Guid ghxxid, Guid jzid, string blh, int djlx, string sqrq,
                        int sqr, int sqks, string bsjc, string lczd, int zxks, string bbmc, string zysx, int bjjbz, decimal cfje, int yblx
                        , RelationalDatabase _DataBase)
        {

            try
            {
 
                _DataBase.BeginTransaction();

                if (jgbm <= 0) throw new Exception("û���趨��������,���ʵ");
                if (brxxid == Guid.Empty) throw new Exception("û��ѡ������,���ʵ");
                if (ghxxid == Guid.Empty) throw new Exception("û��ѡ������,���ʵ");
                if (jzid == Guid.Empty) throw new Exception("û�������,���ʵ");

                int err_code = -1; string err_text = "";
                Guid NewHjid = Guid.Empty;
                mz_hj.SaveCf(yzid, brxxid, ghxxid, blh, sqrq, sqr, "", sqr, sqks, 0, cfje, zxks, 0, 2, 1, jgbm, 1, jzid, out NewHjid, out err_code, out err_text, _DataBase);
                if (NewHjid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                DataTable Tab1 = mzys.Select_cf(0, ghxxid, 99888, 1, Guid.Empty, Guid.Empty, 0, jgbm, _DataBase);
                DataTable Tab = Tab1.Clone();



                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    int tcid = Convert.ToInt32(tbmx.Rows[i]["�ײ�id"]);
                    long order_id = Convert.ToInt64(tbmx.Rows[i]["ҽ����Ŀid"]);
                    string order_name = Convert.ToString(tbmx.Rows[i]["����"]);
                    decimal dj = Convert.ToDecimal(tbmx.Rows[i]["����"]);
                    decimal sl = Convert.ToDecimal(tbmx.Rows[i]["����"]);
                    string dw = Convert.ToString(tbmx.Rows[i]["��λ"]);
                    decimal je = Convert.ToDecimal(tbmx.Rows[i]["���"]);
                    string pc = Convert.ToString(tbmx.Rows[i]["Ƶ��"]);
         
                    if (tcid > 0)
                    {
                        DataTable Tabtc;

                        if (yzid != Guid.Empty)
                        {
                            DataTable tbyj = mzys_yjsq.Select_E(yjsqid, _DataBase);
                            if (tbyj.Rows.Count > 0)
                            {
                                mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(), _DataBase);
                            }
                        }

                        Tabtc = mzys.Select_cf(0, ghxxid, tcid, sl, Guid.Empty, Guid.Empty, order_id, jgbm, _DataBase);

                        for (int b = 0; b <= Tabtc.Rows.Count - 1; b++)
                        {
                            Tabtc.Rows[b]["Ƶ��"] = pc;
                            Tab.ImportRow(Tabtc.Rows[b]);
                        }
                    }
                    else
                    {
                        string ssql = "select item_unit,cost_price ,0 pfj,a.py_code,std_code,item_name,item_id,statitem_code " +
                            " from jc_hsitemdiction a inner join jc_hoi_hdi b on a.item_id=b.hditem_id and tc_flag=0 inner join " +
                          " jc_hoitemdiction c on b.hoitem_id=c.order_id   where c.order_id=" + order_id + " and a.jgbm=" + jgbm + " ";
                        DataTable tabxm = _DataBase.GetDataTable(ssql);
                        DataRow row = Tab.NewRow();
                        if (yzid != Guid.Empty && order_id > 0)
                        {
                            ssql = "select hjmxid from mz_hjb_mx where hjid='" + yzid + "' and yzid=" + order_id + "";
                            DataTable tb = _DataBase.GetDataTable(ssql);
                            if (tb.Rows.Count > 1) throw new Exception("�ڸ���ҽ����ϸʱ��ͬһ�����ҵ�������ͬ����Ŀ");
                            if (tb.Rows.Count == 1)
                                row["HJMXID"] = tb.Rows[0]["hjmxid"];
                            else
                            {
                                DataTable tbyj = mzys_yjsq.Select_E(yjsqid, _DataBase);
                                if (tbyj.Rows.Count > 0)
                                {
                                    if (tbyj.Rows[0]["yzxmid"].ToString() != order_id.ToString())
                                        mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(), _DataBase);
                                }
                                row["HJMXID"] = Guid.Empty.ToString();
                            }


                        }
                        else
                            row["HJMXID"] = Guid.Empty.ToString();
                        row["HJID"] = yzid.ToString();
                        row["ƴ����"] = tabxm.Rows[0]["PY_CODE"];
                        row["����"] = tabxm.Rows[0]["std_code"];
                        row["��Ŀ����"] = tabxm.Rows[0]["item_name"];
                        row["��Ʒ��"] = tabxm.Rows[0]["item_name"];
                        row["Ƶ��ID"] = "0";
                        row["Ƶ��"] = pc;
                        row["�÷�ID"] = "0";
                        row["ͳ�ƴ���Ŀ"] = tabxm.Rows[0]["statitem_code"];
                        row["��ĿID"] = tabxm.Rows[0]["item_id"];
                        row["ִ�п���"] = Fun.SeekDeptName(zxks, _DataBase);
                        row["ִ�п���id"] = zxks.ToString();
                        row["סԺ����ID"] = "0";
                        row["��Ŀ��Դ"] = "2";
                        row["����"] = sl;
                        row["����"] = "1";
                        row["����"] = dj.ToString();
                        row["��λ"] = tabxm.Rows[0]["item_unit"].ToString();
                        row["���"] = je.ToString();
                        row["yzid"] = order_id;
                        row["yzmc"] = order_name;
                        row["����"] = sl.ToString();
                        row["����"] = "1";
                        row["������λ"] = tabxm.Rows[0]["item_unit"];
                        Tab.Rows.Add(row);
                    }

                    Guid NewYjsqid = Guid.Empty;
                    mzys_yjsq.Save(yjsqid, jgbm, brxxid, ghxxid, jzid, blh, djlx, sqrq, sqr, sqks, order_name, dj, sl, dw, je, pc, bsjc, lczd, zxks, bbmc, zysx, bjjbz, NewHjid, order_id,null, out NewYjsqid,
                        out err_code, out err_text, _DataBase);
                    if (err_code != 0) throw new Exception(err_text);


                    #region ���»���볣��ҩƷ����Ŀ
                    if (yzid == Guid.Empty)
                    {
                        mzys.add_cyyp_cyxm(jgbm, 2, order_id, tcid > 0 ? 1 : 0,
                            sqr, sl,
                            0, 0,
                            0, 0, sqrq, _DataBase);
                    }
                    #endregion

                }


                for (int xx = 0; xx <= Tab.Rows.Count - 1; xx++)
                {
                    Guid _NewHjmxid = Guid.Empty;
                    Guid _hjmxid = new Guid(Convertor.IsNull(Tab.Rows[xx]["hjmxid"], Guid.Empty.ToString()));
                    string _pym = Convertor.IsNull(Tab.Rows[xx]["ƴ����"], "");
                    string _bm = Convertor.IsNull(Tab.Rows[xx]["����"], "");
                    string _pm = Convertor.IsNull(Tab.Rows[xx]["��Ŀ����"], "");
                    string _spm = Convertor.IsNull(Tab.Rows[xx]["��Ʒ��"], "");
                    string _gg = Convertor.IsNull(Tab.Rows[xx]["���"], "");
                    string _cj = Convertor.IsNull(Tab.Rows[xx]["����"], "");
                    decimal _dj = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0"));
                    decimal _sl = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0"));
                    string _dw = Convertor.IsNull(Tab.Rows[xx]["��λ"], "");
                    int _ydwbl = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["ydwbl"], "0"));
                    decimal _je = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["���"], "0"));
                    string _tjdxmdm = Convertor.IsNull(Tab.Rows[xx]["ͳ�ƴ���Ŀ"], "");
                    long _xmid = Convert.ToInt64(Convertor.IsNull(Tab.Rows[xx]["��Ŀid"], "0"));
                    int _bzby = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�Ա�ҩ"], "0"));
                    int _bpsbz = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["Ƥ�Ա�־"], "-1"));
                    Guid _pshjmxid = new Guid(Convertor.IsNull(Tab.Rows[xx]["pshjmxid"], Guid.Empty.ToString()));
                    decimal _yl = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0"));
                    string _yldw = Convertor.IsNull(Tab.Rows[xx]["������λ"], "");
                    int _yldwid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["������λid"], "0"));
                    int _dwlx = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["dwlx"], "0"));
                    int _yfid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�÷�id"], "0"));
                    string _yfmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["�÷�"], ""));
                    int _pcid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["Ƶ��id"], "0"));
                    string _pcmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["Ƶ��"], ""));
                    decimal _ts = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "1"));
                    string _zt = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["����"], ""));
                    int _fzxh = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�����������"], "0"));
                    int _pxxh = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�������"], "0"));
                    decimal _pfj = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["������"], "0"));
                    decimal _pfje = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["�������"], "0"));
                    long _yzid = Convert.ToInt64(Convertor.IsNull(Tab.Rows[xx]["yzid"], "0"));
                    string _yzmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["yzmc"], ""));
                    int _tcid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�ײ�id"], "0"));
                    mz_hj.SaveCfmx(_hjmxid.ToString(), NewHjid.ToString(), _pym.Trim(), _bm.Trim(), _pm.Trim(), _spm.Trim(), _gg.Trim(), _cj.Trim(), _dj, _sl, _dw.Trim(), _ydwbl, 1, _je, _tjdxmdm.Trim(), _xmid, _bzby, _bpsbz,
                        _pshjmxid.ToString(), _yl, _yldw, _yldwid, _dwlx, _yfid, _yfmc, _pcid, _pcmc, _ts, _zt, _fzxh, _pxxh, _pfj, _pfje, _tcid, _yzid, _yzmc, out _NewHjmxid, out err_code, out err_text, yblx,"", _DataBase);
                    if ((_NewHjmxid == Guid.Empty && _hjmxid == Guid.Empty) || err_code != 0) throw new Exception(err_text);



                }

                mz_hj.UpdateHjCfje(NewHjid, _DataBase);

                _DataBase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                throw new System.Exception(err.ToString());
                //return;
            }



        } 

        /// <summary>
        /// �������  �¼���ؼ�����  Modify By zp 2013-08-21
        /// </summary>
        /// <param name="jgbm"></param>
        /// <param name="tbmx"></param>
        /// <param name="yjsqid"></param>
        /// <param name="yzid"></param>
        /// <param name="brxxid"></param>
        /// <param name="ghxxid"></param>
        /// <param name="jzid"></param>
        /// <param name="blh"></param>
        /// <param name="djlx"></param>
        /// <param name="sqrq"></param>
        /// <param name="sqr"></param>
        /// <param name="sqks"></param>
        /// <param name="bsjc"></param>
        /// <param name="lczd"></param>
        /// <param name="zxks"></param>
        /// <param name="zysx"></param>
        /// <param name="bjjbz"></param>
        /// <param name="cfje"></param>
        /// <param name="yblx"></param>
        /// <param name="_DataBase"></param>
        public static void Yjsq(long jgbm, DataTable tbmx, Guid yjsqid, Guid yzid, Guid brxxid, Guid ghxxid, Guid jzid, string blh, int djlx, string sqrq,
                        int sqr, int sqks, string bsjc, string lczd, int zxks, string zysx, int bjjbz, decimal cfje, int yblx,
                        bool issfy, RelationalDatabase _DataBase)
        {

            try
            {
                DataTable dt_xglf = GetJyGlItem(tbmx,_DataBase);
                _DataBase.BeginTransaction();

                if (jgbm <= 0) throw new Exception("û���趨��������,���ʵ");
                if (brxxid == Guid.Empty) throw new Exception("û��ѡ������,���ʵ");
                if (ghxxid == Guid.Empty) throw new Exception("û��ѡ������,���ʵ");
                if (jzid == Guid.Empty) throw new Exception("û�������,���ʵ");

                int err_code = -1; string err_text = "";
                Guid NewHjid = Guid.Empty;
            
                mz_hj.SaveCf(yzid, brxxid, ghxxid, blh, sqrq, sqr, "", sqr, sqks, 0, cfje, zxks, 0, 2, 1, jgbm, 1, jzid, out NewHjid, out err_code, out err_text, _DataBase);
                if (NewHjid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                //������շ�Ա�����Ĵ�������Ҫ���»��۱�� ҽ��������־
                if (issfy)
                {
                    string sql = string.Format(@"UPDATE MZ_HJB SET BYSCF=0 WHERE HJID='{0}'",NewHjid);
                    _DataBase.DoCommand(sql);
                }
                DataTable Tab1 = mzys.Select_cf(0, ghxxid, 99888, 1, Guid.Empty, Guid.Empty, 0, jgbm, _DataBase);
                DataTable Tab = Tab1.Clone();


                for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
                {
                    int tcid = Convert.ToInt32(Convertor.IsNull(tbmx.Rows[i]["�ײ�id"], "-1"));
                    long order_id = Convert.ToInt64(tbmx.Rows[i]["ҽ����Ŀid"]);
                    string order_name = Convert.ToString(tbmx.Rows[i]["����"]);
                    decimal dj = Convert.ToDecimal(tbmx.Rows[i]["����"]);
                    decimal sl = Convert.ToDecimal(tbmx.Rows[i]["����"]);
                    string dw = Convert.ToString(tbmx.Rows[i]["��λ"]);
                    decimal je = Convert.ToDecimal(tbmx.Rows[i]["���"]);
                    string pc = Convert.ToString(tbmx.Rows[i]["Ƶ��"]);
                    string bbmc = Convert.ToString(tbmx.Rows[i]["�걾"]); //���浽������ϸ��GG�ֶ� Modify By ZP 2013-10-10 
                    //Modify By zp 2013-08-19  ��������˵��
                    string memo = Convertor.IsNull(tbmx.Rows[i]["����˵��"], "");
                    if (tcid > 0)
                    {
                        #region ��ȡ�ײ͵Ĵ�����ϸ��Ŀ
                        DataTable Tabtc;
                        if (yzid != Guid.Empty)
                        {
                            DataTable tbyj = mzys_yjsq.Select_E(yjsqid, _DataBase);
                            if (tbyj.Rows.Count > 0)
                            {
                                Guid _hjmxid = new Guid(Convertor.IsNull(tbyj.Rows[0]["HJMXID"], Guid.Empty.ToString()));
                                if(int.Parse(Convertor.IsNull(tbyj.Rows[0]["tcid"],"0").ToString())<=0)
                                    mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(),_hjmxid, _DataBase);
                                else
                                    mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(), _DataBase);
                            }
                        }
                        Tabtc = mzys.Select_cf(0, ghxxid, tcid, sl, Guid.Empty, Guid.Empty, order_id, jgbm, _DataBase);
                        //��ȡ�ײ͵���ϸ��Ŀ
                        for (int b = 0; b <= Tabtc.Rows.Count - 1; b++)
                        {
                            Tabtc.Rows[b]["Ƶ��"] = pc;
                            Tab.ImportRow(Tabtc.Rows[b]);
                        }
                        #endregion
                    }
                    else
                    {
                        #region ��ȡ���ײ͵Ĵ�����ϸ��Ŀ ��䵽������ϸ�ڴ��Tab
                        string ssql = "select item_unit,cost_price ,0 pfj,a.py_code,std_code,item_name,item_id,statitem_code " +
                            " from jc_hsitemdiction a inner join jc_hoi_hdi b on a.item_id=b.hditem_id and tc_flag=0 inner join " +
                          " jc_hoitemdiction c on b.hoitem_id=c.order_id   where c.order_id=" + order_id + " and a.jgbm=" + jgbm + " ";
                        DataTable tabxm = _DataBase.GetDataTable(ssql);
                        DataRow row = Tab.NewRow();
                        if (yzid != Guid.Empty && order_id > 0)
                        {
                            ssql = "select hjmxid from mz_hjb_mx where hjid='" + yzid + "' and yzid=" + order_id + "";
                            DataTable tb = _DataBase.GetDataTable(ssql);
                            //Modify By zp ���·��ײͼ�����Ŀ����ʱ����֤ͬһ�Ŵ�������ͬ��ϸ 2013-08-20
                            if (tb.Rows.Count > 1) throw new Exception("�ڸ���ҽ����ϸʱ��ͬһ�����ҵ�������ͬ����Ŀ");
                            if (tb.Rows.Count == 1)
                                row["HJMXID"] = tb.Rows[0]["hjmxid"];
                            else
                            {
                                DataTable tbyj = mzys_yjsq.Select_E(yjsqid, _DataBase);
                                if (tbyj.Rows.Count > 0)
                                {
                                    string _yzxmid = tbyj.Rows[0]["yzxmid"].ToString();

                                    Guid _hjmxid = Guid.Empty;
                                    if (!string.IsNullOrEmpty(Convertor.IsNull( tbyj.Rows[0]["HJMXID"],""))) 
                                        _hjmxid= new Guid(tbyj.Rows[0]["HJMXID"].ToString());
                                    //Modify by zp 2013-10-25
                                    if (tbyj.Rows[0]["yzxmid"].ToString() != order_id.ToString())
                                    {
                                        if (_hjmxid != Guid.Empty && int.Parse(Convertor.IsNull( tbyj.Rows[0]["tcid"],"0").ToString())<=0)
                                            mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(),_hjmxid, _DataBase);
                                        else 
                                            mz_hj.Delete_Cfmx(yzid, tbyj.Rows[0]["yzxmid"].ToString(), _DataBase);
                                    }
                                }
                                row["HJMXID"] = Guid.Empty.ToString();
                            }


                        }
                        else
                            row["HJMXID"] = Guid.Empty.ToString();
                        row["HJID"] = yzid.ToString();
                        row["ƴ����"] = tabxm.Rows[0]["PY_CODE"];
                        row["����"] = tabxm.Rows[0]["std_code"];
                        row["��Ŀ����"] = tabxm.Rows[0]["item_name"];
                        row["��Ʒ��"] = tabxm.Rows[0]["item_name"];
                        row["Ƶ��ID"] = "0";
                        row["Ƶ��"] = pc;
                        row["�÷�ID"] = "0";
                        row["ͳ�ƴ���Ŀ"] = tabxm.Rows[0]["statitem_code"];
                        row["��ĿID"] = tabxm.Rows[0]["item_id"];
                        row["ִ�п���"] = Fun.SeekDeptName(zxks, _DataBase);
                        row["ִ�п���id"] = zxks.ToString();
                        row["סԺ����ID"] = "0";
                        row["��Ŀ��Դ"] = "2";
                        row["����"] = sl;
                        row["����"] = "1";
                        row["����"] = dj.ToString();
                        row["��λ"] = tabxm.Rows[0]["item_unit"].ToString();
                        row["���"] = je.ToString();
                        row["yzid"] = order_id;
                        row["yzmc"] = order_name;
                        row["����"] = sl.ToString();
                        row["����"] = "1";
                        row["������λ"] = tabxm.Rows[0]["item_unit"];
                        Tab.Rows.Add(row);
                        #endregion
                    }
                    /*��ǰ���Ȳ���ҽ�������ٱ��滮����ϸ ,���ڸ�Ϊ��ȡ��ҽ�������Ӧ�Ļ�����ϸ���ȱ���
                     ��֤�Ȳ��뻮����ϸ,��Ϊ��ҽ���������Ҫ�õ�������ϸid
                     * */
                    Guid NewYjsqid = Guid.Empty;
                    Guid _NewHjmxid = Guid.Empty;
                    
                     

                    for (int xx = 0; xx <= Tab.Rows.Count - 1; xx++)
                    {
                        #region //ѭ��������ϸ ���뵽������ϸ
                        Guid _hjmxid = new Guid(Convertor.IsNull(Tab.Rows[xx]["hjmxid"], Guid.Empty.ToString()));
                        string _pym = Convertor.IsNull(Tab.Rows[xx]["ƴ����"], "");
                        string _bm = Convertor.IsNull(Tab.Rows[xx]["����"], "");
                        string _pm = Convertor.IsNull(Tab.Rows[xx]["��Ŀ����"], "");
                        string _spm = Convertor.IsNull(Tab.Rows[xx]["��Ʒ��"], "");
                        string _gg = bbmc; // Convertor.IsNull(Tab.Rows[xx]["���"], "");�˴�gg����걾 Modify By zp 2013-10-10 
                        string _cj = Convertor.IsNull(Tab.Rows[xx]["����"], "");
                        decimal _dj = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0"));
                        decimal _sl = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0"));
                        string _dw = Convertor.IsNull(Tab.Rows[xx]["��λ"], "");
                        int _ydwbl = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["ydwbl"], "0"));
                        decimal _je = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["���"], "0"));
                        string _tjdxmdm = Convertor.IsNull(Tab.Rows[xx]["ͳ�ƴ���Ŀ"], "");
                        long _xmid = Convert.ToInt64(Convertor.IsNull(Tab.Rows[xx]["��Ŀid"], "0"));
                        int _bzby = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�Ա�ҩ"], "0"));
                        int _bpsbz = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["Ƥ�Ա�־"], "-1"));
                        Guid _pshjmxid = new Guid(Convertor.IsNull(Tab.Rows[xx]["pshjmxid"], Guid.Empty.ToString()));
                        decimal _yl = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "0")); //modify by wangzhi 2015-4-10 ���ﲻ���á��������ֶ� 
                        string _yldw = Convertor.IsNull(Tab.Rows[xx]["������λ"], "");
                        int _yldwid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["������λid"], "0"));
                        int _dwlx = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["dwlx"], "0"));
                        int _yfid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�÷�id"], "0"));
                        string _yfmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["�÷�"], ""));
                        int _pcid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["Ƶ��id"], "0"));
                        string _pcmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["Ƶ��"], ""));
                        decimal _ts = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["����"], "1"));
                        string _zt = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["����"], ""));
                        int _fzxh = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�����������"], "0"));
                        int _pxxh = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�������"], "0"));
                        decimal _pfj = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["������"], "0"));
                        decimal _pfje = Convert.ToDecimal(Convertor.IsNull(Tab.Rows[xx]["�������"], "0"));
                        long _yzid = Convert.ToInt64(Convertor.IsNull(Tab.Rows[xx]["yzid"], "0"));
                        string _yzmc = Convert.ToString(Convertor.IsNull(Tab.Rows[xx]["yzmc"], ""));
                        int _tcid = Convert.ToInt32(Convertor.IsNull(Tab.Rows[xx]["�ײ�id"], "0"));
                        mz_hj.SaveCfmx(_hjmxid.ToString(), NewHjid.ToString(), _pym.Trim(), _bm.Trim(), _pm.Trim(), _spm.Trim(), _gg.Trim(), _cj.Trim(), _dj, _sl, _dw.Trim(), _ydwbl, 1, _je, _tjdxmdm.Trim(), _xmid, _bzby, _bpsbz,
                            _pshjmxid.ToString(), _yl, _yldw, _yldwid, _dwlx, _yfid, _yfmc, _pcid, _pcmc,_ts, _zt, _fzxh, _pxxh, _pfj, _pfje, _tcid, _yzid, _yzmc, out _NewHjmxid, out err_code, out err_text, yblx,memo, _DataBase);
                        if ((_NewHjmxid == Guid.Empty && _hjmxid == Guid.Empty) || err_code != 0) throw new Exception(err_text);
                        if (_sl > 1)//Modify By zp 2013-10-08 �˴�д��Ϊ1 ��Ϊ�ײ��ڵ���ϸnum����1����ҽ��վ��ѯ���̻���ʾ�ظ����ײͼ�¼ 
                        {
                            string _sql = string.Format(@"UPDATE MZ_HJB_MX SET YL=1 WHERE HJMXID='{0}'", _NewHjmxid);
                            _DataBase.DoCommand(_sql);
                        }
                        #endregion

                        /*�����괦����ϸ���ٱ���ҽ�������¼*/
                        if (tcid <= 0) //����Ƿ��ײ� ��ÿ����һ��������ϸ�� ����һ��ҽ������
                        {
                            mzys_yjsq.Save(yjsqid, jgbm, brxxid, ghxxid, jzid, blh, djlx, sqrq, sqr, sqks,
                                order_name, dj, sl, dw, je, pc, bsjc, lczd, zxks, bbmc, zysx, bjjbz, NewHjid,
                                order_id, _NewHjmxid, out NewYjsqid, out err_code, out err_text, _DataBase);
                            if (err_code != 0) throw new Exception(err_text);
                        }
                    }
                    Tab.Clear();//���������������ϸ

                    if (tcid > 0) //�ײ�ֻ����һ��ҽ�������¼
                    {
                        mzys_yjsq.Save(yjsqid, jgbm, brxxid, ghxxid, jzid, blh, djlx, sqrq, sqr, sqks,
                                                       order_name, dj, sl, dw, je, pc, bsjc, lczd, zxks, bbmc, zysx, bjjbz, NewHjid,
                                                       order_id, _NewHjmxid, out NewYjsqid, out err_code, out err_text, _DataBase);
                        if (err_code != 0) throw new Exception(err_text);
                    }
               
                    #region ���»���볣��ҩƷ����Ŀ
                    if (yzid == Guid.Empty)
                    {
                        mzys.add_cyyp_cyxm(jgbm, 2, order_id, tcid > 0 ? 1 : 0,
                            sqr, sl,
                            0, 0,
                            0, 0, sqrq, _DataBase);
                    }
                    #endregion

                }
                mz_hj.UpdateHjCfje(NewHjid, _DataBase);

                _DataBase.CommitTransaction();
            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                throw new System.Exception(err.ToString());
                //return;
            }

        }


        //��ӳ�����Ŀ��ҩƷ
        public static void add_cyyp_cyxm(long jgbm, int lx, long xmid, int btc, int ysdm, decimal scyl, int scyldwlx, int scyf, int scpc, int cjid, string djsj, RelationalDatabase _DataBase)
        {
            string ssql = "update mzys_cyypxm set sypc=sypc+1,scyl=" + scyl + "," +
                " scyldwlx=" + scyldwlx + ",scyf=" + scyf + ",scpc=" + scpc + ",djsj='" + djsj + "' where ysdm=" + ysdm + " and jgbm=" + jgbm + " and lx=" + lx + " and xmid=" + xmid + " ";
            int i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                ssql = "insert into mzys_cyypxm(jgbm,lx,xmid,btc,ysdm,sypc,scyl,scyldwlx,scyf,scpc,cjid,djsj)values(" +
                    jgbm + "," + lx + "," + xmid + "," + btc + "," + ysdm + ",1," + scyl + "," + scyldwlx + "," + scyf + "," + scpc + "," + cjid + ",'" + djsj + "')";
                i = _DataBase.DoCommand(ssql);
            }
        }
        //��ӳ������
        public static void add_cyzd(long jgbm, string zdbm, string zdmc, string pym, string wbm, int ysdm, string djsj, int bbzbm, RelationalDatabase _DataBase)
        {
            using ( IDbCommand command = _DataBase.GetCommand() )
            {
                int effectRow = 0;
                command.CommandType = CommandType.Text;
                if ( _DataBase.IsInTransaction )
                    command.Transaction = _DataBase.GetTransaction();
                command.CommandText = "update mzys_cyzd set sypc=sypc+1 where ysdm=@ysdm and jgbm=@jgbm and zdbm=@zdbm and zdmc=@zdmc";
                command.Parameters.Add( Fun.NewCommandParameter( command , "@ysdm" , ysdm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@jgbm" , jgbm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@zdbm" , zdbm ) );
                command.Parameters.Add( Fun.NewCommandParameter( command , "@zdmc" , zdmc ) );
                effectRow = command.ExecuteNonQuery();
                if ( effectRow == 0 )
                {
                    command.Parameters.Clear();
                    command.CommandText = "insert into mzys_cyzd(jgbm,zdbm,zdmc,pym,wbm,sypc,ysdm,djsj,bbzbm)values(@jgbm,@zdbm,@zdmc,@pym,@wbm,1,@ysdm,@djsj,@bbzbm)";
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@jgbm" , jgbm ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@zdbm" , zdbm ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@zdmc" , zdmc ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@pym" , pym ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@wbm" , wbm ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@ysdm" , ysdm ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@djsj" , djsj ) );
                    command.Parameters.Add( Fun.NewCommandParameter( command , "@bbzbm" , bbzbm ) );
                    effectRow = command.ExecuteNonQuery();
                }
            }



            //string ssql = "update mzys_cyzd set sypc=sypc+1 where ysdm=" + ysdm + " and jgbm=" + jgbm + " and zdbm='" + zdbm + "' and zdmc='" + zdmc + "' ";
            //int i = _DataBase.DoCommand(ssql);
            //if (i == 0)
            //{
            //    ssql = "insert into mzys_cyzd(jgbm,zdbm,zdmc,pym,wbm,sypc,ysdm,djsj,bbzbm)values(" +
            //        jgbm + ",'" + zdbm + "','" + zdmc + "','" + pym + "','" + wbm + "',1," + ysdm + ",'" + djsj + "'," + bbzbm + ")";
            //    i = _DataBase.DoCommand(ssql);
            //}
        }

        //���벡����Ϣ����  �Ƿ������޺�
        public static void whkz(Guid kdjid, out int bok, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];

                parameters[0].Text = "@kdjid";
                parameters[0].Value = kdjid;

                parameters[1].Text = "@bok";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int16;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@err_code";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].DataType = System.Data.DbType.Int32;
                parameters[2].ParaSize = 100;

                parameters[3].Text = "@err_text";
                parameters[3].ParaDirection = ParameterDirection.Output;
                parameters[3].ParaSize = 100;

                _DataBase.DoCommand("SP_mzys_whkz", parameters, 30);
                bok = Convert.ToInt32(parameters[1].Value);
                err_code = Convert.ToInt32(parameters[2].Value);
                err_text = Convert.ToString(parameters[3].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }



        }

        /// <summary>
        /// ͨ���Һ���Ϣ��ȡ������Ϣ Add By Zp 2013-09-11
        /// </summary>
        /// <param name="_ghxxid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string GetTzInfo(Guid _ghxxid, TrasenClasses.DatabaseAccess.RelationalDatabase db)
        {
            string value = "";
            try
            {
                string sql = "select * from MZ_BRTZ where delete_bit=0 and ghxxid='" + _ghxxid + "'";
                DataTable dt = db.GetDataTable(sql);
                if (dt.Rows.Count == 0) return value;
         
               foreach (DataColumn dc in dt.Columns)
               {
                   if (!string.IsNullOrEmpty(dt.Rows[0][dc].ToString()))
                   {
                       switch(dc.ColumnName)
                       { 
                           case "xy":
                               value += "Ѫѹ(mmHg)��" + dt.Rows[0]["xy"]; 
                               break;
                           case "xt":
                               value += "|| Ѫ��(mmoL/L )��" + dt.Rows[0]["xt"];
                               break;
                           case "tw":
                               value += "|| ����(��)��" + dt.Rows[0]["tw"];
                               break;
                           case "hx":
                               value += "|| ����(����)��" + dt.Rows[0]["hx"];
                               break;
                           case "mb":
                               value += "|| ������" + dt.Rows[0]["mb"];
                               break;
                           case "Tz":
                               value += "|| ����(kg)��" + dt.Rows[0]["Tz"];
                                break;
                       }
                   }
               }
            }
            catch (Exception ea)
            {
                throw new Exception("ʵ����������Ϣ�����쳣!ԭ��:"+ea.Message);
            }
            return value;
        }

        //
        public static void SetYfglFee(Guid brxxid,Guid ghxxid,string blh,string cfrq,int hjy,int ysdm,int ksdm,long jgbm,Guid jzid, DataTable dt_item, TrasenClasses.DatabaseAccess.RelationalDatabase _DataBase)
        {
            try
            {
                /*����ж����Ŀ��JC_JYBBFLMX�ﹲ��һ��FLID��ֻ��ȡһ�����ӷѺ;�����Ѫ��*/
                if (dt_item == null || dt_item.Rows.Count <= 0) return;
                List<string> List_yzxm = new List<string>();
                int item_cout = dt_item.Rows.Count, Ufl_cout = 0;
                string where_xmid = "",sql = "";
 
                if (dt_JYBBFLMX == null)
                {
                    sql = @"select * from JC_JYBBFLMX";
                    dt_JYBBFLMX = _DataBase.GetDataTable(sql);
                }
                for (int i = 0; i < item_cout; i++)
                {
                    /*��dt_flmx�õ���ǰҽ����Ӧ��FLMXid */
                    string yzxmid = Convertor.IsNull(dt_item.Rows[i]["yzid"], "0");
                    if (dt_JYBBFLMX.Select("YZXMID=" + yzxmid + "").Length > 0)
                    {
                        if (string.IsNullOrEmpty(where_xmid))
                            where_xmid = yzxmid;
                        else
                            where_xmid += "," + yzxmid;
                    }
                    else
                        Ufl_cout++;               
                }
                DataTable dt_fl=new DataTable ();
                if (!string.IsNullOrEmpty(where_xmid) && item_cout > 0)
                {
                    sql = @"select  distinct FLID  from JC_JYBBFLMX a 
                        inner join JC_HOITEMDICTION b on a.YZXMID=b.ORDER_ID
                        where b.ORDER_ID in (" + where_xmid + ")";
                     dt_fl = _DataBase.GetDataTable(sql); //ÿһ������һ�����ӷѺ;�����Ѫ��
                }
                Ufl_cout = Ufl_cout + dt_fl.Rows.Count; //������Ҫ���ɹ��ӷѺ;�����Ѫ��
                SaveYfglCf(brxxid, ghxxid, blh, cfrq, hjy, ysdm, ksdm, jgbm, jzid, Ufl_cout, 0, _DataBase); 
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }

        private static void SaveYfglCf( Guid brxxid , Guid ghxxid , string blh , string cfrq , int hjy , int ysdm , int ksdm , long jgbm , Guid jzid , int Ufl_cout , int yblx , RelationalDatabase _DataBase )
        {
            /*ͨ��������ȡ�� ���ӷѵ���Ŀ�;�����Ѫ����Ŀ,�Զ�����һ�Ŵ������Ȳ�ѯ��������Ŀ��
               ִ�п��ң���һ������Ҫ�������Ŵ���*/
            try
            {
                if ( _cfg7015 == null )
                    _cfg7015 = new SystemCfg( 7015 , _DataBase );
                if ( _cfg7016 == null )
                    _cfg7016 = new SystemCfg( 7016 , _DataBase );
                if ( _cfg3077 == null )
                    _cfg3077 = new SystemCfg( 3077 , _DataBase );
                string sql = "";
                Guid _pshjmxid = Guid.Empty;
                if ( exc_dept7015 == -1 )
                {
                    sql = @" select isnull(EXEC_DEPT,0) from JC_HOI_DEPT where ORDER_ID =" + _cfg7015.Config + "  order by DEFAULT_BIT desc";
                    exc_dept7015 = Convert.ToInt32( _DataBase.GetDataResult( sql ) );
                }
                if ( exc_dept7016 == -1 )
                {
                    sql = @" select isnull(EXEC_DEPT,0) from JC_HOI_DEPT where ORDER_ID =" + _cfg7016.Config + "  order by DEFAULT_BIT desc";
                    exc_dept7016 = Convert.ToInt32( _DataBase.GetDataResult( sql ) );
                }
                int cfzs = 1;
                if ( exc_dept7015 != exc_dept7016 ) //ִ�п��Ҳ�ͬ��Ҫ�������Ŵ���
                    cfzs = 2;


                decimal cfje = 0;
                int zxks = 0;
                Guid NewHjid = Guid.Empty;
                int err_code = 0;
                string err_text = "";
                string pym = "";
                string bm = "";
                string pm = "";
                decimal dj = 0;
                string dw = "";
                string tjdxmdm = "";
                long xmid = 0;
                string yldwmc = "";
                long yzid = 0;
                string yzmc = "";
                sql = @"select a.STD_CODE ����,c.PY_CODE ƴ����,a.ITEM_NAME ��Ʒ��,a.RETAIL_PRICE ����,a.ITEM_UNIT ��λ,a.STATITEM_CODE,a.ITEM_ID,
                0 psks,a.ITEM_UNIT ������λ,0 PCID,'' PCMC,1 TS,'' ZT,0 FZXH,0 TCID,c.ORDER_ID yzid,c.ORDER_NAME yzmc,0 bsdbz,0 sdks,0 sddjy,'' memo from JC_HSITEMDICTION a
                inner join JC_HOI_HDI b on a.ITEM_ID=b.HDITEM_ID
                inner join JC_HOITEMDICTION c on b.HOITEM_ID=c.ORDER_ID
                where c.ORDER_ID in(" + _cfg7015.Config + "," + _cfg7016.Config + ")";
                DataTable dt_order = _DataBase.GetDataTable( sql );
                //Modify By ������Ѫֻ����һ�ν��
                sql = @"  select isnull(sum(RETAIL_PRICE),0) from JC_HSITEMDICTION a
                        inner join JC_HOI_HDI b on a.ITEM_ID=b.HDITEM_ID
                        where b.HOITEM_ID in(" + _cfg7015.Config + ")";
                cfje += Convert.ToDecimal( _DataBase.GetDataResult( sql ) );

                if ( cfzs == 1 )
                {
                    zxks = exc_dept7015;
                    for ( int i = 0 ; i < Ufl_cout ; i++ ) //ͨ�����ӡ�������Ѫ��������ܽ��
                    {
                        sql = @"  select isnull(sum(RETAIL_PRICE),0) from JC_HSITEMDICTION a
                        inner join JC_HOI_HDI b on a.ITEM_ID=b.HDITEM_ID
                        where b.HOITEM_ID in(" + _cfg7016.Config + ")";
                        cfje += Convert.ToDecimal( _DataBase.GetDataResult( sql ) );
                    }

                    mz_hj.SaveCf( Guid.Empty , brxxid , ghxxid , blh , cfrq , hjy , "" , ysdm , ksdm , 0 , cfje , zxks , 0 , 2 , 1 , jgbm , 1 , jzid , out NewHjid , out err_code , out err_text , _DataBase );
                    //Modify By ������Ѫֻ����һ��
                    int _Ufl_cout;
                    decimal cfmxje = 0;
                    for ( int k = 0 ; k < dt_order.Rows.Count ; k++ )
                    {
                        _Ufl_cout = Ufl_cout;
                        if ( Convertor.IsNull( dt_order.Rows[k]["yzid"] , "0" ) == _cfg7015.Config )
                            _Ufl_cout = 1;
                        pym = Convertor.IsNull( dt_order.Rows[k]["ƴ����"] , "" );
                        bm = Convertor.IsNull( dt_order.Rows[k]["����"] , "" );
                        pm = Convertor.IsNull( dt_order.Rows[k]["��Ʒ��"] , "" );
                        dj = Convert.ToDecimal( Convertor.IsNull( dt_order.Rows[k]["����"] , "0" ) );
                        tjdxmdm = Convertor.IsNull( dt_order.Rows[k]["STATITEM_CODE"] , "" );
                        xmid = Convert.ToInt64( Convertor.IsNull( dt_order.Rows[k]["ITEM_ID"] , "0" ) );
                        yldwmc = Convertor.IsNull( dt_order.Rows[k]["������λ"] , "" );
                        yzid = Convert.ToInt64( Convertor.IsNull( dt_order.Rows[k]["yzid"] , "0" ) );
                        yzmc = Convertor.IsNull( dt_order.Rows[k]["yzmc"] , "" );
                        Guid _NewHjmxid = Guid.Empty;
                        int _err_code = 0;
                        string _err_text = "";
                        if ( _cfg3077.Config == "1" )
                            Ufl_cout = 1;
                        mz_hj.SaveCfmx( Guid.Empty.ToString() , NewHjid.ToString() , pym , bm , pm , pm , "" , "" , dj , _Ufl_cout , dw , 1 , 1 ,
                                ( dj * _Ufl_cout ) , tjdxmdm , xmid , 0 , -1 , Guid.Empty.ToString() , _Ufl_cout , yldwmc , 0 , 0 , 0 , "" , 0 , "" , 1 , "" ,
                                0 , k , 0 , 0 , 0 , yzid , yzmc , out _NewHjmxid , out _err_code , out _err_text , yblx , "" , _DataBase );
                        cfmxje = cfmxje +  dj * _Ufl_cout;
                    }
                    if ( cfmxje != cfje )
                        throw new Exception( string.Format( "����������÷�������,����7016�趨����Ŀ�Ľ��Ϊ{0},���ɴ�������ϸ���Ϊ{1}" , cfje , cfmxje ) );
                }
                else//���Ŵ��� ������Ŀ�ֿ�����
                {
                    zxks = exc_dept7015;
                    mz_hj.SaveCf( Guid.Empty , brxxid , ghxxid , blh , cfrq , hjy , "" , ysdm , ksdm , 0 , cfje , zxks , 0 , 2 , 1 , jgbm , 1 , jzid , out NewHjid , out err_code , out err_text , _DataBase );
                    DataRow[] drs = dt_order.Select( "yzid=" + _cfg7015.Config.Trim() + "" );
                    pym = Convertor.IsNull( drs[0]["ƴ����"] , "" );
                    bm = Convertor.IsNull( drs[0]["����"] , "" );
                    pm = Convertor.IsNull( drs[0]["��Ʒ��"] , "" );
                    dj = Convert.ToDecimal( Convertor.IsNull( drs[0]["����"] , "0" ) );
                    tjdxmdm = Convertor.IsNull( drs[0]["STATITEM_CODE"] , "" );
                    xmid = Convert.ToInt64( Convertor.IsNull( drs[0]["ITEM_ID"] , "0" ) );
                    yldwmc = Convertor.IsNull( drs[0]["������λ"] , "" );
                    yzid = Convert.ToInt64( Convertor.IsNull( drs[0]["yzid"] , "0" ) );
                    yzmc = Convertor.IsNull( drs[0]["yzmc"] , "" );
                    Guid _NewHjmxid = Guid.Empty;
                    int _err_code = 0;
                    string _err_text = "";
                    if ( _cfg3077.Config == "1" )
                        Ufl_cout = 1; //Add by CC
                    mz_hj.SaveCfmx( Guid.Empty.ToString() , NewHjid.ToString() , pym , bm , pm , pm , "" , "" , dj , Ufl_cout , dw , 1 , 1 ,
                        ( dj * Ufl_cout ) , tjdxmdm , xmid , 0 , -1 , Guid.Empty.ToString() , Ufl_cout , yldwmc , 0 , 0 , 0 , "" , 0 , "" , 1 , "" ,
                        0 , 0 , 0 , 0 , 0 , yzid , yzmc , out _NewHjmxid , out _err_code , out _err_text , yblx , "" , _DataBase );
                    if ( ( dj * Ufl_cout ) != cfje )
                        throw new Exception( string.Format( "�����������[{0}]��������,�������Ϊ{1},��Ŀ��ϸ���Ϊ{2}(7015)" ,pm, cfje , ( dj * Ufl_cout ) ) );

                    zxks = exc_dept7016;
                    //NewHjid = Guid.Empty;
                    //mz_hj.SaveCf(Guid.Empty, brxxid, ghxxid, blh, cfrq, hjy, "", ysdm, ksdm, 0, cfje, zxks, 0, 2, 1, jgbm, 1, jzid, out NewHjid, out err_code, out err_text, _DataBase);
                    drs = dt_order.Select( "yzid=" + _cfg7016.Config.Trim() + "" );
                    pym = Convertor.IsNull( drs[0]["ƴ����"] , "" );
                    bm = Convertor.IsNull( drs[0]["����"] , "" );
                    pm = Convertor.IsNull( drs[0]["��Ʒ��"] , "" );
                    dj = Convert.ToDecimal( Convertor.IsNull( drs[0]["����"] , "0" ) );
                    tjdxmdm = Convertor.IsNull( drs[0]["STATITEM_CODE"] , "" );
                    xmid = Convert.ToInt64( Convertor.IsNull( drs[0]["ITEM_ID"] , "0" ) );
                    yldwmc = Convertor.IsNull( drs[0]["������λ"] , "" );
                    yzid = Convert.ToInt64( Convertor.IsNull( drs[0]["yzid"] , "0" ) );
                    yzmc = Convertor.IsNull( drs[0]["yzmc"] , "" );
                                       
                    if ( _cfg3077.Config == "1" )
                        Ufl_cout = 1; //Add by CC
                    cfje = dj * Ufl_cout;

                    _err_code = 0;
                    _err_text = "";
                    NewHjid = Guid.Empty;
                    mz_hj.SaveCf( Guid.Empty , brxxid , ghxxid , blh , cfrq , hjy , "" , ysdm , ksdm , 0 , cfje , zxks , 0 , 2 , 1 , jgbm , 1 , jzid , out NewHjid , out err_code , out err_text , _DataBase );

                    _err_code = 0;
                    _err_text = "";
                    _NewHjmxid = Guid.Empty;
                    mz_hj.SaveCfmx( Guid.Empty.ToString() , NewHjid.ToString() , pym , bm , pm , pm , "" , "" , dj , Ufl_cout , dw , 1 , 1 ,
                        ( dj * Ufl_cout ) , tjdxmdm , xmid , 0 , -1 , Guid.Empty.ToString() , Ufl_cout , yldwmc , 0 , 0 , 0 , "" , 0 , "" , 1 , "" ,
                        0 , 0 , 0 , 0 , 0 , yzid , yzmc , out _NewHjmxid , out _err_code , out _err_text , yblx , "" , _DataBase );
                    if ( ( dj * Ufl_cout ) != cfje )
                        throw new Exception( string.Format( "�����������[{0}]��������,�������Ϊ{1},��Ŀ��ϸ���Ϊ{2}(7016)" , pm , cfje , ( dj * Ufl_cout ) ) );
                }
            }
            catch ( Exception ea )
            {
                throw new Exception( "ts_mzys_class.mzys.SaveYfglCf���÷����쳣����ȷ�ϲ���7015,7016�Ƿ�������ȷ��û������0" , ea );
            }
        }
        //ͨ������id��������ϸid��ҽ����Ŀid��ȡ����ҽ��������Ƿ��м�¼ false �޼�¼ true �м�¼ Add By zp 2014-01-09
        public static bool CheckYjMzsqItem(string hjid, string hjmxid, long yzid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select 1 from YJ_MZSQ WHERE YZID='" + hjid + "' AND YZXMID=" + yzid + "";
                if(!string.IsNullOrEmpty(hjmxid))
                   sql+=" AND HJMXID='"+hjmxid+"'";
                if (Convertor.IsNull(_DataBase.GetDataResult(sql), "") == "1")
                    return true;
                else
                    return false;
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        //ͨ������id��������ϸid��ҽ����Ŀid��ȡ����ҽ��������Ƿ��м�¼ false �޼�¼ true �м�¼ Add By zp 2014-01-09
        public static bool DeleteYjmzsq(string hjid, string hjmxid, long yzid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select yjsqid from YJ_MZSQ WHERE YZID='" + hjid + "' AND YZXMID=" + yzid + "";
                if (!string.IsNullOrEmpty(hjmxid))
                    sql += " AND HJMXID='" + hjmxid + "'";
                string strYjsqid = Convertor.IsNull(_DataBase.GetDataResult(sql), "");
                if (strYjsqid == "") return false;
                else
                {
                    int iReturn = _DataBase.DoCommand("DELETE YJ_MZSQ where yjsqid = '" + strYjsqid + "'");
                    if (iReturn > 0)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        public static void SentYpsqRecord(Guid YPSQID, Guid GHXXID, int GGID, string YPPM, string YPSPM,
            int YPDW, string YPGG, int CFJB, int SQYS, int SQYSJB, string SQSJ, int BSCBZ, int BZT,int SHY,string SHSJ,string bz,
            out Guid NewYpsqid, out int err_code, out string err_text,RelationalDatabase _DataBase)
        {
            ParameterEx[] parameters = new ParameterEx[19];

            parameters[0].Text = "@YPSQID";
            parameters[0].Value = YPSQID;

            parameters[1].Text = "@GHXXID";
            parameters[1].Value = GHXXID;

            parameters[2].Text = "@GGID";
            parameters[2].Value = GGID;

            parameters[3].Text = "@YPPM";
            parameters[3].Value = YPPM;

            parameters[4].Text = "@YPSPM";
            parameters[4].Value = YPSPM;

            parameters[5].Text = "@YPDW";
            parameters[5].Value = YPDW;

            parameters[6].Text = "@YPGG";
            parameters[6].Value = YPGG;

            parameters[7].Text = "@CFJB";
            parameters[7].Value = CFJB;

            parameters[8].Text = "@SQYS";
            parameters[8].Value = SQYS;

            parameters[9].Text = "@SQYSJB";
            parameters[9].Value = SQYSJB;

            parameters[10].Text = "@SQSJ";
            parameters[10].Value = SQSJ;

            parameters[11].Text = "@BSCBZ";
            parameters[11].Value = BSCBZ;

            parameters[12].Text = "@BZT";
            parameters[12].Value = BZT;

            parameters[13].Text = "@SHY";
            parameters[13].Value = SHY;

            parameters[14].Text = "@SHSJ";
            parameters[14].Value = SHSJ;

            parameters[15].Text = "@BZ";
            parameters[15].Value = bz;



            parameters[16].Text = "@NewYpsqid";
            parameters[16].ParaDirection = ParameterDirection.Output;
            parameters[16].DataType = System.Data.DbType.Guid;
            parameters[16].ParaSize = 100;

            parameters[17].Text = "@err_code";
            parameters[17].ParaDirection = ParameterDirection.Output;
            parameters[17].DataType = System.Data.DbType.Int32;
            parameters[17].ParaSize = 100;

            parameters[18].Text = "@err_text";
            parameters[18].ParaDirection = ParameterDirection.Output;
            parameters[18].DataType = System.Data.DbType.String;
            parameters[18].ParaSize = 100;



            _DataBase.DoCommand("SP_MZYS_YPSQ_RECORD", parameters, 30);
            NewYpsqid = new Guid(parameters[16].Value.ToString());
            err_code = Convert.ToInt32(parameters[17].Value);
            err_text = parameters[18].Value.ToString();
        }

        public static int IsYpsq(Guid ghxxid, int sqys, int ggid, RelationalDatabase _DataBase)
        {
            try
            {
                string sql = @"select bzt from MZYS_YPSQ_RECORD WHERE bscbz = 0  and ghxxid='" + ghxxid + "' AND sqys=" + sqys + " and ggid =" + ggid;

                return Convert.ToInt32(Convertor.IsNull(_DataBase.GetDataResult(sql), "-1"));
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }


        public static int getShy(int sqys, int ggid,RelationalDatabase _DataBase) 
        {
            int shy = 0;
            try
            {
                string sql = @"select top 1 shy from MZYS_YPSQ_RECORD where bscbz=0  and sqys ="+sqys+" and ggid ="+ggid +" order by sqsj desc";

                if (Convertor.IsNull(_DataBase.GetDataResult(sql), "-1") != "-1")
                    shy = Convert.ToInt32(_DataBase.GetDataResult(sql));
                else
                {
                    sql = @"select top 1 shy from MZYS_YPSQ_RECORD where bscbz=0  and sqys =" + sqys + "  order by sqsj desc";
                    if (Convertor.IsNull(_DataBase.GetDataResult(sql), "-1") != "-1")
                        shy = Convert.ToInt32(_DataBase.GetDataResult(sql));
                }
                return shy;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// ͨ�����Ż�ȡ������Ϣ
        /// </summary>
        /// <param name="klx"></param>
        /// <param name="kh"></param>
        /// <param name="kye"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static YY_BRXX GetBRXX( int klx , string kh ,out decimal kye, out Guid kdjid, RelationalDatabase database)
        {
            string ssq = " select dbo.fun_zy_age(csrq,3,getdate()) age,dbo.FUN_ZY_SEEKSEXNAME(XB) sexname,xb, b.csrq,a.* from yy_kdjb a left join YY_BRXX  b on a.BRXXID=b.BRXXID where b.BSCBZ=0   and klx={0} and kh='{1}'  and ZFBZ=0 ";
            ssq = string.Format( ssq , klx , kh );
            DataTable tbk = database.GetDataTable( ssq );
            ReadCard readcard = null;
            if ( tbk.Rows.Count != 0 )
                readcard = new ReadCard( new Guid( tbk.Rows[0]["kdjid"].ToString() ) , database );

            if ( tbk.Rows.Count == 0 )
                throw new Exception( "û���ҵ�����Ϣ����ȷ�Ͽ����Ƿ���ȷ��û������" );
            
            if ( tbk.Rows.Count > 1 )            
                throw new Exception( "�ҵ�����ͬʱ��Ч�Ŀ�,���ϵͳ����Ա��ϵ" );
               
            if ( readcard.sdbz == 1 )
                throw new Exception( "���ſ��ѱ�����,��������.���ȼ���" );
               
            if ( readcard.sdbz == 2 )
                throw new Exception( "���ſ��ѱ���ʧ,��������.���ȼ���"  );

            kye = Convert.ToDecimal( Convertor.IsNull( tbk.Rows[0]["kye"] , "0" ) );
            YY_BRXX brxx = new YY_BRXX();
            brxx.Brxxid = new Guid( tbk.Rows[0]["brxxid"].ToString() );
            brxx.Brxm = tbk.Rows[0]["ckrxm"].ToString().Trim();
            brxx.Xb = tbk.Rows[0]["xb"].ToString();
            brxx.Csrq = Convert.ToDateTime( tbk.Rows[0]["csrq"] ).ToString( "yyyy-MM-dd HH:mm:ss" );
            if ( !Convert.IsDBNull( tbk.Rows[0]["kdjid"] ) )
                kdjid = new Guid( tbk.Rows[0]["kdjid"].ToString() );
            else
                kdjid = Guid.Empty;
            return brxx;
        }
        /// <summary>
        /// ��ȡҽ���Һż����б�
        /// </summary>
        /// <param name="employeeId">ҽ������ԱID</param>
        /// <param name="deptId">��ǰҽ�����ڿ���</param>
        /// <param name="database"></param>
        /// <returns></returns>
        /// <remarks>
        /// �÷�������ָ��ҽ���Ŀ�ѡ�ĹҺż����б� ,��Ҫ���ڷǹҺŽ�����йҺŲ���ʱ���ṩҽ������ѡ����      
        /// </remarks>
        public static DataTable GetDoctorRegisterTypeList(int employeeId,int deptId, RelationalDatabase database )
        {
            //����ҽ��վ�Һ��Ƿ����ѡ�񼶱� 0=�� 1=��
            SystemCfg cfg1083 = new SystemCfg( 1083 , database );
            //����ҽ��վ�Ƿ����ü��׻�����Ѽ���Һţ���3052������������£� 
            SystemCfg cfg3100 = new SystemCfg( 3100 , database );

            TrasenFrame.Classes.Doctor doctor = null;
            try
            {
                doctor = new TrasenFrame.Classes.Doctor( employeeId , database );
            }
            catch
            {
                doctor = null;
            }
            DateTime time1 = Convert.ToDateTime( "0:00:00" );
            DateTime time2 = Convert.ToDateTime( DateManager.ServerDateTimeByDBType( database ) );
            TimeSpan TS = new TimeSpan( time2.Ticks - time1.Ticks );
            int Time = (int)TS.TotalHours;
            string pbxx = string.Format( "select * from JC_MZ_YSPB where PBKSID={0} and  ysid={1} and pblx={2} and  pbsj='{3}'" , deptId , employeeId , ( Time <= 12 ? "1" : "2" ) , DateManager.ServerDateTimeByDBType( database ).ToShortDateString() );
            DataTable pbxxtb = database.GetDataTable( pbxx );
            string sql = "select TYPE_ID �Һż���,TYPE_NAME ��������  from JC_DOCTOR_TYPE where 1=1";
            if ( doctor != null )
            {
                if ( pbxxtb.Rows.Count > 0 )
                {
                    //��ǰ��Ա��ҽ���������Ű࣬ȡ�Ű�����Ｖ��
                    string zzjbid = pbxxtb.Rows[0]["ZZJBID"].ToString();
                    //sql += string.Format( " and ((4!={0} and type_id!=4) or 1=1)  and  zcjb {1} (select zcjb  from JC_DOCTOR_TYPE where TYPE_ID={0}) and zcjb in(1,2,3) " , zzjbid , ( cfg1083.Config == "1" ? ">=" : "=" ) );
                    if ( cfg3100.Config == "1" )
                        sql += string.Format( " and ((4!={0} and type_id!=4) or 1=1)  and  zcjb {1} (select zcjb  from JC_DOCTOR_TYPE where TYPE_ID={0}) " , zzjbid , ( cfg1083.Config == "1" ? ">=" : "=" ) );
                    else
                        sql += string.Format( " and ((4!={0} and type_id!=4) or 1=1)  and  zcjb {1} (select zcjb  from JC_DOCTOR_TYPE where TYPE_ID={0}) and zcjb in(1,2,3) " , zzjbid , ( cfg1083.Config == "1" ? ">=" : "=" ) );
                }
                else
                {
                    object zzjb = database.GetDataResult( string.Format( "select type_id from jc_doctor_type where zcjb={0}" , doctor.TypeID ) );
                    if ( cfg3100.Config == "1" )
                        sql = sql + string.Format( " and zcjb {0} (select zcjb  from JC_DOCTOR_TYPE where TYPE_ID={1}) " , ( cfg1083.Config == "1" ? ">=" : "=" ) , zzjb );
                    else
                        sql = sql + string.Format( " and type_id<>4 and  zcjb {0} (select zcjb  from JC_DOCTOR_TYPE where TYPE_ID={1}) and zcjb in(1,2,3) " , ( cfg1083.Config == "1" ? ">=" : "=" ) , zzjb );
                }
            }
            else
            {
                //�����ǰ����Ա����ҽ����ȫ����ѡ��
                if ( cfg3100.Config == "0" )
                    sql = sql + " and type_id<>4 and zcjb in(1,2,3) ";
            }
            return database.GetDataTable( sql );
        }        
        /// <summary>
        /// �����ȡ��ָ����ҽ���Ϳ��ҵĹҺŷ�����Ŀ
        /// </summary>
        /// <param name="kh"></param>
        /// <param name="employeeId"></param>
        /// <param name="deptId"></param>
        /// <param name="jgbm"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static List<ts_mz_class.classes.hjcfmx> CalucateRegFeeItem( string kh , int employeeId , int deptId , int ghjb , long jgbm , RelationalDatabase database )
        {
            int err_code = -1;
            string err_text = "";            
            Department department = new Department( deptId , database );
            //��ùҺŽ����  blb Ĭ��Ϊ��
            DataSet dset = null;
            SystemCfg cfg3089 = new SystemCfg( 3089 ,database );//Add by cc 2014-03-18 �Ƿ���Ժ��ְ����Һŷ��ú����Ʒ��� (ԭ��������Ҫ����3052�����������޿���Ҳ��Ҫ�չҺŷѣ���˸ò���������3052����) 
            int ghlx = ( department.Jz_Flag == 0 ? 1 : 2 );
            if ( cfg3089.Config == "1" && !string.IsNullOrEmpty(kh) ) 
            {
                //������3089������Ҫ�п��Ž����ж�
                string strSql = string.Format( @"SELECT TOP 1 a.YHLXID FROM dbo.JC_KYHLXSZ a INNER JOIN dbo.JC_YHLX b ON a.YHLXID = b.ID INNER JOIN 
                                                    YY_KDJB c ON a.KDJID = c.KDJID 
                                                    WHERE  KH='{0}'
                                                    AND b.YHMC ='Ժ��ְ����ҺŷѺ����Ʒ�'" , kh );
                object objYhlxid = database.GetDataResult( strSql );
                Guid yhlxid = new Guid( Convertor.IsNull( objYhlxid , Guid.Empty.ToString() ) );
                dset = mz_ghxx.mzgh_get_sfmx( ghlx , 0 , 0 , deptId , ghjb , employeeId , "" , 0 , 0 , yhlxid , jgbm , out err_code , out err_text , "" , database );                
            }
            else
            {
                dset = mz_ghxx.mzgh_get_sfmx( ghlx , 0 , 0 , deptId , ghjb , employeeId , "" , 0 , 0 , Guid.Empty , jgbm , out err_code , out err_text , "" , database );
            }

           


            DataTable ghftb = dset.Tables[4];
            List<ts_mz_class.classes.hjcfmx> items = new List<ts_mz_class.classes.hjcfmx>();
            for ( int i = 0 ; i < ghftb.Rows.Count ; i++ )
            {
                ghftb.Rows[i]["je"] = Convert.ToString( Convert.ToDecimal( ghftb.Rows[i]["je"] ) - Convert.ToDecimal( ghftb.Rows[i]["yhje"] ) );
                string strSql = @"select b.order_id,b.order_name,c.item_id,c.item_name,c.statitem_code,c.item_unit
                                from (select hditem_id,hoitem_id,num from jc_hoi_hdi where tc_flag = 0 and hditem_id = {0}) a 
                                inner join (select order_id,order_name from jc_hoitemdiction where delete_bit = 0) b on a.hoitem_id = b.order_id 
                                inner join (select item_id,item_name,retail_price,item_unit,statitem_code from jc_hsitemdiction 
                                            where delete_bit =0 and item_id = {0} and jgbm = {1}) c on a.hditem_id = c.item_id";
                strSql = string.Format( strSql , ghftb.Rows[i]["item_id"] , jgbm );
                DataRow r = database.GetDataRow( strSql );
                if ( r != null )
                {
                    ts_mz_class.classes.hjcfmx cfmx = new ts_mz_class.classes.hjcfmx();
                    cfmx.hjmxid = Guid.Empty;
                    cfmx.tjdxmdm = Convertor.IsNull( r["statitem_code"] , "" );
                    cfmx.xmid = Convert.ToInt64( Convertor.IsNull( r["item_id"] , "0" ) );
                    cfmx.spm = Convertor.IsNull( r["item_name"] , "" );
                    cfmx.pm = cfmx.spm;
                    cfmx.dj = Convert.ToDecimal( Convertor.IsNull( ghftb.Rows[i]["je"] , "0" ) );
                    cfmx.sl = 1;
                    cfmx.je = Convert.ToDecimal( Convertor.IsNull( ghftb.Rows[i]["je"] , "0" ) );
                    cfmx.dw = Convertor.IsNull( r["item_unit"] , "" );
                    cfmx.ydwbl = 1;
                    cfmx.js = 1;
                    cfmx.yl = 1;
                    cfmx.ts = 1;
                    cfmx.pxxh = items.Count + 1;
                    cfmx.yzid = Convert.ToInt64( Convertor.IsNull( r["order_id"] , "0" ) );
                    cfmx.yzmc = Convertor.IsNull( r["order_name"] , "" );
                    items.Add( cfmx );
                }
                else
                    throw new Exception( string.Format( "{0}û�ж�Ӧ��ҽ����Ŀ�����ȶ�Ӧ" , ghftb.Rows[i]["item_name"] ) );
            }
            return items;
        }
        /// <summary>
        /// ������3121ָ�����շ���Ŀ���ɹҺ���ϸ
        /// </summary>       
        /// <param name="jgbm"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static List<ts_mz_class.classes.hjcfmx> CalucateRegFeeItem( int deptId, long jgbm , RelationalDatabase database )
        {

            SystemCfg cfg3121 = new SystemCfg( 3121 , database );//��3120������2ʱҪ��ȡ���õ���Ŀ���
            if ( string.IsNullOrEmpty( cfg3121.Config ) )
                throw new Exception( "û��ָ���޺�ʱ��Ҫ��ȡ�ķ��ã��뽫����3121��ֵ����ΪҪ��ȡ�ķ��õ�ID" );
            string[] strItemIds = cfg3121.Config.Split( ",".ToCharArray() );

            List<ts_mz_class.classes.hjcfmx> items = new List<ts_mz_class.classes.hjcfmx>();
            for ( int i = 0 ; i < strItemIds.Length ; i++ )
            {
                if ( !Convertor.IsInteger( strItemIds[i].Trim() ) )
                    throw new Exception( "����3121���ô������������ָ�ʽ�����ö���(��,��)����" );

                string strSql = @"select b.order_id,b.order_name,c.item_id,c.item_name,c.statitem_code,c.item_unit,c.retail_price
                                from (select hditem_id,hoitem_id,num from jc_hoi_hdi where tc_flag = 0 and hditem_id = {0}) a 
                                inner join (select order_id,order_name from jc_hoitemdiction where delete_bit = 0) b on a.hoitem_id = b.order_id 
                                inner join (select item_id,item_name,retail_price,item_unit,statitem_code from jc_hsitemdiction 
                                            where delete_bit =0 and item_id = {0} and jgbm = {1}) c on a.hditem_id = c.item_id";
                strSql = string.Format( strSql , strItemIds[i] , jgbm );
                DataRow r = database.GetDataRow( strSql );
                if ( r != null )
                {
                    ts_mz_class.classes.hjcfmx cfmx = new ts_mz_class.classes.hjcfmx();
                    cfmx.hjmxid = Guid.Empty;
                    cfmx.tjdxmdm = Convertor.IsNull( r["statitem_code"] , "" );
                    cfmx.xmid = Convert.ToInt64( Convertor.IsNull( r["item_id"] , "0" ) );
                    cfmx.spm = Convertor.IsNull( r["item_name"] , "" );
                    cfmx.pm = cfmx.spm;
                    cfmx.dj = Convert.ToDecimal( Convertor.IsNull( r["retail_price"] , "0" ) );
                    cfmx.sl = 1;
                    cfmx.je = Convert.ToDecimal( Convertor.IsNull( r["retail_price"] , "0" ) );
                    cfmx.dw = Convertor.IsNull( r["item_unit"] , "" );
                    cfmx.ydwbl = 1;
                    cfmx.js = 1;
                    cfmx.yl = 1;
                    cfmx.ts = 1;
                    cfmx.pxxh = items.Count + 1;
                    cfmx.yzid = Convert.ToInt64( Convertor.IsNull( r["order_id"] , "0" ) );
                    cfmx.yzmc = Convertor.IsNull( r["order_name"] , "" );
                    items.Add( cfmx );
                }
                else
                    throw new Exception( string.Format( "��ĿIDΪ{0}����Ŀû�ж�Ӧ��ҽ����Ŀ�����ȶ�Ӧ" , strItemIds[i] ) );
            }

            //��3119=1 3120=2ʱ����ȡ�κη��õĿ��ұ�Ŷ������ʹ��,�ָ�
            SystemCfg cfg3135 = new SystemCfg( 3135 , database );
            SystemCfg cfg3120 = new SystemCfg( 3120 , database );
            if ( cfg3120.Config == "2" )
            {
                int index = cfg3135.Config.IndexOf( deptId.ToString() );  //������õĲ��շѿ����а�����ǰ���ң��������
                if ( index != -1 )
                    items.Clear();
            }

            return items;
        }        
        /// <summary>
        /// �����޺ŹҺ�����
        /// </summary>
        /// <param name="brxx">������Ϣ</param>
        /// <param name="ghxx">�Һ���Ϣ</param>
        /// <param name="items">�Һŷ�����Ŀ</param>
        /// <param name="jgbm">��������</param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool SaveNoneRegisterData( ts_mz_class.YY_BRXX brxx , mz_ghxx ghxx , List<ts_mz_class.classes.hjcfmx> items , long jgbm , RelationalDatabase database )
        {
            Guid _NewBrxxId = Guid.Empty;
            Guid _NewGhxxId = Guid.Empty;
            int err_code = 0;
            string err_text = "";
            decimal cfje = 0;
            items.ForEach( delegate( ts_mz_class.classes.hjcfmx mx )
            {
                cfje = cfje + mx.je;
            } );
            string djsj = DateManager.ServerDateTimeByDBType( database ).ToString( "yyyy-MM-dd HH:mm:ss" );
            try
            {
                database.BeginTransaction();
                //1�����没�˻�����Ϣ,һ�����޿����޺�ʱ��Ҫ����������Ϣ���п����˿���ֱ�ӻ�ȡ��������Ϣ
                if ( brxx.Brxxid == Guid.Empty )
                {

                    ts_mz_class.YY_BRXX.BrxxDj( Guid.Empty , brxx.Brxm , brxx.Xb , brxx.Csrq , brxx.Hyzk , brxx.Gj , brxx.Mz , brxx.Zy , brxx.Csdz , brxx.Jtdz ,
                        brxx.Jtyb , brxx.Jtdh , brxx.Jtlxr , brxx.Brlxfs , brxx.Dzyj , brxx.Gzdw , brxx.Gzdwdh , brxx.Gzdwyb , brxx.Gzdwdh , brxx.Gzdwlxr , brxx.Sfzh ,
                        brxx.Brlx , brxx.Yblx , brxx.Cbkh , brxx.Djy , brxx.Djly , out _NewBrxxId , out err_code , out err_text , database );
                    if ( _NewBrxxId == Guid.Empty || err_code != 0 )
                        throw new Exception( err_text );
                }
                else
                {
                    _NewBrxxId = brxx.Brxxid;
                }
                //2����ȡһ���µ������
                string mzh = Fun.GetNewMzh( database );
                int pdxh = 0;
                //3���Һ���Ϣ����
                mz_ghxx.GhxxDj( Guid.Empty , _NewBrxxId , ghxx.ghlx , ghxx.kdjid , mzh , ghxx.ghks , ghxx.ghys , ghxx.ghjb , cfje , ghxx.ghys , ghxx.yhbz , "" ,
                    ref pdxh , 0L , "" , jgbm , out _NewGhxxId , out err_code , out err_text , 0 , 0 , 0 , "" , "" , "" , 0 , "" , "" , djsj , database );
                if ( _NewGhxxId == Guid.Empty || err_code != 0 )
                    throw new Exception( err_text );
                //4������
                Guid jzid = Guid.Empty;
                mzys_jzjl.Mzysjz( jgbm , _NewGhxxId , ghxx.ghys , ghxx.ghks , djsj , "" , out jzid , out err_code , out err_text , 1 , database );
                if ( err_code == -1 || jzid == Guid.Empty )
                    throw new Exception( err_text );

                string ssql = string.Format( "update mzhs_fzjl set bjzbz=3,jzys={0},jzsj='{1}' where ghxxid='{2}' and bscbz=0" , ghxx.ghys , djsj , _NewGhxxId );
                database.DoCommand( ssql );
                database.DoCommand( string.Format( "update jc_zjsz set zjzt=2 where zjid='{0}'" , ghxx.zsid ) );
                //5�����ɹҺŷ�����ϸ  
                if ( items.Count > 0 && cfje>0)
                {
                    ts_mz_class.classes.hjcf cf = new ts_mz_class.classes.hjcf();
                    #region cfͷ��ֵ
                    cf.hjid = Guid.Empty;
                    cf.brxxid = _NewBrxxId;
                    cf.ghxxid = _NewGhxxId;
                    cf.blh = mzh;
                    cf.cfrq = djsj;
                    cf.hjy = ghxx.ghys;
                    cf.ysdm = ghxx.ghys;
                    cf.ksdm = ghxx.ghks;
                    cf.zyksdm = 99999;  //�������𴦷��Ƿ�ҺŷѵĴ���
                    cf.zxks = ghxx.ghks;
                    cf.cfje = cfje;
                    cf.xmly = 2;
                    cf.cfjs = 1;
                    cf.jgbm = jgbm;
                    cf.byscf = 1;
                    cf.jzid = jzid;
                    #endregion
                    mz_hj.SaveCf( cf , database );
                    if ( cf.NewHjid == Guid.Empty )
                        throw new Exception( cf.err_text );
                    //������ϸ
                    foreach ( ts_mz_class.classes.hjcfmx mx in items )
                    {                        
                        mx.hjid = cf.NewHjid;
                        mz_hj.SaveCfmx( mx , database );
                        if ( mx.NewHjmxid == Guid.Empty )
                            throw new Exception( mx.err_text );
                    }
                }

                database.CommitTransaction();
                if ( brxx.Brxxid == Guid.Empty )
                    brxx.Brxxid = _NewBrxxId;
                ghxx.ghxxid = _NewGhxxId;
                return true;
            }
            catch ( Exception error )
            {
                database.RollbackTransaction();
                throw error;
            }
        }
        /// <summary>
        /// �����޺ŹҺ�����
        /// </summary>
        /// <param name="klx">������</param>
        /// <param name="kh">����</param>
        /// <param name="ghxx">�Һ���Ϣ</param>
        /// <param name="items">�Һŷ�����Ŀ</param>
        /// <param name="jgbm">��������</param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool SaveNoneRegisterData( int klx , string kh , mz_ghxx ghxx , List<ts_mz_class.classes.hjcfmx> items , long jgbm , RelationalDatabase database )
        {
            
            decimal kye = 0;
            Guid kdjid = Guid.Empty;
            YY_BRXX brxx = mzys.GetBRXX( klx , kh , out kye , out kdjid, database );
            ghxx.kdjid = kdjid;
            return SaveNoneRegisterData( brxx , ghxx , items , jgbm , database );
        }

        
    }
}
