//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Auu.WebApi.Controllers.Base;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//
//namespace Auu.WebApi.Controllers.Product
//{
//    public class CategoryController: BaseController
//    {
//        [HttpGet]
//        [Route("product/category")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetCategories()
//        {
//            var categories = UserDbHelper.QueryList<CstCategory>("select * from CstCategory");
//            return Ok(categories);
//        }
//
//        [HttpGet]
//        [Route("product/categoryFullName")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetCategoriesFullName()
//        {
//            var categories =
//                UserDbHelper.QueryList<CstCategory>(
//                    "SELECT * from CstCategory where id not in (SELECT DISTINCT ParentId from CstCategory)");
//            if (categories == null) return Ok();
//            var categoryList=UserDbHelper.QueryList<CstCategory>("SELECT * from CstCategory");
//            
//            foreach (var cstCategory in categories)
//            {
//                cstCategory.Name = GetFullNameById(categoryList,cstCategory.Id);
//            }
//
//            return Ok(categories);
//        }        
//        
//        private string GetFullNameById(List<CstCategory> categoryList,int Id)
//        {
//            var category = categoryList.FirstOrDefault(c => c.Id == Id);
//            if (category == null) return null;
//            string fullName = category.Name;
//            while (true)
//            {
//                category = categoryList.FirstOrDefault(c => c.Id == category.ParentId);
//                if (category==null || 0 == category.Id) break;
//                fullName = category.Name + "/" + fullName;
//            }
//
//            return fullName;
//        }
//        
//        [HttpPost]
//        [Route("product/category")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult AddCategory([FromBody] CstCategory category)
//        {
//            try
//            {
//                if (category == null)
//                {
//                    ErrorResult er=new ErrorResult();
//                    er.error=new Error();
//                    er.error.name = "category information cannot be empty.";
//                    return Ok(er);
//                }
//
//                var checkExist =
//                    UserDbHelper.QueryDynamicList($"select Id from CstCategory where Name = '{category.Name}'");
//                if (checkExist.Count > 0)
//                {
//                    ErrorResult er=new ErrorResult();
//                    er.error=new Error();
//                    er.error.name = "Category Name already exist!";
//                    return Ok(er);
//                }
//
//                UserDbHelper.Insert(category);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("Insert new category error.",ex);
//                return StatusCode(500, ex);
//            }
//        }
//        
//        [HttpPut]
//        [Route("product/category")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult UpdateCategory([FromBody] CstCategory category)
//        {
//            try
//            {
//                UserDbHelper.Update(category);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError("update category error.",ex);
//                return StatusCode(500, ex);
//            }
//        }
//        
//        [HttpDelete]
//        [Route("product/category/{categoryId}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult DeleteEbayAccounts(string categoryId)
//        {
//            //TODO 删除之前需要验证是否可以删除，有子项或者有item的都不可以删除
//            var checkSub = UserDbHelper.QueryDynamicList($"select Id from CstCategory where ParentId={categoryId}");
//            if (checkSub.Any())
//            {
//                return StatusCode(600, "You cannot delete a category which has subcategory.");
//            }
//            UserDbHelper.Execute($"delete from CstCategory where Id = {categoryId}");
//            return Ok();
//        }
//        
//        [HttpPost]
//        [Route("product/category/ebaymapping")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult EbayMapping([FromBody] CstCategoryEbay mapping)
//        {
//            var check = UserDbHelper.QueryDynamicList($"select Id from CstCategoryEbay where CstCategoryId={mapping.CstCategoryId}");
//            if (check.Any())
//            {
//                if(!CheckIfLeaf(mapping))
//                    return StatusCode(600, $"Only leaf category can be map");
//                mapping.Id = check[0].Id;
//                mapping.EbayCategoryFullName = GetFullNameByCode(mapping.EbayCategoryCode);
//                UserDbHelper.Update(mapping);
//                return Ok();
//            }
//
//            if(!CheckIfLeaf(mapping))
//                return StatusCode(600, $"Only leaf category can be map");
//            mapping.EbayCategoryFullName = GetFullNameByCode(mapping.EbayCategoryCode);
//            UserDbHelper.Insert(mapping);
//            return Ok();
//        }
//
//        private bool CheckIfLeaf(CstCategoryEbay mapping)
//        {
//            var result =
//                UserDbHelper.QueryDynamicList($"select * from CstCategory where ParentId= {mapping.CstCategoryId}");
//            if (result.Count > 0)
//                return false;
//            result = SysDbHelper.QueryDynamicList(
//                $"select * from EbayCategory where code='{mapping.EbayCategoryCode}' and LeafCategory=0");
//            if (result.Count > 0)
//                return false;
//
//            return true;
//        }
//
//        private string GetFullNameByCode(string code)
//        {
//            var category =
//                SysDbHelper.QueryOne<EbayCategory>($"select * from EbayCategory where code='{code}'");
//            if (category == null) return null;
//            string fullName = category.CategoryName;
//            while (true)
//            {
//                var tId = category.Id;
//                category = SysDbHelper.QueryOne<EbayCategory>(
//                    $"select * from EbayCategory where code='{category.ParentCode}'");
//                if (tId == category.Id) break;
//                
//                fullName = category.CategoryName + "/" + fullName;
//            }
//
//            return fullName;
//        }
//        
//        [HttpGet]
//        [Route("product/category/ebaymapping")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult EbayMapping()
//        {
//            var result = UserDbHelper.QueryDynamicList("select T1.*,T2.EbayCategoryFullName from CstCategory T1 left JOIN CstCategoryEbay T2 on T1.Id = T2.CstCategoryId");
//            return Ok(result);
//        }
//        
//        [HttpDelete]
//        [Route("product/category/ebaymapping/{id}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult DeleteEbayMapping(string id)
//        {
//            UserDbHelper.Execute($"delete from CstCategoryEbay where CstCategoryId = {id}");
//            return Ok();
//        }
//
//        [HttpGet]
//        [Route("product/category/ebayCategory/{parentCode}")]
//        [EnableCors("AllowAllOrigins")]
//        public IActionResult GetEbayCategory(string parentCode)
//        {
//            List<EbayCategory> result;
//            if (parentCode == "0")
//                result = (SysDbHelper.QueryList<EbayCategory>("select * from EbayCategory where Level=1"));
//            else
//                result = (SysDbHelper.QueryList<EbayCategory>(
//                    $"select * from EbayCategory where ParentCode='{parentCode}' and Code<>'{parentCode}'"));
//
//            if (result == null || result.Count == 0)
//            {
//                return StatusCode(601, parentCode);
//            }
//            foreach (var ebayCategory in result)
//            {
//                if (ebayCategory.LeafCategory == (byte) 0)
//                    ebayCategory.CategoryName += " >>";
//            }
//
//            return Ok(result);
//        }
//    }
//}
//
