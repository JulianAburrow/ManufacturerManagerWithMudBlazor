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
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            new("Search", null, true),
        });
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

    private async void ExportAsCSV()
    {
        var csvString = string.Empty;
        var fileName = string.Empty;
        if (ManufacturerSearchResults != null)
        {
            csvString = CSVStrings.CreateManufacturersCSVString(ManufacturerSearchResults);
            fileName = $"Manufacturers-TBD={DateTime.Now}.csv";
        }
        if (WidgetSearchResults != null)
        {
            csvString = CSVStrings.CreateWidgetsCSVString(WidgetSearchResults);
            fileName = $"Widgets-TBD={DateTime.Now}.csv";
        }

        var fileBytes = SharedMethods.GetUTF8Bytes(csvString);
        var base64 = SharedMethods.GetBase64String(fileBytes);

        await JSRuntime.InvokeVoidAsync(DownloadFile, base64, ContentType, fileName);
    }
}
