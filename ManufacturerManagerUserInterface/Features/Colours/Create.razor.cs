namespace ManufacturerManagerUserInterface.Features.Colours;

public partial class Create
{
    private async Task CreateColour()
    {
        ColourModel.Name = ColourDisplayModel.Name;

        try
        {
            await ColourHandler.CreateColourAsync(ColourModel, true);
            Snackbar.Add($"Colour {ColourModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/colours/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating colour {ColourModel.Name}. Please try again.", Severity.Error);
        }
    }
}
