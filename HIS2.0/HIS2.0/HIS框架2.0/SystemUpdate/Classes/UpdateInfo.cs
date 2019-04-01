using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace SystemUpdate
{
    /// <summary>
    /// id,type,name,update_time,version,dellocalreport
    /// </summary>
    public class UpdateInfo
    {
        private const int BUFFER_LENGTH = 4096;

        private int id;
        private int type;
        /// <summary>
        /// ��ǰ�ļ���
        /// </summary>
        private string name;
        private DateTime updateTime;
        private string version;
        private int dellocalreport;
        private object content;
        private bool needUpdate;
        private string downloadFolder;
        private readonly  string downloadFolder_default = ".."; //ȱʡֵ jianqg 2013-7-2
        private Database database;


        public static event LoadingUpdateFileListHandle LoadingUpdateFileList;

        public event UpdateProcessingHandle UpdateProcessing;

        public event FileUpdateHandle FileUpdate;

        public UpdateInfo( Database Database )
        {
            database = Database;
        }
        public string DownloadFolder
        {
            get
            {
                return downloadFolder;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    downloadFolder =downloadFolder_default;// "..";
                else
                    downloadFolder = value;
            }
        }


        public bool NeedUpdate
        {
            get
            {
                return needUpdate;
            }
            set
            {
                needUpdate = value;
            }
        }

        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        public int DelLocalReport
        {
            get
            {
                return dellocalreport;
            }
            set
            {
                dellocalreport = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                updateTime = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /// <summary>
        /// �����ļ�
        /// </summary>
        public void Update()
        {
            string iniFile = Application.StartupPath + "\\UpdateFile.ini";           
            string folder = this.DownloadFolder;
            if ( string.IsNullOrEmpty( folder ) )
                folder = "";
            if ( folder == downloadFolder_default )
                folder = "";

            //���folderΪ�գ����ʾ��ǰҪ�������ļ�ʱSystemUpdate.exe����HIS����������Ĭ��������Ŀ¼�£������ط���ͬ���ļ�����Ϊ����HIS�ĸ��³���
            if ( string.IsNullOrEmpty( folder ) )
            {
                //�����������Ҫ���£��˳������ڴ˳����£��ɿ��ȥ������������ĸ���
                if ( ( File.Exists( Application.StartupPath + "\\SysUpdate.exe" ) && this.name.ToUpper() == "SYSUPDATE.EXE" )
                                || ( File.Exists( Application.StartupPath + "\\SysUpdateEx.exe" ) && this.name.ToUpper() == "SYSUPDATEEX.EXE" ) )
                    return;
            }

            string[] strArray = this.name.Split( ".".ToCharArray() );
            string exName = ""; //��׺��
            if ( strArray.Length > 1 )
                exName = strArray[strArray.Length - 1].ToUpper();
            string lpKeyName = this.name;
            string fullFileName = Application.StartupPath + "\\" + this.name; //���ص��ļ�,Ĭ���ǵ�ǰHISĿ¼
            if ( exName.ToUpper() == "RPT" )
            {
                string str = Application.StartupPath + "\\report";
                if ( !System.IO.Directory.Exists( str ) )
                    System.IO.Directory.CreateDirectory( str );
                fullFileName = Application.StartupPath + "\\report\\" + this.name; //��ǰ·���µı����ļ���
            }

            if ( folder != "" )
            {                
                lpKeyName = folder + "\\" + this.name;
                //�����ָ������Ŀ¼�����¹���fullFileName,
                string parentFolder = "";
                if ( this.DownloadFolder.Substring( 0 , 2 ) == downloadFolder_default ) // 
                    parentFolder = Application.StartupPath + downloadFolder.Remove( 0 , 2 ); //ָ��������Ŀ¼Ϊ���·��
                else
                    parentFolder = this.DownloadFolder;                                     //ָ��������Ŀ¼Ϊ����·��
                //·�������ڣ��򴴽�
                if ( !System.IO.Directory.Exists( parentFolder ) )
                    System.IO.Directory.CreateDirectory( parentFolder );
                fullFileName = parentFolder + "\\" + this.name;
            }
            
            string localVersion = ApiFunction.GetIniString( "FILEINFO" , lpKeyName , iniFile );
            string serverVersion = version;                       

            if ( UpdateProcessing != null )
                UpdateProcessing( Action.CompareVersion , "�Ƚ��ļ��汾��..." );
            //�Ƚϱ����ļ��汾�����ݿ��ļ��汾
            if ( localVersion.Trim().ToUpper() != serverVersion.Trim().ToUpper() )
            {
                try
                {
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.DownLoadContent , "���������ļ�" + this.name + "��,���Ժ�......" );
                    try
                    {
                        this.content = database.GetUpdateFileContent( this.id );
                    }
                    catch
                    {
                        if ( UpdateProcessing != null )
                            UpdateProcessing( Action.DownLoadComplete , "�ļ�" + this.name + "����ʧ�ܣ�" );
                        return;
                    }
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.DownLoadComplete , "�ļ�" + this.name + "������ɣ�" );

                    Object obj = this.content;
                    if ( obj != null && !Convert.IsDBNull( obj ) )
                    {                        
                        if ( File.Exists( fullFileName ) )
                        {
                            if ( UpdateProcessing != null )
                                UpdateProcessing( Action.Updating , "�ļ�������..." );
                            //����ԭ�ļ�
                            BackupOldFile( fullFileName , false );
                            //ɾ��ԭ�ļ�
                            File.Delete( fullFileName );

                            Classes.Logger.Write( string.Format( "���ļ�{0}ɾ��,ԭ�汾{1}" , fullFileName , localVersion ) );
                        }
                        #region �Ѷ���������תΪ�ļ�

                        using ( FileStream fw = new FileStream( fullFileName , FileMode.OpenOrCreate , FileAccess.ReadWrite ) )
                        {
                            try
                            {
                                byte[] buffer = (byte[])obj;
                                int fileLength = (int)buffer.Length / BUFFER_LENGTH;
                                if ( fileLength * BUFFER_LENGTH < buffer.Length )
                                {
                                    fileLength++;
                                }
                                Classes.Logger.Write( string.Format( "���ڸ����ļ�{0}������{1}����{2}" , this.name , buffer.Length , fileLength ) );

                                for ( int j = 0 ; j < fileLength ; j++ )	//�Գ���ΪBUFFER_LENGTH�ֽڵĿ���д���
                                {
                                    if ( buffer.Length - j * BUFFER_LENGTH >= BUFFER_LENGTH )
                                    {
                                        fw.Write( buffer , j * BUFFER_LENGTH , BUFFER_LENGTH );
                                    }
                                    else
                                    {
                                        fw.Write( buffer , j * BUFFER_LENGTH , buffer.Length - j * BUFFER_LENGTH );
                                    }
                                    fw.Seek( 0 , SeekOrigin.End );

                                    if ( FileUpdate != null )
                                        FileUpdate( this.name , fileLength , j );
                                }
                            }
                            catch ( Exception error )
                            {
                                Classes.Logger.Write( fullFileName , error );
                                return;
                            }
                            finally
                            {
                                fw.Close();
                                fw.Dispose();
                            }
                        }
                        
                        #endregion

                        //���ڱ����ļ���ɾ���Զ���Ŀ¼�µ��ļ�����
                        if ( dellocalreport == 1 && exName == "RPT" && string.IsNullOrEmpty(folder) )
                        {
                            //ɾ��ָ��Ŀ¼�µı����ļ�
                            string rptFile = CustomDirectory.Path + "\\report\\" + this.name;
                            if ( File.Exists( rptFile ) )
                            {
                                if ( UpdateProcessing != null )
                                    UpdateProcessing( Action.Updating , "�ļ�������..." );
                                //�����ļ�
                                BackupOldFile( rptFile , true );
                                //ɾ���ļ�
                                File.Delete( rptFile );

                                Classes.Logger.Write( string.Format( "ԭ�����ļ�����{0}��ɾ��" , rptFile ) );
                            }
                        }
                        //���ļ������������汾��д�뵽���ص�ini��
                        if ( UpdateProcessing != null )
                            UpdateProcessing( Action.Updating , "����ini������Ϣ..." );

                        //MessageBox.Show("lpKeyName:" + lpKeyName + ":serverVersion:" + serverVersion);
                        ApiFunction.WriteIniString( "FILEINFO" , lpKeyName , serverVersion , iniFile );

                        if ( UpdateProcessing != null )
                        {
                            string sRet = name + "|" + localVersion + "|" + serverVersion + "|" + "�������...";
                            UpdateProcessing( Action.UpdateComplete , sRet );
                        }

                        Classes.Logger.Write( string.Format( "�ļ�{0}�������,�汾{1}" , name , serverVersion ) );
                    }
                }
                catch ( Exception error )
                {
                    if ( UpdateProcessing != null )
                        UpdateProcessing( Action.UpdateFailed , string.Format( "�ļ���{0},����{1}" , this.name , error.Message + error.StackTrace ) );

                    Classes.Logger.Write( name , error );
                }
            }
        }
        /// <summary>
        /// ����ԭ�ļ�
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="isRpt"></param>
        private void BackupOldFile(string fullFileName,bool isRpt)
        {
            string date = DateTime.Now.ToString( "yyyyMMdd" );
            string time = DateTime.Now.ToString( "HHmmss" );            
        }
        /// <summary>
        /// ��ȡ�����ļ��б�
        /// </summary>
        /// <returns></returns>
        public static List<UpdateInfo> LoadUpdateFileList()
        {
            try
            {
                if ( LoadingUpdateFileList != null )
                    LoadingUpdateFileList( Action.LoadingUpdateFile , false ,0 );

                List<UpdateInfo> lstFileInfo = ( new Database() ).GetUpdateFileList();

                if ( LoadingUpdateFileList != null )
                    LoadingUpdateFileList( Action.LoadingUpdateFile , true , lstFileInfo.Count );

                Classes.Logger.Write( string.Format( "���ط������������ļ�(LoadUpdateFileList),��{0}��" , lstFileInfo.Count ) );
                return lstFileInfo;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
    }
}
