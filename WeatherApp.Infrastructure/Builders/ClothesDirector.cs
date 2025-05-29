using WeatherApp.Core.Domain.Models;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.DTO;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Core.Factories.Layers;
//I love the fact that the director could instruct the builder to build different flavors of whatever it is building
//Minimum Viable Product has two pieces as opposed to Full Product has everything
//Maybe Director could get us a Wetaher Only or a Tops Only

namespace WeatherApp.Infrastructure.Builders;

public interface IClothesDirector
{
    Task ConstructClothes(ClothesForCreationDTO clothesForCreationDTO);

    Task ConstructTopLayerOnly(ClothesForCreationDTO clothesForCreationDTO);
    Clothes GetClothes();
}

public class ClothesDirector : IClothesDirector
{
    private IClothesBuilder _clothesBuilder;
    IExternalServicesManager _externalServicesManager;

    public ClothesDirector(IExternalServicesManager externalServicesManager)
    {
        _externalServicesManager = externalServicesManager;
    }
    private void SetClothesBuilder(IClothesBuilder clothesBuilder) => _clothesBuilder = clothesBuilder;

    private IClothesBuilder GetClothesBuilderByType(string type = "Standard")
    {
        return new StandardClothesBuilder();
    }

    public async Task ConstructClothes(ClothesForCreationDTO clothesForCreationDTO)
    {
        //generate customizations
        ILayerCustomizations customizations = new LayerCustomizations();
        WeatherForCreationDTO weatherDTO = new WeatherForCreationDTO
        {
            Latitude = clothesForCreationDTO.Latitude,
            Longitude = clothesForCreationDTO.Longitude
        };
        customizations.Weather = await _externalServicesManager.WeatherService.GetWeather(weatherDTO);
        customizations.ActivityLevel = clothesForCreationDTO.ActivityLevel;
        customizations.BodyTempLevel = clothesForCreationDTO.BodyTempLevel;
        //pass them to the clothesbuilder
        SetClothesBuilder(GetClothesBuilderByType(clothesForCreationDTO.ClothesBuilderType));
        _clothesBuilder.Initialize(customizations);
        _clothesBuilder.BuildGloves();
        _clothesBuilder.BuildHat();
        _clothesBuilder.BuildTopLayers();
        _clothesBuilder.BuildOutermostTopLayer();
        _clothesBuilder.BuildBottomLayer();
        _clothesBuilder.BuildOverview();
    }

    public async Task ConstructTopLayerOnly(ClothesForCreationDTO clothesForCreationDTO) //minimum viable product
    {
        //generate customizations
        ILayerCustomizations customizations = new LayerCustomizations();
        WeatherForCreationDTO weatherDTO = new WeatherForCreationDTO
        {
            Latitude = clothesForCreationDTO.Latitude,
            Longitude = clothesForCreationDTO.Longitude
        };
        customizations.Weather = await _externalServicesManager.WeatherService.GetWeather(weatherDTO);
        customizations.ActivityLevel = clothesForCreationDTO.ActivityLevel;
        customizations.BodyTempLevel = clothesForCreationDTO.BodyTempLevel;
        //pass them to the clothesbuilder
        SetClothesBuilder(GetClothesBuilderByType(clothesForCreationDTO.ClothesBuilderType));
        _clothesBuilder.Initialize(customizations);
        _clothesBuilder.BuildTopLayers();
        _clothesBuilder.BuildOverview();
    }
    public Clothes GetClothes() => _clothesBuilder.GetClothes();
}