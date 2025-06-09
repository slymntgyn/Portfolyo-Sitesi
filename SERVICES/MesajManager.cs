using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class MesajManager : IMesajService {
		readonly IRepositoryManager _repositoryManager;

		public MesajManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddMesajBilgi(Message mesaj) {
			if (mesaj == null) {
				throw new ArgumentNullException(nameof(mesaj), "Mesaj bilgisi boş olamaz.");
			}
			_repositoryManager.Mesaj.Add(mesaj);
			_repositoryManager.Save();
		}

		public void DeleteMesajBilgi(int id) {
			Message? mesaj = _repositoryManager.Mesaj.GetAll(false).FirstOrDefault(m => m.Id == id);
			if (mesaj == null) {
				throw new KeyNotFoundException($"ID {id} ile eşleşen mesaj bulunamadı.");
			}
			_repositoryManager.Mesaj.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Message> GetAllMessages(bool trackChanges = false) {
			return _repositoryManager.Mesaj.GetAll(trackChanges);
		}

		public IEnumerable<Message> GetMesajBilgileri() {
			return _repositoryManager.Mesaj.GetAll(trackChanges: false);
		}

		public Message GetMesajById(int id, bool trackChanges = false) {
			Message? mesaj = _repositoryManager.Mesaj.GetAll(trackChanges).FirstOrDefault(m => m.Id == id);
			if (mesaj == null) {
				throw new KeyNotFoundException($"ID {id} ile eşleşen mesaj bulunamadı.");
			}
			return mesaj;
		}

		public void UpdateMesajBilgi(int id, Message mesaj) {
			if (mesaj == null) {
				throw new ArgumentNullException(nameof(mesaj), "Güncellenecek mesaj bilgisi boş olamaz.");
			}
			Message? existingMesaj = _repositoryManager.Mesaj.GetAll(true).FirstOrDefault(m => m.Id == id);
			if (existingMesaj == null) {
				throw new KeyNotFoundException($"ID {id} ile eşleşen mesaj bulunamadı.");
			}
			existingMesaj.Isim = mesaj.Isim;
			existingMesaj.Email = mesaj.Email;
			existingMesaj.Konu = mesaj.Konu;
			existingMesaj.Mesaj = mesaj.Mesaj;
			existingMesaj.GonderilmeTarihi = mesaj.GonderilmeTarihi;
			existingMesaj.IsRead = mesaj.IsRead;
			_repositoryManager.Mesaj.UpdateMesaj(existingMesaj);
			_repositoryManager.Save();
		}
	}
}
