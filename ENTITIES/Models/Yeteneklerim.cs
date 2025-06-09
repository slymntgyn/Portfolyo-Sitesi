namespace ENTITIES.Models {
	public class Yeteneklerim {
		public int Id { get; set; }
		public string Yetenek { get; set; } = string.Empty;
		public string? YetenekAciklama { get; set; }
		public string YetenekYuzde { get; set; } = string.Empty;
		public string? YetenekIcon { get; set; }
	}
}
