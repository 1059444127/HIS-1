using System;
using System.Collections.Generic;
using System.Text;

namespace ts_mz_class.PhysicalExamineCharge
{
    /// <summary>
    /// ��ѯ��������
    /// </summary>
    public class QueryCondiction
    {
        private string examineNo;
        private string fileNo;
        private string name;
        private string sex;
        private DateTime? examineBeginDate;
        private DateTime? examineEndDate;
        /// <summary>
        /// ����ֹʱ��
        /// </summary>
        public DateTime? ExamineEndDate
        {
            get
            {
                return examineEndDate;
            }
            set
            {
                examineEndDate = value;
            }
        }
        /// <summary>
        /// ��鿪ʼʱ��
        /// </summary>
        public DateTime? ExamineBeginDate
        {
            get
            {
                return examineBeginDate;
            }
            set
            {
                examineBeginDate = value;
            }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string FileNo
        {
            get
            {
                return fileNo;
            }
            set
            {
                fileNo = value;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string ExamineNo
        {
            get
            {
                return examineNo;
            }
            set
            {
                examineNo = value;
            }
        }
    }
}
