using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCorePostgresPersistence.Helpers.DbSetListAdapter
{
    internal class DbSetCollectionAdapter<T> : ICollection<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public DbSetCollectionAdapter(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public int Count => _dbSet.Count();

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Clear()
        {
            _dbSet.RemoveRange(_dbSet.ToList());
        }

        public bool Contains(T item)
        {
            return _dbSet.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _dbSet.ToList().CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_dbSet).GetEnumerator();
        }

        public bool Remove(T item)
        {
            var exists = _dbSet.Contains(item);
            _dbSet.Remove(item);

            return exists;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_dbSet).GetEnumerator();

            //return _dbSet.ToList().GetEnumerator();
        }
    }
}
