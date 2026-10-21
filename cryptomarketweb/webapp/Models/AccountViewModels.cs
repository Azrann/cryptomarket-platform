#region Using

using System.ComponentModel.DataAnnotations;

#endregion

namespace SmartAdminMvc.Models
{
    public class AccountLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class AccountForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class AccountResetPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }

    public class AccountRegistrationModel
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        [StringLength(65)]
        public string Website { get; set; }
        [StringLength(65)]
        public string TwitterUrl { get; set; }
        [StringLength(65)]
        public string YoutubeUrl { get; set; }
        [StringLength(65)]
        public string InstagramUrl { get; set; }
        [StringLength(65)]
        public string FacebookUrl { get; set; }
        [StringLength(65)]
        public string OtherUrl { get; set; }
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Country { get; set; }
        public bool CryptoExpert { get; set; }
        public bool ICOExpert { get; set; }
        public bool IWantListed { get; set; }

        [StringLength(250)]
        public string Bio { get; set; }
        public string FollowersJson { get; set; }
    }
}