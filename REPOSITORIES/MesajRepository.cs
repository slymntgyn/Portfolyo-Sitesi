using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class MesajRepository : RepositoryBase<Message>, IMesajRepository {
		public MesajRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Message mesaj) {
			if (mesaj == null) {
				throw new ArgumentNullException(nameof(mesaj), "Mesaj cannot be null");
			}
			Create(mesaj);
		}

		public void Delete(int id) {
			Message? mesaj = GetOneData(m => m.Id == id, false);
			if (mesaj == null) {
				throw new KeyNotFoundException($"Mesaj with ID {id} not found");
			}
			remove(mesaj);
		}

		public IEnumerable<Message> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}


		public void UpdateMesaj(Message mesaj) {
			if (mesaj == null) {
				throw new ArgumentNullException(nameof(mesaj), "Mesaj cannot be null");
			}
			Update(mesaj);
		}
	}
}
