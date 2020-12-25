using System;
using System.Collections.Generic;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Framework.Interfaces;

namespace WebsiteManagerPanel.Data.Entities
{
    public class FieldValue : AuditEntity, IAggreegateRoot
    {
        public Field Field { get; protected set; }
        public ICollection<FieldItem> Items { get; set; }
        public FieldValue()
        {
            Items = new List<FieldItem>();
        }
        public FieldValue(string value):this()
        {
            Items.Add(new FieldItem (value ));
        }
       
    }
}
