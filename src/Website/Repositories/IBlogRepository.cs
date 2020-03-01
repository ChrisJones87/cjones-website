using System.Collections.Generic;
using System.Threading.Tasks;
using Website.Configuration;

namespace Website.Repositories
{
   public interface IBlogRepository
   {
      BlogPostMetadata Get(string key);

      IReadOnlyList<string> GetCategories();
      IReadOnlyList<string> GetTags();
      Task<IReadOnlyList<BlogPostMetadata>> SearchAsync(string category, string tag);
   }
}