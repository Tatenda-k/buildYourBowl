using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// the base class for bowl entrees
    /// </summary>
    public class Bowl : Entree
    {

        /// <summary>
        /// constructor for the Nachos class
        /// </summary>
        public Bowl()
        {
            Base = new IngredientItem(Ingredient.Rice);
        }
        /// <summary>
        /// the name of the bowl
        /// </summary>
        public override string Name { get; } = "Build-Your-Own-Bowl";

        /// <summary>
        /// description of the bowl
        /// </summary>
        public override string Description { get; } = "A bowl you get to build";

        /// <summary>
        /// the base ingredient for the bowl
        /// </summary>

        public override IngredientItem Base { get; } = new IngredientItem(Ingredient.Rice);

        



    }
}
