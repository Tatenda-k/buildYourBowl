using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// represents the properties that all menu items share
    /// </summary>
    public interface IMenuItem: INotifyPropertyChanged
    {

        public new event  PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// the name of the menu item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// the description of the menu item
        /// </summary>
        public string Description { get; }
        
        /// <summary>
        /// the price of the menu item
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// the calories in the menu item
        /// </summary>
        public uint Calories { get; }

        /// <summary>
        /// the preperation information for the menu item
        /// </summary>
        public IEnumerable<string> PreparationInformation { get; }


      
    }
}
