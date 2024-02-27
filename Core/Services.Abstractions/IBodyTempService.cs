
using WeatherApp.Contracts;

namespace WeatherApp.Services.Abstractions;

public interface IBodyTempService
{
    Task<IEnumerable<BodyTempDTO>> GetAll(CancellationToken cancellationToken = default);
    Task<BodyTempDTO> GetBodyTempById(Guid id, CancellationToken cancellationToken = default);
    Task<BodyTempDTO> GetBodyTempByUserId(Guid userId, CancellationToken cancellationToken = default);
    Task<BodyTempDTO> CreateBodyTemp(BodyTempForCreationDTO bodyTempForCreationDTO, CancellationToken cancellationToken = default);
    Task UpdateBodyTemp(Guid id, BodyTempForUpdateDTO bodyTempForUpdateDTO, CancellationToken cancellationToken = default);
    Task DeleteBodyTemp(Guid id, CancellationToken cancellationToken = default);
}