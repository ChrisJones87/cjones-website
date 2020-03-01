using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Configuration
{
   public class BlogConfiguration
   {
      public List<BlogPostMetadata> Posts { get; set; }
      public List<BlogPostMetadata> Drafts { get; set; }

      public IEnumerable<BlogPostMetadata> AllPosts => Drafts != null ? Drafts.Concat(Posts) : Posts;
   }
}
