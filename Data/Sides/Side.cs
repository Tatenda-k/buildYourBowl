using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace BuildYourBowl.Data
{
    /// <summary>
    /// the base class for side meals
    /// </summary>
    public abstract class Side : IMenuItem
    {
        /// <summary>
        /// property changed event handler event
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// helper method to invoke PropertyChanged event from derived class
        /// </summary>
        /// <param name="propertyName">the name of the altered property</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// the name of the side 
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// the description of the side
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// the price of the side
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// private backing field for size
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// the size of the side
        /// </summary>
        public virtual Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// preperation information for the side 
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }
       
        /// <summary>
        /// the calories of the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// overrides the object ToString() method
        /// </summary>
        /// <returns>string reprsentation of the item</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// returns whether this and obj are the same ingredient item
        /// </summary>
        /// <param name="obj"> the object to be compared to</param>
        /// <returns>whether this and obj are the same ingredient item</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Side item = (Side)obj;
            return Name == item.Name && Price == item.Price && Calories == item.Calories && PreparationInformation==item.PreparationInformation && Size==item.Size && Description ==item.Description;
        }


    }
}
