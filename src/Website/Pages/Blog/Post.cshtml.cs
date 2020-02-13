using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace Website.Pages.Blog
{
   public class PostModel : PageModel
   {
      private readonly IWebHostEnvironment _environment;
      private readonly ILogger<PostModel> _logger;

      public PostModel(IWebHostEnvironment environment, ILogger<PostModel> logger)
      {
         _environment = environment;
         _logger = logger;
      }

      public string PostText { get; private set; }
      public string PostTitle { get; private set; }

      private string GeneratePostTitle(int year, int month, string postName)
      {
         var name = postName.Replace("_", " ");

         return $"{year:D4}-{year:D2} - {name}";
      }

      public async Task<IActionResult> OnGetAsync(int year, int month, string postName)
      {
         try
         {
            var filename = $"posts/{year:D4}/{month:D2}/{postName}.md";
            var file = _environment.WebRootFileProvider.GetFileInfo(filename);

            if (!file.Exists)
               return NotFound();

            await using var stream = file.CreateReadStream();
            using var reader = new StreamReader(stream);

            PostText = await reader.ReadToEndAsync();
            PostTitle = GeneratePostTitle(year, month, postName);

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