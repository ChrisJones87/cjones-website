using System.Globalization;

namespace Website.Pages.Blog
{
   public static class StringExtensions
   {
      public static string MakeUiFriendly(this string value)
      {
         if (value == null)
            return null;

         var valueWithSpaces = value.Replace("-", " ");

         var textInfo = CultureInfo.CurrentUICulture.TextInfo;

         return textInfo.ToTitleCase(valueWithSpaces);
      }
   }
}