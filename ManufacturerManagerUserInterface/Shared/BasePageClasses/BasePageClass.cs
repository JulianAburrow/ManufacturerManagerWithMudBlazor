namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public class BasePageClass : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected ISnackbar Snackbar { get; set; } = default!;

    [CascadingParameter] public MainLayout MainLayout { get; set; } = new();

    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue(string.Empty);
    }
}
