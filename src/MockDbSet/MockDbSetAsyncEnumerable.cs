using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkCore.MockDbSet
{
    internal class MockDbSetAsyncEnumerable<TEntity> : EnumerableQuery<TEntity>, IAsyncEnumerable<TEntity>, IQueryable<TEntity>
    {
        private readonly MockDbSetAsyncQueryProvider<TEntity> _asyncQueryProvider;
        private readonly MockDbSetAsyncEnumerator<TEntity> _asynEnumerator;

        internal MockDbSetAsyncEnumerable(IEnumerable<TEntity> enumerable)
            : base(enumerable)
        {
            if (enumerable == null)
            {
                throw new System.ArgumentNullException(nameof(enumerable));
            }

            _asyncQueryProvider = new MockDbSetAsyncQueryProvider<TEntity>(this);
            _asynEnumerator = new MockDbSetAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }

        internal MockDbSetAsyncEnumerable(Expression expression)
            : base(expression)
        {
            if (expression == null)
            {
                throw new System.ArgumentNullException(nameof(expression));
            }

            _asyncQueryProvider = new MockDbSetAsyncQueryProvider<TEntity>(this);
            _asynEnumerator = new MockDbSetAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator()
        {
            return _asynEnumerator;
        }

        public IAsyncEnumerator<TEntity> GetEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _asyncQueryProvider; }
        }
    }

}
