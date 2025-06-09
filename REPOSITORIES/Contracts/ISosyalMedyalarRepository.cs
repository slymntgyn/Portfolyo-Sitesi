using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface ISosyalMedyalarRepository {
		IEnumerable<SosyalMedyalar> GetAll(bool trackChanges);
		void Add(SosyalMedyalar sosyalMedyalar);
		void Delete(int id);
		void UpdateSosyalMedyalar(SosyalMedyalar sosyalMedyalar);
	}
}
