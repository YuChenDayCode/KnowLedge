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

        [EntityMapper_ColumnName("c_tag_id")]
        public string TagId { get; set; }

        [EntityMapper_ColumnName("c_title")]
        public string Titile { get; set; }

        [EntityMapper_ColumnName("c_askuser_id")]
        public string AskuserId { get; set; }

        [EntityMapper_ColumnName("c_create_time")]
        public DateTime? CreateTime { get; set; }

        [EntityMapper_ColumnName("c_update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
