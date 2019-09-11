using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public partial class EbayCategory : IEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public int Level { get; set; }
        public string CategoryName { get; set; }
        public byte LeafCategory { get; set; }
    }
}
