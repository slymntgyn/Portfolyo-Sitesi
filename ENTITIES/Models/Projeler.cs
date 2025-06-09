namespace ENTITIES.Models {
	public class Projeler {
		public int Id { get; set; }
		public string Baslik { get; set; } = string.Empty;
		public string Tip { get; set; } = string.Empty;
		public string AltBaslik { get; set; } = string.Empty;
		public string? ResimYolu { get; set; }
		public string? ProjeUrl { get; set; }
		public string? Aciklama { get; set; }

	}
}
