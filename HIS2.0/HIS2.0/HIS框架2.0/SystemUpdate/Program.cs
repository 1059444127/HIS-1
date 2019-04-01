using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SystemUpdate
{
    static class Program
    {
        //API��������
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        //static void Main(params string[] invokAppId)
        //Modify By Tany 2012-04-10 ����������
        static void Main(string[] args)
        {
            Classes.Logger.Write( new string[] { "Start Run Update Main Function" } , true );
            string hisStartupExe = "Trasen.exe";
            string procName = "Trasen";
            //Modify By Tany 2012-03-09 ��ȡ�������exe����
            hisStartupExe = GetIniString("MAINPROGRAMINFO", "hisStartupExe", Application.StartupPath + "\\ClientConfig.ini");
            procName = GetIniString("MAINPROGRAMINFO", "Trasen", Application.StartupPath + "\\ClientConfig.ini");
            if (hisStartupExe.Trim() == "")
            {
                hisStartupExe = "Trasen.exe";
            }
            if (procName.Trim() == "")
            {
                procName = "Trasen";
            }

            //�ж���������Ĳ�����û�в���������Trasen.exe����
            if (args.Length > 0)
            {

                hisStartupExe = args[0];
                //MessageBox.Show(args[0]);
            }
            if (args.Length > 1)
            {
                procName = args[1];

                //MessageBox.Show(args[1]);
            }

            Classes.Logger.Write( new string[] { "Beform CreateMutex" } , true );

            IntPtr hMutex = ApiFunction.CreateMutex(null, false, "SysUpdateEx");
            if (ApiFunction.GetLastError() == ApiFunction.ERROR_ALREADY_EXISTS)
            {
                ApiFunction.ReleaseMutex(hMutex);
                return;
            }

            #region add by wangzhi ��¼�����������Ϣ
            List<string> lstLogHeader = new List<string>();
            lstLogHeader.Add( "*******************************************************************************************" );
            lstLogHeader.Add( string.Format( "hisStartupExe:{0}" , hisStartupExe ) );
            lstLogHeader.Add( string.Format( "procName:{0}" , procName ) );
            if ( args != null && args.Length > 0 )
            {
                lstLogHeader.Add( "Main.args[]:" );
                for ( int i = 0 ; i < args.Length ; i++ )
                {
                    if ( !string.IsNullOrEmpty( args[i] ) )
                        lstLogHeader.Add( args[i] );
                }
            }
            lstLogHeader.Add( "*******************************************************************************************" );
            Classes.Logger.Write( lstLogHeader.ToArray() , false );
            #endregion

            Frmflash f = new Frmflash("���ڹر����Ӧ�ó���...");//jianqg  2013-4-22
            #region �ر���صĳ���
            try
            {
                f.Show();
                f.Refresh();                
                KillProcess( "" );                
            }
            catch (Exception err)
            {
                MessageBox.Show("���������޷��ر����Ӧ�ó������ֹ��رճ��������" + err.Message);
                return;
            }
            finally
            {
                f.Close();
            }
            #endregion

            //������������������
            Classes.Logger.Write( "������������������." );
            Application.Run(new SystemUpdate.Forms.FrmFileUpdate());

            //��������������HISӦ�ó���
            try
            {
                bool invokeBySSO = false;
                string strags = "";
                if ( args.Length == 1 && args[0]=="SSO" )
                {
                    //����ΪSSO��ʾ�ɵ����¼�ĳ������Trasen���ٵ�����������
                    invokeBySSO = true;
                }
                //jianqg  2013-4-22
                if ( args.Length > 2 ) //jianqg  2013-4-22 ���� ͨ���ӿ���pacs ����Ĳ���
                {
                    strags += args[2];
                    //MessageBox.Show(args[2]);
                }
                if ( args.Length > 3 ) //jianqg  2013-4-22 ���� ͨ���ӿ���pacs ����Ĳ���
                {
                    strags += " " + args[3] + " " + "IsFromUpdate";
                }
                //MessageBox.Show(hisStartupExe);
                //MessageBox.Show(strags);

                if ( invokeBySSO )
                {
                    MessageBox.Show( "������ɣ����������Ż��������" ,"",MessageBoxButtons.OK,MessageBoxIcon.Information );
                    return;
                }

                if ( strags == "" )
                {
                    Classes.Logger.Write( string.Format( "������������׼������{0}������{1}" , hisStartupExe , "IsFormUpdate" ) );
                    Process.Start( Application.StartupPath + "\\" + hisStartupExe , "IsFormUpdate" );
                }
                else
                {
                    Classes.Logger.Write( string.Format( "������������׼������{0}������{1}" , hisStartupExe , strags ) );
                    Process.Start( Application.StartupPath + "\\" + hisStartupExe , strags );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }



        private static void KillProcess( string procName )
        {
            try
            {
                /**********ʹ��cmd����������� add by wangzhi 2013-06-18*************/
                Classes.Logger.Write( "��ʼ�����̲�������ؽ���" );
                //����Ҫkill�Ľ����б�
                List<string> lstExe = new List<string>();
                #region Ҫkill����HIS��ؽ���
                lstExe.Add( "TRASEN" );
                lstExe.Add( "TRASEN.EXE" );
                lstExe.Add( "NEUSOFT" );
                lstExe.Add( "NEUSOFT.EXE" );
                lstExe.Add( "ONKIY" );
                lstExe.Add( "ONKIY.EXE" );
                lstExe.Add( "NEUSOFTEMR" );
                lstExe.Add( "NEUSOFTEMR.EXE" );
                lstExe.Add( "TRASENEMR" );
                lstExe.Add( "TRASENEMR.EXE" );
                lstExe.Add( "EMRDOCORNURSEVIEW" );
                lstExe.Add( "EMRDOCORNURSEVIEW.EXE" );
                lstExe.Add( "EMRCONFIG" );
                lstExe.Add( "EMRCONFIG.EXE" );
                lstExe.Add( "CLIENTCONFIG" );
                lstExe.Add( "CLIENTCONFIG.EXE" );
                #endregion

                #region ��ȡ��ǰ���н����������е�HIS����ID
                List<int> lstPID = new List<int>();
                try
                {
                    System.Diagnostics.Process[] proces = Process.GetProcesses();
                    foreach ( Process p in proces )
                    {
                        //������ǰ���н��̣�Ϊ��ֹ�������ж�ԭʼ�ļ�����ֻҪ��HIS��صĳ������ӵ�KILL�б���
                        string originalFilename = "";
                        try
                        {
                            originalFilename = p.MainModule.FileVersionInfo.OriginalFilename.ToUpper();//תΪ��д
                        }
                        catch 
                        {
                            //����ϵͳ����ģ��ȵĴ������
                            continue;
                        }
                        //ִ���ļ����Ʋ�Ϊ�ղ�����ɾ���б��д��ڣ�����ӵ�KILL�б���
                        if ( !string.IsNullOrEmpty( originalFilename ) && lstExe.Contains( originalFilename ) )
                            lstPID.Add( p.Id );
                    }
                    Classes.Logger.Write( "��������ؽ��̹�" + lstPID.Count.ToString() );
                }
                catch ( Exception error )
                {
                    Classes.Logger.Write( "�������̷�������",error );
                }
                #endregion

                //ɱ����,����taskkill����ǿ�ƽ�������   
                int killType = 1;
                foreach (int pid in lstPID )
                {
                    if ( killType == 0 )
                    {
                        #region ����cmd.exe��������
                        Classes.Logger.Write( "��ʼ���Խ�������" + pid.ToString() );

                        System.Diagnostics.Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";

                        cmd.StartInfo.UseShellExecute = false;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardError = true;
                        cmd.StartInfo.CreateNoWindow = true;

                        string command = "taskkill /PID " + pid + " /F /T";
                        cmd.Start();
                        cmd.StandardInput.WriteLine( command );
                        Classes.Logger.Write( command );

                        cmd.StandardInput.WriteLine( "exit" );
                        Classes.Logger.Write( "exit" );
                        cmd.WaitForExit();
                        cmd.Close();

                        Classes.Logger.Write( "ִ�н�����" );
                        #endregion
                    }
                    else
                    {
                        #region ʹ��Process���������
                        try
                        {
                            //��һ�ο�ʼ���ҽ���ID
                            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById( pid );
                            int count = 1;
                            int maxCount = 3;
                            //����ҵ����̣�����ѭ�����Խ������̣�����ΪmaxCountָ��
                            while ( count <= maxCount )
                            {
                                Classes.Logger.Write( string.Format( "���ڵ�{0}���Խ�������{1}" , count , pid ) );
                                p.Kill();
                                p.WaitForExit();
                                try
                                {
                                    //���¸���ID��ȡ����
                                    p = System.Diagnostics.Process.GetProcessById( pid );
                                }
                                catch
                                {
                                    //�������ArgementException,˵�������Ѿ�����,����whileѭ��
                                    Classes.Logger.Write( string.Format( "����{0}�Ѿ�����" , pid ) );
                                    break;
                                }

                                if ( count == maxCount )
                                {
                                    //������Դ��������޶�����������ѭ��
                                    Classes.Logger.Write( string.Format( "��������{0}�ν�������{1}ʧ�ܣ�" , maxCount , pid ) );
                                    break;
                                }
                                else
                                {
                                    //���¸���ID��ȡ���̵Ĳ�������ɹ����������һ��ѭ������������
                                    count++;
                                }
                            }
                        }
                        catch ( ArgumentException argex )
                        {
                            //��һ�ο�ʼ���ҽ��̷�������
                            Classes.Logger.Write( string.Format( "����{0}δ�������ѽ�����" , pid ) );
                        }
                        catch ( Exception error )
                        {
                            Classes.Logger.Write( string.Format( "�ڽ�������{0}ʱ��������" , error ) );
                        }
                        #endregion
                    }
                }
                Classes.Logger.Write( "�����̲�������ؽ��̵Ĵ������" );                
                return;
                /**********************************************************************/

                #region wangzhi 2013-06-18 ע�ͣ��ݲ���
                /*
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName( procName );
                //MessageBox.Show(procName + " KillProcessǰ:" + procs.Length.ToString());
                while ( procs.Length > 0 )
                {
                    for ( int i = 0 ; i < procs.Length ; i++ )
                    {
                        try
                        {
                            if ( !procs[i].HasExited )
                            {
                                //MessageBox.Show(procName + " kill ǰ" + procs[i].ToString());
                                procs[i].Kill();
                                //MessageBox.Show(procName + " kill ��" + procs[i].ToString());
                            }
                            procs[i].Close();
                            procs[i].Dispose();

                            procs = System.Diagnostics.Process.GetProcessesByName( procName );
                        }
                        catch ( Exception ex )
                        {
                            //MessageBox.Show(procName + " kill ����  ����" + ex.Message);
                        }
                    }

                }
                //MessageBox.Show(procName + " KillProcess��:" + procs.Length.ToString());
                 * */
                #endregion
            }
            catch
            {
                //throw new Exception("���������޷��ر�" + procName + "Ӧ�ó������ֹ��رճ��������" + err.Message);
                //MessageBox.Show("���������޷��ر����Ӧ�ó������ֹ��رճ��������" + err.Message);
                //return;
            }
        }

        

        /// <summary>
        /// ��ȡINI�ļ�
        /// </summary>
        /// <param name="lpApplicationName">����</param>
        /// <param name="lpKeyName">�ؼ���</param>
        /// <param name="lpFileName">INI�ļ�·��</param>
        /// <returns></returns>
        public static string GetIniString( string lpApplicationName , string lpKeyName, string lpFileName )
        {
            System.Text.StringBuilder strReturn = new StringBuilder(255);
            int nSize = GetPrivateProfileString(lpApplicationName, lpKeyName, "", strReturn, 255, lpFileName);
            return strReturn.ToString();
        }
    }
}
