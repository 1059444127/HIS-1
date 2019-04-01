using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TrasenClasses.GeneralClasses;
using TrasenClasses.DatabaseAccess;
using System.Globalization;
using TrasenFrame.Classes;

namespace ts_zyhs_classes
{
    /// <summary>
    /// ҽ��ִ����Ϣ��
    /// </summary>
    public class ClsOrderExecInfo
    {
        private RelationalDatabase _database;
        public ClsConfigList _cfgList;
        public List<OrderEntity> _orderList;
        public List<OrderExecEntity> _orderExecList;
        public DataTable _dtPat;
        public DataTable _dtFreq;
        public long EXEUSER;
        public Guid _Binid;
        public long _Babyid;
        public long _JGBM;
        private DateTime EXECDATE;//����
        public long _Groupid;

        public int MNGTYPE;// --MNGTYPE=5ʹ��
        public Guid ORDERID;
        public int? FRISTTIMES;
        public int? TERMINALTIMES;
        public string FREQUENCY;
        public long DEPTID;
        public long DEPTBR; //ADD BY TANY 2005-08-30 �������ڿ���
        public long DEPTLY;//ADD BY TANY 2005-12-11 ��ҩ����
        public string WARDID;
        public long EXEDEPT;
        public int NTYPE;
        public DateTime BEGINEXEDATE;
        public DateTime? STOPEXEDATE;
        public int STATUS_FLAG;
        public long HOITEMID;
        public string ITEMCODE;
        public int XMLY;// --1ҩƷ2��Ŀ3����
        public int CYCLEDAY;// --ѭ������
        public int CYCLELX;// --ѭ������ 1=����ִ��2=����ִ��
        public int ZXR;//--ִ���� @CYCLELX=2 ʱ 1=������2=����һ3=���ڶ�4=������5=������6=������7=������
        public int MNGTYPE2;// --MNGTYPE=5ʹ��
        public string ORDERUNIT;// --ADD BY TANY 2007-10-29 ����ҽ����λ�жϵ�λ�ǲ��Ǹı�
        public string NOWUNIT;//--��ǰ��λ
        public int ISKDKSLY;//--�Ƿ񿪵�������ҩ
        public long GCYS;// --Modify By Tany 2009-12-23 ���ӹܴ�ҽ��
        public int ZHBJ;
        public int PVSCHKBIT;
        public string ORDER_USAGE;
        public string EXECTIME;
        public int YBLX;
        public string BED_NO;
        public string PAT_NAME;
        public int TS;//--add by zouchihua ��ʱҽ������
        public int TEMPPL;// --add by zouchihua ��ʱҽ��Ƶ��

        public Guid EXECID;
        public long ADDFEEID;
        public DateTime EXECBOOKDATE;
        public int EXENUM0;
        public int EXENUM;

        public decimal CFH;//DECIMAL(21,6);
        public decimal NUM; //DECIMAL(18,3)
        public decimal RETAIL_PRICE;//DECIMAL(18,3);//---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���
        public decimal RETAIL_PRICE1;//DECIMAL(18,3)  //---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���


        public int NUM_NEW;// ---add yaokx 2014-05-22 ���ӷ���ÿ��ִ��һ��
        public int HDITEM_ID;// ---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���
        public int NUM_FJ;//---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���
        public int HDITEM_ID1;// ---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���

        public int NUM_FJ1;//---add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���
        public int GLXMID;// ---add yaokx 2014-05-29 
        public int JD;//---add yaokx 2014-05-29 
        public int XD;//---add yaokx 2014-05-29 
        public int cfg7198;//--add yaokx 2014-05-29 ���ӷ���ÿ��ִ��һ��,ʣ�µ�תΪ���ӷ���
        public string cfg7199;// ---add yaokx 2014-05-29 
        public string cfg7200;//---add yaokx 2014-05-29

        public bool BSsmzOrder = false;

        public int EXECNUM;
        public int EXECNUMtmp;

        public Guid _BRXXID;//ҽ����

        public ClsOrderExecInfo(RelationalDatabase database)
        {
            _database = database;
        }

        #region"���ݳ�ʼ��"

        public void DoInit(ClsConfigList cfgList, List<OrderEntity> orderList, List<OrderExecEntity> orderExecList, DataTable dtPat, DataTable dtFreq, long thisExecUser,
            Guid Binid, long Babyid, long Groupid, long JGBM, DateTime thisEXECDATE, int _MNGTYPE, int _MNGTYPE2)
        {
            _cfgList = cfgList;
            _orderList = orderList;
            _orderExecList = orderExecList;
            EXEUSER = thisExecUser;
            _Binid = Binid;
            _Babyid = Babyid;
            _Groupid = Groupid;
            _JGBM = JGBM;
            EXECDATE = thisEXECDATE;
            MNGTYPE = _MNGTYPE;
            MNGTYPE2 = _MNGTYPE2;

            _dtPat = dtPat;

            if (orderList.Count <= 0)
                throw new Exception("��ʼ�� ִ����ϸ��Ϣ ʧ�ܣ�δ����ҽ����");

            if (dtPat.Rows.Count <= 0)
                throw new Exception("��ʼ�� ִ����ϸ��Ϣ ʧ�ܣ�δ���뻼���ڴ���Ϣ��");

            if (dtFreq.Rows.Count <= 0)
                throw new Exception("��ʼ�� ִ����ϸ��Ϣ ʧ�ܣ�δ����Ƶ�ʻ�����Ϣ��");

            OrderEntity order = _orderList[0];//ִ�п��ҴӴ�С�����������к����Ա�ҩ��

            string freq = order.FREQUENCY.ToUpper();
            //�����Ƶ��
            if (!string.IsNullOrEmpty(freq))
            {
                //��ȡ����Ƶ����Ϣ
                _dtFreq = dtFreq.Clone();
                for (int i = 0; i < dtFreq.Rows.Count; i++)
                {
                    string jcFreq = dtFreq.Rows[i]["NAME"].ToString().ToUpper();

                    if (jcFreq.Equals(freq))
                    {
                        _dtFreq.Rows.Add(dtFreq.Rows[i].ItemArray);
                    }
                }
                _dtFreq.AcceptChanges();

                //if (_dtFreq.Rows.Count <= 0)
                //    throw new Exception(dtPat.Rows[0]["BED_NO"].ToString() + " ������ " + dtPat.Rows[0]["NAME"].ToString() + " ��ʼ��ִ����ϸ��Ϣerr��ҽ��Ƶ�ʣ�" + freq + " δƥ�䵽����Ƶ�ʱ��е����ݣ�");
            }

            DoInitParamInfo(order, _dtPat, _dtFreq);
        }

        /// <summary>
        /// |ȡ��ҽ���Ĳ���ID��Ӥ��ID,ҽ���ţ�ִ�п��ң�ҽ�����࣬ҽ��Ƶ�ʵ�ִ�д�������ʼִ��ʱ�䣬ҽ��״̬��ҽ����Ŀ��ID��ҩƷ���룬
        /// |����ִ�д�����Ƶ��,ҽ�����
        /// </summary>
        /// <param name="order"></param>
        /// <param name="dtPat"></param>
        /// <param name="dtFreqInfo"></param>
        public void DoInitParamInfo(OrderEntity order, DataTable dtPat, DataTable dtFreqInfo)
        {
            ORDERID = order.ORDER_ID;
            EXEDEPT = order.EXEC_DEPT;
            NTYPE = order.NTYPE;

            BEGINEXEDATE = order.ORDER_BDATE;
            STOPEXEDATE = order.ORDER_EDATE;
            STATUS_FLAG = order.STATUS_FLAG;
            HOITEMID = order.HOITEM_ID;

            ITEMCODE = order.ITEM_CODE;
            FREQUENCY = order.FREQUENCY;
            DEPTID = order.DEPT_ID;
            XMLY = order.XMLY;
            ISKDKSLY = order.ISKDKSLY;

            TS = int.Parse(Convertor.IsNull(order.ts, "1"));//(case  when ts is null then 1 else ts end);
            ZHBJ = int.Parse(Convertor.IsNull(order.ZHBJ, "0")); ;//isnull(zhbj,0) ;

            PVSCHKBIT = order.is_PvsChk;//is_PvsChk;//		--add by jchl

            ORDER_USAGE = order.ORDER_USAGE;// --Add By Tany 2015-04-20

            //Ƶ�γ�ʼ��
            EXECNUM = 1;
            EXECNUMtmp = 1;
            CYCLEDAY = 1;
            CYCLELX = 1;
            ZXR = 1234567;
            string freq = order.FREQUENCY.ToUpper();
            if (string.IsNullOrEmpty(freq) || dtFreqInfo == null || dtFreqInfo.Rows.Count <= 0)
            {
                //������Ƶ��
                EXECNUM = 1;
                EXECNUMtmp = 1;
                CYCLEDAY = 1;
                CYCLELX = 1;
                ZXR = 1234567;
            }
            else
            {
                DataTable dtFreq = GetFreqByFreqName(dtFreqInfo);
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    EXECNUM = 1;
                }
                else
                {
                    EXECNUM = int.Parse(dtFreq.Rows[0]["EXECNUM"].ToString());
                }
                EXECNUMtmp = int.Parse(dtFreq.Rows[0]["EXECNUM"].ToString());

                CYCLEDAY = int.Parse(dtFreq.Rows[0]["CYCLEDAY"].ToString());
                CYCLELX = int.Parse(dtFreq.Rows[0]["LX"].ToString());
                ZXR = int.Parse(dtFreq.Rows[0]["ZXR"].ToString());
                EXECTIME = dtFreq.Rows[0]["EXECTIME"].ToString().Trim();
                TEMPPL = Convertor.IsNull(order.ts, "-1").Equals("-1") ? 1 : EXECNUMtmp;//(case  when ts is null then 1 else EXECNUMtmp end);//--��ʱҽ��ִ�д���

            }

            FRISTTIMES = order.FIRST_TIMES > EXECNUM ? 1 : order.FIRST_TIMES;
            TERMINALTIMES = order.TERMINAL_TIMES > EXECNUM ? 1 : order.TERMINAL_TIMES;

            GCYS = 0;//CASE WHEN ZY_DOC<=0 OR ZY_DOC IS NULL THEN ORDER_DOC ELSE ZY_DOC END;
            long iZyDoc = long.Parse(Convertor.IsNull(dtPat.Rows[0]["ZY_DOC"], "0"));
            GCYS = iZyDoc > 0 ? iZyDoc : order.ORDER_DOC;

            WARDID = dtPat.Rows[0]["WARD_ID"].ToString();
            DEPTBR = long.Parse(dtPat.Rows[0]["DEPT_ID"].ToString());
            BED_NO = dtPat.Rows[0]["BED_NO"].ToString();
            PAT_NAME = dtPat.Rows[0]["NAME"].ToString();
            YBLX = int.Parse(dtPat.Rows[0]["YBLX"].ToString()); // --Add By jchl 2016-12-27

            //���������Ƿ�����
            string ssql = string.Format(@"select * from SS_DEPT where DEPTID={0} ", order.DEPT_ID);
            DataTable dt = _database.GetDataTable(ssql);
            if (dt != null && dt.Rows.Count > 0)
            {
                BSsmzOrder = true;
            }

            if (NTYPE == 5)
            {
                ssql = string.Format(@"select A.PATIENT_ID from ZY_INPATIENT A where INPATIENT_ID='{0}' ", _Binid);

                string strBrxxid = _database.GetDataResult(ssql).ToString();

                _BRXXID = new Guid(strBrxxid);
            }
        }

        #endregion

        #region"ִ��׼�����÷���"

        #region"ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)"

        /// <summary>
        /// ҽ���Ƿ����ִ��
        /// 1��û��ת����ҽ�����Ѿ�ֹͣ��ҽ�������� 
        /// 2����ʱҽ�����˵�������Ѿ�ִ�й�����ִ�У�����״̬���
        /// </summary>
        /// <returns>1��ִ��  2��nextday 0��return</returns>
        public int CanOrderExec()
        {
            int iret = 0;
            try
            {
                // 1��û��ת����ҽ�����Ѿ�ֹͣ��ҽ�������� 
                if (STATUS_FLAG < 2 || STATUS_FLAG == 5)
                {
                    iret = 1;
                    return iret;//������
                }

                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    if (_orderExecList != null && _orderExecList.Count > 0)
                    {
                        if (STATUS_FLAG == 2)
                        {
                            iret = 2;//nextday����״̬
                            return iret;
                        }
                        else
                        {
                            iret = 1;//���
                            return iret;
                        }
                    }
                }

                iret = 0;//����ִ��
                return iret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// ҽ���Ƿ����ִ��
        /// 3���Ѿ�ͣת�����ҵ�ǰִ��ʱ�����ͣ����
        /// </summary>
        /// <returns>1��ִ��  2��nextday 0��return</returns>
        public int CanOrderExecWhenStop()
        {
            int iret = 0;
            try
            {
                if (STATUS_FLAG == 4)
                {
                    if (!STOPEXEDATE.HasValue)
                    {
                        throw new Exception(_orderList[0].ORDER_CONTEXT + " �Ѿ�ͣ����,û��ͣ��ʱ��,����ϵ����Ա��");
                    }

                    if (CUREXECDATE.Date > STOPEXEDATE.Value.Date && EXECDATE.Date >= STOPEXEDATE.Value.Date)
                    {
                        iret = 2;//nextday����״̬
                        return iret;
                    }
                }

                iret = 0;//����ִ��
                return iret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region"����ǰִ��ʱ��CUREXECDATE��LASTEXECDATE��LASTVALIDEXECDATE��execNumEver"

        private DateTime CUREXECDATE;
        private DateTime? LASTEXECDATE;
        private DateTime? LASTVALIDEXECDATE;
        private int execNumEver = 0;//���ִ�����ڵģ���ǰִ�д���

        /// <summary>
        /// ��ȡ��ǰִ��ʱ��
        /// </summary>
        /// <returns></returns>
        public void SetCurrExecDate()
        {
            CUREXECDATE = BEGINEXEDATE;//������δ���ͳ���Ĭ�Ͽ�ʱ��
            try
            {
                execNumEver = 0;//��ǰִ�д���
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    /*
                        IF (@LASTEXECDATE IS NOT NULL )  
                         begin
                             --ִ�д���С��Ƶ��,��ǰִ��ʱ�����ڲ��� Modify by zouchihua 2012-02-01
                             if @Cqyz_zxcs<@EXENUM0 and @BEGINEXEDATE!=@LASTEXECDATE                               --1
                               SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                             --���ڼ�һ�� Modify by zouchihua 2012-02-01
                             ELSE
                               SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,1,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                               --����ǳ�Ժҽ���ȣ���
                               IF @ntype=0
                                 SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                          END 
                        ELSE
                            SET @CUREXECDATE=@BEGINEXEDATE
                     */

                    List<OrderExecEntity> myExeOrderList = new List<OrderExecEntity>();

                    //ȡ����orderid������ִ�м�¼
                    foreach (OrderExecEntity myExeOrder in _orderExecList)
                    {
                        if (myExeOrder.ORDER_ID == ORDERID)
                        {
                            myExeOrderList.Add(myExeOrder);
                        }
                    }

                    if (myExeOrderList.Count > 0)
                    {
                        myExeOrderList.Sort();//����execDate�Ӵ�С����

                        OrderExecEntity orderExecMax = myExeOrderList[0];//���ִ��ʱ���һ��

                        LASTEXECDATE = orderExecMax.EXECDATE;//LASTEXECDATE����

                        //foreach (OrderExecEntity ordExe in myExeOrderList)
                        for (int i = 0; i < myExeOrderList.Count; i++)
                        {
                            OrderExecEntity ordExe = myExeOrderList[i];
                            int isAna = int.Parse(Convertor.IsNull(ordExe.ISANALYZED, "0"));
                            DateTime thisExeDate = ordExe.EXECDATE;

                            if (isAna > 0 && !LASTVALIDEXECDATE.HasValue)
                            {
                                LASTVALIDEXECDATE = ordExe.EXECDATE;//���û��ֵ����ֵ��ǰִ��ʱ��
                            }

                            if (isAna > 0 && (LASTVALIDEXECDATE.HasValue && thisExeDate > LASTVALIDEXECDATE))
                            {
                                LASTVALIDEXECDATE = ordExe.EXECDATE;//LASTVALIDEXECDATE����//���ִ�����ڵ���ȡ��Чִ�д���>0�ļ�¼
                            }

                            if (ordExe.EXECDATE.Date == LASTEXECDATE.Value.Date)
                            {
                                execNumEver += ordExe.ISANALYZED;
                            }
                        }

                        //throw new Exception();

                        //ִ�д���С��Ƶ��,��ǰִ��ʱ�����ڲ��� Modify by zouchihua 2012-02-01
                        if (execNumEver < EXECNUM && BEGINEXEDATE != LASTEXECDATE)
                        {
                            //ִ�д���С��Ƶ��,���ҷ�����ִ�У�������Ҫ�������δִ����Ƶ�Σ�
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.Date.ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));//(wait �Ż���Ƶ��֮���ʱ����ҽ����������ִ�м�¼ ���磺20 �� q3d �״�1 ����һ�η�����21�� ���ŵڶ��η�����22�� 21�յ�ִ�м�¼��������0�ġ�)
                        }
                        else
                        {
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.AddDays(1).ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));
                        }

                        if (NTYPE == 0)
                        {
                            CUREXECDATE = Convert.ToDateTime(LASTEXECDATE.Value.ToString("yyyy-MM-dd") + EXECDATE.ToString(" HH:mm:ss"));
                        }

                        ////����ǳ�Ժҽ���ȣ���
                        //IF @ntype=0
                        //  SET @CUREXECDATE=CONVERT(DATETIME,DBO.FUN_GETDATE(DATEADD(DD,0,@LASTEXECDATE))+' '+CONVERT(CHAR,@EXECDATE,108),120)
                    }
                    else
                    {
                        CUREXECDATE = BEGINEXEDATE;//������δ���ͳ���Ĭ�Ͽ�ʱ��
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡCUREXECDATEʱerr��" + ex.Message);
            }
        }

        #endregion

        #region"����ִ��ʱ��EXECDATE"

