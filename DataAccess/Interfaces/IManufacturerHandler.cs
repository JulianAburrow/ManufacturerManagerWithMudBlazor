﻿namespace DataAccess.Interfaces;

public interface IManufacturerHandler
{
    Task<ManufacturerModel> GetManufacturerAsync(int manufacturerId);

    Task<List<ManufacturerModel>> GetManufacturersAsync();

    Task CreateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges);

    Task UpdateManufacturerAsync(ManufacturerModel manufacturer, bool callSaveChanges);

    Task DeleteManufacturerAsync(int manufacturerId, bool callSaveChanges);

    Task SaveChangesAsync();
}
