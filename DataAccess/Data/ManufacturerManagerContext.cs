namespace DataAccess.Data;

public class ManufacturerManagerContext : DbContext
{
    public ManufacturerManagerContext(DbContextOptions<ManufacturerManagerContext> options)
        : base(options)
    {
    }

    public DbSet<ColourModel> Colours { get; set; }
    public DbSet<ColourJustificationModel> ColourJustifications { get; set; }
    public DbSet<ManufacturerModel> Manufacturers { get; set; }
    public DbSet<ManufacturerStatusModel> ManufacturerStatuses { get; set; }
    public DbSet<WidgetModel> Widgets { get; set; }
    public DbSet<WidgetStatusModel> WidgetStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
            .Where(p => p.ClrType == typeof(string))))
        {
            property.SetIsUnicode(false);
        }

        builder.ApplyConfiguration(new ColourConfiguration());
        builder.ApplyConfiguration(new ColourJustificationConfiguration());
        builder.ApplyConfiguration(new ManufacturerConfiguration());
        builder.ApplyConfiguration(new ManufacturerStatusConfiguration());
        builder.ApplyConfiguration(new WidgetConfiguration());
        builder.ApplyConfiguration(new WidgetStatusConfiguration());
    }
}
