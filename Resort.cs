using System;
using System.Collections.Generic;

namespace AlgoDM
{
    static class Resort
    {
        /// <summary>
        /// Affiche l'algnement obtenue a partir de l
        /// </summary>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <param name="l"> liste de pair d'entier triée permettant l'affichage de l'algnement entre dna1 et dna2</param>
        public static void PrintOptimisedAlignement(Dna dna1, Dna dna2, List<Tuple<int,int>> l)
        {
            int oldI = 0, oldJ = 0;
            string optimisedDna1 = "";
            string optimisedDna2 = "";
            foreach (var tuple in l)
            {
                var difI = tuple.Item1 - oldI;
                var difJ = tuple.Item2 - oldJ;
                oldI = tuple.Item1;
                oldJ = tuple.Item2;
                
                if (difI == 0)
                {
                    optimisedDna1 += "_";
                    optimisedDna2 += dna2.GetProteine(tuple.Item2);
                    continue;
                }
                if (difJ == 0)
                {
                    optimisedDna2 += "_";
                    optimisedDna1 += dna1.GetProteine(tuple.Item1);
                    continue;
                }
                optimisedDna1 += dna1.GetProteine(tuple.Item1);
                optimisedDna2 += dna2.GetProteine(tuple.Item2);
            }
            Console.WriteLine(optimisedDna1);
            Console.WriteLine(optimisedDna2);
        }
    }
}
