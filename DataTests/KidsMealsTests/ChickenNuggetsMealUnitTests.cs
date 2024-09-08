

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.DataTests
{
    /// <summary>
    /// class with unit tests for the ChickenNuggetsMeal
    /// </summary>
    public class ChickenNuggetsMealUnitTests
    {

        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="drinkSize">the size of the drink</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData( "Size")]
       
        [InlineData( "PreparationInformation")]
       
        [InlineData( "Calories")]
       
        [InlineData( "Price")]
        public void ChangingDrinkShouldNotifyOfPropertyChange( string propertyName)
        {
            ChickenNuggetsMeal meal = new();

            meal.SideChoice = new MockSide();

            Assert.PropertyChanged(meal, propertyName, () => {

                meal.DrinkChoice = new MockDrink() ;

            });

        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="sideSize">the size of the side</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData( "Size")]
        
        [InlineData( "PreparationInformation")]
        [InlineData("Calories")]
       
        [InlineData("Price")]
        public void ChangingSideShouldNotifyOfPropertyChange( string propertyName)
        {
            ChickenNuggetsMeal meal = new();


            meal.DrinkChoice = new MockDrink();

            Assert.PropertyChanged(meal, propertyName, () => {
                meal.SideChoice = new MockSide();

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

            ChickenNuggetsMeal meal = new();
            Assert.PropertyChanged(meal, propertyName, () => {
                meal.ItemCount = count;
            });


        }
        /// <summary>
        /// chickenNuggets object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            ChickenNuggetsMeal meal = new();
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
        public override uint Calories { get; }

    }
        /// <summary>
        /// the price is calculated correctly for different side and drink sizes 
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="sideSize">the side size</param>
        /// <param name="count">the number of nuggets</param>
        ///<param name="expectedPrice">the expected added price for drinks and sides</param>
        [Theory]
        [InlineData(Size.Large, Size.Small,8,2)]
        [InlineData(Size.Large, Size.Large,7,3)]
        [InlineData(Size.Kids, Size.Small,6,0.5)]
        [InlineData(Size.Large, Size.Medium,5,2.5)]
        
        public void PricePropertyTest4(Size drinkSize, Size sideSize,uint count,decimal expectedPrice)
    {
        ChickenNuggetsMeal meal = new();
        meal.ItemCount = count;
        meal.DrinkChoice = new MockDrink() { Size = drinkSize };
        meal.SideChoice = new MockSide() { Size = sideSize };
            
        Assert.Equal(5.99m + 0.75m * (count-5) + expectedPrice, meal.Price);


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
        [InlineData(Size.Large, Size.Kids, 8, 60 * 8)]
        [InlineData(Size.Medium, Size.Kids, 5, 60 * 5)]
        [InlineData(Size.Medium, Size.Large, 5, 60 * 5)]
        [InlineData(Size.Small,Size.Small,6,60*6)]
        [InlineData(Size.Kids, Size.Kids, 5, 60 * 5)]

        public void CaloriesPropertyWorkingProperly1(Size sideSize, Size drinkSize, uint count, decimal expectedCalories)
        {

            ChickenNuggetsMeal meal = new();
            meal.ItemCount = count;
            meal.DrinkChoice = new MockDrink() {  Size=drinkSize } ;
            meal.SideChoice = new MockSide() { Size = sideSize };


            Assert.Equal(expectedCalories + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);

        }



        /// <summary>
        /// checks that count property is initially set to 5
        /// </summary>
        [Fact]
        public void CountPropertyInitiallisedProperlyTEst()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal(5u, meal.ItemCount);
        }
        /// <summary>
        /// checks that drink choice is initially set to milk without chocolate
        /// </summary>
        [Fact]
        public void DrinkPropertyInitiallisedProperlyTest()
        {
            ChickenNuggetsMeal meal = new();

            Milk milk =(Milk) meal.DrinkChoice;
            
            Assert.False(milk.Chocolate);

        }
        /// <summary>
        /// checks that SideChoice  is initially set to fries with kids size
        /// </summary>
        [Fact]
        public void FriesPropertyInitiallisedProperlyTest()
        {
            ChickenNuggetsMeal meal = new();
           
            Assert.Equal(Size.Kids, meal.SideChoice.Size);
        }

        /// <summary>
        /// ensuers the default price is correct 
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
           ChickenNuggetsMeal meal = new();
            Assert.Equal(5.99m, meal.Price);
        }
        /// <summary>
        /// ensuers the default calories is correct 
        /// </summary>
        [Fact]
        public void DefaultCalories()
        {
            ChickenNuggetsMeal meal = new();
            Assert.Equal(300+ meal.DrinkChoice.Calories+meal.SideChoice.Calories, meal.Calories);
        }

        /// <summary>
        /// count property does not set values out of set bounds
        /// </summary>
        /// <param name="count">the value to set the count property</param>
        [Theory]
        [InlineData(4)]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(25)]
        public void CountPropertyDoesNotSetOutOfBoundNumbersTest(uint count)
        {
            ChickenNuggetsMeal meal = new();
            meal.ItemCount = count;
            Assert.Equal(5u, meal.ItemCount);
        }

      

       
       
            /// <summary>
            /// /tests the calories property of kids meal
            /// </summary>
        [Fact]
        public void CaloriesPropertyTest1()
        {
            ChickenNuggetsMeal meal = new();
            meal.ItemCount = 8;

            meal.SideChoice = new Fries();
            meal.SideChoice.Size = Size.Small;
            meal.DrinkChoice = new Horchata();
            Assert.Equal(60*8 + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);
        }
        /// <summary>
        /// tests the calories property of meal
        /// </summary>

        [Fact]
        public void CaloriesPropertyTest2()
        {
            ChickenNuggetsMeal meal = new();
            meal.ItemCount = 5;

            meal.SideChoice = new Fries();
         
            Assert.Equal(60 * 5 + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);
        }
        /// <summary>
        /// tests calories property of meal
        /// </summary>

        [Fact]
        public void CaloriesPropertyTest3()
        {
            ChickenNuggetsMeal meal = new();
            meal.ItemCount = 7;

            meal.SideChoice = new StreetCorn();
            meal.SideChoice.Size = Size.Small;
            meal.DrinkChoice = new AguaFresca();
            meal.DrinkChoice.Size = Size.Large;


            Assert.Equal(60 * 7 + meal.DrinkChoice.Calories + meal.SideChoice.Calories, meal.Calories);
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
        [InlineData(Size.Large, Size.Kids, 8,  60*8)]
        [InlineData(Size.Medium, Size.Kids, 5,60*5)]
        [InlineData(Size.Medium, Size.Large, 5,60*5)]
        // [InlineData(Size.Small,Size.Large,4,11.99)]
        // [InlineData(Size.Medium,Size.Large,5,14.49)]
        public void CaloriesPropertyWorkingProperly(Size sideSize, Size drinkSize, uint count,decimal expectedCalories)

        {

            ChickenNuggetsMeal meal = new();
            meal.ItemCount = count;
            meal.SideChoice.Size = sideSize;

            meal.DrinkChoice.Size = drinkSize;
            

            Assert.Equal(expectedCalories+meal.DrinkChoice.Calories+meal.SideChoice.Calories, meal.Calories);


        }


        /// <summary>
        /// checks that preperation information is generated correctly
        /// </summary>       
        /// <param name="info">the expected information</param>
        /// <param name="count">the count property</param>      
        /// <param name="sideSize">the size of the side</param>
        [Theory]
        [InlineData(5, Size.Medium,  new string[] { })]
        [InlineData(8, Size.Large,new string[]{ "8 Nuggets" })]
        [InlineData(7,  Size.Large, new string[] { "7 Nuggets" })]
        public void PreperationInformationCorrect(uint count, Size sideSize,string[] info)

        {

            
            ChickenNuggetsMeal meal = new();
            meal.ItemCount = count;

        meal.SideChoice.Size = sideSize;
            foreach (string str in info)
            {
                Assert.Contains(str, meal.PreparationInformation);

            }
        }
    }
}
