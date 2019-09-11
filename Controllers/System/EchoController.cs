using Auu.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SysEbayAccount = Auu.Models.System.SysEbayAccount;

namespace Auu.WebApi.Controllers.System
{
    /// <summary>
    ///     用户登录接口
    /// </summary>
    public class EchoController: BaseController
    {
        /// <summary>
        ///     用户登录接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echo")]
        [EnableCors("AllowAllOrigins")]
        public IActionResult Login()
        {
            //Session.Register("a", "p");
            //DbHelper.QueryDynamicList("select * from test1");
            //var country = SysDbHelper.QueryOne<EbayCountry>("select * from EbayCountry where Id = '123'");
            //var result = SysDbHelper.Insert<EbayCountry>(new EbayCountry()
            //    {Code = Models.SystemModel.CountryCodeType.AE, Id = "456", Name = "AE"});
            var sql = SysDbHelper.GetCompiler().Compile(SysDbHelper.GetQuery("SysEbayAccount").Where("EbayId", "acseller8"));
            var test = sql.RawSql;
            var test2 = sql.ToString();
            var account=SysDbHelper.QueryOne<SysEbayAccount>(test2); //注意mysql 表名区分大消息
            //var itemService = new EbayItemService();
            //var session = itemService.AddItemTest(account);
            //var session = EbayApiCategory.GetEbayCategory(account);
            //var categoryService = new EbayCategoryService();
            //var session = categoryService.SyncEbayCategory(SysDbHelper, account);
            //SysDbHelper.Insert(session.ToArray());
            //Logger.LogTrace(session);
            return Ok();
        }
    }
}

