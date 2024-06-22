using CleanArchitecture.Domain.Abstraction;

namespace CleanArchitecture.Domain.Entites;

public sealed class Car : Entity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }
}
