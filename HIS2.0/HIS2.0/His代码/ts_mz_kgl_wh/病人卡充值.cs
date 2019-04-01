using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_kgl
{
    public delegate void OnAfterRechargeSuccessHanld();
    public partial class Frmbrkcz : Form
    {
        public event OnAfterRechargeSuccessHanld AfterRechargeSuccess;

        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid Kdjid = Guid.Empty;
        private Guid Brxxid = Guid.Empty;
        /// <summary>
        /// ������˿��Ƿ���Ҫ��֤���� 0 ����Ҫ 1��Ҫ Ĭ��0
        /// </summary>
        SystemCfg cfg1059 = new SystemCfg(1059);
        /// <summary>
        /// ���￨��ֵ�Ƿ�ֻ��ˢ�� 0=�� 1=��
        /// </summary>
        SystemCfg cfg1085 = new SystemCfg(1085);

        SystemCfg cfg1111 = new SystemCfg(1111);

        private string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
        private string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
        public Frmbrkcz(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            this.WindowState = FormWindowState.Maximized;

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
        }

        public Frmbrkcz(RelationalDatabase _DataBase, User _User, Department _BCurrentDept,int klx,string kh)
        {
            InstanceForm.BDatabase = _DataBase;

            InstanceForm.BCurrentUser = _User;

            InstanceForm.BCurrentDept = _BCurrentDept;

            InitializeComponent();

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            this.cmbklx.SelectedValue = klx;

            cmbklx.SelectedValue = klx.ToString();

            if (kh != "")
            {
                txtkh.Text = kh;
                txtkh_KeyPress(null, null);
            }


        }


        private void Frmbrkdj_Load(object sender, EventArgs e)
        {

            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);

            SystemCfg cfg1113 = new SystemCfg(1113);

            string str="SELECT NAME,CODE FROM JC_FKFS";
            if (cfg1113.Config != "")
                str += " where code not in(" + cfg1113.Config + ")";

            //���ʽ�ֵ�
            DataTable tb = InstanceForm.BDatabase.GetDataTable(str);
            if (tb == null)
            {
                MessageBox.Show("����δ��ȡ�ø��ʽ��");
                return;
            }
            cmbfkfs.DisplayMember = "NAME";
            cmbfkfs.ValueMember = "CODE";
            cmbfkfs.DataSource = tb;
            tb = null;
            cmbfkfs.SelectedIndex = 0;

            //���л�����Ϣ
            tb = InstanceForm.BDatabase.GetDataTable("SELECT NAME,ID FROM JC_BANK");
            if (tb == null)
            {
                MessageBox.Show("���棬δ��ȡ��������Ϣ��", "��ʾ");
                return;
            }
            cmbyh.DisplayMember = "NAME";
            cmbyh.ValueMember = "ID";
            cmbyh.DataSource = tb;
            cmbyh.SelectedIndex = -1;
            tb = null;

            #region ���������� Add By tck
            try
            {
                string bqybjq = ApiFunction.GetIniString("�������ļ�·��", "���ñ�����", Constant.ApplicationDirectory + "//ClientWindow.ini");
                if (bqybjq == "true")
                {
                    string bjqxh = ApiFunction.GetIniString("�������ļ�·��", "�������ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.SetPicture(InstanceForm.BCurrentUser.EmployeeId.ToString());  //(txtxm.Text.Trim());
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("�����������쳣!ԭ��:" + ea.Message, "��ʾ");
            }
            #endregion

            if ( !txtkh.ReadOnly )
            {
                //�Զ�����Ƶ��
                string sbxh = ApiFunction.GetIniString( "ҽԺ������" , "�豸�ͺ�" , Constant.ApplicationDirectory + "//ClientWindow.ini" );
                ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall( sbxh );
                if ( ReadCard != null )
                    ReadCard.AutoReadCard( _menuTag.Function_Name , cmbklx , txtkh );
            }
            //����Ԥ�����Ƿ�Ҫ��ӡ��Ʊ ����ǣ����ȡԤ����Ʊ��
            if (cfg1111.Config.Trim() == "1")
                getYjjFph();
          
        }

        DataTable tbfp = null;

        private void getYjjFph()
        {
            //��ȡԤ����Ʊ��  ADD BY jiangzf 2014-2-25
            int err_code;
            string err_text;
            tbfp = Fun.GetFph(InstanceForm.BCurrentUser.EmployeeId, 1, 3, out err_code, out err_text, InstanceForm.BDatabase);
            if (tbfp.Rows.Count == 0 || err_code != 0)
            {
                MessageBox.Show(err_text, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblfph.Text = Convertor.IsNull(tbfp.Rows[0]["QZ"], "") + tbfp.Rows[0]["fph"].ToString().Trim(); 
        }

        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void txtkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e != null)
            {
                if ((int)e.KeyChar != 13)
                {
                    if (cfg1085.Config.Trim() == "1")
                        e.Handled = true;
                    return;
                }
            }
            Kdjid = Guid.Empty;
            Brxxid = Guid.Empty;
            int klx = Convert.ToInt32(cmbklx.SelectedValue);
            txtkh.Text = Fun.returnKh(klx, txtkh.Text.Trim(), InstanceForm.BDatabase);
            txtkh.Text = ToDBC(txtkh.Text);
            string ssql = "select *,dbo.fun_zy_age(csrq,3,getdate()) ����,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա� from YY_KDJB a inner join YY_BRXX b  on a.brxxid=b.brxxid and  klx=" + klx + " and kh='" + txtkh.Text.Trim() + "' and zfbz=0";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            if (tb.Rows.Count == 0) { MessageBox.Show("û���ҵ�����Ϣ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            Kdjid = new Guid(tb.Rows[0]["kdjid"].ToString());
            Brxxid = new Guid(tb.Rows[0]["brxxid"].ToString());

            lblbrxm.Text = Convertor.IsNull(tb.Rows[0]["brxm"], "");
            lblxb.Text = Convertor.IsNull(tb.Rows[0]["�Ա�"], "");
            lblnl.Text = Convertor.IsNull(tb.Rows[0]["����"], "");
            lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["brlxfs"], "");
            lblgzdw.Text = Convertor.IsNull(tb.Rows[0]["gzdw"], "");
            lbldwdh.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
            lbljtdz.Text = Convertor.IsNull(tb.Rows[0]["jtdz"], "");
            lblsfzh.Text = Convertor.IsNull(tb.Rows[0]["sfzh"], "");//Add By Zj 2012-05-28 ���֤��
            if (lbllxfs.Text == "") lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["jtdh"], "");
            if (lbllxfs.Text == "") lbllxfs.Text = Convertor.IsNull(tb.Rows[0]["gzdwdh"], "");
            Fill(Kdjid);
    
            if (bqybjq == "true" && bjqxh == "�Ϻ�ͨ�������������ͺŢ�")
            {
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.����, lblbrxm.Text);
            }
            else if (bqybjq == "true" && bjqxh == "�Ϻ�ͨ������������������һ����ҽԺ")
            {
                //ADD BY TCK 2013-11-21
                ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                call.Call(ts_call.DmType.����, lblbrxm.Text);
            }
            txtje.Focus();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            SystemCfg cfg1121 = new SystemCfg(1121);
            if (cfg1121.Config == "1")
            {
                int out_code = 0;
                string out_text = "";
                Fun.Isjz(InstanceForm.BCurrentUser.EmployeeId, out out_code, out out_text, InstanceForm.BDatabase);
                if (out_code == -1)
                {
                    MessageBox.Show(out_text);
                    return;
                }
            }
            mz_card card;
            try
            {
                if (cfg1111.Config.Trim() == "1" && lblfph.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("û�п��÷�Ʊ��,�����շ�!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                if (Kdjid == Guid.Empty) { MessageBox.Show("�����뿨��Ϣ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                //��ʾ������
                card = new mz_card(Convert.ToInt32(cmbklx.SelectedValue), InstanceForm.BDatabase);
                if (txtkh.Text.Length != card.kcd)
                {
                    MessageBox.Show("��λ���������ϵͳ�趨����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReadCard readcard = new ReadCard(Convert.ToInt32(cmbklx.SelectedValue), txtkh.Text.Trim(), InstanceForm.BDatabase);
                if (readcard.kdjid != Kdjid)
                {
                    MessageBox.Show("Ч�鿨��Ϣʱ����,�����¶���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (card.bjebz == false)
                {
                    MessageBox.Show("�˿����ܴ�����,��μ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (readcard.sdbz == 1)
                {
                    MessageBox.Show("���˿��Ѷ��ᣬ�ݲ������ѡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (readcard.sdbz == 2)
                {
                    MessageBox.Show("���˿��ѹ�ʧ���ݲ������ѡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (Convertor.IsNumeric(txtje.Text.Trim()) == false || txtje.Text.Trim() == "0")
            {
                MessageBox.Show("�������������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtje.SelectAll();
                txtje.Focus();
                return;
            }

            decimal Crje = Convert.ToDecimal(Convertor.IsNull(txtje.Text, "0"));

            string ssql = "select * from YY_KDJB where kdjid='" + Kdjid + "'";
            DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssql);
            if (Convert.ToDecimal(tbk.Rows[0]["kye"]) + Crje < 0)
            {
                MessageBox.Show("����˱ʽ���,����Ϊ������������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Crje < 0)
            {
                if (MessageBox.Show("��ȷ��Ҫ�˿�" + Crje.ToString() + "��?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                //Add By Zj 2012-04-19 �˿�����������֤
                if (cfg1059.Config == "1")
                {
                    ts_mz_class.FrmPassWord fPassword = new FrmPassWord(InstanceForm._menuTag, "�˿�������֤", this, InstanceForm.BDatabase);
                    fPassword.Kdjid = Kdjid;
                    if (fPassword.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

            Guid _kjeid = Guid.Empty;
            int err_code = -1;
            string err_text = "";
            int fkfs = Convert.ToInt32(cmbfkfs.SelectedValue);

            if (fkfs == 2)
            {
                if (txtzph.Text.Trim() == "") { MessageBox.Show("������֧Ʊ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtdw.Text.Trim() == "") { MessageBox.Show("�����뿪����λ", "����", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (cmbyh.Text.Trim() == "") { MessageBox.Show("�����뿪������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }


            try
            {
                InstanceForm.BDatabase.BeginTransaction();

                //�Ǽǽ���
                mz_kdj.Kdj_je(Guid.Empty, Kdjid, Brxxid, fkfs, lblfph.Text, Crje, InstanceForm.BCurrentUser.EmployeeId, djsj, txtbz.Text.Trim(), txtzph.Text.Trim(), txtdw.Text.Trim(), cmbyh.Text.Trim(), out _kjeid, out err_code, out err_text, InstanceForm.BDatabase);
                if (_kjeid == Guid.Empty || err_code != 0) throw new Exception(err_text);
                //����
                if (checkBox1.Checked == true)
                    mz_kdj.Kdj_je_zpdz(_kjeid, Kdjid, Brxxid, fkfs, Crje, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                //����Ԥ����Ʊ���ñ�ĵ�ǰ��Ʊ����
                string Msg = "";
                if (cfg1111.Config.Trim() == "1")
                    mz_sf.UpdateDqfph(new Guid(tbfp.Rows[0]["fpid"].ToString()), tbfp.Rows[0]["fph"].ToString().Trim(), tbfp.Rows[tbfp.Rows.Count - 1]["fph"].ToString().Trim(), out Msg, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                Print(_kjeid);

                radioButton1.Checked = true;

                Fill(Kdjid);

                //��ʾ��Ʊ���Ѿ����� --ADD jiangzf 2014-2-25
                if (Msg.Trim() != "")
                    MessageBox.Show(Msg, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.Text = "";
                txtje.Text = "";
                txtbz.Text = "";
                txtkh.SelectAll();
                txtkh.Focus();
                MessageBox.Show("�ɹ�", "��ʾ");
                this.txtkh.Text = "";
                this.lblbrxm.Text = "";
                lblye.Text = "";
                lblgzdw.Text = "";
                lblsfzh.Text = "";
                lblxb.Text = "";
                lblnl.Text = "";

                //���»�ȡԤ����Ʊ��
                if (cfg1111.Config.Trim() == "1")
                    getYjjFph();
                
                //txtkh_KeyPress(null,new KeyPressEventArgs('\r'));

                if (bqybjq == "true" && bjqxh == "�Ϻ�ͨ�������������ͺŢ�")
                {
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.Call(ts_call.DmType.����ֵ, Crje.ToString("0.00"));
                }
                else if (bqybjq == "true" && bjqxh == "�Ϻ�ͨ������������������һ����ҽԺ")
                {
                    //ADD BY TCK 2013-11-21
                    ts_call.Icall call = ts_call.CallFactory.NewCall(bjqxh);
                    call.Call(ts_call.DmType.����ֵ, Crje.ToString("0.00"));

                }
                if ( AfterRechargeSuccess != null )
                    AfterRechargeSuccess();
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Print(Guid kjeid)
        {
            try
            {
                string ssql = "select dbo.FUN_ZY_SEEKFKFSNAME(a.fkfs) ֧����ʽ,b.kye,a.* from yy_kdjb_je a inner join yy_kdjb b on a.kdjid=b.kdjid where a.kjeid='" + kjeid.ToString() + "' and a.bzfbz=0 and a.bdzbz=1";
                DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
                if (tb.Rows.Count != 0)
                {
                    ts_mz_report.DataSet1 Dset = new ts_mz_report.DataSet1();
                    DataRow myrow;

                    myrow = Dset.Ԥ�տ�.NewRow();

                    myrow["����"] = tb.Rows[0]["֧����ʽ"].ToString();
                    myrow["Ʊ�ݺ�"] = tb.Rows[0]["pjh"].ToString();
                    myrow["���"] = tb.Rows[0]["crje"].ToString();
                    myrow["�տ�����"] = tb.Rows[0]["djsj"].ToString();
                    myrow["�տ�Ա"] = Fun.SeekEmpName(Convert.ToInt32(tb.Rows[0]["djy"]), InstanceForm.BDatabase);
                    myrow["��д���"] = Money.NumToChn(tb.Rows[0]["crje"].ToString());
                    myrow["����"] = tb.Rows[0]["khyh"].ToString();
                    myrow["��λ"] = tb.Rows[0]["khdw"].ToString();
                    myrow["����"] = lblbrxm.Text;
                    myrow["֧Ʊ��"] = tb.Rows[0]["zph"].ToString();
                    myrow["����"] = txtkh.Text;
                    myrow["����"] = lblnl.Text;
                    myrow["�Ա�"] = lblxb.Text;
                    myrow["��ϵ��ʽ"] = lbllxfs.Text;
                    myrow["��ע"] = tb.Rows[0]["bz"].ToString();
                    Dset.Ԥ�տ�.Rows.Add(myrow);

                    ParameterEx[] parameters = new ParameterEx[2];

                    parameters[0].Text = "ҽԺ����";
                    parameters[0].Value = TrasenFrame.Classes.Constant.HospitalName + "����Ԥ�տ�ƾ֤";
                    //Add by zp 2014-01-07 ������������
                    parameters[1].Text = "�����";
                    parameters[1].Value = tb.Rows[0]["kye"];

                    TrasenFrame.Forms.FrmReportView f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_Ԥ�տ�Ʊ��.rpt", parameters);

                    string Bview = ApiFunction.GetIniString("�����շ�", "��ƱԤ��", Constant.ApplicationDirectory + "//ClientWindow.ini");

                    if (Bview == "true")
                    {
                        if (f.LoadReportSuccess)
                            f.Show();
                        else
                            f.Dispose();
                    }
                    else
                    {
                        f = new TrasenFrame.Forms.FrmReportView(Dset, Constant.ApplicationDirectory + "\\Report\\MZ_Ԥ�տ�Ʊ��.rpt", parameters, true);
                    }
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Fill(Guid kdjid)
        {
            string ssql = "select '' ���,dbo.FUN_ZY_SEEKFKFSNAME(fkfs) ֧����ʽ,crje ���,djsj �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,dzrq ����ʱ��,dbo.fun_getempname(dzy) ����Ա,zph ֧Ʊ��,khyh ����,khdw ������λ,bz ��ע,kjeid,bdzbz,fkfs,kdjid as kid ,zfrq �������� from YY_KDJB_je ";
            if (kdjid != Guid.Empty)
                ssql = ssql + " where kdjid='" + kdjid + "'";
            else
                ssql = ssql + "";
            DataTable tb = InstanceForm.BDatabase.GetDataTable(ssql);
            Fun.AddRowtNo(tb);
            this.DateGridView1.DataSource = tb;

            if (kdjid == Guid.Empty) return;
            ssql = "select * from YY_KDJB where kdjid='" + kdjid + "'";
            DataTable tbk = InstanceForm.BDatabase.GetDataTable(ssql);
            lblye.Text = tbk.Rows[0]["kye"].ToString();
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbfkfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fkfs = Convert.ToInt32(cmbfkfs.SelectedValue);
            //�ֽ��Pos����ʽ
            if (fkfs != 2)
            {
                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.SelectedIndex = -1;
                checkBox1.Checked = true;

                txtzph.Enabled = false;
                txtdw.Enabled = false;
                cmbyh.Enabled = false;
                checkBox1.Enabled = false;
            }
            //֧Ʊ����ʽ
            else
            {
                txtzph.Text = "";
                txtdw.Text = "";
                cmbyh.SelectedIndex = -1;
                checkBox1.Checked = false;

                txtzph.Enabled = true;
                txtdw.Enabled = true;
                cmbyh.Enabled = true;
                checkBox1.Enabled = true;
            }
            txtje.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Fill(Guid.Empty);
        }

        private void DateGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgv in DateGridView1.Rows)
            {
                if (Convertor.IsNull(dgv.Cells["��������"].Value, "") != "")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Red;
                }

                if (Convertor.IsNull(dgv.Cells["fkfs"].Value, "") == "2" && Convertor.IsNull(dgv.Cells["����ʱ��"].Value, "") == "" && Convertor.IsNull(dgv.Cells["��������"].Value, "") == "")
                {
                    dgv.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void mnudzqr_Click(object sender, EventArgs e)
        {
            try
            {
                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                Guid kid = new Guid(tb.Rows[nrow]["kid"].ToString());
                Guid kjeid = new Guid(tb.Rows[nrow]["kjeid"].ToString());
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                decimal je = Convert.ToDecimal(tb.Rows[nrow]["���"]);
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                if (bdzbz == 1) { MessageBox.Show("�ѵ���,�����ٴ�ȷ��", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                InstanceForm.BDatabase.BeginTransaction();

                mz_kdj.Kdj_je_zpdz(kjeid, kid, Brxxid, fkfs, je, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);

                InstanceForm.BDatabase.CommitTransaction();

                Print(kjeid);

                Fill(kid);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuzfjk_Click(object sender, EventArgs e)
        {
            try
            {

                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;


                if (MessageBox.Show("��ȷ�����ϵ�ǰԤ�տ�����?", "ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if (tb.Rows[nrow]["�Ǽ�Ա"].ToString().Trim() != InstanceForm.BCurrentUser.Name.Trim())
                {
                    MessageBox.Show("�Ǳ��˵Ǽǵ�Ԥ�տ�,����Ȩ����"); return;
                }
                Guid kid = new Guid(tb.Rows[nrow]["kid"].ToString());
                Guid kjeid = new Guid(tb.Rows[nrow]["kjeid"].ToString());
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                decimal je = Convert.ToDecimal(tb.Rows[nrow]["���"]);
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();

                InstanceForm.BDatabase.BeginTransaction();
                mz_kdj.Kdj_je_zf(kid, kjeid, Brxxid, je, djsj, InstanceForm.BCurrentUser.EmployeeId, InstanceForm.BDatabase);
                InstanceForm.BDatabase.CommitTransaction();
                Fill(kid);
            }
            catch (System.Exception err)
            {
                InstanceForm.BDatabase.RollbackTransaction();
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                int nrow = this.DateGridView1.CurrentCell.RowIndex;
                DataTable tb = (DataTable)this.DateGridView1.DataSource;
                if (nrow > tb.Rows.Count - 1) return;
                int bdzbz = Convert.ToInt32(tb.Rows[nrow]["bdzbz"]);
                int fkfs = Convert.ToInt32(tb.Rows[nrow]["fkfs"]);
                string zfrq = Convert.ToString(tb.Rows[nrow]["��������"]);

                if (bdzbz == 1)
                {
                    mnudzqr.Enabled = false;
                    mnuzfjk.Enabled = true;
                }
                if (zfrq.Trim() != "")
                    mnuzfjk.Enabled = false;
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }

        private void txtkh_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((char)e.KeyData != '\r')
            //{
            //    e.Handled = true;
            //    return;
            //}
        }

        private void txtkh_KeyUp(object sender, KeyEventArgs e)
        {

            
        }

    }
}