using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Know.Model.Entity
{
    [EntityMapper_TableName("t_answer")]
    public class AnswerEntity
    {
        [PrimaryKey(PrimaryType.Increment)]
        [EntityMapper_ColumnName("c_Id")]
        public int Id { get; set; }

        [EntityMapper_ColumnName("c_question_id")]
        public int QuestionId { get; set; }

        [EntityMapper_ColumnName("c_user_id")]
        public int UserId { get; set; }

        [EntityMapper_ColumnName("c_user_name")]
        public string UserName { get; set; }


        [EntityMapper_ColumnName("c_content")]
        public string Content { get; set; }

        /// <summary>
        /// 赞同数
        /// </summary>
        [EntityMapper_ColumnName("c_consent")]
        public int Consent { get; set; }

        [EntityMapper_ColumnName("c_create_time")]
        public DateTime CreateTime { get; set; }

        [EntityMapper_ColumnName("c_update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}
