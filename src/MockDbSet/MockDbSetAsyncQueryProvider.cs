using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EntityFrameworkCore.MockDbSet
{
    internal class MockDbSetAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal MockDbSetAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner ?? throw new System.ArgumentNullException(nameof(inner));
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new MockDbSetAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new MockDbSetAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new MockDbSetAsyncEnumerable<TResult>(expression);
        }

        IAsyncEnumerable<TResult> IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression)
        {
            return ExecuteAsync<TResult>(expression);
        }
    }

}
