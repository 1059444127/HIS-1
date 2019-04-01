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

namespace ts_mz_class
{
    public class mz_cf
    {

        /// <summary>
        /// ���洦��ͷ
        /// </summary>
        /// <param name="cfid">����ID</param>
        /// <param name="brxxid">������ϢID</param>
        /// <param name="ghxxid">�Һ���ϢID</param>
        /// <param name="blh">������</param>
        /// <param name="sfck">�շѴ���</param>
        /// <param name="zje">�ܽ��</param>
        /// <param name="hjrq">��������</param>
        /// <param name="hjy">����Ա</param>
        /// <param name="hjyxm">����Ա����</param>
        /// <param name="hjck">���۴���</param>
        /// <param name="hjid">���۴�����ID</param>
        /// <param name="ksdm">����</param>
        /// <param name="ksmc">��������</param>
        /// <param name="ysdm">ҽ��</param>
        /// <param name="ysxm">ҽ������</param>
        /// <param name="zyksdm">����סԺ����</param>
        /// <param name="zxks">ִ�п���</param>
        /// <param name="zxksmc">ִ�п�������</param>
        /// <param name="bghpbz">�Һ�Ʊ��־</param>
        /// <param name="tcid">�ײ�ID</param>
        /// <param name="xmly">��Ŀ��Դ</param>
        /// <param name="djy">��������</param>
        /// <param name="NewCfid">�����´���ID ֻ�� cfid=0 ʱ��ֵ</param>
        /// <param name="err_code">���ش���� 0 ����</param>
        /// <param name="err_text">���ش����ļ�</param>
        public static void SaveCf(Guid cfid, Guid brxxid, Guid ghxxid, string blh, string sfck, decimal zje, string hjrq, int hjy, string hjyxm, string hjck, Guid hjid, int ksdm, string ksmc, int ysdm, string ysxm, int zyksdm, int zxks, string zxksmc, int bghpbz, long tcid, int xmly, int bscbz, int cfjs, long jgbm, out Guid NewCfid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[27];

                parameters[0].Text = "@cfid";
                parameters[0].Value = cfid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@sfck";
                parameters[4].Value = sfck;

                parameters[5].Text = "@zje";
                parameters[5].Value = zje;

                parameters[6].Text = "@hjrq";
                parameters[6].Value = hjrq;

                parameters[7].Text = "@hjy";
                parameters[7].Value = hjy;

                parameters[8].Text = "@hjyxm";
                parameters[8].Value = hjyxm;

                parameters[9].Text = "@hjck";
                parameters[9].Value = hjck;

                parameters[10].Text = "@hjid";
                parameters[10].Value = hjid;

                parameters[11].Text = "@ksdm";
                parameters[11].Value = ksdm;

                parameters[12].Text = "@ksmc";
                parameters[12].Value = ksmc;

                parameters[13].Text = "@ysdm";
                parameters[13].Value = ysdm;

                parameters[14].Text = "@ysxm";
                parameters[14].Value = ysxm;

                parameters[15].Text = "@zyksdm";
                parameters[15].Value = zyksdm;

                parameters[16].Text = "@zxks";
                parameters[16].Value = zxks;

                parameters[17].Text = "@zxksmc";
                parameters[17].Value = zxksmc;

                parameters[18].Text = "@bghpbz";
                parameters[18].Value = bghpbz;

                parameters[19].Text = "@tcid";
                parameters[19].Value = tcid;

                parameters[20].Text = "@xmly";
                parameters[20].Value = xmly;

                parameters[21].Text = "@cfjs";
                parameters[21].Value = cfjs;

                parameters[22].Text = "@bscbz";
                parameters[22].Value = bscbz;

                parameters[23].Text = "@jgbm";
                parameters[23].Value = jgbm;


                parameters[24].Text = "@NewCfid";
                parameters[24].ParaDirection = ParameterDirection.Output;
                parameters[24].DataType = System.Data.DbType.Guid;
                parameters[24].ParaSize = 100;

                parameters[25].Text = "@err_code";
                parameters[25].ParaDirection = ParameterDirection.Output;
                parameters[25].DataType = System.Data.DbType.Int32;
                parameters[25].ParaSize = 100;

                parameters[26].Text = "@err_text";
                parameters[26].ParaDirection = ParameterDirection.Output;
                parameters[26].ParaSize = 100;


                _DataBase.DoCommand("SP_MZSF_CF", parameters, 30);
                NewCfid = new Guid(parameters[24].Value.ToString());
                err_code = Convert.ToInt32(parameters[25].Value);
                err_text = Convert.ToString(parameters[26].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }

        /// <summary>
        /// ���洦����ϸ
        /// </summary>
        /// <param name="cfmxid">������ϸID</param>
        /// <param name="cfid">����ͷID</param>
        /// <param name="pym">ƴ����</param>
        /// <param name="bm">����</param>
        /// <param name="pm">Ʒ��</param>
        /// <param name="spm">��Ʒ��</param>
        /// <param name="gg">���</param>
        /// <param name="cj">����</param>
        /// <param name="dj">����</param>
        /// <param name="sl">����</param>
        /// <param name="dw">��λ</param>
        /// <param name="ydwbl">ԭ��λ����</param>
        /// <param name="js">����</param>
        /// <param name="je">���</param>
        /// <param name="tjdxmdm">ͳ�ƴ���Ŀ����</param>
        /// <param name="xmid">��ĿID</param>
        /// <param name="hjmxid">������ϸID</param>
        /// <param name="gjbm">���ұ���</param>
        /// <param name="bpsyybz">Ƥ����ҩ��־</param>
        /// <param name="bpsbz">Ƥ�Ա�־</param>
        /// <param name="bmsbz">��ѱ�־</param>
        /// <param name="syff">ʹ�÷���</param>
        /// <param name="zt">����</param>
        /// <param name="fzxh">�������</param>
        /// <param name="pxxh">�Ŷ����</param>
        /// <param name="tyid">��ԭID</param>
        /// <param name="pxxh">������</param>
        /// <param name="tyid">�������</param>
        /// <param name="NewCfmxid">�����µĴ�����ϸID ֻ�е�cfmxid=0 ʱ����ֵ</param>
        /// <param name="err_code">���ش���� 0 Ϊ����</param>
        /// <param name="err_text">���ش����ļ�</param>
        public static void SaveCfmx(Guid cfmxid, Guid cfid, string pym, string bm, string pm, string spm, string gg, string cj, decimal dj, decimal sl, string dw, int ydwbl, int js, decimal je, string tjdxmdm, long xmid, Guid hjmxid, string gjbm, int bzby, int bpsbz, Guid pshjmxid, decimal yl, string yldw, string yfmc, int pcid, decimal ts, string zt, int fzxh, int pxxh, Guid tyid, decimal pfj, decimal pfje, int tcid, out Guid NewCfmxid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[36];

                parameters[0].Text = "@cfmxid";
                parameters[0].Value = cfmxid;

                parameters[1].Text = "@cfid";
                parameters[1].Value = cfid;

                parameters[2].Text = "@pym";
                parameters[2].Value = pym;

                parameters[3].Text = "@bm";
                parameters[3].Value = bm;

                parameters[4].Text = "@pm";
                parameters[4].Value = pm;

                parameters[5].Text = "@spm";
                parameters[5].Value = spm;

                parameters[6].Text = "@gg";
                parameters[6].Value = gg;

                parameters[7].Text = "@cj";
                parameters[7].Value = cj;

                parameters[8].Text = "@dj";
                parameters[8].Value = dj;

                parameters[9].Text = "@sl";
                parameters[9].Value = sl;

                parameters[10].Text = "@dw";
                parameters[10].Value = dw;

                parameters[11].Text = "@ydwbl";
                parameters[11].Value = ydwbl;

                parameters[12].Text = "@js";
                parameters[12].Value = js;

                parameters[13].Text = "@je";
                parameters[13].Value = je;

                parameters[14].Text = "@tjdxmdm";
                parameters[14].Value = tjdxmdm;

                parameters[15].Text = "@xmid";
                parameters[15].Value = xmid;

                parameters[16].Text = "@hjmxid";
                parameters[16].Value = hjmxid;

                parameters[17].Text = "@gjbm";
                parameters[17].Value = gjbm;

                parameters[18].Text = "@bzby";
                parameters[18].Value = bzby;

                parameters[19].Text = "@bpsbz";
                parameters[19].Value = bpsbz;

                parameters[20].Text = "@pshjmxid";
                parameters[20].Value = pshjmxid;

                parameters[21].Text = "@yl";
                parameters[21].Value = yl;

                parameters[22].Text = "@yldw";
                parameters[22].Value = yldw;

                parameters[23].Text = "@yfmc";
                parameters[23].Value = yfmc;

                parameters[24].Text = "@pcid";
                parameters[24].Value = pcid;

                parameters[25].Text = "@ts";
                parameters[25].Value = ts;

                parameters[26].Text = "@zt";
                parameters[26].Value = zt;

                parameters[27].Text = "@fzxh";
                parameters[27].Value = fzxh;

                parameters[28].Text = "@pxxh";
                parameters[28].Value = pxxh;

                parameters[29].Text = "@tyid";
                parameters[29].Value = tyid;

                parameters[30].Text = "@pfj";
                parameters[30].Value = pfj;

                parameters[31].Text = "@pfje";
                parameters[31].Value = pfje;

                parameters[32].Text = "@tcid";
                parameters[32].Value = tcid;

                parameters[33].Text = "@NewCfmxid";
                parameters[33].ParaDirection = ParameterDirection.Output;
                parameters[33].DataType = System.Data.DbType.Guid;
                parameters[33].ParaSize = 100;

                parameters[34].Text = "@err_code";
                parameters[34].ParaDirection = ParameterDirection.Output;
                parameters[34].DataType = System.Data.DbType.Int32;
                parameters[34].ParaSize = 100;

                parameters[35].Text = "@err_text";
                parameters[35].ParaDirection = ParameterDirection.Output;
                parameters[35].ParaSize = 100; 

                _DataBase.DoCommand("SP_MZSF_CFMX", parameters, 30);
                NewCfmxid = new Guid(parameters[33].Value.ToString());
                err_code = Convert.ToInt32(parameters[34].Value);
                err_text = Convert.ToString(parameters[35].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }  
        }
        //���洦����ϸ Add by zp 2013-12-13  NewCfmxid���ⲿ������� ����ҽ������ 
        public static void SaveCfmx(Guid cfmxid, Guid cfid, string pym, string bm, string pm, string spm, string gg, string cj, decimal dj, decimal sl, string dw, int ydwbl, int js, decimal je, string tjdxmdm, long xmid, Guid hjmxid, string gjbm, int bzby, int bpsbz, Guid pshjmxid, decimal yl, string yldw, string yfmc, int pcid, decimal ts, string zt, int fzxh, int pxxh, Guid tyid, decimal pfj, decimal pfje, int tcid, ref Guid NewCfmxid, out int err_code, out string err_text,bool IsAdd, RelationalDatabase _DataBase)
        {
            try
            {
                err_code = -1;
               
                Guid yhjmxid=hjmxid;
                Guid ytyid = tyid; 
                decimal ysl = 0;
                int yjs = 0;
                decimal ytsl = 0;
                int ytjs = 0;
                decimal ktsl = 0;
                int ktjs = 0;
                int qrbz = 0;
                int tfbz = 0;
                string sql = "";
               
                #region ��ҩ
                if (tyid != Guid.Empty) //��ҩ
                {
                    NewCfmxid = Guid.Empty;
                    sql = @"select (sl*js) ysl,js yjs,bqrbz bqrbz,qrsj,qrks,qrdjy,btfbz 
                    from mz_cfb_mx where cfmxid='" + tyid + @"' and bscbz=0  ";
                    DataTable dt_ty = _DataBase.GetDataTable(sql);
                    if (dt_ty.Rows.Count == 0)
                    {
                        err_text = "������ת�Ƶ���ʷ��,���ܰ����˷�,����ѯ����Ա��";
                        return;
                    }
                    qrbz = Convert.ToInt32(dt_ty.Rows[0]["bqrbz"]);
                    tfbz = Convert.ToInt32(dt_ty.Rows[0]["btfbz"]);
                    ysl = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ysl"], "0"));
                    yjs = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["js"], "0"));

                    if (tjdxmdm != "01" && tjdxmdm != "02" && tjdxmdm != "03")
                    {
                        if (qrbz == 1 && tfbz == 0 && (new SystemCfg(3013, _DataBase)).Config.Trim() == "1")
                        {
                            err_text = "�÷����ѱ�����ȷ��,�辭����ͬ��ſ��˷ѣ�";
                            return;
                        }
                    }
                    //--�������� ���˼���  
                    sql = @"select coalesce(sum(sl*js),0) ytsl,coalesce(sum(js),0) ytjs  
                            from mz_cfb_mx where tyid='" + tyid + "' and bscbz=0 ";
                    dt_ty = _DataBase.GetDataTable(sql);
                    ytsl = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ytsl"], "0"));
                    ytjs = Convert.ToInt32(Convertor.IsNull(dt_ty.Rows[0]["ytjs"], "0"));
                    ktsl = ysl + ytsl;//��������  
                    ktjs = yjs + ytjs;//���˼��� 
                    if ((ktsl + sl) < 0)
                    {
                        //cast(cast(coalesce(@ysl,0) as float) as varchar(20))+@dw
                        //cast(cast(coalesce(@ytsl,0) as float) as varchar(20))+@dw
                        //cast(cast(coalesce(@ktsl,0) as float) as varchar(20))+@dw
                        //cast((@ysl*@yjs) as varchar(30))
                        //cast((@ytsl*@ytjs) as varchar(30))
                        //cast((@ktsl*@ktjs) as varchar(30))
                        err_text = "���������벻��ȷ�� [" + pm + "] ԭ����Ϊ" + Convert.ToDecimal(ysl).ToString() + dw + @",
                         ����" + Convert.ToDecimal(ytsl).ToString() + dw + @",����" + Convert.ToDecimal(ktsl).ToString() + dw + @" 
                         ԭ����" + (ysl * yjs).ToString() + @" ��������" + (ytsl * ytjs).ToString() + @" 
                         ��������" + (ktsl * ktjs).ToString() + "";
                        return;
                    }
                    if (ktjs + (-1) * js < 0 && tjdxmdm == "03")
                    {
                        //cast(cast(coalesce(@yjs,0) as float) as varchar(20))
                        //cast(cast(coalesce(@ytjs,0) as float) as varchar(20))
                        //cast(cast(coalesce(@ktjs,0) as float) as varchar(20))
                        err_text = "'�˼������벻��ȷ��[" + pm + "]   ԭ����Ϊ " + Convert.ToDecimal(yjs).ToString() + "'��,  ���� " + Convert.ToDecimal(ytjs).ToString() + @"��, 
                        ���� " + Convert.ToDecimal(ktjs).ToString() + "��";
                        return;
                    }
                    if ((ktjs + (-1) * js) < 0 && tjdxmdm != "03")
                    {
                        if (tcid > 0)
                        {
                            //cast(cast(coalesce(@yjs,0) as float) as varchar(20))
                            //cast(cast(coalesce(@ytjs,0) as float) as varchar(20))
                            //cast(cast(coalesce(@ktjs,0) as float) as varchar(20))+'
                             err_text = "���ײʹ������벻��ȷ��ԭ�ײ���Ϊ" + Convert.ToDecimal(yjs) + @"��,
                             ����" + Convert.ToDecimal(ytjs) + "��, ����" + Convert.ToDecimal(ktjs).ToString() + "��";
                             return;
                        }
                    }

                }
                #endregion
                if (IsAdd) //NewCfmxid���ⲿ�������
                {
                    int bqrbz = 0;
                    object qrsj = DBNull.Value;
                    int qrks = 0;
                    int qrdjy = 0;
                    if (tjdxmdm != "01" && tjdxmdm != "02" && tjdxmdm != "03" && ytyid == Guid.Empty && yhjmxid != Guid.Empty)
                    {
                        sql = @"select bsdbz,sdsj,sdks,sddjy from mz_hjb_mx where hjmxid='" + hjmxid + "'";
                        DataTable dt = _DataBase.GetDataTable(sql);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //if (NewCfmxid == Guid.Empty) NewCfmxid = new Guid();
                            bqrbz = Convert.ToInt32(Convertor.IsNull(dt.Rows[0]["bsdbz"], "0"));
                            if (dt.Rows[0]["sdsj"] != null)
                                qrsj = dt.Rows[0]["sdsj"].ToString();
                            qrks = int.Parse(Convertor.IsNull(dt.Rows[0]["sdks"], "0"));
                            qrdjy = int.Parse(Convertor.IsNull(dt.Rows[0]["sddjy"], "0"));
                        }
                    }
                    sql = @" insert into mz_cfb_mx(cfmxid,cfid,pym,bm,pm,spm,gg,cj,dj,sl,dw,ydwbl,js,je,tjdxmdm,xmid,hjmxid,  
                               gjbm,bzby,bpsbz,pshjmxid,YL,YLDW,YFMC,PCID,TS,zt,fzxh,pxxh,tyid,pfj,pfje,TCID,bqrbz,qrsj,qrks,qrdjy)  
                             values('" + NewCfmxid + "','" + cfid + "','" + pym + "','" + bm + "','" + pm + "','" + spm + "','" + gg + "','" + cj + "','" + dj + "','" + sl + "','" + dw + @"',
                             " + ydwbl + "," + js + ",round(" + je + ",2),'" + tjdxmdm + "'," + xmid + ",'" + hjmxid + "','" + gjbm + "','" + bzby + "','" + bpsbz + "','" + pshjmxid + @"',
                             " + yl + ",'" + yldw + "','" + yfmc + "','" + pcid + "'," + ts + ",'" + zt + "','" + fzxh + "'," + pxxh + ",'" + tyid + @"',
                             " + pfj + "," + pfje + "," + tcid + "," + bqrbz + ",'" + qrsj + "'," + qrks + "," + qrdjy + ")  ";
                    _DataBase.DoCommand(sql);
                }
                else
                {
                    sql = @"update mz_cfb_mx set cfid='"+cfid+"',pym='"+pym+"',bm='"+bm+"',pm='"+pm+"',spm='"+spm+@"',
                    gg='"+gg+"',cj='"+cj+"',dj="+dj+",sl="+sl+",dw='"+dw+"',ydwbl='"+ydwbl+"',js="+js+",je="+je+",tjdxmdm='"+tjdxmdm+@"',
                    xmid="+xmid+",hjmxid='"+hjmxid+"',gjbm='"+gjbm+"',bzby="+bzby+",bpsbz="+bpsbz+@",
                    pshjmxid='"+pshjmxid+"',YL="+yl+",YLDW='"+yldw+"',YFMC='"+yfmc+"',PCID="+pcid+@",  
                    TS="+ts+",zt='"+zt+"',fzxh="+fzxh+",pxxh="+pxxh+",tyid='"+tyid+"',pfj="+pfj+",pfje="+pfje+@",
                    TCID="+tcid+" where cfmxid='"+cfmxid+"'";
                    _DataBase.DoCommand(sql);
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
            err_code = 0;
            err_text = "���洦����ϸ��ɹ�";
        }


