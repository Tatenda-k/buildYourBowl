using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the street corn
    /// </summary>
    public class StreetCorn : Side
    {

        /// <summary>
        /// the name of the dish
        /// </summary>
        public override string Name { get; } = "Street Corn";
        /// <summary>
        /// the description of the corn
        /// </summary>
        public override string Description { get; } = "The zestiest corn out there";

        /// <summary>
        /// private backing field for Onions
        /// </summary>
        private bool _cilantro = true;

        /// <summary>
        /// whether the beans have onions 
        /// </summary>
        public bool Cilantro
        {
            get
            {
                return _cilantro;
            }
            set
            {
                _cilantro = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Cilantro));



            }
        }

        /// <summary>
        /// private backing field for Onions
        /// </summary>
        private bool _cheese = true;

        /// <summary>
        /// whether the beans have onions 
        /// </summary>
        public bool CotijaCheese
        {
            get
            {
                return _cheese;
            }
            set
            {
                _cheese = value;
                OnPropertyChanged(nameof(PreparationInformation));
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(CotijaCheese));



            }
        }


        /// <summary>
        /// the preperation information for the street corn
        /// </summary>
        public override IEnumerable<string> PreparationInformation
        {
            get
            {
                List<string> instructions = new();


                if (!Cilantro) instructions.Add("Hold Cilantro");
                if (!CotijaCheese) instructions.Add("Hold Cotija Cheese");
                instructions.Add(Size.ToString());




                return instructions;
            }
        }
        /// <summary>
        /// the calories in the corn
        /// </summary>

        public override uint Calories
        {
            get
            {
                uint cals = 300;

                if (CotijaCheese == false) cals -= 80;



                if (Cilantro == false) cals -= 5;

                if (Size == Size.Kids) cals = (uint)(cals * 0.60);
                if (Size == Size.Small) cals = (uint)(cals * 0.75);
                if (Size == Size.Large) cals = (uint)(cals * 1.5);
                return cals;
            }
        }

        /// <summary>
        /// the price of the corn
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 4.50m;
                if (Size == Size.Kids) price -= 1.25m;
                else if (Size == Size.Large) price += 1m;
                else if (Size == Size.Small) price -= 0.75m;
                return price;
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
            StreetCorn item = (StreetCorn)obj;
            return   Size == item.Size  && Cilantro==item.Cilantro && item.CotijaCheese ==CotijaCheese;
        }



    }
}
