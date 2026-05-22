using Lexicom.Mvvm;

namespace Lexicom.Concentrate.Mvvm.Amenities;

public class SingletonViewModelSourceService<TViewModel> where TViewModel : class
{
    private readonly IViewModelProvider<TViewModel> _viewModelProvider;

    protected SingletonViewModelSourceService(IViewModelProvider<TViewModel> viewModelProvider)
    {
        _viewModelProvider = viewModelProvider;
    }

    public TViewModel? ViewModel => _viewModelProvider
        .GetViewModels()
        .SingleOrDefault();
}
