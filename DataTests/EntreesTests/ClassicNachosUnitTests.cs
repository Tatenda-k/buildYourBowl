
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// class with unit tests for the ClassicNachos class
    /// </summary>
    public class ClassicNachosUnitTests
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
        ClassicNachos f = new();
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
    [InlineData(Ingredient.Steak, true, "Calories")]
    [InlineData(Ingredient.Queso, false, "Calories")]
    [InlineData(Ingredient.Guacamole, true, "Calories")]
    [InlineData(Ingredient.SourCream, false, "PreparationInformation")]
    [InlineData(Ingredient.Steak, false, "PreparationInformation")]
    [InlineData(Ingredient.SourCream, true, "PreparationInformation")]
    [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
    [InlineData(Ingredient.SourCream, true, "Price")]
    [InlineData(Ingredient.Steak, true, "Price")]
    public void ChangingIncludedOfIngredientItemShouldNotifyOfPropertyChanges(Ingredient item, bool include, string propertyName)
    {
        ClassicNachos bowl = new();

        bowl.Instructions.TryGetValue(item, out IngredientItem? value);
        Assert.PropertyChanged(bowl, propertyName, () => {
            value!.Included = include;
        });

    }

    /// <summary>
    /// carnitas bowl implements INotifyPropertyChanged interface
    /// </summary>
    [Fact]
    public void ClassicNachosBowlShouldImplementINotifyPropertyChanged()

    {
        ClassicNachos f = new();
        Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
    }
   
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            ClassicNachos meal = new();
            Assert.Equal("Classic Nachos", meal.ToString());
        }
        /// <summary>
        /// classicNachos object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            ClassicNachos nachos = new();
            Assert.IsAssignableFrom<Entree>(nachos);
            Assert.IsAssignableFrom<Nachos>(nachos);
            Assert.IsAssignableFrom<IMenuItem>(nachos);
        }


        /// <summary>
        /// checks that steak property is initially set to true;
        /// </summary>
        [Fact]
        public void SteakPropertyInitiallisedProperlyTest()
        {
            ClassicNachos nachos = new();

            nachos.Instructions.TryGetValue(Ingredient.Steak, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that chicken property is initially set to true;
        /// </summary>
        [Fact]
        public void ChickenPropertyInitiallisedProperlyTest()
        {
            ClassicNachos nachos = new();

            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            Assert.True(value!.Included);
       

        }

      
        /// <summary>
        /// checks that queso property is initially set to true;
        /// </summary>
        [Fact]
        public void QuesoPropertyInitiallisedProperlyTest()
        {
            ClassicNachos nachos = new();

            nachos.Instructions.TryGetValue(Ingredient.Queso, out IngredientItem? value);
            Assert.True(value!.Included);

        }

        /// <summary>
        /// checks that the guacamole property is initially set to false
        /// </summary>

        [Fact]
        public void GuacamolePropertyInitiallisedProperlyTest()
        {
            ClassicNachos nachos = new();

            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
            Assert.False(value!.Included);
        }

        /// <summary>
        /// checks that sourCream property is initially set to false;
        /// </summary>
        [Fact]
        public void SourCreamPropertyInitiallisedProperlyTest()
        {
           ClassicNachos nachos = new();
      nachos.Instructions.TryGetValue(Ingredient.SourCream, out IngredientItem? value);
            Assert.False(value!.Included);

        }

        /// <summary>
        /// checks that salsa property is correctly initialized
        /// </summary>
        [Fact]
        public void SalsaPropertyInitiallisedProperlyTest()
        {
            ClassicNachos nachos = new();


            Assert.Equal(Salsa.Medium, nachos.SalsaChoice);

        }

        /// <summary>
        /// ensures calories property is initialized correctly
        /// </summary>
        [Fact]
        public void CaloriesInitialisedProperlyTest()
        {
            ClassicNachos nachos = new();
            Assert.Equal(710u, nachos.Calories);
        }

        /// <summary>
        /// ensures initial price is correct
        /// </summary>
        [Fact]
        public void PriceInitialisedProperlyTest()
        {
            ClassicNachos nachos = new();
            Assert.Equal(12.99m, nachos.Price);
        }




        /// <summary>
        /// tests that preperation information is correct
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="steak">the steak property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="info">the expected information</param>


        [Theory]
        [InlineData(true, true, true, true, true, Salsa.Hot, new string[] { "Add Guacamole", "Add Sour Cream", "Swap Hot Salsa" })]
        [InlineData(true, false, true, true, true, Salsa.Green, new string[] { "Hold Chicken", "Add Guacamole", "Add Sour Cream", "Swap Green Salsa" })]
        [InlineData(true, false, false, false, false, Salsa.Medium, new string[] { "Hold Queso", "Hold Chicken" })]
        [InlineData(false, true, true, true, false, Salsa.None, new string[] { "Hold Steak", "Hold Salsa", "Add Guacamole" })]
        [InlineData(true, false, false, false, true, Salsa.Mild, new string[] { "Hold Chicken", "Hold Queso", "Add Sour Cream", "Swap Mild Salsa" })]
        public void PreperationInformationTest(bool steak, bool chicken, bool queso, bool guacamole, bool sourCream, Salsa salsa, string[] info)
        {



            ClassicNachos nachos = new();


            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Chicken] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Steak, out value);
            value!.Included = steak;
            nachos.Instructions[Ingredient.Steak] = value;

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
        /// tests that calories are calculated correctly
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="steak">the steak property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedCalories">the calories expected</param>
        [Theory]

        [InlineData(true, true, true, true, true, Salsa.Hot,150+110+100+150+180+20+250 )]

        [InlineData(true, false, false, true, false, Salsa.Green,570)]
        [InlineData(true, false, false, false, false, Salsa.Green, 420)]
        [InlineData(false, false, true, true, false, Salsa.None, 500)]
        [InlineData(true, true, false, false, false, Salsa.Hot, 530)]

        public void CaloriesPropertyTest(bool chicken, bool queso, bool sourCream, bool guacamole, bool steak, Salsa salsa, uint expectedCalories)
        {
            ClassicNachos nachos = new();


            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Chicken] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Steak, out value);
            value!.Included = steak;
            nachos.Instructions[Ingredient.Steak] = value;

            nachos.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            nachos.Instructions[Ingredient.SourCream] = value;

            nachos.SalsaChoice = salsa;

            nachos.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            nachos.Instructions[Ingredient.Guacamole] = value;




            Assert.Equal(expectedCalories, nachos.Calories);
        }

        /// <summary>
        /// tests that the prices are correct
        /// </summary>
        /// <param name="chicken">the chicken property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="steak">the steak property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedPrice">the expected price</param>

        [Theory]
        [InlineData(true, true, true, true, true, Salsa.Hot, 13.99)]
        [InlineData(true, false, false, true, true, Salsa.Green, 13.99)]
        [InlineData(true, false, false, false, false, Salsa.Medium, 12.99)]
        [InlineData(false, false, true, true, false, Salsa.None, 13.99)]
        [InlineData(false, false, true, false, false, Salsa.Hot, 12.99)]
        public void PricePropertyTest(bool chicken, bool steak, bool queso, bool guacamole, bool sourCream, Salsa salsa, decimal expectedPrice)
        {
            ClassicNachos nachos = new();


            nachos.Instructions.TryGetValue(Ingredient.Chicken, out IngredientItem? value);
            value!.Included = chicken;
            nachos.Instructions[Ingredient.Chicken] = value;


            nachos.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            nachos.Instructions[Ingredient.Queso] = value;

            nachos.Instructions.TryGetValue(Ingredient.Steak, out value);
            value!.Included = steak;
            nachos.Instructions[Ingredient.Steak] = value;

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
