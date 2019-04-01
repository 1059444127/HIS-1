using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;

using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;


namespace YpClass
{
    /// <summary>
    /// *********************************************************************
    /// ���ƣ�Yk_Ypgysfp.cs
    /// ˵���� ��ҩƷ���ۺ�ҩ�����µĽ��۸���Ӧ�̽��㣬�˴��ṩ��Ʊ¼��Ľ���
    ///        �Ե��۵�ҩƷ�ṩ��Ʊ¼�룬��ѯ�ķ�����
    /// ����ˣ�HYD
    /// ���ʱ�䣺2016-07-16
    /// ���һ�θ���ʱ��:   
    /// *********************************************************************
    /// </summary>
   public class Yk_Ypgysfp
    {
       
       public Yk_Ypgysfp()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}


       /// <summary>
       /// ���һ�ŷ�Ʊ�ܽ�������¼
       /// </summary>
       /// <param name="Id">ϵͳ�����ɵ�GUID</param>
       /// <param name="djid">ԭ���ݵ�GUID</param>
       /// <param name="djh">�ǼǺ�</param>
       /// <param name="gysid">��Ӧ������</param>
       /// <param name="Fph">��Ʊ��</param>
       /// <param name="fpzje">��Ʊ�ܽ��</param>
       /// <param name="tjsj">���ʱ��</param>
       /// <param name="tjrid">�����</param>
       /// <param name="deptid">��������ڲ���</param>
       /// <param name="Memo">��ע˵��</param>
        /// <param name="masterId">���ص�GUID</param>
       /// <param name="err_code">�ɹ�����ʶ</param>
       /// <param name="err_text">�ɹ��������ʾ</param>
       /// <param name="_DataBase">����������</param>
        public static void SaveYPgysfp(Guid Id, Guid djid, long djh, string gysid,string Fph,decimal fpzje,DateTime tjsj,int tjrid, 
            long deptid, string Memo, out Guid masterId, out int err_code, out string err_text, RelationalDatabase _DataBase
             )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[13];
                parameters[0].Text = "@Id";
                parameters[0].Value = Id;

                parameters[1].Text = "@djid";
                parameters[1].Value = djid;

                parameters[2].Text = "@djh";
                parameters[2].Value = djh;

                parameters[3].Text = "@gysid";
                parameters[3].Value = gysid;

                parameters[4].Text = "@Fph";
                parameters[4].Value = Fph;

                parameters[5].Text = "@fpzje";
                parameters[5].Value = fpzje;

                parameters[6].Text = "@tjsj";
                parameters[6].Value = tjsj;

                parameters[7].Text = "@tjrid";
                parameters[7].Value = tjrid;

                parameters[8].Text = "@deptid";
                parameters[8].Value = deptid;

                parameters[9].Text = "@Memo";
                parameters[9].Value = Memo;

                parameters[10].Text = "@MasterID";
                parameters[10].ParaDirection = ParameterDirection.Output;
                parameters[10].DataType = System.Data.DbType.Guid;
                parameters[10].ParaSize = 100;

                parameters[11].Text = "@err_code";
                parameters[11].ParaDirection = ParameterDirection.Output;
                parameters[11].DataType = System.Data.DbType.Int32;
                parameters[11].ParaSize = 100;

                parameters[12].Text = "@err_text";
                parameters[12].ParaDirection = ParameterDirection.Output;
                parameters[12].ParaSize = 100;

                _DataBase.DoCommand("sp_yk_YpgysFp", parameters, 30);
                err_code = Convert.ToInt32(parameters[11].Value);
                err_text = Convert.ToString(parameters[12].Value);
                masterId = new Guid(parameters[10].Value.ToString());

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

       /// <summary>
       /// ��������Ʊ��¼
       /// </summary>
       /// <param name="Id">����ID</param>
       /// <param name="gysid">��Ӧ��ID</param>
       /// <param name="Fph">��Ʊ��</param>
       /// <param name="tjrid">�����ID</param>
       /// <param name="deptid">��������ڿ���ID</param>
       /// <param name="err_code">�ɹ������ʾ</param>
       /// <param name="err_text">������Ϣ��ʾ</param>
       /// <param name="_DataBase"></param>
       public static void SaveYPgysfpUpdate(Guid Id,string gysid, string Fph,int tjrid,long deptid, out int err_code, out string err_text, RelationalDatabase _DataBase)
       {
           try
           {
               ParameterEx[] parameters = new ParameterEx[7];
               parameters[0].Text = "@Id";
               parameters[0].Value = Id; 

               parameters[1].Text = "@gysid";
               parameters[1].Value = gysid;

               parameters[2].Text = "@Fph";
               parameters[2].Value = Fph;
              

               parameters[3].Text = "@tjrid";
               parameters[3].Value = tjrid;

               parameters[4].Text = "@deptid";
               parameters[4].Value = deptid;
              

               parameters[5].Text = "@err_code";
               parameters[5].ParaDirection = ParameterDirection.Output;
               parameters[5].DataType = System.Data.DbType.Int32;
               parameters[5].ParaSize = 100;

               parameters[6].Text = "@err_text";
               parameters[6].ParaDirection = ParameterDirection.Output;
               parameters[6].ParaSize = 100;

               _DataBase.DoCommand("sp_UpDateYk_YpgysFp", parameters, 30);
               err_code = Convert.ToInt32(parameters[5].Value);
               err_text = Convert.ToString(parameters[6].Value);              

           }
           catch (System.Exception err)
           {
               throw new System.Exception(err.ToString());
           }
       }
       

