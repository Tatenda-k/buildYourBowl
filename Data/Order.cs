using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;

namespace BuildYourBowl.Data

{
    /// <summary>
    /// the class representing an order
    /// </summary>
    public class Order:ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        ///event listener for order items
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));



        }

       

        /// <summary>
        /// constructor for the order class
        /// </summary>
        public Order()
        {
            PlacedAt= DateTime.Now;
            Number = _last_number ;
            _last_number += 1;
        }
        /// <summary>
        /// the number of the previous order
        /// </summary>
        private static int _last_number;
        
        /// <summary>
        /// the order number
        /// </summary>
        public int Number { get; init; }


        /// <summary>
        /// the time the current order was placed at
        /// </summary>
        public DateTime PlacedAt
        {
            get;init;
        }

        /// <summary>
        /// the order items
        /// </summary>
        private List<IMenuItem> _items = new();
        /// <summary>
        /// price of all items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal sub = 0;
                foreach (IMenuItem item in _items) sub += item.Price;
                return sub;

            }
        }
        /// <summary>
        /// private backing field for TaxRate
        /// </summary>

        private decimal _taxrate =  0.0915m;

        /// <summary>
        /// the tax rate of the order
        /// </summary>
        
        public decimal TaxRate
        {
            get
            {
                return _taxrate;
            }
            set
            {

                _taxrate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            }
        }
        /// <summary>
        /// the tax for the order
        /// </summary>
        public decimal Tax => TaxRate * Subtotal;
        /// <summary>
        /// the final price of the order
        /// </summary>
        public decimal Total => Subtotal + Tax;
        /// <summary>
        ///private backing field for Count
        /// </summary>
       
        private int _count = 0;
        /// <summary>
        /// the number of items in the order
        /// </summary>
        public int Count
        {
            get { return _count; }
        }
        /// <summary>
        /// if the  order object is read only
        /// </summary>
        public bool IsReadOnly { get; } = false;

        /// <summary>
        /// adds an item to the order
        /// </summary>
        /// <param name="item">the item to add</param>
        public void Add(IMenuItem item)
        {
            _items.Add(item);
            item.PropertyChanged += HandlePropertyChanged;
           


            _count += 1;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));

        }
        /// <summary>
        /// clear the order
        /// </summary>

        public void Clear()
        {
            _items.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            

        }

        /// <summary>
        /// returns if an item exists in the order
        /// </summary>
        /// <param name="item">the item to look for</param>
        /// <returns>whether the item exists in the order</returns>
        public bool Contains(IMenuItem item)
        {
            return _items.Contains(item);
        }
        /// <summary>
        /// copies menu items into given array
        /// </summary>
        /// <param name="array">the array to copy to </param>
        /// <param  name="arrayIndex">the starting index for the copying</param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
           
            for (int i = arrayIndex; i < Count; i++)
                array[i] = _items[i];
        }
        /// <summary>
        /// returns the enumerator for menu items
        /// </summary>
        /// <returns>the enumerator for menu items</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        /// <summary>
        /// removes an item from the order
        /// </summary>
        /// <param name="item">the item to be removed</param>
        /// <returns>whether the item has been removed </returns>
        public bool Remove(IMenuItem item)
        {
            int index = _items.IndexOf(item);
            if (index > -1)
      
            {
                _items.Remove(item);
                item.PropertyChanged -= HandlePropertyChanged;


               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
               CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,item, index));

                return true;
            }
            return false;

        }
        /// <summary>
        /// calls GetEnumerator()
        /// </summary>
        /// <returns> GetEnumerator()</returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
