using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    /// <summary>
    /// Classe responsável por ler texto de um arquivo.
    /// </summary>
    public class FileTextReader : ITextReader
    {
        /// <summary>
        /// Caminho completo do arquivo a ser lido.
        /// </summary>
        private readonly string _fullFilenameWithPath;

        /// <summary>
        /// Construtor da classe `FileTextReader`.
        /// </summary>
        /// <param name="fullFilenameWithPath">Caminho completo do arquivo a ser lido.</param>
        public FileTextReader(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        /// <summary>
        /// Obtém um leitor de texto para o arquivo especificado.
        /// </summary>
        /// <returns>Leitor de texto para o arquivo.</returns>
        public TextReader GetTextReader()
        {
            // Abre e retorna um leitor de texto para o arquivo usando o caminho fornecido.
            return File.OpenText(_fullFilenameWithPath);
        }
    }
}