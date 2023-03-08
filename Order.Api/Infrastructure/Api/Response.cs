using System.Text.Json.Serialization;

namespace Order.Api.Infrastructure.Api
{
    public class Response<T>
    {
        public int DataTotalCount { get; set; }
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public bool IsSuccessful { get; set; }

        public string TimeStamp { get; set; }

        private List<string> _errors;
        public List<string> Errors
        {
            get
            {
                if (_errors == null)
                    _errors = new List<string>();
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        // Static Factory Method
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        // Static Factory Method
        public static Response<T> Success(T data, int dataTotalCount, int statusCode)
        {
            return new Response<T> { Data = data, DataTotalCount = dataTotalCount, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)

        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string>() { error }, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}