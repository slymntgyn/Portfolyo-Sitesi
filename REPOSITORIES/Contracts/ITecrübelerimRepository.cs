using ENTITIES.Models;

namespace REPOSITORIES.Contracts {
	public interface ITecrübelerimRepository {
		IEnumerable<Tecrübelerim> GetAll(bool trackChanges);
		void Add(Tecrübelerim tecrübelerim);
		void Delete(int id);
		void UpdateTecrube(Tecrübelerim tecrübelerim);
	}
}
