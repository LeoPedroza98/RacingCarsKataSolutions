namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    /// <summary>
    /// Converte o conteúdo de um arquivo Unicode para texto HTML.
    /// </summary>
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly IHttpUtility _httpUtility;
        private readonly ITextReader _textReader;

        /// <summary>
        /// Construtor que aceita o caminho completo do arquivo como parâmetro e utiliza as implementações padrão de IHttpUtility e ITextReader.
        /// </summary>
        /// <param name="fullFilenameWithPath">Caminho completo do arquivo Unicode.</param>
        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
            : this(new HttpUtility(), new FileTextReader(fullFilenameWithPath))
        {
        }

        /// <summary>
        /// Construtor que permite a injeção de dependência de IHttpUtility e ITextReader.
        /// </summary>
        /// <param name="httpUtility">Instância de IHttpUtility a ser utilizada.</param>
        /// <param name="textReader">Instância de ITextReader a ser utilizada.</param>
        public UnicodeFileToHtmlTextConverter(IHttpUtility httpUtility, ITextReader textReader)
        {
            _httpUtility = httpUtility;
            _textReader = textReader;
        }

        /// <summary>
        /// Converte o conteúdo do arquivo Unicode para uma representação HTML.
        /// </summary>
        /// <returns>Conteúdo do arquivo convertido para HTML.</returns>
        public string ConverteHtml()
        {
            using (var reader = _textReader.GetTextReader())
            {
                var html = string.Empty;
                var line = reader.ReadLine();
                
                while (line != null)
                {
                    html += _httpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = reader.ReadLine();
                }

                return html;
            }
        }
    }
}

