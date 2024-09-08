using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    /// <summary>
    /// the model for the privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        /// <summary>
        /// a logger instance for the privacymodel class
        /// </summary>
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// initializes a new instance of the <see cref="PrivacyModel"/> class.
        /// </summary>
        /// <param name="logger">the logger instance</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// handles the HTTP GET request for the privacy page
        /// </summary>
        public void OnGet()
        {
        }
    }
}