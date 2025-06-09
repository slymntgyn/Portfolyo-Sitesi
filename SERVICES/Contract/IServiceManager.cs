namespace SERVICES.Contract {
	public interface IServiceManager {
		IHakkindaService HakindaService { get; }
		IIletisimService IletisimService { get; }
		IMesajService MesajService { get; }
		IOzellikService OzelllikService { get; }
		IProjelerService ProjeService { get; }
		IReferanslarService ReferansService { get; }
		ISosyalMedyalarService SosyalMedyaService { get; }
		ITecrübelerimService TecrubeService { get; }
		IYeteneklerimService YetenekService { get; }
		IAuthService AuthService { get; }


	}
}
