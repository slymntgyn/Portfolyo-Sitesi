using System.ComponentModel.DataAnnotations;

namespace TuranProjects_Portfolio.Models {
	public class LoginModel {
		private string? _returnUrl = string.Empty;
		[Required(ErrorMessage = "Kullanıcı adı alanı zorunludur")]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; } = string.Empty;
		[Required(ErrorMessage = "Şifre alanı zorunludur")]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; } = string.Empty;
		public string ReturnUrl {
			get {
				if (string.IsNullOrEmpty(_returnUrl)) {
					return "/";
				}
				return _returnUrl;
			}

			set => _returnUrl = value;
		}
	}
}
