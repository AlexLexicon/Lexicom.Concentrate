using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public abstract class AbstractViewModelsSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    /// <exception cref="ArgumentNullException"/>
    protected AbstractViewModelsSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        ArgumentNullException.ThrowIfNull(viewModelProvider);

        _viewModelProvider = viewModelProvider;
    }

    public IReadOnlyList<TViewModel> GetViewModels() => _viewModelProvider.GetViewModels();
}
