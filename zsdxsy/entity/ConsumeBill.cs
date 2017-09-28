/*
* ==============================================================================
*
* File name: ConsumeBill
* Description: 消费的票据实体定义
*
* Version: 1.0
* Created: 2017-09-25 11:05:36
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

using Newtonsoft.Json;
using BJP.Framework.Utility;

namespace zsdxsy.entity
{
    public class ConsumeBill
    {
        public string testDate { get; set; }

        public string consumeSerial { get; set; }

        public string consumeType { get; set; }

        public string consumeUser { get; set; }

        public string receptionDept { get; set; }

        public string visitorUnit { get; set; }

        public decimal consumeTotal { get; set; }

        public decimal realPay { get; set; }

        public decimal changePay { get; set; }
        public string opertioner { get; set; }
        public string consumeState { get; set; }
        public int clearingForm { get; set; }

        public int mealType { get; set; }
    }
}
