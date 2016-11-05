using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoDM
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.EnumerateFiles("donnees/", "*.adn");
            Console.WriteLine("Choisissez votre fichier de données : ");
            int i = 1;
            foreach (var file in files)
            {
                Console.WriteLine(i + " => " + file);
                i++;
            }

            int nbLine = -1;
            while (nbLine <= 0 || nbLine > files.Count())
            {
                Console.WriteLine();
                Console.WriteLine("Taper un numéro de ligne :");
                var nbLineS = Console.ReadLine();
                try
                {
                    nbLine = int.Parse(nbLineS);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ce n'est pas un numéro ! \nEssaye encore !");
                }
            }

            Console.WriteLine();
            Dna[] dnas = FileManager.GetDna(files.ElementAt(nbLine - 1));

            Dictionary<string, int> _values = new Dictionary<string, int>();

            _values["gap"] = ReadInt("Taper la valeur du gap");
            Console.WriteLine();
            _values["different"] = ReadInt("Taper la valeur d'une difference par défaut");
            
            Console.WriteLine();
            int choix = -1;
            while (choix < 1 || choix > 2)
            {
                choix = ReadInt("Voulez vous taper des valeur spécifique à certain couple de proteine ?\n1 => Oui\n2 =>non");
            }

            int nbCouple = ReadInt("Pour Combien de couple ?");

            for (int j = 0; j < nbCouple; j++)
            {
                Console.WriteLine();
                Console.WriteLine("Taper le "+ (j+1)+" couple :");
                var couple = Console.ReadLine();
                if (couple.Length != 2 || couple[0] != 'A' && couple[0] != 'C' && couple[0] != 'G' && couple[0] != 'T' ||
                    couple[1] != 'A' && couple[1] != 'C' && couple[1] != 'G' && couple[1] != 'T')
                {
                    Console.WriteLine("ce n'est pas un couple de proteine(ACGT)");
                    continue;
                }
                Console.WriteLine();
                int value = ReadInt("Taper la valeur de ce couple :");
                _values[couple] = value;
                Console.WriteLine();
            }

            Console.WriteLine();
            choix = -1;
            while (choix != 1 && choix != 2)
            {
                choix = ReadInt("Voulez vous quel type d'algoritme :\n1 => Cout\n2 => Solution");
            }

            if (choix == 1)
            {
                ICout cout = null;
                Console.WriteLine();
                choix = -1;
                while (choix < 1 || choix > 5)
                {
                    choix = ReadInt("Voulez vous quel algoritme de cout :\n1 => Cout1\n2 => Cout2\n3 => Cout2Bis\n4 => Cout2Iterative\n5 => Cout2BisIterative");
                }
                switch (choix)
                {
                    case 1:
                        cout = new Cout1(_values);
                        break;
                    case 2:
                        cout = new Cout2(_values);
                        break;
                    case 3:
                        cout = new Cout2Bis(_values);
                        break;
                    case 4:
                        cout = new Cout2Iterative(_values);
                        break;
                    case 5:
                        cout = new Cout2BisIterative(_values);
                        break;
                }

                i = ReadInt("Choisissez i :");
                int j = ReadInt("Choisissez j :");
                Console.WriteLine();
                AfficherDna(dnas);
                Console.WriteLine();
                Console.WriteLine(cout.Cout(i,j,dnas[0],dnas[1]));
            }
            else
            {
                ISolution solution = null;
                Console.WriteLine();
                choix = -1;
                while (choix < 1 || choix > 2)
                {
                    choix = ReadInt("Voulez vous quel algoritme de solution :\n1 => Solution1\n2 => Solution2");
                }
                switch (choix)
                {
                    case 1:
                        solution = new Solution1(_values);
                        break;
                    case 2:
                        Console.WriteLine();
                        while (choix < 1 || choix > 2)
                        {
                            choix = ReadInt("Voulez vous une version iterative :\n1 => Oui\n2 => Non");
                        }
                        solution = new Solution2(_values, choix == 1);
                        break;
                }
                Console.WriteLine();
                AfficherDna(dnas);
                var chemin = solution.Execute(dnas[0], dnas[1]);
                Console.WriteLine();
                while (choix < 1 || choix > 2)
                {
                    choix = ReadInt("Voulez vous une affichez l'alignement optimal :\n1 => Oui\n2 => Non");
                }
                if (choix == 1)
                {
                    Resort.PrintOptimisedAlignement(dnas[0], dnas[1],chemin);
                }
            }

            

            Console.ReadKey();
        }

        /// <summary>
        /// obtient un int taper sur la console
        /// </summary>
        /// <param name="msg">message a afficher</param>
        /// <returns></returns>
        private static int ReadInt(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                var str = Console.ReadLine();
                try
                {
                    return int.Parse(str);
                }
                catch (FormatException)
                {
                    
                    Console.WriteLine("Ce n'est pas un entier ! \nEssaye encore !");
                }
            }
        }

        /// <summary>
        /// Demande l'affichage des adns
        /// </summary>
        /// <param name="dnas">adns a afficher</param>
        /// <returns></returns>
        private static void AfficherDna(Dna[] dnas)
        {
            int choix = -1;
            while (choix < 1 || choix > 2)
            {
                choix = ReadInt("Voulez vous une affichez les adns :\n1 => Oui\n2 => Non");
            }
            if (choix == 1)
            {
                foreach (var dna in dnas)
                {
                    Console.WriteLine(dna);
                }
            }
        }
    }
}