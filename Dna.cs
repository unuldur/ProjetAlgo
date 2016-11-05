

namespace AlgoDM
{
    class Dna
    {

        private readonly string _dna;
        public Dna(string dna)
        {
            _dna = " "+dna.Replace(" ", "");
        }

        public Dna(Dna dna, int debut,int fin)
        {
            _dna = " ";
            for (int i = debut; i < fin; i++)
            {
                _dna += dna.GetProteine(i);
            }
        }

        /// <summary>
        /// Permet d'obtenir la proteine a l'emplacement i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public char GetProteine(int i)
        {
            return _dna[i];
        }

        /// <summary>
        /// etourne la longueur du brin d'adn
        /// </summary>
        /// <returns></returns>
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
