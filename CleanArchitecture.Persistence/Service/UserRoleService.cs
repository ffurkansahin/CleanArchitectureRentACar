using CleanArchitecture.Application.Features.UserRoleFeature.Commands.CreateUserRole;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Repositories;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository? _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository? repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRoles userRoles = new() { RoleId = request.RoleId,
            UserId=request.UserId};
            await _repository.AddAsync(userRoles, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
