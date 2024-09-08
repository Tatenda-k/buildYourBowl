using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data
{ 
    /// <summary>
    /// unit tests for the agua fresca unit class
    /// </summary>
    public class AguaFrescaUnitTests
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
            AguaFresca f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Ice=ice;
            });
        }


        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="flavor">the flavor of the drink</param>
        /// <param name="propertyName">the property that will change</param>
        [Theory]
        [InlineData(Flavor.Tamarind, "Flavor")]
        [InlineData(Flavor.Cucumber, "Flavor")]
        [InlineData(Flavor.Strawberry, "Flavor")]
        [InlineData(Flavor.Limonada, "Flavor")]
        [InlineData(Flavor.Tamarind, "Price")]
        [InlineData(Flavor.Lime, "Price")]
        [InlineData(Flavor.Cucumber, "Price")]
        [InlineData(Flavor.Strawberry, "Price")]
        [InlineData(Flavor.Tamarind, "Calories")]
        [InlineData(Flavor.Cucumber, "Calories")]
        [InlineData(Flavor.Lime, "Calories")]
        [InlineData(Flavor.Strawberry, "Calories")]
        [InlineData(Flavor.Tamarind, "PreparationInformation")]
        [InlineData(Flavor.Cucumber, "PreparationInformation")]
        [InlineData(Flavor.Lime, "PreparationInformation")]
        [InlineData(Flavor.Strawberry, "PreparationInformation")]
        public void ChangingFlavorShouldNotifyOfPropertyChanges(Flavor flavor, string propertyName)
        {
            AguaFresca f  = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Flavor = flavor;
            });
        }
        /// <summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void  ToStringTest()
        {
            AguaFresca drink = new();
            Assert.Equal("Agua Fresca", drink.ToString());
        }
        /// <summary>
        /// aguaFresca object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            AguaFresca drink = new();
            Assert.IsAssignableFrom<Drink>(drink);
            Assert.IsAssignableFrom<IMenuItem>(drink);
        }
        /// <summary>
        /// test that the Ice property is initially set to true
        /// </summary>
        [Fact]
        public void IcePropertyIsInitiallyCorrect()
        {

            AguaFresca af = new AguaFresca();
            Assert.True(af.Ice);
        }
        /// <summary>
        /// test that the flavor property is initially set to Limonada
        /// </summary>
        [Fact]
        public void FlavorPropertyIsInitiallyCorrect()
        {

            AguaFresca af = new AguaFresca();
            Assert.Equal(Flavor.Limonada, af.Flavor);
        }
        /// <summary>
        /// test that the size property is correctly initiallized to medium
        /// </summary>
        [Fact]
        public void SizePropertyIsInitiallyCorrect()
        {

            AguaFresca af = new AguaFresca();
            Assert.Equal(Size.Medium, af.Size);
        }

        ///<summary>
        /// test default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyIsInitiallisedCorrectlyTest()
        {

            AguaFresca af = new AguaFresca();
            Assert.Equal(125u,af.Calories);
        }
        ///<summary>
        /// test that the price property is initiallised properly
        /// </summary>
        [Fact]
        public void PricePropertyIsInitiallisedCorrectlyTest()
        {

            AguaFresca af = new AguaFresca();
            Assert.Equal(3,af.Price);
        }
        /// <summary>
        /// tests that calories are properly calculated
        /// </summary>
        /// <param name="size">the drink size</param>
        /// <param name="flavor">the flavor of the drink</param>
        /// <param name="ice">whether the drink has ice</param>
        /// <param name="expectedCalories">the calories in the drink</param>
        [Theory]
        [InlineData(true, Size.Large, Flavor.Strawberry, 225)]
        [InlineData(true, Size.Small, Flavor.Cucumber, 56)]
        [InlineData(false, Size.Medium, Flavor.Limonada, 135)]
        [InlineData(true, Size.Kids, Flavor.Tamarind, 90)]
        [InlineData(false, Size.Large, Flavor.Cucumber, 127)]
        [InlineData(false, Size.Medium, Flavor.Lime, 135)]
        [InlineData(true, Size.Kids, Flavor.Cucumber, 45)]
        //specific required test case
        [InlineData(false, Size.Large, Flavor.Tamarind, 240)]



        public void CaloriesPropertyIsCorrect(bool ice, Size size, Flavor flavor, uint expectedCalories)
        {
            AguaFresca af = new AguaFresca();
            af.Ice = ice;
            af.Size = size;
            af.Flavor = flavor;

            Assert.Equal(expectedCalories, af.Calories);
        }
        /// <summary>
        /// tests that the preperation information has been properly generated 
        /// </summary>
        /// <param name="size">the drink size</param>
        /// <param name="flavor">the flavor of the drink</param>
        /// <param name="ice">whether the drink has ice</param>
        /// <param name="info">the preperation instructions</param>

        [Theory]
        [InlineData(Size.Large, Flavor.Tamarind, false, new string[] { "Large", "Tamarind", "Hold Ice" })]
        //specific required test case
        [InlineData(Size.Large, Flavor.Limonada, false, new string[] { "Large", "Limonada", "Hold Ice" })]
        [InlineData(Size.Medium, Flavor.Cucumber, true, new string[] { "Medium", "Cucumber" })]
        [InlineData(Size.Kids, Flavor.Lime, false, new string[] { "Kids", "Lime", "Hold Ice" })]
        [InlineData(Size.Small, Flavor.Strawberry, true, new string[] { "Small", "Strawberry" })]
        public void PreperationInformationCorrect(Size size, Flavor flavor, bool ice, string[] info)
        {
            AguaFresca af = new AguaFresca();
            af.Size = size;
            af.Flavor = flavor;
            af.Ice = ice;
            foreach (string str in info)
            {
        Assert.Contains(str, af.PreparationInformation);
            }
            Assert.Equal(info.Length, af.PreparationInformation.Count());



        }
        /// <summary>
        /// tests that price is properly calculated
        /// </summary>
        /// <param name="size">the drink size</param>  
        /// <param name="flavor">the drink flavor</param>
        /// <param name="expectedPrice">the expected price of the drink</param>
        /// <param name="ice">whether the drink has ice</param>
        [Theory]
        [InlineData(Size.Small, Flavor.Limonada, true,2.5)]
        [InlineData(Size.Medium, Flavor.Tamarind,false, 3.5)]
        [InlineData(Size.Kids, Flavor.Cucumber,false, 2.0)]
        [InlineData(Size.Large, Flavor.Lime,true, 3.75)]
        [InlineData(Size.Medium, Flavor.Strawberry,true, 3)]
        //specific required test case
        [InlineData(Size.Large, Flavor.Tamarind,false, 4.25)]

        public void PricePropertyIsCorrect(Size size, Flavor flavor, bool ice,decimal expectedPrice)
        {
            AguaFresca drink = new AguaFresca();
            drink.Ice = ice;

            drink.Size = size;
            drink.Flavor = flavor;


            Assert.Equal(expectedPrice, drink.Price);
        }









    }
}
