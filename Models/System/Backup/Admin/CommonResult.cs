namespace Auu.Models.System.Backup.Admin
{
    /// <summary>
    ///     通用返回结果
    /// </summary>
    public class CommonResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string Scode { get; set; }

        /// <summary>
        ///     备注信息
        /// </summary>
        public string Remark { get; set; }
    }

    /// <summary>
    ///     包含单条结果的结果对象
    /// </summary>
    public class CommonResult<T> : CommonResult
    {
        /// <summary>
        ///     单条结果
        /// </summary>
        /// <returns></returns>
        public T Result { get; set; }
    }

    /// <summary>
    ///     包含多条结果的结果对象
    /// </summary>
    public class CommonResults<T> : CommonResult
    {
        /// <summary>
        ///     多条结果
        /// </summary>
        /// <returns></returns>
        public T[] Results { get; set; }
    }
}