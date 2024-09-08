using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using BuildYourBowl;
using BuildYourBowl.Data;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
           

        }


        /// <summary>
        /// event handler for customizing MenuItems
        /// </summary>
        public event EventHandler<CustomizeItemEventArgs>? CustomizeEvent;

    
        /// <summary>
        ///adds item to order
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            IMenuItem? item=null;
          
            if(sender is Button button  )
            {
                if (DataContext is Order order) {

                    if (button.Name == "Milk") item = new Milk();
                    else if (button.Name == "Horchata") item = new Horchata();
                    else if (button.Name == "AguaFresca") item = new AguaFresca();

                    else if (button.Name == "Fries") item = new Fries();
                    else if (button.Name == "RefriedBeans") item = new RefriedBeans();
                    else if (button.Name == "StreetCorn") item = new StreetCorn();

                    else if (button.Name == "GreenChicken") item = new GreenChickenBowl();
                    else if (button.Name == "ClassicNachos") item = new ClassicNachos();
                    else if (button.Name == "ChickenFajita") item = new ChickenFajitaNachos();
                    else if (button.Name == "Carnitas") item = new CarnitasBowl();
                    else if (button.Name == "SpicySteak") item = new SpicySteakBowl();
                    else if (button.Name == "CustomBowl") item = new Bowl();
                    else if (button.Name == "CustomNachos") item = new Nachos();

                    else if (button.Name == "Sliders") item = new SlidersMeal();
                    else if (button.Name == "ChickenNuggets") item = new ChickenNuggetsMeal();
                    else if (button.Name == "CornDog") item = new CornDogBitesMeal();

                    
                        order.Add(item!);

                CustomizeEvent?.Invoke(this, new CustomizeItemEventArgs(item!));
                }
            }

        }

       
       
        

    }
}
