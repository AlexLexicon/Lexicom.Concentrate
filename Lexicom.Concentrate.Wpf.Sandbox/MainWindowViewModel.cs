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
    }

    [ObservableProperty]
    public IRuleSetValidator<NameRuleSet, string?> _nameValidator;

    [RelayCommand]
    public void Invalidate()
    {
        NameValidator.ValidationErrors.Add("has problem.");
    }
}
