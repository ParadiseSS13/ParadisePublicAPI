using ParadisePublicAPI.Database;
using System.Text.Json.Serialization;

namespace ParadisePublicAPI.Models {
    /// <summary>
    /// Model class for feedback data
    /// </summary>
    public class Stats_FeedbackModel {

        [JsonPropertyName("key_name")]
        public string KeyName { get; set; } = string.Empty;

        [JsonPropertyName("key_type")]
        public string KeyType { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("raw_data")]
        public string RawData { get; set; } = string.Empty;

        public void FromDBFeedback(Feedback feedback) {
            KeyName = feedback.KeyName;
            KeyType = feedback.KeyType;
            Version = feedback.Version;
            RawData = feedback.Json;
        }
    }
}
