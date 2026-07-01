using System;
using RestApiJson.Data;

namespace RestApiJson.Services
{
    // Contract for anything that can fetch player data.
    // The UI depends on this, not on the concrete class.
    public interface IDataService
    {
        // Ask for the data. One callback runs on success, the other on failure.
        void FetchData(Action<PlayerData> onSuccess, Action<string> onError);
    }
}
