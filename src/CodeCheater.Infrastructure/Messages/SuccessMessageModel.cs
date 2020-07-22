using Newtonsoft.Json;

namespace CodeCheater.Infrastructure.Messages
{
    public class SuccessMessageModel : IMessage
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
