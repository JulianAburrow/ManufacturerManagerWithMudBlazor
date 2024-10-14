namespace ManufacturerManagerUserInterface.Features.Search;

public partial class Search
{
    SearchModel SearchModel = new();
    List<ManufacturerModel>? ManufacturerSearchResults;
    List<WidgetModel>? WidgetSearchResults;

    protected override void OnInitialized()
    {
        ManufacturerSearchResults = null;
        WidgetSearchResults = null;
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
                ManufacturerSearchResults = SearchHandler.GetManufacturerSearchResults(SearchModel);
                break;
            case (int)SharedValues.ObjectTypes.Widget:
                WidgetSearchResults = SearchHandler.GetWidgetSearchResults(SearchModel);
                break;
        }
    }
}
