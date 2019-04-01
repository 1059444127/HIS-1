using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using TrasenClasses.GeneralControls;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_ensemble_eventlog
{
    /// <summary>
    /// InstanceForm ��ժҪ˵����
    /// ������ÿ��DLL�������ʵĽӿں�����
    /// ���Ʋ��ܸģ�������Сд��
    /// </summary>
    public class InstanceForm : IInnerCommunicate
    {
        //������̬����
        public static RelationalDatabase BDatabase;
        public static TrasenFrame.Classes.User BCurrentUser;
        public static Department BCurrentDept;

        public static MenuTag _menuTag;
        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
        private object[] _communicateValue;
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
        public TrasenFrame.Classes.User CurrentUser
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
            Form frm = null;
            switch (_functionName)
            {
                case "Fun_ts_ensemble_eventlog":
                    frm = new FrmMain(_chineseName, BCurrentUser, BCurrentDept);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();
                    break;
                case "Fun_ts_ensemble_tools":
                    frm = new FrmTools();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();	
                    break;
                case "Fun_ts_sync_patientinfo":
                    TrasenHIS.BLL.SyncPatientInfo.SyncPat(FrmMdiMain.Database);
                    break;
                case "Fun_ts_ensemble_eventmessagelog":
                    frm = new FrmMessageMain(_chineseName, BCurrentUser, BCurrentDept);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }

                    frm.WindowState = FormWindowState.Maximized;
                    frm.BringToFront();
                    frm.Show();
                    break;
                default:
                    throw new Exception("��������������");
            }
        }
        /// <summary>
        /// ����һ��FORM����
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            return null;
        }

        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_ensemble_eventlog";
            objectInfo.Text = "ƽ̨�¼���ѯ";
            objectInfo.Remark = "ƽ̨�¼���ѯ";
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_ensemble_eventlog";
            objectInfos[0].Text = "ƽ̨�¼���ѯ";
            objectInfos[0].Remark = "ƽ̨�¼���ѯ";
            objectInfos[1].Name = "Fun_ts_ensemble_tools";
            objectInfos[1].Text = "����С����";
            objectInfos[1].Remark = "����С����";
            objectInfos[2].Name = "Fun_ts_sync_patientinfo";
            objectInfos[2].Text = "ͬ�����ϲ�����Ϣ";
            objectInfos[2].Remark = "ͬ�����ϲ�����Ϣ";
            objectInfos[3].Name = "Fun_ts_ensemble_eventmessagelog";
            objectInfos[3].Text = "�����¼���ѯ";
            objectInfos[3].Remark = "�����¼���ѯ";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
