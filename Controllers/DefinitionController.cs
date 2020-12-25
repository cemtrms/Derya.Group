using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.DefinitionsDeleteCommand;
using WebsiteManagerPanel.Commands.DefinitionsInsertCommand;
using WebsiteManagerPanel.Framework.Infrastructure;
using WebsiteManagerPanel.Query;
using WebsiteManagerPanel.Models;
using static WebsiteManagerPanel.Framework.RoleEnums.Enum;
using WebsiteManagerPanel.Commands.DefinitionsUpdateCommand;

namespace WebsiteManagerPanel.Controllers
{

    public class DefinitionController : Controller
    {
        // GET: /<controller>/

        private readonly IMediator _mediator;
        private readonly DefinitionQuery _definitionQuery;
        private readonly SiteQuery _siteQuery;
        public DefinitionController(IMediator mediator,DefinitionQuery  definitionQuery,SiteQuery siteQuery)
        {
            _mediator = mediator;
            _definitionQuery = definitionQuery;
            _siteQuery = siteQuery;
        }


       
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowDefinition)]
        public async Task<IActionResult> Definitions()
        {

             var definitions = await _definitionQuery.GetAllAsync();
            return View("TableValue", definitions);
        }

        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowField)]
        public async Task<IActionResult> Detail(int id)
        {

            var definition = await _definitionQuery.GetByIdAsync(id);
            return View("Detail", definition);
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(int id)
        {
            var model = await _siteQuery.GetSiteName(id);
            return View("Create",model);
        }
       

        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(DefinitionInsertCommand value)
        {
            int defId = await _mediator.Send(value);
            return RedirectToAction("Create","Field", new { siteId=value.SiteId, definitionId= defId});
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _definitionQuery.GetDefinition(id);
            return View("Update", model);
        }


        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(DefinitionUpdateCommand value)
        {
            int defId = await _mediator.Send(value);
            return RedirectToAction("Detail", "Definition", new { id = defId });
        }

        [HttpPost]
        public async  Task<IActionResult> Delete(DefinitionDeleteCommand model)
        {
            await _mediator.Send(model);
            var result = new { Success = "True", Message = "Başarılı" };
            return Json(result);
        }
    }
}
