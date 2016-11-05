using System;
using System.Collections.Generic;

namespace AlgoDM
{
    interface ISolution
    {
        /// <summary>
        ///  Fonction qui calcule l'alignement optimal de deux adn et qui donne son cout.
        /// </summary>
        /// <returns>le chemin triée emprunter par l'algorithme(permet l'affichage de l'alignement optimal)</returns>
       List<Tuple<int,int>> Execute(Dna dna1, Dna dna2);
    }
}
