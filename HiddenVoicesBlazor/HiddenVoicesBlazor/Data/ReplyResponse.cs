namespace HiddenVoicesBlazor.Data;

public record ReplyResponse(Guid id, string message, int upvotes, int downvotes, Guid confessionId, Guid? parentReply);
