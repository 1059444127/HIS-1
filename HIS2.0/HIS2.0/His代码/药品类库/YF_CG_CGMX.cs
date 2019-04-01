using System;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using System.Drawing;
namespace YpClass
{
	/// <summary>
	/// YK_DJ_DJMX ��ժҪ˵����
	/// </summary>
	public class YF_CG_CGMX
	{
		public YF_CG_CGMX()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

        public static void SaveDJ(Guid id, string jhcgrq, string djsj, long djy, string bz, long deptid, long djh, out Guid djid, out int err_code, out string err_text, long jgbm,int pxfs, RelationalDatabase _DataBase)
		{
			try
			{
				ParameterEx[] parameters=new ParameterEx[12];

				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@jhcgrq";
				parameters[1].Value=jhcgrq;

				parameters[2].Text="@djsj";
				parameters[2].Value=djsj;

				parameters[3].Text="@djy";
				parameters[3].Value=djy;

				parameters[4].Text="@bz";
				parameters[4].Value=bz;

				parameters[5].Text="@deptid";
				parameters[5].Value=deptid;

				parameters[6].Text="@djh";
				parameters[6].Value=djh;

				parameters[7].Text="@djid";
				parameters[7].ParaDirection=ParameterDirection.Output;
				parameters[7].DataType=System.Data.DbType.Guid;
				parameters[7].ParaSize=100;
				
				parameters[8].Text="@err_code";
				parameters[8].ParaDirection=ParameterDirection.Output;
				parameters[8].DataType=System.Data.DbType.Int32;
				parameters[8].ParaSize=100;

				parameters[9].Text="@err_text";
				parameters[9].ParaDirection=ParameterDirection.Output;
				parameters[9].ParaSize=100;

                parameters[10].Text = "@jgbm";
                parameters[10].Value = jgbm;

                parameters[11].Text = "@pxfs";
                parameters[11].Value = pxfs;
				

				_DataBase.DoCommand("sp_YF_CG",parameters,30);
				djid=new Guid(parameters[7].Value.ToString());
				err_code=Convert.ToInt32(parameters[8].Value);
				err_text=Convert.ToString(parameters[9].Value);

			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void SaveDJMX(Guid id, Guid djid, int cjid, decimal xqs, decimal syyl,decimal jhs, string ypdw, int ydwbl, decimal ckjj, decimal ckkl, int wldw, long djh, long deptid, out int err_code, out string err_text, RelationalDatabase _DataBase)
		{
			try
			{

				ParameterEx[] parameters=new ParameterEx[15];

				parameters[0].Text="@id";
				parameters[0].Value=id;

				parameters[1].Text="@djid";
				parameters[1].Value=djid;

				parameters[2].Text="@cjid";
				parameters[2].Value=cjid;

				parameters[3].Text="@xqs";
				parameters[3].Value=xqs;

				parameters[4].Text="@jhs";
				parameters[4].Value=jhs;

				parameters[5].Text="@ypdw";
				parameters[5].Value=ypdw;

				parameters[6].Text="@ydwbl";
				parameters[6].Value=ydwbl;

				parameters[7].Text="@ckjj";
				parameters[7].Value=ckjj;

				parameters[8].Text="@ckkl";
				parameters[8].Value=ckkl;

				parameters[9].Text="@wldw";
				parameters[9].Value=wldw;

				parameters[10].Text="@djh";
				parameters[10].Value=djh;

				parameters[11].Text="@deptid";
				parameters[11].Value=deptid;
				
				parameters[12].Text="@err_code";
				parameters[12].ParaDirection=ParameterDirection.Output;
				parameters[12].DataType=System.Data.DbType.Int32;
				parameters[12].ParaSize=100;

				parameters[13].Text="@err_text";
				parameters[13].ParaDirection=ParameterDirection.Output;
				parameters[13].ParaSize=100;

                parameters[14].Text = "@syyl";
                parameters[14].Value = syyl;

				_DataBase.DoCommand("sp_YF_CGMX",parameters,30);
				err_code=Convert.ToInt32(parameters[12].Value);
				err_text=Convert.ToString(parameters[13].Value);


			}
			catch(System.Exception err)
			{
				throw new System.Exception(err.ToString());
			}	
		}


        public static void Shdj(long djh, long deptid, long employeeid, string sdate, RelationalDatabase _DataBase)
		{
			string ssql="update Yf_CG set shbz=1,shY="+employeeid+",shrq='"+sdate+"' where djh="+djh+" and deptid="+deptid+"  and shbz=0";
			int nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("��������Ӱ���˶��л����У���͹���Ա��ϵ");
		}


        public static DataTable Select_rkmx(int cjid, long deptid, RelationalDatabase _DataBase)
		{
			DataTable tb;
			string ssql="select 0 ���,b.yppm Ʒ��,b.ypgg ���,s_sccj ����,"+
				"'' ��λ,ypph ����,ypxq Ч��,ypkl ����,jhj ����,b.pfj ������,b.lsj ���ۼ�,"+
				"ypsl ����,b.YPDW ��λ,JHJE �������,pfje �������,lsje ���۽��,(lsje-jhje) ������,"+
				"dbo.fun_yp_ghdw(wldw) ������λ,dbo.fun_yp_ywy(jsr) ҵ��Ա,b.shdh �ͻ�����,fph ��Ʊ��,"+
				"fprq ��Ʊ����,a.djh ���ݺ�,rq ��������,djrq �Ǽ�ʱ��,dbo.fun_getEmpName(djy) �Ǽ�Ա "+
				" from vi_yk_dj a,vi_yk_djmx b,vi_yp_ypcd c where a.djh=b.djh and a.deptid=b.deptid and a.ywlx=b.ywlx"+
				" and b.cjid=c.cjid and a.deptid="+deptid+" and b.cjid="+cjid+" and a.ywlx='001' order by  �Ǽ�ʱ�� desc ";
			return tb=_DataBase.GetDataTable(ssql);
		}


        public static void UpdateScjjScjjdw(int cjid, decimal scjj, int ghdw, long deptid, RelationalDatabase _DataBase)
		{
			string ssql="update yk_kcmx set scjj="+scjj+",ghdw="+ghdw+" where deptid="+deptid+" and cjid="+cjid+"";
			_DataBase.DoCommand(ssql);

		}

        public static void DeleteDj(Guid id, RelationalDatabase _DataBase)
		{
			string ssql="delete from Yf_CGMX  where djid='"+id+"'";
			int nrow=_DataBase.DoCommand(ssql);

			ssql="delete from Yf_CG  where id='"+id+"'  and shbz=0";
			nrow=_DataBase.DoCommand(ssql);
			if (nrow!=1) throw new System.Exception("��������Ӱ���˶��л����У���͹���Ա��ϵ");
		}
	}
}
