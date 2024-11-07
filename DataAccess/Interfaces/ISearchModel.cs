namespace DataAccess.Interfaces;

public interface ISearchModel
{
    public string SearchText { get; set; }

    public int ActiveStatus { get; set; }
}
