using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// class with unit tests for corn dog bites meal
    /// </summary>
    public class CornDogBitesMealUnitTests
    {
        /// <summary>
        /// cornDogBites meal object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            CornDogBitesMeal meal = new();
            Assert.IsAssignableFrom<KidsMeal>(meal);
            Assert.IsAssignableFrom<IMenuItem>(meal);
        }
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockSide : Side
        {
            /// <summary>
            /// name of mock object
            /// </summary>
            public override string Name { get; }
            /// <summary>
            /// description of mock object
            /// </summary>
            public override string Description { get; }
            /// <summary>
            /// price of mock object 
            /// </summary>
            public override decimal Price { get; }
            /// <summary>
            /// preperation information for the mock object
            /// </summary>
            public override IEnumerable<string> PreparationInformation { get; }
            /// <summary>
            /// calories for the mock object
            /// </summary>
            public override uint Calories { get; }
        }

        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockDrink : Drink
        {
            /// <summary>
            /// name of the mock object
            /// </summary>
            public override string Name => throw new NotImplementedException();
            /// <summary>
            /// description of the mock object
            /// </summary>
            public override string Description => throw new NotImplementedException();
            /// <summary>
            /// price of the mock object
            /// </summary>
            public override decimal Price { get; }
            /// <summary>
            /// preperation information of the mock object
            /// </summary>
            public override IEnumerable<string> PreparationInformation => throw new NotImplementedException();

            /// <summary>
            /// calories of the mock object
            /// </summary>
            public override uint Calories { get; }

        }
        /// <summary>
        /// the price is calculated correctly for different side and drink sizes 
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="sideSize">the side size</param>
        /// <param name="count">the number of nuggets</param>
        /// <param name="expectedPrice">the expected additional price for sides and drinks</param>

        [Theory]
        [InlineData(Size.Large, Size.Small, 8,2)]
        [InlineData(Size.Large, Size.Large, 7,3)]
        [InlineData(Size.Kids, Size.Small, 6,0.5)]
        [InlineData(Size.Large, Size.Medium, 5,2.5)]

        public void PricePropertyTest4(Size drinkSize, Size sideSize, uint count,decimal expectedPrice)
        {
            CornDogBitesMeal meal = new();
            meal.ItemCount = count;
            meal.DrinkChoice = new MockDrink() { Size = drinkSize };
            meal.SideChoice = new MockSide() { Size = sideSize };

            Assert.Equal(5.99m + 0.75m * (count - 5) +expectedPrice, meal.Price);


        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="drinkSize">the size of the drink</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Kids,  "Size")]
        [InlineData(Size.Medium, "Size" )]
        [InlineData(Size.Large, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Medium, "Price")]
        public void ChangingDrinkShouldNotifyOfPropertyChange( Size drinkSize, string propertyName)
        {
            CornDogBitesMeal meal = new();
          
            meal.SideChoice = new MockSide() ;
            
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
        public void ChangingSideShouldNotifyOfPropertyChange(Size sideSize,  string propertyName)
        {
            CornDogBitesMeal meal = new();

        
            meal.DrinkChoice = new MockDrink() ;
     
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

        public void ChangingItemCountShouldNotifyOfPropertyChange(uint count,string propertyName)
        {

            CornDogBitesMeal meal = new();
            Assert.PropertyChanged(meal, propertyName, () => {
                meal.ItemCount = count;
            });

         
        }

        
        /// <summary>
        /// checks that calories are generated properly
        /// </summary>
        /// <param name="expectedCalories">the expected price</param>
        /// <param name="sideSize">the size property of the side</param>
        /// <param name="drinkSize">the size property of the drink</param>
        /// <param name="count">the count property</param>

        [Theory]
        //[InlineData(Size.Kids, Size.Kids,3,true, )]
        [InlineData(Size.Large, Size.Kids, 8, 50 * 8)]
        [InlineData(Size.Medium, Size.Kids, 5, 50 * 5)]
        [InlineData(Size.Medium, Size.Large, 5, 50 * 5)]
        [InlineData(Size.Small, Size.Small, 6, 50 * 6)]
        [InlineData(Size.Kids, Size.Kids, 5, 50 * 5)]

        public void CaloriesPropertyWorkingProperly1(Size sideSize, Size drinkSize, uint count, decimal expectedCalories)
        {

            CornDogBitesMeal meal = new();
            meal.ItemCount = count;
            meal.DrinkChoice = new MockDrink() { Size = drinkSize };
            meal.SideChoice = new MockSide() { Size = sideSize };


            Assert.Equal(expectedCalories + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);

        }




        /// <summary>
        /// checks that count property is initially set to 2
        /// </summary>
        [Fact]
        public void CountPropertyInitiallisedProperlyTest()
        {
           CornDogBitesMeal meal= new();
            Assert.Equal(5u, meal.ItemCount);
        }
        /// <summary>
        /// checks that drink choice is initially set to milk without chocolate
        /// </summary>
        [Fact]
        public void DrinkPropertyInitiallisedProperlyTest()
        {
            CornDogBitesMeal meal = new();

            Milk milk = (Milk)meal.DrinkChoice;
            
            Assert.False(milk.Chocolate);

        }
        /// <summary>
        /// checks that SideChoice  is initially set to fries with kids size
        /// </summary>
        [Fact]
        public void FriesPropertyInitiallisedProperlyTest()
        {
            CornDogBitesMeal meal = new();
            Assert.Equal(Size.Kids, meal.SideChoice.Size);
        }
        /// <summary>
        /// ensures the default price is correct 
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            CornDogBitesMeal meal = new();
            Assert.Equal(5.99m, meal.Price);
        }

        /// <summary>
        /// ensuers the default calories is correct 
        /// </summary>
        [Fact]
        public void DefaultCalories()
        {
            CornDogBitesMeal meal = new();
            Assert.Equal(250u + meal.SideChoice.Calories + meal.DrinkChoice.Calories, meal.Calories);
        }


        /// <summary>
        /// count property does not set values out of set bounds
        /// </summary>
        /// <param name="count">the value to set the count property</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(9)]
        [InlineData(4)]
        public void CountPropertyDoesNotSetOutOfBoundNumbersTest(uint count)
        {
            CornDogBitesMeal meal = new();
            meal.ItemCount = count;
            Assert.Equal(5u, meal.ItemCount);
        }
        /// <summary>
        /// checks that prices are generated properly
        /// </summary>
        /// <param name="sideSize">the size property of the side</param>
        /// <param name="drinkSize">the size property of the drink</param>
        /// <param name="count">the count property </param>
        /// <param name="expectedPrice">the expected price</param>
        [Theory]
        [InlineData(Size.Kids, Size.Kids, 5, 5.99)]
        [InlineData(Size.Large, Size.Kids, 8, 5.99+3*0.75+1.5)]
        [InlineData(Size.Medium, Size.Kids, 6, 5.99 + 0.75+1)]
        // [InlineData(Size.Small,Size.Large,4,11.99)]
        // [InlineData(Size.Medium,Size.Large,5,14.49)]
        public void PricePropertyTest(Size sideSize, Size drinkSize, uint count, decimal expectedPrice)
        {
           CornDogBitesMeal meal = new();
           meal.SideChoice.Size = sideSize;
       meal.DrinkChoice.Size = drinkSize;

            meal.ItemCount = count;

            Assert.Equal(expectedPrice, meal.Price);

        }

        /// <summary>
        /// checks that calories are generated properly
        /// </summary>
        /// <param name="sideSize">the size property of the side</param>
        /// <param name="expectedCalories">the expected calories</param>
        /// <param name="drinkSize">the size property of the drink</param>
        /// <param name="count">the count property</param>
        [Theory]
        //[InlineData(Size.Kids, Size.Kids,3,true, )]
        ///specific required test case

        [InlineData(Size.Large, Size.Kids, 8,  400)]
        [InlineData(Size.Medium, Size.Kids, 6,  300)]
        [InlineData(Size.Small, Size.Kids, 5,250)]
        //[InlineData(Size.Medium, Size.Kids, 5, 12.99)]
        // [InlineData(Size.Small,Size.Large,4,11.99)]
        // [InlineData(Size.Medium,Size.Large,5,14.49)]
        public void CaloriesPropertyTest(Size sideSize, Size drinkSize, uint count,  decimal expectedCalories)

        {
            
            CornDogBitesMeal meal = new();
            meal.SideChoice.Size = sideSize;
            meal.ItemCount = count;

            meal.DrinkChoice.Size = drinkSize;          


            Assert.Equal(expectedCalories +meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);

        }


        /// <summary>
        /// checks that preperation information is  generated properly
        /// </summary>
        /// <param name="info">the expected information</param>
        /// <param name="count">the count property</param>

        
        [Theory]
        [InlineData(8,  new string[] { "8 Bites"})]
        //specific required test case
        [InlineData(6 ,new string[] {  "6 Bites" })]
        [InlineData(5,new string[] { })]
        public void PreperationInformationTest(uint count, string[] info)
        {

            CornDogBitesMeal meal = new();
            meal.ItemCount = count;

            foreach (string str in info)
            {
                Assert.Contains(str, meal.PreparationInformation);
            }

            Assert.Equal(info.Length+3, meal.PreparationInformation.Count());

        }
    }
}
