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
    /// Interaction logic for KidsMealControl.xaml
    /// </summary>
    public partial class KidsMealControl : UserControl
    {
        public KidsMealControl()
        {
            InitializeComponent();
            
        }

    
     
        /// <summary>
        ///select side or drink  for kid's meal
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void SelectSide(object sender, RoutedEventArgs e)
        {
            if(sender is RadioButton b)
            {
              
                  
                { 
                   KidsMeal? meal = DataContext as KidsMeal;

                    switch (b.Content)
                    {
                        case "Fries":

                            if (meal!.SideChoice == b.DataContext)
                            {
                                Fries fries = new();
                                meal!.SideChoice = fries;
                            }
                            SideContainer.Child = null;
                            SideContainer.Child = new FriesControl();
                            SideControl.DataContext = meal!.SideChoice;
                           

                            break;

                        case "RefriedBeans":

                            RefriedBeans beans = new();
                            meal!.SideChoice = beans;
                            SideContainer.Child = null;
                            SideContainer.Child = new RefriedBeansControl(); 
                            SideControl.DataContext = beans;
                            
                            break;

                        case "StreetCorn":
                            StreetCorn corn = new();
                            meal!.SideChoice = corn;
                            SideContainer.Child = null;
                            SideContainer.Child = new StreetCornControl();
                            SideControl.DataContext = corn;
                            
                            break;

                        case "Milk":
                            if (meal!.DrinkChoice == b.DataContext)
                            {
                                Milk milk = new();
                                meal!.DrinkChoice = milk;
                            }

 
                            DrinkContainer.Child = null;
                            DrinkContainer.Child = new MilkControl();
                            DrinkControl.DataContext = meal!.DrinkChoice;

                            break;

                        case "AguaFresca":

                            AguaFresca drink = new();
                            meal!.DrinkChoice = drink;
                            DrinkContainer.Child = null;
                            DrinkContainer.Child = new AguaFrescaControl();
                            DrinkControl.DataContext = drink;
                            break;

                        case "Horchata":
                            Horchata horchata = new();
                            meal!.DrinkChoice = horchata;
                            DrinkContainer.Child = null;
                            DrinkContainer.Child = new HorchataControl();
                            DrinkControl.DataContext = horchata;
                            break;
                    }
                }
            }

        }

 

        
    }
}
