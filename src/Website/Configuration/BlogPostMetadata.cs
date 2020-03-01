using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Website.Configuration
{
   public sealed class BlogPostMetadata
   {
      private string[] _tags;

      public string ImageName { get; set; }
      
      public string Path { get; set; }

      public string Title { get; set; }

      public string Description { get; set; }

      public string Category { get; set; } = "";

      public string[] Tags
      {
         get => _tags ?? Array.Empty<string>();
         set => _tags = value;
      }

      public string PostUrl => $"/blog/post/{Path}";

      public string ImageUrl => $"/images/media/{ImageName}";

      public bool HasImage => !string.IsNullOrEmpty(ImageName);

      public async Task<string> ReadContentAsync(IFileProvider root)
      {
         var filename = $"posts/{Path}.md";
         var file = root.GetFileInfo(filename);

         if (!file.Exists)
            return null;

         await using var stream = file.CreateReadStream();
         using var reader = new StreamReader(stream);

         return await reader.ReadToEndAsync();
      }
   }
}