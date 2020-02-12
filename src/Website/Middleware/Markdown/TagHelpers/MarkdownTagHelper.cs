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

      private string GetMarkdownText(TagHelperOutput output)
      {
         if (!string.IsNullOrEmpty(Text))
         {
            return Text;            
         }
         else
         {
            return output.Content.GetContent();
         } 
      }

      public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
      {
         var markdownText = GetMarkdownText(output);

         var html = Markdig.Markdown.ToHtml(markdownText ?? "");

         output.Content.SetHtmlContent(html);
      }
   }
}
