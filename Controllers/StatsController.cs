using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParadisePublicAPI.Database;
using ParadisePublicAPI.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ParadisePublicAPI.Controllers {
    /// <summary>
    /// Controller for querying statistics from game rounds
    /// </summary>
    [SwaggerTag("Query statistics from game rounds")]
    [Route("stats")]
    public class StatsController : Controller {
        private readonly paradise_gamedbContext _context;

        public StatsController(paradise_gamedbContext context) {
            _context = context;
        }


        /// <summary>
        /// Gets a list of valid rounds that can be queried.
        /// </summary>
        /// <param name="offset">Offset of rounds to take from. If not specified, will take the 50 most recent rounds. If specified, will take the next 50 rounds older than that offset.</param>
        /// <returns>A list of up to 50 rounds</returns>
        /// <response code="200">Round list successfully retrieved</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("roundlist")]
        public IActionResult GetRounds(int offset) {
            // Init up here so lines down dont whine
            List<Round> db_rounds = new List<Round>();

            // Account for optional offset
            if(offset > 0) {
                // We got an offset, account for it
                db_rounds = _context.Rounds.Where(R => R.ShutdownDatetime != null).Where(R => R.Id < offset).OrderByDescending(R => R.Id).Take(50).ToList();
            } else {
                // We dont. Just go as normal.
                db_rounds = _context.Rounds.Where(R => R.ShutdownDatetime != null).OrderByDescending(R => R.Id).Take(50).ToList();
            }

            // Turn them to the models we want
            List<Stats_RoundModel> returned_rounds = new List<Stats_RoundModel>();
            foreach (Round R in db_rounds) {
                Stats_RoundModel SRM = new Stats_RoundModel();
                SRM.FromDBRound(R);
                returned_rounds.Add(SRM);
            }

            // And send it
            return Ok(returned_rounds);
        }

        /// <summary>
        /// Gets the full blackbox stats from a round
        /// </summary>
        /// <param name="round_id">Round ID to pull stats from.</param>
        /// <returns>All of the feedback keys from the round. Feedback JSON is not parsed API side, as that would require an obnoxious amount of models. Please parse it client side.</returns>
        /// <response code="200">Round data successfully retrieved</response>
        /// <response code="404">Round was not found, or is still ongoing</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("blackbox/{round_id}")]
        public IActionResult GetFeedback([Required] int round_id) {
            // This is required
            if (round_id <= 0) {
                // We somehow got here. This should never happen.
                return BadRequest("A round ID wasnt supplied!");
            }

            if(!RoundExists(round_id)) {
                return NotFound("Round not found, or is still ongoing.");
            }

            // Now we get all the stuff
            List<Feedback> db_feedback_entries = _context.Feedbacks.Where(F => F.RoundId == round_id).OrderBy(F => F.KeyName).ToList();
            List<Stats_FeedbackModel> returned_feedback = new List<Stats_FeedbackModel>();
            foreach(Feedback F in db_feedback_entries) {
                Stats_FeedbackModel SFM = new Stats_FeedbackModel();
                SFM.FromDBFeedback(F);
                returned_feedback.Add(SFM); 
            }

            return Ok(returned_feedback);
        }

        /// <summary>
        /// Gets the playercount data from a round
        /// </summary>
        /// <param name="round_id">Round ID to pull data from.</param>
        /// <returns>Timestamps and player counts as a dictionary. You can use this timestamps with the round init times to get in-round offsets of player numbers.</returns>
        /// <response code="200">Playercount data successfully retrieved</response>
        /// <response code="404">Round was not found, or is still ongoing</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("playercounts/{round_id}")]
        public IActionResult GetPlayercounts([Required] int round_id) {
            // This is required
            if (round_id <= 0) {
                // We somehow got here. This should never happen.
                return BadRequest("A round ID wasnt supplied!");
            }

            if (!RoundExists(round_id)) {
                return NotFound("Round not found, or is still ongoing.");
            }

            // Now we get all the stuff
            // First we need start and end of the round stuff
            Round R = _context.Rounds.Where(R => R.Id == round_id).First();
            List<LegacyPopulation> population_entries = _context.LegacyPopulations.Where(P => P.Time > R.InitializeDatetime).Where(P => P.Time < R.ShutdownDatetime).Where(P => P.ServerId == R.ServerId).ToList();
            Dictionary<DateTime, int?> population_time_dict = new Dictionary<DateTime, int?>();
            foreach(LegacyPopulation LP in population_entries) {
                population_time_dict.Add(LP.Time, LP.Playercount);
            }
            return Ok(population_time_dict);
        }

        /// <summary>
        /// Gets the metadata for a round
        /// </summary>
        /// <param name="round_id">Round ID to pull data from.</param>
        /// <returns>The metadata for a round.</returns>
        /// <response code="200">Round metadata successfully retrieved</response>
        /// <response code="404">Round was not found, or is still ongoing</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("metadata/{round_id}")]
        public IActionResult GetMetadata([Required] int round_id) {
            // This is required
            if (round_id <= 0) {
                // We somehow got here. This should never happen.
                return BadRequest("A round ID wasnt supplied!");
            }

            if (!RoundExists(round_id)) {
                return NotFound("Round not found, or is still ongoing.");
            }

            // Now we get the metadata
            // First we need start and end of the round stuff
            Round R = _context.Rounds.Where(R => R.Id == round_id).First();
            Stats_RoundModel SRM = new Stats_RoundModel();
            SRM.FromDBRound(R);
            return Ok(SRM);
        }

        // This exists for anti-metagaming. A row for the round may exist, but its not over till it has a shutdown datetime.
        // This is an easy check to make sure that the round has ended, to avoid pulling gamemode mid round
        private bool RoundExists(int id) {
            return _context.Rounds.Where(R => R.ShutdownDatetime != null).Where(R => R.Id == id).Any();
        }
    }
}
