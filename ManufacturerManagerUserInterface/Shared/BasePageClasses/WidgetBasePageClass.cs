namespace ManufacturerManagerUserInterface.Shared.BasePageClasses;

public abstract class WidgetBasePageClass : BasePageClass
{
    [Inject] protected IWidgetHandler WidgetHandler { get; set; } = default!;

    [Inject] protected IWidgetStatusHandler WidgetStatusHandler { get; set; } = default!;

    [Inject] protected IColourHandler ColourHandler { get; set; } = default!;

    [Inject] protected IColourJustificationHandler ColourJustificationHandler { get; set; } = default!;

    [Inject] protected IManufacturerHandler ManufacturerHandler { get; set; } = default!;

    [Parameter] public int WidgetId { get; set; }

    protected WidgetModel WidgetModel = new();

    protected WidgetDisplayModel WidgetDisplayModel = new();

    public required List<WidgetStatusModel> WidgetStatuses { get; set; }

    public required List<ColourModel> Colours { get; set; }

    public required List<ColourJustificationModel> ColourJustifications { get; set; }

    public required List<ManufacturerModel> Manufacturers { get; set; }

    protected IBrowserFile WidgetImage = null!;

    protected string FileName = string.Empty;

    protected async Task CopyDisplayModelToModel()
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
        WidgetModel.CostPrice = WidgetDisplayModel.CostPrice;
        WidgetModel.RetailPrice = WidgetDisplayModel.RetailPrice;
        WidgetModel.StockLevel = WidgetDisplayModel.StockLevel;

        if (WidgetImage != null)
        {
            var imageMemoryStream = await ToMemoryStreamAsync(WidgetImage.OpenReadStream());
            WidgetModel.WidgetImage = imageMemoryStream.ToArray();
        }
    }

    protected static async Task<MemoryStream> ToMemoryStreamAsync(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        return memoryStream;
    }

    protected void UploadFile(IBrowserFile file)
    {
        if (file == null)
        {
            return;
        }
        try
        {
            WidgetImage = file;
            FileName = file.Name;
            Snackbar.Add($"File {FileName} successfully uploaded", Severity.Success);
        }
        catch
        {
            Snackbar.Add($"An error occurred uploading {file.Name}. Please try again.", Severity.Error);
        }
    }

    protected void RemoveImage()
    {
        WidgetImage = null!;
        WidgetDisplayModel.WidgetImage = null!;
        FileName = string.Empty;
        StateHasChanged();
    }
}
