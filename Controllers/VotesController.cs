using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TonRoadVoteApi.Data;
using TonRoadVoteApi.Models;

namespace TonRoadVoteApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VotesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public VotesController(AppDbContext context)
		{
			_context = context;
		}

		// POST: api/votes
		[HttpPost]
		public async Task<IActionResult> PostVote([FromBody] Vote vote)
		{
			_context.Votes.Add(vote);
			await _context.SaveChangesAsync();
			return Ok(vote);
		}

		// GET: api/votes
		[HttpGet]
		public async Task<IActionResult> GetVotes()
		{
			var votes = await _context.Votes.ToListAsync();
			return Ok(votes);
		}
	}
}


