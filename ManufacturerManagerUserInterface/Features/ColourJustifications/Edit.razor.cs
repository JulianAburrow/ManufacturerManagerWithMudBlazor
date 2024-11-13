namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
        ColourJustificationDisplayModel.Justification = ColourJustificationModel.Justification;
        MainLayout.SetHeaderValue("Edit Colour Justification");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        });
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
