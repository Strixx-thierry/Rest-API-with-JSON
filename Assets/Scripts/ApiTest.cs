using UnityEngine;
using RestApiJson.Data;
using RestApiJson.Services;

// TEMPORARY test. Attach to any object (the cube), press Play, watch the Console.
// Delete this once the UI works.
public class ApiTest : MonoBehaviour
{
    private void Start()
    {
        // Make a service and ask it for the data.
        JsonApiService service = gameObject.AddComponent<JsonApiService>();
        service.FetchData(OnSuccess, OnError);
    }

    private void OnSuccess(PlayerData data)
    {
        Debug.Log("SUCCESS! Player: " + data.playerName + ", Level: " + data.level);
        Debug.Log("Inventory items: " + data.inventory.Length);
    }

    private void OnError(string error)
    {
        Debug.LogError("FAILED: " + error);
    }
}
