using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class RepositoryManager : IRepositoryManager {
		private readonly MyPortfolioContext _repositoryContext;

		// Updated constructor to initialize all non-nullable fields
		public RepositoryManager(
			MyPortfolioContext repositoryContext,
			IHakkindaRepository hakkindaRepository,
			IIletisimRepository iletisimRepository,
			IMesajRepository mesajRepository,
			IOzellikRepository ozellikRepository,
			IReferanslarRepository referanslarRepository,
			ISosyalMedyalarRepository sosyalMedyalarRepository,
			ITecrübelerimRepository tecrübelerimRepository,
			IYeteneklerimRepository yeteneklerimRepository,
			IProjelerRepository projelerRepository) {
			_repositoryContext = repositoryContext;
			Hakkinda = hakkindaRepository;
			Iletisim = iletisimRepository;
			Mesaj = mesajRepository;
			Ozellik = ozellikRepository;
			Referans = referanslarRepository;
			SosyalMedya = sosyalMedyalarRepository;
			Tecrübelerim = tecrübelerimRepository;
			Yetenek = yeteneklerimRepository;
			Projeler = projelerRepository;
		}

		public IHakkindaRepository Hakkinda { get; }
		public IIletisimRepository Iletisim { get; }
		public IMesajRepository Mesaj { get; }
		public IOzellikRepository Ozellik { get; }
		public IProjelerRepository Projeler { get; }
		public IReferanslarRepository Referans { get; }
		public ISosyalMedyalarRepository SosyalMedya { get; }
		public ITecrübelerimRepository Tecrübelerim { get; }
		public IYeteneklerimRepository Yetenek { get; }

		public void Save() {
			_repositoryContext.SaveChanges();
		}

		public Task SaveAsync() {
			return _repositoryContext.SaveChangesAsync();
		}
	}
}
