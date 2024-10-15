
namespace Store.G04.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public ApiResponse(int statuscode,string? errormessage=null)
        {
            StatusCode = statuscode;
            ErrorMessage = errormessage ?? GetDefaultMessageForStatusCode(statuscode);
        }

        private string? GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch
            {
                400 => "Bad Request",
                404 => "Not Found",
                401 => "You Are NotAuthorized",
                500 => "Internal Server Error ",
                _ => null
            };
        }
    }
}
