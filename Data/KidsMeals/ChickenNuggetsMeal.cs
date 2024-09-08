using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the chicken nuggets meal
    /// </summary>
    public class ChickenNuggetsMeal:KidsMeal
    {
        /// <summary>
        /// the name of the meal
        /// </summary>
        public override string Name { get; } = "Chicken Nuggets Kids Meal";
        /// <summary>
        /// the description of the chicken nuggets
        /// </summary>
        public  override string Description { get; } = "Chicken nuggets with side and drink";
       
        ///<summary>
        ///constructor for Chicken Nuggets meal
        /// </summary>
        public ChickenNuggetsMeal() : base(5, 8, 5)
        {
            _caloriesPerItem = 60;
         

        }
        /// <summary>
        /// the main part of the nuggets meal
        /// </summary>
        public override string Mainpart =>"Nuggets";
        /// <summary>
        /// the price for the chicken nuggets meal
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 5.99m;
                price += 0.75m * (ItemCount-5);
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
        /// the preparation information for the chicken  nuggets meal
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
            
                if (ItemCount != 5) instructions.Add(ItemCount + " Nuggets");
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
