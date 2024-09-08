using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuildYourBowl.Data
{
    /// <summary>
    /// class that represents the reviewdatabase
    /// </summary>
    public static class ReviewDatabase
    {
        /// <summary>
        /// a list of reviews
        /// </summary>
        public static List<Review> reviews=new();
        static ReviewDatabase()
        {
            if (File.Exists("reviews.json"))
            {
                string json = File.ReadAllText("review.json");
                Review review = JsonConvert.DeserializeObject<Review>(json);

            }
            if (reviews == null)
            {
                reviews = new List<Review>();
            }
        }

        public static void AddReview (string content)
        {
            Review review = new Review()
            {
                Text = content,
                Time = DateTime.Now
            };
            if (content != null)
            {
                reviews.Add(review);
                string json = JsonConvert.SerializeObject(reviews, Formatting.Indented);
                File.WriteAllText("review.json", json);
            }
        }

        public static IEnumerable<Review> GetReviews()
        {
           
              return from review in reviews orderby review.Time select review;
            
        }
    }
}
