using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCheater.Infrastructure.Messages
{
    public interface IMessage
    {
        public string Message { get; set; }
        public string Description { get; set; }

        public int StatusCode { get; set; }

    }
}
