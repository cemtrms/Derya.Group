using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;
using WebsiteManagerPanel.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteManagerPanel.Controllers
{

    public class ErrorController : Controller
    {
        // GET: /<controller>/

        public ErrorController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
          
            return View("NotFoundError");
        }
        public IActionResult InternalServerError()
        {

            return View("InternalServerError");
        }

        public IActionResult Auth()
        {

            return View("Auth");
        }
    }
}
