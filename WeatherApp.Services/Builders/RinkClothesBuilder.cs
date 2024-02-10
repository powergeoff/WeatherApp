using WeatherApp.Services.Models;

namespace WeatherApp.Services.Builders;

public class RinkClothesBuilder : IClothesBuilder
{
    private Clothes clothes = new Clothes();
    public void BuildBottomLayer() => throw new System.NotImplementedException();
    public void BuildGloves() => throw new System.NotImplementedException();
    public void BuildHat() => throw new System.NotImplementedException();
    public void BuildOverview() => throw new System.NotImplementedException();
    public void BuildTopLayers() => throw new System.NotImplementedException();
    public Clothes GetClothes() => throw new System.NotImplementedException();
    public Task Initialize() => throw new System.NotImplementedException();
}