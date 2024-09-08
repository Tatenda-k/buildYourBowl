using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       public MainWindow()
        {
            InitializeComponent();
             _order = new();
            DataContext =_order;
            MenuItemDisplay.CustomizeEvent += OnAddedItem;
            OrderSummaryControl.CustomizeEvent += OnAddedItem;
            OrderSummaryControl.EditEvent += OnEdit;
            PaymentControl.CompleteOrderEvent += OrderPaid;
            _item_control = MenuItemDisplay;


        }
        /// <summary>
        /// the current order
        /// </summary>
        private Order _order;

        /// <summary>
        /// keeps track of the control being shown in the space assigned for the MenuItemDisplay
        /// </summary>
        private UserControl? _item_control;


        /// <summary>
        ///event listener for adding/editting items
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        public void OnAddedItem(object? sender,CustomizeItemEventArgs e)
        {
           /// only if it is not the same item
            _item_control!.Visibility = Visibility.Hidden;
            //remove should take us back to menu

            if (e.MenuItem is Entree)
            {
                EntreeControl.Visibility = Visibility.Visible;
                EntreeControl.DataContext = e.MenuItem;
                _item_control = EntreeControl;
            }
            if (e.MenuItem is Fries)
            {
                FriesControl.DataContext = e.MenuItem;
                FriesControl.Visibility = Visibility.Visible;
                _item_control = FriesControl;

            }
            if (e.MenuItem is RefriedBeans)
            {
                RefriedBeansControl.DataContext = e.MenuItem;
               RefriedBeansControl.Visibility = Visibility.Visible;
                _item_control = RefriedBeansControl;

            }
            if (e.MenuItem is StreetCorn)
            {
                StreetCornControl.DataContext = e.MenuItem;
                StreetCornControl.Visibility = Visibility.Visible;
                _item_control = StreetCornControl;

            }
            if (e.MenuItem is AguaFresca)
            {
                AguaFrescaControl.DataContext = e.MenuItem;
                AguaFrescaControl.Visibility = Visibility.Visible;
                _item_control = AguaFrescaControl;

            }
            if (e.MenuItem is Horchata)
            {
                HorchataControl.DataContext = e.MenuItem;
                HorchataControl.Visibility = Visibility.Visible;
                _item_control = HorchataControl;

            }
            if (e.MenuItem is Milk)
            {
                MilkControl.DataContext = e.MenuItem;
                MilkControl.Visibility = Visibility.Visible;
                _item_control = MilkControl;

            }

            if (e.MenuItem is KidsMeal) AddKidsMeal(sender, e);            
        }
        /// <summary>
        ///event listener for adding/editting items
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        public void OnEdit(object? sender, EditItemEventArgs e)
        {
            _item_control!.Visibility = Visibility.Hidden;
       

            if (e.MenuItem is Entree)
            {
                EntreeControl.Visibility = Visibility.Visible;
                EntreeControl.DataContext = e.MenuItem;
            
                _item_control = EntreeControl;
            }
            

            else if (e.MenuItem is KidsMeal)
            {
                MenuItemDisplay.Visibility = Visibility.Hidden;
                KidsMealControl.Visibility = Visibility.Visible;
                KidsMeal? meal = e.MenuItem as KidsMeal;
                KidsMealControl.DataContext = e.MenuItem;
                if (meal != null)
                {
                    KidsMealControl.SideControl.DataContext = meal.SideChoice;
                    KidsMealControl.DrinkControl.DataContext = meal.DrinkChoice;
                    _item_control = KidsMealControl;
                }
                if (meal is SlidersMeal) KidsMealControl.cheese.Visibility = Visibility.Visible;
               else KidsMealControl.cheese.Visibility = Visibility.Hidden;
            }
            else
            {
                OnAddedItem(sender, new CustomizeItemEventArgs(e.MenuItem));
            }
        }

        /// <summary>
        ///enables editting of kid meals
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        public void AddKidsMeal(object? sender, CustomizeItemEventArgs e)
        {
            MenuItemDisplay.Visibility = Visibility.Hidden;
            KidsMealControl.Visibility = Visibility.Visible;

            KidsMeal? meal = e.MenuItem as KidsMeal;
            

            KidsMealControl.DataContext = e.MenuItem;
            //two seperate thingsI wanted to do for the kids meal
            KidsMealControl.FriesB.IsChecked = true;
            KidsMealControl.MilkB.IsChecked = true;
            if (meal != null) 
            { 
                KidsMealControl.SideControl.DataContext = meal.SideChoice; 
                KidsMealControl.DrinkControl.DataContext = meal.DrinkChoice;
               
                _item_control = KidsMealControl;
                

            }

            if (meal is SlidersMeal) KidsMealControl.cheese.Visibility = Visibility.Visible;
            else KidsMealControl.cheese.Visibility = Visibility.Hidden;


        }


        /// <summary>
        ///cancels the order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        public void CancelOrder(object? sender,  RoutedEventArgs e)
        {
         
                _order = new();
                DataContext = _order;
                _item_control!.Visibility = Visibility.Hidden;
                MenuItemDisplay.Visibility = Visibility.Visible;

                _item_control = MenuItemDisplay;

            

        }

        
        /// <summary>
        /// sends user back to the menu
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        public void BackToMenu(object sender, RoutedEventArgs e)
        {
            if (MenuItemDisplay.Visibility == Visibility.Hidden)
            {
                MenuItemDisplay.Visibility = Visibility.Visible;
                _item_control!.Visibility = Visibility.Hidden;
            }
            _item_control = MenuItemDisplay;

        }
        /// <summary>
        ///completes the  order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            _item_control!.Visibility = Visibility.Hidden;
            PaymentControl.Visibility = Visibility.Visible;
            PaymentControl.DataContext = new PaymentViewModel(_order);         
            _item_control = PaymentControl;
           
        }
        /// <summary>
        ///completes the  order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void OrderPaid(object? sender, CompleteOrderEventArgs e)
        {
            _order = new();
            DataContext = _order;
         
            _item_control!.Visibility = Visibility.Hidden;
            MenuItemDisplay.Visibility = Visibility.Visible;

            _item_control = MenuItemDisplay;

        }


    }
}
