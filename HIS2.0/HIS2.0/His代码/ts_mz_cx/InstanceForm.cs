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

namespace ts_mz_cx		//���޸�ΪԼ���������ռ�
{
    /// <summary>
    /// InstanceBForm ��ժҪ˵��
    /// ʵ����ҵ����
    /// </summary>
    public class InstanceForm : IDllInformation
    {
        //������̬����
        public static RelationalDatabase BDatabase;
        public static User BCurrentUser;
        public static Department BCurrentDept;

        private MenuTag _menuTag;
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
  
            switch (_functionName)
            {
                case "Fun_ts_mz_cx_ghxxcx":
                    Frmghxxcx Frmghxxcx = new Frmghxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmghxxcx.MdiParent = _mdiParent; 
                    }
                    Frmghxxcx.Show();
                    break;
                case "Fun_ts_mz_cx_cfcx":
                    Frmcfcx Frmcfcx = new Frmcfcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmcfcx.MdiParent = _mdiParent;
                    }
                    Frmcfcx.WindowState = FormWindowState.Maximized;
                    Frmcfcx.Show();
                    break;
                case "Fun_ts_mz_cx_fpcx":
                case "Fun_ts_mz_cx_fpcx_bd":
                    Frmfpcx Frmfpcx = new Frmfpcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpcx.WindowState = FormWindowState.Maximized;
                        Frmfpcx.MdiParent = _mdiParent;
                        
                    }
                    Frmfpcx.Show();
                    break;
                case "Fun_ts_mz_cx_fpcx_bd_fp":
                    Frmfpcx Frmfpcx1 = new Frmfpcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmfpcx1.WindowState = FormWindowState.Maximized;
                        Frmfpcx1.MdiParent = _mdiParent;
                        Frmfpcx1.flag_fp = "1";

                    }
                    Frmfpcx1.Show();
                    break;
                case "Fun_ts_mz_mzrztj"://Add By zp 2013-08-26
                    Frm_Mzrz frmmzrz = new Frm_Mzrz();
                    if (_mdiParent != null)
                    {
                        frmmzrz.WindowState = FormWindowState.Maximized;
                        frmmzrz.MdiParent = _mdiParent;
                    }
                    frmmzrz.Show();
                    break;
                case "Fun_ts_mz_Yyghxxcx"://Add By jiangzf 2014-03-07                    
                    Frm_Yyghxxcx frmyyghxxcx = new Frm_Yyghxxcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmyyghxxcx.WindowState = FormWindowState.Maximized;
                        frmyyghxxcx.MdiParent = _mdiParent;
                    }
                    frmyyghxxcx.Show();
                    break;
                case "Fun_ts_mz_Mzyspbqkcx":
                    Frm_mzyspbqkcx frmmzyspbqkcx = new Frm_mzyspbqkcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmmzyspbqkcx.WindowState = FormWindowState.Maximized;
                        frmmzyspbqkcx.MdiParent = _mdiParent;
                    }
                    frmmzyspbqkcx.Show();
                    break;
                case "Fun_ts_mz_sjtflccx"://Add By jiangzf 2014-4-11                    
                    FrmSjtflccx frmSjtflccx = new FrmSjtflccx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmSjtflccx.WindowState = FormWindowState.Maximized;
                        frmSjtflccx.MdiParent = _mdiParent;
                    }
                    frmSjtflccx.Show();
                    break;
                case "Fun_ts_mz_cx_DetailsOfCharges":      //2014-12-31 cc/
                    Frm_DetailsOfCharges detailsofcharges = new Frm_DetailsOfCharges(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        detailsofcharges.WindowState = FormWindowState.Maximized;
                        detailsofcharges.MdiParent = _mdiParent;
                    }
                    detailsofcharges.Show();
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
            objectInfo.Name = "ts_mz_cx";						//��dll���ļ�����,�����������ռ䱣��һ��
            objectInfo.Text = "�����ѯ";								//����������,����Ϊ��
            objectInfo.Remark = "";							//������,����Ϊ��
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[10];
            objectInfos[0].Name = "Fun_ts_mz_cx_ghxxcx";
            objectInfos[0].Text = "����Һ���Ϣ��ѯ";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mz_cx_cfcx";
            objectInfos[1].Text = "���ﲡ�˴�����ѯ";
            objectInfos[1].Remark = "";
            objectInfos[2].Name = "Fun_ts_mz_cx_fpcx";
            objectInfos[2].Text = "���﷢Ʊ��ѯ";
            objectInfos[2].Remark = "";
            objectInfos[3].Name = "Fun_ts_mz_cx_fpcx_bd";
            objectInfos[3].Text = "���﷢Ʊ��ѯ(�ɲ����κ��˵ķ�Ʊ)";
            objectInfos[3].Remark = "";
            objectInfos[4].Name = "Fun_ts_mz_mzrztj";
            objectInfos[4].Text = "������־ͳ��";
            objectInfos[4].Remark = "";
            objectInfos[5].Name = "Fun_ts_mz_Yyghxxcx";
            objectInfos[5].Text = "����ԤԼ�Һ���Ϣ��ѯ";
            objectInfos[5].Remark = "";
            objectInfos[6].Name = "Fun_ts_mz_Mzyspbqkcx";
            objectInfos[6].Text = "����ҽ���Ű���Ϣ��ѯ";
            objectInfos[6].Remark = "";

            objectInfos[7].Name = "Fun_ts_mz_cx_fpcx_bd_fp";
            objectInfos[7].Text = "���﷢Ʊ��ѯ(����������Ʊ)";
            objectInfos[7].Remark = "";//Fun_ts_mz_sjtflccx

            objectInfos[8].Name = "Fun_ts_mz_sjtflccx";
            objectInfos[8].Text = "�����˷����̲�ѯ";
            objectInfos[8].Remark = "";

            objectInfos[9].Name = "Fun_ts_mz_cx_DetailsOfCharges";
            objectInfos[9].Text = "120/110���˷��ò�ѯ";
            objectInfos[9].Remark = "";
            return objectInfos;
        }
        #endregion

        #endregion
    }
}
