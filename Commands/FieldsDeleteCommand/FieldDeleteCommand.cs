using MediatR;

namespace WebsiteManagerPanel.Commands.FieldsDeleteCommand
{
    public class FieldDeleteCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
    }
}
