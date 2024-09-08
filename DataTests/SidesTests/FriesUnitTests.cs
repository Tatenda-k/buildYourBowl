
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// a class of unit tests for the Fries class
    /// </summary>
    public class FriesUnitTests
    {
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="size">the size of the fries</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Size.Kids, "Size")]
        [InlineData(Size.Small, "Size")]
        [InlineData(Size.Medium, "Size")]
        [InlineData(Size.Large, "Size")]
        [InlineData(Size.Kids, "Price")]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Kids, "Calories")]
        [InlineData(Size.Small, "Calories")]
        [InlineData(Size.Medium, "Calories")]
        [InlineData(Size.Large, "Calories")]
        [InlineData(Size.Kids, "PreparationInformation")]
        [InlineData(Size.Small, "PreparationInformation")]
        [InlineData(Size.Medium, "PreparationInformation")]
        [InlineData(Size.Large, "PreparationInformation")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            Fries f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Size = size;
            });
        }

        /// <summary>
        /// tests that property change is invoked
        /// </summary>
        /// <param name="curly">whether the fries are curly or not</param>
        /// <param name="propertyName">the property change that will be invoked</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Curly")]
        [InlineData(true, "Curly")]

        public void ChangingCurlyShouldNotifyOfPropertyChanges(bool curly, string propertyName)
        {
            Fries f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Curly = curly;
            });
        }
        /// <summary>
        /// fries implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void FriesShouldImplementINotifyPropertyChanged()
        {
            Fries f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Fries side = new();
            Assert.Equal("Fries", side.ToString());
        }
        /// <summary>
        /// fries object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            Fries side = new();
            Assert.IsAssignableFrom<Side>(side);
            Assert.IsAssignableFrom<IMenuItem>(side);
        }
        /// <summary>
        /// checks that curly property is initially set to false;
        /// </summary>
        [Fact]
        public void CurlyPropertyInitiallisedProperlyTest()
        {
            Fries fries = new();
            Assert.False(fries.Curly);
           
        }

        /// <summary>
        /// checks that size property is initially set to medium
        /// </summary>
        [Fact]
        public void SizePropertyInitiallisedProperlyTest()
        {
            Fries fries = new();
            Assert.Equal(Size.Medium, fries.Size);
        }
        ///<summary>
        /// checks default price
        /// </summary>
        [Fact]
        public void PricePropertyInitialTest()
        {
            Fries fries = new();
            Assert.Equal(3.5m, fries.Price);
        }

        ///<summary>
        /// checks default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyInitialTest()
        {
            Fries fries = new();
            Assert.Equal(350u, fries.Calories);
        }


        /// <summary>
        /// checks that prices are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="expectedPrice">the expected price</param>
        /// <param name="curly">the curly property</param>

        [Theory]
        [InlineData(Size.Kids, true, 2.5)]

        [InlineData(Size.Large,false, 4.25)]
        [InlineData(Size.Small,false, 3)]

        [InlineData(Size.Medium, true,3.5)]
        public void PricePropertyTest(Size size,bool curly, decimal expectedPrice)
        {
            Fries fries = new();
            fries.Size = size;
            fries.Curly = curly;


            Assert.Equal(expectedPrice, fries.Price);

        }

        /// <summary>
        /// checks that calories are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="curly">the curly property</param>
        /// <param name="expectedCalories">the expected calories</param>

        [Theory]
        [InlineData(Size.Kids, true, 210)]
        [InlineData(Size.Large, false, 525)]
        [InlineData(Size.Small, false, 262)]
        [InlineData(Size.Medium, true, 350)]
        
        public void CaloriesPropertTest(Size size,  bool curly, uint expectedCalories)
        {

            Fries fries = new();
            fries.Size = size;
            fries.Curly = curly;
            Assert.Equal(expectedCalories, fries.Calories);

        }


        /// <summary>
        /// checks that caloriesare generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="curly">the curly property</param>
        /// <param name="info">the expected information</param>

        [Theory]
        [InlineData(Size.Kids, true, new string[] { "Kids","Curly" })]
        [InlineData(Size.Large, true,  new string[] { "Large","Curly" })]
        [InlineData(Size.Small, false, new string[] { "Small" })]
        [InlineData(Size.Medium, false, new string[] { "Medium" })]
       

        public void PreperationInformationTest(Size size,  bool curly, string[] info) { 


            Fries fries = new();
            fries.Size = size;
            fries.Curly = curly;
            
            foreach (string str in info)
            {

                Assert.Contains(str, fries.PreparationInformation);
            }
            Assert.Equal(info.Length, fries.PreparationInformation.Count());

        }

    }
}
