using System.ComponentModel.DataAnnotations;

namespace ENTITIES.Dtos {
	public record UserDto {
		[DataType(DataType.Text)]
		[Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
		public string? UserName { get; init; }
		[DataType(DataType.EmailAddress)]

		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
		public string? Email { get; init; }

		[DataType(DataType.PhoneNumber)]

		[Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
		public string? PhoneNumber { get; init; }

		public HashSet<String> Roles { get; set; } = new HashSet<string>();

	}
}
