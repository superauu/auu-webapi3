//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Auu.Models.View;
//using Auu.WebApi.Controllers.Base;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace Auu.WebApi.Controllers.Product
//{
//    public class CstItemController : BaseController
//    {
//        [HttpGet]
//        [Route("product/cstItem")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetItemList()
//        {
//            var items = UserDbHelper.QueryList<UserItemsResponse>(
//                "select CstItem.Id,ItemName,SKU,brand.BrandName,CategoryId,MPN,EAN,UPC,ISBN,Quantity,RRP,StandardCost,SellingPrice from CstItem left join CstBrand brand on CstItem.BrandId = brand.Id");
//            if (items != null)
//            {
//                var categories = UserDbHelper.QueryList<CstCategory>("select * from CstCategory");
//                foreach (var item in items)
//                {
//                    item.CategoryName = GetFullNameByCode(categories, item.CategoryId);
//                }
//            }
//
//            return Ok(items);
//        }
//        
//        [HttpGet]
//        [Route("product/cstItemById/{id}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetItemById(int id)
//        {
//            try
//            {
//                var item = UserDbHelper.QueryOne<CstItem>($"select * from CstItem where Id={id}");
//                if (item != null)
//                {
//                    return Ok(item);
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(600, ex.Message);
//            }
//            
//            return StatusCode(600, $"Load item by ID:{id} failed.");
//        }
//
//        private string GetFullNameByCode(List<CstCategory> categories, int id)
//        {
//            var category = categories.FirstOrDefault(c => c.Id == id);
//            if (category == null) return null;
//            string fullName = category.Name;
//            while (true)
//            {
//                category = categories.FirstOrDefault(c => c.Id == category.ParentId);
//                if (category == null || 0 == category.Id) break;
//
//                fullName = category.Name + "/" + fullName;
//            }
//
//            return fullName;
//        }
//
//        [HttpGet]
//        [Route("product/cstItem/{itemId}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetItem(string itemId)
//        {
//            var item = UserDbHelper.QueryOne<CstItem>($"select * from CstItem where id={itemId}");
//            return Ok(item);
//        }
//
//        [HttpPost]
//        [Route("product/cstItem")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult AddItem([FromBody] CstItem item)
//        {
//            try
//            {
//                if (item == null)
//                {
//                    var er = new ErrorResult();
//                    er.error = new Error();
//                    er.error.name = "Item information cannot be empty.";
//                    return Ok(er);
//                }
//                item.AddTime=DateTime.Now;
//                item.CountryCode = Models.SystemModel.CountryCodeType.AU;
//                item.SiteCode = Models.SystemModel.SiteCodeType.Australia;
//                UserDbHelper.Insert(item);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("Insert new item error.", ex);
//                return StatusCode(500, ex);
//            }
//        }
//
//        [HttpPut]
//        [Route("product/cstItem")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult UpdateItem([FromBody] CstItem item)
//        {
//            try
//            {
//                UserDbHelper.Update(item);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("update item error.", ex);
//                return StatusCode(500, ex);
//            }
//        }
//
//        [HttpDelete]
//        [Route("product/cstItem/{itemId}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult DeleteItem(string itemId)
//        {
//            var checkSub = UserDbHelper.QueryDynamicList($"select Id from CstItemEbay where CstItemId={itemId}");
//            if (checkSub.Any()) return StatusCode(600, "You cannot delete a item which is in use.");
//
//            UserDbHelper.Execute($"delete from CstItem where Id = {itemId}");
//            return Ok();
//        }
//    }
//}