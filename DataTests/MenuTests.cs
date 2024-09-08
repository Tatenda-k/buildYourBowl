using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// class for testing the menu class
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// ensures that count of items of sides property is correct
        /// </summary>
        [Fact]
        public void CountOfSidesTest()
        {
            Assert.Equal(4 * (2 + 2 * 2 + 2 * 2), Menu.Sides.Count());
        }
        /// <summary>
        /// ensures that count of items of drinks property is correct
        /// </summary>
        [Fact]
        public void CountOfDrinksTest()
        {
            Assert.Equal(2 + 4 * (1+5), Menu.Drinks.Count());
        }
        /// <summary>
        /// ensures that count of items of ingredients property is correct
        /// </summary>
         [Fact]
        public void CountOfIngredient()
        {
            Assert.Equal(9, Menu.Ingredients.Count());
        }
        /// <summary>
        /// ensures that count of items of ingredients property is correct
        /// </summary>
        [Fact]
        public void CountOfSalsa()
        {
            Assert.Equal(5, Menu.Salsas.Count());
        }
        /// <summary>
        /// ensures that count of items of entrees property is correct
        /// </summary>
        [Fact]
        public void CountOfEntree()
        {
            Assert.Equal(7, Menu.Entrees.Count());
        }

        /// <summary>
        /// ensures that count of items of kidsmeal property is correct
        /// </summary>
        [Fact]
        public void CountOfKidsMeal()
        {
            Assert.Equal(2*(3 * 3) + (3 * 6), Menu.KidsMeals.Count());
        }

        /// <summary>
        /// ensures that count of items of fullmenu property is correct
        /// </summary>
        [Fact]
        public void CountOfFullMenu()
        {
            Assert.Equal(Menu.Entrees.Count() + Menu.Sides.Count() + Menu.Drinks.Count() + Menu.KidsMeals.Count(), Menu.FullMenu.Count());
        }
        /// <summary>
        /// ensures that all unique combinations exist in the category
        /// </summary>

        [Fact]
    public void UniqueCombinationExistsEntreeTest()
        {
            Assert.Contains(Menu.Entrees, item => item is GreenChickenBowl G );
            Assert.Contains(Menu.Entrees, item => item is CarnitasBowl C);
            Assert.Contains(Menu.Entrees, item => item is ChickenFajitaNachos C);
            Assert.Contains(Menu.Entrees, item => item is ClassicNachos C);
            Assert.Contains(Menu.Entrees, item => item is SpicySteakBowl B);
            Assert.Contains(Menu.Entrees, item => item is Bowl  && item is not GreenChickenBowl && item is not CarnitasBowl && item is not ChickenFajitaNachos && item is not ClassicNachos && item is not SpicySteakBowl);
            Assert.Contains(Menu.Entrees, item => item is Nachos && item is not GreenChickenBowl && item is not CarnitasBowl && item is not ChickenFajitaNachos && item is not ClassicNachos && item is not SpicySteakBowl);
        
        }

        /// <summary>
        /// ensures that all unique combinations exist in the ingredients property
        /// </summary>
        [Fact]

        public void UniqueCombinationsExistIngredientsTest()
        {
          
            foreach(Ingredient ingr in Enum.GetValues(typeof(Ingredient)))
            {
                if (!(ingr==Ingredient.Rice || ingr == Ingredient.Chips)){
                    IngredientItem i = new IngredientItem(ingr);
                    Assert.Contains(Menu.Ingredients, item => item.Equals(i));
                }
            }
        }
        /// <summary>
        /// ensures that all unique combinations exist in the Salsas property
        /// </summary>
        [Fact]
        public void UniqueCombinationsExistDrinksSalsasTest()
        {

            foreach (Salsa salsa in Enum.GetValues(typeof(Salsa)))
            {
                Salsa expected = salsa;
                    
                    Assert.Contains(Menu.Salsas, item=>item.Equals(expected));
            }


        }

        /// <summary>
        /// ensures that all unique combinations exist in the sides property
        /// </summary>
        [Fact]
        public void UniqueCombinationsExistSidesTest()
        {
            foreach(Size size in Enum.GetValues(typeof(Size)))
            {
                Assert.Contains(Menu.Sides, item => item is Fries f && f.Curly && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is Fries f && f.Curly==false && f.Size == size);

                Assert.Contains(Menu.Sides, item => item is RefriedBeans f && f.Onions  && f.CheddarCheese==false && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans f && f.Onions==false && f.CheddarCheese && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans f && f.Onions == false && f.CheddarCheese==false && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is RefriedBeans f && f.Onions && f.CheddarCheese==false && f.Size == size);

                Assert.Contains(Menu.Sides, item => item is StreetCorn f && f.CotijaCheese == false & f.Cilantro && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn f && f.CotijaCheese == false & f.Cilantro==false && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn f &&  f.Cilantro==false && f.CotijaCheese && f.Size == size);
                Assert.Contains(Menu.Sides, item => item is StreetCorn f && f.CotijaCheese && f.Cilantro && f.Size == size);

            }
        }
        /// <summary>
        /// ensures that all unique combinations exist in the drinks property
        /// </summary>
        [Fact]
        public void UniqueCombinationExistDrinksTest()
        {
            //separate case for milk

            Assert.Contains(Menu.Drinks, item => item is Milk);
            Assert.Contains(Menu.Drinks, item => item is Milk m && m.Chocolate==false);

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                Assert.Contains(Menu.Drinks, item => item is Horchata d && d.Size == size);

                Assert.Contains(Menu.Drinks, item => item is AguaFresca d && d.Flavor==Flavor.Tamarind && d.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca d && d.Flavor == Flavor.Strawberry && d.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca d && d.Flavor == Flavor.Limonada && d.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca d && d.Flavor == Flavor.Lime && d.Size == size);
                Assert.Contains(Menu.Drinks, item => item is AguaFresca d && d.Flavor == Flavor.Cucumber && d.Size == size);



            }


        }


        /// <summary>
        /// ensures that all unique combinations exist in the kidsmeals property
        /// </summary>
        [Fact]
        public void UniqueCombinationExistKidsMealsTest()
        {
            List<Side> sides = new()
            {
              new Fries() {Size=Size.Kids } as Side,
              new RefriedBeans() {Size=Size.Kids } as Side,
              new StreetCorn() {Size=Size.Kids } as Side
            };
            List<Drink> drinks = new()
           {
                new Horchata() {Size=Size.Kids } as Drink,
               new Milk()  {Size=Size.Kids } as Drink,
               new AguaFresca()  {Size=Size.Kids } as Drink
           };

            //Assert.Contains(Menu.KidsMeals, item => item is ChickenNuggetsMeal m && m.SideChoice.Equals(new Fries() { Size = Size.Kids }) && m.DrinkChoice.Equals(new Fries() { Size = Size.Kids }));

            int i = 0;
            foreach (Drink drink in drinks)
            {
                foreach (Side side in sides)
                {

                    Assert.Contains(Menu.KidsMeals, item => item is ChickenNuggetsMeal m && m.SideChoice.Equals(side) && m.DrinkChoice.Equals(drink));
                    Assert.Contains(Menu.KidsMeals, item => item is CornDogBitesMeal m && m.SideChoice.Equals(side) && m.DrinkChoice.Equals(drink));
                    Assert.Contains(Menu.KidsMeals, item => item is SlidersMeal m && m.SideChoice.Equals(side) && m.DrinkChoice.Equals(drink));
                    Assert.Contains(Menu.KidsMeals, item => item is SlidersMeal m && m.SideChoice.Equals(side) && m.DrinkChoice.Equals(drink) && m.AmericanCheese);
                    Assert.Contains(Menu.KidsMeals, item => item is SlidersMeal m && m.SideChoice.Equals(side) && m.DrinkChoice.Equals(drink) && m.AmericanCheese==false);
                    i += 1;
                    //MessageBox.Show(i.ToString());

                }
            }




        }

        

       

    }
}
