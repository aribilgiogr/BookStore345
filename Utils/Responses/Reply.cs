namespace Utils.Responses
{
    public class Reply : IReply
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public IEnumerable<string>? Errors { get; init; }
    }

    public class Reply<T> : Reply, IReply<T>
    {
        public T? Data { get; init; }
    }
}
