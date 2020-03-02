using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Website.Repositories;
using Website.ViewModels;

namespace Website.Pages.Blog
{
   public class PostModel : PageModel
   {
      private readonly IWebHostEnvironment _environment;
      private readonly ILogger<PostModel> _logger;
      private readonly IBlogRepository _blogRepository;

      public PostModel(IWebHostEnvironment environment, ILogger<PostModel> logger, IBlogRepository blogRepository)
      {
         _environment = environment;
         _logger = logger;
         _blogRepository = blogRepository;
      }

      public PostViewModel Post { get; private set; }

      public IReadOnlyList<string> Categories { get; set; }
      public IReadOnlyList<string> Tags { get; set; }

      public async Task<IActionResult> OnGetAsync(string postName)
      {
         try
         {
            Categories = _blogRepository.GetCategories();
            Tags = _blogRepository.GetTags();

            var post = _blogRepository.Get(postName);
            Post = await PostViewModel.Load(post, _environment.WebRootFileProvider);

            return Page();
         }
         catch (Exception ex)
         {
            _logger.LogError(ex, "Failed to display blog post");
            return BadRequest();
         }
      }
   }
}