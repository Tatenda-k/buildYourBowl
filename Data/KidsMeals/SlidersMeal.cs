using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the sliders meal
    /// </summary>
    public class SlidersMeal:KidsMeal

    {
        /// <summary>
        /// the name of the meal
        /// </summary>
        public override string Name { get; } = "Sliders Kids Meal";
        /// <summary>
        /// the description of the sliders meal
        /// </summary>
        public override  string Description { get; } = "Sliders with side and drink";


        /// <summary>
        /// the main part of the sliders meal
        /// </summary>
        public override string Mainpart => "Sliders";

        ///<summary>
        ///constructor for Sliders meal
        /// </summary>
        public SlidersMeal() : base(2,4,2)

        {

            _caloriesPerItem = 150;  
        }
        /// <summary>
        /// private backing field for american cheese property
        /// </summary>
        private bool _americanCheese=true;
        /// <summary>
        /// whether american cheese is to be included
        /// </summary>

        public bool AmericanCheese 
        {
          get{
                return _americanCheese;

            }
            set
            {
                _americanCheese = value;
                if(value==false)
                  _caloriesPerItem = 110 ;
                
                if (value == true)
                    _caloriesPerItem = 150;
 
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
            }

            }

      /// <summary>
        /// the price of the sliders meal
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 5.99m;

                price += 2.0m * (ItemCount-2);

                if (SideChoice.Size == Size.Small) price += 0.50m;
                if (SideChoice.Size == Size.Medium) price += 1.0m;
                if (SideChoice.Size == Size.Large) price += 1.50m;
                if (DrinkChoice.Size == Size.Small) price += 0.50m;
                if (DrinkChoice.Size == Size.Medium) price += 1.0m;
                if (DrinkChoice.Size == Size.Large) price += 1.50m;

                return price;
            }
        }
        /// <summary>
        /// the preperation information for the sliders meal
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                if (ItemCount != 2) instructions.Add(ItemCount + " Sliders");
                if (!AmericanCheese) instructions.Add("Hold American Cheese");
                instructions.Add($"Side: {SideChoice.Name}");
                foreach (string x in SideChoice.PreparationInformation) instructions.Add("         " + x);
                instructions.Add($"Drink: {DrinkChoice.Name} ");
                foreach (string x in DrinkChoice.PreparationInformation) instructions.Add("          " + x);
                return instructions;
            }
        }

        /// <summary>
        /// returns whether this and obj are the same ingredient item
        /// </summary>
        /// <param name="obj"> the object to be compared to</param>
        /// <returns>whether this and obj are the same ingredient item</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            KidsMeal kids = (KidsMeal)obj;
            return SideChoice.Equals(kids.SideChoice) && DrinkChoice.Equals(kids.DrinkChoice);
        }
    }
}
