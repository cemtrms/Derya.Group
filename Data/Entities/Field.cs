using System.Collections.Generic;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Data.Entities
{
    public class Field : AuditEntity
    {
        public Definition Definition { get; protected set; }
        public string Name { get; protected set; }
        public FieldType Type { get; protected set; }
        public string ? Description { get; set; }
        public ICollection<FieldValue>? FieldValues { get; set; }
        protected Field()
        {
            FieldValues = new List<FieldValue>();
        }

        public Field(Definition definition, string name) : this()
        {
            Definition = definition;
            Name = name;
        }

        public Field(string name, string description, FieldType fieldType)
        {
            Name = name;
            Description = description;
            Type = fieldType;
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
