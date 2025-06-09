using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class SosyalMedyalarManager : ISosyalMedyalarService {
		private readonly IRepositoryManager _repositoryManager;

		public SosyalMedyalarManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddSosyalMedyaBilgi(SosyalMedyalar sosyalMedyalar) {
			if (sosyalMedyalar == null) {
				throw new ArgumentNullException(nameof(sosyalMedyalar), "Sosyal medya bilgisi boş olamaz.");
			}
			_repositoryManager.SosyalMedya.Add(sosyalMedyalar);
			_repositoryManager.Save();
		}

		public void DeleteSosyalMedyaBilgi(int id) {
			SosyalMedyalar? sosyalMedyalar = _repositoryManager.SosyalMedya.GetAll(false).FirstOrDefault(x => x.Id == id);
			if (sosyalMedyalar == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili sosyal medya bilgisi bulunamadı.");
			}
			_repositoryManager.SosyalMedya.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<SosyalMedyalar> GetSosyalMedyalarBilgileri() {
			IEnumerable<SosyalMedyalar> sosyalMedyalarBilgileri = _repositoryManager.SosyalMedya.GetAll(trackChanges: false);
			if (sosyalMedyalarBilgileri == null || !sosyalMedyalarBilgileri.Any()) {
				throw new KeyNotFoundException("Sosyal medya bilgisi bulunamadı.");
			}
			return sosyalMedyalarBilgileri;
		}

		public void UpdateSosyalMedyaBilgi(int id, SosyalMedyalar sosyalMedyalar) {
			if (sosyalMedyalar == null) {
				throw new ArgumentNullException(nameof(sosyalMedyalar), "Güncellenecek sosyal medya bilgisi boş olamaz.");
			}
			SosyalMedyalar? existingSosyalMedyalar = _repositoryManager.SosyalMedya.GetAll(true).FirstOrDefault(x => x.Id == id);
			if (existingSosyalMedyalar == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili sosyal medya bilgisi bulunamadı.");
			}
			existingSosyalMedyalar.Adi = sosyalMedyalar.Adi;
			existingSosyalMedyalar.Url = sosyalMedyalar.Url;
			existingSosyalMedyalar.Icon = sosyalMedyalar.Icon;
			existingSosyalMedyalar.Durum = sosyalMedyalar.Durum;
			existingSosyalMedyalar.SiraNo = sosyalMedyalar.SiraNo;
			_repositoryManager.SosyalMedya.UpdateSosyalMedyalar(existingSosyalMedyalar);
			_repositoryManager.Save();
		}
	}
}
