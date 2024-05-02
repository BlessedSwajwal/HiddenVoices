using HiddenVoicesBlazor.API.Interface;
using HiddenVoicesBlazor.Data;
using System.Text;
using System.Text.Json;

namespace HiddenVoicesBlazor.API.Implementation;

public class ConfessionAPIService(HttpClient _httpClient) : IConfessionAPIService
{
    public async Task<List<ConfessionResponse>> GetConfessionResponses(int offset = 0, int count = 10)
    {
        if (count <= 0) count = 10;
        var response = await _httpClient.GetFromJsonAsync<List<ConfessionResponse>>($"https://localhost:7122/api/Confession/All?offset={offset}&count={count}");
        return response;
    }
    public async Task<ConfessionResponse> GetConfessionDetail(Guid confessionId)
    {
        var response = await _httpClient.GetFromJsonAsync<ConfessionResponse>($"https://localhost:7122/api/Confession/Detail?confessionId={confessionId}");
        return response;
    }

    public async Task<ConfessionWithSecret> CreateConfession(string title, string message)
    {
        var data = new
        {
            title,
            message
        };

        var json = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7122/api/Confession/Create", stringContent);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("error creating confession");
        }
        var confession = await response.Content.ReadFromJsonAsync<ConfessionWithSecret>();
        return confession;
    }

    public async Task<string> AddComment(Guid confessionId, string message, Guid? parentReply)
    {
        var data = new
        {
            comment = message
        };
        var json = JsonSerializer.Serialize(data);
        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7122/api/Confession/Comment?confessionId={confessionId}", stringContent);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("error creating comment");
        }

        var secretKey = JsonDocument.Parse(response.Content.ReadAsStream()).RootElement.GetProperty("secretKey").GetString();
        return secretKey;
    }
}
