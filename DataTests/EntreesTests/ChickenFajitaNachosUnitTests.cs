

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// a class with unit tests for the ChickenFajitaNachos class
    /// </summary>
   public  class ChickenFajitaNachosUnitTests
    {



        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="salsa">the salsa choice</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Salsa.Mild, "SalsaChoice")]
        [InlineData(Salsa.Green, "SalsaChoice")]
        [InlineData(Salsa.Hot, "SalsaChoice")]
        [InlineData(Salsa.None, "SalsaChoice")]
        [InlineData(Salsa.Medium, "SalsaChoice")]
        [InlineData(Salsa.Mild, "Calories")]
        [InlineData(Salsa.Green, "Calories")]
        [InlineData(Salsa.Hot, "Calories")]
        [InlineData(Salsa.None, "Calories")]
        [InlineData(Salsa.Medium, "Calories")]
        [InlineData(Salsa.Mild, "PreparationInformation")]
        [InlineData(Salsa.Green, "PreparationInformation")]
        [InlineData(Salsa.Hot, "PreparationInformation")]
        [InlineData(Salsa.None, "PreparationInformation")]
        [InlineData(Salsa.Medium, "PreparationInformation")]

        public void ChangingSalsaShouldNotifyOfPropertyChanges(Salsa salsa, string propertyName)
        {
            ChickenFajitaNachos f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.SalsaChoice = salsa;
            });
        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="item">the particular ingredient</param>
        /// <param name="include">whether the item is included</param>
        /// <param name="propertyName">the property that will be changed</param>
        [Theory]
        [InlineData(Ingredient.Chicken, true, "Calories")]
        [InlineData(Ingredient.Veggies, true, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.Guacamole, true, "Calories")]
        [InlineData(Ingredient.SourCream, false, "PreparationInformation")]
        [InlineData(Ingredient.Veggies, false, "PreparationInformation")]
        [InlineData(Ingredient.SourCream, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.SourCream, true, "Price")]
        [InlineData(Ingredient.Chicken, true, "Price")]
        public void ChangingIncludedOfIngredientItemShouldNotifyOfPropertyChanges(Ingredient item, bool include, string propertyName)
        {
            ChickenFajitaNachos bowl = new();

            bowl.Instructions.TryGetValue(item, out IngredientItem? value);
            Assert.PropertyChanged(bowl, propertyName, () => {
                value!.Included = include;
            });

        }

        /// <summary>
        /// spicy steak implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void ChickenFajitaShouldImplementINotifyPropertyChanged()

        {
            ChickenFajitaNachos f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ChickenFajitaNachos meal = new();
            Assert.Equal("Chicken Fajita Nachos", meal.ToString());
        }

        /// <summary>
        /// chickenFajitaNachos can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            ChickenFajitaNachos nachos = new ();
            Assert.IsAssignableFrom<Entree>(nachos);
            Assert.IsAssignableFrom<Nachos>(nachos);
            Assert.IsAssignableFrom<IMenuItem>(nachos);
        }
        /// <summary>
        /// checks that chicken property is initially set to true;
        /// </summary>
        [Fact]
        public void ChickenPropertyInitialTest()
        {

            ChickenFajitaNachos nachos = new ChickenFajitaNachos();
            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that Veggies property is initially set to true;
        /// </summary>
        [Fact]
        public void VeggiesPropertyInitialTest()
        {

            ChickenFajitaNachos nachos = new ChickenFajitaNachos();
            nachos.Instructions.TryGetValue(Ingredient.Veggies, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that queso property is initially set to true;
        /// </summary>
        [Fact]
        public void QuesoPropertyInitiallTest()
        {

            ChickenFajitaNachos nachos = new ChickenFajitaNachos();
            nachos.Instructions.TryGetValue(Ingredient.Queso, out IngredientItem? value);
            Assert.True(value!.Included);

        }
 
        /// <summary>
        /// checks that the guacamole property is initially set to false;
        /// </summary>
        [Fact]
        public void GuacamolePropertyInitialTest()
        {

            ChickenFajitaNachos nachos = new ChickenFajitaNachos();
            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
            Assert.False (value!.Included);

        }

        /// <summary>
        /// checks that sourCream property is initially set to true;
        /// </summary>
        [Fact]
        public void SourCreamPropertyInitialTest()
        {

            ChickenFajitaNachos nachos = new ChickenFajitaNachos();
            nachos.Instructions.TryGetValue(Ingredient.SourCream, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that salsa property is correctly initialized
        /// </summary>
        [Fact]
        public void SalsaPropertyInitialTest()
        {
            ChickenFajitaNachos nachos = new();
          

            Assert.Equal(Salsa.Medium,nachos.SalsaChoice);

        }
 
    
    /// <summary>
    ///  checks default calories
   /// </summary>
    [Fact]
        public void CaloriesInitialisedProperlyTest()
        {
            ChickenFajitaNachos nachos = new();
            Assert.Equal(650u, nachos.Calories);
        }

        /// <summary>
        /// ensures initial price is correct
        /// </summary>
        [Fact]
        public void PriceInitialisedProperlyTest()
        {
            ChickenFajitaNachos nachos = new();
            Assert.Equal(10.99m,nachos.Price);
        }


        /// <summary>
        /// tests that calories are calculated correctly
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedCalories">the calories expected</param>
        [Theory]

        [InlineData(true, true, true, true, true,  Salsa.Hot, 150+110+100+150+20+20+250)]
        [InlineData(true, false, false, true, false, Salsa.Green, 150+150+250+20)]
        [InlineData(true, false, false, false, false, Salsa.Medium, 150+250+20)]
        [InlineData(false, false, false, false, false, Salsa.Mild, 250+20)]

        [InlineData(false, false, true, true, false,Salsa.None,100+150+250)]
        [InlineData(true, true, false, true, false,  Salsa.Hot, 150+110+150+250+20)]
        //specific required test case
        [InlineData(false,true,false,false,false,Salsa.Hot,110+250+20)]
        public void CaloriesPropertyTest(bool chicken, bool queso, bool sourCream, bool guacamole, bool veggies,  Salsa salsa, uint expectedCalories)
        {
            ChickenFajitaNachos nachos = new();
           

            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Chicken] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            nachos.Instructions[Ingredient.Veggies] = value;

            nachos.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            nachos.Instructions[Ingredient.SourCream] = value;

            nachos.SalsaChoice = salsa;

            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            nachos.Instructions[Ingredient.Guacamole] = value;

           




           



            Assert.Equal(expectedCalories,nachos.Calories);
        }
        

        /// <summary>
        /// tests that preperation information is correct
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="info">the expected information</param>


        [Theory]
        [InlineData(true, true, true, true, true, Salsa.Hot, new string[] {  "Add Guacamole", "Swap Hot Salsa" })]
        [InlineData(true, false, false, true, true,  Salsa.Green, new string[] { "Hold Queso", "Add Guacamole", "Hold Veggies","Swap Green Salsa" })]
        [InlineData(true, false, false, false, false, Salsa.Medium, new string[] { "Hold Queso", "Hold Sour Cream", "Hold Veggies" })]
        [InlineData(false, false, true, true, false,  Salsa.None, new string[] { "Hold Chicken","Hold Veggies","Hold Sour Cream", "Hold Salsa","Add Guacamole" })]
       //specific required test case
        [InlineData(false,false,true,false,false,Salsa.Hot,new string[] {"Hold Chicken", "Hold Veggies", "Swap Hot Salsa", "Hold Sour Cream"})]
         [InlineData(true, true, false, true, true, Salsa.Mild, new string[] {  "Add Guacamole","Hold Queso", "Swap Mild Salsa" })]
        public void PreperationInnformationTest(bool chicken, bool veggies, bool queso, bool guacamole, bool sourCream, Salsa salsa, string[] info)
        {
            ChickenFajitaNachos nachos = new();



            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Chicken] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            nachos.Instructions[Ingredient.Veggies] = value;

            nachos.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            nachos.Instructions[Ingredient.SourCream] = value;

            nachos.SalsaChoice = salsa;

            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            nachos.Instructions[Ingredient.Guacamole] = value;
            foreach (string str in info)
            {
                Assert.Contains(str, nachos.PreparationInformation);
            }
            Assert.Equal(info.Length, nachos.PreparationInformation.Count());

        }


        /// <summary>
        /// tests that the prices are correct
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedPrice">the expected price</param>

        [Theory]
        [InlineData(true, true, true, true, true,  Salsa.Hot, 11.99)]
        [InlineData(true, false, false, true, true, Salsa.Green, 11.99)]
        [InlineData(true, false, false, false, false,  Salsa.Medium, 10.99)]
        [InlineData(false, false, true, true, false,  Salsa.None, 11.99)]
        // specific required test case
        [InlineData(false, false, true, false, false, Salsa.Mild, 10.99)]
        public void PricePropertyTest(bool chicken, bool veggies, bool queso, bool guacamole, bool sourCream, Salsa salsa, decimal expectedPrice)
        {
            ChickenFajitaNachos nachos = new();



            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Queso] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            nachos.Instructions[Ingredient.Veggies] = value;

            nachos.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            nachos.Instructions[Ingredient.SourCream] = value;

            nachos.SalsaChoice = salsa;

            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            nachos.Instructions[Ingredient.Guacamole] = value;
            Assert.Equal(expectedPrice, nachos.Price);
        }

    }
}
