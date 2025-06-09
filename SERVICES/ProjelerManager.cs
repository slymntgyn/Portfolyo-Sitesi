using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class ProjelerManager : IProjelerService {
		readonly IRepositoryManager _repositoryManager;

		public ProjelerManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddProjeBilgi(Projeler proje) {
			if (proje == null) {
				throw new ArgumentNullException(nameof(proje), "Proje bilgisi boş olamaz.");
			}
			_repositoryManager.Projeler.Add(proje);
			_repositoryManager.Save();
		}

		public void DeleteProjeBilgi(int id) {
			Projeler? proje = _repositoryManager.Projeler.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (proje == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili proje bilgisi bulunamadı.");
			}
			_repositoryManager.Projeler.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Projeler> GetProjeBilgileri() {
			IEnumerable<Projeler> projeler = _repositoryManager.Projeler.GetAll(trackChanges: false);
			if (projeler == null || !projeler.Any()) {
				throw new KeyNotFoundException("Proje bilgisi bulunamadı.");
			}
			return projeler;
		}

		public Projeler GetProjeById(int id) {
			Projeler? proje = _repositoryManager.Projeler.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (proje == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili proje bilgisi bulunamadı.");
			}
			return proje;
		}

		public IEnumerable<Projeler> GetProjeByKategoriId(String tip) {
			IEnumerable<Projeler> projeler = _repositoryManager.Projeler.GetAll(false).Where(x => x.Tip == tip);
			if (projeler == null || !projeler.Any()) {
				throw new KeyNotFoundException($"Kategori ID {tip} ile ilgili proje bilgisi bulunamadı.");
			}
			return projeler;
		}


		public void UpdateProjeBilgi(int id, Projeler proje) {
			if (proje == null) {
				throw new ArgumentNullException(nameof(proje), "Güncellenecek proje bilgisi boş olamaz.");
			}
			Projeler? existingProje = _repositoryManager.Projeler.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingProje == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili proje bilgisi bulunamadı.");
			}
			// UpdateProjeBilgi methodundaki ilgili alanları güncelledim:
			existingProje.Baslik = proje.Baslik;
			existingProje.Tip = proje.Tip;
			existingProje.AltBaslik = proje.AltBaslik;
			existingProje.ResimYolu = proje.ResimYolu;
			existingProje.ProjeUrl = proje.ProjeUrl;
			existingProje.Aciklama = proje.Aciklama;
			_repositoryManager.Projeler.UpdateProjeler(existingProje);
			_repositoryManager.Save();
		}
	}
}
