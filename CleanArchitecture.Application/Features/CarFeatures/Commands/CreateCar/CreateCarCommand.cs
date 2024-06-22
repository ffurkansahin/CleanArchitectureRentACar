using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed record CreateCarCommand
    (string Brand,
    string Model,
    int EnginePower): IRequest<MessageResponse>;
