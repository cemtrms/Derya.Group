using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Data.Entities.Enums;

namespace WebsiteManagerPanel.Data.Entities
{
    public class Definition : AuditEntity
    {
        //dfinition dediğimiz urunun bir siteye ait oldugunu belirtmek istediğimiz için siteId deriz.Burda urun dediğimiz definition yani bir tablo,fieldlar bu tablo içindeki field yanı column lar fieldvalue ise dalar.
        public Site Site { get; protected set; }
        //mesala definition olan urunlerın adı,fıyatı,stogu bırer fieldsdır ve tipleri ile birlikte fields tablosunda tutulur.Bunlara karsılık gelen datalar ıse fielvalue da yer alır
        public ICollection<Field>? Fields { get; set; }
        public string Name { get; protected set; }
        public string? Description { get; protected set; }

        protected Definition() {
            Fields = new List<Field>();
        }

        public Definition(string name,string desc) : this()
        {
            Name = name;
            Description = desc;
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddField(string name, string description, FieldType fieldType)
        {
            Fields.Add(new Field (name,description,fieldType ));
        }

        
    }
}
