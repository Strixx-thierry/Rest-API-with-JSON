using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RestApiJson.Data;
using RestApiJson.Services;

namespace RestApiJson.UI
{
    // asks the service for data, then fills the screen with it.
    public class PlayerDataUIController : MonoBehaviour
    {
        [Header("Data source")]
        [SerializeField] private JsonApiService apiService;
        private IDataService dataService;                   // used through the interface

        [Header("Header texts")]
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private TMP_Text positionText;

        [Header("Inventory list")]
        [SerializeField] private Transform inventoryContent;
        [SerializeField] private InventoryItemView itemPrefab;   

        [Header("Status / controls")]
        [SerializeField] private TMP_Text statusText;
        [SerializeField] private Button refreshButton;

        private void Awake()
        {
            // Depend on the interface, not the concrete class.
            dataService = apiService;
        }

        private void Start()
        {
            // Refresh button reloads the data (LO2: events/delegates).
            refreshButton.onClick.AddListener(LoadData);
            LoadData();
        }

        // Ask the service for fresh data.
        private void LoadData()
        {
            statusText.text = "Loading...";
            dataService.FetchData(OnLoaded, OnError);
        }

        // Runs when data arrives successfully.
        private void OnLoaded(PlayerData data)
        {
            nameText.text = data.playerName;
            levelText.text = "Level " + data.level;
            healthText.text = "Health: " + data.health;
            positionText.text = "Position: (" + data.position.x + ", "
                                + data.position.y + ", " + data.position.z + ")";

            BuildInventory(data.inventory);
            statusText.text = "";
        }

        // Runs when the load fails.
        private void OnError(string error)
        {
            statusText.text = "Error: " + error;
        }

        // Clear old rows, then spawn one row per item.
        private void BuildInventory(InventoryItem[] items)
        {
            foreach (Transform child in inventoryContent)
                Destroy(child.gameObject);

            foreach (InventoryItem item in items)
            {
                InventoryItemView row = Instantiate(itemPrefab, inventoryContent);
                row.Bind(item);
            }
        }
    }
}
