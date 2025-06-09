using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IOzellikRepository {
		IEnumerable<Ozellik> GetAll(bool trackChanges);
		void Add(Ozellik ozellik);
		void Delete(int id);
		void UpdateOzellik(Ozellik ozellik);
	}
}
