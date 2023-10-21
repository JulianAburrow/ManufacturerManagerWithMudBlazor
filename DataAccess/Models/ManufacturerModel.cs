namespace DataAccess.Models;

public class ManufacturerModel
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = default!;

    public int StatusId { get; set; }

    public ManufacturerStatusModel Status { get; set; } = null!;

    public ICollection<WidgetModel> Widgets { get; set; } = null!;
}
