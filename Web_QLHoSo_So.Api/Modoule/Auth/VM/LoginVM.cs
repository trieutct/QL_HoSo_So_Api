using System.ComponentModel.DataAnnotations;

namespace Web_QLHoSo_So.Api.Modoule.Auth.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username không được để trống")]
        [MinLength(4,ErrorMessage ="Username không dưới 4 ký tự")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password không được để trống")]
        [MinLength(4, ErrorMessage = "Password không dưới 4 ký tự")]
        public string password { get; set; }
    }
}
