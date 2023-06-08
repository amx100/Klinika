namespace Klinika.API.Data.Dto
{

    public class ResponseDto
    {
		public bool IsSuccess { get; set; } = true;
		public object Data { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}