using System;
using System.Management;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using System.Resources;
using TrasenClasses.DatabaseAccess;
using System.Net;

namespace TrasenClasses.GeneralClasses
{
    /// <summary>
    /// ������̬����
    /// </summary>
    public class PubStaticFun
    {
        private PubStaticFun()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        #region ȥ�������е�TEXTBOX
        /// <summary>
        /// ȥ�������е�TEXTBOX
        /// </summary>
        /// <param name="grid">��Ҫȥ��TEXTBOX������</param>
        /// <param name="tableStyleIndex">������ʽ������</param>
        /// <returns></returns>
        public static void ModifyDataGridStyle(DataGrid grid, int tableStyleIndex)
        {
            DataGridTextBoxColumn dgtxt = null;
            Type c = typeof(System.Windows.Forms.DataGridTextBoxColumn);
            for (int i = 0; i < grid.TableStyles[tableStyleIndex].GridColumnStyles.Count; i++)
            {
                if (grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType() == c || grid.TableStyles[tableStyleIndex].GridColumnStyles[i].GetType().IsSubclassOf(c))
                {
                    dgtxt = (DataGridTextBoxColumn)grid.TableStyles[tableStyleIndex].GridColumnStyles[i];
                    grid.Controls.Remove(dgtxt.TextBox);
                }
            }
        }
        #endregion

        #region �������ؼ�Ϊ�ı��������Ͽ�ʱ�趨ѡ��������ϱ߾�����߾�
        /// <summary>
        /// �������ؼ�Ϊ�ı��������Ͽ�ʱ�趨ѡ��������ϱ߾�����߾�
        /// </summary>
        /// <param name="occurTextBox">�����ı���</param>
        /// <param name="cardGrid">ѡ������</param>
        /// <param name="parentCtrl">�����ؼ�</param>
        /// <param name="oppositeTop">�ڸ��ؼ��е����������</param>
        /// <param name="oppositeLeft">�ڸ��ؼ��е���Ժ�����</param>
        public static void SetCardGridTopAndLeft(Control occurTextBox, DataGrid cardGrid, Control parentCtrl, int oppositeTop, int oppositeLeft)
        {
            //��������ڴ����ı�����������涼������
            if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop && oppositeTop < cardGrid.Height)
            {
                #region �߶Ȳ��ʺ�
                if (parentCtrl.Parent != null)
                {
                    SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                }
                #endregion
            }
            else
            {
                #region �߶��ʺ�
                cardGrid.Parent = parentCtrl;
                cardGrid.BringToFront();
                if (parentCtrl.Height < cardGrid.Height + occurTextBox.Height + oppositeTop)		//������±߽糬���������ױ߽���ײ��븸�����ױ߽����
                {
                    cardGrid.Top = oppositeTop - cardGrid.Height;
                }
                else
                {
                    cardGrid.Top = oppositeTop + occurTextBox.Height;
                }
                if (parentCtrl.Width < cardGrid.Width + oppositeLeft)
                {
                    cardGrid.Left = oppositeLeft - (cardGrid.Width - occurTextBox.Width);
                    if (cardGrid.Left < 0)	//��Ȳ��ʺ�
                    {
                        if (parentCtrl.Parent != null)
                        {
                            SetCardGridTopAndLeft(occurTextBox, cardGrid, parentCtrl.Parent, oppositeTop + parentCtrl.Top, oppositeLeft + parentCtrl.Left);
                        }
                    }
                }
                else
                {
                    cardGrid.Left = oppositeLeft;
                }
                #endregion
            }
        }
        #endregion

