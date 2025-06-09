using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class ProjelerRepository : RepositoryBase<Projeler>, IProjelerRepository {
		public ProjelerRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Projeler projeler) {
			if (projeler == null) {
				throw new ArgumentNullException(nameof(projeler), "Projeler cannot be null");
			}
			Create(projeler);
		}

		public void Delete(int id) {
			if (id <= 0) {
				throw new ArgumentException("ID must be greater than zero", nameof(id));
			}
			Projeler? projeler = GetOneData(p => p.Id == id, false);
			if (projeler == null) {
				throw new KeyNotFoundException($"Projeler with ID {id} not found");
			}
			remove(projeler);
		}

		public IEnumerable<Projeler> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}


		public void UpdateProjeler(Projeler projeler) {
			if (projeler == null) {
				throw new ArgumentNullException(nameof(projeler), "Projeler cannot be null");
			}
			if (projeler.Id <= 0) {
				throw new ArgumentException("ID must be greater than zero", nameof(projeler.Id));
			}
			Update(projeler);
		}
	}
}
