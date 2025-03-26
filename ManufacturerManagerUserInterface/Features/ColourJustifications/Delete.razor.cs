﻿namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
        MainLayout.SetHeaderValue("Delete Colour Justification");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadCrumbs(new List<BreadcrumbItem>
        {
            GetHomeBreadcrumbItem(),
            GetColourJustificationHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        });
    }


    private async Task DeleteColourJustification()
    {
        try
        {
            await ColourJustificationHandler.DeleteColourJustificationAsync(ColourJustificationId, true);
            Snackbar.Add($"Colour Justification {ColourJustificationModel.Justification} successfully deleted.", Severity.Success);
            NavigationManager.NavigateTo("/colourjustifications/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting Colour Justification {ColourJustificationModel.Justification}. PLease try again.", Severity.Error);
        }
    }
}
