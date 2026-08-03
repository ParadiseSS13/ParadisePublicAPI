using ParadisePublicAPI.ProfilerDatabase;
using System.Text.Json.Serialization;

namespace ParadisePublicAPI.Models {
    public class Profiler_Sample {

        [JsonPropertyName("roundId")]
        public int RoundId { get; set; }

        [JsonPropertyName("sampleTime")]
        public DateTime SampleTime { get; set; }

        [JsonPropertyName("procpath")]
        public string Procpath { get; set; } = string.Empty;

        [JsonPropertyName("self")]
        public double Self { get; set; }

        [JsonPropertyName("total")]
        public double Total { get; set; }

        [JsonPropertyName("real")]
        public double Real { get; set; }

        [JsonPropertyName("over")]
        public double Over { get; set; }

        [JsonPropertyName("calls")]
        public int Calls { get; set; }

        public void FromModels(Proc proc, Sample sample) {
            RoundId = sample.RoundId;
            SampleTime = sample.SampleTime;
            Procpath = proc.Procpath;
            Self = sample.Self;
            Total = sample.Total;
            Real = sample.Real;
            Over = sample.Over;
            Calls = sample.Calls;
        }
    }
}
