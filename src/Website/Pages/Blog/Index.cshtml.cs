using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Website.Configuration;

namespace Website.Pages.Blog
{
   public class IndexModel : PageModel
   {
      private readonly IWebHostEnvironment _environment;
      private readonly ILogger _logger;
      private readonly BlogConfiguration _blogConfiguration;

      public IndexModel(IWebHostEnvironment environment,
                        ILogger<IndexModel> logger,
                        IOptions<BlogConfiguration> blogConfigurationOptions)
      {
         _environment = environment;
         _logger = logger;
         _blogConfiguration = blogConfigurationOptions.Value;
      }

      public List<BlogPostMetadata> BlogPosts => _blogConfiguration.Posts;

      public async Task<IActionResult> OnGetAsync()
      {
         return Page();
      }
   }
}