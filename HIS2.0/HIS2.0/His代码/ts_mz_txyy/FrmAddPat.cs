using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenClasses.GeneralClasses;

namespace ts_mz_txyy
{
    public partial class FrmAddPat : Form
    {
        public bool _bSuc = false;
        public string _CardNo = "";

        public FrmAddPat()
        {
            InitializeComponent();
        }

        private void FrmAddPat_Load(object sender, EventArgs e)
        {
            _bSuc = false;

            DoBindPatientType();
            DoBindPatientSex();

            txtbrxm.Select();
            txtbrxm.Focus();
        }

        private void DoBindPatientType()
        {
            //����ԤԼ��ʱ����  Ĭ��ֻ����ʱ��   д��
            DataTable dt = new DataTable();
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(new object[] { "16", "��ʱ" });
            dt.AcceptChanges();

            Addcmb(cmbbrlx, dt, "Code", "Name");

            cmbbrlx.SelectedIndex = 0;
        }

        private void DoBindPatientSex()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(new object[] { "", "" });
            dt.Rows.Add(new object[] { "1", "��" });
            dt.Rows.Add(new object[] { "2", "Ů" });
            dt.AcceptChanges();

            Addcmb(cmbxb, dt, "Code", "Name");

            cmbbrlx.SelectedIndex = 0;
        }

        public void Addcmb(System.Windows.Forms.ComboBox cmb, DataTable dtSrc, string valueMem, string displayMem)
        {
            cmb.ValueMember = valueMem;
            cmb.DisplayMember = displayMem;
            cmb.DataSource = dtSrc;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            try
            {
                string sex = Convertor.IsNull(cmbxb.SelectedValue, "");//�Ա��¼
                string name = txtbrxm.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("������ ����");
                    txtbrxm.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(sex))
                {
                    MessageBox.Show("��ѡ�� �Ա�");
                    cmbxb.Focus();
                    return;
                }

                if (MessageBox.Show("�Ƿ񱣴�?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                string brlx = cmbbrlx.SelectedValue.ToString();
                string sfzh = txtsfzh.Text.Trim();
                string birthday = dtpcsrq.Value.ToString("yyyy-MM-dd");
                string tel = txtjtdh.Text.Trim();
                string addr = txtAddr.Text.Trim();

                #region ------------------------------------ 2017-04-05���� ���ò��˽����ӿ� ------------------------------------
                StringBuilder sb = new StringBuilder();
                #region ���xml
                sb.Append("<root>");
                sb.Append(string.Format("<Name>{0}</Name>", name));
                sb.Append(string.Format("<Sex>{0}</Sex>", sex));
                sb.Append(string.Format("<BirthDate>{0}</BirthDate>", birthday));
                sb.Append(string.Format("<CivilState>{0}</CivilState>", ""));
                sb.Append(string.Format("<PatientType>{0}</PatientType>", brlx)); //16Ϊ��ʱ��
                sb.Append("<Nationality>156</Nationality>"); //156Ϊ�й�
                sb.Append("<NativePlace>0</NativePlace>"); //
                sb.Append("<Ethnicity>HA</Ethnicity>");
                sb.Append("<Profession>90</Profession>");
                sb.Append(string.Format("<HospitalId>{0}</HospitalId>", 1000));
                sb.Append("<cardTypeId>2</cardTypeId>");
                sb.Append("<cardNo></cardNo>");
                sb.Append(string.Format("<createUserId>{0}</createUserId>", InstanceForm.BCurrentUser.EmployeeId));
                sb.Append(string.Format("<UserCode>{0}</UserCode>", ""));
                sb.Append(string.Format("<IdCard>{0}</IdCard>", sfzh));
                sb.Append(string.Format("<Telephone>{0}</Telephone>", tel));
                sb.Append(string.Format("<HomeAddress>{0}</HomeAddress>", addr));
                sb.Append("</root>");
                #endregion

                string patNo = "";
                bool isCreateSuc = CreateInpInfo(sb, out patNo);

                if (isCreateSuc)
                {
                    _bSuc = true;
                    _CardNo = patNo;
                    this.Close();
                }
                else
                {
                    _bSuc = false;
                    return;
                }


                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool CreateInpInfo(StringBuilder sb, out string patNo)
        {
            patNo = "";
            try
            {
                try
                {
                    string url = GetCreatPatienFileURL();
                    if (string.IsNullOrEmpty(url))
                        throw new InvalidOperationException("���˽����ӿڵ�URL��ַ��Ч");

                    WsNewHisPat.WebService ws = new WsNewHisPat.WebService();
                    ws.Url = url;// @"http://192.168.201.1:19889//WebService.asmx?wsdl";//��ʽ�������

                    string response = ws.AddPatientAndCardByXML(sb.ToString());

                    System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                    document.LoadXml(response);
                    System.Xml.XmlNode ndCode = document.SelectSingleNode("root/resultCode");
                    if (ndCode == null)
                        throw new InvalidOperationException("���ص�xml����Ҳ���root/resultCode�ڵ�");
                    if (ndCode.InnerText == "200")
                    {
                        System.Xml.XmlNode nPatientNo = document.SelectSingleNode("root/PatientNo");
                        if (nPatientNo == null)
                            throw new InvalidOperationException("���ص�xml����Ҳ���root/PatientNo�ڵ�");

                        //�����ɹ�  ����ndPatientId���ܷ񷵻� patientNo  ������
                        patNo = nPatientNo.InnerText;
                    }
                    else
                    {
                        System.Xml.XmlNode ndError = document.SelectSingleNode("root/message");
                        throw new InvalidOperationException(ndError.InnerText);
                    }
                }
                catch (Exception error)
                {
                    throw new InvalidOperationException(string.Format("���ý����ӿڳ���:{0}\r\n���:{1}", error.ToString(), sb.ToString()) + "\r\n" + string.Format("�������˵���ʧ��->{0}", error.Message), error);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void butquit_Click(object sender, EventArgs e)
        {
            _bSuc = false;
            _CardNo = "";
            this.Close();
        }


        /// <summary>
        /// �س�������һ���ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoNext(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            if (e.KeyChar == 13)
            {
                if (control.Name.Equals("txtsfzh"))
                {
                    if (txtsfzh.Text.Trim().Length == 18)
                    {
                        try
                        {
                            string nl = txtsfzh.Text.Substring(6, 4) + "-" + txtsfzh.Text.Substring(10, 2) + "-" + txtsfzh.Text.Substring(12, 2);

                            DateTime csny = DateTime.Parse(nl);

                            dtpcsrq.Value = csny;
                        }
                        catch { }
                    }
                }

                this.SelectNextControl(control, true, false, false, false);
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        internal static string GetCreatPatienFileURL()
        {
            try
            {
                string xml = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PatientFileWebserviceCfg.xml");

                if (!System.IO.File.Exists(xml))
                    return "";

                System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                document.Load(xml);

                System.Xml.XmlNode node = document.SelectSingleNode("PatientFileService/Address");

                if (node == null)
                    return "";

                string url = node.Attributes["URL"].Value;
                return url;
            }
            catch (Exception error)
            {
                return "";
            }
        }
    }
}