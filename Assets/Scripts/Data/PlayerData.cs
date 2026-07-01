namespace RestApiJson.Data
{
    // the "record" object from the API.
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int level;
        public float health;
        public Position position;         // the x/y/z object
        public InventoryItem[] inventory; // the list of items
    }
}
