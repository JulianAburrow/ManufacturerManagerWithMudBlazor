namespace Tests;

public class WidgetStatusTests
{
    private readonly ManufacturerManagerContext _manufacturerManagerContext;
    private readonly IWidgetStatusHandler _widgetStatusHandler;

    public WidgetStatusTests()
    {
        var options = new DbContextOptionsBuilder<ManufacturerManagerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _manufacturerManagerContext = new ManufacturerManagerContext(options);
        _widgetStatusHandler = new WidgetStatusHandler(_manufacturerManagerContext);
    }

    private readonly WidgetStatusModel WidgetStatus1 = new()
    {
        StatusName = PublicEnums.WidgetStatusEnum.Active.ToString(),
    };
    private readonly WidgetStatusModel WidgetStatus2 = new()
    {
        StatusName = PublicEnums.ManufacturerStatusEnum.Inactive.ToString(),
    };

    [Fact]
    public async void GetWidgetStatusesGetsWidgetStatuses()
    {
        var initialCount = _manufacturerManagerContext.WidgetStatuses.Count();

        _manufacturerManagerContext.WidgetStatuses.Add(WidgetStatus1);
        _manufacturerManagerContext.WidgetStatuses.Add(WidgetStatus2);
        _manufacturerManagerContext.SaveChanges();

        var widgetStatutusesReturned = await _widgetStatusHandler.GetWidgetStatusesAsync();

        widgetStatutusesReturned.Count().Should().Be(initialCount + 2);
    }
}
