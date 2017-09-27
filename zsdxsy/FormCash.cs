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
        /// 访问手台服务器地址
        /// </summary>
        string serviceUrl = ConfigurationManager.AppSettings["serviceUrl"].ToString();

        /// <summary>
        /// 当前收银机的设备编号
        /// </summary>
        string deviceNum = ConfigurationManager.AppSettings["deviceNum"].ToString();
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
        /// 本收银机启动时的起始收银序号
        /// </summary>
        int billCount = 1;

        /// <summary>
        /// 已选择的消费明细项
        /// </summary>
        private Dictionary<string, ConsumeDetail> dicConsumeItems = new Dictionary<string, ConsumeDetail>();

        /// <summary>
        /// 当前操作员
        /// </summary>
        string opertioner = string.Empty;
        /// <summary>
        /// 快餐数据
        /// </summary>
        List<ValueEntity> listZhao = null;
        List<ValueEntity> listWu = null;
        List<ValueEntity> listWan = null;
        List<ValueEntity> listYe = null;

        /// <summary>
        /// 点餐与围餐的菜品
        /// </summary>
        List<ValueEntity> listMealItems = null;
        List<ValueEntity> listHun = null;
        List<ValueEntity> listShu = null;
        List<ValueEntity> listTang = null;
        List<ValueEntity> listZhu = null;
        List<ValueEntity> listJiu = null;
        List<ValueEntity> listOther = null;

        bool blGetCashDishes = false;
        bool blGetMeal = false;
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
            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.Text = "中山市委党校总务收银系统-操作员:" + loginForm.userXm;
                opertioner = loginForm.userXm;

                lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
                blGetCashDishes = DataHelper.getCashDishes(out listHun, out listShu, out listTang, out listZhu, out listJiu, out listOther, serviceUrl);
                if (blGetCashDishes)
                {
                    if (listShu != null && listShu.Count > 0)
                    {
                        createSelectButton(listShu, plDianShu);
                        createSelectButton(listShu, plWeiShu);
                    }

                    if (listTang != null && listTang.Count > 0)
                    {
                        createSelectButton(listTang, plDianTang);
                        createSelectButton(listTang, plWeiTang);
                    }

                    if (listZhu != null && listZhu.Count > 0)
                    {
                        createSelectButton(listZhu, plDianZhu);
                        createSelectButton(listZhu, plWeiZhu);
                    }

                    if (listJiu != null && listJiu.Count > 0)
                    {
                        createSelectButton(listJiu, plDianJiu);
                        createSelectButton(listJiu, plWeiJiu);
                    }

                    if (listOther != null && listOther.Count > 0)
                    {
                        createSelectButton(listOther, plDianOther);
                        createSelectButton(listOther, plWeiOther);
                    }
                    if (listHun != null && listHun.Count > 0)
                    {
                        createSelectButton(listHun, plDianHun);
                        createSelectButton(listHun, plWeiHun);
                    }
                }

                blGetMeal = DataHelper.getCashMealList(out listZhao, out listWu, out listWan, out listYe, serviceUrl);
                if (blGetMeal)
                    createCashMealButton(listZhao, listWu, listWan, listYe);
            }
            else
            {
                if (opertioner == "")
                {
                    this.Close();
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// 切换到快餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiKuai_Click(object sender, EventArgs e)
        {
            if (CheckNoClearingBill(1))
                tcDinnerType_TabIndexChanged(1);
        }
        /// <summary>
        /// 切换到点餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiDian_Click(object sender, EventArgs e)
        {
            // if (CheckNoClearingBill(2))
            tcDinnerType_TabIndexChanged(2);
        }

        /// <summary>
        /// 切换到围餐标签页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbiWei_Click(object sender, EventArgs e)
        {
            //if (CheckNoClearingBill(3))
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
            //if (itemsCount > 0 && eatType != selectType)
            //{
            //    Info = "您好：\n";
            //    Info += "    还有未结算的消费，请先结算\n\n";
            //    Info += "    按[确认]返回结算\n";

            //    InfoType = "OK";

            //    string Title = "未结算单提醒";
            //    frmInfo frmInfo = new frmInfo(Info, Title, InfoType);
            //    if (frmInfo.ShowDialog() == DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
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
            //if (CheckNoClearingBill(selectIndex))
            //{//没有没有待结算的单，则显示对应餐类的可选项
            switch (selectIndex)
            {
                case 1:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.快餐;
                    dinnerType = 1;
                    eatType = 1;
                    break;
                case 2:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.点餐;
                    eatType = 1;
                    dinnerType = 2;
                    break;
                case 3:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.围餐;
                    dinnerType = 3;
                    eatType = 1;
                    break;
            }
            //}
            //else {
            //    plDianHun.Controls.Clear();
            //}
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
                total = sumItemsTotal();
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
                total = sumItemsTotal();
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
        /// <summary>
        /// 切换收银员账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            this.frmCash_Load(new frmCash(), e);
        }
        /// <summary>
        /// 退出收银系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        #region 非事件处理函数
        /// <summary>
        /// 根据时间生成可选的快餐按钮
        /// </summary>
        /// <param name="listZhao"></param>
        /// <param name="listWu"></param>
        /// <param name="listWan"></param>
        /// <param name="listYe"></param>
        private void createCashMealButton(List<ValueEntity> listZhao, List<ValueEntity> listWu, List<ValueEntity> listWan, List<ValueEntity> listYe)
        {
            string justDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            DateTime justTime = DateTime.Now;

            DateTime endZhao = Convert.ToDateTime(justDate + " 09:00");
            DateTime endWu = Convert.ToDateTime(justDate + " 13:00");
            DateTime endWan = Convert.ToDateTime(justDate + " 19:00");
            DateTime endYe = Convert.ToDateTime(justDate + " 22:00");
            if (justTime < endZhao)
            {
                if (listZhao != null && listZhao.Count > 0)
                {
                    createSelectButton(listZhao, plSelectItems);
                }
            }
            else
            {
                if (justTime < endWu)
                {
                    if (listWu != null && listWu.Count > 0)
                    {
                        createSelectButton(listWu, plSelectItems);
                    }
                }
                else
                {
                    if (justTime < endWan)
                    {
                        if (listWan != null && listWan.Count > 0)
                        {
                            createSelectButton(listWan, plSelectItems);
                        }
                    }
                    else
                    {
                        if (listYe != null && listYe.Count > 0)
                        {
                            createSelectButton(listYe, plSelectItems);
                        }
                    }
                }

            }
        }
        /// <summary>
        /// 检查是否有未结算的小票
        /// </summary>
        /// <param name="selectIndex"></param>
        /// <returns></returns>
        private bool CheckNoClearingBill(int selectIndex)
        {
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
                    txtRealPay.Focus();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 生成票据流水号
        /// </summary>
        /// <returns></returns>
        private string creatBillSerial()
        {
            string temp1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            string temp2 = Utility.CreateGuidLeft(4, billCount.ToString(), '0', false);
            StringBuilder sb = new StringBuilder(temp1);
            sb.Append(deviceNum);
            sb.Append(temp2);

            return sb.ToString();
        }
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
        private decimal sumItemsTotal()
        {
            decimal total = 0;
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
            string info = string.Empty;
            string InfoType = string.Empty;
            string Title = "结算提醒";
            frmInfo frmInfo = null;
            if (txtNeedPay.Text == "")
            {
                info = "您好：\n";
                info += "    请输入应付金额\n\n";

                InfoType = "OK";
                frmInfo = new frmInfo(info, Title, InfoType);
                if (frmInfo.ShowDialog() == DialogResult.OK)
                {
                    txtRealPay.Focus();
                    return;
                }
            }
            //如果是快餐，重新计算总额
            if (dinnerType == 1)
            {
                txtNeedPay.Text = sumItemsTotal().ToString();
            }
            if (txtRealPay.Text == "")
            {
                txtRealPay.Text = "0";
            }

            Decimal needPay = Convert.ToDecimal(txtNeedPay.Text);
            Decimal realPay = Convert.ToDecimal(txtRealPay.Text);
            Decimal payChange = realPay - needPay;
            //如果是接待快餐或接待围餐,不需要输入实付金额
            if (dinnerType == 3 || eatType == 3)
            {
                payChange = 0;
                realPay = 0;
            }
            else
            {
                if (payChange < 0)
                {
                    info = "您好：\n";
                    info += "    实付金额不够，无法结算\n\n";

                    InfoType = "OK";

                    frmInfo = new frmInfo(info, Title, InfoType);
                    if (frmInfo.ShowDialog() == DialogResult.OK)
                    {
                        txtRealPay.Focus();
                        return;
                    }
                }
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
            string consumeSerial = creatBillSerial();
            string printDir = Application.StartupPath + @"\items\";
            string info = string.Empty;
            string consumer = "个人";

            info = "=====================================================================\r\n";
            info += "交易时间：" + dt + "\r\n";
            info += "交易流水号：" + consumeSerial + "\r\n";
            info += lblConsumeType.Text + "\r\n";
            //招待快餐和接待围餐要打印招待单位和来访单位
            if (eatType == 3 || dinnerType == 3)
            {
                consumer = "单位";
                info += "消费者：单位\r\n";
                info += "接待部门：" + txtReception.Text + "\r\n";
                info += "来访单位：" + txtVisitor.Text + "\r\n";
            }
            else
            {
                info += "消费者：个人\r\n";
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

            //写入交易票据文件
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
            outData = DataHelper.postConsumeBill(serviceUrl, consumeBill, billDetail);
            LogHelper.Info("流水号为" + consumeSerial + outData);

            billCount++;
        }

        /// <summary>
        /// 打印完小票后清理界面的消费项控件
        /// </summary>
        private void delItemControlFromItemPanel()
        {
            DevComponents.DotNetBar.ButtonX btnMeal = null;
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

                switch (dinnerType)
                {
                    case 1:
                        btnMeal = (DevComponents.DotNetBar.ButtonX)plSelectItems.Controls.Find("btn_" + cd.detailName, false)[0];
                        break;
                    case 2:
                        if (plDianHun.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianHun.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plDianShu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianShu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plDianTang.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianTang.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plDianZhu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianZhu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plDianJiu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianJiu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plDianOther.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plDianOther.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        break;
                    case 3:
                        if (plWeiHun.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiHun.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plWeiShu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiShu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plWeiTang.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiTang.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plWeiZhu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiZhu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plWeiJiu.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiJiu.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        if (plWeiOther.Controls.ContainsKey("btn_" + cd.detailName))
                        {
                            btnMeal = (DevComponents.DotNetBar.ButtonX)plWeiOther.Controls.Find("btn_" + cd.detailName, false)[0];
                            break;
                        }
                        break;
                }
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
