using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.SitesDeleteCommand;
using WebsiteManagerPanel.Commands.SitesInsertCommand;
using WebsiteManagerPanel.Commands.SitesUpdateCommand;
using WebsiteManagerPanel.Framework.Infrastructure;
using WebsiteManagerPanel.Query;
using static WebsiteManagerPanel.Framework.RoleEnums.Enum;

namespace WebsiteManagerPanel.Controllers
{

    public class SiteController : Controller
    {
        // GET: /<controller>/

        private readonly IMediator _mediator;
        private readonly SiteQuery _siteQuery;

        public SiteController(IMediator mediator, SiteQuery siteQuery)
        {
            _mediator = mediator;
            _siteQuery = siteQuery;
        }


        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowSite)]
        public async Task<IActionResult> Sites()
        {

            var sites = await _siteQuery.GetAllAsync();
            return View("TableValue", sites);
        }

        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowSite)]
        public async Task<IActionResult> Detail(int id)
        {
            var site = await _siteQuery.GetByIdAsync(id);
            return View("Detail", site);
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeSite)]
        public async Task<IActionResult> Create()
        {

            return View();
        }
       
     

        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeSite)]
        public async Task<IActionResult> Create(SiteInsertCommand value)
        {
            var siteId = await _mediator.Send(value);
            return RedirectToAction("Create", "Definition", new { id = siteId });
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeSite)]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _siteQuery.GetSite(id);
            return View("Update",model);
        }

        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeSite)]
        public async Task<IActionResult> Update(SiteUpdateCommand value)
        {
            var siteId = await _mediator.Send(value);
            return RedirectToAction("Detail", "Site", new { id = siteId });
        }

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeSite)]
        [HttpPost()]
        public async Task<IActionResult> Delete([FromQuery] SiteDeleteCommand siteDeleteCommand)
        {
            await _mediator.Send(siteDeleteCommand);
            var result = new { Success = "True", Message = "Başarılı" };
            return Json(result);
        }
    }
}
