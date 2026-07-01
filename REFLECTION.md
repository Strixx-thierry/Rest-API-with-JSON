# Reflection — REST API with JSON

## 1. The JSON structure

The API returns the player data wrapped in two layers that jsonbin.io adds
automatically: a `record` object (the real payload) and a `metadata` envelope.

```json
{
  "record": {
    "playerName": "BSE Maestro",
    "level": 10,
    "health": 85.5,
    "position": { "x": 1, "y": 2, "z": 3 },
    "inventory": [
      { "itemName": "Sword",  "quantity": 1, "weight": 5   },
      { "itemName": "Shield", "quantity": 1, "weight": 7.5 },
      { "itemName": "Potion", "quantity": 5, "weight": 0.5 }
    ]
  },
  "metadata": { "id": "...", "createdAt": "...", "name": "PlayerData" }
}
```

To map this completely I made one C# class per level of the structure:

- `ApiResponse` — the top level (`record` + `metadata`).
- `PlayerData` — the player fields, plus a nested `Position` and an
  `InventoryItem[]` array.
- `Position` — `x`, `y`, `z`.
- `InventoryItem` — `itemName`, `quantity`, `weight`.
- `Metadata` — `id`, `createdAt`, `name`.

Every field name matches the JSON exactly, because Unity's `JsonUtility` maps by
name. `JsonUtility.FromJson<ApiResponse>(text)` fills the whole tree in one call,
and the UI only ever receives the unwrapped `record` (a `PlayerData`).

## 2. How the UI presents the data

The UI is built on Unity's Canvas with layout groups, so spacing and alignment
are handled automatically and it scales with screen size.

- A bold **title** and the player stats (name, level, health, position) sit at
  the top as a clear header — visual hierarchy from big/bold down to normal text.
- The **inventory** is a scrollable list. Each item is a reusable `Row` prefab
  showing name, quantity, and weight in aligned columns. The controller spawns
  one row per item, so the list is fully dynamic — if the data changes, the UI
  changes with it.
- A **status line** shows "Loading..." while fetching and an error message if
  something goes wrong.

I kept the data and UI logic separate: `JsonApiService` handles the web request
and deserialization, and it implements the `IDataService` interface. The UI
controller depends on that interface, not the concrete class, so the parts stay
loosely coupled and easy to change.

## 3. Challenges and extra features

**Challenges**
- The jsonbin.io `record` / `metadata` wrapper. At first I expected the player
  fields at the top level; I had to add an `ApiResponse` class to match the real
  shape before deserialization worked.
- `private` is a reserved word in C#, so I couldn't name a field after the JSON's
  `"private"` key. Since I don't display it, I left it out of `Metadata`.
- Because the project uses the new Input System, the button needed the Input
  System UI module on the EventSystem to be clickable.

**Extra features**
- **Refresh button** that reloads the data using a button click event (delegate).
- **Error handling** — network failures and bad JSON show a message instead of
  crashing.
- **Scrollable inventory list** so it works no matter how many items there are.
