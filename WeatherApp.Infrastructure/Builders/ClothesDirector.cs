using WeatherApp.Core.Domain.Entities;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.DTO;
using WeatherApp.Core.DTO.Weather;
using WeatherApp.Core.Factories.Layers;

namespace WeatherApp.Infrastructure.Builders;

public interface IClothesDirector
{
    Task ConstructClothes(ClothesForCreationDTO clothesForCreationDTO);
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
        _clothesBuilder.BuildBottomLayer();
        _clothesBuilder.BuildOverview();
    }



    public Clothes GetClothes() => _clothesBuilder.GetClothes();
}