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
using BuildYourBowl.Data;


namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event handler for customizing MenuItems
        /// </summary>
        
        public event EventHandler<EditItemEventArgs>? EditEvent;

        public event EventHandler<CustomizeItemEventArgs>? CustomizeEvent;

        /// <summary>
        /// removes an item from the order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for this event</param>
        private void ClickRemove(object sender, RoutedEventArgs e)
        {

            if(sender is Button b)
            {
                if(b.DataContext is IMenuItem item)
                {
                    if(DataContext is Order order)
                    {
                        order.Remove(item);
                        ((MainWindow)Application.Current.MainWindow).BackToMenu(sender,e);

                    }
                }
            }

        }
        /// <summary>
        /// edits an item from the order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">netadata for this event </param>
        private void ClickEdit(object sender,RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(b.DataContext is IMenuItem item)
                {
                    if(DataContext is Order order)
                    {
                        EditEvent?.Invoke(this, new EditItemEventArgs(item));

                    }
                }
            }
        }
    }
}
