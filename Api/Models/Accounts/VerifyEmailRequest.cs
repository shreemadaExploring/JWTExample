using System.ComponentModel.DataAnnotations;

namespace Api.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}