using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public abstract class AbstractSingletonViewModelSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    /// <exception cref="ArgumentNullException"/>
    protected AbstractSingletonViewModelSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        ArgumentNullException.ThrowIfNull(viewModelProvider);

        _viewModelProvider = viewModelProvider;
    }

    public TViewModel? ViewModel => _viewModelProvider
        .GetViewModels()
        .SingleOrDefault();
}
