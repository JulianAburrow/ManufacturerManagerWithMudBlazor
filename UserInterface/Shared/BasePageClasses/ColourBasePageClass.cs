namespace UserInterface.Shared.BasePageClasses;

public class ColourBasePageClass : BasePageClass
{
    [Inject] protected IColourHandler ColourHandler { get; set; } = default!;
}
