
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// unit tests for the Horchata class
    /// </summary>
    public  class HorchataUnitTests
    {


        /// <summary>
        /// agua fresca implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void AguaFrescaShouldImplementINotifyPropertyChanged()
        {
            AguaFresca f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="ice">whether the drink has ice</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Ice")]
        [InlineData(true, "Ice")]
        [InlineData(false, "Calories")]
        [InlineData(true, "Calories")]
        public void ChangingIceShouldNotifyOfPropertyChanges(bool ice, string propertyName)
        {
            Horchata f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Ice = ice;
            });
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Horchata drink = new();
            Assert.Equal("Horchata", drink.ToString());
        }

        /// <summary>
        /// horchata object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            Horchata drink = new();
            Assert.IsAssignableFrom<Drink>(drink);
            Assert.IsAssignableFrom<IMenuItem>(drink);
        }


        /// <summary>
        /// test that the Ice property is initially set to true
        /// </summary>
        [Fact]
            public void IcePropertyIsInitiallisedCorrectylTest()
            {

                Horchata drink = new Horchata();
                Assert.True(drink.Ice);
            }
            
            /// <summary>
            /// test that the size property is initially medium
            /// </summary>
            [Fact]
            public void SizePropertyIsInitiallyCorrectTest()
            {

            Horchata drink = new Horchata();
                Assert.Equal(Size.Medium, drink.Size);
            }

        ///<summary>
        /// test default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyIsInitiallisedCorrectlyTest()
        {

            Horchata drink = new Horchata();
            Assert.Equal(280u, drink.Calories);
        }
        ///<summary>
        /// test that the calories property is initiallised properly
        /// </summary>
        [Fact]
        public void PricePropertyIsInitiallisedCorrectlyTest()
        {
            Horchata drink = new Horchata();
            Assert.Equal(3.5m, drink.Price);
        }
    


        /// <summary>
        /// tests that calories are properly calculated
        /// </summary>
        /// <param name="size">the drink size</param>    
        /// <param name="ice">whether the drink has ice</param>
        /// <param name="expectedCalories">the calories in the drink</param>
        [Theory]
            [InlineData(true, Size.Large,420) ]
            [InlineData(true, Size.Small,210)]
            [InlineData(false, Size.Medium,310)]
            [InlineData(true, Size.Kids,168)]
            [InlineData(false, Size.Large, 465)]
            [InlineData(true, Size.Medium, 280)]

            public void CaloriesPropertyTest(bool ice, Size size,uint expectedCalories)
            {
                Horchata drink = new Horchata();
                drink.Ice = ice;
                drink.Size = size;
               

                Assert.Equal(expectedCalories, drink.Calories);
            }
            /// <summary>
            /// tests that the preperation information has been properly generated 
            /// </summary>
            /// <param name="size">the drink size</param>
            /// <param name="ice">whether the drink has ice</param>
            /// <param name="info">the preperation instructions</param>

            [Theory]
            [InlineData(Size.Large,false, new string[] { "Large", "Hold Ice" })]
            [InlineData(Size.Medium, true, new string[] { "Medium" })]
            [InlineData(Size.Kids,  false, new string[] { "Kids", "Hold Ice" })]
            [InlineData(Size.Small,  true, new string[] { "Small" })]
            public void PreperationInformationCorrect(Size size, bool ice, string[] info)
            {
                Horchata drink=new Horchata();
                drink.Size = size;
                
                drink.Ice = ice;
                foreach (string str in info)
                {

                    Assert.Contains(str, drink.PreparationInformation);
                }
            Assert.Equal(info.Length, drink.PreparationInformation.Count());

        }
        /// <summary>
        /// tests that price is properly calculated
        /// </summary>
        /// <param name="size">the drink size</param>  
        ///<param name="expectedPrice">the expected price</param>
        /// <param name="ice">whether the drink has ice</param>
        [Theory]
        [InlineData(Size.Small, true, 3)]
        [InlineData(Size.Medium,  false, 3.5)]
        [InlineData(Size.Kids, false, 2.5)]
        [InlineData(Size.Large, true, 3.5+0.75)]
        [InlineData(Size.Medium, true, 3.5)]
        [InlineData(Size.Large, false, 4.25)]

        public void PricePropertyTest(Size size,  bool ice, decimal expectedPrice)
        {
            Horchata drink = new ();
            drink.Ice = ice;

            drink.Size = size;
         

            Assert.Equal(expectedPrice, drink.Price);
        }






    }
}





