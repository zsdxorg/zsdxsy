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
        /// 操作员登录
        /// </summary>
        /// <param name="loginInfo">登录结果消息</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="serviceUrl">提交url</param>
        /// <returns></returns>
        public static bool loginCasher(out string loginInfo, string userName, string userPwd, string serviceUrl)
        {
            string outData = string.Empty;
            string url = serviceUrl + "/casherLogin?userName=" + userName + "&userPwd=" + userPwd;
            bool re = HttpHelper.PostToREST(out outData, url, "");
            if (re)
            {
                ExtResult er = JsonBuilder.fromJson<ExtResult>(outData);
                loginInfo = er.obj.ToString();
                if (er.success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                loginInfo = "登录失败，失败原因：网络错误";
                return false;
            }
        }

        /// <summary>
        /// 获取可用的快餐项
        /// </summary>
        /// <param name="listZhao"></param>
        /// <param name="listWu"></param>
        /// <param name="listWan"></param>
        /// <param name="listYe"></param>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public static bool getCashMealList(out List<ValueEntity> listZhao, out List<ValueEntity> listWu, out List<ValueEntity> listWan, out List<ValueEntity> listYe, string serviceUrl)
        {
            string outData = string.Empty;
            string tempName = string.Empty;
            JArray jsonData = null;
            CashDinneritem reData = null;
            List<CashDinneritem> reDatas = new List<CashDinneritem>();
            List<CashDinneritem> list = new List<CashDinneritem>();

            string url = serviceUrl + "/getCashMealList";
            bool re = HttpHelper.PostToREST(out outData, url, "");
            if (re)
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(outData);
                bool er = Convert.ToBoolean(jo["success"].ToString());
                if (er)
                {
                    jsonData = (JArray)jo["obj"];
                    foreach (JObject joData in jsonData)
                    {
                        reData = new CashDinneritem();
                        object value = null;
                        PropertyInfo[] propertys = reData.GetType().GetProperties();
                        //处理每个数据项
                        foreach (PropertyInfo pi in propertys)
                        {
                            tempName = pi.Name;//将属性名称赋值给临时变量
                            value = joData[tempName].ToString().Replace("\"", "");
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
                    listZhao = getCashMealByType(reDatas, 1);
                    listWu = getCashMealByType(reDatas, 2);
                    listWan = getCashMealByType(reDatas, 3);
                    listYe = getCashMealByType(reDatas, 4);

                    return true;
                }
                else
                {
                    listZhao = null;
                    listWu = null;
                    listWan = null;
                    listYe = null;

                    return false;
                }
            }
            else
            {
                listZhao = null;
                listWu = null;
                listWan = null;
                listYe = null;

                return false;
            }
        }
        /// <summary>
        /// 获取点餐或围餐的菜品
        /// </summary>
        /// <returns></returns>
        public static bool getCashDishes(out List<ValueEntity> listHun, out List<ValueEntity> listShu, out List<ValueEntity> listTang, out List<ValueEntity> listZhu, out List<ValueEntity> listJiu, out List<ValueEntity> listOther, string serviceUrl)
        {
            string outData = string.Empty;
            string tempName = string.Empty;
            JArray jsonData = null;
            CashDishes reData = null;
            List<CashDishes> reDatas = new List<CashDishes>();
            List<CashDishes> list = new List<CashDishes>();

            string url = serviceUrl + "/getDishesList";
            bool re = HttpHelper.PostToREST(out outData, url, "");
            if (re)
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(outData);
                bool er = Convert.ToBoolean(jo["success"].ToString());
                if (er)
                {
                    jsonData = (JArray)jo["obj"];
                    foreach (JObject joData in jsonData)
                    {
                        reData = new CashDishes();
                        object value = null;
                        PropertyInfo[] propertys = reData.GetType().GetProperties();
                        //处理每个数据项
                        foreach (PropertyInfo pi in propertys)
                        {
                            tempName = pi.Name;//将属性名称赋值给临时变量
                            value = joData[tempName].ToString().Replace("\"", "");
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
                    listHun = getCashDishesByType(reDatas, 1);
                    listShu = getCashDishesByType(reDatas, 2);
                    listTang = getCashDishesByType(reDatas, 3);
                    listZhu = getCashDishesByType(reDatas, 4);
                    listJiu = getCashDishesByType(reDatas, 5);
                    listOther = getCashDishesByType(reDatas, 6);
                    return true;
                }
                else
                {
                    listHun = null;
                    listShu = null;
                    listTang = null;
                    listZhu = null;
                    listJiu = null;
                    listOther = null;
                    return false;
                }
            }
            else
            {
                listHun = null;
                listShu = null;
                listTang = null;
                listZhu = null;
                listJiu = null;
                listOther = null;
                return false;
            }
        }

        /// <summary>
        /// 收银票据及明细信息保存到数据库
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="consumeBill"></param>
        /// <param name="billDetail"></param>
        /// <returns></returns>
        public static string postConsumeBill(string serviceUrl, string consumeBill, string billDetail)
        {
            string outData = string.Empty;
            string url = serviceUrl + "/doAddConsumeBill?consumeBill=" + consumeBill + "&billDetail=" + billDetail;
            bool re = HttpHelper.PostToREST(out outData, url, "");
            if (re)
            {
                ExtResult er = JsonBuilder.fromJson<ExtResult>(outData);
                if (er.success)
                    outData = "的单据入库成功";
                else
                    outData = "的单据入库失败,失败原因:" + er.obj;
            }
            else
            {
                outData = "的单据入库失败,失败原因:络故障";
            }

            return outData;
        }

        /// <summary>
        /// 将获取的菜品按类型分开
        /// </summary>
        /// <param name="listDishes"></param>
        /// <param name="dishesType"></param>
        /// <returns></returns>
        private static List<ValueEntity> getCashDishesByType(List<CashDishes> listDishes, Int16 dishesType)
        {
            List<CashDishes> list = listDishes.FindAll(X => X.dishesType == dishesType);
            ValueEntity valueItem = null;
            List<ValueEntity> listValueItme = new List<ValueEntity>();
            if (list.Count > 0)
            {
                foreach (CashDishes cd in list)
                {
                    valueItem = new ValueEntity();
                    valueItem.valueName = cd.dishesName;
                    valueItem.valuePrice = cd.dishesPrice;
                    listValueItme.Add(valueItem);
                }

                return listValueItme;
            }
            else
            {
                return null;
            }
        }

        private static List<ValueEntity> getCashMealByType(List<CashDinneritem> listDishes, Int16 dishesType)
        {
            List<CashDinneritem> list = listDishes.FindAll(X => X.mealType == dishesType);
            ValueEntity valueItem = null;
            List<ValueEntity> listValueItme = new List<ValueEntity>();
            if (list.Count > 0)
            {
                foreach (CashDinneritem cd in list)
                {
                    valueItem = new ValueEntity();
                    valueItem.valueName = cd.mealName;
                    valueItem.valuePrice = cd.mealPrice;
                    listValueItme.Add(valueItem);
                }

                return listValueItme;
            }
            else
            {
                return null;
            }
        }
    }
}
