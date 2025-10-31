using Application.Commons;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands_Queries.Queries.Users.GetsUser
{
    public record GetUsersQuery : IRequest<BaseResponse<IEnumerable<User>>>;
}
