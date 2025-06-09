using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class HakkindaRepository : RepositoryBase<Hakkinda>, IHakkindaRepository {
		public HakkindaRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Hakkinda hakkinda) {
			if (hakkinda == null) {
				throw new ArgumentNullException(nameof(hakkinda), "Lütfen geçerli değer giriniz.");
			}
			Create(hakkinda);
			_context.SaveChanges();
		}

		public void Delete(int id) {
			Hakkinda? hakkinda = GetOneData(h => h.Id == id, false);
			if (hakkinda == null) {
				throw new ArgumentNullException(nameof(hakkinda), "Lütfen geçerli değer giriniz.");
			}
			remove(hakkinda);
			_context.SaveChanges();
		}

		public IEnumerable<Hakkinda> GetAll(bool trackChangesbool) {
			return FindAll(trackChangesbool);
		}

		public Hakkinda GetById(int id, bool trackChanges) {
			Hakkinda? hakkinda = GetOneData(h => h.Id == id, trackChanges);
			if (hakkinda == null) {
				throw new KeyNotFoundException($"Hakkında bilgisi bulunamadı. ID: {id}");
			}
			return hakkinda;
		}

		public void UpdateHakkinda(Hakkinda hakkinda) {
			if (hakkinda == null) {
				throw new ArgumentNullException(nameof(hakkinda), "Lütfen geçerli değer giriniz.");
			}
			Update(hakkinda);
			_context.SaveChanges();
		}
	}
}