        /// <summary>
        /// ������ҩ��Ϣ���´����������Ϣ  ������CFID 
        /// </summary>
        /// <param name="cfid">����ID</param>
        /// <param name="yfdm">ҩ������</param>
        /// <param name="fyrq">��ҩ����</param>
        /// <param name="fyr">��ҩ��</param>
        /// <param name="fyck">��ҩ����</param>
        /// <param name="pyr">��ҩ��</param>
        /// <param name="pyck">��ҩ����</param>
        /// <param name="Nrows">��������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        public static void UpdateCfFyzt(Guid cfid, int yfdm, string yfmc, string fyrq, int fyr, string fyck, int pyr, string pyck, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bfybz=1,zxks=" + yfdm + ",zxksmc='" + yfmc + "',fyrq='" + fyrq + "',fyr=" + fyr + ",fyrxm='" + Fun.SeekEmpName(fyr, _DataBase) + "',fyck='" + fyck + "',pyr=" + pyr + ",pyrxm='" + Fun.SeekEmpName(pyr, _DataBase) + "',pyck='" + pyck + "' where cfid='" + cfid + "' and bfybz=0 ";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "���³ɹ�";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        /// <summary>
        /// ����CFID���´�������շ�״̬  �˷�ʱ��
        /// </summary>
        /// <param name="cfid">����ID�ַ��� ��ʽΪ(1,2,3)</param>
        /// <param name="sky">�շ�Ա</param>
        /// <param name="skyxm">�շ�Ա����</param>
        /// <param name="skrq">�շ�����</param>
        /// <param name="sfck">�շѴ���</param>
        /// <param name="dnlsh">������ˮ��</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="Fpid">��ƱID</param>
        /// <param name="Nrows">Ӱ�������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        public static void UpdateCfsfzt(string cfid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, Guid Fpid, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bsfbz=1,sfy=" + sky + ",sfyxm='" + skyxm + "',sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "' where cfid in " + cfid + " and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "���³ɹ�";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static void UpdateCfsfzt(Guid cfid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set fph='" + fph + "',bsfbz=1,sfy=" + sky + ", sfyxm='" + skyxm + "',sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + " where cfid = '" + cfid + "' and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "���³ɹ�";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }


