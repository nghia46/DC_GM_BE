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
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, BaseResponse<IEnumerable<User>>>
    {
        public Task<BaseResponse<IEnumerable<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
