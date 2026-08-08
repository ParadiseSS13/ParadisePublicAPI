using ParadisePublicAPI.Database;
using System.Text.Json.Serialization;

namespace ParadisePublicAPI.Models {
    public class ChangelogModel {
        [JsonPropertyName("key")]
        public int RowId { get; set; } // This is named key just to make react accept it

        [JsonPropertyName("prn")]
        public int PrNumber { get; set; }

        [JsonPropertyName("dm")]
        public DateTime DateMerged { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; } = string.Empty;

        [JsonPropertyName("clt")]
        public string ChangelogType { get; set; } = string.Empty;

        [JsonPropertyName("cle")]
        public string ChangelogEntry { get; set; } = string.Empty;

        public void FromModel(Changelog changelog) {
            RowId = changelog.Id;
            PrNumber = changelog.PrNumber;
            DateMerged = changelog.DateMerged;
            Author = changelog.Author;
            ChangelogType = changelog.ClType;
            ChangelogEntry = changelog.ClEntry;
        }
    }
}
