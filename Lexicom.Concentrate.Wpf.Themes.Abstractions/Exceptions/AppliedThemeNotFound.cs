namespace Lexicom.Concentrate.Wpf.Themes.Exceptions;
public class AppliedThemeNotFound : Exception
{
    public AppliedThemeNotFound() : base($"No applied theme could be found for this application.")
    {
    }
}
