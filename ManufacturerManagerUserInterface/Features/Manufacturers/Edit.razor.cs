namespace ManufacturerManagerUserInterface.Features.Manufacturers;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerStatuses = await ManufacturerStatusHandler.GetManufacturerStatusesAsync();
        ManufacturerModel = await ManufacturerHandler.GetManufacturerAsync(ManufacturerId);
        ManufacturerDisplayModel.ManufacturerId = ManufacturerId;
        ManufacturerDisplayModel.Name = ManufacturerModel.Name;
        ManufacturerDisplayModel.StatusId = ManufacturerModel.StatusId;
        Layout.SetHeaderValue("Edit Manufacturer");
    }

    private async Task UpdateManufacturer()
    {
        ManufacturerModel.ManufacturerId = ManufacturerId;
        ManufacturerModel.Name = ManufacturerDisplayModel.Name;
        ManufacturerModel.StatusId = ManufacturerDisplayModel.StatusId;

        try
        {
            await ManufacturerHandler.UpdateManufacturerAsync(ManufacturerModel, true);
            Snackbar.Add($"Manufacturer {ManufacturerModel.Name} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo("/manufacturers/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating manufacturer {ManufacturerModel.Name}. Please try again.", Severity.Error);
        }
    }        
}
