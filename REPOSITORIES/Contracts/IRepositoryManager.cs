namespace REPOSITORIES.Contracts {
	public interface IRepositoryManager {
		IHakkindaRepository Hakkinda { get; }
		IIletisimRepository Iletisim { get; }
		IMesajRepository Mesaj { get; }
		IOzellikRepository Ozellik { get; }
		IProjelerRepository Projeler { get; }
		IReferanslarRepository Referans { get; }
		ISosyalMedyalarRepository SosyalMedya { get; }
		ITecrübelerimRepository Tecrübelerim { get; }
		IYeteneklerimRepository Yetenek { get; }
		void Save();
		Task SaveAsync();
	}
}
