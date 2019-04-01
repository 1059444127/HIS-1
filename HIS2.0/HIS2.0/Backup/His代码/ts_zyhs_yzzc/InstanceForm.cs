using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenFrame.Forms;

namespace ts_zyhs_yzzc
{
    /// <summary>
    /// InstanceForm ��ժҪ˵����
    /// ������ÿ��DLL�������ʵĽӿں�����
    /// ���Ʋ��ܸģ�������Сд��
    /// </summary>
    public class InstanceForm : IDllInformation, IInnerCommunicate
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
        private long _menuId;
        private Form _mdiParent;
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
            frmYZZC frmYzzc = null;
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzzc":
                    frmYzzc = new frmYZZC(_chineseName, 1);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                case "Fun_ts_zyhs_yzhd":
                    frmYzzc = new frmYZZC(_chineseName, 3);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                case "Fun_ts_zyhs_yzcd":
                    frmYzzc = new frmYZZC(_chineseName, 5);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                case "Fun_ts_zyhs_JyCodePrt":
                    FrmLisCodePrt frmJy = new FrmLisCodePrt();
                    if (_mdiParent != null)
                    {
                        frmJy.MdiParent = _mdiParent;
                    }
                    frmJy.WindowState = FormWindowState.Maximized;
                    frmJy.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }

        }
        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_zyhs_yzzc";
            objectInfo.Text = "ҽ��ת�����˶ԡ����";
            objectInfo.Remark = "ҽ��ת�����˶ԡ���ԣ�0��ҽ�� 1δת�� 2��ת�� 3δ�˶� 4�Ѻ˶� 5δ��� 6�Ѳ�ԣ�";
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_zyhs_yzzc";
            objectInfos[0].Text = "ҽ��ת��";
            objectInfos[0].Remark = "ҽ��ת��";
            objectInfos[1].Name = "Fun_ts_zyhs_yzhd";
            objectInfos[1].Text = "ҽ���˶�";
            objectInfos[1].Remark = "ҽ���˶�";
            objectInfos[2].Name = "Fun_ts_zyhs_yzcd";
            objectInfos[2].Text = "ҽ�����";
            objectInfos[2].Remark = "ҽ�����";
            objectInfos[3].Name = "Fun_ts_zyhs_JyCodePrt";
            objectInfos[3].Text = "���������ӡ";
            objectInfos[3].Remark = "���������ӡ";
            return objectInfos;
        }
        #endregion

        #endregion

        #region IInnerCommunicate ��Ա

        private object[] communicateValue ;

        public object[] CommunicateValue
        {
            get { return communicateValue; }
            set { communicateValue = value; }
        }

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            frmYZZC frmYzzc = null;
            switch (_functionName)
            {
                case "Fun_ts_zyhs_yzzc":
                    frmYzzc = new frmYZZC(_chineseName, 1);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                case "Fun_ts_zyhs_yzhd":
                    frmYzzc = new frmYZZC(_chineseName, 3);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                case "Fun_ts_zyhs_yzcd":
                    frmYzzc = new frmYZZC(_chineseName, 5);
                    if (_mdiParent != null)
                    {
                        frmYzzc.MdiParent = _mdiParent;
                    }
                    frmYzzc.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return frmYzzc;
        }

        #endregion
    }
}
