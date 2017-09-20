/*
* ==============================================================================
*
* File name: DataHelper
* Description: 从后台获取界面需要显示的数据
*
* Version: 1.0
* Created: 2017-09-19 16:14:56
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

using zsdxsy.entity;

namespace zsdxsy.helper
{
    public class DataHelper
    {

        /// <summary>
        /// 获取快餐项
        /// </summary>
        /// <param name="dinnerTime"></param>
        /// <returns></returns>
        public static List<CashDinneritem> getCashDinnerItmes(DateTime dinnerTime)
        {
            //先做点模拟数据
            CashDinneritem mealItem = null;
            int beginPrice = 10;
            List<CashDinneritem> list = new List<CashDinneritem>();
            for (int i = 0; i < 3; i++) {
                mealItem = new CashDinneritem();
                mealItem.mealName = beginPrice.ToString() + "元快餐";
                mealItem.mealPrice = beginPrice;
                list.Add(mealItem);
                beginPrice += 10;
            }
            return list;
        }

        /// <summary>
        /// 获取点餐或围餐的菜品
        /// </summary>
        /// <returns></returns>
        public static List<CashDishes> getCashDishes() {

            //模拟数据
            CashDishes caiping = null;

            List<CashDishes> list = new List<CashDishes>();
            caiping = new CashDishes();
            caiping.dishesType = 1;
            caiping.dishesName = "红烧肉";
            caiping.dishesCode = 1;
            caiping.dishesPrice = 30;
            list.Add(caiping);

            caiping = new CashDishes();
            caiping.dishesType = 1;
            caiping.dishesName = "水煮鱼片";
            caiping.dishesCode = 2;
            caiping.dishesPrice = 30;
            list.Add(caiping);


            caiping = new CashDishes();
            caiping.dishesType = 1;
            caiping.dishesName = "水煮牛肉";
            caiping.dishesCode = 2;
            caiping.dishesPrice = 30;
            list.Add(caiping);


            caiping = new CashDishes();
            caiping.dishesType = 1;
            caiping.dishesName = "木须肉";
            caiping.dishesCode = 2;
            caiping.dishesPrice = 30;
            list.Add(caiping);


            caiping = new CashDishes();
            caiping.dishesType = 1;
            caiping.dishesName = "永州血鸭";
            caiping.dishesCode = 2;
            caiping.dishesPrice = 30;
            list.Add(caiping);

            return list;
        }
    }
}
