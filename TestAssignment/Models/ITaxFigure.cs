namespace TestAssignment.Models
{
    public interface ITaxFigure
    {
        string Account { get; set; }
        string Description { get; set; }
        string CurrencyCode { get; set; }
        int? Value { get; set; }
    }
}