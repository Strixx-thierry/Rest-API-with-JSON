namespace RestApiJson.Data
{
    // The "metadata" info jsonbin.io adds around our data.
    // (We skip "private" because it is a C# reserved word.)
    [System.Serializable]
    public class Metadata
    {
        public string id;
        public string createdAt;
        public string name;
    }
}
