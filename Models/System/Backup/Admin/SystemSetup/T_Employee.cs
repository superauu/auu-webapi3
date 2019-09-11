using System;

namespace  Auu.Models.System.Backup.Admin.SystemSetup
{
    /// <summary>
    ///     人员信息表实体类
    /// </summary>
    public class T_Employee
    {
        /// <summary>
        ///     编号
        /// </summary>
        /// ///
        /// <returns></returns>
        public int Oid { get; set; }

        /// <summary>
        ///     员工编号
        /// </summary>
        /// <returns></returns>
        public string TTid { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        /// <returns></returns>
        public string Sex { get; set; }

        /// <summary>
        ///     生日
        /// </summary>
        /// <returns></returns>
        public DateTime Birthdate { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        /// <returns></returns>
        public string Nation { get; set; }

        /// <summary>
        ///     政治面貌
        /// </summary>
        /// <returns></returns>
        public string PoliticalStatus { get; set; }

        /// <summary>
        ///     婚姻状态
        /// </summary>
        /// <returns></returns>
        public string MaritaStatus { get; set; }

        /// <summary>
        ///     入职日期
        /// </summary>
        /// <returns></returns>
        public DateTime HireDate { get; set; }

        /// <summary>
        ///     部门编号
        /// </summary>
        /// <returns></returns>
        public int DTid { get; set; }

        /// <summary>
        ///     职称
        /// </summary>
        /// <returns></returns>
        public string JobTitle { get; set; }

        /// <summary>
        ///     学历
        /// </summary>
        /// <returns></returns>
        public int EducationOid { get; set; }

        /// <summary>
        ///     应急电话
        /// </summary>
        /// <returns></returns>
        public string Telephone { get; set; }

        /// <summary>
        ///     联系电话
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }

        /// <summary>
        ///     身份证号
        /// </summary>
        /// <returns></returns>
        public string IDNo { get; set; }

        /// <summary>
        ///     地址
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }

        /// <summary>
        ///     照片地址
        /// </summary>
        /// <returns></returns>
        public string Photo { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        /// <returns></returns>
        public string Desc { get; set; }

        /// <summary>
        ///     是否在职，在职1离职0
        /// </summary>
        /// <returns></returns>
        public int Visible { get; set; }
    }
}