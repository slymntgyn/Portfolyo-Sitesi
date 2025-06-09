using Microsoft.EntityFrameworkCore;
using REPOSITORIES.Contracts;
using System.Linq.Expressions;

namespace REPOSITORIES {
	public abstract class RepositoryBase<T> : IRepositoryBase<T>
where T : class, new() {
		protected MyPortfolioContext _context;

		protected RepositoryBase(MyPortfolioContext context) {
			_context = context;
		}

		public void Create(T entity) {
			_context.Set<T>().Add(entity);
		}

		public IQueryable<T> FindAll(bool trackChanges) {
			return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
		}

		public T? GetOneData(Expression<Func<T, bool>> predicate, bool trackChanges) {
			return !trackChanges ? _context.Set<T>().AsNoTracking().FirstOrDefault(predicate) :
				_context.Set<T>().FirstOrDefault(predicate);

		}

		public void remove(T entity) {
			_context.Set<T>().Remove(entity);
		}

		public void Update(T entity) {
			_context.Set<T>().Update(entity);
		}
	}
}
