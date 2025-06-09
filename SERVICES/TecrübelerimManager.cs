using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class TecrübelerimManager : ITecrübelerimService {
		readonly IRepositoryManager _repositoryManager;

		public TecrübelerimManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddTecrubeBilgi(Tecrübelerim tecrube) {
			if (tecrube == null) {
				throw new ArgumentNullException(nameof(tecrube), "Tecrübe bilgisi boş olamaz.");
			}
			_repositoryManager.Tecrübelerim.Add(tecrube);
			_repositoryManager.Save();
		}

		public void DeleteTecrubeBilgi(int id) {
			Tecrübelerim? tecrube = _repositoryManager.Tecrübelerim.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (tecrube == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili tecrübe bilgisi bulunamadı.");
			}
			_repositoryManager.Tecrübelerim.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Tecrübelerim> GetTecrubeBilgileri() {
			IEnumerable<Tecrübelerim> tecrubeler = _repositoryManager.Tecrübelerim.GetAll(trackChanges: false);
			if (tecrubeler == null || !tecrubeler.Any()) {
				throw new KeyNotFoundException("Tecrübe bilgisi bulunamadı.");
			}
			return tecrubeler;
		}

		public void UpdateTecrubeBilgi(int id, Tecrübelerim tecrube) {
			if (tecrube == null) {
				throw new ArgumentNullException(nameof(tecrube), "Güncellenecek tecrübe bilgisi boş olamaz.");
			}
			Tecrübelerim? existingTecrube = _repositoryManager.Tecrübelerim.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingTecrube == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili tecrübe bilgisi bulunamadı.");
			}
			existingTecrube.Tip = tecrube.Tip;
			existingTecrube.Baslik = tecrube.Baslik;
			existingTecrube.Unvan = tecrube.Unvan;
			existingTecrube.Date = tecrube.Date;
			existingTecrube.Aciklama = tecrube.Aciklama;
			_repositoryManager.Tecrübelerim.UpdateTecrube(existingTecrube);
			_repositoryManager.Save();
		}
	}
}
