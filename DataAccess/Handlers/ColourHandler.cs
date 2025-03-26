﻿namespace DataAccess.Handlers;

public class ColourHandler : IColourHandler
{
    private readonly ManufacturerManagerContext _context;

    public ColourHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task CreateColourAsync(ColourModel colour, bool callSaveChanges)
    {
        _context.Colours.Add(colour);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task DeleteColourAsync(int colourId, bool callSaveChanges)
    {
        var colourToDelete = _context.Colours.SingleOrDefault(c => c.ColourId == colourId);
        if (colourToDelete == null)
            return;
        _context.Colours.Remove(colourToDelete);
        if ( callSaveChanges )
            await SaveChangesAsync();
    }

    public async Task<ColourModel> GetColourAsync(int colourId) =>
        await _context.Colours
            .Include(c => c.Widgets)
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.ColourId == colourId);

    public async Task<List<ColourModel>> GetColoursAsync() =>
        await _context.Colours
            .Include(c => c.Widgets)
            .AsNoTracking()
            .ToListAsync();

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public async Task UpdateColourAsync(ColourModel colour, bool callSaveChanges)
    {
        var colourToUpdate = _context.Colours.SingleOrDefault(c => c.ColourId == colour.ColourId);
        if (colourToUpdate == null)
            return;

        colourToUpdate.Name = colour.Name;
        if (callSaveChanges)
            await SaveChangesAsync();
    }
}
