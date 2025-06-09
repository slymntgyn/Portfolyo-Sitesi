using System.ComponentModel.DataAnnotations;

namespace ENTITIES.Dtos {
	public record UserDtoForCreation : UserDto {
		[DataType(DataType.Password)]

		[Required(ErrorMessage = "Şifre gereklidir.")]
		public string? Password { get; init; }
	}
}
