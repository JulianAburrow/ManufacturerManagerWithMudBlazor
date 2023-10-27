namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public class ColourBasePageClass : BasePageClass
{
    [Inject] protected IColourHandler ColourHandler { get; set; } = default!;

    [Parameter] public int ColourId { get; set; }

    protected ColourModel ColourModel { get; set; } = new();

    protected ColourDisplayModel ColourDisplayModel { get; set; } = new();
}
