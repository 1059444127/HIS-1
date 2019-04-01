using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using TrasenClasses.DatabaseAccess;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_yspbsz
{
    //InstanceForm ��ժҪ˵����������ÿ��DLL�������ʵĽӿں����࣬���Ʋ��ܸģ�������Сд��
    public class InstanceForm : IDllInformation
    {
        //������̬����
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private Form _mdiParent;
        public static MenuTag _menuTag;
        private long _menuId;
        private string _functionName;
        private string _chineseName;
        private object[] _communicateValue;

        public InstanceForm()
        {
            //�ڴ˴���ӹ��캯���߼�
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

        //ʵ�������庯������
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

        //������������
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

        //��ǰ����ԱID
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

        //��ǰ��������ID
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

        //�˵�ID
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

        //�ڲ�ͨ�Ų���
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
        //���ݺ�������ʵ��������
        public void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }

            switch (_functionName)
            {
                case "Fun_ts_mz_yspb_flsz":
                    Frm_yspb_flsz frm = new Frm_yspb_flsz(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.WindowState = FormWindowState.Maximized;

                    frm.Show();
                    break;
                case "Fun_ts_mz_yspb_ksflmx":
                    Frm_yspb_ksflmx frm_mx = new Frm_yspb_ksflmx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_mx.MdiParent = _mdiParent;
                    }
                    frm_mx.WindowState = FormWindowState.Maximized;
                    frm_mx.Show();
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }

        }

        //����һ��FORM����
        public object GetObject()
        {
            return null;
        }

        //��ø�Dll����Ϣ
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mz_yspbsz";
            objectInfo.Text = "����ҽ���Ű�����";
            objectInfo.Remark = "����ҽ���Ű�����";
            return objectInfo;
        }

        /// ��ø�Dll��������������Ϣ
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];
            objectInfos[0].Name = "Fun_ts_mz_yspb_flsz";
            objectInfos[0].Text = "�����Ű��������";
            objectInfos[0].Remark = "�����Ű��������";
            objectInfos[1].Name = "Fun_ts_mz_yspb_ksflmx";
            objectInfos[1].Text = "�����Ű���ҷ�����ϸ";
            objectInfos[1].Remark = "�����Ű���ҷ�����ϸ";

            return objectInfos;
        }
        #endregion

        #endregion

    }
}
