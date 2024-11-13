namespace ManufacturerManagerUserInterface.Features;

public partial class Index
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Home");
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(true),
        });
    }
        
}
