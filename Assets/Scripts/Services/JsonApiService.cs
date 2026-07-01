using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using RestApiJson.Data;

namespace RestApiJson.Services
{
    // The one place that talks to the web and turns JSON text into objects.
    // Implements IDataService so the UI can depend on the contract, not this class.
    public class JsonApiService : MonoBehaviour, IDataService
    {
        [SerializeField] // editable in the Inspector, no magic string in code
        private string apiUrl = "https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa";

        // Entry point from the interface. Starts the coroutine that does the work.
        public void FetchData(Action<PlayerData> onSuccess, Action<string> onError)
        {
            StartCoroutine(FetchRoutine(onSuccess, onError));
        }

        // Runs across several frames so the web request never freezes the game.
        private IEnumerator FetchRoutine(Action<PlayerData> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
            {
                // Send the request and wait here until the server replies.
                yield return request.SendWebRequest();

                // Did the network call itself fail? (no internet, bad URL, server error)
                if (request.result != UnityWebRequest.Result.Success)
                {
                    onError?.Invoke(request.error);
                    yield break;
                }

                // We got text back. Try to translate it into our C# objects.
                try
                {
                    string json = request.downloadHandler.text;
                    ApiResponse response = JsonUtility.FromJson<ApiResponse>(json);
                    onSuccess?.Invoke(response.record); // hand back only the player data
                }
                catch (Exception e)
                {
                    // The text arrived but wasn't the shape we expected.
                    onError?.Invoke("Failed to read data: " + e.Message);
                }
            }
        }
    }
}
