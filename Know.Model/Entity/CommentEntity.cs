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
	/// 评论
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "t_comment", DisableSyncStructure = true)]
	public partial class CommentEntity {

		[JsonProperty, Column(Name = "c_id", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 答案id
		/// </summary>
		[JsonProperty, Column(Name = "c_answer_id")]
		public int? AnswerId { get; set; }

		/// <summary>
		/// 赞同数
		/// </summary>
		[JsonProperty, Column(Name = "c_consent")]
		public int? Consent { get; set; }

		/// <summary>
		/// 评论内容
		/// </summary>
		[JsonProperty, Column(Name = "c_content", StringLength = -1)]
		public string Content { get; set; }

		[JsonProperty, Column(Name = "c_create_time", DbType = "datetime")]
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// 父id
		/// </summary>
		[JsonProperty, Column(Name = "c_pid")]
		public int Pid { get; set; }

		[JsonProperty, Column(Name = "c_update_time", DbType = "datetime")]
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// 评论者id
		/// </summary>
		[JsonProperty, Column(Name = "c_user_id")]
		public int? UserId { get; set; }

		/// <summary>
		/// 评论者
		/// </summary>
		[JsonProperty, Column(Name = "c_user_name", StringLength = 256)]
		public string UserName { get; set; }

	}

}
