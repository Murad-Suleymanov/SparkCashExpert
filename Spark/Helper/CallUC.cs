using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Spark.Helper
{
    public class CallUC
    {
        public  delegate void FillUCDelegate(Grid grd, UserControl uc);
        public static void FillUC(Grid grd, UserControl uc)
        {
                if (grd.Children.Count > 0)
                {
                    grd.Children.Clear();
                    grd.Children.Add(uc);
                }
                else
                    grd.Children.Add(uc);
        }
    }
}
