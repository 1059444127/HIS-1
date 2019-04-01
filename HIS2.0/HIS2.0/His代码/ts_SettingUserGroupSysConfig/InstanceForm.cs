using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_SettingUserGroupSysConfig
{
    public class InstanceForm : IDllInformation
    {
         

        //������̬����
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        public static MenuTag _menuTag;
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
        /// <summary>
        /// ���캯��
        /// </summary>
        public InstanceForm()
        {
            BDatabase = null;
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _menuId = -1;
            _mdiParent = null;
        }

        #region IDllInformation ��Ա(һ��Ҫ�ڴ�ʵ��)

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
            Form frm = null;
            switch (_functionName)
            {

                case "Fun_ts_SettingUserGroupSysConfig":
                    frm = new FrmSetUserGroupSysConfig(_menuTag, _chineseName, _mdiParent);
                    frm.MdiParent = _mdiParent;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;
                default:
                    throw new Exception("��������������");
            }

        }
        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_SettingUserGroupSysConfig";
            objectInfo.Text = "�û����������";
            objectInfo.Remark = "�û����������";
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[1];
            objectInfos[0].Name = "Fun_ts_SettingUserGroupSysConfig";
            objectInfos[0].Text = "�û����������";
            objectInfos[0].Remark = "";        
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
