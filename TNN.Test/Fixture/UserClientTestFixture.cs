namespace TNN.Test.Fixture;
public class UserClientTestFixture : BaseFixture
{
    public string GetValidPassword() => Faker.Random.AlphaNumeric(8);
    public string GetValidUserName() => Faker.Person.FirstName;
    public string GetValidCodeClient() => Faker.Random.AlphaNumeric(6);    
}
