namespace Application.Confessions.Common;

public record ConfessionResponse(Guid id, string title, string message, int upvotes, int downvotes, DateTime createdAt, DateTime modifiedAt);