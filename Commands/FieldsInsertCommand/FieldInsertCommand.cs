using MediatR;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Commands.FieldsInsertCommand
{
    public class FieldInsertCommand:IRequest<int>
    {
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
        public FieldType FieldType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
