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
    public class Nachos : Entree

    {
        /// <summary>
        /// constructor for the Nachos class
        /// </summary>
        public Nachos()
        {
            Base = new IngredientItem(Ingredient.Chips);
        }
        /// <summary>
        /// the name of the bowl
        /// </summary>
        public override string Name { get; } = "Build-Your-Own-Nachos";

        /// <summary>
        /// description of the bowl
        /// </summary>
        public override string Description { get; } = "Nachos you get to build";

        
        /// <summary>
        /// the base ingredient for the nacho
        /// </summary>
        public override IngredientItem Base { get; } = new IngredientItem(Ingredient.Chips);



        
    }
}
