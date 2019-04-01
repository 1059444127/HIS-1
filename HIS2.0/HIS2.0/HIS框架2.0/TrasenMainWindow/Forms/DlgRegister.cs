using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;

namespace TrasenMainWindow
{
    /// <summary>
    /// ϵͳע��Ի���
    /// </summary>
    public class DlgRegister : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TextBox txtRegisterCode;
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// ϵͳע�ṹ�캯��
        /// </summary>
        public DlgRegister()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRegisterCode = new System.Windows.Forms.TextBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOK.Location = new System.Drawing.Point(101, 217);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(92, 30);
            this.btOK.TabIndex = 12;
            this.btOK.Text = "ȷ��(&O)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancel.Location = new System.Drawing.Point(286, 217);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(92, 30);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "ȡ��(&C)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRegisterCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 136);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ע����";
            // 
            // txtRegisterCode
            // 
            this.txtRegisterCode.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterCode.Location = new System.Drawing.Point(6, 20);
            this.txtRegisterCode.Multiline = true;
            this.txtRegisterCode.Name = "txtRegisterCode";
            this.txtRegisterCode.Size = new System.Drawing.Size(454, 110);
            this.txtRegisterCode.TabIndex = 15;
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(9, 22);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(464, 23);
            this.lblCaption.TabIndex = 15;
            this.lblCaption.Text = "    ����ϵ��������̲����������ṩ��ע��������ע����༭��";
            // 
            // DlgRegister
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(484, 265);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���ע��";
            this.Load += new System.EventHandler(this.DlgRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void btCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            string keyCode = txtRegisterCode.Text.Trim();
            try
            {
                TrasenRegister.Licence.Exists(keyCode, WorkStaticFun.GetConfigValueByCode(0002, TrasenFrame.Forms.FrmMdiMain.Database));
                TrasenRegister.Licence.UpdateRegCode(TrasenFrame.Forms.FrmMdiMain.Database, keyCode);
                MessageBox.Show("ע��ɹ�����������������");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DlgRegister_Load(object sender, System.EventArgs e)
        {

        }
    }
}
