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

namespace zsdxsy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnKuai_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MessageBox.Show(btn.Tag.ToString());
        }

        private void btnDinnerType_Click(object sender, EventArgs e) {
            Button btnDinnerType = (Button)sender;
            string dinnerType = btnDinnerType.Tag.ToString();
            
            //根据餐类生成不对应的餐标数据
            MessageBox.Show(dinnerType);
        }

        /// <summary>
        /// 根据选择的餐类，动态生成相应的可点餐
        /// </summary>
        /// <param name="dinnerType"></param>
        private void createDinnerInfo(string dinnerType) {
        }
    }
}
