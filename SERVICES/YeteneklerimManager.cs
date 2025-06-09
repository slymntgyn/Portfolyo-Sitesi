using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class YeteneklerimManager : IYeteneklerimService {
		readonly IRepositoryManager _repositoryManager;

		public YeteneklerimManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddYetenekBilgi(Yeteneklerim yeteneklerim) {
			if (yeteneklerim == null) {
				throw new ArgumentNullException(nameof(yeteneklerim), "Yetenek bilgisi boş olamaz.");
			}
			_repositoryManager.Yetenek.Add(yeteneklerim);
			_repositoryManager.Save();
		}

		public void DeleteYetenekBilgi(int id) {
			Yeteneklerim? yetenek = _repositoryManager.Yetenek.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (yetenek == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili yetenek bilgisi bulunamadı.");
			}
			_repositoryManager.Yetenek.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Yeteneklerim> GetYetenekBilgileri() {
			IEnumerable<Yeteneklerim> yetenekler = _repositoryManager.Yetenek.GetAll(trackChanges: false);
			if (yetenekler == null || !yetenekler.Any()) {
				throw new KeyNotFoundException("Yetenek bilgisi bulunamadı.");
			}
			return yetenekler;
		}

		public void UpdateYetenekBilgi(int id, Yeteneklerim yeteneklerim) {
			if (yeteneklerim == null) {
				throw new ArgumentNullException(nameof(yeteneklerim), "Güncellenecek yetenek bilgisi boş olamaz.");
			}
			Yeteneklerim? existingYetenek = _repositoryManager.Yetenek.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingYetenek == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili yetenek bilgisi bulunamadı.");
			}
			existingYetenek.Yetenek = yeteneklerim.Yetenek;
			existingYetenek.YetenekAciklama = yeteneklerim.YetenekAciklama;
			existingYetenek.YetenekYuzde = yeteneklerim.YetenekYuzde;
			existingYetenek.YetenekIcon = yeteneklerim.YetenekIcon;
			_repositoryManager.Yetenek.UpdateYeteneklerim(existingYetenek);
			_repositoryManager.Save();
		}
	}
}
