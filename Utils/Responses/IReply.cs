namespace Utils.Responses
{
    public interface IReply
    {
        bool IsSuccess { get; }
        string? Message { get; }
        IEnumerable<string>? Errors { get; }
    }

    public interface IReply<T> : IReply
    {
        T? Data { get; }
    }
}
