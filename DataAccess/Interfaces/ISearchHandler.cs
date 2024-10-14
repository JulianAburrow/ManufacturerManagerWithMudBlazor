namespace DataAccess.Interfaces;

public interface ISearchHandler
{
    List<ManufacturerModel> GetManufacturerSearchResults(SearchModel searchModel);

    List<WidgetModel> GetWidgetSearchResults(SearchModel searchModel);
}
