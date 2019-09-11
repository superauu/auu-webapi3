using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public partial class EbayCountry:IEntity
    {
        public string Id { get; set; }
        public CountryCodeType Code { get; set; }
        public string Name { get; set; }
    }

}
