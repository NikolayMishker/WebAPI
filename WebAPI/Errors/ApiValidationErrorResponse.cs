using System.Collections.Generic;

namespace WebAPI.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse () : base(400)
        {}       
    }
}
