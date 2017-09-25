using BJP.Framework.Log;
using BJP.Framework.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zsdxsy.entity;
using zsdxsy.helper;

namespace zsdxsy
{
    public partial class frmCash : Form
    {
        /// <summary>
        /// 皮肤文件定义
        /// </summary>
        string skinFileName = ConfigurationManager.AppSettings["skinFileName"].ToString();
        /// <summary>
        /// 收银类型 1-快餐 2-点餐 3-接待围餐
        /// 默认为1
        /// </summary>
        private int dinnerType = 1;
        /// <summary>
        /// 快餐类型 1-普通 2-加班 3-招待 4-忘记带卡
        /// 默认为1
        /// </summary>
        private int eatType = 1;

        /// <summary>
        /// 已选择的消费明细项
        /// </summary>
        private Dictionary<string, ConsumeDetail> dicConsumeItems = new Dictionary<string, ConsumeDetail>();

        public frmCash()
        {
            InitializeComponent();
            //初始化皮肤
            skinEngine1.SkinFile = Application.StartupPath + skinFileName;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.ResizeRedraw |
                              ControlStyles.SupportsTransparentBackColor, true);

            this.UpdateStyles();
        }

        private void frmCash_Load(object sender, EventArgs e)
        {
            lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
        }

        /// <summary>
        /// 切换到快餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiKuai_Click(object sender, EventArgs e)
        {
            tcDinnerType_TabIndexChanged(1);
        }
        /// <summary>
        /// 切换到点餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiDian_Click(object sender, EventArgs e)
        {
            tcDinnerType_TabIndexChanged(2);
        }

