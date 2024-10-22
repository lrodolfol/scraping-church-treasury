using TNN.Domain.Entities;
using TNN.Domain.Exceptions;
using TNN.Test.Fixture;

namespace TNN.Test.DomainTest;

[Collection(nameof(UserClientTestFixture))]
public class UserClientTest
{

    [Theory(DisplayName = nameof(ShoudGenerateExceptionWithNullClientValues))]
    [InlineData(null, "user", "pass", "CodeClient can not be null or empty")]
    [InlineData("123", null, "pass", "UserName can not be null or empty")]
    [InlineData("123", "user", null, "Password can not be null or empty")]
    public void ShoudGenerateExceptionWithNullClientValues(string codeClient, string userName, string password, string messageErroReturn)
    {
        var client = () => new UserClient(codeClient, userName, password);
        var exception = Assert.Throws<DomainException>(client);

        Assert.Equal(messageErroReturn, exception.Message);
    }

    [Theory(DisplayName = nameof(ShoudGenerateExceptionWithEmptyClientValues))]
    [MemberData(nameof(GetInvalidClients))]
    public void ShoudGenerateExceptionWithEmptyClientValues(string codeClient, string userName, string password, string messageErroReturn)
    {
        var client = () => new UserClient(codeClient, userName, password);
        var exception = Assert.Throws<DomainException>(client);

        Assert.Equal(messageErroReturn, exception.Message);
    }

    [Theory(DisplayName = nameof(ShoudGenerateExceptionWithEmptyClientValues))]
    [MemberData(nameof(GetValidClients))]
    public void ShoudCreateUserClientSuccess(string codeClient, string userName, string password)
    {
        var client = new UserClient(codeClient, userName, password);

        Assert.Equal(codeClient, client.CodeClient);
        Assert.Equal(userName, client.UserName);
        Assert.Equal(password, client.Password);
    }

    public static IEnumerable<object[]> GetInvalidClients()
    {
        var _fixture = new UserClientTestFixture();

        yield return new object[] { "", _fixture.GetValidUserName(), _fixture.GetValidPassword(), "CodeClient can not be null or empty" };
        yield return new object[] { _fixture.GetValidCodeClient(), "", _fixture.GetValidPassword(), "UserName can not be null or empty" };
        yield return new object[] { _fixture.GetValidCodeClient(), _fixture.GetValidUserName(), "", "Password can not be null or empty" };
    }
    public static IEnumerable<object[]> GetValidClients()
    {
        var _fixture = new UserClientTestFixture();

        yield return new object[] { _fixture.GetValidCodeClient(), _fixture.GetValidUserName(), _fixture.GetValidPassword() };
        yield return new object[] { _fixture.GetValidCodeClient(), _fixture.GetValidUserName(), _fixture.GetValidPassword() };
        yield return new object[] { _fixture.GetValidCodeClient(), _fixture.GetValidUserName(), _fixture.GetValidPassword() };
    }
}