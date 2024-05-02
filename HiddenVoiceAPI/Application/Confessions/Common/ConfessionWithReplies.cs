using Application.Common.DTO;

namespace Application.Confessions.Common;
public record ConfessionWithReplies(Guid id, string title, string message, int upvotes, int downvotes, DateTime createdAt, DateTime modifiedAt, List<ReplyResponse> replies);
