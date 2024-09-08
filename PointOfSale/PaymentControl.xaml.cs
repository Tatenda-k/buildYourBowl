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
using System.IO;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event handler for completing order
        /// </summary>
        public event EventHandler<CompleteOrderEventArgs>? CompleteOrderEvent;
        /// <summary>
        ///complete the order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void ClickComplete(object? sender, RoutedEventArgs e)
        {
            if(DataContext is PaymentViewModel)
            {
                PaymentViewModel? model = DataContext as PaymentViewModel;
                string receipt = model!.Receipt;
                File.AppendAllText("receipt.txt",receipt);
                MessageBox.Show("Receipt has beenk printed. Click OK to start a new order");
                CompleteOrderEvent?.Invoke(this, new CompleteOrderEventArgs());
                


            }
        }
    }
}
