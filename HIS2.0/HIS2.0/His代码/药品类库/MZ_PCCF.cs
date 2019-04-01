using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Data;
namespace YpClass
{
    //�������β�ַ����� 
    public class MZ_PCCF
    {
        
        /// <summary>
        /// ���﷢ҩ���η���(�ֿ������ſ��)
        /// </summary>
        /// <param name="sumYpmx"></param>
        /// <param name="mxlx">��ϸ����</param>
        /// <returns></returns>
        public static List<MZ_Kcph> GetMZFYLstKcph(List<MZ_SumYpmx> _lstSumYpmx, List<MZ_Ypmx> _lstYpmx,RelationalDatabase db)
        {
            List<MZ_Kcph> lstKcph = new List<MZ_Kcph>();
            List<MZ_SumYpmx> lstSumYpmx = ZY_PCCF.CloneBySerialize<List<MZ_SumYpmx>>(_lstSumYpmx);
            List<MZ_Ypmx> lstYpmx = ZY_PCCF.CloneBySerialize<List<MZ_Ypmx>>(_lstYpmx);

            //�жϿ���Ƿ��㹻 
            string errtext = "";
            if (!OutKcmx(lstSumYpmx, out errtext, db))
            {
                throw new Exception(errtext);
            }

            #region ��ϸ���������Ƚ��е��� ����������ϸ������������ο��,�������������ȫ�������򱨴�
            foreach (MZ_Ypmx ypmx_fs in lstYpmx)
            {
                if (ypmx_fs.ypsl < 0)
                {
                    foreach (MZ_Ypmx ypmx_zs in lstYpmx)
                    {
                        if (ypmx_zs.ypsl > 0 && ypmx_zs.mxid == ypmx_fs.tyid)
                        {
                            decimal temp = ypmx_fs.ypsl + ypmx_zs.ypsl;
                            if (temp >= 0)//�ܹ���ȫ����
                            {
                                MZ_Kcph kcph_zs = new MZ_Kcph();
                                kcph_zs.cks = ypmx_fs.ypsl * (-1);
                                kcph_zs.mxid = ypmx_zs.mxid;
                                kcph_zs.cjid=ypmx_zs.cjid;

                                MZ_Kcph kcph_fs = new MZ_Kcph();
                                kcph_fs.cks = ypmx_fs.ypsl;
                                kcph_fs.mxid = ypmx_fs.mxid;
                                kcph_fs.tyid = ypmx_fs.tyid;
                                kcph_fs.cjid=ypmx_fs.cjid;

                                ypmx_fs.ypsl = 0;
                                ypmx_zs.ypsl = temp;

                                lstKcph.Add(kcph_fs);
                                lstKcph.Add(kcph_zs);
                            }
                            else
                            {
                                if (ypmx_fs.ypsl < 0)
                                {
                                    throw new Exception("����δ�ܵ����ĸ�������¼��");
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            //�������ſ��
            foreach (MZ_SumYpmx sum in lstSumYpmx)  //����ϸ���ܽ��е���
            {
                #region ȡ���ο��
                string ssql_kcph = string.Format(@" select 
                                              id,jgbm,ggid,cjid,kwid,ypph,ypxq,yppch,id kcid,
                                              jhj,kcl,djsj,bdelete,deptid,ykbdelete,zxdw,dwbl  
                                              from yf_kcph where  cjid={0} and deptid={1} and bdelete<>1 and ykbdelete<>1 and kcl>0 ",
                                   sum.cjid, sum.deptid);//Ҫ���ǵ�λ����֮��Ļ��������õĻ����е�dwbl
                DataTable tb_kcph = db.GetDataTable(ssql_kcph, 30); //ȡ����ǰҩƷ���ſ����>0�����ſ��

                if (tb_kcph.Rows.Count <= 0) //��������Ϊ0
                {
                    ssql_kcph = string.Format(@" select top 1 
                                              id,jgbm,ggid,cjid,kwid,ypph,ypxq,yppch,id kcid,
                                              jhj,kcl,djsj,bdelete,deptid,ykbdelete,zxdw,dwbl   
                                              from yf_kcph where  cjid={0} and deptid={1} and bdelete<>1 and ykbdelete<>1 ",
                                   sum.cjid, sum.deptid);//Ҫ���ǵ�λ����֮��Ļ��������õĻ����е�dwbl
                    tb_kcph = db.GetDataTable(ssql_kcph, 30);
                    if (tb_kcph.Rows.Count <= 0)
                    {
                        Ypcj ypcj = new Ypcj(sum.cjid,db);
                        throw new Exception(string.Format("{0} {1} û�����ο���¼��",ypcj.S_YPPM,ypcj.S_YPGG));
                    }
                }

                if (Convert.ToInt32(tb_kcph.Rows[0]["dwbl"]) != sum.dwbl)
                {
                    throw new Exception("�����㵥λ�����仯����ˢ�����ݺ�����!");
                }

                #endregion

                #region ��������kcph��������
                foreach (MZ_Kcph kcph in lstKcph)
                {
                    if (kcph.cjid == sum.cjid)
                    {
                        DataRow row = tb_kcph.Rows[0];
                        kcph.jhj = Convert.ToDecimal(row["jhj"]);
                        kcph.dwbl = sum.dwbl;
                        kcph.zxdw = Convert.ToInt32(row["zxdw"]);
                        kcph.ggid = Convert.ToInt32(row["ggid"]);
                        kcph.ypph = row["ypph"].ToString();
                        kcph.ypxq = row["ypxq"].ToString();
                        kcph.yppch = Convertor.IsNull(row["yppch"].ToString(),"");
                        kcph.kcid = Convertor.IsNull(row["kcid"],Guid.Empty.ToString());
                    }
                }
                #endregion

                #region ��δ������ypmx�������ſ��
                foreach (MZ_Ypmx ypmx in lstYpmx)   
                {
                    if (ypmx.cjid == sum.cjid)   
                    {
                        decimal temp = ypmx.ypsl;//��ǰ��ϸҪ���������
                        if (temp == 0) continue; //�����ǰ������ϸҪ���������Ϊ0����������ϸ����������һ��
                        if (temp > 0)
                        {
                            for (int j = 0; j < tb_kcph.Rows.Count; j++) //�Ե�ǰҩƷ�����ſ����е���
                            {
                                DataRow tempRow = tb_kcph.Rows[j];
                                decimal kcl_ph = Convert.ToDecimal(tempRow["kcl"]); //��ǰ���ſ������

                                if (temp == 0) break;           //���������ϸ����Ϊ0�����������ſ�����

                                if (temp > kcl_ph)              //�����ǰ�����п����С�ڵ�ǰ������ϸҪ����������������ſ��ȫ������
                                {
                                    #region ���kcph
                                    string id_kcph = tempRow["id"].ToString();
                                    int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                    int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                    int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                    int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);
                                    string ypph_kcph = tempRow["ypph"].ToString();
                                    string ypxq_kcph = tempRow["ypxq"].ToString();
                                    string yppch_kcph = tempRow["yppch"].ToString(); //���κ�
                                    string kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty.ToString() : tempRow["kcid"].ToString();
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = kcl_ph;   //����ǰ���ſ������
                                    string mxid_kcph = ypmx.mxid;//mxid
                                    string tid_kcph = ypmx.tid;  //ͷid
                                    string tyid_kcph = ypmx.tyid;//tyid
                                    temp = temp - cks_kcph;  //��ǰ������ϸҪ���������-��ǰ���ſ������ 
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph;//��ǰ������ϸҪ���������-��ǰ���ſ������ 
                                    MZ_Kcph kcph = new MZ_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph,tid_kcph,cks_kcph
                                        ,tyid_kcph);
                                    lstKcph.Add(kcph);
                                    #endregion 
                                    tb_kcph.Rows[j]["kcl"] = 0; //����ǰ���ſ���� ��kcl����Ϊ 0
                                }
                                else                            //��������ſ��������Ҫ���������,���Ҫ���������
                                {
                                    #region ���kcph
                                    string id_kcph = tempRow["id"].ToString();
                                    int jgbm_kcph = Convert.ToInt32(tempRow["jgbm"]);
                                    int ggid_kcph = Convert.ToInt32(tempRow["ggid"]);
                                    int cjid_kcph = Convert.ToInt32(tempRow["cjid"]);
                                    int kwid_kcph = Convert.ToInt32(tempRow["kwid"]);
                                    string ypph_kcph = tempRow["ypph"].ToString();
                                    string ypxq_kcph = tempRow["ypxq"].ToString();
                                    string yppch_kcph = tempRow["yppch"].ToString(); //���κ�
                                    string kcid_kcph = (tempRow["kcid"] is DBNull) ? Guid.Empty.ToString() : tempRow["kcid"].ToString();
                                    decimal jhj_kcph = Convert.ToDecimal(tempRow["jhj"]);
                                    decimal kcl_kcph = Convert.ToDecimal(tempRow["kcl"]);
                                    int zxdw_kcph = Convert.ToInt32(tempRow["zxdw"]);
                                    int dwbl_kcph = sum.dwbl;
                                    int bdelete_kcph = Convert.ToInt32(tempRow["bdelete"]);
                                    int ykdelete_kcph = Convert.ToInt32(tempRow["ykbdelete"]);
                                    decimal cks_kcph = temp;     //ypmx��Ҫ���������
                                    string mxid_kcph = ypmx.mxid;//��ϸid
                                    string tid_kcph = ypmx.tid;  //ͷid
                                    string tyid_kcph = ypmx.tyid;//tyid
                                    ypmx.ypsl = ypmx.ypsl - cks_kcph; // 0
                                    temp = temp - cks_kcph;      //��ǰ������ϸҪ���������-��ǰ���ſ������ 
                                    MZ_Kcph kcph = new MZ_Kcph(id_kcph, jgbm_kcph, ggid_kcph, cjid_kcph, kwid_kcph,
                                        ypph_kcph, ypxq_kcph, yppch_kcph, kcid_kcph, jhj_kcph, kcl_kcph, zxdw_kcph,
                                        dwbl_kcph, bdelete_kcph, ykdelete_kcph, cks_kcph, mxid_kcph,tid_kcph,cks_kcph
                                        ,tyid_kcph);
                                    lstKcph.Add(kcph);
                                    #endregion 
                                    tb_kcph.Rows[j]["kcl"] = kcl_kcph - cks_kcph; //��ǰ���ſ�����е�kcl-���������
                                    break; //�������ſ�����
                                }
                            }
                            if (temp < 0)
                            {
                                throw new Exception("�������ο�淢������");
                            }
                        }
                    }
                }
                #endregion
            }

            //����
            List<MZ_Kcph> lstTemp = new List<MZ_Kcph>();
            foreach (MZ_Kcph kcph in lstKcph)
            {
                bool bContain = false;
                foreach (MZ_Kcph kcph_temp in lstTemp)
                {
                    if (kcph.mxid == kcph_temp.mxid && kcph.kcid == kcph_temp.kcid)
                    {
                        bContain = true;
                        kcph_temp.cks = kcph_temp.cks + kcph.cks;
                        break;
                    }
                    else
                    {
                        bContain = false;
                    }
                }
                if (!bContain)
                {
                    lstTemp.Add(ZY_PCCF.CloneBySerialize<MZ_Kcph>(kcph));
                }
            }
            

            //return lstKcph;
            return lstTemp;

        }
        
        /// <summary>
        /// �����ϸ����
        /// </summary>
        /// <param name="lstYpmx">��ϸ����</param>
        /// <param name="lstSumYpmx">��ϸ����</param>
        public static List<MZ_SumYpmx> CreateLstSumYpmx(List<MZ_Ypmx> lstYpmx)
        {
            List<MZ_SumYpmx> lstSumYpmx = new List<MZ_SumYpmx>();
            foreach (MZ_Ypmx ypmx in lstYpmx)
            {
                bool bContain = false;
                int index = 0;
                for (int i = 0; i < lstSumYpmx.Count; i++)
                {
                    if (lstSumYpmx[i].cjid == ypmx.cjid)
                    {
                        bContain = true;
                        index = i;
                    }
                }
                if (bContain)//�������
                {
                    lstSumYpmx[index].AddCount(ypmx.ypsl, ypmx.dwbl);
                }
                else//���������
                {
                    lstSumYpmx.Add(new MZ_SumYpmx(ypmx.cjid, ypmx.ypsl, ypmx.dwbl, ypmx.deptid));
                }
            }
            return lstSumYpmx;
        }

        /// <summary>
        /// �ж���ϸ�����п���Ƿ��㹻
        /// </summary>
        /// <param name="lstSumYpmx">��ϸ����</param>
        /// <param name="errText">�����ı�</param>
        /// <param name="db">DataBase</param>
        /// <returns></returns>
        public static bool OutKcmx(List<MZ_SumYpmx> lstSumYpmx, out string errText, RelationalDatabase db)
        {
            bool value = true;
            errText = string.Empty;
            foreach (MZ_SumYpmx sumypmx in lstSumYpmx)
            {
                string ssql_kcmx = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcmx 
                    where bdelete<>1   and 
                cjid={0} and deptid ={1} ", sumypmx.cjid, sumypmx.deptid, sumypmx.dwbl);
                decimal kcl = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcmx, 30), "0"));
                if (kcl < sumypmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(sumypmx.cjid, db);
                    value = false;
                    errText = c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " ��ϸ��������㣡";
                }

                //���ſ��
                string ssql_kcph = string.Format(@" select cast( sum(kcl*dwbl/{2}) as decimal) kcl from yf_kcph 
                    where bdelete<>1 and ykbdelete<>1   and 
                cjid={0} and deptid ={1} ", sumypmx.cjid, sumypmx.deptid, sumypmx.dwbl);
                decimal kcl_ph = Convert.ToDecimal(Convertor.IsNull(db.GetDataResult(ssql_kcph, 30), "0"));

                if (kcl_ph < sumypmx.sumcount)
                {
                    YpClass.Ypcj c_ypcj = new Ypcj(sumypmx.cjid,db);
                    value = false;
                    errText = c_ypcj.S_YPPM + " " + c_ypcj.S_YPGG + " ���ſ�������㣡";
                }
                if (!value)
                {
                    break;
                }
            }
            
            return value;
        }

        /// <summary>
        /// ���¿��
        /// </summary>
        /// <param name="lstSumYpmx">ҩƷ��ϸ���ܼ���</param>
        /// <param name="err_code"></param>
        /// <param name="err_text"></param>
        /// <param name="db"></param>
        public static void UpdateKc(List<MZ_SumKcph> lstSumKcph, out int err_code, out string err_text, RelationalDatabase db)
        {
            try
            {
                int cjid = 0;
                decimal ypsl = 0;
                int dwbl = 0;
                int deptid = 0;
                Guid kcid = Guid.Empty;
                err_text = "";
                err_code=0;

                foreach (MZ_SumKcph sumKcph in lstSumKcph)
                {
                    cjid = sumKcph.cjid;
                    ypsl = sumKcph.ypsl;
                    dwbl = sumKcph.dwbl;
                    deptid = sumKcph.deptid;
                    kcid = new Guid(sumKcph.kcid);
                    ParameterEx[] parameters = new ParameterEx[7];
                    parameters[0].Text = "@cjid";
                    parameters[0].Value = cjid;
                    parameters[1].Text = "@ypsl";
                    parameters[1].Value = ypsl;
                    parameters[2].Text = "@dwbl";
                    parameters[2].Value = dwbl;
                    parameters[3].Text = "@deptid";
                    parameters[3].Value = deptid;
                    parameters[4].Text = "@kcid";
                    parameters[4].Value = kcid;
                    parameters[5].Text = "@err_code";
                    parameters[5].ParaDirection = ParameterDirection.Output;
                    parameters[5].DataType = System.Data.DbType.Int32;
                    parameters[5].ParaSize = 100;
                    parameters[6].Text = "@err_text";
                    parameters[6].ParaDirection = ParameterDirection.Output;
                    parameters[6].ParaSize = 100;
                    db.DoCommand("sp_yf_updatekc", parameters, 7);
                    err_code = Convert.ToInt32(parameters[5].Value);
                    err_text = Convert.ToString(parameters[6].Value);
                    if (err_code != 0)
                    {
                        throw new Exception(err_text);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }
        }
    }

    //���ſ��(��������)
    [Serializable]
    public class MZ_Kcph
    {
        public string id;      //�������id
        public int jgbm;       //��������
        public int ggid;       //���id
        public int cjid;       //����id
        public int kwid;        
        public string ypph;    //����
        public string ypxq;    //Ч��
        public string yppch;   //���κ�
        public string kcid; //��ⵥ����ϸid
        public decimal jhj;     //������
        public decimal kcl;     //�����
        public int zxdw;        //ִ�е�λ
        public int dwbl;        //��λ����
        public int bdelete;
        public int ykdelete;
        public decimal cks;     //��������
        public string mxid;     //mxid          mz_cfb_mx���ֶ�id
        public string tid;      //ͷid          mz_cfb���ֶ�cfid 
        public decimal ktsl;    //��������      
        public string tyid;     //��ҩ��ϸid    mz_cfb_mx���ֶ�tyid ��Ӧ����mz_cfb_mx���ֶ�id

        public MZ_Kcph(string _id, int _jgbm, int _ggid, int _cjid, int _kwid,
                    string _ypph, string _ypxq,
                    string _yppch, string _kcid,//
                    decimal _jhj, decimal _kcl, int _zxdw,
                    int _dwbl, int _bdelete, int _ykdelete,
                    decimal _cks, string _mxid,string _tid,decimal _ktsl,
                    string _tyid)
        {
            this.id = _id;
            this.jgbm = _jgbm;
            this.ggid = _ggid;
            this.cjid = _cjid;
            this.kwid = _kwid;
            this.ypph = _ypph;
            this.ypxq = _ypxq;
            this.yppch = _yppch;//
            this.kcid = _kcid;//
            this.jhj = _jhj;
            this.kcl = _kcl;
            this.zxdw = _zxdw;
            this.dwbl = _dwbl;
            this.bdelete = _bdelete;
            this.ykdelete = _ykdelete;
            this.cks = _cks;
            this.mxid = _mxid;
            this.tid = _tid;
            this.ktsl = _ktsl;
            this.tyid = _tyid;
        }

        public MZ_Kcph()
        { 
            
        }
    }

    //ҩƷ��ϸ
    [Serializable]
    public  class MZ_Ypmx
    {
        public string tid;      //ͷid
        public string mxid;     //��ϸid
        public string tyid;     //��ҩid
        public int cjid;        //ҩƷid 
        public int dwbl;        //��λ����
        public decimal ypsl;    //����
        public int deptid;
        public Guid kcid;   //
        public MZ_Ypmx(string _tid,string _mxid,int _cjid,int _dwbl,decimal _ypsl,int _deptid,string _tyid,
            decimal jhj,Guid _kcid)
        {
            tid = _tid;
            mxid=_mxid;
            cjid=_cjid;
            dwbl=_dwbl;
            ypsl=_ypsl;
            deptid = _deptid;
            tyid = _tyid;
            kcid = _kcid;
        }
    }

    //ҩƷ��ϸ����
    [Serializable]
    public  class MZ_SumYpmx
    {
        public int cjid;
        public decimal sumcount;
        public int dwbl;
        public int deptid;
        public MZ_SumYpmx(int _cjid, decimal _sumcount, int _dwbl, int _deptid)
        {
            this.cjid = _cjid;
            this.sumcount = _sumcount;
            this.dwbl = _dwbl;
            this.deptid = _deptid;
        }

        public void AddCount(decimal _count, int _dwbl)
        {
            sumcount = sumcount + _count * _dwbl / dwbl;//Ҫ���ǵ�λ����֮��Ļ���
        }
    }

    //����õ����ſ�����
    [Serializable]
    public class MZ_SumKcph
    { 
       public  int cjid;
       public  decimal ypsl;
       public  int dwbl;
       public  string kcid;
       public  int deptid;
       public MZ_SumKcph(int _cjid,decimal _ypsl,int _dwbl,string _kcid,int _deptid)
        {
            cjid = _cjid;
            ypsl = _ypsl;
            dwbl = _dwbl;
            kcid = _kcid;
            deptid = _deptid;
        }
        public void AddCount(MZ_Kcph kcph)
        {
            this.ypsl += kcph.cks;
        }
    }

}
