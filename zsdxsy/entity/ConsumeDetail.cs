/*
* ==============================================================================
*
* File name: ConsumeDetail
* Description: 消费项明细
*
* Version: 1.0
* Created: 2017-09-20 09:24:27
*
* Author: yiboLuo
* Company: 深圳市宇川智能系统有限公司
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zsdxsy.entity
{
    public class ConsumeDetail
    {
        /// <summary>
        /// 明细项名称
        /// </summary>
        public string detailName { get; set; }

        /// <summary>
        /// 明细项数量
        /// </summary>
        public int detailCount { get; set; }

        /// <summary>
        /// 明细项单价
        /// </summary>
        public Decimal detailPrice { get; set; }
    }
}
