﻿namespace Tests;

public class ManufacturerStatusTests
{
    private readonly ManufacturerManagerContext _manufacturerManagerContext;
    private readonly IManufacturerStatusHandler _manufacturerStatusHandler;

    public ManufacturerStatusTests()
    {
        var options = new DbContextOptionsBuilder<ManufacturerManagerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _manufacturerManagerContext = new ManufacturerManagerContext(options);
        _manufacturerStatusHandler = new ManufacturerStatusHandler(_manufacturerManagerContext);
    }

    private readonly ManufacturerStatusModel ManufacturerStatus1 = new()
    {
        StatusName = PublicEnums.ManufacturerStatusEnum.Active.ToString(),
    };
    private readonly ManufacturerStatusModel ManufacturerStatus2 = new()
    {
        StatusName = PublicEnums.ManufacturerStatusEnum.Inactive.ToString(),
    };

    [Fact]
    private async void GetManufacturerStatusesGetsManufacturerStatuses()
    {
        var initialCount = _manufacturerManagerContext.ManufacturerStatuses.Count();

        _manufacturerManagerContext.ManufacturerStatuses.Add(ManufacturerStatus1);
        _manufacturerManagerContext.ManufacturerStatuses.Add(ManufacturerStatus2);
        _manufacturerManagerContext.SaveChanges();

        var manufacturerStatutusesReturned = await _manufacturerStatusHandler.GetManufacturerStatusesAsync();

        manufacturerStatutusesReturned.Count().Should().Be(initialCount + 2);
    }
}
