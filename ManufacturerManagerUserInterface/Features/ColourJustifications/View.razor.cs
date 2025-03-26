namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        Thread.Sleep(2000);
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
        MainLayout.SetHeaderValue("View Colour Justification");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        });
    }
}
