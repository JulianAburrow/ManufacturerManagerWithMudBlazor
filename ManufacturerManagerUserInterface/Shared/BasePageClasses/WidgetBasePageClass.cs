namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public abstract class WidgetBasePageClass : BasePageClass
{
    [Inject] protected IWidgetHandler WidgetHandler { get; set; } = default!;

    [Inject] protected IWidgetStatusHandler WidgetStatusHandler { get; set; } = default!;

    [Inject] protected IColourHandler ColourHandler { get; set; } = default!;

    [Inject] protected IColourJustificationHandler ColourJustificationHandler { get; set; } = default!;

    [Inject] protected IManufacturerHandler ManufacturerHandler { get; set; } = default!;

    [Parameter] public int WidgetId { get; set; }

    protected WidgetModel WidgetModel = new();

    protected WidgetDisplayModel WidgetDisplayModel = new();

    public required List<WidgetStatusModel> WidgetStatuses { get; set; }

    public required List<ColourModel> Colours { get; set; }

    public required List<ColourJustificationModel> ColourJustifications { get; set; }

    public required List<ManufacturerModel> Manufacturers { get; set; }
}
