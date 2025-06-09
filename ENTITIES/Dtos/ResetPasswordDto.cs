using System.ComponentModel.DataAnnotations;

namespace ENTITIES.Dtos {
	public record ResetPasswordDto {
		public string UserName { get; init; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Lütfen yeni şifrenizi giriniz.")]
		[MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
		public string NewPassword { get; init; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
		[MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
		[Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor.")]
		public string ConfirmPassword { get; init; }

	}
}
