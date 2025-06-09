using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IReferanslarRepository {
		IEnumerable<Referanslar> GetAll(bool trackChanges);
		void Add(Referanslar referanslar);
		void Delete(int id);
		void UpdateReferanslar(Referanslar referanslar);
	}
}
