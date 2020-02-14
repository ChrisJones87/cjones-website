using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
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

      public List<string> Categories { get; set; }
      public List<string> Tags { get; set; }

      public async Task<IActionResult> OnGetAsync([FromQuery] string category, [FromQuery] string tag)
      {
         Categories = BlogPosts.Where(x => !string.IsNullOrWhiteSpace(x.Category)).Select(x => x.Category).Distinct().ToList();
         Tags = BlogPosts.Where(x => x.Tags != null).SelectMany(x => x.Tags).Distinct().ToList();

         return Page();
      }
   }
}