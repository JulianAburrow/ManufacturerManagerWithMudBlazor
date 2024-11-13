namespace ManufacturerManagerUserInterface.Models;

public class SearchModel
{
    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Search Type")]
    public int SearchType { get; set; }

    public string SearchText { get; set; } = string.Empty;

    public int ActiveStatus { get; set; }
}
