using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Website.Configuration;

namespace Website.Repositories
{
   public sealed class BlogRepository : IBlogRepository
   {
      private readonly BlogConfiguration _blog;

      public BlogRepository(IOptions<BlogConfiguration> blogOptions)
      {
         _blog = blogOptions.Value;
      }

      public BlogPostMetadata Get(string key)
      {
         return _blog.AllPosts.FirstOrDefault(x => x.Path == key);
      }

      public IReadOnlyList<string> GetCategories()
      {
         return _blog.AllPosts.Where(x => !string.IsNullOrWhiteSpace(x.Category)).Select(x => x.Category).Distinct().ToArray();
      }

      public IReadOnlyList<string> GetTags()
      {
         return _blog.AllPosts.Where(x => x.Tags != null).SelectMany(x => x.Tags).Distinct().ToArray();
      }

      public async Task<IReadOnlyList<BlogPostMetadata>> SearchAsync(string category, string tag)
      {
         var query = _blog.AllPosts.AsQueryable();

         if (!string.IsNullOrWhiteSpace(category))
         {
            query = query.Where(x => x.Category == category);
         }

         if (!string.IsNullOrWhiteSpace(tag))
         {
            query = query.Where(x => x.Tags.Contains(tag));
         }

         return query.ToList();
      }
   }
}