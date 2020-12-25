using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Entities
{
    public class FieldItem : AuditEntity
    {
        public FieldItem(string value)
        {
            Value = value;
        }

        public FieldValue FieldValue { get; protected set; }
        public string Value { get; protected set; }

        public void Update(string fieldValue)
        {
            Value = fieldValue;
        }
    }
}
