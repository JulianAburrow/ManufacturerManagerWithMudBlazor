﻿using DataAccess.Data;

namespace DataAccess.Handlers;

public class WidgetHandler : IWidgetHandler
{
    private readonly ManufacturerManagerContext _context;

    public WidgetHandler(ManufacturerManagerContext context) =>
        _context = context;

    public async Task CreateWidgetAsync(WidgetModel widget, bool callSaveChanges)
    {
        _context.Widgets.Add(widget);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task DeleteWidgetAsync(int widgetId, bool callSaveChanges)
    {
        var widgetToDelete = _context.Widgets.SingleOrDefault(w => w.WidgetId == widgetId);
        if (widgetToDelete == null)
            return;
        _context.Widgets.Remove(widgetToDelete);
        if (callSaveChanges)
            await SaveChangesAsync();
    }

    public async Task<WidgetModel> GetWidgetAsync(int widgetId)
    {
        return await _context.Widgets.SingleOrDefaultAsync(w => w.WidgetId == widgetId);
    }

    public async Task<List<WidgetModel>> GetWidgetsAsync()
    {
        return await _context.Widgets.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWidgetAsync(WidgetModel widget, bool callSaveChanges)
    {
        var widgetToUpdate = _context.Widgets.SingleOrDefault(w => w.WidgetId == widget.WidgetId);
        if (widgetToUpdate == null)
            return;
        widgetToUpdate.Name = widget.Name;
        widgetToUpdate.ColourJustificationId = widget.ColourJustificationId;
        widgetToUpdate.ManufacturerId = widget.ManufacturerId;
        widgetToUpdate.StatusId = widget.StatusId;
        if (callSaveChanges)
            await SaveChangesAsync();
    }
}
