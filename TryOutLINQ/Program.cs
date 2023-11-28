using System;
using System.Linq;

namespace TryOutLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Primjeri: 
            //Primjer 1.

            #region Primjer 1.
            int[] brojevi =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
                16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28
            };
            var rezUpita = from num in brojevi
                           where num > 10
                           select num;
            foreach (var rez in rezUpita)
            {
                Console.WriteLine(rez.ToString() + " ");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
