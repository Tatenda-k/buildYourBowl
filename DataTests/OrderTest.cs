using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;



namespace BuildYourBowl.Data.Tests
{
    /// <summary>
    /// tests for the order class
    /// </summary>
    public  class OrderTest
    {

        /// <summary>
        /// number property stays same when requested more than once
        /// </summary>
        [Fact]
        public void NumberPropertyStaysSameWhenRequestedMoreThanOnce()
        {
            Order order = new();
            int number = order.Number;
            Assert.Equal(number, order.Number);
            Assert.Equal(number, order.Number);
        }

        /// <summary>
        /// placed at property stays same when requested more than once
        /// </summary>
        [Fact]
        public void PlacedAtPropertyStaysSameWhenRequestedMoreThanOnce()
        {
            Order order = new();
            DateTime time = order.PlacedAt;
            Assert.Equal(time, order.PlacedAt);
            Assert.Equal(time, order.PlacedAt);
        }


        /// <summary>
        /// tests that order number updates
        /// </summary>
        [Fact]
        public void NumberIncrements()
        {
            Order order = new();
            int number = order.Number;
            order.Clear();
            order = new();
            Assert.Equal(number+1,order.Number);
        }

        /// <summary>
        /// tests that order number updates
        /// </summary>
        [Fact]
        public void NumberIncrements2()
        {
            Order order = new();
            int number = order.Number;
            order.Clear();
            order = new();
            order.Clear();
            order = new();
            Assert.Equal(number+2, order.Number);
        }
        /// <summary>
        /// PlacedAt property reflects time order was created
        /// </summary>
        [Fact]
        public void PlacedAtReflectsTimeOrderWasCreated()
        {
            Order order = new();
            DateTime time = order.PlacedAt;
            Assert.True(DateTime.Now - time < TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Order object can  be cast to IMenuItem 
        /// </summary>

        [Fact]
        public void CastTest()
        {
            Order order = new();
            Assert.IsAssignableFrom<ICollection<IMenuItem>>(order);
        }
      
        /// <summary>
        /// changing tax rate notifies propertyChange of tax rate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// changing tax rate notifies propertyChange of tax
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChangeTax()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Tax", () => {
                order.TaxRate = 0.15m;
            });
        }


