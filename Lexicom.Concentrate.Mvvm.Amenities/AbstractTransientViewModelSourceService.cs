using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public abstract class AbstractTransientViewModelSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    /// <exception cref="ArgumentNullException"/>
    protected AbstractTransientViewModelSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        ArgumentNullException.ThrowIfNull(viewModelProvider);

        _viewModelProvider = viewModelProvider;
    }

    public IReadOnlyList<TViewModel> ViewModels => _viewModelProvider.GetViewModels();
}
