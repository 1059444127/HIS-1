using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using System.Data;
using TrasenFrame.Forms;
using System.Windows.Forms;
using System.Drawing;
using TrasenFrame.Classes;

namespace YpClass
{
    public class WBKS
    {
        /// <summary>
        /// �ж��Ƿ�Ϊ�ⲿ����
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool IsWbks(int deptid, RelationalDatabase db)
        {
            //�ⲿ�����ж�
            string sql = string.Format(" select ID from YP_YJKS where iswbks = 1 and DEPTID = {0}", deptid);
            DataTable tab = db.GetDataTable(sql);
            return tab != null && tab.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// FrmShowCard��ѯ����
        /// </summary>
        /// <param name="sender">�����Ŀؼ�</param>
        /// <param name="_ShowCardType">��ѯ����Ȩ��</param>
        /// <param name="Fid">��������ID</param>
        /// <param name="point">λ�� </param>
        public static void frmShowCard_wbks(object sender, ShowCardType _ShowCardType, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            Control control = (Control)sender;

            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }


            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.����)
            {
                GrdMappingName = new string[] { "id", "ҩƷ����", "ƴ����", "�����" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,mc,pym,wbm from yp_ypjx where id<>0 ";//yplx="+Convert.ToInt32(Convertor.IsNull(Fid,"0"))+" ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "ҩƷ����";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["mc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.��λ)
            {
                GrdMappingName = new string[] { "��ʶ", "����" };
                GrdWidth = new int[] { 100, 200 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,dwmc from yp_ypdw where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "ҩƷ��λ";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["dwmc"].ToString();
                    control.Tag = row["ID"].ToString();
                }
            }
            if (_ShowCardType == ShowCardType.����)
            {
                GrdMappingName = new string[] { "id", "��������", "ƴ����", "�����" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select id,sccj,pym,wbm from yp_sccj where id<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "��������";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["sccj"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }
            if (_ShowCardType == ShowCardType.�÷�)
            {
                GrdMappingName = new string[] { "id", "ʹ�÷���", "ƴ����", "�����" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                //if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wb_code", "py_code", "", "", "" };
                //else
                //	sfield=new string[] {"","","","",""};
                ssql = "select id,name,py_code,wb_code from jc_usagediction where name is not null ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "ҩƷ�÷�";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["name"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.ҩ�����)
            {
                GrdMappingName = new string[] { "id", "��λ���", "ҩƷ����", "������", "ƴ����", "�����" };
                GrdWidth = new int[] { 0, 60, 150, 150, 100, 100 };
                //				if (Convertor.IsNull(control.Tag.ToString(),"0")!="0")
                sfield = new string[] { "wbm", "pym", "", "", "" };
                //				else
                //					sfield=new string[] {"","","","",""};
                ssql = "select id,hwbh,flmc,(select flmc from yp_ylfl where id=a.fid),pym,wbm from yp_ylfl a where yjdbz=1 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Width = 600;
                f.Text = "ҩ�����";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["flmc"].ToString();
                    control.Tag = row["id"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.������λ)
            {
                GrdMappingName = new string[] { "id", "������", "ƴ����", "�����" };
                GrdWidth = new int[] { 0, 150, 100, 100 };
                sfield = new string[] { "wbm", "pym", "", "", "" };
                ssql = "select ID,ghdwmc,pym,wbm from yp_ghdw WHERE ID<>0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "������λ";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ghdwmc"].ToString();
                    control.Tag = row["id"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.�����ڿ��ҹ��������е�ҩƷ�ֵ�)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "DWBL", "�ϴν���", "������", "������", "���ۼ�", "����", "��ҩ" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = @"select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,
                (case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,
                a.mrjj,
                pfj,lsj,shh,(case when GJJBYW=1 then '��' else '' end) ��ҩ from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + "  where cjbdelete=0  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);

                f.Location = point;
                f.Text = "ҩƷ����";
                f.Width = 800;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.����ҩƷ�ֵ�)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 0, 70, 60, 60, 100 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                ssql = "select distinct top 100  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from yp_ypcjd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);

                f.Location = point;
                f.Text = "ҩƷ����";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.��������б�)
            {
                GrdMappingName = new string[] { "�к�", "�����", "��λ", "����", "Ч��", "��λ", "kwid" };
                GrdWidth = new int[] { 0, 80, 40, 75, 100, 0, 0 };
                sfield = new string[] { "", "", "", "", "" };

                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yk_kcph " +
                    " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";
                else
                    ssql = "select 0, kcl,dbo.fun_yp_ypdw(zxdw),ypph,ypxq,'' kwmc,kwid  from yf_kcph " +
                        " where deptid=" + deptid + " and cjid=" + Fid + " and bdelete=0 ";

                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, "", ssql, _DataBase);
                f.Location = point;
                f.Text = "�����б�";
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Text = row["ypph"].ToString();
                }

            }

            if (_ShowCardType == ShowCardType.���ҩƷ)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "���", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                 * update code by pengy 7-2 10:17   
                 * ��ϵͳ�������û�ȡ����Ƿ���ڵ���0������
                 */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh 
                                 from vi_yK_kcmx a,yp_ypbm b
                                 where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0 and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";

                    else
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                }
                else
                {
                    if (ypkc)
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL >= 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                    else
                        ssql = @"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + " and bdelete_kc=0  and a.cjid in (select cjid from YP_YPCJD where iswbyp =1)";
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "���ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.���ҩƷ_�����ֽ���)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "���", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0  and deptid=" + deptid + " ";
                else
                    ssql = "select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid and KCL > 0 and deptid=" + deptid + "  ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "���ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            if (_ShowCardType == ShowCardType.���ҩƷ_����ҩƷ)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where a.ggid=b.ggid and wyyp=1   and deptid=" + deptid + " and bdelete_kc=0 ";
                else
                    ssql = "select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where a.ggid=b.ggid  and wyyp=1 and deptid=" + deptid + " and bdelete_kc=0 ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "����ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }

            #region �ӹ���Ʒ��ҩƷ�ֵ�
            if (_ShowCardType == ShowCardType.�ӹ���Ʒ��ҩƷ�ֵ�)
            {
                //SystemCfg cfg = new SystemCfg(8002, _DataBase);
                //string tablename = "YK_KCMX";
                //if (cfg.Config == "1")
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);

                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "������", "DWBL", "�ϴν���", "������", "���ۼ�", "����", "��ҩ" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };

                string strWhere = "";
                DataTable dtConfig = _DataBase.GetDataTable(string.Format(" select config from jc_config where id = 8042 ", 8042));
                if (dtConfig.Rows.Count > 0)
                {
                    string strCfg = dtConfig.Rows[0][0].ToString();

                    string[] strs = strCfg.Split('|');
                    string strCp = strs[0];
                    string[] scps = strCp.Split(',');


                    for (int i = 0; i < scps.Length; i++)
                    {
                        if (i == 0)
                            strWhere += string.Format(" and a.n_ypzlx in ({0},", scps[i]);
                        else
                            strWhere += string.Format("{0},", scps[i]);
                        if (i == scps.Length - 1)
                        {
                            strWhere = (strWhere.Substring(0, strWhere.Length - 1)) + ") ";
                        }
                    }
                }

                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '��' else '' end) ��ҩ from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                try
                {
                    f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                }
                catch
                {
                    throw new Exception(" 8042������������ ");
                    return;
                }

