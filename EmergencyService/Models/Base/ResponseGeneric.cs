using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmergencyService.Models.Base
{
    public class ResponseGeneric<T>
    {
        public string Message { get; set; }
        public bool State { get; set; }
        public HttpStatusCode Code { get; set; }
        public int Status => (int)Code;
        public T Data { get; set; }

        public ResponseGeneric(string message, T data, HttpStatusCode code = HttpStatusCode.OK, bool state = true)
        {
            Message = message;
            Code = code;
            State = state;
            Data = data;
        }

    }
}
