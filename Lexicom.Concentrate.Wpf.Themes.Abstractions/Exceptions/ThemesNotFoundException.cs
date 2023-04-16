namespace Lexicom.Concentrate.Wpf.Themes.Exceptions;
public class ThemesNotFoundException : Exception
{
    public ThemesNotFoundException() : base($"No themes could be found for this application.")
    {
    }
}
