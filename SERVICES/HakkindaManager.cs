using ENTITIES.Models;
using REPOSITORIES.Contracts;
using SERVICES.Contract;

namespace SERVICES
{
    public class HakkindaManager : IHakkindaService
    {
        readonly IRepositoryManager _repositoryManager;

        public HakkindaManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void AddHakkindaBilgi(Hakkinda hakkinda)
        {
            if (hakkinda == null)
            {
                throw new ArgumentNullException(nameof(hakkinda), "Hakkında bilgisi boş olamaz.");
            }
            _repositoryManager.Hakkinda.Add(hakkinda);
            _repositoryManager.Save();
        }

        public void DeleteHakkindaBilgi(int id)
        {
            _repositoryManager.Hakkinda.Delete(id);
            _repositoryManager.Save();
        }

        public IEnumerable<Hakkinda> GetHakkindaBilgileri()
        {
            IEnumerable<Hakkinda> hakkindaBilgileri = _repositoryManager.Hakkinda.GetAll(trackChanges: false);

            // Boş ise boş liste döndür, hata fırlatma
            return hakkindaBilgileri ?? Enumerable.Empty<Hakkinda>();
        }


        public void UpdateHakkindaBilgi(int id, Hakkinda hakkinda)
        {
            if (hakkinda == null)
            {
                throw new ArgumentNullException(nameof(hakkinda), "Hakkında bilgisi boş olamaz.");
            }
            Hakkinda existingHakkinda = _repositoryManager.Hakkinda.GetById(id, trackChanges: true);
            if (existingHakkinda == null)
            {
                throw new KeyNotFoundException($"ID {id} ile ilgili hakkında bilgisi bulunamadı.");
            }
            existingHakkinda.Baslik = hakkinda.Baslik;
            existingHakkinda.AltAciklama = hakkinda.AltAciklama;
            existingHakkinda.DogumGunu = hakkinda.DogumGunu;
            existingHakkinda.Telefon = hakkinda.Telefon;
            existingHakkinda.Şehir = hakkinda.Şehir;
            existingHakkinda.Öğrenim = hakkinda.Öğrenim;
            existingHakkinda.Mail = hakkinda.Mail;
            existingHakkinda.ResimYolu = hakkinda.ResimYolu;
            _repositoryManager.Hakkinda.UpdateHakkinda(existingHakkinda);
            _repositoryManager.Save();

        }
    }
}
