using Newtonsoft.Json;

namespace CodeCheater.Infrastructure.Messages
{
    public class FailedMessageModel : IMessage
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public int StatusCode { get; set; }
        public bool HasError { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
