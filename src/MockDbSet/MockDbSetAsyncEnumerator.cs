using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace EntityFrameworkCore.MockDbSet
{

    internal class MockDbSetAsyncEnumerator<TEntity> : IAsyncEnumerator<TEntity>
    {
        private readonly IEnumerator<TEntity> _inner;

        internal MockDbSetAsyncEnumerator(IEnumerator<TEntity> inner)
        {
            _inner = inner ?? throw new System.ArgumentNullException(nameof(inner));
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public async Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_inner.MoveNext());
        }

        public TEntity Current
        {
            get { return _inner.Current; }
        }
    }

}
