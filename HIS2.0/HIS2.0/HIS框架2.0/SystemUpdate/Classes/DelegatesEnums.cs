using System;
using System.Collections.Generic;
using System.Text;

namespace SystemUpdate
{
    /// <summary>
    /// ���ݿ���������
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>΢��SQLSERVER���ݿ�</summary>
        SQLSERVER ,
        /// <summary>IBMDB2���ݿ�</summary>
        IBMDB2 ,
        /// <summary>Oracle���ݿ�</summary>
        ORACLE ,
        /// <summary>΢��Access���ݿ�</summary>
        MSACCESS ,
        /// <summary>��������</summary>
        OTHER = -1
    }

    public enum Action
    {
        /// <summary>
        /// ��������ļ�
        /// </summary>
        LoadingUpdateFile,
        /// <summary>
        /// �Ƚϰ汾
        /// </summary>
        CompareVersion,
        /// <summary>
        /// ������
        /// </summary>
        Updating,
        /// <summary>
        /// �����ļ�����
        /// </summary>
        DownLoadContent,
        /// <summary>
        /// �������
        /// </summary>
        DownLoadComplete,

        UpdateComplete,

        UpdateFailed
    }

    public delegate void UpdateProcessingHandle(Action action ,string message);

    public delegate void FileUpdateHandle(string fileName,long fileLength,long current);

    public delegate void LoadingUpdateFileListHandle( Action action , bool complated ,int fileCount);

}