        /// <summary>
        /// ���� HJID���շѱ�־ ���´�������շ�״̬   �շ�ʱ��
        /// </summary>
        /// <param name="cfid">����ID�ַ��� ��ʽΪ(1,2,3)</param>
        /// <param name="sky">�շ�Ա</param>
        /// <param name="skyxm">�շ�Ա����</param>
        /// <param name="skrq">�շ�����</param>
        /// <param name="sfck">�շѴ���</param>
        /// <param name="dnlsh">������ˮ��</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="Fpid">��ƱID</param>
        /// <param name="Nrows">Ӱ�������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        public static void  UpdateCfsfzt_E(string hjid, int sky, string skyxm, string skrq, string sfck, long dnlsh, string fph, Guid Fpid, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set bsfbz=1,sfy=" + sky + ",sfyxm='" + Fun.SeekEmpName(sky, _DataBase) + "', sfrq='" + skrq + "',sfck='" + sfck + "',dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "' where hjid in " + hjid + " and bsfbz=0";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
      
        /// <summary>
        ///  ����ԭ��ƱID ��ԭ��������Ϊ���շ�Ʊ�ķ�Ʊ��Ϣ�����д���ͷ�ĳɵ�ǰ��Ʊ�š���ƱID ����������Ϣ����  �˷�ʱ��
        /// </summary>
        /// <param name="hjid">����id</param>
        /// <param name="dnlsh">������ˮ��</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="Fpid">�·�ƱID</param>
        /// <param name="YFpid">ԭ��ƱID</param>
        /// <param name="Nrows">Ӱ�������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        public static void UpdateCfsfzt_Old_New(string hjid, long dnlsh, string fph, Guid Fpid, string Yfph, out int Nrows, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "update mz_cfb set dnlsh=" + dnlsh + ",fph='" + fph + "',fpid='" + Fpid + "',bscbz=0 where hjid in " + hjid + " and  fph='" + Yfph + "' and bscbz<>1";
                Nrows = _DataBase.DoCommand(ssql);
                err_code = 0;
                err_text = "";

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        //��ѯ�Ƿ��չ�����
        public static DataTable SelectCardFee(Guid ghxxid, string fph, long sfxmid, RelationalDatabase _DataBase)
        {
            string ssql = "select XMID from mz_cfb a,mz_cfb_mx b where a.cfid=b.cfid and a.ghxxid='" + ghxxid + "' and fph='" + fph + "' and bsfbz=1 and xmid=" + sfxmid + " and ghxxid='" + ghxxid + "'";
            return _DataBase.GetDataTable(ssql);
        }
        //�˹Һ�Ʊ
        public static void Tghp(Guid ghxxid, string fph, string sfck, string sdate, Guid NewFpid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            string ssql = "select * from mz_cfb a   where ghxxid='" + ghxxid + "' and a.fph='" + fph + "' and bghpbz=1  ";
            DataTable tbcf = _DataBase.GetDataTable(ssql);
            if (tbcf.Rows.Count > 1)
            {
                err_code = -1;
                err_text = "�ҵ����д�����Ϣ,��͹���Ա��ϵ";
                return;
            }
            if (tbcf.Rows.Count == 0)
            {
                err_code = -1;
                err_text = "û���ҵ�������Ϣ,���ݿ�����ת��";
                return;
            }

            Guid Newcfid = Guid.Empty;
            mz_cf.SaveCf(Guid.Empty, new Guid(tbcf.Rows[0]["brxxid"].ToString()), new Guid(tbcf.Rows[0]["ghxxid"].ToString()), Convertor.IsNull(tbcf.Rows[0]["blh"], ""), sfck,
                Convert.ToDecimal(tbcf.Rows[0]["zje"]) * (-1), sdate, TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId,
                TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, Convertor.IsNull(tbcf.Rows[0]["hjck"], ""), Guid.Empty, Convert.ToInt32(tbcf.Rows[0]["ksdm"]),
                Convertor.IsNull(tbcf.Rows[0]["ksmc"], ""), Convert.ToInt32(tbcf.Rows[0]["ysdm"]), Convertor.IsNull(tbcf.Rows[0]["ysxm"], ""),
                Convert.ToInt32(tbcf.Rows[0]["zyksdm"]), Convert.ToInt32(tbcf.Rows[0]["zxks"]), Convertor.IsNull(tbcf.Rows[0]["zxksmc"], ""),
                Convert.ToInt16(tbcf.Rows[0]["bghpbz"]), 0, Convert.ToInt32(tbcf.Rows[0]["xmly"]), 0,
                Convert.ToInt32(tbcf.Rows[0]["cfjs"]), TrasenFrame.Forms.FrmMdiMain.Jgbm, out Newcfid, out err_code, out err_text, _DataBase);
            if (Newcfid == Guid.Empty || err_code != 0) throw new Exception(err_text);

            Guid NewCfmxid = Guid.Empty;
            ssql = "select * from mz_cfb_mx(nolock) where cfid='" + new Guid(tbcf.Rows[0]["cfid"].ToString()) + "' and bscbz=0 ";
            DataTable tbmx = _DataBase.GetDataTable(ssql);
            if (tbmx.Rows.Count == 0) throw new Exception("û���ҵ��ô�������ϸ");
            for (int i = 0; i <= tbmx.Rows.Count - 1; i++)
            {
                mz_cf.SaveCfmx(Guid.Empty, Newcfid, Convertor.IsNull(tbmx.Rows[i]["pym"], ""), Convertor.IsNull(tbmx.Rows[i]["bm"], ""),
                    Convertor.IsNull(tbmx.Rows[i]["pm"], ""), Convertor.IsNull(tbmx.Rows[i]["spm"], ""), Convertor.IsNull(tbmx.Rows[i]["gg"], ""),
                    Convertor.IsNull(tbmx.Rows[i]["cj"], ""), Convert.ToDecimal(tbmx.Rows[i]["dj"]), Convert.ToDecimal(tbmx.Rows[i]["sl"]) * (-1),
                    Convertor.IsNull(tbmx.Rows[i]["dw"], ""), Convert.ToInt32(tbmx.Rows[i]["ydwbl"]), Convert.ToInt32(tbmx.Rows[i]["js"]), Convert.ToDecimal(tbmx.Rows[i]["je"]) * (-1),
                    Convertor.IsNull(tbmx.Rows[i]["tjdxmdm"], ""), Convert.ToInt64(tbmx.Rows[i]["xmid"]), new Guid(Convertor.IsNull(tbmx.Rows[i]["hjmxid"], Guid.Empty.ToString())),
                    Convertor.IsNull(tbmx.Rows[i]["gjbm"], ""), Convert.ToInt32(tbmx.Rows[i]["bzby"]), Convert.ToInt16(tbmx.Rows[i]["bpsbz"]), new Guid(Convertor.IsNull(tbmx.Rows[i]["pshjmxid"], Guid.Empty.ToString())),
                    Convert.ToDecimal(tbmx.Rows[i]["yl"]) * (-1), Convertor.IsNull(tbmx.Rows[i]["yldw"], ""), "", 0, 1, "", 0, 0, new Guid(tbmx.Rows[i]["cfmxid"].ToString()),
                    Convert.ToDecimal(tbmx.Rows[i]["pfj"]), Convert.ToDecimal(tbmx.Rows[i]["pfje"]) * (-1), 0, out NewCfmxid, out err_code, out err_text, _DataBase);
                if (NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
            }

            //�����շ�״̬
            int Nrows = 0;
            mz_cf.UpdateCfsfzt("('" + Newcfid.ToString() + "')", Convert.ToInt32(TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId.ToString()), TrasenFrame.Forms.FrmMdiMain.CurrentUser.Name, sdate, sfck, 0, fph, NewFpid, out Nrows, out err_code, out err_text, _DataBase);
            if (Nrows != 1) throw new Exception("�ڸ����˷Ѵ������շ�״̬ʱ,û�и��µ�����ͷ��,��͹���Ա��ϵ");

        }
       
        /// <summary>
        /// �޸Ĵ�����ע
        /// </summary>
        /// <param name="hjid"></param>
        /// <param name="_DataBase"></param>
        public static void UpdateCfZyBz(string hjid, string BZ, RelationalDatabase _DataBase)
        {
            string ssql = "update mz_hjb set BZ='" + BZ + "' where hjid='" + hjid + "' and BSCBZ=0 and BSFBZ=0";
            _DataBase.DoCommand(ssql);
        }


        public static DataRow GetCfxx(string hjid, RelationalDatabase _DataBase)
        {
            string sql = "select * from mz_hjb where hjid='" + hjid + "' and BSCBZ=0";
            return _DataBase.GetDataRow(sql);
        }
    }
}
