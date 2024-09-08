
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// unit test class for testing the CarnitasBowl class
    /// </summary>

    public  class CarnitasBowlUnitTests
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
            CarnitasBowl f = new();
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
            CarnitasBowl bowl = new();

            bowl.Instructions.TryGetValue(item, out IngredientItem? value);
            Assert.PropertyChanged(bowl, propertyName, () => {
                value!.Included = include;
            });

        }

        /// <summary>
        /// carnitas bowl implements INotifyPropertyChanged interface
        /// </summary>
        [Fact]
        public void CarnitasBowlShouldImplementINotifyPropertyChanged()

        {
            CarnitasBowl f = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(f);
        }

        ///<summary>
        /// checks that tostring() method is implemented properly
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            CarnitasBowl meal = new();
            Assert.Equal("Carnitas Bowl", meal.ToString());
        }
        /// <summary>
        /// bowl object can  be cast to IMenuItem and base classes
        /// </summary>

        [Fact]
        public void CastTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();
            Assert.IsAssignableFrom<Entree>(bowl);
            Assert.IsAssignableFrom<Bowl>(bowl);
            Assert.IsAssignableFrom<IMenuItem>(bowl);
        }
        /// <summary>
        /// checks that carnitas property is initially set to true
        /// </summary>
        [Fact]
        public void CarnitasPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Carnitas, out IngredientItem? value);
            Assert.True(value!.Included);

        }
 
        /// <summary>
        /// checks that Veggies property is initially set to false
        /// </summary>
        [Fact]
        public void VeggiesPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out IngredientItem? value);
            Assert.False(value!.Included);

        }
        /// <summary>
        /// checks that queso property is initially set to true
        /// </summary>
        [Fact]
        public void QuesoPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Queso, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that pintoBeans property is initially set to true
        /// </summary>
        [Fact]

        public void PintoBeansPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();
            bowl.Instructions.TryGetValue(Ingredient.PintoBeans, out IngredientItem? value);
            Assert.True(value!.Included);

        }
        /// <summary>
        /// checks that the guacamole property is initially set to false
        /// </summary>
        [Fact]
        public void GuacamolePropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out IngredientItem? value);
            Assert.False(value!.Included);

        }

        /// <summary>
        /// checks that sourCream property is initially set to false
        /// </summary>
        [Fact]
        public void SourCreamPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out IngredientItem? value);
            
            Assert.False(value!.Included);

        }

        /// <summary>
        /// checks that salsa property is correctly initialized
        /// </summary>
        [Fact]
        public void SalsaPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();
    Assert.Equal(Salsa.Medium, bowl.SalsaChoice);

        }
        /// <summary>
        /// checks dfeault calories
        /// </summary>
        [Fact]
        public void CaroliesPropertyInitialTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();
            Assert.Equal(680u,bowl.Calories);
        }
        /// <summary>
        /// checks default price
        /// </summary>
        [Fact]
        public void PriceInitialisedTest()
        {
            CarnitasBowl bowl = new CarnitasBowl();
            Assert.Equal(9.99m, bowl.Price);
        }

        /// <summary>
        /// tests that calories are calculated correctly
        /// </summary>
        /// <param name="carnitas">the carnitas property</param>
        /// <param name="pintoBeans">the blackBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedCalories">the calories expected</param>
        [Theory]
        [InlineData(true, true, true, true, true,true, Salsa.Hot, 950)]
        [InlineData(true, false, false, true, false,true, Salsa.Green, 670)]
        [InlineData(false, false, false, false, false,false, Salsa.Green, 230)]
        [InlineData(false, false, true, true, false,true, Salsa.None, 460)]
        [InlineData(true, true, false, true, false, true, Salsa.Hot, 780)]
        //specific required test case
        [InlineData(false,false,true,true,true,false,Salsa.Medium,500)]

        public void CaloriesPropertyTest(bool carnitas, bool queso, bool veggies, bool sourCream, bool guacamole, bool pintoBeans, Salsa salsa, uint expectedCalories)
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Carnitas, out IngredientItem? value);
            value!.Included = carnitas;
            bowl.Instructions[Ingredient.Carnitas] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out  value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out  value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;
          
            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.PintoBeans, out  value);
            value!.Included = pintoBeans;
            bowl.Instructions[Ingredient.PintoBeans] = value;
            
          



            Assert.Equal(expectedCalories, bowl.Calories);
        }
      
        /// <summary>
        /// tests that preperation information is correct
        /// </summary>
        /// <param name="carnitas">the carnitas property</param>
        /// <param name="pintoBeans">the pintoBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        ///<param name="info">the expected preperation information</param>

        [Theory]

        [InlineData(true, true, true, true, true,  true, Salsa.Hot, new string[] { "Add Veggies","Add Guacamole","Add Sour Cream","Swap Hot Salsa" })]
        [InlineData(true, false, false, true, true, false, Salsa.Green, new string[] { "Hold Queso", "Add Guacamole","Swap Green Salsa" })]

        [InlineData(true, false, false, false, false, true, Salsa.Medium, new string[] { "Hold Pinto Beans", "Hold Queso", "Add Sour Cream" })]
        [InlineData(false, false, true, true, false, true, Salsa.None, new string[] { "Hold Carnitas",  "Add Sour Cream","Hold Salsa"})]
        [InlineData(false, false, false, false, false, true, Salsa.Medium, new string[] {"Hold Carnitas", "Hold Pinto Beans", "Hold Queso", "Add Sour Cream" })]


        [InlineData(true, true, false, true, false,false, Salsa.Mild, new string[] { "Add Veggies", "Hold Queso", "Swap Mild Salsa" })]

        // specific required test case
        [InlineData(false,true,false,false,true,true,Salsa.Medium,new string[] { "Add Veggies", "Hold Carnitas", "Hold Queso", "Hold Pinto Beans", "Add Guacamole", "Add Sour Cream" })]
        public void PreperationInformationTest(bool carnitas, bool veggies, bool queso, bool pintoBeans, bool guacamole, bool sourCream,  Salsa salsa, string[] info)
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Carnitas, out IngredientItem? value);
            value!.Included = carnitas;
            bowl.Instructions[Ingredient.Carnitas] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out  value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.PintoBeans, out value);
            value!.Included = pintoBeans;
            bowl.Instructions[Ingredient.PintoBeans] = value;

            bowl.SalsaChoice = salsa;
            
            foreach (string str in info)
            {
               
                Assert.Contains(str, bowl.PreparationInformation);
            }
            Assert.Equal(info.Length, bowl.PreparationInformation.Count());

        }

       
        
        /// <summary>
        /// tests that the prices are correct
        /// </summary>
        /// <param name="carnitas">the carnitas property</param>
        /// <param name="pintoBeans">the pintoBeans property</param>
        /// <param name="queso">the queso property</param>
        /// <param name="veggies">the veggies property</param>
        /// <param name="sourCream">the sourCream property</param>
        /// <param name="salsa">the salsa propery</param>
        /// <param name="guacamole">the guacamole property</param>
        /// <param name="expectedPrice">the expected price</param>
      
        [Theory]
        [InlineData(true, true, true, true, true, true, Salsa.Hot,10.99)]
        [InlineData(true, false, false, true, true, false, Salsa.Green, 10.99)]
        [InlineData(true, false, false, false, false, true, Salsa.Medium, 9.99 )]
        [InlineData(false, false, true, true, false, true, Salsa.None, 9.99)]
        // specific required test case
        [InlineData(false, true, false, false, true, true, Salsa.Mild, 10.99)]
        public void PricesTest(bool carnitas, bool veggies, bool queso, bool pintoBeans, bool guacamole, bool sourCream, Salsa salsa,decimal expectedPrice)
        {
            CarnitasBowl bowl = new CarnitasBowl();

            bowl.Instructions.TryGetValue(Ingredient.Carnitas, out IngredientItem? value);
            value!.Included = carnitas;
            bowl.Instructions[Ingredient.Carnitas] = value;


            bowl.Instructions.TryGetValue(Ingredient.Queso, out value);
            value!.Included = queso;
            bowl.Instructions[Ingredient.Queso] = value;

            bowl.Instructions.TryGetValue(Ingredient.Veggies, out value);
            value!.Included = veggies;
            bowl.Instructions[Ingredient.Veggies] = value;

            bowl.Instructions.TryGetValue(Ingredient.SourCream, out value);
            value!.Included = sourCream;
            bowl.Instructions[Ingredient.SourCream] = value;

            bowl.SalsaChoice = salsa;

            bowl.Instructions.TryGetValue(Ingredient.Guacamole, out  value);
            value!.Included = guacamole;
            bowl.Instructions[Ingredient.Guacamole] = value;

            bowl.Instructions.TryGetValue(Ingredient.PintoBeans, out value);
            value!.Included = pintoBeans;
            bowl.Instructions[Ingredient.PintoBeans] = value;


            bowl.SalsaChoice = salsa;
          

           
            Assert.Equal(expectedPrice,bowl.Price);
        }





    }
}
