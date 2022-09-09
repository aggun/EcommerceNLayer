using System.ComponentModel.DataAnnotations;

namespace eticaretWebsite.Models
{
    public class CustomerRegisterModel
    {
        [Required(ErrorMessage = "Lütfen epost adresinizi giriniz")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifreniz büyük, küçük harfler ve sayılar içermelidir.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı giriniz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı  giriniz")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı  giriniz")]
        public string? UserName { get; set; }
    }
}
