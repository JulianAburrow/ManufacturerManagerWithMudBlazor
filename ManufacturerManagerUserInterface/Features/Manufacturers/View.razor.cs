namespace ManufacturerManagerUserInterface.Features.Manufacturers;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerModel = await ManufacturerHandler.GetManufacturerAsync(ManufacturerId);
        MainLayout.SetHeaderValue("View Manufacturer");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        });
    }

    private async void ExportAsCSV()
    {
        var csvString = CSVStrings.CreateWidgetsCSVString(ManufacturerModel.Widgets.ToList());
        var fileBytes = SharedMethods.GetUTF8Bytes(csvString);
        var fileName = $"{ManufacturerModel.Name}-Widgets-{DateTime.Now}.csv";
        var base64 = SharedMethods.GetBase64String(fileBytes);

        await JSRuntime.InvokeVoidAsync(DownloadFile, base64, ContentType, fileName);
    }
}
