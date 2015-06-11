namespace Project.Web.Infrastructure.Sanitizer
{
    using Ganss.XSS;

    public class Sanitizer : ISanitizer
    {
        public string Sanitize(string html)
        {
            HtmlSanitizer sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}
