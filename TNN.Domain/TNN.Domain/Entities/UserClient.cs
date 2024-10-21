
using TNN.Domain.Exceptions;

namespace TNN.Domain.Entities;
public class UserClient
{
    public UserClient(string codeClient, string userName, string password)
    {
        CodeClient = codeClient;
        UserName = userName;
        Password = password;

        Validate();
    }

    public string CodeClient { get; private set; } = null!;
    public string UserName { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    private void Validate()
    {
        if (string.IsNullOrEmpty(CodeClient))
            throw new DomainException("CodeClient can not be null or empty");
        if(string.IsNullOrEmpty(UserName))
            throw new DomainException("UserName can not be null or empty");
        if(string.IsNullOrEmpty(Password))
            throw new DomainException("Password can not be null or empty");
    }
}
