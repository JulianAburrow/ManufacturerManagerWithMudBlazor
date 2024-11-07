namespace ManufacturerManagerUserInterface.Models;

public class SearchModel
{
    public int SearchType { get; set; }

    public string SearchText { get; set; } = string.Empty;

    public int ActiveStatus { get; set; }
}
