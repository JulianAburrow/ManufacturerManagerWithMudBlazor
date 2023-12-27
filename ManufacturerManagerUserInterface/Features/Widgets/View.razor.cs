namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        WidgetModel = await WidgetHandler.GetWidgetAsync(WidgetId);
        Layout.SetHeaderValue("View Widget");
    }
}
