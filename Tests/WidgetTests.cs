namespace Tests;

public class WidgetTests
{
    private readonly ManufacturerManagerContext _manufacturerManagerContext;
    private readonly IWidgetHandler _widgetHandler;

    public WidgetTests()
    {
        var options = new DbContextOptionsBuilder<ManufacturerManagerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _manufacturerManagerContext = new ManufacturerManagerContext(options);
        _widgetHandler = new WidgetHandler(_manufacturerManagerContext);
    }

    private readonly WidgetModel Widget1 = new()
    {
        Name = "Widget1",
        Manufacturer = new ManufacturerModel()
        {
            Name = "Manufacturer1",
            StatusId = (int)PublicEnums.ManufacturerStatusEnum.Active
        },
        StatusId = (int)PublicEnums.WidgetStatusEnum.Active,
    };

    private readonly WidgetModel Widget2 = new()
    {
        Name = "Widget2",
        Manufacturer = new ManufacturerModel()
        {
            Name = "Manufacturer2",
            StatusId = (int)PublicEnums.ManufacturerStatusEnum.Inactive
        },
        StatusId = (int)PublicEnums.WidgetStatusEnum.Inactive,
    };

    [Fact]
    public async void CreateWidgetCreatesWidget()
    {
        var initialCount = _manufacturerManagerContext.Widgets.Count();

        await _widgetHandler.CreateWidgetAsync(Widget1, false);
        await _widgetHandler.CreateWidgetAsync(Widget2, true);

        _manufacturerManagerContext.Widgets.Count().Should().Be(initialCount +2);
    }

    [Fact]
    public async void GetWidgetGetsWidget()
    {
        _manufacturerManagerContext.Widgets.Add(Widget2);
        _manufacturerManagerContext.SaveChanges();

        var returnedWidget = await _widgetHandler.GetWidgetAsync(Widget2.WidgetId);
        returnedWidget.Should().NotBeNull();
        Assert.Equal(Widget2.Name, returnedWidget.Name);
        Assert.Equal(Widget2.Manufacturer.Name, returnedWidget.Manufacturer.Name);
    }

    [Fact]
    public async void GetWidgetsGetsWidgets()
    {
        var initialCount = _manufacturerManagerContext.Widgets.Count();

        _manufacturerManagerContext.Widgets.Add(Widget1);
        _manufacturerManagerContext.Widgets.Add(Widget2);
        _manufacturerManagerContext.SaveChanges();

        var widgetsReturned = await _widgetHandler.GetWidgetsAsync();

        widgetsReturned.Count().Should().Be(initialCount +2);
    }

    [Fact]
    public async void UpdateWidgetUpdatesWidget()
    {
        var newWidget = "AcmeWidget";

        _manufacturerManagerContext.Widgets.Add(Widget1);
        _manufacturerManagerContext.SaveChanges();

        var widgetToUpdate = _manufacturerManagerContext.Widgets.First(w => w.WidgetId == Widget1.WidgetId);
        widgetToUpdate.Name = newWidget;
        await _widgetHandler.UpdateWidgetAsync(widgetToUpdate, true);

        var updatedWidget = _manufacturerManagerContext.Widgets.First(w => w.WidgetId == Widget1.WidgetId);
        updatedWidget.Name.Should().Be(newWidget);

    }
}
