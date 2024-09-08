using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildYourBowl.Data
{
    /// <summary>
    /// base class for menu items
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
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
        /// the name of the menu item
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// the description of the menu item
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// constructor for the entree class
        /// </summary>
        public Entree()
        {
            foreach (Ingredient i in Enum.GetValues(typeof(Ingredient)))
            {
                if (i != Ingredient.Rice && i != Ingredient.Chips)
                {
                    IngredientItem item = new IngredientItem(i);
                    item.PropertyChanged += HandlePropertyChanged;
                    _possibleToppings.Add(i, item);
                }
            }

        }
        /// <summary>
        /// helper method to invoke propertychanged
        /// </summary>
        /// <param name="sender">the sender of this event</param>
        /// <param name="e">information about the event</param>
        protected void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));

        }
        /// <summary>
        /// the price of the menu item
        /// </summary>
        public virtual decimal Price {
            get
            {
                decimal price = 7.99m;
                foreach (KeyValuePair<Ingredient, IngredientItem> entry in Instructions)
                    if (entry.Value.Included) price += entry.Value.UnitCost;
                return price;
            }
        }

        /// <summary>
        /// the calories in the menu item
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                uint cals = 0;
                cals += Base.Calories;
                foreach (KeyValuePair<Ingredient, IngredientItem> entry in Instructions)
                    if (entry.Value.Included) cals += entry.Value.Calories;
                if (SalsaChoice != Salsa.None) cals += 20;
                return cals;
            }
        }

        /// <summary>
        /// the preperation information for the menu item
        /// </summary>
        public virtual IEnumerable<string> PreparationInformation {
            get
            {
                List<string> instructions = new();

                foreach (KeyValuePair<Ingredient, IngredientItem> entry in Instructions)
                {
                    if (entry.Value.Included == true && entry.Value.Default == false) instructions.Add($"Add {entry.Value.Name}");
                    if (entry.Value.Included == false && entry.Value.Default == true) instructions.Add($"Hold {entry.Value.Name}");
                }
                if (SalsaChoice == Salsa.None)
                {
                    instructions.Add($"Hold Salsa");
                }
                else if (SalsaChoice != DefaultSalsa)
                {
                    instructions.Add($"Swap {SalsaChoice} Salsa");
                }
                return instructions;
            }
        }

        /// <summary>
        /// private backing field for Salsa
        /// </summary>
        private Salsa _salsa = Salsa.Medium;

        /// <summary>
        /// the salsa for the entree
        /// </summary>
        public virtual Salsa SalsaChoice
        {
            get
            {
                return _salsa;
            }
            set
            {
                _salsa = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SalsaChoice)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreparationInformation)));
            }
        }

        /// <summary>
        /// the default salsa
        /// </summary>
        protected virtual Salsa DefaultSalsa { get; } = Salsa.Medium;

        /// <summary>
        /// the base ingredient of the entree
        /// </summary>
        public abstract IngredientItem Base { get; }

        /// <summary>
        /// private backing field for Instructions 
        /// </summary>
        protected Dictionary<Ingredient, IngredientItem> _possibleToppings = new();

        /// <summary>
        ///ingredients in addtion to the base 
        /// </summary>
        public Dictionary<Ingredient, IngredientItem> Instructions { get
            {
                return _possibleToppings;
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
        /// a list of all possible ingredients for the meal
        /// </summary>
        public List<IngredientItem> AllIngredients {

            get
            {
             return    _possibleToppings.Values.ToList();
            }
            set
            {
                foreach(IngredientItem item in _possibleToppings.Values.ToList())
                {
                   item.PropertyChanged += HandlePropertyChanged;
                }
            }


            }


    }
}
