namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        WidgetModel = await WidgetHandler.GetWidgetAsync(WidgetId);
        MainLayout.SetHeaderValue("View Widget");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetWidgetHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        });
    }
}
