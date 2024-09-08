using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data


{
    /// <summary>
    ///a class representing a green chicken bowl
    /// </summary>
    public class GreenChickenBowl:Bowl,IMenuItem
    {
        /// <summary>
        /// the name of the entree
        /// </summary>
        public override string Name { get; } = "Green Chicken Bowl";

        /// <summary>
        /// the description of the green chicken bowl
        /// </summary>

        public override string Description => "Rice bowl with chicken and green things";

        

        /// <summary>
        /// the default salsa option 
        /// </summary>
        protected  override Salsa DefaultSalsa { get; } = Salsa.Green;
        /// <summary>
        /// constructor for the GreenChickenBowl class
        /// </summary>
        public GreenChickenBowl()
        {

            _possibleToppings.Clear();
            SalsaChoice = DefaultSalsa;
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
            guacamole.Included = true;
            guacamole.Default = true;

            IngredientItem sourCream = new IngredientItem(Ingredient.SourCream);
            sourCream.Default = true;
            sourCream.Included = true;
            _possibleToppings.Add(Ingredient.SourCream,sourCream);

            IngredientItem blackbeans = new IngredientItem(Ingredient.BlackBeans);
            blackbeans.Default = true;
            blackbeans.Included = true;
            _possibleToppings.Add(Ingredient.BlackBeans,blackbeans);

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
                return 9.99m;
            }
        }





    }
}