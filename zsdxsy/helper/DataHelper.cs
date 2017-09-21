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
        public static List<ValueEntity> getCashDinnerItmes(DateTime dinnerTime)
        {
            //先做点模拟数据
            ValueEntity mealItem = null;
            int beginPrice = 10;
            List<ValueEntity> list = new List<ValueEntity>();
            for (int i = 0; i < 6; i++) {
                mealItem = new ValueEntity();
                mealItem.valueName = beginPrice.ToString() + "元快餐";
                mealItem.valuePrice = beginPrice;
                list.Add(mealItem);
                beginPrice += 10;
            }
            return list;
        }

        /// <summary>
        /// 获取点餐或围餐的菜品
        /// </summary>
        /// <returns></returns>
        public static List<ValueEntity> getCashDishes() {

            //模拟数据
            ValueEntity caiping = null;

            List<ValueEntity> list = new List<ValueEntity>();
            caiping = new ValueEntity();
            //caiping.dishesType = 1;
            caiping.valueName = "红烧肉";
            //caiping.dishesCode = 1;
            caiping.valuePrice = 30;
            list.Add(caiping);

            caiping = new ValueEntity();
            //caiping.dishesType = 1;
            caiping.valueName = "水煮鱼片";
            //caiping.dishesCode = 2;
            caiping.valuePrice = 30;
            list.Add(caiping);


            caiping = new ValueEntity();
            //caiping.dishesType = 1;
            caiping.valueName = "水煮牛肉";
            //caiping.dishesCode = 2;
            caiping.valuePrice = 30;
            list.Add(caiping);


            caiping = new ValueEntity();
            //caiping.dishesType = 1;
            caiping.valueName = "木须肉";
            //caiping.dishesCode = 2;
            caiping.valuePrice = 30;
            list.Add(caiping);


            caiping = new ValueEntity();
            //caiping.dishesType = 1;
            caiping.valueName = "永州血鸭";
            //caiping.dishesCode = 2;
            caiping.valuePrice = 30;
            list.Add(caiping);

            return list;
        }
    }
}
