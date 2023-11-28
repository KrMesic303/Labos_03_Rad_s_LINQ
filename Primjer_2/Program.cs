using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primjer_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Profesor> listaProfesora = new List<Profesor>()
            {
                new Profesor
                {
                    ImePrezimeProfesora = "Dubravka Milić",
                    JeRazrednikRazredu = "3.b"
                },
                new Profesor
                {
                    ImePrezimeProfesora = "Dragica Pribić",
                    JeRazrednikRazredu = "4.h"
                },
                new Profesor()
                {
                    ImePrezimeProfesora = "Miroslav Šašić",
                    JeRazrednikRazredu = "4.k"
                }
            };
            List<Ucenik> popisNajboljihUcenika = new List<Ucenik>()
            {
                new Ucenik
                {
                    ImePrezimeUcenika = "Ana Anić",
                    RazredUcenika = "1.a"
                },
                new Ucenik
                {
                    ImePrezimeUcenika = "Ivo Matić",
                    RazredUcenika = "3.h"
                },
                new Ucenik
                {
                    ImePrezimeUcenika = "Petra Petrić",
                    RazredUcenika = "4.h"
                }
            };

            #region LINQ UPIT:

            var upit = from prof in listaProfesora
                from ucenik in popisNajboljihUcenika
                where ucenik.RazredUcenika == prof.JeRazrednikRazredu
                //Nice one here :)
                select new
                {
                    ucenik.ImePrezimeUcenika,
                    ucenik.RazredUcenika,
                    prof.ImePrezimeProfesora
                };


            foreach (var s in upit)
            {
                Console.WriteLine($"Uceniku {s.ImePrezimeUcenika} iz razreda {s.RazredUcenika}" +
                                  $" razrednik je {s.ImePrezimeProfesora}");
            }

            Console.ReadKey();

        #endregion

        }
    }
}
