using MediatR;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Commands.FieldsUpdateCommand
{
    public class FieldUpdateCommand:IRequest<int>
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
