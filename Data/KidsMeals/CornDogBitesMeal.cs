using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the corn dog bites meal
    /// </summary>
    public class CornDogBitesMeal:KidsMeal
    {
        /// <summary>
        /// the name of the meal
        /// </summary>
        public  override string Name { get; } = "Corn Dog Bites Kids Meal";
        /// <summary>
        /// the description of the corn dog bites meal
        /// </summary>
        public override string Description { get; } = "Mini corn dogs with side and drink";

        ///<summary>
        /// the main part of the corn dog bites meal
        /// </summary>
        public override string Mainpart => "Bites";

        ///<summary>
        ///constructor for CornDogBites meal
        /// </summary>
        public CornDogBitesMeal(): base (5,8,5)
        {
            _caloriesPerItem = 50;
        }
       

        /// <summary>
        /// the pirce of the corn dog bites meal
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 5.99m;

                price += 0.75m *( ItemCount-_defaultCount);

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
        /// the preparation information for the corn dog bites meal
        /// </summary>

        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                if (ItemCount != 5) instructions.Add(ItemCount + " Bites");
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
