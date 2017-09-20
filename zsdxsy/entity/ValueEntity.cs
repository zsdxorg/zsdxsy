/*
* ==============================================================================
*
* File name: ValueEntity
* Description: 用来动态生成收银时可以点击的选择按钮
*
* Version: 1.0
* Created: 2017-09-20 22:41:04
*
* Author: Your name
* Company: Your company name
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
    public class ValueEntity
    {
        /// <summary>
        /// 可选择项名称
        /// </summary>
        public string valueName { get; set; }

        /// <summary>
        /// 可选择项单价
        /// </summary>
        public Decimal valuePrice { get; set; }
    }
}
