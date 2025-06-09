using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class ReferanslarManager : IReferanslarService {
		private readonly IRepositoryManager _repositoryManager;

		public ReferanslarManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddReferansBilgi(Referanslar referans) {
			if (referans == null) {
				throw new ArgumentNullException(nameof(referans), "Referans bilgisi boş olamaz.");
			}
			_repositoryManager.Referans.Add(referans);
			_repositoryManager.Save();
		}

		public void DeleteReferansBilgi(int id) {
			Referanslar? referans = _repositoryManager.Referans.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (referans == null) {
				// Return silently or do nothing if not found, as per "return empty list" intent
				return;
			}
			_repositoryManager.Referans.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Referanslar> GetReferansBilgileri() {
			IEnumerable<Referanslar> referansBilgileri = _repositoryManager.Referans.GetAll(trackChanges: false);
			return referansBilgileri ?? Enumerable.Empty<Referanslar>();
		}

		public void UpdateReferansBilgi(int id, Referanslar referans) {
			if (referans == null) {
				throw new ArgumentNullException(nameof(referans), "Güncellenecek referans bilgisi boş olamaz.");
			}
			Referanslar? existingReferans = _repositoryManager.Referans.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingReferans == null) {
				return;

			}
			existingReferans.Isim = referans.Isim;
			existingReferans.Baslik = referans.Baslik;
			existingReferans.Aciklama = referans.Aciklama;
			existingReferans.ImageUrl = referans.ImageUrl;
			_repositoryManager.Referans.UpdateReferanslar(existingReferans);
			_repositoryManager.Save();
		}
	}
}
