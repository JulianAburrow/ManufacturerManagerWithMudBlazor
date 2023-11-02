namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public class ColourJustificationBasePageClass : BasePageClass
{
    [Inject] protected IColourJustificationHandler ColourJustificationHandler { get; set; } = default!;

    [Parameter] public int ColourJustificationId {  get; set; }

    protected ColourJustificationModel ColourJustificationModel { get; set; } = new();

    protected ColourJustificationDisplayModel ColourJustificationDisplayModel { get; set; } = new();
}
