namespace DataAccess.Interfaces;

public interface IWidgetStatusHandler
{
    Task<List<WidgetStatusModel>> GetWidgetStatusModelsAsync();
}
