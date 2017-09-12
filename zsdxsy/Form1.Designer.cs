namespace zsdxsy
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKuai = new System.Windows.Forms.Button();
            this.btnDian = new System.Windows.Forms.Button();
            this.btnJiedai = new System.Windows.Forms.Button();
            this.btnXueyuan = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXueyuan);
            this.groupBox1.Controls.Add(this.btnJiedai);
            this.groupBox1.Controls.Add(this.btnDian);
            this.groupBox1.Controls.Add(this.btnKuai);
            this.groupBox1.Location = new System.Drawing.Point(44, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "餐类";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(830, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 554);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " 结算";
            // 
            // btnKuai
            // 
            this.btnKuai.Location = new System.Drawing.Point(41, 20);
            this.btnKuai.Name = "btnKuai";
            this.btnKuai.Size = new System.Drawing.Size(85, 42);
            this.btnKuai.TabIndex = 0;
            this.btnKuai.Tag = "kuai";
            this.btnKuai.Text = "快 餐";
            this.btnKuai.UseVisualStyleBackColor = true;
            this.btnKuai.Click += new System.EventHandler(this.btnDinnerType_Click);
            // 
            // btnDian
            // 
            this.btnDian.Location = new System.Drawing.Point(182, 20);
            this.btnDian.Name = "btnDian";
            this.btnDian.Size = new System.Drawing.Size(85, 42);
            this.btnDian.TabIndex = 1;
            this.btnDian.Tag = "dian";
            this.btnDian.Text = "点 餐";
            this.btnDian.UseVisualStyleBackColor = true;
            this.btnDian.Click += new System.EventHandler(this.btnDinnerType_Click);
            // 
            // btnJiedai
            // 
            this.btnJiedai.Location = new System.Drawing.Point(305, 20);
            this.btnJiedai.Name = "btnJiedai";
            this.btnJiedai.Size = new System.Drawing.Size(85, 42);
            this.btnJiedai.TabIndex = 2;
            this.btnJiedai.Tag = "jiedai";
            this.btnJiedai.Text = "接待围餐";
            this.btnJiedai.UseVisualStyleBackColor = true;
            this.btnJiedai.Click += new System.EventHandler(this.btnDinnerType_Click);
            // 
            // btnXueyuan
            // 
            this.btnXueyuan.Location = new System.Drawing.Point(416, 20);
            this.btnXueyuan.Name = "btnXueyuan";
            this.btnXueyuan.Size = new System.Drawing.Size(85, 42);
            this.btnXueyuan.TabIndex = 3;
            this.btnXueyuan.Tag = "xueyuan";
            this.btnXueyuan.Text = "学员围餐";
            this.btnXueyuan.UseVisualStyleBackColor = true;
            this.btnXueyuan.Click += new System.EventHandler(this.btnDinnerType_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(44, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(780, 465);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "餐标";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "10元快餐";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "15元快餐";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "20元快餐";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(416, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 42);
            this.button4.TabIndex = 4;
            this.button4.Text = "30元快餐";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "10元快餐";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(81, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 24);
            this.button5.TabIndex = 1;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(134, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(193, 38);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 24);
            this.button6.TabIndex = 3;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(193, 76);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 24);
            this.button7.TabIndex = 7;
            this.button7.Text = "+";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(134, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(81, 76);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 24);
            this.button8.TabIndex = 5;
            this.button8.Text = "-";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "15元快餐";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(193, 111);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 24);
            this.button9.TabIndex = 11;
            this.button9.Text = "+";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(134, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(81, 111);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 24);
            this.button10.TabIndex = 9;
            this.button10.Text = "-";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "20元快餐";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(193, 145);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(47, 24);
            this.button11.TabIndex = 15;
            this.button11.Text = "+";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(134, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(81, 145);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(47, 24);
            this.button12.TabIndex = 13;
            this.button12.Text = "-";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(22, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "30元快餐";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(134, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(22, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 16;
            this.label10.Text = "合计：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(43, 260);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 42);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "确 定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(155, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 42);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 594);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXueyuan;
        private System.Windows.Forms.Button btnJiedai;
        private System.Windows.Forms.Button btnDian;
        private System.Windows.Forms.Button btnKuai;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label4;
    }
}

