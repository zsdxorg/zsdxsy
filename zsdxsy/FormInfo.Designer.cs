﻿namespace zsdxsy
{
    partial class frmInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInfo = new DevComponents.DotNetBar.LabelX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.BackgroundImage = global::zsdxsy.Properties.Resources.Snap13;
            this.lblInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            // 
            // 
            // 
            this.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 21.75F);
            this.lblInfo.Location = new System.Drawing.Point(64, 33);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(569, 223);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "labelX1";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("宋体", 21.75F);
            this.btnOk.Image = global::zsdxsy.Properties.Resources.Apply;
            this.btnOk.Location = new System.Drawing.Point(160, 331);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(149, 69);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确 定";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 21.75F);
            this.btnCancel.Image = global::zsdxsy.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(149, 69);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取  消";
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::zsdxsy.Properties.Resources.Snap13;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(771, 498);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息提示";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblInfo;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}