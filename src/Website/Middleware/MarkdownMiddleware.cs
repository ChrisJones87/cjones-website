using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Website.Middleware
{
   public class MarkdownMiddleware
   {
      private readonly RequestDelegate _next;

      public MarkdownMiddleware(RequestDelegate next)
      {
         _next = next;
      }

      public Task Invoke(HttpContext httpContext)
      {
         var markdownText = "  # Blog Post Header\nThis is a blog post! \n* point 1\n* point 2\n* point 3";

         var html = Markdig.Markdown.ToHtml(markdownText);

         return _next(httpContext);
      }
   }

   public static class MarkdownMiddlewareExtensions
   {
      public static IApplicationBuilder UseMarkdown(this IApplicationBuilder builder)
      {
         return builder.UseMiddleware<MarkdownMiddleware>();
      }
   }
}
