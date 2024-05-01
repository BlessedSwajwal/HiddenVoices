namespace Domain;
public class Confession
{
    public static Confession Empty = new Confession();
    private Confession(Guid id, string title, string message, string secretKey, int upvotes, int downVotes, DateTime createdAt, DateTime modifiedAt)
    {
        Id = id;
        Title = title;
        Message = message;
        SecretKey = secretKey;
        Upvotes = upvotes;
        DownVotes = downVotes;
        CreatedAt = createdAt;
        ModifiedAt = modifiedAt;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public string SecretKey { get; private set; }
    public int Upvotes { get; private set; }
    public int DownVotes { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public static Confession Create(string title, string message)
    {
        return new(Guid.NewGuid(), title, message, Guid.NewGuid().ToString(), 0, 0, DateTime.Now, DateTime.Now);
    }

    private Confession() { }
}
