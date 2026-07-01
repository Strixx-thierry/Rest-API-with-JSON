namespace RestApiJson.Data
{
    // "metadata". This is the class we parse the response into.
    [System.Serializable]
    public class ApiResponse
    {
        public PlayerData record;
        public Metadata metadata;
    }
}
