using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1._LINQ_upiti_nad_objektima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listaStudenata = new List<Student>()
            {
                new Student()
                {
                    Id = 1, Ime = "Pero"
                },
                new Student()
                {
                    Id = 2, Ime = "Marko"
                },
                new Student()
                {
                    Id = 3, Ime = "Luka"
                },
                new Student()
                {
                    Id = 4, Ime = "Borna"
                },
                new Student()
                {
                    Id = 5, Ime = "NePrisutan"
                }
            };

            var listaIspita = new List<Ispit>()
            {
                new Ispit()
                {
                    ImePredmeta = "Matematika", DatumIspita = "27.11.2023.", Rezultati = new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(1, 1),
                        new Tuple<int, int>(2, 5),
                        new Tuple<int, int>(3, 2),
                        new Tuple<int, int>(4, 1),
                    }
                },
                new Ispit()
                {
                    ImePredmeta = "Fizika", DatumIspita = "24.11.2023.", Rezultati = new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(1, 5),
                        new Tuple<int, int>(2, 4),
                        new Tuple<int, int>(4, 3),
                    }
                },
                new Ispit()
                {
                    ImePredmeta = "CSH", DatumIspita = "27.11.2019.", Rezultati = new List<Tuple<int, int>>()
                    {
                        new Tuple<int, int>(2, 1),
                        new Tuple<int, int>(3, 1),
                        new Tuple<int, int>(4, 1),
                    }
                }
            };

            #region Ispis svih studenata:

            var upit = from stud in listaStudenata
                select new { stud.Ime, stud.Id };

            foreach (var stud in upit)
            {
                Console.WriteLine(stud.Ime + " ima id: " + stud.Id);
            }

            #endregion

            #region Ispis studnata koji su bili prisutni na ispitima

            var studentsWithExams = from student in listaStudenata
                where listaIspita.Any(ispit => ispit.Rezultati.Any(result => result.Item1 == student.Id))
                select new{
                    student.Ime,
                    student.Id,
                    Ispiti = string.Join(", ", listaIspita.Where(ispit => ispit.Rezultati.Any(rezultat => rezultat.Item1 == student.Id && rezultat.Item2 == 1))
                        .Select(ispit => ispit.ImePredmeta))
                };

            #endregion

            Console.WriteLine("Na ispitu su bili: ");
            foreach (var student in studentsWithExams)
            {
                Console.WriteLine($"Student {student.Ime};Id:{student.Id} je bio na ispitu!");
                Console.WriteLine("Nije polozio sljedeće ispite: " + student.Ispiti);
            }

            Console.ReadKey();
        }
    }
}
