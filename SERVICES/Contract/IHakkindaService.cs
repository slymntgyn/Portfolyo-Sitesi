using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IHakkindaService {
		IEnumerable<Hakkinda> GetHakkindaBilgileri();
		void AddHakkindaBilgi(Hakkinda hakkinda);
		void UpdateHakkindaBilgi(int id, Hakkinda hakkinda);
		void DeleteHakkindaBilgi(int id);
	}
}
