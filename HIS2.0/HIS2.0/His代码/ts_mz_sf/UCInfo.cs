using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ts_mz_sf
{
    public partial class UCInfo : UserControl
    {
        public UCInfo()
        {
            InitializeComponent();
        }

        public string ��һ����
        {
            get
            {
                return lbl_xm.Text;
            }
            set
            {
                lbl_xm.Text = value;
            }
        }
        public string �ܽ��
        {
            get
            {
                return lbl_zje.Text;
            }
            set
            {
                lbl_zje.Text = value;
            }
        }
        public string �ֽ�֧��
        {
            get
            {
                return lbl_xjzf.Text;
            }
            set
            {
                lbl_xjzf.Text = value;
            }
        }
        public string ʵ���ֽ�
        {
            get
            {
                return lbl_ssxj.Text;
            }
            set
            {
                lbl_ssxj.Text = value;
            }
        }
        public string ������
        {
            get
            {
                return lbl_zlje.Text;
            }
            set
            {
                lbl_zlje.Text = value;
            }
        }
        public string ֧Ʊ֧��
        {
            get
            {
                return lbl_zpzf.Text;
            }
            set
            {
                lbl_zpzf.Text = value;
            }
        }
        public string ����֧��
        {
            get
            {
                return lbl_ylkzf.Text;
            }
            set
            {
                lbl_ylkzf.Text = value;
            }
        }
        public string ҽ��֧��
        {
            get
            {
                return lbl_ybzf.Text;
            }
            set
            {
                lbl_ybzf.Text = value;
            }
        }
        public string �������
        {
            get
            {
                return lbl_cwjz.Text;
            }
            set
            {
                lbl_cwjz.Text = value;
            }
        }
        public string Ƿ�ѹ���
        {
            get
            {
                return lbl_qfgz.Text;
            }
            set
            {
                lbl_qfgz.Text = value;
            }
        }
        public string �Żݽ��
        {
            get
            {
                return lbl_yhje.Text;
            }
            set
            {
                lbl_yhje.Text = value;
            }
        }
        public string ������
        {
            get
            {
                return lbl_srje.Text;
            }
            set
            {
                lbl_srje.Text = value;
            }
        }

        protected override void OnSizeChanged( EventArgs e )
        {
            this.Size = new Size( 275, 330 );
        }
    }
}
