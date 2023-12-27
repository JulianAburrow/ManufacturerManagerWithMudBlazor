namespace ManufacturerManagerUserInterface.Features.Manufacturers;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerModel = await ManufacturerHandler.GetManufacturerAsync(ManufacturerId);
        Layout.SetHeaderValue("View Manufacturer");
    }
                
}
