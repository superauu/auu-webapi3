using Auu.Framework.DbControllers.Base;

namespace Auu.Models.System
{
    public class SysDbScript : IEntity
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        /// <returns></returns>
        public string Desc { get; set; }

        /// <summary>
        ///     脚本正文
        /// </summary>
        /// <returns></returns>
        public string Script { get; set; }

        /// <summary>
        ///     版本号
        /// </summary>
        /// <returns></returns>
        public float Version { get; set; }
    }
}