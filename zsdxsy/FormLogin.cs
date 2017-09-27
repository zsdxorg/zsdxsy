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
using zsdxsy.helper;

namespace zsdxsy
{
    public partial class frmLogin : Form
    {
        /// <summary>
        /// 皮肤文件定义
        /// </summary>
        string skinFileName = ConfigurationManager.AppSettings["skinFileName"].ToString();

        /// <summary>
        /// 访问手台服务器地址
        /// </summary>
        string serviceUrl = ConfigurationManager.AppSettings["serviceUrl"].ToString();

        public string userXm = string.Empty;
        public frmLogin()
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            string loginInfo = string.Empty;
            string info = string.Empty;
            string infoType = string.Empty;
            string userName = txtUserName.Text;
            string userPwd = txtPwd.Text;

            bool checkResult = DataHelper.loginCasher(out loginInfo,userName, userPwd,serviceUrl);

            if (checkResult)
            {
                this.DialogResult = DialogResult.OK;
                this.userXm = loginInfo;
            } else
            {
                info = "您好：\n";
                info += "    " + loginInfo + "\n\n";
                info += "    请重新输入\n";

                infoType = "OK";

                string Title = "登录提醒";
                frmInfo frmInfo = new frmInfo(info, Title, infoType);
                if (frmInfo.ShowDialog() == DialogResult.OK)
                {
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
