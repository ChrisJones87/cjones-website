using System;
using System.Text.Json.Serialization;

namespace Website.Configuration
{
   public class BlogPostMetadata
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
   }
}