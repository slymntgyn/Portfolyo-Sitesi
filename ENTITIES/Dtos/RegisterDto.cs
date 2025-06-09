using System.ComponentModel.DataAnnotations;

namespace ENTITIES.Dtos {
	public record RegisterDto {
		[Required(ErrorMessage = "Kullanıcı adını giriniz.")]
		public string Username { get; init; } = string.Empty;
		[Required(ErrorMessage = "Mail adresini giriniz.")]
		public string Email { get; init; } = string.Empty;
		[Required(ErrorMessage = "Şifrenizi giriniz.")]
		public string Password { get; init; } = string.Empty;
	}
}
