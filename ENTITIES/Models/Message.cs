namespace ENTITIES.Models {
	public class Message {
		public int Id { get; set; }
		public string Isim { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Konu { get; set; } = string.Empty;
		public string Mesaj { get; set; } = string.Empty;
		public DateTime GonderilmeTarihi { get; set; }
		public bool IsRead { get; set; }

	}
}
