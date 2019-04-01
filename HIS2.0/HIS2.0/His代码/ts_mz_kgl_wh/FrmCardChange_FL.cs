using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ts_mz_class;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace ts_mz_kgl
{
    public partial class FrmCardChange_FL : Form
    {
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        private Guid _brxxid;
        private Guid _kdjid;
        private Guid _xkdjid;
        private int _xklx;
        public Guid brxxid
        {
            set { _brxxid = value; }
        }
        public Guid kdjid
        {
            set { _kdjid = value; }
        }
        public Guid xkdjid
        {
            get { return _xkdjid; }
        }
        public int xklx
        {
            get { return _xklx; }
        }

        public FrmCardChange_FL(MenuTag menuTag, string chineseName, Form mdiParent)
        {
            InitializeComponent();
            FunAddComboBox.AddKlx(false, 0, cmb_yklx, InstanceForm.BDatabase);
            FunAddComboBox.AddKlx(false, 0, cmbklx, InstanceForm.BDatabase);
            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;
            this.Text = _chineseName;
        }

        private void FrmCardChange_FL_Load(object sender, EventArgs e)
        {
            //�Զ�����Ƶ��
            string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
            ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
            if (ReadCard != null)
                ReadCard.AutoReadCard(InstanceForm._menuTag.Function_Name, cmbklx, txtxkh);
            if (cmbklx.Items.Count>0 && cmbklx.SelectedValue == null)
            {
                cmbklx.SelectedIndex = 0;
            }
        }

        private void butcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butok_Click(object sender, EventArgs e)
        {
            try
            {
                string Newkh = Fun.returnKh(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtxkh.Text, InstanceForm.BDatabase);
                string djsj = DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString();
                decimal kye = Convert.ToDecimal(Convertor.IsNull(txtyj.Text, "0"));
                _xklx = Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0"));
                string kxym = "";

                if (String.IsNullOrEmpty(txtxkh.Text))
                {
                    MessageBox.Show("��¼���¿���Ϣ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //ʵ�����¿��������Ƿ����
                ReadCard newCard = new ReadCard(_xklx, Newkh, InstanceForm.BDatabase);
                if (newCard.kdjid != Guid.Empty)
                {
                    MessageBox.Show(Newkh + "��������ѱ������û�ʹ��,����ȷ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //�Զ�����Ƶ��
                if (newCard.kdjid == Guid.Empty)
                {
                    string sbxh = ApiFunction.GetIniString("ҽԺ������", "�豸�ͺ�", Constant.ApplicationDirectory + "//ClientWindow.ini");
                    ts_Read_hospitalCard.Icall ReadCard = ts_Read_hospitalCard.CardFactory.NewCall(sbxh);
                    if (ReadCard != null)
                    {
                        kxym = ReadCard.CreateKxym();
                        bool bok = ReadCard.WriterCard(Newkh, kxym, "", kxym);
                        if (bok == false)
                            throw new Exception("д��û�гɹ�");
                    }
                }
                //��������
                ParameterEx[] parameters = new ParameterEx[11];

                parameters[0].Text = "@kdjid";
                parameters[0].Value = _kdjid.ToString();

                parameters[1].Text = "@XKLX";
                parameters[1].Value = _xklx;

                parameters[2].Text = "@XKH";
                parameters[2].Value = Newkh;

                parameters[3].Text = "@BZ";
                parameters[3].Value = txtbz.Text.Trim();

                parameters[4].Text = "@XKXYM";
                parameters[4].Value = kxym;

                parameters[5].Text = "@XKXLH";
                parameters[5].Value = "";

                parameters[6].Text = "@DJY";
                parameters[6].Value = TrasenFrame.Forms.FrmMdiMain.CurrentUser.EmployeeId;

                parameters[7].Text = "@JGBM";
                parameters[7].Value = TrasenFrame.Forms.FrmMdiMain.Jgbm;

                parameters[8].Text = "@XKDJID";
                parameters[8].ParaDirection = ParameterDirection.Output;
                parameters[8].DataType = System.Data.DbType.String;
                parameters[8].ParaSize = 50;

                parameters[9].Text = "@err_code";
                parameters[9].ParaDirection = ParameterDirection.Output;
                parameters[9].DataType = System.Data.DbType.Int32;

                parameters[10].Text = "@err_text";
                parameters[10].ParaDirection = ParameterDirection.Output;
                parameters[10].DataType = System.Data.DbType.String;
                parameters[10].ParaSize = 100;

                InstanceForm.BDatabase.DoCommand("SP_MZGH_KDJ_HK", parameters, 30);
                _xkdjid = new Guid(parameters[8].Value.ToString());
                int err_code = Convert.ToInt32(parameters[9].Value);
                string err_text = Convert.ToString(parameters[10].Value);
                if (err_code == -1)
                {
                    throw new Exception(err_text);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btn_news_Click(object sender, EventArgs e)
        {
            Frmbrkdj f = new Frmbrkdj(_menuTag, "������ϸ��Ϣ", _mdiParent, _brxxid, _kdjid);
            f.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string sql = "select brxm ,dbo.FUN_ZY_SEEKSEXNAME(xb) as xb from yy_brxx where brxxid ='" + _brxxid + "'";
                DataTable dt = InstanceForm.BDatabase.GetDataTable(sql);
                if (dt.Rows.Count == 1)
                {
                    lblxm.Text = dt.Rows[0]["brxm"].ToString();
                    lblxb.Text = dt.Rows[0]["xb"].ToString();
                }
            }
        }

        private void txtxkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtxkh.Text = Fun.returnKh(Convert.ToInt32(cmbklx.SelectedValue), txtxkh.Text, InstanceForm.BDatabase);
                ReadCard rd = new ReadCard(Convert.ToInt32(Convertor.IsNull(cmbklx.SelectedValue, "0")), txtxkh.Text, InstanceForm.BDatabase);
                if (rd.kdjid != Guid.Empty)
                {
                    string zt = " ����";
                    if (rd.zfbz == true) zt = "������";
                    if (rd.sdbz == 1) zt = zt + " �Ѷ���";
                    if (rd.sdbz == 2) zt = zt + " �ѹ�ʧ";
                    MessageBox.Show(txtxkh.Text + "���ſ����ڱ���ʹ��,��״̬:" + zt, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtxkh.Focus();
                }
            }
        }

        private void Language_Off(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOff();

        }

        private void Language_On(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.KatakanaHalf;
            Fun.SetInputLanguageOn();
        }
    }
}
