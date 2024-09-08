using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the refried beans
    /// </summary>
    public class RefriedBeans:Side,IMenuItem
    {

        /// <summary>
        /// the name of the dish
        /// </summary>
        public override string Name { get; } = "Refried Beans";
        /// <summary>
        /// the description of the beans
        /// </summary>
        public override string Description { get; } = "Beans fried not just once but twice";

        /// <summary>
        /// private backing field for Onions
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// whether the beans have onions 
        /// </summary>
        public bool Onions
        {
            get
            {
                return _onions;
            }
            set
            {
                _onions = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Onions));

            }
        }
        /// <summary>
        /// private backing field for CheddarCheese
        /// </summary>
        private bool _cheddar = true;

        /// <summary>
        /// whether the beans have cheddar cheese 
        /// </summary>
        public bool CheddarCheese
        {
            get
            {
                return _cheddar;
            }
            set
            {
                _cheddar = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(CheddarCheese));

            }
        }


        /// <summary>
        /// the price of the beans
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 3.75m;
                if (Size == Size.Kids) price -= 1m;
                else if (Size == Size.Large) price += 0.75m;
                else if (Size == Size.Small) price -= 0.50m;
                return price;
            }
        }

        /// <summary>
        /// the calories in the refried beans
        /// </summary>
        public override  uint Calories
        {
            get
            {
                uint cals = 300;

                if (CheddarCheese == false) cals -= 90;

                if (Onions == false) cals -= 5;
                if (Size == Size.Kids) cals = (uint)(cals * 0.60);
                if (Size == Size.Small) cals = (uint)(cals * 0.75);
                if (Size == Size.Large) cals = (uint)(cals * 1.5);
                return cals;
            }
        }
 
        /// <summary>
        /// the preperation information of the benas
        /// </summary>

        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
               
                if (!Onions) instructions.Add("Hold Onions");
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                instructions.Add(Size.ToString());

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
            RefriedBeans item = (RefriedBeans)obj;
            return  Size == item.Size  && Onions == item.Onions && item.CheddarCheese == CheddarCheese;
        }
    }
}
