using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpf.Printing;
using System.Windows.Threading;
using DevExpress.Data.Utils.ServiceModel;
using DevExpress.Xpf.Printing.BrickCollection;
using DevExpress.Xpf.Printing.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.DataNodes;
using System.Collections.Generic;
using System.Windows;

namespace Spark.Report
{
    public partial class InvoiceDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public InvoiceDetail()
        {
            InitializeComponent();
        }

      

        public static void PrintReport()
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail();
            invoiceDetail.CreateDocument();
            Action p = () =>
               {
                   var report = invoiceDetail.Report;
                   PrintHelper.Print(invoiceDetail);
               };
            Dispatcher.CurrentDispatcher.Invoke(p);
        }

    }
}
