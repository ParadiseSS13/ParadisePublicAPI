using ParadisePublicAPI.ProfilerDatabase;

namespace ParadisePublicAPI.Models {
    public class Profiler_Sample {
        public int roundId { get; set; }
        public DateTime sampleTime { get; set; }
        public string procpath { get; set; } = "";
        public double self { get; set; }
        public double total { get; set; }
        public double real { get; set; }
        public double over { get; set; }
        public int calls { get; set; }

        public void fromModels(Proc proc, Sample sample) {
            roundId = sample.RoundId;
            sampleTime = sample.SampleTime;
            procpath = proc.Procpath;
            self = sample.Self;
            total = sample.Total;
            real = sample.Real;
            over = sample.Over;
            calls = sample.Calls;
        }
    }
}
