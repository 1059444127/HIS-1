using System;
using System.Collections.Generic;
using System.Text;

namespace TrasenClasses.DatabaseAccess
{
    /// <summary>
    /// ���ݿ���������
    /// </summary>
    public enum ConnectType
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
}
