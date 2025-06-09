using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IOzellikService {
		void AddOzellikBilgi(Ozellik ozellik);
		void DeleteOzellikBilgi(int id);
		IEnumerable<Ozellik> GetOzellikBilgileri();
		void UpdateOzellikBilgi(int id, Ozellik ozellik);

	}
}
