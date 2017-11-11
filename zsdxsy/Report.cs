using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace YC.Components
{
    /// <summary>
    /// 报表组件
    /// </summary>
    public class Report
    {
        #region 变量定义

        private ReportDocument m_ReportDocument;    //报表文档

        private string m_FilePath;  //报表路径

        private ParameterFields m_parafields;

        private string[] m_FieldsArray;     //字段数组
        private string[] m_ParasArray;      //固定参数数组

        private string m_texts;        //动态参数

        #endregion

        #region 方法

        /// <summary>
        /// 加载报表
        /// </summary>
        /// <param name="ReportPath">报表路径</param>
        /// <returns>成功返回True</returns>
        private bool Load(string ReportPath)
        {
            m_FilePath = ReportPath;
            if (System.IO.File.Exists(m_FilePath))
            {
                return true;
            }
            else
            {
                string msg = "报表支持文件路径：" + "\r\n" + m_FilePath + " 找不到。" + "\r\n" + " 请与管理员联系。";
                MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        ///// <summary>
        ///// 显示报表
        ///// </summary>
        ///// <param name="DataSource">传入的数据源</param>
        ///// <returns>返回对话框结果</returns>
        //public System.Windows.Forms.DialogResult ShowDialog(object DataSource)
        //{
        //    this.ReportDocument.SetDataSource(DataSource);
        //    FillParameters();

        //    if (m_parafields == null)
        //    {
        //        InitParameterFields();
        //    }


        //    frmReportView frm = new frmReportView(this.ReportDocument, this.m_parafields);
        //    return frm.ShowDialog();
        //}

        /// <summary>
        /// 填充参数
        /// </summary>
        private void FillParameters()
        {
            if (this.m_texts == null || this.m_texts == "")
            {
                return;
            }

            TextObject txt;
            string[] str = this.m_texts.Split(new char[] { '●' });

            for (int i = 0; i < str.Length; i += 2)
            {
                txt = (TextObject)this.m_ReportDocument.ReportDefinition.ReportObjects[str[i]];
                txt.Text = str[i + 1];
            }
        }

        /// <summary>
        /// 初始化参数字段
        /// </summary>
        private void InitParameterFields()
        {
            try
            {
                m_parafields = new ParameterFields();

                ParameterField paramfield;
                ParameterDiscreteValue discreteVal;

                if (this.m_ParasArray != null && (this.m_ParasArray.Length == 4 || this.m_ParasArray.Length == 5))
                {
                    //标题
                    paramfield = new ParameterField();
                    paramfield.Name = "标题";
                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = this.m_ParasArray[0];
                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    //公司
                    paramfield = new ParameterField();
                    paramfield.Name = "公司";
                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = this.m_ParasArray[1];
                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    //时间段
                    paramfield = new ParameterField();
                    paramfield.Name = "时间";
                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = this.m_ParasArray[2];
                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    //制表人
                    paramfield = new ParameterField();
                    paramfield.Name = "制表人";
                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = "制表人：" + this.m_ParasArray[3];
                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    if (this.m_ParasArray.Length == 5)
                    {
                        //报表数字签名
                        paramfield = new ParameterField();
                        paramfield.Name = "报表数字签名";
                        discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = "*" + this.m_ParasArray[4] + "*";
                        paramfield.CurrentValues.Add(discreteVal);

                        m_parafields.Add(paramfield);
                        paramfield.AllowCustomValues = false;
                    }
                }

                if (this.FieldsArray == null)
                {
                    return;
                }

                int count = this.FieldsArray.Length;
                //参数数目－减掉固定的四个
                int paramscount = this.ReportDocument.DataDefinition.ParameterFields.Count - 4;

                //参数和字段数不能大于15
                if (count > 15)
                {
                    count = 15;
                }

                if (paramscount > 15)
                {
                    paramscount = 15;
                }

                for (int i = 0; i < this.FieldsArray.Length; i++)
                {
                    paramfield = new ParameterField();
                    paramfield.Name = "参数" + Convert.ToString(i + 1);

                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = this.FieldsArray[i];

                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    if (m_FieldsArray[i] == "卡号")
                    {
                        //卡号的小数位数为0
                        this.ReportDocument.DataDefinition.FormulaFields["公式" + Convert.ToString(i + 1)].Text = "totext({Report." + m_FieldsArray[i] + "},0)";
                    }
                    else
                    {
                        this.ReportDocument.DataDefinition.FormulaFields["公式" + Convert.ToString(i + 1)].Text = "totext({Report." + m_FieldsArray[i] + "})";
                    }

                }

                for (int j = this.FieldsArray.Length; j < paramscount; j++)
                {
                    paramfield = new ParameterField();
                    paramfield.Name = "参数" + Convert.ToString(j + 1);

                    discreteVal = new ParameterDiscreteValue();
                    discreteVal.Value = "";

                    paramfield.CurrentValues.Add(discreteVal);

                    m_parafields.Add(paramfield);
                    paramfield.AllowCustomValues = false;

                    this.ReportDocument.DataDefinition.FormulaFields["公式" + Convert.ToString(j + 1)].Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "报表预览", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        #endregion

        #region 属性

        /// <summary>
        /// 设定报表文档属性
        /// </summary>
        public CrystalDecisions.CrystalReports.Engine.ReportDocument ReportDocument
        {
            private get { return m_ReportDocument; }    //只允许本地访问
            set { m_ReportDocument = value; }
        }

        /// <summary>
        /// 字段数组
        /// </summary>
        public string[] FieldsArray
        {
            private get { return this.m_FieldsArray; }    //只允许本地访问
            set { m_FieldsArray = value; }
        }

        /// <summary>
        /// 动态参数
        /// </summary>
        public string Texts
        {
            private get { return this.m_texts; }    //只允许本地访问
            set { m_texts = value; }
        }

        /// <summary>
        /// 固定参数数组
        /// </summary>
        public string[] ParasArray
        {
            private get { return this.m_ParasArray; }    //只允许本地访问
            set
            {
                m_ParasArray = value;
                //InitParameterFields();
            }
        }

        /// <summary>
        /// 提供参数接口,可以动态添加参数
        /// </summary>
        public ParameterFields parameterfields
        {
            get
            {
                return this.m_parafields;
            }
            set
            {
                this.m_parafields = value;
            }
        }

        #endregion
    }
}
