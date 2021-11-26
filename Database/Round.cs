using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Round
    {
        public int Id { get; set; }
        public DateTime InitializeDatetime { get; set; }
        public DateTime? StartDatetime { get; set; }
        public DateTime? ShutdownDatetime { get; set; }
        public DateTime? EndDatetime { get; set; }
        public uint ServerIp { get; set; }
        public ushort ServerPort { get; set; }
        public string? CommitHash { get; set; }
        public string? GameMode { get; set; }
        public string? GameModeResult { get; set; }
        public string? EndState { get; set; }
        public string? ShuttleName { get; set; }
        public string? MapName { get; set; }
        public string? StationName { get; set; }
        public string? ServerId { get; set; }
    }
}
