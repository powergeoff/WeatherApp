using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Infrastructure.Builders;

public interface IClothesDirector
{
    Task ConstructClothes();
    Clothes GetClothes();
}

public class ClothesDirector : IClothesDirector
{
    private IClothesBuilder _clothesBuilder;

    public ClothesDirector(IClothesBuilder clothesBuilder)
    {
        _clothesBuilder = clothesBuilder;
    }

    public async Task ConstructClothes()
    {
        await _clothesBuilder.Initialize();
        _clothesBuilder.BuildGloves();
        _clothesBuilder.BuildHat();
        _clothesBuilder.BuildTopLayers();
        _clothesBuilder.BuildBottomLayer();
        _clothesBuilder.BuildOverview();
    }

    public Clothes GetClothes() => _clothesBuilder.GetClothes();

}