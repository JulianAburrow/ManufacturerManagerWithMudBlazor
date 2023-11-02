namespace ManufacturerManagerUserInterface.Features.ColourJustifications;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ColourJustificationModel = await ColourJustificationHandler.GetColourJustificationAsync(ColourJustificationId);
    }
}
