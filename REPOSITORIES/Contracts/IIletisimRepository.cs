using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IIletisimRepository {
		IEnumerable<Contact> GetAll(bool trackChanges);
		Contact GetById(int id, bool trackChanges);
		void Add(Contact iletisim);
		void Delete(int id);
		void UpdateIletisim(Contact iletisim);
	}
}
