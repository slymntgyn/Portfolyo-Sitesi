using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IReferanslarService {
		void AddReferansBilgi(Referanslar referans);
		void DeleteReferansBilgi(int id);
		IEnumerable<Referanslar> GetReferansBilgileri();
		void UpdateReferansBilgi(int id, Referanslar referans);

	}
}
