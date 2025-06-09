using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class ReferanslarRepository : RepositoryBase<Referanslar>, IReferanslarRepository {
		public ReferanslarRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Referanslar referanslar) {
			if (referanslar == null) {
				throw new ArgumentNullException(nameof(referanslar), "Referanslar cannot be null");
			}
			Create(referanslar);
		}

		public void Delete(int id) {
			if (id <= 0) {
				throw new ArgumentException("ID must be greater than zero", nameof(id));
			}
			Referanslar? referans = GetOneData(r => r.Id == id, false);
			if (referans == null) {
				throw new KeyNotFoundException($"Referans with ID {id} not found");
			}
			remove(referans);
		}

		public IEnumerable<Referanslar> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}


		public void UpdateReferanslar(Referanslar referanslar) {
			if (referanslar == null) {
				throw new ArgumentNullException(nameof(referanslar), "Referanslar cannot be null");
			}
			if (referanslar.Id <= 0) {
				throw new ArgumentException("ID must be greater than zero", nameof(referanslar.Id));
			}
			Update(referanslar);
		}
	}
}
