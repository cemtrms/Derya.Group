using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Enums;
using WebsiteManagerPanel.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteManagerPanel.Controllers
{

    public class EnumController : Controller
    {
        // GET: /<controller>/

        public EnumController()
        {

        }

        public JsonResult Select2(string semester)
        {
            var list = ((FieldType[])Enum.GetValues(typeof(FieldType))).Select(c => new ListItem { Value = ((byte)c).ToString(), Text = c.ToString() }).ToList();

            return Json(list);
        }

    }
}
