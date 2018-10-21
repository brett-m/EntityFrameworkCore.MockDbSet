using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System;

namespace EntityFrameworkCore.MockDbSet
{
    public class MockDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IAsyncEnumerable<TEntity>
    where TEntity : class
    {
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;
        private readonly MockDbSetAsyncQueryProvider<TEntity> _queryProvier;
        private readonly MockDbSetAsyncEnumerator<TEntity> _asyncEnumerator;

        public MockDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
            _queryProvier = new MockDbSetAsyncQueryProvider<TEntity>(_query.Provider);
            _asyncEnumerator =  new MockDbSetAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }

        public MockDbSet(IEnumerable<TEntity> entities) : this()
        {
            AddRange(entities);
        }

        public new TEntity Add(TEntity entity)
        {
            _data.Add(entity);            
            return entity;
        }
        public override void AddRange( IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
                _data.Add(entity);
        }


        public new TEntity Remove(TEntity item)
        {
            _data.Remove(item);
            return item;
        }

        public new TEntity Attach(TEntity item)
        {
            _data.Add(item);
            return item;
        }

        public TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public  TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        //public override ObservableCollection<TEntity> Local
        //{
        //    get { return _data; }
        //}

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _queryProvier; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
        {
            return _asyncEnumerator;
        }
    }

}
