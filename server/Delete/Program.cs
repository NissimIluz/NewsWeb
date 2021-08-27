using GetData;
using System;

namespace Delete
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var rss = new RSS();
            rss.SetNews();
        }
    }
}
