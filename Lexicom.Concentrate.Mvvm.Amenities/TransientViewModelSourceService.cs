using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public abstract class TransientViewModelSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    protected TransientViewModelSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        _viewModelProvider = viewModelProvider;
    }

    public IReadOnlyList<TViewModel> ViewModels => _viewModelProvider.GetViewModels();
}
