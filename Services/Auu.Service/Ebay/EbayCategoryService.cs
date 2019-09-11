using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auu.Framework.DbControllers.Base;
using Auu.Models.System;
using Auu.PlugIn.Store.EbayApi.Dictionary;

namespace Service.Ebay
{
    public class EbayCategoryService
    {
        public bool SyncEbayCategory(IDbHelper db, SysEbayAccount account)
        {
            var ebayCategories = EbayApiCategory.GetEbayCategory(account);
            if (ebayCategories.Count > 0)
            {
               var dbCategories = db.QueryList<EbayCategory>("SELECT * FROM EbayCategory");
               var addCategories = ebayCategories.Where(ec => !dbCategories.Any(dc => dc.Code.Equals(ec.Code))).ToList();
                foreach (EbayCategory addCategory in addCategories)
                {
                    addCategory.Id = Guid.NewGuid().ToString();
                }
                if (addCategories.Count > 0)
                    db.Insert(addCategories.ToArray());

                var updateCategories = ebayCategories.Join(dbCategories, ec => ec.Code, dc => dc.Code, (ec, dc) =>
                    new EbayCategory()
                    {
                        Id = dc.Id, Code = dc.Code, ParentCode = ec.ParentCode, Level = ec.Level,
                        CategoryName = ec.CategoryName, LeafCategory = ec.LeafCategory, ParentName = ec.ParentName,

                    }).ToList();
                if (updateCategories.Count > 0)
                    db.Update(updateCategories.ToArray());

                var deleteCategories = dbCategories.Where(dc => !ebayCategories.Any(ec => ec.Code.Equals(dc.Code))).ToList();
                if (deleteCategories.Count > 0)
                    db.Delete(deleteCategories.ToArray());

            }

            return true;
        }
    }
}
