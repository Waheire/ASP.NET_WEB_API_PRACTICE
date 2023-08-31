namespace WebApiPractice.ResponseDto
{
    public class TodoSuccess
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TodoSuccess(int id, string message)
        {
            this.Code = id;
            this.Message = message;
        }
    }
}
