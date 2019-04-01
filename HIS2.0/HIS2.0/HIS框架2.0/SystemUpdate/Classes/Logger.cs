using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUpdate.Classes
{
    class Logger
    {
        public static void Write( string text )
        {
            string[] str = new string[1];
            str[0] = text;
            Write( str );
        }

        

        public static void Write( string fileName , Exception error )
        {
            List<string> lstStr = new List<string>();

            lstStr.Add( string.Format( "�ļ�[{0}]������������" , fileName ) );
            lstStr.Add( "�ļ�����" + fileName );
            if ( error != null )
            {
                lstStr.Add( "������Ϣ��" + error.Message );
                if ( !string.IsNullOrEmpty( error.Source ) )
                {
                    lstStr.Add( "����Դ��" );
                    lstStr.Add( error.Source );
                }
                if ( !string.IsNullOrEmpty( error.StackTrace ) )
                {
                    lstStr.Add( "���ö�ջ��" );
                    lstStr.Add( error.StackTrace );
                }
            }
            Write( lstStr.ToArray() );
        }

        public static void Write( string[] content  )
        {
            Write( content , true );
        }

        public static void Write( string[] content ,bool showTime )
        {
            string logFile = string.Format( "{0}\\{1}" , Logger.LogPath , "UpdateLog.log" );
            string strTime = "[" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "]";
            if ( !showTime )
                strTime = "";

            if ( !System.IO.File.Exists( logFile ) )
            {
                using ( System.IO.StreamWriter sw = System.IO.File.CreateText( logFile ) )
                {
                    sw.WriteLine( string.Format( "{0}����������־�ļ�" , strTime ) );
                    sw.Flush();
                    sw.Close();
                }
            }

            for ( int i = 0 ; i < content.Length ;i++ )
            {
                using ( System.IO.StreamWriter sw = System.IO.File.AppendText( logFile ) )
                {
                    if ( i == 0 )
                    {
                        sw.WriteLine( strTime + content[i] );
                    }
                    else
                    {
                        if ( strTime != "" )
                        {
                            sw.WriteLine( "                     " + content[i] );
                        }
                        else
                        {
                            sw.WriteLine( content[i] );
                        }
                    }
                    sw.Flush();
                    sw.Close();
                }
            }         
        }

        private static string LogPath
        {
            get
            {
                string path = string.Format( "{0}\\AppLog\\Update" , System.Windows.Forms.Application.StartupPath  );
                if ( !System.IO.Directory.Exists( path ) )
                    System.IO.Directory.CreateDirectory( path );
                return path;
            }
        }
    }
}
