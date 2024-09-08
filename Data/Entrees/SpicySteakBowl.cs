using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing the spicy steak bowl
    /// </summary>
    public class SpicySteakBowl:Bowl,IMenuItem
    {
        /// <summary>
        /// the name of the entree
        /// </summary>
        public override string Name { get; } = "Spicy Steak Bowl";
        /// <summary>
        /// the description of the spicy steak bowl
        /// </summary>
        public override string Description { get; } = "Spicy rice bowl with steak and fajita toppings";

        /// <summary>
        /// the default salsa option 
        /// </summary>
        protected override Salsa DefaultSalsa { get; } = Salsa.Hot;

        /// <summary>
        /// constructor for the SpicySteakBowl class
        /// </summary>
        public SpicySteakBowl()
        {
            SalsaChoice = DefaultSalsa;
            _possibleToppings.Clear();
            IngredientItem steak = new IngredientItem(Ingredient.Steak);
            steak.Default = true;
            steak.Included = true;
            _possibleToppings.Add(Ingredient.Steak,steak);

            IngredientItem veggies = new IngredientItem(Ingredient.Veggies);
            _possibleToppings.Add(Ingredient.Veggies,veggies);

            IngredientItem queso = new IngredientItem(Ingredient.Queso);
            queso.Default = true;
            queso.Included = true;
            _possibleToppings.Add(Ingredient.Queso,queso);

            IngredientItem guacamole = new IngredientItem(Ingredient.Guacamole);
            _possibleToppings.Add(Ingredient.Guacamole,guacamole);
           
            IngredientItem sourCream = new IngredientItem(Ingredient.SourCream);
            sourCream.Default = true;
            sourCream.Included = true;
            _possibleToppings.Add(Ingredient.SourCream,sourCream);
            foreach (KeyValuePair<Ingredient, IngredientItem> item in _possibleToppings)
            {
                item.Value.PropertyChanged += HandlePropertyChanged;
            }


        }
        /// <summary>
        /// price of a spicy steak bowl
        /// </summary>
        public override decimal Price
        {
            get
            {
                decimal price = 10.99m;
                Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
                if (value!.Included) price += 1;
                return price;
            }
        }


    }
}
