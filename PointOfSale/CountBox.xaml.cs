using BuildYourBowl.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for CountBox.xaml
    /// </summary>
    public partial class CountBox : UserControl
    {
        public CountBox()
        {
            InitializeComponent();

          
        }
        /// <summary>
        /// the count of main items in the kids meal
        /// </summary>
        public uint Count
        {
            get
            {
                return (uint)GetValue(CountProperty);
            }
            set
            {
                SetValue(CountProperty, value);
            }
        }
        /// <summary>
        ///Identifies the CountBox.Count XAML attached property
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(uint), typeof(CountBox), new PropertyMetadata(1u));

        /// <summary>
        ///decreases count within bounds
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            KidsMeal? meal = DataContext as KidsMeal;
            if (meal != null) meal.ItemCount--;


        }

        /// <summary>
        ///increases count within bounds
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            KidsMeal? meal = DataContext as KidsMeal;
            if (meal != null) meal.ItemCount++;
        }
    }
}
