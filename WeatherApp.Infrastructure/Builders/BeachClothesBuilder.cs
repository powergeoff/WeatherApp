

using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.DTO;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

public class BeachClothesBuilder : ClothesBuilderBase
{
    public BeachClothesBuilder() : base()
    {
        //instatiate your clothes factories
    }

    public override void BuildBottomLayer() => throw new NotImplementedException();
    public override void BuildGloves() => throw new NotImplementedException();
    public override void BuildHat() => throw new NotImplementedException();
    public override void BuildTopLayers() => throw new NotImplementedException();
}