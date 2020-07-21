using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Know.Model.Entity
{

    [EntityMapper_TableName("t_question")]
    public class QuestionEntity
    {
        [PrimaryKey(PrimaryType.Increment)]
        [EntityMapper_ColumnName("c_Id")]
        public int Id { get; set; }

        [EntityMapper_ColumnName("c_tag")]
        public string Tag { get; set; }

        [EntityMapper_ColumnName("c_desc")]
        public string Desc { get; set; }

        [EntityMapper_ColumnName("c_title")]
        public string Title { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        [EntityMapper_ColumnName("c_views")]
        public int Views { get; set; }

        [EntityMapper_ColumnName("c_askuser_id")]
        public string AskuserId { get; set; }

        [EntityMapper_ColumnName("c_create_time")]
        public DateTime? CreateTime { get; set; }

        [EntityMapper_ColumnName("c_update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
