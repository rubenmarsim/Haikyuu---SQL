using Unity;
using Haikyuu.Services.Navigation;

namespace Haikyuu.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<CustomCellViewModel>();
            _container.RegisterType<MainViewModel>();

            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
        }

        public CustomCellViewModel CustomCellViewModel
        {
            get { return _container.Resolve<CustomCellViewModel>(); }
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}