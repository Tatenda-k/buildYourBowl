
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// class for testing the Bowl class
    /// </summary>
    public class BowlTests
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
            Bowl f = new();
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
        [InlineData(Ingredient.Carnitas, true, "Calories")]
        [InlineData(Ingredient.Veggies, true, "Calories")]
        [InlineData(Ingredient.Queso, false, "Calories")]
        [InlineData(Ingredient.Guacamole, true, "Calories")]
        [InlineData(Ingredient.PintoBeans, false, "PreparationInformation")]
        [InlineData(Ingredient.Veggies, false, "PreparationInformation")]
        [InlineData(Ingredient.SourCream, true, "PreparationInformation")]
        [InlineData(Ingredient.Guacamole, false, "PreparationInformation")]
        [InlineData(Ingredient.Carnitas, true, "Price")]
        [InlineData(Ingredient.Queso, true, "Price")]
        public void ChangingIncludedOfIngredientItemShouldNotifyOfPropertyChanges(Ingredient item, bool include, string propertyName)
        {
            Bowl bowl = new();

            bowl.Instructions.TryGetValue(item, out IngredientItem? value);
            Assert.PropertyChanged(bowl, propertyName, () => {
                value!.Included = include;
            });

        }

        /// <summary>
        ///  bowl implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void BowlShouldImplementINotifyPropertyChanged()

        {
            Bowl f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }
        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Bowl bowl = new();
            Assert.Equal("Build-Your-Own-Bowl",bowl.ToString());
        }

        /// <summary>
        /// bowl object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            Bowl bowl= new();
            Assert.IsAssignableFrom<Entree>(bowl);
            Assert.IsAssignableFrom<IMenuItem>(bowl);
        }
        /// <summary>
        /// price is calculated properly
        /// </summary>
        /// <param name="blackBeans">whether the black beans ingredient item is included</param>
        /// <param name="pintoBeans">whether the pinto beans ingredient item is included</param>
        /// <param name="queso">whether the queso ingredient item is included</param>
        /// <param name="veggies">whether the veggies ingredient item is included</param>
        /// <param name="sourCream">whether the sour cream ingredient item is included</param>
        /// <param name="guacamole">whether the guacamole ingredient item is included</param>
        /// <param name="chicken">whether the chicken ingredient item is included </param>
        /// <param name="steak">whether the steak ingredient item is included</param>
        /// <param name="carnitas">whether the black beans ingredient item is included</param>
        /// <param name="price">the expected price</param>
        /// <param name="salsa">the salsa choice</param>
        [Theory]
        [InlineData(Salsa.Medium,true,true,true,true,true,true,true,true,true,17.99)]
        [InlineData(Salsa.Hot,false,false,false,false,false,false,false,false,false,7.99)]
        [InlineData(Salsa.Green,true, false,true,true, false, false,false,true,true,2+4+7.99)]
        [InlineData(Salsa.Mild,false,false,false,false,true,true,true,true,true,2*3+1+7.99)]
        [InlineData(Salsa.None,true,true,true,true,true,true,false,false,false,4+7.99)]
        public void PriceReflectsBaseAndToppings(Salsa salsa,bool blackBeans,bool pintoBeans,bool queso,bool veggies,bool sourCream,bool guacamole,bool chicken, bool steak, bool carnitas,decimal price)
        {
            Bowl bowl = new Bowl();
            bowl.SalsaChoice = salsa;
            bowl.Instructions[Ingredient.Chicken].Included = chicken;
            bowl.Instructions[Ingredient.Guacamole].Included = guacamole;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.BlackBeans].Included = blackBeans;
            bowl.Instructions[Ingredient.PintoBeans].Included = pintoBeans;
            bowl.Instructions[Ingredient.Veggies].Included = veggies;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.Queso].Included = queso;
            bowl.Instructions[Ingredient.Steak].Included = steak;
            bowl.Instructions[Ingredient.Carnitas].Included = carnitas;
            Assert.Equal(price, bowl.Price);

        }
        /// <summary>
        /// price is calculated properly
        /// </summary>
        /// <param name="blackBeans">whether the black beans ingredient item is included</param>
        /// <param name="pintoBeans">whether the pinto beans ingredient item is included</param>
        /// <param name="queso">whether the queso ingredient item is included</param>
        /// <param name="veggies">whether the veggies ingredient item is included</param>
        /// <param name="sourCream">whether the sour cream ingredient item is included</param>
        /// <param name="guacamole">whether the guacamole ingredient item is included</param>
        /// <param name="chicken">whether the chicken ingredient item is included </param>
        /// <param name="steak">whether the steak ingredient item is included</param>
        /// <param name="carnitas">whether the black beans ingredient item is included</param>
        /// <param name="expectedCalories">the expected calories</param>
        /// <param name="salsa">the salsa choice</param>

        [Theory]
        [InlineData(Salsa.None,true, true, true, true, true, true, true, true, true, 2*130+110+20+100+2*150+180+210+210)]
        [InlineData(Salsa.Hot,false, false, false, false, false, false, false, false, false, 210+20)]
        [InlineData(Salsa.Medium,true, false, true, true, false, false, false, true, true, 130+110+20+210+180+20+210)]
        [InlineData(Salsa.Mild,false, false, false, false, true, true, true, true, true,150+100+210+180+150+20+210 )]
        [InlineData(Salsa.Green,true, true, true, true, true, true, false, false, false, 2 * 130 + 110 + 20 + 100 +  150+20+210)]
        public void CaloriesReflectsBaseAndToppings(Salsa salsa,bool blackBeans, bool pintoBeans, bool queso, bool veggies, bool sourCream, bool guacamole, bool chicken, bool steak, bool carnitas, uint expectedCalories)
        {
            Bowl bowl = new Bowl();
            bowl.SalsaChoice = salsa;
            bowl.Instructions[Ingredient.Chicken].Included = chicken;
            bowl.Instructions[Ingredient.Guacamole].Included = guacamole;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.BlackBeans].Included = blackBeans;
            bowl.Instructions[Ingredient.PintoBeans].Included = pintoBeans;
            bowl.Instructions[Ingredient.Veggies].Included = veggies;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.Queso].Included = queso;
            bowl.Instructions[Ingredient.Steak].Included = steak;
            bowl.Instructions[Ingredient.Carnitas].Included = carnitas;
            Assert.Equal(expectedCalories, bowl.Calories);

        }


        /// <summary>
        /// price is calculated properly
        /// </summary>
        /// <param name="blackBeans">whether the black beans ingredient item is included</param>
        /// <param name="pintoBeans">whether the pinto beans ingredient item is included</param>
        /// <param name="queso">whether the queso ingredient item is included</param>
        /// <param name="veggies">whether the veggies ingredient item is included</param>
        /// <param name="sourCream">whether the sour cream ingredient item is included</param>
        /// <param name="guacamole">whether the guacamole ingredient item is included</param>
        /// <param name="chicken">whether the chicken ingredient item is included </param>
        /// <param name="steak">whether the steak ingredient item is included</param>
        /// <param name="carnitas">whether the black beans ingredient item is included</param>
        /// <param name="info">the expected perperation information</param>
        /// <param name="salsa">the salsa choice</param>

        [Theory]
        [InlineData(Salsa.None, true, true, true, true, true, true, true, true, true,new string[] {"Hold Salsa", "Add Pinto Beans", "Add Black Beans", "Add Queso", "Add Veggies", "Add Sour Cream", "Add Guacamole", "Add Chicken", "Add Steak", "Add Carnitas" })]
        [InlineData(Salsa.Hot, false, false, false, false, false, false, false, false, false, new string[] {"Swap Hot Salsa"})]
        [InlineData(Salsa.Medium, true, false, true, true, false, false, false, true, true, new string[] {"Add Black Beans","Add Queso","Add Veggies","Add Carnitas","Add Steak"})]
        [InlineData(Salsa.Mild, false, false, false, false, true, true, true, true, true,new string[] {"Swap Mild Salsa","Add Sour Cream", "Add Guacamole","Add Chicken","Add Steak","Add Carnitas"} )]
        [InlineData(Salsa.Green, true, true, true, true, true, true, false, false, false,new string[] { "Swap Green Salsa","Add Pinto Beans","Add Black Beans", "Add Queso", "Add Veggies", "Add Sour Cream", "Add Guacamole" } )]
        public void PreperationInstructionsReflectsBaseAndToppings(Salsa salsa, bool blackBeans, bool pintoBeans, bool queso, bool veggies, bool sourCream, bool guacamole, bool chicken, bool steak, bool carnitas, string[] info)
        {
            Bowl bowl = new Bowl();
            bowl.SalsaChoice = salsa;
            bowl.Instructions[Ingredient.Chicken].Included = chicken;
            bowl.Instructions[Ingredient.Guacamole].Included = guacamole;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.BlackBeans].Included = blackBeans;
            bowl.Instructions[Ingredient.PintoBeans].Included = pintoBeans;
            bowl.Instructions[Ingredient.Veggies].Included = veggies;
            bowl.Instructions[Ingredient.SourCream].Included = sourCream;
            bowl.Instructions[Ingredient.Queso].Included = queso;
            bowl.Instructions[Ingredient.Steak].Included = steak;
            bowl.Instructions[Ingredient.Carnitas].Included = carnitas;

            foreach (string str in info)
            {
                Assert.Contains(str, bowl.PreparationInformation);
            }

            Assert.Equal(info.Length, bowl.PreparationInformation.Count());

        }
        /// <summary>
        /// the salsa choice is initially set to medium
        /// </summary>
        [Fact]
        public void SalsaChoiceDefaultIsMediumSalsa()
        {
            Bowl bowl = new Bowl();
            Assert.Equal(Salsa.Medium, bowl.SalsaChoice);
        }
        /// <summary>
        /// tests that the base is set to rice
        /// </summary>
        [Fact]
        public void BaseSetToRice()
        {
            Bowl bowl = new();
            Assert.Equal(Ingredient.Rice.ToString(), bowl.Base.IngredientType.ToString());
        }
        /// <summary>
        /// tests that the bowl is an entree, and implements IMenuItem
        /// </summary>
        [Fact]
        public void BowlImplementsIMenuAndIsEntree()
        {
            Bowl bowl = new();
            Assert.IsAssignableFrom<Entree>(bowl);
            Assert.IsAssignableFrom<IMenuItem>(bowl);
        }




    }
}
