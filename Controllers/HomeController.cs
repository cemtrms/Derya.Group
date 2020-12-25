using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteManagerPanel.Controllers
{

    public class HomeController : Controller
    {
        // GET: /<controller>/

        public HomeController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
