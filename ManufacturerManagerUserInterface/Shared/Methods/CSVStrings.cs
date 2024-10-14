namespace ManufacturerManagerUserInterface.Shared.Methods;

public static class CSVStrings
{
    public static string CreateWidgetsCSVString(List<WidgetModel> widgets)
    {
        var netStockValue = 0m;
        var widgetsSB = new StringBuilder();
        widgetsSB.Append("Name,Manufacturer,Colour,Cost Price,Stock Level,Net Stock Value,Status");
        widgetsSB.Append(Environment.NewLine);
        foreach (var widget in widgets)
        {
            var widgetStockValue = widget.CostPrice * widget.StockLevel;
            netStockValue += widgetStockValue;
            widgetsSB.Append($"{RemoveCommas(widget.Name)},{RemoveCommas(widget.Manufacturer.Name)},{widget.Colour?.Name ?? "None"},{widget.CostPrice},{widget.StockLevel.ToString()},{widgetStockValue},{widget.Status.StatusName}");
            widgetsSB.Append(Environment.NewLine);
        }
        widgetsSB.Append($",,,,Total Net Value,{netStockValue},");

        return widgetsSB.ToString();
    }

    public static string CreateManufacturersCSVString(List<ManufacturerModel> manufacturers)
    {
        var manufacturersSB = new StringBuilder();
        manufacturersSB.Append("Name,Status,Widget Count");
        manufacturersSB.Append(Environment.NewLine);
        foreach(var manufacturer in manufacturers)
        {
            manufacturersSB.Append($"{RemoveCommas(manufacturer.Name)},");
            manufacturersSB.Append($"{manufacturer.Status.StatusName},");
            manufacturersSB.Append($"{manufacturer.Widgets.Count} ({manufacturer.Widgets.Where(w => w.StatusId == 2).Count()} inactive)");
            manufacturersSB.Append(Environment.NewLine);
        }

        return manufacturersSB.ToString();
    }

    private static string RemoveCommas(string? stringToCheck)
    {
        if (stringToCheck == null)
            return string.Empty;
        return stringToCheck.Replace(",", "-");
    }

}
