using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.FieldsDeleteCommand;
using WebsiteManagerPanel.Commands.FieldsInsertCommand;
using WebsiteManagerPanel.Data.Entities.Enums;
using WebsiteManagerPanel.Framework.Infrastructure;
using WebsiteManagerPanel.Query;
using WebsiteManagerPanel.Models;
using static WebsiteManagerPanel.Framework.RoleEnums.Enum;
using WebsiteManagerPanel.Commands.FieldsUpdateCommand;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebsiteManagerPanel.Controllers
{

    public class FieldController : Controller
    {
        // GET: /<controller>/

        private readonly IMediator _mediator;
        private readonly FieldQuery _fieldQuery;
        private readonly DefinitionQuery _definitionQuery;
        private readonly FieldValueQuery _fieldValueQuery;

        public FieldController(IMediator mediator,  FieldQuery fieldQuery,DefinitionQuery definitionQuery, FieldValueQuery fieldValueQuery)
        {
            _mediator = mediator;
            _fieldQuery = fieldQuery;
            _definitionQuery = definitionQuery;
            _fieldValueQuery = fieldValueQuery;
        }
       
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowField)]
        public async Task<IActionResult> Fields()
        {

             var fields = await _fieldQuery.GetAllAsync();
            return View("TableValue", fields);
        }

        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowField)]
        public async Task<IActionResult> Detail(int id)
        {

            var field = await _fieldQuery.GetByIdAsync(id);
            return View("Detail", field);
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(int definitionId)
        {
            var model = await _definitionQuery.GetFieldForInsert(definitionId);
            
            return View("Create",model);
        }
       

        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(FieldInsertCommand value)
        {
            int result = await _mediator.Send(value);
            return RedirectToAction("Fields");
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _fieldQuery.GetField(id);

            return View("Update", model);
        }


        // POST api/values
        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(FieldUpdateCommand value)
        {
            int result = await _mediator.Send(value);
            return RedirectToAction("Detail", new { id = result });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FieldDeleteCommand model)
        {
            await _mediator.Send(model);
            var result = new { Success = "True", Message = "Başarılı" };
            return Json(result);
        }
    }
}
