using System.Collections.Generic;

namespace Skinet.Api.Errors
{
    public class ApiValidationResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationResponse() : base(400) { }
    }
}