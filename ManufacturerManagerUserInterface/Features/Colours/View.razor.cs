namespace ManufacturerManagerUserInterface.Features.Colours;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        ColourModel = await ColourHandler.GetColourAsync(ColourId);
    }
}
