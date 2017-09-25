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
using BJP.Framework.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

using zsdxsy.entity;
using Newtonsoft.Json.Linq;

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
            string tempName = string.Empty;
            string outData = string.Empty;
            CashDinneritem reData = null;
            ValueEntity valueEntity = null;
            List<CashDinneritem> reDatas = new List<CashDinneritem>();
            List<ValueEntity> list = new List<ValueEntity>();
            //bool tt = HttpHelper.PostToREST(out outData, "http://localhost:9300/CashDishesTime/typelist?mealtime=12:00", "");
            outData = "{'statusCode':200,'message':'操作成功','jsonData':[{'mealType':2,'mealName':'快餐1','mealPrice':10},{'mealType':2,'mealName':'快餐1','mealPrice':15}]}";
            JObject jo = (JObject)JsonConvert.DeserializeObject(outData);
            string StatusCode = jo["statusCode"].ToString();
            if (StatusCode=="200") {
                JArray joDatas = (JArray)jo["jsonData"];
                //处理每条数据
                foreach (JObject joData in joDatas)
                {
                    reData = new CashDinneritem();
                    object value = null;
                    PropertyInfo[] propertys = reData.GetType().GetProperties();
                    //处理每个数据项
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;//将属性名称赋值给临时变量
                        value = joData[tempName].ToString();
                        string tempType = pi.PropertyType.ToString();
                        if (tempType == "System.DateTime")
                            value = Convert.ToDateTime(value);
                        if (tempType == "System.Int32")
                            value = Convert.ToInt32(value);
                        if (tempType == "System.Int16")
                            value = Convert.ToInt16(value);
                        if (tempType == "System.Decimal")
                            value = Convert.ToDecimal(value);
                        pi.SetValue(reData, value, null);
                    }
                    reDatas.Add(reData);
                }
            }
            foreach (CashDinneritem cd in reDatas) {
                valueEntity = new ValueEntity();
                valueEntity.valueName = cd.mealPrice.ToString() + "元快餐";
                valueEntity.valuePrice = cd.mealPrice;
                list.Add(valueEntity);
            }
            ////先做点模拟数据
            //ValueEntity mealItem = null;
            //int beginPrice = 10;
            //List<ValueEntity> list = new List<ValueEntity>();
            //for (int i = 0; i < 6; i++) {
            //    mealItem = new ValueEntity();
            //    mealItem.valueName = beginPrice.ToString() + "元快餐";
            //    mealItem.valuePrice = beginPrice;
            //    list.Add(mealItem);
            //    beginPrice += 10;
            //}
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
