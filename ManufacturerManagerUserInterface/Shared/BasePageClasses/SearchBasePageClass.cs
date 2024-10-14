namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public class SearchBasePageClass : BasePageClass
{
    [Inject] public ISearchHandler SearchHandler { get; set; } = null!;
}
