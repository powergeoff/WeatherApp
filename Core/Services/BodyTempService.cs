using WeatherApp.Contracts;
using WeatherApp.Domain.Repositories;
using WeatherApp.Services.Abstractions;
using Mapster;
using WeatherApp.Domain.Entities;
using WeatherApp.Domain.Exceptions;

namespace WeatherApp.Services;

internal sealed class BodyTempService : IBodyTempService
{
    private readonly IRepositoryManager _repositoryManager;
    public BodyTempService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

    public Task<BodyTempDTO> CreateBodyTemp(BodyTempForCreationDTO bodyTempForCreationDTO, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task DeleteBodyTemp(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<IEnumerable<BodyTempDTO>> GetAll(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<BodyTempDTO> GetBodyTempById(Guid id, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task<BodyTempDTO> GetBodyTempByUserId(Guid userId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    public Task UpdateBodyTemp(Guid id, BodyTempForUpdateDTO bodyTempForUpdateDTO, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}