using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.DTO;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Factories.Layers;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

namespace WeatherApp.Infrastructure.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

//we could have ActiveClothes, RinkClothes, BeachClothes
//they could all define their own layers - the layers themselves have the logic to say whether they are applied or not
public class StandardClothesBuilder : ClothesBuilderBase
{
    public StandardClothesBuilder() : base()
    {
        //each clothes builder implementation should register it's unique layer factories
        _topLayersFactory = new TopLayersFactory();
        _hatLayerFactory = new HatLayerFactory();
        _handsLayerFactory = new HandsLayerFactory();
        _bottomLayerFactory = new BottomLayerFactory();
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