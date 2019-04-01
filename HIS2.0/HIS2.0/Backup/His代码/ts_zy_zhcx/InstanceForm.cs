using System;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenFrame.Classes;
using TrasenClasses.GeneralClasses;

namespace ts_zy_zhcx
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

        //Modify by Kevin 2012-10-10
        private object[] _communicateValue;


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

            //_communicateValue[0] = "";
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

        //Modify by Kevin 2012-10-10
        public object[] communicateValue
        {
            get { return _communicateValue; }
            set { _communicateValue = value; }
        }
        #endregion

        #region ����
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            FrmZybrzhcx frmZybrzhcx;
            switch (_functionName)
            {
                case "Fun_ts_zy_zhcx":
                    frmZybrzhcx = new FrmZybrzhcx(false);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_all":
                    frmZybrzhcx = new FrmZybrzhcx(true);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_all_OrdDetail":
                    frmZybrzhcx = new FrmZybrzhcx(true,true);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                case "Fun_ts_zy_zhcx_bw":  //Modify by Kevin 2012-10-10 ���Ӳ�Σ��������������                   
                    frmZybrzhcx = new FrmZybrzhcx(communicateValue);
                    if (_mdiParent != null)
                    {
                        frmZybrzhcx.MdiParent = _mdiParent;
                    }
                    frmZybrzhcx.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
        }
        public TrasenClasses.GeneralClasses.ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[4];
            objectInfos[0].Name = "Fun_ts_zy_zhcx";
            objectInfos[0].Text = "סԺ�����ۺϲ�ѯ";
            objectInfos[0].Remark = "סԺ�����ۺϲ�ѯ";

            objectInfos[1].Name = "Fun_ts_zy_zhcx_all";
            objectInfos[1].Text = "סԺ�����ۺϲ�ѯ(ȫ������)";
            objectInfos[1].Remark = "סԺ�����ۺϲ�ѯ(ȫ������)";

            //Modify by Kevin 2012-10-10
            objectInfos[2].Name = "Fun_ts_zy_zhcx_bw";
            objectInfos[2].Text = "סԺ�����ۺϲ�ѯ(��Σ,����)";
            objectInfos[2].Remark = "סԺ�����ۺϲ�ѯ(��Σ,����)";



            objectInfos[3].Name = "Fun_ts_zy_zhcx_all_OrdDetail";
            objectInfos[3].Text = "סԺҽ����ѯ(ȫ������)";
            objectInfos[3].Remark = "סԺҽ����ѯ(ȫ������)";

            return objectInfos;

        }
        public TrasenClasses.GeneralClasses.ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zy_zhcx";
            objectInfo.Text = "סԺ�����ۺϲ�ѯ";
            objectInfo.Remark = "סԺ�����ۺϲ�ѯ";
            return objectInfo;
        }
        #endregion
        #endregion
    }
}
