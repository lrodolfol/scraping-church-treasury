using TNN.Domain.Enums;

namespace TNN.Test.Fixture;
public class ExpenseFixture : BaseFixture
{
    public DateOnly GetValidDate() => Faker.Date.BetweenDateOnly(new(2021, 1, 1), new(DateTime.Now.Year, 12, 31));
    public string GetValidDayOfWeek() => "Domingo";
    public Origin GetValidOrigin()
    {
        var randon = new Random().Next(1, 4);
        return (Origin)randon;
    }
    public string GetValidCongreation() => "CEO - Carmo de minas";
    public Method GetValidMethod() 
    {
        var randon = new Random().Next(1, 3);
        return (Method)randon;
    }
    public Decimal GetValidAmount() => Faker.Random.Decimal(0.1m, 100m);
    public string GetValidHistory() => Faker.Lorem.Sentence();
    public string GetValidMinister() => Faker.Name.FullName();
    public string GetValidOfferor() => Faker.Name.FullName();
}
