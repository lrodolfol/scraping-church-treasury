using Bogus;

namespace TNN.Test.Fixture;
public abstract class BaseFixture
{
    protected BaseFixture() => Faker = new Faker();
    public Faker Faker { get; private set; }
}
