using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Validation;
using Lexicom.Validation.Amenities.RuleSets;

namespace Lexicom.Concentrate.Wpf.Sandbox;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel(IRuleSetValidator<NameRuleSet, string?> nameValidator)
    {
        NameValidator = nameValidator;

        Errors = new ObservableCollection<string?>();
    }

    [ObservableProperty]
    public partial IRuleSetValidator<NameRuleSet, string?> NameValidator { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<string?> Errors { get; set; }

    [RelayCommand]
    public void Invalidate()
    {
        NameValidator.ValidationErrors.Add("has problem.");
        Errors.Add("has problem.");
    }
}
