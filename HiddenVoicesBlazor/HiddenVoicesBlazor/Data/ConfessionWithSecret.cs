namespace HiddenVoicesBlazor.Data;

public record ConfessionWithSecret(Guid id, string title, string message, int upvotes, int downvotes, string secretKey, DateTime createdAt, DateTime modifiedAt);
