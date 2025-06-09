using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IYeteneklerimService {
		void AddYetenekBilgi(Yeteneklerim yeteneklerim);
		void DeleteYetenekBilgi(int id);
		IEnumerable<Yeteneklerim> GetYetenekBilgileri();
		void UpdateYetenekBilgi(int id, Yeteneklerim yeteneklerim);
	}
}