        #region ��ȡMAC��ַ��IP
        /// <summary>
        /// ��ȡMAC��ַ
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            ManagementClass adapters = new ManagementClass("Win32_NetworkAdapterConfiguration");
            string MACAddress = "unknown";
            foreach (ManagementObject adapter in adapters.GetInstances())
            {
                if ((bool)adapter["IPEnabled"] == true)
                {
                    MACAddress = adapter.Properties["MACAddress"].Value.ToString();
                    break;
                }
            }
            return MACAddress;
        }

        /// <summary>
        /// ��ȡIP��ַ
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string ipAdress = "";
            //�õ�������������
            IPHostEntry ipEntry = Dns.GetHostEntry( Dns.GetHostName() ); //ȡ�ñ���IP
            foreach ( System.Net.IPAddress ip in ipEntry.AddressList )
            {
                //2012-12-27 jianqg �޸�ȡip�ķ�������ip ����������Ҫ��win7 ������
                string strIp = ip.ToString();
                if ( strIp.Split( '.' ).Length == 4 )
                {
                    if ( ipAdress.Length <= 0 )
                    {
                        ipAdress = strIp.ToString();
                    }
                    else
                    {
                        ipAdress = ipAdress + "|" + strIp.ToString();
                    }
                }
            }
            return ipAdress;
        }
        #endregion

        #region  �������뷨������ȡ���뷨
        /// <summary>
        /// �������뷨������ȡ���뷨
        /// </summary>
        /// <param name="languageName">���뷨������������ʣ�</param>
        /// <returns></returns>
        public static InputLanguage GetInputLanguage(string languageName)
        {
            foreach (InputLanguage l in InputLanguage.InstalledInputLanguages)
            {
                if (l.LayoutName.IndexOf(languageName) >= 0)
                {
                    return l;
                }
            }
            //�����ǰ���뷨����Ҫ���ҵ����뷨�򷵻�Ĭ�����뷨
            return InputLanguage.DefaultInputLanguage;
        }
        #endregion

        #region �������
        /// <summary>
        /// ���õ�ǰ�ȴ����
        /// </summary>
        /// <returns></returns>
        public static Cursor WaitCursor()
        {
            System.IO.Stream stream = Assembly.LoadFrom(Application.StartupPath + "\\TrasenClasses.dll").GetManifestResourceStream("TrasenClasses.GeneralClasses.wait.cur");
            return new Cursor(stream);
        }
        /// <summary>
        /// ���õ�ǰ���
        /// </summary>
        /// <param name="res">�����Դ·���ַ���</param>
        /// <param name="type">����</param>
        /// <returns></returns>
        public static Cursor GetCursor(string res, Type type)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(type);
            System.IO.Stream stream = assembly.GetManifestResourceStream(res);
            return new Cursor(stream);
        }
        #endregion

        #region �����ڵ�Ӣ������ת��Ϊ������
        /// <summary>
        /// �����ڵ�Ӣ������ת��Ϊ������
        /// </summary>
        /// <param name="EWeekName">����Ӣ������</param>
        /// <returns></returns>
        public static string GetCHNWeekName(string EWeekName)
        {
            string CHNWeekName = "";

            switch (EWeekName)
            {
                case "Monday":
                    CHNWeekName = "����һ";
                    break;
                case "Tuesday":
                    CHNWeekName = "���ڶ�";
                    break;
                case "Wednesday":
                    CHNWeekName = "������";
                    break;
                case "Thursday":
                    CHNWeekName = "������";
                    break;
                case "Friday":
                    CHNWeekName = "������";
                    break;
                case "Saturday":
                    CHNWeekName = "������";
                    break;
                case "Sunday":
                    CHNWeekName = "������";
                    break;
            }

            return CHNWeekName;
        }
        #endregion

        #region ��ȡ�����ַ���ƴ�������
        /// <summary>
        /// ��ȡ�����ַ���ƴ�������
        /// </summary>
        /// <param name="nameString">�����ַ���</param>
        /// <param name="type">0 ƴ����ƴ�� 1�����ƴ�� 2ƴ��ȫ��</param>
        /// <returns></returns>
        public static string GetPYWBM(string nameString, int type)
        {
            try
            {
                ResourceManager rm = null;
                string sResult = "";
                string singleChar = "";
                string singleCode = "";
                int charValue = 0;
                switch (type)
                {
                    case 0:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.Pym", Assembly.GetExecutingAssembly());
                        break;
                    case 1:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.Wbm", Assembly.GetExecutingAssembly());
                        break;
                    case 2:
                        rm = new ResourceManager("TrasenClasses.GeneralClasses.FullPym", Assembly.GetExecutingAssembly());
                        break;
                    default:
                        break;
                }
                if (rm != null)
                {
                    for (int i = 0; i < nameString.Length; i++)
                    {
                        singleChar = nameString.Substring(i, 1).Trim();
                        if (singleChar != "")
                        {
                            singleCode = (string)rm.GetObject(singleChar);
                            if (singleCode != null && singleCode.Trim() != "")
                            {
                                sResult += singleCode;
                            }
                            else
                            {
                                charValue = (int)Convert.ToChar(singleChar);
                                //0-9;A-Z;a-z;
                                if ((charValue >= 48 && charValue <= 57) || (charValue >= 65 && charValue <= 90) || (charValue >= 97 && charValue <= 122))
                                {
                                    sResult += singleChar;
                                }
                            }
                        }
                    }
                    rm = null;
                }
                return sResult;
            }
            catch (Exception err)
            {
                throw new Exception("ȡƴ����������\n" + err.Message);
            }
        }
        #endregion

        #region ���ݻ�����Ϣ������ö�ٻ�ñ���Ϣ
        /// <summary>
        /// ���ݻ�����Ϣ������ö�ٻ�ñ���Ϣ
        /// </summary>
        /// <param name="database">RelationDatabase</param>
        /// <param name="baseTable">������Ϣ������ö��</param>
        /// <returns></returns>
        public static DataTable GetBaseTableInfo(RelationalDatabase database, SelectBaseTable baseTable)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@SELECTTABLEINDEX";
                parameters[0].Value = (int)baseTable;
                parameters[1].Text = "@Err_Code";
                parameters[1].Value = 0;
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@Err_Text";
                parameters[2].Value = "";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;
                return database.GetDataTable("SP_BASE_GET_BASEINFO", parameters, 30);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        /// <summary>
        /// ���ݻ�����Ϣ������ö�ٻ�ñ���Ϣ
        /// </summary>
        /// <param name="database">RelationDatabase</param>
        /// <param name="baseTable">������Ϣ������ö��</param>
        /// <param name="throwException">�Ƿ��׳��쳣</param>
        /// <returns></returns>
        public static DataTable GetBaseTableInfo(RelationalDatabase database, SelectBaseTable baseTable, bool throwException)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[3];
                parameters[0].Text = "@SELECTTABLEINDEX";
                parameters[0].Value = (int)baseTable;
                parameters[1].Text = "@Err_Code";
                parameters[1].Value = 0;
                parameters[1].ParaDirection = ParameterDirection.Output;
                parameters[2].Text = "@Err_Text";
                parameters[2].Value = "";
                parameters[2].ParaDirection = ParameterDirection.Output;
                parameters[2].ParaSize = 100;
                return database.GetDataTable("SP_BASE_GET_BASEINFO", parameters, 30);

            }
            catch (Exception err)
            {
                if (throwException)
                    throw new Exception(err.Message);
                else
                {
                    MessageBox.Show(err.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }
        #endregion

        #region ָ��������DataGrid�е�ĳ��Ϊ������ֵ
        /// <summary>
        /// ָ��������DataGrid�е�ĳ��Ϊ������ֵ
        /// </summary>
        /// <param name="srcTable">��Ҫ���õ�DataGrid</param>
        /// <param name="columnName">ָ�����õ�����</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = i + 1;
                }
            }
        }
        /// <summary>
        /// ָ��������DataGrid�е�ĳ��Ϊ������ֵ
        /// </summary>
        /// <param name="srcTable">��Ҫ���õ�DataGrid</param>
        /// <param name="columnName">ָ�����õ�����</param>
        /// <param name="startValue">��ʼֵ</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName, int startValue)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = startValue;
                    startValue++;
                }
            }
        }
        /// <summary>
        /// ָ��������DataGrid�е�ĳ��Ϊ������ֵ
        /// </summary>
        /// <param name="srcTable">��Ҫ���õ�DataGrid</param>
        /// <param name="columnName">ָ�����õ�����</param>
        /// <param name="startValue">��ʼֵ</param>
        /// <param name="step">����</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string columnName, int startValue, int step)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    srcTable.Rows[i][columnName] = startValue;
                    startValue += step;
                }
            }
        }
        /// <summary>
        /// ָ��������DataGrid�е�ĳ��Ϊ������ֵ
        /// </summary>
        /// <param name="srcTable">��Ҫ���õ�DataGrid</param>
        /// <param name="columnName">��������</param>
        /// <param name="startValue">��ʼֵ����</param>
        /// <param name="step">��������</param>
        public static void SetDataGridIncreaseRowNumber(DataTable srcTable, string[] columnName, int[] startValue, int[] step)
        {
            if (srcTable != null && srcTable.Rows.Count > 0)
            {
                for (int i = 0; i < srcTable.Rows.Count; i++)
                {
                    for (int j = 0; j < columnName.Length; j++)
                    {
                        srcTable.Rows[i][columnName[j]] = startValue[j];
                        startValue[j] += step[j];
                    }
                }
            }
        }
        #endregion

        public static string ChangeDecimalToString(decimal num)
        {
            string rtn = "";

            rtn = Convert.ToSingle(num).ToString().Trim();

            return rtn;
        }

        ///<summary>
        /// ���� GUID �������ݿ�������ض���ʱ����������߼���Ч��
        /// </summary>
        /// <returns>COMB (GUID ��ʱ������) ���� GUID ����</returns>
        public static Guid NewGuid()
        {
            byte[] guidArray = System.Guid.NewGuid().ToByteArray();
            DateTime baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;
            // Get the days and milliseconds which will be used to build the byte string 
            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = new TimeSpan(now.Ticks - (new DateTime(now.Year, now.Month, now.Day).Ticks));

            // Convert to a byte array 
            // Note that SQL Server is accurate to 1/300th of a millisecond so we divide by 3.333333 
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)(msecs.TotalMilliseconds / 3.333333));

            // Reverse the bytes to match SQL Servers ordering 
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Copy the bytes into the guid 
            Array.Copy(daysArray, daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

            return new System.Guid(guidArray);
        }

        /// <summary>
        /// �� COMB ���ص� GUID ������ʱ����Ϣ
        /// </summary>
        /// <param name="guid">����ʱ����Ϣ�� COMB </param>
        /// <returns>ʱ��</returns>
        public static DateTime GetDateFromGuid(System.Guid guid)
        {
            DateTime baseDate = new DateTime(1900, 1, 1);
            byte[] daysArray = new byte[4];
            byte[] msecsArray = new byte[4];
            byte[] guidArray = guid.ToByteArray();

            // Copy the date parts of the guid to the respective byte arrays. 
            Array.Copy(guidArray, guidArray.Length - 6, daysArray, 2, 2);
            Array.Copy(guidArray, guidArray.Length - 4, msecsArray, 0, 4);

            // Reverse the arrays to put them into the appropriate order 
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Convert the bytes to ints 
            int days = BitConverter.ToInt32(daysArray, 0);
            int msecs = BitConverter.ToInt32(msecsArray, 0);

            DateTime date = baseDate.AddDays(days);
            date = date.AddMilliseconds(msecs * 3.333333);

            return date;
        }

        #region DGVת����DataTable   modify by zjf 20120928
        /// <summary>
        /// DGVת����DataTable   modify by zjf 20120928
        /// jianqg 2012-10-6 emr&his�������  ����
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dtbl_QianTai = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dtbl_QianTai.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dtbl_QianTai.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
                }
                dtbl_QianTai.Rows.Add(dr);
            }
            return dtbl_QianTai;
        }
        #endregion

    }
}
