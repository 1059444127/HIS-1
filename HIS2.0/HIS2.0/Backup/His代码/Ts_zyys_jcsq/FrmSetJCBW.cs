using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ts_zyys_public;
namespace Ts_zyys_jcsq
{
    public partial class FrmSetJCBW : Form
    {
        private string strPosition = "";
        private string strRemaer = "";
        private string strAction = "";
        private string strBw_code = "";//add  by   chenli  ���Ӳ�λ����  2017-06-30
        private string strBw_xs = "";//add  by   chenli  ���Ӳ�λϵ��  2017-06-30
        private string strBw_class = "";//add  by   chenli  ���Ӳ�λ����  2017-06-30

        public FrmSetJCBW(string _strAction)
        {
            InitializeComponent();
            strAction = _strAction;
        }

        //public FrmSetJCBW(string _strPosition, string _strRemaer, string _strActon, string _strBw_code, string _strBw_xs, string _strBw_class)
        //{
        //    InitializeComponent();
        //    strPosition = _strPosition;
        //    strRemaer = _strRemaer;
        //    strAction = _strActon;
        //    strBw_code = _strBw_code;
        //    strBw_xs = _strBw_xs;
        //    strBw_class = _strBw_class;
        //}
        public FrmSetJCBW(string _strPosition, string _strRemaer, string _strActon, string _strBw_code,string _strBw_xs,string _strBw_class)//add by  chenli 2017-06-30
        {
            InitializeComponent();
            strPosition = _strPosition;
            strRemaer = _strRemaer;
            strAction = _strActon;
            strBw_code = _strBw_code;
            strBw_xs = _strBw_xs;
            strBw_class = _strBw_class;
        }



       

        private void FrmSetJCBW_Load(object sender, EventArgs e)
        {
            if (strAction == "Update")
            {
                this.txtSiteName.Text = strPosition;
                this.txtRemaker.Text = strRemaer;
                this.txtBW_CODE.Text = strBw_code;
                this.txtbw_class.Text = strBw_class;
                this.txtbw_xs.Text = strBw_xs;
            }
        }

        private void btn_����_Click(object sender, EventArgs e)
        {
            if (System.Text.Encoding.Default.GetByteCount(txtRemaker.Text) > 50)
            {
                MessageBox.Show("��������̫��,ֻ������25��������");
                this.txtRemaker.Focus();
                return;
            }
            if (System.Text.Encoding.Default.GetByteCount(txtSiteName.Text) > 50)
            {
                MessageBox.Show("��������̫��,ֻ������25��������");
                this.txtSiteName.Focus();
                return;
            }
            if (System.Text.Encoding.Default.GetByteCount(txtBW_CODE.Text) > 50)
            { 
                 MessageBox.Show("��������̫��,ֻ������50���ַ�");
                this.txtBW_CODE.Focus();
                return;
            }
            if (System.Text.Encoding.Default.GetByteCount(txtbw_class.Text) > 50)
            {
                MessageBox.Show("��������̫��,ֻ������50���ַ�");
                this.txtbw_class.Focus();
                return;
            }



            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public CheckSiteInfo GetCheckSite()
        {
            CheckSiteInfo info = new CheckSiteInfo();
            if (txtSiteName.Text.ToString() != ""||txtBW_CODE.Text.ToString().Trim()!="")
            {
             
                info.Checksitename = txtSiteName.Text.ToString();
                info.Checksiteremarker = txtRemaker.Text.ToString();
                info.Checksitecode = txtBW_CODE.Text.ToString();
                info.Checksiteclass = txtbw_class.Text.ToString();
                info.Checksitexs = txtbw_xs.Text.ToString();
            }
            else
            {
                MessageBox.Show("��鲿λ���ƻ���벻��Ϊ��", "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return info;
        }

        private void btn_ȡ��_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void txtSiteName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtRemaker.Focus();
           
            }
        }

        private void txtRemaker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btn_����.Focus();
            }
        }

        private void txtbw_class_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbw_xs_TextChanged(object sender, EventArgs e)
        {
            //if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            //{
            //    MessageBox.Show("���������֣�");
            //    return;
            //}
        }
    }
}