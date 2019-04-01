using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;

namespace ts_mz_class
{
    public partial class Frmsf : Form
    {
        public bool Bok = false;
        public bool Bybsf = false;
        public int fpzs = 0; //�����շѷ�Ʊ����
        private Form _mdiParent;
        private MenuTag _menuTag;
        private string _chineseName;
        public Guid kdjid = Guid.Empty;
        public int klx = 0;
        public RelationalDatabase _DataBase;

        public Frmsf( MenuTag menuTag , string chineseName , Form mdiParent , RelationalDatabase DataBase )
        {
            InitializeComponent();

            _menuTag = menuTag;
            _chineseName = chineseName;
            _mdiParent = mdiParent;

            this.Text = _chineseName;
            _DataBase = DataBase;
        }

        private void groupBox1_Enter( object sender , EventArgs e )
        {

        }

        private void label22_Click( object sender , EventArgs e )
        {

        }

        private void Frmsf_Load( object sender , EventArgs e )
        {
            #region ����������Ŀ���
            string ylzf = new SystemCfg( 1012 ).Config == "0" ? "true" : "false";

            txtpos.Enabled = ylzf == "true" ? true : false;
            //this.groupBox2.Visible = false;
            //this.Height = this.Height - 83;
            txtssxj.Focus();
            //BindZffs();//
            #endregion
        }
        //��֧����ʽ ��ʾ�� Add by zp 2013-11-22
        private void BindZffs()
        {
            try
            {
                string sql = @"SELECT ZFFSID,ZFFSNAME FROM JC_ZFFS";
                DataTable dt = _DataBase.GetDataTable( sql );
                this.Cmb_Zffs.ValueMember = "ZFFSID";
                this.Cmb_Zffs.DisplayMember = "ZFFSNAME";
                this.Cmb_Zffs.DataSource = dt;
            }
            catch ( Exception ea )
            {
                MessageBox.Show( "�����쳣!ԭ��:" + ea.Message , "��ʾ" );
            }
        }

