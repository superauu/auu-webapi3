////Author: Nathan Li
////Create Time: Tuesday, 25 June 2019
//
//using Auu.WebApi.Controllers.Base;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace Auu.WebApi.Controllers.Product
//{
//    public class TaxCodeController:BaseController
//    {
//        [HttpGet]
//        [Route("product/taxCode")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetBrands()
//        {
//            var taxCodes = UserDbHelper.QueryList<CstTaxCode>("SELECT * from CstTaxCode");
//            return Ok(taxCodes);
//        }
//    }
//}