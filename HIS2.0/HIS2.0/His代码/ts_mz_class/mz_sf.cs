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
    public class mz_sf
    {
        /// <summary>
        /// ��õ�ǰҪ�շѴ����������Ϣ
        /// 1>��Ʊ��¼
        /// 2>��Ʊ��Ŀ������ϸ
        /// 3>��Ʊ��ӡ����
        /// 4>ͳ�ƴ���Ŀ����
        /// </summary>
        /// <param name="hjid">hjid����</param>
        /// <param name="yblx">ҽ������</param>
        /// <param name="ybzf">ҽ��֧��</param>
        /// <param name="tfbz">�˷ѱ�־ 0 �շ� 1����</param>
        /// <param name="fpid">����ƱID</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        /// <param name="err_text">����״ֵ̬</param>
        /// <returns></returns>
        public static DataSet GetFpResult(string hjid, int yblx, decimal ybzf, int tfbz, Guid fpid, Guid yhlxid, long jgbm, out int err_code, out string err_text, int tszt, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[10];

                parameters[0].Text = "@hjid";
                parameters[0].Value = hjid;

                parameters[1].Text = "@yblx";
                parameters[1].Value = yblx;

                parameters[2].Text = "@ybzf";
                parameters[2].Value = ybzf;

                parameters[3].Text = "@tfbz";
                parameters[3].Value = tfbz;

                parameters[4].Text = "@fpid";
                parameters[4].Value = fpid;

                parameters[5].Text = "@yhlxid";
                parameters[5].Value = yhlxid;

                parameters[6].Text = "@jgbm";
                parameters[6].Value = jgbm;

                parameters[7].Text = "@err_code";
                parameters[7].ParaDirection = ParameterDirection.Output;
                parameters[7].DataType = System.Data.DbType.Int32;
                parameters[7].ParaSize = 100;

                parameters[8].Text = "@err_text";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].ParaSize = 100;

                parameters[9].Text = "@tszt";
                parameters[9].Value = tszt;

                DataSet dset = new DataSet();
                _DataBase.AdapterFillDataSet("SP_MZSF_GetFpResult", parameters, dset, "sfmx", 30);

                err_code = Convert.ToInt32(parameters[7].Value);
                err_text = Convert.ToString(parameters[8].Value);
                return dset;
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        /// <param name="fph"></param>
        /// <param name="zje"></param>
        /// <param name="ybzhzf"></param>
        /// <param name="ybjjzf"></param>
        /// <param name="ybbzzf"></param>
        /// <param name="ybzhzf"></param>
        /// <param name="ybjjzf"></param>
        /// <param name="ybbzzf"></param>
        /// <param name="ybzhzf"></param>
        /// <param name="ybjjzf"></param>
        /// <param name="ybbzzf"></param>
        /// <param name="yhje">ID</param>
        /// <param name="srje"></param>
        /// <param name="jsid">����ID</param>
        /// <param name="bghpbz">�Һ�Ʊ��־</param>
        /// <param name="yhje"></param>
        /// <param name="srje">ҽ��id</param>
        /// <param name="jsid">סԺ����id</param>
        /// <param name="bghpbz">ִ�п���</param>
        /// <param name="bghpbz">��������</param>
        /// <param name="NewFpid">�·�ƱID</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        /// <summary>
        /// ���淢Ʊ
        /// </summary>
        /// <param name="fpid">��ƱID ��Guid.Empty</param>
        /// <param name="brxxid">������ϢID</param>
        /// <param name="ghxxid">�Һ���ϢID</param>
        /// <param name="blh">������</param>
        /// <param name="brxm">��������</param>
        /// <param name="sfrq">�շ�����</param>
        /// <param name="sfy">�շ�Ա</param>
        /// <param name="sfck"></param>
        /// <param name="dnlsh">������ˮ��</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="zje">�ܽ��</param>
        /// <param name="ybzhzf">ҽ���˻�֧��</param>
        /// <param name="ybjjzf">ҽ������֧��</param>
        /// <param name="ybbzzf">ҽ������֧��</param>
        /// <param name="ylkzf">������֧��</param>
        /// <param name="yhje">�Żݽ��</param>
        /// <param name="cwjz">�������</param>
        /// <param name="qfgz">Ƿ�Ѽ���</param>
        /// <param name="xjzf">�ֽ�֧��</param>
        /// <param name="zpzf"></param>
        /// <param name="srje">������</param>
        /// <param name="zffpid">���Ϸ�ƱID</param>
        /// <param name="zfyy">����ԭ��</param>
        /// <param name="jsid">����ID</param>
        /// <param name="bghpbz">�Һ�Ʊ��־</param>
        /// <param name="ksdm">����ID</param>
        /// <param name="ysdm">ҽ��ID</param>
        /// <param name="zyksdm"></param>
        /// <param name="zxks"></param>
        /// <param name="yblx"></param>
        /// <param name="ybjydjh"></param>
        /// <param name="jlzt"></param>
        /// <param name="kdjid"></param>
        /// <param name="jgbm"></param>
        /// <param name="yhlxid"></param>
        /// <param name="yhlxmc"></param>
        /// <param name="NewFpid"></param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="_DataBase"></param>
        public static void SaveFp(Guid fpid, Guid brxxid, Guid ghxxid, string blh, string brxm, string sfrq, int sfy, string sfck, long dnlsh, string fph, decimal zje, decimal ybzhzf, decimal ybjjzf, decimal ybbzzf, decimal ylkzf, decimal yhje, decimal cwjz, decimal qfgz, decimal xjzf, decimal zpzf, decimal srje, Guid zffpid, string zfyy, Guid jsid, int bghpbz, int ksdm, int ysdm, int zyksdm, int zxks, int yblx, string ybjydjh, int jlzt, Guid kdjid, long jgbm, Guid yhlxid, string yhlxmc, out Guid NewFpid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[39];

                parameters[0].Text = "@fpid";
                parameters[0].Value = fpid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;


                parameters[3].Text = "@blh";
                parameters[3].Value = blh;

                parameters[4].Text = "@brxm";
                parameters[4].Value = brxm;

                parameters[5].Text = "@sfrq";
                parameters[5].Value = sfrq;

                parameters[6].Text = "@sfy";
                parameters[6].Value = sfy;

                parameters[7].Text = "@sfck";
                parameters[7].Value = sfck;

                parameters[8].Text = "@dnlsh";
                parameters[8].Value = dnlsh;

                parameters[9].Text = "@fph";
                parameters[9].Value = fph;

                parameters[10].Text = "@zje";
                parameters[10].Value = zje;

                parameters[11].Text = "@ybzhzf";
                parameters[11].Value = ybzhzf;

                parameters[12].Text = "@ybjjzf";
                parameters[12].Value = ybjjzf;

                parameters[13].Text = "@ybbzzf";
                parameters[13].Value = ybbzzf;

                parameters[14].Text = "@ylkzf";
                parameters[14].Value = ylkzf;

                parameters[15].Text = "@yhje";
                parameters[15].Value = yhje;

                parameters[16].Text = "@cwjz";
                parameters[16].Value = cwjz;

                parameters[17].Text = "@qfgz";
                parameters[17].Value = qfgz;

                parameters[18].Text = "@xjzf";
                parameters[18].Value = xjzf;

                parameters[19].Text = "@srje";
                parameters[19].Value = srje;

                parameters[20].Text = "@zffpid";
                parameters[20].Value = zffpid;

                parameters[21].Text = "@zfyy";
                parameters[21].Value = zfyy;

                parameters[22].Text = "@jsid";
                parameters[22].Value = jsid;

                parameters[23].Text = "@bghpbz";
                parameters[23].Value = bghpbz;

                parameters[24].Text = "@ksdm";
                parameters[24].Value = ksdm;

                parameters[25].Text = "@ysdm";
                parameters[25].Value = ysdm;

                parameters[26].Text = "@zyksdm";
                parameters[26].Value = zyksdm;

                parameters[27].Text = "@zxks";
                parameters[27].Value = zxks;

                parameters[28].Text = "@yblx";
                parameters[28].Value = yblx;

                parameters[29].Text = "@ybjydjh";
                parameters[29].Value = ybjydjh;

                parameters[30].Text = "@jlzt";
                parameters[30].Value = jlzt;

                parameters[31].Text = "@kdjid";
                parameters[31].Value = kdjid;

                parameters[32].Text = "@jgbm";
                parameters[32].Value = jgbm;

                parameters[33].Text = "@yhlxid";
                parameters[33].Value = yhlxid;

                parameters[34].Text = "@yhlxmc";
                parameters[34].Value = yhlxmc;

                parameters[35].Text = "@NewFpid";
                parameters[35].ParaDirection = ParameterDirection.Output;
                parameters[35].DataType = System.Data.DbType.Guid;
                parameters[35].ParaSize = 100;

                parameters[36].Text = "@err_code";
                parameters[36].ParaDirection = ParameterDirection.Output;
                parameters[36].DataType = System.Data.DbType.Int32;
                parameters[36].ParaSize = 100;

                parameters[37].Text = "@err_text";
                parameters[37].ParaDirection = ParameterDirection.Output;
                parameters[37].ParaSize = 100;

                parameters[38].Text = "@zpzf";
                parameters[38].Value = zpzf;


                _DataBase.DoCommand("SP_MZSF_saveFP", parameters, 30);
                NewFpid = new Guid(parameters[35].Value.ToString());
                err_code = Convert.ToInt32(parameters[36].Value);
                err_text = Convert.ToString(parameters[37].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }
        /// <summary>
        /// ���淢Ʊ��Ŀ��ϸ
        /// </summary>
        /// <param name="fpid">��ƱID</param>
        /// <param name="xmdm">��Ŀ����</param>
        /// <param name="xmmc">��Ŀ����</param>
        /// <param name="je">���</param>
        /// <param name="srje">������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ļ�</param>
        public static void SaveFpmx(Guid fpid, string xmdm, string xmmc, decimal je, decimal srje, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@fpid";
                parameters[0].Value = fpid;

                parameters[1].Text = "@xmdm";
                parameters[1].Value = xmdm;


                parameters[2].Text = "@xmmc";
                parameters[2].Value = xmmc;

                parameters[3].Text = "@je";
                parameters[3].Value = je;

                parameters[4].Text = "@srje";
                parameters[4].Value = srje;


                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                DataSet dset = new DataSet();
                _DataBase.DoCommand("SP_MZSF_saveFPmx", parameters, 30);
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }

        /// <summary>
        /// ���淢Ʊͳ�ƴ���Ŀ��ϸ
        /// </summary>
        /// <param name="jsid">��ƱID</param>
        /// <param name="xmdm">��Ŀ����</param>
        /// <param name="xmmc">��Ŀ����</param>
        /// <param name="je">���</param>
        /// <param name="srje">������</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ļ�</param>
        public static void SaveFpdxmmx(Guid fpid, string xmdm, string xmmc, decimal je, decimal srje, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@fpid";
                parameters[0].Value = fpid;

                parameters[1].Text = "@xmdm";
                parameters[1].Value = xmdm;


                parameters[2].Text = "@xmmc";
                parameters[2].Value = xmmc;

                parameters[3].Text = "@je";
                parameters[3].Value = je;

                parameters[4].Text = "@srje";
                parameters[4].Value = srje;


                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                DataSet dset = new DataSet();
                _DataBase.DoCommand("SP_MZSF_saveFpdxmmx", parameters, 30);
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }

        }
        /// <summary>
        ///  ��������¼
        /// </summary>
        /// <param name="jsid">����ID</param>
        /// <param name="brxxid">������ϢID</param>
        /// <param name="ghxxid">���˹Һ�ID</param>
        /// <param name="sfrq">�շ�����</param>
        /// <param name="sfy">�շ�Ա</param>
        /// <param name="zje">�ܽ��</param>
        /// <param name="ybzhzf">ҽ���ʻ�֧��</param>
        /// <param name="ybjjzf">ҽ������֧��</param>
        /// <param name="ybbzzf">ҽ���ʻ�֧��</param>
        /// <param name="ylkzf">������֧��</param>
        /// <param name="yhje">�Żݽ��</param>
        /// <param name="cwjz">�������</param>
        /// <param name="qfgz">Ƿ�ѹ���</param>
        /// <param name="xjzf">�ֽ�֧��</param>
        /// <param name="zpzf">֧Ʊ֧��</param>
        /// <param name="srje">������</param>
        /// <param name="skje">�տ���</param>
        /// <param name="zlje">������</param>
        /// <param name="fpzs">��Ʊ����</param>
        /// <param name="zfzs">��������</param>
        /// <param name="jgbm">��������</param>
        /// <param name="NewJsid">�½���ID</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        /// <param name="_DataBase">���ݿ�����</param>
        public static void SaveJs(Guid jsid, Guid brxxid, Guid ghxxid, string sfrq, int sfy, decimal zje, decimal ybzhzf, decimal ybjjzf, decimal ybbzzf, decimal ylkzf, decimal yhje, decimal cwjz, decimal qfgz, decimal xjzf, decimal zpzf, decimal srje, decimal skje, decimal zlje, int fpzs, int zfzs, long jgbm, out Guid NewJsid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[25];

                parameters[0].Text = "@jsid";
                parameters[0].Value = jsid;

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;

                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;

                parameters[3].Text = "@sfrq";
                parameters[3].Value = sfrq;

                parameters[4].Text = "@sfy";
                parameters[4].Value = sfy;

                parameters[5].Text = "@zje";
                parameters[5].Value = zje;

                parameters[6].Text = "@ybzhzf";
                parameters[6].Value = ybzhzf;

                parameters[7].Text = "@ybjjzf";
                parameters[7].Value = ybjjzf;

                parameters[8].Text = "@ybbzzf";
                parameters[8].Value = ybbzzf;

                parameters[9].Text = "@ylkzf";
                parameters[9].Value = ylkzf;

                parameters[10].Text = "@yhje";
                parameters[10].Value = yhje;

                parameters[11].Text = "@cwjz";
                parameters[11].Value = cwjz;

                parameters[12].Text = "@qfgz";
                parameters[12].Value = qfgz;

                parameters[13].Text = "@xjzf";
                parameters[13].Value = xjzf;

                parameters[14].Text = "@srje";
                parameters[14].Value = srje;

                parameters[15].Text = "@skje";
                parameters[15].Value = skje;

                parameters[16].Text = "@zlje";
                parameters[16].Value = zlje;

                parameters[17].Text = "@fpzs";
                parameters[17].Value = fpzs;

                parameters[18].Text = "@jgbm";
                parameters[18].Value = jgbm;

                parameters[19].Text = "@wkdz";
                parameters[19].Value = PubStaticFun.GetMacAddress();

                parameters[20].Text = "@NewJsid";
                parameters[20].ParaDirection = ParameterDirection.Output;
                parameters[20].DataType = System.Data.DbType.Guid;
                parameters[20].ParaSize = 100;

                parameters[21].Text = "@err_code";
                parameters[21].ParaDirection = ParameterDirection.Output;
                parameters[21].DataType = System.Data.DbType.Int32;
                parameters[21].ParaSize = 100;

                parameters[22].Text = "@err_text";
                parameters[22].ParaDirection = ParameterDirection.Output;
                parameters[22].ParaSize = 100;

                parameters[23].Text = "@zpzf";
                parameters[23].Value = zpzf;

                parameters[24].Text = "@zfzs";
                parameters[24].Value = zfzs;

                _DataBase.DoCommand("SP_MZSF_saveJS", parameters, 30);
                NewJsid = new Guid(parameters[20].Value.ToString());
                err_code = Convert.ToInt32(parameters[21].Value);
                err_text = Convert.ToString(parameters[22].Value);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }



        }


        public static void UpdateFpjlzt(Guid fpid, out int Nrows, RelationalDatabase _DataBase)
        {
            string ssql = "update mz_fpb set jlzt=1 where fpid='" + fpid + "' and jlzt=0";
            Nrows = _DataBase.DoCommand(ssql);
            if (Nrows == 0)
            {
                ssql = "update mz_fpb_h set jlzt=1 where fpid='" + fpid + "' and jlzt=0";
                Nrows = _DataBase.DoCommand(ssql);
            }
        }
        /// <summary>
        /// ���·�Ʊ��ǰ���� 
        /// </summary>
        /// <param name="fpid">��Ʊ����ID</param>
        /// <param name="kshm">���ο�ʼ����</param>
        /// <param name="jshm">���ν�������</param>
        public static void UpdateDqfph(Guid fpid, string kshm, string jshm, out string err_text, RelationalDatabase _DataBase)
        {
            err_text = "";
            long dqfph = Convert.ToInt64(jshm) + 1;
            //string ssql = "update MZ_FPLYB set dqhm=left('00000000000000'," + (jshm.Length - dqfph.ToString().Length) + ") +'" + dqfph.ToString() + "' where dqhm='" + kshm + "' and (cast(jshm as bigint)>='" + dqfph.ToString() + "' or jshm='" + jshm + "') and bwcbz=0 and fplyid='" + fpid + "'";
            //int i = _DataBase.DoCommand(ssql);
            //if (i == 0) throw new Exception("���·�Ʊ��ʱ��������,û�и��µ���");


            //ssql = "update MZ_FPLYB set bwcbz=1 where jshm='" + jshm + "' and  fplyid='" + fpid + "'";
            //i = _DataBase.DoCommand(ssql);
            //if (i == 1) err_text = "��ǰ��Ʊ���Ѿ�����,��������һ����Ʊ��";

            //chencan 
            string ssql = "update MZ_FPLYB set dqhm=left('00000000000000'," + (jshm.Length - dqfph.ToString().Length) + ") +'" + dqfph.ToString() + "' where dqhm='" + kshm + "' and cast(jshm as bigint)>=" + dqfph.ToString() + " and bwcbz=0 and fplyid='" + fpid + "'";
            int i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                ssql = "update MZ_FPLYB set bwcbz=1 where fplyid='" + fpid + "'";
                i = _DataBase.DoCommand(ssql);
                if (i == 1) err_text = "��ǰ��Ʊ���Ѿ�����,��������һ����Ʊ��";
            }
        }
        ///// <summary>
        ///// ���·�Ʊ��ӡ��Ϣ
        ///// </summary>
        ///// <param name="fpid"></param>
        ///// <param name="fph"></param>
        ///// <param name="qz"></param>
        ///// <param name="dyy"></param>
        ///// <param name="dysj"></param>
        ///// <param name="err_text"></param>
        //public static void UpdateFpdyxx(Guid fpid, string fph, string qz, int dyy, string dysj, out string err_text, RelationalDatabase _DataBase)
        //{
        //    err_text = "";
        //    string ssql = "update mz_fpb set fph='" + fph + "' ,fpdyy=" + dyy + ",fpdysj='" + dysj + "' where fpid='" + fpid.ToString() + "' and fph in ('0','') "; //Modify By Zj 2013-03-20 ����СƱ�����ж� СƱΪ��.
        //    int i = _DataBase.DoCommand(ssql);
        //    if (i == 0)
        //    {
        //        ssql = "update mz_fpb_h set fph='" + fph + "' ,fpdyy=" + dyy + ",fpdysj='" + dysj + "' where fpid='" + fpid.ToString() + "' and  fph in ('0','') ";
        //        i = _DataBase.DoCommand(ssql);
        //    }
        //    if (i == 0)
        //        throw new Exception("���·�Ʊ��ʱ��������,û�и��µ���");

        //    ssql = "select ghxxid,bghpbz from vi_mz_fpb where fpid='" + fpid + "'";
        //    DataRow dr = _DataBase.GetDataRow(ssql);
        //    int ghpbz = Convert.ToInt32(dr["bghpbz"]);
        //    Guid ghxxid = new Guid(dr["ghxxid"].ToString());

        //    if (ghpbz == 1)
        //    {
        //        //����mz_ghxx��fph
        //        ssql = "update mz_ghxx set fph='" + fph + "' where ghxxid='" + ghxxid.ToString() + "' and fph='0'";
        //        i = _DataBase.DoCommand(ssql);
        //        if (i == 0)
        //        {
        //            ssql = "update mz_ghxx_h set fph='" + fph + "' where ghxxid='" + ghxxid.ToString() + "' and fph='0'";
        //            i = _DataBase.DoCommand(ssql);
        //        }
        //        if (i == 0)
        //            throw new Exception("���·�Ʊ�ŵ��Һ���Ϣʱ��������,û�и��µ���");
        //    }
        //    //����mz_cfb��fph
        //    ssql = "update mz_cfb set fph='" + fph + "' where fpid='" + fpid + "' and fph in ('0','') ";
        //    i = _DataBase.DoCommand(ssql);
        //    if (i == 0)
        //    {
        //        ssql = "update mz_cfb_h set fph='" + fph + "' where fpid='" + fpid + "' and fph in ('0','') ";
        //        i = _DataBase.DoCommand(ssql);
        //    }
        //    if (i == 0)
        //        throw new Exception("���·�Ʊ�ŵ�������Ϣʱ��������,û�и��µ���");

        //    ssql = "update yf_fy set fph='" + fph + "' where cfxh in(select cfid from vi_mz_cfb where fpid='" + fpid + "')";
        //    i = _DataBase.DoCommand(ssql);


        //    ssql = "update yf_fymx set fph='" + fph + "' where cfxh in(select cfid from mz_cfb where fpid='" + fpid + "')";//Add By Zj 2013-03-11
        //    i = _DataBase.DoCommand(ssql);

        //}
        /// <summary>
        /// ���·�Ʊ��ӡ��Ϣ
        /// </summary>
        /// <param name="fpid"></param>
        /// <param name="fph"></param>
        /// <param name="qz"></param>
        /// <param name="dyy"></param>
        /// <param name="dysj"></param>
        /// <param name="err_text"></param>
        public static void UpdateFpdyxx(Guid fpid, string fph, string qz, int dyy, string dysj, out string err_text, RelationalDatabase _DataBase)
        {
            err_text = "";
            string ssql = "update mz_fpb set fph='" + fph + "' ,fpdyy=" + dyy + ",fpdysj='" + dysj + "' where fpid='" + fpid.ToString() + "' and fph in ('0','') "; //Modify By Zj 2013-03-20 ����СƱ�����ж� СƱΪ��.
            int i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                ssql = "update mz_fpb_h set fph='" + fph + "' ,fpdyy=" + dyy + ",fpdysj='" + dysj + "' where fpid='" + fpid.ToString() + "' and  fph in ('0','') ";
                i = _DataBase.DoCommand(ssql);
                if (i == 0)
                    throw new Exception("���·�Ʊ�ŵ���Ʊ��Ϣʱ��������,û�и��µ���");
            }

            ssql = "select ghxxid,bghpbz from vi_mz_fpb where fpid='" + fpid + "'";
            DataRow dr = _DataBase.GetDataRow(ssql);
            int ghpbz = Convert.ToInt32(dr["bghpbz"]);
            Guid ghxxid = new Guid(dr["ghxxid"].ToString());

            if (ghpbz == 1)// �Һ�Ʊ��־Ϊ1ʱ�Ÿ��¹Һ���Ϣ��
            {
                //����mz_ghxx��fph
                ssql = "update mz_ghxx set fph='" + fph + "' where ghxxid='" + ghxxid.ToString() + "' and fph in ('0','')";// ����fphΪ�յ��ж� by fangke 2014.11.6
                i = _DataBase.DoCommand(ssql);
                if (i == 0)
                {
                    ssql = "update mz_ghxx_h set fph='" + fph + "' where ghxxid='" + ghxxid.ToString() + "' and fph in ('0','')";
                    i = _DataBase.DoCommand(ssql);
                    if (i == 0)
                        throw new Exception("���·�Ʊ�ŵ��Һ���Ϣʱ��������,û�и��µ���");
                }
            }

            //����mz_cfb��fph
            ssql = "update mz_cfb set fph='" + fph + "' where fpid='" + fpid + "' and fph in ('0','') ";
            i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                ssql = "update mz_cfb_h set fph='" + fph + "' where fpid='" + fpid + "' and fph in ('0','') ";
                i = _DataBase.DoCommand(ssql);
                if (i == 0)
                    throw new Exception("���·�Ʊ�ŵ�������Ϣʱ��������,û�и��µ���");
            }

            ssql = "update yf_fy set fph='" + fph + "' where cfxh in(select cfid from mz_cfb where fpid='" + fpid + "')";
            i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                // add by fangke 2014.11.6
                ssql = "update yf_fy_h set fph='" + fph + "' where cfxh in(select cfid from mz_cfb where fpid='" + fpid + "')";
                i = _DataBase.DoCommand(ssql);
            }

            ssql = "update yf_fymx set fph='" + fph + "' where cfxh in(select cfid from mz_cfb where fpid='" + fpid + "')";//Add By Zj 2013-03-11
            i = _DataBase.DoCommand(ssql);
            if (i == 0)
            {
                // add by fangke 2014.11.6
                ssql = "update yf_fymx_h set fph='" + fph + "' where cfxh in(select cfid from mz_cfb where fpid='" + fpid + "')";
                i = _DataBase.DoCommand(ssql);
            }
        }

        /// <summary>
        /// ��ȡδ�շѵĴ���
        /// </summary>
        /// <param name="ghxxid">�Һ���Ϣ�ɣ�</param>
        /// <param name="tcid">�ײ�ID����ѯ��ϸ��</param>
        /// <returns></returns>
        public static DataTable Select_Wsfcf(int execdept, Guid brxxid, Guid ghxxid, int tcid, decimal tccs, Guid hjid, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[7];

                parameters[0].Text = "@execdept";
                parameters[0].Value = execdept;//0

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;//00000000-0000-0000-0000-000000000000


                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;//cc3e593e-1a83-4586-b5db-a2b100d81fb7

                parameters[3].Text = "@tcid";
                parameters[3].Value = tcid;//0

                parameters[4].Text = "@tccs";
                parameters[4].Value = tccs;//0

                parameters[5].Text = "@hjid";
                parameters[5].Value = hjid;//00000000-0000-0000-0000-000000000000

                parameters[6].Text = "@jgbm";
                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;//1000

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_SelectWsfcf", parameters, 30);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// ��ȡδ�շѵĴ���
        /// </summary>
        /// <param name="ghxxid">�Һ���Ϣ�ɣ�</param>
        /// <param name="tcid">�ײ�ID����ѯ��ϸ��</param>
        /// <returns></returns>
        public static DataTable Select_Wsfcf(int execdept, Guid brxxid, Guid ghxxid, int tcid, decimal tccs, Guid hjid, int flag, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];

                parameters[0].Text = "@execdept";
                parameters[0].Value = execdept;//0

                parameters[1].Text = "@brxxid";
                parameters[1].Value = brxxid;//00000000-0000-0000-0000-000000000000


                parameters[2].Text = "@ghxxid";
                parameters[2].Value = ghxxid;//cc3e593e-1a83-4586-b5db-a2b100d81fb7

                parameters[3].Text = "@tcid";
                parameters[3].Value = tcid;//0

                parameters[4].Text = "@tccs";
                parameters[4].Value = tccs;//0

                parameters[5].Text = "@hjid";
                parameters[5].Value = hjid;//00000000-0000-0000-0000-000000000000

                parameters[6].Text = "@jgbm";
                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;//1000

                parameters[7].Text = "@flag";
                parameters[7].Value = flag;

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_SelectWsfcf_lx", parameters, 30);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// ����˷Ѵ���
        /// </summary>
        /// <param name="ghxxid">�Һ���ϢID</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="err_code">�����</param>
        /// <param name="err_text">�����ı�</param>
        /// <returns></returns>
        public static DataTable Select_tf(long dnlsh, Guid ghxxid, string fph, int tcid, int tccs, Guid hjid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;//bf6c4b09-d412-43cf-8a68-a2bf00adf3ed

                parameters[1].Text = "@fph";
                parameters[1].Value = fph;//''

                parameters[2].Text = "@tcid";
                parameters[2].Value = tcid; //0

                parameters[3].Text = "@tccs";
                parameters[3].Value = tccs;//0

                parameters[4].Text = "@hjid";
                parameters[4].Value = hjid; //00000000-0000-0000-0000-000000000000

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@dnlsh";
                parameters[7].Value = dnlsh;//1401261518666

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_SelectTf", parameters, 30);
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// �����Ч�ķ�Ʊ��¼
        /// </summary>
        /// <param name="ghxxid">�Һ���Ϣid</param>
        /// <param name="fph">��Ʊ��</param>
        /// <returns></returns>
        public static DataTable SelectFp(Guid ghxxid, long dnlsh, string fph, int bghpbz, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "select *,0 as bk from mz_fpb where ghxxid='" + ghxxid + "' and jlzt=0  and bghpbz=" + bghpbz + " ";
                if (!string.IsNullOrEmpty(fph.Trim()))
                    ssql = ssql + " and fph='" + fph + "'";
                if (dnlsh > 0)
                    ssql = ssql + " and dnlsh=" + dnlsh + "";

                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "select *,1 as bk from mz_fpb_h where ghxxid='" + ghxxid + "' and jlzt=0   and bghpbz=" + bghpbz + " ";
                    if (!string.IsNullOrEmpty(fph.Trim()))
                        ssql = ssql + " and fph='" + fph + "'";
                    if (dnlsh > 0)
                        ssql = ssql + " and dnlsh=" + dnlsh + "";
                    tb = _DataBase.GetDataTable(ssql);
                }
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        public static DataTable SelectFp(Guid ghxxid, Guid fpid, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "select * from mz_fpb where ghxxid='" + ghxxid + "' and fpid='" + fpid.ToString() + "' and jlzt=0";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "select * from mz_fpb_h where ghxxid='" + ghxxid + "' and fpid='" + fpid.ToString() + "' and jlzt=0";
                    tb = _DataBase.GetDataTable(ssql);
                }
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        public static DataTable SelectFp_mx(Guid fpid, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "select * from mz_fpb_mx where fpid='" + fpid + "'";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "select * from mz_fpb_mx_h where fpid='" + fpid + "'";
                    tb = _DataBase.GetDataTable(ssql);
                }
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }
        public static DataTable SelectFp_dxmmx(Guid fpid, RelationalDatabase _DataBase)
        {
            try
            {
                string ssql = "select * from mz_fpb_dxmmx where fpid='" + fpid + "'";
                DataTable tb = _DataBase.GetDataTable(ssql);
                if (tb.Rows.Count == 0)
                {
                    ssql = "select * from mz_fpb_dxmmx_h where fpid='" + fpid + "'";
                    tb = _DataBase.GetDataTable(ssql);
                }
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }


        public static void UpdateYF_fy(decimal zje, string old_fph, string new_fph, long old_dnlsh, long new_dnlsh, string skrq, int sky, Guid patid, RelationalDatabase _DataBase)
        {
            //Add By Zj 2012-11-08 ����8013Ϊ1��ʱ�������ˮ��Ϊ0.000000
            //SystemCfg cfg8013 = new SystemCfg(8013);
            //if (cfg8013.Config == "1")
            //    old_dnlsh = 0;
            string ssql = "update yf_fy set tfbz=0,tfqrbz=1,skrq='" + skrq + "',sky=" + sky + " where fph='" + old_fph + "' and jssjh=" + old_dnlsh + " and patid='" + patid + "' and tfbz=1";
            int x = _DataBase.DoCommand(ssql);
            if (x == 0)
            {
                ssql = "update yf_fy_h set tfbz=0,tfqrbz=1,skrq='" + skrq + "',sky=" + sky + " where fph='" + old_fph + "'  and jssjh=" + old_dnlsh + " and patid='" + patid + "' and tfbz=1";
                x = _DataBase.DoCommand(ssql);
            }

            if (zje > 0)
            {
                ssql = "update yf_fymx  set fph='" + new_fph + "' where fyid in(select id from yf_fy(nolock) where fph='" + old_fph + "'  and jssjh=" + old_dnlsh + " and patid='" + patid + "')";
                int xx = _DataBase.DoCommand(ssql);
                //if (xx < 2) throw new Exception("���·�Ʊ�Ÿ��µ���ҩ��ʱ����,��ˢ������");

                ssql = "update yf_fy set fph='" + new_fph + "',jssjh=" + new_dnlsh + " where fph='" + old_fph + "'  and jssjh=" + old_dnlsh + " and patid='" + patid + "'";
                xx = _DataBase.DoCommand(ssql);
                // if (xx < 2) throw new Exception("���·�Ʊ�Ÿ��µ���ҩ��ʱ����,��ˢ������");
            }
        }

        /// <summary>
        /// ��ȡɣ��ҽ���Ľ���ID
        /// </summary>
        /// <returns></returns>
        public static string GetSDYbjssjh(RelationalDatabase _DataBase)
        {
            //ҽ������ŵ����ΪҽԺ����+������+��λ��ˮ��
            string ybjssjh = Fun.GetNewYbh(_DataBase);
            string iniFile = Application.StartupPath + "\\InsureConfig.ini";
            string HospCode = PrintClass.PrintClass.GetIniString("�ϲ���·ҽ��", "ҽ�ƻ���ID", iniFile);

            ybjssjh = HospCode + ybjssjh;

            return ybjssjh;
        }

        /// <summary>
        /// ����ҩƷ����Ŀ��ҽ�����(�ϲ�ҽ����)
        /// </summary>
        /// <param name="hisItemId">ҽԺҩƷ(cjid)����Ŀ(itemId)�ı��</param>
        /// <param name="itemType">0-ҩƷ��1����Ŀ</param>
        /// <returns></returns>
        public static string GetInsurMediItemCode(long hisItemId, int itemType, RelationalDatabase _DataBase)
        {
            string sql = "";
            if (itemType == 0)
            {
                sql = "select insureid from pub_adapt where type = 1 and hisid='" + hisItemId + "'";
            }
            else
            {
                sql = "select insureid from pub_adapt where type = 0 and  hisid='" + hisItemId + "'";
            }
            object objId = _DataBase.GetDataResult(sql);
            if (objId == null)
                return "";
            else
                return Convert.IsDBNull(objId) ? "" : objId.ToString();
        }

        //���·�ҩ����
        public static void UpdateFyck(Guid brxxid, Guid fpid, out string fyck, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@brxxid";
                parameters[0].Value = brxxid;

                parameters[1].Text = "@fpid";
                parameters[1].Value = fpid;

                parameters[2].Text = "@fyck";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                _DataBase.DoCommand("sp_yf_MZSF_FYCK", parameters, 30);

                fyck = Convertor.IsNull(parameters[2].Value, "");


            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

        /// <summary>
        /// ҽ���˷���ϸ
        /// </summary>
        /// <param name="hjid"></param>
        /// <param name="ybjklx"></param>
        /// <param name="jgbm"></param>
        /// <returns></returns>
        public static DataTable Select_tf_YB(string hjid, int ybjklx, long jgbm, int all, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[4];
                parameters[0].Text = "@hjid";
                parameters[0].Value = hjid;

                parameters[1].Text = "@ybjklx";
                parameters[1].Value = ybjklx;

                parameters[2].Text = "@jgbm";
                parameters[2].Value = jgbm;

                parameters[3].Text = "@all";
                parameters[3].Value = all;


                DataTable tb = _DataBase.GetDataTable("SP_MZSF_Select_YBTF", parameters, 30);
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        public static bool Bqedy(Guid yhlxid, RelationalDatabase _DataBase)
        {
            string ssql = "select * from jc_yhlx where id='" + yhlxid + "'";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0)
                return Convert.ToBoolean(tb.Rows[0]["bqedy"]);
            else
                return false;
        }


        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="fpid"></param>
        /// <returns></returns>
        public static bool MoveData(string fpid, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@fpid";
                parameters[0].Value = fpid;

                parameters[1].Text = "@errcode";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int32;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@errtext";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                DataSet dset = new DataSet();
                _DataBase.DoCommand("SP_MZ_TF_MOVEDATE", parameters, 30);
                int err_code = Convert.ToInt32(parameters[1].Value);
                string err_text = Convert.ToString(parameters[2].Value);
                if (err_code == 0) return true;
                else
                    throw new Exception(err_text);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }


        /// <summary>
        /// ���ڼ��ؿ���
        /// </summary>
        /// <param name="sfy"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static bool CKJZKZ(int sfy, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];

                parameters[0].Text = "@sky";
                parameters[0].Value = sfy;

                parameters[1].Text = "@errcode";
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[1].DataType = System.Data.DbType.Int32;
                parameters[1].ParaSize = 100;

                parameters[2].Text = "@errtext";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;

                DataSet dset = new DataSet();
                _DataBase.DoCommand("SP_MZSF_CKJZKZ", parameters, 30);
                int err_code = Convert.ToInt32(parameters[1].Value);
                string err_text = Convert.ToString(parameters[2].Value);
                if (err_code == 0) return true;
                else
                    throw new Exception(err_text);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// ��ȡ��ǰ�շ�Ա���õ��շѷ�Ʊ�����վ�
        /// </summary>
        /// <param name="sfy"></param>
        /// <param name="_DataBase"></param>
        /// <returns></returns>
        public static int GetFpLx(int sfy, RelationalDatabase _DataBase)
        {
            string ssql = "select FPLX from MZ_FPLYB where LYR=" + sfy.ToString() + " and BZYBZ=1 and BWCBZ=0 AND BSCBZ=0 AND FPLX<>0 AND FPLX <3 ";
            DataTable tb = _DataBase.GetDataTable(ssql);
            if (tb.Rows.Count > 0 && tb != null)
                return Convert.ToInt32(Convertor.IsNull(tb.Rows[0]["FPLX"], "-1"));
            else
                return -1;
        }

        /// <summary>
        /// ͨ��������Ŀid��ȡ��Ӧ�ļ���ҽ����Ŀ��Ϣ Add By zp 2013-10-09
        /// </summary>
        /// <param name="fee_xmid">����id</param>
        /// <param name="tcid">�ײ�id -1���ײ�</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetOrderYjItemInfo(string fee_xmid, string tcid, string order_id, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "";
                if (int.Parse(tcid) > 0)
                {
                    sql = @"SELECT top 1 A.*,B.ORDER_NAME,C.PRICE,B.DEFAULT_DEPT,
                     dbo.fun_getDeptname(b.DEFAULT_DEPT) as ִ�п�������,D.BBID,B.ORDER_UNIT,
                     E.SAMP_NAME,A.HOITEM_ID AS ҽ����Ŀid FROM JC_HOI_HDI AS A 
                     INNER JOIN JC_HOITEMDICTION AS B ON A.HOITEM_ID=B.ORDER_ID 
                     LEFT JOIN JC_TC AS C ON C.ITEM_ID=A.HDITEM_ID 
                     INNER JOIN JC_ASSAY AS D ON D.YZID=A.HOITEM_ID  
                     LEFT JOIN LS_AS_SAMPLE AS E ON D.BBID=E.SAMP_CODE
                     WHERE A.HDITEM_ID=" + fee_xmid + " AND A.TCID=" + tcid;
                    if (!string.IsNullOrEmpty(order_id))
                        sql += " AND a.HOITEM_ID=" + order_id;
                }
                else
                {
                    sql += @"SELECT top 1 A.*,B.ORDER_NAME,C.cost_price AS PRICE,B.DEFAULT_DEPT,
                     dbo.fun_getDeptname(b.DEFAULT_DEPT) as ִ�п�������,D.BBID,B.ORDER_UNIT,
                     E.SAMP_NAME,A.HOITEM_ID AS ҽ����Ŀid FROM JC_HOI_HDI AS A 
                     INNER JOIN JC_HOITEMDICTION AS B ON A.HOITEM_ID=B.ORDER_ID 
                     INNER JOIN jc_hsitemdiction AS C ON C.ITEM_ID=A.HDITEM_ID 
                     INNER JOIN JC_ASSAY AS D ON D.YZID=A.HOITEM_ID  
                     LEFT JOIN LS_AS_SAMPLE AS E ON D.BBID=E.SAMP_CODE
                     WHERE A.HDITEM_ID=" + fee_xmid + " AND A.TC_FLAG=0 ";
                    if (!string.IsNullOrEmpty(order_id))
                        sql += " AND a.HOITEM_ID=" + order_id;
                }
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        /// <summary>
        /// ͨ��������Ŀid��ȡ��Ӧ�ļ����Ŀҽ����Ϣ Add By zp 2013-10-09
        /// </summary>
        /// <param name="fee_xmid"></param>
        /// <param name="tcid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable GetOrderJcItemInfo(string fee_xmid, string tcid, string order_id, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT top 1 A.NUM as ����, A.HOITEM_ID,
                    B.ORDER_NAME as ����,C.cost_price as �۸�,B.DEFAULT_DEPT as execDept, 
                     dbo.fun_getDeptname(b.DEFAULT_DEPT)  as ִ�п���,
                    D.JCLXID,B.ORDER_UNIT as ��λ,ISNULL(E.ORDER_POSITION,'') AS �걾,2 AS ��Ŀ����,
                    D.ID AS JcxmId,A.TCID as �ײ�id,A.HOITEM_ID AS ҽ����Ŀid FROM JC_HOI_HDI AS A 
                    INNER JOIN JC_HOITEMDICTION AS B ON A.HOITEM_ID=B.ORDER_ID 
                    INNER JOIN jc_hsitemdiction AS C ON C.ITEM_ID=A.HDITEM_ID 
                    INNER JOIN JC_JC_ITEM AS D ON D.YZID=A.HOITEM_ID
                    LEFT JOIN JC_HOITEMDICTIONCHILD AS E ON E.ORDER_ID=A.HOITEM_ID
                     WHERE A.HDITEM_ID=" + fee_xmid + "";
                if (!string.IsNullOrEmpty(order_id))
                    sql += " AND a.HOITEM_ID=" + order_id;

                if (int.Parse(tcid) > 0)
                    sql += " AND A.TCID=" + tcid;
                else
                    sql += " and A.TC_FLAG=0";

                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //��ȡ�����¼
        public static DataTable GetJzInfo(Guid ghxxid, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = string.Format(@" SELECT A.JZID,A.GHXXID,A.JSKSDM,A.JSYSDM,A.JSSJ,C.BRXM,
             (CASE WHEN C.XB=1 THEN '��' when C.XB=2 THEN 'Ů' ELSE 'δ֪' END) AS XB,
             cast(dbo.fun_GetAgeYear(C.CSRQ,GETDATE()) AS VARCHAR)+'��' AS AGE,C.BRLXFS,C.GZDW from MZYS_JZJL AS A 
             INNER JOIN MZ_GHXX AS B ON A.GHXXID=B.GHXXID
             INNER JOIN YY_BRXX AS C ON B.BRXXID=C.BRXXID where A.GHXXID='{0}'", ghxxid);
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //ͨ������id�����ײ�id ��ȡҽ����Ŀ
        public static DataTable GetFeeItemToOrder(string fee_id, string tcid, RelationalDatabase db)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = @" select * from JC_HOI_HDI where 1=1  ";
                if (!string.IsNullOrEmpty(fee_id))
                    sql += "AND HDITEM_ID=" + fee_id + "";
                if (!string.IsNullOrEmpty(tcid))
                    sql += " and TCID=" + tcid + " ";
                dt = db.GetDataTable(sql);
            }
            catch (Exception ea)
            {
                throw ea;
            }
            return dt;
        }
        //���������˷�������̺� �˷ѽ���Ĵ�����ϸ���� Add By Zp 2014-02-07
        public static DataTable Select_tf_Sjsh(long dnlsh, Guid ghxxid, string fph, int tcid, int tccs, Guid hjid, out int err_code, out string err_text, RelationalDatabase _DataBase)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[8];
                parameters[0].Text = "@ghxxid";
                parameters[0].Value = ghxxid;//bf6c4b09-d412-43cf-8a68-a2bf00adf3ed

                parameters[1].Text = "@fph";
                parameters[1].Value = fph;//''

                parameters[2].Text = "@tcid";
                parameters[2].Value = tcid; //0

                parameters[3].Text = "@tccs";
                parameters[3].Value = tccs;//0

                parameters[4].Text = "@hjid";
                parameters[4].Value = hjid; //00000000-0000-0000-0000-000000000000

                parameters[5].Text = "@err_code";
                parameters[5].ParaDirection = ParameterDirection.Output;
                parameters[5].DataType = System.Data.DbType.Int32;
                parameters[5].ParaSize = 100;

                parameters[6].Text = "@err_text";
                parameters[6].ParaDirection = ParameterDirection.Output;
                parameters[6].ParaSize = 100;

                parameters[7].Text = "@dnlsh";
                parameters[7].Value = dnlsh;//1401261518666

                DataTable tb = _DataBase.GetDataTable("SP_MZSF_SelectTf_SJSH", parameters, 30);
                err_code = Convert.ToInt32(parameters[5].Value);
                err_text = Convert.ToString(parameters[6].Value);


                //���鴦��
                //string[] GroupbyField ={ "HJID", "��ҩ����", "�˼���" };
                //string[] ComputeField ={ "�˽��" };
                //string[] CField ={ "sum" };
                //TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
                //xcset.TsDataTable = tb;
                //DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "hjmxid<>'' and �˽��>0 ");
                return tb;

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        /// <summary>
        /// ���˷���ȷ��
        /// </summary>
        /// <param name="fph">��Ʊ���</param>
        /// <param name="fph">��Ʊ��</param>
        /// <param name="je">ȷ�Ͻ��</param>
        /// <param name="qrry">ȷ���˱���</param>
        /// <param name="qrryxm">ȷ��������</param>
        /// <param name="bwcbz">���˱�־</param>
        /// <param name="bscbz">ɾ����־</param>
        /// <param name="bz">��ע</param>
        /// <returns></returns>
        public static int Save_htdwdzlog(string fpid, string fph, decimal je, int qrry, string qrryxm, int bwcbz, int bscbz, string bz, RelationalDatabase _DataBase)
        {
            string cmd = "";
            try
            {
                object id;
                cmd = String.Format(@"insert into MZ_HTDW_DZLOG (DZID,FPID,JE,QRRQ,QRRY,QRRYXM,BWCBZ,BSCBZ,BZ,FPH) 
VALUES(newid(),'{0}',{1},GETDATE(),{2},'{3}',{4},{5},'{6}','{7}')", fpid, je, qrry, qrryxm, bwcbz, bscbz, bz, fph);
                return _DataBase.InsertRecord(cmd, out id, 30);
            }
            catch (Exception ex)
            {
                throw new Exception(cmd+"\n___________________\n"+ex.Message);
            }
        }
        /// <summary>
        /// �����շѽ�����ض�Ӧ��ҽ���б�
        /// </summary>
        /// <param name="dset"></param>
        /// <param name="dtOrderList"></param>
        /// <param name="Database"></param>
        public static void GetGuideBillListForOrderItem( DataSet dset , DataTable dtOrderList , RelationalDatabase Database )
        {
            string shjids = "";
            //hjid�ַ���
            for ( int i = 0 ; i < dset.Tables[0].Rows.Count - 1 ; i++ )
                shjids = shjids + dset.Tables[0].Rows[i]["hjid"].ToString().Trim().Replace( "(" , "" ).Replace( ")" , "" ) + ",";
            if ( dset.Tables[0].Rows.Count > 0 )
                shjids = shjids + dset.Tables[0].Rows[dset.Tables[0].Rows.Count - 1]["hjid"].ToString().Trim().Replace( "(" , "" ).Replace( ")" , "" );

            shjids = "(" + ( string.IsNullOrEmpty( shjids ) ? string.Format( "'{0}'" , Guid.Empty.ToString() ) : shjids ) + ")";
            //���»�ȡҽ����ϸ
            #region select string
            string strSql = @"SELECT ִ�п���,(select DEPTADDR from JC_DEPT_PROPERTY where DEPT_ID = ִ�п���id) as ִ�п��ҵص�,����,����,a.���,����,����,��λ,����,���,����,������λ,�÷�,Ƶ��,����,
                                        (case when ��Ŀ��Դ=1 then ��Ŀ���� else ҽ������ end) as Ʒ��,
                                        (case when ��Ŀ��Դ=1 then ��Ʒ�� else ҽ������ end) as ��Ʒ��
                                        FROM 
                                        (            
                                            select 
	                                            (CASE WHEN B.MEMO<>'' and  B.MEMO IS NOT NULL THEN  yzmc+'  ['+  B.MEMO +']' WHEN (B.MEMO='' OR B.MEMO IS NULL) AND xmly=2 THEN YZMC else yzmc+'  '+gg END) as ҽ������,          
	                                            cast(cast(yl as float) as varchar(30)) ����,yldw ������λ,pcmc Ƶ��,yfmc �÷�,ts ����,b.zt ����,          
	                                            cast(cast(dj as float) as varchar(30)) ����,cast(js as varchar(10)) ����,cast(cast(sl as float) as varchar(30)) ����,dw ��λ,cast(je as float)  ���,          
	                                             dbo.fun_getempname(ysdm) ����ҽ��,dbo.fun_getdeptname(zxks) ִ�п���,a.hjid,rtrim(bm) ����,rtrim(pm) ��Ŀ����,spm ��Ʒ��,gg ���,            
	                                            cj ����,yldwid ������λid,dwlx, cast(pcid as varchar(20)) Ƶ��id,cast(yfid as varchar(20)) �÷�ID,  ydwbl,tjdxmdm ͳ�ƴ���Ŀ,xmid ��ĿID,hjmxid,bzby �Ա�ҩ,                        
	                                            bpsbz Ƥ�Ա�־,  zxks ִ�п���id,ksdm ����id,ysdm ҽ��id  ,zyksdm סԺ����id,xmly ��Ŀ��Դ,tcid �ײ�ID, CFRQ ��������,dbo.fun_getempname(HJY) ����Ա,hjy,HJCK ���۴���, 
	                                            yzid,yzmc, c.YPJX ypjx ,  zdmc �������,zdicd   ���ICD ,MZYP    
                                            from vi_mz_hjb a 
                                            inner join vi_mz_hjb_mx b  on a.HJID=b.HJID          
                                            inner join VI_YP_YPCD c on a.XMLY=1 and b.XMID=c.cjid and b.YZID=c.GGID          
                                            where a.hjid=b.hjid and a.HJID in {0}
                                            union all             
                                            select 
	                                            (CASE WHEN B.MEMO<>'' and  B.MEMO IS NOT NULL THEN  yzmc+'  ['+  B.MEMO +']' else  yzmc END ) as ҽ������,          
	                                            cast(cast(b.yl as float) as varchar(30)) ����,rtrim(item_unit) ������λ,pcmc Ƶ��,yfmc �÷�,ts ����,zt ����,          
	                                            cast(cast(sum(je)/(case when js=0 then 1 else js end) as float) as varchar(30)) ����, cast(1 as varchar(10)) ����,cast(b.js as varchar(30)) ����,rtrim(item_unit) ��λ,sum(je)  ���,          
	                                            dbo.fun_getempname(ysdm) ����ҽ��,dbo.fun_getdeptname(ZXKS) ִ�п���,a.hjid,'' ����,rtrim(item_name) ��Ŀ����,item_name ��Ʒ��,ISNULL(B.GG,'') ���,            
	                                            '' ����,yldwid ������λid,0 dwlx,pcid Ƶ��id,yfid �÷�ID,1 ydwbl,'' ͳ�ƴ���Ŀ,tcid ��ĿID,null hjmxid,0 �Ա�ҩ,
	                                            0 Ƥ�Ա�־,   ZXKS ִ�п���id,ksdm ����id,ysdm ҽ��id ,zyksdm סԺ����id,xmly ��Ŀ��Դ,tcid �ײ�ID, CFRQ ��������,dbo.fun_getempname(HJY) ����Ա,hjy,HJCK ���۴���,                               
	                                            b.yzid,b.yzmc    ,   null ypjx  ,  zdmc ������� ,zdicd   ���ICD,0 MZYP     
                                            from vi_mz_hjb a  
                                            inner join vi_mz_hjb_mx B on a.hjid=b.hjid            
                                            left join jc_tc_t c on b.tcid=c.item_id             
                                            where a.xmly=2 and a.HJID in {0}         
                                            group by a.hjid,b.yzid,b.yzmc,c.py_code,item_name,item_unit,tcid,b.yl,b.yldwid,ts,b.js,zxks,ksdm,ysdm,zyksdm, xmly,cfrq,hjy,hjck,yfmc,yfid,pcmc,pcid ,zt ,bsfbz,bsdbz,jsd,B.MEMO,B.GG ,zdmc ,zdicd ,a.FLAG   
                                        ) A ORDER BY HJID";
            #endregion
            strSql = string.Format( strSql , shjids );

            DataTable tbList = Database.GetDataTable( strSql );
            dtOrderList.Rows.Clear();
            foreach ( DataRow r in tbList.Rows )
            {
                DataRow r0 = dtOrderList.NewRow();
                r0["ZXKSMC"] = r["ִ�п���"];//��������
                r0["DEPTADDR"] = r["ִ�п��ҵص�"];//λ��
                r0["CJ"] = r["����"];//����
                r0["BM"] = r["����"];
                r0["PM"] = r["Ʒ��"];
                r0["GG"] = r["���"];
                r0["DJ"] = r["����"];
                r0["SL"] = r["����"];
                r0["DW"] = r["��λ"];
                r0["JS"] = r["����"];
                r0["JE"] = r["���"];
                
                r0["SPM"] = r["��Ʒ��"];
                r0["YL"] = r["����"];
                r0["YLDW"] = r["������λ"];//������λ
                r0["YFMC"] = r["�÷�"];//�÷�
                r0["PCMC"] = r["Ƶ��"];//Ƶ��
                r0["ZT"] = r["����"];//����
                dtOrderList.Rows.Add( r0 );
            }
        }
        /// <summary>
        /// ���ݷ�Ʊ����ҽ���б���
        /// </summary>
        /// <param name="Fpid"></param>
        /// <param name="dtOrderList"></param>
        /// <param name="Database"></param>
        public static void GetGuideBillListForOrderItem( Guid Fpid , DataTable dtOrderList , RelationalDatabase Database )
        {
            string format = @"select ִ�п���,(select DEPTADDR from JC_DEPT_PROPERTY where DEPT_ID = ZXKS) as ִ�п��ҵص�,����,����, ���,����,����,��λ,����,���, ����,������λ,�÷�,Ƶ��,���� ,
                                    (case when ��Ŀ��Դ=1 then ��Ŀ���� else ҽ������ end) as Ʒ��,
                                    (case when ��Ŀ��Դ=1 then ��Ʒ�� else ҽ������ end) as ��Ʒ��
                                from (
                                       select bm ����,rtrim(pm) ��Ŀ����,spm ��Ʒ��,(select yzmc from MZ_HJB_MX where HJMXID = c.HJMXID group by YZMC) as ҽ������,gg ���,cj ����,dj ����,sl ����,rtrim(dw) ��λ,js ����,je ���,(case when bpsbz=-1 then '����' when bpsbz=0 then 'Ƥ��' else '' end) Ƥ��,c.YFMC �÷�,zt ����,(select pcmc from MZ_HJB_MX where HJMXID = c.HJMXID group by PCMC) as Ƶ��,(select yl from MZ_HJB_MX where HJMXID=c.hjmxid group by yl) as ����,(select yldw from MZ_HJB_MX where HJMXID=c.hjmxid group by YLDW ) as ������λ, ksmc ����,ysxm ҽ��,
                                              zxksmc ִ�п���,b.ZXKS, tcid �ײ�id,hjrq ��������,hjyxm ����Ա,a.sfrq �շ�����,sfyxm �շ�Ա,fyrq ��ҩ����,fyrxm ��ҩԱ,isnull(cast(hjid as varchar(50)),'0') CFID,pxxh,hjmxid cfmxid,xmly as ��Ŀ��Դ                                             
                                       from mz_fpb a 
                                            inner join mz_cfb b on a.fpid=b.fpid 
                                            inner join mz_cfb_mx c on b.cfid=c.cfid
                                       where a.bscbz=0 and tcid=0  and a.FPID='{0}'
                                       union all 
                                       select ����,��Ŀ����,��Ʒ��,ҽ������,���,����,sum(����) as ����,����, ��λ,����,sum(���) as ���, Ƥ��,�÷�, ����,'' as Ƶ��,null as ����,null as ������λ,  ����,  ҽ��,  ִ�п���, ZXKS,  �ײ�id,  ��������,  ����Ա,  �շ�����,  �շ�Ա,  ��ҩ����,  ��ҩԱ,  CFID ,  pxxh,  cfmxid ,  ��Ŀ��Դ
                                       from (
                                           select '' ����,rtrim(item_name) ��Ŀ����,item_name ��Ʒ��,(select yzmc from MZ_HJB_MX where HJMXID = c.HJMXID group by YZMC) as ҽ������,'' ���,'' ����,cast(round(sum(je)/js,2) as decimal(15,2)) ����,(case when sum(je)>0 then js else (-1)*js end) ����,
                                                 rtrim(item_unit) ��λ,1 ����,cast(sum(je) as float) ���,'' Ƥ��,c.YFMC �÷�,'' ����,ksmc ����,ysxm ҽ��,zxksmc ִ�п���,b.ZXKS,tcid �ײ�id,hjrq ��������,hjyxm ����Ա,a.sfrq �շ�����,sfyxm �շ�Ա,fyrq ��ҩ����,fyrxm ��ҩԱ,isnull(cast(hjid as varchar(50)),'0') CFID ,0 pxxh,null cfmxid ,xmly ��Ŀ��Դ
                                           from mz_fpb a 
                                                inner join mz_cfb b on a.fpid=b.fpid 
                                                inner join mz_cfb_mx c on b.cfid=c.cfid 
                                                inner join jc_tc d on c.tcid=d.item_id AND D.JGBM=1000   
                                           where a.bscbz=0  and tcid>0  and a.FPID='{0}'
                                           group by a.blh,brxm,tcid,item_name,item_unit,c.js,ksmc,ysxm,zxksmc,b.zxks,hjrq,hjyxm,a.fph,a.sfrq,sfyxm,fyrq,fyrxm,hjid,xmly,yfmc,c.hjmxid
                                        ) aa group by ����,��Ŀ����,��Ʒ��,ҽ������,���,����,����, ��λ,����, Ƥ��,�÷�, ����,  ����,  ҽ��,  ִ�п���, ZXKS,  �ײ�id,  ��������,  ����Ա,  �շ�����,  �շ�Ա,  ��ҩ����,  ��ҩԱ,  CFID ,  pxxh,  cfmxid ,  ��Ŀ��Դ
                                ) a order by ��������,pxxh,cfmxid";
            format = string.Format( format , Fpid );
            DataTable dataTable = Database.GetDataTable( format );
            dtOrderList.Rows.Clear();
            foreach ( DataRow row in dataTable.Rows )
            {
                DataRow row2 = dtOrderList.NewRow();
                row2["ZXKSMC"] = row["ִ�п���"];
                row2["DEPTADDR"] = row["ִ�п��ҵص�"];
                row2["CJ"] = row["����"];
                row2["BM"] = row["����"];
                row2["PM"] = row["Ʒ��"];
                row2["GG"] = row["���"];
                row2["DJ"] = row["����"];
                row2["SL"] = row["����"];
                row2["DW"] = row["��λ"];
                row2["JS"] = row["����"];
                row2["JE"] = row["���"];
                row2["SPM"] = row["��Ʒ��"];
                row2["YL"] = row["����"];
                row2["YLDW"] = row["������λ"];
                row2["YFMC"] = row["�÷�"];
                row2["PCMC"] = row["Ƶ��"];
                row2["ZT"] = row["����"];
                dtOrderList.Rows.Add( row2 );
            }
        }
    }
}
