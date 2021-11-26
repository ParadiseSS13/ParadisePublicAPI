using ParadisePublicAPI.Database;

namespace ParadisePublicAPI.Models {
    /// <summary>
    /// Model class for feedback data
    /// </summary>
    public class Stats_FeedbackModel {
        public string key_name { get; set; } = String.Empty;
        public string key_type { get; set; } = String.Empty;
        public int version { get; set; }
        public string raw_data { get; set; } = String.Empty;

        public void FromDBFeedback(Feedback feedback) {
            key_name = feedback.KeyName;
            key_type = feedback.KeyType;
            version = feedback.Version;
            raw_data = feedback.Json;
        }
    }
}
