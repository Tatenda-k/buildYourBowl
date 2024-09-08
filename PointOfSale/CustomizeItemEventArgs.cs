using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildYourBowl.Data;


namespace BuildYourBowl.PointOfSale
{

    /// <summary>
    /// custom event to handle customizing of items
    /// </summary>
    public class CustomizeItemEventArgs
    {
        /// <summary>
        /// Sets and returns the item to be customized
        /// </summary>
        public IMenuItem MenuItem { get; private set; }


        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="item">the item to be customized</param>
        public CustomizeItemEventArgs(IMenuItem item)
        {
            MenuItem = item;
        }

    }
}
