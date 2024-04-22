using It_Expert.Domain.Dtos;
using It_Expert.Domain.Requests;

namespace It_Expert.Services.Interfaces;

public interface IDataService
{
    Task<DataDto[]> GetDataAsync(int? code, string? value);
    Task SaveDataAsync(PostRequest dataRequest);
}
