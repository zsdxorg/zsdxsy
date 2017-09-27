/*
* ==============================================================================
*
* File name: CashDishes
* Description: 菜品实体定义类
*
* Version: 1.0
* Created: 2017-09-19 15:35:33
*
* Author: yiboluo
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
    public class CashDishes
    {
        /// <summary>
        /// 菜品类别
        /// 1- 荦菜类 2-素菜类 3-汤类 4-主食类 5-酒水类 6-其它
        /// </summary>
        public short dishesType { get; set; }

        /// <summary>
        /// 菜品名称
        /// </summary>
        public string dishesName { get; set; }

        /// <summary>
        /// 菜品编码
        /// </summary>
        //public short dishesCode { get; set; }

        /// <summary>
        /// 菜品单价
        /// </summary>
        public Decimal dishesPrice { get; set; }
    }
}
