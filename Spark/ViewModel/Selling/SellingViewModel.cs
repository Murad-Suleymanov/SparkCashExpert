using System;
using System.Windows.Controls;

namespace Spark.ViewModel.Selling
{
    public class SellingViewModel : UCViewModel
    {
        public override string Header => "Satis";
        public override UserControl UserControl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DataGrid DataGrid { get; set; }


        private bool myVar;

        //public Selling 
        //{
        //    get => myVar; 
        //    set
        //    {
        //        if()
        //        myVar = value;
        //    }
        //}

    }
}
