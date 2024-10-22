using TNN.Domain.Entities;
using TNN.Domain.Enums;
using TNN.Domain.Exceptions;
using TNN.Test.Fixture;

namespace TNN.Test.DomainTest;
public class ExpenseTest
{
    [Fact(DisplayName = nameof(ShouldCreateValidExpense))]
    public void ShouldCreateValidExpense()
    {
        var _fixture = new ExpenseFixture();

        var expense = new Expense(
            _fixture.GetValidDate(),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor()
            );

        Assert.Equal(1, 1);
    }

    [Theory(DisplayName = nameof(ShouldGenerateExceptionWithNullExpenseValues))]
    [MemberData(nameof(GetInValidClientsWithNullValues))]
    public void ShouldGenerateExceptionWithNullExpenseValues(
        DateOnly date, string dayOfWeek, Origin origin, string congregation, Method method, 
        decimal amount, string history, string minister, string offeror, string messageErroReturn)
    {
        var expense = () => new Expense(date, dayOfWeek, origin, congregation, method, amount, history, minister, offeror);

        var exception = Assert.Throws<DomainException>(expense);

        Assert.Equal(messageErroReturn, exception.Message);
    }

    [Theory(DisplayName = nameof(ShouldGenerateExceptionWithEmptyExpenseValues))]
    [MemberData(nameof(GetInValidClientsWithEmptyValues))]
    public void ShouldGenerateExceptionWithEmptyExpenseValues(
    DateOnly date, string dayOfWeek, Origin origin, string congregation, Method method,
    decimal amount, string history, string minister, string offeror, string messageErroReturn)
    {
        var expense = () => new Expense(date, dayOfWeek, origin, congregation, method, amount, history, minister, offeror);

        var exception = Assert.Throws<DomainException>(expense);

        Assert.Equal(messageErroReturn, exception.Message);
    }

    [Theory(DisplayName = nameof(ShouldGenerateExceptionWithEmptyExpenseValues))]
    [MemberData(nameof(GetInValidClientsWithInvalidDateValues))]
    public void ShouldGenerateExceptionWithInvalidDateExpenseValues(DateOnly date, string dayOfWeek, Origin origin, string congregation, Method method,
    decimal amount, string history, string minister, string offeror, string messageErroReturn)
    {
        var expense = () => new Expense(date, dayOfWeek, origin, congregation, method, amount, history, minister, offeror);

        var exception = Assert.Throws<DomainException>(expense);

        Assert.Equal(messageErroReturn, exception.Message);
    }

    public static IEnumerable<object[]> GetInValidClientsWithEmptyValues()
    {
        var _fixture = new ExpenseFixture();

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            "",
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "DayOfWeek can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            "",
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "Congregation can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            "",
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "History can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            "",
            _fixture.GetValidOfferor(),
            "Minister can not be null or empty"
        };
    }

    public static IEnumerable<object[]> GetInValidClientsWithNullValues()
    {
        var _fixture = new ExpenseFixture();

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            null,
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "DayOfWeek can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            null,
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "Congregation can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            null,
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "History can not be null or empty"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.UtcNow),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            null,
            _fixture.GetValidOfferor(),
            "Minister can not be null or empty"
        };
    }

    public static IEnumerable<object[]> GetInValidClientsWithInvalidDateValues()
    {
        var _fixture = new ExpenseFixture();

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.MinValue),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "Date is Invalid"
        };

        yield return new object[] {
            DateOnly.FromDateTime(DateTime.MaxValue),
            _fixture.GetValidDayOfWeek(),
            _fixture.GetValidOrigin(),
            _fixture.GetValidCongreation(),
            _fixture.GetValidMethod(),
            _fixture.GetValidAmount(),
            _fixture.GetValidHistory(),
            _fixture.GetValidMinister(),
            _fixture.GetValidOfferor(),
            "Date is Invalid"
        };
    }
}
