using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TrasenMainWindow.Forms
{
    public partial class FrmMenuAuth : Form
    {
        public FrmMenuAuth()
        {
            InitializeComponent();
        }

        string qt = "\"";
        private void CreateSystemInfoFile( string fileName )
        {
            string sql = "";
            StringBuilder sb = new StringBuilder();
            //ȡע����
            sql = "select RegCode from YY_Register";
            object objCode = TrasenFrame.Forms.FrmMdiMain.Database.GetDataResult( sql );

            sb.Append( string.Format( "<REG_CODE>{0}</REG_CODE>" , objCode.ToString() ) );

            //ȡϵͳ��ģ���б�
            sql = "select System_Id,Name,Sort_id from Pub_System where Delete_Bit = 0";
            DataTable dtSystem = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_System>" );
            foreach ( DataRow row in dtSystem.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " system_id = {0}{1}{0}" , qt , row["System_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " name = {0}{1}{0}" , qt , row["Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " sort_id = {0}{1}{0}" , qt , row["Sort_id"].ToString().Trim() , qt ) );
                sb.Append( " />" );
            }
            sb.Append( "</Pub_System>" );

            //ȡ�˵���
            sql = @"select Menu_Id,Name,Dll_Name,Function_Name,AuthCode from Pub_Menu 
                    where Delete_Bit =0 and Menu_Id in (select Menu_Id from Pub_System_Menu where System_Id in (select System_Id From Pub_System where Delete_Bit = 0 ))";
            DataTable dtMenu = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_Menu>" );
            foreach ( DataRow row in dtMenu.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " menu_id = {0}{1}{0}" , qt , row["Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " name = {0}{1}{0}" , qt , row["Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " dll_name = {0}{1}{0}" , qt , row["Dll_Name"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " function_name = {0}{1}{0}" , qt , row["Function_Name"].ToString().Trim() , qt ) );
                sb.Append( ">" );
                sb.Append( string.Format( " <AUTHCODE>{0}</AUTHCODE>" , Convert.IsDBNull( row["AuthCode"] ) ? "" : row["AuthCode"].ToString() ) );
                sb.Append( " </ROW>" );
            }
            sb.Append( "</Pub_Menu>" );

            //ȡϵͳ�˵��ṹ��
            sql = @"select Sys_Menu_Id,System_Id,Menu_Id,Parent_id,Sort_Id from Pub_System_Menu 
                    where System_Id in (select System_Id From Pub_System where Delete_Bit = 0 )";
            DataTable dtRelation = TrasenFrame.Forms.FrmMdiMain.Database.GetDataTable( sql );
            sb.Append( "<Pub_System_Menu>" );
            foreach ( DataRow row in dtRelation.Rows )
            {
                sb.Append( "<ROW " );
                sb.Append( string.Format( " sys_menu_id = {0}{1}{0}" , qt , row["Sys_Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " system_id = {0}{1}{0}" , qt , row["System_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " menu_id = {0}{1}{0}" , qt , row["Menu_Id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " parent_id = {0}{1}{0}" , qt , row["Parent_id"].ToString().Trim() , qt ) );
                sb.Append( string.Format( " sort_id = {0}{1}{0}" , qt , row["Sort_Id"].ToString().Trim() , qt ) );
                sb.Append( " />" );
            }
            sb.Append( "</Pub_System_Menu>" );

            StringBuilder sbAll = new StringBuilder();
            sbAll.Append( "<SYSTEM>" );
            sbAll.Append( sb.ToString() );
            sbAll.Append( "</SYSTEM>" );

            string content = sbAll.ToString();

            using ( System.IO.StreamWriter sw = System.IO.File.CreateText( fileName ) )
            {
                sw.WriteLine( content );
                sw.Flush();
                sw.Close();
            }
        }

        private void button1_Click( object sender , EventArgs e )
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "trasen";
                dlg.Filter = "����ϵͳ��Ϣ�ļ�|*.trasen";
                dlg.FileName = ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config;
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    string fileName = dlg.FileName;
                    CreateSystemInfoFile( fileName );
                    MessageBox.Show( "ϵͳ��Ϣ�ļ���������" + fileName + ",�뽫���ļ�����ʵʩ����ʦ����ֱ�ӷ��͸����ǹ�˾�ۺ�" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
            }
            catch ( Exception error )
            {
                MessageBox.Show( "����ϵͳ��Ϣ�ļ���������" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
        }

        private void button2_Click( object sender , EventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "������Ȩ�ļ�|*.tsauth";
            dlg.Multiselect = false;
            if ( dlg.ShowDialog() == DialogResult.OK )
            {
                string fileName = dlg.FileName;
                using ( System.IO.StreamReader sr = new System.IO.StreamReader( dlg.FileName ) )
                {
                    string content = sr.ReadToEnd();
                    if ( !string.IsNullOrEmpty( content ) )
                    {
                        try
                        {
                            XmlDocument document = new XmlDocument();
                            document.LoadXml( content );
                            if ( document.GetElementsByTagName( "HospitalName" ).Count == 0 )
                            {
                                MessageBox.Show( "��Ȩ�ļ���ʧҽԺ��Ϣ" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                return;
                            }
                            else
                            {
                                string name = document.GetElementsByTagName( "HospitalName" )[0].InnerText;
                                string hpName = TrasenRegister.Security.DeCryp( name );
                                if ( hpName != ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config )
                                {
                                    MessageBox.Show( string.Format( "ѡ�����Ȩ�ļ�����ҽԺ{0}����Ȩ�ļ�" , ( new TrasenFrame.Classes.SystemCfg( 2 ) ).Config ) , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                    return;
                                }
                                else
                                {

                                    if ( document.GetElementsByTagName( "Menus" ).Count == 0 )
                                    {
                                        MessageBox.Show( "û����Ȩ�Ĳ˵���Ϣ" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                                        return;
                                    }
                                    else
                                    {
                                        DataTable dtMenu = new DataTable();
                                        dtMenu.Columns.Add( "Menu_Id" );
                                        dtMenu.Columns.Add( "AuthCode" );

                                        XmlNodeList lstNodes = document.GetElementsByTagName( "Menus" )[0].ChildNodes;

                                        foreach ( XmlNode xn in lstNodes )
                                        {
                                            string menuId = xn.Attributes["id"].Value;
                                            string code = xn.ChildNodes[0].InnerText;
                                            DataRow dr = dtMenu.NewRow();
                                            dr["Menu_Id"] = menuId;
                                            dr["AuthCode"] = code;
                                            dtMenu.Rows.Add( dr );
                                        }

                                        UpdateMenuAuthCode( dtMenu );
                                    }
                                }
                            }
                        }
                        catch ( Exception error )
                        {
                            MessageBox.Show( "��Ȩʱ��������" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
                        }
                    }
                }
            }
        }

        private void UpdateMenuAuthCode( DataTable dtMenu )
        {
            if ( MessageBox.Show( "��֤�ļ��ɹ���������ʼ��Ȩ���Ƿ������" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;

            button2.Enabled = false;
            try
            {
                for ( int i = 0 ; i < dtMenu.Rows.Count ; i++ )
                {
                    string menuId = dtMenu.Rows[i]["Menu_Id"].ToString();
                    string code = dtMenu.Rows[i]["AuthCode"].ToString();

                    string sql = string.Format( "update Pub_Menu set AuthCode = '{0}' where Menu_Id = {1}" , code , menuId );
                    TrasenFrame.Forms.FrmMdiMain.Database.DoCommand( sql );
                }
                MessageBox.Show( "��Ȩ��ɣ�����������������" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
            catch ( Exception error )
            {
                MessageBox.Show( error.Message , "��Ȩ��������" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                TrasenFrame.Forms.FrmMdiMain.WriteFrameLocalLog( new string[] { error.Message }, true );
            }
            finally
            {
                button2.Enabled = true;
            }
        }

        private void button3_Click( object sender , EventArgs e )
        {
            this.Close();
        }
    }
}