using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Service
{
    public sealed class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(AppDbContext context, IMapper mapper, IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            //await _context.Set<Car>().AddAsync(car,cancellationToken);
            //await _context.SaveChangesAsync(cancellationToken);

            await _carRepository.AddAsync(car,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars = await _carRepository
                .GetWhere(i=>i.Brand.ToLower().Contains(request.search.ToLower()))
                .OrderBy(i=>i.Brand)
                .ToPagedListAsync(request.pageNumber,request.pageSize,cancellationToken);
            return cars;
        }
    }
}
