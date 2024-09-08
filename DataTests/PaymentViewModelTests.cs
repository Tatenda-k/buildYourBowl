using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;

namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// tests for the PaymentViewModel class
    /// </summary>
    public class PaymentViewModelTests
    {
        [Fact]
        public void IntegrationTest()
        {
            Order order = new();

            Assert.Equal(0, order.Number);
            SlidersMeal meal = new();
            meal.ItemCount = 3;
            meal.AmericanCheese = false;
            RefriedBeans beans= new RefriedBeans();
            beans.Onions = false;
            
            meal.SideChoice = beans;
            meal.SideChoice.Size = Size.Medium;
            AguaFresca drink = new();
            drink.Flavor = Flavor.Tamarind;
            drink.Size = Size.Large;
            meal.DrinkChoice = drink;
            Assert.Equal(5.99m + 2 + 1 + 1.5m, meal.Price);
            order.Add(meal);

            Bowl bowl = new();
            bowl.Instructions[Ingredient.Steak].Included = true;
            bowl.Instructions[Ingredient.Queso].Included = true;
            bowl.Instructions[Ingredient.SourCream].Included = true;
            Assert.Equal(7.99m + 2 + 1, bowl.Price);

            ChickenFajitaNachos nachos = new();
            nachos.Instructions[Ingredient.Guacamole].Included = true;
            nachos.Instructions[Ingredient.SourCream].Included = false;
            nachos.SalsaChoice = Salsa.None;
            Assert.Equal(10.99m + 1, nachos.Price);

            order.Add(bowl);
            order.Add(nachos);

            Assert.Equal(33.47m, order.Subtotal);
            Assert.Equal(3.06m, Math.Round(order.Tax,2));
            Assert.Equal(36.53m, Math.Round(order.Total,2));


            PaymentViewModel model = new(order);
            model.Paid = 40;
            Assert.Equal(3.47m, Math.Round(model.Change,2));

            order = new();
            Assert.Equal(1, order.Number);

            StreetCorn corn = new();
            corn.Size = Size.Large;
            corn.Cilantro = false;
            Assert.Equal(5.5m, Math.Round(corn.Price,2));

            AguaFresca agua = new();
            agua.Flavor = Flavor.Tamarind;
            agua.Size = Size.Kids;
            Assert.Equal(2.5m, Math.Round( agua.Price,2));

            Nachos nacho = new();
            nacho.Instructions[Ingredient.BlackBeans].Included = true;
            nacho.Instructions[Ingredient.PintoBeans].Included = true;
            nacho.Instructions[Ingredient.Veggies].Included = true;
            nacho.SalsaChoice = Salsa.Green;
            Assert.Equal(7.99m + 1 + 1, nacho.Price);

            order.Add(corn);
            order.Add(agua);
            order.Add(nacho);

            Assert.Equal(17.99m, Math.Round(order.Subtotal,2));
            Assert.Equal(1.65m, Math.Round(order.Tax,2));
            Assert.Equal(19.64m, Math.Round(order.Total,2));

            model = new(order);
            Assert.Throws<ArgumentException>(() => model.Paid = 15);
           // model.Paid = 15;
            //Assert.Equal(3.47m, model.Change);


        }
    }
}
