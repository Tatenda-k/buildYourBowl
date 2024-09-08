using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// unit test class for the GreenChickenBowl class
    /// </summary>
   public  class GreenChickenBowlUnitTests
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
            SpicySteakBowl f = new();
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
        [InlineData(Ingredient.BlackBeans, true, "Price")]
        [InlineData(Ingredient.Chicken, true, "Price")]
        public void ChangingIncludedOfIngredientItemShouldNOtifyOfPropertyChanges(Ingredient item, bool include, string propertyName)
        {
            GreenChickenBowl bowl = new();

            bowl.Instructions.TryGetValue(item, out IngredientItem? value);
            Assert.PropertyChanged(bowl, propertyName, () => {
                value!.Included = include;
            });

        }

        /// <summary>
        /// green chicken bowl implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void 
            GreenChickenBowlShouldImplementINotifyPropertyChanged()
        {
            GreenChickenBowl f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            GreenChickenBowl meal = new();
            Assert.Equal("Green Chicken Bowl", meal.ToString());
        }
        /// <summary>
        /// greenChickenBowl object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            GreenChickenBowl bowl = new ();
            Assert.IsAssignableFrom<Entree>(bowl);
            Assert.IsAssignableFrom<Bowl>(bowl);
            Assert.IsAssignableFrom<IMenuItem>(bowl);
        }
        /// <summary>
        /// checks that chicken property is initially set to true;
        /// </summary>
        [Fact]
        public void ChickenPropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl =new();

            bowl.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that blackBeans property is initially set to true;
        /// </summary>
        [Fact]
        public void BlackBeanPropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl = new ();

            bowl.Instructions.TryGetValue(Ingredient.BlackBeans, out IngredientItem? value);

            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that Veggies property is initially set to true;
        /// </summary>
        [Fact]
        public void VeggiesPropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that queso property is initially set to true;
        /// </summary>
        [Fact]
        public void QuesoPropertyInitiallisedProperlTest()
        {
            GreenChickenBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.Queso, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that the guacamole property is initially set to true;
        /// </summary>
        [Fact]
        public void GuacamolePropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that sourCream property is initially set to true;
        /// </summary>
        [Fact]
        public void SourCreamPropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that salsa property is correctly initialized
        /// </summary>
        [Fact]
        public void SalsaPropertyInitiallisedProperlyTest()
        {
            GreenChickenBowl bowl = new();

            Assert.Equal(Salsa.Green, bowl.SalsaChoice);

        }
        /// <summary>
        /// checks default calories
        /// </summary>
        [Fact]
        public void CaroliesPropertyInitialTest()
        {
           GreenChickenBowl bowl = new ();
            Assert.Equal(890u, bowl.Calories);
        }
        /// <summary>
        /// ensures initial price is correct
        /// </summary>
        [Fact]
        public void PriceInitialisedTest()
        {

            GreenChickenBowl bowl = new();

            Assert.Equal(9.99m, bowl.Price);
        }

        /// <summary>
        /// tests that prices are calculated correctly
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="blackBeans">the blackBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedPrice">the calories expected</param>
        [Theory]
        [InlineData(true,true,true,true,true,Salsa.Hot,true,9.99)]
        [InlineData(true, false, false, true, false, Salsa.Green, true, 9.99)]
        [InlineData(true, false, false, false, false, Salsa.Green, true, 9.99)]
        [InlineData(false, false, true, true, false, Salsa.None, true, 9.99)]
        [InlineData(true, true, false, true, false, Salsa.Hot, false, 9.99)]
        [InlineData(false, false, false,false, false, Salsa.None, false, 9.99)]

        public void PricePropertyTest(bool chicken,bool blackBeans, bool queso,bool veggies,bool sourCream, Salsa salsa,bool guacamole, decimal expectedPrice)
        {
            GreenChickenBowl bowl = new();
           
            bowl.SalsaChoice = salsa;
            
            bowl.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            bowl.Instructions[Ingredient.Chicken] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.BlackBeans, out value);
            value!.Included = blackBeans;
            bowl.Instructions[Ingredient.PintoBeans] = value;


            Assert.Equal(expectedPrice,bowl.Price);

        }
        /// <summary>
        /// tests that preperation information is correct
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="blackBeans">the blackBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="info">the preperation information</param>
     

        [Theory]
        [InlineData(true, true, true, true, true, Salsa.Hot, true, new string[] { "Swap Hot Salsa" })]
        [InlineData(true, false, false, true, true, Salsa.Green, false, new string[] { "Hold Black Beans","Hold Queso","Hold Guacamole" })]
        [InlineData(true, false, false, false, false, Salsa.Medium, true, new string[] { "Hold Black Beans","Hold Queso","Hold Veggies","Hold Sour Cream", "Swap Medium Salsa" })]
        [InlineData(false, false, true, true, false, Salsa.None, true, new string[] {  "Hold Chicken", "Hold Black Beans", "Hold Sour Cream", "Hold Salsa" })]
        [InlineData(true, true, false, true, false, Salsa.Hot, false, new string[] { "Hold Queso", "Hold Sour Cream" , "Swap Hot Salsa", "Hold Guacamole" })]
        public void PreperationInformationTest(bool chicken, bool blackBeans, bool queso, bool veggies, bool sourCream,Salsa salsa,bool guacamole, string[] info)
        {
            GreenChickenBowl bowl = new();


            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            bowl.Instructions[Ingredient.Chicken] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;


            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.BlackBeans, out value);
            value!.Included = blackBeans;
            bowl.Instructions[Ingredient.BlackBeans] = value;
            foreach (string str in info)
            {
                Assert.Contains(str, bowl.PreparationInformation);
            }
            Assert.Equal(info.Length, bowl.PreparationInformation.Count());
        }

        /// <summary>
        /// tests that calories are calculated correctly
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="blackBeans">the blackBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedCalories">the calories expected</param>
        [Theory]
        [InlineData(true, true, true, true, true, Salsa.Hot, true, 890)]
        [InlineData(true, false, false, true, false, Salsa.Green, true,150+20+20+210+150 )]
        [InlineData(true, false, false, false, false, Salsa.Green, true, 150+150+20+210)]
        [InlineData(false, false, true, true, false, Salsa.None, true, 490)]
        [InlineData(true, true, false, true, false, Salsa.Hot, false, 150+130+20+210+20)]
        [InlineData(false, false, false, false, false, Salsa.None, false, 210)]

        public void CaloriesPropertyTest(bool chicken, bool blackBeans, bool queso, bool veggies, bool sourCream, Salsa salsa, bool guacamole, uint expectedCalories)
        {
            GreenChickenBowl bowl = new();

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            bowl.Instructions[Ingredient.Chicken] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.BlackBeans, out value);
            value!.Included = blackBeans;
            bowl.Instructions[Ingredient.BlackBeans] = value;


            Assert.Equal(expectedCalories, bowl.Calories);

        }




    }
}
