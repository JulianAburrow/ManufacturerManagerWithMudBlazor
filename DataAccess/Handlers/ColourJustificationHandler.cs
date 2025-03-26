﻿namespace DataAccess.Handlers;

public class ColourJustificationHandler : IColourJustificationHandler
{
    private readonly ManufacturerManagerContext _context;

    public ColourJustificationHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task CreateColourJustificationAsync(ColourJustificationModel colourJustification, bool callSaveChanges)
    {
        _context.ColourJustifications.Add(colourJustification);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task DeleteColourJustificationAsync(int colourJustificationId, bool callSaveChanges)
    {
        var colourJustificationToDelete = _context.ColourJustifications.SingleOrDefault(c => c.ColourJustificationId == colourJustificationId);
        if (colourJustificationToDelete == null)
            return;
        _context.ColourJustifications.Remove(colourJustificationToDelete);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task<ColourJustificationModel> GetColourJustificationAsync(int colourJustificationId) =>
        await _context.ColourJustifications
            .Include(c => c.Widgets)
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.ColourJustificationId == colourJustificationId);

    public async Task<List<ColourJustificationModel>> GetColourJustificationsAsync() =>
        await _context.ColourJustifications
            .Include(c => c.Widgets)
            .AsNoTracking()
            .ToListAsync();

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public async Task UpdateColourJustificationAsync(ColourJustificationModel colourJustification, bool callSaveChanges)
    {
        var colourJustificationToUpdate = _context.ColourJustifications.SingleOrDefault(c => c.ColourJustificationId == colourJustification.ColourJustificationId);
        if (colourJustificationToUpdate == null)
            return;
        colourJustificationToUpdate.Justification = colourJustification.Justification;
        if (callSaveChanges)
            await SaveChangesAsync();
    }
}
