/*
 * �����ռ�:Ĭ��Ϊ��������,�������dll�ļ�ͬ��
 * ��Ҫ�޸ĵĲ���Ϊ
 *		InstanceWorkForm������ʵ��
 *		GetDllInfo �����ڵ���Ϣ
 *		GetFunctionsInfo �����ڵ���Ϣ
 * ����μ������д��ŵ�ע��
*/
using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;

namespace ts_yp_tj				//���޸�ΪԼ���������ռ�
{
    /// <summary>
    /// InstanceBForm ��ժҪ˵��
    /// ʵ����ҵ����
    /// </summary>
    public class InstanceForm : IDllInformation, IInnerCommunicate
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
        private object[] _communicateValue;
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
            Frmtitle Frmtitle = null;					//����Ҫ���õĴ�����
            switch (_functionName)
            {
                case "Fun_ts_yp_tj":						//���Զ�����ú�����,����ĺ�����������GetFunctionsInfo�����ڵ�ObjectInfo.Nameһ��
                case "Fun_ts_yp_tj_cx":
                    Frmtitle = new Frmtitle(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmtitle.MdiParent = _mdiParent;
                    }
                    Frmtitle.Show();
                    break;

                case "Fun_ts_yp_tjwh":
                    Frmtjwh frm = new Frmtjwh(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                    }
                    frm.Show();
                    break;

                case "Fun_ts_yp_ypgysfp":
                    Frmypgysfp frmYPFp = new Frmypgysfp(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmYPFp.MdiParent = _mdiParent;
                    }
                    frmYPFp.WindowState = FormWindowState.Maximized;
                    frmYPFp.Show();
                    break;

                case "Fun_ts_yp_yptjcwtj":
                    FrmYptjCWBB frmYPcwtj = new FrmYptjCWBB(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmYPcwtj.MdiParent = _mdiParent;
                    }
                    frmYPcwtj.WindowState = FormWindowState.Maximized;
                    frmYPcwtj.Show();
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
            objectInfo.Name = "ts_yp_tj";						//��dll���ļ�����,�����������ռ䱣��һ��
            objectInfo.Text = "ҩƷ����";								//����������,����Ϊ��
            objectInfo.Remark = "";							//������,����Ϊ��
            return objectInfo;
        }

        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            Form f = null;
            switch (_functionName)
            {
                case "Fun_ts_yp_tj_cx":
                    Frmyptj Frmyptj = new Frmyptj((MenuTag)CommunicateValue[0], Convert.ToString(CommunicateValue[1]), _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmyptj.MdiParent = _mdiParent;
                    }
                    Frmyptj.FillDj(new Guid(Convert.ToString(CommunicateValue[2])), true);
                    Frmyptj.Show();
                    Frmyptj.FindRecord((int)CommunicateValue[4], 0);
                    return Frmyptj;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return f;
        }


        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[5];
            objectInfos[0].Name = "Fun_ts_yp_tj";
            objectInfos[0].Text = "ҩƷ����";
            objectInfos[0].Remark = "";

            objectInfos[1].Name = "Fun_ts_yp_tj_cx";
            objectInfos[1].Text = "ҩƷ����(��ѯ)";
            objectInfos[1].Remark = "";

            objectInfos[2].Name = "Fun_ts_yp_tjwh";
            objectInfos[2].Text = "ҩƷ�����ĺ�";
            objectInfos[2].Remark = "";

            objectInfos[3].Name = "Fun_ts_yp_ypgysfp";
            objectInfos[3].Text = "ҩƷ���۷�Ʊ¼��";
            objectInfos[3].Remark = "";

            objectInfos[4].Name = "Fun_ts_yp_yptjcwtj";
            objectInfos[4].Text = "ҩƷ���۲���ͳ��";
            objectInfos[4].Remark = "";

            return objectInfos;
        }
        #endregion

        #endregion
    }
}
