using System.Collections.Generic;

namespace AlgoDM
{
    class Cout2 : ICout
    {
        private readonly Dictionary<string, int> _gapValue;
        public Cout2(Dictionary<string, int> gapValue)
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
            return RecursiveCout(i, dna1, dna2)[j];
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre 0,0 et i,j en recursive
        /// </summary>
        /// <param name="i"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        private int[] RecursiveCout(int i, Dna dna1, Dna dna2)
        {
            int[] k = new int[dna2.GetLenght()];
            if (i == 0)
            {
                for (int j = 0; j < k.Length; j++)
                {
                    k[j] = _gapValue["gap"]*j;
                }
                return k;

            }

            int gapj = 999999;
            int gapij = 999999;
            var kMoinsUn = RecursiveCout(i - 1, dna1, dna2);
            
            for (int j = 0; j < k.Length; j++)
            {
                if (j != 0)
                {
                    gapj = k[j - 1];
                    gapij = kMoinsUn[j - 1];
                }
                var gapi = kMoinsUn[j];

                int myCout = _gapValue["different"];
                if (_gapValue.ContainsKey(dna1.GetProteine(i) + "" + dna2.GetProteine(j)))
                {
                    myCout = _gapValue[dna1.GetProteine(i) + "" + dna2.GetProteine(j)];
                }
                if (dna1.GetProteine(i) == dna2.GetProteine(j))
                {
                    myCout = 0;
                }

                gapi += _gapValue["gap"];
                gapj += _gapValue["gap"];
                gapij += myCout;

                if (gapi < gapj && gapi < gapij)
                {
                    k[j] = gapi;
                    continue;
                }
                if (gapj < gapij)
                {
                    k[j] = gapj;
                    continue;
                }
                k[j] = gapij;
            }

            return k;
        }
    }
}
