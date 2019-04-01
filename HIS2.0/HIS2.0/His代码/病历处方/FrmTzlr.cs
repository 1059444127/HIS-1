using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using ts_mz_class;
using TrasenFrame.Forms;
namespace ts_mzys_blcflr
{

    /// <summary>
    /// ����¼�� add by zouchihua 2013-6-28
    /// </summary>
    public partial class FrmTzlr : Form
    {
        /// <summary>
        /// �����ַ���
        /// </summary>
        public string Tzinfo = "";
        /// <summary>
        /// �Һ���Ϣid 
        /// </summary>
        private Guid _ghxxid;
        private Guid _brxxid;
        private DataTable tb;
        BindingManagerBase bm;
        public FrmTzlr(string xm, string kh,  string ks, string xb, string nl,Guid ghxxid,Guid brxxid)
        {
            InitializeComponent();
            this.txtkh.Text = kh;
            this.txtdeptname.Text = ks;
            this.txtage.Text = nl;
            this.txtname.Text = xm;
            this.txtxb.Text = xb;
            _ghxxid = ghxxid;
            _brxxid = brxxid;
        }

        private void FrmTzlr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmTzlr_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from MZ_BRTZ where delete_bit=0 and ghxxid='" + _ghxxid + "'";
                tb = FrmMdiMain.Database.GetDataTable(sql);
                bm = this.BindingContext[tb, ""];
                Ts_Clinicalpathway_Factory.PublicFunction.Bindtext(this.groupBox3, tb);
                this.ActiveControl = textBox7;
                textBox7.Focus();
            }
            catch (Exception ea)
            {
                MessageBox.Show("�����쳣!ԭ��:" + ea.Message, "��ʾ");
            }
        }

        private void txtxy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
                //this.DialogResult = DialogResult.No;
                //if ((sender as TextBox).Name == "textBox2")
                //    this.SelectNextControl((sender as TextBox), true, false, false, true);
            }
        }
        /// <summary>
        /// ֵ�����ж�
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        private void Typepd(Control ct,string  type,string value)
       {
           if (value.Trim() == "")
               return;
              switch(type)
              {
                  case "System.Decimal":
                      if (!System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"(^[0-9]+(.[0-9]{1,3})?$)"))
                      {
                          ct.Focus();
                          MessageBox.Show("��������������");
                      }
                      break;
                  case "System.Int32":
                      if (!System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), @"(^\d{0,4}$)"))
                      {
                          ct.Focus();
                          MessageBox.Show("��������������");
                      }
                      break;
              }
       }
        private void button1_Click(object sender, EventArgs e)
        {
            SetzInfo();
        }
        /// <summary>
        /// Modify By zp 2013-09-11 
        /// </summary>
        private void SetzInfo()
        {
            try
            {
                this.BindingContext[tb, ""].EndCurrentEdit();
                // bm.Position = bm.Position + 1;
                string sql = "select * from MZ_BRTZ where delete_bit=0 and ghxxid='" + _ghxxid + "'";

                if (tb.Rows.Count == 0)
                {
                    DataRow r = tb.NewRow();
                    r["tzid"] = Guid.NewGuid();
                    r["ghxxid"] = _ghxxid;
                    r["brxxid"] = _brxxid;
                    //���ڴ�����ֵ
                    for (int i = 0; i < this.groupBox3.Controls.Count; i++)
                    {
                        if ((this.groupBox3.Controls[i] as TextBox) != null)
                        {
                            string name = (this.groupBox3.Controls[i] as TextBox).Tag.ToString();
                            string value = (this.groupBox3.Controls[i] as TextBox).Text;//this.textBox7.Text
                            r[name] = value;
                        }
                    }
                    tb.Rows.Add(r);
                }
                Tzinfo = "";
                Tzinfo = "Ѫѹ(mmHg)��" + this.textBox7.Text.Trim() + " || Ѫ��(mmoL/L )��" + this.textBox6.Text.Trim()
                     + "|| ����(��)��" + this.textBox5.Text.Trim() + "|| ����(����)��" + this.textBox4.Text.Trim()
                     + "|| ������" + this.textBox3.Text.Trim() + "|| ����(kg)��" + this.textBox2.Text.Trim();
                
                Ts_Clinicalpathway_Factory.PublicFunction.databaseupdate(sql, tb);
               
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Int32",(sender as Control).Text);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Decimal", (sender as Control).Text);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Int32", (sender as Control).Text);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            Typepd((sender as Control), "System.Decimal", (sender as Control).Text);
        }
    }
}