        private void butok_Click( object sender , EventArgs e )
        {

            try
            {
                //������
                mz_card card = new mz_card( klx , _DataBase );

                //��ȡ���˿����
                ReadCard readcard = new ReadCard( kdjid , _DataBase );

                //У�鿨����
                if ( klx != 0 && card.bmm == true && readcard.kye > 0 )
                {
                    FrmPassWord fw = new FrmPassWord( _menuTag , "" , _mdiParent , _DataBase );
                    fw.Kdjid = kdjid;
                    if ( fw.ShowDialog() == DialogResult.Cancel )
                        return;

                    //comment by wangzhi ��β���Ҫ����Ϊ������֤�Ѿ������봰����֤
                    //if (fw.PassWord.Trim() != Convertor.IsNull(readcard.kmm, ""))
                    //{
                    //    MessageBox.Show("������֤����ȷ", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }

                decimal zje = Convert.ToDecimal( Convertor.IsNull( lblzje.Text , "0" ) );
                decimal yhje = Convert.ToDecimal( Convertor.IsNull( lblyhje.Text , "0" ) );
                decimal srje = Convert.ToDecimal( Convertor.IsNull( lblsrje.Text , "0" ) );

                decimal ybzf = Convert.ToDecimal( Convertor.IsNull( txtybzf.Text , "0" ) );
                decimal qfgz = Convert.ToDecimal( Convertor.IsNull( txtqfgz.Text , "0" ) );
                decimal cwjz = Convert.ToDecimal( Convertor.IsNull( txtcwjz.Text , "0" ) );
                decimal pos = Convert.ToDecimal( Convertor.IsNull( txtpos.Text , "0" ) );
                decimal ysxj = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );

                decimal zpzf = Convert.ToDecimal( Convertor.IsNull( txtzpzf.Text , "0" ) );

                decimal sumzje = ( yhje ) + ( ybzf ) + ( qfgz + cwjz + pos ) + ysxj + zpzf;

                //////if (Bybsf == true && fpzs > 1)
                //////{
                //////    MessageBox.Show("ҽ�������շ�ʱ��ÿ��ֻ����ȡһ�ŷ�Ʊ,������ڶ��ŷ�Ʊ��ִ���ȡ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //////    return;
                //////}

                //��������ʵ�ս��
                SystemCfg cg = new SystemCfg( 1032 );
                if ( cg.Config == "1" && ysxj > 0 && ssxj <= 0 )
                {
                    MessageBox.Show( "������ʵ���ֽ�" , "����" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }
                if ( cg.Config == null )
                    return;
                if ( ssxj < ysxj && ssxj > 0 )
                {
                    MessageBox.Show( "ʵ���ֽ���ȷ,��ȷ��" , "����" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }
                if ( ysxj == 0 && ssxj > 0 )
                {
                    MessageBox.Show( "�ò��˲���Ҫ�ֽ�֧��." , "����" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    txtssxj.Focus();
                    return;
                }

                //���鹫�Ե�ƽ����
                if ( sumzje != zje )
                {
                    MessageBox.Show( "����֧����ʽ��ƽ��,����ȷ����" , "����" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }

                if ( _chineseName == "����ҺŵǼ�" && zpzf > 0 )//Add By Zj 2012-12-26 ��Ϊ��ǩ��֧Ʊ֧��������ʵ��ҵ����Ҳû�����ã�������ʱ��ֹ
                {
                    MessageBox.Show( "����ҺŵǼǲ���ʹ��֧Ʊ֧��!" , "��ʾ" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return;
                }

                if ( fpzs > 1 && _chineseName != "����ҺŵǼ�" )//Modify By Zj 2012-12-19 ����ҺŵǼ� �������֧����ʽ ���� ֻ�йҺŷѻ�ʹ��ҽ��֧�� ����
                {
                    if ( ( ysxj > 0 && pos > 0 ) || ( ysxj > 0 && cwjz > 0 ) || ( ysxj > 0 && qfgz > 0 ) || ( ysxj > 0 && zpzf > 0 ) || ( ysxj > 0 && ybzf > 0 ) || ( pos > 0 && cwjz > 0 ) || ( pos > 0 && qfgz > 0 ) || ( pos > 0 && zpzf > 0 ) || ( pos > 0 && ybzf > 0 ) || ( cwjz > 0 && qfgz > 0 ) || ( zpzf > 0 && qfgz > 0 ) || ( cwjz > 0 && ybzf > 0 ) || ( zpzf > 0 && ybzf > 0 ) || ( qfgz > 0 && ybzf > 0 ) )
                    {
                        MessageBox.Show( "���ж��ŷ�Ʊʱ,ÿ��ֻ����һ��֧����ʽ�����Ʊ�շ�" , "��ʾ" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        return;
                    }
                }

                if ( fpzs > 1 && _chineseName == "����ҺŵǼ�" )//Modify By Zj 2012-12-26 ����ҺŵǼ� �������֧����ʽ ���� ֻ֧�� �ֽ�+ҽ�� ���� POS+ҽ�� ���� �������+ҽ��
                {
                    if ( ( ysxj > 0 && pos > 0 ) || ( ysxj > 0 && cwjz > 0 ) || ( ysxj > 0 && qfgz > 0 ) || ( ysxj > 0 && zpzf > 0 ) || ( pos > 0 && cwjz > 0 ) || ( pos > 0 && qfgz > 0 ) || ( pos > 0 && zpzf > 0 ) || ( cwjz > 0 && qfgz > 0 ) || ( zpzf > 0 && qfgz > 0 ) || ( zpzf > 0 && ybzf > 0 ) )
                    {
                        MessageBox.Show( "����ҺŶ��ŷ�Ʊ֧����֧�� ҽ��֧��+(�ֽ�,POS,�������) �����е�����һ��." , "��ʾ" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        return;
                    }
                }
                if ( ysxj < 0 || ybzf < 0 || pos < 0 || qfgz < 0 || cwjz < 0 || zpzf < 0 )
                {
                    MessageBox.Show( "֧������в����и��� " , "��ʾ" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }

                if ( ybzf < 0 || qfgz < 0 || pos < 0 || cwjz < 0 )
                {
                    MessageBox.Show( "֧�����Ϊ���� " , "��ʾ" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }

                Bok = true;
                this.Close();
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "����" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }

        private void butquit_Click( object sender , EventArgs e )
        {
            Bok = false;
            this.Close();
        }

        private void txtzhzf_TextChanged( object sender , EventArgs e )
        {
            try
            {
                decimal zje = Convert.ToDecimal( Convertor.IsNull( lblzje.Text , "0" ) );
                decimal yhje = Convert.ToDecimal( Convertor.IsNull( lblyhje.Text , "0" ) );
                decimal srje = Convert.ToDecimal( Convertor.IsNull( lblsrje.Text , "0" ) );

                decimal ybzf = Convert.ToDecimal( Convertor.IsNull( txtybzf.Text , "0" ) );
                decimal qfgz = Convert.ToDecimal( Convertor.IsNull( txtqfgz.Text , "0" ) );
                decimal cwjz = Convert.ToDecimal( Convertor.IsNull( txtcwjz.Text , "0" ) );
                decimal pos = Convert.ToDecimal( Convertor.IsNull( txtpos.Text , "0" ) );

                decimal zpzf = Convert.ToDecimal( Convertor.IsNull( txtzpzf.Text , "0" ) );

                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                decimal zlje = 0;

                decimal ysxj = ( zje - yhje ) - ( ybzf ) - ( qfgz + cwjz + pos + zpzf );
                lblysxj.Text = ysxj.ToString();
                if ( ssxj > 0 )
                {
                    zlje = ssxj - ysxj;
                    lblzl.Text = zlje.ToString();
                }
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "����" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

        }

        private void txtssxj_TextChanged( object sender , EventArgs e )
        {
            try
            {
                decimal ysxj = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                decimal zlje = ssxj - ysxj;
                //if (zlje > 0)
                lblzl.Text = zlje.ToString();
                //else 
                //    lblzl.Text = "";
            }
            catch ( System.Exception err )
            {
                MessageBox.Show( err.Message , "����" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }
        }

        private void txtssxj_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                decimal xjzf = Convert.ToDecimal( Convertor.IsNull( lblysxj.Text , "0" ) );
                decimal ssxj = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                //if (ssxj < xjzf && ssxj!=0)
                //{
                //    return;
                //}

                decimal zlje = Convert.ToDecimal( Convertor.IsNull( txtssxj.Text , "0" ) );
                if ( zlje < 0 )
                {
                    if ( MessageBox.Show( this , "��ȷ��������Ϊ������?" , "ȷ��" , MessageBoxButtons.YesNo , MessageBoxIcon.Question , MessageBoxDefaultButton.Button1 ) == DialogResult.No )
                        return;
                }
                butok_Click( sender , e );
            }
        }

        private void Frmsf_Activated( object sender , EventArgs e )
        {
            txtssxj.Focus();
        }

        private void Language_Off( object sender , System.EventArgs e )
        {
            Control control = (Control)sender;

            control.ImeMode = ImeMode.Close;
            Fun.SetInputLanguageOff();
        }

        private void Language_On( object sender , System.EventArgs e )
        {
            Control control = (Control)sender;
            control.ImeMode = ImeMode.On;
            Fun.SetInputLanguageOff();
        }

        private void Frmsf_KeyUp( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.F2 && butok.Enabled == true )
            {
                butok_Click( sender , e );
            }
            if ( e.KeyCode == Keys.Escape )
                butquit_Click( sender , e );
        }

        private void txtssxj_KeyUp( object sender , KeyEventArgs e )
        {
            Control control = (Control)sender;
            if ( e.KeyCode == Keys.Right )
            {
                if ( control.Name == "txtssxj" && txtpos.Enabled == true )
                {
                    txtpos.Focus();
                    txtpos.SelectAll();
                    return;
                }
                if ( control.Name == "txtcwjz" && txtpos.Enabled == true )
                {
                    txtpos.Focus();
                    txtpos.SelectAll();
                    return;
                }
            }
            if ( e.KeyCode == Keys.Left )
            {
                if ( control.Name == "txtpos" )
                {
                    txtssxj.Focus();
                    txtssxj.SelectAll();
                    return;
                }
            }
            if ( e.KeyCode == Keys.Up )
            {
                if ( control.Name == "txtssxj" && txtcwjz.Enabled == true )
                {
                    txtcwjz.Focus();
                    txtcwjz.SelectAll();
                    return;
                }
                if ( control.Name == "txtpos" && txtqfgz.Enabled == true )
                {
                    txtqfgz.Focus();
                    txtqfgz.SelectAll();
                    return;
                }
                if ( control.Name == "txtzpzf" && txtpos.Enabled == true )
                {
                    txtpos.Focus();
                    txtpos.SelectAll();
                    return;
                }
            }
            if ( e.KeyCode == Keys.Down )
            {
                if ( control.Name == "txtssxj" )
                {
                    butok.Focus();
                    return;
                }
                if ( control.Name == "txtpos" && txtzpzf.Enabled == true )
                {
                    txtzpzf.Focus();
                    txtzpzf.SelectAll();
                    return;
                }
                if ( control.Name == "txtzpzf" )
                {
                    butok.Focus();
                    return;
                }
            }
        }

        private void txtpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                butok_Click(sender, e);
            }
        }
    }
}