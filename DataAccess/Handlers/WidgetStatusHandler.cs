using DataAccess.Data;

namespace DataAccess.Handlers;

public class WidgetStatusHandler : IWidgetStatusHandler
{
    private readonly ManufacturerManagerContext _context;

    public WidgetStatusHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task<List<WidgetStatusModel>> GetWidgetStatusModelsAsync()
    {
        return await _context.WidgetStatuses.ToListAsync();
    }
}
