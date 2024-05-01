using HiddenVoicesBlazor.Data;

namespace HiddenVoicesBlazor.API.Interface;

public interface IConfessionAPIService
{
    Task<ConfessionWithSecret> CreateConfession(string title, string message);
    Task<List<ConfessionResponse>> GetConfessionResponses(int offest, int count);
}
