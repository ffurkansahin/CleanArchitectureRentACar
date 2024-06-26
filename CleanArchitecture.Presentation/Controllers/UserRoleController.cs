using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Application.Features.UserRoleFeature.Commands.CreateUserRole;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    public class UserRoleController : ApiController
    {
        public UserRoleController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRole(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse messageResponse = await _mediator.Send(request, cancellationToken);
            return Ok(messageResponse);
        }
    }
}
