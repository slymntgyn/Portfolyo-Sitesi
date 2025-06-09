using ENTITIES.Models;

namespace SERVICES.Contract {
	public interface IMesajService {
		void AddMesajBilgi(Message mesaj);
		void DeleteMesajBilgi(int id);
		IEnumerable<Message> GetMesajBilgileri();
		void UpdateMesajBilgi(int id, Message mesaj);
		Message GetMesajById(int id, bool trackChanges = false);
		IEnumerable<Message> GetAllMessages(bool trackChanges = false);
	}
}
