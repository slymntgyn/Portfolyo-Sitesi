using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface ISosyalMedyalarService {
		void AddSosyalMedyaBilgi(SosyalMedyalar sosyalMedyalar);
		void DeleteSosyalMedyaBilgi(int id);
		IEnumerable<SosyalMedyalar> GetSosyalMedyalarBilgileri();
		void UpdateSosyalMedyaBilgi(int id, SosyalMedyalar sosyalMedyalar);
	}
}
