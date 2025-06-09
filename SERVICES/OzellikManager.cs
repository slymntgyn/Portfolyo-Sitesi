using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class OzellikManager : IOzellikService {
		readonly IRepositoryManager _repositoryManager;

		public OzellikManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddOzellikBilgi(Ozellik ozellik) {
			if (ozellik == null) {
				throw new ArgumentNullException(nameof(ozellik), "Özellik bilgisi boş olamaz.");
			}
			_repositoryManager.Ozellik.Add(ozellik);
			_repositoryManager.Save();
		}

		public void DeleteOzellikBilgi(int id) {
			Ozellik? ozellik = _repositoryManager.Ozellik.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (ozellik == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili özellik bilgisi bulunamadı.");
			}
			_repositoryManager.Ozellik.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Ozellik> GetOzellikBilgileri() {
			IEnumerable<Ozellik> ozellikler = _repositoryManager.Ozellik.GetAll(trackChanges: false);
			if (ozellikler == null || !ozellikler.Any()) {
				throw new KeyNotFoundException("Özellik bilgisi bulunamadı.");
			}
			return ozellikler;
		}

		public void UpdateOzellikBilgi(int id, Ozellik ozellik) {
			if (ozellik == null) {
				throw new ArgumentNullException(nameof(ozellik), "Güncellenecek özellik bilgisi boş olamaz.");
			}
			Ozellik? existingOzellik = _repositoryManager.Ozellik.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingOzellik == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili özellik bilgisi bulunamadı.");
			}
			existingOzellik.Baslik = ozellik.Baslik;
			existingOzellik.Aciklama = ozellik.Aciklama;
			existingOzellik.Aciklama2 = ozellik.Aciklama2;
			existingOzellik.Resim = ozellik.Resim;
			_repositoryManager.Ozellik.UpdateOzellik(existingOzellik);
			_repositoryManager.Save();
		}
	}
}
