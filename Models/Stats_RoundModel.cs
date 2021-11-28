using ParadisePublicAPI.Database;

namespace ParadisePublicAPI.Models {
    /// <summary>
    /// Model class for a round (With some data stripped out)
    /// </summary>
    public class Stats_RoundModel {
        public int round_id { get; set; }
        public DateTime init_datetime { get; set; }
        public DateTime? start_datetime { get; set; }
        public DateTime? shutdown_datetime { get; set; }
        public DateTime? end_datetime { get; set; }
        public string? commit_hash { get; set; }
        public string? game_mode { get; set; }
        public string? game_mode_result { get; set; }
        public string? end_state { get; set; }
        public string? map_name { get; set; }
        public string? server_id { get; set; }

        public void FromDBRound(Round round) {
            round_id = round.Id;
            init_datetime = round.InitializeDatetime;
            start_datetime = round.StartDatetime;
            shutdown_datetime = round.ShutdownDatetime;
            end_datetime = round.EndDatetime;
            commit_hash = round.CommitHash;
            game_mode = round.GameMode;
            game_mode_result = round.GameModeResult;
            end_state = round.EndState;
            map_name = round.MapName;
            server_id = round.ServerId;
        }
    }
}
