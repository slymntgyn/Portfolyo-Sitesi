using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IYeteneklerimRepository {
		IEnumerable<Yeteneklerim> GetAll(bool trackChanges);
		void Add(Yeteneklerim yeteneklerim);
		void Delete(int id);
		void UpdateYeteneklerim(Yeteneklerim yeteneklerim);
	}
}
