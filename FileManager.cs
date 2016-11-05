
namespace AlgoDM
{
    static class FileManager
    {
        /// <summary>
        /// Fonction retournant les adn correspondant au fichier adn
        /// </summary>
        /// <param name="pathFile"> le chemin du fichier</param>
        /// <returns></returns>
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
