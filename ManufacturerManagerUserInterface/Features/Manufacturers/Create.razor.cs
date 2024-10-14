namespace ManufacturerManagerUserInterface.Features.Manufacturers;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        ManufacturerStatuses = await ManufacturerStatusHandler.GetManufacturerStatusesAsync();
        ManufacturerStatuses.Insert(0, new ManufacturerStatusModel
        {
            StatusId = SharedValues.PleaseSelectValue,
            StatusName = SharedValues.PleaseSelectText,
        });
        ManufacturerDisplayModel.StatusId = -1;
        MainLayout.SetHeaderValue("Create Manufacturer");
    }

    private async Task CreateManufacturer()
    {
        CopyDisplayModelToModel();

        try
        {
            await ManufacturerHandler.CreateManufacturerAsync(ManufacturerModel, true);
            Snackbar.Add($"Manufacturer {ManufacturerModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/manufacturers/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating manufacturer {ManufacturerModel.Name}. Please try again.", Severity.Error);
        }
    }
}
