using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDM
{
    class FileManager
    {
        public static Dna[] GetDna(string pathFile)
        {
            Dna[] dnas = new Dna[2];
            string[] lines = System.IO.File.ReadAllLines(pathFile);
            dnas[0] = new Dna(lines[2]);
            dnas[1] = new Dna(lines[3]);
            return dnas;
        }
    }
}
