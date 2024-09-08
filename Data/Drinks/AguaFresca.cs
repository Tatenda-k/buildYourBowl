using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data
{
    /// <summary>
    /// the class representing the agua fresca drink
    /// </summary>
    public class AguaFresca:Drink
    {
        /// <summary>
        /// the name of the drink
        /// </summary>
        public override string Name { get; } = "Agua Fresca";
        /// <summary>
        /// the description of the agua fresca
        /// </summary>
        public override string Description { get; } = "Refreshing lightly sweetened fruit drink";

        /// <summary>
        /// private backing field for Ice
        /// </summary>
        private bool _ice = true;

        /// <summary>
        /// whehther the agua fresca has ice or not
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
        /// the price of the agua fresca
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 0m;
                if (Flavor == Flavor.Tamarind) price += 0.50m;
                if (Size == Size.Kids) price += 2.00m;
                else if (Size == Size.Small) price += 2.50m;
                else if (Size == Size.Medium) price += 3.00m;
                else if (Size == Size.Large) price += 3.75m;
                
                return price;
            }
        }
        /// <summary>
        /// private backing field for flavor
        /// </summary>
        private Flavor _flavor = Flavor.Limonada;

        /// <summary>
        /// the flavor of the agua fresca
        /// </summary>
        public Flavor Flavor
        {
            get
            {
                return _flavor;
            }
            set
            {
                _flavor = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Flavor));
            }
        }
        

        /// <summary>
        /// the calories in the agua fresca
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint cals = 0;

                if (Flavor == Flavor.Limonada || Flavor == Flavor.Lime) cals = 125;
                else if (Flavor == Flavor.Tamarind || Flavor == Flavor.Strawberry) cals = 150;
                else if(Flavor==Flavor.Cucumber ) cals = 75;
                if (!Ice) cals += 10;
                if (Size == Size.Kids) cals = (uint) (0.6 * cals);
                else if (Size == Size.Small) cals = (uint)(0.75 * cals);
                else if (Size == Size.Large) cals = (uint)(1.5 * cals);

                return cals;
            }
        }
  
        /// <summary>
        /// the preperation information for the agua fresca
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new()
                {
                  
                    Size.ToString(),
                    Flavor.ToString()
                };
                if (!Ice) instructions.Add("Hold Ice");



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
            AguaFresca item = (AguaFresca)obj;
            return Size == item.Size && Ice==item.Ice;
        }
    }
}
