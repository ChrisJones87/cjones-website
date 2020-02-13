using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Website.Middleware.Markdown.TagHelpers
{
   // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
   [HtmlTargetElement("markdown")]
   public class MarkdownTagHelper : TagHelper
   {
      public string Text { get;set;}

      private async Task<string> GetMarkdownTextAsync(TagHelperOutput output)
      {
         if (!string.IsNullOrEmpty(Text))
         {
            return Text;            
         }
         else
         {
            var content = await output.GetChildContentAsync();
            return content.GetContent();
         } 
      }

      public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
      {
         var markdownText = await GetMarkdownTextAsync(output);

         var html = Markdig.Markdown.ToHtml(markdownText ?? "");

         output.Content.SetHtmlContent(html);
      }
   }
}
