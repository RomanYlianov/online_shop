using System;
using System.Net;

namespace onlineshop.Models
{
    public class HttpException<T> : Exception
    {
        public readonly string ClassName;

        public readonly string MethodName;

        public readonly HttpStatusCode Code;

        public HttpException(string methodName, string message, HttpStatusCode code) : base(message)
        {
            this.ClassName = typeof(T).Name;
            this.MethodName = methodName;
            this.Code = code;
        }
    }
}