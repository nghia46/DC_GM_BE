using API.Extentions;
using Application.Commands_Queries.Queries.Users.GetsUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var result = await sender.Send(query, cancellationToken);
            return result.ToActionResult();
        }
    }
}
