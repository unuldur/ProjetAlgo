using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDM
{
    class Dna
    {

        private string _dna;

        public Dna(string dna)
        {
            _dna = dna;
            _dna = " "+String.Join("",dna.Split(' '));
        }

        public char GetProteine(int i)
        {
            return _dna[i];
        }

        public void AddGap(int index, bool replace)
        {
            if (!replace)
            {
                _dna = _dna.Insert(index, "-");
            }
            else
            {
                _dna = _dna.Substring(0, index - 1) + "-" + _dna.Substring(index+1);
            }
        }

        public int GetLenght()
        {
            return _dna.Length;
        }

        public override string ToString()
        {
            return _dna;
        }
    }
}
