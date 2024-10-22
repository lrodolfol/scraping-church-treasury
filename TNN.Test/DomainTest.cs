using TNN.Domain.Entities;
using TNN.Domain.Exceptions;
using TNN.Test.Fixture;

namespace TNN.Test;

[Collection(nameof(UserClientTestFixture))]
public class DomainTest
{

    [Theory]
    [InlineData(null, "user", "pass", "CodeClient can not be null or empty")]
    [InlineData("123", null, "pass", "UserName can not be null or empty")]
    [InlineData("123", "user", null, "Password can not be null or empty")]
    public void ShoudGenerateExceptionWithNullClientValues(string CodeClient, string UserName, string Password, string MessageErroReturn)
    {
        var client = () => new UserClient(CodeClient, UserName, Password);
        var exception = Assert.Throws<DomainException>(client);   
        
        Assert.Equal(MessageErroReturn, exception.Message);
    }

    [Theory]
    [MemberData(nameof(GetClients))]
    public void ShoudGenerateExceptionWithEmptyClientValues(string CodeClient, string UserName, string Password, string MessageErroReturn)
    {
        var client = () => new UserClient(CodeClient, UserName, Password);
        var exception = Assert.Throws<DomainException>(client);

        Assert.Equal(MessageErroReturn, exception.Message);
    }

    public static IEnumerable<object[]> GetClients()
    {
        var _fixture = new UserClientTestFixture();

        yield return new object[] { "", _fixture.GetValidUserName(), _fixture.GetValidPassword(), "CodeClient can not be null or empty" };
        yield return new object[] { _fixture.GetValidCodeClient(), "", _fixture.GetValidPassword(), "UserName can not be null or empty" };
        yield return new object[] { _fixture.GetValidCodeClient(), _fixture.GetValidUserName(), "", "Password can not be null or empty" };
    }
}