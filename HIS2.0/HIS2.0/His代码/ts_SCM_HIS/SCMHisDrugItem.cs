using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using System.Windows.Forms;

namespace ts_SCM_HIS
{
    /// <summary>
    /// SCMҩƷ�ֵ�˵��
    /// </summary>
    public class SCMHisDrugItem
    {

      /*    ҩƷ����	NAME	string
            ҩƷ����	CODE	string
            ҩƷ���	SPEC	string
            ��������	FACTORY	string
            ҩƷ����	MRJJ	Decimal��14��4�� */

        private string _NAME;	   //ҩƷ����
        private string _CODE;	   //ҩƷ����
        private string _SPEC;     //ҩƷ���
        private string _FACTORY;  //��������
        private Decimal _MRJJ;     //ҩƷ����


        /// <summary>
        /// ҩƷ����
        /// </summary>
        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        /// <summary>
        /// ҩƷ����
        /// </summary>
        public string CODE
        {
            get { return _CODE; }
            set { _CODE = value; }
        }

        /// <summary>
        /// ҩƷ���
        /// </summary>
        public string SPEC
        {
            get { return _SPEC; }
            set { _SPEC = value; }
        }

        /// <summary>
        /// ҩƷ��������
        /// </summary>
        public string FACTORY
        {
            get { return _FACTORY; }
            set { _FACTORY = value; }
        }

        /// <summary>
        /// ҩƷ������
        /// </summary>
        public Decimal MRJJ
        {
            get { return _MRJJ; }
            set { _MRJJ = value; }
        }



       // public static void HisPushDrugItemToSCM(IList<SCMHisDrugItem> DrugItem, string ActFlag, out bool err_Flag, out bool Suc_Flag)
        //public static void HisPushDrugItemToSCM( List<SCMHisDrugItem> DrugItem, string ActFlag)
        //{
        //    if (DrugItem != null)
        //    {
        //        try
        //        {
        //            //WebReference SCMServer = new WebReference(); GetPucharseFromSap,GetDrugFromHIS
        //            WebReference.SAPtoSCM ScmSer = new WebReference.SAPtoSCM();
                     
        //           // ScmSer.GetDrugFromHIS(DrugItem, ActFlag, err_Flag, Suc_Flag);//�˴�û�ж�Ӧ�ķ���
                    
        //        }
        //        catch (System.Exception err)
        //        {
        //            throw new System.Exception(err.ToString());
        //        }
        //    }
        //}
    }                  	
}                      	
