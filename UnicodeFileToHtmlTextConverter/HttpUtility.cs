namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    /// <summary>
    /// Implementação da interface IHttpUtility para codificação HTML.
    /// </summary>
    public class HttpUtility : IHttpUtility
    {
        /// <summary>
        /// Codifica uma linha de texto para uso seguro em HTML.
        /// </summary>
        /// <param name="line">A linha de texto a ser codificada.</param>
        /// <returns>A linha de texto codificada para HTML.</returns>
        public string HtmlEncode(string line)
        {
            // Substitui os caracteres especiais por suas entidades HTML equivalentes
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&apos;");

            return line;
        }
    }
}