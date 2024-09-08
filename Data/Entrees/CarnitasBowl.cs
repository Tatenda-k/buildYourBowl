using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing a  carnitas bowl
    /// </summary>
    public class CarnitasBowl : Bowl, IMenuItem
    {
        /// <summary>
        /// the name of the meal
        /// </summary>
        public override string Name { get; } = "Carnitas Bowl";
        /// <summary>
        /// the description of the carnitas bowl 
        /// </summary>
        public override string Description { get; } = "Rice bowl with carnitas and extras";

        /// <summary>
        /// the default salsa option 
        /// </summary>
        protected override Salsa DefaultSalsa { get; } = Salsa.Medium;

        /// <summary>
        /// constructor for the SpicySteakBowl class
        /// </summary>
        public CarnitasBowl()
        {
            SalsaChoice = DefaultSalsa;
            _possibleToppings.Clear();
            IngredientItem carnitas = new IngredientItem(Ingredient.Carnitas);
            carnitas.Default = true;
            carnitas.Included = true;
            _possibleToppings.Add(Ingredient.Carnitas,carnitas);

            IngredientItem veggies = new IngredientItem(Ingredient.Veggies);
            _possibleToppings.Add(Ingredient.Veggies,veggies);

            IngredientItem queso = new IngredientItem(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;
            _possibleToppings.Add(Ingredient.Queso,queso);

            IngredientItem pintoBeans = new IngredientItem(Ingredient.PintoBeans);
            pintoBeans.Default = true;
            pintoBeans.Included = true;
            _possibleToppings.Add(Ingredient.PintoBeans,pintoBeans);



            IngredientItem guacamole = new IngredientItem(Ingredient.Guacamole);
            _possibleToppings.Add(Ingredient.Guacamole,guacamole);

            IngredientItem sourCream = new IngredientItem(Ingredient.SourCream);
            
            _possibleToppings.Add(Ingredient.SourCream,sourCream);
            foreach(KeyValuePair<Ingredient,IngredientItem> item in _possibleToppings)
            {
                item.Value.PropertyChanged += HandlePropertyChanged;
            }


        }

        /// <summary>
        /// price of a green chicken bowl
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 9.99m;
                Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
                if (value!.Included) price += 1;
                return price;
            }
        }





    }
}



