using System;

namespace ArrangementApp
{
    internal static class Program
    {
        // За методичкою Main можна не реалізовувати; тут коротка демонстрація класу.
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var a = new Arrangement(5, 2);
            var b = new Arrangement(4, 3);
            var c = new Arrangement(a);

            Console.WriteLine($"{a} = {a.Count()}");
            Console.WriteLine($"{b} = {b.Count()}");
            Console.WriteLine($"{c} є копією {a}, Equals: {a.Equals(c)}");
            Console.WriteLine($"{a}.CompareTo({b}) = {a.CompareTo(b)}");
        }
    }
}
