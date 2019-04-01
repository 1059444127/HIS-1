using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using ts_mz_class;

namespace ts_mz_tjbb
{
    public partial class frmHtdwdzje : Form
    {
        /// <summary>
        /// ��Ʊ��
        /// </summary>
        private string _fph;
        public string fph
        {
            set { _fph = value; }
            get { return _fph; }
        }
        /// <summary>
        /// ��Ʊ���
        /// </summary>
        private string _fpid;
        public string fpid
        {
            set { _fpid = value; }
            get { return _fpid; }
        }
        /// <summary>
        /// ������
        /// </summary>
        private decimal _Je;
        public decimal Je
        {
            set { _Je = value; }
            get { return _Je; }
        }

        public frmHtdwdzje()
        {
            InitializeComponent();
        }
        private void txtJe_Enter(object sender, EventArgs e)
        {
            if (this.txtJe.Text == "��������")
                this.txtJe.Text = "";
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnQr_Click(object sender, EventArgs e)
        {
            try
            {
                decimal del_je;
                //��֤����
                if (String.IsNullOrEmpty(txtJe.Text.Trim()))
                {
                    MessageBox.Show("����Ϊ��.");
                    this.txtJe.Focus();
                    return;
                } 
                del_je = decimal.Parse(txtJe.Text.Trim());
                if (del_je < 0)
                {
                    MessageBox.Show("����С��0!");
                    return;
                }
                if (del_je > _Je)
                {
                    MessageBox.Show("���ܴ��ڹ��˽��: " + _Je.ToString());
                    return;
                }

                //��װ
                MZ_HTDW_DZLOG obj = new MZ_HTDW_DZLOG();
                obj.FPID = _fpid;
                obj.FPH = _fph;
                obj.JE = del_je;
                obj.QRRY = InstanceForm.BCurrentUser.EmployeeId; 
                obj.QRRYXM = InstanceForm.BCurrentUser.Name;
                obj.BWCBZ = 1;
                obj.BSCBZ = 0;
                obj.BZ = txtBz.Text.Trim();

                //����
                int num = mz_sf.Save_htdwdzlog(obj.FPID, obj.FPH, obj.JE, obj.QRRY, obj.QRRYXM, obj.BWCBZ, obj.BSCBZ, obj.BZ, TrasenFrame.Forms.FrmMdiMain.Database);
                if (num > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("����ʧ��, Ӱ����Ϊ0.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmHtdwdzje_Load(object sender, EventArgs e)
        {
            if (_Je > 0)
            {
                txtJe.Text = _Je.ToString();
            }
        }

        private void txtJe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBz_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }

    public class MZ_HTDW_DZLOG
    {
        private string _DZID;
        private string _FPID;
        private string _FPH;
        private decimal _JE;
        private DateTime? _QRRQ;
        private int _QRRY;
        private string _QRRYXM;
        private int _BWCBZ;
        private int _BSCBZ;
        private string _BZ;

        /// <summary>
        /// ��־����(guid)
        /// </summary>
        public string DZID
        {
            set { _DZID = value; }
            get { return _DZID; }
        }
        /// <summary>
        /// ��Ʊ����(guid)
        /// </summary>
        public string FPID
        {
            set { _FPID = value; }
            get { return _FPID; }
        }
        /// <summary>
        /// ��Ʊ��
        /// </summary>
        public string FPH
        {
            set { _FPH = value; }
            get { return _FPH; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public decimal JE
        {
            set { _JE = value; }
            get { return _JE; }
        }
        /// <summary>
        /// ȷ������
        /// </summary>
        public DateTime? QRRQ
        {
            set { _QRRQ = value; }
            get { return _QRRQ; }
        }
        /// <summary>
        /// ȷ���˱���
        /// </summary>
        public int QRRY
        {
            set { _QRRY = value; }
            get { return _QRRY; }
        }
        /// <summary>
        /// ȷ��������
        /// </summary>
        public string QRRYXM
        {
            set { _QRRYXM = value; }
            get { return _QRRYXM; }
        }
        /// <summary>
        /// ���˱�־
        /// </summary>
        public int BWCBZ
        {
            set { _BWCBZ = value; }
            get { return _BWCBZ; }
        }
        /// <summary>
        /// ɾ����־
        /// </summary>
        public int BSCBZ
        {
            set { _BSCBZ = value; }
            get { return _BSCBZ; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string BZ
        {
            set { _BZ = value; }
            get { return _BZ; }
        }
    }
}