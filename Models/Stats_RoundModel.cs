using ParadisePublicAPI.Database;
using System.Text.Json.Serialization;

namespace ParadisePublicAPI.Models {
    /// <summary>
    /// Model class for a round (With some data stripped out)
    /// </summary>
    public class Stats_RoundModel {
        [JsonPropertyName("round_id")]
        public int RoundId { get; set; }

        [JsonPropertyName("init_datetime")]
        public DateTime Initdatetime { get; set; }

        [JsonPropertyName("start_datetime")]
        public DateTime? StartDatetime { get; set; }

        [JsonPropertyName("shutdown_datetime")]
        public DateTime? ShutdownDatetime { get; set; }

        [JsonPropertyName("end_datetime")]
        public DateTime? EndDatetime { get; set; }

        [JsonPropertyName("commit_hash")]
        public string? CommitHash { get; set; }

        [JsonPropertyName("game_mode")]
        public string? Gamemode { get; set; }

        [JsonPropertyName("game_mode_result")]
        public string? GamemodeResult { get; set; }

        [JsonPropertyName("end_state")]
        public string? EndState { get; set; }

        [JsonPropertyName("map_name")]
        public string? MapName { get; set; }

        [JsonPropertyName("server_id")]
        public string? ServerId { get; set; }

        public void FromDBRound(Round round) {
            RoundId = round.Id;
            Initdatetime = round.InitializeDatetime;
            StartDatetime = round.StartDatetime;
            ShutdownDatetime = round.ShutdownDatetime;
            EndDatetime = round.EndDatetime;
            CommitHash = round.CommitHash;
            Gamemode = round.GameMode;
            GamemodeResult = round.GameModeResult;
            EndState = round.EndState;
            MapName = round.MapName;
            ServerId = round.ServerId;
        }
    }
}
