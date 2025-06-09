using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IProjelerService {
		void AddProjeBilgi(Projeler proje);
		void DeleteProjeBilgi(int id);
		IEnumerable<Projeler> GetProjeBilgileri();
		void UpdateProjeBilgi(int id, Projeler proje);
		Projeler GetProjeById(int id);
		IEnumerable<Projeler> GetProjeByKategoriId(string tip);
	}
}
