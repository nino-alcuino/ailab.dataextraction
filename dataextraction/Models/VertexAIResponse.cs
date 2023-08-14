namespace dataextraction.Models
{
    public class VertexAIResponse
    {
        public List<Prediction> predictions { get; set; } = new List<Prediction>();
    }
    public class CitationMetadata
    {
        public List<object> citations { get; set; } = new List<object>();
    }

    public class Prediction
    {
        public CitationMetadata citationMetadata { get; set; } = null!;
        public SafetyAttributes safetyAttributes { get; set; } = null!;
        public string content { get; set; } = null!;
    }

    public class SafetyAttributes
    {
        public bool blocked { get; set; }
        public List<object> scores { get; set; } = null!;
        public List<object> categories { get; set; } = null!;
    }
}
