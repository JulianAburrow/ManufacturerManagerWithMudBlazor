namespace ManufacturerManagerUserInterface.Features.Colours;

public partial class Index
{
    ICollection<ColourModel> Colours { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Colours = await ColourHandler.GetColoursAsync();
        Snackbar.Add($"{Colours.Count} item(s) found", Colours.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue("Colours");
    }
}
