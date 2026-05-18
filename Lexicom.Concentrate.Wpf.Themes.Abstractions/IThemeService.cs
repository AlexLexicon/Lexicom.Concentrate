using Lexicom.Wpf.Amenities.Exceptions;
using Lexicom.Concentrate.Wpf.Themes.Exceptions;

namespace Lexicom.Concentrate.Wpf.Themes;
public interface IThemeService
{
    /// <exception cref="ThemesNotFoundException"/>
    /// <exception cref="AppliedThemeNotFoundException"/>
    Task LoadThemeAsync();

    /// <exception cref="ThemesNotFoundException"/>
    Task<IReadOnlyList<string>> GetThemesAsync();

    /// <exception cref="ThemesNotFoundException"/>
    /// <exception cref="AppliedThemeNotFoundException"/>
    Task<string> GetThemeAsync();

    /// <exception cref="AppliedThemeNotFoundException"/>
    Task<string> GetAppliedThemeAsync();

    /// <exception cref="ThemeDoesNotExistException"/>
    Task SetThemeAsync(string theme);
}
