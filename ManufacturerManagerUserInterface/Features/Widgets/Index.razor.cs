namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class Index
{
    protected List<WidgetModel> Widgets { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Widgets = await WidgetHandler.GetWidgetsAsync();
        Snackbar.Add($"{Widgets.Count} item(s) found.", Widgets.Count == 0 ? Severity.Error : Severity.Success);
        Layout.SetHeaderValue("Widgets");
    }
}
