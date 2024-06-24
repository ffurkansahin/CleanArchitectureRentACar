using CleanArchitecture.Domain.Entites;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed record GetAllCarQuery(
        int pageNumber = 1,
        int pageSize = 10,
        string search ="") : IRequest<PaginationResult<Car>>;
}
