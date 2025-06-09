using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class IletisimRepository : RepositoryBase<Contact>, IIletisimRepository {
		public IletisimRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Contact iletisim) {
			if (iletisim == null) {
				throw new ArgumentNullException(nameof(iletisim), "Contact cannot be null");
			}
			Create(iletisim);
		}

		public void Delete(int id) {
			Contact? iletisim = GetOneData(c => c.Id == id, false);
			if (iletisim == null) {
				throw new ArgumentNullException(nameof(iletisim), "Contact not found");
			}
			remove(iletisim);
			_context.SaveChanges();
		}

		public IEnumerable<Contact> GetAll(bool trackChanges) {
			return FindAll(trackChanges);
		}

		public Contact GetById(int id, bool trackChanges) {
			Contact? contact = GetOneData(c => c.Id == id, trackChanges);
			if (contact == null) {
				throw new KeyNotFoundException($"Contact with ID {id} not found");
			}
			return contact;
		}

		public void UpdateIletisim(Contact iletisim) {
			if (iletisim == null) {
				throw new ArgumentNullException(nameof(iletisim), "Contact cannot be null");
			}
			Update(iletisim);
			_context.SaveChanges();
		}
	}
}
