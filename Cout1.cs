using System;
using System.Collections.Generic;

namespace AlgoDM
{
    class Cout1 :ICout
    {
        private readonly Dictionary<string,int> _gapValue;

        public Cout1(Dictionary<string, int> gapValue)
        {
            _gapValue = gapValue;
        }

        public int Cout(int i, int j, Dna dna1, Dna dna2, int[,] f)
        {
            if (j == 0 && i == 0)
            {
                f[0, 0] = 0;
                return 0;
            }
            int gapi = 999999;
            int gapj = 999999;
            int gapij = 999999;

            if (i > 0)
            {
                gapi = f[i - 1, j] != 0 ? f[i - 1, j] : Cout(i - 1, j, dna1, dna2, f);
            }
            if (j > 0)
            {
                gapj = f[i, j - 1] != 0 ? f[i, j -1] : Cout(i, j - 1, dna1, dna2, f);
            }
            if (i > 0 && j > 0)
            {
                gapij = f[i - 1, j - 1] != 0 ? f[i - 1, j - 1] : Cout(i - 1, j - 1, dna1, dna2, f);
            }

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
                f[i, j] = gapi;
                return f[i, j];
            }
            if (gapj < gapij)
            {
                f[i, j] = gapj;
                return f[i,j];
            }
            
            f[i, j] = gapij;
            return f[i, j];
        }
    }
}
