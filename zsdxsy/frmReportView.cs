using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace YC.Components
{
    internal partial class frmReportView : Form
    {

        //¹¹Ôìº¯Êý
        public frmReportView(object DataSource, ParameterFields parafields)
        {
            InitializeComponent();
            m_DataSource = DataSource;
            m_parafields = parafields;
        }

        private object m_DataSource;
        private ParameterFields m_parafields;

        private void frmReportView_Load(object sender, EventArgs e)
        {
           // this.ReportViewer.Cursor = Cursors.Default;

            if (m_parafields != null && m_parafields.Count > 0)
            {
                this.ReportViewer.ParameterFieldInfo = m_parafields;
            }

            this.ReportViewer.EnableDrillDown = false;
            this.ReportViewer.ShowCloseButton = true;
            this.ReportViewer.ReportSource = m_DataSource;
        }
    }
}