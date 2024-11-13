namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class Index
{
    protected List<WidgetModel> Widgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Widgets = await WidgetHandler.GetWidgetsAsync();
        Snackbar.Add($"{Widgets.Count} item(s) found.", Widgets.Count == 0 ? Severity.Error : Severity.Success);
        MainLayout.SetHeaderValue("Widgets");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(true),
        });
    }

    private async void ExportAsCSV()
    {
        var csvString = CSVStrings.CreateWidgetsCSVString(Widgets);
        var fileBytes = SharedMethods.GetUTF8Bytes(csvString);
        var fileName = $"Widgets-{DateTime.Now}.csv";
        var base64 = SharedMethods.GetBase64String(fileBytes);

        await JSRuntime.InvokeVoidAsync(DownloadFile, base64, ContentType, fileName);
    }
}
