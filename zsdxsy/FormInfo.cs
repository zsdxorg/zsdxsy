using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zsdxsy
{
    public partial class frmInfo : Form
    {
        public frmInfo(string info, string title, string infotype)
        {
            InitializeComponent();

            this.Text = "中山市委党校总务收银系统-" + title;
            lblInfo.Text = info;
            if (infotype == "CANCEL")
                btnOk.Visible = false;
            else
                btnOk.Visible = true;
            if (infotype == "OK")
                btnCancel.Visible = false;
            else
                btnCancel.Visible = true;
            if (infotype == "OK|CANCEL") {
                btnCancel.Visible = true;
                btnOk.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
