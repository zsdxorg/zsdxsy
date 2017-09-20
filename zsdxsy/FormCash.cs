using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
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
                    List<ValueEntity> listMealItems = DataHelper.getCashDinnerItmes(DateTime.Now);
                    createSelectButton(listMealItems, plSelectItems);
                    break;
                case 2:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.点餐;
                    dinnerType = 2;
                    break;
                case 3:
                    lblConsumeType.Text = "消费类型：" + EnumDinnerType.围餐;
                    dinnerType = 3;
                    break;
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e) {
            Decimal total = 0;
            int itemsCount = dicConsumeItems.Count;  //已添加的明细项个数
            DevComponents.DotNetBar.ButtonX btn = (DevComponents.DotNetBar.ButtonX) sender;
            string selectText = btn.Text;
            Decimal selectPrice = Convert.ToDecimal(btn.Tag.ToString());

            //明细项名称
            DevComponents.DotNetBar.LabelX lbl = new DevComponents.DotNetBar.LabelX();
            lbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            lbl.Name = "lblSelect_" + selectText;
            lbl.Text = selectText;
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, itemsCount * 20 + 70);
            gboxConsumeItems.Controls.Add(lbl);

            //减份数按钮 

            //份数文本框

            //加份数按钮

            //加入到明细项中
            ConsumeDetail detail = new ConsumeDetail();
            detail.detailName = selectText;
            detail.detailCount = 1;
            detail.detailPrice = selectPrice;
            dicConsumeItems.Add(selectText, detail);

            //如果是快餐，自动计算总价
            if (dinnerType == 1)
            {
                Dictionary<string, ConsumeDetail>.ValueCollection valueColl = dicConsumeItems.Values;
                foreach (ConsumeDetail cd in valueColl)
                {
                    total += cd.detailCount * cd.detailPrice;
                }
                txtNeedPay.Text = total.ToString();
            }
            btn.Enabled = false;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {

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

        private void createSelectButton(List<ValueEntity> listItems, Control addPanel)
        {
            int i = 0;
            int yu = 0;
            int mo = 0;
            DevComponents.DotNetBar.ButtonX btn = null;
            addPanel.Controls.Clear();
            foreach (ValueEntity valueItem in listItems) {
                yu = i % 2;
                mo = i / 2;
                btn = new DevComponents.DotNetBar.ButtonX();
                btn.Name = "btn_" + valueItem.valueName;
                btn.Text = valueItem.valueName;
                btn.Tag = valueItem.valuePrice.ToString();
                btn.AutoSize = true;
                btn.Size = new Size(150, 70);
                btn.Location = new Point(15 + 400*yu, 25 + 100 * mo);
                btn.Click += new EventHandler(btnSelectItem_Click);
                addPanel.Controls.Add(btn);
                i++;
            }
            //Button btn = null;
            //gboxMealItems.Controls.Clear();
            //foreach (CashDinneritem mealItem in listMealItems)
            //{
            //    btn = new Button();
            //    btn.Name = "btn" + mealItem.mealName;
            //    btn.Text = mealItem.mealName;
            //    btn.Tag = mealItem.mealPrice.ToString();
            //    btn.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //    //btn.BackgroundImage = global::Sipbus.selfservice.App.Properties.Resources.Snap13;
            //    //btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //    btn.AutoSize = true;
            //    btn.Size = new Size(160, 45);
            //    btn.Click += new EventHandler(btnSelectItem_Click);
            //    btn.Location = new Point(25, 55 + 70 * i);
            //    gboxMealItems.Controls.Add(btn);
            //    i++;
            //}
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
                MessageBox.Show("请输入实付金额");
                return;
            }
            Decimal needPay = Convert.ToDecimal(txtNeedPay.Text);
            Decimal realPay = Convert.ToDecimal(txtRealPay.Text);
            Decimal payChange = realPay - needPay;
            if (payChange < 0)
            {
                MessageBox.Show("实付金额不够，无法结算");
                return;
            }
            txtChange.Text = payChange.ToString();

        }
        #endregion
    }
}
