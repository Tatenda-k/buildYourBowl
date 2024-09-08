using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing a chicken fajita nachos
    /// </summary>
    public class ChickenFajitaNachos:Nachos,IMenuItem
    {
        /// <summary>
        /// the name of the entree
        /// </summary>
        public override string Name { get; } = "Chicken Fajita Nachos";
        /// <summary>
        /// the description of the chicken fajita nachos
        /// </summary>
        public override string Description { get; } = "Chicken fajitas but with chips";


        /// <summary>
        /// the default salsa option 
        /// </summary>
        protected override Salsa DefaultSalsa { get; } = Salsa.Medium;
        /// <summary>


        /// <summary>
        /// constructor for the ChickenFajitaNachos class
        /// </summary>

        public ChickenFajitaNachos()
        {
            _possibleToppings.Clear();
            IngredientItem chicken = new IngredientItem(Ingredient.Chicken);
            chicken.Default = true;
            chicken.Included = true;
            _possibleToppings.Add(Ingredient.Chicken,chicken);

            IngredientItem veggies = new IngredientItem(Ingredient.Veggies);
            veggies.Default = true;
            veggies.Included = true;
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
        /// price of a chicken fajita nacho
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
