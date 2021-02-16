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
            #region alle bieren
            //Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", "Nummer", "Naam", "Alcohol",
            //"Brouwer");
            //foreach (Bier bier in service.Bieren)
            //{
            //    Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam,
            //    bier.Alcohol, bier.Brouwer);
            //}
            #endregion

            List<Bier> bieren = service.Bieren;
            /*BIEREN VAN JUPILER*/
            var bierenjupiler = bieren.Where(m => m.Brouwer.ToLower() == "jupiler").ToList();
            Show(bierenjupiler);

            /*BIEREN MET MEER DAN 7% ALCOHOL*/
            //var alcoholZeven = bieren.Where(a => a.Alcohol > 7).ToList();
            //Show(alcoholZeven);

            /*BIEREN MET DELHAIZE ALS BROUWER*/
            //var brouwerDelhaize = bieren.Where(m => m.Brouwer.ToLower().Contains("delhaize")).ToList();
            //Show(brouwerDelhaize);

            /*BIER MET NUMMER 120*/
            //var bierNmr = bieren.Where(n => n.BierNr == 120);
            //Show(bierNmr);

            /*BIEREN VAN BROUWER JUPILER EN <=5% ALCOHOL*/
            //var jupVijf = bieren.Where(b => b.Brouwer.ToLower() == "jupiler")
            //                            .Where(a => a.Alcohol <= 5).ToList();
            //Show(jupVijf);

            /*BIEREN VAN BROUWERS JUPILER, PALM, ARTOIS*/
            //var drieBrouwers = bieren.Where(b => b.Brouwer.ToLower() == "jupiler" || b.Brouwer.ToLower() == "palm" || b.Brouwer.ToLower() == "artois")
            //                                 .OrderBy(b => b.Brouwer).ToList();
            //Show(drieBrouwers);

            /*GEMMIDELDE ALCOHOLPERCENTAGE*/
            var brouwersGroupedBy = bieren.GroupBy(b => b.Brouwer);
            Dictionary<string, decimal> results = new Dictionary<string, decimal>();

            foreach (var group in brouwersGroupedBy)
            {
                results.Add(group.Key, group.Average(a => a.Alcohol));
            }
            Show(results);


            Console.ReadLine();
        }
        public static void Show(IEnumerable<Bier> bieren)
        {
            foreach (var bier in bieren)
            {
                Console.WriteLine("{0,-20}{1,-100}{2,-20}{3,-20}", bier.BierNr, bier.Naam, bier.Alcohol, bier.Brouwer);
            }
        }

        public static void Show(Dictionary<string, decimal> dictionary)
        {
            foreach (var item in dictionary.OrderByDescending(x => x.Value))
            {
                Console.WriteLine(item.Key + " "+ item.Value.ToString("#.##"));
            }
        }
    }
}

