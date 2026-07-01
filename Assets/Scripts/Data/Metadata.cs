namespace RestApiJson.Data
{
    // The "metadata" info jsonbin.io adds around our data.
    [System.Serializable]
    public class Metadata
    {
        public string id;
        public string createdAt;
        public string name;
    }
}
