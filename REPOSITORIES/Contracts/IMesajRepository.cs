using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IMesajRepository {
		IEnumerable<Message> GetAll(bool trackChanges);

		void Add(Message mesaj);
		void Delete(int id);
		void UpdateMesaj(Message mesaj);

	}
}
