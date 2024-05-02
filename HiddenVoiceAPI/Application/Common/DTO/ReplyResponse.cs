namespace Application.Common.DTO;

public record ReplyResponse(Guid id, string message, int upvotes, int downvotes, Guid confessionId, Guid? parentReply);
