using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace TraSen
{
    public class TransDBFClass
    {
        
        /// <summary>
        /// ��Access���ݿ�ת��ΪExcel���
        /// </summary>
        /// <param name="DbPath">Access���ݿ������ļ�·��</param>

        public void  AccessToExcel(string DbPath)

        {
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\TransDBF\db.mdb;");
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";");
            try
            {
                conn.Open();

                DataTable dt = conn.GetSchema("Tables");//��ȡACCESS���ݿ������еı�\��ѯ\��\����\ģ��

                string p = "d:\\dbf";

                if (!System.IO.Directory.Exists(p))
                {
                    System.IO.Directory.CreateDirectory(p);
                }
                string[] vFiles = Directory.GetFiles(p);
                foreach (string vFile in vFiles)
                    File.Delete(vFile);

 


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string tablename = "";
                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//�ж��Ƿ����û���
                        {
                            tablename = dt.Rows[i].ItemArray[2].ToString();//��ȡ���ݱ���

                        }
                        if (tablename != "")
                        {
                            //ת��AccessΪdbf��ʽ����sql���
                            // String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;]." + tablename + ".dbf  FROM " + tablename;
                            //String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
                            String sql = "SELECT * INTO   [dBASE III;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;

                            //String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + tablename + ".dbf  FROM " + tablename;
                            OleDbCommand cmd = new OleDbCommand(sql, conn);

                            cmd.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                    }
                }
               }
            catch (Exception ex)
            {
                File.AppendAllText(@"c:\1.txt",ex.ToString()); 
            }
            finally
            {
                conn.Close();
            }

        }

        /// <summary>
        /// ���Ѿ�ת���˵�Excel��ת��ΪDbf��ʽ����
        /// </summary>
        public void ExcelToDbf()
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\dbf\dbf.xls;Extended Properties=Excel 8.0;");
            try
            {
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string tablename = "";
                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//�ж��Ƿ����û���
                        {

                            tablename = dt.Rows[i].ItemArray[2].ToString();//��ȡ���ݱ���

                        }
                        //ת��ExcelΪdbf��ʽ����sql���
                        String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;
                        // String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
                        if (tablename.IndexOf('$') >= 0)
                        {
                            continue;
                        }
                        else
                        {
                            OleDbCommand cmd = new OleDbCommand(sql, conn);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }

 

            }
            catch (Exception ex)
            {
                File.AppendAllText(@"c:\2.txt",ex.ToString()); 
            }
            finally
            {
                conn.Close();
            }
        }
    
    }
}

 

//����һ�ִ�������ʵ�

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Data.OleDb;
//using System.IO;

//namespace TransDBFClass
//{
//    public class TransDBFClass
//    {
        
//        /// <summary>
//        /// ��Access���ݿ�ת��ΪExcel���
//        /// </summary>
//        /// <param name="DbPath">Access���ݿ������ļ�·��</param>

//        public void  AccessToExcel(string DbPath)

//        {
//            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\project\TransDBF\db.mdb;");
//            //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";Persist   Security   Info=False;Jet OLEDB:Database Password=sa;");
//            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DbPath + ";Jet OLEDB:Database Password=sa;");
//            try
//            {
//                conn.Open();

//                DataTable dt = conn.GetSchema("Tables");//��ȡACCESS���ݿ������еı�\��ѯ\��\����\ģ��

//                string p = "d:\\dbf";

//                if (!System.IO.Directory.Exists(p))
//                {
//                    System.IO.Directory.CreateDirectory(p);
//                }
//                string[] vFiles = Directory.GetFiles(p);
//                foreach (string vFile in vFiles)
//                    File.Delete(vFile);

 


//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    try
//                    {
//                        string tablename = "";
//                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//�ж��Ƿ����û���
//                        {
//                            tablename = dt.Rows[i].ItemArray[2].ToString();//��ȡ���ݱ���

//                        }
//                        //ת��AccessΪdbf��ʽ����sql���
//                        // String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;]." + tablename + ".dbf  FROM " + tablename;
//                        String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
//                        OleDbCommand cmd = new OleDbCommand(sql, conn);

//                        cmd.ExecuteNonQuery();


//                    }
//                    catch (Exception ex)
//                    {
//                    }
//                }
//               }
//            catch (Exception ex)
//            {
//                File.AppendAllText(@"c:\1.txt",ex.ToString()); 
//            }
//            finally
//            {
//                conn.Close();
//            }

//        }

//        /// <summary>
//        /// ���Ѿ�ת���˵�Excel��ת��ΪDbf��ʽ����
//        /// </summary>
//        public void ExcelToDbf()
//        {
//            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\dbf\dbf.xls;Extended Properties=Excel 8.0;");
//            try
//            {
//                conn.Open();
//                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    try
//                    {
//                        string tablename = "";
//                        if (dt.Rows[i].ItemArray[3].ToString() == "TABLE")//�ж��Ƿ����û���
//                        {

//                            tablename = dt.Rows[i].ItemArray[2].ToString();//��ȡ���ݱ���

//                        }
//                        //ת��ExcelΪdbf��ʽ����sql���
//                        String sql = "SELECT * INTO   [dBASE 5.0;   Database=d:\\dbf;].DBF" + i + ".dbf  FROM " + tablename;
//                        // String sql = "SELECT * INTO   [Excel 5.0;Database=d:\\dbf\\dbf.xls ]." + "[" + tablename + "] FROM " + tablename;
//                        if (tablename.IndexOf('$') >= 0)
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            OleDbCommand cmd = new OleDbCommand(sql, conn);

//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                    }

//                }

 

//            }
//            catch (Exception ex)
//            {
//               File.AppendAllText(@"c:\2.txt",ex.ToString()); 
//            }
//            finally
//            {
//                conn.Close();
//            }
//        }
    
//    }
//}