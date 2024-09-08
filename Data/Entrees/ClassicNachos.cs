using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a class representing a classic nachos
    /// </summary>
    public class ClassicNachos:Nachos,IMenuItem
    {
        /// <summary>
        /// the name of the entree
        /// </summary>
        public override string Name { get; } = "Classic Nachos";
        /// <summary>
        /// the description of the classic nachos
        /// </summary>
        public override string Description { get; } = "Standard nachos with steak, chicken, and cheese";


        /// <summary>
        /// the default salsa option 
        /// </summary>
        protected override Salsa DefaultSalsa { get; } = Salsa.Medium;






        /// <summary>
        /// constructor for the ChickenFajitaNachos class
        /// </summary>

        public ClassicNachos()
        {
            SalsaChoice = DefaultSalsa;
            _possibleToppings.Clear();
            IngredientItem chicken = new IngredientItem(Ingredient.Chicken);
            chicken.Default = true;
            chicken.Included = true;

            _possibleToppings.Add(Ingredient.Chicken,chicken);
            IngredientItem steak = new IngredientItem(Ingredient.Steak);
             steak.Default = true;
            steak.Included = true;

            _possibleToppings.Add(Ingredient.Steak,steak);  
            
            IngredientItem queso = new IngredientItem(Ingredient.Queso);
            queso.Default = true;
             queso.Included= true;
            _possibleToppings.Add(Ingredient.Queso,queso);

            IngredientItem guacamole = new IngredientItem(Ingredient.Guacamole);
            _possibleToppings.Add(Ingredient.Guacamole,guacamole);

            IngredientItem sourCream = new IngredientItem(Ingredient.SourCream);
            _possibleToppings.Add(Ingredient.SourCream,sourCream);

            foreach (KeyValuePair<Ingredient, IngredientItem> item in _possibleToppings)
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
                decimal price = 12.99m;
                Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
                if (value!.Included) price += 1;
                return price;
            }
        }


    }
}
