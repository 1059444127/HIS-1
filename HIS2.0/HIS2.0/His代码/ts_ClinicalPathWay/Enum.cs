using System;
using System.Collections.Generic;
using System.Text;

namespace ts_ClinicalPathWay
{
    public class Enum
    {
        /// <summary>
        /// �޸� ��Ŀ�׶ε�����
        /// </summary>
        public enum KindModifyItem
        {
            /// <summary>
            ///   item  �ı�
            /// </summary>
            text,
            /// <summary>
            /// item  ��ʼ ʱ��
            /// </summary>
            time_up,
            /// <summary>
            /// item   ���� ʱ��
            /// </summary>
            time_down,
            /// <summary>
            /// item  �Ƿ���ʼ�׶�
            /// </summary>
            isFirst
        }
    }

    public enum NewItemKind
    {
        /// <summary>
        /// ����ҽ��
        /// </summary>
        Normal,
        /// <summary>
        /// ˵��ҽ��
        /// </summary>
        Explain,
        /// <summary>
        /// ��������ҽ��
        /// </summary>
        Operation

    }
}
