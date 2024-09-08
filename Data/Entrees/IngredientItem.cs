using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// reperesents an ingredient for a menu item
    /// </summary>
    public class IngredientItem : INotifyPropertyChanged
    {

        /// <summary>
        /// constructor for the IngredientItem
        /// </summary>
        /// <param name="ingredient"></param>
        public IngredientItem(Ingredient ingredient)
        {
            IngredientType = ingredient;


        }
        /// <summary>
        /// the type of ingredient
        /// </summary>
        public Ingredient IngredientType { get; }

        /// <summary>
        /// the name of the ingredient 
        /// </summary>
        public string Name
        {
            get
            {
                if (IngredientType == Ingredient.PintoBeans) return "Pinto Beans";
                if (IngredientType == Ingredient.BlackBeans) return "Black Beans";
                if (IngredientType == Ingredient.SourCream) return "Sour Cream";

                return IngredientType.ToString();
            }
        }
        /// <summary>
        /// the calories in an ingredient
        /// </summary>
        public uint Calories
        {
            get
            {
                if (IngredientType == Ingredient.BlackBeans || IngredientType == Ingredient.PintoBeans) return 130;
                if (IngredientType == Ingredient.Queso) return 110;
                if (IngredientType == Ingredient.Veggies) return 20;
                if (IngredientType == Ingredient.SourCream) return 100;
                if (IngredientType == Ingredient.Guacamole || IngredientType == Ingredient.Chicken) return 150;
                if (IngredientType == Ingredient.Steak) return 180;
                if (IngredientType == Ingredient.Carnitas) return 210;
                if (IngredientType == Ingredient.Rice) return 210;
                if (IngredientType == Ingredient.Chips) return 250;
                return 0;
            }
        }

        /// <summary>
        /// the unit cost of an ingredient
        /// </summary>
        public decimal UnitCost
        {
            get
            {
                if (IngredientType == Ingredient.Steak || IngredientType == Ingredient.Chicken ||
                    IngredientType == Ingredient.Carnitas)
                    return 2.0m;

                else if (IngredientType == Ingredient.BlackBeans || IngredientType == Ingredient.PintoBeans || IngredientType == Ingredient.Queso || IngredientType == Ingredient.Guacamole)
                    return 1.0m;
                else return 0;


            }
        }
        /// <summary>
        /// private backing field for Included
        /// </summary>
        private bool _included = false;

        /// <summary>
        /// whether this ingredient is currently included in a containing menu item
        /// </summary>
        public bool Included
        {
            get
            {
                return _included;
            }
            set
            {
                _included = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Included)));
                //also calories and price need to change, custom event preperation information
            }
        }

        /// <summary>
        /// whether this ingredient is included in its containing menu item
        /// </summary>
        public bool Default { get; set; } = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// returns whether this and obj are the same ingredient item
        /// </summary>
        /// <param name="obj"> the object to be compared to</param>
        /// <returns>whether this and obj are the same ingredient item</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null|| GetType()!=obj.GetType()) return false;
            IngredientItem item = (IngredientItem)obj;
            return Name == item.Name && UnitCost == item.UnitCost && Calories == item.Calories;
        }
    }
}