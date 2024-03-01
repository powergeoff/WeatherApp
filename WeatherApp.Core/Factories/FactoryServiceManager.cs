using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.Factories;

namespace WeatherApp.Core.RepositoryServices;

public interface IFactoryServiceManager
{
    IBottomLayerFactory BottomLayerFactory { get; }
}

public class FactoryServiceManager : IFactoryServiceManager
{
    private readonly Lazy<IBottomLayerFactory> _lazyBottomLayerService;

    public FactoryServiceManager()
    {
        _lazyBottomLayerService = new Lazy<IBottomLayerFactory>(() => new BottomLayerFactory());
    }


    public IBottomLayerFactory BottomLayerFactory => _lazyBottomLayerService.Value;
}