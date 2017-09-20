using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BJP.Framework.Log;
using zsdxsy.entity;
using zsdxsy.helper;
using System.Collections;
using System.Configuration;
using Sunisoft.IrisSkin;

namespace zsdxsy
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 收银类型 1-快餐 2-点餐 3-接待围餐
        /// </summary>
        private string dinnerType = "1";
        /// <summary>
        /// 吃快餐的类型 1-普通 2-加班 3-招待 4-忘记带卡
        /// </summary>
        private string eatType = string.Empty;

        string skinFileName = ConfigurationManager.AppSettings["skinFileName"].ToString();//皮肤文件名称

        private Dictionary<string, ConsumeDetail> dicConsumeItems = new Dictionary<string, ConsumeDetail>();

        public frmMain()
        {
            InitializeComponent();
            skinEngine1.SkinFile = Application.StartupPath + skinFileName;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.ResizeRedraw |
                              ControlStyles.SupportsTransparentBackColor, true);

            this.UpdateStyles();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
        //    List<CashDishes> listDishes = DataHelper.getCashDishes();
        //    createDishes(listDishes);

        //    //加载快餐的数据
        //    List<CashDinneritem> listMealItems = DataHelper.getCashDinnerItmes(DateTime.Now);
        //    crearteMealType(listMealItems);

            //默认消费类型
            //lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;

            //加载菜品数据
        }

        /// <summary>
        /// 收银的餐类切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcDinnerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = this.tcDinnerType.SelectedIndex;
            switch (selectIndex)
            {
                case 0:
                    dinnerType = "1";
                    //List<CashDinneritem> listMealItems = DataHelper.getCashDinnerItmes(DateTime.Now);
                    //crearteMealType(listMealItems);
                    break;
                case 1:
                    //MessageBox.Show("点餐");
                    break;
                case 2:
                    MessageBox.Show("接待围餐");
                    break;
            }
        }

        /// <summary>
        /// 吃快餐类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEatType_Click(object sender, EventArgs e)
        {
            Button btnEatType = (Button)sender;
            string selectType = btnEatType.Tag.ToString();
            int isDetal = dicConsumeItems.Count;
            if (isDetal > 0) {
                MessageBox.Show("当前有单没有结算，请先结算");
                return;
            }
            eatType = selectType;
            switch (selectType)
            {
                case "1": //普通
                    lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
                    break;
                case "2":
                    lblConsumeType.Text = "消费类型：" + EnumEatType.加班 + EnumDinnerType.快餐  ;
                    break;
                case "3":
                    lblConsumeType.Text = "消费类型：" + EnumEatType.招待 + EnumDinnerType.快餐 ;
                    break;
                case "4":
                    lblConsumeType.Text = "消费类型：" + EnumEatType.无卡 + EnumDinnerType.快餐 ;
                    break;
            }

        }

        /// <summary>
        /// 生成可选择的快餐
        /// </summary>
        /// <param name="listMealItems"></param>
        private void crearteMealType(List<CashDinneritem> listMealItems)
        {
            int i = 0;
            Button btn = null;
            gboxMealItems.Controls.Clear();
            foreach (CashDinneritem mealItem in listMealItems)
            {
                btn = new Button();
                btn.Name = "btn" + mealItem.mealName;
                btn.Text = mealItem.mealName;
                btn.Tag = mealItem.mealPrice.ToString();
                btn.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //btn.BackgroundImage = global::Sipbus.selfservice.App.Properties.Resources.Snap13;
                //btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btn.AutoSize = true;
                btn.Size = new Size(160, 45);
                btn.Click += new EventHandler(btnMeal_Click);
                btn.Location = new Point(25, 55 + 70 * i);
                gboxMealItems.Controls.Add(btn);
                i++;
            }
        }

        /// <summary>
        /// 生成可选择的菜品
        /// </summary>
        /// <param name="listMealItems"></param>
        private void createDishes(List<CashDishes> listMealItems)
        {
            int i = 0;
            Button btn = null;
            gboxMealItems.Controls.Clear();
            foreach (CashDishes mealItem in listMealItems)
            {
                btn = new Button();
                btn.Name = "btn" + mealItem.dishesName;
                btn.Text = mealItem.dishesName;
                btn.Tag = mealItem.dishesPrice.ToString();
                btn.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //btn.BackgroundImage = global::Sipbus.selfservice.App.Properties.Resources.Snap13;
                //btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                btn.AutoSize = true;
                btn.Size = new Size(160, 45);
                btn.Click += new EventHandler(btnMeal_Click);
                btn.Location = new Point(25, 55 + 70 * i);
                //gboxMealItems.Controls.Add(btn);
                tpHun.Controls.Add(btn);
                i++;
            }
        }

        /// <summary>
        /// 生成快餐的消费明细项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeal_Click(object sender, EventArgs e)
        {
            string eatType = lblConsumeType.Text;
            if (eatType == "消费类型：") {
                MessageBox.Show("请先选择快餐类型");
                return; 
            }
            Button btnMeal = (Button)sender;
            string tempName = btnMeal.Text;
            Decimal dPrice = 0;
            int itemsCount = dicConsumeItems.Count;

            //消费项名称标签
            Label lbl = new Label();
            lbl.Name = "lbl" + tempName;
            lbl.Text = btnMeal.Text;
            lbl.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.AutoSize = true;
            lbl.Location = new Point(30, itemsCount * 40 + 70);
            gboxConsumeItems.Controls.Add(lbl);

            //减份数按钮
            Button btn = new Button();
            btn.Name = "btnItemReduce_" + tempName;
            btn.Text = "-";
            btn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn.AutoSize = false;
            btn.Size = new Size(30, 30);
            btn.Click += new EventHandler(btnItemReduce_Click);
            btn.Location = new Point(150, itemsCount * 40 + 70);
            gboxConsumeItems.Controls.Add(btn);

            //份数文本框
            TextBox txt = new TextBox();
            txt.Name = "txt_" + tempName;
            txt.Text = "1";
            txt.Enabled = false;
            txt.AutoSize = false;
            txt.Size = new Size(30, 30);
            txt.Location = new Point(200, itemsCount * 40 + 70);
            gboxConsumeItems.Controls.Add(txt);

            //加份数按钮
            btn = new Button();
            btn.Name = "btnItemAdd_" + tempName;
            btn.Text = "+";
            btn.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn.AutoSize = false;
            btn.Size = new Size(30, 30);
            btn.Click += new EventHandler(btnItmeAdd_Click);
            btn.Location = new Point(250, itemsCount * 40 + 70);
            gboxConsumeItems.Controls.Add(btn);

            //加入到明细项中
            ConsumeDetail detail = new ConsumeDetail();
            detail.detailName = tempName;
            detail.detailCount = 1;
            detail.detailPrice =Convert.ToDecimal(btnMeal.Tag.ToString());
            dicConsumeItems.Add(tempName, detail);
            //计算总价
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                dPrice += cd.detailCount * cd.detailPrice;
            }
            labNeedPay.Text = dPrice.ToString();

            btnMeal.Enabled = false;
        }

        /// <summary>
        /// 消费项份数增加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItmeAdd_Click(object sender, EventArgs e) {
            Button btnItemAdd = (Button)sender;
            string[] tempName = btnItemAdd.Name.Split('_');
            int iCount = 1;
            Decimal dPrice = 0;

            TextBox txtCount = (TextBox) gboxConsumeItems.Controls.Find("txt_" + tempName[1], false)[0];
            iCount = Convert.ToInt16(txtCount.Text) +1;
            txtCount.Text = iCount.ToString();

            //更新dicConsumeItems
            if (dicConsumeItems.TryGetValue(tempName[1], out ConsumeDetail value)) {
                value.detailCount = iCount;
            }

            //计算总价
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl) {
                dPrice += cd.detailCount * cd.detailPrice;
            }
            labNeedPay.Text = dPrice.ToString();
        }

        /// <summary>
        /// 消费项份数减少按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemReduce_Click(object sender, EventArgs e) {
            Button btnItemAdd = (Button)sender;
            string[] tempName = btnItemAdd.Name.Split('_');
            int iCount = 0;
            Decimal dPrice = 0;

            TextBox txtCount = (TextBox)gboxConsumeItems.Controls.Find("txt_" + tempName[1], false)[0];
            iCount = Convert.ToInt16(txtCount.Text) - 1;
            if (iCount < 0)
                iCount = 0;
            txtCount.Text = iCount.ToString();

            //更新dicConsumeItems
            if (dicConsumeItems.TryGetValue(tempName[1], out ConsumeDetail value))
            {
                value.detailCount = iCount;
            }
            //计算总价
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                dPrice += cd.detailCount * cd.detailPrice;
            }
            labNeedPay.Text = dPrice.ToString();

        }

        /// <summary>
        /// 实付文本框回车事件
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
        /// 结算
        /// </summary>
        private void CashClearing() {
            string needPay = labNeedPay.Text;
            string realPay = txtRealPay.Text;
            string info = string.Empty;
            Decimal change = 0;
            if (realPay.Length == 0)
            {
                MessageBox.Show("请输入实付金额");
                return;
            }
            change = Convert.ToDecimal(realPay) - Convert.ToDecimal(needPay);
            if (change < 0)
            {
                MessageBox.Show("付款金额不够，无法结算");
                return;
            }
            lblChange.Text = "-" + change.ToString();

            //将当前的明细写入日志并清除数据
            LogHelper.Info("=========================================================================");
            LogHelper.Info("交易时间：" + DateTime.Now);
            LogHelper.Info(lblConsumeType.Text);
            LogHelper.Info("交易明细：");
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                LogHelper.Info("        " + cd.detailName + " " + cd.detailCount.ToString() + " 份");

                TextBox txtCount = (TextBox)gboxConsumeItems.Controls.Find("txt_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(txtCount);
                Label lblItemName = (Label)gboxConsumeItems.Controls.Find("lbl" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(lblItemName);

                Button btnItemAdd = (Button)gboxConsumeItems.Controls.Find("btnItemAdd_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemAdd);
                Button btnItemReduce = (Button)gboxConsumeItems.Controls.Find("btnItemReduce_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemReduce);

                Button btnMeal = (Button)gboxMealItems.Controls.Find("btn" + cd.detailName, false)[0];
                btnMeal.Enabled = true;
            }
            LogHelper.Info("        ------------------------------");
            LogHelper.Info("        应收合计：" + needPay);
            LogHelper.Info("        实收：" + realPay);
            LogHelper.Info("        找零：" + "-" + change.ToString());

            //清除当前交易的数据
            dicConsumeItems.Clear();
            lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
            eatType = "1";
            labNeedPay.Text = "0";
            txtRealPay.Text = "0";
            lblChange.Text = "0";

            //弹出钱箱并打印小票
            MessageBox.Show("弹出钱箱并打印小票");
        }

        /// <summary>
        /// 确定按钮，点击后进行结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            CashClearing();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
            foreach (ConsumeDetail cd in valueColl)
            {
                TextBox txtCount = (TextBox)gboxConsumeItems.Controls.Find("txt_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(txtCount);
                Label lblItemName = (Label)gboxConsumeItems.Controls.Find("lbl" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(lblItemName);

                Button btnItemAdd = (Button)gboxConsumeItems.Controls.Find("btnItemAdd_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemAdd);
                Button btnItemReduce = (Button)gboxConsumeItems.Controls.Find("btnItemReduce_" + cd.detailName, false)[0];
                gboxConsumeItems.Controls.Remove(btnItemReduce);

                Button btnMeal = (Button)gboxMealItems.Controls.Find("btn" + cd.detailName, false)[0];
                btnMeal.Enabled = true;
            }
            //清除当前交易的数据
            dicConsumeItems.Clear();
            lblConsumeType.Text = "消费类型：" + EnumEatType.普通 + EnumDinnerType.快餐;
            eatType = "1";
            labNeedPay.Text = "0";
            txtRealPay.Text = "0";
            lblChange.Text = "0";
        }
    }
}
