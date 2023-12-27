namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
        Layout.SetHeaderValue("Delete Colour Justification");
    }
        

    private async Task DeleteColourJustification()
    {
        try
        {
            await ColourJustificationHandler.DeleteColourJusticationAsync(ColourJustificationId, true);
            Snackbar.Add($"Colour Justification {ColourJustificationModel.Justification} successfully deleted.", Severity.Success);
            NavigationManager.NavigateTo("/colourjustifications/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting Colour Justification {ColourJustificationModel.Justification}. PLease try again.", Severity.Error);
        }
    }
}
