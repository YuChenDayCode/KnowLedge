using FreeSql.DatabaseModel;using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace Know.Model.Entity {

	/// <summary>
	/// 回答
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "t_answer", DisableSyncStructure = true)]
	public partial class AnswerEntity {

		[JsonProperty, Column(Name = "c_id", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 所属问题
		/// </summary>
		[JsonProperty, Column(Name = "c_question_id")]
		public int QuestionId { get; set; }

		/// <summary>
		/// 赞同数
		/// </summary>
		[JsonProperty, Column(Name = "c_consent")]
		public int? Consent { get; set; } = 0;

		/// <summary>
		/// 内容
		/// </summary>
		[JsonProperty, Column(Name = "c_content", StringLength = -1)]
		public string Content { get; set; }

		[JsonProperty, Column(Name = "c_create_time", DbType = "datetime")]
		public DateTime CreateTime { get; set; }

		[JsonProperty, Column(Name = "c_update_time", DbType = "datetime")]
		public DateTime? UpdateTime { get; set; }

		[JsonProperty, Column(Name = "c_user_id")]
		public int? UserId { get; set; }

		/// <summary>
		/// 回答者
		/// </summary>
		[JsonProperty, Column(Name = "c_user_name", StringLength = 256)]
		public string UserName { get; set; }

	}

}
