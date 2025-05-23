using System.Globalization;

namespace School.Data.Commons
{
    public class GeniralLocalizableEntity
    {
        public string Localize(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            if (culture.TwoLetterISOLanguageName == "ar")
            {
                return textAr;
            }
            else
            {
                return textEn;
            }
        }
    }
}
