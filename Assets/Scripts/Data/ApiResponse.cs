namespace RestApiJson.Data
{
    // Top level of the JSON. jsonbin.io wraps our player data in "record"
    // and adds "metadata". This is the class we parse the response into.
    [System.Serializable]
    public class ApiResponse
    {
        public PlayerData record;
        public Metadata metadata;
    }
}
