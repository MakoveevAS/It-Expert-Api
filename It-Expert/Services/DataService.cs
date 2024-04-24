using It_Expert.DataBase;
using It_Expert.DataBase.Entities;
using It_Expert.Domain;
using It_Expert.Domain.Dtos;
using It_Expert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace It_Expert.Services;

public class DataService : IDataService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<IDataService> _logger;

    public DataService(
        DataContext dataContext,
        ILogger<IDataService>  logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }
    public Task<DataDto[]> GetDataAsync(int? code, string? value)
    {
        try
        {
            return _dataContext.Data
                .Where(d =>
                    (!code.HasValue || d.Code == code)
                    && (string.IsNullOrEmpty(value) || string.Equals(d.Value, value, StringComparison.OrdinalIgnoreCase)))

                .OrderBy(d => d.Id)
                .Select(d => new DataDto()
                {
                    Value = d.Value,
                    Code = d.Code
                }).ToArrayAsync();
        }
        catch (Exception)
        {
            _logger.LogError("Error when getting data from the DB");
            throw;
        }
    }

    public async Task SaveDataAsync(PostRequest dataRequest)
    {
        try
        {
            _dataContext.Data.Clear();
            await _dataContext.Data.AddRangeAsync(
                dataRequest.Data.OrderBy(d => d.Code).Select(d => new Data()
                {
                    Code = d.Code ?? 0,
                    Value = d.Value ?? ""
                }));
            await _dataContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            _logger.LogError("Error when save data into the DB");
            throw;
        }
        
    }
}
