
namespace DataAccess.Handlers;

public class SearchHandler : ISearchHandler
{
    private readonly ManufacturerManagerContext _context;

    public SearchHandler(ManufacturerManagerContext context) =>
        _context = context;

    public List<ManufacturerModel> GetManufacturerSearchResults(SearchModel searchModel)
    {
        return _context.Manufacturers
                .Include(m => m.Status)
                .Include(m => m.Widgets)
                .Where(m => m.Name.Contains(searchModel.SearchText))
                .ToList();
    }


    public List<WidgetModel> GetWidgetSearchResults(SearchModel searchModel)
    {
        return _context.Widgets
                .Include(w => w.Manufacturer).Include(w => w.Status)
                .Where(w => w.Name.Contains(searchModel.SearchText))
                .ToList();
    }
}
