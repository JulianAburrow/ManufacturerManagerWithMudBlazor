﻿namespace ManufacturerManagerUserInterface.Shared.Components;

public partial class WidgetGridViewComponent
{
    [Parameter] public List<WidgetModel> Widgets { get; set; } = null!;

    private decimal TotalStockValue { get; set; }

    protected override void OnParametersSet()
    {
        GetTotalWidgetStockValue();
    }

    public void GetTotalWidgetStockValue()
    {
        TotalStockValue = 0;
        foreach (var widget in Widgets)
        {
            TotalStockValue += widget.StockLevel * widget.CostPrice;
        }
    }
}
