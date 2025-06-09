using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface ITecrübelerimService {
		void AddTecrubeBilgi(Tecrübelerim tecrube);
		void DeleteTecrubeBilgi(int id);
		IEnumerable<Tecrübelerim> GetTecrubeBilgileri();
		void UpdateTecrubeBilgi(int id, Tecrübelerim tecrube);
	}
}
