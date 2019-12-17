﻿using Spark.ViewModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spark.View
{
    /// <summary>
    /// Interaction logic for ChangeAmount.xaml
    /// </summary>
    public partial class ChangeAmount : Window
    {
        ChangeAmountViewModel changeAmountVM;
        public ChangeAmount()
        {
            InitializeComponent();
            changeAmountVM = new ChangeAmountViewModel();
            DataContext = this.changeAmountVM;
            changeAmountVM.CurrentWindow = this;
        }
    }
}
