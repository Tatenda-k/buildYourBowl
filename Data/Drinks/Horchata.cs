using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{/// <summary>
/// a class representing the horchata drink
/// </summary>
    public class Horchata:Drink
    {
        /// <summary>
        /// the name of the drink
        /// </summary>
        public override string Name { get; } = "Horchata";
        /// <summary>
        /// the description of the horchata
        /// </summary>
        public override string Description { get; } = "Milky drink with cinnamon";

        /// <summary>
        /// private backing field for Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// whehther the horchata has ice or not
        /// </summary>
        public bool Ice
        {
            get
            {
                return _ice;
            }
            set
            {
                _ice = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Ice));
            }
        }


        /// <summary>
        /// the number of calories in a medium horchata
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 280;
                if (!Ice) cals += 30;
                if (Size == Size.Kids) cals = (uint)(cals * 0.60);
                if (Size == Size.Small) cals = (uint)(cals * 0.75);
                if (Size == Size.Large) cals = (uint)(cals * 1.5);
                return cals;
            }
        }



        /// <summary>
        /// the price of the horchata
        /// </summary>
        public override  decimal Price
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
        ///the preperation instructions for the horchata
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();

                
                if (!Ice) instructions.Add("Hold Ice");

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
            Horchata item = (Horchata)obj;
            return Size == item.Size && Ice == item.Ice;

        }
    }
}
