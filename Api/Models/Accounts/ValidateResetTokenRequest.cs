using System.ComponentModel.DataAnnotations;

namespace Api.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}