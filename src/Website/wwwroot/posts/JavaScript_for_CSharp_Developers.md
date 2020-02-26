# Start of Development

If you're like me you've come from a background in C# and want to get much more involved in the web as it is a huge and evolving space.



Testing C Sharp Code:

```cs
using System.IO.Compression;

#pragma warning disable 414, 3021

namespace MyApplication
{
   [Obsolete("...")]
   class Program : IInterface
   {
      public static List<int> JustDoIt(int count)
      {
         Console.WriteLine($"Hello {Name}!");
         return new List<int>(new int[] { 1, 2, 3 })
      }
   }
}
```