using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IHakkindaRepository {
		IEnumerable<Hakkinda> GetAll(bool trackChanges);
		Hakkinda GetById(int id, bool trackChanges);
		void Add(Hakkinda hakkinda);
		void Delete(int id);
		void UpdateHakkinda(Hakkinda hakkinda);
	}
}
