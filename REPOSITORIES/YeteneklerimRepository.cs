using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class YeteneklerimRepository : RepositoryBase<Yeteneklerim>, IYeteneklerimRepository {
		public YeteneklerimRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Yeteneklerim yeteneklerim) {
			if (yeteneklerim == null) {
				throw new ArgumentNullException(nameof(yeteneklerim), "Yeteneklerim cannot be null");
			}
			Create(yeteneklerim);
		}

		public void Delete(int id) {
			if (id == 0) {
				throw new ArgumentException("ID cannot be zero", nameof(id));
			}
			Yeteneklerim? yetenek = GetOneData(o => o.Id == id, false);
			if (yetenek == null) {
				throw new KeyNotFoundException($"Yetenek with ID {id} not found");
			}
			remove(yetenek);
		}

		public IEnumerable<Yeteneklerim> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}

		public void UpdateYeteneklerim(Yeteneklerim yeteneklerim) {
			if (yeteneklerim == null) {
				throw new ArgumentNullException(nameof(yeteneklerim), "Yeteneklerim cannot be null");
			}
			if (yeteneklerim.Id == 0) {
				throw new ArgumentException("ID cannot be zero", nameof(yeteneklerim.Id));
			}
			Update(yeteneklerim);
		}
	}
}