        /// <summary>
        /// 切换到围餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiWei_Click(object sender, EventArgs e)
        {
            tcDinnerType_TabIndexChanged(3);
        }
        /// <summary>
        /// 点击并切换快餐类型按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEatType_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX btnx = (DevComponents.DotNetBar.ButtonX)sender;
            int itemsCount = dicConsumeItems.Count;    //已选择的消费项
            int selectType = Convert.ToInt16(btnx.Tag.ToString());
            string Info = string.Empty;
            string InfoType = string.Empty;
            //如果是切换前的类型已有消费明细，提示需要先结算
            if (itemsCount > 0 && eatType != selectType)
            {
                Info = "您好：\n";
                Info += "    还有未结算的消费，请先结算\n\n";
                Info += "    按[确认]返回结算\n";

                InfoType = "OK";

                string Title = "未结算单提醒";
                frmInfo frmInfo = new frmInfo(Info, Title, InfoType);
                if (frmInfo.ShowDialog() == DialogResult.OK)
                {
                    return;
                }
            }
            //设置消费类型
            eatType = selectType;
            switch (selectType)
            {
                case 1: //普通
                    lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
                    break;
                case 2:
                    lblConsumeType.Text = "消费类型：" + EnumEatType.加班 + EnumDinnerType.快餐;
                    break;
                case 3:
                    lblConsumeType.Text = "消费类型：" + EnumEatType.招待 + EnumDinnerType.快餐;
                    break;
                case 4:
                    lblConsumeType.Text = "消费类型：" + EnumEatType.无卡 + EnumDinnerType.快餐;
                    break;
            }

        }

        /// <summary>
        /// 就餐类型的切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcDinnerType_TabIndexChanged(int selectIndex)
        {
            List<ValueEntity> listMealItems = null;
            int itemsCount = dicConsumeItems.Count;    //已选择的消费项
            string Info = string.Empty;
            string InfoType = string.Empty;
            //如果是切换前的类型已有消费明细，提示需要先结算
            if (itemsCount > 0 && dinnerType != selectIndex)
            {
                Info = "您好：\n";
                Info += "    还有未结算的消费，请先结算\n\n";
                Info += "    按[确认]返回结算\n";

                InfoType = "OK";

                string Title = "未结算单提醒";
                frmInfo frmInfo = new frmInfo(Info, Title, InfoType);
                if (frmInfo.ShowDialog() == DialogResult.OK)
                {
                    return;
                }
            }
            switch (selectIndex)
            {
                case 1:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.快餐;
                    dinnerType = 1;
                    eatType = 1;
                    listMealItems = DataHelper.getCashDinnerItmes(DateTime.Now);
                    createSelectButton(listMealItems, plSelectItems);
                    break;
                case 2:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.点餐;
                    eatType = 1;
                    dinnerType = 2;
                    listMealItems = DataHelper.getCashDishes();
                    createSelectButton(listMealItems, plDianHun);
                    break;
                case 3:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.围餐;
                    dinnerType = 3;
                    eatType = 1;
                    break;
            }
        }

        /// <summary>
        /// 选择快餐或菜品事件
        /// 选择后加入到明细中，同时禁止再次点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            Decimal total = 0;
            int itemsCount = dicConsumeItems.Count;  //已添加的明细项个数
            DevComponents.DotNetBar.ButtonX btn = (DevComponents.DotNetBar.ButtonX)sender;
            string selectText = btn.Text;
            Decimal selectPrice = Convert.ToDecimal(btn.Tag.ToString());

            //明细项名称
            DevComponents.DotNetBar.LabelX lbl = new DevComponents.DotNetBar.LabelX();
            lbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            lbl.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold);
            lbl.Name = "lblSelect_" + selectText;
            lbl.Text = selectText;
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, itemsCount * 50 + 70);
            gboxConsumeItems.Controls.Add(lbl);

            //减份数按钮 
            DevComponents.DotNetBar.ButtonX btnReduce = new DevComponents.DotNetBar.ButtonX();
            btnReduce.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold);
            btnReduce.Name = "btnReduce_" + selectText;
            btnReduce.Text = "-";
            btnReduce.AutoSize = false;
            btnReduce.Size = new Size(50, 35);
            btnReduce.Click += new EventHandler(btnCountChange_Click);
            btnReduce.Location = new Point(230, itemsCount * 50 + 70);
            gboxConsumeItems.Controls.Add(btnReduce);

            //份数文本框
            DevComponents.DotNetBar.ButtonX btnCount = new DevComponents.DotNetBar.ButtonX();
            btnCount.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold);
            btnCount.Name = "btnCount_" + selectText;
            btnCount.Text = "1";
            btnCount.AutoSize = false;
            btnCount.Size = new Size(60, 35);
            btnCount.Location = new Point(300, itemsCount * 50 + 70);
            gboxConsumeItems.Controls.Add(btnCount);

            //加份数按钮
            DevComponents.DotNetBar.ButtonX btnAdd = new DevComponents.DotNetBar.ButtonX();
            btnAdd.Name = "btnAdd_" + selectText;
            btnAdd.Text = "+";
            btn.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold);
            btnAdd.AutoSize = false;
            btnAdd.Size = new Size(50, 35);
            btnAdd.Location = new Point(380, itemsCount * 50 + 70);
            btnAdd.Click += new EventHandler(btnCountChange_Click);
            gboxConsumeItems.Controls.Add(btnAdd);

            //加入到明细项中
            ConsumeDetail detail = new ConsumeDetail();
            detail.detailName = selectText;
            detail.detailCount = 1;
            detail.detailPrice = selectPrice;
            dicConsumeItems.Add(selectText, detail);

            //如果是快餐，自动计算总价
            if (dinnerType == 1)
            {
                total = sumItemsTotal(total);
            }
            btn.Enabled = false;
        }

        /// <summary>
        /// 增加和减少份数按钮操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCountChange_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX btnOper = (DevComponents.DotNetBar.ButtonX)sender;
            string[] tempName = btnOper.Name.Split('_');
            int iCount = 0;
            Decimal dPrice = 0;
            Decimal total = 0;

            DevComponents.DotNetBar.ButtonX txtCount = (DevComponents.DotNetBar.ButtonX)gboxConsumeItems.Controls.Find("btnCount_" + tempName[1], false)[0];
            if (tempName[0] == "btnAdd")
                iCount = Convert.ToInt16(txtCount.Text) + 1;
            else
            {
                iCount = Convert.ToInt16(txtCount.Text) - 1;
                if (iCount < 0)
                    iCount = 0;
            }
            txtCount.Text = iCount.ToString();

            //更新dicConsumeItems
            if (dicConsumeItems.TryGetValue(tempName[1], out ConsumeDetail value))
            {
                value.detailCount = iCount;
            }
            //如果是快餐，自动计算总价
            if (dinnerType == 1)
            {
                total = sumItemsTotal(total);
            }

        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            printConsumeItems("取消");
            delItemControlFromItemPanel();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            CashClearing();
            delItemControlFromItemPanel();
        }

        /// <summary>
        /// 输入实付金额后回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRealPay_KeyDown(object sender, KeyEventArgs e)
        {
            //输入金额后回车进行结算
            if (e.KeyCode == Keys.Enter)
            {
                CashClearing();
            }
        }


        #region 非事件处理函数

        /// <summary>
        /// 动态生成可选择的快餐或菜品
        /// </summary>
        /// <param name="listItems">快餐或菜品数据</param>
        /// <param name="addPanel">加入的容器</param>
        private void createSelectButton(List<ValueEntity> listItems, Control addPanel)
        {
            int i = 0;
            int yu = 0;
            int mo = 0;
            DevComponents.DotNetBar.ButtonX btn = null;
            addPanel.Controls.Clear();
            foreach (ValueEntity valueItem in listItems)
            {
                yu = i % 2;
                mo = i / 2;
                btn = new DevComponents.DotNetBar.ButtonX();
                btn.Name = "btn_" + valueItem.valueName;
                btn.Text = valueItem.valueName;
                btn.Tag = valueItem.valuePrice.ToString();
                btn.AutoSize = true;
                btn.Size = new Size(150, 70);
                btn.Location = new Point(15 + 400 * yu, 25 + 100 * mo);
                btn.Click += new EventHandler(btnSelectItem_Click);
                addPanel.Controls.Add(btn);
                i++;
            }
        }

        /// <summary>
        /// 汇总消费项的总价
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        private decimal sumItemsTotal(decimal total)
        {
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                total += cd.detailCount * cd.detailPrice;
            }
            txtNeedPay.Text = total.ToString();
            return total;
        }

        /// <summary>
        /// 付款结算
        /// </summary>
        private void CashClearing()
        {
            if (txtNeedPay.Text == "")
            {
                MessageBox.Show("请输入应付金额");
                return;
            }

            if (txtRealPay.Text == "")
            {
                txtRealPay.Text = "0";
            }

            Decimal needPay = Convert.ToDecimal(txtNeedPay.Text);
            Decimal realPay = Convert.ToDecimal(txtRealPay.Text);
            Decimal payChange = realPay - needPay;

            //如果是接待快餐或接待围餐,不需要输入实付金额
            // if(eatType)
            if (payChange < 0)
            {
                MessageBox.Show("实付金额不够，无法结算");
                return;
            }
            txtChange.Text = "-" + payChange.ToString();

            //打印小票
            printConsumeItems("成功");

            //清除相关控件
            delItemControlFromItemPanel();

        }

        /// <summary>
        /// 打印小票
        /// </summary>
        private void printConsumeItems(string state)
        {
            List<ConsumeDetail> billItems = new List<ConsumeDetail>();
            DateTime dt = DateTime.Now;
            string outData = string.Empty;
            string needPay = txtNeedPay.Text;
            string realPay = txtRealPay.Text;
            string chagePay = txtChange.Text;
            string consumeSerial = dt.ToString("yyyyMMddHHmmss");
            string printDir = Application.StartupPath + @"\items\";
            string info = string.Empty;
            string consumer = "个人";
            string opertioner = "aaaaa";
            info = "=====================================================================\r\n";
            info += "交易时间：" + dt + "\r\n";
            info += "交易流水号：" + consumeSerial + "\r\n";
            info += lblConsumeType.Text + "\r\n";
            info += "消费者：" + consumer + "\r\n";
            //招待快餐和接待围餐要打印招待单位和来访单位
            if (eatType == 3 || dinnerType == 3)
            {
                info += "接待部门：" + txtReception.Text + "\r\n";
                info += "来访单位：" + txtVisitor.Text + "\r\n";
            }
            info += "交易明细：\r\n";
            info += "-----------------------------------\r\n";
            info += "名称               份数        \r\n";
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                info += cd.detailName + "            X" + cd.detailCount.ToString() + "        \r\n";
                billItems.Add(cd);
            }
            info += "-----------------------------------\r\n";
            info += "             合计：" + needPay + "\r\n";
            info += "             实收：" + realPay + "\r\n";
            info += "             找零：" + chagePay + "\r\n";
            info += "操 作 人：" + opertioner + "\r\n";
            info += "交易状态：" + state + "\r\n";

            if (false == System.IO.Directory.Exists(printDir))
            {
                System.IO.Directory.CreateDirectory(printDir);
            }
            string path = printDir + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine(info);
            sw.Close();

            //组装数据并发送到后台
            ConsumeBill bill = new ConsumeBill();
            bill.testDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
            bill.consumeSerial = consumeSerial;
            bill.consumeType = lblConsumeType.Text.Split('：')[1];
            bill.consumeUser = consumer;
            bill.receptionDept = txtReception.Text;
            bill.visitorUnit = txtVisitor.Text;
            bill.consumeTotal = Convert.ToDecimal(needPay);
            bill.realPay = Convert.ToDecimal(realPay);
            bill.changePay = Convert.ToDecimal(chagePay);
            bill.opertioner = opertioner;
            bill.consumeState = state;

            string consumeBill = JsonBuilder.toJson(bill);
            string billDetail = JsonBuilder.toJson(billItems);
            string url = "http://localhost:9300/app/cashReset/doAddConsumeBill?consumeBill=" + consumeBill + "&billDetail=" + billDetail;
            bool re = HttpHelper.PostToREST(out outData, url, "");
            if (re)
            {
                //outData = "{\"success\":true,\"jsonData\":\"操作成功\"}";
                ExtResult er = JsonBuilder.fromJson<ExtResult>(outData);
                if (er.success)
                    LogHelper.Info("流水号为" + consumeSerial + "的单据入库成功");
                else
                    LogHelper.Error("流水号为" + consumeSerial + "的单据入库失败,将在本地记录失败原因:" + er.jsonData);
            }
            else {
                LogHelper.Error("流水号为" + consumeSerial + "的单据入库失败,将在本地记录。失败原因:网络故障");
            }
        }

        /// <summary>
        /// 打印完小票后清理界面的消费项控件
        /// </summary>
        private void delItemControlFromItemPanel()
        {
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                DevComponents.DotNetBar.ButtonX txtCount = (DevComponents.DotNetBar.ButtonX)gboxConsumeItems.Controls.Find("btnCount_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(txtCount);

                DevComponents.DotNetBar.LabelX lblItemName = (DevComponents.DotNetBar.LabelX)gboxConsumeItems.Controls.Find("lblSelect_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(lblItemName);

                DevComponents.DotNetBar.ButtonX btnItemAdd = (DevComponents.DotNetBar.ButtonX)gboxConsumeItems.Controls.Find("btnAdd_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemAdd);

                DevComponents.DotNetBar.ButtonX btnItemReduce = (DevComponents.DotNetBar.ButtonX)gboxConsumeItems.Controls.Find("btnReduce_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemReduce);

                DevComponents.DotNetBar.ButtonX btnMeal = (DevComponents.DotNetBar.ButtonX)plSelectItems.Controls.Find("btn_" + cd.detailName, false)[0];
                btnMeal.Enabled = true;
            }
            dicConsumeItems.Clear();
            txtNeedPay.Text = "0";
            txtRealPay.Text = "0";
            txtChange.Text = "0";
        }
        #endregion
    }
}
