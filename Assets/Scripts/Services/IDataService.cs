using System;
using RestApiJson.Data;

namespace RestApiJson.Services
{
    // The UI depends on this.
    public interface IDataService
    {
        // Ask for the data. One callback runs on success, the other on failure.
        void FetchData(Action<PlayerData> onSuccess, Action<string> onError);
    }
}