                f.Location = point;
                f.Text = "ҩƷ����";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            #endregion

            #region �Ƽ���Ʒ��ҩƷ�ֵ�
            if (_ShowCardType == ShowCardType.�Ƽ���Ʒ��ҩƷ�ֵ�)
            {
                string tablename = Yp.Seek_kcmx_table(deptid, _DataBase);
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "������", "DWBL", "�ϴν���", "������", "���ۼ�", "����", "��ҩ" };
                GrdWidth = new int[] { 0, 0, 0, 140, 90, 90, 30, 60, 0, 70, 60, 60, 100, 45 };
                sfield = new string[] { "b.wbm", "b.pym", "szm", "ywm", "ypbm" };
                string strWhere = "";

                ssql = "select distinct top 80  a.ggid,a.cjid,0 rowno,s_yppm,s_ypgg,s_sccj,s_ypdw, d.mc zlxmc, 1 dwbl,(case when scjj=0 or scjj is null then '' else cast(scjj as varchar(50)) end) scjj,pfj,lsj,shh,(case when GJJBYW=1 then '��' else '' end) ��ҩ from vi_yp_ypcd a inner join yp_ypbm b " +
                    " on a.ggid=b.ggid left join " + tablename + " c on a.cjid=c.cjid and c.deptid=" + deptid + " inner join yp_ypzlx d on a.ypzlx=d.id  where cjbdelete=0" + strWhere + "  and a.n_ypzlx in(select ypzlx from yp_gllx where deptid=" + deptid + ") ";
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql);
                f.Location = point;
                f.Text = "ҩƷ����";
                f.Width = 750;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            #endregion
        }


        /// <summary>
        /// FrmShowCard��ѯ����
        /// </summary>
        /// <param name="sender">�����Ŀؼ�</param>
        /// <param name="_ShowCardType">��ѯ����Ȩ��</param>
        /// <param name="Fid">��������ID</param>
        /// <param name="point">λ�� </param>
        public static void frmShowCard(object sender, ShowCardType _ShowCardType, string functionName, long Fid, Point point, int deptid, RelationalDatabase _DataBase)
        {
            //SystemCfg sc = new SystemCfg(8201);
            //if (sc.Config == "0")
            //{
            //    frmShowCard(sender, _ShowCardType, Fid, point, deptid, _DataBase);
            //    return;
            //}

            Control control = (Control)sender;
            if (control.Text.Trim() == "")
            {
                control.Text = "";
                control.Tag = "0";
            }
            string[] GrdMappingName;
            int[] GrdWidth;
            string[] sfield;
            string ssql = "";
            Fshowcard f;

            if (_ShowCardType == ShowCardType.���ҩƷ)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "���", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                /*
                   * update code by pengy 7-2 10:17   
                   * ��ϵͳ�������û�ȡ����Ƿ���ڵ���0������
                  */
                ssql = "select config from jc_config where id = '8200'";
                DataTable paramTable = _DataBase.GetDataTable(ssql);
                bool ypkc = paramTable != null && paramTable.Rows.Count > 0 && paramTable.Rows[0][0].ToString().Trim() == "1" ? true : false;
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                }
                else
                {
                    if (ypkc)
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL >= 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                    else
                        ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                        a.ggid=b.ggid and KCL > 0 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0}) and cjid in (select cjid from YP_YPCJD where iswbyp =1)", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "���ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.���ҩƷ_�����ֽ���)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "���", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 60, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                    a.ggid=b.ggid and KCL > 0  and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                else
                {
                    ssql = string.Format(@"select distinct top 100  a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,cast(kcl/dwbl as float) kcl,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b 
                    where a.ggid=b.ggid and KCL > 0 and deptid={0}  and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                        where DEPTID = {0})", deptid);
                }
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "���ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
            else if (_ShowCardType == ShowCardType.���ҩƷ_����ҩƷ)
            {
                GrdMappingName = new string[] { "ggid", "cjid", "�к�", "Ʒ��", "���", "����", "��λ", "DWBL", "������", "���ۼ�", "����" };
                GrdWidth = new int[] { 0, 0, 30, 140, 90, 90, 30, 0, 60, 60, 100 };
                sfield = new string[] { "wbm", "pym", "szm", "ywm", "ypbm" };
                if (YpConfig.�Ƿ�ҩ��(deptid, _DataBase) == true)
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yK_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid and wyyp=1   and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID
                          where DEPTID = {0})  ", deptid);
                else
                    ssql = string.Format(@"select distinct top 100 a.ggid,cjid,0 rowno,yppm,ypgg,s_sccj,s_ypdw,1 dwbl,pfj,lsj,shh from vi_yf_kcmx a,yp_ypbm b where 
                          a.ggid=b.ggid  and wyyp=1 and deptid={0} and bdelete_kc=0 and YPLX in (select distinct YPLX from YP_GLLX a left join YP_YPLX b on a.YPLX = b.ID                           
                          where DEPTID = {0})", deptid);
                f = new Fshowcard(GrdMappingName, GrdWidth, sfield, FilterType.ƴ��, control.Text.Trim(), ssql, _DataBase);
                f.Location = point;
                f.Text = "����ҩƷ";
                f.Width = 700;
                f.ShowDialog();
                DataRow row = f.dataRow;
                if (row != null)
                {
                    control.Tag = row["cjid"].ToString();
                }
            }
        }
    }
}
