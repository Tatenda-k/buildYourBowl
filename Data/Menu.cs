using BuildYourBowl.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// a static class representing configurations of menu items
    /// </summary>
    public static class Menu
    {

        /// <summary>
        /// private backing field for Entrees
        /// </summary>
        private static List<IMenuItem> entrees=new();

        /// <summary>
        /// private backing field for kidsmeals
        /// </summary>
        private static List<IMenuItem> kidsmeals = new();
        /// <summary>
        /// private backing field for drinks
        /// </summary>
        private static List<IMenuItem> drinks=new();

        /// <summary>
        /// private backing field for sides
        /// </summary>
        private static List<IMenuItem> sides=new();
        /// <summary>
        /// 
        /// </summary>


        static Menu()
        {
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new ChickenNuggetsMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });


            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new CornDogBitesMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });


            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new Fries() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new SlidersMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new RefriedBeans() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            kidsmeals.Add(new SlidersMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Horchata() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new AguaFresca() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });
            kidsmeals.Add(new SlidersMeal() { AmericanCheese = false, SideChoice = new StreetCorn() { Size = Size.Kids }, DrinkChoice = new Milk() { Size = Size.Kids } });

            sides.Add(new Fries());
            sides.Add(new Fries() { Curly = true });

            sides.Add(new Fries() { Size = Size.Kids });
            sides.Add(new Fries() { Size = Size.Kids, Curly = true });
            sides.Add(new Fries() { Size = Size.Large });
            sides.Add(new Fries() { Size = Size.Large, Curly = true });
            sides.Add(new Fries() { Size = Size.Small, Curly = true });
            sides.Add(new Fries() { Size = Size.Small });

            sides.Add(new RefriedBeans());
            sides.Add(new RefriedBeans() { CheddarCheese = false });
            sides.Add(new RefriedBeans() { Onions = false });
            sides.Add(new RefriedBeans() { Onions = false, CheddarCheese = false });

            sides.Add(new RefriedBeans() { Size = Size.Kids });
            sides.Add(new RefriedBeans() { Size = Size.Kids, CheddarCheese = false });
            sides.Add(new RefriedBeans() { Size = Size.Kids, Onions = false });
            sides.Add(new RefriedBeans() { Size = Size.Kids, Onions = false, CheddarCheese = false });

            sides.Add(new RefriedBeans() { Size = Size.Large });
            sides.Add(new RefriedBeans() { Size = Size.Large, CheddarCheese = false });
            sides.Add(new RefriedBeans() { Size = Size.Large, Onions = false });
            sides.Add(new RefriedBeans() { Size = Size.Large, Onions = false, CheddarCheese = false });


            sides.Add(new RefriedBeans() { Size = Size.Small });
            sides.Add(new RefriedBeans() { Size = Size.Small, CheddarCheese = false });
            sides.Add(new RefriedBeans() { Size = Size.Small, Onions = false });
            sides.Add(new RefriedBeans() { Size = Size.Small, Onions = false, CheddarCheese = false });

            sides.Add(new StreetCorn());
            sides.Add(new StreetCorn() { Cilantro = false, CotijaCheese = false });
            sides.Add(new StreetCorn() { CotijaCheese = false });
            sides.Add(new StreetCorn() { Cilantro = false });


            sides.Add(new StreetCorn() { Size = Size.Kids });
            sides.Add(new StreetCorn() { Size = Size.Kids, Cilantro = false, CotijaCheese = false });
            sides.Add(new StreetCorn() { Size = Size.Kids, Cilantro = false });
            sides.Add(new StreetCorn() { Size = Size.Kids, CotijaCheese = false });

            sides.Add(new StreetCorn() { Size = Size.Large });
            sides.Add(new StreetCorn() { Size = Size.Large, Cilantro = false, CotijaCheese = false });
            sides.Add(new StreetCorn() { Size = Size.Large, Cilantro = false });
            sides.Add(new StreetCorn() { Size = Size.Large, CotijaCheese = false });

            sides.Add(new StreetCorn() { Size = Size.Small });
            sides.Add(new StreetCorn() { Size = Size.Small, Cilantro = false, CotijaCheese = false });
            sides.Add(new StreetCorn() { Size = Size.Small, Cilantro = false });
            sides.Add(new StreetCorn() { Size = Size.Small, CotijaCheese = false });

            drinks.Add(new Milk());
            drinks.Add(new Milk() { Chocolate = true }); ;

            drinks.Add(new Horchata());
            drinks.Add(new Horchata() { Size = Size.Kids });
            drinks.Add(new Horchata() { Size = Size.Large });
            drinks.Add(new Horchata() { Size = Size.Small });

            drinks.Add(new AguaFresca() { Flavor = Flavor.Tamarind });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Tamarind, Size = Size.Kids });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Tamarind, Size = Size.Large });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Tamarind, Size = Size.Small });


            drinks.Add(new AguaFresca() { Flavor = Flavor.Cucumber });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Cucumber, Size = Size.Kids });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Cucumber, Size = Size.Small });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Cucumber, Size = Size.Large });



            drinks.Add(new AguaFresca() { Flavor = Flavor.Limonada });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Limonada, Size = Size.Kids });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Limonada, Size = Size.Small });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Limonada, Size = Size.Large });


            drinks.Add(new AguaFresca() { Flavor = Flavor.Lime });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Lime, Size = Size.Kids });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Lime, Size = Size.Small });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Lime, Size = Size.Large });

            drinks.Add(new AguaFresca() { Flavor = Flavor.Strawberry });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Strawberry, Size = Size.Kids });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Strawberry, Size = Size.Large });
            drinks.Add(new AguaFresca() { Flavor = Flavor.Strawberry, Size = Size.Small });

            entrees.Add(new CarnitasBowl());
            entrees.Add(new ClassicNachos());
            entrees.Add(new GreenChickenBowl());
            entrees.Add(new ChickenFajitaNachos());
            entrees.Add(new SpicySteakBowl());
            entrees.Add(new Bowl());
            entrees.Add(new Nachos());


        }
        /// <summary>
        /// filters salsas by the string passed in 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static IEnumerable<Salsa> Search(string search, IEnumerable<Salsa> menu)
        {
            if (search == null) return menu;
            string[] searches = search.Split(",");
            List<Salsa> items = new();
            bool seen = true;
            if (search == null) return menu;
            foreach(Salsa salsa in menu)
            {
                seen = true;
                foreach (string check in searches)
                {
                    if (!(salsa.ToString().Contains(check, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        seen = false;
                        break;
                    }
                 }
                if (seen == true) items.Add(salsa);
            }
            return items;
        }
        /// <summary>
        /// filters Full Menu by the search parameter based on the name and preparation information properties
        /// </summary>
        /// <param name="search">the searching filter</param>
        /// <param name="menu">the enumerable to filter</param>
        /// <returns>the filtered results</returns>
        public static IEnumerable<IMenuItem> Search(string search,IEnumerable<IMenuItem>menu )
        {
            //make sure that for
            if (search == null) return menu;
            bool seen = false;
            string[] searches = search.Split(" ");
            List<IMenuItem> items = new();
            bool found = true;
            
            foreach (IMenuItem item in menu)
            {
                
                

                foreach (string check in searches)
                {
                    found = true;
                    seen = false;

                    foreach (string prep in item.PreparationInformation)
                    {
                        if (prep.Contains(check, StringComparison.CurrentCultureIgnoreCase))
                        {
                            seen = true;
                            break;
                        }
                    }
                        if(item is Entree)
                        {
                            Entree? entree = item as Entree;
                            foreach(KeyValuePair<Ingredient,IngredientItem> entry in entree!.Instructions)
                            {
                                if(entry.Value.Included==true && entry.Value.Name.Contains(check, StringComparison.CurrentCultureIgnoreCase)){
                                    seen = true;
                                }
                            }

                        }
                    
                    if (!(item.Name.Contains(check, StringComparison.CurrentCultureIgnoreCase)) && seen == false)
                    {
                        found = false;
                        break;
                    }
                }
                if(found==true) items.Add(item);
            }
            return items;
        }
        /// <summary>
        /// filters the menu parameter by the min and max parameters representing calories
        /// </summary>
        /// <param name="menu">the items to be filtered</param>
        /// <param name="min">the minimum bound for filtering</param>
        /// <param name="max">the maximum bound for filters</param>
        /// <returns>IMenuItems filtered by calores between min and max</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem>menu,uint? min, uint? max)
        {
            if (min == null && max == null) return menu;
            var results = new List<IMenuItem>();

            // only a maximum specified
            if (min == null)
            {
  
                return from item in menu where item.Calories <= max select item;

            }
          
            if (max == null)
            {
                
                return from item in menu where item.Calories >= min select item;

            }
            // Both minimum and maximum specified

            return from item in menu where item.Calories <= max && item.Calories >= min select item;
        }
              
/// <summary>
/// filters the menu parameter by the min and max parameters representing calories
/// </summary>
/// <param name="menu">the items to be filtered</param>
/// <param name="min">the minimum bound for filtering</param>
/// <param name="max">the maximum bound for filters</param>
/// <returns>IMenuItems filtered by calores between min and max</returns>
public static IEnumerable<Salsa> FilterByCalories(IEnumerable<Salsa> menu, uint? min, uint? max)
        {
            if (min == null && max == null) return menu;
            var results = new List<IMenuItem>();

            // only a maximum specified
            if (min == null)
            {

                return from item in menu where 20 <= max select item;

            }

            if (max == null)
            {

                return from item in menu where 20 >= min select item;

            }
            // Both minimum and maximum specified

            return from item in menu where 20 <= max && 20 >= min select item;


        }
        ///<summary>
        /// filters the menu parameter by the min and max parameters representing price
        /// </summary>
        /// <param name="menu">the items to be filtered</param>
        /// <param name="min">the minimum bound for filtering</param>
        /// <param name="max">the maximum bound for filters</param>
        /// <returns>IMenuItems filtered by price between min and max</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> menu, decimal? min, decimal? max)
        {
            if (min == null && max == null) return menu;
            var results = new List<IMenuItem>();

            // only a maximum specified
            if (min == null)
            {
                return from item in menu where item.Price <= max select item;

            }

            if (max == null)
            {

                return from item in menu where item.Price >= min select item;

            }
            // Both minimum and maximum specified

            return from item in menu where item.Price <= max && item.Price >= min select item;
        }



        /// <summary>
        /// all ingredients that could be added to a bowl or nachos order
        /// </summary>
        public static IEnumerable<IngredientItem> Ingredients
        {
            get
            {
                List<IngredientItem> ingredients = new();
                ingredients.Add(new IngredientItem(Ingredient.PintoBeans));
                ingredients.Add(new IngredientItem(Ingredient.BlackBeans));
                ingredients.Add(new IngredientItem(Ingredient.Queso));
                ingredients.Add(new IngredientItem(Ingredient.Veggies));
                ingredients.Add(new IngredientItem(Ingredient.SourCream));
                ingredients.Add(new IngredientItem(Ingredient.Guacamole));
                ingredients.Add(new IngredientItem(Ingredient.Chicken));
                ingredients.Add(new IngredientItem(Ingredient.Steak));
                ingredients.Add(new IngredientItem(Ingredient.Carnitas));
               
                return ingredients;
            }
        }
        /// <summary>
        /// all configurations of salsa
        /// </summary>
        public static IEnumerable<Salsa> Salsas
        {
            get
            {
                List<Salsa> salsas = new();
                salsas.Add(Salsa.Medium);
                salsas.Add(Salsa.None);
                salsas.Add(Salsa.Hot);
                salsas.Add(Salsa.Mild);
                salsas.Add(Salsa.Green);
                return salsas;
            }
        }
        /// <summary>
        /// all of the menu items
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> menu = new();

                menu.AddRange(KidsMeals);
                menu.AddRange(Sides);
                menu.AddRange(Drinks);
                menu.AddRange(Entrees);
                return menu;
            }
        }

        /// <summary>
        /// all instances of available kids meals
        /// </summary>
        public static IEnumerable<IMenuItem> KidsMeals
        {
            get
            {
                //List<IMenuItem> kidsmeals = new();




                return kidsmeals;
            }
        }
        /// <summary>
        /// all instances of available drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                //List<IMenuItem> drinks = new();

 

                return drinks;

            }
        }

        /// <summary>
        /// all available entrees
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees
        {
            get
            {
              //  List<IMenuItem> entrees = new();



                return entrees;          

            }
        }
        /// <summary>
        /// all instances of available sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
               // List<IMenuItem> sides = new();

                return sides;

            }
        }

    }
}
