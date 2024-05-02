namespace HiddenVoicesBlazor.Data;

public record ConfessionResponse(Guid id, string title, string message, int upvotes, int downvotes, DateTime createdAt, DateTime modifiedAt, List<ReplyResponse> replies);


