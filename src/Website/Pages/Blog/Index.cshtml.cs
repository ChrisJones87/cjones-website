using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Website.Configuration;
using Website.Repositories;

namespace Website.Pages.Blog
{
   public class IndexModel : PageModel
   {
      private readonly ILogger _logger;
      private readonly IBlogRepository _blogRepository;

      public IndexModel(ILogger<IndexModel> logger,
                        IBlogRepository blogRepository)
      {
         _logger = logger;
         _blogRepository = blogRepository;
      }

      public IReadOnlyList<BlogPostMetadata> BlogPosts { get; private set; }

      public IReadOnlyList<string> Categories { get; set; }
      public IReadOnlyList<string> Tags { get; set; }

      public async Task<IActionResult> OnGetAsync([FromQuery] string category, [FromQuery] string tag)
      {
         Categories = _blogRepository.GetCategories();
         Tags = _blogRepository.GetTags();

         BlogPosts = await _blogRepository.SearchAsync(category, tag);

         return Page();
      }
   }
}