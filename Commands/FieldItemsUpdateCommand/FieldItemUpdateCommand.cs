using MediatR;

namespace WebsiteManagerPanel.Commands.FieldItemsUpdateCommand
{
    public class FieldItemUpdateCommand : IRequest<int>
    {
        public int FieldItemId { get; set; }
        public string FieldItemValue { get; set; }
        public int FieldValueId { get; set; }
        public int FieldId { get; set; }
        public int SiteId { get; set; }
        public int DefinitionId { get; set; }
    }
}
