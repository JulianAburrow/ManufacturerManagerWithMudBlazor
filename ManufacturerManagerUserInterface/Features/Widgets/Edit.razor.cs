namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class Edit
{
    private bool ManufacturerInactive { get; set; }

    protected override async Task OnInitializedAsync()
    {
        WidgetStatuses = await WidgetStatusHandler.GetWidgetStatusesAsync();
        Colours = await ColourHandler.GetColoursAsync();
        Colours.Insert(0, new ColourModel
        {
            ColourId = SelectValues.NoneValue,
            Name = SelectValues.NoneText,
        });
        ColourJustifications = await ColourJustificationHandler.GetColourJustificationsAsync();
        ColourJustifications.Insert(0, new ColourJustificationModel
        {
            ColourJustificationId = SelectValues.NoneValue,
            Justification = SelectValues.NoneText,
        });
        Manufacturers = await ManufacturerHandler.GetManufacturersAsync();

        WidgetModel = await WidgetHandler.GetWidgetAsync(WidgetId);
        WidgetDisplayModel.WidgetId = WidgetId;
        WidgetDisplayModel.Name = WidgetModel.Name;
        WidgetDisplayModel.ManufacturerId = WidgetModel.ManufacturerId;
        WidgetDisplayModel.ColourId = WidgetModel.ColourId != null
            ? WidgetModel.ColourId
            : SelectValues.NoneValue;
        WidgetDisplayModel.ColourJustificationId = WidgetModel.ColourJustificationId != null
            ? WidgetModel.ColourJustificationId
            : SelectValues.NoneValue;
        WidgetDisplayModel.StatusId = WidgetModel.StatusId;
        WidgetDisplayModel.Manufacturer = WidgetModel.Manufacturer;
        WidgetDisplayModel.WidgetImage = WidgetModel.WidgetImage;
        WidgetDisplayModel.CostPrice = WidgetModel.CostPrice;
        WidgetDisplayModel.RetailPrice = WidgetModel.RetailPrice;

        ManufacturerInactive = WidgetModel.Manufacturer.StatusId == (int)ManufacturerStatusEnum.Inactive;

        MainLayout.SetHeaderValue("Edit Widget");
    }

    private async void UpdateWidget()
    {
        await CopyDisplayModelToModel();

        try
        {
            await WidgetHandler.UpdateWidgetAsync(WidgetModel, true);
            Snackbar.Add($"Widget {WidgetModel.Name} successfully updated.", Severity.Success);
            NavigationManager.NavigateTo("/widgets/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {WidgetModel.Name}. Please try again.", Severity.Error);
        }
    }
}
