namespace Store.G04.APIs.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int statuscode ,string?Message = null,string?details=null ):base(statuscode, Message)
        {
            Details = details;
        }
    }
}
