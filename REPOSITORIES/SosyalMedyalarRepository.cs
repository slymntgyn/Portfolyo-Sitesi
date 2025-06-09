using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class SosyalMedyalarRepository : RepositoryBase<SosyalMedyalar>, ISosyalMedyalarRepository {
		public SosyalMedyalarRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(SosyalMedyalar sosyalMedyalar) {
			if (sosyalMedyalar != null) {
				Create(sosyalMedyalar);
				_context.SaveChanges();
			}

		}

		public void Delete(int id) {
			SosyalMedyalar? sosyalMedyalar = GetOneData(x => x.Id == id, false);
			if (sosyalMedyalar != null) {
				remove(sosyalMedyalar);
				_context.SaveChanges();
			}
		}

		public IEnumerable<SosyalMedyalar> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}

		public void UpdateSosyalMedyalar(SosyalMedyalar sosyalMedyalar) {
			if (sosyalMedyalar == null) {
				throw new ArgumentNullException(nameof(sosyalMedyalar), "SosyalMedyalar cannot be null");
			}
			Update(sosyalMedyalar);
			_context.SaveChanges();
		}
	}
}
