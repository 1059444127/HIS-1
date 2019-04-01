using System;
using System.Collections.Generic;
using System.Text;
using TrasenFrame.Classes;
using System.Data;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class
{
    public class ts_dbz_yb
    {
        //������
        public static void dbz_yb_js(Guid brxxid, Guid ghxxid, string mzh, User _BCurrentUser, Department _BCurrentDept, RelationalDatabase _DataBase)
        {
            #region ������ֵ

            SystemCfg cfg1063 = new SystemCfg(1063);// �Ƿ��Զ�ȷ�� Add By Zj 2012-07-02

            DataTable tb = mz_sf.Select_Wsfcf(0, Guid.Empty, ghxxid, 0, 0, Guid.Empty,1, _DataBase);

            string ssql = "";

            //���鴦��
            string[] GroupbyField = { "HJID", "����ID", "ҽ��ID", "ִ�п���ID", "סԺ����ID", "��Ŀ��Դ", "����", "��������", "hjy", "���۴���" };
            string[] ComputeField = { "���", "hjmxid" };
            string[] CField = { "sum", "count" };
            TrasenFrame.Classes.TsSet xcset = new TrasenFrame.Classes.TsSet();
            xcset.TsDataTable = tb;
            DataTable tbcf = xcset.GroupTable(GroupbyField, ComputeField, CField, "1=1");
            if (tbcf.Rows.Count == 0) { MessageBox.Show("û��Ҫ�շѵĴ���"); return; }

            Guid _hjid = Guid.Empty;
            int _xmly = 0;

            //���ر���
            int err_code = -1;
            string err_text = "";
            //ʱ��
            string sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();

            #endregion

            #region �������
            try
            {
                //������˿���
                //ҽ�����˴�����Ҫ���
                //SystemCfg syscfg1 = new SystemCfg(1042);
                //if (syscfg1.Config == "1" && Convertor.IsNull(cmbyblx.SelectedValue, "0") != "0")
                //{
                //    DataRow[] rows = tb.Select(" ���״̬=0 or ���״̬=2");
                //    if (rows.Length > 0)
                //    {
                //        MessageBox.Show("�ò����д���δͨ�����,�����շ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //}
                //���в��˵�ҩƷ������Ҫ���
                SystemCfg syscfg2 = new SystemCfg(1043);
                if (syscfg2.Config == "1")
                {
                    DataRow[] rows = tb.Select(" (���״̬=0 or ���״̬=2) and ��Ŀ��Դ=1");
                    if (rows.Length > 0)
                    {
                        MessageBox.Show("�ò�����ҩƷ����δͨ�����,�����շ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region ��֤�Ƿ���Ĵ���
            for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
            {
                Guid yz_hjid = new Guid(Convertor.IsNull(tbcf.Rows[i]["hjid"], Guid.Empty.ToString()));
                decimal yz_cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0")), 2);
                ssql = "select * from mz_hjb where hjid='" + yz_hjid + "'";
                DataTable yz_tb = _DataBase.GetDataTable(ssql);
                if (yz_tb.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(yz_tb.Rows[0]["cfje"]) != yz_cfje)
                    {
                        MessageBox.Show("���������Ѹ���,������ˢ�����ݺ����ԣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (yz_tb.Rows[0]["bsfbz"].ToString() == "1")
                    {
                        MessageBox.Show("�����������շ�,������ˢ�����ݺ����ԣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("����������ɾ��,��ˢ�����ݺ����ԣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //add by zouchihua 2013-4-9 ������Ŀ���ж� yzid
                ssql = "select * from mz_hjb_mx where hjid='" + yz_hjid + "' and  yzid='" + tbcf.Rows[i]["yzid"].ToString() + "'";
                DataTable hjmx = _DataBase.GetDataTable(ssql);
                if (hjmx.Rows.Count <= 0)
                {
                    MessageBox.Show("���������Ѿ��޸�,��ˢ�����ݺ����ԣ�", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            try
            {
                sDate = DateManager.ServerDateTimeByDBType(_DataBase).ToString();

                _DataBase.BeginTransaction();

                #region ������������
                //decimal cfje = 0;
                for (int i = 0; i <= tbcf.Rows.Count - 1; i++)
                {
                    //���봦��ͷ
                    Guid _NewCfid = Guid.Empty;
                    string _mzh = mzh;
                    _hjid = new Guid(Convertor.IsNull(tbcf.Rows[i]["hjid"], Guid.Empty.ToString()));
                    int _ksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����id"], "0"));
                    int _ysdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ҽ��id"], "0"));
                    int _zxksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["ִ�п���id"], "0"));
                    int _zyksdm = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["סԺ����id"], "0"));
                    _xmly = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["��Ŀ��Դ"], "0"));
                    int _js = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["����"], "0"));
                    string _cfrq = tbcf.Rows[i]["��������"].ToString();
                    int _hjyid = Convert.ToInt32(Convertor.IsNull(tbcf.Rows[i]["hjy"], "0"));
                    string _hjyxm = Fun.SeekEmpName(_hjyid, _DataBase);
                    string _hjck = tbcf.Rows[i]["���۴���"].ToString();
                    decimal _cfje = Math.Round(Convert.ToDecimal(Convertor.IsNull(tbcf.Rows[i]["���"], "0")), 2);


                    DataRow[] rows = tb.Select("HJID='" + _hjid + "' and ��Ŀid>0");

                    long rowcount = Convert.ToInt32(tbcf.Rows[i]["HJMXID"]);
                    if (rowcount != rows.Length)
                        throw new Exception("���鴦��ʱ��" + rowcount + "��,���봦��ʱ��" + rows.Length + "��.���鴦��״̬��ˢ�´�������");

                    if (rows.Length == 0) throw new Exception("û���ҵ�������ϸ,��͹���Ա��ϵ");
                    mz_cf.SaveCf(Guid.Empty, brxxid, ghxxid, _mzh, _hjck, _cfje, _cfrq, _hjyid, _hjyxm, _hjck, _hjid, _ksdm, Fun.SeekDeptName(_ksdm, _DataBase), _ysdm, Fun.SeekEmpName(_ysdm, _DataBase), _zyksdm, _zxksdm, Fun.SeekDeptName(_zxksdm, _DataBase), 0, 0, _xmly, 0, _js, TrasenFrame.Forms.FrmMdiMain.Jgbm, out _NewCfid, out err_code, out err_text, _DataBase);
                    if (_NewCfid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                    //�崦����ϸ��

                    for (int j = 0; j <= rows.Length - 1; j++)
                    {

                        int _tcid = Convert.ToInt32(Convertor.IsNull(rows[j]["�ײ�id"], "0"));
                        //������ײ���ֽⱣ��
                        if (_tcid > 0)
                        {
                            #region ������ײ���ֽⱣ��

                            DataRow[] tcrow = tb.Select("HJID='" + _hjid + "' and  �ײ�id=" + _tcid + " ");
                            if (tcrow.Length == 0) throw new Exception("�����ײʹ���ʱ����û���ҵ�ƥ�����");
                            _js = Convert.ToInt32(Convertor.IsNull(tcrow[0]["����"], "0"));
                            DataTable Tabtc = mz_sf.Select_Wsfcf(0, Guid.Empty, ghxxid, _tcid, _js, _hjid, _DataBase);
                            long _tcyzid = Convert.ToInt64(Convertor.IsNull(rows[j]["yzid"], "0"));//Add By Zj 2012-08-14 ����yzid�ж��ײ�
                            DataRow[] rows_tc = Tabtc.Select(" yzid=" + _tcyzid + " ");//" "
                            if (rows_tc.Length == 0) throw new Exception("û���ҵ��ײ͵���ϸ");
                            for (int xx = 0; xx <= rows_tc.Length - 1; xx++)
                            {
                                Guid _NewCfmxid = Guid.Empty;
                                Guid _hjmxid = new Guid(Convertor.IsNull(rows_tc[xx]["hjmxid"], Guid.Empty.ToString()));
                                string _pym = Convertor.IsNull(rows_tc[xx]["ƴ����"], "");
                                string _bm = Convertor.IsNull(rows_tc[xx]["����"], "");
                                string _pm = Convertor.IsNull(rows_tc[xx]["��Ŀ����"], "");
                                string _spm = Convertor.IsNull(rows_tc[xx]["��Ʒ��"], "");
                                string _gg = Convertor.IsNull(rows_tc[xx]["���"], "");
                                string _cj = Convertor.IsNull(rows_tc[xx]["����"], "");
                                decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["����"], "0"));
                                decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["����"], "0"));
                                string _dw = Convertor.IsNull(rows_tc[xx]["��λ"], "");
                                int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["ydwbl"], "0"));
                                decimal _je = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["���"], "0"));
                                string _tjdxmdm = Convertor.IsNull(rows_tc[xx]["ͳ�ƴ���Ŀ"], "");
                                long _xmid = Convert.ToInt64(Convertor.IsNull(rows_tc[xx]["��Ŀid"], "0"));
                                //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["Ƥ����ҩ"], "0"));
                                int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["Ƥ�Ա�־"], "0"));
                                //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["���Ա�־"], "0"));
                                decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["����"], "0"));
                                string _yldw = Convertor.IsNull(rows_tc[xx]["������λ"], "");
                                int _yldwid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["������λid"], "0"));
                                int _dwlx = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["dwlx"], "0"));
                                int _yfid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["�÷�id"], "0"));
                                string _yfmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["�÷�"], "0"));
                                int _pcid = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["Ƶ��id"], "0"));
                                string _pcmc = Convert.ToString(Convertor.IsNull(rows_tc[xx]["Ƶ��"], "0"));
                                decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["����"], "0"));
                                string _zt = Convert.ToString(Convertor.IsNull(rows_tc[xx]["����"], "0"));
                                int _fzxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["�����������"], "0"));
                                int _pxxh = Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["�������"], "0"));
                                decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["������"], "0"));
                                decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows_tc[xx]["�������"], "0"));
                                if (_js != Convert.ToInt32(Convertor.IsNull(rows_tc[xx]["����"], "0"))) throw new Exception("�����������޸�,������ˢ��");
                                mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                    Guid.Empty, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, _tcid, out _NewCfmxid, out err_code, out err_text, _DataBase);
                                if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);

                                #region �ײ�ȷ��
                                if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["ִ�п���ID"], "0")) != 0)
                                {
                                    ParameterEx[] parameters = new ParameterEx[10];
                                    parameters[0].Text = "@CFID";
                                    parameters[0].Value = _NewCfid;
                                    parameters[1].Text = "@CFMXID";
                                    parameters[1].Value = _NewCfmxid;
                                    parameters[2].Text = "@TCID";
                                    parameters[2].Value = _tcid;


                                    parameters[3].Text = "@BQRBZ";
                                    parameters[3].Value = 1;
                                    parameters[4].Text = "@QRKS";
                                    parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["ִ�п���ID"], "0"));
                                    parameters[5].Text = "@QRRQ";
                                    parameters[5].Value = sDate;

                                    parameters[6].Text = "@QRDJY";
                                    parameters[6].Value = _BCurrentUser.EmployeeId;

                                    parameters[7].Text = "@err_code";
                                    parameters[7].ParaDirection = ParameterDirection.Output;
                                    parameters[7].DataType = System.Data.DbType.Int32;
                                    parameters[7].ParaSize = 100;

                                    parameters[8].Text = "@err_text";
                                    parameters[8].ParaDirection = ParameterDirection.Output;
                                    parameters[8].ParaSize = 100;

                                    parameters[9].Text = "@YQRKS";
                                    parameters[9].Value = 0;

                                    _DataBase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                    err_code = Convert.ToInt32(parameters[7].Value);
                                    err_text = Convert.ToString(parameters[8].Value);
                                    if (err_code != 0) throw new Exception(err_text);
                                }
                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            #region ���ײ�
                            Guid _NewCfmxid = Guid.Empty;
                            Guid _hjmxid = new Guid(Convertor.IsNull(rows[j]["hjmxid"], Guid.Empty.ToString()));
                            string _pym = Convertor.IsNull(rows[j]["ƴ����"], "");
                            string _bm = Convertor.IsNull(rows[j]["����"], "");
                            string _pm = Convertor.IsNull(rows[j]["��Ŀ����"], "");
                            string _spm = Convertor.IsNull(rows[j]["��Ʒ��"], "");
                            string _gg = Convertor.IsNull(rows[j]["���"], "");
                            string _cj = Convertor.IsNull(rows[j]["����"], "");
                            decimal _dj = Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0"));
                            decimal _sl = Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0"));
                            string _dw = Convertor.IsNull(rows[j]["��λ"], "");
                            int _ydwbl = Convert.ToInt32(Convertor.IsNull(rows[j]["ydwbl"], "0"));
                            decimal _je = Convert.ToDecimal(Convertor.IsNull(rows[j]["���"], "0"));
                            string _tjdxmdm = Convertor.IsNull(rows[j]["ͳ�ƴ���Ŀ"], "");
                            long _xmid = Convert.ToInt64(Convertor.IsNull(rows[j]["��Ŀid"], "0"));
                            //int _bpsyybz = Convert.ToInt32(Convertor.IsNull(rows[j]["Ƥ����ҩ"], "0"));
                            int _bpsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["Ƥ�Ա�־"], "0"));
                            //int _bmsbz = Convert.ToInt32(Convertor.IsNull(rows[j]["���Ա�־"], "0"));
                            decimal _yl = Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0"));
                            string _yldw = Convertor.IsNull(rows[j]["������λ"], "");
                            int _yldwid = Convert.ToInt32(Convertor.IsNull(rows[j]["������λid"], "0"));
                            int _dwlx = Convert.ToInt32(Convertor.IsNull(rows[j]["dwlx"], "0"));
                            int _yfid = Convert.ToInt32(Convertor.IsNull(rows[j]["�÷�id"], "0"));
                            string _yfmc = Convert.ToString(Convertor.IsNull(rows[j]["�÷�"], "0"));
                            int _pcid = Convert.ToInt32(Convertor.IsNull(rows[j]["Ƶ��id"], "0"));
                            string _pcmc = Convert.ToString(Convertor.IsNull(rows[j]["Ƶ��"], "0"));
                            decimal _ts = Convert.ToDecimal(Convertor.IsNull(rows[j]["����"], "0"));
                            string _zt = Convert.ToString(Convertor.IsNull(rows[j]["����"], ""));
                            int _fzxh = Convert.ToInt32(Convertor.IsNull(rows[j]["�����������"], "0"));
                            int _pxxh = Convert.ToInt32(Convertor.IsNull(rows[j]["�������"], "0"));
                            decimal _pfj = Convert.ToDecimal(Convertor.IsNull(rows[j]["������"], "0"));
                            decimal _pfje = Convert.ToDecimal(Convertor.IsNull(rows[j]["�������"], "0"));
                            Guid _pshjmxid = new Guid(Convertor.IsNull(rows[j]["pshjmxid"], Guid.Empty.ToString()));
                            mz_cf.SaveCfmx(Guid.Empty, _NewCfid, _pym, _bm, _pm, _spm, _gg, _cj, _dj, _sl, _dw, _ydwbl, _js, _je, _tjdxmdm, _xmid, _hjmxid, _bm, 0, _bpsbz,
                                _pshjmxid, _yl, _yldw, _yfmc, _pcid, _ts, _zt, _fzxh, _pxxh, Guid.Empty, _pfj, _pfje, 0, out _NewCfmxid, out err_code, out err_text, _DataBase);
                            if (_NewCfmxid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                            //Add By Zj 2012-07-10
                            string updatejsdsql = "update mz_cfb_mx set jsd='" + Convert.ToString(Convertor.IsNull(rows[j]["JSD"], "0")) + "' where cfmxid='" + _NewCfmxid.ToString() + "' ";
                            _DataBase.DoCommand(updatejsdsql);
                            #region ���ײ�ȷ��
                            if (cfg1063.Config == "1" && Convert.ToInt32(Convertor.IsNull(rows[j]["ִ�п���ID"], "0")) != 0)
                            {
                                ParameterEx[] parameters = new ParameterEx[10];
                                parameters[0].Text = "@CFID";
                                parameters[0].Value = _NewCfid;
                                parameters[1].Text = "@CFMXID";
                                parameters[1].Value = _NewCfmxid;
                                parameters[2].Text = "@TCID";
                                parameters[2].Value = 0;


                                parameters[3].Text = "@BQRBZ";
                                parameters[3].Value = 1;
                                parameters[4].Text = "@QRKS";
                                parameters[4].Value = Convert.ToInt32(Convertor.IsNull(rows[j]["ִ�п���ID"], "0"));
                                parameters[5].Text = "@QRRQ";
                                parameters[5].Value = sDate;

                                parameters[6].Text = "@QRDJY";
                                parameters[6].Value = _BCurrentUser.EmployeeId;

                                parameters[7].Text = "@err_code";
                                parameters[7].ParaDirection = ParameterDirection.Output;
                                parameters[7].DataType = System.Data.DbType.Int32;
                                parameters[7].ParaSize = 100;

                                parameters[8].Text = "@err_text";
                                parameters[8].ParaDirection = ParameterDirection.Output;
                                parameters[8].ParaSize = 100;

                                parameters[9].Text = "@YQRKS";
                                parameters[9].Value = 0;

                                _DataBase.GetDataTable("SP_YJ_SAVE_QRJL_MZ", parameters, 60);
                                err_code = Convert.ToInt32(parameters[7].Value);
                                err_text = Convert.ToString(parameters[8].Value);
                                if (err_code != 0) throw new Exception(err_text);
                            }
                            #endregion
                            #endregion ���ײ�
                        }

                    }


                }
                #endregion

                _DataBase.CommitTransaction();

            }
            catch (System.Exception err)
            {
                _DataBase.RollbackTransaction();
                MessageBox.Show("�������ݳ���!" + err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
