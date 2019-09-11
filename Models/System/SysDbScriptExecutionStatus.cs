using System;
using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public class SysDbScriptExecutionStatus:IEntity
    {
        public string Id { get; set; }
        public string DbName { get; set; }
        public float ScriptVersion { get; set; }
        public DateTime ExecuteDateTime { get; set; }
        public bool Success { get; set; }
        public string Log { get; set; }
    }
}