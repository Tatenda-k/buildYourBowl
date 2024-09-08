using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// class for representing reviews
    /// </summary>
    public class Review
    {
        /// <summary>
        /// the text in the review
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// the time the review was made at
        /// </summary>
        public DateTime Time { get; set; }

       
    }
}
