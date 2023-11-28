using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak2.LINQ_to_SQL.SQLClasses;

namespace Zadatak2.LINQ_to_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();

            //Get table
            Table<student> studenti = dbcontext.GetTable<student>();
            Table<ispit> ispiti = dbcontext.GetTable<ispit>();

            //Get students
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Zadatak 3. - prisutni studenti");
            Console.WriteLine("-----------------------------------");
            var upit = from s in studenti
                       select new
                       {
                           sID = s.stud_ID,
                           ime = s.ime + " " + s.prezime
                       };
            
            foreach (var s in upit)
            {
                Console.WriteLine($"ID: {s.sID} - {s.ime}");
            }

            //Zadatak 4.
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Zadatak 4.");
            Console.WriteLine("-----------------------------------");

            var upit1 = from s in studenti
                where ispiti.Any(ispit => ispit.stud_ID == s.stud_ID)
                select new
                {
                    s.ime,
                    s.prezime,
                    NaIspitima = string.Join(", ", ispiti.Where(ispit => ispit.stud_ID == s.stud_ID).Select(ispit => ispit.pred_ID))

                };

            foreach (var s in upit1)
            {
                Console.WriteLine($"Student: {s.ime} {s.prezime}; je bio na ispitima s IDem: {s.NaIspitima}");
            }

            
            Console.WriteLine("-----------------------------------");
            var upit2 = from s in studenti
                where ispiti.Any(ispit => ispit.stud_ID == s.stud_ID && ispit.ocjena == 1)
                select new
                {
                    s.ime,
                    s.prezime,
                    NaIspitima = string.Join(", ", ispiti.Where(ispit => ispit.stud_ID == s.stud_ID).Select(ispit => ispit.pred_ID))

                };
            Console.WriteLine("Zadatak 4. - Pali borci:");
            foreach (var s in upit2)
            {
                Console.WriteLine($"Student: {s.ime} {s.prezime}; je PAO na ispitima s IDem: {s.NaIspitima}");
            }


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Zadatak 5.: ");
            var spAllExcelentStResult = dbcontext.AllExcelentStudentsGet();
            foreach (var s in spAllExcelentStResult)
            {
                Console.WriteLine($"{s.stud_ID}:{s.ime} {s.prezime} ima prosjek {s.prosjek}");
            }
            Console.ReadKey();
        }
    }
}
