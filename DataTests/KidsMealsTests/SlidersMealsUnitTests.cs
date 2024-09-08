using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// unit tests for testing the slidersMeal class
    /// </summary>
    public class SlidersMealsUnitTests
    {


        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="drinkSize">the size of the drink</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Medium, "Price")]
        public void ChangingDrinkShouldNotifyOfPropertyChange(Size drinkSize, string propertyName)
        {
            SlidersMeal meal = new();

            meal.SideChoice = new MockSide();

            Assert.PropertyChanged(meal, propertyName, () => {

                meal.DrinkChoice = new MockDrink() { Size = drinkSize };

            });

        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="sideSize">the size of the side</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Medium, "Price")]
        public void ChangingSideShouldNotifyOfPropertyChange(Size sideSize, string propertyName)
        {
             SlidersMeal meal = new();
            meal.DrinkChoice = new MockDrink();

            Assert.PropertyChanged(meal, propertyName, () => {
                meal.SideChoice = new MockSide() { Size = sideSize };
            });
        }

        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="count">the number of bites</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]

        [InlineData(7, "PreparationInformation")]
        [InlineData(6, "PreparationInformation")]
        [InlineData(5, "PreparationInformation")]
        [InlineData(7, "Calories")]
        [InlineData(8, "Calories")]
        [InlineData(6, "Price")]
        [InlineData(5, "Price")]
        [InlineData(8, "Price")]
        public void ChangingItemCountShouldNotifyOfPropertyChange(uint count, string propertyName)
        {

            SlidersMeal meal = new();
            Assert.PropertyChanged(meal, propertyName, () => {
                meal.ItemCount = count;
            });


        }

        /// <summary>
        /// slidersMeal object can  be cast to IMenuItem and base classes
        /// </summary>
        [Fact]
        public void CastTest()
        {
            SlidersMeal meal = new();
            Assert.IsAssignableFrom<KidsMeal>(meal);
            Assert.IsAssignableFrom<IMenuItem>(meal);
        }

        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockSide : Side
            {
                /// <summary>
                /// the name of the mock object
                /// </summary>
                public override string Name { get; }
                /// <summary>
                /// the description of the mock object
                /// </summary>
                public override string Description { get; }
                /// <summary>
                /// the price of the mock object
                /// </summary>
                public override decimal Price { get; }
                /// <summary>
                /// the preperation information of the mock object 
                /// </summary>
                public override IEnumerable<string> PreparationInformation { get; }
                /// <summary>
                /// the calories of the mock object
                /// </summary>
                public override uint Calories { get; }
            }


            /// <summary>
            /// A mock menu item for testing
            /// </summary>
            internal class MockDrink : Drink
            {
                /// <summary>
                /// the name of the mock object
                /// </summary>
                public override string Name => throw new NotImplementedException();
                /// <summary>
                /// the description of the mock object
                /// </summary>
                public override string Description => throw new NotImplementedException();
                /// <summary>
                /// the price of the mock object
                /// </summary>
                public override decimal Price { get; }
                /// <summary>
                /// the preperation information of the mock object
                /// </summary>
                public override IEnumerable<string> PreparationInformation => throw new NotImplementedException();
                /// <summary>
                /// the calories of the mock object
                /// </summary>
                public override uint Calories {get;}
            }
            /// <summary>
            /// the price is calculated correctly for different side and drink sizes 
            /// </summary>
            /// <param name="drinkSize">the drink size</param>
            /// <param name="sideSize">the side size</param>
            /// <param name="count">the number of nuggets</param>
            /// <param name="expectedPrice">the expected added price for drinks and sides</param>

            [Theory]
            [InlineData(Size.Large, Size.Small, 2,2)]
            [InlineData(Size.Large, Size.Large, 2,3)]
            [InlineData(Size.Kids, Size.Small, 3,0.5)]
            [InlineData(Size.Large, Size.Medium, 4,2.5)]

            public void PricePropertyTest4(Size drinkSize, Size sideSize, uint count,decimal expectedPrice)
            {
                SlidersMeal meal = new();
                meal.ItemCount = count;
                meal.DrinkChoice = new MockDrink() { Size = drinkSize };
                meal.SideChoice = new MockSide() { Size = sideSize };

                Assert.Equal(5.99m + (2 * (count - 2)) +expectedPrice, meal.Price);


            }

            /// <summary>
            /// checks that calories are generated properly
            /// </summary>
            /// <param name="expectedCalories">the expected price</param>
            /// <param name="sideSize">the size property of the side</param>
            /// <param name="drinkSize">the size property of the drink</param>
            /// <param name="count">the count property</param>
            /// <param name="cheese">the AmericanCheese property</param>

            [Theory]
            //[InlineData(Size.Kids, Size.Kids,3,true, )]
            [InlineData(Size.Large, Size.Kids, 2, true,150*2)]
            [InlineData(Size.Medium, Size.Kids, 3, false,110*3)]
            [InlineData(Size.Medium, Size.Large, 4, true,150*4)]
            [InlineData(Size.Small, Size.Small, 2, true,150*2)]
            [InlineData(Size.Kids, Size.Kids, 4, false,110*4)]

            public void CaloriesPropertyWorkingProperly1(Size sideSize, Size drinkSize, uint count, bool cheese,decimal expectedCalories)
            {

                SlidersMeal meal = new();
                meal.ItemCount = count;
                meal.AmericanCheese = cheese;
                meal.DrinkChoice = new MockDrink() { Size = drinkSize };
                meal.SideChoice = new MockSide() { Size = sideSize };


                Assert.Equal(expectedCalories + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);

            }


            /// <summary>
            /// checks that curly property is initially set to true;
            /// </summary>
            [Fact]
            public void AmericanCheesePropertyInitiallisedProperlyTest()
            {

                SlidersMeal slide = new();
                Assert.True(slide.AmericanCheese);

            }
    

            /// <summary>
            /// checks that count property is initially set to 2
            /// </summary>
            [Fact]
            public void CountPropertyInitiallisedProperlyTest()
            {

                SlidersMeal slide = new();
                Assert.Equal(2u, slide.ItemCount);
            }
            /// <summary>
            /// checks that drink choice is initially set to milk without chocolate
            /// </summary>
            [Fact]
            public void DrinkPropertyInitiallisedProperlyTest()
            {
                SlidersMeal slide = new();
                Milk milk = new();
                slide.DrinkChoice = milk;
                Assert.False(((Milk)slide.DrinkChoice).Chocolate);
            }
            /// <summary>
            /// checks that SideChoice  is initially set to fries with kids size
            /// </summary>
            [Fact]
            public void FriesPropertyInitiallisedProperlyTest()
            {
                SlidersMeal slide = new();
                Assert.Equal(Size.Kids, slide.SideChoice.Size);
            }
            /// <summary>
            /// ensuers the default price is correct 
            /// </summary>
            [Fact]
            public void DefaultPrice()
            {
                SlidersMeal slide = new();
                Assert.Equal(5.99m, slide.Price);
            }

            /// <summary>
            /// ensuers the default calories is correct 
            /// </summary>
            [Fact]
            public void DefaultCalories()
            {
                SlidersMeal slide = new();
                Assert.Equal(300u + slide.SideChoice.Calories + slide.DrinkChoice.Calories, slide.Calories);
            }


            /// <summary>
            /// count property does not set values out of set bounds
            /// </summary>
            /// <param name="count">the value to set the count property</param>
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(9)]
            [InlineData(5)]
            public void CountPropertyDoesNotSetOutOfBoundNumbersTest(uint count)
            {
                SlidersMeal slide = new();
                slide.ItemCount = count;
                Assert.Equal(2u, slide.ItemCount);
            }
            /// <summary>
            /// checks that prices are generated properly
            /// </summary>
            /// <param name="sideSize">the size property of the side</param>
            /// <param name="drinkSize">the size property of the drink</param>
            /// <param name="count">the count property </param>
            /// <param name="expectedPrice">the expected price</param>
            [Theory]
            [InlineData(Size.Kids, Size.Kids, 2, 5.99)]
            //specific required test case
            [InlineData(Size.Large, Size.Kids, 3, 7.99+1.5)]
            [InlineData(Size.Medium, Size.Kids, 4,9.99 +1)]
            // [InlineData(Size.Small,Size.Large,4,11.99)]
            // [InlineData(Size.Medium,Size.Large,5,14.49)]
            public void PricePropertyTest(Size sideSize, Size drinkSize, uint count, decimal expectedPrice)
            {
                SlidersMeal slide = new();
                slide.SideChoice.Size = sideSize;
                slide.ItemCount = count;
                slide.DrinkChoice.Size = drinkSize;

                Assert.Equal(expectedPrice, slide.Price);

            }

            /// <summary>
            /// checks that prices are generated properly
            /// </summary>
            /// <param name="sideSize">the size property of the side</param>
            /// <param name="expectedCalories">the expected calories</param>
            /// <param name="choc">the chocolate property of the milk</param>
            /// <param name="cheese">the cheese property</param>
            /// <param name="drinkSize">the size property of the drink</param>
            /// <param name="count">the count property</param>
            //// 3 cheese-less sliders, a large fries, and chocolate milk has 3*(150-40) = 330 calories,
            [Theory]
            //[InlineData(Size.Kids, Size.Kids,3,true, )]
            ///specific required test case
            [InlineData(Size.Large, Size.Kids, 3, true, 450)]
            [InlineData(Size.Medium, Size.Kids, 2, true, 300)]
            [InlineData(Size.Small, Size.Kids, 4, true, 600)]
            //[InlineData(Size.Medium, Size.Kids, 5, 12.99)]
            // [InlineData(Size.Small,Size.Large,4,11.99)]
            // [InlineData(Size.Medium,Size.Large,5,14.49)]
            public void CaloriesPropertyTest(Size sideSize, Size drinkSize, uint count, bool cheese, decimal expectedCalories)
            {
                SlidersMeal slide = new();
                slide.SideChoice.Size = sideSize;
                slide.DrinkChoice.Size = drinkSize;
                slide.ItemCount = count;
                slide.AmericanCheese = cheese;

                Assert.Equal(expectedCalories + slide.DrinkChoice.Calories + slide.SideChoice.Calories, slide.Calories);

            }


            /// <summary>
            /// checks that preperation information is  generated properly
            /// </summary>
            /// <param name="cheese">the americanCheese property</param>
            /// <param name="info">the expected information</param>
            /// <param name="count">the count property</param>
            /// <param name="sideSize">the size property of the side</param>
            /// <param name="drinkSize">the size property of the drink</param>

            [Theory]
            [InlineData(Size.Large, Size.Small, 5, true, new string[] { })]
            //specific required test case
            [InlineData(Size.Large, Size.Large, 3, false, new string[] { "Hold American Cheese", "3 Sliders" })]
            [InlineData(Size.Medium, Size.Kids, 4, false, new string[] { "Hold American Cheese", "4 Sliders" })]
            public void PreperationInformationTest(Size sideSize, Size drinkSize, uint count, bool cheese, string[] info)
            {

                SlidersMeal slide = new();
                slide.AmericanCheese = cheese;
                slide.DrinkChoice.Size = drinkSize;

                slide.ItemCount = count;
                slide.SideChoice.Size = sideSize;

                foreach (string str in info)
                {
                    Assert.Contains(str, slide.PreparationInformation);
                }

                Assert.Equal(info.Length+3, slide.PreparationInformation.Count());
            }




        

    }

}
