using System.Linq.Expressions;

namespace REPOSITORIES.Contracts {
	public interface IRepositoryBase<T> {
		IQueryable<T> FindAll(bool trackChanges);
		T GetOneData(Expression<Func<T, bool>> predicate, bool trackChanges);
		void Create(T entity);
		void remove(T entity);
		void Update(T entity);
	}
}
