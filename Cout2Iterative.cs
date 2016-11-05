
using System.Collections.Generic;

namespace AlgoDM
{
    class Cout2Iterative : ICout
    {
        private readonly Dictionary<string, int> _gapValue;
        public Cout2Iterative(Dictionary<string, int> gapValue)
        {
            _gapValue = gapValue;
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre 0,0 et i,j
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        public int Cout(int i, int j, Dna dna1, Dna dna2)
        {
            return IterativeCout(i, j, dna1, dna2)[j];
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre 0,0 et i,j en iteratif
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        private int[] IterativeCout(int i, int j, Dna dna1, Dna dna2)
        {
            int[] k = new int[j + 1];
            int[] kMoinsUn = new int[j + 1];

            for (int l = 0; l < k.Length; l++)
            {
                kMoinsUn[l] = _gapValue["gap"] * l;
            }

            for (int w = 1; w <= i; w++)
            {
                int gapj = 999999;
                int gapij = 999999;
                k = new int[j + 1];

                for (int l = 0; l < k.Length; l++)
                {
                    if (l != 0)
                    {
                        gapj = k[l - 1];
                        gapij = kMoinsUn[l - 1];
                    }
                    var gapi = kMoinsUn[l];

                    int myCout = _gapValue["different"];
                    if (_gapValue.ContainsKey(dna1.GetProteine(w) + "" + dna2.GetProteine(l)))
                    {
                        myCout = _gapValue[dna1.GetProteine(w) + "" + dna2.GetProteine(l)];
                    }
                    if (dna1.GetProteine(w) == dna2.GetProteine(l))
                    {
                        myCout = 0;
                    }

                    gapi += _gapValue["gap"];
                    gapj += _gapValue["gap"];
                    gapij += myCout;

                    if (gapi < gapj && gapi < gapij)
                    {
                        k[l] = gapi;
                        continue;
                    }
                    if (gapj < gapij)
                    {
                        k[l] = gapj;
                        continue;
                    }
                    k[l] = gapij;
                }
                kMoinsUn = k;
            }



            return kMoinsUn;
        }
    }
}
