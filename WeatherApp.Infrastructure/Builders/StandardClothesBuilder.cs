using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.DTO;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

//we could have ActiveClothes, RinkClothes, BeachClothes
public class StandardClothesBuilder : ClothesBuilderBase
{
    public StandardClothesBuilder(UserDTO user, IOpenWeatherMapService openWeatherMapService) : base(user, openWeatherMapService)
    {

    }

    public override void BuildGloves()
    {
        var gloves = _handsLayerFactory.GetLayer();
        _clothes.Gloves = gloves?.ToString();
    }
    public override void BuildHat()
    {
        var hat = _hatLayerFactory.GetLayer();
        _clothes.Hat = hat?.ToString();
    }
    public override void BuildTopLayers()
    {
        var topLayers = _topLayersFactory.GetLayers();
        foreach (var layer in topLayers)
        {
            _clothes.TopLayers.Add(layer.ToString());
        }
    }
    public override void BuildBottomLayer()
    {
        var bottom = _bottomLayerFactory.GetLayer();
        _clothes.BottomLayer = bottom.ToString(); //no null here YOU MUST WEAR PANTS OR SHORTS!
    }
}