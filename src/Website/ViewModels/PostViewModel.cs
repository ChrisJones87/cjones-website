﻿using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Website.Configuration;

namespace Website.ViewModels
{
   public sealed class PostViewModel
   {
      private readonly BlogPostMetadata _post;
      private readonly string _content;

      private PostViewModel(BlogPostMetadata post, string content)
      {
         _post = post;
         _content = content;
      }

      public string Content => _content;
      public string Title => _post.Title;
      public bool HasImage => _post.HasImage;
      public string PostUrl => _post.PostUrl;

      public string ImageUrl => _post.ImageUrl;

      public static async Task<PostViewModel> Load(BlogPostMetadata post, IFileProvider root)
      {
         var content = await post.ReadContentAsync(root);

         return new PostViewModel(post, content);
      }
   }
}