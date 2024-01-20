using AdoptMe.Service.Interfaces;
using AdoptMe.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AdoptMe.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UserAuthController(IServiceProvider serviceProvider)
        {
            _tokenService = serviceProvider.GetRequiredService<ITokenService>();
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAuthModel userAuthModel)
        {
            if (userAuthModel != null)
            {
                var user = _userService.RetrieveUser(userAuthModel.Username, userAuthModel.Password);
            }
            else
            {

            }
        }
    }
}
