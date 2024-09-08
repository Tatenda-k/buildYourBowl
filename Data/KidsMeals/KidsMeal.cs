using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// base class for kids meals
    /// </summary>
    public abstract class KidsMeal : IMenuItem,INotifyPropertyChanged

    {
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
        ///event listener for side
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">metadata for the event</param>
        private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
        }

        public KidsMeal(uint min,uint max, uint defaultt)
        {
            _maximumCount = max;
             _minimumCount = min;
             _defaultCount = defaultt;
            _count = defaultt;
            this.SideChoice.PropertyChanged += HandlePropertyChanged;
            this.DrinkChoice.PropertyChanged += HandlePropertyChanged;
            SideChoice.Size = Size.Kids;
            DrinkChoice.Size = Size.Kids;


        }
        /// <summary>
        /// the main part of the kids meal
        /// </summary>
        public abstract string Mainpart { get; }
        /// <summary>
        /// the name of the drink
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// the description of the drink
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// private backing field for the SideChoice property
        /// </summary>
        protected Side _side = new Fries() { Size = Size.Kids };

        /// <summary>
        /// private backing field for the DrinkChoice property
        /// </summary>
        protected Drink _drink = new Milk();

        /// <summary>
        /// drink choice for the kids meal
        /// </summary>
        public Drink DrinkChoice
        {
            get
            {
                return _drink;
            }
            set
            {

                _drink = value;
               
              _drink.PropertyChanged += HandlePropertyChanged;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));
            }
        }

        /// <summary>
        /// the side choice for the chicken nuggets meal
        /// </summary>
        public Side SideChoice
        {
            get
            {
                return _side;
            }
            set
            {
                _side = value;
                
                _side.PropertyChanged += HandlePropertyChanged;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));

            }
        }
        /// <summary>
        /// the calories in the meal
        /// </summary>
        
        public virtual uint Calories
        {
            get
            {
                uint cals = _caloriesPerItem*ItemCount;
                cals += SideChoice.Calories;
                cals += DrinkChoice.Calories;
                return cals;
            }
        }

        /// <summary>
        /// the price of  the meal
        /// </summary>

        public abstract decimal Price{ get; }
        /// <summary>
        /// the preperation information for a kids meal
        /// </summary>
        public abstract IEnumerable<string> PreparationInformation { get; }

        /// <summary>
        /// the calories per item of the kids meal
        /// </summary>
        protected uint _caloriesPerItem;
        /// <summary>
        ///  the default count
        /// </summary>
        protected uint _defaultCount;

        /// <summary>
        /// the maximum count
        /// </summary>
        /// 

        protected  uint _maximumCount;

        /// <summary>
        /// the minimum count
        /// </summary>
        /// 

        protected uint _minimumCount;

        /// <summary>
        /// the number of bites/nuggets/sliders
        /// </summary>

        protected uint _count;

        /// <summary>
        /// the count of .............................................................
        /// </summary>
        public virtual uint ItemCount
        {
            set
            {
                if (value >=_minimumCount && value <=_maximumCount) _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemCount)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
            get
            {
                return _count;
            }
        }
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
            KidsMeal kids = (KidsMeal)obj;
            return SideChoice.Equals(kids.SideChoice) && DrinkChoice.Equals(kids.DrinkChoice);
        }
    }
}
