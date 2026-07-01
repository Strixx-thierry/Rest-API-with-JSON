# REST API with JSON — Unity

A  Unity project that fetches remote player data from a REST API, deserializes
the JSON into C# classes, and displays it in a clean, dynamic UI.

**API:** `https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa`

## What it shows
- Player profile: name, level, health, and position.
- An inventory list (name, quantity, weight), built dynamically — one row per item.
- A **Refresh** button that reloads the data, plus on-screen error handling.

## How it's structured
The code is split so UI logic and data logic stay separate:

- `Assets/Scripts/Data/` — plain C# classes that mirror the JSON
  (`ApiResponse`, `PlayerData`, `Position`, `InventoryItem`, `Metadata`).
- `Assets/Scripts/Services/` — `IDataService` (interface) and `JsonApiService`,
  the only place that talks to the web (`UnityWebRequest`) and deserializes the
  JSON (`JsonUtility`).
- `Assets/Scripts/UI/` — `PlayerDataUIController` (fills the screen) and
  `InventoryItemView` (one reusable inventory row).

## How to run
1. Open the project in **Unity 6 (6000.4.5f1)**.
2. Open the scene `Assets/Scenes/SampleScene.unity`.
3. Press **Play**. The data loads automatically from the API.
4. Click **Refresh** to reload it.

