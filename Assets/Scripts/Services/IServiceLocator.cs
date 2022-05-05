
namespace Services
{
    public interface IServiceLocator<TService>
    {
        T Register<T>(T newService) where T : TService;
        void Unregister<T>(T removeService) where T : TService;
        T GetService<T>() where T : TService;
    }
}