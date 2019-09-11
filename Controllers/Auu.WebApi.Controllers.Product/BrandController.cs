//using System;
//using System.Linq;
//using Auu.WebApi.Controllers.Base;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.KeyVault.Models;
//
//namespace Auu.WebApi.Controllers.Product
//{
//    public class BrandController : BaseController
//    {
//        [HttpGet]
//        [Route("product/brand")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetBrands()
//        {
//            var brands = UserDbHelper.QueryList<CstBrand>("select * from CstBrand");
//            var result = brands.Select(b => new {b.Id, b.BrandName});
//            return Ok(result);
//        }
//
//        [HttpPost]
//        [Route("product/brand")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult AddBrand([FromBody] CstBrand brand)
//        {
//            try
//            {
//                if (brand == null)
//                {
//                    var er = new ErrorResult();
//                    er.error = new Error();
//                    er.error.name = "Brand information cannot be empty.";
//                    return Ok(er);
//                }
//
//                var checkExist =
//                    UserDbHelper.QueryDynamicList($"select Id from CstBrand where BrandName = '{brand.BrandName}'");
//                if (checkExist.Count > 0)
//                {
//                    var er = new ErrorResult();
//                    er.error = new Error();
//                    er.error.name = "Brand Name already exist!";
//                    return Ok(er);
//                }
//
//                UserDbHelper.Execute($"insert into CstBrand(BrandName) values (@BrandName)",brand);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("Insert new brand error.", ex);
//                return StatusCode(500, ex);
//            }
//        }
//
//        [HttpPut]
//        [Route("product/brand")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult UpdateBrand([FromBody] CstBrand brand)
//        {
//            try
//            {
//                UserDbHelper.Execute("update CstBrand set BrandName=@BrandName where Id=@Id", brand);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("update brand error.", ex);
//                return StatusCode(500, ex);
//            }
//        }
//
//        [HttpDelete]
//        [Route("product/brand/{brandId}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult DeleteBrand(string brandId)
//        {
//            var checkSub = UserDbHelper.QueryDynamicList($"select Id from CstItem where BrandId={brandId}");
//            if (checkSub.Any()) return StatusCode(600, "You cannot delete a brand which is in use.");
//
//            UserDbHelper.Execute($"delete from CstBrand where Id = {brandId}");
//            return Ok();
//        }
//    }
//}