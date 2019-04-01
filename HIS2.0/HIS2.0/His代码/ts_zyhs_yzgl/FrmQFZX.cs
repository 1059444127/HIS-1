using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrasenFrame.Forms;
using ts_zyhs_classes;
using TrasenClasses.GeneralClasses;
using TrasenFrame.Classes;
using TrasenClasses.GeneralControls;

namespace ts_zyhs_yzgl
{
    public partial class FrmQFZX : Form
    {
        public FrmQFZX()
        {
            InitializeComponent();
        }

        ������Ϣ.PatientInfo brxx = new ������Ϣ.PatientInfo();
        private BaseFunc myFunc = new BaseFunc();

        string sPaint = "", sPaintPS = "", sPaintWZX = "", sName = "";
        int max_len0 = 0, max_len1 = 0, max_len2 = 0;//���ҽ������,���ҽ������(��������λ��),���������λ����		
        private void FrmQFZX_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.myDataGrid.TableStyles[0].GridColumnStyles.Clear();
            string[] GrdMappingName ={ "����", "סԺ��", "����", "INPATIENT_ID", "Baby_ID", "DEPT_ID", "isMY", "IN_DATE" };
            string[] GrdHeaderText = new string[] {"����", "סԺ��", "����", "", "", "", "", "" };
            int[] GrdWidth ={ 5,9, 8, 0, 0, 0, 0 ,0};
            int[] Alignment ={ 1,1, 0, 0, 0, 0, 0 ,0};
            int[] ReadOnly ={ 0,0, 0, 0, 0, 0, 0, 0};
            BRData();
            myFunc.InitGrid(GrdMappingName,GrdHeaderText, GrdWidth, Alignment, ReadOnly, this.myDataGrid);

            DataTable myTb = (DataTable)myDataGrid.DataSource;


            this.myDataGrid1.TableStyles[0].GridColumnStyles.Clear();
           
            string[] GrdMappingName1 ={ "status_flag","Order_ID","Group_ID","Num","Unit","dwlx","Order_Usage","frequency","Dropsper","Dosage",
										"ntype","exec_dept","day1","second1","day2","second2", "AUDITING_USER","AUDITING_USER1",
										"order_euser","order_euser1","item_code","xmly",     
										"ѡ",
										"������","��ʱ��","ҽ������","����","����ҽ��","����ת��","�����˶�",
										"ͣ����","ͣʱ��","ͣ��ҽ��","ͣ��ת��","ͣ���˶�",
										"ִ��ʱ��","ִ����","ִ�п���","����ʱ��","���ͻ�ʿ",//"ִ��ʱ��","ִ����",
										"ps_flag","ps_orderid","ps_user","wzx_flag","P","hoitem_id","isprintypgg"};//isggdy add by zouchihua 2011-11-30
 
