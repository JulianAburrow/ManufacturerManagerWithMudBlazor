﻿namespace ManufacturerManagerUserInterface.Shared.Components;

public partial class ManufacturerGridViewComponent
{
    [Parameter] public List<ManufacturerModel> Manufacturers { get; set; } = null!;
}
