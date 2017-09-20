namespace zsdxsy
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gboxConsumeItems = new System.Windows.Forms.GroupBox();
            this.lblConsumeType = new System.Windows.Forms.Label();
            this.tcDinnerType = new System.Windows.Forms.TabControl();
            this.tpKuai = new System.Windows.Forms.TabPage();
            this.gboxMealItems = new System.Windows.Forms.GroupBox();
            this.gboxEatType = new System.Windows.Forms.GroupBox();
            this.btn_eatType_4 = new System.Windows.Forms.Button();
            this.btn_eatType_3 = new System.Windows.Forms.Button();
            this.btn_eatType_2 = new System.Windows.Forms.Button();
            this.btn_eatType_1 = new System.Windows.Forms.Button();
            this.tpDian = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tcCashDishes = new System.Windows.Forms.TabControl();
            this.tpHun = new System.Windows.Forms.TabPage();
            this.btnNewDishes = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tpJiedai = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button15 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtRealPay = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.labNeedPay = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.gboxConsumeItems.SuspendLayout();
            this.tcDinnerType.SuspendLayout();
            this.tpKuai.SuspendLayout();
            this.gboxEatType.SuspendLayout();
            this.tpDian.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tcCashDishes.SuspendLayout();
            this.tpHun.SuspendLayout();
            this.tpJiedai.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxConsumeItems
            // 
            this.gboxConsumeItems.Controls.Add(this.lblConsumeType);
            this.gboxConsumeItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxConsumeItems.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxConsumeItems.Location = new System.Drawing.Point(0, 0);
            this.gboxConsumeItems.Name = "gboxConsumeItems";
            this.gboxConsumeItems.Size = new System.Drawing.Size(387, 462);
            this.gboxConsumeItems.TabIndex = 1;
            this.gboxConsumeItems.TabStop = false;
            this.gboxConsumeItems.Text = "消费明细";
            // 
            // lblConsumeType
            // 
            this.lblConsumeType.AutoSize = true;
            this.lblConsumeType.Location = new System.Drawing.Point(62, 27);
            this.lblConsumeType.Name = "lblConsumeType";
            this.lblConsumeType.Size = new System.Drawing.Size(115, 21);
            this.lblConsumeType.TabIndex = 26;
            this.lblConsumeType.Text = "消费类型：";
            // 
            // tcDinnerType
            // 
            this.tcDinnerType.Controls.Add(this.tpKuai);
            this.tcDinnerType.Controls.Add(this.tpDian);
            this.tcDinnerType.Controls.Add(this.tpJiedai);
            this.tcDinnerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDinnerType.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcDinnerType.Location = new System.Drawing.Point(0, 0);
            this.tcDinnerType.Multiline = true;
            this.tcDinnerType.Name = "tcDinnerType";
            this.tcDinnerType.SelectedIndex = 0;
            this.tcDinnerType.Size = new System.Drawing.Size(1343, 751);
            this.tcDinnerType.TabIndex = 2;
            this.tcDinnerType.SelectedIndexChanged += new System.EventHandler(this.tcDinnerType_SelectedIndexChanged);
            // 
            // tpKuai
            // 
            this.tpKuai.Controls.Add(this.gboxMealItems);
            this.tpKuai.Controls.Add(this.gboxEatType);
            this.tpKuai.Location = new System.Drawing.Point(4, 45);
            this.tpKuai.Name = "tpKuai";
            this.tpKuai.Padding = new System.Windows.Forms.Padding(3);
            this.tpKuai.Size = new System.Drawing.Size(1335, 702);
            this.tpKuai.TabIndex = 0;
            this.tpKuai.Text = "快 餐";
            this.tpKuai.UseVisualStyleBackColor = true;
            // 
            // gboxMealItems
            // 
            this.gboxMealItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gboxMealItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxMealItems.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxMealItems.Location = new System.Drawing.Point(3, 103);
            this.gboxMealItems.Name = "gboxMealItems";
            this.gboxMealItems.Size = new System.Drawing.Size(1329, 596);
            this.gboxMealItems.TabIndex = 1;
            this.gboxMealItems.TabStop = false;
            this.gboxMealItems.Text = "快餐单";
            // 
            // gboxEatType
            // 
            this.gboxEatType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gboxEatType.Controls.Add(this.btn_eatType_4);
            this.gboxEatType.Controls.Add(this.btn_eatType_3);
            this.gboxEatType.Controls.Add(this.btn_eatType_2);
            this.gboxEatType.Controls.Add(this.btn_eatType_1);
            this.gboxEatType.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxEatType.Font = new System.Drawing.Font("宋体", 21.75F);
            this.gboxEatType.Location = new System.Drawing.Point(3, 3);
            this.gboxEatType.Name = "gboxEatType";
            this.gboxEatType.Size = new System.Drawing.Size(1329, 100);
            this.gboxEatType.TabIndex = 0;
            this.gboxEatType.TabStop = false;
            this.gboxEatType.Text = "就餐类型";
            // 
            // btn_eatType_4
            // 
            this.btn_eatType_4.Location = new System.Drawing.Point(442, 30);
            this.btn_eatType_4.Name = "btn_eatType_4";
            this.btn_eatType_4.Size = new System.Drawing.Size(112, 45);
            this.btn_eatType_4.TabIndex = 1;
            this.btn_eatType_4.Tag = "4";
            this.btn_eatType_4.Text = "无 卡";
            this.btn_eatType_4.UseVisualStyleBackColor = true;
            this.btn_eatType_4.Click += new System.EventHandler(this.btnEatType_Click);
            // 
            // btn_eatType_3
            // 
            this.btn_eatType_3.Location = new System.Drawing.Point(310, 30);
            this.btn_eatType_3.Name = "btn_eatType_3";
            this.btn_eatType_3.Size = new System.Drawing.Size(100, 45);
            this.btn_eatType_3.TabIndex = 2;
            this.btn_eatType_3.Tag = "3";
            this.btn_eatType_3.Text = "招 待";
            this.btn_eatType_3.UseVisualStyleBackColor = true;
            this.btn_eatType_3.Click += new System.EventHandler(this.btnEatType_Click);
            // 
            // btn_eatType_2
            // 
            this.btn_eatType_2.Location = new System.Drawing.Point(171, 30);
            this.btn_eatType_2.Name = "btn_eatType_2";
            this.btn_eatType_2.Size = new System.Drawing.Size(100, 45);
            this.btn_eatType_2.TabIndex = 1;
            this.btn_eatType_2.Tag = "2";
            this.btn_eatType_2.Text = "加 班";
            this.btn_eatType_2.UseVisualStyleBackColor = true;
            this.btn_eatType_2.Click += new System.EventHandler(this.btnEatType_Click);
            // 
            // btn_eatType_1
            // 
            this.btn_eatType_1.Location = new System.Drawing.Point(25, 30);
            this.btn_eatType_1.Name = "btn_eatType_1";
            this.btn_eatType_1.Size = new System.Drawing.Size(100, 45);
            this.btn_eatType_1.TabIndex = 0;
            this.btn_eatType_1.Tag = "1";
            this.btn_eatType_1.Text = "普 通";
            this.btn_eatType_1.UseVisualStyleBackColor = true;
            this.btn_eatType_1.Click += new System.EventHandler(this.btnEatType_Click);
            // 
            // tpDian
            // 
            this.tpDian.Controls.Add(this.groupBox4);
            this.tpDian.Location = new System.Drawing.Point(4, 45);
            this.tpDian.Name = "tpDian";
            this.tpDian.Padding = new System.Windows.Forms.Padding(3);
            this.tpDian.Size = new System.Drawing.Size(1335, 702);
            this.tpDian.TabIndex = 1;
            this.tpDian.Text = "点 餐";
            this.tpDian.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tcCashDishes);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1329, 696);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "菜品清单";
            // 
            // tcCashDishes
            // 
            this.tcCashDishes.Controls.Add(this.tpHun);
            this.tcCashDishes.Controls.Add(this.tabPage2);
            this.tcCashDishes.Controls.Add(this.tabPage3);
            this.tcCashDishes.Controls.Add(this.tabPage4);
            this.tcCashDishes.Controls.Add(this.tabPage5);
            this.tcCashDishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCashDishes.Location = new System.Drawing.Point(3, 27);
            this.tcCashDishes.Name = "tcCashDishes";
            this.tcCashDishes.SelectedIndex = 0;
            this.tcCashDishes.Size = new System.Drawing.Size(1323, 666);
            this.tcCashDishes.TabIndex = 0;
            // 
            // tpHun
            // 
            this.tpHun.Controls.Add(this.btnNewDishes);
            this.tpHun.Controls.Add(this.textBox1);
            this.tpHun.Location = new System.Drawing.Point(4, 31);
            this.tpHun.Name = "tpHun";
            this.tpHun.Padding = new System.Windows.Forms.Padding(3);
            this.tpHun.Size = new System.Drawing.Size(1315, 631);
            this.tpHun.TabIndex = 0;
            this.tpHun.Text = "荦菜类";
            this.tpHun.UseVisualStyleBackColor = true;
            // 
            // btnNewDishes
            // 
            this.btnNewDishes.Location = new System.Drawing.Point(715, 533);
            this.btnNewDishes.Name = "btnNewDishes";
            this.btnNewDishes.Size = new System.Drawing.Size(100, 45);
            this.btnNewDishes.TabIndex = 4;
            this.btnNewDishes.Text = "添 加";
            this.btnNewDishes.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(30, 533);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(671, 47);
            this.textBox1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1315, 631);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "素菜类";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1315, 631);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "汤 类";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1315, 631);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "主食类";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 31);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1315, 631);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "酒水类";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tpJiedai
            // 
            this.tpJiedai.Controls.Add(this.groupBox5);
            this.tpJiedai.Location = new System.Drawing.Point(4, 45);
            this.tpJiedai.Name = "tpJiedai";
            this.tpJiedai.Size = new System.Drawing.Size(1335, 702);
            this.tpJiedai.TabIndex = 2;
            this.tpJiedai.Text = "接待围餐";
            this.tpJiedai.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tabControl3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1335, 702);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "菜品清单";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 27);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1329, 672);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button15);
            this.tabPage6.Controls.Add(this.textBox2);
            this.tabPage6.Controls.Add(this.button16);
            this.tabPage6.Controls.Add(this.button17);
            this.tabPage6.Location = new System.Drawing.Point(4, 31);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1321, 637);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "荦菜类";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(715, 571);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(100, 45);
            this.button15.TabIndex = 4;
            this.button15.Text = "添 加";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(30, 571);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(671, 47);
            this.textBox2.TabIndex = 3;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(30, 110);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(100, 45);
            this.button16.TabIndex = 2;
            this.button16.Text = "水煮鱼";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(30, 26);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(100, 45);
            this.button17.TabIndex = 1;
            this.button17.Text = "红烧肉";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 31);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1321, 637);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "素菜类";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 31);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1321, 637);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "汤 类";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 31);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1321, 637);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "主食类";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 31);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1321, 637);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "酒水类";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtRealPay);
            this.groupBox6.Controls.Add(this.lblChange);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.btnCancel);
            this.groupBox6.Controls.Add(this.btnOk);
            this.groupBox6.Controls.Add(this.labNeedPay);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(0, 462);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(387, 289);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "结算";
            // 
            // txtRealPay
            // 
            this.txtRealPay.Location = new System.Drawing.Point(207, 72);
            this.txtRealPay.Name = "txtRealPay";
            this.txtRealPay.Size = new System.Drawing.Size(106, 31);
            this.txtRealPay.TabIndex = 33;
            this.txtRealPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRealPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRealPay_KeyDown);
            // 
            // lblChange
            // 
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChange.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChange.Location = new System.Drawing.Point(206, 107);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(106, 24);
            this.lblChange.TabIndex = 32;
            this.lblChange.Text = "0";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(94, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 24);
            this.label14.TabIndex = 31;
            this.label14.Text = "找零：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(80, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 24);
            this.label12.TabIndex = 30;
            this.label12.Text = "实付金额：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 42);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(115, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 42);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "确 定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labNeedPay
            // 
            this.labNeedPay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labNeedPay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNeedPay.Location = new System.Drawing.Point(206, 36);
            this.labNeedPay.Name = "labNeedPay";
            this.labNeedPay.Size = new System.Drawing.Size(106, 24);
            this.labNeedPay.TabIndex = 27;
            this.labNeedPay.Text = "0.0";
            this.labNeedPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(62, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 24);
            this.label10.TabIndex = 26;
            this.label10.Text = "应付金额：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.gboxConsumeItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(956, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 751);
            this.panel1.TabIndex = 3;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1343, 751);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcDinnerType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "党校收银系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboxConsumeItems.ResumeLayout(false);
            this.gboxConsumeItems.PerformLayout();
            this.tcDinnerType.ResumeLayout(false);
            this.tpKuai.ResumeLayout(false);
            this.gboxEatType.ResumeLayout(false);
            this.tpDian.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tcCashDishes.ResumeLayout(false);
            this.tpHun.ResumeLayout(false);
            this.tpHun.PerformLayout();
            this.tpJiedai.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gboxConsumeItems;
        private System.Windows.Forms.Label lblConsumeType;
        private System.Windows.Forms.TabControl tcDinnerType;
        private System.Windows.Forms.TabPage tpKuai;
        private System.Windows.Forms.TabPage tpDian;
        private System.Windows.Forms.TabPage tpJiedai;
        private System.Windows.Forms.GroupBox gboxMealItems;
        private System.Windows.Forms.GroupBox gboxEatType;
        private System.Windows.Forms.Button btn_eatType_4;
        private System.Windows.Forms.Button btn_eatType_3;
        private System.Windows.Forms.Button btn_eatType_2;
        private System.Windows.Forms.Button btn_eatType_1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tcCashDishes;
        private System.Windows.Forms.TabPage tpHun;
        private System.Windows.Forms.Button btnNewDishes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtRealPay;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label labNeedPay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}

