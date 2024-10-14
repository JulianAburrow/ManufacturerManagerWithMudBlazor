namespace ManufacturerManagerUserInterface.Shared.Components;

public partial class WidgetGridViewComponent
{
    [Parameter] public List<WidgetModel> Widgets { get; set; } = null!;
}
