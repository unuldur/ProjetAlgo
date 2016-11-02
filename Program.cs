using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDM
{
    class Program
    {
        static void Main(string[] args)
        {
            Dna[] dnas = FileManager.GetDna("C: /Users/Juju_et_yaya/Documents/Travail/algo/donnees/Inst_0000010_44.adn");


            Dictionary<string, int> _values = new Dictionary<string, int>();
            _values["gap"] = 2;
            _values["AT"] = 3;
            _values["TA"] = 3;
            _values["CG"] = 3;
            _values["GC"] = 3;
            _values["different"] = 4;
            Console.WriteLine(dnas[0].ToString());
            Console.WriteLine(dnas[1].ToString());
            Solution1 sol =new Solution1(new Cout1(_values));
            sol.Execute(dnas[0],dnas[1]);
            Console.ReadKey();
        }
    }
}
