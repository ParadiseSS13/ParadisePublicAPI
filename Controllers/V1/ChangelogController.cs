using Microsoft.AspNetCore.Mvc;
using ParadisePublicAPI.Database;
using ParadisePublicAPI.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ParadisePublicAPI.Controllers.V1 {
    /// <summary>
    /// Controller for querying statistics from game rounds
    /// </summary>
    [ApiExplorerSettings(GroupName = "v1")]
    [SwaggerTag("Query historical changelog entries")]
    [Route("cl")]
    public class ChangelogController(ParadiseGamedbContext context) : Controller {
        private readonly ParadiseGamedbContext _context = context;

        /// <summary>
        /// Gets a list of valid changelog entries.
        /// </summary>
        /// <param name="offset">Offset of CL entries to take from. If not specified, will take the 50 most recent PRs merged. If specified, will take the next 50 PRs older than that offset.</param>
        /// <returns>A list of up to 50 PRs worth of changelog entries.</returns>
        /// <response code="200">Changelog list successfully retrieved</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("entries")]
        public IActionResult GetEntries(int offset) {
            // Init up here so lines down dont whine
            List<int> recent_prs = [];

            // Account for optional offset
            if (offset > 0) {
                // We got an offset, account for it
                recent_prs = [.. _context.Changelogs.Where(x => x.PrNumber < offset).Select(x => x.PrNumber).Distinct().OrderByDescending(x => x).Take(50)];
            } else {
                // We dont. Just go as normal.
                recent_prs = [.. _context.Changelogs.Select(x => x.PrNumber).Distinct().OrderByDescending(x => x).Take(50)];
            }

            List<Changelog> db_cl_entries = [.. _context.Changelogs.Where(x => recent_prs.Contains(x.PrNumber)).OrderByDescending(x => x.Id)];
            List<ChangelogModel> out_models = [];

            foreach(Changelog cl in db_cl_entries) {
                ChangelogModel cm = new();
                cm.FromModel(cl);
                out_models.Add(cm);
            }

            // And send it
            return Ok(out_models);
        }
    }
}
