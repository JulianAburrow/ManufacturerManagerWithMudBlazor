namespace ManufacturerManagerUserInterface.Features.Search;

public partial class Search
{
    SearchModel SearchModel = new();
    List<ManufacturerModel>? ManufacturerSearchResults = null;
    List<WidgetModel>? WidgetSearchResults = null;

    protected override void OnInitialized()
    {
        SearchModel.SearchType = (int)SharedValues.ObjectTypes.PleaseSelect;
        MainLayout.SetHeaderValue("Search");
    }

    private void DoSearch()
    {
        ManufacturerSearchResults = null;
        WidgetSearchResults = null;
        switch (SearchModel.SearchType)
        {
            case (int)SharedValues.ObjectTypes.Manufacturer:
                var manufacturerSearchModel = new ManufacturerSearchModel
                {
                    ManufacturerName = SearchModel.SearchText,
                    ActiveStatus = SearchModel.ActiveStatus,
                };
                ManufacturerSearchResults = SearchHandler.GetManufacturerSearchResults(manufacturerSearchModel);
                break;
            case (int)SharedValues.ObjectTypes.Widget:
                var widgetSearchModel = new WidgetSearchModel
                {
                    WidgetName = SearchModel.SearchText,
                    ActiveStatus = SearchModel.ActiveStatus,
                };
                WidgetSearchResults = SearchHandler.GetWidgetSearchResults(widgetSearchModel);
                break;
        }
    }
}
