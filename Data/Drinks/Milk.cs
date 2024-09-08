using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the milk drink 
    /// </summary>
    public class Milk:Drink
    {
        /// <summary>
        /// the name of the drink
        /// </summary>
        public override string Name { get; } = "Milk";
        /// <summary>
        /// the description of the milk
        /// </summary>
        public override string Description { get; } = "Creamy beverage in plain or chocolate";

        /// <summary>
        /// private backing field for Chocolate
        /// </summary>
        private bool _chocolate = false;

        /// <summary>
        /// whether the milk has chocolate or not
        /// </summary>
        public bool Chocolate
        {
            get
            {
                return _chocolate;
            }
            set
            {
                _chocolate = value;
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Chocolate));
            }
        }

        /// <summary>
        /// the price of the milk
        /// </summary>
        public override decimal Price => 2.50m;

        /// <summary>
        /// the size property of the milk
        /// </summary>
        public override Size Size
        {
            get
            {
                return Size.Kids;
            }
            set
            {
                OnPropertyChanged(nameof(Size));
                

            }
        }

        /// <summary>
        /// the number of calories  in the milk
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Chocolate == false) return 200;
                return 270;
            }
        }
   
        /// <summary>
        /// the preperation instructions for the milk
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

               
                if (Chocolate) instructions.Add("Chocolate");


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
            Milk item = (Milk)obj;
            return Size == item.Size && Chocolate == item.Chocolate;
        }

    }
}