            int[] GrdWidth1 ={0,0,0,0,0,0,0,0,0,0,
									 0,0,0,0,0,0,0,0,
									 0,0,0,0,
									 2,
									 6,6,50,6,8,8,0,//�����˶Բ���ʾ
									 6,6,8,8,0,//ͣ���˶Բ���ʾ
									 15,8,8,15,8,
									 0,0,0,0,2,0,0};//isggwide
            int[] Alignment1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };
            int[] ReadOnly1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1};
            this.InitGridYZ(GrdMappingName1, GrdWidth1, Alignment1, ReadOnly1, this.myDataGrid1);

            if (myTb == null || myTb.Rows.Count == 0)
            {
                //if (rbTszl.Checked == false)
                //{
                //    rbTszl.Checked = true;
                //    rb_Click(null, null);
                //    return;
                //}
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClassStatic.Current_BinID = Guid.Empty;
                ClassStatic.Current_BabyID = 0;
                ClassStatic.Current_DeptID = 0;
                ClassStatic.Current_isMYTS = 0;
                ClassStatic.Current_isMY = 0;

            }
        }

        private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        {
            myDataGrid.TableStyles[0].AllowSorting = false; //����������

            DataGridEnableTextBoxColumn aColumnTextColumn;
            for (int i = 0; i <= GrdMappingName.Length - 1; i++)
            {
                if (GrdMappingName[i].ToString().Trim() == "ѡ")
                {
                    DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
                    myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
                }
                else
                {
                    aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
                    aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
                    myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
                    myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
                    myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
                    myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
                    if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
                }
            }
        }
        private void BRData()
        {
            //�����ò��������в���
            string sql = @"select BED_NO as ����,INPATIENT_NO as סԺ��,NAME as ����,INPATIENT_ID,BABY_ID,DEPT_ID,ISMY,IN_DATE from VI_ZY_VINPATIENT_BED where WARD_ID='" + FrmMdiMain.CurrentDept.WardId + "'and flag in(1,3,4)  order by BED_NO";
            DataTable dt= FrmMdiMain.Database.GetDataTable(sql);
            if (dt == null) return;
          
            for (int i =dt.Rows.Count - 1; i >= 0; i--)
            {
                //�������˷�����Ϣ
                DataRow dr=dt.Rows[i];
                DataTable dtf= brxx.GetInpatientInfo(new Guid(dr["INPATIENT_ID"].ToString()), Convert.ToInt64(dr["BABY_ID"]), Convert.ToInt32(dr["ISMY"]));
                if(dtf==null) continue;
                decimal _ye =Convert.ToDecimal(dtf.Rows[0]["YE"].ToString() == "" ? "0" : dtf.Rows[0]["YE"].ToString());
                if (_ye < myFunc.GetPatMinExecYE(new Guid(dr["INPATIENT_ID"].ToString())))
                {
                    // ���ӶԲ�����Ժʱ����ж�
                    //7072������Ժ��Сʱ�����Ƿ�ѣ�0=�������ƣ�
                    int _hour = Convert.ToInt32(new SystemCfg(7072, InstanceForm.BDatabase).Config);
                    DateTime _rysj = Convert.ToDateTime(dr["IN_DATE"].ToString());
                    if (_rysj.AddHours(_hour) <= DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase))
                    {
                        //Ƿ�Ѳ���
                    }else
                    {    //�Ƴ���Ƿ�ѵĲ���
                        dt.Rows.RemoveAt(i);
                    }
                }
                else
                {    //�Ƴ���Ƿ�ѵĲ���
                    dt.Rows.RemoveAt(i);
                }

            }
            this.myDataGrid.DataSource = dt;
        }

        private int GetMNGType()
        {
            switch (this.tabControl1.SelectedTab.Text.Trim())
            {
                case "��Ч����":
                    return 0;
                case "��Ч�����˵�":
                    return 2;
                
                default:
                    return 0;
            }
        }
        private void ShowDate()
        {
            //5=����������
            //0-����  1,5-����  2-�����˵�  3-��ʱ�˵�  ��MNGTYPE��
            int nType = this.GetMNGType();
            int nKind = this.tabControl1.SelectedTab.Text.Trim().IndexOf("��Ч", 0, this.tabControl1.SelectedTab.Text.Trim().Length) >= 0 ? 0 : 1;

            DataTable myTb = new DataTable();
      
            myTb = myFunc.GetBinOrdrs("", ClassStatic.Current_BinID, ClassStatic.Current_BabyID, nType, nKind, 0, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), InstanceForm.BCurrentDept.WardId,  0);

            DataView dv = myTb.DefaultView;
            dv.RowFilter = "status_flag = 4";
            DataTable newmyTb = dv.ToTable();
         
            DataColumn col = new DataColumn();
            col.DataType = System.Type.GetType("System.Boolean");
            col.AllowDBNull = true;
            col.ColumnName = "ѡ";
            col.DefaultValue = false;
            newmyTb.Columns.Add(col);
    
            CheckGrdData(newmyTb, nType);
            if(newmyTb.Rows.Count==0)
               this.myDataGrid1.DataSource = newmyTb;
        }
        private void CheckGrdData(DataTable myTb, int nType)
        {
            if (myTb.Rows.Count == 0) return;

            string sNum = "";
            int i = 0, iDay = 0, iTime = 0;                //��¼��һ����ʾ���ں�ʱ����к�
            int l = 0, group_rows = 1;    //ͬ���е�ҽ������
            int ii = 0;
            this.sPaint = "";
            this.sPaintPS = "";
            this.sPaintWZX = "";

            #region �������
            max_len0 = 0;
            max_len1 = 0;
            max_len2 = 0;
            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                sNum = this.GetNumUnit(myTb, i);
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                //�ҽ��
                max_len0 = max_len0 > l ? max_len0 : l;
                if (sNum.Trim() != "")
                {
                    //�ҽ��
                    max_len1 = max_len1 > l ? max_len1 : l;
                    l = System.Text.Encoding.Default.GetByteCount(sNum);
                    //���λ
                    max_len2 = max_len2 > l ? max_len2 : l;
                }
            }
            #endregion

            for (i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                #region ��ʾ����ʱ��
                myTb.Rows[i]["������"] = myFunc.getDate(myTb.Rows[i]["������"].ToString().Trim(), myTb.Rows[i]["day1"].ToString().Trim());
                myTb.Rows[i]["��ʱ��"] = myFunc.getTime(myTb.Rows[i]["��ʱ��"].ToString().Trim(), myTb.Rows[i]["second1"].ToString().Trim());
                myTb.Rows[i]["ͣ����"] = myFunc.getDate(myTb.Rows[i]["ͣ����"].ToString().Trim(), myTb.Rows[i]["day2"].ToString().Trim());
                myTb.Rows[i]["ͣʱ��"] = myFunc.getTime(myTb.Rows[i]["ͣʱ��"].ToString().Trim(), myTb.Rows[i]["second2"].ToString().Trim());
                if (i != 0)
                {
                    if (myTb.Rows[i]["������"].ToString().Trim() == myTb.Rows[iDay]["������"].ToString().Trim())
                    {
                        myTb.Rows[i]["������"] = System.DBNull.Value;
                    }
                    else
                    {
                        iDay = i;
                    }
                    // ʱ����ͬ�����ڲ�ͬҪ��ʾʱ�� Modify by zouchihua 2012-11-14
                    if (myTb.Rows[i]["��ʱ��"].ToString().Trim() == myTb.Rows[iTime]["��ʱ��"].ToString().Trim() && (myTb.Rows[i]["������"].ToString().Trim() == myTb.Rows[iTime]["������"].ToString().Trim() || myTb.Rows[i]["������"].ToString().Trim() == ""))
                    {
                        myTb.Rows[i]["��ʱ��"] = System.DBNull.Value;
                    }
                    else
                    {
                        iTime = i;
                    }
                }
                #endregion
                #region ��ʾҽ������

                //��ҽ�����ݡ�+= ��ҽ�����ݡ�+���ո�+��������λ��
                l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i]["ҽ������"].ToString().Trim());
                sNum = this.GetNumUnit(myTb, i);
                if (sNum.Trim() != "")
                    myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(max_len1 - l) + sNum;//��һ���ո� Modify by zouchiua 2012-6-29
                else
                    myTb.Rows[i]["ҽ������"] = myTb.Rows[i]["ҽ������"].ToString().Trim() + myFunc.Repeat_Space(max_len0 - l) + sNum;

                if ((i == myTb.Rows.Count - 1) || (i != myTb.Rows.Count - 1 && myTb.Rows[i]["Group_id"].ToString().Trim() != myTb.Rows[i + 1]["Group_id"].ToString().Trim()))
                {
                    //��������һ�л��к���һ�е�ҽ���Ų�һ��

                    //ͬ���е�һ��ҽ���ġ�ҽ�����ݡ�+=���÷���+�����١�+ ��Ƶ�ʡ�
                    l = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1]["ҽ������"].ToString().Trim());
                    if (sNum.Trim() != "")
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len1 + max_len2 - l + 4);//Modify By Tany 2005-01-25			
                    else
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(max_len2 + 4);//Modify By Tany 2005-01-25			
                    if (myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Order_Usage"].ToString().Trim();
                    if (myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim() != "") myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["Dropsper"].ToString().Trim();// +"��/min"; Modify by zouchihua 2012-4-27��ȥ��
                    if (myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != ""
                        && myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim() != "1"
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["frequency"].ToString().Trim();
                    int cd = 0;
                    //add by zouchihua 2012-6-23 ��������
                    if ((nType == 1 || nType == 5) && myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() != ""
                        && int.Parse(myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim()) > 1
                        //						&&(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])<4 
                        //						    ||(Convert.ToInt16(myTb.Rows[i-group_rows+1]["nType"])>=4 && myTb.Rows[i-group_rows+1]["frequency"].ToString().Trim().ToUpper() !="QD"))
                        )
                    {
                        cd = System.Text.Encoding.Default.GetByteCount(" " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��");
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += " " + myTb.Rows[i - group_rows + 1]["ts"].ToString().Trim() + "��" + myFunc.Repeat_Space(6 - cd);
                    }
                    else
                    {
                        myTb.Rows[i - group_rows + 1]["ҽ������"] += myFunc.Repeat_Space(6 - cd);
                    }
                    int len = 0;
                    for (int x = 0; x < group_rows; x++)
                    {

                        #region//������ʾ
                        if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i - group_rows + 1 + x]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i - group_rows + 1 + x]["zsl"].ToString().Trim() != "")//�����ҩƷ
                        {
                            string ssNum = "";

                            if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == Convert.ToInt64(myTb.Rows[i - group_rows + 1 + x]["zsl"]))
                            {
                                ssNum = String.Format("{0:F0}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                                if (Convert.ToDecimal(myTb.Rows[i - group_rows + 1 + x]["zsl"]) == 0)
                                    ssNum = "";
                            }
                            else
                            {
                                ssNum = String.Format("{0:F3}", myTb.Rows[i - group_rows + 1 + x]["zsl"]).Trim();
                            }
                            if (x == 0)
                            {
                                len = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                            else
                            {
                                int blen = System.Text.Encoding.Default.GetByteCount(myTb.Rows[i - group_rows + 1 + x]["ҽ������"].ToString());
                                myTb.Rows[i - group_rows + 1 + x]["ҽ������"] += myFunc.Repeat_Space(len - blen) + " " + ssNum + myTb.Rows[i - group_rows + 1 + x]["zsldw"].ToString().Trim();
                            }
                        }
                        #endregion
                    }

                    //���һ���е�ҽ����������1
                    if (group_rows != 1)
                    {
                        //[3i2]0 �����������һ��ҽ�������һ��������ҽ��������ҽ����status_flag=0
                        this.sPaint += "[" + i.ToString() + "i" + group_rows.ToString().Trim() + "]" + myTb.Rows[i]["status_flag"].ToString().Trim();
                    }

                    ii = i - group_rows + 1;

                    group_rows = 1;
                }
                else
                {
                    try
                    {

                        //������ǵ�һ�У��ұ��к���һ�е�ҽ����һ��
                        myTb.Rows[i]["����ҽ��"] = System.DBNull.Value;
                        myTb.Rows[i]["����ת��"] = System.DBNull.Value;
                        myTb.Rows[i]["�����˶�"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ����"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣʱ��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ��ҽ��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ��ת��"] = System.DBNull.Value;
                        myTb.Rows[i]["ͣ���˶�"] = System.DBNull.Value;
                        if (myTb.Rows[i]["ntype"].ToString() == "1" || myTb.Rows[i]["ntype"].ToString() == "2" || myTb.Rows[i]["ntype"].ToString() == "3") group_rows += 1;

                        ii = i;
                    }
                    catch (System.Data.OleDb.OleDbException err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                    catch (System.Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
                #region//������ʾ
                //if ((nType == 1 || nType == 5) && Convert.ToInt32(myTb.Rows[i]["ntype"].ToString().Trim()) < 4 && myTb.Rows[i]["zsl"].ToString().Trim() != "")//�����ҩƷ
                //{
                //    string ssNum = "";

                //    if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == Convert.ToInt64(myTb.Rows[i]["zsl"]))
                //    {
                //        ssNum = String.Format("{0:F0}", myTb.Rows[i]["zsl"]).Trim();
                //        if (Convert.ToDecimal(myTb.Rows[i]["zsl"]) == 0)
                //            ssNum = "";
                //    }
                //    else
                //    {
                //        ssNum = String.Format("{0:F3}", myTb.Rows[i]["zsl"]).Trim();
                //    }
                //    myTb.Rows[i]["ҽ������"] += " " + ssNum + myTb.Rows[i]["zsldw"].ToString().Trim();
                //}
                #endregion
                #endregion

                #region ��ʾδִ��
                if (Convert.ToInt16(myTb.Rows[i]["wzx_flag"]) > 0)
                {
                    this.sPaintWZX += "i" + i.ToString() + "X";
                }
                #endregion

                #region ��ʾƤ��
                //����
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 2 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "+" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]";
                }
                //����
                if (Convert.ToInt16(myTb.Rows[ii]["ps_flag"]) == 1 &&
                    (myTb.Rows[ii]["ҽ������"].ToString().Trim().IndexOf("Ƥ��", 0) > 0
                    || myTb.Rows[ii]["ҽ������"].ToString().Trim().ToUpper().IndexOf("AST", 0) > 0))
                {
                    this.sPaintPS += "[" + ii.ToString() + "-" + System.Text.Encoding.Default.GetByteCount(myTb.Rows[ii]["ҽ������"].ToString().Trim()) + "]" + myTb.Rows[ii]["status_flag"].ToString().Trim();
                }
                #endregion
            }
            this.myDataGrid1.DataSource = myTb;
        }

        //���ء�����+��λ��������Ƿ���ʾС��
        private string GetNumUnit(DataTable myTb, int i)
        {
            string sNum = "";
            if (Convert.ToDecimal(myTb.Rows[i]["Num"]) == Convert.ToInt64(myTb.Rows[i]["Num"]))
            {
                sNum = String.Format("{0:F0}", myTb.Rows[i]["Num"]).Trim();
            }
            else
            {
                sNum = String.Format("{0:F3}", myTb.Rows[i]["Num"]).Trim();
            }
            //Modify By Tany 2004-10-27
            if ((sNum == "1" && myTb.Rows[i]["ntype"].ToString().Trim() != "1"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "2"
                && myTb.Rows[i]["ntype"].ToString().Trim() != "3"
                && GetMNGType() != 2
                && GetMNGType() != 3)
                || sNum == "0" || sNum == "")
                return "";
            else
                return "" + sNum + myTb.Rows[i]["Unit"].ToString().Trim();//Modify by zouchihua 2012-6-29 ��һ���ո�
        }
        private void SetEnableValues(object sender, DataGridEnableEventArgs e)
        {
            //��ɫ������ҽ����״̬ 
            int ColorCol = 0;		 //״̬��
            e.BackColor = Color.White;
            if (this.myDataGrid1[e.Row, ColorCol].ToString() != "")
            {
                if (Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) > 1 && Convert.ToInt16(this.myDataGrid1[e.Row, ColorCol]) < 5)   //�����
                {
                    e.ForeColor = Color.Blue;
                    //ѡ����
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
            }
           
            //�Ѿ�ִ�е�ҽ����ʾ��ɫ Modify By Tany 2007-10-27
            if (this.myDataGrid1[e.Row, 38].ToString() != "")
            {
                if (Convert.ToDateTime(this.myDataGrid1[e.Row, 38]) >= Convert.ToDateTime(DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString("yyyy-MM-dd")))
                {
                    e.ForeColor = Color.Red;
                    if (this.myDataGrid1[e.Row, 22].ToString() == "True") e.BackColor = Color.GreenYellow;
                }
            }
        }

        //private void InitGridYZ(string[] GrdMappingName, int[] GrdWidth, int[] Alignment, int[] ReadOnly, DataGridEx myDataGrid)
        //{
        //    myDataGrid.TableStyles[0].AllowSorting = false; //����������

        //    DataGridEnableTextBoxColumn aColumnTextColumn;
        //    for (int i = 0; i <= GrdMappingName.Length - 1; i++)
        //    {
        //        if (GrdMappingName[i].ToString().Trim() == "ѡ" || GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //        {
        //            DataGridEnableBoolColumn myBoolCol = new DataGridEnableBoolColumn(i);
        //            if (GrdMappingName[i].ToString().Trim() == "P" || GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //            {
        //                myBoolCol.AllowNull = false;
        //                myBoolCol.TrueValue = (short)1;
        //                myBoolCol.FalseValue = (short)0;
        //                myBoolCol.NullValue = (short)0;
        //            }
        //            myBoolCol.CheckCellEnabled += new DataGridEnableBoolColumn.EnableCellEventHandler(SetEnableValues);
        //            myDataGrid.TableStyles[0].GridColumnStyles.Add(myBoolCol);
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].Width = GrdWidth[i] == 0 ? 0 : (GrdWidth[i] * 7 + 2);
        //            //add by zouchihua 2011-11-30
        //            if (GrdMappingName[i].ToString().Trim() == "isprintypgg")
        //            {
        //                myBoolCol.AllowNull = false;
        //                myBoolCol.TrueValue = 1;
        //                myBoolCol.FalseValue = 0;
        //                myBoolCol.NullValue = 0;
        //                myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = "��ӡ���";
        //            }
        //        }
        //        else
        //        {
        //            aColumnTextColumn = new DataGridEnableTextBoxColumn(i);
        //            aColumnTextColumn.CheckCellEnabled += new DataGridEnableTextBoxColumn.EnableCellEventHandler(SetEnableValues);
        //            myDataGrid.TableStyles[0].GridColumnStyles.Add(aColumnTextColumn);
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].MappingName = GrdMappingName[i].ToString();
        //            myDataGrid.TableStyles[0].GridColumnStyles[i].HeaderText = GrdMappingName[i].ToString().Trim();
        //            myFunc.InitGrid_Sub(i, GrdMappingName, GrdWidth, Alignment, myDataGrid);
        //            if (ReadOnly[i] != 0) myDataGrid.TableStyles[0].GridColumnStyles[i].ReadOnly = true;
        //        }
        //    }
        //}

        private void myDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataTable myTb1 = (DataTable)myDataGrid.DataSource;
            if (myTb1 == null || myTb1.Rows.Count == 0)
            {
                return;
            }

            int nrow = this.myDataGrid.CurrentCell.RowNumber;
            this.myDataGrid.Select(nrow);
            //Modify By Tany 2010-01-29 �д�����ʾ���ţ�û�д�����ʾסԺ��
            string bz = "";
            if (myTb1.Columns.Contains("����"))
            {
                bz = "(" + Convert.ToString(myTb1.Rows[nrow]["����"]).Trim() + "��)";
            }
            else if (myTb1.Columns.Contains("סԺ��"))
            {
                bz = "(" + Convert.ToString(myTb1.Rows[nrow]["סԺ��"]).Trim() + ")";
            }
            this.sName = Convert.ToString(myTb1.Rows[nrow]["����"]).Trim() + bz;
            ClassStatic.Current_BinID = new Guid(myTb1.Rows[nrow]["inpatient_id"].ToString());
            ClassStatic.Current_BabyID = Convert.ToInt64(myTb1.Rows[nrow]["baby_id"]);
            ClassStatic.Current_DeptID = Convert.ToInt64(myTb1.Rows[nrow]["dept_id"]);
            ClassStatic.Current_isMY = Convert.ToInt16(myTb1.Rows[nrow]["ismy"]);

       
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb != null)
                myTb.Rows.Clear();
                this.myDataGrid1.DataSource = myTb;
                this.ShowDate();
            

           
        }

        private void buttzx_Click(object sender, EventArgs e)
        {
            bool _qfExeCurDeptOrder = false;//Ƿ���Ƿ��ܹ����ͱ�����ҽ��

            if (ClassStatic.Current_BinID == null || ClassStatic.Current_BinID == Guid.Empty)
            {
                MessageBox.Show("û���ҵ�������Ϣ��������ȷ�ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            decimal _orderfee = 0;
            int GroupID = -999;
            int iMNGType = 0;
            int iSelectRows = 0;
            DataTable myTb = (DataTable)myDataGrid1.DataSource;
            DateTime ExecDate = Convert.ToDateTime(Convertor.IsNull(((Button)sender).Tag, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase).ToString()));

            #region ��Ч���ж�
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    iSelectRows += 1;
                }
            }

            if (iSelectRows == 0)
            {
                MessageBox.Show(this, "�Բ���û��ѡ��ҽ����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            iMNGType = GetMNGType();
            progressBar1.Maximum = myTb.Rows.Count;
            progressBar1.Value = 0;
            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                //�����ѡ����
                if (myTb.Rows[i]["ѡ"].ToString() == "True")
                {
                    //����������һ��ҽ����ͬ����ִ��
                    if (GroupID == Convert.ToInt32(myTb.Rows[i]["Group_ID"]))
                    {
                        if (_orderfee > 0)
                        {
                            myTb.Rows[i]["ѡ"] = false;
                        }
                        continue;
                    }

                    GroupID = Convert.ToInt32(myTb.Rows[i]["Group_ID"]);
                  
                    _orderfee = myFunc.GetOrderFee(ClassStatic.Current_BinID, ClassStatic.Current_BabyID, iMNGType, GroupID, ExecDate, ExecDate);
                    progressBar1.Value += 1;

                    if(_orderfee >0)
                    {
                        myTb.Rows[i]["ѡ"] = false;
                    }
                }
            }
            try
            {
                string[] rtnSql = ts_zyhs_classes.BaseFunc.GetBrzt(ClassStatic.Current_BinID);
                int BrJgbm = Convert.ToInt32(rtnSql[1]);
                //����
                myFunc.ExecOrdersWithData(this.myDataGrid1, iMNGType, 1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                //myFunc.ExecOrdersWithData(this.myDataGrid1, 2, 1, this.progressBar1, ClassStatic.Current_BinID, Convert.ToInt64(ClassStatic.Current_BabyID), ExecDate, ExecDate, _qfExeCurDeptOrder, BrJgbm);
                MessageBox.Show("������ϣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ˢ�½���
                this.tabControl1_SelectedIndexChanged(sender, e);
            }
            catch (Exception err)
            {
                SystemLog _systemErrLog = new SystemLog(-1, InstanceForm.BCurrentDept.DeptId, InstanceForm.BCurrentUser.EmployeeId, "�������", "ҽ��ִ�д���" + err.Message + "  Source��" + err.Source, DateManager.ServerDateTimeByDBType(InstanceForm.BDatabase), 1, "��������" + System.Environment.MachineName, 39);
                _systemErrLog.Save();
                _systemErrLog = null;

                MessageBox.Show("����" + err.Message + "\n" + "Source��" + err.Source + "\n\n�����Ѿ��ع������������ִ�У�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
              
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ShowDate();  
        }

        private void myDataGrid1_Paint(object sender, PaintEventArgs e)
        {
            DataTable myTb = (DataTable)this.myDataGrid1.DataSource;
            if (myTb == null) return;
            if (myTb.Rows.Count == 0) return;

            int i = 0;
            int yDelta = this.myDataGrid1.GetCellBounds(i, 0).Height + 1;
            int y = this.myDataGrid1.GetCellBounds(i, 0).Top + 2;

            int index_start = 0, index_i = 0, index_p = 0, index_end = 0;
            int start_row = 0, start_point = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[this.myDataGrid1.DataSource, this.myDataGrid1.DataMember];

            while (y < this.myDataGrid1.Height - yDelta && i < cm.Count)
            {
                y += yDelta;

                //δִ��
                index_start = this.sPaintWZX.IndexOf("i" + i.ToString() + "X", 0, this.sPaintWZX.Trim().Length);
                if (index_start >= 0)
                {
                    e.Graphics.DrawString("δִ��", this.myDataGrid1.Font, new SolidBrush(Color.Red), 650, y - yDelta);
                }

                //Ƥ��+
                index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "+", 0, this.sPaintPS.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPS.IndexOf("+", index_start, this.sPaintPS.Trim().Length - index_start);
                    index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                    start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    e.Graphics.DrawString("(+)", this.myDataGrid1.Font, new SolidBrush(Color.Red), start_point, y - yDelta);

                }

                //Ƥ��-
                index_start = this.sPaintPS.IndexOf("[" + i.ToString() + "-", 0, this.sPaintPS.Trim().Length);
                if (index_start >= 0)
                {
                    index_p = this.sPaintPS.IndexOf("-", index_start, this.sPaintPS.Trim().Length - index_start);
                    index_end = this.sPaintPS.IndexOf("]", index_p, this.sPaintPS.Trim().Length - index_p);
                    start_point = 119 + Convert.ToInt16(this.sPaintPS.Substring(index_p + 1, index_end - index_p - 1)) * 6;
                    switch (this.sPaintPS.Substring(index_end + 1, 1))
                    {
                        case "1":  //δ���
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Black), start_point, y - yDelta);
                            break;
                        case "5":  //��ֹͣ
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Gray), start_point, y - yDelta);
                            break;
                        default: //�����
                            e.Graphics.DrawString("(-)", this.myDataGrid1.Font, new SolidBrush(Color.Blue), start_point, y - yDelta);
                            break;
                    }

                }

                //����
                index_start = this.sPaint.IndexOf("[" + i.ToString() + "i", 0, this.sPaint.Trim().Length);
                if (index_start >= 0)
                {
                    index_i = index_start + i.ToString().Trim().Length + 1;
                    index_end = this.sPaint.IndexOf("]", index_i, this.sPaint.Trim().Length - index_i);
                    start_row = Convert.ToInt16(this.sPaint.Substring(index_i + 1, index_end - index_i - 1));
                    if (this.max_len1 == 0) start_point = 119 + (this.max_len0 + 4) * 6;
                    else start_point = 119 + (this.max_len1 + this.max_len2 + 4) * 6;
                    switch (this.sPaint.Substring(index_end + 1, 1))
                    {
                        case "1":  //δ���
                            e.Graphics.DrawLine(System.Drawing.Pens.Black, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        case "5":  //��ֹͣ
                            e.Graphics.DrawLine(System.Drawing.Pens.Gray, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                        default: //�����
                            e.Graphics.DrawLine(System.Drawing.Pens.Blue, start_point, y - start_row * yDelta, start_point, y - 5);
                            break;
                    }
                }
                i++;
            }
        }

        private void btȫѡ_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["ѡ"] = true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void bt��ѡ_Click(object sender, EventArgs e)
        {
            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["status_flag"].ToString().Trim() == "1") continue;
                this.myDataGrid1.CurrentCell = new DataGridCell(i, 0);
                myTb.Rows[i]["ѡ"] = myTb.Rows[i]["ѡ"].ToString() == "True" ? false : true;
            }
            this.myDataGrid1.DataSource = myTb;
        }

        private void myDataGrid1_Click(object sender, EventArgs e)
        {
            int nrow, ncol;
            nrow = this.myDataGrid1.CurrentCell.RowNumber;
            ncol = this.myDataGrid1.CurrentCell.ColumnNumber;

            //�ύ��������
            if (ncol > 0 && nrow > 0) this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol - 1);
            this.myDataGrid1.CurrentCell = new DataGridCell(nrow, ncol);

            DataTable myTb = ((DataTable)this.myDataGrid1.DataSource);
            if (myTb == null) return;
            if (myTb.Rows.Count <= 0) return;
            bool isResult = myTb.Rows[nrow]["ѡ"].ToString() == "True" ? false : true;
            myTb.Rows[nrow]["ѡ"] = isResult;

            for (int i = 0; i <= myTb.Rows.Count - 1; i++)
            {
                if (myTb.Rows[i]["Group_id"].ToString().Trim() == myTb.Rows[nrow]["Group_id"].ToString().Trim()
                    && myTb.Rows[i]["ѡ"].ToString() != isResult.ToString())
                {
                    this.myDataGrid1.CurrentCell = new DataGridCell(i, ncol);
                    myTb.Rows[i]["ѡ"] = isResult;
                    //this.myDataGrid1.CurrentCell=new DataGridCell(i,ncol);	
                }
            }

            this.myDataGrid1.DataSource = myTb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = PubStaticFun.WaitCursor();
            FrmQFZX_Load(null,null);
            Cursor.Current = Cursors.Default;
        }


    }
}