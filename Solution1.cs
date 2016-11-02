using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDM
{
    class Solution1 : Solution
    {
        
        public Solution1(ICout cout) : base(cout)
        {
            
        }

        public override void Execute(Dna dna1, Dna dna2)
        {
            int[,] f =new int[dna1.GetLenght(),dna2.GetLenght()];
            Cout.Cout(dna1.GetLenght()-1, dna2.GetLenght()-1, dna1, dna2, f);
            int i = dna1.GetLenght() -1;
            int j = dna2.GetLenght() -1;
            String dna1dif = "";
            String dna2dif = "";
            while (i != 0 || j != 0)
            {
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
                    dna2dif += "- ";
                    dna1dif += dna1.GetProteine(i + 1)+" ";
                    continue;
                }
                if (gapj < gapij)
                {
                    j--;
                    dna2dif += dna2.GetProteine(j + 1)+" ";
                    dna1dif += "- ";
                    continue;
                }
                i--;
                j--;
                dna1dif += dna1.GetProteine(i + 1)+" ";
                dna2dif += dna2.GetProteine(j + 1)+" ";
            }
            
            Console.WriteLine(Reverse(dna1dif));
            Console.WriteLine(Reverse(dna2dif));
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
