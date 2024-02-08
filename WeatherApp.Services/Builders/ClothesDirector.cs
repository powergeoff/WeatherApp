using WeatherApp.Services.Models;

namespace WeatherApp.Services.Builders;

public interface IClothesDirector
{
    Task ConstructClothes(double latitude, double longitude);
    Clothes GetClothes();
}

public class ClothesDirector : IClothesDirector
{
    private IClothesBuilder _clothesBuilder;

    public ClothesDirector(IClothesBuilder clothesBuilder)
    {
        _clothesBuilder = clothesBuilder;
    }

    public async Task ConstructClothes(double latitude, double longitude)
    {
        await _clothesBuilder.Initialize(latitude, longitude);
        //_clothesBuilder.BuildGloves();
        _clothesBuilder.BuildHat();
        //_clothesBuilder.BuildTopLayers();
        //_clothesBuilder.BuildBottomLayer();
        _clothesBuilder.BuildOverview();
    }

    public Clothes GetClothes() => _clothesBuilder.GetClothes();

}