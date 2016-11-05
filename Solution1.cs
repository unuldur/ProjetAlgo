using System;
using System.Collections.Generic;

namespace AlgoDM
{
    class Solution1 : ISolution
    {
        private readonly Cout1 _cout;
        public Solution1(Dictionary<string, int> values)
        {
            _cout = new Cout1(values);
        }

        /// <summary>
        ///  Fonction qui calcule l'alignement optimal de deux adn et qui donne son cout.
        /// </summary>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <param name="f"> tableau contenant toute les meilleurs valeurs de cout entre 0,0 et i,j</param>
        /// <returns>le chemin triée emprunter par l'algorithme(permet l'affichage de l'alignement optimal)</returns>
        public List<Tuple<int,int>> Execute(Dna dna1, Dna dna2,out int[,] f)
        {
            List<Tuple<int, int>> chemin = new List<Tuple<int, int>>();
            _cout.Cout(dna1.GetLenght()-1, dna2.GetLenght()-1, dna1, dna2);
            f = _cout.F;
            int i = dna1.GetLenght() -1;
            int j = dna2.GetLenght() -1;
            while (i != 0 || j != 0)
            {
                chemin.Add(new Tuple<int, int>(i,j));
                int gapi = 999999999;
                int gapj = 999999999;
                int gapij = 999999999;
                if (i != 0)
                {
                    gapi = f[i - 1, j];
                }
                if (j != 0)
                {
                    gapj = f[i, j - 1];
                }
                if (i != 0 && j != 0)
                {
                    gapij = f[i - 1, j - 1];
                }
                if (gapi < gapj && gapi < gapij)
                {
                    i--;
                    continue;
                }
                if (gapj < gapij)
                {
                    j--;
                    continue;
                }
                i--;
                j--;
            }
            return chemin;
        }

        /// <summary>
        ///  Fonction qui calcule l'alignement optimal de deux adn et qui donne son cout.
        /// </summary>
        /// <returns>le chemin triée emprunter par l'algorithme(permet l'affichage de l'alignement optimal)</returns>
        public List<Tuple<int, int>> Execute(Dna dna1, Dna dna2)
        {
            int[,] f;
            var l = Execute(dna1, dna2, out f);
            Console.WriteLine("Cout : "+f[dna1.GetLenght()-1,dna2.GetLenght() - 1]);
            l.Sort(delegate (Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x.Item1 == y.Item1)
                {
                    return x.Item2 - y.Item2;
                }
                return x.Item1 - y.Item1;
            });
            return l;
        }
    }
}
