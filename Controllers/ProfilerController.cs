using Microsoft.AspNetCore.Mvc;
using ParadisePublicAPI.Database;
using ParadisePublicAPI.Models;
using ParadisePublicAPI.ProfilerDatabase;
using Swashbuckle.AspNetCore.Annotations;

namespace ParadisePublicAPI.Controllers {
    /// <summary>
    /// Profiler
    /// </summary>
    [SwaggerTag("Query proc times from the profiler. Old data may be cleared with no notice")]
    [Route("profiler")]
    public class ProfilerController : Controller {
        private readonly paradise_gamedbContext _gameContext;
        private readonly paradise_profilerdaemonContext _profilerContext;

        public ProfilerController(paradise_gamedbContext gameContext, paradise_profilerdaemonContext profilerContext) {
            _gameContext = gameContext;
            _profilerContext = profilerContext;
        }

        /// <summary>
        /// Gets a list of procs as a search suggestion
        /// </summary>
        /// <param name="searchterm">Term to search for. Must be atleast 12 characters</param>
        /// <returns>A list of up to 10 procs</returns>
        /// <response code="200">List of up to 10 procs returned</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("procsearch")]
        public IActionResult ProcSearch(string searchterm) {
            if(searchterm.Length < 12) {
                Ok(null); // Dont look for anything
            }

            // Init up here so lines down dont whine
            List<string> db_procs = new List<string>();

            db_procs = _profilerContext.Procs.Where(P => P.Procpath.Contains(searchterm)).Select(P => P.Procpath).Take(10).ToList();

            // And send it
            return Ok(db_procs);
        }

        /// <summary>
        /// Gets all samples for a specified proc from a specified round ID
        /// </summary>
        /// <param name="procname">Proc to get data for</param>
        /// <param name="roundid">Round to get data from</param>
        /// <returns>A list of proc samples</returns>
        /// <response code="200">List of up all samples of that proc from the specified round</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("getproc")]
        public IActionResult GetProc(string procname, int roundid) {
            if(procname == null) {
                return BadRequest("Parameter procname must be supplied!");
            }
            if(roundid <= 0) {
                return BadRequest("Parameter roundid must be supplied!");
            }

            // Make sure the round is valid
            if(!RoundExists(roundid)) {
                return NotFound("Round is either non-existent or still ongoing");
            }

            // See if the proc exists
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Proc proc = _profilerContext.Procs.Where(P => P.Procpath.Equals(procname)).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (proc == null) {
                return NotFound("Proc not found");
            }

            List<Sample> db_samples = new List<Sample>();
            List<Profiler_Sample> output_samples = new List<Profiler_Sample>();

            db_samples = _profilerContext.Samples.Where(S => S.Proc.Procpath == proc.Procpath).Where(S => S.RoundId == roundid).ToList();

            if (db_samples.Count > 0) {
                // Convert them
                foreach(Sample sample in db_samples) {
                    Profiler_Sample ps = new Profiler_Sample();
                    ps.fromModels(proc, sample);
                    output_samples.Add(ps);
                }

                // Send em
                return Ok(output_samples);
            } else {
                return NotFound("No samples found");
            }

            
        }



        // This exists for anti-metagaming. A row for the round may exist, but its not over till it has a shutdown datetime.
        // This is an easy check to make sure that the round has ended, to avoid pulling potentially meta things in the round
        // Yes, I am 100% serious. I would not be surprised if people used the profiler to see if terror spider Life() calls were increasing
        private bool RoundExists(int id) {
            return _gameContext.Rounds.Where(R => R.ShutdownDatetime != null).Where(R => R.Id == id).Any();
        }
    }
}
