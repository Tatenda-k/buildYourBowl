
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// unit test class for Milk class
    /// </summary>
    public class MilkUnitTests
    {

        /// <summary>
        /// milk implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void MilkShouldImplementINotifyPropertyChanged()
        {
            Milk f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }

        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="choc">whether the milk has chocolate</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Chocolate")]
        [InlineData(true, "Chocolate")]
        [InlineData(false, "Calories")]
        [InlineData(true, "Calories")]
        public void ChangingChocoloateShouldNotifyOfPropertyChanges(bool choc, string propertyName)
        {
            Milk f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Chocolate = choc;
            });
        }

        

        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Milk drink = new();
            Assert.Equal("Milk", drink.ToString());
        }
        /// <summary>
        /// milk object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            Milk drink = new();
            Assert.IsAssignableFrom<Drink>(drink);
            Assert.IsAssignableFrom<IMenuItem>(drink);
        }

        /// <summary>
        /// test that milk size does not change
        /// </summary>
        [Fact]
        public void MilkSizeDoesNotChange()
        {
            Milk milk = new();
            milk.Size = Size.Large;
            Assert.Equal(Size.Kids, milk.Size);
        }


        /// <summary>
        /// test that the chocolate property is initially set to false
        /// </summary>
        [Fact]
        public void ChocolatePropertyIsInitiallisedCorrectlyTest()
        {

            Milk milk = new Milk();
            Assert.False(milk.Chocolate);
        }

        ///<summary>
        /// test default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyIsInitiallisedCorrectlyTest()
        {

            Milk milk = new Milk();
            Assert.Equal(200u, milk.Calories);
        }

        /// <summary>
        /// tests that calories are properly calculated
        /// </summary>      
        /// <param name="choc">whether chocolate is included</param>
        /// <param name="expectedCals">the calories in the drink</param>

        [Theory]
        [InlineData(true, 270)]
        [InlineData(false, 200)]

        public void CaloriesPropertyTest(bool choc, uint expectedCals)
        {

            Milk milk = new Milk();
            milk.Chocolate = choc;
            Assert.Equal(expectedCals, milk.Calories);
        }
        /// <summary>
        /// tests that the preperation information has been properly generated 
        /// </summary>
        /// <param name="choc">whether chocolate should be included</param>
        /// <param name="info">the preperation instructions</param>

        [Theory]
        [InlineData(false, new string[] { })]
        [InlineData(true, new string[] { "Chocolate" })]

        public void PreperationInformationTest(bool choc, string[] info)
        {
            Milk milk = new Milk();
            milk.Chocolate = choc;
            foreach (string str in info)
            {

                Assert.Contains(str, milk.PreparationInformation);
            }
            Assert.Equal(info.Length, milk.PreparationInformation.Count());



        }
      
    }
}
