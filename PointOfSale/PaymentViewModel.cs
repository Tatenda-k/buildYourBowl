using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;
using System.Windows;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// View Model for the PaymentControl
    /// </summary>
    public class PaymentViewModel: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// the current order
        /// </summary>
        private Order _order;

        /// <summary>
        /// the order's total
        /// </summary>
        public decimal Total => _order.Total;

        /// <summary>
        /// the order's subtotal
        /// </summary>
        public decimal Subtotal => _order.Subtotal;

        /// <summary>
        /// whether the payment's have been made, and the order can be completed
        /// </summary>
        public bool Finalize => Change >= 0;

        /// <summary>
        /// the order's tax
        /// </summary>
        public decimal Tax => _order.Tax;

        /// <summary>
        /// private baacking field for Paid
        /// </summary>
        private decimal _paid;

        /// <summary>
        /// how much the user paid for the order
        /// </summary>
        public decimal Paid
        {
            set
            {
                if (value < Total)
                {
                    _paid = 0;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayError)));

                    //error.Visibility = Visibility.Visible;

                    throw new ArgumentException("less than cost");
                    
                }
                //enabling button, showing textblock with error messages
                //handling invalid paid values, making change display dissappear
                _paid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Paid)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Change)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Finalize)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayError)));


            }
            get
            {
                return _paid;
            }
        }
        /// <summary>
        /// returns an error message when payment is not enough
        /// </summary>
        public string DisplayError
        {
            get
            {
                if (Finalize == true)
                {
                    return "";
                }
                else
                {
                    return "Insufficient funds";
                }
            }
        }
        /// <summary>
        /// calculate's the user's change
        /// </summary>
        public decimal Change
        {
            get
            {
                return Paid - Total;
            }
        }
        /// <summary>
        /// the receipt information
        /// </summary>
        public string Receipt
        {
            get
            {
                StringBuilder sb = new();
                sb.AppendLine($"Order Number: {_order.Number}");
                sb.AppendLine($"Placed At: {_order.PlacedAt}");
                
                foreach(IMenuItem item in _order)
                {
                    sb.Append($"{item.Name}: ");
                    sb.AppendLine(item.Price.ToString());
                    foreach(string str in item.PreparationInformation)
                    {
                        sb.AppendLine(str);
                    }

                }
                sb.AppendLine($"Subtotal: {Subtotal}");
                sb.AppendLine($"Total: {Total}");
                sb.AppendLine($"Tax: {Tax}");
                sb.AppendLine($"Paid: {Paid}");
                sb.AppendLine($"Change: {Change}");
                sb.AppendLine("...................................................");
                return sb.ToString();
            }

        }

        public PaymentViewModel(Order order)
        {
            _order = order;
            _paid = order.Total;
         

        }
       
    }
}
