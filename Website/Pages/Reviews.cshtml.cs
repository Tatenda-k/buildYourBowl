using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuildYourBowl.Data;

namespace Website.Pages
{
    public class ReviewsModel : PageModel
    {
        /// <summary>
        /// the review a customer enters
        /// </summary>
        /// 

        public List<Review> Reviews = ReviewDatabase.reviews;
        [BindProperty]
        public string NewReview { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            ReviewDatabase.AddReview(NewReview);

        }
    }
}
