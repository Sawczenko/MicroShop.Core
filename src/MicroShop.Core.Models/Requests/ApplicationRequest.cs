namespace MicroShop.Core.Models.Requests
{
    public class ApplicationRequest
    {
        public object Response { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public TimeSpan Duration { get; set; }

        public Exception Exception { get; set; }

        public bool IsSuccess { get; set; }

        public TimeSpan CalculateDuration()
        {
            if(CompletionDate != default && StartDate != default)
            {
                Duration = CompletionDate - StartDate;
                return Duration;
            }

            throw new Exception("One of application request date fields is not valid!");
        }
    }
}
