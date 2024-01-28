

namespace ATM.BLL.DTOs.RegisterDtos
{
    public class RegisterDto
    {
        public string CardNumber { get; set; } = string.Empty;
        public string Pin { get; set; } = string.Empty;

        public int Balance { get; set; } = 0;   
    }
}
