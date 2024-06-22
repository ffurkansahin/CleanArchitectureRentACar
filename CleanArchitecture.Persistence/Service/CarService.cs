using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Service
{
    public sealed class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CarService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            await _context.Set<Car>().AddAsync(car);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
