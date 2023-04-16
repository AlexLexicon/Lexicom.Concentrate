using Lexicom.Concentrate.Wpf.Themes.Exceptions;
using Lexicom.Concentrate.Wpf.Themes.Validators;
using Lexicom.Configuration.Settings;
using Lexicom.Extensions.Exceptions;
using Lexicom.Wpf.Amenities.Exceptions;
using Lexicom.Wpf.Amenities.Themes;
using Microsoft.Extensions.Options;

namespace Lexicom.Concentrate.Wpf.Themes;
public class WpfThemeService : IThemeService
{
    private readonly ISettingsWriter _settingsWriter;
    private readonly IThemeApplicator _themeApplicator;
    private readonly IThemeProvider _themeProvider;
    private readonly IOptionsMonitor<ThemeOptions> _themeOptions;

    /// <exception cref="ArgumentNullException"/>
    public WpfThemeService(
        ISettingsWriter settingsWriter,
        IThemeApplicator themeApplicator,
        IThemeProvider themeProvider,
        IOptionsMonitor<ThemeOptions> themeOptions)
    {
        ArgumentNullException.ThrowIfNull(settingsWriter);
        ArgumentNullException.ThrowIfNull(themeApplicator);
        ArgumentNullException.ThrowIfNull(themeProvider);
        ArgumentNullException.ThrowIfNull(themeOptions);

        _settingsWriter = settingsWriter;
        _themeApplicator = themeApplicator;
        _themeProvider = themeProvider;
        _themeOptions = themeOptions;
    }

    /// <exception cref="ThemesNotFoundException"/>
    /// <exception cref="AppliedThemeNotFound"/>
    public async Task LoadThemeAsync()
    {
        string theme = await GetThemeAsync();

        try
        {
            await _themeApplicator.ApplyAsync(theme);
        }
        catch (ThemeDoesNotExistException e)
        {
            throw e.ToUnreachableException($"The theme '{theme}' should exist since we already checked that is could be found.");
        }
    }

    /// <exception cref="ThemesNotFoundException"/>
    public async Task<IReadOnlyList<string>> GetThemesAsync()
    {
        IReadOnlyList<string> themes = await _themeProvider.GetThemesAsync();

        if (!themes.Any())
        {
            throw new ThemesNotFoundException();
        }

        return themes;
    }

    /// <exception cref="AppliedThemeNotFound"/>
    public async Task<string> GetAppliedThemeAsync()
    {
        string? theme = await _themeProvider.GetAppliedThemeAsync();

        if (theme is null)
        {
            throw new AppliedThemeNotFound();
        }

        return theme;
    }

    /// <exception cref="ThemesNotFoundException"/>
    /// <exception cref="AppliedThemeNotFound"/>
    public async Task<string> GetThemeAsync()
    {
        ThemeOptions themeOptions = _themeOptions.CurrentValue;

        if (string.IsNullOrWhiteSpace(themeOptions.AppliedTheme))
        {
            throw ThemeOptionsValidator.ToUnreachableException();
        }

        string theme = themeOptions.AppliedTheme;

        IReadOnlyList<string> themes = await GetThemesAsync();

        if (!themes.Contains(theme))
        {
            theme = await GetAppliedThemeAsync();
        }

        return theme;
    }

    /// <exception cref="ThemeDoesNotExistException"/>
    public async Task SetThemeAsync(string theme)
    {
        var applyTask = _themeApplicator.ApplyAsync(theme);
        var saveAndBindTask = _settingsWriter.SaveAndBindAsync(new ThemeOptions
        {
            AppliedTheme = theme,
        });

        await applyTask;
        await saveAndBindTask;
    }
}
