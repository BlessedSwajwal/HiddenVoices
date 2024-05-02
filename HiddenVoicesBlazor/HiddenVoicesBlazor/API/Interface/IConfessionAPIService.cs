using HiddenVoicesBlazor.Data;

namespace HiddenVoicesBlazor.API.Interface;

public interface IConfessionAPIService
{
    Task<string> AddComment(Guid confessionId, string message, Guid? parentReply);
    Task<ConfessionWithSecret> CreateConfession(string title, string message);
    Task<ConfessionResponse> GetConfessionDetail(Guid confessionId);
    Task<List<ConfessionResponse>> GetConfessionResponses(int offest, int count);
}
