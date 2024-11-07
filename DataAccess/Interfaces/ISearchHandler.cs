namespace DataAccess.Interfaces;

public interface ISearchHandler
{
    List<ManufacturerModel> GetManufacturerSearchResults(ManufacturerSearchModel manufacturerSearchModel);

    List<WidgetModel> GetWidgetSearchResults(WidgetSearchModel widgetSearchModel);
}
