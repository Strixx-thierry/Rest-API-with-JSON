using UnityEngine;
using TMPro;
using RestApiJson.Data;

namespace RestApiJson.UI
{
    // Sits on the inventory-row prefab. Fills its 3 texts from one item.
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text quantityText;
        [SerializeField] private TMP_Text weightText;

        // Called once for each item to show its values on this row.
        public void Bind(InventoryItem item)
        {
            nameText.text = item.itemName;
            quantityText.text = "x" + item.quantity;
            weightText.text = item.weight + " kg";
        }
    }
}
