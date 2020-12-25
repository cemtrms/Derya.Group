using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.DefinitionsInsertCommand;
using WebsiteManagerPanel.Commands.FieldItemsDeleteCommand;
using WebsiteManagerPanel.Commands.FieldItemsInsertCommand;
using WebsiteManagerPanel.Commands.FieldItemsUpdateCommand;
using WebsiteManagerPanel.Commands.FieldsInsertCommand;
using WebsiteManagerPanel.Commands.SitesDeleteCommand;
using WebsiteManagerPanel.Commands.SitesInsertCommand;
using WebsiteManagerPanel.Commands.SitesUpdateCommand;
using WebsiteManagerPanel.Framework.Infrastructure;
using WebsiteManagerPanel.Query;
using static WebsiteManagerPanel.Framework.RoleEnums.Enum;

namespace WebsiteManagerPanel.Controllers
{

    public class FieldItemController : Controller
    {
        // GET: /<controller>/

        private readonly IMediator _mediator;
        private readonly FieldItemQuery _fieldItemQuery;

        private readonly FieldQuery _fieldQuery;
        public FieldItemController(IMediator mediator,FieldQuery fieldQuery, FieldItemQuery fieldItemQuery)
        {
            _mediator = mediator;
            _fieldItemQuery = fieldItemQuery;
            _fieldQuery = fieldQuery;
        }


        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.ShowField)]
        public async Task<IActionResult> FieldValues()
        {

            var values = await _fieldItemQuery.GetAllAsync();
            return View("TableValue", values);
        }

        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(int fieldId)
        {
            var model = await _fieldQuery.GetFieldValueByFieldId(fieldId);

            return View("Create",model);
        }

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Create(FieldItemInsertCommand model )
        {
            await _mediator.Send(model);
            var result = new { Success = "True", Message = "Başarılı" };
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FieldItemDeleteCommand model)
        {
            await _mediator.Send(model);
            var result = new { Success = "True", Message = "Başarılı" };
            return Json(result);
        }
        [HttpGet]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(int Id)
        {
            var model = await _fieldItemQuery.GetById(Id);

            return View("Update", model);
        }

        [HttpPost]
        [ServiceFilter(typeof(PermissionFilter))]
        [RoleAttribute((int)RoleGroup.Admin, (Int64)AdminRole.CanChangeField)]
        public async Task<IActionResult> Update(FieldItemUpdateCommand model)
        {
            await _mediator.Send(model);
          return  RedirectToAction("FieldValues");
        }
    }
}
