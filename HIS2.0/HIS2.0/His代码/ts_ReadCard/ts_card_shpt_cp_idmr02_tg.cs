using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace ts_ReadCard
{
    public class ts_card_shpt_cp_idmr02_tg : Icard
    {
        #region api
        [StructLayout( LayoutKind.Sequential , CharSet = CharSet.Unicode , Pack = 4 )]
        private struct PERSONINFOW
        {
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 16 )]
            public string name;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 2 )]
            public string sex;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string nation;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string birthday;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 36 )]
            public string address;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 20 )]
            public string cardId;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 16 )]
            public string police;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string validStart;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 10 )]
            public string validEnd;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 2 )]
            public string sexCode;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 4 )]
            public string nationCode;
            [MarshalAs( UnmanagedType.ByValTStr , SizeConst = 36 )]
            public string appendMsg;
        }
        [DllImport( "cardapi2.dll" , EntryPoint = "OpenCardReader" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 OpenCardReader( Int32 lPort , UInt32 ulFlag );
        [DllImport( "cardapi2.dll" , EntryPoint = "GetPersonMsgW" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 GetPersonMsgW( ref PERSONINFOW pInfo , string pszImageFile );
        [DllImport( "cardapi2.dll" , EntryPoint = "CloseCardReader" , CallingConvention = CallingConvention.StdCall , CharSet = CharSet.Unicode )]
        private static extern Int32 CloseCardReader();
        #endregion
        
        public Int32 port
        {
            get
            {
                string strVal = CardFactory.GetIniString( "���֤ɨ����" , "�˿�" , Path.Combine( AppDomain.CurrentDomain.BaseDirectory , "ClientWindow.ini" ) );
                if ( string.IsNullOrEmpty( strVal ) )
                    throw new Exception( "δ��ClientWindow.ini�С����֤ɨ�������ڵ�����ȷ���á��˿ڡ���(��ʽ��1001��ʾUSB1��1002��ʾUSB2���������ơ�)" );
                int io = -1;
                if ( int.TryParse( strVal , out io ) )
                    return Convert.ToInt32( strVal );
                else
                    return -1;
            }            
        }

        #region Icard ��Ա

        public bool ReadCard( ref IDCardData _idcarddata , ref string msg )
        {
            try
            {
                Int32 result = OpenCardReader( port , 0x02 );
                if ( result != 0 )
                {
                    msg = "���豸�˿�ʧ��";
                    return false;
                }

                PERSONINFOW info = new PERSONINFOW();
                result = GetPersonMsgW( ref info , "" );
                if ( result != 0 )
                {
                    msg = "�����֤ʧ��";
                    return false;
                }

                _idcarddata = new IDCardData();
                _idcarddata.Address = info.address;
                _idcarddata.Born = string.Format( "{0}-{1}-{2}" , info.birthday.Substring( 0 , 4 ) , info.birthday.Substring( 4 , 2 ) , info.birthday.Substring( 6 , 2 ) );
                _idcarddata.GrantDept = info.police;
                _idcarddata.IDCardNo = info.cardId;
                _idcarddata.Name = info.name;
                _idcarddata.Nation = info.nation + "��";
                _idcarddata.Sex = info.sex;
                _idcarddata.UserLifeBegin = info.validStart;
                _idcarddata.UserLifeEnd = info.validEnd;

                msg = "��ȡ�ɹ�";
                return true;
            }
            catch
            {
                msg = "δ֪�Ĵ���";
                return false;
            }
            finally
            {
                CloseCardReader();
            }
            
        }

        #region  ��ȡ���֤��Ϣ���ؼ�
        /// <summary>
        /// ��ȡ���֤��Ϣ���ؼ�
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="msg">������ʾ��Ϣ</param>
        /// <param name="errAutoMsg">����ʱ�Ƿ��Զ�������ʾ����</param>
        /// <param name="txtName">����</param>
        /// <param name="combXb">�Ա�</param>
        /// <param name="txtYear">���������£���</param>
        /// <param name="txtMonth">���������£���</param>
        /// <param name="txtDay">���������£���</param>
        /// <param name="txtDz">סַ����ַ</param>
        /// <param name="txtSfz">���֤��</param>
        /// <param name="comMz">����</param>
        /// <returns></returns>
        public bool ReadCardToControl( ref IDCardData CardMsg , ref string msg , bool errAutoMsg ,
            Control txtName , Control combXb , Control txtYear , Control txtMonth , Control txtDay , Control txtDz , Control txtSfz , Control comMz )
        {

            bool flag = this.ReadCard( ref CardMsg , ref msg );
            if ( flag )
            {
                this.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
            }
            else if ( errAutoMsg == true )
            {
                MessageBox.Show( msg , "��ʾ��Ϣ" , MessageBoxButtons.OK , MessageBoxIcon.Hand );
            }

            return flag;

        }
        #endregion
        #region  ��ȡ���֤��Ϣ���ؼ�
        /// <summary>
        /// ��CardMsg��Ϣ ���õ��ؼ�
        /// </summary>
        /// <param name="CardMsg"></param>
        /// <param name="txtName">����</param>
        /// <param name="combXb">�Ա�</param>
        /// <param name="txtYear">���������£���</param>
        /// <param name="txtMonth">���������£���</param>
        /// <param name="txtDay">���������£���</param>
        /// <param name="txtDz">סַ����ַ</param>
        /// <param name="txtSfz">���֤��</param>
        /// <param name="comMz">����</param>
        /// <returns></returns>
        public void ReadCardToControl( IDCardData CardMsg ,
            Control txtName , Control combXb , Control txtYear , Control txtMonth , Control txtDay , Control txtDz , Control txtSfz , Control comMz )
        {

            bool flag = false;
            PubFun.ReadCardToControl( CardMsg , txtName , combXb , txtYear , txtMonth , txtDay , txtDz , txtSfz , comMz );
        }
        #endregion


        #endregion
    }
}
