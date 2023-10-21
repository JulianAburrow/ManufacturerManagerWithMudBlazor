namespace DataAccess.Interfaces;

public interface IManufacturerStatusHandler
{
    Task<List<ManufacturerStatusModel>> GetManufacturerStatusesAsync();
}
