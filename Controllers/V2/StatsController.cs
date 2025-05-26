using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ParadisePublicAPI.Database;
using Swashbuckle.AspNetCore.Annotations;

namespace ParadisePublicAPI.Controllers.V2
{
    /// <summary>
    /// Controller for querying statistics from game rounds
    /// </summary>
    [ApiExplorerSettings(GroupName = "v2")]
    [SwaggerTag("Query statistics from game rounds")]
    [Route("v2/stats")]
    public class StatsController : Controller {
        private readonly paradise_gamedbContext _context;

        public StatsController(paradise_gamedbContext context) {
            _context = context;
        }

        /// <summary>
        /// Gets the data of a specific feedback key for the specified rounds.
        /// </summary>
        /// <param name="key_name">The name of the desired feedback key.</param>
        /// <param name="start_date">The start date to retrieve data for.</param>
        /// <param name="end_date">The end date to retrieve data for.</param>
        /// <returns>A list of key-value objects, where "data" is the feedback data and "round_id" is the round ID the data was recorded.</returns>
        /// <response code="200">Round data successfully retrieved</response>
        /// <response code="429">Rate limited by server</response>
        [HttpGet("feedback")]
        public IActionResult GetFeedbackRow([FromQuery, Required] string key_name, [FromQuery, Required] DateOnly start_date, [FromQuery, Required] DateOnly end_date) {
            if (key_name == null) {
                return BadRequest("No feedback key_name specified.");
            }
            if (start_date > end_date) {
                return BadRequest($"start_date {start_date} is later than end_date {end_date}");
            }
            if (start_date.AddMonths(2) < end_date) {
                return BadRequest("Only two months of data may be requested in one query.");
            }
            var start_datetime = start_date.ToDateTime(TimeOnly.MinValue);
            var end_datetime = end_date.ToDateTime(TimeOnly.MaxValue);
            var feedbacks = (from feedback in _context.Feedbacks
                             join round in _context.Rounds on feedback.RoundId equals round.Id
                             orderby round.Id
                             where feedback.KeyName == key_name
                                 && round.ShutdownDatetime != null
                                 && round.InitializeDatetime >= start_datetime
                                 && round.InitializeDatetime <= end_datetime
                             // feedback.JSON begins with `{"data": ...` so we strip the first curly brace
                             // in order to interpolate the rest of the JSON data into the resultant string
                             select $"{{\"round_id\": {round.Id}, {feedback.Json.Substring(1)}");

            return new ContentResult()
            {
                Content = "[" + string.Join(", ", feedbacks) + "]",
                ContentType = "application/json",
                StatusCode = 200
            };
        }
    }
}
