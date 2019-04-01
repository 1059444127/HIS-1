using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;
using TrasenClasses.GeneralClasses;
using YpClass;

namespace ts_yf_ypck
{
    public partial class Frmqr : Form
    {
        public int uid=0;
        public string uname;

        public Frmqr()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string name = txtuname.Text;//�û�id
            string mm = txtmm.Text.Trim();//����
            

            User user = new User(name, InstanceForm.BDatabase);
            if (user.EmployeeId <= 0)
            {
                MessageBox.Show("�û������ڣ�");
                return;
            }

            if (user.CheckPassword(mm))
            {
                uid = user.EmployeeId;
                this.Close();
            }
            else
            {
                MessageBox.Show("�������");
                return;
            }

             
            
        }
    }
}