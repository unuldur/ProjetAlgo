using System.Collections.Generic;

namespace AlgoDM
{
    class Cout2BisIterative : ICout
    {
        private readonly Dictionary<string, int> _gapValue;
        public Cout2BisIterative(Dictionary<string, int> gapValue)
        {
            _gapValue = gapValue;
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre i,j et m,n
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        public int Cout(int i, int j, Dna dna1, Dna dna2)
        {
            return IterativeCout(i, j, dna1.GetLenght() - 1, dna1, dna2)[dna2.GetLenght() - j - 1];
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre i,j et m,n en iteratif
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="m"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        private int[] IterativeCout(int i, int j, int m, Dna dna1, Dna dna2)
        {
            int[] k = new int[dna2.GetLenght() - j];
            int[] kMoinsUn = new int[dna2.GetLenght() - j];

            for (int l = 0; l < k.Length; l++)
            {
                kMoinsUn[l] = _gapValue["gap"] * l;
            }

            for (int w = i + 1; w <= m; w++)
            {
                int gapj = 999999;
                int gapij = 999999;
                k = new int[dna2.GetLenght() - j];

                for (int l = 0; l < k.Length; l++)
                {
                    if (l != 0)
                    {
                        gapj = k[l - 1];
                        gapij = kMoinsUn[l - 1];
                    }
                    var gapi = kMoinsUn[l];

                    int myCout = _gapValue["different"];
                    if (_gapValue.ContainsKey(dna1.GetProteine(w) + "" + dna2.GetProteine(l + j)))
                    {
                        myCout = _gapValue[dna1.GetProteine(w) + "" + dna2.GetProteine(l + j)];
                    }
                    if (dna1.GetProteine(w) == dna2.GetProteine(l + j))
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
