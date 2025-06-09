using SERVICES.Contract;

namespace SERVICES {
	public class ServiceManager : IServiceManager {
		public ServiceManager(
			IHakkindaService hakkindaService,
			IIletisimService iletisimService,
			IMesajService mesajService,
			IOzellikService ozellikService,
			IProjelerService projeService,
			IReferanslarService referansService,
			ISosyalMedyalarService sosyalMedyaService,
			ITecrübelerimService tecrubeService,
			IYeteneklerimService yetenekService,
			IAuthService authService
			) {
			this.HakindaService = hakkindaService;
			this.IletisimService = iletisimService;
			this.MesajService = mesajService;
			this.OzelllikService = ozellikService;
			this.ProjeService = projeService;
			this.ReferansService = referansService;
			this.SosyalMedyaService = sosyalMedyaService;
			this.TecrubeService = tecrubeService;
			this.YetenekService = yetenekService;
			this.AuthService = authService;
		}
		public IHakkindaService HakindaService { get; }
		public IIletisimService IletisimService { get; }
		public IMesajService MesajService { get; }
		public IOzellikService OzelllikService { get; }
		public IProjelerService ProjeService { get; }
		public IReferanslarService ReferansService { get; }
		public ISosyalMedyalarService SosyalMedyaService { get; }
		public ITecrübelerimService TecrubeService { get; }
		public IYeteneklerimService YetenekService { get; }
		public IAuthService AuthService { get; }

	}
}
