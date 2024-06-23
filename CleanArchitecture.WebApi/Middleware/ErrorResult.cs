﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CleanArchitecture.WebApi.Middleware
{
    public sealed class ErrorResult : ErrorStatusCode
    {
        public string Message { get; set; }
    }
    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public sealed class ValidationErrorDetail : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