        /// <summary>
        /// ��ȡ��Ҫִ�е�ʱ�䣨ǰ̨����󣬿�����Ҫ����
        /// </summary>
        /// <returns></returns>
        public void SetExecDate()
        {
            try
            {
                if (STATUS_FLAG == 4)
                {
                    if (!STOPEXEDATE.HasValue)
                    {
                        throw new Exception(_orderList[0].ORDER_CONTEXT + " �Ѿ�ͣ����,û��ͣ��ʱ��,����ϵ����Ա��");
                    }

                    if (EXECDATE.Date < STOPEXEDATE.Value.Date)
                    {
                        EXECDATE = STOPEXEDATE.Value.Date;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡEXECDATEʱerr��" + ex.Message);
            }
        }

        #endregion

        #region"��ò���  ����ҩƷ�Ƿ�ֱ�Ӽ���"
        //��ò���  ����ҩƷ�Ƿ�ֱ�Ӽ���
        private int iMedCharge = -1;

        /// <summary>
        /// IF (SELECT CONFIG FROM JC_CONFIG WHERE ID=7018)='��'
        /// </summary>
        /// <returns></returns>
        public void IsMedCharge()
        {
            try
            {
                if (_cfgList.cfg7018.Config.Trim().Equals("��"))
                {
                    iMedCharge = 1;
                }
            }
            catch (Exception ex)
            {
                iMedCharge = 0;
                throw ex;
            }
        }

        #endregion

        #region"pivas�������մ���pvsbit��cfbit��ִ�п���@EXEDEPT=@pvsExeDept��"

        //pivas�������մ���pvsbit��ִ�п���@EXEDEPT=@pvsExeDept��
        private int pvsBit = 0;//�Ƿ�pivas

        public int SetPivasBit(out long execDeptId, out int errCode, out string errMsg)
        {
            execDeptId = EXEDEPT;
            pvsBit = 0;
            errCode = 0;
            errMsg = "";
            try
            {
                long pvsDept = 0;
                bool isYp = XMLY == 1;
                bool isYpOth = NTYPE == 1 || NTYPE == 2;//�����г�
                //1�����жϸ�ҽ���Ƿ����Pivas  ��1������ҩ�����Ƿ����pivas����JC_DEPT_DRUGSTORE�� 2��Ƶ��������VI_pivas_Freq   3���÷�������VI_pivas_Orderusage ��   
                bool CanPivas = IsCanPivas(FREQUENCY, ORDER_USAGE, DEPTBR, EXEDEPT, out pvsDept);//��������ҩ���Ƿ��������pivas

                if (isYp && isYpOth && CanPivas)
                {

                    //2���ж�ҽ���󷽱�� 
                    if (PVSCHKBIT == 2)
                    {
                        errCode = -1;
                        errMsg = "��ҽ��pivas��δͨ������֪ͨҽ��ͣ��!";
                        return pvsBit;
                    }

                    //3���ж�pivas�������ݣ�0������1������2��������7602
                    string pvsType = _cfgList.cfg7602.Config.ToString().Trim();
                    if ((pvsType.Equals("0") && MNGTYPE == 0) ||
                        (pvsType.Equals("1") && MNGTYPE == 1) ||
                        (pvsType.Equals("2") && (MNGTYPE == 0 || MNGTYPE == 1)))
                    {
                        //pivas���ù���
                        //1.��ҽ������2��ҽ��
                        int iOrdCnt = _orderList.Count;

                        //2.�����Ա�ҩ
                        bool isZb = false;

                        foreach (OrderEntity myOrder in _orderList)
                        {
                            isZb = myOrder.HOITEM_ID <= 0 || myOrder.EXEC_DEPT <= 0;
                            if (isZb == true)
                                break;
                        }

                        if (iOrdCnt > 1 && (!isZb))
                        {
                            //pivas����
                            foreach (OrderEntity order in _orderList)
                            {
                                string unit = "";
                                decimal kcl = 0;
                                decimal xnKcl = 0;
                                //��ȡpivas�����Ϣ

                                GetYpKcmxInfo(order.DWLX, order.HOITEM_ID, order.XMLY, pvsDept, out unit, out kcl, out xnKcl);

                                if (string.IsNullOrEmpty(unit))
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//ԭҩ��
                                    return pvsBit;
                                }

                                //case when @MNGTYPE in(1,5) then isnull(a.zsldw,a.unit) else A.UNIT end
                                string thisOrderUnit = "";
                                if (MNGTYPE == 1 || MNGTYPE == 5)
                                {
                                    thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(order.zsldw, "")) ? order.UNIT : order.zsldw;
                                }
                                else
                                {
                                    thisOrderUnit = order.UNIT;
                                }

                                //ҩƷ�ֶε�λ�Ƿ���������
                                if (!thisOrderUnit.Trim().Equals(unit.Trim()))
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//ԭҩ��
                                    return pvsBit;
                                }

                                if (kcl <= 0)
                                {
                                    pvsBit = 0;
                                    execDeptId = EXEDEPT;//ԭҩ��
                                    return pvsBit;
                                }
                            }

                            pvsBit = 1;
                            execDeptId = pvsDept;//pivasҩ��
                            return pvsBit;
                        }
                    }
                }
                pvsBit = 0;
                execDeptId = EXEDEPT;//ԭҩ��
                return pvsBit;
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡPivas��־err��" + ex.Message);
            }
        }

        public bool IsCanPivas(string freq, string orderUsage, long deptBr, long execDeptid, out long pvsExecDept)
        {
            pvsExecDept = execDeptid;
            try
            {

                string ssql = string.Format(@"SELECT count(1) as num from VI_pivas_Freq where name='{0}'", freq);

                int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));

                bool isPvsFreq = iCnt > 0;

                if (!isPvsFreq)
                    return false;

                ssql = string.Format(@"SELECT count(1) as num from VI_pivas_Orderusage where name='{0}'", orderUsage);

                iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));

                bool isPvsOrderUsage = iCnt > 0;

                if (!isPvsOrderUsage)
                    return false;

                ssql = string.Format(@"SELECT *  from JC_DEPT_DRUGSTORE where DEPT_ID={0} and is_pvsrel=1 and  DELETE_BIT=0 ", deptBr);

                DataTable dt = _database.GetDataTable(ssql);

                bool isPvsDept = false;

                if (dt == null || dt.Rows.Count <= 0)
                    return isPvsDept;

                isPvsDept = true;

                pvsExecDept = long.Parse(dt.Rows[0]["DRUGSTORE_ID"].ToString());//Ĭ��ȡ��һ�в��˿��Ҷ�Ӧ��pivasҩ��

                return isPvsDept;
            }
            catch
            {
                return false;
            }
        }

        private int cfBit = 0;//�Ƿ���

        public int SetCfBit()
        {
            cfBit = 0;
            try
            {
                if (pvsBit == 1)
                {
                    cfBit = 1;
                }
            }
            catch
            {
                return cfBit;
            }
            return cfBit;
        }

        #endregion

        #region"dept_br��dept_ly����"

        /// <summary>
        /// �������� ����dept_br(��ͨҽ��ȡ����vi_zy_beddiction���dept_id)
        /// </summary>
        /// <returns></returns>
        public void SetDeptBr(long orderDeptBr)
        {
            try
            {
                //������¼��ҽ����ת�Ʋ��˼����Ƿ����ת��ǰ�Ŀ��ҷ����� 0=��1=��
                if (_cfgList.cfg9010.Config.ToString().Trim().Equals("1"))
                {
                    if (BSsmzOrder)
                    {
                        //ҽ��������������������,ȡ��ҽ�����deptbr
                        DEPTBR = orderDeptBr;
                    }
                }
                //DEPTBR
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡDeptBrʱerr��" + ex.Message);
            }
        }

        /// <summary>
        /// dept_ly����
        /// </summary>
        /// <returns></returns>
        public void SetDeptLyInfo(string orderDeptid)
        {
            try
            {
                if (BSsmzOrder || ISKDKSLY == 1)
                {
                    //�����������������������Ѳ����ĳ���������
                    string ssql = string.Format(@"SELECT WARD_ID FROM JC_WARDRDEPT WHERE DEPT_ID={0} ", orderDeptid);

                    DataTable dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("δ�ҵ��������ң�" + orderDeptid + " ��Ӧ�Ĳ�����Ϣ");
                    }

                    WARDID = dt.Rows[0]["WARD_ID"].ToString();//���鿪��������ҩ  �����޸�Ϊ�����Ӧ����

                    ssql = string.Format(@"SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID={0}", WARDID);

                    dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("δ�ҵ���" + WARDID + " �ò�����Ӧ������Ϣ");
                    }

                    DEPTLY = long.Parse(dt.Rows[0]["DEPT_ID"].ToString());
                }
                else
                {
                    //�����������ҩ������ҩ
                    string ssql = string.Format(@"SELECT DEPT_ID FROM JC_WARD WHERE WARD_ID={0}", WARDID);

                    DataTable dt = _database.GetDataTable(ssql);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("δ�ҵ���" + WARDID + " �ò�����Ӧ������Ϣ");
                    }

                    DEPTLY = long.Parse(dt.Rows[0]["DEPT_ID"].ToString());

                    //����ò������ڿ����ǵ�����ҩ��Ҳ��Ҫ��������
                    ssql = string.Format(@"SELECT count(1) as num FROM JC_DEPT_TYPE_RELATION WHERE DEPT_ID={0} AND TYPE_CODE='009'", DEPTBR);
                    int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(ssql), "0"));
                    if (iCnt > 0)
                    {
                        DEPTLY = DEPTBR;
                    }
                }

                if (DEPTLY <= 0)
                {
                    if (ISKDKSLY == 1)
                    {
                        DEPTLY = DEPTID;
                    }
                    else
                    {
                        DEPTLY = DEPTBR;
                    }
                }

                //���@ISKDKSLY=-1 ��Щ�������ƿ��Ҳ���Ҫ��ҩ
                if (ISKDKSLY == -1)
                {
                    DEPTLY = -1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("��ȡDEPTLYʱerr��" + ex.Message);
            }
        }

        #endregion

        #region"Ԥ��ҩ����@YLCS��@ISYL��@EXECTIME��@EXECDATE��"

        public int ISYL = 0;//�Ƿ�Ԥ��
        public int YLCS = 0;//Ԥ�����

        /// <summary>
        /// Ԥ��ҩ����
        /// </summary>
        /// <returns></returns>
        public void SetYlyInfo(out int iExecDateAdd)
        {
            iExecDateAdd = 0;
            try
            {
                string lsyl = _cfgList.cfg7052.Config.ToString().Trim();

                if (lsyl.Equals("1"))
                {
                    //��ҪԤ��ҩ
                    //ѭ����ʼǰ�ȿ����Ƿ���ҪԤ��ҩ�������Ҫ����ôִ��ʱ��+1��
                    //�����ҩƷ�������ǳ���
                    if (XMLY == 1 && MNGTYPE == 0)
                    {
                        //����ҩƷҽ����У��
                        GetYlInfo(HOITEMID, EXECTIME, out ISYL, out YLCS);
                    }
                }

                if (ISYL == 1)
                {
                    iExecDateAdd = 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("����Ԥ��ҩʱerr��" + ex.Message);
            }
        }

        /// <summary>
        /// ��ȡ
        /// </summary>
        /// <param name="cjid">ҩƷid</param>
        /// <param name="execTimes">ִ�д���</param>
        /// <param name="iIsYl"></param>
        /// <param name="iYlcs"></param>
        public void GetYlInfo(long cjid, string execTimes, out int iIsYl, out int iYlcs)
        {
            iIsYl = 0;
            iYlcs = 0;
            try
            {
                string ypTlfl = GetYpTlfl(cjid);

                string kfylConfif = _cfgList.cfg7048.Config.ToString().Trim();
                bool isKf = kfylConfif.Contains(ypTlfl);

                if ((!string.IsNullOrEmpty(kfylConfif)) && isKf)
                {
                    string kfylTime = _cfgList.cfg7049.Config.ToString().Trim();
                    GetYlInfo(execTimes, kfylTime, out  iIsYl, out  iYlcs);
                }
                else
                {
                    string zsyYlConfif = _cfgList.cfg7050.Config.ToString().Trim();
                    bool isZsy = zsyYlConfif.Contains(ypTlfl);

                    if ((!string.IsNullOrEmpty(zsyYlConfif)) && isZsy)
                    {
                        string zsyYlTime = _cfgList.cfg7051.Config.ToString().Trim();
                        GetYlInfo(execTimes, zsyYlTime, out  iIsYl, out  iYlcs);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡԤ��ҩ��Ϣʱerr��" + ex.Message);
            }
            //SET @TLFL = (SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) FROM VI_YP_YPCD A WHERE A.CJID=@HOITEMID)
            //SET @KFCS = (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7048) --�ڷ�����
        }

        private void GetYlInfo(string execTimes, string ylTimes, out int iIsYl, out int iYlcs)
        {
            iIsYl = 0;
            iYlcs = 0;
            try
            {
                string thisTimes = "";
                if (!string.IsNullOrEmpty(execTimes))
                {
                    string varSplit = @"/";
                    if (execTimes.Contains(varSplit))
                    {
                        char charSplit = varSplit.ToCharArray()[0];
                        string[] times = execTimes.Split(charSplit);

                        for (int i = 0; i < times.Length; i++)
                        {
                            thisTimes = times[i];
                            if (thisTimes.Equals("24:00"))
                            {
                                thisTimes = "23:59";
                            }

                            DateTime ylDate = Convert.ToDateTime(ylTimes);
                            DateTime thisDate = Convert.ToDateTime(thisTimes);

                            if (ylDate >= thisDate)
                            {
                                iIsYl = 1;
                                iYlcs++;
                            }
                        }
                    }
                    else
                    {
                        thisTimes = execTimes;
                        if (thisTimes.Equals("24:00"))
                        {
                            thisTimes = "23:59";
                        }

                        DateTime ylDate = Convert.ToDateTime(ylTimes);
                        DateTime thisDate = Convert.ToDateTime(thisTimes);

                        if (ylDate >= thisDate)
                        {
                            iIsYl = 1;
                            iYlcs++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡԤ��ҩ��Ϣʱerr��" + ex.Message);
            }
        }

        private string GetYpTlfl(long cjid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) FROM VI_YP_YPCD A WHERE A.CJID={0}", cjid);

                string tlfl = Convertor.IsNull(_database.GetDataResult(ssql), "00");

                return tlfl;
            }
            catch
            {
                return "00";
            }
        }

        #endregion

        public void GetYpKcmxInfo(int dwlx, long cjid, int xmly, long ExecDept, out string unit, out decimal kcl, out decimal xnkcl)
        {
            unit = "";
            kcl = 0;
            string ssql = "";
            try
            {
                if (xmly != 1)
                    throw new Exception("��ҩƷû�п����Ϣ");

                if (dwlx == 1)
                {
                    //hldw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.HLDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);

                }
                else if (dwlx == 2)
                {
                    //bzdw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.BZDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }
                else if (dwlx == 3)
                {
                    //ykdw
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.YPDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }
                else if (dwlx == 4)
                {
                    //yfdw 
                    ssql = string.Format(@"SELECT B.DWMC,A.KCL,A.xnKCL FROM VI_YF_KCMX A INNER JOIN YP_YPDW B ON A.ZXDW=B.ID WHERE CJID={0} AND DEPTID={1} ", cjid, ExecDept);
                }

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null || dt.Rows.Count <= 0)
                {
                    //û�п����Ϣ
                    //throw new Exception("\r\n��ȡҩƷ�����Ϣ����" + cjid + " ҩ����" + ExecDept + " ��λ���ͣ�" + dwlx);
                    unit = "";
                    kcl = 0;
                    xnkcl = 0;
                    return;
                }

                unit = dt.Rows[0]["DWMC"].ToString();
                kcl = decimal.Parse(dt.Rows[0]["KCL"].ToString());
                xnkcl = decimal.Parse(Convertor.IsNull(dt.Rows[0]["xnKCL"], "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ��ȡƵ��
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable GetFreqByFreqName(DataTable dtFreq)
        {
            try
            {
                string fil = string.Format(@"NAME='{0}'", FREQUENCY.ToString().Trim());
                DataRow[] drs = dtFreq.Select(fil);

                DataTable dt = dtFreq.Clone();

                for (int i = 0; i < drs.Length; i++)
                {
                    dt.Rows.Add(drs[i].ItemArray);
                }

                dt.AcceptChanges();

                if (dt == null || dt.Rows.Count <= 0)
                    throw new Exception(FREQUENCY + " ��ҽ��Ƶ���ڻ������в�����");

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetExecNums(DateTime execNow, DateTime execEnd)
        {
            try
            {
                int iExecNum = EXECNUM;//Ĭ��Ϊҽ��ִ�д���
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    //����ҽ��Ƶ�δ���
                    if (STATUS_FLAG == 4)
                    {
                        if (!STOPEXEDATE.HasValue)
                        {
                            throw new Exception(_orderList[0].ORDER_CONTEXT + " �Ѿ�ͣ����,û��ͣ��ʱ��,����ϵ����Ա��");
                        }
                    }

                    //ִ�д�����ȡ˳��
                    //1�����ж�ĩ�Σ�������쿪����ͣ�ж�ĩ��
                    //2���״��ж�
                    //3��Ԥִ���߼�
                    if (STOPEXEDATE.HasValue && execNow.Date == STOPEXEDATE.Value.Date && STATUS_FLAG == 4)
                    {
                        if (LASTEXECDATE.HasValue && LASTEXECDATE.Value == STOPEXEDATE.Value)
                        {
                            iExecNum = TERMINALTIMES.Value - execNumEver;//����ִ��ĩ��=ҽ��ĩ��-��ǰԤִ�д���
                        }
                        else
                        {
                            iExecNum = TERMINALTIMES.Value;
                        }

                        if (iExecNum < 0)
                        {
                            iExecNum = 0;
                        }
                    }
                    else if (execNow.Date == BEGINEXEDATE.Date)
                    {
                        iExecNum = FRISTTIMES.Value;
                    }
                    else if (ISYL == 1)
                    {
                        //�����ҪԤִ��
                        bool isExec = LASTEXECDATE.HasValue;

                        //�ϴ�ִ�����ڵ��ڵ�ǰ���� ,�Ҳ�����ѭ�����һ�� ����ִ�д���-�ϴ�ִ�еĴ���
                        if (isExec && execNow.Date == LASTEXECDATE.Value.Date && execNow.Date != execEnd.Date)
                        {
                            iExecNum = EXECNUM - execNumEver;//����ִ��ĩ��=ҽ��ĩ��-��ǰԤִ�д���
                        }
                        else
                        {
                            //ִ�е����һ�죬���ж�Ԥ��ҩ
                            if (execNow.Date == execEnd.Date)
                            {
                                if (isExec && execNow.Date == LASTEXECDATE.Value.Date && execNumEver > 0)
                                {
                                    iExecNum = 0;//�Ѵ���ִ�м�¼   ��Ԥ��
                                }
                                else
                                {
                                    iExecNum = YLCS;//Ԥ��
                                }
                            }
                            else
                            {
                                iExecNum = EXECNUM;//�����һ�Σ���ִ�д���Ϊ��Ƶ�ʴ���
                            }
                        }
                    }
                    else if (STOPEXEDATE.HasValue && STOPEXEDATE.Value.Date > STOPEXEDATE.Value.Date && STATUS_FLAG == 4)
                    {
                        iExecNum = 0;//���������Ĺ��������
                    }



                    //--�ж��Ƿ�����ִ�з�������
                    //--Modify By Tany 2015-04-22 �����ͳ����˵��Ĳ����ֿ�
                    //IF ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7070)='1' AND @MNGTYPE=0)
                    //    OR ((SELECT CONFIG FROM JC_CONFIG WHERE ID=7804)='1' AND @MNGTYPE=2)
                    //BEGIN
                    //    --�������С��Ӧ��ִ�е����ڲ���С�ڽ��죬��ô����ִ�е�����Ч
                    //    IF CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(@EXECDATE))
                    //        AND CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE))<CONVERT(DATETIME,DBO.FUN_GETDATE(GETDATE()))
                    //    BEGIN
                    //        SET @EXENUM=0
                    //    END
                    //END

                    if ((MNGTYPE == 0 && _cfgList.cfg7070.Config.ToString().Equals("1"))
                        || (MNGTYPE == 2 && _cfgList.cfg7804.Config.ToString().Equals("1")))
                    {
                        DateTime now = DateManager.ServerDateTimeByDBType(_database);

                        if (execNow.Date < EXECDATE.Date && execNow.Date < now.Date)
                        {
                            iExecNum = 0;
                        }
                    }
                }

                if (CYCLELX == 1)
                {
                    //���ѭ����������1�����ϴ���Чִ�й���Ҳ����˵��һ�ο϶���ִ�еģ������ǳ���
                    if (CYCLEDAY > 1 && LASTVALIDEXECDATE.HasValue && (MNGTYPE == 0 || MNGTYPE == 2))
                    {
                        DateTime valideExecDate = LASTVALIDEXECDATE.Value.Date;

                        TimeSpan tp1 = execNow.Date.Subtract(valideExecDate);
                        int iDiff = tp1.Days;

                        if (iDiff != CYCLEDAY)
                        {
                            iExecNum = 0;
                        }
                    }
                }
                else if (CYCLELX == 2 && (MNGTYPE == 0 || MNGTYPE == 2))
                {
                    //IF (CHARINDEX(CONVERT(VARCHAR,DATEPART(WEEKDAY,@CUREXECDATE)),CONVERT(VARCHAR,@ZXR))=0)
                    //BEGIN
                    //    SET @EXENUM=0
                    //END
                    DayOfWeek dw = execNow.DayOfWeek;

                    int iDw = (int)dw;//0�������� 1������1 6������6  etc...
                    int thisDw = iDw + 1;//�ͻ�������ά����ִ���ղ�ͬ  ���գ�1246  ˫�գ�357����+1��

                    if (!ZXR.ToString().Contains(thisDw.ToString()))
                    {
                        iExecNum = 0;
                    }
                }

                return iExecNum;
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡִ�д���ʱʱerr��" + ex.Message);
            }
        }

        public string GetPrescNo()
        {
            try
            {
                string ssql = string.Format(@"select CONVERT(DECIMAL(21,6),CONVERT(VARCHAR,GETDATE(),112)+CONVERT(VARCHAR,DATEPART(HH,GETDATE()))+CONVERT(VARCHAR,DATEPART(MI,GETDATE()))+CONVERT(VARCHAR,DATEPART(SS,GETDATE()))+'.'+CONVERT(VARCHAR,DATEPART(MS,GETDATE())))");

                string ret = _database.GetDataResult(ssql).ToString();

                //decimal dRet = decimal.Parse(ret);

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("��ȡcfhʱʱerr��" + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// ѭ��ִ��ҽ��ǰ׼������
        /// </summary>
        /// <returns>0������ִ��  1��return  2��nextday </returns>
        public int DoPrepareExecOrderFirst()
        {
            int iret = 0;
            try
            {
                //1����һ��У��ҽ���Ƿ��ܹ�ִ��
                iret = CanOrderExec();
                if (iret == 1 || iret == 2)
                {
                    //��Ҫ����ִ��  ��������׼��
                    return iret;
                }

                //2���ڶ��� ����ǰִ��ʱ��CUREXECDATE��LASTEXECDATE��LASTVALIDEXECDATE
                SetCurrExecDate();

                //3�������� ��ͣת������ִ��ʱ��С��ͣʱ�� ����ִ��ʱ��EXECDATE
                SetExecDate();

                //4�����Ĳ�
                iret = CanOrderExecWhenStop();
                if (iret == 1 || iret == 2)
                {
                    //��Ҫ����ִ��  ��������׼��
                    return iret;
                }

                //5����5��pivas����
                int iErr = -1;
                string strMsg = "";
                pvsBit = SetPivasBit(out EXEDEPT, out iErr, out strMsg);
                if (iErr == -1)
                {
                    iret = 1;
                    return iret;
                }

                //6����6����ִ���
                cfBit = SetCfBit();


                //7����7��dept_br����
                OrderEntity order = _orderList[0];//ִ�п��ҴӴ�С�����������к����Ա�ҩ��
                SetDeptBr(order.DEPT_BR);

                //8����8��dept_ly����
                SetDeptLyInfo(order.DEPT_ID.ToString().Trim());

                //9����9��Ԥ��ҩ����
                int iAddExecDate = 0;
                SetYlyInfo(out iAddExecDate);
                if (iAddExecDate > 0)
                {
                    //Ԥ��ҩ��ҪԤִ�д���EXECDATE
                    EXECDATE = EXECDATE.AddDays(iAddExecDate);
                }

                return iret;

            }
            catch (Exception ex)
            {
                //throw new Exception("ѭ��ִ��ҽ��ǰ׼������err��" + ex.Message);
                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ѭ��ִ��ҽ��ǰ׼������err��" + ex.Message);
            }
        }

        /// <summary>
        /// ִ�е���
        /// </summary>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public void DoExcuteFee(int iOut, out int iret, out string strMsg)
        {
            iret = -1;
            strMsg = "";
            try
            {
                DateTime execStart = CUREXECDATE.Date;
                DateTime execEnd = EXECDATE.Date;

                //�������ʱ��ִ����
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    execEnd = CUREXECDATE.Date;//��ʱִֻ�е���
                }

                //�������ҽ��ֹͣ
                if (MNGTYPE == 0 || MNGTYPE == 2)
                {
                    //�Ѿ�ͣת��
                    if (STOPEXEDATE.HasValue && STATUS_FLAG == 4)
                    {
                        if (execEnd.Date > STOPEXEDATE.Value.Date)
                        {
                            //ִ��ʱ��>����ͣ����
                            execEnd = STOPEXEDATE.Value.Date;//ִ�е�ͣ���ڼ���
                        }
                    }
                }

                TimeSpan tp = execEnd.Subtract(execStart);
                int iExecDays = tp.Days;

                int iExecNum = EXECNUM;//ִ�д���

                bool isAddFeeOrNextDay = true;//�ǲ���������   ����  �Զ�����  wait
                if (iExecDays < 0)
                {
                    //��ִ��ʱ��>����ʱ��[ִ��һ�γ���]
                    isAddFeeOrNextDay = false;
                    iExecDays = 0;
                }
                //��ִ����Ҫʵ������
                Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderLists
                    = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();//��ִ�м�¼
                List<OrderEntity> updateLastInfo = new List<OrderEntity>();
                List<XnKclEntity> xnKcLists = new List<XnKclEntity>();
                List<OrderPrescEntity> fjPrescLists = new List<OrderPrescEntity>();
                List<OrderFeeEntity> fjFeeLists = new List<OrderFeeEntity>();
                List<YjZySqEntity> yjsqLists = new List<YjZySqEntity>();
                List<YjZySqEntity> yjqrLists = new List<YjZySqEntity>();
                //ת��list
                List<OrderExecEntity> ordExeLists = new List<OrderExecEntity>();
                List<OrderPrescEntity> ordPrescLists = new List<OrderPrescEntity>();
                List<OrderFeeEntity> ordFeeLists = new List<OrderFeeEntity>();

                //�Զ�������Ҫʵ������
                List<OrderEntity> cz_updateOrderInfo = new List<OrderEntity>();
                List<OrderFeeEntity> cz_FeeLists = new List<OrderFeeEntity>();
                List<XnKclEntity> cz_xnKcLists = new List<XnKclEntity>();
                List<YjZySqEntity> cz_upDatetYjsqLists = new List<YjZySqEntity>();
                List<string> cz_updateFeeFlagLists = new List<string>();
                List<OrderFeeEntity> cz_delFeeLists = new List<OrderFeeEntity>();

                //ע��������Ӧ����<=����execStart��ʼ  ִ�е�execEnd���������+1
                for (int i = 0; i <= iExecDays; i++)
                {
                    orderLists.Clear();
                    updateLastInfo.Clear();
                    xnKcLists.Clear();
                    fjPrescLists.Clear();
                    fjFeeLists.Clear();
                    yjsqLists.Clear();
                    yjqrLists.Clear();

                    ordExeLists.Clear();
                    ordPrescLists.Clear();
                    ordFeeLists.Clear();

                    cz_updateOrderInfo.Clear();
                    cz_FeeLists.Clear();
                    cz_xnKcLists.Clear();
                    cz_upDatetYjsqLists.Clear();
                    cz_updateFeeFlagLists.Clear();
                    cz_delFeeLists.Clear();

                    //ִ��׼��������execNow/iExecNum
                    DateTime execNow = CUREXECDATE.AddDays(i);//����ִ������
                    EXECBOOKDATE = DateManager.ServerDateTimeByDBType(_database);


                    if (isAddFeeOrNextDay)
                    {
                        //ƴ��ʵ��
                        int iOutPut = DoExcuteAddFee(execNow, execEnd, iExecNum,
                            orderLists, updateLastInfo, xnKcLists,
                            fjPrescLists, fjFeeLists, yjsqLists,
                            yjqrLists, out  iret, out  strMsg);

                        if (iOutPut == 2)
                        {
                            //ƴ��ʵ��
                            DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay ���Ҽ���forѭ��
                        }
                        else if (iOutPut == 1)
                        {
                            return;//ִֹͣ��
                        }
                        else if (iOutPut == 0)
                        {
                            _orderExecList.Sort();
                            if (_orderExecList.Count > 0)
                            {
                                for (int iOrderExe = 0; iOrderExe < _orderExecList.Count; iOrderExe++)
                                {
                                    OrderExecEntity ordExe = _orderExecList[iOrderExe];
                                    int isAna = int.Parse(Convertor.IsNull(ordExe.ISANALYZED, "0"));

                                    DateTime thisExeDate = ordExe.EXECDATE;

                                    if (isAna > 0 && !LASTVALIDEXECDATE.HasValue)
                                    {
                                        LASTVALIDEXECDATE = ordExe.EXECDATE;//���û��ֵ����ֵ��ǰִ��ʱ��
                                    }

                                    //if (isAna > 0)
                                    if (isAna > 0 && (LASTVALIDEXECDATE.HasValue && thisExeDate > LASTVALIDEXECDATE))
                                    {
                                        //NextDay֮ǰ �ظ�ֵ�����Чʱ��
                                        LASTVALIDEXECDATE = ordExe.EXECDATE;//LASTVALIDEXECDATE����//���ִ�����ڵ���ȡ��Чִ�д���>0�ļ�¼
                                    }
                                }
                            }

                            //ƴ��ʵ��
                            DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay ���Ҽ���forѭ��
                        }
                    }
                    else
                    {
                        //ƴ��ʵ��
                        DoExcuteNextDay(execNow, cz_updateOrderInfo, cz_FeeLists, cz_xnKcLists, cz_upDatetYjsqLists, cz_updateFeeFlagLists, cz_delFeeLists, out iret, out strMsg);//NextDay ���Ҽ���forѭ��
                    }

                    if (orderLists.Count > 0)
                    {
                        //GetExecEntity(orderLists, out ordExeLists, out ordPrescLists, out ordFeeLists);
                        GetExecEntity(execNow, orderLists, out ordExeLists, out ordPrescLists, out ordFeeLists);//У��˫��ҽ���汾
                    }

                    ////ִ������֮ǰ�ڲ�ѯһ��execNow�Ƿ����ִ�м�¼����������insert[���ϣ���Ԥ��ҩ�ͳ��������]
                    //string strSql = string.Format(@"select count(1) as Num from  ZY_ORDEREXEC where  ORDER_ID='{0}' and  CONVERT(DATETIME,DBO.FUN_GETDATE(EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))", ORDERID.ToString(), execNow);

                    //int iCnt = int.Parse(Convertor.IsNull(_database.GetDataResult(strSql), "0"));

                    //if (iCnt <= 0)
                    //{
                    //��ʼҵ������ִ�У�wait
                    ExecCommit(ordExeLists, ordPrescLists, ordFeeLists,
                        updateLastInfo, xnKcLists,
                        fjPrescLists, fjFeeLists,
                        yjsqLists, yjqrLists,
                        cz_FeeLists, cz_xnKcLists,
                        cz_upDatetYjsqLists,
                        cz_updateFeeFlagLists, cz_delFeeLists,
                        cz_updateOrderInfo,
                        out iret, out strMsg);
                    //}
                }

                iret = 0;
                strMsg = "";
            }
            catch (Exception ex)
            {
                throw new Exception("ִ��ҽ��ʱerr��" + ex.Message);
            }
        }

        /// <summary>
        /// ����ִ��
        /// </summary>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public int ExecCommit(
            //ִ����
            List<OrderExecEntity> ordExeLists, List<OrderPrescEntity> ordPrescLists, List<OrderFeeEntity> ordFeeLists,
            List<OrderEntity> updateLastInfo, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists,
            //���������
            List<OrderFeeEntity> cz_FeeLists, List<XnKclEntity> cz_xnKcLists,
            List<YjZySqEntity> cz_upDatetYjsqLists,
            List<string> cz_updateFeeFlagLists, List<OrderFeeEntity> cz_delFeeLists,
            List<OrderEntity> cz_updateOrderInfo,//�����
            out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;

            if (ordExeLists.Count <= 0 && updateLastInfo.Count <= 0 && cz_FeeLists.Count <= 0 && cz_updateOrderInfo.Count <= 0)
            {
                iret = 0;
                strMsg = "";
                iOutPut = 0;
                return iOutPut;
            }

            bool CanExecFee = true;//�Ƿ�ִ������¼
            if (ordExeLists.Count <= 0)
            {
                //Ƶ��У��δͨ��
                CanExecFee = false;
            }

            _database.BeginTransaction();
            try
            {
                string ssql = "";

                if (CanExecFee && ordExeLists.Count > 0)
                {
                    foreach (OrderExecEntity ettOrdExe in ordExeLists)
                    {
                        ssql = ettOrdExe.AddExecInfo();

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ����ҽ��ִ�б�û�����ݣ����飡");
                        }
                    }
                }
                if (CanExecFee && updateLastInfo.Count > 0)
                {
                    foreach (OrderEntity ettOrd in updateLastInfo)
                    {
                        ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET LASTEXECDATE='{0}',LASTEXECUSER='{1}' 
                                           WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                            AND (MNGTYPE='{5}' OR MNGTYPE='{6}') AND DELETE_BIT=0 ",
                                            ettOrd.LASTEXECDATE, ettOrd.LASTEXECUSER,
                                            _Binid, _Babyid, _Groupid,
                                            MNGTYPE, MNGTYPE2);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (CanExecFee && xnKcLists.Count > 0)
                {
                    if (XMLY == 1)
                    {
                        foreach (XnKclEntity ettXnKcl in xnKcLists)
                        {
                            string TMP_CJID = ettXnKcl.cjid;
                            string ypsl = ettXnKcl.num;
                            string TMED_DWLX = ettXnKcl.dwbl;
                            string TMED_EXEC_DEPT = ettXnKcl.execDeptId;

                            UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//ʧ�ܲ��ع�
                        }
                    }
                }
                if (CanExecFee && ordPrescLists.Count > 0)
                {

                    foreach (OrderPrescEntity ettOrdPresc in ordPrescLists)
                    {
                        ssql = ettOrdPresc.AddPrescInfo(XMLY);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ���봦����ҩƷ��Ϣû�����ݣ����飡");
                        }
                    }
                }
                if (CanExecFee && ordFeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in ordFeeLists)
                    {
                        int iType = 0;
                        ssql = ettOrdFee.AddFeeInfo(XMLY, iType);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ������ñ�" + (XMLY == 1 ? "ҩƷ" : "��Ŀ") + "��Ϣ����");
                        }
                    }
                }
                if (CanExecFee && yjsqLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjSq in yjsqLists)
                    {
                        ssql = string.Format(@"INSERT INTO YJ_ZYSQ 
			                                    ( 
				                                    YJSQID, JGBM, BRXXID, INPATIENT_ID, 
				                                    SQRQ, SQR, SQKS, SQNR, 
				                                    JE, LCZD, ZXKS, BSJC, 
				                                    BBMC, ZYSX, BJJBZ, YZID, YZXMID,
				                                    ZXR, ZXSJ, ZXID, DJLX
			                                    )
                                            values('{0}','{1}','{2}','{3}',
                                                    '{4}','{5}','{6}','{7}',
                                                    '{8}','{9}','{10}','{11}',
                                                    '{12}','{13}','{14}','{15}','{16}',
                                                    '{17}','{18}','{19}','{20}'
                                                    )",
                                                   ettYjSq.YJSQID, ettYjSq.JGBM, ettYjSq.BRXXID, ettYjSq.INPATIENT_ID,
                                                   ettYjSq.SQRQ, ettYjSq.SQR, ettYjSq.SQKS, ettYjSq.SQNR,
                                                   ettYjSq.JE, ettYjSq.LCZD, ettYjSq.ZXKS, ettYjSq.BSJC,
                                                   ettYjSq.BBMC, ettYjSq.ZYSX, ettYjSq.BJJBZ, ettYjSq.YZID, ettYjSq.YZXMID,
                                                   ettYjSq.ZXR, ettYjSq.ZXSJ, ettYjSq.ZXID, ettYjSq.DJLX);

                        iret = _database.DoCommand(ssql);
                        if (iret <= 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ����ҽ�������û�����ݣ����飡");
                        }
                    }
                }
                if (CanExecFee && yjqrLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjqr in yjsqLists)
                    {
                        Guid YJ_EXEC_ID = ettYjqr.ZXID;
                        Guid YJ_APP_ID = ettYjqr.YJSQID;
                        Guid YJ_ORDER_ID = ettYjqr.YZID;
                        decimal YJ_JE = ettYjqr.JE;

                        Guid NEWYJSQID = Guid.Empty;
                        int iSqRet = -1;
                        string strSqMsg = "";

                        string qrsj = EXECBOOKDATE.ToString("yyyy-MM-dd HH:mm:ss");
                        int iDept = Convert.ToInt32(DEPTID);
                        int iExeUser = Convert.ToInt32(EXEUSER);

                        yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, iDept, qrsj, iExeUser, 1, qrsj, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                        if (iSqRet != 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ҽ��ȷ�ѳ���" + strSqMsg);
                        }
                    }
                }
                ////wait
                //if (CanExecFee && fjPrescLists.Count > 0)
                //{
                //}
                //if (CanExecFee && fjFeeLists.Count > 0)
                //{
                //}

                //�Զ�����
                if (cz_FeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in cz_FeeLists)
                    {
                        int iType = 1;
                        ssql = ettOrdFee.AddFeeInfo(XMLY, iType);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (cz_upDatetYjsqLists.Count > 0)
                {
                    foreach (YjZySqEntity ettYjqr in cz_upDatetYjsqLists)
                    {
                        ssql = string.Format(@"update yj_zysq set btfbz=1,tfje=TFJE-{2} where yzid='{0}' and zxid='{1}'", ettYjqr.YZID, ettYjqr.ZXID, ettYjqr.TFJE);

                        iret = _database.DoCommand(ssql);
                    }
                }
                if (cz_xnKcLists.Count > 0)
                {
                    if (XMLY == 1)
                    {
                        foreach (XnKclEntity ettXnKcl in cz_xnKcLists)
                        {
                            string TMP_CJID = ettXnKcl.cjid;
                            string ypsl = ettXnKcl.num;
                            string TMED_DWLX = ettXnKcl.dwbl;
                            string TMED_EXEC_DEPT = ettXnKcl.execDeptId;

                            UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//ʧ�ܲ��ع�
                        }
                    }
                }
                if (cz_updateFeeFlagLists.Count > 0)
                {
                    foreach (string feeid in cz_updateFeeFlagLists)
                    {
                        ssql = string.Format(@"UPDATE ZY_FEE_SPECI SET CZ_FLAG=1 WHERE ID='{0}'", feeid);

                        iret = _database.DoCommand(ssql);
                    }
                }

                if (cz_delFeeLists.Count > 0)
                {
                    foreach (OrderFeeEntity ettOrdFee in cz_delFeeLists)
                    {
                        ssql = string.Format(@"UPDATE ZY_FEE_SPECI SET DELETE_BIT=1,BZ=ISNULL(BZ,'')+'�Զ�����ɾ��' WHERE FY_BIT=0 AND SCBZ=0 AND (ID='{0}' OR CZ_ID='{0}')  ", ettOrdFee.ID);

                        iret = _database.DoCommand(ssql);
                    }
                }

                //���
                if (cz_updateOrderInfo.Count > 0)
                {
                    foreach (OrderEntity ettOrd in cz_updateOrderInfo)
                    {
                        if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                        {

                            ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG='{0}',ORDER_EDATE='{1}'
                                                WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' AND STATUS_FLAG =2 AND DELETE_BIT=0 
                                                    AND ((MNGTYPE='{5}' OR MNGTYPE='{6}') or ({5} in (1,5) and MNGTYPE in (1,5))) ",
                                                    5, ettOrd.ORDER_EDATE.Value, _Binid, _Babyid, _Groupid, MNGTYPE, MNGTYPE2
                                                 );
                        }

                        if (MNGTYPE == 0 || MNGTYPE == 2)
                        {
                            if (NTYPE == 0)
                            {
                                if (ettOrd.ORDER_EDATE.HasValue)
                                {
                                    ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG=5,ORDER_EDATE='{0}',ORDER_EDOC='{1}',LASTEXECDATE=GETDATE()
                                                        WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                                        AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0 ",
                                                            ettOrd.ORDER_EDATE.Value, ettOrd.ORDER_EDOC.Value, _Binid, _Babyid, _Groupid
                                                         );
                                }
                                else
                                {
                                    ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG=5,ORDER_EDATE=null,ORDER_EDOC=null 
                                                         WHERE INPATIENT_ID='{0}' AND BABY_ID='{1}' AND GROUP_ID='{2}' 
                                                         AND (MNGTYPE=0 OR MNGTYPE=2) AND NTYPE = 0 ",
                                                         _Binid, _Babyid, _Groupid
                                                         );
                                }
                            }
                            else
                            {
                                ssql = string.Format(@"UPDATE ZY_ORDERRECORD SET STATUS_FLAG='{0}',LASTEXECDATE='{1}'
                                                        WHERE INPATIENT_ID='{2}' AND BABY_ID='{3}' AND GROUP_ID='{4}' 
                                                        AND (STATUS_FLAG=4 OR (STATUS_FLAG=2 AND NTYPE=0)) AND (MNGTYPE=0 OR MNGTYPE=2) ",
                                                        5, ettOrd.LASTEXECDATE.Value, _Binid, _Babyid, _Groupid
                                                     );
                            }
                        }

                        iret = _database.DoCommand(ssql);
                    }
                }

                _database.CommitTransaction();

                iret = 0;
                strMsg = "";
                iOutPut = 0;
            }
            catch (Exception ex)
            {
                _database.RollbackTransaction();
                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ��ţ�" + _Groupid + " ����ִ��ҽ��ʱerr��" + ex.Message);

                //iOutPut = 1;//return
                //iret = -1;
                //return iOutPut;
            }
            return iOutPut;
        }

        /// <summary>
        /// ��ִ�з���
        /// </summary>
        /// <param name="execNow"></param>
        /// <param name="iret"></param>
        /// <param name="strMsg"></param>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public int DoExcuteAddFee(DateTime execNow, DateTime execEnd, int iExecNum,
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderLists,
             List<OrderEntity> updateLastInfo, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists, out int iret, out string strMsg)
        {
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo
                = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();

            iret = 0;
            strMsg = "";
            int iOutPut = 0;
            try
            {
                //��ʼִ��ʱ���ֹͣʱ����ж�
                if (execNow.Date < BEGINEXEDATE.Date)
                {
                    //Goto NextDay 
                    iOutPut = 2;
                    return iOutPut;
                }

                //ExecNum
                iExecNum = GetExecNums(execNow, execEnd);//��������ִ�д�����ע�⡿

                string dCfh = GetPrescNo();

                #region"1������ִ�б�  2:����set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER"

                //1������ִ�б�
                foreach (OrderEntity ettOrd in _orderList)
                {
                    int iCfExecCnt = iExecNum;
                    bool bCf = false;
                    if (cfBit == 1 && XMLY == 1 && iExecNum > 0)
                    {
                        //��Ҫ���
                        iCfExecCnt = 1;
                        bCf = true;
                    }

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo
                        = new Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>();

                    while (iCfExecCnt <= iExecNum)
                    {
                        OrderExecEntity ettOrdExec = new OrderExecEntity();

                        /*
                         * 
                        INSERT INTO #ZY_ORDEREXEC (ID,BOOK_DATE,ORDER_ID,EXEUSER,EXECDATE,ISANALYZED,PRESCRIPTION_ID,INPATIENT_ID,BABY_ID,JGBM,pvs_xh)--Modify by jchl ��Ƶ�ʲ������߼����룩
                        SELECT DBO.FUN_GETGUID(NEWID(),GETDATE()),@EXECBOOKDATE, ORDER_ID,@EXEUSER,@CUREXECDATE,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then 1 else @EXENUM end),@CFH,@INPATIENTID,@BABYID,@JGBM,(case when @cfbz=1 and @XMLY=1 and @EXENUM>0 then @cfcs else -1 end)  --Modify by jchl ��Ƶ�ʲ������߼����룩
                         */

                        ettOrdExec.ID = PubStaticFun.NewGuid();
                        ettOrdExec.BOOK_DATE = EXECBOOKDATE;
                        ettOrdExec.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdExec.EXEUSER = EXEUSER;
                        ettOrdExec.EXECDATE = execNow;

                        ettOrdExec.ISANALYZED = bCf ? 1 : iExecNum;
                        ettOrdExec.PRESCRIPTION_ID = dCfh;
                        ettOrdExec.INPATIENT_ID = _Binid;
                        ettOrdExec.BABY_ID = _Babyid;
                        ettOrdExec.JGBM = _JGBM;

                        ettOrdExec.PVS_XH = bCf ? iCfExecCnt : -1;

                        //1������ִ�б�
                        execListsInfo.Add(ettOrdExec, new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>());//������ִ�б�����
                        _orderExecList.Add(ettOrdExec);//�����м��

                        ettOrd.LASTEXECDATE = execNow;//������ִ�б�����
                        ettOrd.LASTEXECUSER = EXEUSER;//������ִ�б�����

                        iCfExecCnt++;
                    }

                    orderInfo.Add(ettOrd, execListsInfo);
                }

                #endregion

                //wait
                //2:����set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                OrderEntity updateLastOrder = new OrderEntity();
                updateLastOrder.LASTEXECDATE = execNow;
                updateLastOrder.LASTEXECUSER = EXEUSER;
                updateLastInfo.Add(updateLastOrder);

                //����Ǵ���ֹͣʱ�����ִ�е�����֮�䣬��ֻдZY_ORDEREXEC��������Ϊ�ա�
                if (iExecNum == 0)
                {
                    //����Ǵ���ֹͣʱ�����ִ�е�����֮�䣬��ֻдZY_ORDEREXEC��������Ϊ�ա�

                    foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
                    {
                        OrderEntity ettOrd = kvOrdList.Key;

                        Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                        orderLists.Add(ettOrd, execListsInfo);
                    }

                    // goto next 
                    iOutPut = 2;
                    return iOutPut;
                }

                #region"���봦�������ñ�etc"

                foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
                {
                    OrderEntity ettOrd = kvOrdList.Key;

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                    Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execLists
                        = new Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>();

                    orderLists.Add(ettOrd, execLists);

                    foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                    //foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                        Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                        Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();
                        //ִ�ж�Ӧ����
                        execLists.Add(ettOrdExec, prescLists);

                        #region"ҩƷ��������ZY_PRESCRIPTION"

                        string TMED_ID = "";
                        string TMED_ORDER_ID = "";
                        string TMED_DEPT_ID = "";
                        string TMED_DEPT_BR = "";
                        string TMED_EXEC_DEPT = "";
                        string TMED_ORDER_DOC = "";
                        string TMED_NUM = "";
                        string TMED_HOITEM_ID = "";
                        string TMED_ITEM_CODE = "";
                        string TMED_XMLY = "";
                        string TMED_DWLX = "";
                        string ORDERUNIT = "";
                        string TMED_ORDER_SPEC = "";
                        string TMED_DOSAGE = "";
                        string TMED_MNGTYPE = "";
                        string TMED_JZ_FLAG = "";
                        string TMED_ORDER_CONTEXT = "";
                        string TMED_NTYPE = "";
                        string TMED_STATCODE = "";
                        string TEMD_TLFL = "";

                        //--|��ʱ���Ϊ����������ҽ��ִ�б��õ�Ҫ����Ĵ�����ļ�¼
                        //--|ҩ��Ҫѭ���������ͼ۸� MODIFY BY TANY 2005-09-11
                        //IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0
                        if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0)
                        {

                            //�������Ա�ҩ
                            if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                                continue;

                            TMED_ID = ettOrdExec.ID.ToString();
                            TMED_ORDER_ID = ettOrd.ORDER_ID.ToString();
                            TMED_DEPT_ID = ettOrd.DEPT_ID.ToString();
                            TMED_DEPT_BR = ettOrd.DEPT_BR.ToString();
                            TMED_EXEC_DEPT = ettOrd.EXEC_DEPT.ToString();
                            if (pvsBit == 1)
                            {
                                //pvs����
                                TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                int iDiff2 = tm2.Days;
                                if (iDiff2 >= 1)
                                {
                                    //pivas��һ��ҩ�����ã�wait to��װ��
                                    TMED_EXEC_DEPT = EXEDEPT.ToString();
                                }
                            }
                            TMED_ORDER_DOC = ettOrd.ORDER_DOC.ToString();
                            TMED_NUM = ettOrd.NUM.ToString();
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                TMED_NUM = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                            }
                            TMED_HOITEM_ID = ettOrd.HOITEM_ID.ToString();
                            TMED_ITEM_CODE = ettOrd.ITEM_CODE.ToString();
                            TMED_XMLY = ettOrd.XMLY.ToString();
                            TMED_DWLX = ettOrd.DWLX.ToString();
                            ORDERUNIT = ettOrd.UNIT;
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                ORDERUNIT = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                            }

                            TMED_ORDER_SPEC = ettOrd.ORDER_SPEC.ToString();
                            TMED_DOSAGE = ettOrd.DOSAGE.ToString();
                            TMED_MNGTYPE = ettOrd.MNGTYPE.ToString();
                            TMED_JZ_FLAG = ettOrd.JZ_FLAG.ToString();
                            TMED_ORDER_CONTEXT = ettOrd.ORDER_CONTEXT.ToString();
                            TMED_NTYPE = ettOrd.NTYPE.ToString();

                            if (ettOrd.XMLY == 1)
                            {
                                DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                                if (dtYp == null || dtYp.Rows.Count <= 0)
                                {
                                    throw new Exception(ettOrd.HOITEM_ID + " ҩƷ���ҵ���δ�ҵ���ҩƷ��Ϣ");
                                }

                                TMED_STATCODE = dtYp.Rows[0]["STATITEM_CODE"].ToString();
                                TEMD_TLFL = dtYp.Rows[0]["TLFL"].ToString();
                            }

                            string unit = "";
                            decimal kcl = 0;
                            decimal xnKcl = 0;
                            long thisExecDept = long.Parse(TMED_EXEC_DEPT);
                            //��ȡpivas�����Ϣ
                            GetYpKcmxInfo(ettOrd.DWLX, ettOrd.HOITEM_ID, ettOrd.XMLY, thisExecDept, out unit, out kcl, out xnKcl);

                            if (string.IsNullOrEmpty(unit))
                            {
                                iOutPut = 1;//return
                                iret = -1;
                                strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�ڡ�" + TMED_EXEC_DEPT + "��û���ҵ������Ϣ�������¿���ҽ����";
                                return iOutPut;
                            }

                            string thisOrderUnit = "";
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                            }
                            else
                            {
                                thisOrderUnit = ettOrd.UNIT;
                            }

                            if (unit.Trim().ToUpper() != thisOrderUnit.Trim().ToUpper())
                            {
                                iOutPut = 1;//return
                                iret = -1;
                                strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�ĵ�λ(" + unit + ")��ҽ���ĵ�λ(" + ettOrd.UNIT + ")��ͬ�������¿���ҽ����";
                                return iOutPut;
                            }

                            decimal _num = decimal.Parse(TMED_NUM);
                            int _cjid = int.Parse(TMED_HOITEM_ID);
                            int _execDeptid = int.Parse(TMED_EXEC_DEPT);

                            DataTable dtYpDw = GetYpkcmxInfo(ettOrd.DWLX, _num, _cjid, _execDeptid);

                            if (dtYpDw == null || dtYpDw.Rows.Count <= 0)
                            {
                                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + "ҩƷ������Ϣ����");
                            }

                            string TMP_GGID = dtYpDw.Rows[0]["GGID"].ToString();
                            string TMP_CJID = dtYpDw.Rows[0]["CJID"].ToString();
                            string TMP_YL = dtYpDw.Rows[0]["YL"].ToString();
                            string TMP_UNIT = dtYpDw.Rows[0]["UNIT"].ToString();
                            string TMP_PRICE = dtYpDw.Rows[0]["PRICE"].ToString();
                            string TMP_SDVALUE = dtYpDw.Rows[0]["SDVALUE"].ToString();
                            string TMP_YDWBL = dtYpDw.Rows[0]["YDWBL"].ToString();
                            string TMP_ZXKSID = dtYpDw.Rows[0]["ZXKSID"].ToString();
                            string TMP_BDELETE = dtYpDw.Rows[0]["BDELETE"].ToString();
                            string TMP_KCL = Convertor.IsNull(dtYpDw.Rows[0]["KCL"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 ���Ϊnull��Ϊ0
                            string TMP_YLKC = Convertor.IsNull(dtYpDw.Rows[0]["YLKC"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 ���Ϊnull��Ϊ0

                            //add by zouchihua  ��������ж� 2012-02-21
                            //�������� ���ҿ�ҽ��ʱ�䲻���ڵ�ǰִ�е�ʱ��
                            if (_cfgList.cfg6035.Config.ToString().Equals("1"))
                            {
                                if (execNow.Date != BEGINEXEDATE.Date)
                                {
                                    decimal dTMP_YL = decimal.Parse(TMP_YL);
                                    decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                    decimal ypsl = -1 * dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;

                                    XnKclEntity xn = new XnKclEntity();
                                    xn.cjid = TMP_CJID;
                                    xn.num = ypsl.ToString();
                                    xn.dwbl = TMED_DWLX;
                                    xn.execDeptId = TMED_EXEC_DEPT;
                                    //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//ʧ�ܲ�����
                                    xnKcLists.Add(xn);
                                }
                            }

                            //Modify By Tany 2009-12-22  ҽ��ִ��ʱ�Ƿ����ƿ���������ҩƷ���ܷ��� 0=���� 1=��
                            if (_cfgList.cfg7059.Config.ToString().Equals("1"))
                            {
                                decimal ylKcl = decimal.Parse(TMP_KCL);
                                decimal dTMP_YL = decimal.Parse(TMP_YL);
                                decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                decimal thisYl = dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;
                                if (thisYl > ylKcl)
                                {
                                    //ҽ��ִ��ҩƷ���������ʱ�Ƿ��Զ��滻ͬ���ͬ�����п���ҩƷ 0=���� 1=��
                                    if (_cfgList.cfg7060.Config.ToString().Equals("1"))
                                    {
                                        iOutPut = 1;//return
                                        iret = -1;
                                        strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�Ŀ����Ϊ(" + ylKcl + ") ����ִ������Ϊ(" + thisYl + ")����������������ִ�У�";
                                        return iOutPut;
                                    }
                                    else
                                    {
                                        //wait ��ҩ�߼�
                                    }
                                }
                            }

                            //����Ǳ����ҵ�ҩ���ж��Ƿ�ֱ�Ӽ���
                            int TMP_CHARGE_BIT = GetMedChargeBit(TMED_EXEC_DEPT, TMED_MNGTYPE, TMED_JZ_FLAG);

                            OrderPrescEntity ettOrdPresc = new OrderPrescEntity();
                            ettOrdPresc.ID = PubStaticFun.NewGuid();
                            ettOrdPresc.INPATIENT_ID = _Binid;
                            ettOrdPresc.BABY_ID = _Babyid;
                            ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                            ettOrdPresc.BOOK_USER = EXEUSER;
                            ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)
                            ettOrdPresc.PRESC_DATE = execNow;
                            ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                            ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdPresc.TYPE = 1;//type=1����ͨ   type=2�����ӷ���
                            ettOrdPresc.DEPT_ID = long.Parse(TMED_DEPT_BR);
                            ettOrdPresc.EXECDEPT_ID = long.Parse(TMED_EXEC_DEPT);
                            ettOrdPresc.PRESC_DOC = long.Parse(TMED_ORDER_DOC);
                            ettOrdPresc.HDITEM_ID = long.Parse(TMED_HOITEM_ID);
                            ettOrdPresc.XMLY = int.Parse(TMED_XMLY);
                            ettOrdPresc.STATITEM_CODE = TMED_STATCODE;
                            ettOrdPresc.SUBCODE = TMED_ITEM_CODE;
                            ettOrdPresc.STANDARD = "";
                            ettOrdPresc.DOSAGE = int.Parse(TMED_DOSAGE);
                            ettOrdPresc.UNIT = TMP_UNIT;
                            ettOrdPresc.UNITRATE = int.Parse(TMP_YDWBL);
                            ettOrdPresc.PRICE = decimal.Parse(TMP_PRICE);
                            ettOrdPresc.AGIO = 1;
                            ettOrdPresc.NUM = decimal.Parse(TMP_YL) * ettOrdExec.ISANALYZED;
                            ettOrdPresc.CHARGE_BIT = TMP_CHARGE_BIT;
                            ettOrdPresc.JGBM = _JGBM;

                            //prescLists.Add(ettOrdPresc, FeeLists);
                            prescListsInfo.Add(ettOrdPresc, new List<OrderFeeEntity>());
                        }

                        #endregion

                        #region"��Ŀ������ZY_PRESCRIPTION"

                        if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                        {
                            //��Ժת�ơ�������˵�����ж��Ƿ��м�¼����
                            if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                                continue;

                            OrderPrescEntity ettOrdPresc = new OrderPrescEntity();

                            DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                            if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                            {
                                throw new Exception("δ�ҵ���" + ettOrd.EXEC_DEPT + " ��ִ�п��Ҷ�Ӧ�Ŀ�����Ϣ");
                            }

                            string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                            long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());

                            DataTable dtXm = GetItemInfo(ettOrd.HOITEM_ID, ettOrd.EXEC_DEPT, ettOrd.JGBM, ExecDeptJgbm);

                            if (dtXm == null || dtXm.Rows.Count <= 0)
                            {
                                if (NTYPE == 0 || NTYPE == 7 || NTYPE == 10)
                                {
                                    //execLists.Add(ettOrdExec, prescLists);
                                    continue;
                                }

                                //�Ʒ�ҽ��δ��Ӧ�շ���Ŀ
                                throw new Exception("δ�ҵ���" + ettOrd.HOITEM_ID + " ��HOITEM_ID��Ӧ�ķ�����Ϣ");
                            }

                            ettOrdPresc.ID = PubStaticFun.NewGuid();
                            ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                            ettOrdPresc.INPATIENT_ID = _Binid;
                            ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)

                            ettOrdPresc.DEPT_ID = ettOrd.DEPT_BR;
                            ettOrdPresc.EXECDEPT_ID = ettOrd.EXEC_DEPT;

                            ettOrdPresc.HDITEM_ID = long.Parse(dtXm.Rows[0]["HDITEM_ID"].ToString().Trim());
                            ettOrdPresc.XMLY = ettOrd.XMLY;

                            ettOrdPresc.STATITEM_CODE = dtXm.Rows[0]["BIGITEMCODE"].ToString().Trim();

                            ettOrdPresc.TCID = long.Parse(dtXm.Rows[0]["TCID"].ToString().Trim());
                            ettOrdPresc.TC_FLAG = int.Parse(dtXm.Rows[0]["TC_FLAG"].ToString().Trim());

                            ettOrdPresc.PRESC_DATE = execNow;
                            ettOrdPresc.PRESC_DOC = ettOrd.ORDER_DOC;
                            ettOrdPresc.STANDARD = ettOrd.ORDER_SPEC;

                            ettOrdPresc.UNIT = dtXm.Rows[0]["UNIT"].ToString().Trim();
                            ettOrdPresc.UNITRATE = 1;

                            if (decimal.Parse(Convertor.IsNull(ettOrd.PRICE, "0")) == 0)
                            {
                                ettOrdPresc.PRICE = decimal.Parse(dtXm.Rows[0]["PRICE"].ToString().Trim());//Ϊ0��ʹ����Ŀ�۸�
                            }
                            else
                            {
                                ettOrdPresc.PRICE = ettOrd.PRICE;//ҽ���۸�Ϊ0��ʹ��ҽ���۸�
                            }
                            ettOrdPresc.AGIO = 1;

                            string thisNum = ettOrd.NUM.ToString();
                            if (MNGTYPE == 1 || MNGTYPE == 5)
                            {
                                thisNum = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                            }
                            decimal dNum = decimal.Parse(thisNum);
                            decimal xmNum = decimal.Parse(dtXm.Rows[0]["NUM"].ToString().Trim());
                            ettOrdPresc.NUM = xmNum * dNum * ettOrdExec.ISANALYZED;//��Ŀ����*��������*ִ��Ƶ��
                            ettOrdPresc.DOSAGE = ettOrd.DOSAGE;
                            ettOrdPresc.BABY_ID = _Babyid;

                            ettOrdPresc.SUBCODE = ettOrd.ITEM_CODE;

                            //ֱ�Ӽ��ˣ�1.���Ƽ���  2.���Ƽ��˼�����jz_flag=1  3.ҽ��Jz_flag 4.ntype<>5
                            ettOrdPresc.CHARGE_BIT = 0;
                            if (ettOrd.DEPT_ID == ettOrd.EXEC_DEPT || (ettOrd.DEPT_ID != ettOrd.EXEC_DEPT && deptJzFlag.Equals("1")) || ettOrd.JZ_FLAG == 1 || ettOrd.NTYPE != 5)
                            {
                                ettOrdPresc.CHARGE_BIT = 1;
                            }

                            ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                            ettOrdPresc.BOOK_USER = EXEUSER;
                            ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdPresc.TYPE = 1;//type=1����ͨ   type=2�����ӷ���
                            ettOrdPresc.JGBM = _JGBM;


                            prescListsInfo.Add(ettOrdPresc, new List<OrderFeeEntity>());
                        }

                        #endregion

                        foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                        //foreach (OrderPrescEntity ettOrdPresc in prescLists)
                        {
                            OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                            List<OrderFeeEntity> FeeLists = new List<OrderFeeEntity>();
                            //������Ӧ����
                            prescLists.Add(ettOrdPresc, FeeLists);

                            if (ettOrdPresc.TYPE != 1)
                            {
                                continue;
                            }

                            #region"ҩƷ���ô���[ҩƷ����������ͬ����������ִ������]"

                            //wait  ����7605�Ŀ���
                            if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0 && EXEDEPT > 0)
                            {
                                #region"ҩƷ��ZY_FEE_SPECI"

                                OrderFeeEntity ettOrdFee = new OrderFeeEntity();
                                ettOrdFee.ID = PubStaticFun.NewGuid();
                                ettOrdFee.INPATIENT_ID = _Binid;
                                ettOrdFee.BABY_ID = _Babyid;

                                ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                                ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                                ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;

                                ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                                ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                                ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;
                                ettOrdFee.STATITEM_CODE = ettOrdPresc.STATITEM_CODE;
                                ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                ettOrdFee.XMLY = ettOrdPresc.XMLY;

                                ettOrdFee.ITEM_NAME = ettOrd.ORDER_CONTEXT;
                                ettOrdFee.SUBCODE = ettOrdPresc.SUBCODE;
                                ettOrdFee.UNIT = ettOrdPresc.UNIT;
                                ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                                ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM;
                                ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM * ettOrdPresc.DOSAGE / ettOrdExec.ISANALYZED;
                                string strMoney = dMoney.ToString("0.00");
                                dMoney = decimal.Parse(strMoney);
                                ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;

                                ettOrdFee.AGIO = ettOrdPresc.AGIO;

                                ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                                ettOrdFee.CHARGE_DATE = null;
                                ettOrdFee.CHARGE_USER = null;
                                if (pvsBit == 1)
                                {
                                    //pvs����
                                    TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                    int iDiff2 = tm2.Days;
                                    if (iDiff2 >= 1)
                                    {
                                        ettOrdFee.CHARGE_BIT = 0;
                                    }
                                }
                                if (ettOrdFee.CHARGE_BIT == 1)
                                {
                                    //pvs����
                                    TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                                    int iDiff2 = tm2.Days;

                                    if (pvsBit == 0 || iDiff2 <= 0)
                                    {
                                        ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                        ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                    }
                                }

                                ettOrdFee.DELETE_BIT = 0;
                                ettOrdFee.CZ_FLAG = 0;
                                ettOrdFee.DISCHARGE_BIT = 0;

                                ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                                ettOrdFee.DEPT_ID = DEPTID;
                                ettOrdFee.DEPT_BR = DEPTBR;
                                ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 ִ�п��һ��Ǹ��洦�����ڴ�����ȷ�����ĸ�ִ�п�����ҩ


                                DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                                if (dtYp == null || dtYp.Rows.Count <= 0)
                                {
                                    throw new Exception(ettOrd.HOITEM_ID + " ҩƷ���ҵ���δ�ҵ���ҩƷ��Ϣ");
                                }
                                ettOrdFee.TLFS = GetTlflInfo(ettOrd, ettOrdPresc, dtYp);

                                ettOrdFee.DEPT_LY = DEPTLY;
                                ettOrdFee.JGBM = _JGBM;
                                ettOrdFee.GG = dtYp.Rows[0]["S_YPGG"].ToString();
                                ettOrdFee.CJ = dtYp.Rows[0]["S_SCCJ"].ToString();

                                ettOrdFee.GCYS = GCYS;
                                ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                                ettOrdFee.FY_BIT = GetFyBit(ettOrdPresc);
                                ettOrdFee.pvs_xh = ettOrdExec.PVS_XH;

                                //FeeListsInfo.Add(ettOrdFee);
                                FeeLists.Add(ettOrdFee);

                                #endregion
                            }

                            #endregion

                            #region"���Ʒ��ü�����ҽ���߼�����[��Ŀ�����������Ѵ�������Ϊ���������ײ�]"

                            if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                            {
                                #region"��Ŀ��ZY_FEE_SPECI"

                                //����ִ�е��շ���Ŀ
                                DataTable dtXm = GetItemInfoToFee(ettOrd, ettOrdPresc);
                                if (dtXm == null || dtXm.Rows.Count <= 0)
                                {
                                    throw new Exception(" δ��ȡ������Ҫִ�е���Ŀ��Ϣ�� ");
                                }

                                string xmSTATITEM_CODE = "";
                                string xmITEM_NAME = "";
                                string xmSTD_CODE = "";
                                string xmITEM_UNIT = "";
                                string xmCOST_PRICE = "";
                                string xmRETAIL_PRICE = "";
                                string xmSUBITEM_ID = "";
                                string xmNUM = "";

                                decimal dSumAcVal = 0;
                                bool bCharged = false;

                                for (int iXm = 0; iXm < dtXm.Rows.Count; iXm++)
                                {
                                    #region"ZY_FEE_SPECI"

                                    OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                                    if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                                    {
                                        //���ײ͵����շ���Ϣ
                                        xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                        xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                        xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                        xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();


                                        ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                        ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                        ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                        ettOrdFee.NUM = ettOrdPresc.NUM;

                                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                        decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM / ettOrdExec.ISANALYZED;
                                        string strMoney = dMoney.ToString("0.00");
                                        dMoney = decimal.Parse(strMoney);
                                        ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                        ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;
                                    }
                                    else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                                    {
                                        //�ײͲ�ֺ����շ���Ϣ
                                        xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                        xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                        xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                        xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();
                                        xmCOST_PRICE = dtXm.Rows[iXm]["COST_PRICE"].ToString();
                                        xmRETAIL_PRICE = dtXm.Rows[iXm]["RETAIL_PRICE"].ToString();
                                        xmSUBITEM_ID = dtXm.Rows[iXm]["SUBITEM_ID"].ToString();
                                        xmNUM = dtXm.Rows[iXm]["NUM"].ToString();

                                        decimal dXmNum = decimal.Parse(xmNUM);
                                        decimal dXmCOST_PRICE = decimal.Parse(xmCOST_PRICE);
                                        decimal dXmRETAIL_PRICE = decimal.Parse(xmRETAIL_PRICE);

                                        ettOrdFee.XMID = long.Parse(xmSUBITEM_ID);
                                        ettOrdFee.COST_PRICE = dXmCOST_PRICE;
                                        ettOrdFee.RETAIL_PRICE = dXmRETAIL_PRICE;
                                        ettOrdFee.NUM = ettOrdPresc.NUM * dXmNum;

                                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                        ettOrdFee.SDVALUE = dXmCOST_PRICE * ettOrdPresc.NUM * dXmNum;
                                        ettOrdFee.ACVALUE = dXmRETAIL_PRICE * ettOrdPresc.NUM * dXmNum;
                                    }

                                    ettOrdFee.ID = PubStaticFun.NewGuid();
                                    ettOrdFee.INPATIENT_ID = _Binid;
                                    ettOrdFee.BABY_ID = _Babyid;
                                    ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                                    ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                                    ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;
                                    ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                                    ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                                    ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                                    ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;

                                    ettOrdFee.STATITEM_CODE = xmSTATITEM_CODE;
                                    ettOrdFee.XMLY = ettOrdPresc.XMLY;
                                    ettOrdFee.TCID = ettOrdPresc.TCID;
                                    ettOrdFee.TC_FLAG = ettOrdPresc.TC_FLAG;

                                    ettOrdFee.ITEM_NAME = xmITEM_NAME;
                                    ettOrdFee.SUBCODE = xmSTD_CODE;
                                    ettOrdFee.UNIT = xmITEM_UNIT;
                                    ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                                    ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;


                                    ettOrdFee.AGIO = ettOrdPresc.AGIO;

                                    bool bYjqr = false;
                                    ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                                    ettOrdFee.CHARGE_DATE = null;
                                    ettOrdFee.CHARGE_USER = null;
                                    if (ettOrdFee.CHARGE_BIT == 1)
                                    {
                                        ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                        ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                        bYjqr = true;

                                        bCharged = true;
                                    }

                                    ettOrdFee.DELETE_BIT = 0;
                                    ettOrdFee.CZ_FLAG = 0;
                                    ettOrdFee.DISCHARGE_BIT = 0;

                                    ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                                    ettOrdFee.DEPT_ID = DEPTID;
                                    ettOrdFee.DEPT_BR = DEPTBR;
                                    ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 ִ�п��һ��Ǹ��洦�����ڴ�����ȷ�����ĸ�ִ�п�����ҩ

                                    ettOrdFee.DEPT_LY = DEPTLY;
                                    ettOrdFee.JGBM = _JGBM;

                                    ettOrdFee.GCYS = GCYS;
                                    ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                                    FeeLists.Add(ettOrdFee);

                                    #endregion

                                    dSumAcVal += ettOrdFee.ACVALUE;
                                }

                                //ҽ������ͬ���������ײͲ���Ҫ������ɼ�¼��
                                if (NTYPE == 5)
                                {
                                    #region"ҽ������"

                                    //ҽ������
                                    YjZySqEntity yjsq = new YjZySqEntity();

                                    yjsq.YJSQID = PubStaticFun.NewGuid();
                                    yjsq.JGBM = _JGBM;
                                    yjsq.BRXXID = _BRXXID;
                                    yjsq.INPATIENT_ID = ettOrdExec.INPATIENT_ID;
                                    yjsq.SQRQ = ettOrdPresc.PRESC_DATE;
                                    yjsq.SQR = ettOrd.ORDER_DOC;
                                    yjsq.SQKS = ettOrd.DEPT_ID;

                                    yjsq.SQNR = ettOrd.ORDER_CONTEXT;
                                    if (ettOrd.UNIT.ToUpper().Equals("U") || ettOrd.UNIT.ToUpper().Equals("ML"))
                                    {
                                        string charInfo = Get_ZY_CHGDECIMALTOCHAR(ettOrd.NUM);
                                        yjsq.SQNR = ettOrd.ORDER_CONTEXT.Trim() + " " + charInfo + " " + ettOrd.UNIT;
                                    }

                                    yjsq.JE = dSumAcVal;
                                    yjsq.LCZD = Convertor.IsNull(ettOrd.MEMO1, "");
                                    yjsq.ZXKS = ettOrd.EXEC_DEPT;
                                    yjsq.BSJC = "";
                                    yjsq.BBMC = GetSampName(ettOrd.DWLX);
                                    yjsq.ZYSX = "";
                                    yjsq.BJJBZ = 0;
                                    yjsq.YZID = ettOrd.ORDER_ID;
                                    yjsq.YZXMID = ettOrd.HOITEM_ID;
                                    yjsq.ZXR = EXEUSER;
                                    yjsq.ZXSJ = DateManager.ServerDateTimeByDBType(_database);
                                    yjsq.ZXID = ettOrdExec.ID;
                                    yjsq.DJLX = GetDjly(ettOrd.HOITEM_ID);

                                    yjsqLists.Add(yjsq);

                                    #endregion

                                    #region"ҽ��ȷ��"

                                    if (bCharged)
                                    {
                                        YjZySqEntity yjqr = new YjZySqEntity();

                                        yjqr.YJSQID = yjsq.YJSQID;
                                        yjqr.ZXID = ettOrdExec.ID;
                                        yjqr.YZID = ettOrd.ORDER_ID;
                                        yjqr.JE = dSumAcVal;

                                        yjqrLists.Add(yjqr);
                                        //Guid YJ_EXEC_ID = ettOrdExec.ID;
                                        //Guid YJ_APP_ID = yjsq.YJSQID;
                                        //Guid YJ_ORDER_ID = ettOrd.ORDER_ID;
                                        //decimal YJ_JE = yjsq.JE;

                                        //Guid NEWYJSQID = Guid.Empty;
                                        //int iSqRet = -1;
                                        //string strSqMsg = "";
                                        //yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, DEPTID, EXECBOOKDATE, EXEUSER, 1, EXECBOOKDATE, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                                        //if (iSqRet != 0)
                                        //{
                                        //    iOutPut = 1;//return
                                        //    iret = -1;
                                        //    strMsg = BED_NO + " ������ " + PAT_NAME + " ҽ��ȷ�ѳ���:" + strSqMsg;
                                        //    return iOutPut;
                                        //}
                                    }

                                    #endregion
                                }

                                #endregion
                            }

                            #endregion

                            ////������Ӧ����
                            //prescLists.Add(ettOrdPresc, FeeLists);
                        }

                        //ִ�ж�Ӧ����
                        //execLists.Add(ettOrdExec, prescLists);

                        #region"ҽ�����ӷ��� wait"
                        #endregion
                    }

                    //orderLists.Add(ettOrd, execLists);
                }

                #endregion

                return iOutPut;
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ��ţ�" + _Groupid + " ҽ�����ڣ�" + execNow.ToString("yyyy-MM-dd") + " DoExcuteAddFeeʱerr��" + ex.Message);
            }
        }

        /// <summary>
        /// NextDay���ݴ�ҩ7191  ��������6035��   ҽ���Զ�����  wait ��
        /// </summary>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public int DoExcuteNextDay(DateTime execNow, List<OrderEntity> updateOrderInfo,
            List<OrderFeeEntity> czFeeLists, List<XnKclEntity> xnKcLists, List<YjZySqEntity> upDatetYjsqLists,
            List<string> updateFeeFlagLists, List<OrderFeeEntity> delFeeLists,
            out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;
            try
            {
                if (MNGTYPE == 1 || MNGTYPE == 3 || MNGTYPE == 5)
                {
                    #region"ͣ��ʱ��ҽ��"

                    //��ʱ�Ƿ������ִ�м�¼��ҽ��״̬Ϊ2�ļ�¼
                    //ֱ�����ݿ⡾���Ĳ�������ʹ���ڴ��¼��
                    int iStatus = GetTmpOrder();
                    if (iStatus == 1)//��Ҫͣ��ʱ
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        ettOrd.STATUS_FLAG = 5;
                        ettOrd.ORDER_EDATE = EXECBOOKDATE;

                        updateOrderInfo.Add(ettOrd);//���������б�

                        //���»����¼
                        foreach (OrderEntity thisOrd in _orderList)
                        {
                            thisOrd.STATUS_FLAG = 5;
                            thisOrd.ORDER_EDATE = EXECBOOKDATE;
                        }
                    }

                    #endregion
                }
                else
                {
                    //���������߼�������ʱ�ο�����cycles��
                    if (ZHBJ == 1)
                    {
                        //��ʱ���������洦��  wait
                        iret = 0;
                        strMsg = "";
                        iOutPut = 0;
                        return iOutPut;
                    }

                    DateTime now = DateManager.ServerDateTimeByDBType(_database);

                    //��ͣ���ڣ����ҵ�ǰִ��ʱ��>=ͣʱ�䣺�Զ������߼�
                    if (STOPEXEDATE.HasValue && execNow.Date >= STOPEXEDATE.Value.Date)
                    {
                        string isCz = _cfgList.cfg7055.Config.Trim();
                        if (STATUS_FLAG == 4 && isCz.Equals("1"))
                        {
                            int iCzCharge = GetCzChargeBit();

                            string cfg7142 = _cfgList.cfg7142.Config.ToString().Trim();
                            foreach (OrderEntity ettOrd in _orderList)
                            {
                                if (cfg7142.Equals("0") && ettOrd.NTYPE == 5)
                                {
                                    //ҽ��wait����
                                    //��������ҽ����Ŀ������
                                    continue;
                                }

                                DateTime? maxPresDate = GetMaxPrescDate(ettOrd.ORDER_ID);
                                if (!maxPresDate.HasValue)
                                {
                                    continue;//û��ִ�м�¼�����������ntype=0��7 ���� δִ��ֱ��ͣ�����շ�ҽ����
                                }

                                DateTime MAXEXECDATE = maxPresDate.Value;
                                TimeSpan tp = MAXEXECDATE.Date.Subtract(STOPEXEDATE.Value.Date);
                                int iDiff = tp.Days;
                                while (MAXEXECDATE.Date >= STOPEXEDATE.Value.Date)
                                {
                                    DataTable dtCz = GetCzFeeInfo(ettOrd.ORDER_ID, MAXEXECDATE.Date.ToString("yyyy-MM-dd"));

                                    if (dtCz != null && dtCz.Rows.Count > 0)
                                    {
                                        int iDayOrderCz = 0;//�����ڳ�����¼������ʱ�ύ�����ֳ���ʱ����Ҫ��¼����ҽ���������������������ո�ҽ�����������

                                        for (int iCz = 0; iCz < dtCz.Rows.Count; iCz++)
                                        {
                                            DataRow drFee = dtCz.Rows[iCz];//������ó������ײͣ�

                                            string kfTlfl = _cfgList.cfg7048.Config.Trim();
                                            string isClYpCz = _cfgList.cfg7054.Config.Trim();
                                            //����ǿڷ�ҩ�����Ҳ��㣬���Ҳ������˲���ڷ�ҩ������ȥִ����һ��
                                            //����ڷ�ҩ�ж�ԭ����@CFG_ISCLYPCZ=0�����ڸ�Ϊ������1�����ڲ�����������סԺ��������������� Modify By Tany 2015-06-04

                                            bool bKfTlFl = string.IsNullOrEmpty(kfTlfl);
                                            bool bClYpCz = isClYpCz.Equals("1");
                                            int iUnitRate = int.Parse(Convertor.IsNull(drFee["UNITRATE"], "0"));
                                            bool bKf = kfTlfl.Contains(drFee["TLFL"].ToString());

                                            if ((!bKfTlFl) && (!bClYpCz) && iUnitRate > 1 && bKf)
                                            {
                                                //����ڷ�ҩ���Զ�����
                                                continue;
                                            }

                                            string cfg7603 = _cfgList.cfg7603.Config.Trim();
                                            string pvsScan = Convertor.IsNull(drFee["is_PvsScn"], "0");
                                            if (cfg7603.Equals("0") && pvsScan.Equals("1"))
                                            {
                                                //�����pivas�Ѿ�����ɨ�貢��7603��pivas��ɨ��ҩƷ�Ƿ������� 0�� 1�ǣ�Ϊ0������ȥִ����һ��
                                                continue;
                                            }

                                            Guid feeid = new Guid(drFee["id"].ToString());
                                            DataTable dtCzNum = GetCzNum(feeid);
                                            if (dtCzNum != null && dtCzNum.Rows.Count > 0)
                                            {

                                                string strCzzNum = Convertor.IsNull(dtCzNum.Rows[0]["CZZNUM"], "0").Trim();
                                                string strCzzMoney = Convertor.IsNull(dtCzNum.Rows[0]["CZZJE"], "0").Trim();
                                                decimal dCzzNum = Convert.ToDecimal(strCzzNum);//�ɳ���
                                                int iCzNum = (int)dCzzNum;//�ɳ�����
                                                decimal dCzMoney = Convert.ToDecimal(strCzzMoney);//�ɳ���

                                                string disChargeBit = drFee["DISCHARGE_BIT"].ToString().Trim();

                                                if (iCzNum > 0 && disChargeBit.Equals("0"))
                                                {
                                                    int iNeedCzNum = iCzNum;//��Ч��

                                                    //�пɳ�������
                                                    int iCzAll = 1;//0���ֳ���   1ȫ��
                                                    if (MAXEXECDATE.Date > STOPEXEDATE.Value.Date)
                                                    {
                                                        iCzAll = 1;

                                                        //ȫ������
                                                        DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                            drFee, iNeedCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);
                                                    }
                                                    else
                                                    {
                                                        if (!TERMINALTIMES.HasValue)
                                                            throw new Exception("TERMINALTIMESΪnull�������Գ���");

                                                        if (TERMINALTIMES.Value == 0)
                                                        {
                                                            iCzAll = 1;

                                                            //ȫ������
                                                            DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                drFee, iNeedCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);
                                                        }
                                                        else
                                                        {
                                                            //���ֳ���
                                                            //2017-09-22 ͨ��order_id��xmid��xmly ȷ������Чҽ������
                                                            string thisXmid = drFee["cjid"].ToString().Trim();//��xmid
                                                            string thisXmly = drFee["xmly"].ToString().Trim();
                                                            DataTable dtCzNumOrder = GetCzNumByOrder(ettOrd.ORDER_ID, thisXmid, thisXmly, MAXEXECDATE.Date.ToString("yyyy-MM-dd"));
                                                            //��ҽ����ִ�в��ֲ���Ҫ�Զ�����
                                                            if (dtCzNumOrder != null && dtCzNumOrder.Rows.Count > 0)
                                                            {
                                                                //string strCzzNumOrd = Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0").Trim();
                                                                //decimal dCzzNumOrd = Convert.ToDecimal(strCzzNum);//�ɳ�����
                                                                //int iOrderNum = (int)dCzzNumOrd;//ҽ���Ŀɳ�����//ҽ������Ч����
                                                                string strCzzNumOrd = Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0").Trim();
                                                                decimal dCzzNumOrd = Convert.ToDecimal(strCzzNumOrd);//�ɳ�����
                                                                int iOrderNum = (int)dCzzNumOrd;//ҽ���Ŀɳ�����//ҽ������Ч����

                                                                //int iOrderNum = int.Parse(Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZNUM"], "0"));//ҽ���Ŀɳ�����
                                                                //2017-09-22
                                                                decimal dOrderMoney = decimal.Parse(Convertor.IsNull(dtCzNumOrder.Rows[0]["CZZJE"], "0"));//ҽ���Ŀɳ���

                                                                Guid execId = new Guid(drFee["ORDEREXEC_ID"].ToString());
                                                                OrderExecEntity ettOrdExec = GetISANALYZED(execId, _orderExecList);

                                                                int zxcs = ettOrdExec.ISANALYZED;
                                                                decimal FeeNum = decimal.Parse(drFee["Num"].ToString());
                                                                iNeedCzNum = iCzNum;//�÷�����Ч����
                                                                decimal terNums = TERMINALTIMES.Value * FeeNum / zxcs;//ĩ������
                                                                //ȡ��terNums
                                                                int iTerNums = Convert.ToInt32(terNums);
                                                                int iFeeNums = Convert.ToInt32(FeeNum);

                                                                iDayOrderCz = GetCzFeeNumByCzList(czFeeLists, ettOrd.ORDER_ID, drFee);

                                                                int iWaitCzNum = iOrderNum - iDayOrderCz - iTerNums;//ҽ������Ч����-��������������-ĩ������=��Ҫ��������
                                                                if (iWaitCzNum <= 0)
                                                                {
                                                                    //��Ҫ��������С��0
                                                                    continue;
                                                                }

                                                                //������Ч����>��Ҫ��������
                                                                if (iNeedCzNum > iWaitCzNum)
                                                                {
                                                                    iCzAll = 0;

                                                                    //������
                                                                    int realCzNum = iWaitCzNum;
                                                                    decimal realCzMoney = (dCzMoney / iNeedCzNum) * realCzNum;
                                                                    DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                        drFee, realCzNum, realCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);

                                                                    //iDayOrderCz += realCzNum;
                                                                    //iDayXmid = thisXmid;
                                                                    //iDayXmly = thisXmly;
                                                                }
                                                                else
                                                                {
                                                                    iCzAll = 1;

                                                                    //��������(ȫ��)
                                                                    int realCzNum = iNeedCzNum;
                                                                    DoExexCzFee(execNow, czFeeLists, xnKcLists, upDatetYjsqLists, updateFeeFlagLists, delFeeLists,
                                                                        drFee, realCzNum, dCzMoney, iCzCharge, iCzAll, out  iret, out  strMsg);

                                                                    //iDayOrderCz += realCzNum;
                                                                    //iDayXmid = thisXmid;
                                                                    //iDayXmly = thisXmly;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }


                                    MAXEXECDATE = MAXEXECDATE.AddDays(-1);
                                }
                            }
                        }

                        #region"������ҽ�����"

                        OrderEntity ettOrdFinish = new OrderEntity();
                        ettOrdFinish.STATUS_FLAG = 5;
                        ettOrdFinish.LASTEXECDATE = now;

                        updateOrderInfo.Add(ettOrdFinish);//���������б�

                        //���»����¼
                        foreach (OrderEntity thisOrd in _orderList)
                        {
                            thisOrd.STATUS_FLAG = 5;
                            thisOrd.LASTEXECDATE = now;
                        }

                        #endregion
                    }
                    else
                    {
                        #region"ͣNtype=0�ĳ�����ҽ��"

                        //IF (LTRIM(RTRIM(@FREQUENCY))='1') AND (CONVERT(DATETIME,DBO.FUN_GETDATE(@CUREXECDATE)) >= CONVERT(DATETIME,DBO.FUN_GETDATE(@BEGINEXEDATE)))
                        //��ǰִ�����ڴ��ڵ��ڿ�������
                        if (FREQUENCY.Equals("1") && execNow.Date >= BEGINEXEDATE.Date)
                        {
                            //ֻ������Ntype=0��ҽ�� ͣ
                            if ((MNGTYPE == 0 || MNGTYPE == 2) && NTYPE == 0)
                            {
                                OrderEntity ettOrd = new OrderEntity();
                                ettOrd.STATUS_FLAG = 5;
                                ettOrd.ORDER_EDATE = EXECBOOKDATE;
                                ettOrd.ORDER_EDOC = _orderList[0].ORDER_DOC;
                                ettOrd.LASTEXECDATE = now;


                                OrderEntity order = _orderList[0];//ִ�п��ҴӴ�С�����������к����Ա�ҩ��
                                if (_orderList[0].ORDER_CONTEXT.Contains("ת"))
                                {
                                    ettOrd.ORDER_EDATE = null;
                                    ettOrd.ORDER_EDOC = null;
                                }

                                updateOrderInfo.Add(ettOrd);//���������б�

                                //���»����¼
                                foreach (OrderEntity thisOrd in _orderList)
                                {
                                    thisOrd.STATUS_FLAG = 5;
                                    thisOrd.ORDER_EDATE = EXECBOOKDATE;
                                    thisOrd.ORDER_EDOC = _orderList[0].ORDER_DOC;
                                    thisOrd.LASTEXECDATE = now;
                                    if (thisOrd.ORDER_CONTEXT.Contains("ת"))
                                    {
                                        thisOrd.ORDER_EDATE = null;
                                        thisOrd.ORDER_EDOC = null;
                                    }
                                }
                            }
                        }

                        #endregion
                    }
                }

                iOutPut = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ��ţ�" + _Groupid + "  ҽ�����ڣ�" + execNow.ToString("yyyy-MM-dd") + " ִ��NextDayʱerr��" + ex.Message);
            }
            return iOutPut;
        }

        public int GetCzFeeNumByCzList(List<OrderFeeEntity> czFeeLists, Guid orderid, DataRow drFee)
        {
            decimal dNowCzNum = 0;

            long xmid = long.Parse(drFee["XMID"].ToString());
            int xmly = int.Parse(drFee["XMLY"].ToString());
            string presDate = DateTime.Parse(drFee["PRESC_DATE"].ToString()).ToString("yyyy-MM-dd");

            foreach (OrderFeeEntity ettOrdFee in czFeeLists)
            {
                string ettPreDate = ettOrdFee.PRESC_DATE.ToString("yyyy-MM-dd");

                if (ettOrdFee.ORDER_ID == orderid && ettOrdFee.XMID == xmid && ettOrdFee.XMLY == xmly && ettPreDate.Equals(presDate))
                {
                    dNowCzNum += Math.Abs(ettOrdFee.NUM);
                }
            }

            int iNowCzNum = (int)dNowCzNum;

            return iNowCzNum;
        }

        /// <summary>
        /// ������װ
        /// </summary>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public int DoExexCzFee(DateTime execNow, List<OrderFeeEntity> czFeeLists,
            List<XnKclEntity> xnKcLists, List<YjZySqEntity> upDatetYjsqLists,
            List<string> updateFeeFlagLists, List<OrderFeeEntity> delFeeLists,
            DataRow drFee, int iNeedCzNum, decimal dCzMoney, int iCzCharge, int iCzAll, out int iret, out string strMsg)
        {
            iret = 0;
            strMsg = "";
            int iOutPut = -1;
            try
            {
                DateTime now = DateManager.ServerDateTimeByDBType(_database);
                Guid feeid = new Guid(drFee["id"].ToString());

                #region"����iCzAll= 1��ȫ  0������ "

                #region"CzFee"

                //ȫ��
                OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                ettOrdFee.ID = PubStaticFun.NewGuid();
                ettOrdFee.ORDER_ID = new Guid(drFee["ORDER_ID"].ToString());
                ettOrdFee.PRESCRIPTION_ID = new Guid(drFee["PRESCRIPTION_ID"].ToString());
                ettOrdFee.ORDEREXEC_ID = new Guid(drFee["ORDEREXEC_ID"].ToString());
                ettOrdFee.PRESC_DATE = DateTime.Parse(drFee["PRESC_DATE"].ToString());
                ettOrdFee.BOOK_DATE = now;
                ettOrdFee.BOOK_USER = EXEUSER;
                ettOrdFee.PRESC_NO = drFee["PRESC_NO"].ToString();

                ettOrdFee.STATITEM_CODE = Convertor.IsNull(drFee["STATITEM_CODE"], "00");
                ettOrdFee.XMID = long.Parse(drFee["XMID"].ToString());
                ettOrdFee.TCID = long.Parse(drFee["TCID"].ToString());
                ettOrdFee.TC_FLAG = int.Parse(drFee["TC_FLAG"].ToString());
                ettOrdFee.INPATIENT_ID = new Guid(drFee["INPATIENT_ID"].ToString());

                ettOrdFee.BABY_ID = long.Parse(drFee["BABY_ID"].ToString());
                ettOrdFee.ITEM_NAME = drFee["ITEM_NAME"].ToString();
                ettOrdFee.SUBCODE = drFee["SUBCODE"].ToString();
                ettOrdFee.XMLY = int.Parse(drFee["XMLY"].ToString());
                ettOrdFee.UNIT = drFee["UNIT"].ToString();

                ettOrdFee.UNITRATE = int.Parse(drFee["UNITRATE"].ToString());
                ettOrdFee.DOSAGE = int.Parse(drFee["DOSAGE"].ToString());
                ettOrdFee.COST_PRICE = decimal.Parse(drFee["COST_PRICE"].ToString());
                ettOrdFee.RETAIL_PRICE = decimal.Parse(drFee["RETAIL_PRICE"].ToString());
                ettOrdFee.AGIO = (int)Convert.ToDecimal(drFee["AGIO"].ToString());
                ettOrdFee.EXECDEPT_ID = long.Parse(drFee["EXECDEPT_ID"].ToString());

                ettOrdFee.DEPT_ID = long.Parse(drFee["DEPT_ID"].ToString());
                ettOrdFee.DEPT_BR = long.Parse(drFee["DEPT_BR"].ToString());
                ettOrdFee.DEPT_LY = long.Parse(drFee["DEPT_LY"].ToString());
                ettOrdFee.DOC_ID = long.Parse(drFee["DOC_ID"].ToString());

                ettOrdFee.CZ_FLAG = 2;
                ettOrdFee.CZ_ID = new Guid(drFee["ID"].ToString());
                ettOrdFee.DELETE_BIT = 0;
                ettOrdFee.DISCHARGE_BIT = 0;
                ettOrdFee.NUM = -1 * iNeedCzNum;
                ettOrdFee.SDVALUE = -1 * dCzMoney;
                ettOrdFee.ACVALUE = -1 * dCzMoney;
                ettOrdFee.TYPE = int.Parse(drFee["TYPE"].ToString());
                ettOrdFee.TLFS = int.Parse(drFee["TLFS"].ToString());

                ettOrdFee.CHARGE_BIT = 0;
                ettOrdFee.CHARGE_USER = null;
                ettOrdFee.CHARGE_DATE = null;
                if (isDsyYf(ettOrdFee.EXECDEPT_ID) || iCzCharge == 1 || (XMLY == 2 && iCzCharge != 2))
                {
                    ettOrdFee.CHARGE_BIT = 1;
                    ettOrdFee.CHARGE_USER = EXEUSER;
                    ettOrdFee.CHARGE_DATE = now;
                }

                ettOrdFee.BZ = "��ϵͳ�Զ�������";
                ettOrdFee.JGBM = _JGBM;
                ettOrdFee.GG = drFee["GG"].ToString();
                ettOrdFee.CJ = drFee["CJ"].ToString();
                ettOrdFee.GCYS = long.Parse(drFee["GCYS"].ToString());

                ettOrdFee.FY_BIT = 0;//wait
                if (isDsyYf(ettOrdFee.EXECDEPT_ID))
                {
                    ettOrdFee.FY_BIT = 5;
                }

                ettOrdFee.pvs_xh = int.Parse(drFee["pvs_xh"].ToString());
                ettOrdFee.ZFBL = drFee["ZFBL"].ToString();

                czFeeLists.Add(ettOrdFee);

                #endregion

                if (NTYPE == 5 && XMLY == 2)
                {
                    YjZySqEntity yjsq = new YjZySqEntity();
                    yjsq.BTFBZ = 1;
                    yjsq.TFJE = 1 * dCzMoney;
                    yjsq.YZID = ettOrdFee.ORDER_ID;
                    yjsq.ZXID = ettOrdFee.ORDEREXEC_ID;
                    upDatetYjsqLists.Add(yjsq);
                }

                string cfg6035 = _cfgList.cfg6035.Config.Trim();
                if (cfg6035.Equals("1") && XMLY == 1)
                {
                    //��������������
                    XnKclEntity xn = new XnKclEntity();
                    xn.cjid = drFee["cjid"].ToString();
                    xn.num = iNeedCzNum.ToString();
                    xn.dwbl = drFee["UNITRATE"].ToString();
                    xn.execDeptId = drFee["EXECDEPT_ID"].ToString();
                    //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//ʧ�ܲ�����
                    xnKcLists.Add(xn);
                }

                updateFeeFlagLists.Add(feeid.ToString());//cz_flag=1

                //�����Զ�ɾ��
                string cfg7026 = _cfgList.cfg7026.Config.Trim();
                if (cfg7026.Equals("��"))
                {
                    string fyBit = Convertor.IsNull(drFee["FY_BIT"], "0");
                    string scbz = Convertor.IsNull(drFee["scbz"], "0");
                    string CHARGE_BIT = Convertor.IsNull(drFee["CHARGE_BIT"], "0");
                    string DISCHARGE_BIT = Convertor.IsNull(drFee["DISCHARGE_BIT"], "0");

                    if (fyBit.Equals("0") && scbz.Equals("0") && CHARGE_BIT.Equals("0") && DISCHARGE_BIT.Equals("0"))
                    {
                        //δ�ϴ���δ��ҩ��δ���� ��δҽ������
                        //wait 
                        //IF NOT EXISTS(SELECT 1 FROM ZY_FEE_SPECI WHERE  ((@zcy_zdsc=1 and TLFS=9) or (@zcy_zdsc=0  ))   and (FY_BIT=1 OR SCBZ=1) AND DELETE_BIT=0 AND (CZ_ID=@O2_ID ))
                        //�ݴ�ҩ�Զ�����ɾ��������7191����
                        //У����������
                        if (iCzAll == 1)
                        {
                            //ȫ������ɾ����������
                            OrderFeeEntity delFee = new OrderFeeEntity();
                            delFee.ID = feeid;
                            delFee.DELETE_BIT = 1;

                            delFeeLists.Add(delFee);
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(BED_NO + " ������ " + PAT_NAME + " ��ţ�" + _Groupid + " ҽ�����ڣ�" + execNow.ToString("yyyy-MM-dd") + " ִ��NextDayʱerr��" + ex.Message);
            }
            return iOutPut;
        }

        /// <summary>
        /// ҽ��ִ��������ֳ�list(ʵ��)
        /// </summary>
        public void GetExecEntity(
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo,
            out List<OrderExecEntity> ordExeLists, out List<OrderPrescEntity> ordPrescLists, out List<OrderFeeEntity> ordFeeLists
            )
        {
            ordExeLists = new List<OrderExecEntity>();
            ordPrescLists = new List<OrderPrescEntity>();
            ordFeeLists = new List<OrderFeeEntity>();



            #region"���봦�������ñ�etc"

            foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
            {
                OrderEntity ettOrd = kvOrdList.Key;

                Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                {
                    OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();

                    foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                    {
                        OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                        List<OrderFeeEntity> FeeLists = kvOrdPresLists.Value;
                        ordFeeLists.AddRange(FeeLists);//����

                        ordPrescLists.Add(ettOrdPresc);//����
                    }

                    ordExeLists.Add(ettOrdExec);//ִ�м�¼
                }
            }

            #endregion
        }

        /// <summary>
        /// ҽ��ִ��������ֳ�list(ʵ��)��У��汾��
        /// </summary>
        public void GetExecEntity(DateTime execNow,
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo,
            out List<OrderExecEntity> ordExeLists, out List<OrderPrescEntity> ordPrescLists, out List<OrderFeeEntity> ordFeeLists
            )
        {
            ordExeLists = new List<OrderExecEntity>();
            ordPrescLists = new List<OrderPrescEntity>();
            ordFeeLists = new List<OrderFeeEntity>();

            int iNowExecNum = 0;

            #region"���봦�������ñ�etc"

            foreach (KeyValuePair<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> kvOrdList in orderInfo)
            {
                OrderEntity ettOrd = kvOrdList.Key;

                Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> execListsInfo = kvOrdList.Value;

                foreach (KeyValuePair<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>> kvOrdExecList in execListsInfo)
                {
                    OrderExecEntity ettOrdExec = kvOrdExecList.Key;
                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescListsInfo = kvOrdExecList.Value;

                    Dictionary<OrderPrescEntity, List<OrderFeeEntity>> prescLists = new Dictionary<OrderPrescEntity, List<OrderFeeEntity>>();

                    foreach (KeyValuePair<OrderPrescEntity, List<OrderFeeEntity>> kvOrdPresLists in prescListsInfo)
                    {
                        OrderPrescEntity ettOrdPresc = kvOrdPresLists.Key;

                        List<OrderFeeEntity> FeeLists = kvOrdPresLists.Value;
                        ordFeeLists.AddRange(FeeLists);//����

                        ordPrescLists.Add(ettOrdPresc);//����
                    }

                    if (ettOrd.ORDER_ID == ORDERID)
                    {
                        iNowExecNum += ettOrdExec.ISANALYZED;
                    }
                    ordExeLists.Add(ettOrdExec);//ִ�м�¼
                }
            }

            #endregion

            #region"����У��"

            //��ҽ�������з��ü�¼��ֻУ���з��õ�ҽ����
            if (ordFeeLists.Count > 0)
            {
                ////ִ������֮ǰУ�飺����ִ�д���+��ǰִ�д���<=Ƶ�δ�������ֹ˫�����ݣ�
                string strSql = string.Format(@"select SUM(ISANALYZED) as Num from  ZY_ORDEREXEC where  ORDER_ID='{0}' and  CONVERT(DATETIME,DBO.FUN_GETDATE(EXECDATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))", ORDERID.ToString(), execNow);

                int iEverNum = int.Parse(Convertor.IsNull(_database.GetDataResult(strSql), "0"));

                int iTodayNum = iNowExecNum + iEverNum;

                if (iTodayNum > EXECNUM)
                {
                    //����ִ�д��� ���� Ƶ��
                    ordExeLists = new List<OrderExecEntity>();
                    ordPrescLists = new List<OrderPrescEntity>();
                    ordFeeLists = new List<OrderFeeEntity>();
                }
            }

            #endregion
        }

        private DataTable GetYpInfo(long cjid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT LTRIM(RTRIM(ISNULL(TLFL,'00'))) TLFL,STATITEM_CODE,S_YPGG,S_SCCJ,DJYP,MZYP,JSYP,GZYP,RSYP FROM VI_YP_YPCD A WHERE A.CJID={0}", cjid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ������Ŀ��Ϣ[��ã��ײͻ���]
        /// </summary>
        /// <param name="Hoitemid"></param>
        /// <param name="OrdExecDeptid"></param>
        /// <param name="OrdJgbm"></param>
        /// <param name="ExecDeptJgbm"></param>
        /// <returns></returns>
        private DataTable GetItemInfo(long Hoitemid, long OrdExecDeptid, long OrdJgbm, long ExecDeptJgbm)
        {
            try
            {
                string ssql = "";
                //                ssql = string.Format(@"select R.HDITEM_ID,H.BIGITEMCODE,R.TCID,R.TC_FLAG,H.UNIT,H.PRICE,R.NUM from JC_HOI_HDI R 
                //                                        INNER JOIN
                //                                        VI_JC_ITEMS H
                //                                        ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID 
                //                                        AND CASE WHEN A.EXEC_DEPT<=0 THEN A.JGBM ELSE DBO.FUN_GETDEPTJGBM(A.EXEC_DEPT) END=H.JGBM
                //                                        where R.HOITEM_ID={0}", cjid);

                long thisJgbm = OrdJgbm;
                if (OrdExecDeptid <= 0)
                {
                    thisJgbm = OrdJgbm;
                }
                else
                {
                    thisJgbm = ExecDeptJgbm;
                }

                ssql = string.Format(@"select R.HDITEM_ID,H.BIGITEMCODE,R.TCID,R.TC_FLAG,H.UNIT,H.PRICE,R.NUM from JC_HOI_HDI R 
                                        INNER JOIN
                                        VI_JC_ITEMS H
                                        ON H.ITEMID=R.HDITEM_ID AND H.TCID=R.TCID 
                                        AND H.JGBM={1}
                                        where R.HOITEM_ID={0}", Hoitemid, thisJgbm);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetDeptJzInfo(long OrdExecDeptid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT * FROM JC_DEPT_PROPERTY A WHERE A.DEPT_ID={0}", OrdExecDeptid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetYpkcmxInfo(int dwlx, decimal num, int cjid, int execdept)
        {
            try
            {
                string sSql = "EXEC SP_FUN_DW_NUM " + dwlx + "," + num + ",1,1,1," + cjid + "," + execdept + ",0";
                DataTable myTb = _database.GetDataTable(sSql);

                return myTb;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ������Ŀ��Ϣ���ײͲ�֣�
        /// </summary>
        /// <param name="Hoitemid"></param>
        /// <param name="OrdExecDeptid"></param>
        /// <param name="OrdJgbm"></param>
        /// <param name="ExecDeptJgbm"></param>
        /// <returns></returns>
        private DataTable GetItemInfoToFee(OrderEntity ettOrd, OrderPrescEntity ettOrdPresc)
        {
            try
            {
                string ssql = "";

                if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                {

                    ssql = string.Format(@"select R.STATITEM_CODE,R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT from JC_HSITEMDICTION R
                                        where R.ITEM_ID={0} and R.JGBM={1}", ettOrdPresc.HDITEM_ID, ettOrdPresc.JGBM);
                }
                else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                {
                    long thisJgbm = ettOrd.JGBM;
                    if (ettOrd.EXEC_DEPT <= 0)
                    {
                        thisJgbm = ettOrd.JGBM;
                    }
                    else
                    {
                        DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                        if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                        {
                            throw new Exception("δ�ҵ���" + ettOrd.EXEC_DEPT + " ��ִ�п��Ҷ�Ӧ�Ŀ�����Ϣ");
                        }

                        string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                        long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());
                        thisJgbm = ExecDeptJgbm;
                    }

                    ssql = string.Format(@"select R.STATITEM_CODE,R.ITEM_NAME,R.STD_CODE,R.ITEM_UNIT,R.COST_PRICE,R.RETAIL_PRICE,T.SUBITEM_ID,T.NUM
                                        from JC_TC_MX T
                                        INNER JOIN JC_HSITEMDICTION R ON T.SUBITEM_ID=R.ITEM_ID AND R.JGBM={1}
                                        where T.MAINITEM_ID={0} ", ettOrdPresc.TCID, thisJgbm);
                }
                else
                {
                    throw new Exception("TC_FLAG:" + ettOrdPresc.TC_FLAG + " TCID:" + ettOrdPresc.TCID + " ���ײ��ҷǵ����շ���Ŀ,����ʧ��,����ϵ����Ա���ZY_PRESCRIPTION��¼��");
                }

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateXnKc(string cjid, string num, string dwbl, string execDeptId)
        {
            try
            {
                ParameterEx[] parameters = new ParameterEx[6];
                parameters[0].Text = "@cjid";
                parameters[0].Value = Convert.ToInt32(cjid);
                parameters[1].Text = "@ypsl";
                parameters[1].Value = Convert.ToInt32(num);
                parameters[2].Text = "@ydwbl";
                parameters[2].Value = Convert.ToInt32(dwbl);
                parameters[3].Text = "@deptid ";
                parameters[3].Value = Convert.ToInt32(execDeptId);
                parameters[4].Text = "@err_code";
                parameters[4].ParaSize = 100;
                parameters[4].ParaDirection = ParameterDirection.Output;
                parameters[5].Text = "@Err_Text";
                parameters[5].ParaSize = 100;
                parameters[5].ParaDirection = ParameterDirection.Output;
                _database.DoCommand("sp_yf_updatekcmx_xnkcl", parameters, 60);
                string rtnStr = "";
                rtnStr = parameters[5].Value.ToString().Trim();
                string outcode = "0";
                outcode = parameters[5].Value.ToString().Trim();

                if (outcode == "-1" || rtnStr != "����ɹ�")
                    throw new Exception(rtnStr.Trim());
            }
            catch { }
        }

        public int GetMedChargeBit(string TMED_EXEC_DEPT, string TMED_MNGTYPE, string TMED_JZ_FLAG)
        {
            int TMP_CHARGE_BIT = iMedCharge;
            try
            {
                //����Ǳ����ҵ�ҩ���ж��Ƿ�ֱ�Ӽ���
                if (TMED_EXEC_DEPT.Trim().Equals(DEPTLY.ToString().Trim()))
                {
                    TMP_CHARGE_BIT = iMedCharge;
                }
                else
                {
                    TMP_CHARGE_BIT = 0;
                }

                //���������������ҩ��ֱ�Ӽ���(����Ҫ���²�ѯ��������)
                if (BSsmzOrder)
                {
                    TMP_CHARGE_BIT = 1;
                }

                //����ǳ�Ժ��ҩ����ֱ�Ӽ���
                if (TMED_MNGTYPE.Equals("5") && TMED_JZ_FLAG.Equals("1"))
                {
                    TMP_CHARGE_BIT = 1;
                }

                //���������Ƿ�ֱ�Ӽ��� MODIFY BY TANY 2007-08-29
                if (_cfgList.cfg7031.Config.ToString().Equals("��"))
                {
                    TMP_CHARGE_BIT = 1;
                }

                //����Ǵ���Һ��ֱ�Ӽ���,�人����ҽԺ��Ŀ Modify By Tany 2014-11-24
                //���봦�����ʱ�����շѱ�־ wait to Modify (����Һҩ����ҩƷֱ�Ӽ��ˣ������Ǵ���Һͳ������ֱ�Ӽ���)
                bool bDsy = isDsyYf(long.Parse(TMED_EXEC_DEPT));
                if (bDsy)
                {
                    TMP_CHARGE_BIT = 1;
                }
            }
            catch
            {
                TMP_CHARGE_BIT = 0;
            }
            return TMP_CHARGE_BIT;
        }

        public int GetTlflInfo(OrderEntity ettOrd, OrderPrescEntity ettOrdPresc, DataTable dtYp)
        {
            /*
            CASE WHEN C.MNGTYPE=5 AND C.JZ_FLAG=1 THEN 3
			WHEN
			  isnull((SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206),0)='0'
			 and
			 (
			 C.NTYPE=3 OR D.DJYP=1 OR  ( D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='0' )--
			OR (D.MZYP=1 and (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7101)='1' and not EXISTS (SELECT 1 FROM SS_DEPT WHERE DEPTID=@DEPTLY) ) --Modify by zouchihua 2012-01-31 ����ҩƷ��7101�������������������� �������������ҩƷ�Ƿ�ͳ��
			OR D.JSYP=1 OR D.GZYP=1 OR D.RSYP=1 OR (C.MNGTYPE=5 AND (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7091)='1') 
			OR a.STATITEM_CODE in (@tjdxm_cf)  ) THEN 5 --Modify By Tany 2011-06-19 7091������ʱҩƷҽ���Ƿ񴦷���ҩ 0=���� 1=��
			when  (SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=7206)='1' and ( D.MZYP=1  OR C.NTYPE=3 )  then 5 ---yaokx 2014-06-24 סԺ������ҩ��ҽԺ�Ƿ�ֻҪ����ҩƷ
			ELSE 0 END,--��Ժ��ҩTLFS=3 --����ҩTLFS=5 ���龫�������
             */
            int iret = 0;
            SystemCfg cfg7206 = _cfgList.cfg7206;
            SystemCfg cfg7101 = _cfgList.cfg7101;
            SystemCfg cfg7091 = _cfgList.cfg7091;
            SystemCfg cfg7132 = _cfgList.cfg7132;

            bool bDjyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["djyp"], "false"));
            bool bMzyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["mzyp"], "false"));
            bool bJsyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["jsyp"], "false"));
            bool bGzyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["gzyp"], "false"));

            string djyp = bDjyp ? "1" : "0";
            string mzyp = bMzyp ? "1" : "0";
            string jsyp = bJsyp ? "1" : "0";
            string gzyp = bGzyp ? "1" : "0";
            string rsyp = (Convertor.IsNull(dtYp.Rows[0]["rsyp"], "0"));

            //bool rsyp = Convert.ToBoolean(Convertor.IsNull(dtYp.Rows[0]["rsyp"], "false"));

            if (ettOrd.MNGTYPE == 5 && ettOrd.JZ_FLAG == 1)
            {
                iret = 3;
            }
            else if (cfg7206.Config.ToString().Trim().Equals("0"))
            {
                if (ettOrd.NTYPE == 3
                        || djyp.Equals("1") || jsyp.Equals("1") || gzyp.Equals("1") || rsyp.Equals("1")
                        || (mzyp.Equals("1") && cfg7101.Config.ToString().Trim().Equals("0"))
                        || (ettOrd.MNGTYPE == 5 && cfg7091.Config.ToString().Trim().Equals("1"))
                        || cfg7132.Config.ToString().Trim().Contains(ettOrdPresc.STATITEM_CODE)
                   )
                {
                    iret = 5;
                }

                if (mzyp.Equals("1") && cfg7101.Config.ToString().Trim().Equals("1"))
                {
                    //���������Ƿ�����
                    string ssql = string.Format(@"select * from SS_DEPT where DEPTID={0} ", DEPTLY);
                    DataTable dt = _database.GetDataTable(ssql);
                    if (dt != null && dt.Rows.Count == 0)
                    {
                        iret = 5;//�����������ҩ������ҩƷ
                    }
                }
            }
            else if (cfg7206.Config.ToString().Trim().Equals("1") && (ettOrd.NTYPE == 3 || djyp.Equals("1")))
            {
                iret = 5;
            }
            else
            {
                iret = 0;
            }

            return iret;
        }

        /// <summary>
        /// ��ȡ���÷�ҩ��־���人��
        /// </summary>
        /// <returns></returns>
        public int GetFyBit(OrderPrescEntity ettOrdPresc)
        {
            /*
             * case when A.EXECDEPT_ID in (566,672,783) and C.DEPT_ID not in (SELECT DEPTID FROM SS_DEPT) then 5 else 0 end,
             */
            int iret = 0;

            //�����鿪��  ���� ִ�п���Ϊ����Һҩ��
            bool bDsy = isDsyYf(ettOrdPresc.EXECDEPT_ID);
            if (bDsy && !BSsmzOrder)
            {
                iret = 5;
            }

            return iret;
        }

        public string Get_ZY_CHGDECIMALTOCHAR(decimal NUM)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT DBO.FUN_ZY_CHGDECIMALTOCHAR({0})", NUM);

                string charInfo = _database.GetDataResult(ssql).ToString();

                return charInfo;
            }
            catch
            {
                return "";
            }
        }

        public string GetSampName(int DWLX)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT SAMP_NAME from LS_AS_SAMPLE where SAMP_CODE={0}", DWLX);

                string charInfo = _database.GetDataResult(ssql).ToString();

                return charInfo;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// ��ȡ�Ǽ����ͣ�1����2��飩
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns>1����2���0����</returns>
        public int GetDjly(long yzid)
        {
            int iret = 0;
            try
            {
                string ssql = "";

                ssql = string.Format(@"SELECT j.class_type from JC_JC_ITEM h
                                        left join JC_JCCLASSDICTION j on h.jclxid=j.id
                                        where h.YZID={0}", yzid);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    iret = int.Parse(dt.Rows[0]["class_type"].ToString());

                    if (iret == 0)
                    {
                        //���
                        iret = 2;
                    }
                    else if (iret == 1)
                    {
                        //����
                        iret = 1;
                    }

                    return iret;
                }

                ssql = string.Format(@"SELECT i.class_type from JC_ASSAY g
                                        left join JC_JCCLASSDICTION i on g.hylxid=i.id
                                        where g.YZID={0}", yzid);

                dt = _database.GetDataTable(ssql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    iret = int.Parse(dt.Rows[0]["class_type"].ToString());

                    if (iret == 0)
                    {
                        //���
                        iret = 2;
                    }
                    else if (iret == 1)
                    {
                        //����
                        iret = 1;
                    }

                    return iret;
                }

                iret = 0;
            }
            catch
            {
                iret = 0;
            }

            return iret;
        }

        /// <summary>
        /// ��ȡ��ʱҽ���Ƿ��ܹ�ֱ�����
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public int GetTmpOrder()
        {
            int iret = 0;

            if (STATUS_FLAG == 2 && _orderExecList.Count > 0)
            {
                iret = 1;//��ִ�м�¼����STATUS_FLAG = 2
            }

            return iret;
        }

        /// <summary>
        /// ��ȡ�Զ����������Ƿ�Ҫ���ˣ�charge_bit
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public int GetCzChargeBit()
        {
            int iCharge = 1;

            //�����ҩƷ,���ҳ���ҩƷ��ֱ�Ӽ���
            string cfg7025 = _cfgList.cfg7025.Config.ToString().Trim();
            if (NTYPE <= 3 && NTYPE != 0 && XMLY == 1 && cfg7025.Equals("��"))
            {
                iCharge = 0;//��ִ�м�¼����STATUS_FLAG = 2
            }

            string cfg7212 = _cfgList.cfg7212.Config.ToString().Trim();
            //�������Ƿ��������
            if (XMLY == 2)
            {
                if (cfg7212.Equals("1"))
                {
                    foreach (OrderEntity ettOrd in _orderList)
                    {
                        DataTable dt = GetHoitemInfo(ettOrd.HOITEM_ID);

                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            throw new Exception("δ�ҵ�����Hoitem��Ϣ��" + ettOrd.HOITEM_ID);
                        }

                        string isbks = Convertor.IsNull(dt.Rows[0]["isbks"], "");
                        string isryks = Convertor.IsNull(dt.Rows[0]["isbks"], "");
                        if (isbks.Equals("1") || isryks.Equals("1"))
                        {
                            iCharge = 0;
                        }
                    }
                }
            }

            string cfg7053 = _cfgList.cfg7053.Config.ToString().Trim();
            if (NTYPE == 5 && XMLY == 2 && cfg7053.Equals("1"))
            {
                iCharge = 2;
            }

            return iCharge;
        }

        private DataTable GetHoitemInfo(long Hoitemid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT * FROM JC_HOITEMDICTION where ORDER_ID={0}", Hoitemid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ��ȡ���ñ����ִ��ʱ��
        /// </summary>
        /// <param name="DWLX"></param>
        /// <returns></returns>
        public DateTime? GetMaxPrescDate(Guid orderid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT MAX(PRESC_DATE) PRESC_DATE FROM ZY_FEE_SPECI WHERE ORDER_ID='{0}'", orderid);

                DataTable dt = _database.GetDataTable(ssql);

                if (dt == null || dt.Rows.Count <= 0)
                {
                    throw new Exception("δ�ҵ����ñ������PRESC_DATE��order_id��" + orderid);
                }

                if (string.IsNullOrEmpty(Convertor.IsNull(dt.Rows[0]["PRESC_DATE"], "")))
                {
                    return null;
                }

                DateTime datePres = DateTime.Parse(dt.Rows[0]["PRESC_DATE"].ToString());
                return datePres;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DataTable GetCzFeeInfo(Guid orderid, string strMaxPresDate)
        {
            string cfg7198 = _cfgList.cfg7198.Config.ToString().Trim();
            string cfg7199 = _cfgList.cfg7199.Config.ToString().Trim();
            string cfg7200 = _cfgList.cfg7200.Config.ToString().Trim();
            try
            {
                string ssql = "";

                if (cfg7198.Equals("1"))
                {
                    ssql = string.Format(@"SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,'') TLFL,A.EXECDEPT_ID,XMID as cjid,xmly,A.is_PvsScn,ISNULL(A.CHARGE_DATE,GETDATE()) CHARGE_DATE
                                            ,A.ORDER_ID,A.PRESCRIPTION_ID,A.PRESC_DATE,
                                            A.PRESC_NO,A.STATITEM_CODE,A.XMID,A.TCID,A.TC_FLAG,A.INPATIENT_ID,A.BABY_ID,
                                            A.ITEM_NAME,A.SUBCODE,A.UNIT,A.DOSAGE,A.COST_PRICE, A.RETAIL_PRICE, 
                                            A.AGIO,A.DEPT_ID,A.DEPT_BR,A.DEPT_LY,A.DOC_ID,
                                            A.TYPE,A.TLFS,A.EXECDEPT_ID,A.GG,A.CJ,A.GCYS,A.pvs_xh,A.ZFBL,A.DISCHARGE_BIT,A.FY_BIT,A.SCBZ,A.CHARGE_BIT
	                                        FROM ZY_FEE_SPECI A  
	                                        LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
	                                        WHERE ORDER_ID='{0}' AND CZ_FLAG<>2 
	                                        AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))
		                                        and isnull(YBJS_BIT,0)=0 
		                                        and isnull(A.is_PvsScn,0)=0
		                                        order by xmly,(case when xmly=2 
		                                        and 
		                                        (charindex(','+cast(xmid as varchar(20))+',',','+'{2}'+',')>0 
		                                        or charindex(','+cast(xmid as varchar(20))+',',','+'{3}'+',')>0 )
		                                        then num else a.xmid END),num desc", orderid, strMaxPresDate, cfg7199, cfg7200);
                }
                else
                {
                    ssql = string.Format(@"SELECT A.ID,A.ORDEREXEC_ID,A.NUM,A.UNITRATE,ISNULL(B.TLFL,'') TLFL,A.EXECDEPT_ID,XMID AS cjid,xmly,A.is_PvsScn,ISNULL(A.BOOK_DATE,GETDATE()) CHARGE_DATE
                                            ,A.ORDER_ID,A.PRESCRIPTION_ID,A.PRESC_DATE,
                                            A.PRESC_NO,A.STATITEM_CODE,A.XMID,A.TCID,A.TC_FLAG,A.INPATIENT_ID,A.BABY_ID,
                                            A.ITEM_NAME,A.SUBCODE,A.UNIT,A.DOSAGE,A.COST_PRICE, A.RETAIL_PRICE, 
                                            A.AGIO,A.DEPT_ID,A.DEPT_BR,A.DEPT_LY,A.DOC_ID,
                                            A.TYPE,A.TLFS,A.EXECDEPT_ID,A.GG,A.CJ,A.GCYS,A.pvs_xh,A.ZFBL,A.DISCHARGE_BIT,A.FY_BIT,A.SCBZ,A.CHARGE_BIT
						                    FROM ZY_FEE_SPECI A  
						                    LEFT JOIN VI_YP_YPCD B ON A.XMID=B.CJID AND A.XMLY=1
						                    WHERE ORDER_ID='{0}' AND CZ_FLAG<>2 
                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}'))
						                      AND ISNULL(YBJS_BIT,0)=0 
						                      AND ISNULL(A.is_PvsScn,0)=0
						                      ORDER BY xmly,xmid, num,pvs_xh DESC", orderid, strMaxPresDate);
                }

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        //��ʱ����
        private OrderExecEntity GetISANALYZED(Guid execid, List<OrderExecEntity> execLists)
        {
            try
            {
                foreach (OrderExecEntity ettOrdExec in execLists)
                {
                    if (ettOrdExec.ID == execid)
                    {
                        return ettOrdExec;
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        //��ʱ����
        private DataTable GetCzNumByOrder(Guid orderid, string xmid, string xmly, string strMaxPresDate)
        {
            try
            {
                string ssql = "";

                //                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE  ORDER_ID='{0}' 
                //                                                AND CZ_FLAG<>2 
                //                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}')) and DELETE_BIT=0 ", orderid, strMaxPresDate, xmid, xmly);


                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE  ORDER_ID='{0}' 
                                            and xmid='{2}' and xmly='{3}'
                                            AND CONVERT(DATETIME,DBO.FUN_GETDATE(PRESC_DATE))=CONVERT(DATETIME,DBO.FUN_GETDATE('{1}')) and DELETE_BIT=0 ", orderid, strMaxPresDate, xmid, xmly);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        private DataTable GetCzNum(Guid feeid)
        {
            try
            {
                string ssql = "";
                ssql = string.Format(@"SELECT SUM(NUM) CZZNUM,SUM(ACVALUE) CZZJE FROM ZY_FEE_SPECI WHERE DELETE_BIT=0 AND (ID='{0}' OR CZ_ID='{0}')", feeid);

                DataTable dt = _database.GetDataTable(ssql);

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// �Ƿ����Һҩ��
        /// </summary>
        /// <param name="execDept"></param>
        /// <returns></returns>
        public bool isDsyYf(long execDept)
        {
            bool bDsy = false;

            if (execDept == 566 || execDept == 672 || execDept == 783)
            {
                bDsy = true;
            }

            return bDsy;
        }

        /// <summary>
        /// ҽ��ȷ��
        /// </summary>
        /// <param name="orderid">ҽ��ID</param>
        /// <param name="yjsqid">ҽ������id</param>
        /// <param name="je">ȷ�Ͻ��</param>
        /// <param name="qrks">�������</param>
        /// <param name="qrsj">����ʱ��</param>
        /// <param name="qrr">������</param>
        /// <param name="bscqrbz">�״�ȷ�ϱ�־</param>
        /// <param name="jcrq">�������</param>
        /// <param name="jcys">���ҽ��</param>
        /// <param name="jgwz">���λ�û�����</param>
        /// <param name="NewYjqrid">ȷ��id</param>
        /// <param name="err_code">����� 0 �ɹ�</param>
        /// <param name="err_text">�����ļ�</param>
        public void yj_zysq_qrjl(Guid orderid, Guid orderexecid, Guid yjsqid, decimal je, long qrks, string qrsj,
            int qrr, int bscqrbz, string jcrq, int jcys, string jgwz, out Guid NewYjqrid, out int err_code,
            out string err_text, int bjlzt)
        {
            ParameterEx[] parameters = new ParameterEx[15];
            parameters[0].Text = "@ORDERID";
            parameters[0].Value = orderid;
            parameters[1].Text = "@yjsqid";
            parameters[1].Value = yjsqid;
            parameters[2].Text = "@JE";
            parameters[2].Value = je;
            parameters[3].Text = "@QRKS";
            parameters[3].Value = qrks;
            parameters[4].Text = "@QRSJ";
            parameters[4].Value = qrsj;
            parameters[5].Text = "@QRR";
            parameters[5].Value = qrr;

            parameters[6].Text = "@BSCQRBZ";
            parameters[6].Value = bscqrbz;
            parameters[7].Text = "@jcrq";
            parameters[7].Value = jcrq;
            parameters[8].Text = "@jcys";
            parameters[8].Value = jcys;
            parameters[9].Text = "@JGWZ";
            parameters[9].Value = jgwz;

            parameters[10].Text = "@NewYjqrid";
            parameters[10].ParaDirection = ParameterDirection.Output;
            parameters[10].ParaSize = 100;

            parameters[11].Text = "@err_code";
            parameters[11].ParaDirection = ParameterDirection.Output;
            parameters[11].DataType = System.Data.DbType.Int32;
            parameters[11].ParaSize = 100;

            parameters[12].Text = "@err_text";
            parameters[12].ParaDirection = ParameterDirection.Output;
            parameters[12].ParaSize = 100;

            parameters[13].Text = "@orderexecid";
            parameters[13].Value = orderexecid;

            parameters[14].Text = "@bjlzt";
            parameters[14].Value = bjlzt;

            _database.GetDataTable("SP_YJ_SAVE_QRJL", parameters, 60);
            NewYjqrid = new Guid(parameters[10].Value.ToString());
            err_code = Convert.ToInt32(parameters[11].Value);
            err_text = Convert.ToString(parameters[12].Value);
        }
    }

    public class XnKclEntity
    {
        public string cjid;
        public string num;
        public string dwbl;
        public string execDeptId;
    }

    public class YjZySqEntity
    {
        public Guid YJSQID;
        public long JGBM;
        public Guid BRXXID;
        public Guid INPATIENT_ID;
        public DateTime SQRQ;
        public long SQR;
        public long SQKS;
        public string SQNR;
        public decimal JE;
        public string LCZD;
        public long ZXKS;
        public string BSJC;
        public string BBMC;
        public string ZYSX;
        public int BJJBZ;
        public Guid YZID;
        public long YZXMID;
        public long ZXR;
        public DateTime ZXSJ;
        public Guid ZXID;
        public int DJLX;
        public int BTFBZ;
        public decimal TFJE;
    }

    #region"����"

    /*
        /// <summary>
        /// ��ִ�з���
        /// </summary>
        /// <param name="execNow"></param>
        /// <param name="iret"></param>
        /// <param name="strMsg"></param>
        /// <returns>ҽ���Ƿ���ִ��(0������  1��return  2��nextday��ɴ���)</returns>
        public int ZF_DoExcuteAddFee(DateTime execNow, DateTime execEnd, int iExecNum,
            List<OrderExecEntity> execLists, List<XnKclEntity> xnKcLists,
            List<OrderPrescEntity> prescLists, List<OrderFeeEntity> FeeLists,
            List<OrderPrescEntity> fjPrescLists, List<OrderFeeEntity> fjFeeLists,
            List<YjZySqEntity> yjsqLists, List<YjZySqEntity> yjqrLists,
            out int iret, out string strMsg)
        {
            Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>> orderInfo
                = new Dictionary<OrderEntity, Dictionary<OrderExecEntity, Dictionary<OrderPrescEntity, List<OrderFeeEntity>>>>();

            iret = 0;
            strMsg = "";
            int iOutPut = 0;
            try
            {
                //��ʼִ��ʱ���ֹͣʱ����ж�
                if (execNow.Date < BEGINEXEDATE.Date)
                {
                    //Goto NextDay 
                    iOutPut = 2;
                    return iOutPut;
                }

                //ExecNum
                iExecNum = GetExecNums(execNow, execEnd);//��������ִ�д�����ע�⡿

                string dCfh = GetPrescNo();

                int iCfExecCnt = iExecNum;
                bool bCf = false;
                if (cfBit == 1 && XMLY == 1 && iExecNum > 0)
                {
                    //��Ҫ���
                    iCfExecCnt = 1;
                    bCf = true;
                }

                #region"1������ִ�б�  2:����set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER"

                //1������ִ�б�
                //2:����set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                while (iCfExecCnt <= iExecNum)
                {
                    foreach (OrderEntity ettOrd in _orderList)
                    {
                        OrderExecEntity ettOrdExec = new OrderExecEntity();

                        ettOrdExec.ID = PubStaticFun.NewGuid();
                        ettOrdExec.BOOK_DATE = EXECBOOKDATE;
                        ettOrdExec.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdExec.EXEUSER = EXEUSER;
                        ettOrdExec.EXECDATE = execNow;

                        ettOrdExec.ISANALYZED = bCf ? 1 : iExecNum;
                        ettOrdExec.PRESCRIPTION_ID = dCfh;
                        ettOrdExec.INPATIENT_ID = _Binid;
                        ettOrdExec.BABY_ID = _Babyid;
                        ettOrdExec.JGBM = _JGBM;

                        ettOrdExec.PVS_XH = bCf ? iCfExecCnt : -1;

                        //1������ִ�б�
                        execLists.Add(ettOrdExec);//������ִ�б�����
                        _orderExecList.Add(ettOrdExec);//�����м��

                        //2:����set LASTEXECDATE=@CUREXECDATE,LASTEXECUSER=@EXEUSER
                        ettOrd.LASTEXECDATE = execNow;//������ִ�б�����
                        ettOrd.LASTEXECUSER = EXEUSER;//������ִ�б�����
                    }

                    iCfExecCnt++;
                }

                #endregion

                if (iExecNum == 0)
                {
                    // goto next 
                    iOutPut = 2;
                    return iOutPut;
                }

                #region"ҩƷ��������ZY_PRESCRIPTION"

                string TMED_ID = "";
                string TMED_ORDER_ID = "";
                string TMED_DEPT_ID = "";
                string TMED_DEPT_BR = "";
                string TMED_EXEC_DEPT = "";
                string TMED_ORDER_DOC = "";
                string TMED_NUM = "";
                string TMED_HOITEM_ID = "";
                string TMED_ITEM_CODE = "";
                string TMED_XMLY = "";
                string TMED_DWLX = "";
                string ORDERUNIT = "";
                string TMED_ORDER_SPEC = "";
                string TMED_DOSAGE = "";
                string TMED_MNGTYPE = "";
                string TMED_JZ_FLAG = "";
                string TMED_ORDER_CONTEXT = "";
                string TMED_NTYPE = "";
                string TMED_STATCODE = "";
                string TEMD_TLFL = "";

                //--|��ʱ���Ϊ����������ҽ��ִ�б��õ�Ҫ����Ĵ�����ļ�¼
                //--|ҩ��Ҫѭ���������ͼ۸� MODIFY BY TANY 2005-09-11
                //IF @NTYPE<=3 AND @NTYPE<>0 AND @XMLY=1 AND @HOITEMID>0
                if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0)
                {
                    foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        bool bHasOrd = false;
                        foreach (OrderEntity thisOrder in _orderList)
                        {
                            if (ettOrdExec.ORDER_ID == thisOrder.ORDER_ID)
                            {
                                ettOrd = thisOrder;
                                bHasOrd = true;
                                break;
                            }
                        }

                        if (!bHasOrd)
                            throw new Exception("ִ�м�¼δ�ҵ���Ӧ��ҽ����Ϣ");

                        //�������Ա�ҩ
                        if (ettOrd.HOITEM_ID <= 0)
                            continue;

                        TMED_ID = ettOrdExec.ID.ToString();
                        TMED_ORDER_ID = ettOrd.ORDER_ID.ToString();
                        TMED_DEPT_ID = ettOrd.DEPT_ID.ToString();
                        TMED_DEPT_BR = ettOrd.DEPT_BR.ToString();
                        TMED_EXEC_DEPT = ettOrd.EXEC_DEPT.ToString();
                        if (pvsBit == 1)
                        {
                            //pvs����
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;
                            if (iDiff2 >= 1)
                            {
                                //pivas��һ��ҩ�����ã�wait to��װ��
                                TMED_EXEC_DEPT = EXEDEPT.ToString();
                            }
                        }
                        TMED_ORDER_DOC = ettOrd.ORDER_DOC.ToString();
                        TMED_NUM = ettOrd.NUM.ToString();
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            TMED_NUM = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                        }
                        TMED_HOITEM_ID = ettOrd.HOITEM_ID.ToString();
                        TMED_ITEM_CODE = ettOrd.ITEM_CODE.ToString();
                        TMED_XMLY = ettOrd.XMLY.ToString();
                        TMED_DWLX = ettOrd.DWLX.ToString();
                        ORDERUNIT = ettOrd.UNIT;
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            ORDERUNIT = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                        }

                        TMED_ORDER_SPEC = ettOrd.ORDER_SPEC.ToString();
                        TMED_DOSAGE = ettOrd.DOSAGE.ToString();
                        TMED_MNGTYPE = ettOrd.MNGTYPE.ToString();
                        TMED_JZ_FLAG = ettOrd.JZ_FLAG.ToString();
                        TMED_ORDER_CONTEXT = ettOrd.ORDER_CONTEXT.ToString();
                        TMED_NTYPE = ettOrd.NTYPE.ToString();

                        if (ettOrd.XMLY == 1)
                        {
                            DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                            if (dtYp == null || dtYp.Rows.Count <= 0)
                            {
                                throw new Exception(ettOrd.HOITEM_ID + " ҩƷ���ҵ���δ�ҵ���ҩƷ��Ϣ");
                            }

                            TMED_STATCODE = dtYp.Rows[0]["STATITEM_CODE"].ToString();
                            TEMD_TLFL = dtYp.Rows[0]["TLFL"].ToString();
                        }

                        string unit = "";
                        decimal kcl = 0;
                        decimal xnKcl = 0;
                        long thisExecDept = long.Parse(TMED_EXEC_DEPT);
                        //��ȡpivas�����Ϣ
                        GetYpKcmxInfo(ettOrd.DWLX, ettOrd.HOITEM_ID, ettOrd.XMLY, thisExecDept, out unit, out kcl, out xnKcl);

                        if (string.IsNullOrEmpty(unit))
                        {
                            iOutPut = 1;//return
                            iret = -1;
                            strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�ڡ�" + TMED_EXEC_DEPT + "��û���ҵ������Ϣ�������¿���ҽ����";
                            return iOutPut;
                        }

                        string thisOrderUnit = "";
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            thisOrderUnit = string.IsNullOrEmpty(Convertor.IsNull(ettOrd.zsldw, "")) ? ettOrd.UNIT : ettOrd.zsldw;
                        }
                        else
                        {
                            thisOrderUnit = ettOrd.UNIT;
                        }

                        if (unit.Trim().ToUpper() != thisOrderUnit.Trim().ToUpper())
                        {
                            iOutPut = 1;//return
                            iret = -1;
                            strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�ĵ�λ(" + unit + ")��ҽ���ĵ�λ(" + ettOrd.UNIT + ")��ͬ�������¿���ҽ����";
                            return iOutPut;
                        }

                        decimal _num = decimal.Parse(TMED_NUM);
                        int _cjid = int.Parse(TMED_HOITEM_ID);
                        int _execDeptid = int.Parse(TMED_EXEC_DEPT);

                        DataTable dtYpDw = GetYpkcmxInfo(ettOrd.DWLX, _num, _cjid, _execDeptid);

                        if (dtYpDw == null || dtYpDw.Rows.Count <= 0)
                        {
                            throw new Exception(BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + "ҩƷ������Ϣ����");
                        }

                        string TMP_GGID = dtYpDw.Rows[0]["GGID"].ToString();
                        string TMP_CJID = dtYpDw.Rows[0]["CJID"].ToString();
                        string TMP_YL = dtYpDw.Rows[0]["YL"].ToString();
                        string TMP_UNIT = dtYpDw.Rows[0]["UNIT"].ToString();
                        string TMP_PRICE = dtYpDw.Rows[0]["PRICE"].ToString();
                        string TMP_SDVALUE = dtYpDw.Rows[0]["SDVALUE"].ToString();
                        string TMP_YDWBL = dtYpDw.Rows[0]["YDWBL"].ToString();
                        string TMP_ZXKSID = dtYpDw.Rows[0]["ZXKSID"].ToString();
                        string TMP_BDELETE = dtYpDw.Rows[0]["BDELETE"].ToString();
                        string TMP_KCL = Convertor.IsNull(dtYpDw.Rows[0]["KCL"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 ���Ϊnull��Ϊ0
                        string TMP_YLKC = Convertor.IsNull(dtYpDw.Rows[0]["YLKC"], "0");//Add By Tany 2011-03-22 Modify By Tany 2015-04-20 ���Ϊnull��Ϊ0

                        //add by zouchihua  ��������ж� 2012-02-21
                        //�������� ���ҿ�ҽ��ʱ�䲻���ڵ�ǰִ�е�ʱ��
                        if (_cfgList.cfg6035.Config.ToString().Equals("1"))
                        {
                            if (execNow.Date != BEGINEXEDATE.Date)
                            {
                                decimal dTMP_YL = decimal.Parse(TMP_YL);
                                decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                                decimal ypsl = -1 * dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;

                                XnKclEntity xn = new XnKclEntity();
                                xn.cjid = TMP_CJID;
                                xn.num = ypsl.ToString();
                                xn.dwbl = TMED_DWLX;
                                xn.execDeptId = TMED_EXEC_DEPT;
                                //UpdateXnKc(TMP_CJID, ypsl, TMED_DWLX, TMED_EXEC_DEPT);//ʧ�ܲ�����
                                xnKcLists.Add(xn);
                            }
                        }

                        //Modify By Tany 2009-12-22  ҽ��ִ��ʱ�Ƿ����ƿ���������ҩƷ���ܷ��� 0=���� 1=��
                        if (_cfgList.cfg7059.Config.ToString().Equals("1"))
                        {
                            decimal ylKcl = decimal.Parse(TMP_KCL);
                            decimal dTMP_YL = decimal.Parse(TMP_YL);
                            decimal dTMED_DOSAGE = decimal.Parse(TMED_DOSAGE);
                            decimal thisYl = dTMP_YL * ettOrdExec.ISANALYZED * dTMED_DOSAGE;
                            if (thisYl > ylKcl)
                            {
                                //ҽ��ִ��ҩƷ���������ʱ�Ƿ��Զ��滻ͬ���ͬ�����п���ҩƷ 0=���� 1=��
                                if (_cfgList.cfg7060.Config.ToString().Equals("1"))
                                {
                                    iOutPut = 1;//return
                                    iret = -1;
                                    strMsg = BED_NO + " ������ " + PAT_NAME + " ����ҩƷ:" + TMED_ORDER_CONTEXT.Trim() + "(CJID=" + TMED_HOITEM_ID + ")�Ŀ����Ϊ(" + ylKcl + ") ����ִ������Ϊ(" + thisYl + ")����������������ִ�У�";
                                    return iOutPut;
                                }
                                else
                                {
                                    //wait ��ҩ�߼�
                                }
                            }
                        }

                        //����Ǳ����ҵ�ҩ���ж��Ƿ�ֱ�Ӽ���
                        int TMP_CHARGE_BIT = GetMedChargeBit(TMED_EXEC_DEPT, TMED_MNGTYPE, TMED_JZ_FLAG);

                        OrderPrescEntity ettOrdPresc = new OrderPrescEntity();
                        ettOrdPresc.ID = PubStaticFun.NewGuid();
                        ettOrdPresc.INPATIENT_ID = _Binid;
                        ettOrdPresc.BABY_ID = _Babyid;
                        ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                        ettOrdPresc.BOOK_USER = EXEUSER;
                        ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)
                        ettOrdPresc.PRESC_DATE = execNow;
                        ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                        ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdPresc.TYPE = 1;//type=1����ͨ   type=2�����ӷ���
                        ettOrdPresc.DEPT_ID = long.Parse(TMED_DEPT_BR);
                        ettOrdPresc.EXECDEPT_ID = long.Parse(TMED_EXEC_DEPT);
                        ettOrdPresc.PRESC_DOC = long.Parse(TMED_ORDER_DOC);
                        ettOrdPresc.HDITEM_ID = long.Parse(TMED_HOITEM_ID);
                        ettOrdPresc.XMLY = int.Parse(TMED_XMLY);
                        ettOrdPresc.STATITEM_CODE = TMED_STATCODE;
                        ettOrdPresc.SUBCODE = TMED_ITEM_CODE;
                        ettOrdPresc.STANDARD = "";
                        ettOrdPresc.DOSAGE = int.Parse(TMED_DOSAGE);
                        ettOrdPresc.UNIT = TMP_UNIT;
                        ettOrdPresc.UNITRATE = int.Parse(TMP_YDWBL);
                        ettOrdPresc.PRICE = decimal.Parse(TMP_PRICE);
                        ettOrdPresc.AGIO = 1;
                        ettOrdPresc.NUM = decimal.Parse(TMP_YL) * ettOrdExec.ISANALYZED;
                        ettOrdPresc.CHARGE_BIT = TMP_CHARGE_BIT;
                        ettOrdPresc.JGBM = _JGBM;

                        prescLists.Add(ettOrdPresc);
                    }
                }

                #endregion

                #region"��Ŀ������ZY_PRESCRIPTION"

                if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                {
                    foreach (OrderExecEntity ettOrdExec in execLists)
                    {
                        OrderEntity ettOrd = new OrderEntity();
                        bool bHasOrd = false;

                        foreach (OrderEntity thisOrder in _orderList)
                        {
                            if (ettOrdExec.ORDER_ID == thisOrder.ORDER_ID)
                            {
                                ettOrd = thisOrder;
                                bHasOrd = true;
                                break;
                            }
                        }

                        if (!bHasOrd)
                            throw new Exception("ִ�м�¼δ�ҵ���Ӧ��ҽ����Ϣ");

                        //��Ժת�ơ�������˵�����ж��Ƿ��м�¼����
                        if (ettOrd.HOITEM_ID <= 0 || ettOrd.EXEC_DEPT <= 0)
                            continue;

                        OrderPrescEntity ettOrdPresc = new OrderPrescEntity();

                        DataTable dtExeDept = GetDeptJzInfo(ettOrd.EXEC_DEPT);

                        if (dtExeDept == null || dtExeDept.Rows.Count <= 0)
                        {

                            throw new Exception("δ�ҵ���" + ettOrd.EXEC_DEPT + " ��ִ�п��Ҷ�Ӧ�Ŀ�����Ϣ");
                        }

                        string deptJzFlag = dtExeDept.Rows[0]["ISJZ"].ToString().Trim();
                        long ExecDeptJgbm = long.Parse(dtExeDept.Rows[0]["JGBM"].ToString().Trim());

                        DataTable dtXm = GetItemInfo(ettOrd.HOITEM_ID, ettOrd.EXEC_DEPT, ettOrd.JGBM, ExecDeptJgbm);

                        if (dtXm == null || dtXm.Rows.Count <= 0)
                        {
                            if (NTYPE == 0 || NTYPE == 7)
                            {
                                continue;
                            }

                            //�Ʒ�ҽ��δ��Ӧ�շ���Ŀ
                            throw new Exception("δ�ҵ���" + ettOrd.HOITEM_ID + " ��HOITEM_ID��Ӧ�ķ�����Ϣ");
                        }

                        ettOrdPresc.ID = PubStaticFun.NewGuid();
                        ettOrdPresc.SOURCE_ID = ettOrdExec.ID;
                        ettOrdPresc.INPATIENT_ID = _Binid;
                        ettOrdPresc.PRESC_NO = dCfh;//decimal(21,6)

                        ettOrdPresc.DEPT_ID = ettOrd.DEPT_BR;
                        ettOrdPresc.EXECDEPT_ID = ettOrd.EXEC_DEPT;

                        ettOrdPresc.HDITEM_ID = long.Parse(dtXm.Rows[0]["HDITEM_ID"].ToString().Trim());
                        ettOrdPresc.XMLY = ettOrd.XMLY;

                        ettOrdPresc.STATITEM_CODE = dtXm.Rows[0]["BIGITEMCODE"].ToString().Trim();

                        ettOrdPresc.TCID = long.Parse(dtXm.Rows[0]["TCID"].ToString().Trim());
                        ettOrdPresc.TC_FLAG = int.Parse(dtXm.Rows[0]["TC_FLAG"].ToString().Trim());

                        ettOrdPresc.PRESC_DATE = execNow;
                        ettOrdPresc.PRESC_DOC = ettOrd.ORDER_DOC;
                        ettOrdPresc.STANDARD = ettOrd.ORDER_SPEC;

                        ettOrdPresc.UNIT = dtXm.Rows[0]["UNIT"].ToString().Trim();
                        ettOrdPresc.UNITRATE = 1;

                        if (decimal.Parse(Convertor.IsNull(ettOrd.PRICE, "0")) == 0)
                        {
                            ettOrdPresc.PRICE = decimal.Parse(dtXm.Rows[0]["PRICE"].ToString().Trim());//Ϊ0��ʹ����Ŀ�۸�
                        }
                        else
                        {
                            ettOrdPresc.PRICE = ettOrd.PRICE;//ҽ���۸�Ϊ0��ʹ��ҽ���۸�
                        }
                        ettOrdPresc.AGIO = 1;

                        string thisNum = ettOrd.NUM.ToString();
                        if (MNGTYPE == 1 || MNGTYPE == 5)
                        {
                            thisNum = Convertor.IsNull(ettOrd.zsl, "-1").Equals("-1") ? ettOrd.NUM.ToString() : ettOrd.zsl.ToString();
                        }
                        decimal dNum = decimal.Parse(thisNum);
                        decimal xmNum = decimal.Parse(dtXm.Rows[0]["NUM"].ToString().Trim());
                        ettOrdPresc.NUM = xmNum * dNum * ettOrdExec.ISANALYZED;//��Ŀ����*��������*ִ��Ƶ��
                        ettOrdPresc.DOSAGE = ettOrd.DOSAGE;
                        ettOrdPresc.BABY_ID = _Babyid;

                        ettOrdPresc.SUBCODE = ettOrd.ITEM_CODE;

                        //ֱ�Ӽ��ˣ�1.���Ƽ���  2.���Ƽ��˼�����jz_flag=1  3.ҽ��Jz_flag 4.ntype<>5
                        ettOrdPresc.CHARGE_BIT = 0;
                        if (ettOrd.DEPT_ID == ettOrd.EXEC_DEPT || (ettOrd.DEPT_ID != ettOrd.EXEC_DEPT && deptJzFlag.Equals("1")) || ettOrd.JZ_FLAG == 1 || ettOrd.NTYPE != 5)
                        {
                            ettOrdPresc.CHARGE_BIT = 1;
                        }

                        ettOrdPresc.BOOK_DATE = EXECBOOKDATE;
                        ettOrdPresc.BOOK_USER = EXEUSER;
                        ettOrdPresc.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdPresc.TYPE = 1;//type=1����ͨ   type=2�����ӷ���
                        ettOrdPresc.JGBM = _JGBM;

                        prescLists.Add(ettOrdPresc);
                    }
                }

                #endregion

                #region"ҽ�����ӷ��� wait"
                #endregion

                #region"ҩƷ���ô���[ҩƷ����������ͬ����������ִ������]"

                //wait  ����7605�Ŀ���
                if (NTYPE <= 3 && NTYPE > 0 && XMLY == 1 && HOITEMID > 0 && EXEDEPT > 0)
                {
                    #region"ҩƷ��ZY_FEE_SPECI"

                    foreach (OrderPrescEntity ettOrdPresc in prescLists)
                    {
                        //��ͨ���� �Ǹ��ӷ�
                        if (ettOrdPresc.TYPE != 1)
                        {
                            continue;
                        }

                        //wait 
                        OrderEntity ettOrd = new OrderEntity();//����װ��ȡ��Ӧҽ��
                        OrderExecEntity ettOrdExec = new OrderExecEntity();//����װ��ȡ��Ӧִ�м�¼

                        OrderFeeEntity ettOrdFee = new OrderFeeEntity();
                        ettOrdFee.ID = PubStaticFun.NewGuid();
                        ettOrdFee.INPATIENT_ID = _Binid;
                        ettOrdFee.BABY_ID = _Babyid;

                        ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                        ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                        ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;

                        ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                        ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                        ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                        ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;
                        ettOrdFee.STATITEM_CODE = ettOrdPresc.STATITEM_CODE;
                        ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                        ettOrdFee.XMLY = ettOrdPresc.XMLY;

                        ettOrdFee.ITEM_NAME = ettOrd.ORDER_CONTEXT;
                        ettOrdFee.SUBCODE = ettOrdPresc.SUBCODE;
                        ettOrdFee.UNIT = ettOrdPresc.UNIT;
                        ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                        ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                        ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                        ettOrdFee.NUM = ettOrdPresc.NUM;
                        ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;

                        //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                        decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM * ettOrdPresc.DOSAGE / ettOrdExec.ISANALYZED;
                        string strMoney = dMoney.ToString("0.00");
                        dMoney = decimal.Parse(strMoney);
                        ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                        ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;

                        ettOrdFee.AGIO = ettOrdPresc.AGIO;

                        ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                        ettOrdFee.CHARGE_DATE = null;
                        ettOrdFee.CHARGE_USER = null;
                        if (pvsBit == 1)
                        {
                            //pvs����
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;
                            if (iDiff2 >= 1)
                            {
                                ettOrdFee.CHARGE_BIT = 1;
                            }
                        }
                        if (ettOrdFee.CHARGE_BIT == 1)
                        {
                            //pvs����
                            TimeSpan tm2 = ettOrdExec.EXECDATE.Subtract(ettOrd.ORDER_BDATE);
                            int iDiff2 = tm2.Days;

                            if (pvsBit == 0 || iDiff2 <= 0)
                            {
                                ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                            }
                        }

                        ettOrdFee.DELETE_BIT = 0;
                        ettOrdFee.CZ_FLAG = 0;
                        ettOrdFee.DISCHARGE_BIT = 0;

                        ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                        ettOrdFee.DEPT_ID = DEPTID;
                        ettOrdFee.DEPT_BR = DEPTBR;
                        ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 ִ�п��һ��Ǹ��洦�����ڴ�����ȷ�����ĸ�ִ�п�����ҩ


                        DataTable dtYp = GetYpInfo(ettOrd.HOITEM_ID);

                        if (dtYp == null || dtYp.Rows.Count <= 0)
                        {
                            throw new Exception(ettOrd.HOITEM_ID + " ҩƷ���ҵ���δ�ҵ���ҩƷ��Ϣ");
                        }
                        ettOrdFee.TLFS = GetTlflInfo(ettOrd, ettOrdPresc, dtYp);

                        ettOrdFee.DEPT_LY = DEPTLY;
                        ettOrdFee.JGBM = _JGBM;
                        ettOrdFee.GG = dtYp.Rows[0]["S_YPGG"].ToString();
                        ettOrdFee.CJ = dtYp.Rows[0]["S_SCCJ"].ToString();

                        ettOrdFee.GCYS = GCYS;
                        ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                        ettOrdFee.FY_BIT = GetFyBit(ettOrdPresc);
                        ettOrdFee.pvs_xh = ettOrdExec.PVS_XH;

                        FeeLists.Add(ettOrdFee);

                    }

                    #endregion
                }

                #endregion

                #region"���Ʒ��ü�����ҽ���߼�����[��Ŀ�����������Ѵ�������Ϊ���������ײ�]"

                if ((NTYPE > 3 || XMLY == 2) && HOITEMID > 0)
                {
                    #region"��Ŀ��ZY_FEE_SPECI"

                    foreach (OrderPrescEntity ettOrdPresc in prescLists)
                    {
                        //��ͨ���� �Ǹ��ӷ�
                        if (ettOrdPresc.TYPE != 1)
                        {
                            continue;
                        }

                        //wait 
                        OrderEntity ettOrd = new OrderEntity();//����װ��ȡ��Ӧҽ��
                        OrderExecEntity ettOrdExec = new OrderExecEntity();//����װ��ȡ��Ӧִ�м�¼

                        //����ִ�е��շ���Ŀ
                        DataTable dtXm = GetItemInfoToFee(ettOrd, ettOrdPresc);
                        if (dtXm == null || dtXm.Rows.Count <= 0)
                        {
                            throw new Exception(" δ��ȡ������Ҫִ�е���Ŀ��Ϣ�� ");
                        }

                        string xmSTATITEM_CODE = "";
                        string xmITEM_NAME = "";
                        string xmSTD_CODE = "";
                        string xmITEM_UNIT = "";
                        string xmCOST_PRICE = "";
                        string xmRETAIL_PRICE = "";
                        string xmSUBITEM_ID = "";
                        string xmNUM = "";

                        decimal dSumAcVal = 0;
                        bool bCharged = false;

                        for (int iXm = 0; iXm < dtXm.Rows.Count; iXm++)
                        {
                            #region"ZY_FEE_SPECI"

                            OrderFeeEntity ettOrdFee = new OrderFeeEntity();

                            if (ettOrdPresc.TC_FLAG == 0 && ettOrdPresc.TCID < 0)
                            {
                                //���ײ͵����շ���Ϣ
                                xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();


                                ettOrdFee.XMID = ettOrdPresc.HDITEM_ID;
                                ettOrdFee.COST_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.RETAIL_PRICE = ettOrdPresc.PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                decimal dMoney = ettOrdPresc.PRICE * ettOrdPresc.NUM / ettOrdExec.ISANALYZED;
                                string strMoney = dMoney.ToString("0.00");
                                dMoney = decimal.Parse(strMoney);
                                ettOrdFee.SDVALUE = dMoney * ettOrdExec.ISANALYZED;
                                ettOrdFee.ACVALUE = ettOrdFee.SDVALUE;
                            }
                            else if (ettOrdPresc.TC_FLAG == 1 && ettOrdPresc.TCID >= 0)
                            {
                                //�ײͲ�ֺ����շ���Ϣ
                                xmSTATITEM_CODE = dtXm.Rows[iXm]["STATITEM_CODE"].ToString();
                                xmITEM_NAME = dtXm.Rows[iXm]["ITEM_NAME"].ToString();
                                xmSTD_CODE = dtXm.Rows[iXm]["STD_CODE"].ToString();
                                xmITEM_UNIT = dtXm.Rows[iXm]["ITEM_UNIT"].ToString();
                                xmCOST_PRICE = dtXm.Rows[iXm]["COST_PRICE"].ToString();
                                xmRETAIL_PRICE = dtXm.Rows[iXm]["RETAIL_PRICE"].ToString();
                                xmSUBITEM_ID = dtXm.Rows[iXm]["SUBITEM_ID"].ToString();
                                xmNUM = dtXm.Rows[iXm]["NUM"].ToString();

                                decimal dXmNum = decimal.Parse(xmNUM);
                                decimal dXmCOST_PRICE = decimal.Parse(xmCOST_PRICE);
                                decimal dXmRETAIL_PRICE = decimal.Parse(xmRETAIL_PRICE);

                                ettOrdFee.XMID = long.Parse(xmSUBITEM_ID);
                                ettOrdFee.COST_PRICE = dXmCOST_PRICE;
                                ettOrdFee.RETAIL_PRICE = dXmRETAIL_PRICE;
                                ettOrdFee.NUM = ettOrdPresc.NUM * dXmNum;

                                //CONVERT(DECIMAL(18,2),A.PRICE*A.NUM*A.DOSAGE/B.ISANALYZED)*B.ISANALYZED,
                                ettOrdFee.SDVALUE = dXmCOST_PRICE * ettOrdPresc.NUM * dXmNum;
                                ettOrdFee.ACVALUE = dXmRETAIL_PRICE * ettOrdPresc.NUM * dXmNum;
                            }

                            ettOrdFee.ID = PubStaticFun.NewGuid();
                            ettOrdFee.INPATIENT_ID = _Binid;
                            ettOrdFee.BABY_ID = _Babyid;
                            ettOrdFee.ORDER_ID = ettOrd.ORDER_ID;
                            ettOrdFee.ORDEREXEC_ID = ettOrdPresc.SOURCE_ID;
                            ettOrdFee.PRESCRIPTION_ID = ettOrdPresc.ID;
                            ettOrdFee.PRESC_NO = ettOrdPresc.PRESC_NO;//decimal(21,6)
                            ettOrdFee.PRESC_DATE = ettOrdPresc.PRESC_DATE;
                            ettOrdFee.BOOK_DATE = ettOrdPresc.BOOK_DATE;
                            ettOrdFee.BOOK_USER = ettOrdPresc.BOOK_USER;

                            ettOrdFee.STATITEM_CODE = xmSTATITEM_CODE;
                            ettOrdFee.XMLY = ettOrdPresc.XMLY;
                            ettOrdFee.TCID = ettOrdPresc.TCID;
                            ettOrdFee.TC_FLAG = ettOrdPresc.TC_FLAG;

                            ettOrdFee.ITEM_NAME = xmITEM_NAME;
                            ettOrdFee.SUBCODE = xmSTD_CODE;
                            ettOrdFee.UNIT = xmITEM_UNIT;
                            ettOrdFee.UNITRATE = ettOrdPresc.UNITRATE;

                            ettOrdFee.DOSAGE = ettOrdPresc.DOSAGE;


                            ettOrdFee.AGIO = ettOrdPresc.AGIO;

                            bool bYjqr = false;
                            ettOrdFee.CHARGE_BIT = ettOrdPresc.CHARGE_BIT;
                            ettOrdFee.CHARGE_DATE = null;
                            ettOrdFee.CHARGE_USER = null;
                            if (ettOrdFee.CHARGE_BIT == 1)
                            {
                                ettOrdFee.CHARGE_DATE = ettOrdPresc.BOOK_DATE;
                                ettOrdFee.CHARGE_USER = ettOrdPresc.BOOK_USER;
                                bYjqr = true;

                                bCharged = true;
                            }

                            ettOrdFee.DELETE_BIT = 0;
                            ettOrdFee.CZ_FLAG = 0;
                            ettOrdFee.DISCHARGE_BIT = 0;

                            ettOrdFee.DOC_ID = ettOrdPresc.PRESC_DOC;
                            ettOrdFee.DEPT_ID = DEPTID;
                            ettOrdFee.DEPT_BR = DEPTBR;
                            ettOrdFee.EXECDEPT_ID = ettOrdPresc.EXECDEPT_ID;//--Modify by Tany 2015-04-20 ִ�п��һ��Ǹ��洦�����ڴ�����ȷ�����ĸ�ִ�п�����ҩ

                            ettOrdFee.DEPT_LY = DEPTLY;
                            ettOrdFee.JGBM = _JGBM;

                            ettOrdFee.GCYS = GCYS;
                            ettOrdFee.ZFBL = decimal.Parse(Convertor.IsNull(ettOrd.zfbl, "1")).ToString();

                            FeeLists.Add(ettOrdFee);

                            #endregion

                            dSumAcVal += ettOrdFee.ACVALUE;
                        }

                        //ҽ������ͬ���������ײͲ���Ҫ������ɼ�¼��
                        if (NTYPE == 5)
                        {
                            #region"ҽ������"

                            //ҽ������
                            YjZySqEntity yjsq = new YjZySqEntity();

                            yjsq.YJSQID = PubStaticFun.NewGuid();
                            yjsq.JGBM = _JGBM;
                            yjsq.BRXXID = new Guid(_dtPat.Rows[0]["patient_id"].ToString());//wait
                            yjsq.INPATIENT_ID = ettOrdExec.INPATIENT_ID;
                            yjsq.SQRQ = ettOrdPresc.PRESC_DATE;
                            yjsq.SQR = ettOrd.ORDER_DOC;
                            yjsq.SQKS = ettOrd.DEPT_ID;

                            yjsq.SQNR = ettOrd.ORDER_CONTEXT;
                            if (ettOrd.UNIT.ToUpper().Equals("U") || ettOrd.UNIT.ToUpper().Equals("ML"))
                            {
                                string charInfo = Get_ZY_CHGDECIMALTOCHAR(ettOrd.NUM);
                                yjsq.SQNR = ettOrd.ORDER_CONTEXT.Trim() + " " + charInfo + " " + ettOrd.UNIT;
                            }

                            yjsq.JE = dSumAcVal;
                            yjsq.LCZD = Convertor.IsNull(ettOrd.MEMO1, "");
                            yjsq.ZXKS = ettOrd.EXEC_DEPT;
                            yjsq.BSJC = "";
                            yjsq.BBMC = GetSampName(ettOrd.DWLX);
                            yjsq.ZYSX = "";
                            yjsq.BJJBZ = 0;
                            yjsq.YZID = ettOrd.ORDER_ID;
                            yjsq.YZXMID = ettOrd.HOITEM_ID;
                            yjsq.ZXR = EXEUSER;
                            yjsq.ZXSJ = DateManager.ServerDateTimeByDBType(_database);
                            yjsq.ZXID = ettOrdExec.ID;
                            yjsq.DJLX = GetDjly(ettOrd.HOITEM_ID);

                            yjsqLists.Add(yjsq);

                            #endregion

                            #region"ҽ��ȷ��"

                            if (bCharged)
                            {
                                YjZySqEntity yjqr = new YjZySqEntity();

                                yjqr.YJSQID = yjsq.YJSQID;
                                yjqr.ZXID = ettOrdExec.ID;
                                yjqr.YZID = ettOrd.ORDER_ID;
                                yjqr.JE = dSumAcVal;

                                yjqrLists.Add(yjqr);
                                //Guid YJ_EXEC_ID = ettOrdExec.ID;
                                //Guid YJ_APP_ID = yjsq.YJSQID;
                                //Guid YJ_ORDER_ID = ettOrd.ORDER_ID;
                                //decimal YJ_JE = yjsq.JE;

                                //Guid NEWYJSQID = Guid.Empty;
                                //int iSqRet = -1;
                                //string strSqMsg = "";
                                //yj_zysq_qrjl(YJ_ORDER_ID, YJ_EXEC_ID, YJ_APP_ID, YJ_JE, DEPTID, EXECBOOKDATE, EXEUSER, 1, EXECBOOKDATE, 0, "", out NEWYJSQID, out iSqRet, out strSqMsg, 0);
                                //if (iSqRet != 0)
                                //{
                                //    iOutPut = 1;//return
                                //    iret = -1;
                                //    strMsg = BED_NO + " ������ " + PAT_NAME + " ҽ��ȷ�ѳ���:" + strSqMsg;
                                //    return iOutPut;
                                //}
                            }

                            #endregion
                        }
                    }

                    #endregion
                }

                #endregion

                return iOutPut;
            }
            catch (Exception ex)
            {
                throw new Exception(execNow.ToString("yyyy-MM-dd") + " ִ�и���ҽ��ʱerr��" + ex.Message);
            }
        }
     */

    #endregion
}
