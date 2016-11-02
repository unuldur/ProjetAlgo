using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDM
{
    abstract class Solution
    {
        protected ICout Cout;
        public abstract void Execute(Dna dna1, Dna dna2);
        protected Solution(ICout cout)
        {
            Cout = cout;
        }
    }
}
