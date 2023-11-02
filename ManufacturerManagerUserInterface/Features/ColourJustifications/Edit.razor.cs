namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
        ColourJustificationDisplayModel.Justification = ColourJustificationModel.Justification;
    }

    private async Task UpdateColourJustification()
    {
        ColourJustificationModel.Justification = ColourJustificationDisplayModel.Justification;

        try
        {
            await ColourJustificationHandler.UpdateColourJustificationAsync(ColourJustificationModel, true);
            Snackbar.Add($"Colour Justification {ColourJustificationModel.Justification} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo("/colourjustifications/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating Colour Justification {ColourJustificationModel.Justification}. Please try again", Severity.Error);
        }
    }
}
