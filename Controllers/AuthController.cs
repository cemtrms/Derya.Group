using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.UsersInsertCommand;
using WebsiteManagerPanel.Framework.Extensions;
using WebsiteManagerPanel.Query;
using WebsiteManagerPanel.Models;

namespace WebAPI.Controllers
{

    public class AuthController : Controller
    {
        private readonly UserQuery _userQuery;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthController(UserQuery userQuery, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _userQuery = userQuery;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginViewModel userForLoginView)
        {
            var user = await _userQuery.LoginAsync(userForLoginView);
            HttpContext.Session.SetObjectAsJson("User", user);
            return RedirectToAction("Sites", "Site");
        }

       [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("User");
            return RedirectToAction("Login", "Auth");
        }

        
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        public async Task<ActionResult> Register(UserInsertCommand userForRegisterView)
        {
          var userId=  await _mediator.Send(userForRegisterView);
            HttpContext.Session.SetInt32("UserId", userId);
            return RedirectToAction("Sites", "Site");
        }
    }
}
