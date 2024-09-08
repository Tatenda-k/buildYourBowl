
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests.SidesTests
{
    /// <summary>
    /// class of unit tests for the StreetCorn class
    /// </summary>
    public class StreetCornUnitTests
    {

        /// <summary>
        /// street corn implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void StreetCornShouldImplementINotifyPropertyChanged()
        {
            StreetCorn f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }


        /// <summary>
        /// tests that property changed is invoked
        /// </summary>
        /// <param name="size">the size of the street corn</param>
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
            StreetCorn f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Size = size;
            });
        }

        /// <summary>
        /// tests that property change is invoked
        /// </summary>
        /// <param name="cilantro">whether the corn has cilantro</param>
        /// <param name="propertyName">the property change that will be invoked</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "Cilantro")]
        [InlineData(true, "Cilantro")]

        public void ChangingOnionsShouldNotifyOfPropertyChanges(bool cilantro, string propertyName)
        {
            StreetCorn f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.Cilantro=cilantro;
            });
        }

        /// <summary>
        /// tests that property change is invoked
        /// </summary>
        /// <param name="cheese">whether the corn has cotija cheese</param>
        /// <param name="propertyName">the property change that will be invoked</param>
        [Theory]
        [InlineData(false, "PreparationInformation")]
        [InlineData(true, "PreparationInformation")]
        [InlineData(false, "CotijaCheese")]
        [InlineData(true, "CotijaCheese")]

        public void ChangingCheddarCheeseShouldNotifyOfPropertyChanges(bool cheese, string propertyName)
        {
           StreetCorn f = new();
            Assert.PropertyChanged(f, propertyName, () => {
                f.CotijaCheese=cheese;
            });
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            StreetCorn side = new();
            Assert.Equal("Street Corn", side.ToString());
        }
        /// <summary>
        /// streetCorn object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            StreetCorn side = new();
            Assert.IsAssignableFrom<Side>(side);
            Assert.IsAssignableFrom<IMenuItem>(side);
        }

        /// <summary>
        /// checks that cotijaCheese property is initially set to true;
        /// </summary>
        [Fact]
        public void CotijaCheesePropertyInitiallisedProperlyTest()
        {
            StreetCorn corn = new();
            Assert.True(corn.CotijaCheese);
        }

        /// <summary>
        /// checks that cilantro property is initially set to true;
        /// </summary>
        [Fact]
        public void CilantroPropertyInitiallisedProperlyTest()
        {
            StreetCorn corn = new();
            Assert.True(corn.Cilantro);
        }

        /// <summary>
        /// checks that size property is initially medium
        /// </summary>
        [Fact]
        public void SizePropertyInitiallisedProperlyTest()
        {
            StreetCorn corn = new();
            Assert.Equal(Size.Medium, corn.Size);
        }

        ///<summary>
        /// checks default price
        /// </summary>
        [Fact]
        public void PricePropertyInitiallisedProperlyTest()
        {
            StreetCorn corn = new();
            Assert.Equal(4.5m,corn.Price);
        }
        ///<summary>
        /// checks that default calories
        /// </summary>
        [Fact]
        public void CaloriesPropertyInitiallisedProperlyTest()
        {
            StreetCorn corn = new();
            Assert.Equal(300u,corn.Calories);
        }


        /// <summary>
        /// checks that prices are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="expectedPrice">the expected price</param>
        /// <param name="cheese">the cheese property</param>
        /// <param name="cilantro">the cilantro property</param>

        [Theory]
        [InlineData(Size.Kids,true,false, 3.25)]
        [InlineData(Size.Large,false,false, 5.5)]
        //special required test case
        [InlineData(Size.Small,true,true, 3.75)]
        [InlineData(Size.Medium,false,true, 4.5)]
        public void PricePropertyTest(Size size,bool cheese,bool cilantro, decimal expectedPrice)
        {
            StreetCorn corn = new();
            corn.Cilantro = cilantro;
            corn.CotijaCheese = cheese;
            corn.Size = size;
            Assert.Equal(expectedPrice, corn.Price);

        }

        /// <summary>
        /// checks that calories are generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="cheese">the cotijaCheese property</param>
        /// <param name="cilantro">the cilantro property</param>
        /// <param name="expectedCalories">the expected calories</param>

        [Theory]
        [InlineData(Size.Kids, true, true, 180)]
        [InlineData(Size.Large, true, true, 450)]
        [InlineData(Size.Small, true, true, 225)]
        [InlineData(Size.Medium, true, true, 300)]
        //specific required test case
        [InlineData(Size.Small, true, false, 221)]
        [InlineData(Size.Large, false, true, 330)]

        public void CaloriesPropertyTest(Size size, bool cheese, bool cilantro, uint expectedCalories)
        {
            StreetCorn corn = new();
            corn.Size = size;
            corn.CotijaCheese = cheese;
            corn.Cilantro = cilantro;
            Assert.Equal(expectedCalories, corn.Calories);

        }


        /// <summary>
        /// checks that preperation information is  generated properly
        /// </summary>
        /// <param name="size">the size property</param>
        /// <param name="cheese">the cotijaCheese property</param>
        /// <param name="cilantro">the cilantro property</param>
        /// <param name="info">the expected information</param>

        [Theory]
        [InlineData(Size.Kids, true, true, new string[] { "Kids" })]
        [InlineData(Size.Large, true, true, new string[] { "Large" })]
        [InlineData(Size.Small, true, true, new string[] { "Small" })]
        [InlineData(Size.Medium, true, true, new string[] { "Medium" })]
        //specific required test cases
        [InlineData(Size.Small, true, false, new string[]{"Small","Hold Cilantro"})]
        [InlineData(Size.Large, false, true,new string[] {"Large","Hold Cotija Cheese"})]

        public void PreperationInformationCorrect(Size size, bool cheese, bool cilantro, string[] info)
        {
            StreetCorn corn = new();
            corn.Size = size;
            corn.CotijaCheese = cheese;
            corn.Cilantro = cilantro;
           
            foreach (string str in info)
            {

                Assert.Contains(str, corn.PreparationInformation);
            }
            Assert.Equal(info.Length, corn.PreparationInformation.Count());


        }

    }
}
