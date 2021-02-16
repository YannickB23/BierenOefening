using BierenLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BierenOefening
{
    class Program
    {
        static void Main(string[] args)
        {
            BierenService service = new BierenService();
            Console.WindowWidth = 160;
            Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", "Nummer", "Naam", "Alcohol",
            "Brouwer");
            foreach (Bier bier in service.Bieren)
            {
                Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam,
                bier.Alcohol, bier.Brouwer);
            }

            //List<Bier> bieren = new List<Bier>();

            List<Bier> bierenVanJupiler = bieren.Where(m => m.Brouwer.ToLower() == "jupiler").ToList();
            foreach (var bier in bierenVanJupiler)
            {
                Console.WriteLine(bier.Brouwer);
            }

            var queryAlcohol = bieren.Where(a => a.Alcohol > 7);
            foreach (var bier in queryAlcohol)
            {
                Console.WriteLine($"\nBier met meer dan 7% alcohol: {bier.Naam}");
            }

        }
        //public static void Show(IEnumerable<Bier> bieren)
        //{
        //    foreach (var bier in bieren)
        //    {
        //        Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam, bier.Alcohol, bier.Brouwer);
        //    }
        //}
    }
}
