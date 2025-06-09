using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface IProjelerRepository {
		IEnumerable<Projeler> GetAll(bool trackChanges);
		void Add(Projeler projeler);
		void Delete(int id);
		void UpdateProjeler(Projeler projeler);
	}
}