        /// <summary>
        /// ���һ�ŷ�Ʊ�µ��۵�ҩƷ��ϸ��¼
        /// </summary>
        /// <param name="id">������GUID</param>
        /// <param name="Zbid">���������ɵ�GUID</param>
        /// <param name="ypid">ҩƷID</param>
        /// <param name="ypmc">ҩƷ����</param>
        /// <param name="ypgg">ҩƷ���</param>
        /// <param name="ypdw">ҩƷ��λ</param>
        /// <param name="ypkcl">ҩƷ�����</param>
        /// <param name="ypcj">ҩƷ����</param>
        /// <param name="Ypfj">ҩƷԭ������</param>
        /// <param name="xpfj">ҩƷ�½�����</param>
        /// <param name="Tpfzje">ҩƷ�����۲���ܽ��</param>
        /// <param name="ylsj">ҩƷԭ���ۼ�</param>
        /// <param name="xlsj">ҩƷ�����ۼ�</param>
        /// <param name="tlsjje">ҩƷ���ۼ۲���ܽ��</param>
        /// <param name="ypph">ҩƷ����</param>
        /// <param name="yppch">ҩƷ���κ�</param>
        /// <param name="yphh">ҩƷ��λ��</param>
        /// <param name="deptid">����ID</param>
        /// <param name="err_code">�ɹ�����ʶ</param>
        /// <param name="err_text">�ɹ��������ʾ</param>
        /// <param name="_DataBase">����������</param>
       public static void SaveYPgysfpMx(Guid id, Guid Zbid, int ypid, string ypmc, string ypgg, string ypdw, decimal ypkcl, string ypcj,
           decimal Ypfj, decimal xpfj,
           decimal Tpfzje, decimal ylsj, decimal xlsj, decimal tlsjje,          
            string ypph,string yppch,string yphh, long deptid,out int err_code, out string err_text, RelationalDatabase _DataBase            
            )
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[20];
                parameters[0].Text = "@id";
                parameters[0].Value = id;

                parameters[1].Text = "@Zbid";
                parameters[1].Value = Zbid;

                parameters[2].Text = "@ypid";
                parameters[2].Value = ypid;

                parameters[3].Text = "@ypmc";
                parameters[3].Value = ypmc;

                parameters[4].Text = "@ypgg";
                parameters[4].Value = ypgg;

                parameters[5].Text = "@ypdw";
                parameters[5].Value = ypdw;

                parameters[6].Text = "@ypkcl";
                parameters[6].Value = ypkcl;

                parameters[7].Text = "@ypcj";
                parameters[7].Value = ypcj;

                parameters[8].Text = "@Ypfj";
                parameters[8].Value = Ypfj;

                parameters[9].Text = "@xpfj";
                parameters[9].Value = xpfj;

                ///
                parameters[10].Text = "@Tpfzje";
                parameters[10].Value = Tpfzje;

                parameters[11].Text = "@ylsj";
                parameters[11].Value = ylsj;

                parameters[12].Text = "@xlsj";
                parameters[12].Value = xlsj;

                parameters[13].Text = "@tlsjje";
                parameters[13].Value = tlsjje;



                parameters[14].Text = "@ypph";
                parameters[14].Value = ypph;

                parameters[15].Text = "@yppch";
                parameters[15].Value = yppch;               

               

                parameters[16].Text = "@deptid";
                parameters[16].Value = deptid;

                parameters[17].Text = "@yphh";
                parameters[17].Value = yphh;

                parameters[18].Text = "@err_code";
                parameters[18].ParaDirection = ParameterDirection.Output;
                parameters[18].DataType = System.Data.DbType.Int32;
                parameters[18].ParaSize = 100;

                parameters[19].Text = "@err_text";
                parameters[19].ParaDirection = ParameterDirection.Output;
                parameters[19].ParaSize = 100;

                _DataBase.DoCommand("sp_yk_tjgysmx", parameters, 30);
                err_code = Convert.ToInt32(parameters[18].Value);
                err_text = Convert.ToString(parameters[19].Value);

            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.ToString());
            }
        }

       /// <summary>
       /// ͨ�����ݺŲ鿴һ�±������Ƿ��ѶԱ����ݺŵ������Ѿ�¼������
       /// </summary>
       /// <param name="deptid">����ID</param>
       /// <param name="djh">���ݺ�</param>
       /// <returns></returns>
       public static bool GetYpgysMasterZbByDjh(int deptid, int djh,RelationalDatabase db)
       {
           //��ȡ�½�ID�������½���ϸ�м������
           string sql = string.Format("select id from yk_tjgyszb where deptid={0} and djh={1} ", deptid, djh);
           DataTable tab = db.GetDataTable(sql);
           return tab != null && tab.Rows.Count > 0 ? true : false;

       }





    }
}
