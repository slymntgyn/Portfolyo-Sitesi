using ENTITIES.Models;
using REPOSITORIES.Contracts;

namespace REPOSITORIES {
	public class TecrübelerimRepository : RepositoryBase<Tecrübelerim>, ITecrübelerimRepository {
		public TecrübelerimRepository(MyPortfolioContext context) : base(context) {
		}

		public void Add(Tecrübelerim tecrübelerim) {
			if (tecrübelerim == null) {
				throw new ArgumentNullException(nameof(tecrübelerim), "Tecrübelerim cannot be null");
			}
			Create(tecrübelerim);
			_context.SaveChanges();
		}

		public void Delete(int id) {
			if (id <= 0) {
				throw new ArgumentException("ID must be greater than zero", nameof(id));
			}
			Tecrübelerim? tecrübelerim = GetOneData(t => t.Id == id, false);
			if (tecrübelerim == null) {
				throw new KeyNotFoundException($"Tecrübelerim with ID {id} not found");
			}
			remove(tecrübelerim);
			_context.SaveChanges();
		}

		public IEnumerable<Tecrübelerim> GetAll(bool trackChanges) {
			return FindAll(trackChanges).ToList();
		}


		public void UpdateTecrube(Tecrübelerim tecrübelerim) {
			if (tecrübelerim == null) {
				throw new ArgumentNullException(nameof(tecrübelerim), "Tecrübelerim cannot be null");
			}
			Tecrübelerim? existingTecrube = GetOneData(t => t.Id == tecrübelerim.Id, true);
			if (existingTecrube == null) {
				throw new KeyNotFoundException($"Tecrübelerim with ID {tecrübelerim.Id} not found");
			}
			Update(tecrübelerim);
			_context.SaveChanges();
		}
	}
}
