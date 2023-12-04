namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    /// <summary>
    /// Interface que define métodos para codificação HTML.
    /// </summary>
    public interface IHttpUtility
    {
        /// <summary>
        /// Codifica uma string para uso seguro em HTML.
        /// </summary>
        /// <param name="line">A string a ser codificada.</param>
        /// <returns>A string codificada para uso seguro em HTML.</returns>
        string HtmlEncode(string line);
    }
}