using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Printing;

namespace Report
{
    public partial class İnvoiceDetails : XtraReport
    {
        public İnvoiceDetails()
        {
            InitializeComponent();
        }

        public static void PrintReport()
        {
            XtraReport rep = new XtraReport();
            rep.CreateDocument();
            PrintHelper.Print(rep);
        }

    }
}
