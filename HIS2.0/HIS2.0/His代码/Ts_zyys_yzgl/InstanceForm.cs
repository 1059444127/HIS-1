using System;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenFrame.Forms;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;

namespace Ts_zyys_yzgl
{
    /// <summary>
    /// InstanceForm ��ժҪ˵����
    /// ������ÿ��DLL�������ʵĽӿں�����
    /// ���Ʋ��ܸģ�������Сд��
    /// </summary>
    public class InstanceForm : IInnerCommunicate
    {
        private string _functionName;
        private string _chineseName;
        public static User _currentUser;
        public static Department _currentDept;
        private long _menuId;
        public static RelationalDatabase _database;
        private MenuTag _functions;
        private Form _mdiParent;
        private object[] _communicateValue;

        public InstanceForm()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            _functionName = "";
            _chineseName = "";
            _database = null;
            _currentUser = null;
            _currentDept = null;
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
                return _currentUser;
            }
            set
            {
                _currentUser = value;
            }
        }

        /// <summary>
        /// ��ǰ��������ID
        /// </summary>
        public Department CurrentDept
        {
            get
            {
                return _currentDept;
            }
            set
            {
                _currentDept = value;
            }
        }

        /// <summary>
        /// Database���ݿ�ʵ����
        /// </summary>
        public RelationalDatabase Database
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }

        /// <summary>
        /// FuncationTag����������ֵ
        /// </summary>
        public MenuTag FunctionTag
        {
            get
            {
                return _functions;
            }
            set
            {
                _functions = value;
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
        /// MDI������
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
            switch (_functionName)
            {
                case "Fun_Ts_zyys_dlwh":
                    FrmYZDLList f = new FrmYZDLList();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    f.WindowState = FormWindowState.Maximized;
                    f.Show();
                    break;

                case "Fun_Ts_zyys_qxwh":
                    FrmScheme frm = new FrmScheme();
                    if (_mdiParent != null)
                    {
                        frm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    break;

                case "Fun_Ts_zyys_qxmxwh":
                    FrmSchemeRelation frmMx = new FrmSchemeRelation();
                    if (_mdiParent != null)
                    {
                        frmMx.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frmMx.WindowState = FormWindowState.Maximized;
                    frmMx.Show();
                    break;

                case "Fun_Ts_zyys_qxmxwh_ks":
                    FrmSchemeRltDpt frmMxKs = new FrmSchemeRltDpt();
                    if (_mdiParent != null)
                    {
                        frmMxKs.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    frmMxKs.WindowState = FormWindowState.Maximized;
                    frmMxKs.Show();
                    break;
                case "Fun_Ts_ksSpr":
                    FrmKsSpr fm = new FrmKsSpr();
                    if (_mdiParent != null)
                    {
                        fm.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    fm.WindowState = FormWindowState.Maximized;
                    fm.Show();
                    break;
                case "Fun_Ts_SsYp":
                    FrmSsYp frmsy = new FrmSsYp();
                    if (_mdiParent != null)
                    {
                        frmsy.MdiParent = _mdiParent;
                    }
                    frmsy.WindowState = FormWindowState.Maximized;
                    frmsy.Show();
                    break;
                case "Fun_Ts_ksssh":
                    Frmksssh fmksh = new Frmksssh();
                    if (_mdiParent != null)
                    {
                        fmksh.MdiParent = _mdiParent;
                    }
                    fmksh.WindowState = FormWindowState.Maximized;
                    fmksh.Show();
                    break;
                case "Fun_Ts_zyys_kjwdy":
                    FrmKssSqbPrint frmKjw = new FrmKssSqbPrint();
                    if (_mdiParent != null)
                    {
                        frmKjw.MdiParent = _mdiParent;
                    }
                    frmKjw.WindowState = FormWindowState.Maximized;
                    frmKjw.Show();
                    break;
                case "Fun_Ts_zyys_tsksShr":
                    FrmSpecialKssChk frmTsksShr = new FrmSpecialKssChk();
                    if (_mdiParent != null)
                    {
                        frmTsksShr.MdiParent = _mdiParent;
                    }
                    frmTsksShr.WindowState = FormWindowState.Maximized;
                    frmTsksShr.Show();
                    break;
                case "Fun_Ts_zyys_tsksSh":
                    FrmSpecialKssChkSh frmTsksSh = new FrmSpecialKssChkSh();
                    if (_mdiParent != null)
                    {
                        frmTsksSh.MdiParent = _mdiParent;
                    }
                    frmTsksSh.WindowState = FormWindowState.Maximized;
                    frmTsksSh.Show();
                    break;
                case "Fun_Ts_zyys_KssYymd":
                    FrmKssDetailMemo fKssYymd = new FrmKssDetailMemo();
                    if (_mdiParent != null)
                    {
                        fKssYymd.MdiParent = _mdiParent;
                    }
                    fKssYymd.WindowState = FormWindowState.Maximized;
                    fKssYymd.Show();
                    break;
                case "Fun_Ts_zyys_QueryDisease":
                    FrmQueryDisease fDiseaseQuery = new FrmQueryDisease();
                    if (_mdiParent != null)
                    {
                        fDiseaseQuery.MdiParent = _mdiParent;
                    }
                    fDiseaseQuery.WindowState = FormWindowState.Maximized;
                    fDiseaseQuery.Show();
                    break;
                case "Fun_Ts_zyys_KssItem":
                    FrmKssItem fKssItem = new FrmKssItem();
                    if (_mdiParent != null)
                    {
                        fKssItem.MdiParent = _mdiParent;
                    }
                    fKssItem.WindowState = FormWindowState.Maximized;
                    fKssItem.Show();
                    break;
                case "Fun_Ts_zyys_H7N9":
                    FormDoctorH7N9Maintain fDoctorH7N9Maintain = new FormDoctorH7N9Maintain();
                    if (_mdiParent != null)
                    {
                        fDoctorH7N9Maintain.MdiParent = _mdiParent;
                    }
                    fDoctorH7N9Maintain.WindowState = FormWindowState.Maximized;
                    fDoctorH7N9Maintain.Show();
                    break;  
            }
        }

        /// <summary>
        /// ����һ��FORM����
        /// </summary>
        /// <returns></returns>
        public object GetObject()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }
            FrmYZGL frmyzgl = null;
            Form f=null;
            string _hszd = "";
            string sSql;
            switch (_functionName)
            {
                case "Fun_Ts_zyys_yzgl":   //ҽ������վҽ������
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_hszd":   //��ʿ�˵�ҽ������
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, _functionName, _hszd, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_hsyz":   //��ʿҽ������(���ڡ���ʱҽ�������ڡ���ʱ�˵�)
                    if (_communicateValue != null)
                    {
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _communicateValue);
                    }
                    if (_mdiParent != null)
                    {
                        frmyzgl.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    break;

                case "Fun_Ts_zyys_mzyz":    //��������ҽ������
                    if (_communicateValue != null)
                    {
                        sSql = _communicateValue[7].ToString();
                        frmyzgl = new FrmYZGL(_currentUser.UserID, _currentDept.DeptId, _chineseName, sSql, _communicateValue);
                    }
                    break;
                case "Fun_Ts_zyys_dlwh":
                    f = new FrmYZDLList();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                        //						frmyzgl.Show();
                    }
                    return f;
                    break;
                case "Fun_Ts_ksssh":
                    f = new Frmksssh();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_Ts_SsYp":
                    f = new FrmSsYp();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                case "Fun_Ts_zyys_H7N9":
                    f = new FormDoctorH7N9Maintain();
                    if (_mdiParent != null)
                    {
                        f.MdiParent = _mdiParent;
                    }
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return frmyzgl;
        }
        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "Ts_zyys_yzgl";
            objectInfo.Text = "ҽ������";
            objectInfo.Remark = "ҽ������";
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            
            ObjectInfo[] objectInfos = new ObjectInfo[18];

            objectInfos[0].Name = "Fun_Ts_zyys_yzgl";
            objectInfos[0].Text = "ҽ������";
            objectInfos[0].Remark = "ҽ������";
            objectInfos[1].Name = "Fun_Ts_zyys_mzyz";
            objectInfos[1].Text = "ҽ��¼��";
            objectInfos[1].Remark = "ҽ��¼��";
            objectInfos[2].Name = "Fun_Ts_zyys_hsyz";
            objectInfos[2].Text = "��ʿҽ��";
            objectInfos[2].Remark = "��ʿҽ��";
            objectInfos[3].Name = "Fun_Ts_zyys_hszd";
            objectInfos[3].Text = "��ʿ�˵�";
            objectInfos[3].Remark = "��ʿ�˵�";

            objectInfos[4].Name = "Fun_Ts_zyys_dlwh";
            objectInfos[4].Text = "ҽ������ά��";
            objectInfos[4].Remark = "ҽ������ά��";

            objectInfos[5].Name = "Fun_Ts_zyys_qxwh";
            objectInfos[5].Text = "ҽ��Ȩ��ά��";
            objectInfos[5].Remark = "ҽ��Ȩ��ά��";

            objectInfos[6].Name = "Fun_Ts_zyys_qxmxwh";
            objectInfos[6].Text = "ҽ��Ȩ����ϸά��";
            objectInfos[6].Remark = "ҽ��Ȩ����ϸά��";

            objectInfos[7].Name = "Fun_Ts_zyys_qxmxwh_ks";
            objectInfos[7].Text = "ҽ������Ȩ�޿���";
            objectInfos[7].Remark = "ҽ������Ȩ�޿���";

            objectInfos[8].Name = "Fun_Ts_ksSpr";
            objectInfos[8].Text = "��������˹���";
            objectInfos[8].Remark = "��������˹���";

            objectInfos[9].Name = "Fun_Ts_ksssh";
            objectInfos[9].Text = "���Ƽ�����ҩ�����";
            objectInfos[9].Remark = "���Ƽ�����ҩ�����";

            objectInfos[10].Name = "Fun_Ts_zyys_kjwdy";
            objectInfos[10].Text = "���⿹�����ӡ";
            objectInfos[10].Remark = "���⿹�����ӡ";

            objectInfos[11].Name = "Fun_Ts_SsYp";
            objectInfos[11].Text = "����ҩƷ����";
            objectInfos[11].Remark = "����ҩƷ����";

            objectInfos[12].Name = "Fun_Ts_zyys_tsksShr";
            objectInfos[12].Text = "���⼶����ҩ��ά����Ա";
            objectInfos[12].Remark = "���⼶����ҩ��ά����Ա";

            objectInfos[13].Name = "Fun_Ts_zyys_tsksSh";
            objectInfos[13].Text = "���⼶����ҩ�����";
            objectInfos[13].Remark = "���⼶����ҩ�����";

            objectInfos[14].Name = "Fun_Ts_zyys_KssYymd";
            objectInfos[14].Text = "��ҩĿ��ά��";
            objectInfos[14].Remark = "��ҩĿ��ά��";

            objectInfos[15].Name = "Fun_Ts_zyys_QueryDisease";
            objectInfos[15].Text = "��ϲ�ѯ";
            objectInfos[15].Remark = "��ϲ�ѯ";

            objectInfos[16].Name = "Fun_Ts_zyys_KssItem";
            objectInfos[16].Text = "�пڵȼ���Ӧ������";
            objectInfos[16].Remark = "�пڵȼ���Ӧ������";

            objectInfos[17].Name = "Fun_Ts_zyys_H7N9";
            objectInfos[17].Text = "H7N9����Ȩ�޿���";
            objectInfos[17].Remark = "H7N9����Ȩ�޿���";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
