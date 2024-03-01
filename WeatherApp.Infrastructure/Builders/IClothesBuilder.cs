using WeatherApp.Core.Domain.Entities;

namespace WeatherApp.Infrastructure.Builders;

//https://softinbit.medium.com/builder-design-pattern-constructing-complex-objects-with-ease-61bce2df3135

public interface IClothesBuilder
{
    Task Initialize();
    void BuildGloves();
    void BuildHat();
    void BuildTopLayers();
    void BuildBottomLayer();
    void BuildOverview();
    Clothes GetClothes();
}