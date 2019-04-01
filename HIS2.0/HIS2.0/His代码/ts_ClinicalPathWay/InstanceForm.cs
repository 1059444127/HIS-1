using System;
using TrasenFrame.Classes;
using System.Windows.Forms;
using TrasenClasses.DatabaseAccess;
using TrasenClasses.GeneralClasses;
using Trasen.Base;

namespace ts_ClinicalPathWay
{
    public class InstanceForm : InstanceBaseForm
    {
        
        /// <summary>
        /// �Ƿ�Ϊ�ٴ�·��(trueΪ�ٴ�·��,falseΪ������)
        /// </summary>
        bool bIsPathWay = true;

        public override void InstanceWorkForm()
        {
            if (_functionName == "")
            {
                throw new Exception("��������������Ϊ�գ�");
            }

            
            switch (_functionName)
            {

                case "Fun_ClinicalPathWay_maintain":

                    FrmPathWay f1 = new FrmPathWay(_menuTag, _chineseName, _mdiParent, true, bIsPathWay);
                    f1.Show();
                    break;
                case "Fun_ClinicalPathWay_maintain_dbz":
                    bIsPathWay = false;
                    FrmPathWay f2 = new FrmPathWay(_menuTag, _chineseName, _mdiParent, true, bIsPathWay);
                    f2.Show();
                    break;
                //case "Fun_Cszm_Gl":
                //case"Fun_Cszm_Gl_zf":
                //    Frm_Cszm_Cx f2 = new Frm_Cszm_Cx(_menuTag, _chineseName, _mdiParent, true);
                //    f2.Show();
                //    break;

                    
                default:
                    throw new Exception("�����������ƴ���");
            }
        }
        public override ObjectInfo GetDllInfo()
        {
            ObjectInfo objectInfo;
            objectInfo.Name = "ts_ClinicalPathWay";						//��dll���ļ�����,�����������ռ䱣��һ��
            objectInfo.Text = bIsPathWay ? "·��ά������" : "������ά������";								//����������,����Ϊ��
            objectInfo.Remark = "";							//������,����Ϊ��
            return objectInfo;
        }
        public override ObjectInfo[] GetFunctionsInfo()
        {
            ObjectInfo[] objectInfos = new ObjectInfo[2];

            objectInfos[0].Name = "Fun_ClinicalPathWay_maintain";
            objectInfos[0].Remark = objectInfos[0].Text = bIsPathWay ? "·��ά��" : "������ά��";

            objectInfos[1].Name = "Fun_ClinicalPathWay_maintain_dbz";
            objectInfos[1].Text =  "������ά��";
            objectInfos[1].Remark = "������ά��";
            return objectInfos;
        }
    }
}
