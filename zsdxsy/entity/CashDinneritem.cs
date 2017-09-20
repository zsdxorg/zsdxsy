/*
* ==============================================================================
*
* File name: CashDishes
* Description: 可用快餐实体定义类
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

    public class CashDinneritem
    {
        /// <summary>
        /// 餐类
        /// </summary>
        public short mealType {
            get;
            set;
        }
        /// <summary>
        /// 餐名
        /// </summary>
        public string mealName {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public Decimal mealPrice {
            get;
            set;
        }
    }

}
