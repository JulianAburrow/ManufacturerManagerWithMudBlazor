﻿using System.Runtime.CompilerServices;

namespace Tests;

public class ColourTests
{
    private readonly ManufacturerManagerContext _manufacturerManagerContext;
    private readonly IColourHandler _colourHandler;

    public ColourTests()
    {
        var options = new DbContextOptionsBuilder<ManufacturerManagerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _manufacturerManagerContext = new ManufacturerManagerContext(options);
        _colourHandler = new ColourHandler(_manufacturerManagerContext);
    }

    private readonly ColourModel ColourRed = new()
    {
        Name = "Red",
    };
    private readonly ColourModel ColourBlue = new()
    {
        Name = "Blue",
    };
    private readonly ColourModel ColourGreen = new()
    {
        Name = "Green",
    };
    private readonly ColourModel ColourYellow = new()
    {
        Name = "Yellow",
    };

    [Fact]
    public async void AddColourAddsColour()
    {
        var initialCount = _manufacturerManagerContext.Colours.Count();

        await _colourHandler.CreateColourAsync(ColourRed, false);
        await _colourHandler.CreateColourAsync(ColourGreen, false);
        await _colourHandler.CreateColourAsync(ColourBlue, false);
        await _colourHandler.CreateColourAsync(ColourYellow, true);

        _manufacturerManagerContext.Colours.Count().Should().Be(initialCount + 4);
    }

    [Fact]
    public async void GetColourGetsColour()
    {
        _manufacturerManagerContext.Colours.Add(ColourYellow);
        _manufacturerManagerContext.SaveChanges();

        var returnedColour = await _colourHandler.GetColourAsync(ColourYellow.ColourId);
        returnedColour.Should().NotBeNull();
        returnedColour.Name.Should().Be(ColourYellow.Name);
    }

    [Fact]
    public async void GetColoursGetsColours()
    {
        var initialCount = _manufacturerManagerContext.Colours.Count();

        await _colourHandler.CreateColourAsync(ColourRed, false);
        await _colourHandler.CreateColourAsync(ColourGreen, false);
        await _colourHandler.CreateColourAsync(ColourBlue, false);
        await _colourHandler.CreateColourAsync(ColourYellow, true);

        var colours = await _colourHandler.GetColoursAsync();

        colours.Count().Should().Be(initialCount + 4);
    }

    [Fact]
    public async void UpdateColourUpdatesColour()
    {
        var newColourName = "Violet";

        _manufacturerManagerContext.Colours.Add(ColourRed);
        _manufacturerManagerContext.SaveChanges();

        var colourToUpdate = _manufacturerManagerContext.Colours.First(c => c.ColourId == ColourRed.ColourId);
        colourToUpdate.Name = newColourName;
        await _colourHandler.UpdateColourAsync(colourToUpdate, true);

        var updatedColour = _manufacturerManagerContext.Colours.First(c => c.ColourId == ColourRed.ColourId);
        updatedColour.Name.Should().Be(newColourName);
    }

    [Fact]
    public async void DeleteColourDeletesColour()
    {
        int colourId;

        _manufacturerManagerContext.Colours.Add(ColourBlue);
        _manufacturerManagerContext.SaveChanges();
        colourId = ColourBlue.ColourId;

        await _colourHandler.DeleteColourAsync(colourId, true);

        var deletedColour = _manufacturerManagerContext.Colours.FirstOrDefault(c => c.ColourId == colourId);

        deletedColour.Should().BeNull();
    }
}
