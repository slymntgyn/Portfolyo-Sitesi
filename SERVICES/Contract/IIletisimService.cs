using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IIletisimService {
		void AddIletisimBilgi(Contact iletisim);
		void DeleteIletisimBilgi(int id);
		IEnumerable<Contact> GetIletisimBilgileri();
		void UpdateIletisimBilgi(int id, Contact iletisim);
		Contact GetIletisimById(int id, bool trackChanges = false);
	}
}
