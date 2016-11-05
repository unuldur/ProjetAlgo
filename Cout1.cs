using System.Collections.Generic;

namespace AlgoDM
{
    class Cout1 : ICout
    {
        private readonly Dictionary<string,int> _gapValue;

        public int[,] F { get; private set; }

        public Cout1(Dictionary<string, int> gapValue)
        {
            _gapValue = gapValue;
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre 0,0 et i,j et met les autres valeurs dans F 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        private void RecursiveCout(int i, int j, Dna dna1, Dna dna2)
        {
            if (j == 0 || i == 0)
            {
                if (i == 0 && j == 0)
                {
                    F[0, 0] = 0;
                    return;
                }
                if (i == 0)
                {
                    F[i, j] = j * _gapValue["gap"];
                    return;
                }
                F[i, j] = i * _gapValue["gap"];
                return;

            }

            if (F[i - 1, j] != 0)
            {
                RecursiveCout(i - 1, j, dna1, dna2);
            }
            var gapi = F[i - 1, j];

            if (F[i, j - 1] != 0)
            {
                RecursiveCout(i, j - 1, dna1, dna2);
            }
            var gapj = F[i, j - 1];

            if (F[i - 1, j - 1] != 0)
            {
                RecursiveCout(i - 1, j - 1, dna1, dna2);
            }
            var gapij = F[i - 1, j - 1];

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
                F[i, j] = gapi;
                return;
            }
            if (gapj < gapij)
            {
                F[i, j] = gapj;
                return;
            }

            F[i, j] = gapij;
        }

        /// <summary>
        ///  Obtient le cout du chemin le plus court entre 0,0 et i,j et met les autres valeurs dans F
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="dna1"></param>
        /// <param name="dna2"></param>
        /// <returns></returns>
        public int Cout(int i, int j, Dna dna1, Dna dna2)
        {
            F = new int[dna1.GetLenght(), dna2.GetLenght()];
            for (int k = 0; k < dna1.GetLenght(); k++)
            {
                for (int l = 0; l < dna2.GetLenght(); l++)
                {
                    F[k, l] = -1;
                }
            }
            RecursiveCout(i, j, dna1, dna2);
            return F[i,j];
        }
    }
}
