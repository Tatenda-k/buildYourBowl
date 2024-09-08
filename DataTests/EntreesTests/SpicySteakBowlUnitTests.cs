
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests
{
   
    /// <summary>
    /// class with unit tests for the SpicySteakBowl class
    /// </summary>
    public  class SpicySteakBowlUnitTests
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
                f.SalsaChoice=salsa;
            });
        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="item">the particular ingredient</param>
        /// <param name="include">whether the item is included</param>
        /// <param name="propertyName">the property that will be changed</param>
        [Theory]
        [InlineData(Ingredient.Steak, true,"Calories")]
        [InlineData(Ingredient.Veggies,true, "Calories")]
        [InlineData(Ingredient.Queso,false, "Calories")]
        [InlineData(Ingredient.Guacamole,true, "Calories")]
        [InlineData(Ingredient.SourCream,false, "PreparationInformation")]
        [InlineData(Ingredient.Veggies,false, "PreparationInformation")]
        [InlineData(Ingredient.Queso,true,"PreparationInformation")]
        [InlineData(Ingredient.Guacamole,false, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole,true, "Price")]
        [InlineData(Ingredient.Steak,true, "Price")]
        public void ChangingIncludedOfIngredientItemShouldNOtifyOfPropertyChanges(Ingredient item,bool include,string propertyName)
        {
            SpicySteakBowl bowl = new();

            bowl.Instructions.TryGetValue(item, out IngredientItem? value);
            Assert.PropertyChanged(bowl, propertyName, () => {
                value!.Included = include;
            });
            
        }

        /// <summary>
        /// spicy steak implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void SpicySteakShouldImplementINotifyPropertyChanged()
        {
            SpicySteakBowl f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            SpicySteakBowl meal = new();
            Assert.Equal("Spicy Steak Bowl", meal.ToString());
        }
        /// <summary>
        /// spicy steak bowl object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            SpicySteakBowl bowl = new();
            Assert.IsAssignableFrom<Entree>(bowl);
            Assert.IsAssignableFrom<Bowl>(bowl);
            Assert.IsAssignableFrom<IMenuItem>(bowl);
        }

        /// <summary>
        /// checks that steak property is initially set to true;
        /// </summary>
        [Fact]
        public void SteakPropertyInitiallisedProperlyTest()
        {
           SpicySteakBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.Steak, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        
        /// <summary>
        /// checks that Veggies property is initially set to false
        /// </summary>
        [Fact]
        public void VeggiesPropertyInitiallisedProperlyTest()
        {
            SpicySteakBowl bowl = new();
     
            bowl.Instructions.TryGetValue(Ingredient.Veggies, out IngredientItem? value);
            Assert.False(value!.Included);

        }
        /// <summary>
        /// checks that queso property is initially set to true
        /// </summary>
        [Fact]
        public void QuesoPropertyInitiallisedProperlyTest()
        {
            SpicySteakBowl bowl = new();
            bowl.Instructions.TryGetValue(Ingredient.Queso, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that the guacamole property is initially set to false
        /// </summary>
        [Fact]
        public void GuacamolePropertyInitiallisedProperlyTest()
        {
            SpicySteakBowl bowl = new();

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
            Assert.False(value!.Included);
      

        }

        /// <summary>
        /// checks that sourCream property is initially set to true
        /// </summary>
        [Fact]
        public void SourCreamPropertyInitiallisedProperlyTest()
        {
            SpicySteakBowl bowl = new();
            bowl.Instructions.TryGetValue(Ingredient.SourCream, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that salsa property is correctly initialized
        /// </summary>
        [Fact]
        public void SalsaPropertyInitiallisedProperlyTest()
        {
            SpicySteakBowl bowl = new();

            Assert.Equal(Salsa.Hot, bowl.SalsaChoice);

        }

        /// <summary>
        /// checks default calories
        /// </summary>
        [Fact]
        public void CaroliesPropertyInitialTest()
        {
            SpicySteakBowl bowl = new ();
            Assert.Equal(620u, bowl.Calories);
        }
        /// <summary>
        /// ensures initial price is correct
        /// </summary>
        [Fact]
        public void PriceInitialisedTest()
        {
            SpicySteakBowl bowl = new ();
            Assert.Equal(10.99m, bowl.Price);
        }

        /// <summary>
        /// tests that calories are calculated correctly
        /// </summary>
        /// <param name="steak">the steak property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedCalories">the calories expected</param>
        [Theory]
        [InlineData(true, true, true, true, Salsa.Hot, true, 790)]
        [InlineData(true, false, false, true, Salsa.Green, true, 660)]
        [InlineData(true, false, false, false,  Salsa.Green, true, 560)]
        [InlineData(false, false, true, true, Salsa.None, true, 480)]
        [InlineData(true, true, false, true,  Salsa.Hot, false, 620)]
        [InlineData(true, true, false, true, Salsa.None, false, 600)]
        [InlineData(false, false, false, false, Salsa.Green, true, 560-180)]



        public void CaloriesPropertyIsCorrect(bool steak, bool queso, bool veggies, bool sourCream, Salsa salsa, bool guacamole, uint expectedCalories)
        {
            SpicySteakBowl bowl = new();

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Steak, out IngredientItem? value);
            value!.Included = steak;
            bowl.Instructions[Ingredient.Steak] = value;


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


            Assert.Equal(expectedCalories, bowl.Calories);
        }
        /// <summary>
        /// tests that preperation information is correct
        /// </summary>
        /// <param name="steak">the steak property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="info">the preperation information</param>


        [Theory]
        [InlineData(true, true, true, true, Salsa.Hot, true, new string[] { "Add Veggies","Add Guacamole" })]
        [InlineData(true, false, false, true,  Salsa.Green, false, new string[] {"Swap Green Salsa", "Hold Sour Cream", "Hold Queso", "Add Guacamole" })]
        [InlineData(true, false, false, false, Salsa.Medium, true, new string[] { "Hold Queso",  "Swap Medium Salsa" })]
        [InlineData(false, false, true, true,  Salsa.None, true, new string[] { "Hold Steak", "Add Guacamole","Hold Salsa" })]
        [InlineData(true, true, false, true,  Salsa.Hot, false, new string[] { "Add Guacamole","Add Veggies", "Hold Queso", "Hold Sour Cream",  })]
        [InlineData(false,false, false, true, Salsa.Hot, false, new string[] { "Add Guacamole", "Hold Queso","Hold Steak", "Hold Sour Cream", })]
        public void PreperationInformationCorrect(bool steak, bool veggies, bool queso, bool guacamole, Salsa salsa, bool sourCream, string[] info)
        {
            SpicySteakBowl bowl = new();

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Steak, out IngredientItem? value);
            value!.Included = steak;
            bowl.Instructions[Ingredient.Steak] = value;


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
            foreach (string str in info)
            {
                Assert.Contains(str, bowl.PreparationInformation);
            }
            Assert.Equal(info.Length, bowl.PreparationInformation.Count());


        }

        /// <summary>
        /// tests that the prices are correct
        /// </summary>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedPrice">the expected price</param>
        /// <param name="steak">the steak property</param>

        [Theory]
        [InlineData(true, true, true, true, true,  Salsa.Hot, 11.99)]
        [InlineData(true, false, false, true, true,  Salsa.Green, 11.99)]
        [InlineData(true, false, false, false, false,  Salsa.Medium, 10.99)]
        [InlineData(false, false, true, true, false, Salsa.None, 11.99)]
        [InlineData(false, true, false, false, true, Salsa.Mild, 10.99)]
        public void PricesTest(bool steak, bool veggies, bool queso, bool guacamole, bool sourCream, Salsa salsa, decimal expectedPrice)
        {
            SpicySteakBowl bowl = new();

            

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Steak, out IngredientItem? value);
            value!.Included = steak;
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

            



            Assert.Equal(expectedPrice, bowl.Price);
        }

    }
}
