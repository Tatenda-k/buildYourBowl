using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Website.Pages
{
    /// <summary>
    /// the model for the error page
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    
   
    public class ErrorModel : PageModel
    {   

        /// <summary>
        /// gets or sets the request ID
        /// </summary>
        public string? RequestId { get; set; }
        /// <summary>
        /// gets a value indicating whether to show the request ID 
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        /// <summary>
        /// Gets a value indicating whether to show the request ID
        /// </summary>
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Initializes a new instance of the ,see cref="ErrorModel"/> class
        /// </summary>
        /// <param name="logger">The logger instance</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// handles the HTTP GET request for the error page
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}