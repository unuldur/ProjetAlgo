using System;
using System.Collections.Generic;

namespace AlgoDM
{
    class Solution2 : ISolution
    {
        private readonly Solution1 _sol1;
        private readonly ICout _cout2;
        private readonly ICout _cout2Bis;

        public Solution2(Dictionary<string, int> values, bool iterative)
        {
            _sol1 = new Solution1(values);
            if (iterative)
            {
                _cout2 = new Cout2Iterative(values);
                _cout2Bis = new Cout2BisIterative(values);
            }
            else
            {
                _cout2 = new Cout2(values);
                _cout2Bis = new Cout2Bis(values);
            }
        }

        /// <summary>
        ///  Fonction qui calcule l'alignement optimal de deux adn et qui donne son cout.
        /// </summary>
        /// <returns>le chemin triée emprunter par l'algorithme(permet l'affichage de l'alignement optimal)</returns>
        public List<Tuple<int, int>> Execute(Dna dna1, Dna dna2)
        {
            var l = new List<Tuple<int, int>>();
            int cout = Sol2(0, 0, dna1.GetLenght() - 1, dna2.GetLenght() - 1, l, dna1, dna2);
            Console.WriteLine("Cout : " + cout);
            l.Sort(delegate(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x.Item1 == y.Item1)
                {
                    return x.Item2 - y.Item2;
                }
                return x.Item1 - y.Item1;
            });
            return l;
        }

        /// <summary>
        ///  Fonction recursive qui calcule l'alignement optimal de deux adn et qui donne son cout.
        /// </summary>
        /// <param name="k1">i min</param>
        /// <param name="l1">j min</param>
        /// <param name="k2">i max</param>
        /// <param name="l2">j max</param>
        /// <param name="l">le chemin emprunter par l'algorithme(permet l'affichage de l'alignement optimal)</param>
        /// <param name="x">l'adn a tester</param>
        /// <param name="y">l'adn a tester 2</param>
        /// <returns>le cout de l'alignement optimal</returns>
        private int Sol2(int k1, int l1, int k2, int l2, List<Tuple<int, int>> l, Dna x, Dna y)
        {
            if (k2 - k1 > 0 || l2 - l1 > 0)
            {
                if (k2 - k1 <= 2)
                {
                    Dna x2A = new Dna(x, k1 + 1, k2 + 1);
                    Dna y2A = new Dna(y, l1 + 1, l2 + 1);
                    int[,] f2A;
                    List<Tuple<int, int>> prov = _sol1.Execute(x2A, y2A, out f2A);
                    foreach (var tuple in prov)
                    {
                        l.Add(new Tuple<int, int>(tuple.Item1 + k1, tuple.Item2 + l1));
                    }

                    return f2A[k2 - k1, l2 - l1];
                }
                if (l2 - l1 <= 2)
                {
                    Dna x2B = new Dna(x, k1 + 1, k2 + 1);
                    Dna y2B = new Dna(y, l1 + 1, l2 + 1);
                    int[,] f2B;
                    List<Tuple<int, int>> prov = _sol1.Execute(x2B, y2B, out f2B);
                    foreach (var tuple in prov)
                    {
                        l.Add(new Tuple<int, int>(tuple.Item1 + k1, tuple.Item2 + l1));
                    }
                    return f2B[k2 - k1, l2 - l1];
                }
                int j = l1 + (l2 - l1)/2;
                int ie = k1;
                int valmin = _cout2.Cout(k1, j, x, y) + _cout2Bis.Cout(k1, j, x, y);
                for (int i = k1 + 1; i < k2; i++)
                {
                    int val = _cout2.Cout(i, j, x, y) + _cout2Bis.Cout(i, j, x, y);
                    if (valmin > val)
                    {
                        valmin = val;
                        ie = i;
                    }
                }
                return Sol2(k1, l1, ie, j, l, x, y) + Sol2(ie, j, k2, l2, l, x, y);
            }
            return 0;
        }
    }
}