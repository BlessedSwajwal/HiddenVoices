namespace Domain;
public class Reply
{
    private Reply(Guid id, string message, int upvotes, int downvotes, Guid confessionId, string secretKey)
    {
        Id = id;
        Message = message;
        Upvotes = upvotes;
        Downvotes = downvotes;
        ConfessionId = confessionId;
        SecretKey = secretKey;
    }

    public Guid Id { get; private set; }
    public string Message { get; private set; }
    public int Upvotes { get; private set; }
    public int Downvotes { get; private set; }
    public Guid ConfessionId { get; private set; }
    public string SecretKey { get; private set; }

    public static Reply Create(string message, Guid confessionId)
    {
        return new(Guid.NewGuid(), message, 0, 0, confessionId, Guid.NewGuid().ToString());
    }
}
