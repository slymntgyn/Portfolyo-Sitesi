using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class OzellikRepository : RepositoryBase<Ozellik>, IOzellikRepository {
		public OzellikRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Ozellik ozellik) {
			if (ozellik == null) {
				throw new ArgumentNullException(nameof(ozellik), "Ozellik cannot be null");
			}
			Create(ozellik);
		}

		public void Delete(int id) {
			if (id == 0) {
				throw new ArgumentException("ID cannot be zero", nameof(id));
			}
			Ozellik? ozellik = GetOneData(o => o.Id == id, false);
			if (ozellik == null) {
				throw new KeyNotFoundException($"Ozellik with ID {id} not found");
			}
			remove(ozellik);
		}

		public IEnumerable<Ozellik> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}


		public void UpdateOzellik(Ozellik ozellik) {
			if (ozellik == null) {
				throw new ArgumentNullException(nameof(ozellik), "Ozellik cannot be null");
			}
			if (ozellik.Id == 0) {
				throw new ArgumentException("ID cannot be zero", nameof(ozellik.Id));
			}
			Update(ozellik);
		}
	}
}
