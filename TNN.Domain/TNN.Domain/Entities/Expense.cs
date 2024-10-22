using TNN.Domain.Enums;
using TNN.Domain.Exceptions;

namespace TNN.Domain.Entities;
public class Expense
{
    public Expense(DateOnly date, string dayOfWeek, Origin origin, string congregation, 
        Method method, decimal amount, string history, string? minister, string? offeror)
    {
        Date = date;
        DayOfWeek = dayOfWeek;
        Origin = origin;
        Congregation = congregation;
        Method = method;
        Amount = amount;
        History = history;
        Minister = minister;
        Offeror = offeror;

        Validate();
    }

    public DateOnly Date { get; private set; }
    public string DayOfWeek { get; private set; } = null!;
    public Origin Origin { get; private set; } = Origin.Outros;
    public string Congregation { get; private set; } = null!;
    public Method Method { get; private set; }
    public decimal Amount { get; private set; }
    public string History { get; private set; } = null!;
    public string? Minister { get; private set; }
    public string? Offeror { get; set; } = null!;
    private void Validate()
    {
        if (string.IsNullOrEmpty(DayOfWeek))
            throw new DomainException("DayOfWeek can not be null or empty");
        if (string.IsNullOrEmpty(Congregation))
            throw new DomainException("Congregation can not be null or empty");
        if (string.IsNullOrEmpty(History))
            throw new DomainException("History can not be null or empty");
        if (string.IsNullOrEmpty(Minister))
            throw new DomainException("Minister can not be null or empty");
        if (string.IsNullOrEmpty(Offeror))
            throw new DomainException("Offeror can not be null or empty");
        if (Date == DateOnly.FromDateTime(DateTime.MinValue) || Date == DateOnly.FromDateTime(DateTime.MaxValue))
            throw new DomainException("Date is Invalid");
        if (Date > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new DomainException("Date can not be greater than today");
    }
}
