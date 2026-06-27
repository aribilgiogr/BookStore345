namespace Utils.Responses
{
    public static class ReplyFactory
    {
        public static Reply Success(string? message)
        {
            return new()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static Reply Fail(string? message, IEnumerable<string>? errors)
        {
            return new()
            {
                IsSuccess = false,
                Message = message,
                Errors = errors
            };
        }

        public static Reply<T> Success<T>(T? data, string? message)
        {
            return new()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static Reply<T> Fail<T>(T? data, string? message, IEnumerable<string>? errors)
        {
            return new()
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                Data = data
            };
        }
    }
}
