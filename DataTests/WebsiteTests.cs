using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data.Tests.Website
{
    /// <summary>
    /// class for testing 
    /// </summary>
    public class WebsiteTests
    {
        
        /// <summary>
        /// tests that the price filter works properly
        /// </summary>
        /// <param name="max">the maximum bound</param>
        /// <param name="min">the minimum bound</param>
        [Theory]
        [InlineData(0,0)]
        [InlineData(0, 10)]
        [InlineData(5, 0)]
        [InlineData(7, 5)]
        [InlineData(3,9)]

        public void PriceFilterTest(decimal min, decimal max)
        {


            IEnumerable<IMenuItem> result = Menu.FilterByPrice(Menu.FullMenu, min, max);
            foreach (IMenuItem item in result)
            {
                Assert.True(item.Price >= min && item.Price <= max);
            }
            foreach (IMenuItem item in Menu.FullMenu)
            {

                   if((item.Price >= min && item.Price <= max))
                {
                    Assert.Contains(item,result);
                }
            }

            


        }

        /// <summary>
        /// tests that the calories filter works properly
        /// </summary>
        /// <param name="min">the minimum bound</param>
        /// <param name="max">the maximum bound</param>
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, 400)]
        [InlineData(500, null)]
        [InlineData(1000, 600)]
        [InlineData(300, 1200)]

        public void CaloriesFilterTest(uint min, uint max)
        {

            

            IEnumerable<IMenuItem> result = Menu.FilterByCalories(Menu.FullMenu, min, max);
            foreach (IMenuItem item in result)
            {
                Assert.True(item.Calories >= min && item.Calories <= max);
            }
            foreach (IMenuItem item in result)
            {
                Assert.Contains(item, result);

            }


        }


        /// <summary>
        /// tests that the searchfilter works properly
        /// </summary>
        [Fact]
        public void WordFilterSearchTest()
        {
        List<IMenuItem> expected = new List<IMenuItem>();

        AguaFresca dr = new AguaFresca();
        expected.Add(dr);
        Fries fries = new Fries();
        expected.Add(fries);
        GreenChickenBowl bowl = new GreenChickenBowl();
        expected.Add(bowl);
        ChickenFajitaNachos nachos = new ChickenFajitaNachos();
        expected.Add(nachos);


        IEnumerable<IMenuItem> result = Menu.Search("fr",expected );

        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.Equals(fries));
        Assert.Contains(result, x => x.Equals(dr));

        Assert.DoesNotContain(result, x => x.Equals(bowl));
        Assert.DoesNotContain(result, x => x.Equals(nachos));


         expected.Clear();
        Horchata h = new ();
        expected.Add(h);
        RefriedBeans beans = new();
        expected.Add(beans);
        ClassicNachos b = new ();
        expected.Add(b);
        SlidersMeal n = new();
        expected.Add(n);

        result = Menu.Search("sliders fries", expected);

            Assert.Single(result);
            Assert.Contains(result, x => x.Equals(n));
            

            Assert.DoesNotContain(result, x => x.Equals(beans));
            Assert.DoesNotContain(result, x => x.Equals(h));
          
            Assert.DoesNotContain(result, x => x.Equals(b));

            expected.Clear();
            RefriedBeans small = new() { Size = Size.Small };
            RefriedBeans large = new() { Size = Size.Large };
            RefriedBeans kids = new() { Size = Size.Kids };
            expected.Add(small);
            expected.Add(large);
            expected.Add(kids);

            result = Menu.Search("small beans", expected);
            Assert.Single(result);
            Assert.Contains(result, x => x.Equals(small));


            Assert.DoesNotContain(result, x => x.Equals(large));
            Assert.DoesNotContain(result, x => x.Equals(kids));
            result = Menu.Search("small beans xyz", expected);
            Assert.Empty(result);


            expected.Clear();


            expected.Add(dr);
           
            expected.Add(fries);
            
            expected.Add(bowl);
            
            expected.Add(nachos);


           result = Menu.Search("FR", expected);

            Assert.Equal(2, result.Count());
            Assert.Contains(result, x => x.Equals(fries));
            Assert.Contains(result, x => x.Equals(dr));

            Assert.DoesNotContain(result, x => x.Equals(bowl));
            Assert.DoesNotContain(result, x => x.Equals(nachos));





        }




    }
    }

    



