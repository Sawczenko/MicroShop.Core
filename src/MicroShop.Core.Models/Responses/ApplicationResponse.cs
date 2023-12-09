namespace MicroShop.Core.Models.Responses
{
    public class ApplicationResponse
    {
        public bool IsSuccessful { get; set; }

        public DateTime CompletedAt { get; set; }

        public static ApplicationResponse CreateResponse()
        {
            return new ApplicationResponse
            {
                CompletedAt = DateTime.Now,
                IsSuccessful = true
            };
        }
    }

    public class ApplicationResponse<T> : ApplicationResponse
    {
        public T Result { get; set; }

        public static ApplicationResponse<T> CreateResponse(T result)
        {
            return new ApplicationResponse<T>
            {
                CompletedAt = DateTime.Now,
                IsSuccessful = true,
                Result = result
            };
        }
    }
}
