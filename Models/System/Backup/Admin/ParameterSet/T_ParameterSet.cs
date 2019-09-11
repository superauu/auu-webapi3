using System;

namespace  Auu.Models.System.Backup.Admin.ParameterSet
{
    /// <summary>
    ///     参数设置实体类
    /// </summary>
    public class T_ParameterSet
    {
        /// <summary>
        ///     编号自增长
        /// </summary>
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     公司名称
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     公司地址
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }

        /// <summary>
        ///     公司电话
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }

        /// <summary>
        ///     公司传真
        /// </summary>
        /// <returns></returns>
        public string Fax { get; set; }

        /// <summary>
        ///     公司邮编
        /// </summary>
        /// <returns></returns>
        public string Postcode { get; set; }

        /// <summary>
        ///     启用时间
        /// </summary>
        /// <returns></returns>
        public DateTime Startdate { get; set; }

        /// <summary>
        ///     本位币
        /// </summary>
        /// <returns></returns>
        public string Basecurrency { get; set; }

        /// <summary>
        ///     数量小数位
        /// </summary>
        /// <returns></returns>
        public int Numberdecimal { get; set; }

        /// <summary>
        ///     单价小数位
        /// </summary>
        /// <returns></returns>
        public int Pricedecimal { get; set; }

        /// <summary>
        ///     存货计价方法
        /// </summary>
        /// <returns></returns>
        public string Valuationmethod { get; set; }

        /// <summary>
        ///     是否检查负库存
        /// </summary>
        /// <returns></returns>
        public int Ifchecknegativestock { get; set; }

        /// <summary>
        ///     启用审核
        /// </summary>
        /// <returns></returns>
        public int Ifaudit { get; set; }

        /// <summary>
        ///     启用税金
        /// </summary>
        /// <returns></returns>
        public int Iftax { get; set; }

        /// <summary>
        ///     税金
        /// </summary>
        /// <returns></returns>
        public float Taxrate { get; set; }

        /// <summary>
        ///     商品价格是否含税
        /// </summary>
        /// <returns></returns>
        public int Ifplustax { get; set; }

        /// <summary>
        ///     启用辅助属性
        /// </summary>
        /// <returns></returns>
        public int Ifattribute { get; set; }

        /// <summary>
        ///     启用序列号
        /// </summary>
        /// <returns></returns>
        public int Ifsn { get; set; }

        /// <summary>
        ///     启用批次保质期管理
        /// </summary>
        /// <returns></returns>
        public int Ifbatch { get; set; }

        /// <summary>
        ///     启用自动出库最早批次
        /// </summary>
        /// <returns></returns>
        public int Ifoutfirstbatch { get; set; }

        /// <summary>
        ///     启用自动填充结算金额
        /// </summary>
        /// <returns></returns>
        public int Ifauto { get; set; }

        /// <summary>
        ///     启用分仓核算
        /// </summary>
        /// <returns></returns>
        public int Ifbranch { get; set; }
    }
}