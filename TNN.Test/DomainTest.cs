using TNN.Domain.Entities;
using TNN.Domain.Exceptions;

namespace TNN.Test;

public class DomainTest
{
    [Theory]
    [InlineData(null, "user", "pass")]
    [InlineData("123", null, "pass")]
    [InlineData("123", "user", null)]
    public void ShoudGenerateExceptionWithNullClientValues(string CodeClient, string UserName, string Password)
    {
        var client = () => new UserClient(CodeClient, UserName, Password);
        Assert.Throws<DomainException>(client);        
    }

    public static IEnumerable<object[]> GetClients()
    {
        yield return new object[] { "123", "user", "pass" };
        yield return new object[] { "123", "user", "pass" };
        yield return new object[] { "123", "user", "pass" };
    }
}