        /// <summary>
        /// changing tax rate notifies propertyChange of Total
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChangeTotal()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "Total", () => {
                order.TaxRate = 0.15m;
            });
        }
        
        /// <summary>
        /// changing tax rate notifies propertyChange of SubTotal
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChangeSubTotal()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "SubTotal", () => {
                order.TaxRate = 0.15m;
            });
        }
        ///<summary>
        /// adding to order notifies propertyChange of Total
        ///</summary>
        [Fact]
        public void AddingToOrderShouldNotifyOfPropertyChangeTotal()
        {
            Order order = new();
            Assert.PropertyChanged(order, "Total", () =>
            {
                Horchata drink = new();
                order.Add(drink);
            });
        }

        ///<summary>
        /// adding to order notifies propertyChange of SubTotal
        ///</summary>
        [Fact]
        public void AddingToOrderShouldNotifyOfPropertyChangeSubTotal()
        {
            Order order = new();
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                Horchata drink = new();
                order.Add(drink);
            });
        }
        ///<summary>
        /// adding to order notifies propertyChange of Tax
        ///</summary>
        [Fact]
        public void AddingToOrderShouldNotifyOfPropertyChangeTaxRate()
        {
            Order order = new();
            Assert.PropertyChanged(order, "Tax", () =>
            {
                Horchata drink = new();
                order.Add(drink);
            });
        }

        ///<summary>
        /// removing from order notifies propertyChange of total
        ///</summary>
        [Fact]
        public void RemovingFromOrderShouldNotifyOfPropertyChangeTotal()
        {
            Order order = new();
            Milk milk = new();
            order.Add(milk);
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Remove(milk);
            });
        }


        ///<summary>
        /// removing from order notifies propertyChange of subtotal
        ///</summary>
        [Fact]
        public void RemovingFromOrderShouldNotifyOfPropertyChangeSubTotal()
        {
            Order order = new();
            Milk milk = new();
            order.Add(milk);
            Assert.PropertyChanged(order, "SubTotal", () =>
            {
                order.Remove(milk);
            });
        }


        ///<summary>
        /// removing from order notifies propertyChange of Tax
        ///</summary>
        [Fact]
        public void RemovingFromOrderShouldNotifyOfPropertyTax()
        {
            Order order = new();
            Milk milk = new();
            order.Add(milk);
            Assert.PropertyChanged(order, "Tax", () =>
            {
                order.Remove(milk);
            });
        }

        ///<summary>
        /// canceling order notifies propertyChange
        ///</summary>
        [Fact]
        public void CancelingOrderShouldNotifyOfPropertyChange()
        {
            Order order = new();
           
            Assert.PropertyChanged(order, "Total", () =>
            {
                order.Clear();
            });
        }

        /// <summary>
        /// order can be cast into INotifyPropertyChanged instance
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// order can be cast into INotifyCollectionChanged instance
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }


        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {
            /// <summary>
            /// the name of the order
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// the description of the mock object 
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// the price of the mock object
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// the calories per each of the mock object
            /// </summary>
            public uint CaloriesPerEach { get; set; }
            /// <summary>
            /// the total calories of of the mock object
            /// </summary>
            public uint CaloriesTotal { get; set; }
            /// <summary>
            /// the special instructions of of the mock object
            /// </summary>
            public IEnumerable<string> SpecialInstructions { get; set; }
            /// <summary>
            /// the calories of of the mock object
            /// </summary>
            public uint Calories => throw new NotImplementedException();
            /// <summary>
            /// the preperation information of of the mock object
            /// </summary>
            public IEnumerable<string> PreparationInformation => throw new NotImplementedException();

            public event PropertyChangedEventHandler? PropertyChanged;
        }

        /// <summary>
        /// tests that subtotal reflects item prices
        /// </summary>
        [Fact]
        public void SubtotalShouldReflectItemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
            Assert.Equal(6.50m, order.Subtotal);
        }

        /// <summary>
        /// tests that subtotal reflects item prices
        /// </summary>
        [Fact]
        public void TaxPropertyTest()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 1.00m });
            order.Add(new MockMenuItem() { Price = 2.50m });
            order.Add(new MockMenuItem() { Price = 3.00m });
           
            Assert.Equal(6.50m*0.0915m, order.Tax);
        }

        /// <summary>
        /// tests that subtotal reflects item prices
        /// </summary>
        /// <param name="one"> the first item</param>
        /// <param name="two">the second item</param>
        /// <param name="three">the third item</param>
        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2,4,5)]
        [InlineData(2.5, 4, 5.5)]
        [InlineData(2, 3.5, 6.5)]
        public void TaxPropertyTest1(decimal one,decimal two,decimal three)
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price =one });
            order.Add(new MockMenuItem() { Price = two });
            order.Add(new MockMenuItem() { Price = three });

            Assert.Equal((one+two+three) * 0.0915m, order.Tax);
        }
        /// <summary>
        /// tests that subtotal reflects item prices
        /// </summary>
        /// <param name="one"> the first item</param>
        /// <param name="two">the second item</param>
        /// <param name="three">the third item</param>

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 4, 5)]
        [InlineData(2.5, 4, 5.5)]
        [InlineData(2, 3.5, 6.5)]
        public void TotalPropertyTest4(decimal one, decimal two, decimal three)
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = one });
            order.Add(new MockMenuItem() { Price = two });
            order.Add(new MockMenuItem() { Price = three });

            Assert.Equal(((one + two + three) * 0.0915m)+one+two+three, order.Total);
            //Assert.Equal(order.Subtotal+order.Tax, order.Subtotal);
        }
        /// <summary>
        /// count property initially set to 0
        /// </summary>
        [Fact]
        public void InitialCountProperty()
        {
            Order order = new Order();
            Assert.Empty( order);
        }
        /// <summary>
        /// checks that default tax rate is set correctly
        /// </summary>
        [Fact]
        public void DefaultTaxRate()
        {
            Order order = new Order();
            Assert.Equal(0.0915m, order.TaxRate);
        }

       /* /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void AddMethodTest()
        {
            Order order = new Order();
            MockMenuItem mock = new();
            order.Add(mock) ;
            Assert.Contains(mock,order);
        }

        [Fact]
        public void ContainsMethodTest()
        {
            Order order = new();
            MockMenuItem mock = new();
            order.Add(mock);
            bool contains = false;
            foreach(IMenuItem item in order)
            {
                if (item.Equals(mock)) contains = true;

            }
            Assert.True(contains);
        }*/






    }
}
