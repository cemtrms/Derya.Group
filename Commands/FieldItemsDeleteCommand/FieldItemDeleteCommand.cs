using MediatR;

namespace WebsiteManagerPanel.Commands.FieldItemsDeleteCommand
{
    public class FieldItemDeleteCommand : IRequest<bool>
    {
        public int FieldItemId { get; set; }
        public int FieldValueId { get; set; }
        public int FieldId { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
    }
}
