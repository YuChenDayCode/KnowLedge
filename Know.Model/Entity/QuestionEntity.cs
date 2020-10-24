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
	/// 问题
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "t_question", DisableSyncStructure = true)]
	public partial class QuestionEntity {

		[JsonProperty, Column(Name = "c_id", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 提问者id
		/// </summary>
		[JsonProperty, Column(Name = "c_askuser_id", StringLength = 45)]
		public string AskuserId { get; set; }

		[JsonProperty, Column(Name = "c_create_time", DbType = "datetime")]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// 问题描述
		/// </summary>
		[JsonProperty, Column(Name = "c_desc", StringLength = 512)]
		public string Desc { get; set; }

		/// <summary>
		/// 所属话题id
		/// </summary>
		[JsonProperty, Column(Name = "c_tag", StringLength = 128)]
		public string Tag { get; set; }

		/// <summary>
		/// 问题
		/// </summary>
		[JsonProperty, Column(Name = "c_title")]
		public string Title { get; set; }

		[JsonProperty, Column(Name = "c_update_time", DbType = "datetime")]
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// 浏览量
		/// </summary>
		[JsonProperty, Column(Name = "c_views")]
		public int? Views { get; set; }

	}

}
