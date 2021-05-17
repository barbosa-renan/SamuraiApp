using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        public static void Main(string[] args)
        {
            _context.Database.EnsureCreated();

            GetSamurais("Before Add");

            AddSamurai();

            GetSamurais("After Add");

            Console.Write("Press any key:");
            Console.ReadKey();
        }

        private static void GetSamurais(string v)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{v}: Samurai count is {samurais.Count}");

            foreach (var samurai in samurais)
                Console.WriteLine(samurai.Name);
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Renan" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
    }
}
