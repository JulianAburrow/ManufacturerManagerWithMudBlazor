using DataAccess.Data;

namespace DataAccess.Handlers;

public class ManufacturerHandler : IManufacturerHandler
{
    private readonly ManufacturerManagerContext _context;

    public ManufacturerHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task CreateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges)
    {
        _context.Manufacturers.Add(manufacturer);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task DeleteManufacturerAsync(int manufacturerId, bool callSaveChanges)
    {
        var manufacturerToDelete = _context.Manufacturers.SingleOrDefault(m => m.ManufacturerId == manufacturerId);
        if (manufacturerToDelete == null)
            return;
        _context.Manufacturers.Remove(manufacturerToDelete);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task<ManufacturerModel> GetManufacturerAsync(int manufacturerId)
    {
        return await _context.Manufacturers.SingleOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
    }

    public async Task<List<ManufacturerModel>> GetManufacturersAsync()
    {
        return await _context.Manufacturers.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges)
    {
        var manufacturerToUpdate = _context.Manufacturers.SingleOrDefault(m => m.ManufacturerId == manufacturer.ManufacturerId);
        if (manufacturerToUpdate == null)
            return;
        manufacturerToUpdate.ManufacturerName = manufacturer.ManufacturerName;
        manufacturerToUpdate.StatusId = manufacturer.StatusId;
        if (callSaveChanges)
            await SaveChangesAsync();
    }
}
