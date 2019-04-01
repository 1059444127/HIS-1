using System;
using System.Collections.Generic;
using System.Text;

namespace ts_mz_class.PhysicalExamineCharge
{
    /// <summary>
    /// ��첡��
    /// </summary>
    public class PhysicalExaminePatient
    {
        private string examineNo;
        private string fileNo;
        private string name;
        private string sex;
        private DateTime? bornDay;
        private DateTime examineDate;
        private decimal totalCost;
        /// <summary>
        /// �ܷ���
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime ExamineDate
        {
            get
            {
                return examineDate;
            }
            set
            {
                examineDate = value;
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? BornDay
        {
            get
            {
                return bornDay;
            }
            set
            {
                bornDay = value;
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
