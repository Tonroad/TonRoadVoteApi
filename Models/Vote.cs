using System;

namespace TonRoadVoteApi.Models
{
	public class Vote
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string Direction { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
