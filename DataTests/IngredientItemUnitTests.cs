using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// class for testing out the ingredientItem class
    /// </summary>
    public class IngredientItemUnitTests
    {
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
        /// <param name="propertyName">the property that will change</param>
        /// <param name="included">whether the ingredient included</param>
        [Theory]
        [InlineData(Ingredient.Veggies, true, "Included")]
        [InlineData(Ingredient.Queso, false, "Included")]
        [InlineData(Ingredient.Steak, true, "Included")]
        [InlineData(Ingredient.Chicken, false, "Included")]
        [InlineData(Ingredient.Guacamole, true, "Included")]
        [InlineData(Ingredient.PintoBeans, false, "Included")]
        [InlineData(Ingredient.BlackBeans,true, "Included")]
        [InlineData(Ingredient.Queso, true, "Included")]
        public void ChangingIncludedShouldNotifyOfPropertyChanges(Ingredient ingredient, bool included,string propertyName)
        {
            IngredientItem i = new(ingredient);
            Assert.PropertyChanged(i, propertyName, () => {
                i.Included = included;
            });
        }
        /// <summary>
        /// IngredientItem Names have proper values
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
        /// <param name="name">its expected name</param>
        [Theory]
        [InlineData(Ingredient.BlackBeans,"Black Beans")]
        [InlineData(Ingredient.PintoBeans, "Pinto Beans")]
        [InlineData(Ingredient.SourCream, "Sour Cream")]
        [InlineData(Ingredient.Queso, "Queso")]
        [InlineData(Ingredient.Veggies, "Veggies")]
        [InlineData(Ingredient.Guacamole, "Guacamole")]
        [InlineData(Ingredient.Chicken, "Chicken")]
        [InlineData(Ingredient.Steak, "Steak")]
        [InlineData(Ingredient.Carnitas, "Carnitas")]
        [InlineData(Ingredient.Rice, "Rice")]
        [InlineData(Ingredient.Chips, "Chips")]
        public void IngredientNameHaveProperValues(Ingredient ingredient, string name)
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.Equal(name, item.Name);
            
        }


        /// <summary>
        /// IngredientItem unitcosts  have proper values
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
        /// <param name="cost">its expected unit cost</param>
        [Theory]
        [InlineData(Ingredient.BlackBeans, 1)]
        [InlineData(Ingredient.PintoBeans, 1)]
        [InlineData(Ingredient.SourCream, 0)]
        [InlineData(Ingredient.Queso, 1)]
        [InlineData(Ingredient.Veggies, 0)]
        [InlineData(Ingredient.Guacamole, 1)]
        [InlineData(Ingredient.Chicken, 2)]
        [InlineData(Ingredient.Steak, 2)]
        [InlineData(Ingredient.Carnitas, 2)]
        [InlineData(Ingredient.Rice, 0)]
        [InlineData(Ingredient.Chips, 0)]
        public void IngredientUnitCostHaveProperValues(Ingredient ingredient, decimal cost)
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.Equal(cost, item.UnitCost);

        }

        /// <summary>
        /// IngredientItem calories  have proper values
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
        /// <param name="calories">its expected calories</param>
        [Theory]
        [InlineData(Ingredient.BlackBeans, 130)]
        [InlineData(Ingredient.PintoBeans, 130)]
        [InlineData(Ingredient.SourCream, 100)]
        [InlineData(Ingredient.Queso, 110)]
        [InlineData(Ingredient.Veggies, 20)]
        [InlineData(Ingredient.Guacamole, 150)]
        [InlineData(Ingredient.Chicken, 150)]
        [InlineData(Ingredient.Steak, 180)]
        [InlineData(Ingredient.Carnitas, 210)]
        [InlineData(Ingredient.Rice, 210)]
        [InlineData(Ingredient.Chips, 250)]
        public void IngredientCaloriesHaveProperValues(Ingredient ingredient, uint calories)
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.Equal(calories, item.Calories);

        }

        /// <summary>
        /// IngredientItem Included  initially set to false
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
       
        [Theory]
        [InlineData(Ingredient.BlackBeans)]
        [InlineData(Ingredient.PintoBeans)]
        [InlineData(Ingredient.SourCream)]
        [InlineData(Ingredient.Queso)]
        [InlineData(Ingredient.Veggies)]
        [InlineData(Ingredient.Guacamole)]
        [InlineData(Ingredient.Chicken)]
        [InlineData(Ingredient.Steak)]
        [InlineData(Ingredient.Carnitas)]
        [InlineData(Ingredient.Rice)]
        [InlineData(Ingredient.Chips)]
        public void IngredientIncludedPropertyHasProperValues(Ingredient ingredient)
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.False(item.Included);

        }

        /// <summary>
        /// IngredientItem Default initially set to false
        /// </summary>
        /// <param name="ingredient">the particular ingredient</param>
        [Theory]
        [InlineData(Ingredient.BlackBeans)]
        [InlineData(Ingredient.PintoBeans)]
        [InlineData(Ingredient.SourCream)]
        [InlineData(Ingredient.Queso)]
        [InlineData(Ingredient.Veggies)]
        [InlineData(Ingredient.Guacamole)]
        [InlineData(Ingredient.Chicken)]
        [InlineData(Ingredient.Steak)]
        [InlineData(Ingredient.Carnitas)]
        [InlineData(Ingredient.Rice)]
        [InlineData(Ingredient.Chips)]
        public void IngredientDefaultPropertyHasProperValues(Ingredient ingredient)
        {
            IngredientItem item = new IngredientItem(ingredient);
            Assert.False(item.Default);

        }
    }
}
