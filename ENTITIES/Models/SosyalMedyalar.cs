namespace ENTITIES.Models {
	public class SosyalMedyalar {
		public int Id { get; set; }
		public string? Adi { get; set; }
		public string? Url { get; set; }
		public string? Icon { get; set; }
		public int Durum { get; set; }
		public int SiraNo { get; set; } = 0;
	}
}
