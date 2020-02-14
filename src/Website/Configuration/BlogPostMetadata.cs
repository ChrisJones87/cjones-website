namespace Website.Configuration
{
   public class BlogPostMetadata
   {
      public string ImageUrl { get; set; }
      public string Path { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string Category { get; set; }
      public string[] Tags { get; set; }

      public string PostUrl=> $"/blog/post/{Path}";
   }
}