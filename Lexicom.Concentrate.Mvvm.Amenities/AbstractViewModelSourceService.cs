using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public abstract class AbstractViewModelSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    /// <exception cref="ArgumentNullException"/>
    protected AbstractViewModelSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        ArgumentNullException.ThrowIfNull(viewModelProvider);

        _viewModelProvider = viewModelProvider;
    }

    public TViewModel? GetViewModel() => _viewModelProvider
        .GetViewModels()
        .SingleOrDefault();
}
