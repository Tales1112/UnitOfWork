using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Unity_Of_Work.Models
{
    public class Notificator
    {
        public ICollection<string> Errors = new List<string>();
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

        public bool ValidOperation()
        {
            return !Errors.Any();
        }
        public static Notificator OK()
        {
            var result = new Notificator
            {
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
            return result;
        }
        public static Notificator OK(string message)
        {
            var result = new Notificator
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = message
            };
            return result;
        }
        public static Notificator OK(string message, object data = null)
        {
            var result = new Notificator()
            {
                Message = message,
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = data
            };
            return result;
        }
        public static Notificator OK(object data)
        {
            var result = new Notificator()
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Data = data
            };
            return result;
        }
        public static Notificator NorOk()
        {
            var result = new Notificator()
            {
                Success = true
            };
            return result;
        }
        public static Notificator NorOk(string messages, HttpStatusCode code)
        {
            var result = new Notificator()
            {
                Success = false,
                StatusCode = code,
            };

            result.AddMessagesErrors(messages);
            return result;
        }
        public static Notificator NorOk(List<string> messages, HttpStatusCode code)
        {
            var result = new Notificator()
            {
                Success = false,
                StatusCode = code
            };

            foreach (var error in messages)
            {
                result.AddMessagesErrors(error);
            }

            return result;
        }
        public void AddMessagesErrors(string error)
        {
            Errors.Add(error);
        }
    }
}

