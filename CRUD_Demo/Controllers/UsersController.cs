using CRUDDemo.BusinessLogic.Interface;
using CRUDDemo.Entities.CustomEntities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CRUDDemoWebAPI.Extensions;

namespace CRUDDemoWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        protected IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsersAsync();
            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> AddUsers([FromBody] DtoUsers model)
        {
            var response = await _userService.AddUserAsync(model);
            return response.ToHttpResponse();
        }

        [HttpPut]
        [Route("user")]
        public async Task<IActionResult> UpdateUsers([FromBody] DtoUsers model)
        {
            var response = await _userService.UpdateUserAsync(model);
            return response.ToHttpResponse();
        }

        [HttpDelete]
        [Route("users/{id:int}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var response = await _userService.DeleteUserByIdAsync(id);
            return response.ToHttpResponse();
        }
    }
}
