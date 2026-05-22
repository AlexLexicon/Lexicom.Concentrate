using Lexicom.Mvvm.Extensions;
using Lexicom.Mvvm.For.Wpf.Extensions;
using Lexicom.Supports.Wpf.Extensions;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.For.Wpf.Extensions;
using Lexicom.Wpf.DependencyInjection;
using System.Windows;

namespace Lexicom.Concentrate.Wpf.Sandbox;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        var builder = WpfApplication.CreateBuilder(this);

        builder.Lexicom(l =>
        {
            l.AddMvvm(mvvm =>
            {
                mvvm.AddViewModel<MainWindowViewModel>(vm =>
                {
                    vm.ForWindow<MainWindow>();
                });
            });
            l.AddValidation(v =>
            {
                v.AddAmenities();
                v.AddValidators<AssemblyScanMarker>();
            });
        });

        var app = builder.Build();

        app.StartupWindow<MainWindow>();
    }
}

