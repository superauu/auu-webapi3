//Author: Nathan Li
//Create Time: Tuesday, 30 April 2019

using Autofac;
using Auu.Framework.Common;
using Auu.Framework.DbControllers.Base;
using Auu.Models.System;

namespace Auu.Service
{
    public static class DictionaryService
    {
        public static string GetDict(string key)
        {
            using (var scope = LocContainer.Main.BeginLifetimeScope())
            {
                var db = scope.Resolve<IDbHelper>();
                var dict = db.QueryOne<SysDictionary>($"select * from SysDictionary where `Key` = '{key}'");
                return dict?.Value;
            }
        }
    }
}