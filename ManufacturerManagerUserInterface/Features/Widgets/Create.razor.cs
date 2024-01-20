namespace ManufacturerManagerUserInterface.Features.Widgets;

public partial class Create
{
    protected override async Task OnInitializedAsync()
    {
        WidgetStatuses = await WidgetStatusHandler.GetWidgetStatusesAsync();
        Colours = await ColourHandler.GetColoursAsync();
        ColourJustifications = await ColourJustificationHandler.GetColourJustificationsAsync();
        Manufacturers = await ManufacturerHandler.GetManufacturersAsync();
        Manufacturers.Insert(0, new()
        {
            ManufacturerId = SelectValues.PleaseSelectValue,
            Name = SelectValues.PleaseSelectText,
        });
        WidgetDisplayModel.ManufacturerId = SelectValues.PleaseSelectValue;
        Colours.Insert(0, new()
        {
            ColourId = SelectValues.NoneValue,
            Name = SelectValues.NoneText,
        });
        WidgetDisplayModel.ColourId = SelectValues.PleaseSelectValue;
        ColourJustifications.Insert(0, new()
        {
            ColourJustificationId = SelectValues.NoneValue,
            Justification = SelectValues.NoneText,
        });
        WidgetDisplayModel.ColourJustificationId = SelectValues.PleaseSelectValue;
        WidgetStatuses.Insert(0, new()
        {
            StatusId = SelectValues.PleaseSelectValue,
            StatusName = SelectValues.PleaseSelectText,
        });
        WidgetDisplayModel.StatusId = SelectValues.PleaseSelectValue;

        MainLayout.SetHeaderValue("Create Widget");
    }

    private async Task CreateWidget()
    {
        WidgetModel.Name = WidgetDisplayModel.Name;
        WidgetModel.ManufacturerId = WidgetDisplayModel.ManufacturerId;
        WidgetModel.ColourId = WidgetDisplayModel.ColourId != SelectValues.NoneValue
            ? WidgetDisplayModel.ColourId
            : null;
        WidgetModel.ColourJustificationId = WidgetDisplayModel.ColourJustificationId != SelectValues.NoneValue
            ? WidgetDisplayModel.ColourJustificationId
            : null;
        WidgetModel.StatusId = WidgetDisplayModel.StatusId;

        try
        {
            await WidgetHandler.CreateWidgetAsync(WidgetModel, true);
            Snackbar.Add($"Widget {WidgetModel.Name} successfully created.", Severity.Success);
            NavigationManager.NavigateTo("/widgets/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating Widget {WidgetModel.Name}. Please try again.", Severity.Error);
        }
    }
}
