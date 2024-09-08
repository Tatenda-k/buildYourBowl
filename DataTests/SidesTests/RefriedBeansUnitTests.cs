
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests { 
    /// <summary>
    /// a class with unit tests for the RefiredBeans class
    /// </summary>
    public class RefriedBeansUnitTests
    {

        /// <summary>
        /// beans implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void RefriedBeansShouldImplementINotifyPropertyChanged()
        {
            RefriedBeans f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="size">the size of the beans</param>
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
            RefriedBeans f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Size = size;
            });
        }

        /// <summary>
        /// tests that property change is invoked
        /// </summary>
        /// <param name="onions">whether the beans have onions</param>
        /// <param name="propertyName">the property change that will be invoked</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Onions")]
        [InlineData(true, "Onions")]

        public void ChangingOnionsShouldNotifyOfPropertyChanges(bool onions, string propertyName)
        {
            RefriedBeans f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Onions = onions;
            });
        }

        /// <summary>
        /// tests that property change is invoked
        /// </summary>
        /// <param name="cheese">whether the beans have cheddar cheese</param>
        /// <param name="propertyName">the property change that will be invoked</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "CheddarCheese")]
        [InlineData(true, "CheddarCheese")]

        public void ChangingCheddarCheeseShouldNotifyOfPropertyChanges(bool cheese, string propertyName)
        {
            RefriedBeans f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.CheddarCheese = cheese;
            });
        }

        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            RefriedBeans side = new();
            Assert.Equal("Refried Beans", side.ToString());
        }
        /// <summary>
        /// refriedBeans object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            RefriedBeans side = new();
            Assert.IsAssignableFrom<Side>(side);
            Assert.IsAssignableFrom<IMenuItem>(side);
        }


        /// <summary>
        /// checks that onions property is initially set to true;
        /// </summary>
        [Fact]
        public void OnionsPropertyInitiallisedProperly()
        {
           RefriedBeans beans = new();
            Assert.True(beans.Onions);
        }

        /// <summary>
        /// checks that cheddarCheese property is initially set to true;
        /// </summary>
        [Fact]
        public void CheddarCheesePropertyInitiallisedProperly()
        {
            RefriedBeans beans = new();
            Assert.True(beans.CheddarCheese);
        }

        /// <summary>
        /// checks that size property is initially set to medium
        /// </summary>
        [Fact]
        public void SizePropertyInitiallisedProperly()
        {
            RefriedBeans beans = new();
            Assert.Equal(Size.Medium,beans.Size);
        }

        /// <summary>
        /// checks default price
        /// </summary>
        [Fact]
        public void PricePropertyInitiallisedProperly()
        {
            RefriedBeans beans = new();
            Assert.Equal(3.75m,beans.Price);
        }

 
        ///<summary>
        /// checks default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyInitialTest()
        {
            RefriedBeans beans= new();
            Assert.Equal(300u, beans.Calories);
        }
        /// <summary>
        /// checks that prices are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="expectedPrice">the expected price</param>

        [Theory]
        [InlineData(Size.Kids, 2.75)]
        [InlineData(Size.Large, 4.5)]
        [InlineData(Size.Small, 3.25)]
        [InlineData(Size.Medium,3.75)]
        public void PricePropertyTest(Size size, decimal expectedPrice)
        {
            RefriedBeans beans = new();
            beans.Size = size;
            
            Assert.Equal(expectedPrice, beans.Price);

        }

        /// <summary>
        /// checks that calories are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="cheese">the cotijaCheese property</param>
        /// <param name="onions">the onions property</param>
        /// <param name="expectedCalories">the expected calories</param>

        [Theory]
        [InlineData(Size.Kids, true, true, 180)]
        [InlineData(Size.Large, true, true, 450)]
        [InlineData(Size.Small, true, true, 225)]
        [InlineData(Size.Medium, true, true, 300)]
        [InlineData(Size.Small, true, false, 221)]
        [InlineData(Size.Large, false, true, 315)]

        public void CaloriesPropertyTest(Size size, bool cheese, bool onions, uint expectedCalories)
        {
            
            RefriedBeans beans = new();
            beans.Size = size;
            beans.CheddarCheese = cheese;
            beans.Onions =onions;
            Assert.Equal(expectedCalories, beans.Calories);

        }


        /// <summary>
        /// checks that preperation information is generated correctly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="cheese">the cotijaCheese property</param>
        /// <param name="onions">the onions property</param>
        /// <param name="info">the expected information</param>

        [Theory]
        [InlineData(Size.Kids, true, true, new string[] { "Kids" })]
        [InlineData(Size.Large, true, true, new string[] { "Large" })]
        [InlineData(Size.Small, true, true, new string[] { "Small" })]
        [InlineData(Size.Medium, true, true, new string[] { "Medium" })]
        [InlineData(Size.Small, true, false, new string[] { "Small", "Hold Onions" })]
        [InlineData(Size.Large, false, true, new string[] { "Large", "Hold Cheddar Cheese" })]

        public void PreperationInformationTest(Size size, bool cheese, bool onions, string[] info)
        {
            RefriedBeans beans = new();
            beans.Size = size;
            beans.CheddarCheese = cheese;
            beans.Onions = onions;

            foreach (string str in info)
            {

                Assert.Contains(str, beans.PreparationInformation);
            }
            Assert.Equal(info.Length, beans.PreparationInformation.Count());


        }
    }
}
