namespace DataAccess.Handlers;

public class SearchHandler : ISearchHandler
{
    private readonly ManufacturerManagerContext _context;

    public SearchHandler(ManufacturerManagerContext context) =>
        _context = context;

    public List<ManufacturerModel> GetManufacturerSearchResults(ManufacturerSearchModel manufacturerSearchModel)
    {
        var manufacturersFound = new List<ManufacturerModel>();

        manufacturersFound.AddRange(_context.Manufacturers
            .Include(m => m.Status)
            .Include(m => m.Widgets)
            .Where(m => m.Name.Contains(manufacturerSearchModel.ManufacturerName)));

        if (manufacturerSearchModel.ActiveStatus > 0)
        {
            if (manufacturersFound.Any())
            {
                manufacturersFound = manufacturersFound.Where(m => m.StatusId == manufacturerSearchModel.ActiveStatus).ToList();
            }
            else
            {
                manufacturersFound = _context.Manufacturers.Where(m => m.StatusId == manufacturerSearchModel.ActiveStatus).ToList();
            }
        }            

        return manufacturersFound;

    }

    public List<WidgetModel> GetWidgetSearchResults(WidgetSearchModel widgetSearchModel)
    {
        var widgetsFound = new List<WidgetModel>();

        widgetsFound.AddRange(_context.Widgets
            .Include(w => w.Manufacturer)
            .Include(w => w.Status)
            .Where(w => w.Name.Contains(widgetSearchModel.WidgetName)));

        if (widgetSearchModel.ActiveStatus > 0)
        {
            if (widgetsFound.Any())
            {
                widgetsFound = widgetsFound.Where(w => w.StatusId == widgetSearchModel.ActiveStatus).ToList();
            }
            else
            {
                widgetsFound = _context.Widgets.Where(w => w.StatusId == widgetSearchModel.ActiveStatus).ToList();
            }
        }            

        return widgetsFound;
    }
}
