using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuildYourBowl.Data;

//submit button
//text searches by name and pre info
//range of calories
//price range
//case insensitive, containing every given search term in name, prep, or included ingredients if entree
//string.split , manual search for looping over menu items`

namespace Website.Pages
{
    /// <summary>
    /// the index page model class
    /// </summary>
    public class IndexModel : PageModel
        
    {   

        /// <summary>
        /// a logger associated with the index class
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// the full menu of all items
        /// </summary>
        public IEnumerable<IMenuItem> FullMenu => Menu.FullMenu;
        /// <summary>
        /// all ingredients that can be added to a bowl or nachos
        /// </summary>
        public IEnumerable<IngredientItem>Ingredients =>Menu.Ingredients;

        /// <summary>
        /// all entree items
        /// </summary>
        public IEnumerable<IMenuItem> Entrees { get; set; }
        /// <summary>
        /// all sides
        /// </summary>
        public IEnumerable<IMenuItem> Sides { get; set; }
        /// <summary>
        /// all drinks
        /// </summary>
        public IEnumerable<IMenuItem> Drinks { get; set; }
        /// <summary>
        /// all kids meals
        /// </summary>
        public IEnumerable<IMenuItem> KidsMeals { get; set; }
        /// <summary>
        /// all salsa options
        /// </summary>
        public IEnumerable<Salsa> Salsas { get; set; }

        /// <summary>
        /// the string that is sent through the search form
        /// </summary>
        public string SearchTerms { get; set; }
        /// <summary>
        /// the max calories for filtering
        /// </summary>
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// the min calories for filtering
        /// </summary>
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// the min price for filtering
        /// </summary>
        public decimal? PriceMin { get; set; }
        /// <summary>
        /// the max price for filtering
        /// </summary>
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// method for handling HTTP GET requests
        /// </summary>
        public void OnGet(string SearchTerms,  uint? CaloriesMin, uint? CaloriesMax, decimal? PriceMax, decimal? PriceMin)
        {
            this.SearchTerms = SearchTerms;
            this.PriceMin = PriceMin;
            this.PriceMax = PriceMax;
            this.CaloriesMax = CaloriesMax;
            this.CaloriesMin = CaloriesMin;

            Entrees = Menu.Search(SearchTerms,Menu.Entrees);
            KidsMeals = Menu.Search(SearchTerms, Menu.KidsMeals);
            Salsas = Menu.Search(SearchTerms, Menu.Salsas);
            Sides = Menu.Search(SearchTerms, Menu.Sides);
            Drinks = Menu.Search(SearchTerms, Menu.Drinks);

          
            Entrees = Menu.FilterByCalories(Entrees,CaloriesMin, CaloriesMax);
            KidsMeals = Menu.FilterByCalories(KidsMeals, CaloriesMin, CaloriesMax);
            Sides = Menu.FilterByCalories(Sides, CaloriesMin, CaloriesMax);
            Drinks = Menu.FilterByCalories(Drinks, CaloriesMin, CaloriesMax);
            Salsas = Menu.FilterByCalories(Salsas, CaloriesMin, CaloriesMax);

            Entrees = Menu.FilterByPrice(Entrees, PriceMin, PriceMax);
            KidsMeals = Menu.FilterByPrice(KidsMeals,PriceMin, PriceMax);
            Sides = Menu.FilterByPrice(Sides, PriceMin, PriceMax);
            Drinks = Menu.FilterByPrice(Drinks, PriceMin, PriceMax);
           // Salsas = Menu.FilterByPrice(Salsas, CaloriesMin, CaloriesMax);


        }
    }
}