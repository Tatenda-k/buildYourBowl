using BuildYourBowl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.PointOfSale
{
    /// <summary>
    /// special event for editting items
    /// </summary>
    public  class EditItemEventArgs
    {

        /// <summary>
        /// Sets and returns the item to be customized
        /// </summary>
        public IMenuItem MenuItem { get; private set; }


        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="item">the item to be customized</param>
        public EditItemEventArgs(IMenuItem item)
        {
            MenuItem = item;
        }
    }
}
