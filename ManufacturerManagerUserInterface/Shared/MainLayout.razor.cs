namespace ManufacturerManagerUserInterface.Shared;

public partial class MainLayout
{
    bool _drawerOpen = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private string HeaderValue { get; set; } = null!;

    public void SetHeaderValue(string headerValue)
    {
        HeaderValue = headerValue;
        StateHasChanged();
    }
}
