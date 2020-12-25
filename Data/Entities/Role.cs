using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Entities
{
    //Sayfa üzerindeki, her bir Action’a karşılık gelen yetki tablosudur.Burada dikkat edilmesi gereken bir husus da, RoleID alanının “bigint” olmasıdır.Bu kısım makalenin devamında detaylıca anlatılacaktır.
    public partial class Role:Entity
    {
        public long? RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public virtual RoleGroup ?Group { get; set; }
    }
}
