namespace ManufacturerManagerUserInterface.Features.Manufacturers;

public partial class Index
{
    protected List<ManufacturerModel> Manufacturers { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Manufacturers = await ManufacturerHandler.GetManufacturersAsync();
        Snackbar.Add($"{Manufacturers.Count} item(s) found.", Manufacturers.Count == 0 ? Severity.Error : Severity.Success);
        MainLayout.SetHeaderValue("Manufacturers");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetManufacturerHomeBreadcrumbItem(true),
        });
    }

    private async void ExportAsCSV()
    {
        var csvString = CSVStrings.CreateManufacturersCSVString(Manufacturers);
        var fileBytes = SharedMethods.GetUTF8Bytes(csvString);
        var fileName = $"Manufacturers={DateTime.Now}.csv";
        var base64 = SharedMethods.GetBase64String(fileBytes);

        await JSRuntime.InvokeVoidAsync(DownloadFile, base64, ContentType, fileName);
    }
}
