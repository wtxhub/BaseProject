using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.DataContext
{
	public interface IUnitOfWork : IDisposable
	{
		int SaveChanges (bool acceptAllChangesOnSuccess);
		int SaveChanges ();
		Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
		Task<int> SaveChangesAsync (CancellationToken cancellationToken = new CancellationToken());
	}

	public class UnitOfWork : IUnitOfWork
	{

		private readonly IContextFactory _contextFactory;
		private readonly ApplicationDbContext _context;
		private bool _disposed;


		public UnitOfWork (IContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
			_context = _contextFactory.CreateContext<ApplicationDbContext>("dbBase2019");
		}


		public int SaveChanges (bool acceptAllChangesOnSuccess)
		{
			return _context.SaveChanges(acceptAllChangesOnSuccess);
		}

		public int SaveChanges ()
		{
			return _context.SaveChanges();
		}

		public async Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		public async Task<int> SaveChangesAsync (CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _context.SaveChangesAsync(cancellationToken);
		}


		protected virtual void Dispose (bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose ()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

	}

}