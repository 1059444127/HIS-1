using System;
using System.Collections.Generic;
using System.Text;
using TrasenClasses.GeneralClasses;

namespace ts_yp_kjbb
{
    public static class Reports
    {
        public static List<ReportInfo> ReportList
        {
            get
            {
                List<ReportInfo> list = new List<ReportInfo>();
                list.Add(new ReportInfo("��������ܱ�(��һ)", "YP_{0}ҩƷ��������ܱ�{1}.grf", "sp_yp_tj_jxchzb_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 ��Ժ���ֿ������ӡ��ʽ
                //list.Add(new ReportInfo("��������ܱ�(��һ)(��Ժ)", "YP_{0}ҩƷ��������ܱ�_��Ժ.grf", "sp_yp_tj_jxchzb_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(��һ)(���)", "YP_{0}ҩƷ��������ܱ�_���.grf", "sp_yp_tj_jxchzb_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(��һ)(�ȼ��)", "YP_{0}ҩƷ��������ܱ�_�ȼ��.grf", "sp_yp_tj_jxchzb_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(��һ)(����)", "YP_{0}ҩƷ��������ܱ�_����.grf", "sp_yp_tj_jxchzb_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));

                list.Add(new ReportInfo("��������ܱ�(���)(����ҩƷ����)", "YP_{0}ҩƷ��������ܱ�(��ҩƷ����){1}.grf", "sp_yp_tj_jxchzb_yplx_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 ��Ժ���ֿ������ӡ��ʽ
                //list.Add(new ReportInfo("��������ܱ�(���)(����ҩƷ����)(��Ժ)", "YP_{0}ҩƷ��������ܱ�(��ҩƷ����)_��Ժ.grf", "sp_yp_tj_jxchzb_yplx_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(���)(����ҩƷ����)(���)", "YP_{0}ҩƷ��������ܱ�(��ҩƷ����)_���.grf", "sp_yp_tj_jxchzb_yplx_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(���)(����ҩƷ����)(�ȼ��)", "YP_{0}ҩƷ��������ܱ�(��ҩƷ����)_�ȼ��.grf", "sp_yp_tj_jxchzb_yplx_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(���)(����ҩƷ����)(����)", "YP_{0}ҩƷ��������ܱ�(��ҩƷ����)_����.grf", "sp_yp_tj_jxchzb_yplx_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));


                list.Add(new ReportInfo("��������ܱ�(����) (�ϲ�ҩ��������ҩƷ����)", "YP_{0}ҩƷ��������ܱ�(�ϲ�ҩ��������ҩƷ����){1}.grf", "sp_yp_tj_jxchzb_kshb_yq", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //Modify By Tany 2015-05-28 ��Ժ���ֿ������ӡ��ʽ
                //list.Add(new ReportInfo("��������ܱ�(����) (�ϲ�ҩ��������ҩƷ����)(��Ժ)", "YP_{0}ҩƷ��������ܱ�(�ϲ�ҩ��������ҩƷ����)_��Ժ.grf", "sp_yp_tj_jxchzb_kshb_ny", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(����) (�ϲ�ҩ��������ҩƷ����)(���)", "YP_{0}ҩƷ��������ܱ�(�ϲ�ҩ��������ҩƷ����)_���.grf", "sp_yp_tj_jxchzb_kshb_hh", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(����) (�ϲ�ҩ��������ҩƷ����)(�ȼ��)", "YP_{0}ҩƷ��������ܱ�(�ϲ�ҩ��������ҩƷ����)_�ȼ��.grf", "sp_yp_tj_jxchzb_kshb_sjj", "ts_yp_kjbb.Condiction.UCCondictionA"));
                //list.Add(new ReportInfo("��������ܱ�(����) (�ϲ�ҩ��������ҩƷ����)(����)", "YP_{0}ҩƷ��������ܱ�(�ϲ�ҩ��������ҩƷ����)_����.grf", "sp_yp_tj_jxchzb_kshb_hq", "ts_yp_kjbb.Condiction.UCCondictionA"));


                list.Add(new ReportInfo("�����ϸͳ��", "YP_{0}ҩƷ�����ϸ��.grf", "sp_yp_tj_rkmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("������ͳ��", "YP_{0}ҩƷ�����ܱ�.grf", "sp_yp_tj_rkhztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("������ϸͳ��", "YP_{0}ҩƷ������ϸ��.grf", "sp_yp_tj_ckmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("�������ͳ��", "YP_{0}ҩƷ������ܱ�.grf", "sp_yp_tj_ckhztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("����������ϸͳ��", "YP_{0}����������ϸ��.grf", "sp_yp_tj_qtmxtj", "ts_yp_kjbb.Condiction.UCCondictionB"));
                list.Add(new ReportInfo("�������ݻ���ͳ��", "YP_{0}�������ݻ��ܱ�.grf", "sp_yp_tj_qthztj", "ts_yp_kjbb.Condiction.UCCondictionB"));

                list.Add(new ReportInfo("ҩƷ��ϸ������", "YP_{0}ҩƷ��ϸ������.grf", "sp_yp_tj_ypmxflz", "ts_yp_kjbb.Condiction.UCCondictionYP"));

                //list.Add( new ReportInfo( "����Һ����ͳ��" , "YP_����Һ����ͳ��.grf" , "sp_yp_tj_dsyhz" , "ts_yp_kjbb.Condiction.UCCondictionC" ) );

                list.Add(new ReportInfo("����Һ����ͳ��", "YP_����Һ����ͳ��.grf", "sp_yp_tj_dsyhz", "ts_yp_kjbb.Condiction.UCCondictionKS"));
                list.Add(new ReportInfo("ҩƷ��ϸ����������", "YP_{0}ҩƷ��ϸ����������.grf", "sp_yp_tj_ypmxflz_new", "ts_yp_kjbb.Condiction.UCCondictionYP"));
                return list;
            }
        }
    }

    public sealed class ReportParameterDefine
    {
        public const string �ⷿ���� = "�ⷿ����";
        public const string �ⷿ���� = "�ⷿ����";
        public const string �۸�ͳ�Ʒ�ʽ = "�۸�ͳ�Ʒ�ʽ";
        public const string ͳ����� = "ͳ�����";
        public const string ͳ���·� = "ͳ���·�";
        public const string ͳ��ʱ�� = "ͳ��ʱ��";
        public const string ҩƷ���� = "ҩƷ����";
        public const string ҩƷ��� = "ҩƷ���";
        public const string ҩƷ��λ = "ҩƷ��λ";
        public const string ҩƷ���� = "ҩƷ����";
        public const string ͳ�ƿ��� = "ͳ�ƿ���";
        //Add By Tany 2016-03-01
        public const string Ժ������ = "Ժ������";
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct MatchFieldPairType
    {
        public grproLib.IGRField grField;
        public int MatchColumnIndex;
    }

    public class ReportInfo
    {

        public ReportInfo()
        {
        }
        public ReportInfo(string name, string template, string storeProcudeName, string condictionControlName)
        {
            _ReportName = name;
            _TemplateFile = template;
            _StoreProcudeName = storeProcudeName;
            _CondictionControlName = condictionControlName;
        }

        private string _ReportName;
        private string _TemplateFile;
        private string _StoreProcudeName;
        private string _CondictionControlName;

        private ParameterEx[] reportParameters;

        public ParameterEx[] ReportParameters
        {
            get
            {
                return reportParameters;
            }
            set
            {
                reportParameters = value;
            }
        }

        public string CondictionControlName
        {
            get
            {
                return _CondictionControlName;
            }
            set
            {
                _CondictionControlName = value;
            }
        }

        public string StoreProcudeName
        {
            get
            {
                return _StoreProcudeName;
            }
            set
            {
                _StoreProcudeName = value;
            }
        }

        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }

        public string TemplateFile
        {
            get
            {
                string _StoreTypeName = "";
                string _YqName = "";//Add By Tany 2016-03-01
                for (int i = 0; i < reportParameters.Length; i++)
                {
                    if (reportParameters[i].Text == ReportParameterDefine.�ⷿ����)
                    {
                        _StoreTypeName = reportParameters[i].Value.ToString();
                        //break;
                    }
                    if (reportParameters[i].Text == ReportParameterDefine.Ժ������)
                    {
                        _YqName = reportParameters[i].Value.ToString();
                        //break;
                    }
                }
                if (string.IsNullOrEmpty(_StoreTypeName))
                    return System.Windows.Forms.Application.StartupPath + "\\report\\" + _TemplateFile;
                else
                    return System.Windows.Forms.Application.StartupPath + "\\report\\" + string.Format(_TemplateFile, _StoreTypeName, _YqName == "ȫ��" ? "" : "_" + _YqName);
            }
            //set
            //{
            //    //Add By Tany 2015-05-28 ������������
            //    _TemplateFile = value;
            //}
        }
    }

    public delegate void OnCloseReportHandle(ReportInfo ri);
}
