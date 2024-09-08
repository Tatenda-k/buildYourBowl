using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing fries
    /// </summary>
    public class Fries: Side,IMenuItem
    {
        /// <summary>
        /// the name of the dish
        /// </summary>
        public override string Name { get; } = "Fries";
        /// <summary>
        /// the description of the fries
        /// </summary>
        public override string Description { get; } = "Crispy salty sticks of deliciousness";

        /// <summary>
        /// the price of the fries
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 3.50m;

                if (Size == Size.Kids) price -= 1m;
                else if (Size == Size.Large) price += 0.75m;
                else if (Size == Size.Small) price -= 0.50m;
                return price;
            }
        }
        /// <summary>
        /// the calories in the fries
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 350;
                if (Size == Size.Kids) cals = (uint)(cals * 0.60);
                if (Size == Size.Small) cals = (uint)(cals * 0.75);
                if (Size == Size.Large) cals = (uint)(cals * 1.5);
                return cals;
            }
        }
        /// <summary>
        /// private backing field for Curly
        /// </summary>
        private bool _curly = false;

        /// <summary>
        /// whether the fries are curly
        /// </summary>
        public bool Curly
        {
            get
            {
                return _curly;
            }
            set
            {
                _curly = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Curly));

            }
        }
 
        /// <summary>
        /// preperation information for the fries
        /// </summary>
        public override  IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();
                if (Curly) instructions.Add("Curly");
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
            Fries item = (Fries)obj;
            return Size == item.Size && Curly == item.Curly ;
        }

    }

}
