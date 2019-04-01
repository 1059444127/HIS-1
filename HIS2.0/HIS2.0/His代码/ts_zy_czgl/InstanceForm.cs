using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_zy_czgl
{
    /// <summary>
    /// InstanceForm ��ժҪ˵����
    /// ������ÿ��DLL�������ʵĽӿں�����
    /// ���Ʋ��ܸģ�������Сд��
    /// </summary>
    public class InstanceForm : IDllInformation
    {
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private string _functionName;
        private string _chineseName;
        private long _menuId;
        private Form _mdiParent;
        private MenuTag _menuTag;
        public InstanceForm()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            BCurrentUser = null;
            BCurrentDept = null;

            _functionName = "";
            _chineseName = "";
            _menuId = -1;
            _mdiParent = null;
        }

        #region IDllInformation ��Ա

        #region ����
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

        public RelationalDatabase Database
        {
            get
            {
                return BDatabase;
            }
            set
            {
                BDatabase = value;
            }
        }
        #endregion

        #region ����
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            FrmCzgl frmCzgl;
            switch (_functionName)
            {
                case "Fun_ts_zy_czgl":
                case "Fun_ts_zy_czgl_all":
                case "Fun_ts_zy_czgl_cx":
                case "Fun_ts_zy_czgl_cx_all":
                case "Fun_ts_zy_czgl_sh":
                case "Fun_ts_zy_czgl_sh_all":
                    frmCzgl = new FrmCzgl(_functionName, _chineseName);
                    if (_mdiParent != null)
                    {
                        frmCzgl.MdiParent = _mdiParent;
                    }
                    frmCzgl.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
        }
        public TrasenClasses.GeneralClasses.ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[6];
            objectInfos[0].Name = "Fun_ts_zy_czgl";
            objectInfos[0].Text = "סԺ���˳���ȷ��";
            objectInfos[0].Remark = "סԺ���˳���ȷ��";
            objectInfos[1].Name = "Fun_ts_zy_czgl_all";
            objectInfos[1].Text = "סԺ���˳���ȷ��(ȫ��)";
            objectInfos[1].Remark = "סԺ���˳���ȷ��(ȫ��)";
            objectInfos[2].Name = "Fun_ts_zy_czgl_cx";
            objectInfos[2].Text = "סԺ���˳��˲�ѯ";
            objectInfos[2].Remark = "סԺ���˳��˲�ѯ";
            objectInfos[3].Name = "Fun_ts_zy_czgl_cx_all";
            objectInfos[3].Text = "סԺ���˳��˲�ѯ(ȫ��)";
            objectInfos[3].Remark = "סԺ���˳��˲�ѯ(ȫ��)";
            objectInfos[4].Name = "Fun_ts_zy_czgl_sh";
            objectInfos[4].Text = "סԺ���˳������";
            objectInfos[4].Remark = "סԺ���˳������";
            objectInfos[5].Name = "Fun_ts_zy_czgl_sh_all";
            objectInfos[5].Text = "סԺ���˳������(ȫ��)";
            objectInfos[5].Remark = "סԺ���˳������(ȫ��)";
            return objectInfos;

        }
        public TrasenClasses.GeneralClasses.ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zy_czgl";
            objectInfo.Text = "סԺ���˳��˹���";
            objectInfo.Remark = "סԺ���˳��˹���";
            return objectInfo;
        }
        #endregion
        #endregion
    }
}
