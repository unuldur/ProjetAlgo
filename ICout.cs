

namespace AlgoDM
{
    interface ICout
    {
        /// <summary>
        /// Fontions qui calcule le cout optimal d'un alignement.
        /// </summary>
        int Cout(int i, int j, Dna dna1, Dna dna2);
    }
}
