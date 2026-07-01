namespace RestApiJson.Data
{
    // One row of the player's "inventory" array.
    [System.Serializable]
    public class InventoryItem
    {
        public string itemName;
        public int quantity;
        public float weight;
    }
}
