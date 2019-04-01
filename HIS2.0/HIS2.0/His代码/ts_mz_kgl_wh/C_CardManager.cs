using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_kgl
{
    //150108 chencan/ 
    class C_CardManager
    {
        //���ɿ����
        public static string M_GenerateCard(object klxId,RelationalDatabase database )
        {
            string sql = "select MAX( cast(kh as bigint)) + 1 from YY_KDJB where len(kh)<9 and klx=2 and ISNUMERIC(KH)>0";
            object obj = database.GetDataResult( sql );
            if ( obj != null )
                return ts_mz_class.Fun.returnKh( Convert.ToInt32( klxId ) , obj.ToString() );
            else
                return ts_mz_class.Fun.returnKh( Convert.ToInt32( klxId ) , "1" );

            //string str_sql;
            //object obj = new object();
            //int i_kcd;
            //if (klxId == null)
            //{
            //    MessageBox.Show("��ȷ�������ͣ�");
            //    return "";
            //}

            //ts_mz_class.mz_card card = new ts_mz_class.mz_card( Convert.ToInt64( klxId ) , InstanceForm.BDatabase );

            ////��ѯ������
            //str_sql = string.Format("select KCD from JC_KLX where BQYBZ='1' and KLX={0}", klxId.ToString());
            //obj = InstanceForm.BDatabase.GetDataResult(str_sql);
            //if (obj == null || obj.ToString()=="")
            //{
            //    MessageBox.Show("��ά���ÿ����ͺ��ٽ������ƿ�������");
            //    return "";
            //}
            //i_kcd = Int32.Parse(obj.ToString());
            ////�����¿���
            //str_sql = string.Format(@"select replicate('0',{0}-len(max(convert(numeric,kh))+1))+cast(max(convert(numeric,kh))+1 as varchar) from YY_KDJB where PatIndex('%[./\]%',kh)=0 and ISNUMERIC(KH)>0", i_kcd);
            //obj = InstanceForm.BDatabase.GetDataResult(str_sql);
            //if (obj == null || obj.ToString() == "")
            //{
            //    MessageBox.Show("�����Ѵﵽ���ֵ���޷��������¿��š�\r\n���飺�ӳ������͵Ŀ��ų��ȣ�");
            //    return "";
            //}
            //return obj.ToString();
        }

        //��ӡ������
        public static void M_PrintCard(string barCode)
        {
            try
            {
                DataRow rxx = InstanceForm.BDatabase.GetDataRow( string.Format( "select a.KH,b.BRXM,dbo.FUN_ZY_SEEKSEXNAME( b.XB) as xb from yy_kdjb a inner join yy_brxx b on a.brxxid=b.brxxid where a.KH='{0}' and a.ZFBZ=0 and b.BSCBZ = 0" , barCode ) );

                Trasen.Print.Grid5.Interface.IPrinter printer = new Trasen.Print.Grid5.ReportPrinter();
                Trasen.Print.Grid5.ReportParameter[] ps = new Trasen.Print.Grid5.ReportParameter[3];
                ps[0] = new Trasen.Print.Grid5.ReportParameter( "barcode" , barCode );
                ps[1] = new Trasen.Print.Grid5.ReportParameter( "name" , Convertor.IsNull(rxx["BRXM"],"") );
                ps[2] = new Trasen.Print.Grid5.ReportParameter( "sex" , Convertor.IsNull( rxx["XB"] , "" ) );
                
                printer.ReportTemplateFile = Application.StartupPath + "\\CardReport.grf";
                printer.ReportParameters = ps;

                string bView = ApiFunction.GetIniString( "�����շ�" , "��ƱԤ��" , TrasenFrame.Classes.Constant.ApplicationDirectory + "//ClientWindow.ini" );
                if ( bView=="true" )
                    printer.Preview();
                else
                    printer.Print();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("��ӡ���ƿ����ݳ���" + ex.Message);
            }
        }
    }
}
