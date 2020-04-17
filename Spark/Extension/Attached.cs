using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Spark.Extension
{
    public enum LastFocusedEntityType { None, Record, Row }

    public class Attached
    {
        public static string GetFocussedElementName(DependencyObject obj)
        {
            return (string)obj.GetValue(FocussedElementNameProperty);
        }

        public static void SetFocussedElementName(DependencyObject obj, string value)
        {
            obj.SetValue(FocussedElementNameProperty, value);
        }

        public static readonly DependencyProperty FocussedElementNameProperty =
            DependencyProperty.RegisterAttached("FocussedElementName", typeof(string), typeof(Attached), new UIPropertyMetadata(null, ElementNamePropertyChanged));

        static void ElementNamePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var ele = sender as FrameworkElement;
            if ((string)e.NewValue == ele.Name)
                ele.Focus();
        }
    }
}
