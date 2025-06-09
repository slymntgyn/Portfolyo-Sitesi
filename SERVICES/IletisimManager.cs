using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES {
	public class IletisimManager : IIletisimService {
		readonly IRepositoryManager _repositoryManager;

		public IletisimManager(IRepositoryManager repositoryManager) {
			_repositoryManager = repositoryManager;
		}

		public void AddIletisimBilgi(Contact iletisim) {
			if (iletisim == null) {
				throw new ArgumentNullException(nameof(iletisim), "Iletisim bilgisi null olamaz.");
			}
			_repositoryManager.Iletisim.Add(iletisim);
			_repositoryManager.Save();
		}

		public void DeleteIletisimBilgi(int id) {
			_repositoryManager.Iletisim.Delete(id);
			_repositoryManager.Save();
		}

		public IEnumerable<Contact> GetIletisimBilgileri() {
			IEnumerable<Contact> iletisimBilgileri = _repositoryManager.Iletisim.GetAll(false);
			if (iletisimBilgileri == null || !iletisimBilgileri.Any()) {
				throw new InvalidOperationException("Iletisim bilgileri bulunamadi.");
			}
			return iletisimBilgileri;
		}

		public Contact GetIletisimById(int id, bool trackChanges = false) {
			Contact iletisim = _repositoryManager.Iletisim.GetById(id, trackChanges);
			if (iletisim == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili iletişim bilgisi bulunamadı.");
			}
			return iletisim;
		}

		public void UpdateIletisimBilgi(int id, Contact iletisim) {
			if (iletisim == null) {
				throw new ArgumentNullException(nameof(iletisim), "Iletisim bilgisi null olamaz.");
			}
			Contact existingIletisim = _repositoryManager.Iletisim.GetById(id, true);
			if (existingIletisim == null) {
				throw new KeyNotFoundException($"ID {id} ile ilgili iletişim bilgisi bulunamadı.");
			}
			existingIletisim.Baslik = iletisim.Baslik;
			existingIletisim.Aciklama = iletisim.Aciklama;
			existingIletisim.Telefon = iletisim.Telefon;
			existingIletisim.Telefon2 = iletisim.Telefon2;
			existingIletisim.Email = iletisim.Email;
			existingIletisim.Email2 = iletisim.Email2;
			existingIletisim.Adres = iletisim.Adres;
			_repositoryManager.Iletisim.UpdateIletisim(existingIletisim);
			_repositoryManager.Save();
		}
	}
}
