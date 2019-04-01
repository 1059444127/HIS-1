using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_cftj
{
    public class InstanceForm : IInnerCommunicate
    {
        //������̬����
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private MenuTag _menuTag;

        private string _functionName;
        private string _chineseName;
        private long _currentUserId;
        private long _currentDeptId;
        public static User _currentUser;
        public static Department _currentDept;
        public static RelationalDatabase _database;
        private long _menuId;
        private Form _mdiParent;
        private object[] _communicateValue;
        public InstanceForm()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            BDatabase = null;
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _currentUserId = -1;
            _currentDeptId = -1;
            _menuId = -1;
            _mdiParent = null;
        }

        #region IInnerCommunicate ��Ա(һ��Ҫ�ڴ�ʵ��)

        #region ����
        /// <summary>
        /// ʵ�������庯������
        /// </summary>
        public string FunctionName
        {
            get
            {
                return _functionName;
            }
            set
            {
                _functionName = value;
            }
        }
        /// <summary>
        /// ������������
        /// </summary>
        public string ChineseName
        {
            get
            {
                return _chineseName;
            }
            set
            {
                _chineseName = value;
            }
        }
        /// <summary>
        /// ��ǰ����ԱID
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return BCurrentUser;
            }
            set
            {
                BCurrentUser = value;
            }
        }
        /// <summary>
        /// ��ǰ��������ID
        /// </summary>
        public Department CurrentDept
        {
            get
            {
                return BCurrentDept;
            }
            set
            {
                BCurrentDept = value;
            }
        }
        /// <summary>
        /// �˵�ID
        /// </summary>
        public long MenuId
        {
            get
            {
                return _menuId;
            }
            set
            {
                _menuId = value;
            }
        }
        /// <summary>
        /// �˵�ID
        /// </summary>
        public Form MdiParent
        {
            get
            {
                return _mdiParent;
            }
            set
            {
                _mdiParent = value;
            }
        }
        public RelationalDatabase Database
        {
            get
            {
                return InstanceForm.BDatabase;
            }
            set
            {
                InstanceForm.BDatabase = value;
            }
        }
        public MenuTag FunctionTag
        {
            get
            {
                return _menuTag;
            }
            set
            {
                _menuTag = value;
            }
        }
        /// <summary>
        /// �ڲ�ͨ�Ų���
        /// </summary>
        public object[] CommunicateValue
        {
            get
            {
                return _communicateValue;
            }
            set
            {
                _communicateValue = value;
            }
        }
        #endregion

        #region ����
        /// <summary>
        /// ���ݺ�������ʵ��������
        /// </summary>
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }

            string sSql = "";
            int nType = 0;
            Guid inpatientID = Guid.Empty;
            if (_communicateValue != null)
            {
                sSql = _communicateValue[0].ToString();
                nType = Convert.ToInt32(_communicateValue[1]);
            }
            switch (_functionName)
            {

                case "Fun_ts_mz_cftj":

                    Frmmzcftj Frmmzcftj = new Frmmzcftj();
                    if (_mdiParent != null)
                    {
                        Frmmzcftj.MdiParent = _mdiParent;

                    }
                    Frmmzcftj.Show();
                    Frmmzcftj.WindowState = FormWindowState.Maximized;
                    break;

                default:
                    throw new Exception("�����������ƴ���");
            }

        }

        public object GetObject()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_cftj";
            objectInfo.Text = "����ͳ��";
            objectInfo.Remark = "����ͳ��";
            return objectInfo;
        }

        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_cftj";
            objectInfo.Text = "����ͳ��";
            objectInfo.Remark = "����ͳ��";
            return objectInfo;
        }

        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[1];
            objectInfos[0].Name = "Fun_ts_mz_cftj";
            objectInfos[0].Text = "����ͳ��";
            objectInfos[0].Remark = "����ͳ��";

           
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
