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
using System.Data;

namespace ts_mzys_blcflr	//���޸�ΪԼ���������ռ�
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
        public static string _functionName;
        public static string _chineseName;
        public static long _menuId;
        public static Form _mdiParent;
        public static object[] _communicateValue;
        public static bool IsSfy;
     
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

            switch (_functionName)
            {
                case "Fun_ts_mzys_blcflr":
                case "Fun_ts_mzys_blcflr_grmb":
                case "Fun_ts_mzys_blcflr_kjmb":
                case "Fun_ts_mzys_blcflr_yjmb":
                case "Fun_ts_mzys_blcflr_xdcf_yj":
                case "Fun_ts_mzys_blcflr_xdcf_kj":
                case "Fun_ts_zyys_blcflr":
                    DateTime djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    //��֤�����Ƿ���Ҫ����
                    string ssql = "select * from MZYS_FZKS where ksdm=" + InstanceForm.BCurrentDept.DeptId + "";
                    bool IsSelect_Room = IsSelectRoom(djsj);
                    DataTable tbks = InstanceForm.BDatabase.GetDataTable(ssql);
                    if ( tbks.Rows.Count == 0 || ( !IsSelect_Room ) || ( _functionName != "Fun_ts_zyys_blcflr" && _functionName != "Fun_ts_mzys_blcflr" ) )
                    {
                        Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, 0);
                        if (_mdiParent != null)
                        {
                            Frmhjsf.MdiParent = _mdiParent;
                        }
                        Frmhjsf.Show();
                        return;
                    }
                    //�����Ҫ����
                    SystemCfg cg = new SystemCfg(3001);
                    ssql = "select * from jc_zjsz where wkdz='" + PubStaticFun.GetMacAddress() + "'";
                    DataTable tbjz = InstanceForm.BDatabase.GetDataTable(ssql);
                    //�ж��Ƿ����÷�ʱ�νк�ϵͳ ���δ���������ϵ�ѡ������ģʽ Modify By zp 2013-06-18
                    if (new SystemCfg(3070).Config == "1")
                    {
                        #region δ���·���ϵͳ �����ϵ�ģʽѡ������
                        if (tbjz.Rows.Count == 1)
                        {
                            if (Convert.ToInt16(cg.Config) == 0)
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            else
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            InstanceForm.BDatabase.DoCommand(ssql);

                            Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                            if (_mdiParent != null)
                            {
                                Frmhjsf.MdiParent = _mdiParent;
                            }
                            Frmhjsf.Show();
                            break;
                        }
                        else
                        {
                            Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent);
                            f.ShowDialog();
                            break;
                        }
                        #endregion
                    }
                    else
                    {
                        #region �����·���ϵͳ
                        if (tbjz.Rows.Count == 1 && int.Parse(Convertor.IsNull(tbjz.Rows[0]["ZZYS"], "-1")) == InstanceForm.BCurrentUser.EmployeeId
                           && int.Parse(Convertor.IsNull(tbjz.Rows[0]["KSDM"], "-1")) == InstanceForm.BCurrentDept.DeptId)  //�õ��������Ҫ�ж����Ҽ�¼�Ŀ��Ҵ����ҽ�������뵱ǰ������ҡ�����ҽ���Ƿ�һ��
                        {
                            if (Convert.ToInt16(cg.Config) == 0)
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            else
                                ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                            InstanceForm.BDatabase.DoCommand(ssql);

                            Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                            if (_mdiParent != null)
                            {
                                Frmhjsf.MdiParent = _mdiParent;
                            }
                            Frmhjsf.Show();
                            break;
                        }
                        else  //ͨ������3065��������ѡ��ģʽ
                        {
                            DataTable dt = BindRoom();
                            Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent, dt);
                            f.ShowDialog();
                            break;
                        }
                        #endregion
                    }
                #region ע�ʹ��� Modify By zp 2013-07-09
                //if (tbjz.Rows.Count == 1)
                    //{
                    //    if (Convert.ToInt16(cg.Config) == 0)
                    //        ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ", wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                    //    else
                    //        ssql = "update jc_zjsz set BDLBZ=1,ZZYS=" + InstanceForm.BCurrentUser.EmployeeId.ToString() + ",wkdz='" + PubStaticFun.GetMacAddress() + "',dlsj='" + djsj.ToString() + "' , ksdm=" + InstanceForm.BCurrentDept.DeptId + " where zjid=" + tbjz.Rows[0]["zjid"].ToString() + " ";
                    //    InstanceForm.BDatabase.DoCommand(ssql);

                    //    Frmblcf Frmhjsf = new Frmblcf(_menuTag, _chineseName, _mdiParent, Convert.ToInt32(tbjz.Rows[0]["zjid"]));
                    //    if (_mdiParent != null)
                    //    {
                    //        Frmhjsf.MdiParent = _mdiParent;
                    //    }
                    //    Frmhjsf.Show();
                    //    break;
                    //}
                    //else
                    //{
                    //    Frmzjqr f = new Frmzjqr(_menuTag, _chineseName, _mdiParent);
                    //    f.ShowDialog();
                    //    break;
                //}
                #endregion
                case "Fun_ts_mzys_jzlscx":
                case "Fun_ts_mzys_jzlscx_all":
                    Frmjzlscx Frmjzlscx = new Frmjzlscx(_menuTag, _chineseName, _mdiParent);

                    if (_mdiParent != null)
                    {
                        Frmjzlscx.MdiParent = _mdiParent;
                    }
                    Frmjzlscx.Show();
                    break;
                case "Fun_ts_mzys_blcflr_wtsq":
                    Frmwtsqcx Frmwtsqcx = new Frmwtsqcx(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        Frmwtsqcx.MdiParent = _mdiParent;
                    }
                    Frmwtsqcx.Show();
                    break;
                case "Fun_ts_mzys_zymbwh":
                    FrmZyMbWh frmzymbwh = new FrmZyMbWh(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frmzymbwh.MdiParent = _mdiParent;
                    }
                    frmzymbwh.Show();
                    break;
                case "Fun_ts_mztfsh":
                case "Fun_ts_mztfsq_ys"://add by zouchihua 2014-9-14 ҽ������Ҳ���ԹҲ˵�
                    Frm_TF_Apply frm_tfsq = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    if (_mdiParent != null)
                    {
                        frm_tfsq.MdiParent = _mdiParent;
                    } 
                    frm_tfsq.Show();
                    break;
                case "Fun_ts_mztfsq_hj"://add by zouchihua 2014-9-14 ����ǻ��۵Ļ���Ҳ���ԹҲ˵�
                    Frm_TF_Apply frm_tfsq1 = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                      frm_tfsq1.Show();
                    break;
                case "Fun_ts_mzys_yyjbsh":
                    ��ҩ������� Frmyyjbsh = new ��ҩ�������(_menuTag, _chineseName, _mdiParent);

                    if (_mdiParent != null)
                    {
                        Frmyyjbsh.MdiParent = _mdiParent;
                    }
                    Frmyyjbsh.Show();
                    break;
                case "Fun_ts_zyzCx":
                    frmZyzCx frmActon = new frmZyzCx();
                    if (frmActon != null)
                    {
                        frmActon.MdiParent = _mdiParent;
                    }
                    frmActon.Show();
                    frmActon.WindowState = FormWindowState.Maximized;
                    break;
                default:
                    throw new Exception("�����������ƴ���");

            }

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
                case "Fun_ts_mzys_blcflr_lscx":
                    Frmblcf_cx Frmblcf_cx = new Frmblcf_cx(_menuTag, _chineseName, _mdiParent, new Guid(CommunicateValue[0].ToString()), Guid.Empty);

                    if (_mdiParent != null)
                    {
                        Frmblcf_cx.MdiParent = _mdiParent;
                    }
                    //Frmblcf_cx.Show();
                    f = Frmblcf_cx;
                    break;
                case "Fun_ts_mzys_blcflr_zyz":
                    Frmzyz Frmzyz = new Frmzyz(_menuTag, _chineseName, _mdiParent, new Guid(CommunicateValue[0].ToString()), Convert.ToInt32(CommunicateValue[1]));
                    f = Frmzyz;
                    break;
                case "Fun_ts_mztfsh":
                case "Fun_ts_mztfsq_ys"://add by zouchihua 2014-9-14 ҽ������Ҳ���ԹҲ˵�
                    Frm_TF_Apply frm_tfsq = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    f = frm_tfsq;
                    break;
                case "Fun_ts_mztfsq_hj"://add by zouchihua 2014-9-14 ����ǻ��۵Ļ���Ҳ���ԹҲ˵�
                    Frm_TF_Apply frm_tfsq1 = new Frm_TF_Apply(_menuTag, _chineseName, _mdiParent);
                    f = frm_tfsq1;
                    break;
                default:
                    throw new Exception("�����������ƴ���");
            }
            return f;
        }

        /// <summary>
        /// ��ø�Dll����Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_mzys_blcflr";						//��dll���ļ�����,�����������ռ䱣��һ��
            objectInfo.Text = "��������";								//����������,����Ϊ��
            objectInfo.Remark = "";							//������,����Ϊ��
            return objectInfo;
        }
        /// <summary>
        /// ��ø�Dll��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[17];
            objectInfos[0].Name = "Fun_ts_mzys_blcflr";
            objectInfos[0].Text = "��������";
            objectInfos[0].Remark = "";
            objectInfos[1].Name = "Fun_ts_mzys_jzlscx";
            objectInfos[1].Text = "���˾�����ʷ��ѯ";
            objectInfos[1].Remark = "����ѯ��ǰҽ����½���ҵĽ�����ʷ";
            objectInfos[2].Name = "Fun_ts_mzys_jzlscx_all";
            objectInfos[2].Text = "���˾�����ʷ��ѯ";
            objectInfos[2].Remark = "��ѯ����ҽ��������ʷ";
            objectInfos[3].Name = "Fun_ts_mzys_blcflr_grmb";
            objectInfos[3].Text = "����ģ��ά��";
            objectInfos[3].Remark = "����ģ��ά��";
            objectInfos[4].Name = "Fun_ts_mzys_blcflr_kjmb";
            objectInfos[4].Text = "�Ƽ�ģ��ά��";
            objectInfos[4].Remark = "Ժ��ģ��ά��";
            objectInfos[5].Name = "Fun_ts_mzys_blcflr_yjmb";
            objectInfos[5].Text = "Ժ��ģ��ά��";
            objectInfos[5].Remark = "Ժ��ģ��ά��";
            objectInfos[6].Name = "Fun_ts_mzys_blcflr_zyzdj";
            objectInfos[6].Text = "סԺ֤�Ǽ�";
            objectInfos[6].Remark = "סԺ֤�Ǽ�";
            objectInfos[7].Name = "Fun_ts_mzys_blcflr_wtsq";
            objectInfos[7].Text = "ί������";
            objectInfos[7].Remark = "ί������";
            objectInfos[8].Name = "Fun_ts_zyys_blcflr";
            objectInfos[8].Text = "סԺҽ�����ﴦ��¼��";
            objectInfos[8].Remark = "סԺҽ�����ﴦ��¼��";
            objectInfos[9].Name = "Fun_ts_mzys_zymbwh";
            objectInfos[9].Text = "������עģ��ά��";
            objectInfos[9].Remark = "������עģ��ά��";
            //Add By zp 2014-02-07
            objectInfos[10].Name = "Fun_ts_mztfsh";
            objectInfos[10].Text = "�����˷����";
            objectInfos[10].Remark = "�����˷����";//Fun_ts_mzys_yyjbsh

            objectInfos[11].Name = "Fun_ts_mzys_yyjbsh";
            objectInfos[11].Text = "��ҩ�������";
            objectInfos[11].Remark = "��ҩ�������";

            objectInfos[12].Name = "Fun_ts_zyzCx";
            objectInfos[12].Text = "סԺ֤��ѯ";
            objectInfos[12].Remark = "סԺ֤��ѯ";

            //add by zouchihua ҽ���˷�������ԹҲ˵����ɱ�����ҽ���������� 2014-9-14
            objectInfos[13].Name = "Fun_ts_mztfsq_ys";
            objectInfos[13].Text = "�����˷�����";
            objectInfos[13].Remark = "�����˷�����";//Fun_ts_mzys_yyjbsh

            //add by zouchihua ҽ���˷�������ԹҲ˵����ɱ�����ҽ���������� 2014-9-14
            objectInfos[14].Name = "Fun_ts_mztfsq_hj";
            objectInfos[14].Text = "�����˷�����(����)";
            objectInfos[14].Remark = "�����˷�����(����)";//Fun_ts_mzys_yyjbsh

            objectInfos[15].Name = "Fun_ts_mzys_blcflr_xdcf_yj";
            objectInfos[15].Text = "Ժ��Э������ά��";
            objectInfos[15].Remark = "Ժ��Э������ά��";

            objectInfos[16].Name = "Fun_ts_mzys_blcflr_xdcf_kj";
            objectInfos[16].Text = "�Ƽ�Э������ά��";
            objectInfos[16].Remark = "�Ƽ�Э������ά��";
            return objectInfos;
        }
        #endregion

        /// <summary>
        /// ������ add by zp 2013-06
        /// </summary>
        private DataTable BindRoom()
        {
            DataTable tb = new DataTable();
            try
            {
                SystemCfg _cfg3065 = new SystemCfg(3065);//ҽ��ѡ������ģʽ1ͨ������+�Ű༶�� 2ͨ��IP��ȡ���� 
                string sql = "";
                if (_cfg3065.Config == "1")
                {
                    int time = 1; //������ 1����2����
                    DateTime date_Now = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase);
                    if (date_Now.Hour > 12)
                    {
                        time = 2;
                    }
                    sql = @"SELECT A.ZJID,A.ZJMC,A.bz,A.KSDM FROM JC_ZJSZ AS A
                            INNER JOIN JC_FZ_ZQ AS B ON A.ZQID=B.ZQ_ID
                            INNER JOIN JC_FZ_ZQ_DEPT AS C ON A.KSDM=C.DEPT_ID
                            INNER JOIN JC_MZ_YSPB AS D ON D.PBKSID=A.KSDM
                            INNER JOIN JC_FZ_KSDYJB AS E ON E.GHJB=D.ZZJBID
                            WHERE D.YSID=" + InstanceForm.BCurrentUser.EmployeeId + @" 
                            AND CONVERT(VARCHAR(10),PBSJ,120)= CONVERT(VARCHAR(10),GETDATE(),120) 
                            AND D.PBLX=" + time + @"
                            GROUP BY A.ZJMC,A.bz,A.ZJID,A.KSDM";
                }
                else  //ͨ��IP��ȡָ��������
                {
                    ts_mzys_class.Fz_Zq zq = new ts_mzys_class.Fz_Zq();
                    string ip = zq.GetLoacalHostIP();
                    sql = @"SELECT A.ZJID,A.ZJMC,A.bz ,a.ksdm FROM JC_ZJSZ a WHERE TXIP='" + ip + "'";
                }
                tb = InstanceForm.BDatabase.GetDataTable(sql);

            }
            catch (Exception ea)
            {
                MessageBox.Show("�����쳣!ԭ��:" + ea.Message);
            }
            return tb;
        }

        /// <summary>
        /// �Ƿ���Ҫѡ����� true��Ҫѡ false����Ҫѡ Add by zp 2014-08-22
        /// </summary>
        /// <returns></returns>
        private bool IsSelectRoom(DateTime _date)
        {
            try
            {
                SystemCfg _cfg3142 = new SystemCfg(3142);
                if (_cfg3142.Config.Trim() == "0")
                    return true; //��Ҫ��Ҫ���Ű�ҲҪѡ���
                else
                {
                    /*���Ű�����ѯ�Ƿ�ǰҽ�����Ű���Ϣ,û���򷵻�false ������Ҫѡ�����*/
                    int pblx=0;
                    if (_date.Hour >= 12 && _date.Hour <= 18)
                        pblx = 2;
                    if (_date.Hour >= 7 && _date.Hour <= 11)
                        pblx = 1;
               
                    string sql = @"SELECT isnull(id,0) FROM jc_mz_yspb WHERE PBKSID="+InstanceForm.BCurrentDept.DeptId+@" AND 
                    YSID="+InstanceForm.BCurrentUser.EmployeeId+@" AND CONVERT(VARCHAR(10),PBSJ,120)='"+_date.ToString("yyyy-MM-dd")+@"' 
                    AND PBLX="+pblx+@" AND BSCBZ=0";
                    if (Convert.ToInt32(InstanceForm.BDatabase.GetDataResult(sql)) == 0) //û���Ű�
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ea)
            {
                throw ea;
            }
        }
        #endregion
    }
}
